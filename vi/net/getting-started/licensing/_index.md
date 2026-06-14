---
title: Cấp phép
type: docs
weight: 80
url: /vi/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Áp dụng, quản lý và khắc phục sự cố giấy phép trong Aspose.Slides cho .NET. Đảm bảo truy cập liên tục vào đầy đủ tính năng với hướng dẫn cấp phép từng bước của chúng tôi."
---
## **Tổng quan**

Aspose.Slides có thể được sử dụng ở chế độ đánh giá hoặc với giấy phép hợp lệ. Phiên bản đánh giá cung cấp cùng chức năng như phiên bản có giấy phép, nhưng nó thêm một hình mờ đánh giá khi mở hoặc lưu bản trình bày và giới hạn việc trích xuất văn bản chỉ ở một slide.

Bài viết này giải thích cách cấp phép hoạt động trong Aspose.Slides và cách áp dụng giấy phép trước khi sử dụng thư viện. Giấy phép có thể được tải từ tệp, luồng hoặc tài nguyên nhúng bằng cách sử dụng lớp `License`. Bài viết cũng chỉ ra cách xác thực xem giấy phép đã được áp dụng đúng chưa.

## **Đánh giá Aspose.Slides**

{{% alert color="primary" %}} 

Bạn có thể tải phiên bản đánh giá của **Aspose.Slides for NET** từ [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.NET/). Phiên bản đánh giá cung cấp cùng các chức năng như phiên bản có giấy phép của sản phẩm. Gói đánh giá giống hệt gói đã mua. Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn thêm một vài dòng code vào (để áp dụng giấy phép).

Khi bạn hài lòng với việc đánh giá **Aspose.Slides**, bạn có thể [purchase a license](https://purchase.aspose.com/buy). Chúng tôi khuyên bạn nên xem qua các loại thuê bao khác nhau. Nếu có câu hỏi, hãy liên hệ với đội ngũ bán hàng của Aspose.

Mỗi giấy phép Aspose đi kèm với một năm thuê bao để nâng cấp miễn phí lên các phiên bản mới hoặc các bản sửa lỗi được phát hành trong thời gian thuê bao. Người dùng có sản phẩm có giấy phép hoặc ngay cả các phiên bản đánh giá đều nhận được hỗ trợ kỹ thuật miễn phí và không giới hạn.

{{% /alert %}} 

**Giới hạn phiên bản đánh giá**

* Trong khi phiên bản đánh giá của Aspose.Slides (không chỉ định giấy phép) cung cấp đầy đủ chức năng sản phẩm, nó chèn một hình mờ đánh giá ở đầu tài liệu khi mở và lưu.
* Bạn chỉ được trích xuất văn bản từ một slide duy nhất.

{{% alert color="primary" %}} 

Để thử Aspose.Slides mà không bị giới hạn, bạn có thể yêu cầu **Giấy phép tạm thời 30 ngày**. Xem trang [How to get a Temporary License](https://purchase.aspose.com/temporary-license) để biết thêm thông tin.

{{% /alert %}}

## **Cấp phép trong Aspose.Slides**
* Phiên bản đánh giá sẽ trở thành có giấy phép sau khi bạn mua giấy phép và thêm một vài dòng code vào (để áp dụng giấy phép).
* Giấy phép là tệp XML dạng văn bản thuần chứa các chi tiết như tên sản phẩm, số lượng nhà phát triển được cấp phép, ngày hết hạn thuê bao, v.v.
* Tệp giấy phép được ký số, vì vậy bạn không được phép chỉnh sửa tệp. Ngay cả việc thêm một ký tự xuống dòng kéo dài không mong muốn vào nội dung tệp cũng sẽ làm cho giấy phép không hợp lệ.
* Aspose.Slides for .NET thường cố gắng tìm giấy phép ở các vị trí sau:
  * Đường dẫn rõ ràng
  * Thư mục chứa dll của thành phần (được bao gồm trong Aspose.Slides)
  * Thư mục chứa assembly đã gọi dll của thành phần (được bao gồm trong Aspose.Slides)
  * Thư mục chứa assembly nhập (tệp .exe của bạn)
  * Tài nguyên nhúng trong assembly đã gọi dll của thành phần (được bao gồm trong Aspose.Slides).
* Để tránh các giới hạn liên quan tới phiên bản đánh giá, bạn cần đặt giấy phép trước khi sử dụng Aspose.Slides. Bạn chỉ cần đặt giấy phép một lần cho mỗi ứng dụng hoặc tiến trình.

{{% alert color="primary" %}} 

Bạn có thể muốn xem [Metered Licensing](https://docs.aspose.com/slides/vi/net/metered-licensing/).

{{% /alert %}} 


## **Áp dụng giấy phép**
Giấy phép có thể được tải từ **tệp**, **luồng**, hoặc **tài nguyên nhúng**. 

{{% alert color="primary" %}}

Aspose.Slides cung cấp lớp [License](https://reference.aspose.com/slides/vi/net/aspose.slides/license) để thực hiện các thao tác cấp phép.

{{% /alert %}} 

{{% alert color="warning" %}} 

Các giấy phép mới chỉ có thể kích hoạt Aspose.Slides với phiên bản 21.4 trở lên. Các phiên bản cũ hơn sử dụng hệ thống cấp phép khác và sẽ không nhận ra các giấy phép này.

{{% /alert %}}

### **Tệp**
Phương pháp đơn giản nhất để đặt giấy phép yêu cầu bạn đặt tệp giấy phép vào cùng thư mục chứa DLL của thành phần (được bao gồm trong Aspose.Slides) và chỉ định tên tệp mà không có đường dẫn.

Đoạn mã C# dưới đây cho thấy cách đặt tệp giấy phép:

``` csharp
// Khởi tạo lớp License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Đặt đường dẫn tệp giấy phép
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Nếu bạn đặt tệp giấy phép vào thư mục khác, khi gọi phương thức [SetLicense](https://reference.aspose.com/slides/vi/net/aspose.slides/license/setlicense/#setlicense_1), tên tệp giấy phép ở cuối đường dẫn rõ ràng phải khớp với tệp giấy phép của bạn.

Ví dụ, bạn có thể đổi tên tệp giấy phép thành *Aspose.Slides.lic.xml*. Sau đó, trong code, bạn phải truyền đường dẫn tới tệp (kết thúc bằng *Aspose.Slides.lic.xml*) cho phương thức [SetLicense](https://reference.aspose.com/slides/vi/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Luồng**
Bạn có thể tải giấy phép từ một luồng. Đoạn mã C# dưới đây cho thấy cách áp dụng giấy phép từ luồng:

``` csharp
// Khởi tạo lớp License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Đặt giấy phép thông qua một luồng
license.SetLicense(myStream);
```

### **Tài nguyên nhúng**
Bạn có thể đóng gói giấy phép cùng với ứng dụng của mình (để tránh mất) bằng cách thêm giấy phép như một tài nguyên nhúng vào một trong các assembly gọi DLL của thành phần (được bao gồm trong Aspose.Slides). 

Đây là cách bạn thêm tệp giấy phép làm tài nguyên nhúng:

1. Trong Visual Studio, thêm tệp giấy phép (.lic) vào dự án bằng cách: vào **File** > **Add Existing Item** > **Add**. 
2. Chọn tệp trong **Solution Explorer**.
3. Trong cửa sổ **Properties**, đặt **Build Action** thành **Embedded Resource**.
4. Để truy cập giấy phép được nhúng trong assembly, thêm tệp giấy phép làm tài nguyên nhúng vào dự án, sau đó truyền tên tệp giấy phép cho phương thức `SetLicense`. 


Lớp `License` tự động tìm tệp giấy phép trong các tài nguyên nhúng. Bạn không cần gọi các phương thức `GetExecutingAssembly` và `GetManifestResourceStream` của lớp `System.Reflection.Assembly` trong Microsoft .NET Framework.

Đoạn mã C# dưới đây cho thấy cách đặt giấy phép như một tài nguyên nhúng:

``` csharp
// Khởi tạo lớp License
Aspose.Slides.License license = new Aspose.Slides.License();

// Truyền tên tệp giấy phép được nhúng trong assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Xác thực giấy phép**

Để kiểm tra xem giấy phép đã được đặt đúng chưa, bạn có thể xác thực nó. Đoạn mã C# dưới đây cho thấy cách xác thực giấy phép:

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

{{% alert title="Note" color="warning" %}} 

Phương thức [license.SetLicense](https://reference.aspose.com/slides/vi/net/aspose.slides/license/setlicense/) không an toàn với đa luồng. Nếu phương thức này phải được gọi đồng thời từ nhiều luồng, bạn nên sử dụng các primitive đồng bộ (như lock) để tránh các vấn đề. 

{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng giấy phép trong môi trường hoàn toàn offline (không có kết nối internet) không?**

Có. Việc xác thực giấy phép được thực hiện cục bộ bằng tệp giấy phép; không cần kết nối internet.

**Điều gì sẽ xảy ra sau khi thuê bao một năm hết hạn? Thư viện có ngừng hoạt động không?**

Không. Giấy phép là vĩnh viễn: bạn vẫn có thể sử dụng các phiên bản đã phát hành trước ngày kết thúc thuê bao; bạn chỉ không đủ điều kiện sử dụng các bản phát hành mới hơn nếu không gia hạn.