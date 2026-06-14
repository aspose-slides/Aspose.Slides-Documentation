---
title: Thêm Chữ ký Kỹ thuật số vào Bản trình chiếu trong JavaScript
linktitle: Chữ ký kỹ thuật số
type: docs
weight: 10
url: /vi/nodejs-java/digital-signature-in-powerpoint/
keywords:
- chữ ký kỹ thuật số
- chứng chỉ kỹ thuật số
- cơ quan cấp chứng chỉ
- chứng chỉ PFX
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách ký kỹ thuật số các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js thông qua Java. Bảo mật các slide của bạn trong vài giây với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

**Chứng cái kỹ thuật số** được sử dụng để tạo một bản trình chiếu PowerPoint được bảo vệ bằng mật khẩu, được đánh dấu là do một tổ chức hoặc cá nhân cụ thể tạo ra. Chứng cái kỹ thuật số có thể được lấy bằng cách liên hệ với một tổ chức được ủy quyền - cơ quan chứng chỉ. Sau khi cài đặt chứng cái kỹ thuật số vào hệ thống, nó có thể được sử dụng để thêm chữ ký kỹ thuật số vào bản trình chiếu thông qua File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Bản trình chiếu có thể chứa nhiều hơn một chữ ký kỹ thuật số. Sau khi chữ ký kỹ thuật số được thêm vào bản trình chiếu, một thông báo đặc biệt sẽ xuất hiện trong PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Để ký bản trình chiếu hoặc kiểm tra tính xác thực của các chữ ký trong bản trình chiếu, **Aspose.Slides API** cung cấp [**DigitalSignature**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/DigitalSignature) lớp, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/DigitalSignatureCollection) lớp và [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) phương thức. Hiện tại, chữ ký kỹ thuật số chỉ được hỗ trợ cho định dạng PPTX.

## **Thêm Chữ ký Kỹ thuật số từ Chứng cái PFX**
Mẫu mã dưới đây minh họa cách thêm chữ ký kỹ thuật số từ chứng chỉ PFX:

1. Mở tệp PFX và truyền mật khẩu PFX cho [**DigitalSignature**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/DigitalSignature) đối tượng.
1. Thêm chữ ký đã tạo vào đối tượng bản trình chiếu.

```javascript
// Mở tệp bản trình chiếu
var pres = new aspose.slides.Presentation();
try {
    // Tạo đối tượng DigitalSignature với tệp PFX và mật khẩu PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Ghi chú cho chữ ký kỹ thuật số mới
    signature.setComments("Aspose.Slides digital signing test.");
    // Thêm chữ ký kỹ thuật số vào bản trình chiếu
    pres.getDigitalSignatures().add(signature);
    // Lưu bản trình chiếu
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Bây giờ có thể kiểm tra xem bản trình chiếu đã được ký kỹ thuật số và chưa bị chỉnh sửa hay không:

```javascript
// Mở bản trình chiếu
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Kiểm tra xem tất cả chữ ký kỹ thuật số có hợp lệ không
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể xóa các chữ ký hiện có khỏi tệp không?**

Có. Bộ sưu tập chữ ký kỹ thuật số hỗ trợ [removing individual items](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) và [clearing it entirely](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); sau khi bạn lưu tệp, bản trình chiếu sẽ không còn chữ ký nào.

**Tệp có trở thành "chỉ đọc" sau khi ký không?**

Không. Một chữ ký bảo vệ tính toàn vẹn và quyền tác giả nhưng không ngăn chỉnh sửa. Để hạn chế việc chỉnh sửa, kết hợp nó với ["Read-only" or a password](/slides/vi/nodejs-java/password-protected-presentation/).

**Chữ ký sẽ hiển thị đúng trong các phiên bản PowerPoint khác nhau không?**

Chữ ký được tạo cho container OOXML (PPTX). Các phiên bản PowerPoint hiện đại hỗ trợ chữ ký OOXML sẽ hiển thị trạng thái của các chữ ký này một cách chính xác.