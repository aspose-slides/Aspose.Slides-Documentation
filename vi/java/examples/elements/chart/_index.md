---
title: Biểu đồ
type: docs
weight: 60
url: /vi/java/examples/elements/chart/
keywords:
- ví dụ mã
- biểu đồ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Thành thạo biểu đồ với Aspose.Slides cho Java: tạo, định dạng, ràng buộc dữ liệu và xuất biểu đồ dưới dạng PPT, PPTX và ODP với các ví dụ Java."
---
Ví dụ về việc thêm, truy cập, xóa và cập nhật các loại biểu đồ khác nhau với **Aspose.Slides for Java**. Các đoạn mã dưới đây minh họa các thao tác cơ bản với biểu đồ.

## **Thêm biểu đồ**
Phương pháp này thêm một biểu đồ khu vực đơn giản vào slide đầu tiên.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Thêm một biểu đồ khu vực đơn giản vào slide đầu tiên.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập biểu đồ**
Sau khi tạo biểu đồ, bạn có thể lấy nó thông qua bộ sưu tập hình dạng.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Truy cập biểu đồ đầu tiên trên slide.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa biểu đồ**
Đoạn mã sau sẽ xóa một biểu đồ khỏi slide.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Xóa biểu đồ.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Cập nhật dữ liệu biểu đồ**
Bạn có thể thay đổi các thuộc tính của biểu đồ như tiêu đề.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Thay đổi tiêu đề biểu đồ.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```