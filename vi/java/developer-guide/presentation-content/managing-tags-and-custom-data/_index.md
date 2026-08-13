---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình chiếu bằng Java
linktitle: Thẻ và Dữ liệu Tùy chỉnh
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bản trình chiếu PowerPoint với Aspose.Slides cho Java, bao gồm việc thêm, đọc, cập nhật, kiểm tra và xoá các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình chiếu PowerPoint. Dữ liệu riêng của bản trình chiếu có thể được lưu dưới dạng thẻ hoặc các phần XML tùy chỉnh. Thẻ là các cặp khóa‑giá trị chuỗi đơn giản, trong khi các phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và tải trọng XML đặc thù của ứng dụng.

Aspose.Slides cung cấp các API để thêm, đọc, cập nhật, kiểm tra và xoá các phần XML tùy chỉnh ở mức bản trình chiếu, slide và shape. Các phần XML tùy chỉnh hữu ích cho các tích hợp lưu thông tin như định danh quản lý tài liệu, trạng thái quy trình làm việc, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu, hoặc bất kỳ dữ liệu ứng dụng có cấu trúc nào khác bên trong bản trình chiếu.

## **Lưu trữ dữ liệu trong tệp bản trình chiếu**

Các tệp PPTX — các tệp có phần mở rộng `.pptx` — được lưu ở định dạng PresentationML, một phần của chuẩn Office Open XML. Office Open XML xác định cấu trúc gói và các quan hệ dùng để lưu nội dung bản trình chiếu và dữ liệu liên quan.

Một bản trình chiếu chứa nhiều phần được kết nối bằng các quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các quan hệ rõ ràng tới các phần khác được định nghĩa bởi ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITagCollection)) hoặc các phần XML tùy chỉnh ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection)). Cả hai đều có sẵn thông qua giao diện [`ICustomData`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomData/) .

{{% alert color="info" %}}
Thẻ lưu trữ các cặp khóa‑giá trị chuỗi đơn giản. Các phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được liên kết với một bản trình chiếu, slide hoặc shape.
{{% /alert %}}

## **Làm việc với các phần XML tùy chỉnh**

Phương thức [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomData#getCustomXmlParts--) trả về tập hợp các phần XML tùy chỉnh được liên kết với một đối tượng bản trình chiếu cụ thể. Ví dụ:

- `presentation.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với chính bản trình chiếu.
- `slide.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một slide cụ thể.
- `shape.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh liên kết với một shape cụ thể.

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) khi bạn cần kiểm tra tất cả các phần XML tùy chỉnh trong bản trình chiếu bất kể chúng được liên kết ở đâu.

### **Thêm một phần XML tùy chỉnh vào bản trình chiếu**

Sử dụng [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) để thêm dữ liệu XML vào một tập hợp phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào tập hợp dữ liệu tùy chỉnh ở mức bản trình chiếu:

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

    // add tự động gán một định danh. Đặt UUID cụ thể chỉ khi cần thiết.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phương thức `add` cũng có thể nhận XML dưới dạng mảng byte hoặc luồng nhập, hữu ích khi nội dung XML đã có ở dạng nhị phân.

### **Thêm một phần XML tùy chỉnh vào slide hoặc shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bản trình chiếu. Điều này hữu ích khi siêu dữ liệu chỉ mô tả một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi ngoại vi, hoặc thông tin ràng buộc.

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

Mức mà một phần được thêm quyết định collection `getCustomData().getCustomXmlParts()` của đối tượng nào sẽ chứa quan hệ tới phần đó. Dữ liệu ở mức bản trình chiếu phù hợp cho siêu dữ liệu toàn tài liệu, dữ liệu ở mức slide cho thông tin thuộc một slide cụ thể, và dữ liệu ở mức shape cho siêu dữ liệu gắn với một shape riêng lẻ.

### **Liệt kê và kiểm tra tất cả các phần XML tùy chỉnh**

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) để lấy tất cả các phần XML tùy chỉnh từ một bản trình chiếu. Mỗi [`ICustomXmlPart`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart/) cung cấp định danh, nội dung XML và các schema không gian tên liên quan.

Ví dụ sau liệt kê tất cả các phần XML tùy chỉnh và các schema không gian tên của chúng:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) trả về các schema XML liên kết với phần XML tùy chỉnh. Thông tin này có thể hữu ích khi kiểm toán các bản trình chiếu chứa XML được tạo bởi hệ thống bên ngoài.

### **Đọc và cập nhật nội dung XML và ItemId**

Sử dụng [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) và [`setXmlAsString()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) để làm việc với XML dưới dạng chuỗi UTF‑8, hoặc [`getXmlData()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#getXmlData--) và [`setXmlData()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) để làm việc với byte XML thô.

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

Khi gọi `setXmlAsString` hoặc `setXmlData`, cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai cách biểu diễn tùy vào ứng dụng làm việc chủ yếu với chuỗi hay dữ liệu byte.

### **Xoá một phần XML tùy chỉnh**

Aspose.Slides cung cấp một số cách để xoá dữ liệu XML tùy chỉnh:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPart#remove--) xoá phần XML tùy chỉnh khỏi bản trình chiếu.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) xoá một phần cụ thể khỏi tập hợp phần XML tùy chỉnh.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) xoá phần tại chỉ mục được chỉ định trong tập hợp.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection#clear--) xoá tất cả các phần khỏi một tập hợp cụ thể.

Ví dụ sau xoá một phần XML tùy chỉnh ở mức bản trình chiếu bằng tham chiếu:

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

Nếu bạn đã có một `ICustomXmlPart` và muốn xoá phần đó khỏi bản trình chiếu thay vì thao tác trên một tập hợp cụ thể, gọi `customXmlPart.remove()`.

Bạn cũng có thể xoá mục theo chỉ mục:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Xoá sạch tất cả các phần XML tùy chỉnh trong một tập hợp**

Sử dụng `clear` khi cần xoá tất cả các phần XML tùy chỉnh liên kết với một đối tượng bản trình chiếu cụ thể.

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

`clear` chỉ ảnh hưởng tới tập hợp được chọn. Ví dụ, xoá sạch tập hợp của một slide sẽ không xoá các tập hợp ở mức bản trình chiếu hay shape.

Để xoá mọi phần XML tùy chỉnh trong bản trình chiếu, lặp qua `getAllCustomXmlParts()` và xoá từng phần:

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

Trong một bản trình chiếu Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ nhiều đối tượng bản trình chiếu. Ví dụ, một tệp hiện có thể chứa các quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh nền tảng.

Một phần được chia sẻ nên được coi là một đối tượng dữ liệu với nhiều tham chiếu:

- Cập nhật nó bằng `setXmlAsString`, `setXmlData` hoặc `setItemId` sẽ thay đổi phần XML tùy chỉnh nền tảng, vì vậy thay đổi sẽ áp dụng ở mọi nơi phần đó được tham chiếu.
- `getItemId()` có thể được dùng để xác định cùng một phần XML tùy chỉnh khi kiểm toán các tập hợp mức đối tượng.
- Xoá một phần khỏi một tập hợp `getCustomXmlParts()` cụ thể sẽ chỉ xoá nó khỏi tập hợp đó. Sử dụng `ICustomXmlPart.remove()` khi muốn phần tự nó bị xoá khỏi bản trình chiếu.
- Trước khi xoá hoặc thay thế một phần được chia sẻ, hãy kiểm tra các tập hợp mức đối tượng để xác định liệu các slide hoặc shape khác vẫn còn tham chiếu tới nó hay không.

Các overload `add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không nhận một `ICustomXmlPart` hiện có. Do đó, các quan hệ chia sẻ thường gặp nhất khi tải các bản trình chiếu đã chứa chúng.

Ví dụ sau kiểm toán các tập hợp ở mức bản trình chiếu, slide và shape bằng `ItemId` và báo cáo các phần được tham chiếu từ hơn một vị trí:

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

Kiểm toán kiểu này hữu ích trước khi sửa đổi hoặc xoá dữ liệu XML tùy chỉnh trong các bản trình chiếu được tạo bởi hệ thống bên ngoài, vì cùng một phần siêu dữ liệu có thể tham gia vào nhiều quan hệ.

## **Lấy giá trị của các thẻ**

Trong Slides, một thẻ tương ứng với phương thức `IDocumentProperties.getKeywords()`. Đoạn mã mẫu sau cho thấy cách lấy giá trị thẻ bằng Aspose.Slides cho Java cho [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Thêm thẻ vào bản trình chiếu**

Aspose.Slides cho phép bạn thêm thẻ vào bản trình chiếu. Một thẻ thường gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ `My Tag Value`.

Nếu bạn cần phân loại bản trình chiếu dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại các bản trình chiếu từ các nước Bắc Mỹ, bạn có thể tạo một thẻ Bắc Mỹ và gán quốc gia tương ứng làm giá trị.

Đoạn mã mẫu sau cho thấy cách thêm một thẻ vào [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) bằng Aspose.Slides cho Java:

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

Các thẻ được thêm qua collection `getCustomData().getTags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình chiếu được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được truy xuất từ PDF có thẻ.

**Giải pháp**: Bạn có thể lưu định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.setAlternativeText("MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xoá tất cả thẻ khỏi một bản trình chiếu, slide hoặc shape trong một thao tác duy nhất không?**

Có. [Bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/#clear--) để xoá tất cả các cặp khóa‑giá trị cùng lúc.

**Làm sao xoá một thẻ đơn lẻ theo tên mà không phải duyệt toàn bộ bộ sưu tập?**

Sử dụng [remove(name)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/) để xoá thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Sử dụng [getNamesOfTags](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/#getNamesOfTags--) trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.

**Làm sao tôi có thể tìm tất cả các phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) để lấy tất cả các phần XML tùy chỉnh trong bản trình chiếu.

**Tôi nên dùng `getXmlAsString`/`setXmlAsString` hay `getXmlData`/`setXmlData` để cập nhật một phần XML tùy chỉnh?**

Dùng `getXmlAsString` và `setXmlAsString` khi ứng dụng làm việc với văn bản XML UTF‑8. Dùng `getXmlData` và `setXmlData` khi XML đã có dưới dạng mảng byte hoặc khi xử lý nhị phân thuận tiện hơn. Cả hai cách biểu diễn đều tham chiếu tới nội dung XML của cùng một phần XML tùy chỉnh.