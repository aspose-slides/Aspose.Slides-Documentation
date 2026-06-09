---
title: Solução Funcional para Redimensionamento de Planilha
type: docs
weight: 20
url: /pt/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de pré-visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Corrija o redimensionamento OLE de planilhas Excel em apresentações: duas maneiras de manter os quadros de objetos consistentes - dimensionar o quadro ou a planilha - nos formatos PPT e PPTX."
---
{{% alert color="primary" %}}

Foi observado que planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint por meio dos componentes Aspose são redimensionadas para uma escala não identificada após a primeira ativação. Esse comportamento cria uma diferença visual perceptível na apresentação entre os estados pré‑ e pós‑ativação do objeto OLE. Investigamos o problema em detalhes e fornecemos uma solução, que está descrita neste artigo.

{{% /alert %}}

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/java/manage-ole/), explicamos como adicionar um quadro OLE a uma apresentação do PowerPoint usando Aspose.Slides for Java. Para resolver o [problema de visualização do objeto](/slides/pt/java/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área da planilha selecionada ao quadro do objeto OLE. Na apresentação resultante, ao clicar duas vezes no quadro OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários podem fazer quaisquer alterações desejadas na pasta de trabalho real do Excel e, em seguida, retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho do quadro OLE e da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel possui seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, o quadro OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e posição do quadro OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensionar o quadro OLE na apresentação do PowerPoint para corresponder à altura e largura do número desejado de linhas e colunas no quadro OLE.
- Manter o tamanho do quadro OLE constante e redimensionar o tamanho das linhas e colunas participantes para caber no tamanho de quadro OLE selecionado.

### **Redimensionar o Tamanho do Quadro OLE**

Nesta abordagem, aprenderemos como definir o tamanho do quadro OLE da pasta de trabalho do Excel incorporada para corresponder ao tamanho cumulativo das linhas e colunas participantes na planilha do Excel.

Suponha que tenhamos uma planilha modelo do Excel e queiramos adicioná‑la a uma apresentação como um quadro OLE. Nesse cenário, o tamanho do quadro OLE será primeiro calculado com base nas alturas cumulativas das linhas e larguras cumulativas das colunas participantes na pasta de trabalho. Em seguida, definiremos o tamanho do quadro OLE para esse valor calculado. Para evitar a mensagem vermelha “EMBEDDED OLE OBJECT” no quadro OLE no PowerPoint, também capturaremos uma imagem das partes desejadas das linhas e colunas na pasta de trabalho e a definiremos como a imagem do quadro OLE.

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

// Obtenha a largura e a altura da imagem OLE em pontos.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Precisamos usar a pasta de trabalho modificada.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Adicione a imagem OLE aos recursos da apresentação.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Crie o quadro do objeto OLE.
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

### **Redimensionar o Tamanho da Faixa de Células**

Nesta abordagem, aprenderemos como redimensionar as alturas das linhas participantes e a largura das colunas participantes para corresponder a um tamanho de quadro OLE personalizado.

Suponha que tenhamos uma planilha modelo do Excel e queiramos adicioná‑la a uma apresentação como um quadro OLE. Nesse cenário, definiremos o tamanho do quadro OLE e redimensionaremos o tamanho das linhas e colunas que participam da área do quadro OLE. Em seguida, salvaremos a pasta de trabalho em um stream para aplicar as alterações e convertê‑la em um array de bytes para adicioná‑la ao quadro OLE. Para evitar a mensagem vermelha “EMBEDDED OLE OBJECT” no quadro OLE no PowerPoint, também capturaremos uma imagem das partes desejadas das linhas e colunas na pasta de trabalho e a definiremos como a imagem do quadro OLE.

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

// Redimensione a faixa de células para caber no tamanho do quadro.
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

// Crie o quadro do objeto OLE.
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
 * @param width     A largura esperada da faixa de células em pontos.
 * @param height    A altura esperada da faixa de células em pontos.
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

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. A escolha da abordagem apropriada depende dos requisitos específicos e do caso de uso. Ambas as abordagens funcionam da mesma forma, tanto para apresentações criadas a partir de um modelo quanto do zero. Além disso, não há limite para o tamanho do quadro OLE nesta solução.

{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha do Excel incorporada altera o tamanho ao ser ativada pela primeira vez no PowerPoint?**

Isso ocorre porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto o quadro OLE no PowerPoint tem dimensões próprias. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir totalmente esse problema de redimensionamento?**

Sim. Redimensionando o quadro OLE para caber no tamanho da faixa de células do Excel ou redimensionando a faixa de células para caber no tamanho desejado do quadro OLE, você pode evitar o redimensionamento indesejado.

**Qual método de redimensionamento devo usar, redimensionamento do quadro OLE ou da faixa de células?**

Escolha **redimensionamento do quadro OLE** se quiser preservar os tamanhos originais das linhas e colunas do Excel. Escolha **redimensionamento da faixa de células** se desejar um tamanho fixo para o quadro OLE na sua apresentação.

**Essas soluções funcionam se minha apresentação for baseada em um modelo?**

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho do quadro OLE ao usar esses métodos?**

Não. Você pode definir o quadro OLE em qualquer tamanho, contanto que ajuste a escala adequadamente.

**Há como evitar o texto de espaço reservado “EMBEDDED OLE OBJECT” no PowerPoint?**

Sim. Ao capturar uma imagem da faixa de células do Excel de destino e defini‑la como imagem de espaço reservado do quadro OLE, você pode exibir uma imagem de pré‑visualização personalizada em vez do espaço reservado padrão.

## **Artigos Relacionados**

[Criando um Gráfico do Excel e Incorporando‑o em uma Apresentação como Objeto OLE](/slides/pt/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Atualizando Objetos OLE Automaticamente Usando um Add‑In do MS PowerPoint](/slides/pt/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)