---
title: Quản lý thẻ và dữ liệu tùy chỉnh trong bản thuyết trình bằng Java
linktitle: Thẻ và dữ liệu tùy chỉnh
type: docs
weight: 300
url: /vi/java/managing-tags-and-custom-data/
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
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bản thuyết trình PowerPoint bằng Aspose.Slides cho Java, bao gồm việc thêm, đọc, cập nhật, kiểm toán và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản thuyết trình PowerPoint. Dữ liệu riêng của bản thuyết trình có thể được lưu dưới dạng thẻ hoặc các phần XML tùy chỉnh. Thẻ là các cặp chuỗi khóa-giá trị đơn giản, trong khi các phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và tải trọng XML đặc thù cho ứng dụng.

Aspose.Slides cung cấp các API để thêm, đọc, cập nhật, kiểm toán và xóa các phần XML tùy chỉnh ở mức bản thuyết trình, slide và shape. Các phần XML tùy chỉnh hữu ích cho các tích hợp lưu trữ thông tin như định danh quản lý tài liệu, trạng thái quy trình công việc, siêu dữ liệu tuân thủ, dữ liệu liên kết mẫu, hoặc các dữ liệu ứng dụng có cấu trúc khác trong một bản thuyết trình.

## **Lưu trữ dữ liệu trong tệp bản thuyết trình**

Các tệp PPTX — các tệp có phần mở rộng `.pptx` — được lưu dưới định dạng PresentationML, một phần của tiêu chuẩn Office Open XML. Office Open XML định nghĩa cấu trúc gói và các mối quan hệ được sử dụng để lưu nội dung bản thuyết trình và dữ liệu liên quan.

Một bản thuyết trình chứa nhiều phần được kết nối bằng các mối quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các mối quan hệ rõ ràng tới các phần khác được định nghĩa bởi ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITagCollection)) hoặc các phần XML tùy chỉnh ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection)). Cả hai đều có sẵn thông qua giao diện [`ICustomData`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}
Thẻ lưu trữ các cặp chuỗi khóa-giá trị đơn giản. Các phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được liên kết với một bản thuyết trình, slide hoặc shape.
{{% /alert %}}

## **Làm việc với các phần XML tùy chỉnh**

Phương thức [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomData#getCustomXmlParts--) trả về tập hợp các phần XML tùy chỉnh liên kết với một đối tượng bản thuyết trình cụ thể. Ví dụ:

- `presentation.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với bản thuyết trình itself.
- `slide.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một slide cụ thể.
- `shape.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một shape cụ thể.

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) khi bạn cần kiểm tra tất cả các phần XML tùy chỉnh trong bản thuyết trình bất kể chúng được liên kết ở đâu.

### **Thêm một phần XML tùy chỉnh vào bản thuyết trình**

Sử dụng [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) để thêm dữ liệu XML vào một tập hợp phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào tập hợp dữ liệu tùy chỉnh ở mức bản thuyết trình:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add tự động gán một định danh. Chỉ đặt UUID cụ thể khi cần thiết.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phương thức `add` cũng có thể nhận XML dưới dạng mảng byte hoặc luồng đầu vào, hữu ích khi nội dung XML đã có ở dạng nhị phân.

### **Thêm một phần XML tùy chỉnh vào slide hoặc shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bản thuyết trình. Điều này hữu ích khi siêu dữ liệu mô tả chỉ một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi bên ngoài, hoặc thông tin liên kết.

Ví dụ sau thêm một phần XML tùy chỉnh vào một slide và một phần khác vào một shape:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mức độ mà một phần được thêm quyết định collection `getCustomData().getCustomXmlParts()` của đối tượng nào chứa mối quan hệ tới phần đó. Dữ liệu ở mức bản thuyết trình phù hợp cho siêu dữ liệu toàn tài liệu, dữ liệu ở mức slide cho thông tin thuộc về một slide cụ thể, và dữ liệu ở mức shape cho siêu dữ liệu gắn với một shape cá nhân.

### **Liệt kê và kiểm toán tất cả các phần XML tùy chỉnh**

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) để lấy tất cả các phần XML tùy chỉnh từ một bản thuyết trình. Mỗi [`ICustomXmlPart`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart/) cung cấp định danh, nội dung XML và các namespace schema liên quan.

Ví dụ sau liệt kê tất cả các phần XML tùy chỉnh và namespace schema của chúng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) trả về các schema XML liên kết với phần XML tùy chỉnh. Thông tin này có thể hữu ích khi kiểm toán các bản thuyết trình chứa XML được tạo bởi hệ thống bên ngoài.

### **Đọc và cập nhật nội dung XML và ItemId**

Sử dụng [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) và [`setXmlAsString()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) để làm việc với XML dưới dạng chuỗi UTF-8, hoặc [`getXmlData()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#getXmlData--) và [`setXmlData()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) để làm việc với các byte XML thô.

Phương thức [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#getItemId--) trả về UUID xác định phần XML tùy chỉnh trong tài liệu Office Open XML. Sử dụng [`setItemId()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) khi một tích hợp yêu cầu định danh mới.

Ví dụ sau cập nhật nội dung XML và định danh:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Đọc XML hiện tại dưới dạng văn bản.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Cập nhật XML dưới dạng chuỗi UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData cung cấp cùng nội dung XML dưới dạng byte thô.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Thay thế định danh khi tích hợp yêu cầu.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Khi gọi `setXmlAsString` hoặc `setXmlData`, cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai biểu diễn tùy thuộc vào việc ứng dụng làm việc chủ yếu với chuỗi hay dữ liệu byte.

### **Xóa một phần XML tùy chỉnh**

Aspose.Slides cung cấp một số cách để xóa dữ liệu XML tùy chỉnh:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#remove--) xóa phần XML tùy chỉnh khỏi bản thuyết trình.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) xóa một phần cụ thể khỏi một tập hợp phần XML tùy chỉnh.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) xóa phần ở vị trí chỉ mục cụ thể trong collection.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection#clear--) xóa tất cả các phần khỏi một collection cụ thể.

Ví dụ sau xóa một phần XML tùy chỉnh ở mức bản thuyết trình bằng tham chiếu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu bạn đã có một `ICustomXmlPart` và muốn xóa phần đó khỏi bản thuyết trình thay vì truy cập một collection cụ thể, gọi `customXmlPart.remove()`.

Bạn cũng có thể xóa một mục theo chỉ mục:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Xóa tất cả các phần XML tùy chỉnh khỏi một collection**

Sử dụng `clear` khi tất cả các phần XML tùy chỉnh liên kết với một đối tượng bản thuyết trình cụ thể cần được xóa.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` chỉ ảnh hưởng đến collection đã chọn. Ví dụ, việc xóa collection của một slide sẽ không xóa các collection ở mức bản thuyết trình hoặc shape.

Để xóa mọi phần XML tùy chỉnh trong bản thuyết trình, lặp qua `getAllCustomXmlParts()` và xóa từng phần:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Xử lý các phần XML tùy chỉnh được liên kết hoặc chia sẻ**

Trong một bản thuyết trình Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ nhiều đối tượng bản thuyết trình. Ví dụ, một tệp hiện có có thể chứa các mối quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh nền tảng.

Một phần chia sẻ nên được coi là một đối tượng dữ liệu với nhiều tham chiếu:

- Cập nhật nó bằng `setXmlAsString`, `setXmlData`, hoặc `setItemId` sẽ thay đổi phần XML tùy chỉnh nền tảng, vì vậy thay đổi sẽ áp dụng ở mọi nơi phần đó được tham chiếu.
- `getItemId()` có thể được dùng để xác định cùng một phần XML tùy chỉnh khi kiểm toán các collection ở mức đối tượng.
- Xóa một phần khỏi một collection `getCustomXmlParts()` cụ thể sẽ xóa nó khỏi collection đó. Sử dụng `ICustomXmlPart.remove()` khi phần đó cần được xóa khỏi bản thuyết trình.
- Trước khi xóa hoặc thay thế một phần chia sẻ, kiểm tra các collection ở mức đối tượng để xác định liệu các slide hoặc shape khác vẫn tham chiếu tới nó hay không.

Các overload `add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một `ICustomXmlPart` hiện có. Do đó, các mối quan hệ chia sẻ thường xuất hiện khi tải các bản thuyết trình đã chứa chúng.

Ví dụ sau kiểm toán các collection ở mức presentation, slide và shape bằng `ItemId` và báo cáo các phần được tham chiếu từ hơn một vị trí:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Loại kiểm toán này hữu ích trước khi chỉnh sửa hoặc xóa dữ liệu XML tùy chỉnh trong các bản thuyết trình được tạo bởi hệ thống bên ngoài, vì cùng một phần metadata có thể tham gia vào nhiều mối quan hệ.

## **Lấy giá trị của các thẻ**

Trong slides, một thẻ tương ứng với phương thức `IDocumentProperties.getKeywords()`. Đoạn mã mẫu này cho thấy cách lấy giá trị thẻ bằng Aspose.Slides cho Java cho [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Thêm thẻ vào bản thuyết trình**

Aspose.Slides cho phép bạn thêm thẻ vào bản thuyết trình. Một thẻ thường bao gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ, `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ, `My Tag Value`.

Nếu bạn cần phân loại bản thuyết trình dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại các bản thuyết trình từ các quốc gia Bắc Mỹ, bạn có thể tạo một thẻ North American và gán quốc gia tương ứng làm giá trị.

Đoạn mã mẫu này cho thấy cách thêm thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) bằng Aspose.Slides cho Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Thẻ cũng có thể được đặt cho một [Slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Hoặc cho một [Shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) cá nhân:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Giới hạn**

Các thẻ được thêm qua collection `getCustomData().getTags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản thuyết trình được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán làm thẻ không thể được truy xuất từ PDF đã gắn thẻ.

**Giải pháp thay thế**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.setAlternativeText("MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một bản thuyết trình, slide hoặc shape trong một thao tác không?**

Có. [tag collection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/#clear--) để xóa tất cả các cặp khóa-giá trị cùng một lúc.

**Làm thế nào để xóa một thẻ duy nhất theo tên mà không phải lặp qua toàn bộ collection?**

Sử dụng [remove(name)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) trên [tag collection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ cho mục đích phân tích hoặc lọc?**

Sử dụng [getNamesOfTags](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/#getNamesOfTags--) trên [tag collection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.

**Làm sao tôi tìm thấy tất cả các phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) để lấy tất cả các phần XML tùy chỉnh trong bản thuyết trình.

**Nên dùng `getXmlAsString`/`setXmlAsString` hay `getXmlData`/`setXmlData` để cập nhật một phần XML tùy chỉnh?**

Sử dụng `getXmlAsString` và `setXmlAsString` khi ứng dụng làm việc với văn bản XML UTF-8. Sử dụng `getXmlData` và `setXmlData` khi XML đã có sẵn dưới dạng mảng byte hoặc khi việc xử lý ở dạng nhị phân thuận tiện hơn. Cả hai biểu diễn đều tham chiếu tới nội dung XML của cùng một phần XML tùy chỉnh.