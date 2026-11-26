---
title: Quản lý Thuộc tính Bản trình chiếu trong PHP
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/php-java/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- Thuộc tính bản trình chiếu
- Thuộc tính tài liệu
- Thuộc tính dựng sẵn
- Thuộc tính tùy chỉnh
- Thuộc tính nâng cao
- Quản lý thuộc tính
- Sửa đổi thuộc tính
- Siêu dữ liệu tài liệu
- Chỉnh sửa siêu dữ liệu
- Ngôn ngữ kiểm tra
- Ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý toàn diện các thuộc tính bản trình chiếu trong Aspose.Slides cho PHP qua Java và tối ưu hoá tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides for PHP via Java hỗ trợ **built-in** và **custom** document properties. Sử dụng các thuộc tính này để đọc và cập nhật siêu dữ liệu của bản trình chiếu, chẳng hạn như tác giả, tiêu đề và các giá trị do người dùng định nghĩa.

Aspose.Slides cho phép bạn làm việc với thuộc tính tài liệu của bản trình chiếu thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/). Một thể hiện của lớp này được trả về bởi [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties). Các ví dụ sau minh họa cách đọc, sửa đổi và quản lý các thuộc tính này. Chúng giả định rằng PHP/Java Bridge và wrapper Aspose.Slides PHP đã được khởi tạo.

{{% alert color="info" title="Note" %}}

Aspose.Slides quản lý siêu dữ liệu ứng dụng và nhà sản xuất khi lưu bản trình chiếu; các trường này xác định phần mềm đã tạo ra đầu ra.

{{% /alert %}}

## **Quản lý Thuộc tính Bản trình chiếu**

Thuộc tính tài liệu lưu trữ thông tin mô tả bên cạnh nội dung bản trình chiếu. Chúng chia thành hai loại:

- **Built-in properties** chứa siêu dữ liệu tiêu chuẩn, chẳng hạn như tiêu đề, tác giả và thống kê tài liệu.
- **Custom properties** lưu trữ các cặp tên/giá trị do người dùng định nghĩa.

Aspose.Slides for PHP via Java cung cấp quyền truy cập vào cả hai loại. Trong PowerPoint, chọn **File → Info → Properties → Advanced Properties** để kiểm tra siêu dữ liệu tài liệu. Hộp thoại nhóm thông tin thành các thẻ như **Summary**, **Statistics**, **Contents**, và **Custom**. Sử dụng thẻ **Custom** để quản lý các thuộc tính do người dùng định nghĩa.

## **Đọc Thuộc tính Công cộng từ Bản trình chiếu Được Mã hoá**

Mật khẩu mở thường bảo vệ cả nội dung bản trình chiếu và thuộc tính tài liệu. Khi một bản trình chiếu được mã hoá sau khi gọi [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) với `false`, các thuộc tính tài liệu của nó vẫn ở chế độ công cộng. Ứng dụng sau đó có thể gọi [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) với `true` và đọc siêu dữ liệu công cộng mà không cần cung cấp mật khẩu mở.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) kiểm soát những gì Aspose.Slides tải; nó không giải mã bất kỳ thứ gì. Nếu các thuộc tính đã được bao gồm trong quá trình mã hoá, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình chiếu không được mã hoá, tùy chọn sẽ bị bỏ qua và toàn bộ bản trình chiếu sẽ được tải.

Ví dụ yêu cầu một bản trình chiếu được mã hoá mà các thuộc tính tài liệu của nó được để công cộng. Nó xác minh chế độ tải thông qua [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) và sau đó đọc các thuộc tính built‑in thông qua [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, shape, media và các đối tượng khác của bản trình chiếu không khả dụng. Ứng dụng nên luôn kiểm tra [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) trước khi thực hiện một thao tác đòi hỏi mô hình đối tượng bản trình chiếu đầy đủ.

{{% alert color="warning" title="Warning" %}}
Siêu dữ liệu công cộng có thể phô bày tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, nhận xét và các giá trị tùy chỉnh. Hãy mã hoá các thuộc tính nhạy cảm cùng với bản trình chiếu. Chỉ để chúng công cộng khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu có yêu cầu cụ thể để truy cập chúng mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật Thuộc tính của Bản trình chiếu Được Mã hoá**

Đối với tệp PPTX được mã hoá, một bản trình chiếu được tải sau khi gọi [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) với `true` chỉ nhằm mục đích đọc siêu dữ liệu công cộng. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ có siêu dữ liệu này vì các thuộc tính công cộng phải đồng nhất với dữ liệu tương ứng bên trong bản trình chiếu đã mã hoá. Do đó, việc cập nhật chúng yêu cầu mật khẩu mở đúng và tải toàn bộ bản trình chiếu.

Ví dụ yêu cầu một bản PPTX được mã hoá với các thuộc tính tài liệu công cộng và một mật khẩu mở đã biết. Nó mở toàn bộ bản trình chiếu bằng [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword), cập nhật các thuộc tính built‑in công cộng, và lưu kết quả. Sau đó sử dụng [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) để xác minh rằng mã hoá vẫn được giữ và mở lại siêu dữ liệu công cộng mà không cần mật khẩu để kiểm tra các giá trị mới:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình chiếu, nó phải coi các thuộc tính công cộng của tệp PPTX được mã hoá là chỉ đọc.

## **Truy cập Thuộc tính Built‑in**

Lớp [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) cung cấp siêu dữ liệu built‑in thông qua các phương thức getter, bao gồm [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle) và [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime). Ví dụ này mở một bản trình chiếu hiện có và in siêu dữ liệu đã lưu ra console. Các giá trị phụ thuộc vào bản trình chiếu đầu vào; một số trường có thể để trống.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

### **Báo cáo Số phiên bản và Thời gian chỉnh sửa**

Để báo cáo số phiên bản và tổng thời gian chỉnh sửa cho mỗi tệp PPTX trong thư mục `presentations`, sử dụng [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) để đọc [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) mà không tải các slide để chỉnh sửa. API PHP via Java trả về thời gian chỉnh sửa tính bằng mili giây. Ví dụ chuyển đổi nó sang giờ, phút và giây và bao gồm số ngày cho các khoảng thời gian từ 24 giờ trở lên.

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

Với một bản trình chiếu có số phiên bản 17 và thời gian chỉnh sửa được ghi là 1 ngày, 2 giờ và 5 phút, báo cáo sẽ hiển thị đầu ra sau:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) đọc một giá trị mà các ứng dụng có thể thay đổi bằng [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber). Số phiên bản đơn độc không thể xác định bao nhiêu lần bản trình chiếu đã được lưu hoặc tái tạo lịch sử phiên bản.

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) đọc thời lượng chỉnh sửa được ghi trong tệp. Một bản trình chiếu có thể có thời lượng lưu là 0 (`00:00:00`) ngay cả khi ai đó đã chỉnh sửa nó.

## **Sửa đổi Thuộc tính Built‑in**

Để cập nhật siêu dữ liệu built‑in, sử dụng các phương thức setter trên đối tượng trả về bởi [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties). Ví dụ này mở một bản trình chiếu hiện có, gọi [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments) và [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager), sau đó lưu bản trình chiếu đã cập nhật bằng [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). Tệp PPTX đã lưu sẽ chứa siêu dữ liệu mới.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Quản lý Hyperlink Base**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) trả về cơ sở tài liệu cho các siêu liên kết tương đối. Sử dụng [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) để thay đổi hoặc xóa bỏ nó. Điều này hữu ích khi di chuyển bản trình chiếu và các tệp liên kết sang vị trí khác. Nó riêng biệt với [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) của một siêu liên kết cá nhân: thay đổi cơ sở không ghi lại lại các địa chỉ liên kết đã lưu hoặc thay đổi đích tuyệt đối.

Ví dụ yêu cầu một bản trình chiếu chứa cả một liên kết tương đối, chẳng hạn `target.html`, và một liên kết tuyệt đối, chẳng hạn `https://example.org/absolute.html`. Nó đọc cơ sở hiện có, gán một địa chỉ cơ sở mới, và lưu và mở lại bản trình chiếu để kiểm tra giá trị. Sau đó xóa cơ sở bằng một chuỗi rỗng và xác minh giá trị rỗng trong một tệp đã lưu riêng. Thay địa chỉ cơ sở mẫu bằng vị trí các tệp liên kết của bạn.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Hai thông báo xác minh nên in ra `true`. Xóa cơ sở không làm thay đổi địa chỉ siêu liên kết cá nhân.

Một liên kết tương đối tới `target.pptx` đã mở `old/target.pptx` khi cơ sở trỏ tới thư mục `old`. Sau khi thay đổi cơ sở thành thư mục `new`, lưu và mở lại bản trình chiếu, cùng một liên kết sẽ mở `new/target.pptx`. Một liên kết tuyệt đối vẫn mở cùng tệp. Hãy kiểm tra các liên kết tương đối của bạn trong PowerPoint trước và sau khi di chuyển bản trình chiếu hoặc thay đổi cơ sở.

## **Thêm Thuộc tính Tùy chỉnh cho Bản trình chiếu**

Thuộc tính tùy chỉnh lưu trữ siêu dữ liệu không có trường built‑in tương ứng. Phương thức [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) cho phép bạn gán một giá trị bằng tên thuộc tính. Ví dụ này tạo một bản trình chiếu, thêm hai giá trị văn bản và một giá trị phiên bản nguyên, và lưu bản trình chiếu bằng [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). Gán một giá trị cho tên đã tồn tại sẽ thay thế giá trị của thuộc tính đó.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Ví dụ này mở một bản trình chiếu chứa các thuộc tính tùy chỉnh và sử dụng [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) để lặp qua chúng. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) nhận một chỉ số bắt đầu từ 0 và trả về tên được sử dụng bởi [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item). Ví dụ in mỗi tên và giá trị gốc, thay thế mọi giá trị bằng một chuỗi đánh số bất kể kiểu gốc, và lưu các thay đổi. Nếu không có thuộc tính tùy chỉnh nào, vòng lặp sẽ không thực hiện thay đổi nào.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ví dụ Trực tiếp**

Thử ứng dụng trực tuyến [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) để xem cách làm việc với thuộc tính tài liệu bằng API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để xóa một thuộc tính built‑in khỏi bản trình chiếu?**

Các thuộc tính built‑in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị thuộc tính.

**Tôi có thể truy cập thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) rồi [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) để đọc siêu dữ liệu tài liệu đã lưu mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Xem [Build a Lightweight Presentation Inventory](/slides/vi/php-java/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các giới hạn theo định dạng.

**Tôi có thể đọc các thuộc tính công cộng của bản trình chiếu đã mã hoá mà không có mật khẩu mở không?**

Có. Bản trình chiếu phải được mã hoá sau khi gọi [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) với `false`, và phải được tải sau khi gọi [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) với `true`.

**Tôi có thể cập nhật một tệp PPTX đã mã hoá ở chế độ chỉ tải tài liệu không?**

Không. Dữ liệu thuộc tính công cộng và được mã hoá phải đồng nhất, vì vậy việc cập nhật một tệp PPTX đã mã hoá yêu cầu tải toàn bộ bản trình chiếu với mật khẩu mở đúng.