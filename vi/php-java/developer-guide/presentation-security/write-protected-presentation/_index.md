---
title: Bảo vệ ghi các bản trình chiếu trong PHP
linktitle: Bảo vệ ghi
type: docs
weight: 25
url: /vi/php-java/write-protected-presentation/
keywords:
- bảo vệ ghi
- bảo vệ ghi PowerPoint
- mật khẩu để chỉnh sửa
- hạn chế chỉnh sửa bản trình chiếu
- xóa bảo vệ ghi
- xác thực mật khẩu chỉnh sửa
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Thiết lập, phát hiện, xác thực và xóa mật khẩu bảo vệ ghi trong các bản trình chiếu PowerPoint PPT và PPTX bằng Aspose.Slides cho PHP."
---
## **Giới thiệu**

Mật khẩu bảo vệ ghi không cho phép chỉnh sửa một bản trình chiếu nhưng không mã hoá nội dung của nó. Người dùng có thể tải và xem bản trình chiếu được bảo vệ ghi mà không cần mật khẩu. Tùy thuộc vào ứng dụng, họ cũng có thể chỉnh sửa nội dung và lưu lại dưới tên khác, vì vậy bảo vệ ghi không nên được coi là cơ chế bảo mật.

Mật khẩu mở có mục đích khác: nó mã hoá bản trình chiếu và bắt buộc phải có để tải nội dung của nó. Để mã hoá một bản trình chiếu hoặc xác thực mật khẩu mở, hãy xem [Bảo vệ mật khẩu cho bản trình chiếu](/slides/vi/php-java/password-protected-presentation/).

Quy trình trong bài viết này áp dụng cho cả bản trình chiếu PPT và PPTX. Các ví dụ sử dụng tệp PPTX; khi lưu thành PPT, hãy sử dụng phần mở rộng `.ppt` và định dạng lưu PPT tương ứng.

## **Đặt bảo vệ ghi trên bản trình chiếu**

Sử dụng [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#setWriteProtection) để chỉ định mật khẩu cho việc chỉnh sửa một bản trình chiếu. Lưu bản trình chiếu sẽ giữ lại cài đặt bảo vệ.

Ví dụ sau đặt bảo vệ ghi trên một bản trình chiếu PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tải bản trình chiếu được bảo vệ ghi**

Vì bảo vệ ghi không mã hoá nội dung bản trình chiếu, không cần mật khẩu để tải bản trình chiếu. Mật khẩu chỉ có liên quan khi xác thực quyền chỉnh sửa bản trình chiếu được bảo vệ.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Không truyền mật khẩu bảo vệ ghi vào [LoadOptions::setPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setPassword). Phương thức đó chỉ chấp nhận mật khẩu mở cho nội dung đã được mã hoá. Nếu một bản trình chiếu có cả hai loại bảo vệ, hãy cung cấp mật khẩu mở để tải và xử lý mật khẩu bảo vệ ghi riêng biệt.

## **Xóa bảo vệ ghi khỏi bản trình chiếu**

Sử dụng [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#removeWriteProtection) để loại bỏ giới hạn chỉnh sửa, sau đó lưu bản trình chiếu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kiểm tra xem bản trình chiếu có được bảo vệ ghi hay không**

Để kiểm tra một tệp mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) đầy đủ, gọi [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) và kiểm tra [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#isWriteProtected). Phương thức này sử dụng [NullableBool](https://reference.aspose.com/slides/vi/php-java/aspose.slides/nullablebool/) và trả về `NullableBool::True` khi phát hiện bảo vệ ghi.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

Phiên bản overload theo luồng của [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) cung cấp cùng thông tin cho một bản trình chiếu được cung cấp dưới dạng luồng.

## **Xác thực mật khẩu bảo vệ ghi**

Sử dụng [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#checkWriteProtection) để xác thực mật khẩu chỉnh sửa mà không cần tải toàn bộ bản trình chiếu. Đầu tiên kiểm tra [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#isWriteProtected) để ứng dụng chỉ yêu cầu hoặc xác thực mật khẩu khi có bảo vệ ghi.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#checkWriteProtection) chỉ xác thực mật khẩu bảo vệ ghi. Nó không xác thực mật khẩu mở hoặc xác định liệu nội dung đã được mã hoá có thể được tải hay không. Ngược lại, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#checkPassword) chỉ xác thực mật khẩu mở. Nếu một bản trình chiếu đầy đủ đã được tải, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#checkWriteProtection) cung cấp kiểm tra bảo vệ ghi tương đương thông qua trình quản lý bảo vệ của nó.

Trong các ứng dụng sản xuất, không ghi lại mật khẩu hoặc bao gồm chúng trong các thông điệp chẩn đoán. Tránh các lần xác thực lặp lại không cần thiết, và chỉ giữ mật khẩu trong bộ nhớ trong thời gian cần thiết.

{{% alert color="info" title="Xem thêm" %}}
- [Bảo vệ mật khẩu cho bản trình chiếu](/slides/vi/php-java/password-protected-presentation/)
- [Bản trình chiếu chỉ đọc](/slides/vi/php-java/read-only-presentation/)
- [Chữ ký số trong PowerPoint](/slides/vi/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Bảo vệ ghi có mã hoá bản trình chiếu không?**

Không. Nó chỉ hạn chế việc chỉnh sửa nhưng vẫn cho phép nội dung bản trình chiếu được tải và xem.

**Mật khẩu bảo vệ ghi có bắt buộc để mở một bản trình chiếu không?**

Không. Chỉ cần mật khẩu mở để tải nội dung bản trình chiếu đã mã hoá.

**Một bản trình chiếu có thể có cả mật khẩu mở và mật khẩu bảo vệ ghi không?**

Có. Cung cấp mật khẩu mở qua các tùy chọn tải để mở bản trình chiếu đã mã hoá, và xác thực mật khẩu bảo vệ ghi riêng khi cần quyền chỉnh sửa.