---
title: Thêm Chữ ký Kỹ thuật số vào Bản trình bày trong .NET
linktitle: Chữ ký kỹ thuật số
type: docs
weight: 10
url: /vi/net/digital-signature-in-powerpoint/
keywords:
- chữ ký kỹ thuật số
- chứng chỉ kỹ thuật số
- cơ quan cấp chứng chỉ
- chứng chỉ PFX
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách ký kỹ thuật số các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Bảo vệ các slide của bạn trong vài giây với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

**Chứng chỉ kỹ thuật số** được sử dụng để tạo một bản trình bày PowerPoint có bảo vệ bằng mật khẩu, được đánh dấu là được tạo bởi một tổ chức hoặc người cụ thể. Chứng chỉ kỹ thuật số có thể lấy được bằng cách liên hệ với một tổ chức được ủy quyền - một cơ quan cấp chứng chỉ. Sau khi cài đặt chứng chỉ kỹ thuật số vào hệ thống, nó có thể được dùng để thêm chữ ký kỹ thuật số vào bản trình bày qua File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Bản trình bày có thể chứa nhiều hơn một chữ ký kỹ thuật số. Sau khi chữ ký kỹ thuật số được thêm vào bản trình bày, một thông báo đặc biệt sẽ xuất hiện trong PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Để ký bản trình bày hoặc kiểm tra tính xác thực của các chữ ký trong bản trình bày, **Aspose.Slides API** cung cấp giao diện [**IDigitalSignature**](https://reference.aspose.com/slides/vi/net/aspose.slides/idigitalsignature), giao diện [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/vi/net/aspose.slides/IDigitalSignatureCollection) và thuộc tính [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/properties/digitalsignatures). Hiện tại, chữ ký kỹ thuật số chỉ được hỗ trợ cho định dạng PPTX.

## **Thêm chữ ký kỹ thuật số từ chứng chỉ PFX**

Mẫu mã dưới đây minh họa cách thêm chữ ký kỹ thuật số từ một chứng chỉ PFX:

1. Mở tệp PFX và truyền mật khẩu PFX cho đối tượng [**DigitalSignature**](https://reference.aspose.com/slides/vi/net/aspose.slides/digitalsignature).
2. Thêm chữ ký đã tạo vào đối tượng bản trình bày.

```c#
using (Presentation pres = new Presentation())
{
    // Tạo đối tượng DigitalSignature với tệp PFX và mật khẩu PFX
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Ghi chú chữ ký kỹ thuật số mới
    signature.Comments = "Aspose.Slides digital signing test.";

    // Thêm chữ ký kỹ thuật số vào bản trình bày
    pres.DigitalSignatures.Add(signature);

    // Lưu bản trình bày
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

Bây giờ có thể kiểm tra xem bản trình bày đã được ký kỹ thuật số và chưa bị chỉnh sửa hay chưa:

```c#
// Mở bản trình bày
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Kiểm tra xem tất cả chữ ký kỹ thuật số có hợp lệ không
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể xoá các chữ ký hiện có khỏi tệp không?**

Có. Bộ sưu tập chữ ký kỹ thuật số hỗ trợ [xóa các mục riêng lẻ](https://reference.aspose.com/slides/vi/net/aspose.slides/digitalsignaturecollection/removeat/) và [xóa toàn bộ](https://reference.aspose.com/slides/vi/net/aspose.slides/digitalsignaturecollection/clear/); sau khi bạn lưu tệp, bản trình bày sẽ không có chữ ký nào.

**Tệp có trở thành “chỉ đọc” sau khi ký không?**

Không. Chữ ký bảo vệ tính toàn vẹn và quyền tác giả nhưng không ngăn việc chỉnh sửa. Để hạn chế chỉnh sửa, kết hợp nó với ["Chỉ đọc" hoặc mật khẩu](/slides/vi/net/password-protected-presentation/).

**Chữ ký có hiển thị đúng trên các phiên bản PowerPoint khác nhau không?**

Chữ ký được tạo cho container OOXML (PPTX). Các phiên bản PowerPoint hiện đại hỗ trợ chữ ký OOXML sẽ hiển thị trạng thái của các chữ ký này một cách đúng đắn.