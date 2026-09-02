---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình bày bằng JavaScript
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/nodejs-java/managing-tags-and-custom-data/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bản trình bày PowerPoint bằng Aspose.Slides cho Node.js thông qua Java, bao gồm việc thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides hoạt động với thẻ và dữ liệu tùy chỉnh trong các bản trình bày PowerPoint. Dữ liệu riêng của bản trình bày có thể được lưu dưới dạng thẻ hoặc các phần XML tùy chỉnh. Thẻ là các cặp chuỗi khóa-giá trị đơn giản, trong khi các phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và payload XML đặc thù của ứng dụng.

Aspose.Slides cung cấp API để thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh ở mức bản trình bày, slide và shape. Các phần XML tùy chỉnh hữu ích cho các tích hợp lưu trữ thông tin như định danh quản lý tài liệu, trạng thái quy trình công việc, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu, hoặc các dữ liệu ứng dụng có cấu trúc khác bên trong một bản trình bày.

## **Lưu trữ dữ liệu trong tệp Bản trình bày**

Các tệp PPTX—tệp có phần mở rộng `.pptx`—được lưu ở định dạng PresentationML, một phần của tiêu chuẩn Office Open XML. Office Open XML định nghĩa cấu trúc gói và các mối quan hệ được sử dụng để lưu trữ nội dung bản trình bày và dữ liệu liên quan.

Một bản trình bày chứa nhiều phần được kết nối bằng các mối quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các mối quan hệ rõ ràng với các phần khác được định nghĩa bởi ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([TagCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/)) hoặc các phần XML tùy chỉnh ([CustomXmlPartCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/customxmlpartcollection/)). Cả hai đều khả dụng thông qua lớp [`CustomData`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Thẻ lưu trữ các cặp khóa-giá trị chuỗi đơn giản. Các phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được gắn với một bản trình bày, slide hoặc shape.
{{% /alert %}}

## **Làm việc với các phần XML tùy chỉnh**

Phương thức `getCustomXmlParts()` của [`CustomData`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/customdata/) trả về bộ sưu tập các phần XML tùy chỉnh được liên kết với một đối tượng bản trình bày cụ thể. Ví dụ:

- `presentation.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với chính bản trình bày.
- `slide.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một slide cụ thể.
- `shape.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một shape cụ thể.

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) khi bạn cần kiểm tra tất cả các phần XML tùy chỉnh trong bản trình bày bất kể chúng được liên kết ở đâu.

### **Thêm một phần XML tùy chỉnh vào Bản trình bày**

Sử dụng phương thức `add` của [`CustomXmlPartCollection`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/customxmlpartcollection/) để thêm dữ liệu XML vào bộ sưu tập các phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào bộ sưu tập dữ liệu tùy chỉnh ở mức bản trình bày:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add tự động gán một định danh. Đặt UUID cụ thể chỉ khi cần.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phương thức `add` cũng có thể chấp nhận XML dưới dạng mảng byte, hữu ích khi nội dung XML đã có sẵn ở dạng nhị phân.

### **Thêm một phần XML tùy chỉnh vào Slide hoặc Shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bản trình bày. Điều này hữu ích khi siêu dữ liệu chỉ mô tả một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi bên ngoài, hoặc thông tin ràng buộc.

Ví dụ sau thêm một phần XML tùy chỉnh vào một slide và một phần khác vào một shape:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mức độ mà một phần được thêm quyết định bộ sưu tập `getCustomData().getCustomXmlParts()` của đối tượng nào chứa mối quan hệ tới phần đó. Dữ liệu ở mức bản trình bày phù hợp cho siêu dữ liệu toàn tài liệu, dữ liệu ở mức slide cho thông tin thuộc về một slide cụ thể, và dữ liệu ở mức shape cho siêu dữ liệu gắn với một shape riêng lẻ.

### **Liệt kê và Kiểm tra Tất cả các phần XML tùy chỉnh**

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) để lấy tất cả các phần XML tùy chỉnh từ một bản trình bày. Mỗi [`CustomXmlPart`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/customxmlpart/) hiển thị định danh, nội dung XML và các schema không gian tên liên quan.

Ví dụ sau liệt kê tất cả các phần XML tùy chỉnh và các schema không gian tên của chúng:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/customxmlpart/) trả về các schema XML liên quan tới phần XML tùy chỉnh. Thông tin này có thể hữu ích khi kiểm tra các bản trình bày chứa XML do hệ thống bên ngoài tạo ra.

### **Đọc và Cập nhật Nội dung XML và ItemId**

Sử dụng `getXmlAsString()` và `setXmlAsString()` từ [`CustomXmlPart`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/customxmlpart/) để làm việc với XML dưới dạng chuỗi UTF-8, hoặc `getXmlData()` và `setXmlData()` để làm việc với các byte XML thô.

Phương thức `getItemId()` trả về UUID xác định phần XML tùy chỉnh trong tài liệu Office Open XML. Sử dụng `setItemId()` khi một tích hợp yêu cầu một định danh mới.

Ví dụ sau cập nhật nội dung XML và định danh:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Đọc XML hiện tại dưới dạng văn bản.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Cập nhật XML dưới dạng chuỗi UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData cung cấp cùng nội dung XML dưới dạng byte thô.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Thay thế định danh khi tích hợp yêu cầu.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Khi gọi `setXmlAsString` hoặc `setXmlData`, hãy cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai dạng tùy thuộc vào việc ứng dụng làm việc chủ yếu với chuỗi hay dữ liệu byte.

### **Xóa một phần XML tùy chỉnh**

Aspose.Slides cung cấp một số cách để xóa dữ liệu XML tùy chỉnh:

- `CustomXmlPart.remove` loại bỏ phần XML tùy chỉnh khỏi bản trình bày.
- `CustomXmlPartCollection.remove` loại bỏ một phần cụ thể khỏi bộ sưu tập các phần XML tùy chỉnh.
- `CustomXmlPartCollection.removeAt` loại bỏ phần ở chỉ mục bộ sưu tập được chỉ định.
- `CustomXmlPartCollection.clear` loại bỏ tất cả các phần khỏi một bộ sưu tập cụ thể.

Ví dụ sau xóa một phần XML tùy chỉnh ở mức bản trình bày bằng tham chiếu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn đã có một `CustomXmlPart` và muốn xóa phần đó khỏi bản trình bày thay vì làm việc với một bộ sưu tập cụ thể, hãy gọi `customXmlPart.remove()`.

Bạn cũng có thể xóa mục theo chỉ mục:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Xóa Tất cả các phần XML tùy chỉnh khỏi một Bộ sưu tập**

Sử dụng `clear` khi tất cả các phần XML tùy chỉnh liên quan đến một đối tượng bản trình bày cụ thể cần được xóa.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` chỉ ảnh hưởng tới bộ sưu tập được chọn. Ví dụ, xóa bộ sưu tập của một slide không xóa các bộ sưu tập ở mức bản trình bày hoặc shape.

Để xóa mọi phần XML tùy chỉnh trong bản trình bày, lặp qua `getAllCustomXmlParts()` và xóa từng phần:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Xử lý các phần XML tùy chỉnh được Liên kết hoặc Chia sẻ**

Trong một bản trình bày Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ hơn một đối tượng bản trình bày. Ví dụ, một tệp hiện có có thể chứa các mối quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh nền.

Một phần được chia sẻ nên được xử lý như một đối tượng dữ liệu duy nhất với nhiều tham chiếu:

- Việc cập nhật nó bằng `setXmlAsString`, `setXmlData` hoặc `setItemId` sẽ thay đổi phần XML tùy chỉnh nền, do đó thay đổi sẽ áp dụng ở mọi nơi phần đó được tham chiếu.
- `getItemId()` có thể được sử dụng để xác định cùng một phần XML tùy chỉnh khi kiểm tra các bộ sưu tập ở cấp độ đối tượng.
- Xóa một phần khỏi một bộ sưu tập `getCustomXmlParts()` cụ thể sẽ xóa nó khỏi bộ sưu tập đó. Sử dụng `CustomXmlPart.remove()` khi phần đó cần được xóa khỏi bản trình bày.
- Trước khi xóa hoặc thay thế một phần được chia sẻ, kiểm tra các bộ sưu tập ở cấp độ đối tượng để xác định liệu các slide hoặc shape khác có vẫn tham chiếu tới nó hay không.

Các overload của `add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một `CustomXmlPart` hiện có. Do đó, các mối quan hệ chia sẻ thường gặp nhất khi tải các bản trình bày đã chứa chúng.

Ví dụ sau kiểm tra các bộ sưu tập ở mức bản trình bày, slide và shape bằng `ItemId` và báo cáo các phần được tham chiếu từ hơn một vị trí:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Loại kiểm tra này hữu ích trước khi sửa đổi hoặc xóa dữ liệu XML tùy chỉnh trong các bản trình bày do hệ thống bên ngoài tạo ra, vì cùng một phần siêu dữ liệu có thể tham gia vào hơn một mối quan hệ.

## **Lấy Giá trị của Thẻ**

Trong Slides, một thẻ tương ứng với phương thức `DocumentProperties.getKeywords()`. Đoạn mã mẫu này cho thấy cách lấy giá trị thẻ với Aspose.Slides cho Node.js qua Java cho [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Thêm Thẻ vào Bản trình bày**

Aspose.Slides cho phép bạn thêm thẻ vào bản trình bày. Một thẻ thường bao gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ, `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ, `My Tag Value`.

Nếu bạn cần phân loại bản trình bày dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu bạn muốn phân loại các bản trình bày từ các quốc gia Bắc Mỹ, bạn có thể tạo một thẻ Bắc Mỹ và gán quốc gia tương ứng làm giá trị.

Đoạn mã mẫu này cho thấy cách thêm một thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) sử dụng Aspose.Slides cho Node.js qua Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Thẻ cũng có thể được đặt cho một [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Hoặc cho một [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) riêng lẻ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Hạn chế**

Thẻ được thêm thông qua bộ sưu tập `getCustomData().getTags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình bày được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được lấy lại từ PDF có thẻ.

**Cách khắc phục**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.setAlternativeText("MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một bản trình bày, slide hoặc shape trong một lần thao tác không?**  
Có. [Bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/) để xóa tất cả các cặp khóa-giá trị cùng một lúc.

**Làm sao tôi xóa một thẻ duy nhất bằng tên của nó mà không phải lặp qua toàn bộ bộ sưu tập?**  
Sử dụng `remove(name)` trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ cho việc phân tích hoặc lọc?**  
Sử dụng `getNamesOfTags()` trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.

**Làm sao tôi có thể tìm tất cả các phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**  
Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) để lấy tất cả các phần XML tùy chỉnh trong bản trình bày.

**Tôi nên dùng `getXmlAsString`/`setXmlAsString` hay `getXmlData`/`setXmlData` để cập nhật một phần XML tùy chỉnh?**  
Sử dụng `getXmlAsString` và `setXmlAsString` khi ứng dụng làm việc với văn bản XML UTF-8. Sử dụng `getXmlData` và `setXmlData` khi XML đã có sẵn dưới dạng mảng byte hoặc khi xử lý theo hướng nhị phân thuận tiện hơn. Cả hai dạng đều tham chiếu tới nội dung XML của cùng một phần XML tùy chỉnh.