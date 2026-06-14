---
title: Quản lý Thuộc tính Bản trình chiếu trong .NET
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/net/presentation-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Kiểm soát các thuộc tính bản trình chiếu trong Aspose.Slides cho .NET và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides for .NET hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể dễ dàng truy cập và quản lý bằng API Aspose.Slides for .NET.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/). Một thể hiện của giao diện này được trả về bởi thuộc tính [Presentation.DocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/documentproperties/). Các ví dụ sau cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="primary" %}} 
Lưu ý rằng các trường **Application** và **Producer** không thể được sửa đổi, vì các trường này sẽ luôn hiển thị "Aspose Ltd." và "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Quản lý Thuộc tính Bản trình chiếu**

Microsoft PowerPoint cung cấp tính năng thêm thuộc tính vào các tệp bản trình chiếu. Các thuộc tính tài liệu này cho phép lưu trữ thông tin hữu ích cùng với các tệp. Có hai loại thuộc tính tài liệu:

- Thuộc tính được định nghĩa bởi hệ thống (built-in)
- Thuộc tính do người dùng định nghĩa (custom)

Các thuộc tính **Built-in** chứa thông tin chung về tài liệu, chẳng hạn như tiêu đề tài liệu, tên tác giả, thống kê tài liệu và hơn thế nữa.

Các thuộc tính **Custom** được người dùng định nghĩa dưới dạng các cặp **Name/Value**, trong đó cả tên và giá trị đều do người dùng chỉ định.

Sử dụng Aspose.Slides for .NET, các nhà phát triển có thể truy cập và sửa đổi cả các thuộc tính built-in và custom.

Microsoft PowerPoint cho phép người dùng quản lý thuộc tính tài liệu bằng cách nhấp vào biểu tượng Office, sau đó chọn **File → Info → Properties**. Sau khi chọn **Advanced Properties**, một hộp thoại sẽ xuất hiện, cho phép bạn quản lý tất cả các thuộc tính tài liệu của tệp bản trình chiếu.

Trong hộp thoại **Properties**, có một vài tab, chẳng hạn như **General**, **Summary**, **Statistics**, **Contents**, và **Custom**.
Mỗi tab cung cấp các tùy chọn để cấu hình các loại thông tin cụ thể liên quan tới tệp PowerPoint. Tab **Custom** được sử dụng để quản lý các thuộc tính do người dùng định nghĩa.

## **Truy cập Thuộc tính Built-in**

Các thuộc tính này, được hiển thị bởi giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/), bao gồm: **Creator** (Tác giả), **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in lần cuối), **LastModifiedBy**, **SharedDoc** (cho biết tài liệu có được chia sẻ giữa các nhà sản xuất khác nhau hay không), **PresentationFormat**, **Subject**, **Title**, và hơn nữa.

```cs
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Lấy tham chiếu tới đối tượng kiểu IDocumentProperties liên kết với bản trình chiếu.
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

Việc sửa đổi các thuộc tính built-in của tệp bản trình chiếu cũng dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn, và giá trị của thuộc tính sẽ được cập nhật. Trong ví dụ dưới đây, chúng tôi trình bày cách sửa đổi các thuộc tính tài liệu built-in của một tệp bản trình chiếu.

```cs
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Lấy tham chiếu tới đối tượng kiểu IDocumentProperties liên kết với bản trình chiếu.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Đặt các thuộc tính Built-in.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Lưu bản trình chiếu vào tệp.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Thêm Thuộc tính Bản trình chiếu Custom**

Các thuộc tính bản trình chiếu custom cho phép các nhà phát triển lưu trữ siêu dữ liệu bổ sung hoặc thông tin cụ thể trong tệp bản trình chiếu. Aspose.Slides giúp tạo và quản lý các thuộc tính custom này một cách lập trình dễ dàng. Các ví dụ sau minh họa cách thêm thuộc tính custom vào bản trình chiếu của bạn.

```cs
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

## **Truy cập và Sửa đổi Thuộc tính Custom**

Aspose.Slides cũng cho phép các nhà phát triển truy cập các thuộc tính custom hiện có và sửa đổi giá trị của chúng một cách dễ dàng. Chức năng này giúp duy trì siêu dữ liệu chính xác và hỗ trợ cập nhật động dựa trên đầu vào của người dùng hoặc logic kinh doanh. Các ví dụ dưới đây minh họa cách lấy và cập nhật giá trị thuộc tính custom trong một bản trình chiếu.

```cs
// Khởi tạo lớp Presentation đại diện cho tệp PPTX.
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

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng trực tuyến [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu bằng API Aspose.Slides:

[![Xem & Chỉnh sửa Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## ***Câu hỏi thường gặp**

**Làm thế nào để tôi xóa một thuộc tính built-in khỏi bản trình chiếu?**

Các thuộc tính built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính custom đã tồn tại?**

Nếu bạn thêm một thuộc tính custom đã tồn tại, giá trị hiện có sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải đầy đủ bản trình chiếu không?**

Có, bạn có thể truy cập các thuộc tính bản trình chiếu mà không tải đầy đủ bản trình chiếu bằng cách sử dụng phương thức `GetPresentationInfo` từ lớp [PresentationFactory](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/). Sau đó, sử dụng phương thức `ReadDocumentProperties` được cung cấp bởi giao diện [IPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/) để đọc các thuộc tính một cách hiệu quả, tiết kiệm bộ nhớ và cải thiện hiệu năng.