---
title: Thêm chữ ký số vào bản trình bày trong C++
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/cpp/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- cơ quan cấp chứng chỉ
- chứng chỉ PFX
- PKCS#12
- xác thực chữ ký
- PowerPoint
- PPTX
- bảo mật bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình bày PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho C++ để xác thực hoặc xóa chữ ký số."
---
## **Tổng quan**

Một chữ ký số giúp người nhận xác định ai đã ký một bản trình bày và liệu nội dung đã ký có bị thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- Một **chứng chỉ số** là một chứng nhận điện tử liên kết một danh tính với khóa công khai. Một cơ quan cấp chứng chỉ (CA) đáng tin cậy có thể phát hành chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho các quy trình nội bộ.
- Một **chữ ký số** được tạo ra từ nội dung bản trình bày và khóa riêng của người nắm giữ chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được sử dụng để xác minh chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hóa bản trình bày.
- **Bảo vệ bằng mật khẩu** kiểm soát xem người dùng có thể mở hoặc sửa đổi bản trình bày hay không. Nó tách biệt với việc ký số và được mô tả trong [Password-Protected Presentations](/cpp/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** trong **File > Info > Protect Presentation**.

![Menu Bảo vệ Bản trình bày của PowerPoint với Add a Digital Signature được làm nổi bật](add-digital-signature-in-powerpoint.png)

Sau khi một bản trình bày đã ký được mở, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo PowerPoint cho biết bản trình bày chứa các chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký thông qua [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_digitalsignatures/), trả về một [IDigitalSignatureCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignaturecollection/) các mục của nó triển khai [IDigitalSignature](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignature/). Một bản trình bày có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Một tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng là những gì cho phép người nắm giữ tạo chữ ký. Một chứng chỉ mà không có khóa riêng có thể truy cập không thể được sử dụng để ký một bản trình bày.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình bày. Không commit các tệp PFX hoặc mật khẩu của chúng vào hệ thống kiểm soát nguồn. Trong môi trường sản xuất, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình được bảo vệ khác. Các ví dụ dưới đây chỉ sử dụng biến môi trường để tránh nhúng mật khẩu vào mã.

## **Thêm chữ ký số vào một bản trình bày**

Để ký một quy trình bản trình bày thực tế, tải một tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/cpp/aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình bày, và lưu thành tệp PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Lưu kết quả dưới một tên mới giữ nguyên tệp nguồn chưa ký. Giá trị [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignature/set_comments/) mô tả mục đích của chữ ký; nó không phải là một kiểm soát bảo mật.

## **Xác thực chữ ký số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mỗi mục trả về bởi [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_digitalsignatures/). Phương thức [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignature/get_isvalid/) cho biết chữ ký nhúng có hợp lệ cho nội dung bản trình bày hiện tại hay không.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình bày đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Loại bỏ mọi chữ ký tạo ra một bản trình bày chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục không đủ: một quy trình nhạy cảm với bảo mật cũng phải xác minh số lượng chữ ký mong đợi và danh tính người ký mong đợi có tồn tại.

Kết quả hợp lệ này không nên được coi là quyết định tin cậy chứng chỉ hoàn chỉnh. Tùy thuộc vào chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi của chứng chỉ, xác nhận chủ đề hoặc dấu vân tay mong đợi, xác minh mục đích sử dụng khóa và đánh giá dấu thời gian đáng tin cậy. Giá trị [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignature/get_signtime/) tự nó không phải là bằng chứng từ một cơ quan dấu thời gian đáng tin cậy.

## **Xóa chữ ký số**

Việc xóa chữ ký làm thay đổi trạng thái bảo mật của bản trình bày. Ví dụ sau tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignaturecollection/clear/), và lưu một bản sao chưa ký.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Để xóa chỉ một chữ ký, gọi [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignaturecollection/removeat/) với chỉ mục bắt đầu từ 0 của nó. Lưu vào tệp mới trừ khi việc ghi đè bản gốc đã ký là một phần rõ ràng trong quy trình của bạn.

## **Xem xét về chỉnh sửa và định dạng**

- Một chữ ký không làm cho bản trình bày chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng việc thay đổi nội dung đã ký thường làm cho chữ ký hiện có mất hiệu lực.
- Hoàn tất mọi chỉnh sửa dự định trước khi ký. Nếu bản trình bày cần được thay đổi, lưu bản trình bày đã chỉnh sửa và ký lại bản sửa đổi đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình bày đã ký sang định dạng khác không chuyển chữ ký PPTX gốc thành chữ ký hợp lệ cho tệp đã chuyển đổi.
- Xem khóa riêng của chứng chỉ là thông tin nhạy cảm. Bất kỳ ai có được khóa riêng và mật khẩu của nó có thể tạo chữ ký trông như đến từ người nắm giữ chứng chỉ đó.
- Giữ lại nguồn chưa ký hoặc một bản sao kiểm soát khác khi chính sách lưu trữ tài liệu của bạn yêu cầu.

## **Câu hỏi thường gặp**

**Chữ ký số có mã hóa bản trình bày không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình bày vẫn đọc được trừ khi có áp dụng mã hóa riêng biệt. Sử dụng [password protection](/cpp/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu bản trình bày không?**

Không. Mật khẩu PFX mở khóa khóa riêng được lưu trong gói chứng chỉ. Nó không kiểm soát ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể sử dụng chứng chỉ tự ký không?**

Kỹ thuậtally, một chứng chỉ tự ký có thể được sử dụng khi nó bao gồm khóa riêng có thể truy cập. Tuy nhiên, người nhận sẽ không tự động tin tưởng nó, trừ khi chứng chỉ đó đã được thêm một cách rõ ràng vào môi trường đáng tin cậy của họ. Các quy trình công cộng hoặc liên tổ chức thường sử dụng chứng chỉ do một CA đáng tin cậy phát hành.

**Điều gì khiến một chữ ký không hợp lệ?**

Thay đổi nội dung bản trình bày đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký không hợp lệ. Hỏng file cũng có thể gây thất bại khi xác thực. Nếu tất cả chữ ký bị xóa, bản trình bày sẽ không có chữ ký hơn là một tệp chứa chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin tưởng người ký không?**

Không phải tự nó. Tính toàn vẹn của chữ ký và sự tin tưởng vào người ký là những quyết định riêng biệt. Chính sách xác thực trong môi trường sản xuất cũng nên kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính mong đợi, mục đích sử dụng khóa và bất kỳ yêu cầu dấu thời gian đáng tin cậy nào.

**Điều gì xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không làm thay đổi byte của bản trình bày, nhưng nó ảnh hưởng đến việc đánh giá độ tin cậy của chứng chỉ. Một chữ ký có còn chấp nhận được hay không phụ thuộc vào chính sách của bạn và liệu một dấu thời gian đáng tin cậy hợp lệ có chứng minh việc ký đã diễn ra khi chứng chỉ còn hiệu lực hay không. Không nên chỉ dựa vào thời gian ký hiển thị như một dấu thời gian đáng tin cậy.

**Bản trình bày đã ký vẫn có thể chỉnh sửa không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện có mất hiệu lực, vì vậy hoàn thiện bản trình bày trước và ký lại bản sửa đổi cuối cùng.

**Một bản trình bày có thể chứa nhiều hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào bộ sưu tập trả về bởi [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_digitalsignatures/) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả người ký yêu cầu đều có mặt.

**Các định dạng bản trình bày nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký số mô tả ở đây cho định dạng PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng đến các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập rồi lưu bản trình bày. Nội dung slide vẫn còn, nhưng tệp đã lưu không còn mang bằng chứng của chữ ký đã bị xóa.