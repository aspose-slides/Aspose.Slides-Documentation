---
title: Thêm Chữ ký Kỹ thuật số vào Bản trình bày với Python
linktitle: Chữ ký Kỹ thuật số
type: docs
weight: 10
url: /vi/python-net/digital-signature-in-powerpoint/
keywords:
- chữ ký kỹ thuật số
- chứng chỉ kỹ thuật số
- cơ quan cấp chứng chỉ
- chứng chỉ PFX
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách ký kỹ thuật số cho các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET. Bảo mật các slide của bạn trong vài giây với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

**Chứng chỉ kỹ thuật số** được sử dụng để tạo một bản trình bày PowerPoint được bảo vệ bằng mật khẩu, đánh dấu là được tạo bởi một tổ chức hoặc cá nhân cụ thể. Chứng chỉ kỹ thuật số có thể được lấy bằng cách liên hệ với một tổ chức được ủy quyền – một cơ quan cấp chứng chỉ. Sau khi cài đặt chứng chỉ kỹ thuật số vào hệ thống, nó có thể được sử dụng để thêm chữ ký kỹ thuật số vào bản trình bày thông qua File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Bản trình bày có thể chứa nhiều chữ ký kỹ thuật số. Sau khi chữ ký kỹ thuật số được thêm vào bản trình bày, một thông báo đặc biệt sẽ xuất hiện trong PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Để ký bản trình bày hoặc kiểm tra tính xác thực của các chữ ký trên bản trình bày, **Aspose.Slides API** cung cấp lớp [**DigitalSignature**](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/) , lớp [**DigitalSignatureCollection**](https://reference.aspose.com/slides/vi/python-net/aspose.slides/DigitalSignatureCollection/) và thuộc tính [**Presentation.digital_signatures**](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/digital_signatures/) . Hiện tại, chữ ký kỹ thuật số chỉ được hỗ trợ cho định dạng PPTX.

## **Thêm Chữ ký Kỹ thuật số từ Chứng chỉ PFX**

Mẫu mã dưới đây trình bày cách thêm chữ ký kỹ thuật số từ một chứng chỉ PFX:

1. Mở tệp PFX và truyền mật khẩu PFX cho đối tượng [**DigitalSignature**](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/) .
1. Thêm chữ ký đã tạo vào đối tượng bản trình bày.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Tạo đối tượng DigitalSignature với tệp PFX và mật khẩu PFX
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Ghi chú chữ ký kỹ thuật số mới
    signature.comments = "Aspose.Slides digital signing test."

    # Thêm chữ ký kỹ thuật số vào bản trình bày
    pres.digital_signatures.add(signature)

    # Lưu bản trình bày
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Bây giờ có thể kiểm tra xem bản trình bày đã được ký kỹ thuật số và chưa bị sửa đổi hay không:

```py
# Mở bản trình bày
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Kiểm tra xem tất cả chữ ký kỹ thuật số có hợp lệ không
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **Câu hỏi thường gặp**

**Tôi có thể xóa các chữ ký hiện có khỏi tệp không?**

Có. Bộ sưu tập chữ ký kỹ thuật số hỗ trợ [removing individual items](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignaturecollection/remove_at/) và [clearing it entirely](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignaturecollection/clear/) ; sau khi bạn lưu tệp, bản trình bày sẽ không còn chữ ký nào.

**Tệp có trở thành "chỉ đọc" sau khi ký không?**

Không. Một chữ ký bảo vệ tính toàn vẹn và quyền tác giả nhưng không ngăn chỉnh sửa. Để hạn chế chỉnh sửa, kết hợp nó với ["Read-only" or a password](/slides/vi/python-net/password-protected-presentation/).

**Chữ ký sẽ hiển thị đúng trong các phiên bản PowerPoint khác nhau không?**

Chữ ký được tạo cho container OOXML (PPTX). Các phiên bản PowerPoint hiện đại hỗ trợ chữ ký OOXML sẽ hiển thị trạng thái của các chữ ký này một cách chính xác.