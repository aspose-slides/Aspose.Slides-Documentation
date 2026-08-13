---
title: Quản lý Thuộc tính Bản trình bày trong .NET
linktitle: Thuộc tính Bản trình bày
type: docs
weight: 70
url: /vi/net/presentation-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Quản lý các thuộc tính của bản trình chiếu trong Aspose.Slides cho .NET và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides cho .NET hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý dễ dàng bằng API Aspose.Slides cho .NET.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình bày thông qua giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/) . Một thể hiện của giao diện này được trả về bởi thuộc tính [Presentation.DocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/documentproperties/) . Các ví dụ dưới đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" %}} 
Lưu ý rằng các trường **Application** và **Producer** không thể sửa đổi, vì các trường này luôn hiển thị "Aspose Ltd." và "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Quản lý Thuộc tính Bản trình bày**

Microsoft PowerPoint cung cấp tính năng thêm thuộc tính vào tệp bản trình bày. Những thuộc tính tài liệu này cho phép lưu trữ các thông tin hữu ích kèm theo tệp. Có hai loại thuộc tính tài liệu:

- Thuộc tính được hệ thống định nghĩa (built-in)
- Thuộc tính do người dùng định nghĩa (custom)

**Built-in** chứa thông tin chung về tài liệu, chẳng hạn tiêu đề tài liệu, tên tác giả, thống kê tài liệu, và các thông tin khác.

**Custom** được người dùng định nghĩa dưới dạng các cặp **Tên/Giá trị**, trong đó cả tên và giá trị đều do người dùng chỉ định.

Sử dụng Aspose.Slides cho .NET, các nhà phát triển có thể truy cập và sửa đổi cả thuộc tính built-in và custom.

Microsoft PowerPoint cho phép người dùng quản lý thuộc tính tài liệu bằng cách nhấp vào biểu tượng Office, sau đó chọn **File → Info → Properties**. Khi chọn **Advanced Properties**, một hộp thoại xuất hiện để bạn có thể quản lý tất cả các thuộc tính của tệp bản trình bày.

Trong hộp thoại **Properties**, có một số tab, chẳng hạn **General**, **Summary**, **Statistics**, **Contents**, và **Custom**. Mỗi tab cung cấp các tùy chọn cấu hình các loại thông tin cụ thể liên quan đến tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính do người dùng định nghĩa.

## **Truy cập Thuộc tính Built-in**

Những thuộc tính này, được khai báo bởi giao diện [IDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/) , bao gồm: **Creator** (Tác giả), **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in cuối cùng), **LastModifiedBy**, **SharedDoc** (cho biết tài liệu có được chia sẻ giữa các nhà sản xuất khác nhau không), **PresentationFormat**, **Subject**, **Title**, và các thuộc tính khác.

```cs
using Aspose.Slides;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Lấy tham chiếu đến đối tượng kiểu IDocumentProperties liên kết với bản trình bày.
IDocumentProperties documentProperties = presentation.DocumentProperties;
```

## **Sửa đổi Thuộc tính Built-in**

Việc sửa đổi các thuộc tính built-in của tệp bản trình bày cũng đơn giản như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn, và giá trị của thuộc tính sẽ được cập nhật. Trong ví dụ dưới đây, chúng tôi trình bày cách sửa đổi các thuộc tính tài liệu built-in của một tệp bản trình bày.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Lấy tham chiếu đến đối tượng kiểu IDocumentProperties liên kết với bản trình bày.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Đặt các thuộc tính Built-in.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Lưu bản trình bày ra tệp.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Thêm Thuộc tính Custom cho Bản trình bày**

Thuộc tính custom cho bản trình bày cho phép các nhà phát triển lưu trữ siêu dữ liệu bổ sung hoặc thông tin cụ thể trong tệp bản trình bày. Aspose.Slides giúp tạo và quản lý các thuộc tính custom này một cách dễ dàng thông qua lập trình. Các ví dụ dưới đây minh họa cách thêm thuộc tính custom vào bản trình bày của bạn.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation.
using Presentation presentation = new Presentation();

// Lấy tham chiếu đến đối tượng kiểu IDocumentProperties liên kết với bản trình bày.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Thêm các thuộc tính tùy chỉnh.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Lưu bản trình bày ra tệp.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Truy cập và Sửa đổi Thuộc tính Custom**

Aspose.Slides cũng cho phép các nhà phát triển truy cập các thuộc tính custom hiện có và sửa đổi giá trị của chúng một cách dễ dàng. Chức năng này giúp duy trì siêu dữ liệu chính xác và hỗ trợ cập nhật động dựa trên đầu vào của người dùng hoặc logic nghiệp vụ. Các ví dụ dưới đây cho thấy cách lấy và cập nhật giá trị thuộc tính custom trong một bản trình bày.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Lấy tham chiếu đến đối tượng kiểu IDocumentProperties liên kết với bản trình bày.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
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

// Lưu bản trình bày ra tệp.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng trực tuyến [**Xem & Chỉnh sửa Siêu dữ liệu PowerPoint**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với thuộc tính tài liệu bằng API Aspose.Slides:

[![Xem & Chỉnh sửa Siêu dữ liệu PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## ***Câu hỏi thường gặp**

### Làm thế nào để xóa một thuộc tính built-in khỏi bản trình bày?

Các thuộc tính built-in là một phần không thể tách rời của bản trình bày và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành chuỗi rỗng nếu thuộc tính cụ thể cho phép.

### Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính custom đã tồn tại?

Nếu bạn thêm một thuộc tính custom đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

### Tôi có thể truy cập thuộc tính bản trình bày mà không tải toàn bộ bản trình bày không?

Có, bạn có thể truy cập thuộc tính bản trình bày mà không tải toàn bộ bản trình bày bằng cách sử dụng phương thức `GetPresentationInfo` từ lớp [PresentationFactory](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/) . Sau đó, sử dụng phương thức `ReadDocumentProperties` được cung cấp bởi giao diện [IPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/) để đọc các thuộc tính một cách hiệu quả, giảm tiêu thụ bộ nhớ và cải thiện hiệu năng.