---
title: Bảo vệ mật khẩu cho bản trình chiếu trong PHP
linktitle: Bảo mật mật khẩu
type: docs
weight: 20
url: /vi/php-java/password-protected-presentation/
keywords:
- bản trình chiếu được bảo vệ bằng mật khẩu
- mật khẩu mở khóa
- mã hoá PowerPoint
- giải mã PowerPoint
- xác thực mật khẩu bản trình chiếu
- kiểm tra mật khẩu bản trình chiếu
- mở bản trình chiếu đã mã hoá
- gỡ bỏ mã hoá
- PowerPoint
- PPT
- PPTX
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu trong PHP với Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở khóa mã hoá một bản trình chiếu. Mật khẩu đúng cần thiết để tải và xem nội dung bản trình chiếu, do đó bảo vệ này cung cấp tính bảo mật.

Mật khẩu mở khóa khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc sửa đổi nhưng không mã hoá nội dung hoặc ngăn bản trình chiếu được tải. Để quản lý mật khẩu cho việc chỉnh sửa bản trình chiếu, xem [Write-Protect Presentations](/slides/vi/php-java/write-protected-presentation/).

Các quy trình làm việc dưới đây áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng là quan trọng.

## **Mã hoá bản trình chiếu bằng mật khẩu mở khóa**

Sử dụng [ProtectionManager::encrypt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#encrypt) để gán mật khẩu mở khóa. Sau đó sử dụng [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) để lưu bản trình chiếu đã được mã hoá.

Ví dụ sau mã hoá một bản trình chiếu PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tải một bản trình chiếu đã được mã hoá**

Đặt [LoadOptions::setPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setPassword) thành mật khẩu mở khóa và truyền tùy chọn này cho [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi mật khẩu mở khóa được yêu cầu nhưng mật khẩu cung cấp bị thiếu hoặc không đúng.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Làm việc với bản trình chiếu đã giải mã.
} finally {
    $presentation->dispose();
}
```

## **Xóa mã hoá khỏi bản trình chiếu**

Tải bản trình chiếu bằng mật khẩu mở khóa của nó, gọi [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#removeEncryption), và lưu kết quả. Bản trình chiếu đã lưu sau đó có thể được tải mà không cần mật khẩu.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Xác thực mật khẩu mở khóa trước khi tải**

Sử dụng [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) để lấy [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/) mà không tạo một thể hiện đầy đủ của bản trình chiếu. Kiểm tra [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#isPasswordProtected) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [PresentationInfo::checkPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Quy trình làm việc Đường dẫn tệp**

Ví dụ sau xác thực mật khẩu mở khóa cho một tệp PPTX, truyền giá trị đã xác thực cho [LoadOptions::setPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setPassword), và sau đó tải bản trình chiếu đầy đủ:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Quy trình làm việc Luồng**

Phiên bản overload luồng của [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) cung cấp cùng một quy trình làm việc. Đặt lại vị trí của luồng có thể tìm kiếm trước khi tải bản trình chiếu đầy đủ từ luồng đó.

Ví dụ sau sử dụng một tệp PPT:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Giá trị trả về của checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#checkPassword) trả về `true` chỉ khi bản trình chiếu có mật khẩu mở khóa và mật khẩu được cung cấp là đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bản trình chiếu không có mật khẩu mở khóa.
- Mật khẩu được cung cấp là `null` hoặc rỗng.

Hành vi này giống nhau cho các bản trình chiếu PPT và PPTX.

## **Kiểm tra xem một bản trình chiếu đã tải có được mã hoá không**

Sau khi tải một bản trình chiếu bằng mật khẩu đúng, kiểm tra [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#isEncrypted) để xác nhận rằng bản trình chiếu nguồn đã được mã hoá. Để phát hiện bảo vệ bằng mật khẩu mở khóa trước khi tải, sử dụng [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#isPasswordProtected) như đã mô tả ở trên.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Khuyến nghị bảo mật**

{{% alert color="warning" title="Security" %}}
Không ghi lại mật khẩu mở khóa hoặc bao gồm chúng trong các thông điệp chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi tải bản trình chiếu ngay lập tức.
{{% /alert %}}

## **Bảo vệ mật khẩu cho bản trình chiếu trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
2. Chọn hoặc tải lên bản trình chiếu.
3. Nhập mật khẩu để bảo vệ chế độ xem.
4. Tùy chọn nhập một mật khẩu riêng cho bảo vệ chỉnh sửa.
5. Áp dụng bảo vệ và tải xuống tệp kết quả.

{{% alert color="info" title="Xem thêm" %}}
- [Write-Protect Presentations](/slides/vi/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**What is the difference between an opening password and a write-protection password?**

Mật khẩu mở khóa mã hoá bản trình chiếu và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc sửa đổi mà không mã hoá nội dung.

**Can I validate an opening password without loading all slides?**

Có. Lấy thông tin bản trình chiếu, kiểm tra xem có bảo vệ bằng mật khẩu mở khóa hay không, và xác thực mật khẩu trước khi tạo một thể hiện đầy đủ của bản trình chiếu.

**Do the password-checking workflows support both PPT and PPTX?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng hoạt động giống nhau cho các bản trình chiếu PPT và PPTX.