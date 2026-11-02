---
title: Quản lý Thuộc tính Bản trình chiếu trên Android
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/androidjava/presentation-properties/
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
- Ngôn ngữ hiệu đính
- Ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các thuộc tính bản trình chiếu trong Aspose.Slides cho Android qua Java và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides cho Android thông qua Java hỗ trợ các thuộc tính tài liệu **built-in** và **custom**. Sử dụng các thuộc tính này để đọc và cập nhật siêu dữ liệu của bản trình chiếu, chẳng hạn như tác giả, tiêu đề và các giá trị do người dùng xác định.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) . Một thể hiện của giao diện này được trả về bởi [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Các ví dụ sau cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Aspose.Slides quản lý siêu dữ liệu của ứng dụng và nhà sản xuất khi lưu bản trình chiếu; các trường này xác định phần mềm đã tạo ra đầu ra.
{{% /alert %}}

## **Quản lý thuộc tính bản trình chiếu**

Các thuộc tính tài liệu lưu trữ thông tin mô tả cùng với nội dung bản trình chiếu. Chúng thuộc về hai loại:

- **Thuộc tính tích hợp** chứa siêu dữ liệu tiêu chuẩn, chẳng hạn như tiêu đề, tác giả và thống kê tài liệu.
- **Thuộc tính tuỳ chỉnh** lưu các cặp tên/giá trị do người dùng xác định.

Aspose.Slides cho Android thông qua Java cung cấp quyền truy cập vào cả hai loại. Trong PowerPoint, chọn **File → Info → Properties → Advanced Properties** để kiểm tra siêu dữ liệu tài liệu. Hộp thoại nhóm thông tin thành các thẻ như **Summary**, **Statistics**, **Contents**, và **Custom**. Sử dụng thẻ **Custom** để quản lý các thuộc tính do người dùng xác định.

## **Đọc các thuộc tính công khai từ bản trình chiếu đã mã hoá**

Mật khẩu mở thường bảo vệ cả nội dung bản trình chiếu và các thuộc tính tài liệu. Khi một bản trình chiếu được mã hoá sau khi gọi [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) với `false`, các thuộc tính tài liệu của nó vẫn ở trạng thái công khai. Ứng dụng sau đó có thể gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) với `true` và đọc siêu dữ liệu công khai mà không cần cung cấp mật khẩu mở.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) kiểm soát những gì Aspose.Slides tải; nó không giải mã bất kỳ thứ gì. Nếu các thuộc tính đã được bao gồm trong quá trình mã hoá, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình chiếu không được mã hoá, tùy chọn này sẽ bị bỏ qua và toàn bộ bản trình chiếu sẽ được tải.

Ví dụ yêu cầu một bản trình chiếu đã mã hoá mà các thuộc tính tài liệu của nó được để ở chế độ công khai. Nó xác minh chế độ tải thông qua [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) và sau đó đọc các thuộc tính tích hợp thông qua [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) :

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

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, shape, media và các đối tượng khác của bản trình chiếu sẽ không khả dụng. Ứng dụng nên luôn kiểm tra [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) trước khi thực hiện một thao tác yêu cầu mô hình đối tượng bản trình chiếu hoàn chỉnh.

{{% alert color="warning" title="Warning" %}}
Siêu dữ liệu công khai có thể lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, nhận xét và các giá trị tuỳ chỉnh. Hãy mã hoá các thuộc tính nhạy cảm cùng với bản trình chiếu. Chỉ để chúng ở chế độ công khai khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu có yêu cầu cụ thể truy cập mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật thuộc tính của bản trình chiếu đã mã hoá**

Đối với tệp PPTX đã mã hoá, một bản trình chiếu được tải sau khi gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) với `true` chỉ nhằm mục đích đọc siêu dữ liệu công khai. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ có siêu dữ liệu vì các thuộc tính công khai phải đồng nhất với dữ liệu tương ứng bên trong bản trình chiếu đã mã hoá. Do đó, việc cập nhật chúng yêu cầu mật khẩu mở đúng và tải toàn bộ bản trình chiếu.

Ví dụ yêu cầu một bản trình chiếu PPTX đã mã hoá với các thuộc tính tài liệu công khai và mật khẩu mở đã biết. Nó mở bản trình chiếu đầy đủ bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), cập nhật các thuộc tính tích hợp công khai, và lưu kết quả. Sau đó sử dụng [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) để xác minh rằng việc mã hoá được giữ nguyên và mở lại siêu dữ liệu công khai mà không có mật khẩu để kiểm tra các giá trị mới:

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

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình chiếu, nó phải coi các thuộc tính công khai của tệp PPTX đã mã hoá là chỉ‑đọc.

## **Truy cập các thuộc tính tích hợp**

Giao diện [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) cung cấp các siêu dữ liệu tích hợp thông qua các phương thức getter, bao gồm [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--), và [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--). Ví dụ này mở một bản trình chiếu hiện có và in siêu dữ liệu đã lưu ra console. Các giá trị phụ thuộc vào bản trình chiếu đầu vào; một số trường có thể trống.

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

## **Sửa đổi các thuộc tính tích hợp**

Để cập nhật siêu dữ liệu tích hợp, sử dụng các phương thức setter trên đối tượng trả về bởi [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Ví dụ này mở một bản trình chiếu hiện có, gọi [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), và [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), sau đó lưu bản trình chiếu đã cập nhật bằng [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Tệp PPTX đã lưu chứa siêu dữ liệu mới.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Quản lý Hyperlink Base**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) trả về cơ sở cấp độ tài liệu cho các siêu liên kết tương đối. Sử dụng [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) để thay đổi hoặc xóa nó. Điều này hữu ích khi di chuyển một bản trình chiếu và các tệp liên kết sang vị trí khác. Nó độc lập với [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) của một siêu liên kết riêng lẻ: việc thay đổi cơ sở không ghi lại lại địa chỉ liên kết đã lưu hoặc thay đổi đích tuyệt đối.

Ví dụ yêu cầu một bản trình chiếu chứa cả một liên kết tương đối, chẳng hạn `target.html`, và một liên kết tuyệt đối, chẳng hạn `https://example.org/absolute.html`. Nó đọc cơ sở hiện tại, gán một địa chỉ cơ sở mới, và lưu rồi mở lại bản trình chiếu để kiểm tra giá trị. Sau đó xóa cơ sở bằng chuỗi rỗng và xác minh giá trị rỗng trong một tệp lưu riêng. Thay địa chỉ cơ sở mẫu bằng vị trí các tệp liên kết của bạn.

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

Hai thông báo xác thực nên in ra `true`. Xóa cơ sở sẽ giữ nguyên địa chỉ các siêu liên kết riêng lẻ.

Một liên kết tương đối tới `target.pptx` mở `old/target.pptx` khi cơ sở trỏ tới thư mục `old`. Sau khi thay đổi cơ sở thành thư mục `new`, lưu và mở lại bản trình chiếu, cùng một liên kết sẽ mở `new/target.pptx`. Liên kết tuyệt đối vẫn mở cùng tệp. Hãy kiểm tra các liên kết tương đối trong PowerPoint trước và sau khi di chuyển bản trình chiếu hoặc thay đổi cơ sở của nó.

## **Thêm thuộc tính tùy chỉnh cho bản trình chiếu**

Các thuộc tính tùy chỉnh lưu siêu dữ liệu mà không có trường tích hợp tương ứng. Phương thức [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) cho phép bạn gán một giá trị theo tên thuộc tính. Ví dụ này tạo một bản trình chiếu, thêm hai giá trị văn bản và một giá trị phiên bản kiểu số nguyên, và lưu bản trình chiếu bằng [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Gán giá trị cho một tên đã tồn tại sẽ thay thế giá trị của thuộc tính đó.

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

## **Truy cập và sửa đổi các thuộc tính tùy chỉnh**

Ví dụ này mở một bản trình chiếu chứa các thuộc tính tùy chỉnh và sử dụng [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) để duyệt qua chúng. [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) nhận một chỉ mục bắt đầu từ 0 và trả về tên được sử dụng bởi [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). Ví dụ in mỗi tên và giá trị gốc, thay thế mọi giá trị bằng một chuỗi có số thứ tự bất kể kiểu gốc, và lưu các thay đổi. Nếu không có thuộc tính tùy chỉnh nào, vòng lặp sẽ không thực hiện thay đổi nào.

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

## **Ví dụ trực tiếp**

Hãy thử ứng dụng trực tuyến [**Xem & Chỉnh sửa Siêu dữ liệu PowerPoint**](https://products.aspose.app/slides/metadata) để xem cách làm việc với các thuộc tính tài liệu bằng API Aspose.Slides:

[![Xem & Chỉnh sửa Siêu dữ liệu PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để xóa một thuộc tính tích hợp khỏi bản trình chiếu?**

Các thuộc tính tích hợp là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính đó.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) và sau đó [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) để đọc siêu dữ liệu tài liệu đã lưu mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) . Xem [Build a Lightweight Presentation Inventory](/slides/vi/androidjava/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.

**Tôi có thể đọc các thuộc tính công khai của bản trình chiếu đã mã hoá mà không có mật khẩu mở không?**

Có. Bản trình chiếu phải đã được mã hoá sau khi gọi [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) với `false`, và phải được tải sau khi gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) với `true`.

**Tôi có thể cập nhật một tệp PPTX đã mã hoá ở chế độ chỉ tải thuộc tính tài liệu không?**

Không. Dữ liệu thuộc tính công khai và đã mã hoá phải đồng nhất, do đó cập nhật một tệp PPTX đã mã hoá yêu cầu tải toàn bộ bản trình chiếu với mật khẩu mở đúng.