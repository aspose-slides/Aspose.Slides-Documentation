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
- Thuộc tính tích hợp
- Thuộc tính tùy chỉnh
- Thuộc tính nâng cao
- Quản lý thuộc tính
- Sửa đổi thuộc tính
- Siêu dữ liệu tài liệu
- Chỉnh sửa siêu dữ liệu
- Ngôn ngữ kiểm tra chính tả
- Ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý các thuộc tính bản trình chiếu trong Aspose.Slides cho PHP qua Java và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý dễ dàng bằng API của Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/) . Một thể hiện của lớp này được trả về bởi phương thức [Presentation::getDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDocumentProperties) . Các ví dụ sau cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Lưu ý" %}}
Vui lòng lưu ý rằng các trường **Application** và **AppVersion** không thể sửa đổi. Aspose.Slides ghi lại chúng mỗi khi lưu, vì vậy một bản trình chiếu đã lưu luôn báo "Aspose.Slides for PHP via Java" và phiên bản của thư viện đã tạo ra nó. Bất kỳ giá trị nào được truyền cho `setNameOfApplication` đều bị bỏ qua khi bản trình chiếu được ghi.
{{% /alert %}} 

## **Quản lý Thuộc tính Bản trình chiếu**

Microsoft PowerPoint cung cấp tính năng thêm một số thuộc tính vào các tệp bản trình chiếu. Các thuộc tính tài liệu này cho phép lưu trữ một số thông tin hữu ích cùng với tài liệu (tệp trình chiếu). Có hai loại thuộc tính tài liệu như sau

- Thuộc tính Định nghĩa Hệ thống (Built-in)
- Thuộc tính Người dùng Định nghĩa (Custom)

Các thuộc tính **Built-in** chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, v.v. Các thuộc tính **Custom** là những thuộc tính do người dùng định nghĩa dưới dạng cặp **Tên/Giá trị**, trong đó cả tên và giá trị đều do người dùng chỉ định. Sử dụng Aspose.Slides for PHP via Java, các nhà phát triển có thể truy cập và sửa đổi các giá trị của cả thuộc tính Built‑in và Custom.

## **Thuộc tính Tài liệu trong PowerPoint**

Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp trình chiếu. Bạn chỉ cần nhấp vào biểu tượng Office và sau đó vào mục **Prepare | Properties | Advanced Properties** của Microsoft PowerPoint 2007 như hình dưới đây:

|**Chọn mục Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| ** **|

Sau khi bạn chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint như hình dưới đây:

|**Hộp thoại Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| ** **|
Trong **Hộp thoại Properties** trên, bạn có thể thấy có nhiều trang tab như **General**, **Summary**, **Statistics**, **Contents** và **Custom**. Tất cả các trang này cho phép cấu hình các loại thông tin khác nhau liên quan đến các tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính tùy chỉnh của các tệp PowerPoint.

### Làm việc với Thuộc tính Tài liệu bằng Aspose.Slides for PHP via Java

Như đã mô tả ở trên, Aspose.Slides for PHP via Java hỗ trợ hai loại thuộc tính tài liệu, đó là **Built-in** và **Custom**. Do đó, các nhà phát triển có thể truy cập cả hai loại thuộc tính này bằng API của Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java cung cấp lớp [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties) đại diện cho các thuộc tính tài liệu liên kết với một tệp trình chiếu thông qua thuộc tính **Presentation.DocumentProperties**.

Các nhà phát triển có thể sử dụng thuộc tính **DocumentProperties** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) để truy cập các thuộc tính tài liệu của các tệp trình chiếu như mô tả dưới đây:

## **Đọc Thuộc tính Công khai từ Bản trình chiếu Được Mã hoá**

Mật khẩu mở thường bảo vệ cả nội dung trình chiếu và các thuộc tính tài liệu. Khi một bản trình chiếu được mã hoá bằng cách truyền `false` vào [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), các thuộc tính tài liệu của nó vẫn công khai. Ứng dụng sau đó có thể truyền `true` vào [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) và đọc siêu dữ liệu công khai mà không cần cung cấp mật khẩu mở.

Tuỳ chọn chỉ tải tài liệu‑properties chỉ kiểm soát những gì Aspose.Slides tải; nó không giải mã bất kỳ gì. Nếu các thuộc tính đã được bao gồm trong quá trình mã hoá, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình chiếu không được mã hoá, tuỳ chọn này sẽ bị bỏ qua và toàn bộ bản trình chiếu sẽ được tải.

Ví dụ sau xác minh chế độ tải thông qua [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) và sau đó đọc các thuộc tính built‑in qua [Presentation::getDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

Trong chế độ này, nội dung slide không được tải. Slides, masters, layouts, shapes, media và các đối tượng trình chiếu khác không khả dụng. Các ứng dụng luôn nên kiểm tra [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/vi/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) trước khi thực hiện bất kỳ thao tác nào yêu cầu mô hình đối tượng trình chiếu đầy đủ.

{{% alert color="warning" title="Cảnh báo" %}}
Siêu dữ liệu công khai có thể lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và các giá trị tùy chỉnh. Hãy mã hoá các thuộc tính nhạy cảm cùng với bản trình chiếu. Để chúng công khai chỉ khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu có yêu cầu cụ thể truy cập chúng mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật Thuộc tính của Bản trình chiếu Được Mã hoá**

Đối với tệp PPTX đã mã hoá, một bản trình chiếu được tải ở chế độ chỉ‑tài‑liệu‑properties nhằm mục đích đọc siêu dữ liệu công khai. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ‑tài‑liệu‑properties này vì các thuộc tính công khai phải luôn nhất quán với dữ liệu tương ứng bên trong bản trình chiếu đã mã hoá. Do đó, việc cập nhật chúng yêu cầu mật khẩu mở đúng và tải đầy đủ bản trình chiếu.

Ví dụ sau mở bản trình chiếu bằng [LoadOptions::setPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setPassword), cập nhật các thuộc tính built‑in công khai, và lưu kết quả. Sau đó dùng [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#isEncrypted) để xác minh rằng mã hoá vẫn được giữ và mở lại siêu dữ liệu công khai mà không cần mật khẩu để kiểm tra các giá trị mới:

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
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
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
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình chiếu, nó phải coi các thuộc tính công khai của tệp PPTX đã mã hoá là chỉ‑đọc.

## **Truy cập Thuộc tính Built-in**

Các thuộc tính được cung cấp bởi đối tượng [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties) bao gồm: **Creator** (Tác giả), **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in cuối cùng), **LastModifiedBy**, **SharedDoc** (Có được chia sẻ giữa các nhà sản xuất khác?), **PresentationFormat**, **Subject** và **Title**

```php
  # Khởi tạo lớp Presentation đại diện cho bản trình chiếu
  $pres = new Presentation("Presentation.pptx");
  try {
    # Tạo một tham chiếu tới đối tượng IDocumentProperties liên kết với Presentation
    $dp = $pres->getDocumentProperties();
    # Hiển thị các thuộc tính tích hợp
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sửa đổi Thuộc tính Built-in**

Việc sửa đổi các thuộc tính built‑in của tệp trình chiếu cũng đơn giản như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách sửa đổi các thuộc tính tài liệu built‑in của tệp trình chiếu bằng Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Tạo một tham chiếu tới đối tượng IDocumentProperties liên kết với Presentation
    $dp = $pres->getDocumentProperties();
    # Đặt các thuộc tính tích hợp
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Lưu bản trình chiếu của bạn vào tệp
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ví dụ này sửa đổi các thuộc tính built‑in của bản trình chiếu và có thể xem được như hình dưới:

|**Thuộc tính tài liệu built‑in sau khi sửa đổi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| ** **|

## **Thêm Thuộc tính Tài liệu Custom**

Aspose.Slides for PHP via Java cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho thuộc tính tài liệu của bản trình chiếu. Ví dụ dưới đây cho thấy cách đặt các thuộc tính tùy chỉnh cho một bản trình chiếu.

```php
  $pres = new Presentation();
  try {
    # Lấy Thuộc tính Tài liệu
    $dProps = $pres->getDocumentProperties();
    # Thêm các thuộc tính tùy chỉnh
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Lấy tên thuộc tính tại chỉ mục cụ thể
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Xóa thuộc tính đã chọn
    $dProps->removeCustomProperty($getPropertyName);
    # Lưu bản trình chiếu
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Thuộc tính Tài liệu Custom Đã Thêm**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| ** **|

## **Truy cập và Sửa đổi Thuộc tính Custom**

Aspose.Slides for PHP via Java cũng cho phép các nhà phát triển truy cập các giá trị của thuộc tính tùy chỉnh. Ví dụ dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh cho một bản trình chiếu.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Tạo một tham chiếu tới đối tượng DocumentProperties liên kết với Presentation
    $dp = $pres->getDocumentProperties();
    # Truy cập và sửa đổi các thuộc tính tùy chỉnh
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Hiển thị tên và giá trị của các thuộc tính tùy chỉnh
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Sửa đổi giá trị của các thuộc tính tùy chỉnh
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Lưu bản trình chiếu của bạn vào tệp
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ví dụ này sửa đổi các thuộc tính tùy chỉnh của bản trình chiếu [PPTX](https://docs.fileformat.com/presentation/pptx/). Các hình dưới đây cho thấy các thuộc tính tùy chỉnh của bản trình chiếu trước và sau khi sửa đổi:

|**Thuộc tính Custom trước khi sửa đổi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| ** **|

|**Thuộc tính Custom sau khi sửa đổi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| ** **|

## **Thuộc tính Tài liệu Nâng cao**

{{% alert color="info" title="Lưu ý" %}}
Các phương thức mới [readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) và [writeBindedPresentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) đã được thêm vào [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo), logic của bộ setter [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#setLastSavedTime) đã được thay đổi.
{{% /alert %}} 

Hai phương thức mới [readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) và [updateDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) đã được thêm vào lớp [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo). Chúng cung cấp truy cập nhanh vào các thuộc tính tài liệu và cho phép thay đổi, cập nhật thuộc tính mà không cần tải toàn bộ bản trình chiếu.

Kịch bản điển hình là tải các thuộc tính, thay đổi một vài giá trị và cập nhật tài liệu có thể được thực hiện theo cách sau:

```php
  # đọc thông tin của bản trình chiếu
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # lấy các thuộc tính hiện tại
  $props = $info->readDocumentProperties();
  # đặt giá trị mới cho các trường Author và Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # cập nhật bản trình chiếu với các giá trị mới
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Có một cách khác để sử dụng các thuộc tính của một bản trình chiếu cụ thể như mẫu để cập nhật thuộc tính trong các bản trình chiếu khác:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Một mẫu mới có thể được tạo từ đầu và sau đó dùng để cập nhật nhiều bản trình chiếu:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Đặt Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp thuộc tính LanguageId (được phơi bày bởi lớp PortionFormat) để cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint sẽ được kiểm tra.

Mã PHP này cho bạn thấy cách đặt ngôn ngữ kiểm tra chính tả cho PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// đặt Id của ngôn ngữ kiểm tra chính tả

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt Ngôn ngữ Mặc định**

Mã PHP này cho bạn thấy cách đặt ngôn ngữ mặc định cho toàn bộ bản trình chiếu PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Thêm một hình chữ nhật mới có văn bản
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Kiểm tra ngôn ngữ của phần đầu tiên
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với thuộc tính tài liệu qua API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để xóa một thuộc tính built‑in khỏi bản trình chiếu?**

Các thuộc tính built‑in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Nếu tôi thêm một thuộc tính custom đã tồn tại thì sao?**

Nếu bạn thêm một thuộc tính custom đã tồn tại, giá trị hiện tại của nó sẽ được ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập thuộc tính của bản trình chiếu mà không tải đầy đủ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/) rồi [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) để đọc siêu dữ liệu tài liệu đã lưu mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) . Xem [Build a Lightweight Presentation Inventory](/slides/vi/php-java/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các giới hạn theo định dạng.

**Tôi có thể đọc các thuộc tính công khai của một bản trình chiếu đã mã hoá mà không có mật khẩu mở không?**

Có. Mã hoá thuộc tính tài liệu phải đã được tắt trước khi bản trình chiếu được mã hoá, và bản trình chiếu phải được tải ở chế độ chỉ‑tài‑liệu‑properties.

**Tôi có thể cập nhật tệp PPTX đã mã hoá ở chế độ chỉ‑tài‑liệu‑properties không?**

Không. Dữ liệu thuộc tính công khai và đã mã hoá phải luôn nhất quán, vì vậy việc cập nhật tệp PPTX đã mã hoá yêu cầu tải toàn bộ bản trình chiếu với mật khẩu mở đúng.