---
title: Quản lý Thuộc tính Bản trình bày trong .NET
linktitle: Thuộc tính Bản trình bày
type: docs
weight: 70
url: /vi/net/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- thuộc tính bản trình bày
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
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Quản lý toàn diện các thuộc tính bản trình bày trong Aspose.Slides cho .NET và tối ưu hoá tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides for .NET hỗ trợ các thuộc tính tài liệu **tích hợp** và **tùy chỉnh**. Sử dụng các thuộc tính này để đọc và cập nhật siêu dữ liệu bản trình bày, chẳng hạn như tác giả, tiêu đề và các giá trị do người dùng định nghĩa.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu bản trình bày thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) . Một thể hiện của giao diện này được trả về bởi [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Các ví dụ sau đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Lưu ý" %}}
Aspose.Slides quản lý siêu dữ liệu ứng dụng và nhà sản xuất khi lưu bản trình bày; các trường này xác định phần mềm đã tạo ra đầu ra.
{{% /alert %}}

## **Quản lý Thuộc tính Bản trình bày**

Thuộc tính tài liệu lưu trữ thông tin mô tả bên cạnh nội dung bản trình bày. Chúng được chia thành hai loại:

- **Thuộc tính tích hợp** chứa siêu dữ liệu tiêu chuẩn, chẳng hạn như tiêu đề, tác giả và thống kê tài liệu.
- **Thuộc tính tùy chỉnh** lưu các cặp tên/giá trị do người dùng xác định.

Aspose.Slides for .NET cung cấp quyền truy cập vào cả hai loại. Trong PowerPoint, chọn **File → Info → Properties → Advanced Properties** để kiểm tra siêu dữ liệu tài liệu. Hộp thoại nhóm thông tin thành các tab như **Summary**, **Statistics**, **Contents**, và **Custom**. Sử dụng tab **Custom** để quản lý các thuộc tính do người dùng định nghĩa.

## **Đọc Thuộc tính Công khai từ Bản trình bày Được Mã hoá**

Mật khẩu mở thường bảo vệ cả nội dung bản trình bày và các thuộc tính tài liệu. Khi một bản trình bày được mã hoá bằng [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) đặt thành `false`, các thuộc tính tài liệu của nó vẫn công khai. Khi đó ứng dụng có thể đặt [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) thành `true` và đọc siêu dữ liệu công khai mà không cần cung cấp mật khẩu mở.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) điều khiển những gì Aspose.Slides tải; nó không giải mã bất cứ thứ gì. Nếu các thuộc tính đã được bao gồm trong quá trình mã hoá, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình bày không được mã hoá, tùy chọn này sẽ bị bỏ qua và toàn bộ bản trình bày sẽ được tải.

Ví dụ yêu cầu một bản trình bày đã được mã hoá mà các thuộc tính tài liệu được để công khai. Nó xác nhận chế độ tải qua [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) và sau đó đọc các thuộc tính tích hợp qua [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, shape, media và các đối tượng khác của bản trình bày không khả dụng. Ứng dụng luôn nên kiểm tra [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) trước khi thực hiện thao tác yêu cầu mô hình đối tượng bản trình bày đầy đủ.

{{% alert color="warning" title="Bảo mật" %}}
Siêu dữ liệu công khai có thể lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và các giá trị tùy chỉnh. Hãy mã hoá các thuộc tính nhạy cảm cùng với bản trình bày. Chỉ để chúng công khai khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu có yêu cầu cụ thể để truy cập chúng mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật Thuộc tính của Bản trình bày Được Mã hoá**

Đối với tệp PPTX đã được mã hoá, một bản trình bày được tải bằng [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) chỉ nhằm mục đích đọc siêu dữ liệu công khai. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ chứa siêu dữ liệu vì các thuộc tính công khai phải đồng nhất với dữ liệu tương ứng bên trong bản trình bày đã mã hoá. Do đó việc cập nhật chúng yêu cầu mật khẩu mở đúng và việc tải đầy đủ.

Ví dụ yêu cầu một bản trình bày PPTX đã được mã hoá với các thuộc tính tài liệu công khai và một mật khẩu mở đã biết. Nó mở toàn bộ bản trình bày bằng [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), cập nhật các thuộc tính tích hợp công khai, và lưu kết quả. Sau đó sử dụng [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) để xác minh rằng mã hoá vẫn được giữ và mở lại siêu dữ liệu công khai mà không cần mật khẩu để kiểm tra các giá trị mới:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình bày, nó phải coi các thuộc tính công khai của tệp PPTX đã mã hoá là chỉ đọc.

## **Truy cập Thuộc tính Tích hợp**

Giao diện [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) cung cấp siêu dữ liệu tích hợp qua các thuộc tính kiểu, bao gồm [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), và [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). Ví dụ này mở một bản trình bày hiện có và in siêu dữ liệu đã lưu ra console. Các giá trị phụ thuộc vào bản trình bày đầu vào; một số trường có thể để trống.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **Sửa đổi Thuộc tính Tích hợp**

Để cập nhật siêu dữ liệu tích hợp, gán giá trị cho các thuộc tính có thể ghi được được cung cấp bởi [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Ví dụ này mở một bản trình bày hiện có, đặt [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), và [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), sau đó lưu bản trình bày đã cập nhật bằng [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Tệp PPTX đã lưu sẽ chứa siêu dữ liệu mới.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Quản lý Cơ sở Siêu liên kết**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) lưu cơ sở ở mức tài liệu cho các siêu liên kết tương đối. Điều này hữu ích khi di chuyển một bản trình bày và các tệp liên kết sang vị trí khác. Nó độc lập với [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) của một siêu liên kết cá nhân: việc thay đổi cơ sở không ghi lại lại địa chỉ liên kết đã lưu hoặc thay đổi đích tuyệt đối.

Ví dụ yêu cầu một bản trình bày chứa cả một liên kết tương đối, ví dụ `target.html`, và một liên kết tuyệt đối, ví dụ `https://example.org/absolute.html`. Nó đọc cơ sở hiện có, gán một địa chỉ cơ sở mới, và lưu rồi mở lại bản trình bày để kiểm tra giá trị. Sau đó xóa cơ sở bằng `string.Empty` và xác minh giá trị rỗng trong một tệp đã lưu riêng. Thay thế địa chỉ cơ sở mẫu bằng vị trí các tệp liên kết của bạn.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

Hai thông báo xác minh nên in ra `True`. Xóa cơ sở không ảnh hưởng tới địa chỉ các siêu liên kết cá nhân.

Một liên kết tương đối tới `target.pptx` đã mở `old/target.pptx` khi cơ sở trỏ tới thư mục `old`. Sau khi thay đổi cơ sở thành thư mục `new`, lưu và mở lại bản trình bày, cùng một liên kết sẽ mở `new/target.pptx`. Một liên kết tuyệt đối vẫn mở cùng một tệp. Hãy kiểm tra các liên kết tương đối của bạn trong PowerPoint trước và sau khi di chuyển bản trình bày hoặc thay đổi cơ sở.

## **Thêm Thuộc tính Bản trình bày Tùy chỉnh**

Thuộc tính tùy chỉnh lưu siêu dữ liệu không có trường tích hợp tương ứng. Bộ chỉ mục của [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) cho phép bạn gán giá trị bằng tên thuộc tính. Ví dụ này tạo một bản trình bày, thêm hai giá trị văn bản và một giá trị phiên bản kiểu nguyên, và lưu bản trình bày bằng [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Gán giá trị cho một tên đã tồn tại sẽ thay thế giá trị của thuộc tính đó.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Ví dụ này mở một bản trình bày chứa các thuộc tính tùy chỉnh và sử dụng [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) để lặp qua chúng. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) nhận một chỉ số bắt đầu từ 0 và trả về tên được sử dụng bởi bộ chỉ mục của [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). Ví dụ in mỗi tên và giá trị gốc, thay thế mọi giá trị bằng một chuỗi đánh số bất kể kiểu gốc, và lưu các thay đổi. Nếu không có thuộc tính tùy chỉnh nào, vòng lặp sẽ không thực hiện thay đổi.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Ví dụ Trực tuyến**

Hãy thử ứng dụng trực tuyến [**Xem & Chỉnh sửa Siêu dữ liệu PowerPoint**](https://products.aspose.app/slides/metadata) để xem cách làm việc với các thuộc tính tài liệu bằng API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để tôi có thể xóa một thuộc tính tích hợp khỏi bản trình bày?**

Thuộc tính tích hợp là một phần không thể tách rời của bản trình bày và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình bày mà không tải đầy đủ bản trình bày không?**

Có. Sử dụng [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) và sau đó [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu đã lưu mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Xem [**Xây dựng Kiểm kê Bản trình bày Nhẹ**](/slides/vi/net/examine-presentation/) để có ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.

**Tôi có thể đọc các thuộc tính công khai của một bản trình bày được mã hoá mà không cần mật khẩu mở không?**

Có. Bản trình bày phải được mã hoá bằng [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) đặt thành `false`, và phải được tải bằng [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) đặt thành `true`.

**Tôi có thể cập nhật một tệp PPTX đã mã hoá ở chế độ chỉ tải thuộc tính tài liệu không?**

Không. Dữ liệu thuộc tính công khai và mã hoá phải đồng nhất, do đó việc cập nhật một tệp PPTX đã mã hoá yêu cầu tải toàn bộ bản trình bày với mật khẩu mở đúng.