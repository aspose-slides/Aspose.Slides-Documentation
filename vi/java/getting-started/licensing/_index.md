---
title: Cấp phép
type: docs
weight: 90
url: /vi/java/licensing/
keywords:
- giấy phép
- giấy phép tạm thời
- thiết lập giấy phép
- sử dụng giấy phép
- xác thực giấy phép
- tệp giấy phép
- phiên bản đánh giá
- PowerPoint
- OpenDocument
- trình chiếu
- Java
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho Java. Đảm bảo truy cập liên tục vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó thêm một dấu bản quyền đánh giá vào mỗi slide của mọi bản trình chiếu mà nó lưu và cắt ngắn văn bản mà mã của bạn đọc qua API.

Bài viết này giải thích cách giấy phép hoạt động trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Giấy phép có thể được tải từ tệp, luồng hoặc tài nguyên nhúng bằng cách sử dụng lớp `License`. Bài viết cũng cho thấy cách xác thực xem giấy phép đã được áp dụng đúng chưa.

## **Đánh giá Aspose.Slides**

{{% alert color="info" title="Note" %}}

Bạn có thể tải phiên bản đánh giá của **Aspose.Slides for Java** từ [trang tải xuống](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Phiên bản đánh giá cung cấp cùng các chức năng như phiên bản có giấy phép của sản phẩm. Gói đánh giá giống hệt gói mua. Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

Khi bạn đã hài lòng với quá trình đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/pricing/slides/vi/java/). Chúng tôi khuyên bạn nên xem xét các loại đăng ký khác nhau. Nếu có câu hỏi, hãy liên hệ với đội ngũ bán hàng của Aspose.

Mỗi giấy phép Aspose đi kèm với một năm đăng ký để nâng cấp miễn phí lên các phiên bản mới hoặc các bản sửa lỗi phát hành trong thời gian đăng ký. Người dùng có sản phẩm có giấy phép (hoặc ngay cả phiên bản đánh giá) nhận được hỗ trợ kỹ thuật miễn phí và không giới hạn.

{{% /alert %}} 

**Các hạn chế của phiên bản đánh giá**

* Phiên bản đánh giá (không chỉ định giấy phép) cung cấp đầy đủ chức năng sản phẩm, nhưng nó thêm một hộp văn bản dấu bản quyền đánh giá vào mỗi slide của mọi bản trình chiếu mà nó lưu.
* Văn bản mà mã của bạn đọc qua API, bao gồm cả văn bản vừa được đặt, sẽ bị cắt ngắn đến một vài ký tự đầu, kèm theo thông báo về hạn chế đánh giá. Văn bản mà mã của bạn ghi sẽ được lưu đầy đủ.

{{% alert color="info" title="Note" %}}

Để thử Aspose.Slides mà không bị hạn chế, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Xem trang [Cách nhận Giấy phép tạm thời](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.

{{% /alert %}}

## **Giấy phép trong Aspose.Slides**

* Một phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.
* Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn đăng ký, v.v.
* Tệp giấy phép được ký số, do đó bạn không được phép sửa đổi tệp. Ngay cả việc vô tình thêm một dòng mới vào nội dung tệp cũng sẽ làm cho giấy phép không còn hiệu lực.
* Aspose.Slides for Java thường tìm kiếm giấy phép ở các vị trí sau:
  * Đường dẫn rõ ràng
  * Thư mục chứa Aspose.Slides.jar
* Để tránh các hạn chế của phiên bản đánh giá, bạn cần thiết lập giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần thiết lập giấy phép một lần cho mỗi ứng dụng hoặc tiến trình.

{{% alert color="info" title="Note" %}}

Bạn có thể muốn xem [Giấy phép tính phí theo lượt sử dụng](/slides/vi/java/metered-licensing/).

{{% /alert %}} 


## **Áp dụng giấy phép**

Giấy phép có thể được tải từ **tệp** hoặc **luồng**.

{{% alert color="info" title="Note" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/java/com.aspose.slides/license/) để thực hiện các thao tác liên quan tới giấy phép.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Các giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng một hệ thống giấy phép khác và sẽ không nhận diện được các giấy phép này.

{{% /alert %}}

### **Tệp**

Phương pháp dễ nhất để thiết lập giấy phép là đặt tệp giấy phép vào thư mục chứa Aspose.Slides.jar hoặc jar của ứng dụng của bạn.

Đoạn mã Java sau cho bạn thấy cách thiết lập tệp giấy phép:

``` java
// Khởi tạo lớp License
com.aspose.slides.License license = new com.aspose.slides.License();

// Đặt đường dẫn tệp giấy phép
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Nếu bạn đặt tệp giấy phép ở một thư mục khác, khi gọi phương pháp [setLicense](https://reference.aspose.com/slides/vi/java/com.aspose.slides/license/#setLicense-java.lang.String-) thì tên tệp giấy phép ở cuối đường dẫn đã chỉ định phải trùng với tên tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.Java.lic.xml*. Sau đó, trong mã, bạn phải truyền đường dẫn đến tệp (kết thúc bằng *Aspose.Slides.Java.lic.xml*) cho phương pháp [setLicense](https://reference.aspose.com/slides/vi/java/com.aspose.slides/license/#setLicense-java.lang.String-).

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

Nếu bạn sử dụng Aspose.Slides cho PHP thông qua Java, bạn có thể thiết lập giấy phép qua cầu nối PHP/Java. Cầu nối này cho phép bạn sử dụng các lớp Java trong cú pháp PHP. Để biết thêm thông tin, xem [Giấy phép trong PHP](/slides/vi/php-java/licensing/).

## **Xác thực giấy phép**

Để kiểm tra xem giấy phép đã được thiết lập đúng chưa, bạn có thể xác thực nó. Đoạn mã Java sau cho bạn thấy cách xác thực giấy phép:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **An toàn đa luồng**

{{% alert color="warning" title="Warning" %}}

Phương pháp [setLicense](https://reference.aspose.com/slides/vi/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) không an toàn khi được gọi đồng thời từ nhiều luồng. Nếu phương pháp này cần được gọi đồng thời từ nhiều luồng, bạn có thể muốn sử dụng các primitive đồng bộ (như lock) để tránh vấn đề.

{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn ngoại tuyến (không có truy cập internet) không?

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

### Điều gì sẽ xảy ra sau khi gói đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?

Không. Giấy phép là vĩnh viễn: bạn có thể tiếp tục sử dụng các phiên bản phát hành trước ngày kết thúc đăng ký; bạn chỉ không đủ điều kiện sử dụng các bản phát hành mới hơn nếu không gia hạn.