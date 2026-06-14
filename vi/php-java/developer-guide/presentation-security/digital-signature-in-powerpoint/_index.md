---
title: Thêm Chữ ký Số vào Bản trình chiếu trong PHP
linktitle: Chữ ký Số
type: docs
weight: 10
url: /vi/php-java/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- nhà cấp chứng chỉ
- chứng chỉ PFX
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách ký số các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho PHP thông qua Java. Bảo vệ slide của bạn trong vài giây với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

**Digital certificate** được sử dụng để tạo một bản trình chiếu PowerPoint có bảo vệ bằng mật khẩu, được đánh dấu là được tạo bởi một tổ chức hoặc cá nhân cụ thể. Digital certificate có thể được lấy bằng cách liên hệ với một tổ chức được ủy quyền - một nhà cấp chứng chỉ. Sau khi cài đặt digital certificate vào hệ thống, nó có thể được dùng để thêm chữ ký số vào bản trình chiếu qua File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Bản trình chiếu có thể chứa nhiều hơn một chữ ký số. Sau khi chữ ký số được thêm vào bản trình chiếu, một thông báo đặc biệt sẽ xuất hiện trong PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Để ký bản trình chiếu hoặc kiểm tra tính xác thực của các chữ ký trong bản trình chiếu, **Aspose.Slides API** cung cấp lớp [**DigitalSignature**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/DigitalSignature) , lớp [**DigitalSignatureCollection**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/DigitalSignatureCollection) và phương thức [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getDigitalSignatures) . Hiện tại, chữ ký số chỉ được hỗ trợ cho định dạng PPTX.

## **Thêm Chữ ký Số từ Chứng chỉ PFX**

Mẫu mã dưới đây minh họa cách thêm chữ ký số từ một chứng chỉ PFX:

1. Mở tệp PFX và truyền mật khẩu PFX cho đối tượng [**DigitalSignature**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/DigitalSignature) .
1. Thêm chữ ký đã tạo vào đối tượng bản trình chiếu.

```php
  # Mở tệp bản trình chiếu
  $pres = new Presentation();
  try {
    # Tạo đối tượng DigitalSignature với tệp PFX và mật khẩu PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Thêm chú thích cho chữ ký số mới
    $signature->setComments("Aspose.Slides digital signing test.");
    # Thêm chữ ký số vào bản trình chiếu
    $pres->getDigitalSignatures()->add($signature);
    # Lưu bản trình chiếu
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Bây giờ có thể kiểm tra xem bản trình chiếu đã được ký số và không bị chỉnh sửa hay chưa:

```php
  # Mở bản trình chiếu
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Kiểm tra xem tất cả chữ ký số có hợp lệ không
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể xóa các chữ ký hiện có khỏi tệp không?**

Đúng. Bộ sưu tập chữ ký số hỗ trợ [removing individual items](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignaturecollection/removeat/) và [clearing it entirely](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignaturecollection/clear/) ; sau khi bạn lưu tệp, bản trình chiếu sẽ không còn chữ ký nào.

**Tệp có trở thành "read-only" sau khi ký không?**

Không. Chữ ký bảo vệ tính toàn vẹn và quyền tác giả nhưng không ngăn chặn việc chỉnh sửa. Để hạn chế chỉnh sửa, kết hợp nó với ["Read-only" or a password](/slides/vi/php-java/password-protected-presentation/).

**Chữ ký sẽ hiển thị đúng trong các phiên bản PowerPoint khác nhau không?**

Chữ ký được tạo cho container OOXML (PPTX). Các phiên bản PowerPoint hiện đại hỗ trợ chữ ký OOXML sẽ hiển thị trạng thái của các chữ ký này một cách chính xác.