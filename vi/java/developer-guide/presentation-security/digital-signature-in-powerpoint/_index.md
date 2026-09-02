---
title: Thêm Chữ ký Số vào Bản Trình bày trong Java
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Tìm hiểu cách ký các bản PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho Java để xác thực hoặc xóa chữ ký số."
---
## **Tổng quan**

Chữ ký số giúp người nhận xác định ai đã ký một bản trình bày và liệu nội dung đã ký có bị thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- **Chứng chỉ số** là một giấy chứng nhận điện tử liên kết danh tính với khóa công khai. Một cơ quan cấp chứng chỉ (CA) đáng tin cậy có thể phát hành chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho quy trình nội bộ.
- **Chữ ký số** được tạo từ nội dung bản trình bày và khóa riêng của người sở hữu chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được sử dụng để xác minh chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình bày.
- **Bảo vệ bằng mật khẩu** kiểm soát việc người dùng có thể mở hoặc chỉnh sửa một bản trình bày hay không. Nó tách biệt khỏi việc ký số và được mô tả trong [Bảo vệ bản trình bày bằng mật khẩu](/java/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** dưới **File > Info > Protect Presentation**.

![Menu Bảo vệ bản trình bày của PowerPoint với tùy chọn Thêm Chữ ký Số được làm nổi bật](add-digital-signature-in-powerpoint.png)

Sau khi mở một bản trình bày đã ký, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo của PowerPoint cho biết bản trình bày chứa các chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký thông qua [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), trả về một [IDigitalSignatureCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idigitalsignaturecollection/) , các mục của nó thực thi [IDigitalSignature](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idigitalsignature/). Một bản trình bày có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng là yếu tố cho phép người sở hữu tạo chữ ký. Một chứng chỉ không có khóa riêng khả dụng không thể được dùng để ký một bản trình bày.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình bày. Không nên cam kết các tệp PFX hoặc mật khẩu của chúng vào hệ thống kiểm soát mã nguồn. Trong môi trường thực tế, hạn chế truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình được bảo vệ khác. Các ví dụ bên dưới chỉ sử dụng biến môi trường để tránh nhúng mật khẩu trong mã.

## **Thêm Chữ ký Số vào Bản Trình Bày**

Để ký một quy trình trình bày thực tế, tải một tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/java/com.aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình bày, và lưu thành tệp PPTX.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lưu kết quả dưới một tên mới sẽ giữ nguyên tệp nguồn chưa ký. Giá trị được đặt bằng [IDigitalSignature.setComments](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) mô tả mục đích của chữ ký; nó không phải là một biện pháp bảo mật.

## **Xác Thực Chữ ký Số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mỗi mục trả về bởi [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Phương thức [IDigitalSignature.isValid](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idigitalsignature/#isValid--) cho biết chữ ký nhúng có hợp lệ với nội dung bản trình bày hiện tại hay không.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình bày đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Việc xóa mọi chữ ký tạo ra một bản trình bày chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục là không đủ: một quy trình nhạy cảm với bảo mật cũng phải xác minh rằng số lượng chữ ký mong đợi và danh tính người ký mong đợi đều có mặt.

Kết quả hợp lệ này không nên được coi là quyết định tin cậy chứng chỉ hoàn chỉnh. Tùy theo chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi của chứng chỉ, xác nhận chủ đề hoặc dấu vân tay mong đợi, kiểm tra việc sử dụng khóa, và đánh giá dấu thời gian đáng tin cậy. Giá trị [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idigitalsignature/#getSignTime--) tự nó không phải là bằng chứng từ một cơ quan dấu thời gian đáng tin cậy.

## **Xóa Chữ ký Số**

Xóa chữ ký làm thay đổi trạng thái bảo mật của bản trình bày. Ví dụ sau tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idigitalsignaturecollection/#clear--) , và lưu một bản sao chưa ký.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để xóa chỉ một chữ ký, gọi [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) với chỉ số bắt đầu từ 0 của nó. Lưu thành tệp mới trừ khi việc ghi đè bản gốc đã ký là một phần rõ ràng của quy trình của bạn.

## **Cân nhắc về Chỉnh sửa và Định dạng**

- Chữ ký không làm cho bản trình bày chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng việc thay đổi nội dung đã ký thường làm cho chữ ký hiện có không còn hiệu lực.
- Hoàn thành tất cả các chỉnh sửa dự định trước khi ký. Nếu bản trình bày cần được thay đổi, lưu bản trình bày đã sửa và ký lại phiên bản đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình bày đã ký sang định dạng khác không chuyển chữ ký PPTX gốc thành chữ ký hợp lệ cho tệp đã chuyển đổi.
- Coi khóa riêng của chứng chỉ là thông tin nhạy cảm. Bất kỳ ai sở hữu khóa riêng và mật khẩu của nó có thể tạo chữ ký trông như đến từ người sở hữu chứng chỉ đó.
- Giữ lại nguồn chưa ký hoặc một bản sao kiểm soát khác khi chính sách lưu trữ tài liệu của bạn yêu cầu.

## **Câu hỏi thường gặp**

**Chữ ký số có mã hoá bản trình bày không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình bày vẫn có thể đọc được trừ khi có áp dụng mã hoá riêng. Sử dụng [bảo vệ bằng mật khẩu](/java/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống với mật khẩu bản trình bày không?**

Không. Mật khẩu PFX mở khóa khóa riêng được lưu trong gói chứng chỉ. Nó không kiểm soát ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể sử dụng chứng chỉ tự ký không?**

Về mặt kỹ thuật, một chứng chỉ tự ký có thể được sử dụng khi nó bao gồm một khóa riêng có thể truy cập. Tuy nhiên, người nhận sẽ không tự động tin tưởng nó, trừ khi chứng chỉ đó đã được thêm một cách rõ ràng vào môi trường tin cậy của họ. Các quy trình công cộng hoặc xuyên tổ chức thường sử dụng chứng chỉ được cấp bởi một CA đáng tin cậy.

**Điều gì làm cho một chữ ký không hợp lệ?**

Việc thay đổi nội dung bản trình bày đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký không hợp lệ. Hỏng hóc tệp cũng có thể khiến việc xác thực thất bại. Nếu tất cả chữ ký bị xóa, bản trình bày sẽ không có chữ ký chứ không phải là một tệp chứa chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin tưởng người ký không?**

Không tự động. Tính toàn vẹn của chữ ký và sự tin tưởng vào người ký là các quyết định riêng biệt. Chính sách xác thực trong môi trường thực tế cũng nên kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính mong đợi, việc sử dụng khóa và bất kỳ yêu cầu dấu thời gian đáng tin cậy nào.

**Đi gì xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không thay đổi byte của bản trình bày, nhưng ảnh hưởng đến việc đánh giá độ tin cậy chứng chỉ. Việc chữ ký còn chấp nhận được hay không phụ thuộc vào chính sách của bạn và liệu một dấu thời gian đáng tin cậy hợp lệ có chứng minh rằng việc ký đã diễn ra khi chứng chỉ còn hiệu lực hay không. Đừng chỉ dựa vào thời gian ký hiển thị như một dấu thời gian đáng tin cậy.

**Bản trình bày đã ký vẫn có thể chỉnh sửa được không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện có mất hiệu lực, vì vậy hãy hoàn thiện bản trình bày trước và ký phiên bản cuối cùng.

**Một bản trình bày có thể chứa nhiều hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào bộ sưu tập trả về bởi [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) trước khi lưu. Khi xác thực, kiểm tra mỗi chữ ký và xác nhận rằng tất cả người ký bắt buộc đều có mặt.

**Định dạng bản trình bày nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký số mô tả ở đây cho định dạng PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng tới các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập rồi lưu bản trình bày. Nội dung các slide vẫn còn, nhưng tệp đã lưu không còn chứa bằng chứng chữ ký đã bị xóa.