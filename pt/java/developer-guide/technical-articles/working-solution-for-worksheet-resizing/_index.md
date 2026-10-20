---
title: Solução Funcional para Redimensionamento de Planilhas
type: docs
weight: 20
url: /pt/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Corrija o redimensionamento de planilhas Excel OLE em apresentações: duas maneiras de manter os quadros de objeto consistentes—escalar o quadro ou a planilha—nos formatos PPT e PPTX."
---
{{% alert color="info" title="Note" %}}
Planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint usando componentes Aspose podem redimensionar inesperadamente após a primeira ativação. Esse comportamento cria uma diferença visual perceptível entre o objeto OLE antes e depois da ativação. Este artigo explica o problema e descreve duas maneiras de corrigi‑lo.
{{% /alert %}}

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/java/manage-ole/), explicamos como adicionar um frame OLE a uma apresentação do PowerPoint usando Aspose.Slides for Java. Para tratar o [problema de visualização do objeto](/slides/pt/java/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área da planilha selecionada ao frame do objeto OLE. Na apresentação resultante, ao clicar duas vezes no frame OLE que exibe a imagem da planilha, a pasta de trabalho Excel é ativada. Os usuários podem fazer as alterações desejadas na pasta de trabalho real e depois retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do frame OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento varia conforme o tamanho do frame OLE e da pasta de trabalho Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho Excel possui sua própria janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, o frame OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que as proporções corretas sejam mantidas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela Excel e o tamanho e posição do frame OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Escalar o frame OLE na apresentação do PowerPoint para corresponder à altura e largura totais das linhas e colunas selecionadas.  
- Manter o tamanho do frame OLE constante e escalar as linhas e colunas selecionadas para caber dentro dele.

### **Escalar o Tamanho do Frame OLE**

Esta abordagem define o tamanho do frame OLE para corresponder à altura e largura totais das linhas e colunas selecionadas na planilha Excel incorporada.

O exemplo carrega uma pasta de trabalho Excel existente e seleciona as primeiras 10 linhas e 13 colunas da primeira planilha usando índices baseados em zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) define o intervalo exibido. A visualização é renderizada a 96 DPI e suas dimensões em pixels são convertidas em pontos usando 72 pontos por polegada. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) incorpora a pasta de trabalho modificada em um frame com essas dimensões. A visualização é atribuída por meio de [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) para substituir o placeholder “EMBEDDED OLE OBJECT” na apresentação salva.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Defina o tamanho exibido quando o arquivo da pasta de trabalho é usado como um objeto OLE no PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
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

O auxiliar de visualização define [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) para o intervalo selecionado e remove margens, cabeçalhos e rodapés. Com [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) ativado, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) renderiza o intervalo como imagem PNG. O auxiliar devolve um novo fluxo de entrada contendo a imagem PNG, posicionado no início para uso na apresentação.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

### **Escalar o Tamanho do Intervalo de Células**

Esta abordagem escala as alturas das linhas selecionadas e as larguras das colunas selecionadas para corresponder a um tamanho de frame OLE personalizado.

O exemplo carrega uma pasta de trabalho Excel existente e seleciona as primeiras 10 linhas e 13 colunas da primeira planilha usando índices baseados em zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) define o intervalo exibido, e o auxiliar abaixo escala esse intervalo para caber em um frame de 400 pontos de largura por 100 pontos de altura. Após salvar a pasta de trabalho modificada em um fluxo, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) a incorpora no tamanho especificado. Uma visualização renderizada a 96 DPI é atribuída por meio de [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) para que a apresentação salva exiba as células selecionadas em vez do placeholder padrão.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Defina o tamanho exibido quando o arquivo da pasta de trabalho é usado como um objeto OLE no PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Escalone o intervalo de células para caber no tamanho do frame.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Adicione a imagem OLE aos recursos da apresentação.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Crie o frame do objeto OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

O auxiliar de dimensionamento calcula razões de largura e altura separadas para o intervalo selecionado, preservando as larguras relativas de suas colunas e as alturas relativas de suas linhas. Converte as dimensões calculadas de pontos para polegadas antes de aplicá‑las com [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) e [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). O intervalo selecionado deve ter largura e altura diferentes de zero.

```java
/**
 * @param width     A largura esperada do intervalo de células em pontos.
 * @param height    A altura esperada do intervalo de células em pontos.
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

Esse auxiliar de visualização renderiza o intervalo redimensionado usando [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Ele limita [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) a esse intervalo, remove margens, cabeçalhos e rodapés e devolve um fluxo PNG posicionado no início.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

{{% alert color="info" title="Note" %}}
Existem duas abordagens para corrigir o problema de redimensionamento da planilha. Escolha a abordagem que melhor se adequa aos seus requisitos e caso de uso. Ambas funcionam da mesma forma, seja a apresentação criada a partir de um modelo ou do zero. Além disso, não há limite para o tamanho do frame OLE nessa solução.
{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha Excel incorporada altera o tamanho quando é ativada pela primeira vez no PowerPoint?**  
Isso ocorre porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto o frame OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir completamente esse problema de redimensionamento?**  
Sim. Ao escalar o frame OLE para caber no tamanho do intervalo de células Excel ou ao escalar o intervalo de células para caber no tamanho desejado do frame OLE, é possível evitar o redimensionamento indesejado.

**Qual método de dimensionamento devo usar, dimensionamento do frame OLE ou dimensionamento do intervalo de células?**  
Selecione **dimensionamento do frame OLE** se quiser manter os tamanhos originais das linhas e colunas do Excel. Se preferir um tamanho fixo para o frame OLE na apresentação, escolha **dimensionamento do intervalo de células**.

**Essas soluções funcionam se a apresentação for baseada em um modelo?**  
Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho do frame OLE ao usar esses métodos?**  
Não. Você pode definir o frame OLE em qualquer tamanho, desde que ajuste a escala adequadamente.

**Há como evitar o texto placeholder “EMBEDDED OLE OBJECT” no PowerPoint?**  
Sim. Capturando uma imagem do intervalo de células Excel alvo e definindo-a como a imagem placeholder do frame OLE, você pode exibir uma visualização personalizada em vez do placeholder padrão.

## **Artigos Relacionados**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/pt/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)