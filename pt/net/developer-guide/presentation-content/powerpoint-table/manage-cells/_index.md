---
title: Gerenciar células de tabela em apresentações em .NET
linktitle: Gerenciar Células
type: docs
weight: 30
url: /pt/net/manage-cells/
keywords:
- célula de tabela
- mesclar células
- remover borda
- dividir célula
- imagem na célula
- cor de fundo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie células de tabela do PowerPoint em C#: identifique células mescladas, remova bordas, divida células e defina cores de fundo e imagens com Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabelas em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas de células, trabalhar com numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula por meio das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

Aspose.Slides usa índices baseados em zero para acessar células de tabela na ordem `(column, row)`.

## **Identificar uma Célula de Tabela Mesclada**

O exemplo abre uma apresentação existente e acessa a primeira forma no primeiro slide como uma tabela. Ele assume que o slide e a forma existem e que a forma é uma tabela. Em seguida, itera por todas as linhas e colunas e usa [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) para identificar células em regiões mescladas. Para cada correspondência, ele imprime as coordenadas da célula na ordem `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), e as coordenadas iniciais da região, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) e [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Remover Bordas de Células da Tabela**

Crie uma [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e adicione uma tabela ao seu primeiro slide com [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Larguras de coluna, alturas de linha e a posição da tabela são especificadas em pontos. O exemplo define todas as quatro bordas da célula como [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), tornando-as invisíveis.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Adicionar Bordas Diagonais à Célula**

Use [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) para desenhar uma linha do canto superior esquerdo ao canto inferior direito, e [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) para desenhar uma linha do canto inferior esquerdo ao canto superior direito. Uma diagonal pode marcar um cabeçalho de canto; ambas as diagonais podem formar um X para marcar a célula como não aplicável.

Cada diagonal é um [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). Em seu [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/), defina [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) como [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) e escolha um [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Defina a [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) da linha em pontos.

O exemplo cria três células em uma linha: uma diagonal vermelha descendente, uma diagonal azul ascendente e ambas as diagonais. Ele mantém as bordas superior, inferior, esquerda e direita da célula inalteradas.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Uma diagonal é uma propriedade de formatação, não uma divisão de célula. Cada célula mantém um único [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); as regiões em cada lado de uma diagonal não podem ser editadas independentemente.

![Três células de tabela mostrando uma diagonal vermelha do canto superior esquerdo ao canto inferior direito, uma diagonal azul do canto inferior esquerdo ao canto superior direito e ambas as diagonais formando um X.](diagonal-cell-borders.png)

*Da esquerda para a direita: diagonal descendente (vermelha, 3 pt), diagonal ascendente (azul, 5 pt) e ambas as diagonais.*

## **Mesclar Células da Tabela**

Use [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) para combinar um intervalo retangular de células da tabela em uma única célula. Especifique as células nos cantos superior esquerdo e inferior direito do intervalo. O argumento final controla se a mesclagem pode incluir células fora do intervalo especificado; `false` mantém a mesclagem dentro desse intervalo.

O exemplo cria uma tabela 4 × 4 com colunas e linhas de 70 pontos, então mescla as quatro células centrais de `(1, 1)` até `(2, 2)`. A célula resultante abrange duas colunas e duas linhas, enquanto a grade subjacente da tabela permanece com quatro colunas e quatro linhas. Para acessar o conteúdo ou a formatação da célula mesclada, use sua posição superior esquerda: `table[1, 1]` neste exemplo. As demais posições no intervalo mesclado permanecem parte da grade da tabela, portanto os índices das células fora do intervalo não mudam.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Dividir Células da Tabela**

Mesclar células no exemplo anterior preserva a grade da tabela. Dividir uma célula pode introduzir uma nova coluna na grade e mudar os índices de coluna das células à sua direita. Aspose.Slides segue o modelo de grade de tabelas do PowerPoint.

Este exemplo cria uma tabela 4 × 4 com colunas e linhas de 70 pontos e chama [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) na célula `(1, 1)`. Metade da largura de 70 pontos da célula é passada para criar duas células de largura igual.

Após essa divisão, as duas metades são acessadas como `table[1, 1]` e `table[2, 1]`. A grade da tabela agora tem cinco colunas: as células originalmente nas colunas 2 e 3 movem‑se para as colunas 3 e 4, respectivamente. Os índices de linha permanecem inalterados. Use esses índices de coluna atualizados ao acessar células após a divisão.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Dividir Células Mescladas por Extensão de Linha ou de Coluna**

Para preparar células‑modelo mescladas para preenchimento de dados, use [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) para dividir ao longo de um limite de linha existente, ou [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) para dividir ao longo de um limite de coluna.

O argumento `index` conta linhas na parte superior ou colunas na parte esquerda da divisão; ele é relativo à região mesclada:

- Divisão de linha: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Divisão de coluna: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

O exemplo pressupõe que a apresentação tenha uma tabela como primeira forma no primeiro slide, com `(1, 2)` e `(1, 3)` mesclados verticalmente. Começando a partir da posição inferior, ele usa [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) e [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) para localizar a origem e verifica ambas as extensões. `SplitByRowSpan(1)` então separa as linhas 2 e 3 para nomes de produtos. Para uma mesclagem horizontal de duas colunas, use `SplitByColSpan(1)` em vez disso.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Recupere as células resultantes da tabela após a divisão.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

A grade da tabela e os índices das células ao redor permanecem inalterados. Recupere as células resultantes pelas suas coordenadas; aqui, ambas têm extensão 1 e [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) imprime `False`. Regiões maiores podem permanecer parcialmente mescladas após uma única divisão.

O texto original e sua formatação permanecem na célula superior (ou esquerda); a nova célula está vazia, mas herda a formatação da célula, como preenchimento, bordas e margens. Preencha as células após a divisão e defina explicitamente qualquer formatação de texto necessária.

A apresentação salva contém células separadas “Product A” e “Product B” com a formatação da célula do modelo mantida. Consulte a [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) para detalhes.

<!-- visual-explanation:manage-cells:start -->
[![A célula mesclada na coluna 1, linhas 2 e 3 se divide em Product A e Product B com os mesmos índices de grade.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*A divisão por extensão de linha usa o limite existente. Product A e Product B ocupam (1, 2) e (1, 3), respectivamente.*
<!-- visual-explanation:manage-cells:end -->

### **Dividir uma Célula em uma Altura Específica**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) recebe a altura da parte superior em pontos. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) recebe o número de linhas da grade existentes na parte superior. Para centralizar uma célula de 40 pontos na coluna da direita, subtraia 40 da altura real da célula e divida o espaço restante igualmente acima e abaixo dela.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

A primeira divisão adiciona uma linha à grade, deixando os 90 pontos inferiores em `[1, 1]`. A segunda divisão tem como alvo essa célula e adiciona outra linha abaixo dela. A coluna da direita agora contém `[1, 0]` com 50 pontos (`margin`), `[1, 1]` com 40 pontos e `[1, 2]` com 50 pontos (`margin`). A célula esquerda abrange as três linhas com sua altura original de 140 pontos.

![A célula esquerda abrange toda a altura da tabela ao lado de três células com Middle no centro.](split-by-height.png)

## **Alterar a Cor de Fundo da Célula da Tabela**

Este exemplo cria uma tabela com colunas de 150 pontos e linhas de 50 pontos. Ele define [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) como sólido e [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) como vermelho para a célula `(2, 3)`, na terceira coluna e quarta linha.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Adicionar uma Imagem Dentro de uma Célula de Tabela**

Coloque a imagem de entrada no diretório de trabalho antes de executar este exemplo. Ela carrega a imagem com [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) e a adiciona à coleção de imagens da apresentação com [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Em seguida, atribui a imagem ao preenchimento de imagem da célula `(0, 0)`, a primeira célula da tabela.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) estica a imagem para preencher a célula, o que pode alterar sua proporção. Larguras de coluna e alturas de linha estão em pontos. A imagem carregada é descartada automaticamente pela declaração using.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **Perguntas Frequentes**

**Posso definir espessuras e estilos de linha diferentes para lados diferentes de uma única célula?**

Sim. As bordas [superior](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[inferior](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[esquerda](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[direita](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) têm propriedades separadas, portanto a espessura e o estilo de cada lado podem ser diferentes.

**O que acontece com a imagem se eu mudar o tamanho da coluna/linha depois de definir uma imagem como plano de fundo da célula?**

O comportamento depende do [modo de preenchimento](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Com esticamento, a imagem se ajusta à nova célula; com ladrilhamento, os ladrilhos são recalculados.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/net/manage-hyperlinks/) são definidos no nível do texto (porção) dentro do quadro de texto da célula ou no nível da tabela/forma inteira. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. O quadro de texto de uma célula suporta [porções](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) com formatação independente — família da fonte, estilo, tamanho e cor.