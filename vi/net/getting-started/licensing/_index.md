---
title: Cấp phép
type: docs
weight: 80
url: /vi/net/licensing/
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho .NET. Đảm bảo truy cập không gián đoạn vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với một giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó sẽ thêm một dấu water­mark đánh giá khi mở hoặc lưu bản trình chiếu và giới hạn việc trích xuất văn bản chỉ ở một slide.

Bài viết này giải thích cách hoạt động của giấy phép trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Giấy phép có thể được tải từ tệp, luồng hoặc tài nguyên nhúng bằng cách sử dụng lớp `License`. Bài viết cũng chỉ ra cách kiểm tra xem giấy phép đã được áp dụng đúng chưa.

## **Đánh giá Aspose.Slides**

{{% alert color="info" %}} 

Bạn có thể tải xuống phiên bản đánh giá của **Aspose.Slides for NET** từ [trang tải NuGet của nó](https://www.nuget.org/packages/Aspose.Slides.NET/). Phiên bản đánh giá cung cấp cùng các tính năng như phiên bản có giấy phép của sản phẩm. Gói đánh giá giống hệt như gói đã mua. Phiên bản đánh giá chỉ trở thành có giấy phép sau khi bạn thêm một vài dòng mã để áp dụng giấy phép.

Khi bạn hài lòng với việc đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/buy). Chúng tôi khuyến nghị bạn xem qua các loại đăng ký khác nhau. Nếu có câu hỏi, hãy liên hệ với đội ngũ bán hàng của Aspose.

Mỗi giấy phép Aspose đi kèm một năm đăng ký miễn phí nâng cấp lên các phiên bản mới hoặc các bản sửa lỗi trong thời gian đăng ký. Người dùng có sản phẩm có giấy phép hoặc thậm chí là phiên bản đánh giá đều nhận hỗ trợ kỹ thuật miễn phí và không giới hạn.

{{% /alert %}} 

**Các giới hạn của phiên bản đánh giá**

* Trong khi phiên bản đánh giá Aspose.Slides (không chỉ định giấy phép) cung cấp đầy đủ chức năng của sản phẩm, nó sẽ chèn một water­mark đánh giá ở đầu tài liệu khi mở và lưu. 
* Bạn chỉ được trích xuất văn bản từ một slide duy nhất.

{{% alert color="info" %}} 

Để thử Aspose.Slides mà không có giới hạn, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Xem trang [Cách nhận Giấy phép tạm thời](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.

{{% /alert %}}

## **Giấy phép trong Aspose.Slides**
* Một phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã để áp dụng giấy phép.
* Giấy phép là một tệp XML dạng văn bản thuần chứa các thông tin như tên sản phẩm, số nhà phát triển được cấp phép, ngày hết hạn đăng ký, v.v. 
* Tệp giấy phép được ký số, vì vậy bạn không được thay đổi tệp. Ngay cả một dấu xuống dòng thừa trong nội dung tệp cũng sẽ làm mất hiệu lực.
* Aspose.Slides for .NET thường tìm kiếm giấy phép ở các vị trí sau:
  * Đường dẫn rõ ràng
  * Thư mục chứa dll của thành phần (được bao gồm trong Aspose.Slides)
  * Thư mục chứa assembly đã gọi dll của thành phần (được bao gồm trong Aspose.Slides)
  * Thư mục chứa assembly nhập (tập tin .exe của bạn)
  * Tài nguyên nhúng trong assembly đã gọi dll của thành phần (được bao gồm trong Aspose.Slides).
* Để tránh các giới hạn của phiên bản đánh giá, bạn cần đặt giấy phép trước khi sử dụng Aspose.Slides. Bạn chỉ cần đặt giấy phép một lần cho mỗi ứng dụng hoặc tiến trình.

{{% alert color="info" %}} 

Bạn có thể muốn xem [Giấy phép tính phí theo lượt sử dụng](https://docs.aspose.com/slides/vi/net/metered-licensing/).

{{% /alert %}} 

## **Áp dụng Giấy phép**
Giấy phép có thể được tải từ **tệp**, **luồng** hoặc **tài nguyên nhúng**. 

{{% alert color="info" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/net/aspose.slides/license) để thực hiện các thao tác liên quan đến giấy phép.

{{% /alert %}} 

{{% alert color="warning" %}} 

Giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống giấy phép khác và sẽ không nhận diện được các giấy phép này.

{{% /alert %}}

### **Tệp**
Phương pháp dễ nhất để đặt giấy phép là đặt tệp giấy phép trong cùng thư mục chứa DLL của thành phần (được bao gồm trong Aspose.Slides) và chỉ định tên tệp mà không cần đường dẫn.

Mã C# dưới đây cho bạn thấy cách đặt một tệp giấy phép:

``` csharp
// Khởi tạo lớp License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Đặt đường dẫn tệp giấy phép
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Nếu bạn đặt tệp giấy phép ở thư mục khác, khi gọi phương thức [SetLicense](https://reference.aspose.com/slides/vi/net/aspose.slides/license/setlicense/#setlicense_1), tên tệp giấy phép ở cuối đường dẫn rõ ràng phải khớp với tên tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.lic.xml*. Sau đó, trong mã của bạn, phải truyền đường dẫn tới tệp (kết thúc bằng *Aspose.Slides.lic.xml*) cho phương thức [SetLicense](https://reference.aspose.com/slides/vi/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Luồng**
Bạn có thể tải giấy phép từ một luồng. Mã C# dưới đây cho bạn thấy cách áp dụng giấy phép từ luồng:

``` csharp
// Khởi tạo lớp License
Aspose.Slides.License license = new Aspose.Slides.License();

// Mở tệp giấy phép dưới dạng stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Đặt giấy phép thông qua stream
license.SetLicense(licenseStream);
```

### **Tài nguyên Nhúng**
Bạn có thể gói giấy phép cùng với ứng dụng của mình (để tránh mất) bằng cách thêm giấy phép như một tài nguyên nhúng vào một trong các assembly gọi DLL của thành phần (được bao gồm trong Aspose.Slides). 

Cách thêm tệp giấy phép làm tài nguyên nhúng:

1. Trong Visual Studio, thêm tệp giấy phép (.lic) vào dự án bằng cách: **File** > **Add Existing Item** > **Add**. 
2. Chọn tệp trong **Solution Explorer**.
3. Trong cửa sổ **Properties**, đặt **Build Action** thành **Embedded Resource**.
4. Để truy cập giấy phép nhúng trong assembly, thêm tệp giấy phép như một tài nguyên nhúng vào dự án, sau đó truyền tên tệp giấy phép cho phương thức `SetLicense`. 


Lớp `License` sẽ tự động tìm tệp giấy phép trong các tài nguyên nhúng. Bạn không cần gọi các phương thức `GetExecutingAssembly` và `GetManifestResourceStream` của lớp `System.Reflection.Assembly` trong Microsoft .NET Framework.

Mã C# dưới đây cho bạn thấy cách đặt giấy phép dưới dạng tài nguyên nhúng:

``` csharp
// Khởi tạo lớp License
Aspose.Slides.License license = new Aspose.Slides.License();

// Truyền tên tệp giấy phép được nhúng trong assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Xác thực Giấy phép**

Để kiểm tra xem giấy phép đã được đặt đúng chưa, bạn có thể xác thực nó. Mã C# dưới đây cho bạn thấy cách xác thực giấy phép:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **An toàn đa luồng**

{{% alert title="Note" color="warning" %}} 

Phương thức [license.SetLicense](https://reference.aspose.com/slides/vi/net/aspose.slides/license/setlicense/) không an toàn đa luồng. Nếu phương thức này phải được gọi đồng thời từ nhiều luồng, bạn nên sử dụng các primitive đồng bộ (như lock) để tránh vấn đề. 

{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

### Điều gì sẽ xảy ra sau khi gói đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?

Không. Giấy phép là vĩnh viễn: bạn vẫn có thể sử dụng các phiên bản đã phát hành trước ngày kết thúc đăng ký; bạn chỉ không đủ điều kiện sử dụng các phiên bản mới hơn nếu không gia hạn.