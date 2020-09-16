﻿using System;
using tabuleiro;
using xadrez;
using xadrez_console.tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            PartidaDeXadrex partida = new PartidaDeXadrex();

            while (!partida.terminada)
            {

                try
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.WriteLine("");
                    Console.WriteLine("Turno: " + partida.turno);
                    Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                    Console.WriteLine("");
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoCXadrez().toPosicao();
                    partida.validarPosicaoDeOrigem(origem);

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();


                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine("");
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoCXadrez().toPosicao();
                    partida.validarPosicaoDeDestino(origem, destino);

                    partida.realizaJogada(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();

            }
        }
    }
}
