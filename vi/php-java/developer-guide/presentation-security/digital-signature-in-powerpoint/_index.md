---
title: Thêm Chữ ký Số vào Bản trình chiếu trong PHP
linktitle: Chữ ký số
type: docs
weight: 10
url: /vi/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình chiếu PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho PHP thông qua Java để xác thực hoặc xóa chữ ký số."
---
## **Tổng quan**

Chữ ký số giúp người nhận xác định ai đã ký bản trình chiếu và nội dung đã ký có thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- Một **digital certificate** là chứng chỉ điện tử liên kết danh tính với khóa công khai. Một cơ quan chứng chỉ (CA) đáng tin cậy có thể phát hành chứng chỉ, hoặc tổ chức có thể sử dụng chứng chỉ tự ký cho các quy trình nội bộ.
- Một **digital signature** được tạo từ nội dung bản trình chiếu và khóa riêng của chủ sở hữu chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được dùng để xác minh chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình chiếu.
- **Password protection** kiểm soát người dùng có thể mở hoặc chỉnh sửa bản trình chiếu hay không. Nó riêng biệt với việc ký số và được mô tả trong [Password-Protected Presentations](/slides/vi/php-java/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** trong **File > Info > Protect Presentation**.

![Menu Protect Presentation của PowerPoint với mục Add a Digital Signature được tô sáng](add-digital-signature-in-powerpoint.png)

Sau khi mở một bản trình chiếu đã ký, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo PowerPoint cho biết bản trình chiếu chứa các chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký thông qua [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDigitalSignatures), trả về một [DigitalSignatureCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignaturecollection/) mà các mục được biểu diễn bằng các đối tượng [DigitalSignature](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/). Một bản trình chiếu có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Một tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng là yếu tố cho phép chủ sở hữu tạo chữ ký. Chứng chỉ không có khóa riêng có thể truy cập không thể dùng để ký bản trình chiếu.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình chiếu. Không đưa các tệp PFX hoặc mật khẩu của chúng lên hệ thống kiểm soát nguồn. Trong môi trường sản xuất, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình được bảo vệ khác. Các ví dụ dưới đây chỉ dùng biến môi trường để tránh nhúng mật khẩu trong mã.

## **Thêm Chữ ký Số vào Bản trình chiếu**

Để ký một quy trình bản trình chiếu thực tế, tải một tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình chiếu, và lưu dưới dạng tệp PPTX.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lưu kết quả dưới một tên mới giúp bảo toàn tệp nguồn chưa ký. Giá trị được đặt bằng [DigitalSignature::setComments](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/setcomments/) mô tả mục đích của chữ ký; nó không phải là một biện pháp kiểm soát bảo mật.

## **Xác thực Chữ ký Số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mọi mục được trả về bởi [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDigitalSignatures). Phương thức [DigitalSignature::isValid](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/isvalid/) cho biết chữ ký nhúng có hợp lệ cho nội dung bản trình chiếu hiện tại hay không.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình chiếu đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Việc loại bỏ mọi chữ ký tạo ra một bản trình chiếu chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục là không đủ: quy trình nhạy cảm với bảo mật còn cần xác minh rằng số lượng chữ ký và danh tính người ký dự kiến đều có mặt.

Kết quả hợp lệ này không nên được coi là quyết định tin cậy hoàn toàn đối với chứng chỉ. Tùy theo chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi của chứng chỉ, xác nhận chủ đề hoặc dấu vân tay mong đợi, kiểm tra mục đích sử dụng khóa, và đánh giá dấu thời gian đáng tin cậy. Giá trị [DigitalSignature::getSignTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/getsigntime/) tự nó không phải là bằng chứng từ một cơ quan dấu thời gian đáng tin.

## **Xóa Chữ ký Số**

Việc xóa chữ ký thay đổi trạng thái bảo mật của bản trình chiếu. Ví dụ dưới đây tải một tệp PPTX đã ký, xóa mọi chữ ký bằng [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignaturecollection/clear/), và lưu một bản sao chưa ký.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Để xóa chỉ một chữ ký, gọi [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignaturecollection/removeat/) với chỉ mục bắt đầu từ 0 của nó. Lưu vào tệp mới trừ khi việc ghi đè lên tệp gốc đã ký là một phần rõ ràng của quy trình của bạn.

## **Xem xét về Chỉnh sửa và Định dạng**

- Một chữ ký không làm cho bản trình chiếu chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng các thay đổi đối với nội dung đã ký thường làm cho chữ ký hiện tại mất hiệu lực.
- Hoàn thành tất cả các chỉnh sửa dự định trước khi ký. Nếu cần thay đổi bản trình chiếu, lưu bản trình chiếu đã chỉnh sửa và ký lại phiên bản đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình chiếu đã ký sang định dạng khác không chuyển chữ ký PPTX gốc thành một chữ ký hợp lệ cho tệp đã chuyển đổi.
- Coi khóa riêng của chứng chỉ là thông tin nhạy cảm. Ai có được khóa riêng và mật khẩu của nó có thể tạo chữ ký trông như đến từ chủ sở hữu chứng chỉ đó.
- Lưu giữ nguồn chưa ký hoặc một bản sao được kiểm soát khác khi chính sách lưu trữ tài liệu của bạn yêu cầu.

## **FAQ**

**Chữ ký số có mã hoá bản trình chiếu không?**

Không. Chữ ký số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình chiếu vẫn có thể đọc được trừ khi có áp dụng mã hoá riêng. Hãy sử dụng [password protection](/slides/vi/php-java/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu bản trình chiếu không?**

Không. Mật khẩu PFX mở khóa khóa riêng lưu trong gói chứng chỉ. Nó không kiểm soát ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể dùng chứng chỉ tự ký không?**

Kỹ thuậtally, chứng chỉ tự ký có thể được dùng khi bao gồm một khóa riêng có thể truy cập. Tuy nhiên, người nhận sẽ không tự động tin cậy nó trừ khi chứng chỉ đã được thêm một cách rõ ràng vào môi trường đáng tin của họ. Các quy trình công cộng hoặc đa tổ chức thường dùng chứng chỉ được cấp bởi một CA đáng tin.

**Điều gì khiến một chữ ký không hợp lệ?**

Thay đổi nội dung bản trình chiếu đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký mất hiệu lực. Hỏng hóc tệp cũng có thể gây thất bại trong việc xác thực. Nếu tất cả chữ ký được xóa, bản trình chiếu trở thành chưa ký chứ không phải chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin cậy người ký không?**

Không tự động. Tính toàn vẹn của chữ ký và mức độ tin cậy của người ký là hai quyết định riêng biệt. Chính sách xác thực trong môi trường sản xuất nên cũng kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính dự kiến, mục đích sử dụng khóa, và bất kỳ yêu cầu dấu thời gian đáng tin nào.

**Điều gì xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không thay đổi byte của bản trình chiếu, nhưng ảnh hưởng đến việc đánh giá độ tin cậy của chứng chỉ. Việc chữ ký còn chấp nhận được hay không phụ thuộc vào chính sách của bạn và liệu có dấu thời gian đáng tin chứng minh rằng việc ký đã diễn ra khi chứng chỉ vẫn còn hiệu lực. Đừng chỉ dựa vào thời gian ký được hiển thị như một dấu thời gian đáng tin.

**Bản trình chiếu đã ký vẫn có thể được chỉnh sửa không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện tại mất hiệu lực, vì vậy hãy hoàn thiện bản trình chiếu trước và ký phiên bản cuối cùng.

**Một bản trình chiếu có thể chứa hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào bộ sưu tập trả về bởi [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDigitalSignatures) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả người ký yêu cầu đều có mặt.

**Các định dạng bản trình chiếu nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký số mô tả ở đây cho PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng tới các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập, sau đó lưu bản trình chiếu. Nội dung slide vẫn còn, nhưng tệp đã lưu không còn mang bằng chứng chữ ký đã xóa.