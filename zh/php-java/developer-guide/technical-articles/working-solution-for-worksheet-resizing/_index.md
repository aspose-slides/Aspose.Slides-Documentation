---
title: 工作表尺寸调整的可行解决方案
type: docs
weight: 20
url: /zh/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像大小调整
- Excel
- 工作表
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "在演示文稿中修复 Excel 工作表 OLE 大小调整问题：通过两种方式保持对象框一致——缩放框架或缩放工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}

使用 Aspose 组件在 PowerPoint 演示文稿中嵌入为 OLE 对象的 Excel 工作表，在首次激活后可能会意外改变大小。此行为导致 OLE 对象在激活前后出现显著的视觉差异。本文解释了此问题并描述了两种解决方案。

{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh/php-java/manage-ole/)中，我们解释了如何使用 Aspose.Slides for PHP via Java 向 PowerPoint 演示文稿添加 OLE 帧。为了解决[对象预览问题](/slides/zh/php-java/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象帧分配了所选工作表区域的图像。在输出的演示文稿中，当您双击显示工作表图像的 OLE 对象帧时，Excel 工作簿将被激活。最终用户可以对实际的 Excel 工作簿进行任何所需的更改，然后通过点击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象帧的大小会发生变化。调整大小的因素取决于 OLE 对象帧的大小以及嵌入的 Excel 工作簿的大小。

## **尺寸调整的原因**

由于 Excel 工作簿拥有自己的窗口大小，它在首次激活时会尝试保持原始大小。另一方面，OLE 对象帧也有自己的尺寸。根据 Microsoft 的说法，当 Excel 工作簿被激活时，Excel 和 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。尺寸调整是基于 Excel 窗口大小与 OLE 对象帧的大小和位置之间的差异而发生的。

## **可行的解决方案**

有两种可能的解决方案可避免尺寸调整效果。

- 在 PowerPoint 演示文稿中缩放 OLE 框，使其匹配所选行和列的总高度和宽度。
- 保持 OLE 框大小不变，并缩放所选的行和列以适应框内。

### **缩放 OLE 框大小**

此方法将 OLE 框的大小设置为匹配嵌入的 Excel 工作表中所选行和列的总高度和宽度。

示例加载现有的 Excel 工作簿，并使用从零开始的索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize)定义显示的范围。预览以 96 DPI 渲染，其像素尺寸使用每英寸 72 点转换为点数。[ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame)将修改后的工作簿嵌入具有这些尺寸的框中。预览通过[OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)分配，以替换已保存演示文稿中的“EMBEDDED OLE OBJECT”占位符。

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

    // 嵌入修改后的工作簿并将二进制数据保存在 Java 字节数组中。
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

预览助手将[PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea)设置为所选范围，并移除页边距、页眉和页脚。启用[ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea)后，[SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage)将范围渲染为 PNG 图像。该助手返回一个包含 PNG 图像的新输入流，流指针位于开头，以供演示文稿使用。

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

### **缩放单元格范围大小**

此方法将所选行的高度和所选列的宽度进行缩放，以匹配自定义的 OLE 框大小。

示例加载现有的 Excel 工作簿，并使用从零开始的索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize)定义显示的范围，下面的助手将该范围缩放以适应宽 400 点、高 100 点的框。将修改后的工作簿保存到流后，[ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame)按指定大小嵌入其中。通过[OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)分配的 96 DPI 渲染的预览，使已保存的演示文稿显示所选单元格而不是默认占位符。

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

    // 嵌入修改后的工作簿并将二进制数据保存在 Java 字节数组中。
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

缩放助手为所选范围计算单独的宽度和高度比例，保持列的相对宽度和行的相对高度。在使用[Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch)和[Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch)应用之前，它先将计算得到的尺寸从点转换为英寸。所选范围的宽度和高度必须非零。

```php
use aspose\cells\CellsUnitType;

// 宽度和高度是单元格范围的预期尺寸（单位：点）。
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

此预览助手使用[SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage)渲染调整大小后的范围。它将[PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea)限制于该范围，移除页边距、页眉和页脚，并返回一个指向开头的 PNG 流。

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

## **结论**

{{% alert color="info" title="Note" %}}

有两种方法可以解决工作表尺寸调整问题。请选择最符合您需求和使用场景的方法。无论演示文稿是从模板创建还是从头开始，两种方法的工作方式相同。此外，此解决方案对 OLE 对象框的大小没有限制。

{{% /alert %}}

## **常见问题**

**为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？**

因为 Excel 在激活时尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框有其自身的尺寸。PowerPoint 与 Excel 协商尺寸以保持纵横比，这可能导致尺寸调整。

**是否可以完全防止此尺寸调整问题？**

可以。通过将 OLE 框缩放以匹配 Excel 单元格范围的大小，或将单元格范围缩放以适应所需的 OLE 框大小，您可以防止不必要的尺寸调整。

**我应该使用哪种缩放方法，OLE 框缩放还是单元格范围缩放？**

如果您希望保持原始的 Excel 行和列大小，请选择**OLE 框缩放**。如果您希望在演示文稿中 OLE 框保持固定尺寸，请选择**单元格范围缩放**。

**如果我的演示文稿基于模板，这些解决方案是否有效？**

是的。这两种解决方案都适用于基于模板创建的演示文稿以及从头创建的演示文稿。

**使用这些方法时 OLE 框的大小是否有限制？**

没有。只要适当设置缩放比例，OLE 对象框可以任意大小。

**是否有办法避免 PowerPoint 中的“EMBEDDED OLE OBJECT”占位符文本？**

可以。通过对目标 Excel 单元格范围进行快照并将其设为 OLE 框的占位图像，您可以用自定义预览图像替代默认占位符。

## **相关文章**

[创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)