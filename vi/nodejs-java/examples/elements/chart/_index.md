---
title: Biểu đồ
type: docs
weight: 60
url: /vi/nodejs-java/examples/elements/chart/
keywords:
- ví dụ mã
- biểu đồ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Thành thạo việc tạo biểu đồ với Aspose.Slides cho Node.js thông qua Java: tạo, định dạng, ràng buộc dữ liệu và xuất biểu đồ sang PPT, PPTX và ODP với các ví dụ JavaScript."
---
Ví dụ về việc thêm, truy cập, xóa và cập nhật các loại biểu đồ khác nhau với **Aspose.Slides for Node.js via Java**. Các đoạn mã dưới đây minh họa các thao tác cơ bản với biểu đồ.

## **Thêm biểu đồ**

Phương pháp này thêm một biểu đồ vùng đơn giản vào slide đầu tiên.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Thêm một biểu đồ khu vực đơn giản vào slide đầu tiên.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập biểu đồ**

Sau khi tạo biểu đồ, bạn có thể lấy nó thông qua bộ sưu tập hình dạng.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Truy cập biểu đồ đầu tiên trên slide.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa biểu đồ**

Mã sau đây xóa biểu đồ khỏi slide.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Xóa biểu đồ.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Cập nhật dữ liệu biểu đồ**

Bạn có thể thay đổi các thuộc tính của biểu đồ như tiêu đề.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Thay đổi tiêu đề biểu đồ.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```