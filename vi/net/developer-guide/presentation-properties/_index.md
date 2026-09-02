---
title: Quản lý Thuộc tính Bản trình chiếu trong .NET
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/net/presentation-properties/
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
- Ngôn ngữ kiểm tra
- Ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- Bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý các thuộc tính bản trình chiếu trong Aspose.Slides cho .NET và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides for .NET hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này có thể dễ dàng truy cập và quản lý bằng API Aspose.Slides for .NET.

Aspose.Slides cho phép bạn làm việc với thuộc tính tài liệu bản trình chiếu thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/) . Một thể hiện của giao diện này được trả về bởi thuộc tính [Presentation.DocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/documentproperties/) . Các ví dụ sau cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Lưu ý" %}}
Xin lưu ý rằng các trường **Application** và **Producer** không thể được sửa đổi, vì các trường này luôn hiển thị "Aspose Ltd." và "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Quản lý Thuộc tính Bản trình chiếu**

Microsoft PowerPoint cung cấp tính năng thêm thuộc tính vào tệp bản trình chiếu. Các thuộc tính tài liệu này cho phép lưu trữ thông tin hữu ích cùng với tệp. Có hai loại thuộc tính tài liệu:

- Thuộc tính được hệ thống định nghĩa (built-in)
- Thuộc tính do người dùng định nghĩa (custom)

**Built-in** chứa thông tin chung về tài liệu, chẳng hạn như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, và nhiều hơn nữa.

**Custom** được người dùng định nghĩa dưới dạng cặp **Tên/Giá trị**, trong đó cả tên và giá trị đều do người dùng chỉ định.

Sử dụng Aspose.Slides cho .NET, các nhà phát triển có thể truy cập và sửa đổi cả thuộc tính built-in và custom.

Microsoft PowerPoint cho phép người dùng quản lý thuộc tính tài liệu bằng cách nhấp vào biểu tượng Office, sau đó chọn **File → Info → Properties**. Sau khi chọn **Advanced Properties**, một hộp thoại xuất hiện cho phép bạn quản lý tất cả các thuộc tính tài liệu của tệp bản trình chiếu.

Trong hộp thoại **Properties**, có một số tab, chẳng hạn **General**, **Summary**, **Statistics**, **Contents**, và **Custom**. Mỗi tab cung cấp các tùy chọn để cấu hình các loại thông tin cụ thể liên quan đến tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính do người dùng định nghĩa.

## **Truy cập Thuộc tính Built-in**

Các thuộc tính này, được mở rộng bởi giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/) , bao gồm: **Creator** (Tác giả), **Description** (Mô tả), **Keywords** (Từ khóa), **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in lần cuối), **LastModifiedBy**, **SharedDoc** (cho biết tài liệu có được chia sẻ giữa các nhà sản xuất khác nhau không), **PresentationFormat**, **Subject**, **Title**, và các thuộc tính khác.

```cs
using Aspose.Slides;

// Instantiate the Presentation class that represents a presentation file.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Sửa đổi Thuộc tính Built-in**

Việc sửa đổi các thuộc tính built-in của tệp bản trình chiếu cũng dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn, và giá trị của thuộc tính sẽ được cập nhật. Trong ví dụ dưới đây, chúng tôi minh họa cách sửa đổi các thuộc tính tài liệu built-in của một tệp bản trình chiếu.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Lấy tham chiếu tới đối tượng loại IDocumentProperties liên kết với bản trình chiếu.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Đặt các thuộc tính tích hợp.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Lưu bản trình chiếu vào tệp.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Thêm Thuộc tính Bản trình chiếu Tùy chỉnh**

Thuộc tính bản trình chiếu tùy chỉnh cho phép các nhà phát triển lưu trữ siêu dữ liệu bổ sung hoặc thông tin cụ thể trong tệp bản trình chiếu. Aspose.Slides giúp bạn dễ dàng tạo và quản lý những thuộc tính tùy chỉnh này một cách lập trình. Các ví dụ sau minh họa cách thêm thuộc tính tùy chỉnh vào bản trình chiếu của bạn.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation.
using Presentation presentation = new Presentation();

// Lấy tham chiếu tới đối tượng kiểu IDocumentProperties liên kết với bản trình chiếu.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Thêm các thuộc tính tùy chỉnh.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Lưu bản trình chiếu vào tệp.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Aspose.Slides cũng cho phép các nhà phát triển truy cập các thuộc tính tùy chỉnh hiện có và sửa đổi giá trị của chúng một cách dễ dàng. Tính năng này giúp duy trì siêu dữ liệu chính xác và hỗ trợ cập nhật động dựa trên đầu vào của người dùng hoặc logic nghiệp vụ. Các ví dụ dưới đây cho thấy cách lấy và cập nhật giá trị thuộc tính tùy chỉnh trong một bản trình chiếu.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho một tệp PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Lấy tham chiếu tới đối tượng kiểu IDocumentProperties liên kết với bản trình chiếu.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Truy cập và sửa đổi các thuộc tính tùy chỉnh.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Hiển thị tên và giá trị của thuộc tính tùy chỉnh.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Sửa đổi giá trị của thuộc tính tùy chỉnh.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Lưu bản trình chiếu vào tệp.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Ví dụ Thực tế**

Thử ứng dụng trực tuyến [**Xem & Chỉnh sửa Siêu dữ liệu PowerPoint**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với thuộc tính tài liệu bằng API Aspose.Slides:

[![Xem & Chỉnh sửa Siêu dữ liệu PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xóa một thuộc tính built-in khỏi bản trình chiếu?**

Các thuộc tính built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt giá trị thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập thuộc tính bản trình chiếu mà không tải đầy đủ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/getpresentationinfo/) và sau đó [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu đã lưu mà không cần tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Xem [Build a Lightweight Presentation Inventory](/slides/vi/net/examine-presentation/) để có ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.