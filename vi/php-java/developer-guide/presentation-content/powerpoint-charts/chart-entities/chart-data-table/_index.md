---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong các bản trình chiếu bằng PHP
linktitle: Bảng Dữ Liệu
type: docs
url: /vi/php-java/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tùy chỉnh phông chữ, viền và ký hiệu chú giải của bảng dữ liệu biểu đồ trong các bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Aspose.Slides cho PHP thông qua Java cho phép bạn hiển thị bảng dữ liệu của biểu đồ và tùy chỉnh định dạng văn bản, viền và các ký hiệu chú giải. Bài viết này giải thích cách bật bảng, định dạng văn bản, kiểm soát từng loại viền và hiển thị hoặc Ẩn các ký hiệu chú giải. Các ví dụ lưu biểu đồ đã cấu hình vào tệp PPTX.

## **Đặt Thuộc Tính Phông Chữ**

Để hiển thị bảng dữ liệu của biểu đồ, truyền `true` vào [setDataTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/setdatatable/). Sử dụng [getChartDataTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/getchartdatatable/) để truy cập bảng và cấu hình định dạng văn bản của nó.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Thêm một biểu đồ cột nhóm vào slide đầu tiên.
1. Bật bảng dữ liệu của biểu đồ.
1. Bật chữ đậm bằng [setFontBold](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setFontBold) và truyền `20` vào [setFontHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setFontHeight) để có văn bản 20 điểm.
1. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ sau yêu cầu tệp `test.pptx` trong thư mục làm việc có ít nhất một slide. Nó thêm một biểu đồ với dữ liệu mặc định tại vị trí (50, 50), với chiều rộng 600 điểm và chiều cao 400 điểm. Tệp `output.pptx` đã lưu chứa biểu đồ với bảng dữ liệu được bật và các cài đặt phông chữ đã chỉ định được áp dụng.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tùy Chỉnh Viền Bảng Dữ Liệu**

Bật bảng bằng [Chart::setDataTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/setdatatable/) và truy cập nó qua [Chart::getChartDataTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/getchartdatatable/). Bạn có thể kiểm soát ba loại viền một cách độc lập:

- [setBorderHorizontal](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datatable/setborderhorizontal/) điều khiển viền ô ngang.
- [setBorderVertical](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datatable/setbordervertical/) điều khiển viền ô dọc.
- [setBorderOutline](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datatable/setborderoutline/) điều khiển viền ngoài của bảng.

Truyền `true` vào mỗi phương thức để hiển thị viền hoặc `false` để ẩn chúng. Ví dụ sau tạo một biểu đồ cột nhóm với dữ liệu mặc định, hiển thị viền ngang và viền ngoài, và ẩn viền dọc. Nó không yêu cầu tệp đầu vào. Vị trí và kích thước của biểu đồ được chỉ định bằng điểm.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

So sánh dưới đây sử dụng cùng dữ liệu biểu đồ và cài đặt ký hiệu chú giải trong bốn trường hợp. Bắt đầu với mọi viền được bật, mỗi biến thể còn lại sẽ tắt chỉ một cài đặt viền. Biến thể dưới trái khớp với cài đặt viền trong ví dụ.

![Bảng dữ liệu biểu đồ với mọi viền được bật, không có viền ngang, không có viền dọc và không có viền ngoài](data-table-borders.png)

## **Hiển Thị Hoặc Ẩn Ký Hiệu Chú Giải**

Ký hiệu chú giải là các dấu màu nhỏ bên cạnh tên series trong bảng dữ liệu. Chúng giúp người đọc ghép mỗi hàng bảng với một series của biểu đồ. Truyền `true` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datatable/setshowlegendkey/) để hiển thị các dấu này hoặc `false` để ẩn chúng.

Chú giải riêng của biểu đồ được kiểm soát bằng [Chart::setLegend](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/setlegend/). Các cài đặt này độc lập: ẩn chú giải riêng không ẩn các ký hiệu trong bảng dữ liệu, và ẩn ký hiệu của bảng không ẩn chú giải riêng.

Ví dụ sau tạo một biểu đồ với dữ liệu mặc định, bật bảng dữ liệu, và hiển thị các ký hiệu chú giải bên trong bảng trong khi ẩn chú giải riêng. Tất cả các viền của bảng được bật rõ ràng. Không yêu cầu bản trình chiếu đầu vào. Để chỉ ẩn các ký hiệu của bảng, truyền `false` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

So sánh dưới đây hiển thị cùng một bảng với ký hiệu chú giải được bật và bị tắt. Tất cả viền vẫn được bật, và chú giải riêng của biểu đồ được ẩn trong cả hai trường hợp.

![Bảng dữ liệu biểu đồ với ký hiệu chú giải hiển thị ở bên trái và ẩn ở bên phải](data-table-legend-keys.png)

## **FAQ**

**Tôi có thể hiển thị ký hiệu chú giải trong bảng dữ liệu của biểu đồ không?**

Có. Truyền `true` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datatable/setshowlegendkey/) để hiển thị ký hiệu chú giải hoặc `false` để ẩn chúng.

**Bảng dữ liệu có được giữ lại khi xuất bản trình chiếu sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ và bảng dữ liệu đã hiển thị như một phần của slide khi xuất sang [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/vi/php-java/convert-powerpoint-to-html/), hoặc [hình ảnh](/slides/vi/php-java/convert-powerpoint-to-png/).

**Tôi có thể làm việc với bảng dữ liệu trong biểu đồ được tải từ mẫu không?**

Có. Đối với biểu đồ được tải từ bản trình chiếu hoặc mẫu hiện có, sử dụng [hasDataTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/hasdatatable/) và [setDataTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/setdatatable/) để kiểm tra hoặc thay đổi việc bảng dữ liệu có được hiển thị hay không.

**Làm sao tôi có thể tìm các biểu đồ có bảng dữ liệu được bật?**

Duyệt qua các shape trên mỗi slide, xác định các biểu đồ, và gọi phương thức [hasDataTable](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/hasdatatable/) của chúng. Giá trị `true` cho biết bảng dữ liệu được bật.