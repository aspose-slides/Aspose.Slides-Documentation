---
title: Thêm Chữ ký số vào Bản trình bày trong Python
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/python-net/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- cơ quan chứng nhận
- chứng chỉ PFX
- PKCS#12
- xác thực chữ ký
- PowerPoint
- PPTX
- bảo mật bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình bày PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho Python thông qua .NET để xác thực hoặc xóa chữ ký số."
---
## **Tổng quan**

Chữ ký số giúp người nhận xác định ai đã ký một bản trình bày và nội dung đã ký có bị thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- Một **digital certificate** là một chứng chỉ điện tử liên kết danh tính với khóa công khai. Một cơ quan chứng nhận (CA) đáng tin có thể phát hành chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho các quy trình nội bộ.
- Một **digital signature** được tạo từ nội dung bản trình bày và khóa riêng của người giữ chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được dùng để xác minh chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình bày.
- **Password protection** kiểm soát việc người dùng có thể mở hoặc sửa đổi bản trình bày hay không. Nó riêng biệt với việc ký số và được mô tả trong [Bảo mật bằng mật khẩu](/python-net/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** trong **File > Info > Protect Presentation**.

![Menu Bảo vệ bản trình bày PowerPoint với Thêm chữ ký số được tô sáng](add-digital-signature-in-powerpoint.png)

Sau khi mở một bản trình bày đã ký, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo PowerPoint cho biết bản trình bày chứa chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký thông qua [Presentation.digital_signatures](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/digital_signatures/), một [DigitalSignatureCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignaturecollection/) mà các mục là các đối tượng [DigitalSignature](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/). Một bản trình bày có thể chứa nhiều chữ ký.

## **Hiểu về chứng chỉ PFX và mật khẩu**

Tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng cho phép người giữ tạo chữ ký. Một chứng chỉ không có khóa riêng có thể truy cập được sẽ không thể dùng để ký bản trình bày.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình bày. Không nên đưa tệp PFX hoặc mật khẩu của chúng lên hệ thống kiểm soát phiên bản. Trong môi trường sản xuất, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình bảo vệ khác. Các ví dụ dưới đây chỉ dùng biến môi trường để tránh nhúng mật khẩu vào mã nguồn.

## **Thêm chữ ký số vào bản trình bày**

Để ký một quy trình thực tế, tải tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình bày, và lưu thành tệp PPTX.

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

Lưu kết quả dưới tên mới sẽ bảo tồn tệp nguồn chưa ký. Giá trị [DigitalSignature.comments](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/comments/) mô tả mục đích của chữ ký; nó không phải là một kiểm soát bảo mật.

## **Xác thực chữ ký số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mọi mục trong [Presentation.digital_signatures](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/digital_signatures/). Thuộc tính [DigitalSignature.is_valid](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/is_valid/) cho biết chữ ký nhúng có hợp lệ với nội dung bản trình bày hiện tại hay không.

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

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình bày đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Xóa mọi chữ ký sẽ tạo ra một bản trình bày chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục là chưa đủ: một quy trình nhạy cảm về bảo mật cũng phải xác minh số lượng chữ ký mong muốn và danh tính người ký dự kiến.

Thuộc tính [DigitalSignature.certificate](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/certificate/) cung cấp dữ liệu chứng chỉ dưới dạng mảng byte. Ví dụ tính toán dấu vân tay SHA‑256 của nó để ứng dụng có thể so sánh với dấu vân tay của chứng chỉ người ký dự kiến.

Kết quả này không nên được coi là quyết định tin cậy hoàn toàn đối với chứng chỉ. Tùy thuộc vào chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi, xác nhận chủ thể hoặc dấu vân tay mong muốn, kiểm tra mục đích sử dụng khóa, và đánh giá dấu thời gian đáng tin cậy. Giá trị [DigitalSignature.sign_time](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignature/sign_time/) một mình không phải là bằng chứng từ một cơ quan thời gian đáng tin cậy.

## **Xóa chữ ký số**

Việc xóa chữ ký thay đổi trạng thái bảo mật của bản trình bày. Ví dụ dưới đây tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignaturecollection/clear/), và lưu một bản sao chưa ký.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Để xóa chỉ một chữ ký, gọi [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/vi/python-net/aspose.slides/digitalsignaturecollection/remove_at/) với chỉ mục bắt đầu từ 0. Lưu thành tệp mới trừ khi việc ghi đè lên tệp đã ký là một phần rõ ràng của quy trình của bạn.

## **Lưu ý khi chỉnh sửa và định dạng**

- Một chữ ký không làm cho bản trình bày chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng các thay đổi đối với nội dung đã ký thường làm cho chữ ký hiện tại mất hiệu lực.
- Hoàn tất mọi chỉnh sửa dự định trước khi ký. Nếu cần thay đổi bản trình bày, lưu phiên bản đã chỉnh sửa và ký lại phiên bản đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình bày đã ký sang định dạng khác sẽ không truyền chữ ký PPTX gốc thành chữ ký hợp lệ cho tệp đã chuyển đổi.
- Xử lý khóa riêng của chứng chỉ như thông tin nhạy cảm. Bất kỳ ai có được khóa riêng và mật khẩu của nó đều có thể tạo chữ ký trông giống như đến từ người giữ chứng chỉ.
- Lưu trữ bản nguồn chưa ký hoặc một bản sao được kiểm soát khi chính sách lưu trữ tài liệu yêu cầu.

## **Câu hỏi thường gặp**

**Chữ ký số có mã hoá bản trình bày không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình bày vẫn có thể đọc được trừ khi có áp dụng mã hoá riêng. Sử dụng [bảo mật bằng mật khẩu](/python-net/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu bản trình bày không?**

Không. Mật khẩu PFX mở khóa khóa riêng được lưu trong gói chứng chỉ. Nó không kiểm soát việc ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể dùng chứng chỉ tự ký không?**

Kỹ thuật-wise, chứng chỉ tự ký có thể dùng được nếu nó bao gồm khóa riêng có thể truy cập. Người nhận sẽ không tự động tin tưởng nó, trừ khi chứng chỉ đã được thêm một cách rõ ràng vào môi trường tin cậy của họ. Các quy trình công cộng hoặc liên tổ chức thường sử dụng chứng chỉ do CA đáng tin cậy phát hành.

**Điều gì làm cho một chữ ký trở nên không hợp lệ?**

Thay đổi nội dung bản trình bày đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký mất hiệu lực. Hỏng hóc tệp cũng có thể gây lỗi xác thực. Nếu tất cả chữ ký được xóa, bản trình bày trở thành chưa ký thay vì chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin người ký không?**

Không tự động. Tính toàn vẹn của chữ ký và độ tin cậy của người ký là hai quyết định riêng biệt. Chính sách xác thực sản xuất nên cũng kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính dự kiến, mục đích sử dụng khóa, và bất kỳ yêu cầu dấu thời gian đáng tin cậy nào.

**Điều gì xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không thay đổi các byte của bản trình bày, nhưng ảnh hưởng đến việc đánh giá tin cậy của chứng chỉ. Việc chữ ký còn chấp nhận được hay không phụ thuộc vào chính sách của bạn và liệu có dấu thời gian đáng tin cậy chứng minh việc ký đã diễn ra khi chứng chỉ còn hiệu lực hay không. Đừng chỉ dựa vào thời gian ký hiển thị như một dấu thời gian đáng tin cậy.

**Bản trình bày đã ký vẫn có thể chỉnh sửa được không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện tại mất hiệu lực, vì vậy hãy hoàn thiện bản trình bày rồi mới ký phiên bản cuối cùng.

**Một bản trình bày có thể chứa nhiều hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào [Presentation.digital_signatures](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/digital_signatures/) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả các người ký cần thiết đều có mặt.

**Các định dạng bản trình bày nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký số mô tả ở đây cho định dạng PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa chữ ký mà không ảnh hưởng đến các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập, sau đó lưu bản trình bày. Nội dung slide vẫn còn, nhưng tệp đã lưu sẽ không còn chứa bằng chứng chữ ký đã bị xóa.