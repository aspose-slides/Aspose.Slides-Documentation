---
title: Gerenciar Células de Tabela em Apresentações no .NET
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
description: "Gerencie células de tabelas do PowerPoint em C#: identifique células mescladas, remova bordas, divida células e defina cores de fundo e imagens com Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabela em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas de células, trabalhar com a numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula através das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

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

## **Remover Bordas de Célula de Tabela**

Crie uma [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e adicione uma tabela ao seu primeiro slide com [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). As larguras das colunas, as alturas das linhas e a posição da tabela são especificadas em pontos. O exemplo define todas as quatro bordas da célula como [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), tornando-as invisíveis.

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

## **Mesclar Células de Tabela**

Use [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) para combinar um intervalo retangular de células de tabela em uma única célula. Especifique as células nos cantos superior esquerdo e inferior direito do intervalo. O argumento final controla se a mesclagem pode incluir células fora do intervalo especificado; `false` mantém a mesclagem dentro desse intervalo.

O exemplo cria uma tabela 4 × 4 com colunas e linhas de 70 pontos, então mescla as quatro células centrais de `(1, 1)` até `(2, 2)`. A célula resultante abrange duas colunas e duas linhas, enquanto a grade subjacente da tabela mantém quatro colunas e quatro linhas. Para acessar o conteúdo ou a formatação da célula mesclada, use sua posição superior esquerda: `table[1, 1]` neste exemplo. As demais posições no intervalo mesclado permanecem parte da grade da tabela, portanto os índices das células fora do intervalo não mudam.

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

## **Dividir Células de Tabela**

Mesclar células no exemplo anterior preserva a grade da tabela. Dividir uma célula pode introduzir uma nova coluna na grade e alterar os índices de coluna das células à sua direita. Aspose.Slides segue o modelo de grade de tabelas do PowerPoint.

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

### **Dividir Células Mescladas por Alcance de Linha ou Coluna**

Para preparar células de modelo mescladas para preenchimento de dados, use [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) para dividir ao longo de um limite de linha existente, ou [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) para dividir ao longo de um limite de coluna.

O argumento `index` conta linhas na parte superior ou colunas na parte esquerda da divisão; ele é relativo à região mesclada:

- Divisão de linha: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Divisão de coluna: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

O exemplo pressupõe que uma apresentação tenha uma tabela como a primeira forma no primeiro slide, com `(1, 2)` e `(1, 3)` mesclados verticalmente. Começando a partir da posição inferior, ele usa [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) e [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) para localizar a origem e verifica ambos os alcances. `SplitByRowSpan(1)` então separa as linhas 2 e 3 para nomes de produtos. Para uma mesclagem horizontal de duas colunas, use `SplitByColSpan(1)` em vez disso.

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

A grade da tabela e os índices das células circundantes permanecem inalterados. Recupere as células resultantes por suas coordenadas; aqui, ambas têm alcance 1 e [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) imprime `False`. Regiões maiores podem permanecer parcialmente mescladas após uma divisão.

O texto original e sua formatação permanecem na célula superior (ou esquerda); a nova célula fica vazia, porém herda a formatação da célula, como preenchimento, bordas e margens. Popule as células após a divisão e defina explicitamente qualquer formatação de texto necessária.

A apresentação salva contém células separadas “Product A” e “Product B” com a formatação de célula do modelo mantida. Consulte a [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) para obter detalhes.

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

Coloque a imagem de entrada no diretório de trabalho antes de executar este exemplo. Ele carrega a imagem com [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) e a adiciona à coleção de imagens da apresentação com [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Em seguida, atribui a imagem ao preenchimento de imagem da célula `(0, 0)`, a primeira célula da tabela.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) estica a imagem para preencher a célula, o que pode alterar sua proporção. As larguras das colunas e as alturas das linhas são em pontos. A imagem carregada é descartada automaticamente pela sua declaração using.

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

**Posso definir diferentes espessuras e estilos de linha para diferentes lados de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) têm propriedades separadas, portanto a espessura e o estilo de cada lado podem ser diferentes.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha após definir uma imagem como plano de fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Com estiramento, a imagem se ajusta à nova célula; com mosaico, os mosaicos são recalculados.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/net/manage-hyperlinks/) são definidos no nível do texto (porção) dentro da caixa de texto da célula ou no nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. A caixa de texto de uma célula suporta [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (execuções) com formatação independente—família da fonte, estilo, tamanho e cor.