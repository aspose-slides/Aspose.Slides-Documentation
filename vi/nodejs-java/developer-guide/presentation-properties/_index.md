---
title: Quản lý Thuộc tính Bản trình bày trong JavaScript
linktitle: Thuộc tính Bản trình bày
type: docs
weight: 70
url: /vi/nodejs-java/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- Thuộc tính bản trình bày
- Thuộc tính tài liệu
- Thuộc tính tích hợp
- Thuộc tính tùy chỉnh
- Thuộc tính nâng cao
- Quản lý thuộc tính
- Sửa đổi thuộc tính
- Siêu dữ liệu tài liệu
- Chỉnh sửa siêu dữ liệu
- Ngôn ngữ kiểm tra chính tả
- Ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Nắm bắt các thuộc tính bản trình bày trong Aspose.Slides cho Node.js qua Java và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể dễ dàng được truy cập và quản lý bằng API của Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình bày thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/) . Một thể hiện của lớp này được trả về bởi phương thức [Presentation.getDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Các ví dụ dưới đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Lưu ý rằng các trường **Application** và **AppVersion** không thể sửa đổi. Aspose.Slides sẽ ghi lại chúng mỗi khi lưu, vì vậy một bản trình bày đã lưu luôn báo cáo "Aspose.Slides for Node.js via Java" và phiên bản của thư viện đã tạo ra nó. Bất kỳ giá trị nào được truyền vào `setNameOfApplication` sẽ bị bỏ qua khi bản trình bày được ghi.
{{% /alert %}} 

## **Quản lý thuộc tính bản trình bày**

Microsoft PowerPoint cung cấp tính năng thêm một số thuộc tính vào các tệp bản trình bày. Các thuộc tính tài liệu này cho phép lưu trữ một số thông tin hữu ích cùng với các tài liệu (tệp bản trình bày). Có hai loại thuộc tính tài liệu như sau

- Thuộc tính Được định nghĩa hệ thống (Built-in) Properties
- Thuộc tính do người dùng định nghĩa (Custom) Properties

Thuộc tính **Built-in** chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, v.v. Thuộc tính **Custom** là những thuộc tính được người dùng định nghĩa dưới dạng cặp **Tên/Giá trị**, trong đó cả tên và giá trị đều do người dùng xác định. Sử dụng Aspose.Slides for Node.js via Java, các nhà phát triển có thể truy cập và sửa đổi giá trị của các thuộc tính built-in cũng như custom.

## **Thuộc tính tài liệu trong PowerPoint**

Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp bản trình bày. Tất cả những gì bạn cần làm là nhấp vào biểu tượng Office và sau đó vào mục **Prepare | Properties | Advanced Properties** của Microsoft PowerPoint 2007 như hình dưới đây:

|**Chọn mục Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Sau khi bạn chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint như hình dưới đây:

|**Hộp thoại Thuộc tính**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Trong **Hộp thoại Thuộc tính** ở trên, bạn có thể thấy có nhiều trang tab như **General**, **Summary**, **Statistics**, **Contents** và **Custom**. Tất cả các trang tab này cho phép cấu hình các loại thông tin khác nhau liên quan đến các tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính tùy chỉnh của các tệp PowerPoint.

Làm việc với Thuộc tính Tài liệu bằng Aspose.Slides for Node.js via Java

Như đã mô tả ở trên, Aspose.Slides for Node.js via Java hỗ trợ hai loại thuộc tính tài liệu, đó là các thuộc tính **Built-in** và **Custom**. Do đó, các nhà phát triển có thể truy cập cả hai loại thuộc tính này bằng API của Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java cung cấp một lớp [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties) đại diện cho các thuộc tính tài liệu liên kết với một tệp bản trình bày thông qua thuộc tính **Presentation.DocumentProperties**.

Các nhà phát triển có thể sử dụng thuộc tính **DocumentProperties** do đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) cung cấp để truy cập các thuộc tính tài liệu của các tệp bản trình bày như mô tả bên dưới:

## **Truy cập Thuộc tính Built-in**

Các thuộc tính được cung cấp bởi đối tượng [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties) bao gồm: **Creator** (Tác giả), **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in lần cuối), **LastModifiedBy**, **SharedDoc** (Có được chia sẻ giữa các nhà sản xuất khác nhau không?), **PresentationFormat**, **Subject** và **Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo lớp Presentation đại diện cho bản trình bày
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu tới đối tượng IDocumentProperties liên kết với Presentation
    var dp = pres.getDocumentProperties();
    // Hiển thị các thuộc tính tích hợp
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sửa đổi Thuộc tính Built-in**

Việc sửa đổi các thuộc tính built-in của tệp bản trình bày cũng dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách chúng ta có thể sửa đổi các thuộc tính tài liệu built-in của tệp bản trình bày bằng Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu tới đối tượng IDocumentProperties liên kết với Presentation
    var dp = pres.getDocumentProperties();
    // Đặt các thuộc tính tích hợp
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Lưu bản trình bày của bạn vào file
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ví dụ này sửa đổi các thuộc tính built-in của bản trình bày và có thể xem như hình dưới đây:

|**Thuộc tính tài liệu Built-in sau khi sửa đổi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Thêm Thuộc tính Tài liệu Tùy chỉnh**

Aspose.Slides for Node.js via Java cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho các thuộc tính tài liệu của bản trình bày. Một ví dụ được đưa ra dưới đây cho thấy cách đặt các thuộc tính tùy chỉnh cho một bản trình bày.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Lấy Thuộc tính Tài liệu
    var dProps = pres.getDocumentProperties();
    // Thêm thuộc tính Tùy chỉnh
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Lấy tên thuộc tính tại chỉ mục cụ thể
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Xóa thuộc tính đã chọn
    dProps.removeCustomProperty(getPropertyName);
    // Lưu bản trình bày
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Thuộc tính Tài liệu Tùy chỉnh Đã Thêm**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Aspose.Slides for Node.js via Java cũng cho phép các nhà phát triển truy cập giá trị của các thuộc tính tùy chỉnh. Một ví dụ được đưa ra dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh này cho một bản trình bày.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu tới đối tượng DocumentProperties liên kết với Presentation
    var dp = pres.getDocumentProperties();
    // Truy cập và sửa đổi các thuộc tính tùy chỉnh
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Hiển thị tên và giá trị của các thuộc tính tùy chỉnh
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Sửa đổi giá trị của các thuộc tính tùy chỉnh
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Lưu bản trình bày của bạn vào file
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ví dụ này sửa đổi các thuộc tính tùy chỉnh của bản trình bày [PPTX ](https://docs.fileformat.com/presentation/pptx/). Các hình ảnh sau đây hiển thị các thuộc tính tùy chỉnh của bản trình bày trước và sau khi sửa đổi:

|**Thuộc tính Tùy chỉnh Trước Khi Sửa đổi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Thuộc tính Tùy chỉnh Sau Khi Sửa đổi**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Thuộc tính Tài liệu Nâng cao**

{{% alert color="info" title="Note" %}}
Đã thêm các phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), và [WriteBindedPresentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) vào [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo), logic của bộ thiết lập thuộc tính [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) đã được thay đổi.
{{% /alert %}} 

Hai phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) và [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) đã được thêm vào lớp [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo) . Chúng cung cấp truy cập nhanh vào các thuộc tính tài liệu và cho phép thay đổi và cập nhật các thuộc tính mà không cần tải toàn bộ bản trình bày.

Kịch bản điển hình tải các thuộc tính, thay đổi một số giá trị và cập nhật tài liệu có thể được thực hiện theo cách sau:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// đọc thông tin của bản trình bày
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// lấy các thuộc tính hiện tại
var props = info.readDocumentProperties();
// đặt giá trị mới cho các trường Author và Title
props.setAuthor("New Author");
props.setTitle("New Title");
// cập nhật bản trình bày với các giá trị mới
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Cũng có một cách khác để sử dụng các thuộc tính của một bản trình bày cụ thể làm mẫu để cập nhật các thuộc tính trong các bản trình bày khác:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
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

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Một mẫu mới có thể được tạo từ đầu và sau đó sử dụng để cập nhật nhiều bản trình bày:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
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

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Thiết lập Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp thuộc tính LanguageId (được lớp PortionFormat công bố) để cho phép bạn thiết lập ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint sẽ được kiểm tra.

Mã JavaScript này cho bạn thấy cách thiết lập ngôn ngữ kiểm tra chính tả cho PowerPoint: xxx Tại sao LanguageId lại thiếu trong lớp JavaScript PortionFormat?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// đặt Id của ngôn ngữ kiểm tra chính tả
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thiết lập Ngôn ngữ Mặc định**

Mã JavaScript này cho bạn thấy cách thiết lập ngôn ngữ mặc định cho toàn bộ bản trình bày PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Thêm một hình chữ nhật mới có văn bản
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Kiểm tra ngôn ngữ của phần tử đầu tiên
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu qua API của Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để tôi có thể xóa một thuộc tính built-in khỏi bản trình bày?**

Thuộc tính built-in là một phần không thể tách rời của bản trình bày và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình bày mà không tải toàn bộ bản trình bày không?**

Đúng vậy. Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) và sau đó [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu được lưu trữ mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) . Xem [Build a Lightweight Presentation Inventory](/slides/vi/nodejs-java/examine-presentation/) để có một ví dụ báo cáo hoàn chỉnh và các giới hạn theo định dạng.