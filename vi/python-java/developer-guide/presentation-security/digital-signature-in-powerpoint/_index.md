---
title: Thêm Chữ ký Số vào Bản trình bày trong Python
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/python-java/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- cơ quan cấp chứng chỉ
- chứng chỉ PFX
- PKCS#12
- xác thực chữ ký
- PowerPoint
- PPTX
- bảo mật bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình bày PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho Python qua Java để xác thực hoặc xóa chữ ký số."
---
## **Tổng quan**

Chữ ký số giúp người nhận xác định ai đã ký một bản trình bày và liệu nội dung đã ký có bị thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- Một **digital certificate** là một chứng chỉ điện tử liên kết một danh tính với khóa công khai. Một cơ quan cấp chứng chỉ (CA) đáng tin cậy có thể phát hành chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho các quy trình nội bộ.
- Một **digital signature** được tạo ra từ nội dung bản trình bày và khóa riêng của người nắm giữ chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được sử dụng để xác thực chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình bày.
- **Password protection** kiểm soát việc người dùng có thể mở hoặc sửa đổi một bản trình bày hay không. Nó tách biệt với chữ ký số và được mô tả trong [Password-Protected Presentations](/slides/vi/python-java/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** trong mục **File > Info > Protect Presentation**.

![Menu Bảo vệ bản trình bày của PowerPoint với Add a Digital Signature được đánh dấu](add-digital-signature-in-powerpoint.png)

Sau khi mở một bản trình bày đã ký, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo của PowerPoint cho biết bản trình bày chứa chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký thông qua [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getDigitalSignatures), phương thức này trả về một [DigitalSignatureCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/digitalsignaturecollection/) mà các mục là các thể hiện của [DigitalSignature](https://reference.aspose.com/slides/vi/python-java/aspose.slides/digitalsignature/). Một bản trình bày có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Một tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng là thành phần cho phép người nắm giữ tạo chữ ký. Một chứng chỉ không có khóa riêng có thể truy cập không thể được dùng để ký một bản trình bày.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình bày. Không nên cam kết các tệp PFX hoặc mật khẩu của chúng vào hệ thống kiểm soát nguồn. Trong môi trường sản xuất, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình được bảo vệ khác. Các ví dụ dưới đây chỉ dùng biến môi trường để tránh nhúng mật khẩu vào mã.

## **Thêm chữ ký số vào bản trình bày**

Để ký một quy trình bản trình bày thực tế, tải một tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/python-java/aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình bày, và lưu thành tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Lưu kết quả dưới một tên mới sẽ bảo tồn tệp nguồn chưa ký. Giá trị được đặt bằng [DigitalSignature.setComments](https://reference.aspose.com/slides/vi/python-java/aspose.slides/digitalsignature/#setComments) mô tả mục đích của chữ ký; nó không phải là một biện pháp kiểm soát bảo mật.

## **Xác thực chữ ký số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mọi mục trả về bởi [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getDigitalSignatures). Phương thức [DigitalSignature.isValid](https://reference.aspose.com/slides/vi/python-java/aspose.slides/digitalsignature/#isValid) cho biết chữ ký nhúng có hợp lệ cho nội dung bản trình bày hiện tại hay không.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình bày đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Việc loại bỏ mọi chữ ký tạo ra một bản trình bày chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục là chưa đủ: một quy trình nhạy cảm về bảo mật cũng phải xác minh số lượng chữ ký mong đợi và danh tính người ký mong đợi có tồn tại hay không.

Kết quả hợp lệ này không nên được xem như quyết định tin cậy hoàn toàn vào chứng chỉ. Tùy theo chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi của chứng chỉ, xác nhận chủ đề hoặc dấu vân tay mong đợi, kiểm tra mục đích sử dụng khóa, và đánh giá một dấu thời gian đáng tin cậy. Giá trị [DigitalSignature.getSignTime](https://reference.aspose.com/slides/vi/python-java/aspose.slides/digitalsignature/#getSignTime) tự nó không phải bằng chứng từ một cơ quan dấu thời gian đáng tin cậy.

## **Xóa chữ ký số**

Việc xóa chữ ký thay đổi trạng thái bảo mật của bản trình bày. Ví dụ sau tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/digitalsignaturecollection/#clear), và lưu một bản sao chưa ký.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Để xóa chỉ một chữ ký, gọi [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/digitalsignaturecollection/#removeAt) với chỉ số bắt đầu từ 0 của nó. Lưu vào tệp mới trừ khi việc ghi đè lên tệp gốc đã ký là một phần rõ ràng của quy trình làm việc của bạn.

## **Xem xét chỉnh sửa và định dạng**

- Một chữ ký không làm bản trình bày trở thành chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng việc thay đổi nội dung đã ký thường làm cho chữ ký hiện có không còn hợp lệ.
- Hoàn thành mọi chỉnh sửa dự định trước khi ký. Nếu bản trình bày phải được thay đổi, lưu bản trình bày đã chỉnh sửa và ký lại bản revision đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình bày đã ký sang định dạng khác không chuyển chuyển chữ ký PPTX gốc thành một chữ ký hợp lệ cho tệp đã chuyển đổi.
- Xử lý khóa riêng của chứng chỉ như một thông tin nhạy cảm. Bất kỳ ai có được khóa riêng và mật khẩu của nó đều có thể tạo ra chữ ký trông giống như đến từ người nắm giữ chứng chỉ đó.
- Lưu giữ nguồn chưa ký hoặc một bản sao được kiểm soát khác khi chính sách lưu trữ tài liệu của bạn yêu cầu.

## **Câu hỏi thường gặp**

**Chữ ký số có mã hoá bản trình bày không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình bày vẫn có thể đọc được trừ khi có áp dụng mã hoá riêng biệt. Sử dụng [password protection](/slides/vi/python-java/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu của bản trình bày không?**

Không. Mật khẩu PFX mở khóa khóa riêng lưu trong gói chứng chỉ. Nó không kiểm soát ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể sử dụng chứng chỉ tự ký không?**

Kỹ thuậtally, một chứng chỉ tự ký có thể được dùng khi nó bao gồm khóa riêng có thể truy cập. Tuy nhiên, người nhận sẽ không tự động tin cậy nó trừ khi chứng chỉ đó đã được thêm một cách rõ ràng vào môi trường tin cậy của họ. Các quy trình công cộng hoặc liên tổ chức thường sử dụng chứng chỉ được cấp bởi một CA đáng tin cậy.

**Điều gì làm cho một chữ ký không hợp lệ?**

Việc thay đổi nội dung đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký không hợp lệ. Hỏng hóc tệp cũng có thể gây lỗi xác thực. Nếu tất cả chữ ký bị xóa, bản trình bày trở thành chưa ký thay vì chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin cậy người ký không?**

Không tự động. Tính toàn vẹn của chữ ký và độ tin cậy của người ký là hai quyết định riêng biệt. Chính sách xác thực trong môi trường sản xuất nên cũng kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính mong đợi, mục đích sử dụng khóa, và bất kỳ yêu cầu dấu thời gian đáng tin cậy nào.

**Điều gì xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không thay đổi byte của bản trình bày, nhưng nó ảnh hưởng đến việc đánh giá độ tin cậy của chứng chỉ. Việc chữ ký vẫn được chấp nhận hay không phụ thuộc vào chính sách của bạn và việc có dấu thời gian đáng tin cậy chứng minh rằng việc ký đã diễn ra khi chứng chỉ còn hiệu lực. Đừng chỉ dựa vào thời gian ký hiển thị như một dấu thời gian đáng tin cậy.

**Một bản trình bày đã ký vẫn có thể được chỉnh sửa không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện có không còn hợp lệ, vì vậy hãy hoàn thiện bản trình bày trước và ký phiên bản cuối cùng.

**Một bản trình bày có thể chứa hơn một chữ ký không?**

Có. Thêm từng chữ ký vào bộ sưu tập trả về bởi [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getDigitalSignatures) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả người ký cần thiết đều có mặt.

**Các định dạng bản trình bày nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký số mô tả ở đây cho định dạng PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng đến các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập rồi lưu bản trình bày. Nội dung slide vẫn còn, nhưng tệp đã lưu sẽ không còn chứa bằng chứng chữ ký đã bị xóa.