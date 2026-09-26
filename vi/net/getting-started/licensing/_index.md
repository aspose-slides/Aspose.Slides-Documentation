---
title: Cấp phép
type: docs
weight: 80
url: /vi/net/licensing/
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
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho .NET. Đảm bảo truy cập liên tục vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó sẽ thêm một watermark đánh giá vào mỗi slide của mọi bản trình bày mà nó lưu và cắt ngắn văn bản mà mã của bạn đọc từ bản trình bày.

Bài viết này giải thích cách hoạt động của việc cấp phép trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Giấy phép có thể được tải từ tệp, luồng hoặc tài nguyên nhúng bằng cách sử dụng lớp `License`. Bài viết cũng cho thấy cách kiểm tra xem giấy phép đã được áp dụng đúng chưa.

## **Đánh giá Aspose.Slides**
{{% alert color="info" title="Note" %}}
Bạn có thể tải xuống phiên bản đánh giá của **Aspose.Slides for .NET** từ [trang tải xuống NuGet của nó](https://www.nuget.org/packages/Aspose.Slides.NET/). Phiên bản đánh giá cung cấp cùng các chức năng như phiên bản có giấy phép của sản phẩm. Gói đánh giá giống với gói đã mua. Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn thêm một vài dòng mã vào (để áp dụng giấy phép).

Khi bạn hài lòng với quá trình đánh giá **Aspose.Slides**, bạn có thể [mua giấy phép](https://purchase.aspose.com/pricing/slides/vi/net/). Chúng tôi khuyên bạn nên xem qua các loại đăng ký khác nhau. Nếu có câu hỏi, hãy liên hệ với đội ngũ bán hàng của Aspose.

Mỗi giấy phép Aspose đi kèm với một năm đăng ký để nâng cấp miễn phí lên các phiên bản mới hoặc các bản sửa lỗi được phát hành trong thời gian đăng ký. Người dùng có sản phẩm có giấy phép hoặc ngay cả phiên bản đánh giá đều nhận được hỗ trợ kỹ thuật miễn phí và không giới hạn.
{{% /alert %}} 

**Các hạn chế của phiên bản đánh giá**

* Phiên bản đánh giá (không chỉ định giấy phép) cung cấp đầy đủ chức năng của sản phẩm, nhưng nó thêm một hộp văn bản watermark đánh giá vào mỗi slide của mọi bản trình bày mà nó lưu.
* Văn bản mà mã của bạn đọc từ bản trình bày sẽ bị cắt ngắn đến vài ký tự đầu, kèm theo thông báo về hạn chế đánh giá. Văn bản mà mã của bạn ghi sẽ được lưu đầy đủ.

{{% alert color="info" title="Note" %}}
Để thử Aspose.Slides mà không có hạn chế, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Xem trang [Cách nhận Giấy phép Tạm thời](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.
{{% /alert %}}

## **Cấp phép trong Aspose.Slides**
* Phiên bản đánh giá sẽ có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng mã vào (để áp dụng giấy phép).
* Giấy phép là một tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn đăng ký, v.v.
* Tệp giấy phép được ký số, vì vậy bạn không được phép sửa đổi tệp. Ngay cả việc vô tình thêm một ký tự ngắt dòng vào nội dung của tệp cũng sẽ làm cho nó không hợp lệ.
* Aspose.Slides for .NET thường cố gắng tìm giấy phép ở các vị trí sau:
  * Một đường dẫn rõ ràng
  * Thư mục chứa dll của thành phần (được bao gồm trong Aspose.Slides)
  * Thư mục chứa assembly đã gọi dll của thành phần (được bao gồm trong Aspose.Slides)
  * Thư mục chứa assembly entry (tệp .exe của bạn)
  * Một tài nguyên nhúng trong assembly đã gọi dll của thành phần (được bao gồm trong Aspose.Slides).
* Để tránh các hạn chế liên quan đến phiên bản đánh giá, bạn cần đặt giấy phép trước khi sử dụng Aspose.Slides. Bạn chỉ cần đặt giấy phép một lần cho mỗi ứng dụng hoặc tiến trình.

{{% alert color="info" title="Note" %}}
Bạn có thể muốn xem [Cấp phép theo công suất](/slides/vi/net/metered-licensing/).
{{% /alert %}} 

## **Áp dụng giấy phép**
Giấy phép có thể được tải từ **tệp**, **luồng**, hoặc **tài nguyên nhúng**. 

{{% alert color="info" title="Note" %}}
Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/net/aspose.slides/license) cho các hoạt động cấp phép.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản trước sử dụng hệ thống cấp phép khác và sẽ không nhận ra các giấy phép này.
{{% /alert %}}

### **Tệp**
Phương pháp dễ nhất để thiết lập giấy phép yêu cầu bạn đặt tệp giấy phép trong cùng thư mục chứa DLL của thành phần (được bao gồm trong Aspose.Slides) và chỉ chỉ định tên tệp mà không có đường dẫn.

Mã C# này cho bạn thấy cách đặt một tệp giấy phép:

``` csharp
// Khởi tạo lớp License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Đặt đường dẫn tệp giấy phép
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}
Nếu bạn đặt tệp giấy phép trong một thư mục khác, khi gọi phương thức [SetLicense](https://reference.aspose.com/slides/vi/net/aspose.slides/license/setlicense/#setlicense_1), tên tệp giấy phép ở cuối đường dẫn chỉ định phải trùng với tên tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.lic.xml*. Sau đó, trong mã của bạn, bạn phải truyền đường dẫn tới tệp (kết thúc bằng *Aspose.Slides.lic.xml*) cho phương thức [SetLicense](https://reference.aspose.com/slides/vi/net/aspose.slides/license/setlicense/#setlicense_1).
{{% /alert %}}

### **Luồng**
Bạn có thể tải giấy phép từ một luồng. Mã C# này cho bạn thấy cách áp dụng giấy phép từ một luồng:

``` csharp
// Khởi tạo lớp License
Aspose.Slides.License license = new Aspose.Slides.License();

// Mở tệp giấy phép dưới dạng luồng
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Đặt giấy phép thông qua luồng
license.SetLicense(licenseStream);
```

### **Tài nguyên nhúng**
Bạn có thể gói giấy phép cùng với ứng dụng của mình (để tránh mất) bằng cách thêm giấy phép như một tài nguyên nhúng vào một trong các assembly gọi DLL của thành phần (được bao gồm trong Aspose.Slides). 

Đây là cách bạn thêm tệp giấy phép như một tài nguyên nhúng:

1. Trong Visual Studio, thêm tệp giấy phép (.lic) vào dự án bằng cách: Vào **File** > **Add Existing Item** > **Add**. 
2. Chọn tệp trong **Solution Explorer**.
3. Trong cửa sổ **Properties**, đặt **Build Action** thành **Embedded Resource**.
4. Để truy cập giấy phép nhúng trong assembly, thêm tệp giấy phép như một tài nguyên nhúng vào dự án, sau đó truyền tên tệp giấy phép cho phương thức `SetLicense`. 

Lớp `License` tự động tìm tệp giấy phép trong các tài nguyên nhúng. Bạn không cần gọi các phương thức `GetExecutingAssembly` và `GetManifestResourceStream` của lớp `System.Reflection.Assembly` trong Microsoft .NET Framework.

``` csharp
// Khởi tạo lớp License
Aspose.Slides.License license = new Aspose.Slides.License();

// Truyền tên tệp giấy phép nhúng trong assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Xác thực giấy phép**

Để kiểm tra xem giấy phép đã được đặt đúng chưa, bạn có thể xác thực nó. Mã C# này cho bạn thấy cách xác thực giấy phép:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **An toàn luồng**

{{% alert color="warning" title="Warning" %}}
Phương thức [license.SetLicense](https://reference.aspose.com/slides/vi/net/aspose.slides/license/setlicense/) không an toàn với đa luồng. Nếu phương thức này phải được gọi đồng thời từ nhiều luồng, bạn có thể muốn sử dụng các primitive đồng bộ (như lock) để tránh lỗi. 
{{% /alert %}}

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

### Điều gì sẽ xảy ra khi gói đăng ký một năm hết hạn? Thư viện có ngừng hoạt động không?

Không. Giấy phép là vĩnh viễn: bạn có thể tiếp tục sử dụng các phiên bản được phát hành trước ngày kết thúc đăng ký; bạn chỉ không thể sử dụng các phiên bản mới hơn nếu không gia hạn.