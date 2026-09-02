---
title: Thêm Chữ ký số vào Bản trình chiếu trong JavaScript
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/nodejs-java/digital-signature-in-powerpoint/
keywords:
- chữ ký số
- chứng chỉ số
- cơ quan cấp chứng chỉ
- chứng chỉ PFX
- PKCS#12
- xác thực chữ ký
- PowerPoint
- PPTX
- bảo mật bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình chiếu PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho Node.js qua Java để xác thực hoặc xóa chữ ký số."
---
## **Tổng quan**

Chữ ký số giúp người nhận xác định ai đã ký bản trình chiếu và nội dung đã ký có bị thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- **Chứng chỉ số** là một chứng chỉ điện tử liên kết danh tính với khóa công khai. Một cơ quan cấp chứng chỉ (CA) đáng tin cậy có thể phát hành chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho các quy trình nội bộ.
- **Chữ ký số** được tạo từ nội dung bản trình chiếu và khóa riêng của người nắm giữ chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được dùng để xác thực chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình chiếu.
- **Bảo vệ bằng mật khẩu** kiểm soát việc người dùng có thể mở hoặc chỉnh sửa bản trình chiếu hay không. Nó riêng biệt với chữ ký số và được mô tả trong [Password-Protected Presentations](/slides/vi/nodejs-java/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** dưới **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Sau khi mở một bản trình chiếu đã ký, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký qua [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), trả về một [DigitalSignatureCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignaturecollection/) chứa các đối tượng [DigitalSignature](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignature/). Một bản trình chiếu có thể chứa nhiều chữ ký.

## **Hiểu về chứng chỉ PFX và mật khẩu**

Tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng cho phép người nắm giữ tạo chữ ký. Một chứng chỉ không có khóa riêng có thể truy cập sẽ không thể dùng để ký một bản trình chiếu.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình chiếu. Không đưa các tệp PFX hoặc mật khẩu của chúng lên hệ thống kiểm soát phiên bản. Trong môi trường sản xuất, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình bảo vệ khác. Các ví dụ dưới đây chỉ dùng biến môi trường để tránh nhúng mật khẩu trong mã.

## **Thêm chữ ký số vào bản trình chiếu**

Để ký một quy trình làm việc thực tế, tải tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình chiếu, và lưu lại thành tệp PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lưu kết quả dưới một tên mới để bảo tồn tệp nguồn chưa ký. Giá trị được đặt bằng [DigitalSignature.setComments](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignature/) mô tả mục đích của chữ ký; nó không phải là một biện pháp kiểm soát bảo mật.

## **Xác thực chữ ký số**

Khi tải một tệp PPTX đã ký, kiểm tra mọi mục trả về bởi [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). Phương thức [DigitalSignature.isValid](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignature/) cho biết chữ ký nhúng có hợp lệ với nội dung hiện tại của bản trình chiếu hay không.

Ví dụ dưới đây cũng sử dụng lớp `X509Certificate` của Node.js để đọc tên chủ đề từ mỗi chứng chỉ nhúng.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình chiếu đã ký hoặc dữ liệu chữ ký đã bị thay đổi sau khi ký, hoặc tệp bị hỏng. Việc loại bỏ mọi chữ ký tạo ra một bản trình chiếu chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục không đủ: một quy trình làm việc nhạy cảm với bảo mật cũng phải xác minh số lượng chữ ký mong đợi và danh tính người ký mong muốn có mặt.

Kết quả này không nên được xem như quyết định tin cậy hoàn toàn đối với chứng chỉ. Tùy theo chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi, xác nhận chủ đề hoặc dấu vân tay mong muốn, kiểm tra mục đích sử dụng khóa và đánh giá dấu thời gian đáng tin cậy. Giá trị [DigitalSignature.getSignTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignature/) tự nó không phải là bằng chứng từ một tổ chức cung cấp dấu thời gian đáng tin cậy.

## **Xóa chữ ký số**

Việc xóa chữ ký thay đổi trạng thái bảo mật của bản trình chiếu. Ví dụ dưới đây tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), và lưu một bản sao chưa ký.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để xóa chỉ một chữ ký, gọi [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) với chỉ mục bắt đầu từ 0. Lưu thành tệp mới trừ khi việc ghi đè lên bản gốc đã ký là một phần rõ ràng trong quy trình của bạn.

## **Xem xét chỉnh sửa và định dạng**

- Một chữ ký không biến bản trình chiếu thành chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng các thay đổi đối với nội dung đã ký thường làm mất hiệu lực chữ ký hiện có.
- Hoàn thành mọi chỉnh sửa dự kiến trước khi ký. Nếu cần thay đổi bản trình chiếu, lưu bản đã sửa và ký lại bản sửa đổi đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình chiếu đã ký sang định dạng khác sẽ không chuyển chữ ký PPTX gốc thành chữ ký hợp lệ cho tệp đã chuyển đổi.
- Xử lý khóa riêng của chứng chỉ như một thông tin nhạy cảm. Bất kỳ ai có được khóa riêng và mật khẩu của nó có thể tạo ra các chữ ký trông giống như đến từ người nắm giữ chứng chỉ.
- Bảo quản bản nguồn chưa ký hoặc một bản sao được kiểm soát khi chính sách lưu trữ tài liệu của bạn yêu cầu điều đó.

## **Câu hỏi thường gặp**

**Chữ ký số có mã hoá bản trình chiếu không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình chiếu vẫn có thể đọc được trừ khi có áp dụng mã hoá riêng. Sử dụng [password protection](/slides/vi/nodejs-java/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu bản trình chiếu không?**

Không. Mật khẩu PFX mở khóa khóa riêng được lưu trong gói chứng chỉ. Nó không kiểm soát ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể dùng chứng chỉ tự ký không?**

Về mặt kỹ thuật, chứng chỉ tự ký có thể được dùng nếu nó bao gồm khóa riêng có thể truy cập. Tuy nhiên, người nhận sẽ không tự động tin cậy nó trừ khi chứng chỉ đã được thêm một cách rõ ràng vào môi trường tin cậy của họ. Các quy trình công cộng hoặc xuyên tổ chức thường sử dụng chứng chỉ do CA đáng tin cậy phát hành.

**Điều gì làm cho chữ ký trở nên không hợp lệ?**

Thay đổi nội dung bản trình chiếu đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm mất hiệu lực chữ ký. Hỏng hóc tệp cũng có thể gây thất bại trong việc xác thực. Nếu tất cả chữ ký bị xóa, bản trình chiếu sẽ không có chữ ký thay vì chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin tưởng người ký không?**

Không tự động. Tính toàn vẹn của chữ ký và độ tin cậy của người ký là hai quyết định riêng biệt. Chính sách xác thực trong môi trường sản xuất nên kiểm tra thêm chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính mong muốn, mục đích sử dụng khóa và bất kỳ yêu cầu dấu thời gian đáng tin cậy nào.

**Điều gì xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không thay đổi byte của bản trình chiếu, nhưng nó ảnh hưởng đến việc đánh giá độ tin cậy của chứng chỉ. Việc chữ ký còn được chấp nhận hay không phụ thuộc vào chính sách của bạn và liệu có dấu thời gian đáng tin cậy chứng minh rằng việc ký đã diễn ra khi chứng chỉ còn hiệu lực hay không. Đừng chỉ dựa vào thời gian ký được hiển thị như một dấu thời gian đáng tin cậy.

**Bản trình chiếu đã ký vẫn có thể được chỉnh sửa không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm mất hiệu lực chữ ký hiện có, vì vậy hãy hoàn thiện bản trình chiếu trước và ký lại phiên bản cuối cùng.

**Một bản trình chiếu có thể chứa hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào bộ sưu tập trả về bởi [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) trước khi lưu. Khi xác thực, kiểm tra mỗi chữ ký và xác nhận rằng tất cả người ký bắt buộc đều có mặt.

**Các định dạng bản trình chiếu nào hỗ trợ các thao tác này?**

Aspose.Slides hỗ trợ các thao tác chữ ký số mô tả ở đây chỉ cho PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng đến các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập, sau đó lưu lại bản trình chiếu. Nội dung slide vẫn còn, nhưng tệp đã lưu sẽ không còn mang chứng cứ của chữ ký đã bị xóa.