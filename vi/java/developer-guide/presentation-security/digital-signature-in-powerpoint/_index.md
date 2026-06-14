---
title: Thêm Chữ ký Kỹ thuật số vào Bài thuyết trình trong Java
linktitle: Chữ ký Kỹ thuật số
type: docs
weight: 10
url: /vi/java/digital-signature-in-powerpoint/
keywords:
- chữ ký kỹ thuật số
- chứng chỉ kỹ thuật số
- cơ quan cấp chứng chỉ
- chứng chỉ PFX
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách ký kỹ thuật số các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Bảo vệ các slide của bạn trong vài giây với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

**Chứng chỉ kỹ thuật số** được sử dụng để tạo một bài thuyết trình PowerPoint có bảo vệ bằng mật khẩu, được đánh dấu là được tạo bởi một tổ chức hoặc cá nhân cụ thể. Chứng chỉ kỹ thuật số có thể được lấy bằng cách liên hệ với một tổ chức được ủy quyền - một cơ quan cấp chứng chỉ. Sau khi cài đặt chứng chỉ kỹ thuật số vào hệ thống, nó có thể được sử dụng để thêm chữ ký kỹ thuật số vào bài thuyết trình qua File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Bài thuyết trình có thể chứa nhiều hơn một chữ ký kỹ thuật số. Sau khi chữ ký kỹ thuật số được thêm vào bài thuyết trình, một thông báo đặc biệt sẽ xuất hiện trong PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Để ký bài thuyết trình hoặc kiểm tra tính xác thực của các chữ ký trong bài thuyết trình, **Aspose.Slides API** cung cấp giao diện [**IDigitalSignature**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IDigitalSignature), giao diện [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IDigitalSignatureCollection) và phương thức [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentation#getDigitalSignatures--). Hiện tại, chữ ký kỹ thuật số chỉ được hỗ trợ cho định dạng PPTX.

## **Thêm chữ ký kỹ thuật số từ chứng chỉ PFX**

Đoạn mã mẫu dưới đây minh họa cách thêm chữ ký kỹ thuật số từ một chứng chỉ PFX:

1. Mở tệp PFX và truyền mật khẩu PFX cho đối tượng [**DigitalSignature**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/DigitalSignature).
2. Thêm chữ ký đã tạo vào đối tượng bài thuyết trình.

```java
// Mở tệp bài thuyết trình
Presentation pres = new Presentation();
try {
    // Tạo đối tượng DigitalSignature với tệp PFX và mật khẩu PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Bình luận cho chữ ký kỹ thuật số mới
    signature.setComments("Aspose.Slides digital signing test.");

    // Thêm chữ ký kỹ thuật số vào bài thuyết trình
    pres.getDigitalSignatures().add(signature);

    // Lưu bài thuyết trình
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Bây giờ có thể kiểm tra xem bài thuyết trình đã được ký kỹ thuật số và không bị sửa đổi hay chưa:

```java
// Mở bài thuyết trình
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Kiểm tra xem tất cả chữ ký kỹ thuật số có hợp lệ không
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

## **Câu hỏi thường gặp**

**Tôi có thể xóa các chữ ký hiện có khỏi tệp không?**

Có. Bộ sưu tập chữ ký kỹ thuật số hỗ trợ [xóa các mục riêng lẻ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) và [xóa toàn bộ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/digitalsignaturecollection/#clear--); sau khi bạn lưu tệp, bài thuyết trình sẽ không còn chữ ký nào.

**Tệp có trở thành "chỉ đọc" sau khi ký không?**

Không. Chữ ký bảo vệ tính toàn vẹn và quyền tác giả nhưng không ngăn chỉnh sửa. Để hạn chế việc chỉnh sửa, hãy kết hợp nó với ["Chỉ đọc" hoặc mật khẩu](/slides/vi/java/password-protected-presentation/).

**Chữ ký sẽ hiển thị đúng trong các phiên bản PowerPoint khác nhau không?**

Chữ ký được tạo cho container OOXML (PPTX). Các phiên bản PowerPoint hiện đại hỗ trợ chữ ký OOXML sẽ hiển thị trạng thái của các chữ ký này một cách chính xác.