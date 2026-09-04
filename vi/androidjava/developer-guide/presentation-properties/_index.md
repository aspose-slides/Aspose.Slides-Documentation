---
title: Quản lý Thuộc tính Bản trình chiếu trên Android
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/androidjava/presentation-properties/
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
- ngôn ngữ kiểm tra
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Kiểm soát các thuộc tính bản trình chiếu trong Aspose.Slides cho Android qua Java và tối ưu hoá tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Introduction**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này có thể dễ dàng được truy cập và quản lý bằng API Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với thuộc tính tài liệu của bản trình chiếu thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties/) . Một thể hiện của giao diện này được trả về bởi [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) . Các ví dụ sau cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Vui lòng lưu ý rằng các trường **Application** và **AppVersion** không thể sửa đổi. Aspose.Slides sẽ ghi lại chúng mỗi khi lưu, vì vậy bản trình chiếu đã lưu luôn báo tên sản phẩm Aspose.Slides và phiên bản của thư viện đã tạo ra. Bất kỳ giá trị nào được truyền cho `setNameOfApplication` sẽ bị bỏ qua khi bản trình chiếu được ghi.
{{% /alert %}} 

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp bản trình chiếu. Tất cả những gì bạn cần làm là nhấp vào biểu tượng Office và sau đó mục **Prepare | Properties | Advanced Properties** của Microsoft PowerPoint 2007 như hình dưới đây:

|**Chọn mục Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Sau khi bạn chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint như hình dưới đây:

|**Hộp thoại Thuộc tính**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Trong **Hộp thoại Thuộc tính** trên, bạn có thể thấy có nhiều tab như **General**, **Summary**, **Statistics**, **Contents** và **Custom**. Tất cả các tab này cho phép cấu hình các loại thông tin khác nhau liên quan đến tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính tùy chỉnh của tệp PowerPoint.

## **Làm việc với Thuộc tính Tài liệu bằng Aspose.Slides cho Android qua Java**

Như đã mô tả ở trên, Aspose.Slides cho Android qua Java hỗ trợ hai loại thuộc tính tài liệu, là **Built-in** và **Custom**. Vì vậy, các nhà phát triển có thể truy cập cả hai loại thuộc tính bằng cách sử dụng API Aspose.Slides cho Android qua Java. Aspose.Slides cho Android qua Java cung cấp lớp [IDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties) đại diện cho các thuộc tính tài liệu liên quan đến một tệp bản trình chiếu thông qua thuộc tính **Presentation.DocumentProperties**.

Các nhà phát triển có thể sử dụng thuộc tính **IDocumentProperties** được công bố bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) để truy cập các thuộc tính tài liệu của các tệp bản trình chiếu như mô tả dưới đây:

## **Read Public Properties from an Encrypted Presentation**

Mật khẩu mở thường bảo vệ cả nội dung bản trình chiếu và các thuộc tính tài liệu. Khi một bản trình chiếu được mã hóa bằng cách truyền `false` vào [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), các thuộc tính tài liệu của nó vẫn ở trạng thái công khai. Ứng dụng sau đó có thể truyền `true` vào [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) và đọc siêu dữ liệu công khai mà không cần cung cấp mật khẩu mở.

Tùy chọn chỉ tải thuộc tính tài liệu kiểm soát những gì Aspose.Slides tải; nó không giải mã bất kỳ thứ gì. Nếu các thuộc tính đã được bao gồm trong quá trình mã hóa, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình chiếu không được mã hóa, tùy chọn sẽ bị bỏ qua và toàn bộ bản trình chiếu sẽ được tải.

Ví dụ sau xác nhận chế độ tải thông qua [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) và sau đó đọc các thuộc tính built‑in qua [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, shape, media và các đối tượng khác của bản trình chiếu sẽ không khả dụng. Ứng dụng nên luôn kiểm tra [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) trước khi thực hiện thao tác yêu cầu mô hình đối tượng bản trình chiếu đầy đủ.

{{% alert color="warning" title="Warning" %}}
Siêu dữ liệu công khai có thể lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, nhận xét và các giá trị tùy chỉnh. Hãy mã hóa các thuộc tính nhạy cảm cùng với bản trình chiếu. Chỉ để chúng công khai khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu có yêu cầu cụ thể truy cập mà không cần mật khẩu.
{{% /alert %}}

## **Update Properties of an Encrypted Presentation**

Đối với tệp PPTX được mã hóa, một bản trình chiếu được tải ở chế độ chỉ thuộc tính tài liệu được thiết kế để đọc siêu dữ liệu công khai. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ có siêu dữ liệu này vì các thuộc tính công khai phải đồng nhất với dữ liệu tương ứng bên trong bản trình chiếu đã mã hóa. Do đó việc cập nhật chúng đòi hỏi mật khẩu mở đúng và tải toàn bộ bản trình chiếu.

Ví dụ sau mở bản trình chiếu bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), cập nhật các thuộc tính built‑in công khai, và lưu kết quả. Sau đó sử dụng [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) để xác minh rằng việc mã hóa vẫn được giữ và mở lại siêu dữ liệu công khai mà không cần mật khẩu để kiểm tra các giá trị mới:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình chiếu, nó phải coi các thuộc tính công khai của tệp PPTX được mã hóa là chỉ đọc.

## **Access Built-in Properties**

Các thuộc tính được công bố bởi đối tượng [IDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties) bao gồm: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** và **Title**.

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation đại diện cho bản trình chiếu
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu đến đối tượng IDocumentProperties liên kết với Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Hiển thị các thuộc tính tích hợp sẵn
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

## **Modify Built-in Properties**

Việc sửa đổi các thuộc tính built‑in của các tệp bản trình chiếu cũng đơn giản như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách sửa đổi các thuộc tính tài liệu built‑in của tệp bản trình chiếu bằng Aspose.Slides cho Android qua Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu đến đối tượng IDocumentProperties liên kết với Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Đặt các thuộc tính tích hợp sẵn
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Lưu bản trình chiếu của bạn vào một tệp
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ví dụ này sửa đổi các thuộc tính built‑in của bản trình chiếu và có thể xem như hình dưới:

|**Thuộc tính tài liệu built‑in sau khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**

Aspose.Slides cho Android qua Java cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho thuộc tính tài liệu của bản trình chiếu. Ví dụ dưới đây thêm ba thuộc tính tùy chỉnh, sau đó tra cứu tên lưu tại chỉ mục 2 và xoá thuộc tính đó, vì vậy bản trình chiếu đã lưu giữ lại hai thuộc tính còn lại. Các thuộc tính tùy chỉnh được sắp xếp theo thứ tự chữ cái, không phải theo thứ tự thêm vào.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Lấy Thuộc tính Tài liệu
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Thêm thuộc tính Tùy chỉnh
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

|**Thuộc tính tài liệu tùy chỉnh đã thêm**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Access and Modify Custom Properties**

Aspose.Slides cho Android qua Java cũng cho phép các nhà phát triển truy cập các giá trị của thuộc tính tùy chỉnh. Dưới đây là một ví dụ cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh này cho một bản trình chiếu.

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
    
    // Lưu bản trình chiếu của bạn vào một tệp
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ví dụ này sửa đổi các thuộc tính tùy chỉnh của bản trình chiếu [PPTX](https://docs.fileformat.com/presentation/pptx/). Các hình dưới đây hiển thị các thuộc tính tùy chỉnh của bản trình chiếu trước và sau khi sửa đổi:

|**Thuộc tính tùy chỉnh trước khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Thuộc tính tùy chỉnh sau khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="info" title="Note" %}}
Các phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), và [WriteBindedPresentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) đã được thêm vào [IPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentationInfo), logic của bộ đặt thuộc tính [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) đã được thay đổi.
{{% /alert %}} 

Hai phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) và [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) đã được thêm vào giao diện [IPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentationInfo). Chúng cung cấp cách truy cập nhanh vào các thuộc tính tài liệu và cho phép thay đổi, cập nhật thuộc tính mà không cần tải toàn bộ bản trình chiếu.

Kịch bản điển hình là tải các thuộc tính, thay đổi một số giá trị và cập nhật tài liệu có thể được thực hiện như sau:

```java
import com.aspose.slides.*;

// đọc thông tin của bản trình chiếu
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// lấy các thuộc tính hiện tại
IDocumentProperties props = info.readDocumentProperties();

// đặt giá trị mới cho các trường Author và Title
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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

Một mẫu mới có thể được tạo từ đầu và sau đó dùng để cập nhật nhiều bản trình chiếu:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Set Proofing Language**

Aspose.Slides cung cấp thuộc tính LanguageId (được công bố bởi lớp PortionFormat) để cho phép bạn đặt ngôn ngữ kiểm tra cho tài liệu PowerPoint. Ngôn ngữ kiểm tra là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint sẽ được kiểm tra.

Đoạn mã Java sau cho bạn thấy cách đặt ngôn ngữ kiểm tra cho PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // đặt Id của ngôn ngữ kiểm tra

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Default Language**

Đoạn mã Java sau cho bạn thấy cách đặt ngôn ngữ mặc định cho toàn bộ bản trình chiếu PowerPoint:

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

## **Live Example**

Hãy thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu qua API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **FAQ**

**Làm thế nào để loại bỏ một thuộc tính built‑in khỏi bản trình chiếu?**

Các thuộc tính built‑in là một phần không thể tách rời của bản trình chiếu và không thể được loại bỏ hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt thành rỗng nếu thuộc tính cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xoá hoặc kiểm tra thuộc tính trước, vì Aspose.Slides tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) và sau đó [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) để đọc siêu dữ liệu tài liệu đã lưu mà không cần tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) . Xem [Build a Lightweight Presentation Inventory](/slides/vi/androidjava/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các giới hạn theo định dạng.

**Tôi có thể đọc các thuộc tính công khai của một bản trình chiếu đã mã hóa mà không có mật khẩu mở không?**

Có. Thuộc tính tài liệu phải đã được tắt mã hóa trước khi bản trình chiếu được mã hóa, và bản trình chiếu phải được tải ở chế độ chỉ thuộc tính tài liệu.

**Tôi có thể cập nhật một tệp PPTX đã mã hóa ở chế độ chỉ thuộc tính tài liệu không?**

Không. Dữ liệu thuộc tính công khai và đã mã hóa phải đồng nhất, vì vậy việc cập nhật một tệp PPTX đã mã hóa yêu cầu tải toàn bộ bản trình chiếu với mật khẩu mở đúng.