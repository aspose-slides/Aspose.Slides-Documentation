---
title: Cấp phép
type: docs
weight: 80
url: /vi/php-java/licensing/
keywords:
- giấy phép
- giấy phép tạm thời
- đặt giấy phép
- sử dụng giấy phép
- xác thực giấy phép
- tệp giấy phép
- phiên bản đánh giá
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho PHP qua Java. Đảm bảo truy cập liên tục vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Giới thiệu**

Đôi khi, để đạt được kết quả đánh giá tốt nhất, có thể cần một cách tiếp cận thực tế. Vì lý do này, Aspose.Slides cung cấp các gói mua hàng khác nhau và cũng cung cấp Bản dùng thử miễn phí và Giấy phép tạm thời 30 ngày để đánh giá.

{{% alert color="primary" %}}
Lưu ý rằng có một số chính sách và thực tiễn chung hướng dẫn bạn cách đánh giá, cấp phép đúng cách và mua sản phẩm của chúng tôi. Bạn có thể tìm chúng trong mục ["Chính sách mua hàng và Hỏi đáp"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Đánh giá Aspose.Slides**
Bạn có thể dễ dàng tải xuống Aspose.Slides để đánh giá. Gói đánh giá giống hệt gói đã mua. Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép. 

## **Hạn chế của Phiên bản Đánh giá**
Phiên bản đánh giá của Aspose.Slides (không có giấy phép được chỉ định) cung cấp đầy đủ chức năng của sản phẩm, nhưng nó sẽ chèn một dấu nước đánh giá ở đầu tài liệu khi mở và lưu. Bạn cũng bị giới hạn chỉ một slide khi trích xuất văn bản từ các slide trình chiếu.

{{% alert color="primary" %}} 
Nếu bạn muốn thử Aspose.Slides mà không gặp các hạn chế của phiên bản đánh giá, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Vui lòng tham khảo [Cách nhận Giấy phép tạm thời?](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.
{{% /alert %}} 

## **Về Giấy phép**
Bạn có thể dễ dàng tải xuống phiên bản đánh giá của Aspose.Slides cho PHP qua Java từ [trang tải xuống](https://packagist.org/packages/aspose/slides). Phiên bản đánh giá cung cấp **cùng các tính năng** của phiên bản có giấy phép của Aspose.Slides. Hơn nữa, phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.

Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp giấy phép, ngày hết hạn đăng ký, v.v. Tệp này được ký số, vì vậy không được chỉnh sửa. Ngay cả việc vô tình thêm một dòng ngắt mới vào nội dung tệp cũng sẽ làm nó mất hiệu lực.

Để tránh các hạn chế liên quan đến phiên bản đánh giá, bạn cần đặt giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần đặt giấy phép một lần cho mỗi ứng dụng hoặc quy trình.

{{% alert color="primary" %}} 
Bạn có thể muốn xem [Giấy phép theo mức tiêu thụ](https://docs.aspose.com/slides/vi/php-java/metered-licensing/).
{{% /alert %}} 

## **Giấy phép đã mua**

Sau khi mua, bạn cần áp dụng tệp hoặc luồng giấy phép. 

{{% alert color="primary" %}}
Bạn cần đặt giấy phép:
* chỉ một lần cho mỗi miền ứng dụng
* trước khi sử dụng bất kỳ lớp Aspose.Slides nào khác
{{% /alert %}}

{{% alert color="primary" %}}
Bạn có thể tìm thông tin giá trên trang ["Thông tin Giá"](https://purchase.aspose.com/pricing/slides/vi/family).
{{% /alert %}}

### **Đặt giấy phép trong Aspose.Slides cho PHP qua Java**

Giấy phép có thể được áp dụng từ các vị trí sau:

* Đường dẫn rõ ràng
* Luồng
* Dưới dạng Giấy phép theo mức tiêu thụ – một cơ chế cấp phép mới

{{% alert color="primary" %}}
Sử dụng phương thức **setLicense** để cấp phép cho một thành phần.

Mặc dù việc gọi **setLicense** nhiều lần không gây hại, nhưng nó sẽ lãng phí tài nguyên (bộ xử lý).
{{% /alert %}}

{{% alert color="warning" %}}
Giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản trước sử dụng hệ thống cấp phép khác và sẽ không nhận diện các giấy phép này.
{{% /alert %}}

#### **Áp dụng giấy phép bằng tệp**

Đoạn mã này được sử dụng để đặt tệp giấy phép:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

Khi gọi phương thức setLicense, tên giấy phép phải giống với tên tệp giấy phép của bạn. Ví dụ, bạn có thể đổi tên tệp giấy phép thành "Aspose.Slides.lic.xml". Sau đó, trong mã của bạn, bạn phải truyền tên giấy phép mới (Aspose.Slides.lic.xml) vào phương thức setLicense.

#### **Áp dụng giấy phép từ một luồng**

Đoạn mã này được sử dụng để áp dụng giấy phép từ một luồng:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?**

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

**Đi gì sẽ xảy ra sau khi đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?**

Không. Giấy phép là vĩnh viễn: bạn có thể tiếp tục sử dụng các phiên bản được phát hành trước ngày kết thúc đăng ký; bạn chỉ không đủ điều kiện sử dụng các bản phát hành mới hơn nếu không gia hạn.