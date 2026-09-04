---
title: "Bảo vệ bản trình chiếu bằng mật khẩu trong .NET"
linktitle: "Bảo vệ mật khẩu"
type: docs
weight: 20
url: /vi/net/password-protected-presentation/
keywords:
- "bản trình chiếu được bảo vệ bằng mật khẩu"
- "mật khẩu mở khóa"
- "mã hoá PowerPoint"
- "giải mã PowerPoint"
- "xác thực mật khẩu bản trình chiếu"
- "kiểm tra mật khẩu bản trình chiếu"
- "mở bản trình chiếu đã mã hoá"
- "gỡ bỏ mã hoá"
- "PowerPoint"
- "PPT"
- "PPTX"
- "bản trình chiếu"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu trong C# với Aspose.Slides cho .NET."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bản trình chiếu. Cần phải có mật khẩu đúng để tải và xem nội dung bản trình chiếu, vì vậy bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc chỉnh sửa nhưng không mã hoá nội dung hoặc ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc sửa đổi bản trình chiếu, xem [Write-Protect Presentations](/slides/vi/net/write-protected-presentation/).

Các quy trình công việc bên dưới áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng quan trọng.

## **Mã hoá bản trình chiếu bằng mật khẩu mở khóa**

Sử dụng [IProtectionManager.Encrypt](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/encrypt/) để gán mật khẩu mở khóa. Sau đó sử dụng [IPresentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/save/) để lưu bản trình chiếu đã được mã hoá.

Ví dụ sau mã hoá một bản trình chiếu PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Giữ thuộc tính tài liệu công khai**

Mặc định, Aspose.Slides bao gồm các thuộc tính tài liệu trong quá trình mã hoá bản trình chiếu. Thuộc tính [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) kiểm soát hành vi này một cách độc lập so với mã hoá nội dung slide. Đặt nó thành `false` trước khi gọi [IProtectionManager.Encrypt](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/encrypt/) khi một hệ thống đánh chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu cần đọc siêu dữ liệu mà không có mật khẩu mở khóa.

Ví dụ sau tạo một bản trình chiếu PPTX đã được mã hoá đồng thời để các thuộc tính tài liệu tích hợp của nó công khai:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Việc đặt `EncryptDocumentProperties` thành `false` không làm cho slide, master, layout, shape, media hoặc bất kỳ nội dung bản trình chiếu nào khác trở nên công khai. Nó chỉ ảnh hưởng đến các thuộc tính tài liệu. Để đọc các thuộc tính đó mà không tải nội dung đã mã hoá, xem [Manage Presentation Properties](/slides/vi/net/presentation-properties/).

## **Tải một bản trình chiếu đã được mã hoá**

Đặt [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/) thành mật khẩu mở khóa và truyền các tùy chọn này cho [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi yêu cầu mật khẩu mở khóa nhưng mật khẩu được cung cấp bị thiếu hoặc không đúng.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Lấm việc với bản trinh chiếu đã giải mã.
```

## **Gỡ bỏ mã hoá khỏi một bản trình chiếu**

Tải bản trình chiếu cùng mật khẩu mở khóa, gọi [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/removeencryption/), và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Xác thực mật khẩu mở khóa trước khi tải**

Sử dụng [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) để lấy [IPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/) mà không tạo một thể hiện bản trình chiếu hoàn chỉnh. Kiểm tra [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/ispasswordprotected/) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Quy trình làm việc dựa trên đường dẫn tệp**

Ví dụ sau xác thực mật khẩu mở khóa cho một tệp PPTX, truyền giá trị đã xác thực cho [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/), và sau đó tải bản trình chiếu hoàn chỉnh:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Quy trình làm việc dựa trên luồng**

Phiên bản overload dựa trên luồng của [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) cung cấp cùng một quy trình. Đặt lại vị trí của luồng có thể tìm kiếm được trước khi tải bản trình chiếu hoàn chỉnh từ luồng đó.

Ví dụ sau sử dụng một tệp PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Giá trị trả về của CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/checkpassword/) trả về `true` chỉ khi bản trình chiếu có mật khẩu mở khóa và mật khẩu được cung cấp là đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở khóa.
- Mật khẩu được cung cấp là `null` hoặc chuỗi rỗng.

Hành vi này giống nhau đối với bản trình chiếu PPT và PPTX.

## **Kiểm tra xem một bản trình chiếu đã tải có được mã hoá hay không**

Sau khi tải một bản trình chiếu với mật khẩu đúng, kiểm tra [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/isencrypted/) để xác nhận rằng bản trình chiếu gốc đã được mã hoá. Để phát hiện bảo vệ bằng mật khẩu mở khóa trước khi tải, sử dụng `IPresentationInfo.IsPasswordProtected` như đã mô tả ở trên.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Khuyến nghị bảo mật**

{{% alert color="warning" title="Security" %}}
Không ghi lại mật khẩu mở khóa hoặc đưa chúng vào các thông điệp chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi ngay lập tức tải bản trình chiếu.

Các thuộc tính tài liệu công khai có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và các giá trị tùy chỉnh ngay cả khi nội dung bản trình chiếu đã được mã hoá. Hãy mã hoá siêu dữ liệu nhạy cảm cùng với bản trình chiếu. Việc để thuộc tính công khai nên là quyết định rõ ràng chỉ khi các hệ thống phải đánh chỉ mục, phân loại, tìm kiếm hoặc quản lý tệp mà không có mật khẩu mở khóa.
{{% /alert %}}

## **Bảo vệ bản trình chiếu bằng mật khẩu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
1. Chọn hoặc tải lên bản trình chiếu.
1. Nhập mật khẩu để bảo vệ chế độ xem.
1. Tùy chọn nhập một mật khẩu riêng cho bảo vệ chỉnh sửa.
1. Áp dụng bảo vệ và tải xuống tệp đã tạo.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/vi/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Mật khẩu mở khóa khác gì so với mật khẩu bảo vệ ghi?**

Mật khẩu mở khóa mã hoá bản trình chiếu và được yêu cầu để tải nội dung của nó. Mật khẩu bảo vệ ghi chỉ hạn chế việc chỉnh sửa mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải toàn bộ slide không?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem có bảo vệ bằng mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thể hiện bản trình chiếu hoàn chỉnh.

**Ứng dụng có thể đọc siêu dữ liệu mà không có mật khẩu mở khóa không?**

Có, nhưng chỉ khi bản trình chiếu được mã hoá với `EncryptDocumentProperties` đặt thành `false`. Ứng dụng sau đó phải sử dụng chế độ tải chỉ thuộc tính tài liệu mô tả trong [Manage Presentation Properties](/slides/vi/net/presentation-properties/).

**Các quy trình xác thực mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và dựa trên luồng hoạt động giống nhau đối với bản trình chiếu PPT và PPTX.