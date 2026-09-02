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
- chỉnh sửa thuộc tính
- siêu dữ liệu tài liệu
- chỉnh sửa siêu dữ liệu
- ngôn ngữ kiểm tra chính tả
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Nắm vững các thuộc tính bản trình chiếu trong Aspose.Slides cho Java và tối ưu hóa việc tìm kiếm, xây dựng thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý dễ dàng bằng API Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties/) . Một thể hiện của giao diện này được trả về bởi phương thức [Presentation.getDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getDocumentProperties--) . Các ví dụ sau cho thấy cách đọc, sửa và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Lưu ý rằng các trường **Application** và **AppVersion** không thể được sửa đổi. Aspose.Slides ghi lại chúng mỗi khi lưu, vì vậy một bản trình chiếu đã lưu luôn báo cáo “Aspose.Slides for Java” và phiên bản của thư viện đã tạo ra nó. Bất kỳ giá trị nào được truyền vào `setNameOfApplication` sẽ bị bỏ qua khi bản trình chiếu được ghi.
{{% /alert %}} 

## **Thuộc tính tài liệu trong PowerPoint**

Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp bản trình chiếu. Bạn chỉ cần nhấn vào biểu tượng Office và sau đó chọn mục menu **Prepare | Properties | Advanced Properties** của Microsoft PowerPoint 2007 như hình dưới đây:

|**Chọn mục menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Sau khi bạn chọn mục menu **Advanced Properties**, một hộp thoại sẽ xuất hiện, cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint như trong hình dưới đây:

|**Đối thoại Thuộc tính**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Trong **Properties Dialog** trên, bạn có thể thấy có nhiều trang tab như **General**, **Summary**, **Statistics**, **Contents** và **Custom**. Tất cả các trang tab này cho phép cấu hình các loại thông tin khác nhau liên quan đến các tệp PowerPoint. Tab **Custom** được sử dụng để quản lý các thuộc tính tùy chỉnh của các tệp PowerPoint.

Làm việc với Thuộc tính Tài liệu bằng Aspose.Slides cho Java

Như đã mô tả ở trên, Aspose.Slides cho Java hỗ trợ hai loại thuộc tính tài liệu, đó là các thuộc tính **Built-in** và **Custom**. Do đó, các nhà phát triển có thể truy cập cả hai loại thuộc tính thông qua API Aspose.Slides cho Java. Aspose.Slides cho Java cung cấp một lớp [IDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties) đại diện cho các thuộc tính tài liệu liên kết với một tệp bản trình chiếu thông qua thuộc tính **Presentation.DocumentProperties**.

Các nhà phát triển có thể sử dụng thuộc tính **IDocumentProperties** được công khai bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) để truy cập các thuộc tính tài liệu của các tệp bản trình chiếu như mô tả bên dưới:

## **Truy cập Thuộc tính Built-in**

Các thuộc tính này được hiển thị bởi đối tượng [IDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties) bao gồm: **Creator** (Tác giả), **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in cuối cùng), **LastModifiedBy**, **Keywords**, **SharedDoc** (Có được chia sẻ giữa các nhà sản xuất khác nhau không?), **PresentationFormat**, **Subject** và **Title**

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho bài thuyết trình
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu đến đối tượng IDocumentProperties liên kết với Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Hiển thị các thuộc tính tích hợp
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

## **Sửa Thuộc tính Built-in**

Việc sửa các thuộc tính Built-in của tệp bản trình chiếu dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách sửa các thuộc tính tài liệu Built-in của tệp bản trình chiếu bằng Aspose.Slides cho Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu đến đối tượng IDocumentProperties liên kết với Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Đặt các thuộc tính tích hợp
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

Ví dụ này sửa các thuộc tính Built-in của bản trình chiếu và có thể xem được như hình dưới đây:

|**Thuộc tính tài liệu Built-in sau khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Thêm Thuộc tính Tài liệu Tùy chỉnh**

Aspose.Slides cho Java cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho thuộc tính tài liệu của bản trình chiếu. Ví dụ dưới đây thêm ba thuộc tính tùy chỉnh, sau đó tra cứu tên lưu tại chỉ mục 2 và xóa thuộc tính đó, vì vậy bản trình chiếu được lưu giữ lại hai thuộc tính. Các thuộc tính tùy chỉnh được sắp xếp theo thứ tự bảng chữ cái, không phải theo thứ tự chúng được thêm vào.

```java
import com.aspose.slides.*;

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

|**Thuộc tính Tài liệu Tùy chỉnh Đã Thêm**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Truy cập và Sửa Thuộc tính Tùy chỉnh**

Aspose.Slides cho Java cũng cho phép các nhà phát triển truy cập giá trị của các thuộc tính tùy chỉnh. Một ví dụ được đưa ra dưới đây cho thấy cách bạn có thể truy cập và sửa tất cả các thuộc tính tùy chỉnh cho một bản trình chiếu.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu đến đối tượng DocumentProperties liên kết với Presentation
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

Ví dụ này sửa các thuộc tính tùy chỉnh của bản trình chiếu [PPTX](https://docs.fileformat.com/presentation/pptx/). Các hình dưới đây hiển thị thuộc tính tùy chỉnh của bản trình chiếu trước và sau khi sửa đổi:

|**Thuộc tính Tùy chỉnh trước khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Thuộc tính Tùy chỉnh sau khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Thuộc tính Tài liệu Nâng cao**

{{% alert color="info" title="Note" %}}
Các phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), và [WriteBindedPresentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) đã được thêm vào [IPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo), logic của bộ đặt thuộc tính [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) đã được thay đổi.
{{% /alert %}} 

Hai phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) và [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) đã được thêm vào giao diện [IPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPresentationInfo). Chúng cung cấp cách truy cập nhanh vào các thuộc tính tài liệu và cho phép thay đổi, cập nhật các thuộc tính mà không cần tải toàn bộ bản trình chiếu.

Kịch bản điển hình là tải các thuộc tính, thay đổi một số giá trị và cập nhật tài liệu có thể được triển khai theo cách sau:

```java
import com.aspose.slides.*;

// đọc thông tin của bản trình chiếu
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// lấy các thuộc tính hiện tại
IDocumentProperties props = info.readDocumentProperties();

// đặt giá trị mới cho các trường Tác giả và Tiêu đề
props.setAuthor("New Author");
props.setTitle("New Title");

// cập nhật bản trình chiếu với các giá trị mới
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Có một cách khác để sử dụng các thuộc tính của một bản trình chiếu cụ thể như mẫu để cập nhật thuộc tính trong các bản trình chiếu khác:

```java
import com.aspose.slides.*;

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Một mẫu mới có thể được tạo từ đầu và sau đó sử dụng để cập nhật nhiều bản trình chiếu:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Thiết lập Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp thuộc tính LanguageId (được công khai bởi lớp PortionFormat) để cho phép bạn thiết lập ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint sẽ được kiểm tra.

Mã Java này cho bạn thấy cách thiết lập ngôn ngữ kiểm tra chính tả cho một tệp PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

## **Thiết lập Ngôn ngữ Mặc định**

Mã Java này cho bạn thấy cách thiết lập ngôn ngữ mặc định cho toàn bộ bản trình chiếu PowerPoint:

```java
import com.aspose.slides.*;

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

Thử[**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata)ứng dụng trực tuyến để xem cách làm việc với thuộc tính tài liệu qua API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xóa một thuộc tính Built-in khỏi bản trình chiếu?**

Các thuộc tính Built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) và sau đó [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) để đọc siêu dữ liệu tài liệu đã lưu mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) . Xem [Build a Lightweight Presentation Inventory](/slides/vi/java/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các giới hạn theo định dạng.