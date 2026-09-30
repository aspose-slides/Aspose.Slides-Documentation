---
title: Tùy chỉnh chú giải biểu đồ trong các bản trình bày bằng JavaScript
linktitle: Chú giải biểu đồ
type: docs
url: /vi/nodejs-java/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho Node.js thông qua Java để tối ưu hóa các bản trình bày PowerPoint với định dạng chú giải được thiết kế riêng."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong bản trình bày PowerPoint. Bài viết này cho thấy cách định vị và kích thước một chú giải, đặt kích thước phông chữ cho toàn bộ chú giải, định dạng một mục chú giải riêng lẻ, và ẩn hoặc khôi phục các mục đã chọn.

FAQ bao gồm các hành vi liên quan, bao gồm việc dành không gian cho chú giải, hiển thị nhãn đa dòng, và kế thừa định dạng từ chủ đề bản trình bày.

## **Vị trí chú giải**

Sử dụng các phương thức [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), và [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) của chú giải để chỉ định vị trí và kích thước của nó dưới dạng phần tỷ lệ của kích thước biểu đồ.

Ví dụ này tạo một bản trình bày và thêm một biểu đồ cột nhóm với dữ liệu mặc định vào slide đầu tiên. Việc chia các offset và kích thước mong muốn của chú giải cho chiều rộng và chiều cao của biểu đồ chuyển chúng thành các giá trị tương đối: chú giải được dịch chuyển 50 điểm từ góc trên‑trái của biểu đồ và có kích thước 100x100 điểm.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Diễn đạt vị trí và kích thước của chú giải so với biểu đồ.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt kích thước phông chữ cho chú giải**

Sử dụng [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) của chú giải để truy cập định dạng văn bản và sử dụng [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) để đặt kích thước phông chữ tính bằng điểm.

Ví dụ này tạo một biểu đồ với dữ liệu mặc định và đặt văn bản chú giải thành 20 điểm. Nó cũng vô hiệu hoá giới hạn tự động cho trục dọc và đặt phạm vi của trục từ -5 đến 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt kích thước phông chữ cho mục chú giải riêng lẻ**

Sử dụng tập hợp trả về bởi phương thức [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) của chú giải để truy cập định dạng cho một mục cụ thể. Các chỉ mục mục được đánh số bắt đầu từ 0, vì vậy chỉ mục `1` tương ứng với mục thứ hai.

Ví dụ này tạo một biểu đồ cột nhóm mà dữ liệu mặc định bao gồm ít nhất hai chuỗi. Nó định dạng mục chú giải thứ hai thành in đậm, in nghiêng và văn bản màu xanh dương có kích thước 20 điểm.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ẩn các mục chú giải riêng lẻ**

Để loại bỏ một chuỗi phụ trợ khỏi chú giải trong khi vẫn giữ dữ liệu của nó hiển thị, gọi [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) với `true` thông qua [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Điều này chỉ ẩn mục chú giải đã chọn; nó không xóa chuỗi hoặc các điểm dữ liệu của nó. Ngược lại, gọi [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) với `false` sẽ ẩn toàn bộ chú giải.

Ví dụ dưới đây tạo một biểu đồ cột nhóm với nhiều chuỗi sử dụng dữ liệu mặc định. Nó ẩn mục chú giải của chuỗi thứ hai (chỉ mục `1`) và lưu bản trình bày. Sau đó khôi phục mục này bằng cách gọi [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) với `false` và lưu một bản sao thứ hai. Các cột vẫn hiển thị trong cả hai tệp.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Khôi phục cùng mục mà không thay đổi dữ liệu biểu đồ.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

So sánh dưới đây cho thấy cùng một biểu đồ với tất cả các mục được hiển thị và với mục thứ hai bị ẩn. Các cột của chuỗi thứ hai vẫn không thay đổi.

![So sánh một biểu đồ với tất cả các mục chú giải hiển thị và với Series 2 bị ẩn khỏi chú giải; tất cả các cột vẫn hiển thị.](hide-legend-entry.png)

Trong các biểu đồ cột, thanh và đường, các mục chú giải xác định chuỗi. Đối với biểu đồ tròn, chúng xác định các điểm dữ liệu riêng lẻ (miếng), vì vậy sử dụng [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) trên miếng đã chọn thay thế. Tài liệu API mô tả phương thức điểm dữ liệu này cho các loại biểu đồ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` và `BarOfPie`. Đừng cho rằng nó áp dụng cho biểu đồ vòng donut, vì chúng không nằm trong danh sách đó.

## **Câu hỏi thường gặp**

**Có thể làm cho biểu đồ dành không gian cho chú giải thay vì chồng lên không?**

Có. Gọi [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) với `false` để dành không gian cho chú giải thay vì cho phép nó chồng lên vùng vẽ.

**Có thể tạo nhãn chú giải đa dòng không?**

Có. Các nhãn dài có thể tự động ngắt dòng khi chiều rộng khả dụng không đủ. Bạn cũng có thể dùng ký tự xuống dòng trong tên chuỗi để yêu cầu ngắt dòng.

**Làm sao để chú giải tuân theo bảng màu chủ đề của bản trình bày?**

Để màu, nền và phông chữ của chú giải không được đặt để nó có thể kế thừa định dạng chủ đề. Định dạng rõ ràng sẽ ghi đè các cài đặt chủ đề tương ứng.