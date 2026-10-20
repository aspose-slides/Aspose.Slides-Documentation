---
title: 创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿
type: docs
weight: 30
url: /zh/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 图表
- 嵌入图表
- OLE 对象
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Cells for PHP via Java 创建 Excel 图表，并使用 Aspose.Slides for PHP via Java 将工作簿嵌入 PowerPoint 演示文稿，包括图表预览。"
---
## **概览**

本文展示如何使用 Aspose.Cells for PHP via Java 创建 Excel 柱形图，并将其工作簿嵌入到使用 Aspose.Slides for PHP via Java 的 PowerPoint 演示文稿中。嵌入的工作簿包含源数据和图表。单独的 PNG 预览在 OLE 对象激活前在幻灯片上显示图表。

结果是嵌入的 Excel 对象，而不是原生的 PowerPoint 图表。通过 OLE 编辑工作簿需要支持 OLE 激活的桌面应用程序和兼容的 Excel 安装。

## **先决条件**

使用相同的 PHP/Java Bridge 实例配置 Aspose.Cells for PHP via Java 和 Aspose.Slides for PHP via Java。加载两个 PHP 包装器并使两个产品的 Java 库对桥可用。使用这些库生成演示文稿不需要 Microsoft Office。

不需要输入文件：示例在内存中创建数据和图表，然后将 `OutputChart.pptx` 写入当前工作目录。在非评估模式下运行时请为两个产品应用许可证。

## **嵌入工作原理**

1. 创建一个工作簿，其中包含数据工作表和图表工作表。  
2. 将图表工作表设为活动工作表，使工作簿打开时直接显示图表。  
3. 设置工作簿的 OLE 显示范围并将图表渲染为 PNG。  
4. 将工作簿以 XLSX 形式保存在内存中，并将其字节嵌入到幻灯片中。  
5. 将 PNG 设为 OLE 对象的预览图，并将演示文稿保存为 PPTX。  

工作簿的显示范围和幻灯片上的框架承担不同的角色。[WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) 使用零基的起止行列索引。相反，[ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) 使用顶行、左列、底行和右列。示例使用行索引 55 和列索引 25 作为右下边界；这些值是布局选择，而非数据行列的数量。

幻灯片框架使用点（points）单位。示例将其放置在幻灯片内部并居中，同时保持 PNG 的宽高比，而不是将预览拉伸以填满幻灯片。

## **创建并嵌入图表**

以下完整示例向 `DataSheet` 填充四行五列的值。每行对应一个图表系列。在保存工作簿之前，选择 `ChartSheet` 为活动工作表。

工作簿显式保存为 XLSX，匹配传递给 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 扩展名。Java 数值结果在 PHP 执行算术运算前通过 `java_values` 转换，而二进制数据保持在 Java 字节数组中。PNG 直接从其字节加载，无需中间的位图转换。通过 [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 进行赋值会替换默认的 OLE 占位符。

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // 在将 PNG 和 XLSX 传递给 Slides 时保持它们为 Java 字节数组。
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // 在保持宽高比的同时调整大小并居中预览。
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **预期结果**

`OutputChart.pptx` 包含一张幻灯片，其中嵌入了 Excel 工作簿和图表预览。工作簿包含原始数据和一个四系列的柱形图。预览居中显示在幻灯片上并保持其比例。

![Excel 柱形图作为嵌入工作簿的预览](excel-chart-ole-preview.png)

在具备 Excel 的兼容桌面 PowerPoint 环境中，双击对象即可激活并编辑嵌入的工作簿。激活与编辑取决于宿主应用程序的 OLE 支持和安全设置。

## **常见问题**

**为什么需要预览图像？**

嵌入的工作簿和其幻灯片预览是分离的内容。提供图表图像，使幻灯片显示图表而不是默认的 “EMBEDDED OLE OBJECT” 占位符。参见 [添加 OleObjectFrame 时的对象预览问题](/slides/zh/php-java/object-preview-issue-when-adding-oleobjectframe/)。

**当我在代码中更改工作簿时，预览会自动更新吗？**

将预览视为快照。程序化更新工作簿数据后，需要重新生成图表图像，并同时替换预览和嵌入的工作簿数据。

**我可以使用 XLS 而不是 XLSX 吗？**

可以。将工作簿保存为 XLS 格式，并使用 `xls` 作为嵌入数据的扩展名。扩展名必须与实际工作簿格式匹配，仅更改扩展名并不会转换数据。

**为什么对象在激活后可能会改变大小？**

宿主应用程序在激活工作簿时可能会更新 OLE 对象的呈现方式。工作簿的 OLE 显示范围和幻灯片框架的尺寸都很关键。参见 [PPTX 中图表大小调整的可行方案](/slides/zh/java/working-solution-for-chart-resizing-in-pptx/)。

## **相关章节**

- [PPTX 中图表大小调整的可行方案](/slides/zh/java/working-solution-for-chart-resizing-in-pptx/)
- [添加 OleObjectFrame 时的对象预览问题](/slides/zh/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [管理 OLE 对象](/slides/zh/php-java/manage-ole/)