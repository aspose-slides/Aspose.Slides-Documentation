---
title: Thêm Chữ ký số vào Bản trình chiếu trên Android
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/androidjava/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng thư số
- cơ quan chứng thực
- chứng thư PFX
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách ký số các tệp PowerPoint & OpenDocument bằng Aspose.Slides cho Android. Bảo mật slide của bạn trong vài giây với các ví dụ mã Java rõ ràng."
---
## **Giới thiệu**

**Chứng thư số** được sử dụng để tạo một bản thuyết trình PowerPoint được bảo mật bằng mật khẩu, được đánh dấu là được tạo bởi một tổ chức hoặc người cụ thể. Chứng thư số có thể được lấy bằng cách liên hệ với một tổ chức được ủy quyền – một cơ quan chứng thực. Sau khi cài đặt chứng thư số vào hệ thống, nó có thể được dùng để thêm chữ ký số vào bản thuyết trình qua File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Bản thuyết trình có thể chứa nhiều hơn một chữ ký số. Sau khi chữ ký số được thêm vào bản thuyết trình, một thông báo đặc biệt sẽ xuất hiện trong PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Để ký bản thuyết trình hoặc kiểm tra tính xác thực của các chữ ký bản thuyết trình, **Aspose.Slides API** cung cấp[**IDigitalSignature**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IDigitalSignature) giao diện,[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IDigitalSignatureCollection) giao diện và[**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) phương thức. Hiện tại, chữ ký số chỉ được hỗ trợ cho định dạng PPTX.

## **Thêm chữ ký số từ chứng thư PFX**

Mẫu mã dưới đây minh họa cách thêm chữ ký số từ một chứng thư PFX:

1. Mở tệp PFX và truyền mật khẩu PFX vào đối tượng[**DigitalSignature**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/DigitalSignature).
1. Thêm chữ ký đã tạo vào đối tượng bản thuyết trình.

```java
// Mở tệp bản trình chiếu
Presentation pres = new Presentation();
try {
    // Tạo đối tượng DigitalSignature với tệp PFX và mật khẩu PFX
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Ghi chú cho chữ ký số mới
    signature.setComments("Aspose.Slides digital signing test.");

    // Thêm chữ ký số vào bản trình chiếu
    pres.getDigitalSignatures().add(signature);

    // Lưu bản trình chiếu
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Bây giờ có thể kiểm tra xem bản thuyết trình đã được ký số và chưa bị sửa đổi hay chưa:

```java
// Mở bản trình chiếu
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Kiểm tra xem tất cả chữ ký số có hợp lệ không
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Tôi có thể xóa các chữ ký hiện có khỏi tệp không?**

Có. Bộ sưu tập chữ ký số hỗ trợ[removing individual items](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) và[clearing it entirely](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--); sau khi bạn lưu tệp, bản thuyết trình sẽ không còn chữ ký nào.

**Tệp có trở thành “chỉ đọc” sau khi ký không?**

Không. Chữ ký bảo toàn tính toàn vẹn và quyền tác giả nhưng không ngăn chỉnh sửa. Để hạn chế chỉnh sửa, kết hợp nó với["chỉ đọc" or a password](/slides/vi/androidjava/password-protected-presentation/).

**Chữ ký có hiển thị đúng trong các phiên bản PowerPoint khác nhau không?**

Chữ ký được tạo cho container OOXML (PPTX). Các phiên bản PowerPoint hiện đại hỗ trợ chữ ký OOXML sẽ hiển thị trạng thái của các chữ ký này một cách chính xác.