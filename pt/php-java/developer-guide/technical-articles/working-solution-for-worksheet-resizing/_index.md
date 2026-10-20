---
title: Solução Funcional para Redimensionamento de Planilha
type: docs
weight: 20
url: /pt/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagem de pré‑visualização
- redimensionamento de imagem
- Excel
- planilha
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Corrija o redimensionamento de OLE de planilhas do Excel em apresentações: duas maneiras de manter os quadros de objeto consistentes—escalando o quadro ou a planilha—nos formatos PPT e PPTX."
---
{{% alert color="info" title="Note" %}}

Planilhas do Excel incorporadas como objetos OLE em uma apresentação do PowerPoint usando componentes Aspose podem redimensionar inesperadamente após a primeira ativação. Esse comportamento cria uma diferença visual notável entre o objeto OLE antes e depois da ativação. Este artigo explica o problema e descreve duas maneiras de resolvê‑lo.

{{% /alert %}}

## **Contexto**

No artigo [Gerenciar OLE](/slides/pt/php-java/manage-ole/), explicamos como adicionar um quadro OLE a uma apresentação do PowerPoint usando Aspose.Slides para PHP via Java. Para resolver o [problema de visualização do objeto](/slides/pt/php-java/object-preview-issue-when-adding-oleobjectframe/), atribuímos uma imagem da área da planilha selecionada ao quadro do objeto OLE. Na apresentação de saída, ao clicar duas vezes no quadro do objeto OLE que exibe a imagem da planilha, o workbook do Excel é ativado. Os usuários finais podem fazer as alterações desejadas no workbook real do Excel e, em seguida, retornar ao slide clicando fora do workbook ativado. O tamanho do quadro do objeto OLE mudará quando o usuário retornar ao slide. O fator de redimensionamento variará dependendo do tamanho do quadro do objeto OLE e do workbook do Excel incorporado.

## **Causa do Redimensionamento**

Como o workbook do Excel tem seu próprio tamanho de janela, ele tenta manter seu tamanho original na primeira ativação. Por outro lado, o quadro do objeto OLE tem seu próprio tamanho. Segundo a Microsoft, quando o workbook do Excel é ativado, Excel e PowerPoint negociam o tamanho para garantir que as proporções corretas sejam mantidas como parte do processo de incorporação. O redimensionamento ocorre com base nas diferenças entre o tamanho da janela do Excel e o tamanho e posição do quadro do objeto OLE.

## **Solução Funcional**

Existem duas soluções possíveis para evitar o efeito de redimensionamento.

- Redimensione o quadro OLE na apresentação do PowerPoint para corresponder à altura e largura totais das linhas e colunas selecionadas.
- Mantenha o tamanho do quadro OLE constante e redimensione as linhas e colunas selecionadas para que caibam nele.

### **Escalar o Tamanho do Quadro OLE**

Essa abordagem define o tamanho do quadro OLE para corresponder à altura e largura totais das linhas e colunas selecionadas na planilha do Excel incorporada.

O exemplo carrega um workbook do Excel existente e seleciona as primeiras 10 linhas e 13 colunas de sua primeira planilha usando índices baseados em zero. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) define o intervalo exibido. A pré‑visualização é renderizada a 96 DPI, e suas dimensões em pixels são convertidas para pontos usando 72 pontos por polegada. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) incorpora o workbook modificado em um quadro com essas dimensões. A pré‑visualização é atribuída através de [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) para substituir o marcador de posição "EMBEDDED OLE OBJECT" na apresentação salva.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Incorpore o workbook modificado e mantenha os dados binários em arrays de bytes Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

O auxiliar de pré‑visualização define [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) para o intervalo selecionado e remove margens, cabeçalhos e rodapés. Com [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) habilitado, [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) renderiza o intervalo como uma imagem PNG. O auxiliar devolve um novo fluxo de entrada contendo a imagem PNG, posicionado no início para uso na apresentação.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Escalar o Tamanho da Faixa de Células**

Essa abordagem redimensiona as alturas das linhas selecionadas e as larguras das colunas selecionadas para corresponder a um tamanho de quadro OLE personalizado.

O exemplo carrega um workbook do Excel existente e seleciona as primeiras 10 linhas e 13 colunas de sua primeira planilha usando índices baseados em zero. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) define o intervalo exibido, e o auxiliar abaixo redimensiona esse intervalo para caber em um quadro de 400 pontos de largura por 100 pontos de altura. Após salvar o workbook modificado em um fluxo, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) o incorpora no tamanho especificado. Uma pré‑visualização renderizada a 96 DPI é atribuída através de [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), de modo que a apresentação salva exiba as células selecionadas em vez do marcador de posição padrão.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Incorpore o workbook modificado e mantenha os dados binários em arrays de bytes Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

O auxiliar de dimensionamento calcula razões de largura e altura separadas para o intervalo selecionado, preservando as larguras relativas de suas colunas e as alturas relativas de suas linhas. Ele converte as dimensões calculadas de pontos para polegadas antes de aplicá‑las com [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) e [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). O intervalo selecionado deve ter largura e altura diferentes de zero.

```php
use aspose\cells\CellsUnitType;

// Largura e altura são as dimensões esperadas da faixa de células em pontos.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Este auxiliar de pré‑visualização renderiza o intervalo redimensionado usando [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Ele limita [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) a esse intervalo, remove margens, cabeçalhos e rodapés, e devolve um fluxo PNG posicionado no início.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Conclusão**

{{% alert color="info" title="Note" %}}

Existem duas abordagens para corrigir o problema de redimensionamento da planilha. Escolha a abordagem que melhor se adequa aos seus requisitos e caso de uso. Ambas as abordagens funcionam da mesma forma, independentemente de as apresentações serem criadas a partir de um modelo ou do zero. Além disso, não há limite para o tamanho do quadro do objeto OLE nesta solução.

{{% /alert %}}

## **Perguntas Frequentes**

**Por que uma planilha do Excel incorporada muda de tamanho quando é ativada pela primeira vez no PowerPoint?**

Isso ocorre porque o Excel tenta manter o tamanho original da janela quando ativado, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir completamente esse problema de redimensionamento?**

Sim. Redimensionando o quadro OLE para caber no tamanho da faixa de células do Excel ou redimensionando a faixa de células para caber no tamanho de quadro OLE desejado, você pode evitar redimensionamentos indesejados.

**Qual método de dimensionamento devo usar, dimensionamento do quadro OLE ou dimensionamento da faixa de células?**

Selecione **dimensionamento do quadro OLE** se quiser manter os tamanhos originais das linhas e colunas do Excel. Selecione **dimensionamento da faixa de células** se quiser um tamanho fixo para o quadro OLE em sua apresentação.

**Essas soluções funcionam se minha apresentação for baseada em um modelo?**

Sim. Ambas as soluções funcionam para apresentações criadas a partir de modelos e do zero.

**Há um limite de tamanho para o quadro OLE ao usar esses métodos?**

Não. Você pode fazer o quadro do objeto OLE de qualquer tamanho, contanto que ajuste a escala adequadamente.

**Existe uma maneira de evitar o texto de marcador de posição "EMBEDDED OLE OBJECT" no PowerPoint?**

Sim. Capturando uma imagem da faixa de células do Excel alvo e definindo‑a como imagem de marcador de posição do quadro OLE, você pode exibir uma imagem de pré‑visualização personalizada no lugar do marcador padrão.

## **Artigos Relacionados**

[Criando um Gráfico do Excel e Incorporando‑lo em uma Apresentação como um Objeto OLE](/slides/pt/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Atualizando Objetos OLE Automaticamente Usando um Add‑In do MS PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)