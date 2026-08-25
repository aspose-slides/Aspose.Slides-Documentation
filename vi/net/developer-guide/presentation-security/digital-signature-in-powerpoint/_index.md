---
title: Thêm Chữ ký Số vào Bài thuyết trình trong .NET
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/net/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- cơ quan cấp chứng chỉ
- chứng chỉ PFX
- PKCS#12
- xác thực chữ ký
- PowerPoint
- PPTX
- bảo mật bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách ký các bài thuyết trình PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho .NET để xác thực hoặc xóa chữ ký số."
---
## **Overview**

Chữ ký số giúp người nhận xác định ai đã ký một bài thuyết trình và liệu nội dung đã ký có thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- Một **digital certificate** là một chứng nhận điện tử liên kết một danh tính với một khóa công khai. Một cơ quan chứng nhận (CA) đáng tin cậy có thể phát hành chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho các quy trình nội bộ.
- Một **digital signature** được tạo từ nội dung bài thuyết trình và khóa riêng của người giữ chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được dùng để xác minh chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bài thuyết trình.
- **Password protection** kiểm soát việc người dùng có thể mở hoặc chỉnh sửa một bài thuyết trình hay không. Nó tách biệt khỏi việc ký số và được mô tả trong [Password-Protected Presentations](/slides/vi/net/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** dưới **File > Info > Protect Presentation**.

![Menu Bảo vệ Bài thuyết trình trong PowerPoint với mục Add a Digital Signature được đánh dấu](add-digital-signature-in-powerpoint.png)

Sau khi một bài thuyết trình đã ký được mở, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo PowerPoint cho biết rằng bài thuyết trình chứa các chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký thông qua [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/digitalsignatures/), một [IDigitalSignatureCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignaturecollection/) mà các mục của nó thực thi [IDigitalSignature](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignature/). Một bài thuyết trình có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Một tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng là thứ cho phép người giữ tạo chữ ký. Một chứng chỉ không có khóa riêng có thể truy cập được không thể được dùng để ký một bài thuyết trình.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bài thuyết trình. Không commit các tệp PFX hoặc mật khẩu của chúng vào hệ thống kiểm soát phiên bản. Trong môi trường sản xuất, hạn chế truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình được bảo vệ khác. Các ví dụ dưới đây chỉ sử dụng biến môi trường để tránh nhúng mật khẩu trong mã.

## **Thêm Chữ ký Số vào Bài thuyết trình**

Để ký một quy trình bài thuyết trình thực tế, tải một tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/net/aspose.slides/digitalsignature/) từ một chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bài thuyết trình, và lưu thành tệp PPTX.

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

Lưu kết quả dưới một tên mới sẽ giữ nguyên tệp nguồn chưa ký. Giá trị [DigitalSignature.Comments](https://reference.aspose.com/slides/vi/net/aspose.slides/digitalsignature/comments/) mô tả mục đích của chữ ký; nó không phải là một kiểm soát bảo mật.

## **Xác minh Chữ ký Số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mọi mục trong [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/digitalsignatures/). Thuộc tính [IDigitalSignature.IsValid](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignature/isvalid/) cho biết chữ ký nhúng có hợp lệ cho nội dung hiện tại của bài thuyết trình hay không.

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

Kết quả không hợp lệ thường có nghĩa là nội dung của bài thuyết trình đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Việc xóa mọi chữ ký sẽ tạo ra một bài thuyết trình chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục là không đủ: một quy trình nhạy cảm với bảo mật cũng phải xác minh rằng số lượng chữ ký mong đợi và danh tính người ký dự kiến đều có mặt.

Kết quả hợp lệ này không nên được coi là quyết định hoàn toàn về độ tin cậy của chứng chỉ. Tùy thuộc vào chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi của chứng chỉ, xác nhận chủ thể hoặc dấu vân tay mong đợi, xác minh cách sử dụng khóa, và đánh giá dấu thời gian đáng tin cậy. Giá trị [IDigitalSignature.SignTime](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignature/signtime/) tự thân không phải là bằng chứng từ một cơ quan thời gian đáng tin.

## **Xóa Chữ ký Số**

Xóa chữ ký làm thay đổi trạng thái bảo mật của bài thuyết trình. Ví dụ dưới đây tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignaturecollection/clear/), và lưu một bản sao chưa ký.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Để xóa chỉ một chữ ký, gọi [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignaturecollection/removeat/) với chỉ số bắt đầu từ 0 của nó. Lưu thành tệp mới trừ khi việc ghi đè lên bản gốc đã ký là một phần rõ ràng trong quy trình của bạn.

## **Cân nhắc về Chỉnh sửa và Định dạng**

- Một chữ ký không làm cho bài thuyết trình chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng việc thay đổi nội dung đã ký thường làm cho chữ ký hiện có không còn hợp lệ.
- Hoàn thành mọi chỉnh sửa dự định trước khi ký. Nếu cần thay đổi bài thuyết trình, lưu bản sửa đổi và ký lại phiên bản đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bài thuyết trình đã ký sang định dạng khác không chuyển chữ ký PPTX gốc thành một chữ ký hợp lệ cho tệp đã chuyển đổi.
- Xem khóa riêng của chứng chỉ là thông tin nhạy cảm. Bất kỳ ai có được khóa riêng và mật khẩu của nó có thể tạo ra các chữ ký trông giống như đến từ người giữ chứng chỉ đó.
- Giữ lại nguồn chưa ký hoặc một bản sao kiểm soát khác khi chính sách lưu trữ tài liệu của bạn yêu cầu.

## **Câu hỏi thường gặp**

**Chữ ký số có mã hoá bài thuyết trình không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bài thuyết trình vẫn có thể đọc được trừ khi áp dụng mã hoá riêng. Hãy sử dụng [password protection](/slides/vi/net/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống với mật khẩu của bài thuyết trình không?**

Không. Mật khẩu PFX mở khóa khóa riêng được lưu trong gói chứng chỉ. Nó không kiểm soát ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể sử dụng chứng chỉ tự ký không?**

Về mặt kỹ thuật, một chứng chỉ tự ký có thể được sử dụng khi nó bao gồm một khóa riêng có thể truy cập được. Tuy nhiên, người nhận sẽ không tự động tin tưởng nó, trừ khi chứng chỉ đó đã được thêm một cách rõ ràng vào môi trường đáng tin cậy của họ. Các quy trình công cộng hoặc giữa các tổ chức thường sử dụng chứng chỉ được cấp bởi một CA đáng tin cậy.

**Điều gì khiến một chữ ký không hợp lệ?**

Thay đổi nội dung đã ký của bài thuyết trình hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký không hợp lệ. Hỏng hỏng tệp cũng có thể gây thất bại trong quá trình xác thực. Nếu tất cả các chữ ký bị xóa, bài thuyết trình sẽ trở thành chưa ký thay vì là tệp chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin tưởng người ký không?**

Không phải tự nó. Tính toàn vẹn của chữ ký và độ tin cậy của người ký là các quyết định riêng biệt. Chính sách xác thực trong môi trường sản xuất cũng nên kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính mong đợi, cách sử dụng khóa và bất kỳ yêu cầu về dấu thời gian đáng tin cậy nào.

**Điều gì xảy ra khi chứng chỉ hết hạn?**

Hạn chế của chứng chỉ không làm thay đổi các byte của bài thuyết trình, nhưng nó ảnh hưởng đến việc đánh giá độ tin cậy của chứng chỉ. Việc chữ ký có còn chấp nhận được hay không phụ thuộc vào chính sách của bạn và việc có một dấu thời gian đáng tin cậy hợp lệ chứng minh việc ký đã xảy ra khi chứng chỉ còn hiệu lực hay không. Không nên chỉ dựa vào thời gian ký hiển thị như một dấu thời gian tin cậy.

**Bài thuyết trình đã ký vẫn có thể chỉnh sửa được không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện có không còn hợp lệ, vì vậy hãy hoàn thiện bài thuyết trình trước và ký phiên bản cuối cùng.

**Một bài thuyết trình có thể chứa hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/digitalsignatures/) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả người ký cần thiết đều có mặt.

**Định dạng bài thuyết trình nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký số mô tả ở đây cho định dạng PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng tới các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập, sau đó lưu lại bài thuyết trình. Nội dung slide vẫn còn, nhưng tệp đã lưu không còn chứa bằng chứng của chữ ký đã xóa.