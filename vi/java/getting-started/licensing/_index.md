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
- phiên bản dùng thử
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides for Java. Đảm bảo truy cập liên tục vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ dùng thử hoặc với giấy phép hợp lệ. Phiên bản dùng thử cung cấp cùng chức năng như phiên bản có giấy phép, nhưng sẽ chèn một watermark đánh dấu dùng thử khi mở hoặc lưu bản trình chiếu và giới hạn việc trích xuất văn bản chỉ trên một slide.

Bài viết này giải thích cách hoạt động của việc cấp phép trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Giấy phép có thể được tải từ tệp, luồng hoặc tài nguyên nhúng bằng cách sử dụng lớp `License`. Bài viết cũng cho biết cách kiểm tra xem giấy phép đã được áp dụng đúng chưa.

## **Đánh giá Aspose.Slides**

{{% alert color="primary" %}} 

Bạn có thể tải phiên bản dùng thử của **Aspose.Slides for Java** từ [trang tải xuống](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Phiên bản dùng thử cung cấp các tính năng giống như phiên bản có giấy phép của sản phẩm. Gói dùng thử giống hệt gói đã mua. Phiên bản dùng thử sẽ trở thành có giấy phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

Khi bạn hài lòng với việc dùng thử **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/buy). Chúng tôi khuyên bạn nên xem qua các loại đăng ký khác nhau. Nếu có câu hỏi, hãy liên hệ với đội ngũ bán hàng của Aspose.

Mỗi giấy phép Aspose đi kèm một năm đăng ký để nâng cấp miễn phí lên các phiên bản mới hoặc nhận các bản sửa lỗi trong thời gian đăng ký. Người dùng có sản phẩm có giấy phép (hoặc ngay cả phiên bản dùng thử) nhận được hỗ trợ kỹ thuật miễn phí và không giới hạn.

{{% /alert %}} 

**Giới hạn của phiên bản dùng thử**

* Mặc dù phiên bản dùng thử Aspose.Slides (không có giấy phép) cung cấp đầy đủ chức năng sản phẩm, nó sẽ chèn một watermark dùng thử ở đầu tài liệu khi mở và lưu.
* Khi trích xuất văn bản từ các slide, bạn chỉ được phép trên một slide.

{{% alert color="primary" %}} 

Để thử Aspose.Slides mà không bị giới hạn, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Xem trang [Cách lấy Giấy phép Tạm thời](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.

{{% /alert %}}

## **Cấp phép trong Aspose.Slides**

* Một phiên bản dùng thử sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.
* Giấy phép là một tệp XML dạng văn bản thuần chứa các thông tin như tên sản phẩm, số nhà phát triển được cấp phép, ngày hết hạn đăng ký, v.v.
* Tệp giấy phép được ký kỹ thuật số, vì vậy bạn không được phép sửa đổi tệp. Thậm chí một dấu xuống dòng thừa trong nội dung tệp cũng sẽ làm cho giấy phép không hợp lệ.
* Aspose.Slides for Java thường tìm giấy phép ở các vị trí sau:
  * Đường dẫn rõ ràng
  * Thư mục chứa Aspose.Slides.jar
* Để tránh các hạn chế của phiên bản dùng thử, bạn cần đặt giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần đặt giấy phép một lần cho mỗi ứng dụng hoặc tiến trình.

{{% alert color="primary" %}} 

Bạn có thể muốn xem [Cấp phép theo mức tiêu thụ](/slides/vi/java/metered-licensing/).

{{% /alert %}} 


## **Áp dụng giấy phép**

Giấy phép có thể được tải từ **tệp** hoặc **luồng**.

{{% alert color="primary" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/java/com.aspose.slides/License) để thực hiện các thao tác cấp phép.

{{% /alert %}} 

{{% alert color="warning" %}}

Giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống cấp phép khác và sẽ không nhận diện được các giấy phép này.

{{% /alert %}}

### **Tệp**

Phương pháp dễ nhất để đặt giấy phép là đặt tệp giấy phép trong thư mục chứa Aspose.Slides.jar hoặc jar của ứng dụng của bạn.

Đoạn mã Java sau cho bạn thấy cách đặt tệp giấy phép:

``` java
// Khởi tạo lớp License
com.aspose.slides.License license = new com.aspose.slides.License();

// Đặt đường dẫn tệp giấy phép
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Nếu bạn đặt tệp giấy phép ở thư mục khác, khi gọi phương thức [SetLicense](https://reference.aspose.com/slides/vi/java/com.aspose.slides/License#setLicense-java.lang.String-) thì tên tệp giấy phép ở cuối đường dẫn rõ ràng phải trùng với tên tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.Java.lic.xml*. Khi đó, trong mã của bạn, bạn phải truyền đường dẫn tới tệp (kết thúc bằng *Aspose.Slides.Java.lic.xml*) cho phương thức [SetLicense](https://reference.aspose.com/slides/vi/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Luồng**

Bạn có thể tải giấy phép từ một luồng. Đoạn mã Java sau cho bạn thấy cách áp dụng giấy phép từ luồng:

``` java
// Khởi tạo lớp License
com.aspose.slides.License license = new com.aspose.slides.License();

// Đặt giấy phép thông qua luồng
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Nếu bạn sử dụng Aspose.Slides cho PHP thông qua Java, bạn có thể đặt giấy phép qua cầu nối PHP/Java. Cầu nối này cho phép bạn sử dụng các lớp Java trong cú pháp PHP. Để biết thêm thông tin, xem [Giấy phép trong PHP](/slides/vi/php-java/licensing/).

## **Xác thực giấy phép**

Để kiểm tra xem giấy phép đã được đặt đúng chưa, bạn có thể xác thực nó. Đoạn mã Java sau cho bạn thấy cách xác thực giấy phép:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **An toàn đa luồng**

{{% alert title="Note" color="warning" %}} 

Phương thức [SetLicense](https://reference.aspose.com/slides/vi/java/com.aspose.slides/License#setLicense-java.io.InputStream-) không an toàn khi gọi đồng thời từ nhiều luồng. Nếu phương thức này phải được gọi đồng thời, bạn nên sử dụng các primitive đồng bộ (như khóa) để tránh vấn đề.

{{% /alert %}}

## **FAQ**

**Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?**

Có. Việc xác thực giấy phép được thực hiện nội bộ bằng tệp giấy phép; không cần kết nối internet.

**Điều gì sẽ xảy ra khi gói đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?**

Không. Giấy phép là vĩnh viễn: bạn vẫn có thể sử dụng các phiên bản được phát hành trước ngày kết thúc đăng ký; bạn chỉ không đủ điều kiện sử dụng các bản phát hành mới hơn nếu không gia hạn.