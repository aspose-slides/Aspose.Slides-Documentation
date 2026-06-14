---
title: Biểu đồ
type: docs
weight: 60
url: /vi/php-java/examples/elements/chart/
keywords:
- biểu đồ
- thêm biểu đồ
- truy cập biểu đồ
- xóa biểu đồ
- cập nhật biểu đồ
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ trong PHP với Aspose.Slides: thêm dữ liệu, định dạng chuỗi, trục và nhãn, thay đổi kiểu, và xuất ra—hỗ trợ PPT, PPTX và ODP."
---
Ví dụ về việc thêm, truy cập, xóa và cập nhật các loại biểu đồ khác nhau với **Aspose.Slides for PHP via Java**. Các đoạn mã dưới đây minh họa các thao tác cơ bản trên biểu đồ.

## **Thêm biểu đồ**

Phương thức này thêm một biểu đồ khu vực đơn giản vào slide đầu tiên.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Thêm một biểu đồ cột đơn giản vào slide.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập biểu đồ**

Lấy biểu đồ từ bộ sưu tập hình dạng.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập biểu đồ đầu tiên trên slide.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa biểu đồ**

Đoạn mã sau sẽ xóa một biểu đồ khỏi slide.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là biểu đồ.
        $chart = $slide->getShapes()->get_Item(0);

        // Xóa biểu đồ.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Cập nhật dữ liệu biểu đồ**

Bạn có thể thay đổi các thuộc tính của biểu đồ như tiêu đề.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là biểu đồ.
        $chart = $slide->getShapes()->get_Item(0);

        // Thay đổi tiêu đề biểu đồ.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```