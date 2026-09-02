---
title: Bảo vệ ghi bản trình chiếu trong .NET
linktitle: Bảo vệ ghi
type: docs
weight: 25
url: /vi/net/write-protected-presentation/
keywords:
- bảo vệ ghi
- PowerPoint bảo vệ ghi
- mật khẩu chỉnh sửa
- giới hạn chỉnh sửa bản trình chiếu
- xóa bảo vệ ghi
- xác thực mật khẩu chỉnh sửa
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Đặt, phát hiện, xác thực và xóa mật khẩu bảo vệ ghi trong các bản trình chiếu PowerPoint PPT và PPTX bằng cách sử dụng Aspose.Slides cho .NET."
---
## **Giới thiệu**

Mật khẩu bảo vệ ghi (write‑protection) hạn chế việc chỉnh sửa một bản trình chiếu nhưng không mã hoá nội dung của nó. Người dùng có thể tải và xem bản trình chiếu được bảo vệ ghi mà không cần mật khẩu. Tùy vào ứng dụng, họ cũng có thể chỉnh sửa nội dung và lưu lại dưới một tên khác, vì vậy bảo vệ ghi không nên được xem như một cơ chế bảo mật.

Mật khẩu mở (opening password) có mục đích khác: nó mã hoá bản trình chiếu và bắt buộc phải có để tải nội dung. Để mã hoá bản trình chiếu hoặc xác thực mật khẩu mở, xem [Password-Protect Presentations](/slides/vi/net/password-protected-presentation/).

Các quy trình trong bài viết này áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng tệp PPTX; khi lưu dưới định dạng PPT, hãy dùng phần mở rộng `.ppt` và định dạng lưu PPT tương ứng.

## **Đặt bảo vệ ghi cho bản trình chiếu**

Sử dụng [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/setwriteprotection/) để gán mật khẩu cho việc chỉnh sửa bản trình chiếu. Khi lưu bản trình chiếu, cài đặt bảo vệ sẽ được lưu lại.

Ví dụ sau đặt bảo vệ ghi cho một bản trình chiếu PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Tải bản trình chiếu được bảo vệ ghi**

Vì bảo vệ ghi không mã hoá nội dung bản trình chiếu, không cần mật khẩu để tải bản trình chiếu. Mật khẩu chỉ có liên quan khi xác thực quyền chỉnh sửa bản trình chiếu đã được bảo vệ.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Không truyền mật khẩu bảo vệ ghi cho [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/). Thuộc tính này chỉ nhận mật khẩu mở cho nội dung đã được mã hoá. Nếu một bản trình chiếu có cả hai loại bảo vệ, cung cấp mật khẩu mở để tải và xử lý mật khẩu bảo vệ ghi riêng biệt.

## **Xóa bảo vệ ghi khỏi bản trình chiếu**

Sử dụng [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/removewriteprotection/) để loại bỏ giới hạn chỉnh sửa, sau đó lưu bản trình chiếu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Kiểm tra xem bản trình chiếu có được bảo vệ ghi không**

Để kiểm tra tệp mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) đầy đủ, gọi [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) và kiểm tra [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/iswriteprotected/). Thuộc tính này sử dụng [NullableBool](https://reference.aspose.com/slides/vi/net/aspose.slides/nullablebool/) và trả về `NullableBool.True` khi phát hiện bảo vệ ghi.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

Phiên bản nhận luồng của [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) cung cấp cùng thông tin cho bản trình chiếu được truyền dưới dạng stream.

## **Xác thực mật khẩu bảo vệ ghi**

Sử dụng [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/checkwriteprotection/) để xác thực mật khẩu chỉnh sửa mà không cần tải toàn bộ bản trình chiếu. Đầu tiên kiểm tra [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/iswriteprotected/) để ứng dụng chỉ yêu cầu hoặc xác thực mật khẩu khi có bảo vệ ghi.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/checkwriteprotection/) chỉ xác thực mật khẩu bảo vệ ghi. Nó không xác thực mật khẩu mở và không xác định liệu nội dung đã mã hoá có thể được tải hay không. Ngược lại, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/checkpassword/) chỉ xác thực mật khẩu mở. Nếu một bản trình chiếu đầy đủ đã được tải, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/vi/net/aspose.slides/iprotectionmanager/checkwriteprotection/) cung cấp kiểm tra bảo vệ ghi tương đương thông qua trình quản lý bảo vệ.

Trong các ứng dụng thực tế, không ghi nhật ký mật khẩu hoặc đưa chúng vào thông báo chẩn đoán. Tránh các lần xác thực không cần thiết và chỉ giữ mật khẩu trong bộ nhớ trong thời gian cần thiết.

{{% alert color="info" title="Xem thêm" %}}
- [Password-Protect Presentations](/slides/vi/net/password-protected-presentation/)
- [Read-Only Presentations](/slides/vi/net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Bảo vệ ghi có mã hoá bản trình chiếu không?**

Không. Nó chỉ hạn chế việc chỉnh sửa nhưng vẫn cho phép tải và xem nội dung bản trình chiếu.

**Mật khẩu bảo vệ ghi có bắt buộc để mở bản trình chiếu không?**

Không. Chỉ cần mật khẩu mở mới bắt buộc để tải nội dung đã được mã hoá.

**Một bản trình chiếu có thể có cả mật khẩu mở và mật khẩu bảo vệ ghi không?**

Có. Cung cấp mật khẩu mở qua tùy chọn tải để mở bản trình chiếu đã mã hoá, và xác thực mật khẩu bảo vệ ghi riêng khi cần quyền chỉnh sửa.