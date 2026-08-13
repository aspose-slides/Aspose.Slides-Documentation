---
title: Cấp phép
type: docs
weight: 90
url: /vi/androidjava/licensing/
keywords:
- giấy phép
- giấy phép tạm thời
- cài đặt giấy phép
- sử dụng giấy phép
- xác thực giấy phép
- tệp giấy phép
- phiên bản đánh giá
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho Android qua Java. Đảm bảo truy cập liên tục vào toàn bộ tính năng với hướng dẫn cấp phép của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó thêm một dấu nước đánh giá khi mở hoặc lưu bài thuyết trình và giới hạn việc trích xuất văn bản chỉ cho một slide.

Bài viết này giải thích cách hoạt động của giấy phép trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Giấy phép có thể được nạp từ tệp, luồng hoặc tài nguyên nhúng bằng cách sử dụng lớp `License`. Bài viết cũng chỉ ra cách xác minh liệu giấy phép đã được áp dụng đúng chưa.

## **Đánh giá Aspose.Slides**

{{% alert color="info" %}} 

Bạn có thể tải xuống phiên bản đánh giá của **Aspose.Slides for Android via Java** từ [trang tải xuống](https://releases.aspose.com/slides/vi/androidjava/). Phiên bản đánh giá cung cấp cùng các chức năng như phiên bản có giấy phép của sản phẩm. Gói đánh giá giống với gói đã mua. Phiên bản đánh giá chỉ cần thêm một vài dòng mã vào (để áp dụng giấy phép) là sẽ trở thành có giấy phép.

Khi bạn hài lòng với việc đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/buy). Chúng tôi khuyên bạn nên xem qua các loại thuê bao khác nhau. Nếu có câu hỏi, hãy liên hệ với đội ngũ bán hàng của Aspose.

Mỗi giấy phép Aspose đi kèm với một năm thuê bao để nâng cấp miễn phí lên các phiên bản mới hoặc các bản sửa lỗi được phát hành trong thời gian thuê bao. Người dùng có sản phẩm có giấy phép (hoặc ngay cả phiên bản đánh giá) nhận được hỗ trợ kỹ thuật miễn phí và không giới hạn.

{{% /alert %}} 

**Các hạn chế của phiên bản đánh giá**

* Trong khi phiên bản đánh giá của Aspose.Slides (không có giấy phép được chỉ định) cung cấp đầy đủ chức năng sản phẩm, nó chèn một dấu nước đánh giá ở đầu tài liệu khi mở và lưu.
* Bạn chỉ được phép trích xuất văn bản từ một slide khi lấy văn bản từ các slide của bài thuyết trình.

{{% alert color="info" %}} 

Để thử Aspose.Slides mà không có hạn chế, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Xem trang [Cách nhận Giấy phép tạm thời](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.

{{% /alert %}}

## **Giấy phép trong Aspose.Slides**

* Một phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã vào (để áp dụng giấy phép).
* Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn thuê bao, v.v.
* Tệp giấy phép được ký số, vì vậy bạn không được phép sửa đổi tệp. Ngay cả việc vô tình thêm một dấu xuống dòng vào nội dung của tệp cũng sẽ làm cho giấy phép không còn hiệu lực.
* Aspose.Slides for Android via Java thường tìm giấy phép ở các vị trí sau:
  * Đường dẫn rõ ràng
  * Thư mục chứa Aspose.Slides.jar
* Để tránh các hạn chế liên quan tới phiên bản đánh giá, bạn cần thiết lập giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần thiết lập giấy phép một lần cho mỗi ứng dụng hoặc tiến trình.

## **Áp dụng giấy phép**

Giấy phép có thể được nạp từ **tệp** hoặc **luồng**.

{{% alert color="info" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/) để thực hiện các thao tác liên quan tới giấy phép.

{{% /alert %}} 

{{% alert color="warning" %}}

Các giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 hoặc mới hơn. Các phiên bản trước sử dụng hệ thống giấy phép khác và sẽ không nhận ra các giấy phép này.

{{% /alert %}}

### **Tệp**

Phương pháp dễ nhất để thiết lập giấy phép là đặt tệp giấy phép vào thư mục chứa Aspose.Slides.jar hoặc jar của ứng dụng của bạn.

Đoạn mã Java sau cho bạn thấy cách đặt tệp giấy phép:

``` java
// Khởi tạo lớp License
com.aspose.slides.License license = new com.aspose.slides.License();

// Đặt đường dẫn tệp giấy phép
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Nếu bạn đặt tệp giấy phép ở thư mục khác, khi gọi phương thức [SetLicense](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-), tên tệp giấy phép ở cuối đường dẫn rõ ràng phải giống với tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.Android.via.Java.lic.xml*. Sau đó, trong mã của bạn, bạn phải truyền đường dẫn tới tệp (kết thúc bằng *Aspose.Slides.Android.via.Java.lic.xml*) cho phương thức [SetLicense](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Luồng**

Bạn có thể nạp giấy phép từ một luồng. Đoạn mã Java sau cho bạn thấy cách áp dụng giấy phép từ một luồng:

``` java
// Khởi tạo lớp License
com.aspose.slides.License license = new com.aspose.slides.License();

// Đặt giấy phép qua một luồng
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Xác thực giấy phép**

Để kiểm tra xem giấy phép đã được đặt đúng chưa, bạn có thể xác thực nó. Đoạn mã Java sau cho bạn thấy cách xác thực giấy phép:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **An toàn đa luồng**

{{% alert title="Note" color="warning" %}} 

Phương thức [SetLicense](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) không an toàn đa luồng. Nếu phương thức này phải được gọi đồng thời từ nhiều luồng, bạn có thể muốn sử dụng các primitive đồng bộ (như lock) để tránh vấn đề. 

{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn ngoại tuyến (không có kết nối internet) không?

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

### Điều gì xảy ra sau khi thuê bao một năm hết hạn? Thư viện sẽ ngừng hoạt động không?

Không. Giấy phép là vĩnh viễn: bạn có thể tiếp tục sử dụng các phiên bản được phát hành trước ngày kết thúc thuê bao; bạn chỉ không đủ điều kiện sử dụng các bản phát hành mới hơn nếu không gia hạn.