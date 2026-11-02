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
- Thuộc tính tích hợp sẵn
- Thuộc tính tùy chỉnh
- Thuộc tính nâng cao
- Quản lý thuộc tính
- Sửa đổi thuộc tính
- Siêu dữ liệu tài liệu
- Chỉnh sửa siêu dữ liệu
- Ngôn ngữ kiểm tra
- Ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý toàn diện các thuộc tính bản trình chiếu trong Aspose.Slides cho Node.js qua Java và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides for Node.js via Java hỗ trợ các thuộc tính tài liệu **tích hợp sẵn** và **tùy chỉnh**. Sử dụng các thuộc tính này để đọc và cập nhật siêu dữ liệu của bản trình chiếu, chẳng hạn như tác giả, tiêu đề và các giá trị do người dùng định nghĩa.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). Một phiên bản của lớp này được trả về bởi [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Các ví dụ sau cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Aspose.Slides quản lý siêu dữ liệu ứng dụng và nhà sản xuất khi lưu bản trình chiếu; các trường này xác định phần mềm đã tạo ra đầu ra.
{{% /alert %}}

## **Quản lý Thuộc tính Bản trình chiếu**

Thuộc tính tài liệu lưu trữ thông tin mô tả cùng với nội dung bản trình chiếu. Chúng được chia thành hai loại:

- **Thuộc tính tích hợp sẵn** chứa siêu dữ liệu chuẩn, chẳng hạn như tiêu đề, tác giả và thống kê tài liệu.
- **Thuộc tính tùy chỉnh** lưu trữ các cặp tên/giá trị do người dùng định nghĩa.

Aspose.Slides for Node.js via Java cung cấp quyền truy cập vào cả hai loại. Trong PowerPoint, chọn **File → Info → Properties → Advanced Properties** để kiểm tra siêu dữ liệu tài liệu. Hộp thoại nhóm thông tin thành các tab như **Summary**, **Statistics**, **Contents**, và **Custom**. Sử dụng tab **Custom** để quản lý các thuộc tính do người dùng định nghĩa.

## **Đọc Thuộc tính Công khai từ Bản trình chiếu Được Mã hóa**

Mật khẩu mở thường bảo vệ cả nội dung bản trình chiếu và các thuộc tính tài liệu. Khi một bản trình chiếu được mã hóa sau khi gọi [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) với `false`, các thuộc tính tài liệu của nó vẫn công khai. Một ứng dụng sau đó có thể gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) với `true` và đọc siêu dữ liệu công khai mà không cung cấp mật khẩu mở.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) kiểm soát những gì Aspose.Slides tải; nó không giải mã bất cứ thứ nào. Nếu các thuộc tính đã được bao gồm trong quá trình mã hóa, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình chiếu không được mã hóa, tùy chọn này sẽ bị bỏ qua và toàn bộ bản trình chiếu sẽ được tải.

Ví dụ yêu cầu một bản trình chiếu đã được mã hóa mà các thuộc tính tài liệu được để lại ở trạng thái công khai. Nó kiểm tra chế độ tải qua [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) và sau đó đọc các thuộc tính tích hợp sẵn qua [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, shape, media và các đối tượng khác của bản trình chiếu không khả dụng. Ứng dụng luôn nên kiểm tra [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) trước khi thực hiện thao tác yêu cầu mô hình đối tượng bản trình chiếu đầy đủ.

{{% alert color="warning" title="Warning" %}}
Siêu dữ liệu công khai có thể lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và các giá trị tùy chỉnh. Hãy mã hóa các thuộc tính nhạy cảm cùng với bản trình chiếu. Chỉ để chúng ở trạng thái công khai khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu có yêu cầu đặc biệt truy cập chúng mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật Thuộc tính của Bản trình chiếu Được Mã hóa**

Đối với tệp PPTX đã được mã hóa, bản trình chiếu được tải sau khi gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) với `true` nhằm mục đích đọc siêu dữ liệu công khai. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ chứa siêu dữ liệu này vì các thuộc tính công khai phải đồng nhất với dữ liệu tương ứng bên trong bản trình chiếu đã mã hóa. Do đó, việc cập nhật chúng yêu cầu mật khẩu mở đúng và tải đầy đủ bản trình chiếu.

Ví dụ yêu cầu một bản trình chiếu PPTX đã được mã hóa với các thuộc tính tài liệu công khai và một mật khẩu mở đã biết. Nó mở toàn bộ bản trình chiếu với [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), cập nhật các thuộc tính tích hợp sẵn công khai, và lưu kết quả. Sau đó sử dụng [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) để xác nhận việc mã hóa vẫn được giữ và mở lại siêu dữ liệu công khai mà không cần mật khẩu để kiểm tra các giá trị mới:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
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

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình chiếu, nó phải coi các thuộc tính công khai của tệp PPTX đã mã hóa là chỉ đọc.

## **Truy cập Thuộc tính Tích hợp sẵn**

Lớp [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) cung cấp siêu dữ liệu tích hợp sẵn qua các phương thức getter, bao gồm [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) và [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Ví dụ này mở một bản trình chiếu hiện có và in siêu dữ liệu đã lưu ra console. Các giá trị phụ thuộc vào bản trình chiếu đầu vào; một số trường có thể để trống.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Sửa đổi Thuộc tính Tích hợp sẵn**

Để cập nhật siêu dữ liệu tích hợp sẵn, sử dụng các phương thức setter trên đối tượng trả về bởi [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Ví dụ này mở một bản trình chiếu hiện có, gọi [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) và [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), sau đó lưu bản trình chiếu đã cập nhật với [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Tệp PPTX đã lưu sẽ chứa siêu dữ liệu mới.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Quản lý Cơ sở Siêu liên kết**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) trả về cơ sở cấp tài liệu cho các siêu liên kết tương đối. Sử dụng [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) để thay đổi hoặc xóa nó. Điều này hữu ích khi di chuyển một bản trình chiếu và các tệp liên kết sang vị trí khác. Nó độc lập với [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) của một siêu liên kết cá nhân: việc thay đổi cơ sở không ghi lại lại các địa chỉ liên kết đã lưu hoặc thay đổi đích tuyệt đối.

Ví dụ yêu cầu một bản trình chiếu chứa cả liên kết tương đối, chẳng hạn `target.html`, và liên kết tuyệt đối, chẳng hạn `https://example.org/absolute.html`. Nó đọc cơ sở hiện tại, gán địa chỉ cơ sở mới, và lưu rồi mở lại bản trình chiếu để kiểm tra giá trị. Sau đó xóa cơ sở bằng chuỗi rỗng và xác nhận giá trị rỗng trong một tệp đã lưu riêng. Thay thế địa chỉ cơ sở ví dụ bằng vị trí các tệp liên kết của bạn.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

Hai thông báo xác minh nên in ra `true`. Xóa cơ sở không làm thay đổi địa chỉ các siêu liên kết cá nhân.

Một liên kết tương đối tới `target.pptx` đã mở `old/target.pptx` khi cơ sở trỏ tới thư mục `old`. Sau khi thay đổi cơ sở thành thư mục `new`, lưu và mở lại bản trình chiếu, cùng một liên kết sẽ mở `new/target.pptx`. Liên kết tuyệt đối vẫn mở cùng tệp. Hãy kiểm tra các liên kết tương đối của bạn trong PowerPoint trước và sau khi di chuyển bản trình chiếu hoặc thay đổi cơ sở.

## **Thêm Thuộc tính Tùy chỉnh cho Bản trình chiếu**

Thuộc tính tùy chỉnh lưu trữ siêu dữ liệu không có trường tích hợp sẵn tương ứng. Phương thức [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) cho phép bạn gán giá trị theo tên thuộc tính. Ví dụ này tạo một bản trình chiếu, thêm hai giá trị văn bản và một giá trị phiên bản kiểu số nguyên, và lưu bản trình chiếu với [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Gán giá trị cho một tên đã tồn tại sẽ thay thế giá trị của thuộc tính đó.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Ví dụ này mở một bản trình chiếu chứa các thuộc tính tùy chỉnh và sử dụng [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) để iterate qua chúng. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) nhận một chỉ mục từ 0 và trả về tên được sử dụng bởi [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). Ví dụ in mỗi tên và giá trị gốc, thay thế mọi giá trị bằng một chuỗi đánh số bất kể kiểu gốc, và lưu các thay đổi. Nếu không có thuộc tính tùy chỉnh nào, vòng lặp không thực hiện thay đổi nào.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng trực tuyến [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) để xem cách làm việc với các thuộc tính tài liệu bằng API Aspose.Slides:

[![Xem & Chỉnh sửa Siêu dữ liệu PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để xóa một thuộc tính tích hợp sẵn khỏi bản trình chiếu?**

Các thuộc tính tích hợp sẵn là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) và sau đó [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) để đọc siêu dữ liệu tài liệu đã lưu mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Xem [Xây dựng Kiểm kê Bản trình chiếu Nhẹ](/slides/vi/nodejs-java/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các giới hạn theo định dạng.

**Tôi có thể đọc các thuộc tính công khai của một bản trình chiếu đã mã hóa mà không có mật khẩu mở không?**

Có. Bản trình chiếu phải đã được mã hóa sau khi gọi [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) với `false`, và phải được tải sau khi gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) với `true`.

**Tôi có thể cập nhật một tệp PPTX đã mã hóa trong chế độ chỉ tải thuộc tính tài liệu không?**

Không. Dữ liệu thuộc tính công khai và đã mã hóa phải đồng nhất, vì vậy việc cập nhật một tệp PPTX đã mã hóa yêu cầu tải toàn bộ bản trình chiếu với mật khẩu mở đúng.