---
title: Thêm Chữ ký Kỹ thuật số vào Bản trình bày trên Android
linktitle: Chữ ký Kỹ thuật số
type: docs
weight: 10
url: /vi/androidjava/digital-signature-in-powerpoint/
keywords:
- chữ ký kỹ thuật số
- chứng chỉ kỹ thuật số
- cơ quan chứng nhận
- chứng chỉ PFX
- PKCS#12
- xác thực chữ ký
- PowerPoint
- PPTX
- bảo mật bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình bày PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho Android qua Java để xác thực hoặc xóa chữ ký kỹ thuật số."
---
## **Tổng quan**

Một chữ ký kỹ thuật số giúp người nhận xác định ai đã ký một bản trình bày và nội dung đã ký có bị thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- Một **digital certificate** là một chứng chỉ điện tử liên kết danh tính với một khóa công khai. Một cơ quan chứng nhận đáng tin cậy (CA) có thể phát hành chứng chỉ, hoặc một tổ chức có thể sử dụng một chứng chỉ tự ký cho các quy trình nội bộ.
- Một **digital signature** được tạo ra từ nội dung bản trình bày và khóa riêng của chủ chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được dùng để xác minh chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình bày.
- **Password protection** kiểm soát việc người dùng có thể mở hoặc chỉnh sửa bản trình bày hay không. Nó tách biệt với việc ký kỹ thuật số và được mô tả trong [Password-Protected Presentations](/androidjava/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** trong **File > Info > Protect Presentation**.

![Menu Bảo vệ bản trình bày của PowerPoint với Add a Digital Signature được đánh dấu](add-digital-signature-in-powerpoint.png)

Sau khi một bản trình bày đã ký được mở, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo PowerPoint cho biết bản trình bày chứa các chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký qua [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), phương thức này trả về một [IDigitalSignatureCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idigitalsignaturecollection/) mà các mục thực thi [IDigitalSignature](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idigitalsignature/). Một bản trình bày có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Một tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng là thứ cho phép người nắm giữ tạo chữ ký. Một chứng chỉ không có khóa riêng có thể truy cập được sẽ không thể dùng để ký bản trình bày.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình bày. Đừng commit các tệp PFX hoặc mật khẩu của chúng vào hệ thống kiểm soát phiên bản. Trong môi trường production, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình được bảo vệ khác. Các ví dụ dưới đây chỉ sử dụng biến môi trường để tránh nhúng mật khẩu vào mã nguồn.

## **Thêm Chữ ký Kỹ thuật số vào Bản trình bày**

Để ký một quy trình bản trình bày thực tế, tải một tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình bày, và lưu thành tệp PPTX.

```java
import com.aspose.slides.*;

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

Lưu kết quả với tên mới giúp bảo toàn tệp nguồn chưa ký. Giá trị được đặt bằng [IDigitalSignature.setComments](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) mô tả mục đích của chữ ký; nó không phải là một kiểm soát bảo mật.

## **Xác thực Chữ ký Kỹ thuật số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mọi mục trả về bởi [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). Phương thức [IDigitalSignature.isValid](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idigitalsignature/#isValid--) cho biết chữ ký nhúng có hợp lệ cho nội dung hiện tại của bản trình bày hay không.

```java
import com.aspose.slides.*;

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

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình bày đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Việc xóa mọi chữ ký tạo ra một bản trình bày chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục không đủ: một quy trình nhạy cảm về bảo mật cũng phải xác minh rằng số lượng chữ ký mong đợi và danh tính người ký dự kiến đều có mặt.

Kết quả hợp lệ này không nên được xem như một quyết định tin cậy toàn bộ chứng chỉ. Tùy thuộc vào chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi của chứng chỉ, xác nhận chủ thể hoặc dấu vân tay mong đợi, kiểm tra mục đích sử dụng khóa, và đánh giá một dấu thời gian đáng tin cậy. Giá trị [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) tự nó không phải là bằng chứng từ một tổ chức thời gian đáng tin cậy.

## **Xóa Chữ ký Kỹ thuật số**

Việc xóa chữ ký thay đổi trạng thái bảo mật của bản trình bày. Ví dụ dưới đây tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), và lưu một bản sao chưa ký.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để xóa chỉ một chữ ký, gọi [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) với chỉ mục bắt đầu từ 0 của nó. Lưu vào tệp mới trừ khi việc ghi đè lên bản gốc đã ký là một phần rõ ràng của quy trình của bạn.

## **Cân nhắc về Chỉnh sửa và Định dạng**

- Một chữ ký không làm cho bản trình bày ở chế độ chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng việc thay đổi nội dung đã ký thường làm chữ ký hiện có mất hiệu lực.
- Hoàn tất mọi chỉnh sửa dự định trước khi ký. Nếu bản trình bày cần thay đổi, hãy lưu bản trình bày đã sửa và ký lại phiên bản đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình bày đã ký sang định dạng khác sẽ không truyền chữ ký PPTX gốc thành một chữ ký hợp lệ cho tệp đã chuyển đổi.
- Xem khóa riêng của chứng chỉ như một thông tin nhạy cảm. Bất kỳ ai có được khóa riêng và mật khẩu của nó có thể tạo ra các chữ ký trông giống như được tạo bởi chủ chứng chỉ.
- Giữ lại nguồn chưa ký hoặc một bản sao được kiểm soát khác khi chính sách lưu trữ tài liệu của bạn yêu cầu điều đó.

## **Câu hỏi thường gặp**

**Chữ ký kỹ thuật số có mã hoá bản trình bày không?**

Không. Chữ ký kỹ thuật số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình bày vẫn có thể đọc được trừ khi có áp dụng mã hoá riêng. Sử dụng [password protection](/androidjava/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu bản trình bày không?**

Không. Mật khẩu PFX mở khóa khóa riêng được lưu trong gói chứng chỉ. Nó không điều khiển ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể sử dụng chứng chỉ tự ký không?**

Về mặt kỹ thuật, một chứng chỉ tự ký có thể được dùng nếu nó bao gồm một khóa riêng có thể truy cập. Tuy nhiên, người nhận sẽ không tự động tin tưởng nó trừ khi chứng chỉ ấy đã được thêm một cách rõ ràng vào môi trường tin cậy của họ. Các quy trình công cộng hoặc liên tổ chức thường sử dụng chứng chỉ do CA đáng tin cậy phát hành.

**Điều gì khiến một chữ ký trở nên không hợp lệ?**

Việc thay đổi nội dung bản trình bày đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký mất hiệu lực. Hỏng hóc tệp cũng có thể gây lỗi xác thực. Nếu tất cả chữ ký bị xóa, bản trình bày sẽ trở thành chưa ký thay vì chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin tưởng người ký không?**

Không tự nhiên. Tính toàn vẹn của chữ ký và độ tin cậy của người ký là hai quyết định riêng biệt. Chính sách xác thực trong môi trường production nên cũng kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính mong đợi, mục đích sử dụng khóa và bất kỳ yêu cầu dấu thời gian đáng tin cậy nào.

**Điều gì sẽ xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không thay đổi các byte của bản trình bày, nhưng nó ảnh hưởng đến việc đánh giá độ tin cậy của chứng chỉ. Việc chữ ký vẫn được chấp nhận hay không phụ thuộc vào chính sách của bạn và việc có một dấu thời gian đáng tin cậy chứng minh thời điểm ký diễn ra khi chứng chỉ còn hiệu lực hay không. Đừng chỉ dựa vào thời gian ký được hiển thị như một dấu thời gian đáng tin cậy.

**Một bản trình bày đã ký vẫn có thể được chỉnh sửa không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện có mất hiệu lực, vì vậy hãy hoàn thiện bản trình bày trước và ký phiên bản cuối cùng.

**Một bản trình bày có thể chứa nhiều hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào bộ sưu tập trả về bởi [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả các người ký bắt buộc đều có mặt.

**Các định dạng bản trình bày nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký kỹ thuật số được mô tả ở đây cho PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng đến các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập, sau đó lưu bản trình bày. Nội dung slide vẫn còn, nhưng tệp đã lưu sẽ không còn chứa bằng chứng về chữ ký đã bị xóa.