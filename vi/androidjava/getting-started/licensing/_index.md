---
title: Cấp phép
type: docs
weight: 90
url: /vi/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho Android qua Java. Đảm bảo truy cập không gián đoạn tới đầy đủ tính năng với hướng dẫn cấp phép của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó thêm một dấu bản quyền đánh giá vào mỗi slide của mỗi bản trình chiếu mà nó lưu và cắt ngắn văn bản mà mã của bạn đọc từ bản trình chiếu.

Bài viết này giải thích cách giấy phép hoạt động trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Giấy phép có thể được tải từ tệp, luồng, hoặc tài nguyên nhúng bằng cách sử dụng lớp [License](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/) . Bài viết cũng cho thấy cách xác thực xem giấy phép đã được áp dụng đúng chưa.

## **Đánh giá Aspose.Slides**

{{% alert color="info" title="Note" %}}

Bạn có thể tải xuống phiên bản đánh giá của **Aspose.Slides for Android via Java** từ [trang tải xuống](https://releases.aspose.com/slides/vi/androidjava/). Phiên bản đánh giá cung cấp cùng các chức năng như phiên bản có giấy phép của sản phẩm. Gói đánh giá giống hệt gói mua. Phiên bản đánh giá sẽ trở thành có giấy phép ngay sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

Khi bạn hài lòng với việc đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/pricing/slides/vi/android-java/). Chúng tôi khuyến nghị bạn xem qua các loại đăng ký khác nhau. Nếu có câu hỏi, hãy liên hệ với đội ngũ bán hàng của Aspose.

Mỗi giấy phép Aspose đi kèm một đăng ký một năm để nâng cấp miễn phí lên các phiên bản mới hoặc bản sửa lỗi được phát hành trong thời gian đăng ký. Người dùng có sản phẩm có giấy phép (hoặc ngay cả phiên bản đánh giá) nhận được hỗ trợ kỹ thuật miễn phí và không giới hạn.

{{% /alert %}} 

**Các hạn chế của phiên bản đánh giá**

* Phiên bản đánh giá (không chỉ định giấy phép) cung cấp đầy đủ chức năng sản phẩm, nhưng nó thêm một hộp văn bản dấu bản quyền đánh giá vào mỗi slide của mỗi bản trình chiếu mà nó lưu.
* Văn bản mà mã của bạn đọc từ một bản trình chiếu bị cắt ngắn đến vài ký tự đầu tiên, kèm theo thông báo về hạn chế đánh giá. Văn bản mà mã của bạn ghi sẽ được lưu đầy đủ.

{{% alert color="info" title="Note" %}}

Để thử Aspose.Slides mà không có hạn chế, bạn có thể yêu cầu một **Giấy phép Tạm thời 30 ngày**. Xem trang [Cách nhận Giấy phép Tạm thời](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.

{{% /alert %}}

## **Cấp giấy phép trong Aspose.Slides**

* Một phiên bản đánh giá trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.
* Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn đăng ký, v.v.
* Tệp giấy phép được ký số, vì vậy bạn không được sửa đổi tệp. Ngay cả việc thêm một dòng trống không mong muốn vào nội dung tệp cũng sẽ làm nó mất hiệu lực.
* Aspose.Slides for Android via Java thường tìm giấy phép ở các vị trí sau:
  * Một đường dẫn rõ ràng
  * Thư mục chứa Aspose.Slides.jar
* Để tránh các hạn chế liên quan đến phiên bản đánh giá, bạn cần đặt giấy phép trước khi sử dụng **Aspose.Slides**. Bạn chỉ cần đặt giấy phép một lần cho mỗi ứng dụng hoặc quy trình.

## **Áp dụng giấy phép**

Giấy phép có thể được tải từ một **tệp** hoặc **luồng**.

{{% alert color="info" title="Note" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/) cho các thao tác cấp giấy phép.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Các giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống cấp phép khác và sẽ không nhận diện các giấy phép này.

{{% /alert %}}

### **Tệp**

Phương pháp dễ nhất để đặt giấy phép yêu cầu bạn đặt tệp giấy phép trong thư mục chứa Aspose.Slides.jar hoặc jar của ứng dụng bạn.

{{% alert color="info" title="Note" %}}

Trên Android, thư viện và ứng dụng của bạn được đóng gói vào APK, vì vậy không có thư mục nào chứa tệp JAR của thư viện, và một đường dẫn tương đối như *Aspose.Slides.Android.via.Java.lic* không trỏ tới tệp trong ứng dụng của bạn. Thêm tệp giấy phép vào thư mục assets của ứng dụng và tải nó từ một luồng, như shown trong [Stream from App Assets](#stream-from-app-assets).

{{% /alert %}}

Mã Java này cho bạn thấy cách đặt một tệp giấy phép:

``` java
// Khởi tạo lớp License
com.aspose.slides.License license = new com.aspose.slides.License();

// Đặt đường dẫn tệp giấy phép
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Nếu bạn đặt tệp giấy phép ở một thư mục khác, khi gọi phương thức [setLicense](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) , tên tệp giấy phép ở cuối đường dẫn được chỉ định phải giống với tên tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.Android.via.Java.lic.xml*. Sau đó, trong mã của bạn, bạn phải truyền đường dẫn tới tệp (kết thúc bằng *Aspose.Slides.Android.via.Java.lic.xml*) cho phương thức [setLicense](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Luồng**

Bạn có thể tải giấy phép từ một luồng. Mã Java này cho bạn thấy cách áp dụng giấy phép từ một luồng:

``` java
// Khởi tạo lớp License
com.aspose.slides.License license = new com.aspose.slides.License();

// Đặt giấy phép qua một luồng
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Luồng từ Tài nguyên Ứng dụng**

Trong một ứng dụng Android, đặt tệp giấy phép vào thư mục *assets* của mô-đun ứng dụng, *app/src/main/assets*, để nó được đóng gói vào APK. Mở tệp bằng phương thức [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) và truyền luồng tới phương thức [setLicense](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) . Mã chạy trong một `Activity`, ví dụ trong phương thức `onCreate` của nó, trước khi ứng dụng sử dụng Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

Tên tệp được truyền cho phương thức [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) là tương đối so với thư mục *assets*. Nếu tệp không có ở đó, mã sẽ ghi lỗi và Aspose.Slides sẽ ở chế độ đánh giá. Để kiểm tra liệu giấy phép đã được áp dụng hay chưa, xem phần [Xác thực Giấy phép](#validating-a-license).

## **Xác thực giấy phép**

Để kiểm tra xem giấy phép đã được đặt đúng chưa, bạn có thể xác thực nó. Mã Java này cho bạn thấy cách xác thực một giấy phép:

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

{{% alert color="warning" title="Warning" %}}

Phương thức [setLicense](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) không an toàn với đa luồng. Nếu phương thức này phải được gọi đồng thời từ nhiều luồng, bạn nên sử dụng các cơ chế đồng bộ (như lock) để tránh vấn đề.

{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

### Điều gì xảy ra sau khi đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?

Không. Giấy phép là vĩnh viễn: bạn vẫn có thể sử dụng các phiên bản đã phát hành trước ngày kết thúc đăng ký; bạn chỉ không đủ điều kiện sử dụng các bản phát hành mới hơn nếu không gia hạn.