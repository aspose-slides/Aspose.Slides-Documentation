---
title: Thêm Chữ ký số vào Bản trình chiếu trong C++
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/cpp/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- cơ quan cấp chứng chỉ
- chứng chỉ PFX
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách ký số các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Bảo mật slide của bạn trong vài giây với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

**Chứng chỉ số** được dùng để tạo một bản trình chiếu PowerPoint được bảo vệ bằng mật khẩu, được đánh dấu là được tạo bởi một tổ chức hoặc người cụ thể. Chứng chỉ số có thể được lấy bằng cách liên hệ với một tổ chức được ủy quyền - một cơ quan cấp chứng chỉ. Sau khi cài đặt chứng chỉ số vào hệ thống, nó có thể được dùng để thêm chữ ký số vào bản trình chiếu qua File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Bản trình chiếu có thể chứa nhiều hơn một chữ ký số. Sau khi chữ ký số được thêm vào bản trình chiếu, một thông báo đặc biệt sẽ xuất hiện trong PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Để ký bản trình chiếu hoặc kiểm tra tính xác thực của các chữ ký trong bản trình chiếu, **Aspose.Slides API** cung cấp giao diện [**IDigitalSignature**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_digital_signature), giao diện [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_digital_signature_collection) và phương thức [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). Hiện tại, chữ ký số chỉ được hỗ trợ cho định dạng PPTX.

## **Thêm chữ ký số từ chứng chỉ PFX**

Mẫu mã dưới đây minh họa cách thêm chữ ký số từ một chứng chỉ PFX:

1. Mở tệp PFX và truyền mật khẩu PFX cho đối tượng [**DigitalSignature**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.digital_signature).
1. Thêm chữ ký đã tạo vào đối tượng bản trình chiếu.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Tạo đối tượng DigitalSignature với tệp PFX và mật khẩu PFX
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Ghi chú chữ ký số mới
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Thêm chữ ký số vào bản trình chiếu
pres->get_DigitalSignatures()->Add(signature);

// Lưu bản trình chiếu
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Bây giờ có thể kiểm tra xem bản trình chiếu đã được ký số và chưa bị sửa đổi hay chưa:

``` cpp
// Mở bản trình chiếu
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Kiểm tra xem tất cả chữ ký số có hợp lệ hay không
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể xóa các chữ ký hiện có khỏi tệp không?**

Có. Bộ sưu tập chữ ký số hỗ trợ [loại bỏ các mục riêng lẻ](https://reference.aspose.com/slides/vi/cpp/aspose.slides/digitalsignaturecollection/removeat/) và [xóa toàn bộ](https://reference.aspose.com/slides/vi/cpp/aspose.slides/digitalsignaturecollection/clear/); sau khi bạn lưu tệp, bản trình chiếu sẽ không có chữ ký nào.

**Tệp có trở thành “chỉ đọc” sau khi ký không?**

Không. Chữ ký bảo vệ tính toàn vẹn và quyền tác giả nhưng không chặn việc chỉnh sửa. Để hạn chế chỉnh sửa, kết hợp nó với ["Read-only" hoặc mật khẩu](/slides/vi/cpp/password-protected-presentation/).

**Chữ ký sẽ hiển thị đúng trong các phiên bản PowerPoint khác nhau không?**

Chữ ký được tạo cho container OOXML (PPTX). Các phiên bản PowerPoint hiện đại hỗ trợ chữ ký OOXML sẽ hiển thị trạng thái của các chữ ký này một cách chính xác.