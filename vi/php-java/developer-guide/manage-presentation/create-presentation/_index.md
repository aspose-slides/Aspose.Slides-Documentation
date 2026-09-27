---
title: Tạo Bản Trình Chiếu trong PHP
linktitle: Tạo Bản Trình Chiếu
type: docs
weight: 10
url: /vi/php-java/create-presentation/
keywords:
- tạo bản trình chiếu
- bản trình chiếu mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo bản trình chiếu với Aspose.Slides cho PHP thông qua Java — tạo các tệp PPT, PPTX và ODP và lưu chúng một cách lập trình để đạt kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo một bản trình chiếu trong Aspose.Slides, thêm một hộp văn bản vào slide đầu tiên và lưu kết quả dưới dạng file. Nó cũng mô tả cách tạo và lưu một bản trình chiếu trống, và cách mở một bản trình chiếu hiện có ở định dạng được hỗ trợ và lưu nó sang định dạng khác. Một mục FAQ ngắn ở cuối đề cập tới các câu hỏi thường gặp về định dạng, mẫu, kích thước slide, đơn vị, việc sử dụng bộ nhớ, đa luồng, cấp phép, chữ ký số và hỗ trợ VBA.

Trước khi bắt đầu, cài đặt Aspose.Slides cho PHP thông qua Java bằng Composer và khởi động PHP/Java Bridge trên Apache Tomcat. Xem [Installation](/slides/vi/php-java/installation/) để biết cài đặt đầy đủ. Các ví dụ dưới đây giả sử Tomcat đang chạy trên `localhost:8080` và thư mục `vendor` của Composer nằm cạnh script.

## **Tạo bản trình chiếu PowerPoint**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Một bản trình chiếu mới đã chứa sẵn một slide trống.  
1. Lấy slide đó từ bộ sưu tập trả về bởi [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/), bằng chỉ số 0.  
1. Thêm một hình chữ nhật bằng phương thức [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) và đặt văn bản bằng [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/).  
1. Lưu bản trình chiếu dưới dạng file PPTX bằng phương thức [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/).

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/vi/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hai dòng `require_once` tải client PHP/Java Bridge từ Tomcat và các lớp Aspose.Slides từ gói Composer. Góc trên‑trái của hình chữ nhật cách mép trái 50 điểm và cách mép trên 50 điểm của slide, và hình chữ nhật có chiều rộng 400 điểm và chiều cao 100 điểm. File đã lưu chứa một slide với hình chữ nhật đó và văn bản của nó. Khi không có giấy phép, Aspose.Slides cũng thêm một dấu mạ đánh dấu đánh giá vào mỗi slide mà nó lưu; xem [Licensing](/slides/vi/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides đọc và ghi các file bên trong Tomcat, không phải trong tiến trình PHP của bạn, vì vậy một đường dẫn tương đối như `"hello.pptx"` sẽ được giải quyết dựa trên thư mục làm việc của Tomcat. Các ví dụ trên trang này tạo đường dẫn tuyệt đối bằng `__DIR__`, vì vậy các file được đọc từ và lưu cạnh script.
{{% /alert %}}

## **Tạo và lưu một bản trình chiếu**

Để tạo một bản trình chiếu trống và lưu nó, tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và lưu nó ở bất kỳ định dạng nào của enumeration [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/). Kết quả là một bản trình chiếu có một slide trống.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/vi/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mở và lưu một bản trình chiếu**

Để chuyển đổi một bản trình chiếu từ định dạng này sang định dạng khác, mở nó bằng cách truyền đường dẫn vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), sau đó lưu nó ở định dạng mục tiêu. Aspose.Slides tự động phát hiện định dạng đầu vào, như PPT, PPTX hoặc ODP, từ chính file.

Ví dụ dưới đây giả sử có một bản trình chiếu OpenDocument tên *Sample.odp* nằm cạnh script và lưu nó dưới dạng PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/vi/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

### Tôi có thể lưu bản trình chiếu mới sang những định dạng nào?

Bạn có thể lưu dưới dạng [PPTX, PPT, và ODP](/slides/vi/php-java/save-presentation/), và xuất ra [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/php-java/convert-powerpoint-to-xps/), [HTML](/slides/vi/php-java/convert-powerpoint-to-html/), [SVG](/slides/vi/php-java/render-a-slide-as-an-svg-image/), và [images](/slides/vi/php-java/convert-powerpoint-to-png/), trong số các định dạng khác.

### Tôi có thể bắt đầu từ mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/php-java/supported-file-formats/).

### Làm sao để kiểm soát kích thước/ tỷ lệ khung hình của slide khi tạo bản trình chiếu?

Đặt [kích thước slide](/slides/vi/php-java/slide-size/) (bao gồm các cài đặt sẵn như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được thu phóng.

### Đơn vị đo kích thước và tọa độ là gì?

Bằng điểm: 1 inch tương đương 72 đơn vị.

### Làm sao để xử lý các bản trình chiếu rất lớn (có nhiều tệp media) để giảm việc sử dụng bộ nhớ?

Sử dụng [chiến lược quản lý BLOB](/slides/vi/php-java/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng các tệp tạm, và ưu tiên quy trình dựa trên tệp thay vì chỉ dùng luồng trong bộ nhớ.

### Tôi có thể tạo/lưu các bản trình chiếu song song không?

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/php-java/multithreading/). Hãy chạy các thể hiện riêng biệt, cô lập cho mỗi luồng hoặc tiến trình.

### Làm sao để loại bỏ dấu mạ dùng thử và các hạn chế?

[Áp dụng giấy phép](/slides/vi/php-java/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị chỉnh sửa, và việc thiết lập giấy phép nên được đồng bộ nếu có nhiều luồng tham gia.

### Tôi có thể ký số PPTX tôi tạo không?

Có. [Chữ ký số](/slides/vi/php-java/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bản trình chiếu.

### Các macro (VBA) có được hỗ trợ trong các bản trình chiếu được tạo không?

Có. Bạn có thể [tạo/chỉnh sửa dự án VBA](/slides/vi/php-java/presentation-via-vba/) và lưu các tệp hỗ trợ macro như PPTM/PPSM.