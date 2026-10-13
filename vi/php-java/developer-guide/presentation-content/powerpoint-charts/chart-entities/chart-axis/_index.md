---
title: Tùy chỉnh trục biểu đồ trong bản trình bày bằng PHP
linktitle: Trục biểu đồ
type: docs
url: /vi/php-java/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
- điều chỉnh trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho PHP thông qua Java để tùy chỉnh trục biểu đồ trong các bản trình bày PowerPoint cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ với Aspose.Slides cho PHP thông qua Java. Nó bao gồm các giá trị trục tính toán, chuyển đổi hàng và cột biểu đồ, hiển thị trục, khoảng cách nhãn và dấu tick của danh mục, danh mục ngày và định dạng, xoay tiêu đề, vị trí trục, đơn vị hiển thị và tỉ lệ logarit.

## **Lấy Giá Trị Tối Đa trên Trục Dọc của Biểu Đồ**

Tạo một [Bản trình bày](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và thêm một biểu đồ khu vực với dữ liệu mặc định. Gọi [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) trước khi đọc các giá trị trục đã tính để bố cục biểu đồ được cập nhật.

Đọc [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) và [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) để lấy các giới hạn của trục, và [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) và [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) để lấy khoảng cách dấu tick. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) và [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) cung cấp tỉ lệ đơn vị thời gian, liên quan đến trục ngày. Ví dụ lưu các giá trị này vào các biến cục bộ và lưu biểu đồ.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hoán Đổi Dữ Liệu Giữa Các Trục**

Sử dụng [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) để hoán đổi vai trò của series và categories trong dữ liệu biểu đồ. Mỗi category cũ trở thành một series, và mỗi series cũ trở thành một category. Điều này thay đổi cách nhóm dữ liệu; nó không hoán đổi các trục ngang và dọc. Ví dụ sử dụng [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) để gắn dữ liệu mặc định vào `Sheet1!A1:D5`, bao gồm hàng tiêu đề và cột category, trước khi hoán đổi hàng và cột. Nó lưu một biểu đồ với bốn series và ba category.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vô Hiệu Hóa Trục Dọc cho Biểu Đồ Đường**

Gọi [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) với `false` trên trục dọc để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu lại với trục dọc bị ẩn.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vô Hiệu Hóa Trục Ngang cho Biểu Đồ Đường**

Gọi [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) với `false` trên trục ngang để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu lại với trục ngang bị ẩn.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Thay Đổi Trục Danh Mục**

Sử dụng [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) để chọn trục danh mục kiểu ngày hoặc văn bản. Ví dụ này yêu cầu `ExistingChart.pptx`, với một biểu đồ là hình dạng đầu tiên trên slide đầu và các ô danh mục chứa giá trị ngày dạng số Excel. Nó thay đổi trục ngang thành trục ngày. Gọi [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) với `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) với `1`, và [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) với `TimeUnitType::Months` để đặt các dấu tick chính ở khoảng một tháng.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kiểm Soát Khoảng Cách Nhãn Trục Danh Mục**

Khi một biểu đồ có nhiều category, giảm số lượng nhãn trục hiển thị mà không loại bỏ category hoặc điểm dữ liệu. Gọi [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) với `false`, sau đó truyền khoảng cách category mong muốn vào [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Đối với category văn bản theo thứ tự bình thường, đếm bắt đầu từ category đầu tiên:

| Khoảng cách | Nhãn hiển thị trong ví dụ |
| --- | --- |
| `1` | Danh mục 1, Danh mục 2, Danh mục 3, ... Danh mục 24 |
| `2` | Danh mục 1, Danh mục 3, Danh mục 5, ... Danh mục 23 |
| `3` | Danh mục 1, Danh mục 4, Danh mục 7, ... Danh mục 22 |

Khoảng cách `3` hiển thị mỗi nhãn thứ ba, để lại hai nhãn ẩn giữa các nhãn hiển thị. Nó không loại bỏ các cột tương ứng. Khoảng cách tự động chọn một khoảng dựa trên không gian có sẵn; nó không nhất thiết hiển thị mọi nhãn.

Các dấu tick có các điều khiển riêng. Gọi [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) với `false` và sử dụng [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) để đặt khoảng cách của chúng. Ví dụ, `1` giữ một dấu tick ở mỗi khoảng category trong khi nhãn chỉ xuất hiện mỗi ba category. Sử dụng [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) với kiểu hiển thị để bạn có thể thấy kết quả. Gọi lại bất kỳ setter khoảng cách tự động nào với `true` sẽ cho phép biểu đồ chọn lại khoảng cách đó.

Ví dụ tự chứa sau tạo 24 category và một series, sau đó lưu ba slide trong `CategoryAxisIntervals.pptx`: khoảng cách tự động, khoảng cách nhãn thủ công với các dấu tick độc lập, và khôi phục khoảng cách tự động. Hai bản sao giữ nguyên dữ liệu biểu đồ gốc. Không cần bản trình bày đầu vào. Văn bản nhãn ngang làm cho sự khác biệt về mật độ dễ nhìn thấy.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Slide 2: hiển thị mỗi nhãn thứ ba, nhưng giữ một dấu tick cho mỗi danh mục.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Slide 3: để biểu đồ chọn lại cả hai khoảng cách.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Khoảng cách tự động (slide 1):** Trong bản render này, mỗi nhãn category thứ hai được hiển thị và chuyển sang hai dòng. Kết quả tự động có thể thay đổi tùy theo kích thước biểu đồ, phông chữ và bộ render.

![Khoảng cách nhãn category tự động với tất cả 24 cột hiển thị](category-axis-automatic.png)

**Khoảng cách thủ công (slide 2):** Mỗi nhãn thứ ba được hiển thị trên một dòng, trong khi các dấu tick vẫn ở mỗi khoảng category. Tất cả 24 cột, bao gồm cả những cột không có nhãn, vẫn hiển thị với cùng giá trị. Slide 3 khôi phục lại giao diện tự động được hiển thị ở trên.

![Khoảng cách nhãn category thủ công ba với tất cả 24 cột hiển thị](category-axis-manual.png)

### **Chọn Trục và Khoảng Cách Phù Hợp**

Sử dụng khoảng cách đếm category này cho trục category dạng văn bản, như trục category của biểu đồ cột, đường, khu vực hoặc thanh. Trong biểu đồ cột, nó là trục ngang. Trong biểu đồ thanh ngang, trục category là trục dọc, vì vậy áp dụng các cài đặt này cho trục được trả về bởi [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Khoảng cách dấu tick cũng áp dụng cho trục series trong các biểu đồ có trục series.

Không sử dụng khoảng cách nhãn category để đặt thang số cho trục giá trị. Trên trục giá trị, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) chỉ định sự chênh lệch giá trị: ví dụ, một đơn vị chính `10` tạo các dấu tick ở 0, 10, 20, … khi trục bắt đầu từ 0. Một khoảng cách nhãn category `3` đếm vị trí category, bất kể giá trị dữ liệu của chúng. Các biểu đồ scatter và bubble sử dụng trục giá trị thay vì trục category dạng văn bản. Đối với trục ngày, sử dụng các đơn vị chính và thang thời gian như mô tả trong [Change a Category Axis](#change-a-category-axis).

## **Đặt Định Dạng Ngày cho Giá Trị Trục Category**

Ví dụ thay thế dữ liệu biểu đồ mặc định bằng bốn giá trị hàng năm. Các ngày được lưu dưới dạng số serial OLE Automation trong worksheet đầu tiên (chỉ mục `0`), tính bằng số ngày kể từ 30 tháng 12 năm 1899 cho các ngày này. Sử dụng [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) với `CategoryAxisType::Date`, gọi [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) với `false`, và truyền `yyyy` vào [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) để các nhãn category hiển thị năm bốn chữ số độc lập với định dạng ô.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt Góc Xoay cho Tiêu Đề Trục Biểu Đồ**

Gọi [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) với `true` trên trục dọc, cung cấp văn bản tiêu đề, và sử dụng [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) để xoay tiêu đề. Góc được đo bằng độ; ví dụ này lưu một biểu đồ cột với tiêu đề trục giá trị được xoay 90 độ.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt Vị Trí Trục trên Trục Category hoặc Giá Trị**

Sử dụng [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) để kiểm soát việc trục giá trị cắt qua trục category giữa các category hoặc tại các dấu tick của category. Cài đặt này áp dụng cho các trục category. Ví dụ này đặt nó thành `true` trên trục category ngang của biểu đồ cột và lưu kết quả.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt Đơn Vị Hiển Thị trên Trục Giá Trị của Biểu Đồ**

Sử dụng [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) để tỷ lệ các nhãn trên trục giá trị mà không thay đổi dữ liệu gốc. Với [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) đặt thành `Millions`, giá trị 60.000.000 sẽ hiển thị là 60. Ví dụ tạo một biểu đồ cột và áp dụng đơn vị hiển thị hàng triệu cho trục dọc của nó.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Cấu Hình Trục Giá Trị Logarit**

Trục giá trị logarit hữu ích khi các giá trị dương trải qua nhiều bậc độ. Ví dụ, một dịch vụ có thể nhận 10, 100, 1.000, 10.000 và 100.000 yêu cầu trong năm giai đoạn. Trên thang tuyến tính, các giá trị nhỏ hơn xuất hiện gần nhau ở gần zero. Thang logarit làm cho sự tăng trưởng tương đối của chúng dễ so sánh hơn: khoảng cách bằng nhau đại diện cho tỉ lệ bằng nhau chứ không phải hiệu số bằng nhau.

Gọi [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) với `true` trên trục giá trị và sử dụng [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) để chọn cơ số. Điều này thay đổi cách hiển thị các giá trị hiện có; nó không thay đổi dữ liệu hoặc thêm đường xu hướng logarit. Đường xu hướng là một tính năng riêng, biểu thị mối quan hệ phù hợp trong dữ liệu.

### **Chọn Trục Giá Trị và Cơ Số**

Đối với biểu đồ đường hoặc cột, trục giá trị được trả về bởi [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Đối với biểu đồ thanh ngang, trục này được trả về bởi [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Các biểu đồ scatter và bubble có hai trục giá trị, vì vậy chọn trục ngang cho giá trị X, trục dọc cho giá trị Y, hoặc cả hai. Không áp dụng tỉ lệ logarit cho trục category.

Cơ số logarit mặc định là `10`. Đối với biểu đồ PPTX, sử dụng cơ số từ `2` đến `1000`, bao gồm; các cơ số phân số như `2.5` cũng được hỗ trợ. Với cơ số `10`, các lũy thừa liên tiếp như 10, 100, 1.000, và 10.000 được cách đều nhau.

### **So Sánh Thang Tuyến Tính và Logarit**

Ví dụ tự chứa sau tạo một biểu đồ đường với năm số yêu cầu trên slide đầu, sau đó sao chép slide đó và bật trục giá trị logarit cơ số 10 trên slide thứ hai. Cả hai slide giữ nguyên dữ liệu.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Giữ slide đầu tiên ở dạng tuyến tính và chỉ thay đổi thang trục giá trị của bản sao.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Thang tuyến tính (slide 1):** Khoảng cách dọc bằng nhau đại diện cho sự chênh lệch bằng nhau trong số lượt yêu cầu. Giá trị lớn nhất chiếm ưu thế trên biểu đồ, khiến các giá trị nhỏ hơn khó phân biệt.

![Biểu đồ đường trong PowerPoint hiển thị năm số yêu cầu trên trục giá trị tuyến tính](value-axis-linear.png)

**Thang logarit (slide 2):** Khoảng cách dọc bằng nhau đại diện cho tỉ lệ bằng nhau. Mỗi giai đoạn có số yêu cầu gấp mười lần so với giai đoạn trước, vì vậy các điểm tạo thành một đường thẳng tăng trên thang cơ số 10. Các nhãn trục vẫn hiển thị số lượt yêu cầu gốc.

![Cùng năm số yêu cầu trong PowerPoint trên trục giá trị logarit cơ số 10](value-axis-logarithmic.png)

### **Xử Lý Giá Trị Zero và Âm**

Thang logarit chỉ có thể hiển thị các giá trị dương tuyệt đối. Kiểm tra dữ liệu trước khi bật tính năng này. Nếu các giá trị zero hoặc âm có ý nghĩa, giữ thang tuyến tính hoặc hiển thị chúng riêng biệt. Nếu việc loại bỏ các giá trị này phù hợp với phân tích, giải thích lý do loại bỏ. Không được thay thế chúng một cách âm thầm bằng các số dương nhỏ, vì điều này làm thay đổi ý nghĩa của dữ liệu. Bất kỳ giá trị tối thiểu hoặc tối đa nào được cấu hình thủ công cho trục logarit cũng phải là dương.

## **CÂU HỎI THƯỜNG GẶP**

**Làm sao để đặt giá trị mà một trục cắt qua trục còn lại (điểm giao trục)?**

Sử dụng [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) để chọn hành vi giao trục. Để chỉ định một giá trị giao cắt số, sử dụng [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Các cài đặt này cho phép bạn di chuyển giao trục tới một mức cơ sở phù hợp.

**Làm sao để định vị nhãn tick so với trục?**

Gọi [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) bằng cách sử dụng [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, hoặc `None`. Để kiểm soát các dấu tick, sử dụng [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) hoặc [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); chúng độc lập với vị trí nhãn.