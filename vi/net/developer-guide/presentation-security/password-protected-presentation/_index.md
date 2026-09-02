---
title: Bảo vệ bản trình bày bằng mật khẩu trong .NET
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/net/password-protected-presentation/
keywords:
- bản trình bày được bảo vệ bằng mật khẩu
- mật khẩu mở khóa
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình bày
- kiểm tra mật khẩu bản trình bày
- mở bản trình bày đã mã hoá
- gỡ bỏ mã hoá
- PowerPoint
- PPT
- PPTX
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình bày PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu trong C# với Aspose.Slides cho .NET."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bản trình bày. Mật khẩu đúng là bắt buộc để tải và xem nội dung bản trình bày, do đó bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc sửa đổi nhưng không mã hoá nội dung hoặc ngăn bản trình bày được tải. Để quản lý mật khẩu cho việc chỉnh sửa bản trình bày, xem [Write-Protect Presentations](/slides/vi/net/write-protected-presentation/).

Các quy trình làm việc dưới đây áp dụng cho cả bản trình bày PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng quan trọng.

## **Mã hoá bản trình bày bằng mật khẩu mở khóa**

Sử dụng [IProtectionManager.Encrypt](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/encrypt/) để chỉ định một mật khẩu mở khóa. Sau đó sử dụng [IPresentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/save/) để lưu bản trình bày đã được mã hoá.

Ví dụ sau mã hoá một bản trình bày PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Tải bản trình bày đã mã hoá**

Đặt [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/) thành mật khẩu mở khóa và truyền các tùy chọn này vào [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi cần mật khẩu mở khóa nhưng mật khẩu cung cấp bị thiếu hoặc không đúng.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Làm việc với bản trình bày đã giải mã.
```

## **Gỡ bỏ mã hoá khỏi bản trình bày**

Tải bản trình bày với mật khẩu mở khóa của nó, gọi [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/removeencryption/), và lưu kết quả. Bản trình bày đã lưu sau đó có thể được tải mà không cần mật khẩu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Xác thực mật khẩu mở khóa trước khi tải**

Sử dụng [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) để lấy [IPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/) mà không tạo một thể hiện bản trình bày đầy đủ. Kiểm tra [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/ispasswordprotected/) trước khi yêu cầu hoặc xác thực mật khẩu. Khi bảo vệ tồn tại, xác thực giá trị đã cung cấp bằng [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Quy trình làm việc theo Đường dẫn Tệp**

Ví dụ sau xác thực mật khẩu mở khóa cho tệp PPTX, truyền giá trị đã xác thực vào [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/), và sau đó tải bản trình bày đầy đủ:

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

### **Quy trình làm việc Dòng**

Phiên bản quá tải dựa trên luồng của [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) cung cấp cùng một quy trình làm việc. Đặt lại vị trí của luồng có thể tìm kiếm trước khi tải bản trình bày đầy đủ từ luồng đó.

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

### **Giá trị Trả về của CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/checkpassword/) trả về `true` chỉ khi bản trình bày có mật khẩu mở khóa và mật khẩu cung cấp là đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình bày không có mật khẩu mở khóa.
- Mật khẩu cung cấp là `null` hoặc rỗng.

Hành vi này giống nhau đối với bản trình bày PPT và PPTX.

## **Kiểm tra xem bản trình bày đã tải có được mã hoá hay không**

Sau khi tải bản trình bày với mật khẩu đúng, kiểm tra [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/isencrypted/) để xác nhận rằng bản trình bày nguồn đã được mã hoá. Để phát hiện bảo vệ mật khẩu mở khóa trước khi tải, sử dụng `IPresentationInfo.IsPasswordProtected` như đã trình bày ở trên.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Khuyến nghị Bảo mật**

{{% alert color="warning" title="Security" %}}
Không ghi lại mật khẩu mở khóa hoặc bao gồm chúng trong các thông điệp chẩn đoán. Tránh các nỗ lực xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi ngay lập tức tải bản trình bày.
{{% /alert %}}

## **Bảo vệ Bản trình bày Bằng Mật khẩu Trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
2. Chọn hoặc tải lên bản trình bày.
3. Nhập mật khẩu để bảo vệ việc xem.
4. Tùy chọn nhập một mật khẩu riêng để bảo vệ việc chỉnh sửa.
5. Áp dụng bảo vệ và tải xuống tệp kết quả.

{{% alert color="info" title="See also" %}}
- [Bảo vệ ghi Bản trình bày](/slides/vi/net/write-protected-presentation/)
- [Chữ ký số trong PowerPoint](/slides/vi/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa mật khẩu mở khóa và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở khóa mã hoá bản trình bày và cần để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở khóa mà không tải tất cả các slide không?**

Có. Lấy thông tin bản trình bày, kiểm tra xem có bảo vệ bằng mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thể hiện bản trình bày đầy đủ.

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và dựa trên luồng hoạt động giống nhau cho bản trình bày PPT và PPTX.