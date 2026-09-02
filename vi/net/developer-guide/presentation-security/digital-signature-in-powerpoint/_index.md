---
title: Thêm Chữ ký Số vào Bản trình chiếu trong .NET
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/net/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- cơ quan chứng chỉ
- chứng chỉ PFX
- PKCS#12
- xác thực chữ ký
- PowerPoint
- PPTX
- bảo mật bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình chiếu PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho .NET để xác thực hoặc xóa chữ ký số."
---
## **Tổng quan**

Chữ ký số giúp người nhận xác định ai đã ký một bản trình chiếu và liệu nội dung đã ký có bị thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- Một **digital certificate** là một chứng chỉ điện tử liên kết một danh tính với một khóa công khai. Một cơ quan chứng chỉ (CA) đáng tin cậy có thể cấp chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho quy trình nội bộ.
- **digital signature** được tạo từ nội dung bản trình chiếu và khóa riêng của người giữ chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được sử dụng để xác minh chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình chiếu.
- **Password protection** kiểm soát việc người dùng có thể mở hoặc chỉnh sửa một bản trình chiếu hay không. Nó tách biệt với việc ký số và được mô tả trong [Password-Protected Presentations](/net/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** trong **File > Info > Protect Presentation**.

![Menu Bảo vệ Bản trình chiếu của PowerPoint với tùy chọn Add a Digital Signature được đánh dấu](add-digital-signature-in-powerpoint.png)

Sau khi mở một bản trình chiếu đã ký, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo PowerPoint cho biết bản trình chiếu chứa các chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký thông qua [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/digitalsignatures/), một [IDigitalSignatureCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignaturecollection/) mà các mục của nó triển khai [IDigitalSignature](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignature/). Một bản trình chiếu có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Một tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng là thứ cho phép người giữ tạo chữ ký. Một chứng chỉ không có khóa riêng có thể truy cập được sẽ không thể dùng để ký một bản trình chiếu.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình chiếu. Không đưa các tệp PFX hoặc mật khẩu của chúng lên hệ thống kiểm soát phiên bản. Trong môi trường sản xuất, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình bảo vệ khác. Các ví dụ dưới đây chỉ sử dụng biến môi trường để tránh nhúng mật khẩu trực tiếp trong mã.

## **Thêm Chữ ký Số vào Bản trình chiếu**

Để ký một quy trình trình chiếu thực tế, tải một tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/net/aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình chiếu, và lưu thành tệp PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Lưu kết quả với tên mới giữ nguyên tệp nguồn chưa ký. Giá trị [DigitalSignature.Comments](https://reference.aspose.com/slides/vi/net/aspose.slides/digitalsignature/comments/) mô tả mục đích của chữ ký; nó không phải là một điều khoản bảo mật.

## **Xác thực Chữ ký Số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mọi mục trong [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/digitalsignatures/). Thuộc tính [IDigitalSignature.IsValid](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignature/isvalid/) cho biết chữ ký nhúng có hợp lệ cho nội dung bản trình chiếu hiện tại hay không.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình chiếu đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Việc xóa mọi chữ ký tạo ra một bản trình chiếu chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục là không đủ: một quy trình nhạy cảm với bảo mật cũng phải xác minh rằng số lượng chữ ký và danh tính người ký mong đợi đều có mặt.

Kết quả hợp lệ này không nên được coi là quyết định hoàn toàn về độ tin cậy của chứng chỉ. Tùy vào chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi của chứng chỉ, xác nhận chủ đề hoặc dấu vân tay mong đợi, xác minh mục đích sử dụng khóa, và đánh giá dấu thời gian đáng tin cậy. Giá trị [IDigitalSignature.SignTime](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignature/signtime/) tự nó không phải là bằng chứng từ một cơ quan thời gian đáng tin cậy.

## **Xóa Chữ ký Số**

Xóa chữ ký làm thay đổi trạng thái bảo mật của bản trình chiếu. Ví dụ dưới đây tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignaturecollection/clear/), và lưu một bản sao chưa ký.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Để xóa chỉ một chữ ký, gọi [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignaturecollection/removeat/) với chỉ số bắt đầu từ 0 của nó. Lưu vào tệp mới trừ khi việc ghi đè lên bản gốc đã ký là một phần rõ ràng của quy trình của bạn.

## **Cân nhắc về Chỉnh sửa và Định dạng**

- Một chữ ký không làm cho bản trình chiếu chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng việc thay đổi nội dung đã ký thường làm vô hiệu hoá chữ ký hiện có.
- Hoàn thành mọi chỉnh sửa dự định trước khi ký. Nếu bản trình chiếu cần thay đổi, lưu bản trình chiếu đã sửa và ký lại phiên bản đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình chiếu đã ký sang định dạng khác không truyền tải chữ ký PPTX gốc thành chữ ký hợp lệ cho tệp đã chuyển đổi.
- Xem khóa riêng của chứng chỉ là thông tin nhạy cảm. Bất kỳ ai có được khóa riêng và mật khẩu của nó có thể tạo chữ ký trông như đến từ người giữ chứng chỉ đó.
- Giữ lại nguồn chưa ký hoặc một bản sao được kiểm soát khi chính sách lưu trữ tài liệu của bạn yêu cầu.

## **Câu hỏi thường gặp**

**Chữ ký số có mã hoá bản trình chiếu không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình chiếu vẫn có thể đọc được trừ khi có áp dụng mã hoá riêng biệt. Sử dụng [password protection](/net/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu của bản trình chiếu không?**

Không. Mật khẩu PFX mở khóa khóa riêng được lưu trong gói chứng chỉ. Nó không kiểm soát việc ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể sử dụng chứng chỉ tự ký không?**

Về mặt kỹ thuật, chứng chỉ tự ký có thể được sử dụng khi nó bao gồm khóa riêng có thể truy cập. Người nhận sẽ không tự động tin cậy nó trừ khi chứng chỉ đã được thêm một cách rõ ràng vào môi trường đáng tin cậy của họ. Các quy trình công cộng hoặc liên tổ chức thường sử dụng chứng chỉ do CA đáng tin cậy phát hành.

**Điều gì làm cho chữ ký không hợp lệ?**

Thay đổi nội dung bản trình chiếu đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký không hợp lệ. Hỏng hóc tệp cũng có thể gây thất bại trong việc xác thực. Nếu tất cả chữ ký bị xóa, bản trình chiếu sẽ không có chữ ký thay vì chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin tưởng người ký không?**

Không tự nó. Tính toàn vẹn của chữ ký và độ tin cậy của người ký là những quyết định riêng biệt. Chính sách xác thực trong môi trường sản xuất cũng nên kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính mong đợi, mục đích sử dụng khóa, và bất kỳ yêu cầu về dấu thời gian đáng tin cậy nào.

**Điều gì xảy ra khi chứng chỉ hết hạn?**

Việc hết hạn chứng chỉ không thay đổi byte của bản trình chiếu, nhưng ảnh hưởng đến việc đánh giá độ tin cậy của chứng chỉ. Chữ ký có còn chấp nhận được hay không phụ thuộc vào chính sách của bạn và liệu một dấu thời gian đáng tin cậy hợp lệ có chứng minh rằng việc ký đã diễn ra khi chứng chỉ còn hiệu lực. Không nên chỉ dựa vào thời gian ký hiển thị như một dấu thời gian đáng tin cậy.

**Bản trình chiếu đã ký có thể vẫn được chỉnh sửa không?**

Đúng. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện có không hợp lệ, vì vậy hãy hoàn thiện bản trình chiếu trước và ký lại phiên bản cuối cùng.

**Một bản trình chiếu có thể chứa nhiều hơn một chữ ký không?**

Đúng. Thêm mỗi chữ ký vào [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/digitalsignatures/) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả người ký cần thiết đều có mặt.

**Các định dạng bản trình chiếu nào hỗ trợ các thao tác này?**

Aspose.Slides hỗ trợ các thao tác chữ ký số mô tả ở đây chỉ cho PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng đến các slide không?**

Đúng. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập và sau đó lưu bản trình chiếu. Nội dung slide vẫn còn, nhưng tệp đã lưu sẽ không còn chứa chứng cứ của chữ ký đã bị xóa.