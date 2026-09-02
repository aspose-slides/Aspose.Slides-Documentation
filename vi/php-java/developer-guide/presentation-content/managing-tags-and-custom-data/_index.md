---
title: Quản lý thẻ và dữ liệu tùy chỉnh trong bản trình bày bằng PHP
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/php-java/managing-tags-and-custom-data/
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- XML tùy chỉnh
- phần XML tùy chỉnh
- siêu dữ liệu XML
- ItemId
- thêm thẻ
- cặp giá trị
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong bản trình bày PowerPoint với Aspose.Slides cho PHP qua Java, bao gồm việc thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình bày PowerPoint. Dữ liệu riêng của bản trình bày có thể được lưu trữ dưới dạng thẻ hoặc phần XML tùy chỉnh. Thẻ là các cặp chuỗi khóa‑giá trị đơn giản, trong khi phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và các tải XML đặc thù cho ứng dụng.

Aspose.Slides cung cấp các API để thêm, đọc, cập nhật, kiểm tra và xóa phần XML tùy chỉnh ở mức bản trình bày, slide và shape. Phần XML tùy chỉnh hữu ích cho các tích hợp lưu thông tin như định danh quản lý tài liệu, trạng thái quy trình, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu hoặc bất kỳ dữ liệu ứng dụng có cấu trúc nào khác bên trong bản trình bày.

## **Lưu trữ dữ liệu trong tệp trình chiếu**

Các tệp PPTX—các tệp có phần mở rộng `.pptx`—được lưu trong định dạng PresentationML, một phần của chuẩn Office Open XML. Office Open XML định nghĩa cấu trúc gói và các mối quan hệ được dùng để lưu nội dung trình chiếu và dữ liệu liên quan.

Một bản trình bày chứa nhiều phần được kết nối bằng các mối quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các mối quan hệ rõ ràng tới các phần khác được định nghĩa bởi ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([TagCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/)) hoặc phần XML tùy chỉnh ([CustomXmlPartCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpartcollection/)). Cả hai đều được truy cập thông qua lớp [`CustomData`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Thẻ lưu trữ các cặp khóa‑giá trị chuỗi đơn giản. Phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được liên kết với một bản trình bày, slide hoặc shape.
{{% /alert %}}

## **Làm việc với Custom XML Parts**

Phương thức [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customdata/#getCustomXmlParts) trả về bộ sưu tập các phần XML tùy chỉnh liên kết với một đối tượng bản trình bày cụ thể. Ví dụ:

- `$presentation->getCustomData()->getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với chính bản trình bày.
- `$slide->getCustomData()->getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một slide cụ thể.
- `$shape->getCustomData()->getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một shape cụ thể.

Sử dụng [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getAllCustomXmlParts) khi bạn cần kiểm tra tất cả các phần XML tùy chỉnh trong bản trình bày bất kể chúng được liên kết ở đâu.

### **Thêm Custom XML Part vào một Presentation**

Dùng [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpartcollection/#add) để thêm dữ liệu XML vào bộ sưu tập phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào bộ sưu tập dữ liệu tùy chỉnh ở mức presentation:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add tự động gán một định danh. Chỉ đặt UUID cụ thể khi cần thiết.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Phương thức `add` cũng có thể nhận XML dưới dạng mảng byte hoặc luồng đầu vào, hữu ích khi nội dung XML đã có dạng nhị phân.

### **Thêm Custom XML Part vào Slide hoặc Shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bản trình bày. Điều này hữu ích khi siêu dữ liệu chỉ mô tả một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi bên ngoài hoặc thông tin ràng buộc.

Ví dụ sau thêm một phần XML tùy chỉnh vào một slide và một phần khác vào một shape:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mức mà một phần được thêm sẽ quyết định bộ sưu tập `getCustomData()->getCustomXmlParts()` của đối tượng nào chứa mối quan hệ tới phần đó. Dữ liệu ở mức presentation phù hợp cho siêu dữ liệu toàn tài liệu, dữ liệu ở mức slide cho thông tin thuộc một slide cụ thể, và dữ liệu ở mức shape cho siêu dữ liệu gắn với một shape riêng lẻ.

### **Liệt kê và Kiểm tra tất cả Custom XML Parts**

Sử dụng [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getAllCustomXmlParts) để lấy tất cả các phần XML tùy chỉnh từ một bản trình bày. Mỗi [`CustomXmlPart`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpart/) cung cấp định danh, nội dung XML và các namespace schema liên quan.

Ví dụ sau liệt kê mọi phần XML tùy chỉnh và các namespace schema của chúng:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) trả về các schema XML được liên kết với phần XML tùy chỉnh. Thông tin này có thể hữu ích khi kiểm tra các bản trình bày chứa XML được tạo bởi hệ thống bên ngoài.

### **Đọc và Cập nhật nội dung XML và ItemId**

Dùng [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpart/#getXmlAsString) và [`setXmlAsString()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpart/#setXmlAsString) để làm việc với XML dưới dạng chuỗi UTF‑8, hoặc dùng [`getXmlData()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpart/#getXmlData) và [`setXmlData()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpart/#setXmlData) để làm việc với các byte XML thô.

Phương thức [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpart/#getItemId) trả về UUID xác định phần XML tùy chỉnh trong tài liệu Office Open XML. Dùng [`setItemId()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpart/#setItemId) khi một tích hợp yêu cầu định danh mới.

Ví dụ sau cập nhật nội dung XML và định danh:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Đọc XML hiện tại dưới dạng văn bản.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Cập nhật XML dưới dạng chuỗi UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData cung cấp cùng nội dung XML dưới dạng byte thô.
    $customXmlData = $customXmlPart->getXmlData();

    // Thay thế định danh khi tích hợp yêu cầu.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Khi gọi `setXmlAsString` hoặc `setXmlData`, cung cấp XML hợp lệ, không rỗng. Chọn một trong hai cách biểu diễn tùy thuộc vào việc ứng dụng làm việc chủ yếu với chuỗi hay dữ liệu byte.

### **Xóa một Custom XML Part**

Aspose.Slides cung cấp nhiều cách để xóa dữ liệu XML tùy chỉnh:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpart/#remove) xóa phần XML tùy chỉnh khỏi bản trình bày.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpartcollection/#remove) xóa một phần cụ thể khỏi bộ sưu tập phần XML tùy chỉnh.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpartcollection/#removeAt) xóa phần tại một chỉ mục bộ sưu tập được chỉ định.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpartcollection/#clear) xóa tất cả các phần khỏi một bộ sưu tập cụ thể.

Ví dụ sau xóa một phần XML tùy chỉnh ở mức presentation bằng tham chiếu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nếu bạn đã có một `CustomXmlPart` và muốn xóa phần đó khỏi bản trình bày thay vì thao tác trên một bộ sưu tập cụ thể, gọi `$customXmlPart->remove()`.

Bạn cũng có thể xóa một mục theo chỉ mục:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Xóa toàn bộ Custom XML Parts từ một Bộ sưu tập**

Dùng `clear` khi mọi phần XML tùy chỉnh liên kết với một đối tượng bản trình bày cụ thể cần được xóa.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` chỉ ảnh hưởng tới bộ sưu tập đã chọn. Ví dụ, xóa bộ sưu tập của một slide sẽ không xóa các bộ sưu tập ở mức presentation hoặc shape.

Để xóa mọi phần XML tùy chỉnh trong bản trình bày, lặp qua `getAllCustomXmlParts()` và xóa từng phần:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Xử lý các Custom XML Parts được Liên kết hoặc Chia sẻ**

Trong một bản trình chiếu Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ hơn một đối tượng bản trình bày. Ví dụ, một tệp hiện có thể chứa các mối quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh nền tảng.

Một phần được chia sẻ nên được coi là một đối tượng dữ liệu duy nhất với nhiều tham chiếu:

- Cập nhật nó bằng `setXmlAsString`, `setXmlData` hoặc `setItemId` sẽ thay đổi phần XML tùy chỉnh nền tảng, vì vậy thay đổi sẽ áp dụng ở mọi nơi mà phần này được tham chiếu.
- `getItemId()` có thể được dùng để xác định cùng một phần XML tùy chỉnh khi kiểm tra các bộ sưu tập ở mức đối tượng.
- Xóa một phần khỏi một bộ sưu tập `getCustomXmlParts()` cụ thể sẽ chỉ xóa nó khỏi bộ sưu tập đó. Dùng `CustomXmlPart::remove()` khi phần tự nó cần được xóa khỏi toàn bộ bản trình bày.
- Trước khi xóa hoặc thay thế một phần được chia sẻ, kiểm tra các bộ sưu tập ở mức đối tượng để xác định liệu các slide hoặc shape khác còn tham chiếu tới nó hay không.

Các overload của `add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một `CustomXmlPart` hiện có. Do đó, các mối quan hệ chia sẻ thường xuất hiện khi tải các bản trình bày đã chứa chúng.

Ví dụ sau kiểm tra các bộ sưu tập ở mức presentation, slide và shape bằng `ItemId` và báo cáo các phần được tham chiếu từ hơn một vị trí:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Loại kiểm tra này hữu ích trước khi sửa đổi hoặc xóa dữ liệu XML tùy chỉnh trong các bản trình bày do hệ thống bên ngoài tạo, vì cùng một phần siêu dữ liệu có thể tham gia vào nhiều mối quan hệ.

## **Lấy Giá trị của Thẻ**

Trong slides, một thẻ tương ứng với phương thức `DocumentProperties::getKeywords()`. Đoạn mã mẫu này cho thấy cách lấy giá trị thẻ bằng Aspose.Slides cho PHP via Java cho [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Thêm Thẻ vào Presentation**

Aspose.Slides cho phép bạn thêm thẻ vào presentation. Một thẻ thường gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ `My Tag Value`.

Nếu bạn cần phân loại các presentation dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại các presentation từ các quốc gia Bắc Mỹ, bạn có thể tạo một thẻ North American và gán quốc gia tương ứng làm giá trị.

Đoạn mã mẫu này cho thấy cách thêm thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) bằng Aspose.Slides cho PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Thẻ cũng có thể được đặt cho một [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Hoặc cho một [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) riêng lẻ:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Giới hạn**

Các thẻ được thêm thông qua bộ sưu tập `getCustomData()->getTags()` chỉ được lưu trong file PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi xuất bản trình bày sang PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được truy xuất từ PDF có thẻ.

**Giải pháp thay thế**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ `$shape->setAlternativeText("MyId")`). Sau khi xuất sang PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa mọi thẻ khỏi một presentation, slide hoặc shape trong một thao tác duy nhất không?**

Có. Bộ sưu tập thẻ ([tag collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/)) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/#clear) để xóa tất cả các cặp khóa‑giá trị cùng một lúc.

**Làm sao để xóa một thẻ duy nhất theo tên mà không cần lặp qua toàn bộ bộ sưu tập?**

Dùng `remove(name)` trên [tag collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Dùng `getNamesOfTags` trên [tag collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả tên thẻ.

**Làm sao tôi có thể tìm tất cả các Custom XML Parts bất kể chúng được lưu ở đâu?**

Dùng [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getAllCustomXmlParts) để lấy mọi phần XML tùy chỉnh trong bản trình bày.

**Nên dùng `getXmlAsString`/`setXmlAsString` hay `getXmlData`/`setXmlData` để cập nhật một Custom XML Part?**

Dùng `getXmlAsString` và `setXmlAsString` khi ứng dụng làm việc với văn bản XML UTF‑8. Dùng `getXmlData` và `setXmlData` khi XML đã có dưới dạng mảng byte hoặc khi việc xử lý dạng nhị phân thuận tiện hơn. Cả hai cách biểu diễn đều tham chiếu tới nội dung XML của cùng một Custom XML Part.