---
title: Bảo vệ bản trình chiếu bằng mật khẩu trong PHP
linktitle: Bảo vệ mật khẩu
type: docs
weight: 20
url: /vi/php-java/password-protected-presentation/
keywords:
- bản trình chiếu được bảo vệ bằng mật khẩu
- mật khẩu mở đầu
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
description: "Mã hoá, phát hiện, xác thực, mở và giải mã các bản trình chiếu PowerPoint PPT và PPTX được bảo vệ bằng mật khẩu trong PHP bằng Aspose.Slides."
---
## **Tổng quan**

Mật khẩu mở đầu mã hoá một bài thuyết trình. Mật khẩu đúng cần thiết để tải và xem nội dung bài thuyết trình, do đó bảo vệ này cung cấp tính bí mật.

Mật khẩu mở đầu khác với mật khẩu bảo vệ ghi. Bảo vệ ghi hạn chế việc chỉnh sửa nhưng không mã hoá nội dung hoặc ngăn không cho bài thuyết trình được tải. Để quản lý mật khẩu cho việc chỉnh sửa bài thuyết trình, xem [Write-Protect Presentations](/slides/vi/php-java/write-protected-presentation/).

Các quy trình dưới đây áp dụng cho cả bài thuyết trình PPT và PPTX. Các ví dụ sử dụng cả hai định dạng khi hành vi dựa trên tệp và dựa trên luồng của chúng quan trọng.

## **Mã hoá một bài thuyết trình bằng mật khẩu mở đầu**

Sử dụng [ProtectionManager::encrypt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#encrypt) để gán mật khẩu mở đầu. Sau đó sử dụng [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) để lưu lại bài thuyết trình đã được mã hoá.

Ví dụ sau mã hoá một bài thuyết trình PPTX:

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

## **Giữ các thuộc tính tài liệu công khai**

Mặc định, Aspose.Slides bao gồm các thuộc tính tài liệu trong việc mã hoá bài thuyết trình. Phương thức [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) kiểm soát hành vi này một cách độc lập với việc mã hoá nội dung slide. Gửi `false` trước khi gọi [ProtectionManager::encrypt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#encrypt) khi một hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu cần đọc siêu dữ liệu mà không cần mật khẩu mở đầu.

Ví dụ sau tạo một bài thuyết trình PPTX đã được mã hoá trong khi giữ các thuộc tính tài liệu tích hợp sẵn công khai:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Việc truyền `false` vào [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) không làm cho các slide, master, layout, shape, media hoặc nội dung bài thuyết trình khác trở nên công khai. Nó chỉ ảnh hưởng đến các thuộc tính tài liệu. Để đọc các thuộc tính đó mà không tải nội dung đã mã hoá, xem [Manage Presentation Properties](/slides/vi/php-java/presentation-properties/).

## **Tải một bài thuyết trình đã mã hoá**

Đặt [LoadOptions::setPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setPassword) thành mật khẩu mở đầu và truyền các tùy chọn tới [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) khi tải tệp. Việc tải sẽ thất bại khi yêu cầu mật khẩu mở đầu nhưng mật khẩu đã cung cấp bị thiếu hoặc không đúng.

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

## **Gỡ bỏ mã hoá khỏi một bài thuyết trình**

Tải bài thuyết trình bằng mật khẩu mở đầu của nó, gọi [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#removeEncryption), và lưu kết quả. Bài thuyết trình đã lưu sau đó có thể được tải mà không cần mật khẩu.

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

## **Xác thực mật khẩu mở đầu trước khi tải**

Sử dụng [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) để lấy [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/) mà không tạo một thể hiện hoàn chỉnh của bài thuyết trình. Kiểm tra [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#isPasswordProtected) trước khi yêu cầu hoặc xác thực mật khẩu. Khi có bảo vệ, xác thực giá trị đã cung cấp bằng [PresentationInfo::checkPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Quy trình Đường dẫn Tệp**

Ví dụ sau xác thực mật khẩu mở đầu cho một tệp PPTX, truyền giá trị đã xác thực tới [LoadOptions::setPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setPassword), và sau đó tải toàn bộ bài thuyết trình:

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

### **Quy trình Luồng**

Phiên bản quá tải luồng của [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) cung cấp cùng một quy trình. Đặt lại vị trí của luồng có thể tìm kiếm trước khi tải toàn bộ bài thuyết trình từ luồng đó.

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

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#checkPassword) trả về `true` chỉ khi bài thuyết trình có mật khẩu mở đầu và mật khẩu đã cung cấp là đúng. Nó trả về `false` trong mỗi trường hợp sau:

- Mật khẩu không đúng.
- Bài thuyết trình không có mật khẩu mở đầu.
- Mật khẩu đã cung cấp là `null` hoặc rỗng.

Hành vi này giống nhau cho các bài thuyết trình PPT và PPTX.

## **Kiểm tra liệu một bài thuyết trình đã tải có được mã hoá hay không**

Sau khi tải một bài thuyết trình bằng mật khẩu đúng, kiểm tra [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#isEncrypted) để xác nhận rằng bài thuyết trình gốc đã được mã hoá. Để phát hiện bảo vệ bằng mật khẩu mở đầu trước khi tải, sử dụng [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#isPasswordProtected) như đã trình bày ở trên.

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

## **Khuyến nghị Bảo mật**

{{% alert color="warning" title="Bảo mật" %}}
Không ghi lại mật khẩu mở đầu hoặc bao gồm chúng trong các thông điệp chẩn đoán. Tránh các lần thử xác thực lặp lại không cần thiết, giữ mật khẩu trong bộ nhớ chỉ trong thời gian cần thiết, và tái sử dụng kết quả xác thực thành công khi tải ngay bài thuyết trình.

Các thuộc tính tài liệu công khai có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và giá trị tùy chỉnh ngay cả khi nội dung bài thuyết trình đã được mã hoá. Mã hoá siêu dữ liệu nhạy cảm cùng với bài thuyết trình. Việc để các thuộc tính công khai nên là một quyết định rõ ràng, chỉ được thực hiện khi các hệ thống phải lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tệp mà không có mật khẩu mở đầu.
{{% /alert %}}

## **Bảo vệ mật khẩu một bài thuyết trình trực tuyến**

1. Mở ứng dụng [Aspose.Slides Lock](https://products.aspose.app/slides/vi/lock).
1. Chọn hoặc tải lên bài thuyết trình.
1. Nhập mật khẩu để bảo vệ khi xem.
1. Tùy chọn nhập một mật khẩu riêng biệt để bảo vệ khi chỉnh sửa.
1. Áp dụng bảo vệ và tải về tệp kết quả.

{{% alert color="info" title="Xem thêm" %}}
- [Write-Protect Presentations](/slides/vi/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/vi/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa mật khẩu mở đầu và mật khẩu bảo vệ ghi là gì?**

Mật khẩu mở đầu mã hoá bài thuyết trình và cần thiết để tải nội dung của nó. Mật khẩu bảo vệ ghi hạn chế việc chỉnh sửa mà không mã hoá nội dung.

**Tôi có thể xác thực mật khẩu mở đầu mà không tải toàn bộ các slide không?**

Có. Lấy thông tin bài thuyết trình, kiểm tra xem có bảo vệ bằng mật khẩu mở đầu hay không, và xác thực mật khẩu trước khi tạo một thể hiện hoàn chỉnh của bài thuyết trình.

**Ứng dụng có thể đọc siêu dữ liệu mà không có mật khẩu mở đầu không?**

Có, nhưng chỉ khi bài thuyết trình được mã hoá với việc mã hoá thuộc tính tài liệu bị tắt. Ứng dụng sau đó phải sử dụng chế độ chỉ tải thuộc tính tài liệu như mô tả trong [Manage Presentation Properties](/slides/vi/php-java/presentation-properties/).

**Các quy trình kiểm tra mật khẩu có hỗ trợ cả PPT và PPTX không?**

Có. Phát hiện và xác thực mật khẩu dựa trên đường dẫn tệp và luồng hoạt động tương tự cho các bài thuyết trình PPT và PPTX.