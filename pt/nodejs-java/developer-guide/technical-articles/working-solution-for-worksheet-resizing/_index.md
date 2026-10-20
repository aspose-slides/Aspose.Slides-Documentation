---
title: Solução Funcional para Redimensionamento de Planilha
type: docs
weight: 20
url: /pt/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de pré-visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Corrija o redimensionamento OLE de planilhas Excel em apresentações: duas maneiras de manter os quadros de objetos consistentes—dimensionar o quadro ou a planilha—nos formatos PPT e PPTX."
---
{{% alert color="info" title="Note" %}}
Planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint usando componentes Aspose podem redimensionar inesperadamente após sua primeira ativação. Esse comportamento cria uma diferença visual perceptível entre o objeto OLE antes e depois da ativação. Este artigo explica o problema e descreve duas maneiras de resolvê‑lo.
{{% /alert %}}

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/nodejs-java/manage-ole/), explicamos como adicionar uma moldura OLE a uma apresentação do PowerPoint usando Aspose.Slides para Node.js via Java. Para resolver o [problema de visualização do objeto](/slides/pt/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área selecionada da planilha ao quadro do objeto OLE. Na apresentação resultante, ao clicar duas vezes no quadro do objeto OLE que exibe a imagem da planilha, a pasta de trabalho do Excel é ativada. Os usuários finais podem fazer as alterações desejadas na pasta de trabalho real do Excel e então retornar ao slide clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho do quadro do objeto OLE e da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel tem seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Por outro lado, o quadro do objeto OLE tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, o Excel e o PowerPoint negociam o tamanho para garantir que mantenha as proporções corretas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e a posição do quadro do objeto OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensionar o quadro OLE na apresentação do PowerPoint para corresponder à altura e largura totais das linhas e colunas selecionadas.
- Manter o tamanho do quadro OLE constante e dimensionar as linhas e colunas selecionadas para que caibam nele.

### **Dimensionar o Tamanho do Quadro OLE**

Esta abordagem define o tamanho do quadro OLE para corresponder à altura e largura totais das linhas e colunas selecionadas na planilha do Excel incorporada.

O exemplo carrega uma pasta de trabalho Excel existente e seleciona as primeiras 10 linhas e 13 colunas da primeira planilha usando índices baseados em zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) define o intervalo exibido. A visualização é renderizada a 96 DPI, e suas dimensões em pixels são convertidas para pontos usando 72 pontos por polegada. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) incorpora a pasta de trabalho modificada em um quadro com essas dimensões. A visualização é atribuída através de [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) para substituir o placeholder "EMBEDDED OLE OBJECT" na apresentação salva.

Instale os pacotes `aspose.cells`, `aspose.slides.via.java` e `java` e coloque o arquivo `sample.xlsx` no diretório de trabalho. Para cada abordagem, execute primeiro o script de preparação e depois o script de incorporação em um processo Node.js separado no mesmo diretório. Os dois pacotes Aspose inicializam a ponte Java separadamente.

Salve este script de preparação como `prepare-frame-scaled.js` e execute‑o com `node prepare-frame-scaled.js`. Ele gera `frame-scaled.xlsx` e `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Todo o trabalho síncrono está concluído; pare o processo da ponte Java.
process.exit(0);
```

Salve este script de incorporação como `embed-frame-scaled.js` e execute‑o com `node embed-frame-scaled.js`. Ele lê esses arquivos e gera `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Todo o trabalho síncrono está concluído; pare o processo da ponte Java.
process.exit(0);
```

O auxiliar de visualização define [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) para o intervalo selecionado e remove margens, cabeçalhos e rodapés. Com [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) habilitado, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) renderiza o intervalo como uma imagem PNG. O auxiliar salva a imagem PNG em um arquivo para uso na apresentação.

### **Dimensionar o Tamanho do Intervalo de Células**

Esta abordagem dimensiona as alturas das linhas selecionadas e as larguras das colunas selecionadas para corresponder a um tamanho de quadro OLE personalizado.

O exemplo carrega uma pasta de trabalho Excel existente e seleciona as primeiras 10 linhas e 13 colunas da primeira planilha usando índices baseados em zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) define o intervalo exibido, e o auxiliar dimensiona esse intervalo para caber em um quadro de 400 pontos de largura por 100 pontos de altura. Após salvar a pasta de trabalho modificada em um arquivo, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) a incorpora no tamanho especificado. Uma visualização renderizada a 96 DPI é atribuída através de [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), de modo que a apresentação salva exibe as células selecionadas em vez do placeholder padrão.

Salve este script de preparação como `prepare-cells-scaled.js` e execute‑o com `node prepare-cells-scaled.js`. Ele gera `cells-scaled.xlsx` e `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Todo o trabalho síncrono está concluído; pare o processo da ponte Java.
process.exit(cellsPrepared ? 0 : 1);
```

Salve este script de incorporação como `embed-cells-scaled.js` e execute‑o com `node embed-cells-scaled.js`. Ele lê esses arquivos e gera `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Todo o trabalho síncrono está concluído; pare o processo da ponte Java.
process.exit(0);
```

O auxiliar de dimensionamento calcula razões de largura e altura separadas para o intervalo selecionado, preservando as larguras relativas de suas colunas e as alturas relativas de suas linhas. Converte as dimensões calculadas de pontos para polegadas antes de aplicá‑las com [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) e [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). O intervalo selecionado deve ter largura e altura diferentes de zero.

Este auxiliar de visualização renderiza o intervalo redimensionado usando [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Ele limita [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) a esse intervalo, remove margens, cabeçalhos e rodapés, e salva a imagem PNG em um arquivo.

## **Conclusão**

{{% alert color="info" title="Note" %}}
Existem duas abordagens para corrigir o problema de redimensionamento da planilha. Escolha a abordagem que melhor atenda aos seus requisitos e caso de uso. Ambas as abordagens funcionam da mesma forma, tanto para apresentações criadas a partir de um modelo quanto do zero. Além disso, não há limite para o tamanho do quadro do objeto OLE nesta solução.
{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha do Excel incorporada muda de tamanho quando ativada pela primeira vez no PowerPoint?**

Isso ocorre porque o Excel tenta manter o tamanho original da janela ao ser ativado, enquanto o quadro do objeto OLE no PowerPoint possui suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível evitar completamente esse problema de redimensionamento?**

Sim. Ao dimensionar o quadro OLE para caber no tamanho da faixa de células do Excel ou dimensionar a faixa de células para caber no tamanho desejado do quadro OLE, você pode evitar o redimensionamento indesejado.

**Qual método de dimensionamento devo usar, dimensionamento do quadro OLE ou dimensionamento da faixa de células?**

Selecione **dimensionamento do quadro OLE** se quiser manter os tamanhos originais das linhas e colunas do Excel. Selecione **dimensionamento da faixa de células** se desejar um tamanho fixo para o quadro OLE na sua apresentação.

**Essas soluções funcionarão se minha apresentação for baseada em um modelo?**

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho do quadro OLE ao usar esses métodos?**

Não. Você pode definir o quadro do objeto OLE em qualquer tamanho, desde que ajuste a escala adequadamente.

**Existe uma maneira de evitar o texto placeholder "EMBEDDED OLE OBJECT" no PowerPoint?**

Sim. Ao capturar uma imagem da faixa de células do Excel alvo e configurá‑la como imagem placeholder do quadro OLE, você pode exibir uma imagem de visualização personalizada no lugar do placeholder padrão.

## **Artigos Relacionados**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/pt/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)