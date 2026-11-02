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
- ngôn ngữ kiểm tra
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý thuộc tính bản trình chiếu trong Aspose.Slides cho Java và tối ưu hoá tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides for Java hỗ trợ các thuộc tính tài liệu **built-in** và **custom**. Sử dụng các thuộc tính này để đọc và cập nhật siêu dữ liệu của bản trình chiếu, chẳng hạn như tác giả, tiêu đề và các giá trị do người dùng định nghĩa.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/). Một thể hiện của giao diện này được trả về bởi [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Các ví dụ sau đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Aspose.Slides quản lý siêu dữ liệu của ứng dụng và nhà sản xuất khi lưu bản trình chiếu; các trường này xác định phần mềm đã tạo ra kết quả.
{{% /alert %}}

## **Quản lý Thuộc tính Bản trình chiếu**

Thuộc tính tài liệu lưu trữ thông tin mô tả cùng với nội dung bản trình chiếu. Chúng được chia thành hai loại:

- **Built-in properties** chứa siêu dữ liệu tiêu chuẩn, như tiêu đề, tác giả và thống kê tài liệu.
- **Custom properties** lưu các cặp tên/giá trị do người dùng định nghĩa.

Aspose.Slides for Java cung cấp quyền truy cập vào cả hai loại. Trong PowerPoint, chọn **File → Info → Properties → Advanced Properties** để kiểm tra siêu dữ liệu tài liệu. Hộp thoại nhóm thông tin thành các tab như **Summary**, **Statistics**, **Contents**, và **Custom**. Sử dụng tab **Custom** để quản lý các thuộc tính do người dùng định nghĩa.

## **Đọc Thuộc tính Công khai từ Bản trình chiếu Được Mã hoá**

Mật khẩu mở thường bảo vệ cả nội dung bản trình chiếu và các thuộc tính tài liệu. Khi một bản trình chiếu được mã hoá sau khi gọi [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) với `false`, các thuộc tính tài liệu của nó vẫn công khai. Ứng dụng sau đó có thể gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) với `true` và đọc siêu dữ liệu công khai mà không cần cung cấp mật khẩu mở.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) điều khiển những gì Aspose.Slides tải; nó không giải mã gì cả. Nếu các thuộc tính đã được bao gồm trong quá trình mã hoá, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình chiếu không được mã hoá, tùy chọn này bị bỏ qua và toàn bộ bản trình chiếu sẽ được tải.

Ví dụ yêu cầu một bản trình chiếu được mã hoá nhưng các thuộc tính tài liệu của nó được để công khai. Nó xác minh chế độ tải qua [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) và sau đó đọc các thuộc tính built-in qua [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--):
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, shape, media và các đối tượng khác của bản trình chiếu không khả dụng. Ứng dụng luôn nên kiểm tra [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) trước khi thực hiện một thao tác yêu cầu mô hình đối tượng bản trình chiếu đầy đủ.

{{% alert color="warning" title="Warning" %}}
Siêu dữ liệu công khai có thể để lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, nhận xét và các giá trị tùy chỉnh. Hãy mã hoá các thuộc tính nhạy cảm cùng với bản trình chiếu. Chỉ để chúng công khai khi hệ thống chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu có yêu cầu cụ thể để truy cập chúng mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật Thuộc tính của Bản trình chiếu Được Mã hoá**

Đối với tệp PPTX đã được mã hoá, một bản trình chiếu được tải sau khi gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) với `true` nhằm mục đích đọc siêu dữ liệu công khai. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ chứa siếu dữ liệu này vì các thuộc tính công khai phải nhất quán với dữ liệu tương ứng bên trong bản trình chiếu đã mã hoá. Do đó, việc cập nhật chúng yêu cầu mật khẩu mở đúng và tải toàn bộ bản trình chiếu.

Ví dụ yêu cầu một bản trình chiếu PPTX được mã hoá với các thuộc tính tài liệu công khai và một mật khẩu mở đã biết. Nó mở toàn bộ bản trình chiếu bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), cập nhật các thuộc tính built-in công khai, và lưu kết quả. Sau đó nó sử dụng [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) để xác minh rằng việc mã hoá vẫn được giữ và mở lại siêu dữ liệu công khai mà không cần mật khẩu để kiểm tra các giá trị mới:
```java
import com.aspose.slides.IDocumentProperties;
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
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

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

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình chiếu, nó phải xem các thuộc tính công khai của tệp PPTX đã mã hoá như là chỉ đọc.

## **Truy cập Thuộc tính Built-in**

Giao diện [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) cung cấp siếu dữ liệu built-in thông qua các phương thức getter, bao gồm [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--), và [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--). Ví dụ này mở một bản trình chiếu hiện có và in siêu dữ liệu lưu trữ của nó ra console. Các giá trị phụ thuộc vào bản trình chiếu đầu vào; một số trường có thể rỗng.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Sửa đổi Thuộc tính Built-in**

Để cập nhật siêu dữ liệu built-in, hãy sử dụng các phương thức setter trên đối tượng trả về bởi [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Ví dụ này mở một bản trình chiếu hiện có, gọi [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), và [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), sau đó lưu bản trình chiếu đã cập nhật bằng [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Tệp PPTX đã lưu chứa siêu dữ liệu mới.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Quản lý Base Siêu liên kết**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) trả về base cấp tài liệu cho các siêu liên kết tương đối. Sử dụng [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) để thay đổi hoặc xóa nó. Điều này hữu ích khi di chuyển bản trình chiếu và các tệp liên kết sang vị trí khác. Nó tách biệt với [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) của một siêu liên kết riêng lẻ: việc thay đổi base không ghi lại lại các địa chỉ liên kết đã lưu hoặc thay đổi đích tuyệt đối.

Ví dụ yêu cầu một bản trình chiếu chứa cả liên kết tương đối, như `target.html`, và liên kết tuyệt đối, như `https://example.org/absolute.html`. Nó đọc base hiện có, gán một địa chỉ base mới, và lưu rồi mở lại bản trình chiếu để kiểm tra giá trị. Sau đó nó xóa base bằng một chuỗi rỗng và xác minh giá trị rỗng trong một tệp đã lưu riêng. Thay thế địa chỉ base mẫu bằng vị trí của các tệp liên kết của bạn.
```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

Hai thông báo xác minh nên in ra `true`. Xóa base để lại các địa chỉ siêu liên kết riêng lẻ không thay đổi.

Một liên kết tương đối tới `target.pptx` đã mở `old/target.pptx` khi base trỏ tới thư mục `old`. Sau khi thay đổi base thành thư mục `new`, lưu và mở lại bản trình chiếu, cùng liên kết đã mở `new/target.pptx`. Liên kết tuyệt đối vẫn mở cùng tệp. Hãy kiểm tra các liên kết tương đối của bạn trong PowerPoint trước và sau khi di chuyển bản trình chiếu hoặc thay đổi base.

## **Thêm Thuộc tính Tùy chỉnh cho Bản trình chiếu**

Các thuộc tính tùy chỉnh lưu siêu dữ liệu không có trường built-in tương ứng. Phương thức [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) cho phép bạn gán một giá trị theo tên thuộc tính. Ví dụ này tạo một bản trình chiếu, thêm hai giá trị văn bản và một giá trị phiên bản nguyên, và lưu bản trình chiếu bằng [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Gán một giá trị cho một tên đã tồn tại sẽ thay thế giá trị của thuộc tính đó.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Ví dụ này mở một bản trình chiếu chứa các thuộc tính tùy chỉnh và sử dụng [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) để duyệt qua chúng. [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) nhận một chỉ mục bắt đầu từ 0 và trả về tên được sử dụng bởi [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). Ví dụ in mỗi tên và giá trị gốc, thay thế mọi giá trị bằng một chuỗi đánh số bất kể kiểu gốc, và lưu các thay đổi. Nếu không có thuộc tính tùy chỉnh, vòng lặp không thực hiện thay đổi nào.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ví dụ Trực tiếp**

Thử ứng dụng trực tuyến [**Xem & Chỉnh sửa Siêu dữ liệu PowerPoint**](https://products.aspose.app/slides/metadata) để xem cách làm việc với các thuộc tính tài liệu bằng API Aspose.Slides:
[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Câu hỏi thường gặp**

**Làm sao tôi có thể xóa một thuộc tính built-in khỏi bản trình chiếu?**

Các thuộc tính built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải đầy đủ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) rồi [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) để đọc siêu dữ liệu tài liệu đã lưu mà không tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Xem [Xây dựng Kiểm kê Bản trình chiếu Nhẹ](/slides/vi/java/examine-presentation/) để có ví dụ báo cáo hoàn chỉnh và các hạn chế theo định dạng.

**Tôi có thể đọc các thuộc tính công khai của một bản trình chiếu được mã hoá mà không có mật khẩu mở không?**

Có. Bản trình chiếu phải đã được mã hoá sau khi gọi [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) với `false`, và phải được tải sau khi gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) với `true`.

**Tôi có thể cập nhật một tệp PPTX đã mã hoá trong chế độ chỉ tải thuộc tính tài liệu không?**

Không. Dữ liệu thuộc tính công khai và đã mã hoá phải nhất quán, vì vậy việc cập nhật một tệp PPTX đã mã hoá yêu cầu tải toàn bộ bản trình chiếu với mật khẩu mở đúng.