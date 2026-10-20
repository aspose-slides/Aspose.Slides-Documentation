---
title: Solução Funcional para Redimensionamento de Planilha
type: docs
weight: 20
url: /pt/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Corrija o redimensionamento de OLE da planilha Excel em apresentações: duas maneiras de manter os quadros de objetos consistentes—escalar o quadro ou a planilha—nos formatos PPT e PPTX."
---
{{% alert color="info" title="Note" %}}

Planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint usando componentes Aspose podem redimensionar inesperadamente após sua primeira ativação. Esse comportamento cria uma diferença visual perceptível entre o objeto OLE antes e depois da ativação. Este artigo explica o problema e descreve duas maneiras de resolvê‑lo.

{{% /alert %}}

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/androidjava/manage-ole/), explicamos como adicionar um quadro OLE a uma apresentação do PowerPoint usando Aspose.Slides for Android via Java. Para tratar o [problema de visualização do objeto](/slides/pt/androidjava/object-preview-issue-when-adding-oleobjectframe/), atribuimos uma imagem da área selecionada da planilha ao quadro do objeto OLE. Na apresentação gerada, ao dar um duplo‑clique no quadro do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer quaisquer alterações desejadas na pasta de trabalho real do Excel e então retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento varia conforme o tamanho do quadro do objeto OLE e da pasta de trabalho do Excel incorporada.

## **Causa do redimensionamento**

Como a pasta de trabalho do Excel tem seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, o quadro do objeto OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho para garantir que mantenham as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e a posição do quadro do objeto OLE.

## **Solução funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensionar o quadro OLE na apresentação do PowerPoint para corresponder à altura e largura totais das linhas e colunas selecionadas.
- Manter o tamanho do quadro OLE constante e redimensionar as linhas e colunas selecionadas para que caibam nele.

### **Redimensionar o tamanho do quadro OLE**

Esta abordagem define o tamanho do quadro OLE para corresponder à altura e largura totais das linhas e colunas selecionadas na planilha do Excel incorporada.

O exemplo carrega uma pasta de trabalho do Excel existente e seleciona as primeiras 10 linhas e 13 colunas da primeira planilha usando índices iniciados em zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) define o intervalo exibido. A visualização é renderizada a 96 DPI e suas dimensões em pixels são convertidas para pontos usando 72 pontos por polegada. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) incorpora a pasta de trabalho modificada em um quadro com essas dimensões. A pré‑visualização é atribuída por meio de [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) para substituir o placeholder “EMBEDDED OLE OBJECT” na apresentação salva.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Defina o tamanho exibido quando o arquivo da pasta de trabalho é usado como objeto OLE no PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Obtenha a largura e a altura da imagem OLE em pontos.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

O auxiliar de visualização define [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) para o intervalo selecionado e remove margens, cabeçalhos e rodapés. Com [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) habilitado, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) renderiza o intervalo como imagem PNG. O auxiliar devolve um novo stream de entrada contendo a imagem PNG, posicionado no início para uso na apresentação.

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

### **Redimensionar o tamanho do intervalo de células**

Esta abordagem redimensiona as alturas das linhas selecionadas e as larguras das colunas selecionadas para corresponder a um tamanho de quadro OLE personalizado.

O exemplo carrega uma pasta de trabalho do Excel existente e seleciona as primeiras 10 linhas e 13 colunas da primeira planilha usando índices iniciados em zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) define o intervalo exibido, e o auxiliar abaixo redimensiona esse intervalo para caber em um quadro de 400 pontos de largura por 100 pontos de altura. Após salvar a pasta de trabalho modificada em um stream, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) a incorpora no tamanho especificado. Uma visualização renderizada a 96 DPI é atribuída por meio de [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), de modo que a apresentação salva exiba as células selecionadas em vez do placeholder padrão.

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

// Defina o tamanho exibido quando o arquivo da pasta de trabalho for usado como objeto OLE no PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Dimensione o intervalo de células para caber no tamanho do quadro.
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

O auxiliar de redimensionamento calcula razões de largura e altura separadas para o intervalo selecionado, preservando as larguras relativas de suas colunas e as alturas relativas de suas linhas. Converte as dimensões calculadas de pontos para polegadas antes de aplicá‑las com [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) e [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). O intervalo selecionado deve ter largura e altura diferentes de zero.

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

Este auxiliar de visualização renderiza o intervalo redimensionado usando [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Limita [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) a esse intervalo, remove margens, cabeçalhos e rodapés e devolve um stream PNG posicionado no início.

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

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. Escolha a abordagem que melhor se adequa aos seus requisitos e caso de uso. Ambas funcionam da mesma forma, independentemente de as apresentações serem criadas a partir de um modelo ou do zero. Além disso, não há limite para o tamanho do quadro do objeto OLE nesta solução.

{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha do Excel incorporada muda de tamanho ao ser ativada pela primeira vez no PowerPoint?**

Isso ocorre porque o Excel tenta manter o tamanho original da janela quando ativado, enquanto o quadro do objeto OLE no PowerPoint tem dimensões próprias. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir totalmente esse problema de redimensionamento?**

Sim. Redimensionando o quadro OLE para caber no tamanho do intervalo de células do Excel ou redimensionando o intervalo de células para caber no tamanho desejado do quadro OLE, você pode evitar redimensionamentos indesejados.

**Qual método de redimensionamento devo usar, redimensionamento do quadro OLE ou redimensionamento do intervalo de células?**

Selecione **redimensionamento do quadro OLE** se quiser manter os tamanhos originais das linhas e colunas do Excel. Se preferir um tamanho fixo para o quadro OLE na apresentação, selecione **redimensionamento do intervalo de células**.

**Essas soluções funcionarão se minha apresentação for baseada em um modelo?**

Sim. Ambas funcionam para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho do quadro OLE ao usar esses métodos?**

Não. Você pode definir o quadro do objeto OLE com qualquer tamanho, contanto que ajuste a escala adequadamente.

**Há como evitar o texto placeholder “EMBEDDED OLE OBJECT” no PowerPoint?**

Sim. Capturando uma instantâneo do intervalo de células do Excel alvo e definindo‑o como a imagem placeholder do quadro OLE, você pode exibir uma imagem de visualização personalizada no lugar do placeholder padrão.

## **Artigos Relacionados**

[Criando um Gráfico Excel e Incorporando‑o em uma Apresentação como Objeto OLE](/slides/pt/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Atualizando Objetos OLE Automaticamente Usando um Add‑In do MS PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)