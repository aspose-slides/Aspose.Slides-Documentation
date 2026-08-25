---
title: Thêm Chữ ký Số vào Bản trình chiếu trong C++
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/cpp/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- nhà cấp chứng chỉ
- chứng chỉ PFX
- PKCS#12
- xác thực chữ ký
- PowerPoint
- PPTX
- bảo mật bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình chiếu PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho C++ để xác thực hoặc xóa chữ ký số."
---
## **Tổng quan**

Chữ ký số giúp người nhận xác định ai đã ký bản trình chiếu và liệu nội dung đã ký có bị thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- Một **chứng chỉ số** là một giấy tờ điện tử liên kết danh tính với một khoá công khai. Một tổ chức chứng nhận (CA) đáng tin cậy có thể phát hành chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho các quy trình nội bộ.
- Một **chữ ký số** được tạo từ nội dung bản trình chiếu và khoá riêng của người giữ chứng chỉ. Khoá công khai của chứng chỉ sau đó có thể được dùng để xác minh chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình chiếu.
- **Bảo vệ bằng mật khẩu** kiểm soát người dùng có thể mở hoặc chỉnh sửa bản trình chiếu hay không. Nó riêng biệt với việc ký số và được mô tả trong [Bảo vệ bản trình chiếu bằng mật khẩu](/slides/vi/cpp/password-protected-presentation/).

PowerPoint cung cấp lệnh **Thêm chữ ký số** dưới **File > Info > Protect Presentation**.

![Menu Bảo vệ bản trình chiếu của PowerPoint với mục Thêm chữ ký số được làm nổi bật](add-digital-signature-in-powerpoint.png)

Sau khi mở một bản trình chiếu đã ký, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo PowerPoint cho biết bản trình chiếu chứa chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký qua [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_digitalsignatures/), trả về một [IDigitalSignatureCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignaturecollection/) mà các mục triển khai [IDigitalSignature](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignature/). Một bản trình chiếu có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khoá riêng của nó và chuỗi chứng chỉ. Khoá riêng là thứ cho phép người giữ tạo chữ ký. Chứng chỉ không có khoá riêng có thể truy cập không thể dùng để ký bản trình chiếu.

Mật khẩu PFX bảo vệ gói chứng chỉ và khoá riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình chiếu. Không được commit tệp PFX hoặc mật khẩu của chúng vào hệ thống kiểm soát phiên bản. Trong môi trường sản xuất, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình được bảo vệ khác. Các ví dụ dưới đây chỉ dùng biến môi trường để tránh nhúng mật khẩu trong mã.

## **Thêm chữ ký số vào bản trình chiếu**

Để ký quy trình thực tế, tải tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/cpp/aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình chiếu, và lưu thành tệp PPTX.

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

Lưu kết quả với tên mới giúp bảo tồn tệp nguồn chưa ký. Giá trị của [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignature/set_comments/) mô tả mục đích của chữ ký; nó không phải là một cơ chế kiểm soát bảo mật.

## **Xác thực chữ ký số**

Khi tải một tệp PPTX đã ký, kiểm tra mọi mục trả về bởi [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_digitalsignatures/). Phương thức [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignature/get_isvalid/) cho biết chữ ký nhúng có hợp lệ cho nội dung hiện tại của bản trình chiếu hay không.

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

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình chiếu đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Việc loại bỏ mọi chữ ký sẽ tạo ra một bản trình chiếu chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục không đủ: một quy trình nhạy cảm về bảo mật cũng phải xác minh số lượng chữ ký mong đợi và danh tính của người ký.

Kết quả hợp lệ này không nên được coi là quyết định tin cậy hoàn toàn đối với chứng chỉ. Tùy theo chính sách bảo mật, ứng dụng của bạn có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi, xác nhận chủ đề hoặc dấu vân tay mong đợi, kiểm tra mục đích sử dụng khoá, và đánh giá dấu thời gian đáng tin cậy. Giá trị của [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignature/get_signtime/) tự nó không phải là bằng chứng từ một cơ quan thời gian đáng tin cậy.

## **Xóa chữ ký số**

Việc xóa chữ ký thay đổi trạng thái bảo mật của bản trình chiếu. Ví dụ dưới đây tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignaturecollection/clear/), và lưu một bản sao chưa ký.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Để xóa chỉ một chữ ký, gọi [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides/idigitalsignaturecollection/removeat/) với chỉ số zero‑based của nó. Lưu vào tệp mới trừ khi việc ghi đè lên bản gốc đã ký là một phần rõ ràng của quy trình của bạn.

## **Cân nhắc về chỉnh sửa và định dạng**

- Một chữ ký không làm cho bản trình chiếu ở chế độ chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng việc thay đổi nội dung đã ký thường làm cho chữ ký hiện có trở nên không hợp lệ.
- Hoàn thiện mọi chỉnh sửa dự định trước khi ký. Nếu bản trình chiếu cần thay đổi, lưu bản trình chiếu đã chỉnh sửa và ký lại phiên bản đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình chiếu đã ký sang định dạng khác sẽ không truyền chữ ký PPTX gốc thành chữ ký hợp lệ cho tệp đã chuyển đổi.
- Xem khoá riêng của chứng chỉ là thông tin nhạy cảm. Bất kỳ ai có được khoá riêng và mật khẩu của nó có thể tạo ra chữ ký trông như đến từ người giữ chứng chỉ đó.
- Giữ lại nguồn chưa ký hoặc một bản sao được kiểm soát khi chính sách lưu trữ tài liệu của bạn yêu cầu.

## **Câu hỏi thường gặp**

**Chữ ký số có mã hoá bản trình chiếu không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình chiếu vẫn có thể đọc được trừ khi có mã hoá riêng biệt được áp dụng. Sử dụng [bảo vệ bằng mật khẩu](/slides/vi/cpp/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu bản trình chiếu không?**

Không. Mật khẩu PFX mở khoá khoá riêng lưu trong gói chứng chỉ. Nó không kiểm soát ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể sử dụng chứng chỉ tự ký không?**

Kỹ thuật적으로, một chứng chỉ tự ký có thể được dùng khi nó bao gồm khoá riêng có thể truy cập. Tuy nhiên, người nhận sẽ không tự động tin cậy nó trừ khi chứng chỉ đã được thêm một cách rõ ràng vào môi trường tin cậy của họ. Các quy trình công cộng hoặc liên tổ chức thường dùng chứng chỉ được phát hành bởi một CA đáng tin cậy.

**Điều gì khiến một chữ ký trở nên không hợp lệ?**

Thay đổi nội dung bản trình chiếu đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký không hợp lệ. Hỏng hóc tệp cũng có thể gây lỗi xác thực. Nếu tất cả chữ ký bị xóa, bản trình chiếu sẽ trở thành chưa ký thay vì chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin vào người ký không?**

Không tự động. Tính toàn vẹn của chữ ký và độ tin cậy của người ký là các quyết định riêng biệt. Chính sách xác thực trong môi trường sản xuất cũng nên kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính mong đợi, mục đích sử dụng khoá và bất kỳ yêu cầu dấu thời gian đáng tin cậy nào.

**Điều gì xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không thay đổi byte của bản trình chiếu, nhưng ảnh hưởng đến việc đánh giá độ tin cậy của chứng chỉ. Việc chữ ký có còn được chấp nhận hay không phụ thuộc vào chính sách của bạn và liệu một dấu thời gian đáng tin cậy hợp lệ có chứng minh rằng việc ký đã xảy ra khi chứng chỉ còn hiệu lực. Đừng chỉ dựa vào thời gian ký hiển thị làm dấu thời gian đáng tin cậy.

**Bản trình chiếu đã ký vẫn có thể được chỉnh sửa không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện có không hợp lệ, vì vậy hãy hoàn thiện bản trình chiếu trước và ký lần cuối.

**Một bản trình chiếu có thể chứa nhiều hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào bộ sưu tập trả về bởi [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_digitalsignatures/) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả người ký bắt buộc đều hiện diện.

**Các định dạng bản trình chiếu nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký số mô tả ở đây cho định dạng PPTX. Định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng đến các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập, sau đó lưu bản trình chiếu. Nội dung slide vẫn còn, nhưng tệp đã lưu sẽ không còn chứa bằng chứng về chữ ký đã bị xóa.