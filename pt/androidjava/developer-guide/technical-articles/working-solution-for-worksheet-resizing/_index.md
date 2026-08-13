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
description: "Corrija o redimensionamento OLE de planilhas do Excel em apresentações: duas maneiras de manter os quadros de objetos consistentes—escale o quadro ou a planilha—nos formatos PPT e PPTX."
---
{{% alert color="info" %}}

Foi observado que as planilhas do Excel incorporadas como objetos OLE em uma apresentação PowerPoint através dos componentes Aspose são redimensionadas para uma escala não identificada após a primeira ativação. Esse comportamento cria uma diferença visual perceptível na apresentação entre os estados pré- e pós-ativação do objeto OLE. Investigamos esse problema em detalhes e fornecemos uma solução, que está coberta neste artigo.

{{% /alert %}}

## **Contexto**

No artigo [Manage OLE](/slides/pt/androidjava/manage-ole/), explicamos como adicionar um quadro OLE a uma apresentação PowerPoint usando Aspose.Slides for Android via Java. Para resolver o [object preview issue](/slides/pt/androidjava/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área da planilha selecionada ao quadro do objeto OLE. Na apresentação resultante, ao dar duplo clique no quadro do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer quaisquer alterações desejadas na pasta de trabalho real do Excel e então retornar ao slide clicando fora da pasta de trabalho do Excel ativada. O tamanho do quadro do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho do quadro do objeto OLE e da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel tem seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, o quadro do objeto OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, o Excel e o PowerPoint negociam o tamanho para garantir que ele mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e posição do quadro do objeto OLE.

## **Solução**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Dimensionar o tamanho do quadro OLE na apresentação PowerPoint para corresponder à altura e largura do número desejado de linhas e colunas no quadro OLE.
- Manter o tamanho do quadro OLE constante e dimensionar o tamanho das linhas e colunas participantes para caber dentro do tamanho do quadro OLE selecionado.

### **Escalar o Tamanho do Quadro OLE**

Nesta abordagem, aprenderemos como definir o tamanho do quadro OLE da pasta de trabalho do Excel incorporada para corresponder ao tamanho cumulativo das linhas e colunas participantes na planilha do Excel.

Suponha que temos uma planilha Excel modelo e queremos adicioná‑la a uma apresentação como um quadro OLE. Nesse cenário, o tamanho do quadro OLE será primeiro calculado com base nas alturas cumulativas das linhas e nas larguras das colunas das linhas e colunas participantes na pasta de trabalho. Em seguida, definiremos o tamanho do quadro OLE para esse valor calculado. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" no quadro OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem do quadro OLE.

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

// Defina o tamanho exibido quando o arquivo da pasta de trabalho é usado como um objeto OLE no PowerPoint.
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

### **Escalar o Tamanho da Faixa de Células**

Nesta abordagem, aprenderemos como dimensionar as alturas das linhas participantes e a largura das colunas participantes para corresponder a um tamanho de quadro OLE personalizado.

Suponha que temos uma planilha Excel modelo e queremos adicioná‑la a uma apresentação como um quadro OLE. Nesse cenário, definiremos o tamanho do quadro OLE e dimensionaremos o tamanho das linhas e colunas que participam da área do quadro OLE. Em seguida, salvaremos a pasta de trabalho em um stream para aplicar as alterações e convertê‑la em um array de bytes para adicioná‑la ao quadro OLE. Para evitar a mensagem vermelha "EMBEDDED OLE OBJECT" no quadro OLE no PowerPoint, também capturaremos uma imagem das porções desejadas das linhas e colunas na pasta de trabalho e a definiremos como imagem do quadro OLE.

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

// Defina o tamanho exibido quando o arquivo da pasta de trabalho for usado como um objeto OLE no PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Dimensione a faixa de células para caber no tamanho do quadro.
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

{{% alert color="info" %}} 

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. A escolha da abordagem apropriada depende dos requisitos específicos e do caso de uso. Ambas as abordagens funcionam da mesma forma, seja a apresentação criada a partir de um modelo ou do zero. Além disso, não há limite para o tamanho do quadro do objeto OLE nesta solução.

{{% /alert %}}

## **FAQ**

### Por que uma planilha Excel incorporada altera o tamanho quando ativada pela primeira vez no PowerPoint?

Isso acontece porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

### É possível evitar completamente esse problema de redimensionamento?

Sim. Dimensionando o quadro OLE para caber no tamanho da faixa de células do Excel ou dimensionando a faixa de células para caber no tamanho desejado do quadro OLE, você pode evitar o redimensionamento indesejado.

### Qual método de dimensionamento devo usar, dimensionamento do quadro OLE ou dimensionamento da faixa de células?

Selecione **dimensionamento do quadro OLE** se desejar manter os tamanhos originais das linhas e colunas do Excel. Selecione **dimensionamento da faixa de células** se quiser um tamanho fixo para o quadro OLE em sua apresentação.

### Essas soluções funcionarão se minha apresentação for baseada em um modelo?

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

### Existe um limite para o tamanho do quadro OLE ao usar esses métodos?

Não. Você pode definir o quadro do objeto OLE em qualquer tamanho, contanto que ajuste a escala adequadamente.

### Existe uma maneira de evitar o texto de espaço reservado "EMBEDDED OLE OBJECT" no PowerPoint?

Sim. Tirando uma captura da faixa de células do Excel alvo e definindo‑a como a imagem de espaço reservado do quadro OLE, você pode exibir uma imagem de visualização personalizada em vez do marcador de posição padrão.