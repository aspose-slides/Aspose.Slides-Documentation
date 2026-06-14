---
title: Quản lý Thuộc tính Bản trình chiếu trong Java
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/java/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- thuộc tính bản trình chiếu
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý tối ưu các thuộc tính bản trình chiếu trong Aspose.Slides cho Java và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể dễ dàng truy cập và quản lý thông qua API của Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties/) . Một thể hiện của giao diện này được trả về bởi phương thức [Presentation.getDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getDocumentProperties--) . Các ví dụ dưới đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="primary" %}} 
Vui lòng lưu ý rằng các trường **Application** và **Producer** không thể chỉnh sửa, vì các trường này luôn hiển thị "Aspose Ltd." và "Aspose.Slides for Java x.x.x".
{{% /alert %}} 

## **Thuộc tính tài liệu trong PowerPoint**

Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của tệp bản trình chiếu. Tất cả những gì bạn cần làm là nhấp vào biểu tượng Office và sau đó chọn **Prepare | Properties | Advanced Properties** như hình dưới đây:

|**Chọn mục Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Sau khi bạn chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint như hình dưới đây:

|**Hộp thoại Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Trong **Hộp thoại Properties** trên, bạn có thể thấy có nhiều trang tab như **General**, **Summary**, **Statistics**, **Contents** và **Custom**. Tất cả các trang tab này cho phép cấu hình các thông tin khác nhau liên quan đến tệp PowerPoint. Trang **Custom** được dùng để quản lý các thuộc tính tùy chỉnh của tệp PowerPoint.

### **Làm việc với Thuộc tính tài liệu bằng Aspose.Slides cho Java**

Như đã mô tả ở trên, Aspose.Slides cho Java hỗ trợ hai loại thuộc tính tài liệu, đó là **Built-in** và **Custom**. Do đó, các nhà phát triển có thể truy cập cả hai loại thuộc tính bằng cách sử dụng API của Aspose.Slides cho Java. Aspose.Slides cho Java cung cấp một lớp [IDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties) đại diện cho các thuộc tính tài liệu liên quan đến tệp bản trình chiếu thông qua thuộc tính **Presentation.DocumentProperties**.

Các nhà phát triển có thể sử dụng thuộc tính **IDocumentProperties** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) để truy cập các thuộc tính tài liệu của tệp bản trình chiếu như mô tả bên dưới:

## **Truy cập Thuộc tính Built-in**

Các thuộc tính được hiển thị bởi đối tượng [IDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties) bao gồm: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** và **Title**.

```java
// Khởi tạo lớp Presentation đại diện cho bản trình chiếu
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu tới đối tượng IDocumentProperties liên kết với Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Hiển thị các thuộc tính built-in
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sửa đổi Thuộc tính Built-in**

Việc sửa đổi các thuộc tính built-in của tệp bản trình chiếu cũng dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách sửa đổi các thuộc tính tài liệu built-in của tệp bản trình chiếu bằng Aspose.Slides cho Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu tới đối tượng IDocumentProperties liên kết với Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Đặt các thuộc tính built-in
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Lưu bản trình chiếu của bạn vào tệp
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ví dụ này sửa đổi các thuộc tính built-in của bản trình chiếu và có thể xem kết quả như sau:

|**Thuộc tính tài liệu Built-in sau khi sửa đổi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Thêm Thuộc tính tài liệu tùy chỉnh**

Aspose.Slides cho Java cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho thuộc tính tài liệu của bản trình chiếu. Một ví dụ được đưa ra dưới đây cho thấy cách đặt các thuộc tính tùy chỉnh cho một bản trình chiếu.

```java
Presentation pres = new Presentation();
try {
    // Lấy Thuộc tính Tài liệu
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Thêm thuộc tính tùy chỉnh
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Lấy tên thuộc tính tại chỉ mục cụ thể
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Xóa thuộc tính đã chọn
    dProps.removeCustomProperty(getPropertyName);
    
    // Lưu bản trình chiếu
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Thuộc tính tài liệu tùy chỉnh đã được thêm**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Aspose.Slides cho Java cũng cho phép các nhà phát triển truy cập giá trị của các thuộc tính tùy chỉnh. Một ví dụ được đưa ra dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh của một bản trình chiếu.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu tới đối tượng DocumentProperties liên kết với Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Truy cập và sửa đổi các thuộc tính tùy chỉnh
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Hiển thị tên và giá trị của các thuộc tính tùy chỉnh
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Sửa đổi giá trị của các thuộc tính tùy chỉnh
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Lưu bản trình chiếu của bạn vào tệp
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ví dụ này sửa đổi các thuộc tính tùy chỉnh của [PPTX](https://docs.fileformat.com/presentation/pptx/)presentation. Các hình dưới đây cho thấy các thuộc tính tùy chỉnh của bản trình chiếu trước và sau khi sửa đổi:

|**Thuộc tính tùy chỉnh trước khi sửa đổi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Thuộc tính tùy chỉnh sau khi sửa đổi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Thuộc tính tài liệu Nâng cao**

{{% alert color="primary" %}} 
Các phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), và [WriteBindedPresentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) đã được thêm vào [IPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo), logic của bộ setter thuộc tính [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) đã được thay đổi.
{{% /alert %}} 

Hai phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) và [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) đã được thêm vào giao diện [IPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo). Chúng cung cấp cách truy cập nhanh vào các thuộc tính tài liệu và cho phép thay đổi, cập nhật thuộc tính mà không cần tải toàn bộ bản trình chiếu.

Kịch bản điển hình tải các thuộc tính, thay đổi một số giá trị và cập nhật tài liệu có thể được thực hiện theo cách sau:

```java
// đọc thông tin của bản trình chiếu
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Có một cách khác để sử dụng các thuộc tính của một bản trình chiếu cụ thể làm mẫu để cập nhật thuộc tính trong các bản trình chiếu khác:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Một mẫu mới có thể được tạo từ đầu và sau đó dùng để cập nhật nhiều bản trình chiếu:

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Đặt Ngôn ngữ Kiểm tra chính tả**

Aspose.Slides cung cấp thuộc tính LanguageId (được hiển thị bởi lớp PortionFormat) để cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint sẽ được kiểm tra.

Mã Java này cho bạn thấy cách đặt ngôn ngữ kiểm tra chính tả cho PowerPoint: xxx Tại sao LanguageId lại thiếu trong lớp Java PortionFormat?

```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // đặt Id của ngôn ngữ kiểm tra chính tả

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt Ngôn ngữ Mặc định**

Mã Java này cho bạn thấy cách đặt ngôn ngữ mặc định cho toàn bộ bản trình chiếu PowerPoint:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Thêm một hình chữ nhật mới có văn bản
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Kiểm tra ngôn ngữ của phần đầu tiên
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ví dụ Trực tiếp**

Hãy thử **[Aspose.Slides Metadata](https://products.aspose.app/slides/vi/metadata)** trực tuyến để xem cách làm việc với các thuộc tính tài liệu qua API của Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## ***Câu hỏi thường gặp**

**Làm thế nào để tôi có thể xoá một thuộc tính built-in khỏi bản trình chiếu?**

Các thuộc tính built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xoá hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt giá trị rỗng nếu thuộc tính cụ thể cho phép.

**Nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại thì sẽ xảy ra gì?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xoá hoặc kiểm tra trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có, bạn có thể truy cập các thuộc tính bản trình chiếu mà không cần tải toàn bộ bản trình chiếu bằng cách sử dụng phương thức `getPresentationInfo` từ lớp [PresentationFactory](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationfactory/) . Sau đó, sử dụng phương thức `readDocumentProperties` được cung cấp bởi giao diện [IPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/) để đọc các thuộc tính một cách hiệu quả, tiết kiệm bộ nhớ và cải thiện hiệu suất.