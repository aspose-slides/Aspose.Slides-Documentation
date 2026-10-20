---
title: PPTX 中图表大小调整的工作解决方案
type: docs
weight: 40
url: /zh/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表大小调整
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 嵌入的 Excel OLE 对象时，修复 PPTX 中意外的图表大小调整。设置固定图表尺寸，以保持图表和 OLE 框尺寸一致。"
---
## **概览**

使用 Aspose 组件在 PowerPoint 演示文稿中嵌入为 OLE 对象的 Excel 图表在首次激活后可能会改变大小。这会导致图表在激活前后的外观出现明显差异。本文解释了产生此类重新大小调整的原因，并展示了通过将固定图表尺寸匹配到 OLE 框来防止此问题的方法。

在[创建 Excel 图表并将其嵌入为演示文稿中的 OLE 对象](/slides/zh/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们解释了如何使用 Aspose.Cells for PHP via Java 创建 Excel 图表并使用 Aspose.Slides for PHP via Java 将其嵌入 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/php-java/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框。在输出的演示文稿中，当您双击显示图表图像的 OLE 对象框时，Excel 图表会被激活。用户可以编辑嵌入的 Excel 工作簿，然后通过点击激活工作簿之外的区域返回幻灯片。当用户返回幻灯片时，OLE 对象框的大小会发生变化，且重新大小调整的比例取决于 OLE 对象框和嵌入的 Excel 工作簿的原始尺寸。

## **导致大小调整的原因**

嵌入的 Excel 工作簿拥有自己的窗口尺寸，Excel 在对象首次激活时会尝试保持该尺寸。幻灯片上的 OLE 框则具有独立定义的尺寸。当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商对象的大小，以在嵌入过程中保持其比例。因此，工作簿窗口与 OLE 框之间的差异可能导致对象重新调整大小。

## **可行的解决方案**

将图表尺寸匹配到幻灯片上的 OLE 框，并保持图表尺寸独立于工作簿窗口。此方案适用于新建演示文稿或已有模板。

示例需要 Aspose.Cells for PHP via Java 和 Aspose.Slides for PHP via Java。使用相同的 PHP/Java Bridge 实例配置两款产品，加载两套 PHP 包装器，并使两套 Java 库可供桥接使用。无需输入文件。示例在活动图表工作表上创建一个简单的柱状图，并以 XLS 格式嵌入工作簿。未分配图表预览图像；图表将在 PowerPoint 中激活 OLE 对象时可见。

示例创建了一个新演示文稿，OLE 框尺寸为 9.5 × 4 英寸，左边距 0.5 英寸，顶边距 1 英寸。幻灯片坐标和尺寸使用点 (每英寸 72 点)。对于已有演示文稿，请参见[使用模板](#use-a-template)。

## **设置固定图表尺寸**

将[Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow)设为 false，以使图表尺寸独立于工作簿窗口。通过[Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width)和[Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height)设置[Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject)的尺寸，使用每英寸 96 像素将点转换为像素：684 × 288 点的框对应 912 × 384 像素的图表。将[Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize)设为[PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/)的 CUSTOM 值。示例使用[ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame)嵌入工作簿，并保存一个带有 9.5 × 4 英寸 OLE 框的演示文稿。

Java 数值结果在用作 PHP 索引之前通过 `java_values` 转换。将工作簿字节传递给[OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/)时仍保留在 Java 字节数组中。

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 幻灯片坐标和尺寸使用点（每英寸 72 点）。
        $width = 684; // 9.5 英寸。
        $height = 288; // 4 英寸。

        $chart->setSizeWithWindow(false);
        // 使用每英寸 96 像素将点转换为图表像素。
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **使用模板**

尺寸逻辑对已有演示文稿同样适用。要调整示例：

1. 加载模板演示文稿，而不是创建空白演示文稿。
1. 检查第一张幻灯片是否至少包含三个形状，然后使用索引为 2 的形状作为占位符。
1. 从该形状获取框的宽度和高度，而非使用固定值 684 和 288。保持尺寸计算不变。
1. 在占位符的位置添加 OLE 框，而不是使用固定坐标 36 和 72。
1. 在保存演示文稿之前删除占位符。

## **常见问题**

**为什么我的嵌入式 Excel 图表在 PowerPoint 中激活后会改变大小？**  
因为 Excel 在首次激活时尝试恢复原始窗口大小，而 PowerPoint 中的 OLE 对象框拥有自己的尺寸。PowerPoint 与 Excel 为保持宽高比而协商尺寸，这会导致重新大小调整。

**如何保持图表和 OLE 框尺寸一致？**  
设置与 OLE 框匹配的固定图表尺寸，并在嵌入工作簿之前使用自定义图表打印尺寸。上面的示例展示了所需的设置和单位换算。

**仅匹配工作簿窗口尺寸是否足够？**  
仅匹配工作簿窗口尺寸并不能可靠地防止 OLE 框在激活后改变大小。请使用示例中所示的固定图表尺寸。

**此方案是否适用于基于模板的演示文稿和新建演示文稿？**  
是的。对于模板，使用占位符的尺寸和位置。对于新建演示文稿，直接指定框的尺寸和位置。

**我可以将此示例用于其他电子表格程序创建的图表吗？**  
示例使用 Aspose.Cells 创建的 Excel 工作簿。它未展示其他电子表格程序的激活行为。

## **相关章节**

- [创建 Excel 图表并将其嵌入为演示文稿中的 OLE 对象](/slides/zh/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)