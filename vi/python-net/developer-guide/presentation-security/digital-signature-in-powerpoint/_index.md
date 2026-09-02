---
title: Thêm Chữ ký số vào Bản trình chiếu trong Python
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/python-net/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- cơ quan chứng chỉ
- chứng chỉ PFX
- PKCS#12
- xác thực chữ ký
- PowerPoint
- PPTX
- bảo mật bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình chiếu PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho Python qua .NET để xác thực hoặc xóa chữ ký số."
---
## **Tổng quan**

Chữ ký số giúp người nhận xác định ai đã ký một bản trình chiếu và liệu nội dung đã ký có thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- A **digital certificate** là chứng chỉ điện tử liên kết một danh tính với khóa công khai. Một cơ quan chứng chỉ (CA) đáng tin cậy có thể cấp chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho các quy trình nội bộ.
- A **digital signature** được tạo từ nội dung bản trình chiếu và khóa riêng của người giữ chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được dùng để xác minh chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình chiếu.
- **Password protection** kiểm soát người dùng có thể mở hoặc chỉnh sửa bản trình chiếu hay không. Nó riêng biệt với việc ký số và được mô tả trong [Password-Protected Presentations](/slides/vi/python-net/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** trong **File > Info > Protect Presentation**.

![Menu Bảo vệ bản trình chiếu của PowerPoint với Add a Digital Signature được đánh dấu](add-digital-signature-in-powerpoint.png)

Sau khi mở một bản trình chiếu đã ký, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo PowerPoint cho biết bản trình chiếu chứa các chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký thông qua [Presentation.digital_signatures](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/digital_signatures/), một [DigitalSignatureCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignaturecollection/) trong đó các mục là các đối tượng [DigitalSignature](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/). Một bản trình chiếu có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Một tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng là thứ cho phép người giữ tạo chữ ký. Một chứng chỉ không có khóa riêng có thể truy cập không thể được sử dụng để ký một bản trình chiếu.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình chiếu. Không đưa các tệp PFX hoặc mật khẩu của chúng lên hệ thống kiểm soát phiên bản. Trong môi trường sản xuất, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình được bảo vệ khác. Các ví dụ dưới đây chỉ dùng biến môi trường để tránh nhúng mật khẩu trong mã.

## **Thêm Chữ ký Số vào Bản trình chiếu**

Để ký một quy trình làm việc thực tế, tải một tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình chiếu, và lưu thành tệp PPTX.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Lưu kết quả dưới tên mới giúp bảo tồn tệp nguồn chưa ký. Giá trị [DigitalSignature.comments](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/comments/) mô tả mục đích của chữ ký; nó không phải là một kiểm soát bảo mật.

## **Xác thực Chữ ký Số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mọi mục trong [Presentation.digital_signatures](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/digital_signatures/). Thuộc tính [DigitalSignature.is_valid](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/is_valid/) cho biết chữ ký nhúng có hợp lệ cho nội dung hiện tại của bản trình chiếu hay không.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Kết quả không hợp lệ thường có nghĩa là nội dung đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Việc loại bỏ mọi chữ ký tạo ra một bản trình chiếu chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục là không đủ: một quy trình nhạy cảm với bảo mật còn phải xác minh số lượng chữ ký mong đợi và danh tính những người ký mong đợi có tồn tại.

Thuộc tính [DigitalSignature.certificate](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/certificate/) cung cấp dữ liệu chứng chỉ dưới dạng mảng byte. Ví dụ tính toán dấu vân tay SHA-256 của nó để ứng dụng có thể so sánh với dấu vân tay của chứng chỉ người ký mong đợi.

Kết quả tính hợp lệ này không nên được coi là quyết định tin cậy hoàn toàn đối với chứng chỉ. Tùy vào chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi, xác nhận chủ thể hoặc dấu vân tay mong đợi, kiểm tra mục đích sử dụng khóa, và đánh giá dấu thời gian đáng tin cậy. Giá trị [DigitalSignature.sign_time](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/sign_time/) tự nó không phải là bằng chứng từ cơ quan thời gian đáng tin cậy.

## **Xóa Chữ ký Số**

Việc xóa chữ ký thay đổi trạng thái bảo mật của bản trình chiếu. Ví dụ sau tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignaturecollection/clear/), và lưu một bản sao chưa ký.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Để xóa chỉ một chữ ký, gọi [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignaturecollection/remove_at/) với chỉ số bắt đầu từ 0 của nó. Lưu vào tệp mới trừ khi việc ghi đè bản gốc đã ký là một phần rõ ràng của quy trình làm việc của bạn.

## **Xem xét về chỉnh sửa và định dạng**

- Một chữ ký không làm cho bản trình chiếu chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng việc thay đổi nội dung đã ký thường làm cho chữ ký hiện có trở nên không hợp lệ.
- Hoàn thành tất cả các chỉnh sửa dự định trước khi ký. Nếu cần thay đổi bản trình chiếu, lưu bản trình chiếu đã chỉnh sửa và ký lại phiên bản đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình chiếu đã ký sang định dạng khác không chuyển dấu chữ ký PPTX gốc thành chữ ký hợp lệ cho tệp đã chuyển đổi.
- Đối xử với khóa riêng của chứng chỉ như thông tin nhạy cảm. Bất kỳ ai có được khóa riêng và mật khẩu của nó có thể tạo ra chữ ký trông như xuất phát từ người giữ chứng chỉ đó.
- Lưu trữ nguồn chưa ký hoặc một bản sao được kiểm soát khác khi chính sách lưu trữ tài liệu của bạn yêu cầu.

## **Câu hỏi thường gặp**

**Chữ ký số có mã hoá bản trình chiếu không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình chiếu vẫn có thể đọc được trừ khi có áp dụng mã hoá riêng biệt. Sử dụng [password protection](/slides/vi/python-net/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu bản trình chiếu không?**

Không. Mật khẩu PFX mở khóa khóa riêng được lưu trong gói chứng chỉ. Nó không kiểm soát ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể dùng chứng chỉ tự ký không?**

Kỹ thuật적으로, một chứng chỉ tự ký có thể được dùng khi nó bao gồm khóa riêng có thể truy cập. Tuy nhiên, người nhận sẽ không tự động tin tưởng nó trừ khi chứng chỉ đã được thêm một cách rõ ràng vào môi trường tin cậy của họ. Các quy trình công cộng hoặc xuyên tổ chức thường sử dụng chứng chỉ do CA đáng tin cậy cấp.

**Điều gì làm cho một chữ ký không hợp lệ?**

Thay đổi nội dung đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký không hợp lệ. Hỏng hóc tệp cũng có thể gây thất bại khi xác thực. Nếu tất cả chữ ký bị loại bỏ, bản trình chiếu sẽ trở thành chưa ký thay vì chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin người ký không?**

Không tự động. Tính toàn vẹn của chữ ký và mức độ tin cậy vào người ký là các quyết định riêng biệt. Chính sách xác thực trong môi trường sản xuất nên còn kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính mong đợi, mục đích sử dụng khóa và bất kỳ yêu cầu dấu thời gian đáng tin cậy nào.

**Điều gì xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không thay đổi byte của bản trình chiếu, nhưng ảnh hưởng đến việc đánh giá tin cậy của chứng chỉ. Chữ ký có còn được chấp nhận hay không phụ thuộc vào chính sách của bạn và liệu có dấu thời gian đáng tin cậy chứng minh việc ký đã diễn ra khi chứng chỉ còn hiệu lực hay không. Đừng chỉ dựa vào thời gian ký hiển thị như một dấu thời gian đáng tin cậy.

**Bản trình chiếu đã ký vẫn có thể được chỉnh sửa không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện có không hợp lệ, vì vậy nên hoàn thành bản trình chiếu rồi mới ký phiên bản cuối cùng.

**Một bản trình chiếu có thể chứa nhiều hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào [Presentation.digital_signatures](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/digital_signatures/) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả người ký cần thiết đều có mặt.

**Các định dạng bản trình chiếu nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký số mô tả ở đây cho định dạng PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng đến các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập rồi lưu bản trình chiếu. Nội dung slide vẫn tồn tại, nhưng tệp đã lưu sẽ không còn chứa bằng chứng chữ ký đã bị xóa.