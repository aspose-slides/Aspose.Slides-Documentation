---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trong PHP
linktitle: Đường Xu Hướng
type: docs
url: /vi/php-java/trend-line/
keywords:
- biểu đồ
- đường xu hướng
- đường xu hướng hàm mũ
- đường xu hướng tuyến tính
- đường xu hướng logarit
- đường xu hướng trung bình di chuyển
- đường xu hướng đa thức
- đường xu hướng lũy thừa
- đường xu hướng tùy chỉnh
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint với Aspose.Slides cho PHP qua Java — một hướng dẫn thực tế để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi biểu đồ, và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, hàm tuyến tính, hàm logarit, trung bình di chuyển, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Hỏi‑Đáp ngắn về giá trị chiếu của đường xu hướng về phía trước và phía sau cũng như việc các đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi hiển thị biểu đồ dưới dạng ảnh hay không.

## **Thêm Đường Xu Hướng**

Sử dụng [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) để thêm một đường xu hướng vào chuỗi biểu đồ, chọn loại bằng [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). Ví dụ tạo một biểu đồ cột nhóm với dữ liệu mặc định và thêm hai đường xu hướng vào mỗi ba chuỗi của nó.

Đường xu hướng hàm mũ ẩn phương trình và giá trị R‑bình phương thông qua [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) và [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), trong khi đường xu hướng tuyến tính có màu đỏ. Đường xu hướng logarit sử dụng [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) để đặt nhãn tùy chỉnh. Đường trung bình di chuyển sử dụng một [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) của ba điểm dữ liệu và một [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/) tùy chỉnh.

Đường xu hướng đa thức có bậc ba, được đặt qua [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), và mở rộng một danh mục về phía trước qua [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). Đường xu hướng lũy thừa mở rộng một danh mục về phía sau qua [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt Giao Cắt Đường Xu Hướng**

Sử dụng [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) để cố định giá trị Y của đường xu hướng tại X = 0. Cài đặt này hỗ trợ cho các đường xu hướng tuyến tính, hàm mũ và đa thức.

Ví dụ, mô hình chi phí sản xuất có thể cần bắt đầu ở chi phí cố định đã biết là 100, ngay cả khi các đo lường ở mức sản xuất không bằng không cho thấy một đường cơ sở khác. Đối với đường xu hướng tuyến tính, việc cố định giao cắt buộc phương trình `y = ax + b` thành `b = 100`; độ dốc được điều chỉnh cho dữ liệu dưới ràng buộc đó. Nó không chỉ di chuyển một đường đã được điều chỉnh sẵn. Cài đặt giao cắt trục chỉ kiểm soát nơi các trục biểu đồ gặp nhau, không phải các hệ số của đường xu hướng đã được điều chỉnh.

Ví dụ sau tạo một biểu đồ phân tán (XY) với khối lượng sản xuất từ 1 đến 4 và chi phí 170, 200, 230 và 260. Nó lưu biểu đồ với giao cắt tự động mặc định, đặt giao cắt thành 100, và lưu một PPTX thứ hai. Hai tệp chỉ khác nhau ở cài đặt giao cắt. Đường xu hướng hiển thị phương trình và mở rộng trở lại X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Với phép tính tự động, các dữ liệu này tạo ra `y = 30x + 140`. Đặt giao cắt thành 100 thay vào đó cho ra khoảng `y = 43.33x + 100`: giá trị điều chỉnh tại không khớp với đường cơ sở đã biết, trong khi đường không còn đi qua mọi điểm dữ liệu nữa.

| Giao cắt tự động | Giao cắt cố định 100 |
| --- | --- |
| ![Đường xu hướng tuyến tính với giao cắt được tính tự động là 140](intercept-automatic.png) | ![Đường xu hướng tuyến tính với giao cắt cố định là 100](intercept-fixed.png) |

Cả hai hình ảnh đều sử dụng cùng một dữ liệu và tỉ lệ trục. Các đường xu hướng được mở rộng trở lại X = 0 để hiển thị giao cắt của chúng.

Mặc định, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) trả về `NaN`, đại diện cho một giao cắt chưa xác định thay vì bằng không. Khi đó giao cắt được tính tự động từ dữ liệu.

## **Thêm Đường Tùy Chỉnh**

Đường tùy chỉnh là một hình dạng được vẽ lên trên biểu đồ thay vì một đường xu hướng được tính từ dữ liệu chuỗi. Ví dụ này sử dụng [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) để thêm một đường ngang vào slide phía trên biểu đồ. Vị trí của đường được chỉ định bằng tọa độ slide, đo bằng điểm, vì vậy nó bắt đầu ở cạnh trái của biểu đồ và nằm giữa chiều cao của biểu đồ. Độ rộng của nó khớp với độ rộng của biểu đồ. Phương thức [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) cung cấp cho đường một màu đỏ đặc.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**‘forward’ và ‘backward’ có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu về phía trước/ phía sau: đối với biểu đồ phân tán (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải phân tán — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình chiếu sang PDF hoặc SVG, hoặc khi hiển thị slide thành ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình chiếu sang [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/) hoặc [SVG](/slides/vi/php-java/render-a-slide-as-an-svg-image/) và hiển thị biểu đồ dưới dạng ảnh; các đường xu hướng, như một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương thức cũng có sẵn để [export an image of the chart](/slides/vi/php-java/create-shape-thumbnails/) tự nó.