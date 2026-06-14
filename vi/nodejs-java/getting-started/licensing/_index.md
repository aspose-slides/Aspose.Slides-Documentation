---
title: "Cấp phép"
type: docs
weight: 80
url: /vi/nodejs-java/licensing/
keywords:
- "giấy phép"
- "giấy phép tạm thời"
- "cài đặt giấy phép"
- "sử dụng giấy phép"
- "xác thực giấy phép"
- "tệp giấy phép"
- "phiên bản đánh giá"
- "PowerPoint"
- "OpenDocument"
- "bài thuyết trình"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho Node.js. Đảm bảo truy cập liên tục vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Giới thiệu**

Đôi khi, để đạt được kết quả đánh giá tốt nhất, có thể cần một cách tiếp cận thực hành. Vì lý do này, Aspose.Slides cung cấp các gói mua khác nhau và cũng cung cấp Dùng thử miễn phí và Giấy phép tạm thời 30 ngày để đánh giá.

{{% alert color="primary" %}}
Lưu ý rằng có một số chính sách và thực hành chung hướng dẫn bạn cách đánh giá, cấp phép đúng cách và mua sản phẩm của chúng tôi. Bạn có thể tìm thấy chúng trong phần ["Chính sách mua hàng và Câu hỏi thường gặp"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Đánh giá Aspose.Slides**
Bạn có thể dễ dàng tải Aspose.Slides để đánh giá. Gói đánh giá giống hệt gói đã mua. Phiên bản đánh giá chỉ cần thêm một vài dòng mã để áp dụng giấy phép. 

## **Hạn chế của Phiên bản Đánh giá**
Phiên bản đánh giá của Aspose.Slides (không chỉ định giấy phép) cung cấp đầy đủ chức năng của sản phẩm, nhưng nó sẽ chèn một dấu nước đánh giá ở đầu tài liệu khi mở và lưu. Bạn cũng bị giới hạn một slide khi trích xuất văn bản từ các slide trình chiếu.

{{% alert color="primary" %}} 
Nếu bạn muốn thử Aspose.Slides mà không có những hạn chế của phiên bản đánh giá, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Vui lòng tham khảo [Cách nhận Giấy phép tạm thời?](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.
{{% /alert %}} 

## **Về Giấy phép**
Bạn có thể dễ dàng tải xuống phiên bản đánh giá của Aspose.Slides cho Node.js thông qua Java từ [trang tải xuống](https://releases.aspose.com/slides/vi/nodejs-java/). Phiên bản đánh giá cung cấp **cùng đầy đủ khả năng** như phiên bản có giấy phép của Aspose.Slides. Hơn nữa, phiên bản đánh giá sẽ trở thành có giấy phép ngay sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.

Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn đăng ký, v.v. Tệp này được ký số, vì vậy không được sửa đổi. Ngay cả việc vô tình thêm một dòng ngắt mới vào nội dung tệp cũng sẽ làm cho nó không hợp lệ.

Để tránh những hạn chế liên quan tới phiên bản đánh giá, bạn cần thiết lập giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần thiết lập giấy phép một lần cho mỗi ứng dụng hoặc quy trình.

{{% alert color="primary" %}} 
Bạn có thể muốn xem [Giấy phép theo tiêu thụ](https://docs.aspose.com/slides/vi/nodejs-java/metered-licensing/).
{{% /alert %}} 

## **Giấy phép đã mua**

Sau khi mua, bạn cần áp dụng tệp hoặc luồng giấy phép. 

{{% alert color="primary" %}}
Bạn cần thiết lập giấy phép:
* chỉ một lần cho mỗi miền ứng dụng
* trước khi sử dụng bất kỳ lớp Aspose.Slides nào khác
{{% /alert %}}

{{% alert color="primary" %}}
Bạn có thể tìm thông tin giá tại trang [“Thông tin Giá”](https://purchase.aspose.com/pricing/slides/vi/family).
{{% /alert %}}

### **Thiết lập Giấy phép trong Aspose.Slides cho Node.js qua Java**

Giấy phép có thể được áp dụng từ các vị trí sau:

* Đường dẫn cụ thể
* Luồng
* Dưới dạng Giấy phép theo tiêu thụ – một cơ chế cấp phép mới

{{% alert color="primary" %}}
Sử dụng phương thức **setLicense** để cấp phép cho một thành phần.

Mặc dù gọi **setLicense** nhiều lần không gây hại, nhưng chúng lãng phí tài nguyên (bộ xử lý).
{{% /alert %}}

{{% alert color="warning" %}}
Giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống cấp phép khác và sẽ không nhận dạng được các giấy phép này.
{{% /alert %}}

#### **Áp dụng Giấy phép bằng Tệp**

Đoạn mã này được dùng để thiết lập tệp giấy phép:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Khi gọi phương thức setLicense, tên giấy phép nên giống với tên tệp giấy phép của bạn. Ví dụ, bạn có thể đổi tên tệp giấy phép thành "Aspose.Slides.lic.xml". Sau đó, trong mã của bạn, bạn phải truyền tên giấy phép mới (Aspose.Slides.lic.xml) cho phương thức setLicense.

#### **Áp dụng Giấy phép từ Luồng**

Đoạn mã này được dùng để áp dụng giấy phép từ một luồng:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **Câu hỏi thường gặp**

**Có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?**

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

**Điều gì xảy ra sau khi gói đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?**

Không. Giấy phép là vĩnh viễn: bạn có thể tiếp tục sử dụng các phiên bản đã phát hành trước ngày hết hạn đăng ký; bạn chỉ không được phép sử dụng các bản phát hành mới hơn nếu không gia hạn.