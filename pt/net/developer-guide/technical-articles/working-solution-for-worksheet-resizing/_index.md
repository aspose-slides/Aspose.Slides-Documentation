---
title: Solução Funcional para Redimensionamento de Planilha
type: docs
weight: 40
url: /pt/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Corrija o redimensionamento OLE de planilhas do Excel em apresentações: duas maneiras de manter as molduras de objetos consistentes—escalando a moldura ou a planilha—nos formatos PPT e PPTX."
---
{{% alert color="info" title="Note" %}}

Planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint usando componentes Aspose podem redimensionar inesperadamente após a primeira ativação. Esse comportamento cria uma diferença visual perceptível entre o objeto OLE antes e depois da ativação. Este artigo explica o problema e descreve duas formas de resolvê‑lo.

{{% /alert %}} 

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/net/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides for .NET. Para resolver o [problema de visualização do objeto](/slides/pt/net/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área da planilha selecionada à moldura do objeto OLE. Na apresentação de saída, ao clicar duas vezes na moldura do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer as alterações desejadas na pasta de trabalho real do Excel e então retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho da moldura do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho da moldura do objeto OLE e da pasta de trabalho do Excel incorporada. 

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel tem seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, a moldura do objeto OLE tem seu próprio tamanho. De acordo com a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e posição da moldura do objeto OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensionar a moldura OLE na apresentação do PowerPoint para corresponder à altura total e largura das linhas e colunas selecionadas.
- Manter o tamanho da moldura OLE constante e redimensionar as linhas e colunas selecionadas para caber dentro dela.

### **Redimensionar o Tamanho da Moldura OLE**

Esta abordagem define o tamanho da moldura OLE para corresponder à altura total e à largura das linhas e colunas selecionadas na planilha do Excel incorporada.

O exemplo carrega uma pasta de trabalho do Excel existente e seleciona as primeiras 10 linhas e 13 colunas da primeira planilha usando índices baseados em zero. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) define o intervalo exibido. A visualização é renderizada a 96 DPI, e suas dimensões em pixels são convertidas para pontos usando 72 pontos por polegada. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) incorpora a pasta de trabalho modificada em uma moldura com essas dimensões. A visualização é atribuída através de [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) para substituir o marcador “EMBEDDED OLE OBJECT” na apresentação salva.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Define o tamanho exibido quando o arquivo da pasta de trabalho é usado como objeto OLE no PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Obtenha a largura e a altura da imagem OLE em pontos.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Precisamos usar a pasta de trabalho modificada.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Adicione a imagem OLE aos recursos da apresentação.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Crie a moldura do objeto OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

O auxiliar de visualização define [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) para o intervalo selecionado e remove margens, cabeçalhos e rodapés. Com [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) habilitado, [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) renderiza o intervalo como uma imagem PNG. O auxiliar rebobina o fluxo de imagem antes de retorná‑lo para uso na apresentação.

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Redimensionar o Tamanho da Faixa de Células**

Esta abordagem redimensiona as alturas das linhas selecionadas e as larguras das colunas selecionadas para corresponder a um tamanho de moldura OLE personalizado.

O exemplo carrega uma pasta de trabalho do Excel existente e seleciona as primeiras 10 linhas e 13 colunas da primeira planilha usando índices baseados em zero. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) define o intervalo exibido, e o auxiliar abaixo redimensiona esse intervalo para caber em uma moldura de 400 pontos de largura por 100 pontos de altura. Após salvar a pasta de trabalho modificada em um fluxo, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) a incorpora no tamanho especificado. Uma visualização renderizada a 96 DPI é atribuída através de [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), de modo que a apresentação salva exiba as células selecionadas em vez do marcador padrão.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Defina o tamanho exibido quando o arquivo da pasta de trabalho é usado como objeto OLE no PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Redimensione a faixa de células para caber no tamanho da moldura.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Precisamos usar a pasta de trabalho modificada.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Adicione a imagem OLE aos recursos da apresentação.
var oleImage = presentation.Images.AddImage(imageStream);

// Crie a moldura do objeto OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

O auxiliar de redimensionamento calcula proporções separadas de largura e altura para o intervalo selecionado, preservando as larguras relativas de suas colunas e as alturas relativas de suas linhas. Converte as dimensões calculadas de pontos para polegadas antes de aplicá‑las com [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) e [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). O intervalo selecionado deve ter largura e altura diferentes de zero.

```cs
/// <param name="width">A largura esperada da faixa de células em pontos.</param>
/// <param name="height">A altura esperada da faixa de células em pontos.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Este auxiliar de visualização renderiza o intervalo redimensionado usando [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Ele limita [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) a esse intervalo, remove margens, cabeçalhos e rodapés e devolve um fluxo PNG posicionado no início.

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Conclusão**

{{% alert color="info" title="Note" %}}

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. Escolha a abordagem que melhor se adapta aos seus requisitos e caso de uso. Ambas as abordagens funcionam da mesma maneira, seja a apresentação criada a partir de um modelo ou do zero. Além disso, não há limite para o tamanho da moldura do objeto OLE nesta solução.

{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha do Excel incorporada muda de tamanho quando é ativada pela primeira vez no PowerPoint?**

Isso ocorre porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto a moldura do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir completamente esse problema de redimensionamento?**

Sim. Redimensionando a moldura OLE para caber no tamanho da faixa de células do Excel ou redimensionando a faixa de células para caber no tamanho desejado da moldura OLE, você pode evitar redimensionamentos indesejados.

**Qual método de redimensionamento devo usar, redimensionamento da moldura OLE ou da faixa de células?**

Selecione **redimensionamento da moldura OLE** se quiser manter os tamanhos originais das linhas e colunas do Excel. Selecione **redimensionamento da faixa de células** se preferir um tamanho fixo para a moldura OLE na apresentação.

**Essas soluções funcionam se minha apresentação for baseada em um modelo?**

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e a partir do zero.

**Existe um limite para o tamanho da moldura OLE ao usar esses métodos?**

Não. Você pode definir a moldura do objeto OLE em qualquer tamanho, contanto que ajuste a escala adequadamente.

**Há como evitar o texto de marcador “EMBEDDED OLE OBJECT” no PowerPoint?**

Sim. Capturando uma imagem da faixa de células do Excel alvo e definindo‑a como imagem de marcador da moldura OLE, você pode exibir uma imagem de visualização personalizada no lugar do marcador padrão.

## **Artigos Relacionados**

[Criando um Gráfico do Excel e Incorporando‑o em uma Apresentação como um Objeto OLE](/slides/pt/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Atualizando Objetos OLE Automaticamente Usando um Add‑In do MS PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)