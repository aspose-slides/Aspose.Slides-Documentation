---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /vi/php-java/
keywords:
- tài liệu
- xử lý bản trình chiếu
- chuyển đổi bản trình chiếu
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Bắt đầu tại đây: cài đặt Aspose.Slides for PHP via Java, tạo bản trình chiếu đầu tiên, và tìm các hướng dẫn cho các công việc thông dụng, tài liệu tham khảo API và hỗ trợ."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java là một thư viện lớp dùng để tạo, đọc, chỉnh sửa và chuyển đổi các bản trình chiếu PowerPoint và OpenDocument trong các ứng dụng PHP, mà không cần Microsoft PowerPoint hay Office Automation.

Nó tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các biến thể có macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/php-java/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/php-java/create-presentation/">Tạo bản trình chiếu đầu tiên của bạn</a></li>
<li><a href="/slides/vi/php-java/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/php-java/supported-file-formats/">Định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/php-java/evaluate-aspose-slides/">Giới hạn dùng thử</a></li>
<li><a href="/slides/vi/php-java/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>CÔNG VIỆC THÔNG THƯỜNG</p>
<ul>
<li><a href="/slides/vi/php-java/open-presentation/">Mở một bản trình chiếu</a></li>
<li><a href="/slides/vi/php-java/save-presentation/">Lưu một bản trình chiếu</a></li>
<li><a href="/slides/vi/php-java/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/php-java/convert-slide/">Kết xuất các slide thành hình ảnh</a></li>
<li><a href="/slides/vi/php-java/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>QUY TRÌNH LÀM VIỆC VỚI SLIDES</p>
<ul>
<li><a href="/slides/vi/php-java/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/php-java/powerpoint-animation/">Hoạt ảnh</a></li>
<li><a href="/slides/vi/php-java/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/php-java/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/php-java/merge-presentation/">Ghép các bản trình chiếu</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/php-java/examples/">Ví dụ theo phần tử slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">Tài liệu API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/php-java/known-issues/">Các vấn đề đã biết</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">Trang sản phẩm</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Tải về</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Trợ giúp hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Bản trình chiếu đầu tiên của bạn**

Aspose.Slides for PHP via Java chạy trên Java trong Apache Tomcat, và các script PHP của bạn tương tác với nó thông qua PHP/Java Bridge. [Cài đặt](/slides/vi/php-java/installation/) thiết lập PHP 8.3 hoặc thấp hơn, Java, Tomcat và bridge, sau đó cài đặt gói từ Packagist vào thư mục dự án:

```bash
composer require aspose/slides
```

Sau đó sao chép tệp JAR của gói vào bridge và khởi động lại Tomcat, như trong bước 4 của [Cài đặt trên Linux](/slides/vi/php-java/installation/#install-on-linux) hoặc bước 6 của [Cài đặt trên Windows](/slides/vi/php-java/installation/#install-on-windows). Khi Tomcat đang chạy, lưu script này dưới tên *hello.php* trong thư mục dự án và chạy `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

Script này lưu *hello.pptx* bên cạnh nó, với một slide chứa hộp văn bản. Nếu không có giấy phép, tệp đã lưu sẽ có dấu watermark đánh giá — xem [Cấp phép](/slides/vi/php-java/licensing/). Để biết thêm các cách tạo và điền nội dung cho bản trình chiếu, xem [Tạo bản trình chiếu](/slides/vi/php-java/create-presentation/).