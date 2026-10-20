---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 40
url: /vi/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Sửa lỗi thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng đối tượng Excel OLE nhúng với Aspose.Slides cho PHP qua Java. Đặt kích thước biểu đồ cố định để giữ cho biểu đồ và khung OLE có kích thước nhất quán."
---
## **Tổng quan**

Biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước sau lần kích hoạt đầu tiên. Điều này có thể gây ra sự khác biệt đáng chú ý về diện mạo của biểu đồ trước và sau khi kích hoạt. Bài viết này giải thích tại sao việc thay đổi kích thước xảy ra và chỉ ra cách ngăn ngừa bằng cách khớp kích thước biểu đồ cố định với khung OLE.

In [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình chiếu](/slides/vi/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for PHP via Java and embed it in a PowerPoint presentation using Aspose.Slides for PHP via Java. To address the [vấn đề xem trước đối tượng](/slides/vi/php-java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Nguyên nhân gây thay đổi kích thước**

The embedded Excel workbook has its own window dimensions, which Excel tries to retain when the object is first activated. The OLE frame on the slide has independently defined dimensions. When the Excel workbook is activated, Excel and PowerPoint negotiate the object's size to maintain its proportions as part of the embedding process. Differences between the workbook window and the OLE frame can therefore cause the object to resize.

## **Giải pháp hoạt động**

Match the chart size to the OLE frame on the slide and keep the chart dimensions independent of the workbook window. This solution works with a new presentation or an existing template.

The example requires Aspose.Cells for PHP via Java and Aspose.Slides for PHP via Java. Configure both products with the same PHP/Java Bridge instance, load both PHP wrappers, and make both Java libraries available to the bridge. No input files are required. It creates a simple column chart on an active chart sheet and embeds the workbook in XLS format. No chart preview image is assigned; the chart becomes visible when the OLE object is activated in PowerPoint.

The example creates a new presentation with a 9.5 × 4-inch OLE frame positioned 0.5 inches from the left edge and 1 inch from the top. Slide coordinates and dimensions are in points (72 points per inch). For an existing presentation, see [Sử dụng mẫu](#use-a-template).

## **Đặt kích thước biểu đồ cố định**

Set [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) to false so that the chart dimensions are independent of the workbook window. Set the [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) dimensions through [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) and [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) to the CUSTOM value of [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). The example embeds the workbook with [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) and saves a presentation with a 9.5 × 4-inch OLE frame.

Java numeric results are converted with `java_values` before they are used as PHP indices. The workbook bytes remain in a Java byte array when passed to [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

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

        // Tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch).
        $width = 684; // 9,5 inch.
        $height = 288; // 4 inch.

        $chart->setSizeWithWindow(false);
        // Chuyển đổi điểm sang pixel biểu đồ bằng cách sử dụng 96 pixel mỗi inch.
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

## **Sử dụng mẫu**

The sizing logic is the same for an existing presentation. To adapt the example:

1. Load the template presentation instead of creating an empty presentation.  
1. Check that the first slide contains at least three shapes, then use the shape at index 2 as the placeholder.  
1. Take the frame width and height from that shape instead of using the fixed values 684 and 288. Keep the sizing calculations unchanged.  
1. Add the OLE frame at the placeholder's position instead of the fixed coordinates 36 and 72.  
1. Remove the placeholder before saving the presentation.  

## **Câu hỏi thường gặp**

**Why does my embedded Excel chart change size after activating it in PowerPoint?**  
This happens because Excel tries to restore the original window size when first activated, whereas the OLE object frame in PowerPoint has its own dimensions. PowerPoint and Excel negotiate the size to maintain the aspect ratio, which can cause the resizing.

**How can I keep the chart and OLE frame sizes consistent?**  
Set fixed chart dimensions that match the OLE frame and use a custom chart print size before embedding the workbook. The example above shows the required settings and unit conversions.

**Is matching the workbook window size sufficient?**  
Matching the workbook window size alone does not reliably prevent the OLE frame from changing size after activation. Use fixed chart dimensions as shown in the example.

**Does this solution work with both template-based presentations and new presentations?**  
Yes. For a template, use the placeholder's dimensions and position. For a new presentation, specify the frame dimensions and position directly.

**Can I use this example with charts created in other spreadsheet programs?**  
The example uses an Excel workbook created with Aspose.Cells. It does not demonstrate activation behavior for other spreadsheet programs.

## **Các phần liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình chiếu](/slides/vi/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)