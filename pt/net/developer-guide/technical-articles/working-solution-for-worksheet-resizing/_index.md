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
description: "Corrija o redimensionamento OLE de planilhas Excel em apresentações: duas maneiras de manter as molduras de objetos consistentes — escalando a moldura ou a planilha — nos formatos PPT e PPTX."
---
{{% alert color="info" %}} 

Foi observado que planilhas Excel incorporadas como objetos OLE em uma apresentação PowerPoint por meio dos componentes Aspose são redimensionadas para uma escala não identificada após a primeira ativação. Esse comportamento gera uma diferença visual perceptível na apresentação entre os estados pré‑ e pós‑ativação do objeto OLE. Investigamos esse problema em detalhe e fornecemos uma solução, que é abordada neste artigo.

{{% /alert %}} 

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/net/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação PowerPoint usando Aspose.Slides for .NET. Para resolver o [problema de visualização do objeto](/slides/pt/net/object-preview-issue-when-adding-oleobjectframe/), atribuimos uma imagem da área da planilha selecionada à moldura do objeto OLE. Na apresentação resultante, ao clicar duas vezes na moldura OLE que exibe a imagem da planilha, a pasta de trabalho Excel é ativada. Os usuários podem fazer as alterações desejadas na pasta de trabalho Excel real e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho da moldura OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho da moldura OLE e da pasta de trabalho Excel incorporada. 

## **Causa do Redimensionamento**

Como a pasta de trabalho Excel possui seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, a moldura OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela Excel e o tamanho e posição da moldura OLE. 

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensionar o tamanho da moldura OLE na apresentação PowerPoint para corresponder à altura e largura do número desejado de linhas e colunas na moldura OLE.  
- Manter o tamanho da moldura OLE constante e redimensionar o tamanho das linhas e colunas participantes para caber dentro do tamanho da moldura OLE selecionada.  

### **Redimensionar o Tamanho da Moldura OLE**

Nesta abordagem, aprenderemos como definir o tamanho da moldura OLE da pasta de trabalho Excel incorporada para corresponder ao tamanho cumulativo das linhas e colunas participantes na planilha Excel.

Suponha que tenhamos uma planilha Excel modelo e queiramos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, o tamanho da moldura OLE será primeiro calculado com base nas alturas cumulativas das linhas e larguras cumulativas das colunas participantes na pasta de trabalho. Em seguida, definiremos o tamanho da moldura OLE para esse valor calculado. Para evitar a mensagem vermelha “EMBEDDED OLE OBJECT” na moldura OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

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

// Defina o tamanho exibido quando o arquivo da pasta de trabalho for usado como objeto OLE no PowerPoint.
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

Nesta abordagem, aprenderemos como redimensionar as alturas das linhas participantes e a largura das colunas participantes para corresponder a um tamanho de moldura OLE personalizado.

Suponha que tenhamos uma planilha Excel modelo e queiramos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, definiremos o tamanho da moldura OLE e redimensionaremos o tamanho das linhas e colunas que participam da área da moldura OLE. Em seguida, salvaremos a pasta de trabalho em um fluxo para aplicar as alterações e convertê‑la em um array de bytes para adicioná‑la à moldura OLE. Para evitar a mensagem vermelha “EMBEDDED OLE OBJECT” na moldura OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

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

// Defina o tamanho exibido quando o arquivo da pasta de trabalho for usado como objeto OLE no PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Escale a faixa de células para caber no tamanho da moldura.
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

{{% alert color="info" %}}

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. A escolha da abordagem apropriada depende dos requisitos específicos e do caso de uso. Ambas as abordagens funcionam da mesma forma, seja para apresentações criadas a partir de um modelo ou do zero. Além disso, não há limite para o tamanho da moldura OLE nesta solução.

{{% /alert %}}

## **Perguntas Frequentes**

### Por que uma planilha Excel incorporada muda de tamanho ao ser ativada pela primeira vez no PowerPoint?
Isso ocorre porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto a moldura OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

### É possível impedir totalmente esse problema de redimensionamento?
Sim. Redimensionando a moldura OLE para se ajustar ao tamanho da faixa de células Excel ou redimensionando a faixa de células para se ajustar ao tamanho desejado da moldura OLE, é possível prevenir o redimensionamento indesejado.

### Qual método de escalonamento devo usar, escalonamento da moldura OLE ou escalonamento da faixa de células?
Selecione **escalonamento da moldura OLE** se desejar manter os tamanhos originais das linhas e colunas Excel. Se preferir um tamanho fixo para a moldura OLE na apresentação, escolha **escalonamento da faixa de células**.

### Essas soluções funcionarão se minha apresentação for baseada em um modelo?
Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

### Existe um limite para o tamanho da moldura OLE ao usar esses métodos?
Não. Você pode definir a moldura OLE em qualquer tamanho, contanto que ajuste a escala adequadamente.

### Existe uma maneira de evitar o texto de espaço reservado "EMBEDDED OLE OBJECT" no PowerPoint?
Sim. Capturando uma captura da faixa de células Excel alvo e definindo‑a como imagem de espaço reservado da moldura OLE, você pode exibir uma imagem de pré‑visualização personalizada no lugar do placeholder padrão.

## **Artigos Relacionados**

[Criando um Gráfico Excel e Incorporando‑o em uma Apresentação como Objeto OLE](/slides/pt/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Atualizando Objetos OLE Automaticamente Usando um Complemento do MS PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)