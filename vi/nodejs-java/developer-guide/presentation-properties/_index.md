---
title: Quản lý Thuộc tính Bài thuyết trình trong JavaScript
linktitle: Thuộc tính Bài thuyết trình
type: docs
weight: 70
url: /vi/nodejs-java/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- thuộc tính bài thuyết trình
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
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các thuộc tính bài thuyết trình trong Aspose.Slides cho Node.js thông qua Java và tối ưu hoá việc tìm kiếm, xây dựng thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể dễ dàng truy cập và quản lý bằng API của Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bài thuyết trình thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/). Một thể hiện của lớp này được trả về bởi phương thức [Presentation.getDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Các ví dụ sau đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Lưu ý rằng các trường **Application** và **AppVersion** không thể được sửa đổi. Aspose.Slides sẽ ghi lại chúng mỗi khi lưu, vì vậy một bản trình bày đã lưu luôn báo "Aspose.Slides for Node.js via Java" và phiên bản của thư viện đã tạo ra nó. Bất kỳ giá trị nào được truyền cho `setNameOfApplication` sẽ bị bỏ qua khi bản trình bày được ghi.
{{% /alert %}} 

## **Quản lý Thuộc tính Bài thuyết trình**

Microsoft PowerPoint cung cấp tính năng thêm một số thuộc tính vào tệp bài thuyết trình. Các thuộc tính tài liệu này cho phép lưu trữ một số thông tin hữu ích cùng với tài liệu (tệp bài thuyết trình). Có hai loại thuộc tính tài liệu như sau

- Thuộc tính Được định nghĩa Hệ thống (Built-in)
- Thuộc tính Được định nghĩa Người dùng (Custom)

Các thuộc tính **Built-in** chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, v.v. Các thuộc tính **Custom** là những thuộc tính được người dùng định nghĩa dưới dạng cặp **Tên/Giá trị**, trong đó cả tên và giá trị đều do người dùng xác định. Sử dụng Aspose.Slides for Node.js via Java, các nhà phát triển có thể truy cập và sửa đổi các giá trị của thuộc tính built-in cũng như custom.

## **Thuộc tính Tài liệu trong PowerPoint**

Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của tệp bài thuyết trình. Bạn chỉ cần nhấp vào biểu tượng Office và sau đó chọn mục **Prepare | Properties | Advanced Properties** trong Microsoft PowerPoint 2007 như hình dưới đây:

|**Chọn mục Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Sau khi bạn chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint như được hiển thị trong hình dưới đây:

|**Hộp thoại Thuộc tính**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Trong **Hộp thoại Thuộc tính** ở trên, bạn có thể thấy có nhiều trang tab như **General**, **Summary**, **Statistics**, **Contents** và **Custom**. Tất cả các trang tab này cho phép cấu hình các loại thông tin khác nhau liên quan đến các tệp PowerPoint. Tab **Custom** được sử dụng để quản lý các thuộc tính tùy chỉnh của các tệp PowerPoint.

Làm việc với Thuộc tính Tài liệu bằng Aspose.Slides for Node.js via Java

Như đã mô tả ở trên, Aspose.Slides for Node.js via Java hỗ trợ hai loại thuộc tính tài liệu, đó là các thuộc tính **Built-in** và **Custom**. Vì vậy, các nhà phát triển có thể truy cập cả hai loại thuộc tính này bằng API của Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java cung cấp một lớp [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties) đại diện cho các thuộc tính tài liệu liên kết với một tệp bài thuyết trình thông qua thuộc tính **Presentation.DocumentProperties**.

Các nhà phát triển có thể sử dụng thuộc tính **DocumentProperties** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) để truy cập các thuộc tính tài liệu của các tệp bài thuyết trình như mô tả dưới đây:

## **Đọc các Thuộc tính Công cộng từ Bản trình bày Được Mã hóa**

Mật khẩu mở thường bảo vệ cả nội dung bản trình bày và các thuộc tính tài liệu. Khi một bản trình bày được mã hóa bằng cách truyền `false` vào [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), các thuộc tính tài liệu của nó vẫn ở trạng thái công cộng. Ứng dụng sau đó có thể truyền `true` vào [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) và đọc siêu dữ liệu công cộng mà không cần cung cấp mật khẩu mở.

Tùy chọn chỉ tải các thuộc tính tài liệu kiểm soát những gì Aspose.Slides tải; nó không giải mã bất kỳ gì. Nếu các thuộc tính được bao gồm trong quá trình mã hóa, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình bày không được mã hóa, tùy chọn này sẽ bị bỏ qua và toàn bộ bản trình bày sẽ được tải.

Ví dụ sau xác nhận chế độ tải thông qua [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) và sau đó đọc các thuộc tính built-in thông qua [Presentation.getDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, shape, media và các đối tượng khác của bản trình bày không khả dụng. Ứng dụng nên luôn kiểm tra [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) trước khi thực hiện thao tác yêu cầu mô hình đối tượng bản trình bày đầy đủ.

{{% alert color="warning" title="Warning" %}}
Siêu dữ liệu công cộng có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và các giá trị tùy chỉnh. Hãy mã hóa các thuộc tính nhạy cảm cùng với bản trình bày. Chỉ để chúng công cộng khi việc lập chỉ mục, phân loại, tìm kiếm hoặc hệ thống quản lý tài liệu có yêu cầu cụ thể truy cập chúng mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật Thuộc tính của Bản trình bày Được Mã hóa**

Đối với tệp PPTX được mã hóa, một bản trình bày được tải ở chế độ chỉ thuộc tính tài liệu nhằm mục đích đọc siêu dữ liệu công cộng. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ có siêu dữ liệu vì các thuộc tính công cộng phải đồng nhất với dữ liệu tương ứng trong bản trình bày đã mã hóa. Do đó, việc cập nhật chúng yêu cầu mật khẩu mở đúng và tải toàn bộ bản trình bày.

Ví dụ sau mở bản trình bày bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword), cập nhật các thuộc tính built-in công cộng, và lưu kết quả. Sau đó sử dụng [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) để xác nhận rằng mã hóa vẫn được giữ và mở lại siêu dữ liệu công cộng mà không cần mật khẩu để kiểm tra các giá trị mới:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình bày, nó phải coi các thuộc tính công cộng của tệp PPTX được mã hóa là chỉ đọc.

## **Truy cập Các Thuộc tính Built-in**

Các thuộc tính này được cung cấp bởi đối tượng [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties) bao gồm: **Creator** (Tác giả), **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in cuối cùng), **LastModifiedBy**, **Keywords**, **SharedDoc** (Có được chia sẻ giữa các nhà sản xuất khác nhau không?), **PresentationFormat**, **Subject** và **Title**.

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

## **Sửa đổi Các Thuộc tính Built-in**

Việc sửa đổi các thuộc tính built-in của tệp bài thuyết trình dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã trình diễn cách chúng ta có thể sửa đổi các thuộc tính tài liệu built-in của tệp bài thuyết trình bằng Aspose.Slides for Node.js via Java.

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
    // Lưu bản trình bày của bạn vào tệp
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ví dụ này sửa đổi các thuộc tính built-in của bản trình bày và có thể xem như hình dưới đây:

|**Các thuộc tính tài liệu Built-in sau khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Thêm Thuộc tính Tài liệu Tùy chỉnh**

Aspose.Slides for Node.js via Java cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho các thuộc tính tài liệu của bài thuyết trình. Một ví dụ được đưa ra dưới đây cho thấy cách đặt các thuộc tính tùy chỉnh cho một bản trình bày.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Lấy các Thuộc tính Tài liệu
    var dProps = pres.getDocumentProperties();
    // Thêm các thuộc tính tùy chỉnh
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

|**Các Thuộc tính Tài liệu Tùy chỉnh Đã Thêm**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Truy cập và Sửa đổi Các Thuộc tính Tùy chỉnh**

Aspose.Slides for Node.js via Java cũng cho phép các nhà phát triển truy cập các giá trị của các thuộc tính tùy chỉnh. Một ví dụ được đưa ra dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh này cho một bản trình bày.

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
    // Lưu bản trình bày của bạn vào tệp
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ví dụ này sửa đổi các thuộc tính tùy chỉnh của bản trình bày [PPTX ](https://docs.fileformat.com/presentation/pptx/). Các hình dưới đây cho thấy các thuộc tính tùy chỉnh của bản trình bày trước và sau khi sửa đổi:

|**Các Thuộc tính Tùy chỉnh Trước Khi Sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Các Thuộc tính Tùy chỉnh Sau Khi Sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Thuộc tính Tài liệu Nâng cao**

{{% alert color="info" title="Note" %}}
Các phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), và [WriteBindedPresentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) đã được thêm vào [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo), logic của bộ setter thuộc tính [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) đã được thay đổi.
{{% /alert %}}

Hai phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) và [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) đã được thêm vào lớp [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo). Chúng cung cấp truy cập nhanh vào các thuộc tính tài liệu và cho phép thay đổi và cập nhật các thuộc tính mà không cần tải toàn bộ bản trình bày.

Kịch bản tiêu biểu tải các thuộc tính, thay đổi một số giá trị và cập nhật tài liệu có thể được thực hiện theo cách sau:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// đọc thông tin của bản trình bày
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Có một cách khác để sử dụng các thuộc tính của một bản trình bày cụ thể làm mẫu để cập nhật thuộc tính trong các bản trình bày khác:

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

Một mẫu mới có thể được tạo từ đầu và sau đó được sử dụng để cập nhật nhiều bản trình bày:

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

## **Đặt Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp thuộc tính LanguageId (được cung cấp bởi lớp PortionFormat) để cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint được kiểm tra.

Mã JavaScript này cho bạn thấy cách đặt ngôn ngữ kiểm tra chính tả cho PowerPoint: xxx Tại sao LanguageId lại thiếu trong lớp JavaScript PortionFormat?

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

## **Đặt Ngôn ngữ Mặc định**

Mã JavaScript này cho bạn thấy cách đặt ngôn ngữ mặc định cho toàn bộ bản trình bày PowerPoint:

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
    // Kiểm tra ngôn ngữ của phần đầu tiên
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ví dụ Trực tiếp**

Thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu qua API của Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xóa một thuộc tính built-in khỏi bản trình bày?**

Các thuộc tính built-in là một phần không thể tách rời của bản trình bày và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình bày mà không tải đầy đủ bản trình bày không?**

Có. Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) và sau đó [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu đã lưu mà không cần tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Xem [Build a Lightweight Presentation Inventory](/slides/vi/nodejs-java/examine-presentation/) để có ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.

**Tôi có thể đọc các thuộc tính công cộng của một bản trình bày được mã hóa mà không cần mật khẩu mở không?**

Có. Việc mã hóa thuộc tính tài liệu phải đã được tắt trước khi bản trình bày được mã hóa, và bản trình bày phải được tải ở chế độ chỉ thuộc tính tài liệu.

**Tôi có thể cập nhật một tệp PPTX được mã hóa ở chế độ chỉ thuộc tính tài liệu không?**

Không. Dữ liệu thuộc tính công cộng và được mã hóa phải đồng nhất, vì vậy việc cập nhật tệp PPTX được mã hóa yêu cầu tải toàn bộ bản trình bày với mật khẩu mở đúng.