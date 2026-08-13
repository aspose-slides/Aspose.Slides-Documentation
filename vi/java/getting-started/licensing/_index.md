---
title: Cấp phép
type: docs
weight: 90
url: /vi/java/licensing/
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
- bản trình bày
- Java
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho Java. Đảm bảo truy cập liên tục vào đầy đủ tính năng với hướng dẫn cấp phép chi tiết của chúng tôi."
---
## **Overview**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó thêm dấu nước đánh giá khi bản trình bày được mở hoặc lưu và giới hạn việc trích xuất văn bản ở một slide.

Bài viết này giải thích cách hoạt động của giấy phép trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Giấy phép có thể được tải từ tệp, luồng hoặc tài nguyên nhúng bằng cách sử dụng lớp `License`. Bài viết cũng cho thấy cách xác thực xem giấy phép đã được áp dụng đúng chưa.

## **Evaluate Aspose.Slides**

{{% alert color="info" %}} 

Bạn có thể tải xuống phiên bản đánh giá của **Aspose.Slides for Java** từ [trang tải xuống](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Phiên bản đánh giá cung cấp cùng các chức năng như phiên bản có giấy phép của sản phẩm. Gói đánh giá giống hệt gói đã mua. Phiên bản đánh giá sẽ trở thành có giấy phép ngay sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

Khi bạn hài lòng với việc đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/buy). Chúng tôi khuyên bạn nên xem qua các loại đăng ký khác nhau. Nếu có câu hỏi, hãy liên hệ với đội bán hàng của Aspose.

Mỗi giấy phép Aspose đi kèm với một năm đăng ký để nâng cấp miễn phí lên các phiên bản mới hoặc các bản sửa lỗi được phát hành trong thời gian đăng ký. Người dùng có sản phẩm có giấy phép (hoặc ngay cả phiên bản đánh giá) nhận được hỗ trợ kỹ thuật miễn phí và không giới hạn.

{{% /alert %}} 

**Giới hạn của phiên bản đánh giá**

* Mặc dù phiên bản đánh giá của Aspose.Slides (không có giấy phép được chỉ định) cung cấp đầy đủ chức năng sản phẩm, nó chèn dấu nước đánh giá tại đầu tài liệu khi mở và lưu.
* Bạn chỉ được trích xuất văn bản từ một slide duy nhất.

{{% alert color="info" %}} 

Để thử Aspose.Slides mà không bị giới hạn, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Xem trang [Cách lấy Giấy phép Tạm thời](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* Một phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.
* Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn đăng ký, v.v.
* Tệp giấy phép được ký kỹ thuật số, vì vậy bạn không được chỉnh sửa tệp. Ngay cả việc vô tình thêm một dòng mới vào nội dung tệp cũng sẽ làm cho giấy phép không hợp lệ.
* Aspose.Slides for Java thường tìm kiếm giấy phép ở các vị trí sau:
  * Đường dẫn cụ thể
  * Thư mục chứa Aspose.Slides.jar
* Để tránh các giới hạn của phiên bản đánh giá, bạn cần thiết lập giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần thiết lập giấy phép một lần cho mỗi ứng dụng hoặc tiến trình.

{{% alert color="info" %}} 

Bạn có thể muốn xem [Metered Licensing](/slides/vi/java/metered-licensing/).

{{% /alert %}} 


## **Applying a License**

Giấy phép có thể được tải từ **tệp** hoặc **luồng**.

{{% alert color="info" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/java/com.aspose.slides/License) để thực hiện các thao tác liên quan đến giấy phép.

{{% /alert %}} 

{{% alert color="warning" %}}

Các giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống giấy phép khác và sẽ không nhận ra các giấy phép này.

{{% /alert %}}

### **File**

Phương pháp đơn giản nhất để thiết lập giấy phép là đặt tệp giấy phép trong thư mục chứa Aspose.Slides.jar hoặc jar của ứng dụng của bạn.

Mã Java này cho bạn biết cách thiết lập tệp giấy phép:

``` java
// Khởi tạo lớp License
com.aspose.slides.License license = new com.aspose.slides.License();

// Đặt đường dẫn tệp giấy phép
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Nếu bạn đặt tệp giấy phép ở thư mục khác, khi gọi phương thức [SetLicense](https://reference.aspose.com/slides/vi/java/com.aspose.slides/License#setLicense-java.lang.String-) , tên tệp giấy phép ở cuối đường dẫn cụ thể phải trùng với tên tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.Java.lic.xml*. Sau đó, trong mã của bạn, bạn phải truyền đường dẫn tới tệp (kết thúc bằng *Aspose.Slides.Java.lic.xml*) cho phương thức [SetLicense](https://reference.aspose.com/slides/vi/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Stream**

Bạn có thể tải giấy phép từ một luồng. Mã Java này cho bạn biết cách áp dụng giấy phép từ một luồng:

``` java
// Khởi tạo lớp License
com.aspose.slides.License license = new com.aspose.slides.License();

// Đặt giấy phép thông qua luồng
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Nếu bạn sử dụng Aspose.Slides cho PHP thông qua Java, bạn có thể thiết lập giấy phép qua cầu nối PHP/Java. Cầu nối này cho phép bạn sử dụng các lớp Java trong cú pháp PHP. Để biết thêm thông tin, xem [License in PHP](/slides/vi/php-java/licensing/).

## **Validating a License**

Để kiểm tra xem giấy phép đã được thiết lập đúng chưa, bạn có thể xác thực nó. Mã Java này cho bạn biết cách xác thực một giấy phép:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

Phương thức [SetLicense](https://reference.aspose.com/slides/vi/java/com.aspose.slides/License#setLicense-java.io.InputStream-) không an toàn với đa luồng. Nếu phương thức này phải được gọi đồng thời từ nhiều luồng, bạn nên sử dụng các nguyên tắc đồng bộ (như lock) để tránh lỗi.

{{% /alert %}}

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Yes. License validation is performed locally using the license file; no internet connection is required.

### What happens after the one-year subscription expires? Will the library stop working?

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.