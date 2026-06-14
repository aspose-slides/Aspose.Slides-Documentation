---
title: Quản lý Thuộc tính Bản trình bày trong PHP
linktitle: Thuộc tính Bản trình bày
type: docs
weight: 70
url: /vi/php-java/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- thuộc tính bản trình bày
- thuộc tính tài liệu
- thuộc tính tích hợp
- thuộc tính tùy chỉnh
- thuộc tính nâng cao
- quản lý thuộc tính
- sửa đổi thuộc tính
- siêu dữ liệu tài liệu
- chỉnh sửa siêu dữ liệu
- ngôn ngữ kiểm tra chính tả
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Quản lý toàn diện các thuộc tính bản trình bày trong Aspose.Slides cho PHP via Java và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý dễ dàng bằng API của Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với thuộc tính tài liệu của bản trình bày thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/). Một thể hiện của lớp này được trả về bởi phương thức [Presentation::getDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDocumentProperties). Các ví dụ dưới đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="primary" %}} 

Lưu ý rằng các trường **Application** và **Producer** không thể được sửa đổi, vì các trường này luôn hiển thị "Aspose Ltd." và "Aspose.Slides for PHP via Java x.x.x".

{{% /alert %}} 

## **Quản lý Thuộc tính Bản trình bày**

Microsoft PowerPoint cung cấp tính năng thêm một số thuộc tính vào các tệp bản trình bày. Các thuộc tính tài liệu này cho phép lưu trữ một số thông tin hữu ích cùng với tài liệu (tệp bản trình bày). Có hai dạng thuộc tính tài liệu như sau

- Thuộc tính Được Định Nghĩa Hệ Thống (Built-in)
- Thuộc tính Do Người Dùng Định Nghĩa (Custom)

Các thuộc tính **Built-in** chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, v.v. Các thuộc tính **Custom** là những thuộc tính được người dùng định nghĩa dưới dạng các cặp **Tên/Giá trị**, trong đó cả tên và giá trị đều do người dùng xác định. Sử dụng Aspose.Slides for PHP via Java, các nhà phát triển có thể truy cập và sửa đổi giá trị của cả thuộc tính built‑in và custom.

## **Thuộc tính Tài liệu trong PowerPoint**

Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp bản trình bày. Tất cả những gì bạn cần làm là nhấp vào biểu tượng Office và chọn **Prepare | Properties | Advanced Properties** trong PowerPoint 2007 như hình dưới:

|**Chọn mục Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Sau khi chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint như trong hình dưới:

|**Hộp thoại Thuộc tính**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Trong **Hộp thoại Thuộc tính** trên, bạn sẽ thấy nhiều trang tab như **General**, **Summary**, **Statistics**, **Contents** và **Custom**. Tất cả các trang này cho phép cấu hình các loại thông tin khác nhau liên quan đến tệp PowerPoint. Trang **Custom** được dùng để quản lý các thuộc tính tùy chỉnh của tệp PowerPoint.

## **Làm việc với Thuộc tính Tài liệu bằng Aspose.Slides for PHP via Java**

Như đã mô tả ở trên, Aspose.Slides for PHP via Java hỗ trợ hai loại thuộc tính tài liệu, đó là **Built-in** và **Custom**. Vì vậy, các nhà phát triển có thể truy cập cả hai loại thuộc tính bằng API của Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java cung cấp lớp [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties) đại diện cho các thuộc tính tài liệu gắn với tệp bản trình bày thông qua thuộc tính **Presentation.DocumentProperties**.

Các nhà phát triển có thể sử dụng thuộc tính **DocumentProperties** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) để truy cập các thuộc tính tài liệu của tệp bản trình bày như mô tả dưới đây:

## **Truy cập Thuộc tính Built‑in**

Các thuộc tính được cung cấp bởi đối tượng [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties) bao gồm: **Creator** (Tác giả), **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in lần cuối), **LastModifiedBy**, **SharedDoc** (Có được chia sẻ giữa các nhà sản xuất khác không?), **PresentationFormat**, **Subject** và **Title**.

```php
  # Tạo một đối tượng Presentation đại diện cho bản trình bày
  $pres = new Presentation("Presentation.pptx");
  try {
    # Tạo một tham chiếu tới đối tượng IDocumentProperties liên quan tới Presentation
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

## **Sửa đổi Thuộc tính Built‑in**

Việc sửa đổi các thuộc tính built‑in của tệp bản trình bày dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được cập nhật. Trong ví dụ dưới đây, chúng tôi đã trình bày cách sửa đổi các thuộc tính tài liệu built‑in của tệp bản trình bày bằng Aspose.Slides for PHP via Java.

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
    # Lưu bản trình bày của bạn vào một tệp
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ví dụ này sửa đổi các thuộc tính built‑in của bản trình bày và có thể xem kết quả như sau:

|**Thuộc tính tài liệu Built‑in sau khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Thêm Thuộc tính Tài liệu Tùy chỉnh**

Aspose.Slides for PHP via Java cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho thuộc tính tài liệu của bản trình bày. Một ví dụ được đưa ra dưới đây cho thấy cách đặt các thuộc tính tùy chỉnh cho một bản trình bày.

```php
  $pres = new Presentation();
  try {
    # Lấy Thuộc tính Tài liệu
    $dProps = $pres->getDocumentProperties();
    # Thêm các thuộc tính Tùy chỉnh
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Lấy tên thuộc tính tại chỉ mục cụ thể
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Xóa thuộc tính đã chọn
    $dProps->removeCustomProperty($getPropertyName);
    # Lưu bản trình bày
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Thuộc tính Tài liệu Custom Được Thêm**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Truy cập và Sửa đổi Thuộc tính Custom**

Aspose.Slides for PHP via Java cũng cho phép các nhà phát triển truy cập giá trị của các thuộc tính tùy chỉnh. Một ví dụ dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh cho một bản trình bày.

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
    # Lưu bản trình bày của bạn vào một tệp
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ví dụ này sửa đổi các thuộc tính tùy chỉnh của [PPTX](https://docs.fileformat.com/presentation/pptx/) presentation. Các hình dưới đây cho thấy các thuộc tính tùy chỉnh của bản trình bày trước và sau khi sửa đổi:

|**Thuộc tính Custom trước khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Thuộc tính Custom sau khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Thuộc tính Tài liệu Nâng cao**

{{% alert color="primary" %}} 

Các phương thức mới [readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) và [writeBindedPresentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) đã được thêm vào lớp [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo); logic của bộ thiết lập thuộc tính [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#setLastSavedTime) đã được thay đổi.

{{% /alert %}} 

Hai phương thức mới [readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) và [updateDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) đã được thêm vào lớp [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo). Chúng cung cấp cách truy cập nhanh vào các thuộc tính tài liệu và cho phép thay đổi, cập nhật thuộc tính mà không cần tải toàn bộ bản trình bày.

Kịch bản điển hình là tải thuộc tính, thay đổi một số giá trị và cập nhật tài liệu có thể được thực hiện như sau:

```php
  # đọc thông tin của bản trình bày
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # lấy các thuộc tính hiện tại
  $props = $info->readDocumentProperties();
  # đặt giá trị mới cho các trường Tác giả và Tiêu đề
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # cập nhật bản trình bày với các giá trị mới
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Có một cách khác để sử dụng các thuộc tính của một bản trình bày cụ thể làm mẫu để cập nhật thuộc tính trong các bản trình bày khác:

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

Một mẫu mới có thể được tạo từ đầu và sau đó dùng để cập nhật nhiều bản trình bày:

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

## **Thiết lập Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp thuộc tính LanguageId (được giới thiệu bởi lớp PortionFormat) để cho phép bạn thiết lập ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà PowerPoint sẽ kiểm tra lỗi chính tả và ngữ pháp.

Mã PHP này cho bạn thấy cách thiết lập ngôn ngữ kiểm tra chính tả cho PowerPoint: xxx Tại sao LanguageId lại không có trong lớp Java PortionFormat?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// đặt Id của ngôn ngữ kiểm tra chính tả

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thiết lập Ngôn ngữ Mặc định**

Mã PHP này cho bạn thấy cách thiết lập ngôn ngữ mặc định cho toàn bộ bản trình bày PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Thêm một hình chữ nhật mới với văn bản
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

Thử dùng ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với thuộc tính tài liệu qua API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi Thường gặp**

**Làm sao tôi có thể xóa một thuộc tính built‑in khỏi bản trình bày?**

Các thuộc tính built‑in là một phần không thể tách rời của bản trình bày và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành chuỗi trống nếu thuộc tính cụ thể cho phép.

**Nếu tôi thêm một thuộc tính custom đã tồn tại thì sẽ sao?**

Nếu bạn thêm một thuộc tính custom đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình bày mà không tải toàn bộ bản trình bày không?**

Có, bạn có thể truy cập các thuộc tính bản trình bày mà không tải toàn bộ bản trình bày bằng cách sử dụng phương thức `getPresentationInfo` từ lớp [PresentationFactory](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/). Sau đó, sử dụng phương thức `readDocumentProperties` được cung cấp bởi lớp [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/) để đọc các thuộc tính một cách hiệu quả, tiết kiệm bộ nhớ và cải thiện hiệu năng.