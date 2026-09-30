---
title: Tùy chỉnh chú giải biểu đồ trong các bản trình bày bằng PHP
linktitle: Chú giải biểu đồ
type: docs
url: /vi/php-java/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho PHP qua Java để tối ưu hóa các bản trình bày PowerPoint với định dạng chú giải được điều chỉnh."
---
## **Tổng quan**

Aspose.Slides for PHP via Java cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong các bản thuyết trình PowerPoint. Bài viết này trình bày cách định vị và kích thước cho chú giải, đặt kích thước phông chữ cho toàn bộ chú giải, định dạng một mục chú giải riêng lẻ, và ẩn hoặc khôi phục các mục đã chọn.

Phần Câu hỏi thường gặp đề cập đến các hành vi liên quan, bao gồm việc dành không gian cho chú giải, hiển thị nhãn đa dòng, và kế thừa định dạng từ giao diện chủ đề của bản trình bày.

## **Định vị chú giải**

Sử dụng các phương thức [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), và [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) của chú giải để chỉ định vị trí và kích thước của nó dưới dạng tỷ lệ của kích thước biểu đồ.

Ví dụ này tạo một bản trình bày và thêm một biểu đồ cột nhóm với dữ liệu mặc định vào slide đầu tiên. Việc chia các offset và kích thước mong muốn của chú giải cho chiều rộng và chiều cao của biểu đồ chuyển chúng thành các giá trị tương đối: chú giải được dịch 50 điểm so với góc trên‑trái của biểu đồ và có kích thước 100 x 100 điểm. Ví dụ sử dụng java_values để chuyển đổi kích thước biểu đồ được PHP/Java Bridge trả về sang số PHP trước khi chia.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Diễn đạt vị trí và kích thước của chú giải tương đối với biểu đồ.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt kích thước phông chữ cho chú giải**

Sử dụng [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) của chú giải để truy cập định dạng văn bản và dùng [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) để đặt kích thước phông chữ tính bằng điểm.

Ví dụ này tạo một biểu đồ với dữ liệu mặc định và đặt văn bản chú giải thành 20 điểm. Nó cũng tắt giới hạn tự động cho trục dọc và đặt phạm vi của nó từ -5 đến 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt kích thước phông chữ cho một mục chú giải riêng lẻ**

Sử dụng bộ sưu tập trả về bởi phương thức [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) của chú giải để truy cập định dạng cho một mục cụ thể. Các chỉ mục mục được đánh số từ 0, vì vậy chỉ mục `1` đề cập tới mục thứ hai.

Ví dụ này tạo một biểu đồ cột nhóm mà dữ liệu mặc định bao gồm ít nhất hai chuỗi. Nó định dạng mục chú giải thứ hai với văn bản đậm, nghiêng và màu xanh 20 điểm.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ẩn các mục chú giải riêng lẻ**

Để loại bỏ một chuỗi phụ khỏi chú giải trong khi vẫn giữ dữ liệu của nó hiển thị, gọi [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) với `true` thông qua [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Điều này chỉ ẩn mục chú giải đã chọn; nó không xóa chuỗi hoặc các điểm dữ liệu của nó. Ngược lại, gọi [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) với `false` sẽ ẩn toàn bộ chú giải.

Ví dụ dưới đây tạo một biểu đồ cột nhóm với nhiều chuỗi sử dụng dữ liệu mặc định. Nó ẩn mục chú giải của chuỗi thứ hai (chỉ mục `1`) và lưu bản trình bày. Sau đó khôi phục mục này bằng cách gọi [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) với `false` và lưu một bản sao thứ hai. Các cột vẫn hiển thị trong cả hai tệp.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Khôi phục lại mục tương tự mà không thay đổi dữ liệu biểu đồ.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

So sánh bên dưới cho thấy cùng một biểu đồ với tất cả các mục hiển thị và với mục thứ hai bị ẩn. Các cột của chuỗi thứ hai không thay đổi.

![So sánh một biểu đồ với tất cả các mục chú giải hiển thị và với Dòng 2 ẩn khỏi chú giải; tất cả các cột vẫn hiển thị.](hide-legend-entry.png)

Trong các biểu đồ cột, thanh và đường, các mục chú giải xác định chuỗi. Đối với biểu đồ bánh, chúng xác định các điểm dữ liệu riêng lẻ (miếng), vì vậy hãy sử dụng [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) trên miếng đã chọn thay thế. API tài liệu phương thức điểm dữ liệu này cho các loại biểu đồ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` và `BarOfPie`. Đừng cho rằng nó áp dụng cho biểu đồ vòng donut, vì chúng không nằm trong danh sách đó.

## **Câu hỏi thường gặp**

**Tôi có thể làm cho biểu đồ dành không gian cho chú giải thay vì chồng lên nó không?**

Có. Gọi [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) với `false` để dành không gian cho chú giải thay vì cho phép nó chồng lên vùng vẽ.

**Tôi có thể tạo nhãn chú giải đa dòng không?**

Có. Các nhãn dài có thể tự động ngắt dòng khi chiều rộng có sẵn không đủ. Bạn cũng có thể sử dụng ký tự xuống dòng trong tên chuỗi để yêu cầu ngắt dòng.

**Làm sao để chú giải tuân theo bảng màu của chủ đề bản trình bày?**

Để trống các màu, nền và phông chữ của chú giải để nó có thể kế thừa định dạng của chủ đề. Định dạng rõ ràng sẽ ghi đè các cài đặt chủ đề tương ứng.