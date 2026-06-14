---
title: Bảo mật bản trình chiếu bằng mật khẩu trong .NET
linktitle: Bảo vệ bằng mật khẩu
type: docs
weight: 20
url: /vi/net/password-protected-presentation/
keywords:
- khóa PowerPoint
- khóa bản trình chiếu
- mở khóa PowerPoint
- mở khóa bản trình chiếu
- bảo vệ PowerPoint
- bảo vệ bản trình chiếu
- đặt mật khẩu
- thêm mật khẩu
- mã hoá PowerPoint
- mã hoá bản trình chiếu
- giải mã PowerPoint
- giải mã bản trình chiếu
- bảo vệ ghi
- bảo mật PowerPoint
- bảo mật bản trình chiếu
- gỡ mật khẩu
- gỡ bảo vệ
- gỡ mã hoá
- vô hiệu hoá mật khẩu
- vô hiệu hoá bảo vệ
- gỡ bảo vệ ghi
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa dễ dàng các bản trình chiếu PowerPoint và OpenDocument được bảo vệ bằng mật khẩu với Aspose.Slides cho .NET. Bảo mật các bản trình chiếu của bạn."
---
## **Giới thiệu**

Khi bạn bảo vệ một bản trình chiếu bằng mật khẩu, nghĩa là bạn đang đặt một mật khẩu áp dụng các hạn chế nhất định lên bản trình chiếu. Để gỡ bỏ các hạn chế này, người dùng phải nhập mật khẩu. Một bản trình chiếu có mật khẩu được coi là bản trình chiếu đã khóa.

Thông thường, bạn có thể đặt mật khẩu để áp dụng các hạn chế sau cho bản trình chiếu:

- **Sửa đổi**

Nếu bạn muốn chỉ một số người dùng nhất định có thể sửa đổi bản trình chiếu, bạn có thể thiết lập hạn chế sửa đổi. Hạn chế này ngăn người dùng sửa đổi, thay đổi hoặc sao chép các thành phần trong bản trình chiếu trừ khi họ cung cấp mật khẩu.

Tuy nhiên, ngay cả khi không có mật khẩu, người dùng vẫn có thể truy cập và mở tài liệu của bạn. Trong chế độ chỉ đọc này, người dùng có thể xem nội dung — bao gồm siêu liên kết, hoạt ảnh, hiệu ứng và các yếu tố khác — trong bản trình chiếu, nhưng họ không thể sao chép mục nào hoặc lưu bản trình chiếu.

- **Mở**

Nếu bạn muốn chỉ một số người dùng nhất định có thể mở bản trình chiếu, bạn có thể thiết lập hạn chế mở. Hạn chế này ngăn người dùng thậm chí xem nội dung của bản trình chiếu nếu họ không cung cấp mật khẩu.

Về mặt kỹ thuật, hạn chế mở cũng ngăn người dùng sửa đổi bản trình chiếu — nếu người dùng không thể mở bản trình chiếu, họ cũng không thể sửa đổi hay thay đổi nó.

**Lưu ý:** Khi bạn bảo vệ bản trình chiếu bằng mật khẩu để ngăn mở, tệp bản trình chiếu sẽ được mã hoá.

## **Bảo vệ bằng mật khẩu trong Aspose.Slides**

**Định dạng được hỗ trợ**

Aspose.Slides hỗ trợ bảo vệ mật khẩu, mã hoá và các thao tác tương tự cho các bản trình chiếu ở các định dạng sau:

- PPTX và PPT – Bản trình chiếu Microsoft PowerPoint
- ODP – Bản trình chiếu OpenDocument
- OTP – Mẫu bản trình chiếu OpenDocument

**Các thao tác được hỗ trợ**

Aspose.Slides cho phép bạn sử dụng bảo vệ bằng mật khẩu trên bản trình chiếu để ngăn sửa đổi theo các cách sau:

- Mã hoá bản trình chiếu
- Thiết lập bảo vệ ghi trên bản trình chiếu

**Các thao tác khác**

Aspose.Slides cho phép bạn thực hiện các nhiệm vụ bổ sung liên quan đến bảo vệ mật khẩu và mã hoá theo các cách sau:

- Giải mã bản trình chiếu; mở bản trình chiếu đã mã hoá
- Gỡ bỏ mã hoá; tắt bảo vệ mật khẩu
- Gỡ bỏ bảo vệ ghi khỏi bản trình chiếu
- Truy xuất các thuộc tính của bản trình chiếu đã mã hoá
- Kiểm tra xem một bản trình chiếu có được bảo vệ mật khẩu hay không trước khi tải
- Kiểm tra xem một bản trình chiếu có được mã hoá hay không
- Kiểm tra xem một bản trình chiếu có được bảo vệ mật khẩu hay không

## **Bảo vệ một bản trình chiếu bằng mật khẩu**

Bạn có thể mã hoá một bản trình chiếu bằng cách đặt mật khẩu. Sau đó, để sửa đổi bản trình chiếu đã khóa, người dùng phải cung cấp mật khẩu.

Để mã hoá (hoặc bảo vệ bằng mật khẩu) một bản trình chiếu, sử dụng phương thức `Encrypt` từ [ProtectionManager](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager) để đặt mật khẩu. Truyền mật khẩu vào phương thức `Encrypt`, sau đó dùng phương thức `Save` để lưu bản trình chiếu đã được mã hoá.

Mẫu mã nguồn dưới đây cho thấy cách mã hoá một bản trình chiếu:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Thiết lập bảo vệ ghi trên bản trình chiếu** 

Bạn có thể thêm một dấu hiệu “Không sửa đổi” vào bản trình chiếu. Điều này thông báo cho người dùng rằng bạn không muốn họ thực hiện thay đổi trên bản trình chiếu.

**Lưu ý:** Quá trình bảo vệ ghi không mã hoá bản trình chiếu. Do đó, người dùng — nếu họ muốn — vẫn có thể sửa đổi bản trình chiếu, nhưng để lưu các thay đổi, họ sẽ phải lưu dưới một tên khác.

Để thiết lập bảo vệ ghi, sử dụng phương thức `SetWriteProtection`. Mẫu mã nguồn dưới đây cho thấy cách thiết lập bảo vệ ghi trên bản trình chiếu:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Tải một bản trình chiếu đã mã hoá**

Aspose.Slides cho phép bạn tải một bản trình chiếu đã mã hoá bằng cách truyền mật khẩu chính xác. Mẫu mã nguồn dưới đây cho thấy cách tải một bản trình chiếu đã mã hoá:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Làm việc với bản trình chiếu đã giải mã.
}
```

## **Gỡ bỏ mã hoá khỏi bản trình chiếu**

Bạn có thể gỡ bỏ mã hoá hoặc bảo vệ mật khẩu khỏi một bản trình chiếu, cho phép người dùng truy cập hoặc sửa đổi nó mà không có bất kỳ hạn chế nào.

Để gỡ bỏ mã hoá hoặc bảo vệ mật khẩu, gọi phương thức [RemoveEncryption](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager/methods/removeencryption). Mẫu mã nguồn dưới đây cho thấy cách gỡ bỏ mã hoá khỏi một bản trình chiếu:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Gỡ bỏ bảo vệ ghi khỏi bản trình chiếu**

Bạn có thể sử dụng Aspose.Slides để gỡ bỏ bảo vệ ghi khỏi tệp bản trình chiếu. Khi đó, người dùng có thể sửa đổi nó theo ý muốn và sẽ không nhận được bất kỳ cảnh báo nào khi thực hiện các thao tác đó.

Bạn có thể gỡ bỏ bảo vệ ghi bằng cách sử dụng phương thức [RemoveWriteProtection](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager/methods/removewriteprotection). Mẫu mã nguồn dưới đây cho thấy cách gỡ bỏ bảo vệ ghi khỏi một bản trình chiếu:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Lấy các thuộc tính của một bản trình chiếu đã mã hoá**

Thông thường, người dùng gặp khó khăn trong việc truy xuất các thuộc tính tài liệu của một bản trình chiếu đã được mã hoá hoặc bảo vệ mật khẩu. Tuy nhiên, Aspose.Slides cung cấp một cơ chế cho phép bạn bảo vệ mật khẩu một bản trình chiếu đồng thời vẫn cho phép người dùng truy cập các thuộc tính của nó.

**Lưu ý:** Mặc định, khi Aspose.Slides mã hoá một bản trình chiếu, các thuộc tính tài liệu của bản trình chiếu cũng được bảo vệ mật khẩu. Nếu bạn cần cho phép các thuộc tính tài liệu có thể truy cập ngay cả sau khi mã hoá, Aspose.Slides cho phép bạn làm điều đó.

Nếu bạn muốn người dùng vẫn có thể truy cập các thuộc tính của một bản trình chiếu đã mã hoá, bạn có thể đặt thuộc tính [EncryptDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) thành `true`. Mẫu mã nguồn dưới đây cho thấy cách mã hoá một bản trình chiếu đồng thời vẫn cung cấp cho người dùng quyền truy cập các thuộc tính tài liệu:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **Kiểm tra xem một bản trình chiếu có được bảo vệ mật khẩu hay không**

Trước khi tải một bản trình chiếu, bạn có thể muốn kiểm tra xem nó có bị bảo vệ bằng mật khẩu hay không. Điều này giúp bạn tránh các lỗi và các vấn đề tương tự xảy ra khi một bản trình chiếu được bảo vệ mật khẩu được tải mà không có mật khẩu đúng.

Mã C# dưới đây cho thấy cách kiểm tra một bản trình chiếu có được bảo vệ mật khẩu mà không thực sự tải nó:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Kiểm tra xem một bản trình chiếu có được mã hoá hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình chiếu có được mã hoá hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [IsEncrypted](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager/properties/isencrypted), trả về `true` nếu bản trình chiếu đã được mã hoá hoặc `false` nếu chưa.

Mẫu mã nguồn dưới đây cho thấy cách kiểm tra xem một bản trình chiếu có được mã hoá hay không:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Kiểm tra xem một bản trình chiếu có được bảo vệ ghi hay không**

Aspose.Slides cho phép bạn kiểm tra xem một bản trình chiếu có được bảo vệ ghi hay không. Để thực hiện việc này, bạn có thể sử dụng thuộc tính [IsWriteProtected](https://reference.aspose.com/slides/vi/net/aspose.slides/protectionmanager/properties/iswriteprotected), trả về `true` nếu bản trình chiếu được bảo vệ ghi hoặc `false` nếu không.

Mẫu mã nguồn dưới đây cho thấy cách kiểm tra xem một bản trình chiếu có được bảo vệ ghi hay không:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Xác minh việc sử dụng mật khẩu cho bản trình chiếu**

Bạn có thể muốn kiểm tra và xác nhận rằng một mật khẩu cụ thể đã được sử dụng để bảo vệ tài liệu bản trình chiếu. Aspose.Slides cung cấp cách để bạn xác thực mật khẩu.

Mẫu mã nguồn dưới đây cho thấy cách xác thực một mật khẩu:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Kiểm tra xem mật khẩu có khớp hay không.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Phương thức trả về `true` nếu bản trình chiếu đã được mã hoá bằng mật khẩu được chỉ định; ngược lại, trả về `false`.

{{% alert color="primary" title="Xem thêm" %}} 
- [Chữ ký kỹ thuật số trong PowerPoint](/slides/vi/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Bảo vệ bản trình chiếu bằng mật khẩu trực tuyến**

1. Truy cập trang [**Aspose.Slides Lock**](https://products.aspose.app/slides/vi/lock). 
2. Nhấp **Drop or upload your files**. 
3. Chọn tệp bạn muốn bảo vệ bằng mật khẩu trên máy tính. 
4. Nhập mật khẩu bạn muốn dùng cho việc bảo vệ chỉnh sửa và mật khẩu bạn muốn dùng cho việc bảo vệ xem. 
5. Nếu bạn muốn người dùng xem bản trình chiếu như bản sao cuối cùng, đánh dấu vào hộp kiểm **Mark as final**. 
6. Nhấp **PROTECT NOW.** 
7. Nhấp **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **Câu hỏi thường gặp**

**Aspose.Slides hỗ trợ các phương pháp mã hoá nào?**

Aspose.Slides hỗ trợ các phương pháp mã hoá hiện đại, bao gồm các thuật toán dựa trên AES, đảm bảo mức độ bảo mật cao cho dữ liệu của bạn.

**Nếu nhập sai mật khẩu khi cố gắng mở bản trình chiếu thì sẽ xảy ra điều gì?**

Một ngoại lệ sẽ được ném ra khi mật khẩu không đúng, thông báo rằng việc truy cập bản trình chiếu bị từ chối. Điều này giúp ngăn chặn truy cập trái phép và bảo vệ nội dung bản trình chiếu.

**Có ảnh hưởng gì đến hiệu năng khi làm việc với các bản trình chiếu được bảo vệ mật khẩu không?**

Quá trình mã hoá và giải mã có thể tạo ra một chút overhead khi mở và lưu file. Trong hầu hết các trường hợp, tác động này là tối thiểu và không ảnh hưởng đáng kể đến thời gian xử lý tổng thể của các tác vụ liên quan đến bản trình chiếu.