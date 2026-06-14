---
title: Cấp phép
description: "Aspose.Slides for Node.js qua .NET cung cấp các kế hoạch mua khác nhau hoặc cung cấp Bản dùng thử miễn phí và Giấy phép tạm thời 30 ngày để đánh giá theo các chính sách Cấp phép và Đăng ký."
type: docs
weight: 80
url: /vi/nodejs-net/licensing/
---
Đôi khi, để đạt được kết quả đánh giá tốt nhất, có thể cần một cách tiếp cận thực tế. Vì lý do này, Aspose.Slides cung cấp các gói mua hàng khác nhau và cũng cung cấp Bản dùng thử miễn phí và Giấy phép tạm thời 30 ngày để đánh giá.

{{% alert color="primary" %}}
Lưu ý rằng có một số chính sách và thực tiễn chung hướng dẫn bạn cách đánh giá, cấp phép đúng cách và mua sản phẩm của chúng tôi. Bạn có thể tìm thấy chúng trong phần ["Chính sách mua hàng và Câu hỏi thường gặp"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Đánh giá Aspose.Slides**
Bạn có thể dễ dàng tải xuống Aspose.Slides để đánh giá. Gói đánh giá giống hệt gói đã mua. Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép. 

## **Giới hạn phiên bản đánh giá**
Phiên bản đánh giá của Aspose.Slides (không chỉ định giấy phép) cung cấp đầy đủ chức năng sản phẩm, nhưng nó chèn một dấu bản quyền đánh giá ở đầu tài liệu khi mở và lưu. Bạn cũng bị giới hạn chỉ một slide khi trích xuất văn bản từ các slide trình chiếu.

{{% alert color="primary" %}} 
Nếu bạn muốn thử Aspose.Slides mà không gặp các hạn chế của phiên bản đánh giá, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Vui lòng tham khảo [Cách lấy Giấy phép tạm thời?](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.
{{% /alert %}} 

## **Về giấy phép**
Bạn có thể dễ dàng tải xuống phiên bản đánh giá của Aspose.Slides cho Node.js thông qua .NET từ [trang tải xuống](https://releases.aspose.com/slides/vi/nodejs-net/). Phiên bản đánh giá cung cấp **cùng các khả năng** như phiên bản có giấy phép của Aspose.Slides. Hơn nữa, phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.

Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn đăng ký và các thông tin khác. Tệp này được ký kỹ thuật số, vì vậy không được sửa đổi tệp. Ngay cả việc vô tình thêm một dấu xuống dòng vào nội dung của tệp cũng sẽ làm tệp không còn hiệu lực.

Để tránh các hạn chế liên quan đến phiên bản đánh giá, bạn cần đặt giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần đặt giấy phép một lần cho mỗi ứng dụng hoặc quy trình.

## Giấy phép đã mua

Sau khi mua, bạn cần áp dụng tệp hoặc luồng giấy phép. 

{{% alert color="primary" %}}
Bạn cần đặt giấy phép:
* chỉ một lần cho mỗi miền ứng dụng
* trước khi sử dụng bất kỳ lớp Aspose.Slides nào khác
{{% /alert %}}

{{% alert color="primary" %}}
Bạn có thể tìm thông tin giá trên trang ["Thông tin giá cả"](https://purchase.aspose.com/pricing/slides/vi/family).
{{% /alert %}}

### **Đặt giấy phép trong Aspose.Slides cho Node.js qua .NET**

Giấy phép có thể được áp dụng từ các vị trí sau:

* Đường dẫn cụ thể
* Luồng
* Dưới dạng Giấy phép tính theo mức – một cơ chế cấp phép mới

{{% alert color="primary" %}}
Sử dụng phương thức **setLicense** để cấp phép cho một thành phần.

Mặc dù việc gọi **setLicense** nhiều lần không gây hại, nhưng chúng là lãng phí tài nguyên (bộ xử lý).
{{% /alert %}}

{{% alert color="warning" %}}
Giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản trước sử dụng hệ thống cấp phép khác và sẽ không nhận ra các giấy phép này.
{{% /alert %}}

#### **Áp dụng giấy phép bằng tệp**

Đoạn mã này được dùng để đặt tệp giấy phép:

**Node.js**

```javascript
// Nhập mô-đun Aspose.Slides để thao tác tệp PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Hàm này thiết lập thư viện Aspose.Slides với giấy phép
function setupAsposeSlidesLicense() {
	
    // Khởi tạo lớp License từ mô-đun Aspose.Slides
    var license = new asposeSlides.License();
    
    // Áp dụng giấy phép từ tệp
    // Thay thế "your_license_file.lic" bằng đường dẫn tới tệp giấy phép thực tế của bạn
    license.setLicense("your_license_file.lic");
}

// Thực thi hàm để thiết lập giấy phép cho Aspose.Slides
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
Khi gọi phương thức setLicense, tên giấy phép phải giống với tên tệp giấy phép của bạn. Ví dụ, bạn có thể đổi tên tệp giấy phép thành "Aspose.Slides.lic.xml". Sau đó, trong mã của bạn, bạn phải truyền tên giấy phép mới (Aspose.Slides.lic.xml) cho phương thức setLicense.
{{% /alert %}}