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
- Chỉnh sửa thuộc tính
- Siêu dữ liệu tài liệu
- Chỉnh sửa siêu dữ liệu
- Ngôn ngữ kiểm tra chính tả
- Ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý toàn diện các thuộc tính bản trình chiếu trong Aspose.Slides cho PHP via Java và tối ưu hoá tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể dễ dàng truy cập và quản lý bằng API của Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/). Một thể hiện của lớp này được trả về bởi phương thức [Presentation::getDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDocumentProperties). Các ví dụ sau cho thấy cách đọc, chỉnh sửa và quản lý các thuộc tính này.

{{% alert color="info" title="Lưu ý" %}}
Lưu ý rằng các trường **Application** và **AppVersion** không thể được chỉnh sửa. Aspose.Slides ghi lại chúng mỗi khi lưu, vì vậy bản trình chiếu đã lưu luôn báo cáo "Aspose.Slides for PHP via Java" và phiên bản của thư viện đã tạo ra nó. Bất kỳ giá trị nào được truyền vào `setNameOfApplication` sẽ bị bỏ qua khi bản trình chiếu được ghi.
{{% /alert %}} 

## **Quản lý Thuộc tính Bản trình chiếu**

Microsoft PowerPoint cung cấp tính năng để thêm một số thuộc tính vào các tệp bản trình chiếu. Các thuộc tính tài liệu này cho phép một số thông tin hữu ích được lưu cùng với tài liệu (các tệp bản trình chiếu). Có hai loại thuộc tính tài liệu như sau

- Thuộc tính Được Định Nghĩa Hệ Thống (Built-in)
- Thuộc tính Được Định Nghĩa Người Dùng (Custom)

Các thuộc tính **Built-in** chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, v.v. Các thuộc tính **Custom** là những thuộc tính được người dùng định nghĩa dưới dạng cặp **Tên/Giá trị**, trong đó cả tên và giá trị đều do người dùng xác định. Sử dụng Aspose.Slides for PHP via Java, các nhà phát triển có thể truy cập và chỉnh sửa giá trị của các thuộc tính built-in cũng như custom.

## **Thuộc tính Tài liệu trong PowerPoint**

Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp bản trình chiếu. Bạn chỉ cần nhấp vào biểu tượng Office và sau đó mục menu **Prepare | Properties | Advanced Properties** của Microsoft PowerPoint 2007 như hình dưới đây:

|**Chọn mục menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Sau khi bạn chọn mục menu **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint như hình dưới đây:

|**Hộp thoại Thuộc tính**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Trong **Hộp thoại Thuộc tính** ở trên, bạn có thể thấy có nhiều trang tab như **General**, **Summary**, **Statistics**, **Contents** và **Custom**. Tất cả các trang tab này cho phép cấu hình các loại thông tin khác nhau liên quan đến các tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính tùy chỉnh của các tệp PowerPoint.

Làm việc với Thuộc tính Tài liệu bằng Aspose.Slides for PHP via Java

Như đã mô tả ở trên, Aspose.Slides for PHP via Java hỗ trợ hai loại thuộc tính tài liệu, đó là các thuộc tính **Built-in** và **Custom**. Do đó, các nhà phát triển có thể truy cập cả hai loại thuộc tính này bằng API của Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java cung cấp một lớp [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties) đại diện cho các thuộc tính tài liệu liên kết với một tệp bản trình chiếu thông qua thuộc tính **Presentation.DocumentProperties**.

Các nhà phát triển có thể sử dụng thuộc tính **DocumentProperties** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) để truy cập các thuộc tính tài liệu của các tệp bản trình chiếu như mô tả bên dưới:

## **Truy cập Thuộc tính Built-in**

Các thuộc tính được cung cấp bởi đối tượng [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties) bao gồm: **Creator** (Tác giả), **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in lần cuối), **LastModifiedBy**, **Keywords**, **SharedDoc** (Có được chia sẻ giữa các nhà sản xuất khác nhau không?), **PresentationFormat**, **Subject** và **Title**

```php
  # Khởi tạo lớp Presentation đại diện cho bản trình chiếu
  $pres = new Presentation("Presentation.pptx");
  try {
    # Tạo tham chiếu tới đối tượng IDocumentProperties liên kết với Presentation
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

## **Chỉnh sửa Thuộc tính Built-in**

Việc chỉnh sửa các thuộc tính built-in của các tệp bản trình chiếu cũng dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách chúng ta có thể chỉnh sửa các thuộc tính tài liệu built-in của tệp bản trình chiếu bằng Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Tạo tham chiếu tới đối tượng IDocumentProperties liên kết với Presentation
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

Ví dụ này chỉnh sửa các thuộc tính built-in của bản trình chiếu và có thể xem như hình dưới đây:

|**Thuộc tính tài liệu Built-in sau khi chỉnh sửa**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Thêm Thuộc tính Tài liệu Tùy chỉnh**

Aspose.Slides for PHP via Java cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho các thuộc tính tài liệu của bản trình chiếu. Một ví dụ được đưa ra dưới đây cho thấy cách đặt các thuộc tính tùy chỉnh cho một bản trình chiếu.

```php
  $pres = new Presentation();
  try {
    # Lấy Thuộc tính Tài liệu
    $dProps = $pres->getDocumentProperties();
    # Thêm thuộc tính tùy chỉnh
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

|**Thuộc tính Tài liệu Tùy chỉnh Được Thêm**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Truy cập và Chỉnh sửa Thuộc tính Tùy chỉnh**

Aspose.Slides for PHP via Java cũng cho phép các nhà phát triển truy cập các giá trị của các thuộc tính tùy chỉnh. Một ví dụ được đưa ra dưới đây cho thấy cách bạn có thể truy cập và chỉnh sửa tất cả các thuộc tính tùy chỉnh này cho một bản trình chiếu.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Tạo tham chiếu tới đối tượng DocumentProperties liên kết với Presentation
    $dp = $pres->getDocumentProperties();
    # Truy cập và chỉnh sửa các thuộc tính tùy chỉnh
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Hiển thị tên và giá trị của các thuộc tính tùy chỉnh
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Chỉnh sửa giá trị của các thuộc tính tùy chỉnh
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

Ví dụ này chỉnh sửa các thuộc tính tùy chỉnh của bản trình chiếu [PPTX ](https://docs.fileformat.com/presentation/pptx/). Các hình dưới đây cho thấy các thuộc tính tùy chỉnh của bản trình chiếu trước và sau khi chỉnh sửa:

|**Thuộc tính Tùy chỉnh trước Khi chỉnh sửa**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Thuộc tính Tùy chỉnh sau Khi chỉnh sửa**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Thuộc tính Tài liệu Nâng cao**

{{% alert color="info" title="Lưu ý" %}}
Các phương thức mới [readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) và [writeBindedPresentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) đã được thêm vào [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo), logic của bộ thiết lập thuộc tính [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#setLastSavedTime) đã được thay đổi.
{{% /alert %}} 

Hai phương thức mới [readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) và [updateDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) đã được thêm vào lớp [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo). Chúng cung cấp cách truy cập nhanh vào các thuộc tính tài liệu và cho phép thay đổi và cập nhật các thuộc tính mà không cần tải toàn bộ bản trình chiếu.

Kịch bản điển hình tải các thuộc tính, thay đổi một số giá trị và cập nhật tài liệu có thể được thực hiện theo cách sau:

```php
  # đọc thông tin của bản trình chiếu
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # lấy các thuộc tính hiện tại
  $props = $info->readDocumentProperties();
  # đặt các giá trị mới cho các trường Tác giả và Tiêu đề
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # cập nhật bản trình chiếu với các giá trị mới
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Có một cách khác để sử dụng các thuộc tính của một bản trình chiếu cụ thể làm mẫu để cập nhật các thuộc tính trong các bản trình chiếu khác:

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

Mã PHP này cho bạn thấy cách đặt ngôn ngữ kiểm tra chính tả cho PowerPoint: xxx Tại sao LanguageId lại thiếu trong lớp Java PortionFormat?

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

Thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu qua API của Aspose.Slides:

[![Xem & Chỉnh sửa Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xóa một thuộc tính built-in khỏi bản trình chiếu?**

Các thuộc tính built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/) và sau đó [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) để đọc siêu dữ liệu tài liệu đã lưu mà không cần tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Xem [Build a Lightweight Presentation Inventory](/slides/vi/php-java/examine-presentation/) để biết một ví dụ báo cáo đầy đủ và các giới hạn theo định dạng.