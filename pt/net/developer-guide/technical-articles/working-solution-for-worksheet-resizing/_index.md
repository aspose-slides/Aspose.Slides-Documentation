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
description: "Corrija o redimensionamento de OLE de planilha do Excel em apresentações: duas maneiras de manter os quadros de objeto consistentes — escale o quadro ou a planilha — nos formatos PPT e PPTX."
---
{{% alert color="primary" %}} 

Foi observado que as planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint por meio dos componentes Aspose são redimensionadas para uma escala não identificada após a primeira ativação. Esse comportamento cria uma diferença visual notável na apresentação entre os estados antes e depois da ativação do objeto OLE. Investigamos esse problema em detalhes e fornecemos uma solução, que está descrita neste artigo.

{{% /alert %}} 

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/net/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides para .NET. Para resolver o [problema de visualização do objeto](/slides/pt/net/object-preview-issue-when-adding-oleobjectframe/), atribuimos uma imagem da área da planilha selecionada à moldura do objeto OLE. Na apresentação gerada, ao clicar duas vezes na moldura do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer quaisquer alterações desejadas na pasta de trabalho real do Excel e então retornar ao slide clicando fora da pasta de trabalho Excel ativada. O tamanho da moldura do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho da moldura do objeto OLE e da pasta de trabalho do Excel incorporada. 

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel possui seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, a moldura do objeto OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e posição da moldura do objeto OLE. 

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensionar o tamanho da moldura OLE na apresentação do PowerPoint para corresponder à altura e largura do número desejado de linhas e colunas na moldura OLE.
- Manter o tamanho da moldura OLE constante e redimensionar o tamanho das linhas e colunas participantes para caber dentro do tamanho da moldura OLE selecionada.

### **Redimensionar o Tamanho da Moldura OLE**

Nesta abordagem, aprenderemos como definir o tamanho da moldura OLE da pasta de trabalho do Excel incorporada para corresponder ao tamanho cumulativo das linhas e colunas participantes na planilha do Excel.

Suponha que temos uma planilha modelo do Excel e queremos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, o tamanho da moldura do objeto OLE será primeiro calculado com base nas alturas cumulativas das linhas e larguras das colunas das linhas e colunas participantes no workbook. Em seguida, definiremos o tamanho da moldura OLE para esse valor calculado. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" na moldura OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas no workbook e a definiremos como imagem da moldura OLE.

```cs
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

// Obtenha a largura e altura da imagem OLE em pontos.
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

Suponha que temos uma planilha modelo do Excel e queremos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, definiremos o tamanho da moldura OLE e redimensionaremos o tamanho das linhas e colunas que participam da área da moldura OLE. Em seguida, salvaremos a pasta de trabalho em um stream para aplicar as alterações e convertê‑la em um array de bytes para adicioná‑la à moldura OLE. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" na moldura OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas no workbook e a definiremos como imagem da moldura OLE.

```cs
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

{{% alert color="primary" %}}

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. A escolha da abordagem apropriada depende dos requisitos específicos e do caso de uso. Ambas as abordagens funcionam da mesma forma, tanto para apresentações criadas a partir de um modelo quanto do zero. Além disso, não há limite para o tamanho da moldura do objeto OLE nesta solução.

{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha do Excel incorporada altera o tamanho quando é ativada pela primeira vez no PowerPoint?**  
Isso acontece porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto a moldura do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção da imagem, o que pode causar o redimensionamento.

**É possível evitar completamente esse problema de redimensionamento?**  
Sim. Redimensionando a moldura OLE para caber ao tamanho da faixa de células do Excel ou redimensionando a faixa de células para caber ao tamanho desejado da moldura OLE, você pode impedir o redimensionamento indesejado.

**Qual método de redimensionamento devo usar, redimensionamento da moldura OLE ou da faixa de células?**  
Selecione **redimensionamento da moldura OLE** se você quiser manter os tamanhos originais das linhas e colunas do Excel. Selecione **redimensionamento da faixa de células** se desejar um tamanho fixo para a moldura OLE em sua apresentação.

**Essas soluções funcionarão se minha apresentação for baseada em um modelo?**  
Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho da moldura OLE ao usar esses métodos?**  
Não. Você pode definir a moldura do objeto OLE em qualquer tamanho, desde que ajuste a escala adequadamente.

**Existe uma forma de evitar o texto de espaço reservado "EMBEDDED OLE OBJECT" no PowerPoint?**  
Sim. Capturando uma captura de tela da faixa de células do Excel alvo e definindo‑a como a imagem de espaço reservado da moldura OLE, você pode exibir uma imagem de pré‑visualização personalizada em vez do espaço reservado padrão.

## **Artigos Relacionados**

[Criando um Gráfico do Excel e Incorporando‑o em uma Apresentação como um Objeto OLE](/slides/pt/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Atualizando Objetos OLE Automaticamente Usando um Add‑In do MS PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)