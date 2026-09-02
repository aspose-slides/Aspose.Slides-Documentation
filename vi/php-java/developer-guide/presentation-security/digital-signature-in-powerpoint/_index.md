---
title: Thêm Chữ ký Kỹ thuật số vào Bản trình bày trong PHP
linktitle: Chữ ký Kỹ thuật số
type: docs
weight: 10
url: /vi/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "Tìm hiểu cách ký các bản trình bày PPTX hiện có bằng chứng chỉ PFX và sử dụng Aspose.Slides cho PHP thông qua Java để xác thực hoặc xóa chữ ký kỹ thuật số."
---
## **Tổng quan**

Chữ ký kỹ thuật số giúp người nhận xác định ai đã ký một bản trình bày và liệu nội dung đã ký có bị thay đổi hay không. Ba khái niệm bảo mật liên quan quan trọng ở đây:

- Một **digital certificate** là một chứng chỉ điện tử liên kết một danh tính với một khóa công khai. Một cơ quan chứng nhận (CA) đáng tin cậy có thể cấp chứng chỉ, hoặc một tổ chức có thể sử dụng chứng chỉ tự ký cho quy trình nội bộ.
- Một **digital signature** được tạo ra từ nội dung bản trình bày và khóa riêng của người nắm giữ chứng chỉ. Khóa công khai của chứng chỉ sau đó có thể được sử dụng để xác thực chữ ký. Chữ ký cung cấp bằng chứng về nguồn gốc và tính toàn vẹn; nó không mã hoá bản trình bày.
- **Password protection** kiểm soát việc người dùng có thể mở hoặc sửa đổi bản trình bày hay không. Nó tách biệt khỏi việc ký kỹ thuật số và được mô tả trong [Password-Protected Presentations](/php-java/password-protected-presentation/).

PowerPoint cung cấp lệnh **Add a Digital Signature** trong **File > Info > Protect Presentation**.

![Menu Bảo vệ bản trình bày PowerPoint với Add a Digital Signature được đánh dấu](add-digital-signature-in-powerpoint.png)

Sau khi một bản trình bày đã ký được mở, PowerPoint có thể hiển thị thông báo trạng thái chữ ký.

![Thông báo PowerPoint cho biết bản trình bày chứa các chữ ký hợp lệ](digital-signature-status-in-powerpoint.png)

Aspose.Slides cung cấp các chữ ký thông qua [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDigitalSignatures), trả về một [DigitalSignatureCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignaturecollection/) trong đó các mục được biểu diễn bằng các đối tượng [DigitalSignature](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/). Một bản trình bày có thể chứa nhiều chữ ký.

## **Hiểu về Chứng chỉ PFX và Mật khẩu**

Một tệp PFX, còn được gọi là tệp PKCS#12 và thường có phần mở rộng `.pfx` hoặc `.p12`, có thể chứa một chứng chỉ X.509, khóa riêng của nó và chuỗi chứng chỉ. Khóa riêng là thứ cho phép người nắm giữ tạo chữ ký. Một chứng chỉ không có khóa riêng có thể truy cập được không thể được sử dụng để ký bản trình bày.

Mật khẩu PFX bảo vệ gói chứng chỉ và khóa riêng. Nó **không** phải là mật khẩu để mở hoặc chỉnh sửa bản trình bày. Không được commit các tệp PFX hoặc mật khẩu của chúng lên hệ thống kiểm soát phiên bản. Trong môi trường sản xuất, hạn chế quyền truy cập vào tệp chứng chỉ và lấy mật khẩu từ kho bí mật hoặc nguồn cấu hình được bảo vệ khác. Các ví dụ dưới đây chỉ sử dụng biến môi trường để tránh nhúng mật khẩu trong mã.

## **Thêm Chữ ký Kỹ thuật số vào Bản trình bày**

Để ký một quy trình thực tế, tải một tệp PPTX hiện có, tạo một [DigitalSignature](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/) từ chứng chỉ PFX và mật khẩu của nó, thêm chữ ký vào bộ sưu tập của bản trình bày và lưu lại dưới dạng tệp PPTX.

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

Lưu kết quả dưới một tên mới giúp giữ nguyên tệp nguồn chưa ký. Giá trị được đặt bằng [DigitalSignature::setComments](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/setcomments/) mô tả mục đích của chữ ký; nó không phải là một kiểm soát bảo mật.

## **Xác thực Chữ ký Kỹ thuật số**

Khi bạn tải một tệp PPTX đã ký, kiểm tra mọi mục được trả về bởi [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDigitalSignatures). Phương thức [DigitalSignature::isValid](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/isvalid/) cho biết chữ ký nhúng có hợp lệ đối với nội dung hiện tại của bản trình bày hay không.

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

Kết quả không hợp lệ thường có nghĩa là nội dung bản trình bày đã ký hoặc dữ liệu chữ ký đã thay đổi sau khi ký, hoặc tệp bị hỏng. Xóa mọi chữ ký sẽ tạo ra một bản trình bày chưa ký, vì vậy chỉ kiểm tra tính hợp lệ của các mục không đủ: một quy trình nhạy cảm với bảo mật cũng phải xác minh rằng số lượng chữ ký mong muốn và danh tính người ký dự kiến đều có mặt.

Kết quả hợp lệ này không nên được xem như quyết định tin cậy chứng chỉ hoàn toàn. Tùy theo chính sách bảo mật của bạn, ứng dụng có thể cần xây dựng và xác thực chuỗi chứng chỉ X.509, kiểm tra ngày hiệu lực và trạng thái thu hồi của chứng chỉ, xác nhận chủ đề hoặc dấu vân tay dự kiến, kiểm tra mục đích sử dụng khóa và đánh giá dấu thời gian tin cậy. Giá trị [DigitalSignature::getSignTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignature/getsigntime/) tự mình không phải là bằng chứng từ một cơ quan thời gian tin cậy.

## **Xóa Chữ ký Kỹ thuật số**

Xóa chữ ký thay đổi trạng thái bảo mật của bản trình bày. Ví dụ dưới đây tải một tệp PPTX đã ký, xóa tất cả chữ ký bằng [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignaturecollection/clear/), và lưu một bản sao chưa ký.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Để xóa chỉ một chữ ký, gọi [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/digitalsignaturecollection/removeat/) với chỉ số bắt đầu từ 0. Lưu vào một tệp mới trừ khi việc ghi đè bản gốc đã ký là một phần rõ ràng của quy trình của bạn.

## **Xem xét về Chỉnh sửa và Định dạng**

- Một chữ ký không làm cho bản trình bày chỉ đọc. Người dùng và ứng dụng vẫn có thể chỉnh sửa tệp, nhưng việc thay đổi nội dung đã ký thường làm cho chữ ký hiện có không hợp lệ.
- Hoàn thành mọi chỉnh sửa dự định trước khi ký. Nếu bản trình bày phải được thay đổi, lưu bản trình bày đã sửa và ký lại phiên bản đó.
- Giữ đầu ra cuối cùng ở định dạng PPTX. Chuyển đổi một bản trình bày đã ký sang định dạng khác không chuyển chữ ký PPTX gốc thành một chữ ký hợp lệ cho tệp đã chuyển đổi.
- Đối xử với khóa riêng của chứng chỉ như thông tin nhạy cảm. Bất kỳ ai có được khóa riêng và mật khẩu của nó có thể tạo ra chữ ký trông giống như đến từ người nắm giữ chứng chỉ.
- Giữ lại nguồn chưa ký hoặc một bản sao được kiểm soát khi chính sách lưu trữ tài liệu của bạn yêu cầu.

## **Câu hỏi thường gặp**

**Chữ ký kỹ thuật số có mã hoá bản trình bày không?**

Không. Chữ ký kỹ thuật số cung cấp bằng chứng về nguồn gốc và tính toàn vẹn, nhưng nội dung bản trình bày vẫn có thể đọc được trừ khi có mã hoá riêng biệt được áp dụng. Sử dụng [password protection](/php-java/password-protected-presentation/) khi cần hạn chế quyền truy cập vào nội dung.

**Mật khẩu PFX có giống mật khẩu bản trình bày không?**

Không. Mật khẩu PFX mở khóa khóa riêng lưu trong gói chứng chỉ. Nó không kiểm soát ai có thể mở hoặc chỉnh sửa tệp PPTX.

**Tôi có thể sử dụng chứng chỉ tự ký không?**

Về mặt kỹ thuật, chứng chỉ tự ký có thể được sử dụng khi nó bao gồm khóa riêng có thể truy cập. Tuy nhiên, người nhận sẽ không tự động tin tưởng nó trừ khi chứng chỉ đã được thêm một cách rõ ràng vào môi trường tin cậy của họ. Thông thường, các quy trình công hoặc liên tổ chức sẽ sử dụng chứng chỉ do CA đáng tin cậy cấp phát.

**Điều gì làm cho chữ ký không hợp lệ?**

Thay đổi nội dung bản trình bày đã ký hoặc dữ liệu chữ ký sau khi ký có thể làm cho chữ ký không hợp lệ. Hỏng hóc tệp cũng có thể gây thất bại trong việc xác thực. Nếu tất cả chữ ký bị xóa, bản trình bày sẽ trở thành chưa ký thay vì chứa một chữ ký không hợp lệ.

**Một chữ ký hợp lệ có nghĩa là tôi nên tin tưởng người ký không?**

Không tự động. Tính toàn vẹn của chữ ký và độ tin cậy của người ký là những quyết định riêng biệt. Chính sách xác thực sản xuất nên cũng kiểm tra chuỗi chứng chỉ, thời gian hiệu lực, trạng thái thu hồi, danh tính dự kiến, mục đích sử dụng khóa và bất kỳ yêu cầu dấu thời gian tin cậy nào.

**Đi gì sẽ xảy ra khi chứng chỉ hết hạn?**

Hết hạn chứng chỉ không thay đổi byte của bản trình bày, nhưng nó ảnh hưởng đến việc đánh giá tin cậy chứng chỉ. Whether a signature remains acceptable depends on your policy and whether a valid trusted timestamp proves that signing occurred while the certificate was valid. Không nên chỉ dựa vào thời gian ký hiển thị như một dấu thời gian tin cậy.

**Bản trình bày đã ký vẫn có thể chỉnh sửa không?**

Có. Việc ký không khóa tệp. Chỉnh sửa nội dung đã ký thường làm cho chữ ký hiện có không hợp lệ, vì vậy hãy hoàn thành bản trình bày trước và ký lại phiên bản cuối cùng.

**Một bản trình bày có thể chứa hơn một chữ ký không?**

Có. Thêm mỗi chữ ký vào bộ sưu tập trả về bởi [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDigitalSignatures) trước khi lưu. Khi xác thực, kiểm tra mọi chữ ký và xác nhận rằng tất cả người ký bắt buộc đều có mặt.

**Định dạng bản trình bày nào hỗ trợ các thao tác này?**

Aspose.Slides chỉ hỗ trợ các thao tác chữ ký kỹ thuật số mô tả ở đây cho định dạng PPTX. Các định dạng PPT và OpenDocument không được API này hỗ trợ.

**Tôi có thể xóa một chữ ký mà không ảnh hưởng đến các slide không?**

Có. Bạn có thể xóa một chữ ký hoặc xóa toàn bộ bộ sưu tập và sau đó lưu bản trình bày. Nội dung slide vẫn còn, nhưng tệp đã lưu sẽ không còn mang bằng chứng của chữ ký đã bị xóa.