---
title: Quản lý Thuộc tính Bản trình chiếu trong JavaScript
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/nodejs-java/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- Thuộc tính bản trình chiếu
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
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Nắm bắt các thuộc tính bản trình chiếu trong Aspose.Slides cho Node.js qua Java và tối ưu hoá tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý dễ dàng bằng cách sử dụng API Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/) . Một thể hiện của lớp này được trả về bởi phương thức [Presentation.getDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Các ví dụ dưới đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="primary" %}} 
Lưu ý rằng bạn không thể đặt giá trị cho các trường **Application** và **Producer**, vì Aspose Ltd. và Aspose.Slides cho Node.js thông qua Java x.x.x sẽ được hiển thị trong các trường này.
{{% /alert %}} 

## **Quản lý Thuộc tính Bản Trình chiếu**

Microsoft PowerPoint cung cấp một tính năng để thêm một số thuộc tính vào các tệp bản trình chiếu. Các thuộc tính tài liệu này cho phép lưu trữ một số thông tin hữu ích cùng với tài liệu (các tệp bản trình chiếu). Có hai loại thuộc tính tài liệu như sau

- Thuộc tính Được Định nghĩa Hệ thống (Built-in)
- Thuộc tính Được Định nghĩa Người dùng (Custom)

**Built-in** các thuộc tính chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu và các thông tin khác. **Custom** các thuộc tính là những thuộc tính được người dùng định nghĩa dưới dạng các cặp **Name/Value**, trong đó cả tên và giá trị đều do người dùng xác định. Sử dụng Aspose.Slides cho Node.js qua Java, các nhà phát triển có thể truy cập và sửa đổi giá trị của các thuộc tính built-in cũng như custom.

## **Thuộc tính Tài liệu trong PowerPoint**

Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp bản trình chiếu. Tất cả những gì bạn cần làm là nhấp vào biểu tượng Office và sau đó chọn mục menu **Prepare | Properties | Advanced Properties** trong Microsoft PowerPoint 2007 như hình dưới đây:

|**Chọn mục menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Sau khi bạn chọn mục menu **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint như được hiển thị dưới đây:

|**Hộp thoại Thuộc tính**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Trong **Hộp thoại Thuộc tính** trên, bạn có thể thấy có nhiều trang tab như **General**, **Summary**, **Statistics**, **Contents** và **Custom**. Tất cả các trang tab này cho phép cấu hình các loại thông tin khác nhau liên quan đến các tệp PowerPoint. Tab **Custom** được sử dụng để quản lý các thuộc tính custom của các tệp PowerPoint.

Làm việc với Thuộc tính Tài liệu bằng Aspose.Slides cho Node.js qua Java

Như đã mô tả ở trên, Aspose.Slides cho Node.js qua Java hỗ trợ hai loại thuộc tính tài liệu, đó là các thuộc tính **Built-in** và **Custom**. Vì vậy, các nhà phát triển có thể truy cập cả hai loại thuộc tính thông qua API Aspose.Slides cho Node.js qua Java. Aspose.Slides cho Node.js qua Java cung cấp lớp [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties) đại diện cho các thuộc tính tài liệu được liên kết với một tệp bản trình chiếu thông qua thuộc tính **Presentation.DocumentProperties**.

Các nhà phát triển có thể sử dụng thuộc tính **DocumentProperties** được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) để truy cập các thuộc tính tài liệu của các tệp bản trình chiếu như mô tả dưới đây:

## **Truy cập Thuộc tính Built-in**

Những thuộc tính được cung cấp bởi đối tượng [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties) bao gồm: **Creator** (Tác giả), **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in cuối cùng), **LastModifiedBy**, **Keywords**, **SharedDoc** (Có được chia sẻ giữa các nhà sản xuất khác nhau không?), **PresentationFormat**, **Subject** và **Title**.

```javascript
// Khởi tạo lớp Presentation đại diện cho bản trình chiếu
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Tạo một tham chiếu tới đối tượng IDocumentProperties liên kết với Presentation
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

Sửa đổi các thuộc tính built-in của tệp bản trình chiếu dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách chúng ta có thể sửa đổi các thuộc tính tài liệu built-in của tệp bản trình chiếu bằng cách sử dụng Aspose.Slides cho Node.js qua Java.

```javascript
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
    // Lưu bản trình chiếu của bạn vào tệp
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ví dụ này sửa đổi các thuộc tính built-in của bản trình chiếu và có thể xem như hình dưới đây:

|**Thuộc tính tài liệu Built-in sau khi sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Thêm Thuộc tính Tài liệu Custom**

Aspose.Slides cho Node.js qua Java cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho các thuộc tính tài liệu của bản trình chiếu. Một ví dụ được đưa ra dưới đây cho thấy cách đặt các thuộc tính custom cho một bản trình chiếu.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lấy thuộc tính tài liệu
    var dProps = pres.getDocumentProperties();
    // Thêm các thuộc tính tùy chỉnh
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Lấy tên thuộc tính tại chỉ mục cụ thể
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Xóa thuộc tính đã chọn
    dProps.removeCustomProperty(getPropertyName);
    // Lưu bản trình chiếu
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Thuộc tính Tài liệu Custom Đã Thêm**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Truy cập và Sửa đổi Thuộc tính Custom**

Aspose.Slides cho Node.js qua Java cũng cho phép các nhà phát triển truy cập các giá trị của các thuộc tính custom. Một ví dụ được đưa ra dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính custom cho một bản trình chiếu.

```javascript
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
    // Lưu bản trình chiếu của bạn vào tệp
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ví dụ này sửa đổi các thuộc tính custom của bản trình chiếu [PPTX ](https://docs.fileformat.com/presentation/pptx/). Các hình ảnh sau đây cho thấy các thuộc tính custom của bản trình chiếu trước và sau khi sửa đổi:

|**Thuộc tính Custom trước Khi Sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Thuộc tính Custom sau Khi Sửa đổi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Thuộc tính Tài liệu Nâng cao**

{{% alert color="primary" %}} 
Đã thêm các phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), và [WriteBindedPresentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) vào lớp [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo), logic của bộ đặt giá trị thuộc tính [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) đã được thay đổi.
{{% /alert %}} 

Hai phương thức mới [ReadDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) và [UpdateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) đã được thêm vào lớp [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo). Chúng cung cấp cách truy cập nhanh vào các thuộc tính tài liệu và cho phép thay đổi và cập nhật các thuộc tính mà không cần tải toàn bộ bản trình chiếu.

Kịch bản điển hình tải các thuộc tính, thay đổi một số giá trị và cập nhật tài liệu có thể được thực hiện theo cách sau:

```javascript
// đọc thông tin của bản trình chiếu
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Cũng có một cách khác để sử dụng các thuộc tính của một bản trình chiếu cụ thể như mẫu để cập nhật các thuộc tính trong các bản trình chiếu khác:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Một mẫu mới có thể được tạo từ đầu và sau đó được sử dụng để cập nhật nhiều bản trình chiếu:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Đặt Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp thuộc tính LanguageId (được cung cấp bởi lớp PortionFormat) để cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint sẽ được kiểm tra.

Mã JavaScript này cho bạn thấy cách đặt ngôn ngữ kiểm tra chính tả cho PowerPoint: xxx Tại sao LanguageId lại thiếu trong lớp PortionFormat của JavaScript?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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

Mã JavaScript này cho bạn thấy cách đặt ngôn ngữ mặc định cho toàn bộ bản trình chiếu PowerPoint:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Thêm một hình chữ nhật mới có văn bản
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Kiểm tra ngôn ngữ của đoạn văn bản đầu tiên
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu qua API Aspose.Slides:

[![Xem & Chỉnh sửa Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## ***CÂU HỎI THƯỜNG GẶP**

**Làm sao tôi có thể xóa một thuộc tính built-in khỏi bản trình chiếu?**

Các thuộc tính built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính custom đã tồn tại?**

Nếu bạn thêm một thuộc tính custom đã tồn tại, giá trị hiện có sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Đúng, bạn có thể truy cập các thuộc tính bản trình chiếu mà không cần tải toàn bộ bản trình chiếu bằng cách sử dụng phương thức `getPresentationInfo` từ lớp [PresentationFactory](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationfactory/). Sau đó, sử dụng phương thức `readDocumentProperties` do lớp [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/) cung cấp để đọc các thuộc tính một cách hiệu quả, tiết kiệm bộ nhớ và cải thiện hiệu năng.