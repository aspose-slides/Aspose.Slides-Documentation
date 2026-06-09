---
title: Solução Funcional para Redimensionamento de Planilha
type: docs
weight: 20
url: /pt/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de pré-visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Corrija o redimensionamento de OLE de planilha Excel em apresentações: duas maneiras de manter as molduras de objetos consistentes — escale a moldura ou a planilha — nos formatos PPT e PPTX."
---
{{% alert color="primary" %}}

Foi observado que as planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint através dos componentes Aspose são redimensionadas para uma escala não identificada após a primeira ativação. Esse comportamento cria uma diferença visual perceptível na apresentação entre os estados pré‑ e pós‑ativação do objeto OLE. Investigamos esse problema em detalhe e fornecemos uma solução, que está descrita neste artigo.

{{% /alert %}}

## **Contexto**

No artigo [Manage OLE](/slides/pt/androidjava/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides for Android via Java. Para resolver o [object preview issue](/slides/pt/androidjava/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área da planilha selecionada à moldura do objeto OLE. Na apresentação de saída, ao clicar duas vezes na moldura do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer quaisquer alterações desejadas na pasta de trabalho real do Excel e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho da moldura do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho da moldura do objeto OLE e da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel tem seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, a moldura do objeto OLE tem seu próprio tamanho. De acordo com a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e posição da moldura do objeto OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensionar a moldura OLE na apresentação do PowerPoint para corresponder à altura e largura do número desejado de linhas e colunas na moldura OLE.
- Manter o tamanho da moldura OLE constante e redimensionar o tamanho das linhas e colunas participantes para caber dentro do tamanho escolhido da moldura OLE.

### **Redimensionar o Tamanho da Moldura OLE**

Nesta abordagem, aprenderemos como definir o tamanho da moldura OLE da pasta de trabalho do Excel incorporada para corresponder ao tamanho cumulativo das linhas e colunas participantes na planilha do Excel.

Suponha que tenhamos uma planilha Excel modelo e queiramos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, o tamanho da moldura do objeto OLE será primeiro calculado com base nas alturas cumulativas das linhas e larguras cumulativas das colunas das linhas e colunas participantes na pasta de trabalho. Em seguida, definiremos o tamanho da moldura OLE para esse valor calculado. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" para a moldura OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Defina o tamanho exibido quando o arquivo da pasta de trabalho for usado como um objeto OLE no PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Redimensionar o Tamanho da Área de Células**

Nesta abordagem, aprenderemos como redimensionar as alturas das linhas participantes e a largura das colunas participantes para corresponder a um tamanho de moldura OLE personalizado.

Suponha que tenhamos uma planilha Excel modelo e queiramos adicioná‑la a uma apresentação como uma moldura OLE. Nesse cenário, definiremos o tamanho da moldura OLE e redimensionaremos o tamanho das linhas e colunas que participam da área da moldura OLE. Em seguida, salvaremos a pasta de trabalho em um fluxo para aplicar as alterações e convertê‑la em um array de bytes para adicioná‑la à moldura OLE. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" para a moldura OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem da moldura OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Defina o tamanho exibido quando o arquivo da pasta de trabalho for usado como um objeto OLE no PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Redimensione a área de células para caber no tamanho da moldura.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Precisamos usar a pasta de trabalho modificada.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Adicione a imagem OLE aos recursos da apresentação.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Crie a moldura do objeto OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     A largura esperada da área de células em pontos.
 * @param height    A altura esperada da área de células em pontos.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Conclusão**

{{% alert color="primary" %}} 

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. A escolha da abordagem apropriada depende dos requisitos específicos e do caso de uso. Ambas as abordagens funcionam da mesma forma, tanto para apresentações criadas a partir de um modelo quanto a partir do zero. Além disso, não há limite para o tamanho da moldura do objeto OLE nesta solução.

{{% /alert %}}

## **FAQ**

**Por que uma planilha Excel incorporada altera o tamanho quando ativada pela primeira vez no PowerPoint?**

Isso ocorre porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto a moldura do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir totalmente esse problema de redimensionamento?**

Sim. Redimensionando a moldura OLE para caber no tamanho da área de células do Excel ou redimensionando a área de células para caber no tamanho desejado da moldura OLE, você pode impedir o redimensionamento indesejado.

**Qual método de dimensionamento devo usar, dimensionamento da moldura OLE ou dimensionamento da área de células?**

Selecione **dimensionamento da moldura OLE** se quiser manter os tamanhos originais das linhas e colunas do Excel. Selecione **dimensionamento da área de células** se desejar um tamanho fixo para a moldura OLE na sua apresentação.

**Essas soluções funcionam se minha apresentação for baseada em um modelo?**

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e a partir do zero.

**Existe um limite para o tamanho da moldura OLE ao usar esses métodos?**

Não. Você pode definir a moldura do objeto OLE em qualquer tamanho, desde que ajuste a escala adequadamente.

**Há como evitar o texto de espaço reservado "EMBEDDED OLE OBJECT" no PowerPoint?**

Sim. Capturando uma captura de tela da área de células do Excel alvo e definindo‑a como imagem de espaço reservado da moldura OLE, você pode exibir uma imagem de pré‑visualização personalizada no lugar do espaço reservado padrão.