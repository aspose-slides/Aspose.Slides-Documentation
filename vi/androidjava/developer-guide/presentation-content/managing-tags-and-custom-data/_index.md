---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình bày trên Android
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bản trình bày PowerPoint với Aspose.Slides cho Android qua Java, bao gồm việc thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình bày PowerPoint. Dữ liệu riêng của bản trình bày có thể được lưu trữ dưới dạng thẻ hoặc các phần XML tùy chỉnh. Thẻ là các cặp chuỗi khóa‑giá trị đơn giản, trong khi các phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và tải dữ liệu XML đặc thù cho ứng dụng.

Aspose.Slides cung cấp các API để thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh ở mức bản trình bày, slide và shape. Các phần XML tùy chỉnh hữu ích cho các tích hợp lưu trữ thông tin như định danh quản lý tài liệu, trạng thái quy trình làm việc, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu, hoặc các dữ liệu ứng dụng có cấu trúc khác bên trong bản trình bày.

## **Lưu trữ Dữ liệu trong Tệp Bản Trình Bày**

Các tệp PPTX—các tệp có phần mở rộng `.pptx`—được lưu trữ ở định dạng PresentationML, một phần của chuẩn Office Open XML. Office Open XML định nghĩa cấu trúc gói và các quan hệ được sử dụng để lưu trữ nội dung bản trình bày và dữ liệu liên quan.

Một bản trình bày chứa nhiều phần được kết nối bằng các quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các quan hệ rõ ràng tới các phần khác theo chuẩn ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu trữ dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITagCollection)) hoặc các phần XML tùy chỉnh ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Cả hai đều có sẵn thông qua giao diện [`ICustomData`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomData/) .

{{% alert color="info" %}}
Thẻ lưu trữ các cặp chuỗi khóa‑giá trị đơn giản. Các phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được gắn với một bản trình bày, slide hoặc shape.
{{% /alert %}}

## **Làm việc với Các Phần XML Tùy Chỉnh**

Phương thức [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) trả về tập hợp các phần XML tùy chỉnh được gắn với một đối tượng bản trình bày cụ thể. Ví dụ:

- `presentation.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh được gắn với chính bản trình bày.
- `slide.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh được gắn với một slide cụ thể.
- `shape.getCustomData().getCustomXmlParts()` chứa các phần XML tùy chỉnh được gắn với một shape cụ thể.

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) khi bạn cần kiểm tra tất cả các phần XML tùy chỉnh trong bản trình bày bất kể chúng được gắn ở đâu.

### **Thêm Phần XML Tùy Chỉnh vào Bản Trình Bày**

Sử dụng [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) để thêm dữ liệu XML vào tập hợp các phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào tập hợp dữ liệu tùy chỉnh ở mức bản trình bày:

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

    //    add tự động gán một định danh. Chỉ đặt UUID cụ thể khi cần thiết.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Phương thức `add` cũng có thể nhận XML dưới dạng mảng byte hoặc luồng đầu vào, rất hữu ích khi nội dung XML đã có sẵn ở dạng nhị phân.

### **Thêm Phần XML Tùy Chỉnh vào Slide hoặc Shape**

Dữ liệu XML tùy chỉnh có thể được gắn với một slide hoặc shape cụ thể thay vì toàn bộ bản trình bày. Điều này hữu ích khi siêu dữ liệu chỉ mô tả một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi bên ngoài, hoặc thông tin ràng buộc.

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

Mức độ mà một phần được thêm vào quyết định tập hợp `getCustomData().getCustomXmlParts()` của đối tượng nào chứa quan hệ tới phần đó. Dữ liệu ở mức bản trình bày phù hợp cho siêu dữ liệu toàn tài liệu, dữ liệu ở mức slide cho thông tin thuộc về một slide cụ thể, và dữ liệu ở mức shape cho siêu dữ liệu liên quan đến một shape riêng lẻ.

### **Liệt kê và Kiểm tra Tất cả Các Phần XML Tùy Chỉnh**

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) để truy xuất tất cả các phần XML tùy chỉnh từ một bản trình bày. Mỗi [`ICustomXmlPart`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPart/) cung cấp định danh, nội dung XML và các schema không gian tên liên quan.

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) trả về các schema XML liên kết với phần XML tùy chỉnh. Thông tin này hữu ích khi kiểm tra các bản trình bày chứa XML do hệ thống bên ngoài tạo ra.

### **Đọc và Cập nhật Nội dung XML và ItemId**

Sử dụng [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) và [`setXmlAsString()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) để làm việc với XML dưới dạng chuỗi UTF‑8, hoặc [`getXmlData()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) và [`setXmlData()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) để làm việc với dữ liệu byte thô.

Phương thức [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) trả về UUID xác định phần XML tùy chỉnh trong tài liệu Office Open XML. Sử dụng [`setItemId()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) khi một tích hợp yêu cầu định danh mới.

Ví dụ sau cập nhật nội dung XML và định danh:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    //    Đọc XML hiện tại dưới dạng văn bản.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    //    Cập nhật XML dưới dạng chuỗi UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    //    getXmlData cung cấp cùng nội dung XML dưới dạng byte thô.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    //    Thay thế định danh khi tích hợp yêu cầu.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Khi gọi `setXmlAsString` hoặc `setXmlData`, cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai cách biểu diễn tùy theo ứng dụng làm việc chính với chuỗi hay dữ liệu byte.

### **Xóa một Phần XML Tùy Chỉnh**

Aspose.Slides cung cấp một số cách để xóa dữ liệu XML tùy chỉnh:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPart#remove--) xóa phần XML tùy chỉnh khỏi bản trình bày.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) xóa một phần cụ thể khỏi tập hợp các phần XML tùy chỉnh.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) xóa phần tại chỉ mục được chỉ định trong tập hợp.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) xóa tất cả các phần trong một tập hợp cụ thể.

Ví dụ sau xóa một phần XML tùy chỉnh ở mức bản trình bày bằng tham chiếu:

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

Nếu bạn đã có một `ICustomXmlPart` và muốn xóa phần đó khỏi bản trình bày thay vì thao tác trên một tập hợp cụ thể, gọi `customXmlPart.remove()`.

Bạn cũng có thể xóa mục theo chỉ mục:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Xóa Tất cả Các Phần XML Tùy Chỉnh trong Một Tập Hợp**

Sử dụng `clear` khi tất cả các phần XML tùy chỉnh gắn với một đối tượng bản trình bày cụ thể cần được xóa.

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

`clear` chỉ ảnh hưởng đến tập hợp đã chọn. Ví dụ, xóa sạch tập hợp của một slide sẽ không xóa các tập hợp ở mức bản trình bày hoặc shape.

Để xóa mọi phần XML tùy chỉnh trong bản trình bày, lặp qua `getAllCustomXmlParts()` và xóa từng phần:

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

### **Xử lý Các Phần XML Tùy Chỉnh Liên kết hoặc Chia sẻ**

Trong một bản trình bày Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ hơn một đối tượng bản trình bày. Ví dụ, một tệp hiện có thể chứa các quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh nền tảng.

Một phần được chia sẻ nên được xem như một đối tượng dữ liệu duy nhất với nhiều tham chiếu:

- Cập nhật nó bằng `setXmlAsString`, `setXmlData` hoặc `setItemId` sẽ thay đổi phần XML tùy chỉnh nền tảng, vì vậy thay đổi sẽ áp dụng ở mọi nơi phần đó được tham chiếu.
- `getItemId()` có thể được dùng để xác định cùng một phần XML tùy chỉnh khi kiểm tra các tập hợp cấp đối tượng.
- Xóa một phần khỏi một tập hợp `getCustomXmlParts()` cụ thể sẽ chỉ xóa nó khỏi tập hợp đó. Sử dụng `ICustomXmlPart.remove()` khi phần đó cần được xóa hoàn toàn khỏi bản trình bày.
- Trước khi xóa hoặc thay thế một phần được chia sẻ, kiểm tra các tập hợp cấp đối tượng để xác định liệu các slide hoặc shape khác còn tham chiếu tới nó hay không.

Các overload của `add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một `ICustomXmlPart` đã tồn tại. Do đó, các quan hệ chia sẻ thường gặp nhất khi tải các bản trình bày đã có chúng.

Ví dụ sau kiểm tra các tập hợp ở mức bản trình bày, slide và shape bằng `ItemId` và báo cáo các phần được tham chiếu từ hơn một vị trí:

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

Loại kiểm tra này hữu ích trước khi sửa đổi hoặc xóa dữ liệu XML tùy chỉnh trong các bản trình bày do hệ thống bên ngoài tạo ra, vì cùng một phần siêu dữ liệu có thể tham gia vào hơn một quan hệ.

## **Lấy Giá trị của Thẻ**

Trong Slides, một thẻ tương ứng với phương thức `IDocumentProperties.getKeywords()`. Đoạn mã mẫu này cho thấy cách lấy giá trị thẻ bằng Aspose.Slides cho Android qua Java cho [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Thêm Thẻ vào Bản Trình Bày**

Aspose.Slides cho phép bạn thêm thẻ vào bản trình bày. Một thẻ thường gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ `My Tag Value`.

Nếu bạn cần phân loại các bản trình bày dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại các bản trình bày từ các quốc gia Bắc Mỹ, bạn có thể tạo một thẻ North American và gán tên quốc gia tương ứng làm giá trị.

Đoạn mã mẫu này cho thấy cách thêm một thẻ vào [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) bằng Aspose.Slides cho Android qua Java:

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

Thẻ cũng có thể được đặt cho một [Slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlide):

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

Hoặc cho một [Shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape) riêng lẻ:

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

Các thẻ được thêm qua tập hợp `getCustomData().getTags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình bày được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được truy xuất từ PDF đã gắn thẻ.

**Giải pháp**: Bạn có thể lưu định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.setAlternativeText("MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **FAQ**

**Tôi có thể xóa tất cả các thẻ khỏi một bản trình bày, slide hoặc shape trong một thao tác duy nhất không?**

Có. [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/#clear--) để xóa tất cả các cặp khóa‑giá trị một lúc.

**Làm sao tôi có thể xóa một thẻ duy nhất theo tên của nó mà không cần duyệt qua toàn bộ tập hợp?**

Sử dụng [remove(name)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm thế nào tôi có thể lấy danh sách đầy đủ các tên thẻ cho mục đích phân tích hoặc lọc?**

Sử dụng [getNamesOfTags](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.

**Làm sao tôi có thể tìm tất cả các phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**

Sử dụng [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) để truy xuất tất cả các phần XML tùy chỉnh trong bản trình bày.

**Tôi nên dùng `getXmlAsString`/`setXmlAsString` hay `getXmlData`/`setXmlData` để cập nhật một phần XML tùy chỉnh?**

Dùng `getXmlAsString` và `setXmlAsString` khi ứng dụng làm việc với văn bản XML UTF‑8. Dùng `getXmlData` và `setXmlData` khi XML đã có dưới dạng mảng byte hoặc khi xử lý dạng nhị phân thuận tiện hơn. Cả hai cách biểu diễn đều tham chiếu tới nội dung XML của cùng một phần XML tùy chỉnh.