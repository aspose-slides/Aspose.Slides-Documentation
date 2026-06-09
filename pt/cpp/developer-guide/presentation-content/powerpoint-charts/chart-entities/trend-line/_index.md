---
title: Adicionar linhas de tendência a gráficos de apresentação em C++
linktitle: Linha de tendência
type: docs
url: /pt/cpp/trend-line/
keywords:
- gráfico
- linha de tendência
- linha de tendência exponencial
- linha de tendência linear
- linha de tendência logarítmica
- linha de tendência de média móvel
- linha de tendência polinomial
- linha de tendência de potência
- linha de tendência personalizada
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Adicione e personalize rapidamente linhas de tendência em gráficos do PowerPoint com Aspose.Slides para C++ — um guia prático para envolver seu público."
---
## **Visão geral**

Este artigo explica como adicionar linhas de tendência a gráficos de apresentação usando Aspose.Slides. Ele mostra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linha de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e potência.

Também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui um breve FAQ sobre valores de projeção de linha de tendência avançada e retroativa e se as linhas de tendência são preservadas durante a exportação para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar uma linha de tendência**
Aspose.Slides for C++ fornece uma API simples para gerenciar diferentes linhas de tendência de gráficos:

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um gráfico com dados padrão juntamente com qualquer tipo desejado (este exemplo usa ChartType.ClusteredColumn).
4. Adicione a linha de tendência exponencial para a série 1 do gráfico.
5. Adicione a linha de tendência linear para a série 1 do gráfico.
6. Adicione a linha de tendência logarítmica para a série 2 do gráfico.
7. Adicione a linha de tendência de média móvel para a série 2 do gráfico.
8. Adicione a linha de tendência polinomial para a série 3 do gráfico.
9. Adicione a linha de tendência de potência para a série 3 do gráfico.
10. Grave a apresentação modificada em um arquivo PPTX.

O código a seguir é usado para criar um gráfico com linhas de tendência.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Adicionar uma linha personalizada**
Aspose.Slides for C++ fornece uma API simples para adicionar linhas personalizadas em um gráfico. Para adicionar uma linha simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da classe Presentation
- Obtenha a referência de um slide usando seu Índice
- Crie um novo gráfico usando o método AddChart exposto pelo objeto Shapes
- Adicione um AutoShape do tipo Linha usando o método AddAutoShape exposto pelo objeto Shapes
- Defina a Cor das linhas da forma.
- Grave a apresentação modificada como um arquivo PPTX

O código a seguir é usado para criar um gráfico com linhas personalizadas.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**O que significam 'forward' e 'backward' em uma linha de tendência?**

Eles são os comprimentos da linha de tendência projetados para frente/para trás: para gráficos de dispersão (XY) — em unidades do eixo; para gráficos que não são de dispersão — em número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. Aspose.Slides converte apresentações para [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/pt/cpp/render-a-slide-as-an-svg-image/) e renderiza gráficos como imagens; as linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Também há um método disponível para [exportar uma imagem do gráfico](/slides/pt/cpp/create-shape-thumbnails/) em si.