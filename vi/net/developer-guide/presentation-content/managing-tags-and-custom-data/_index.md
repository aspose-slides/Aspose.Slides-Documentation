---
title: Quản lý thẻ và dữ liệu tùy chỉnh trong bản trình bày bằng .NET
linktitle: Thẻ và dữ liệu tùy chỉnh
type: docs
weight: 300
url: /vi/net/managing-tags-and-custom-data/
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- XML tùy chỉnh
- phần XML tùy chỉnh
- siêu dữ liệu XML
- ItemId
- thêm thẻ
- cặp giá trị
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bản trình bày PowerPoint bằng Aspose.Slides cho .NET, bao gồm việc thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình bày PowerPoint. Dữ liệu riêng của bản trình bày có thể được lưu dưới dạng thẻ hoặc phần XML tùy chỉnh. Thẻ là các cặp khóa‑giá trị dạng chuỗi đơn giản, trong khi phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và dữ liệu XML đặc thù của ứng dụng.

Aspose.Slides cung cấp API để thêm, đọc, cập nhật, kiểm tra và xóa phần XML tùy chỉnh ở mức bản trình bày, slide và shape. Phần XML tùy chỉnh hữu ích cho các tích hợp lưu thông tin như định danh quản lý tài liệu, trạng thái luồng công việc, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu, hoặc các dữ liệu ứng dụng có cấu trúc khác trong một bản trình bày.

## **Lưu trữ dữ liệu trong tệp Presentation**

Các tệp PPTX—các tệp có phần mở rộng `.pptx`—được lưu ở định dạng PresentationML, một phần của tiêu chuẩn Office Open XML. Office Open XML định nghĩa cấu trúc gói và các quan hệ được dùng để lưu nội dung bản trình bày và dữ liệu liên quan.

Một bản trình bày chứa nhiều phần được kết nối bằng các quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các quan hệ rõ ràng tới các phần khác theo chuẩn ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/itagcollection)) hoặc phần XML tùy chỉnh ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection)). Cả hai đều có sẵn thông qua giao diện [`ICustomData`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomdata/) .

{{% alert color="info" %}}

Thẻ lưu trữ các cặp khóa‑giá trị chuỗi đơn giản. Phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được liên kết với một bản trình bày, slide hoặc shape.

{{% /alert %}}

## **Làm việc với phần XML tùy chỉnh**

Thuộc tính [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomdata/customxmlparts/) trả về tập hợp các phần XML tùy chỉnh được liên kết với một đối tượng bản trình bày cụ thể. Ví dụ:

- `presentation.CustomData.CustomXmlParts` chứa các phần XML tùy chỉnh liên kết với chính bản trình bày.
- `slide.CustomData.CustomXmlParts` chứa các phần XML tùy chỉnh liên kết với một slide cụ thể.
- `shape.CustomData.CustomXmlParts` chứa các phần XML tùy chỉnh liên kết với một shape cụ thể.

Sử dụng [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/allcustomxmlparts/) khi cần kiểm tra tất cả các phần XML tùy chỉnh trong bản trình bày bất kể chúng được liên kết ở đâu.

### **Thêm phần XML tùy chỉnh vào Presentation**

Sử dụng [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection/add/) để thêm dữ liệu XML vào một tập hợp phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào tập hợp dữ liệu tùy chỉnh ở mức presentation:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add tự động gán một định danh. Chỉ đặt GUID cụ thể khi cần thiết.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Phương thức `Add` cũng có thể nhận XML dưới dạng mảng byte hoặc stream, hữu ích khi nội dung XML đã có sẵn ở dạng nhị phân.

### **Thêm phần XML tùy chỉnh vào Slide hoặc Shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bản trình bày. Điều này hữu ích khi siêu dữ liệu mô tả chỉ một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi bên ngoài, hoặc thông tin ràng buộc.

Ví dụ sau thêm một phần XML tùy chỉnh vào một slide và một phần khác vào một shape:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Mức mà một phần được thêm vào xác định tập hợp `CustomData.CustomXmlParts` của đối tượng nào sẽ chứa quan hệ tới phần đó. Dữ liệu ở mức presentation thích hợp cho siêu dữ liệu toàn tài liệu, dữ liệu ở mức slide cho thông tin thuộc về một slide cụ thể, và dữ liệu ở mức shape cho siêu dữ liệu gắn với một shape riêng lẻ.

### **Liệt kê và kiểm tra toàn bộ phần XML tùy chỉnh**

Sử dụng [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/allcustomxmlparts/) để lấy tất cả các phần XML tùy chỉnh từ một bản trình bày. Mỗi [`ICustomXmlPart`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/) cung cấp định danh, nội dung XML và các schema không gian tên liên quan.

Ví dụ sau liệt kê toàn bộ phần XML tùy chỉnh và các schema không gian tên của chúng:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/namespaceschemas/) trả về các schema XML liên kết với phần XML tùy chỉnh. Thông tin này có thể hữu ích khi kiểm tra các bản trình bày chứa XML được tạo bởi hệ thống bên ngoài.

### **Đọc và cập nhật nội dung XML và ItemId**

Sử dụng [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/xmlasstring/) để làm việc với XML dưới dạng chuỗi UTF‑8, hoặc [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/xmldata/) để làm việc với các byte XML thô. Cả hai thuộc tính đều có thể đọc và cập nhật.

Thuộc tính [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/itemid/) chứa GUID xác định phần XML tùy chỉnh trong tài liệu Office Open XML. Nó cũng có thể được thay đổi khi một tích hợp yêu cầu định danh mới.

Ví dụ sau cập nhật nội dung XML và định danh:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Đọc XML hiện tại dưới dạng văn bản.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Cập nhật XML dưới dạng chuỗi UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData cung cấp cùng nội dung XML dưới dạng byte thô.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Thay thế định danh khi tích hợp yêu cầu.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Khi gán `XmlAsString` hoặc `XmlData`, hãy cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai biểu diễn tùy thuộc vào việc ứng dụng chủ yếu làm việc với chuỗi hay dữ liệu byte.

### **Xóa một phần XML tùy chỉnh**

Aspose.Slides cung cấp một số cách để xóa dữ liệu XML tùy chỉnh:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/remove/) xóa phần XML tùy chỉnh khỏi bản trình bày.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection/remove/) xóa một phần cụ thể khỏi tập hợp phần XML tùy chỉnh.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection/removeat/) xóa phần tại chỉ mục nhất định trong tập hợp.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection/clear/) xóa tất cả các phần khỏi một tập hợp cụ thể.

Ví dụ sau xóa một phần XML tùy chỉnh ở mức presentation bằng tham chiếu:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Nếu bạn đã có một `ICustomXmlPart` và muốn xóa phần đó khỏi bản trình bày thay vì thao tác trên một tập hợp cụ thể, gọi `customXmlPart.Remove()`.

Bạn cũng có thể xóa mục theo chỉ mục:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Xóa toàn bộ phần XML tùy chỉnh khỏi một tập hợp**

Sử dụng `Clear` khi muốn xóa tất cả các phần XML tùy chỉnh liên kết với một đối tượng bản trình bày cụ thể.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` chỉ ảnh hưởng đến tập hợp đã chọn. Ví dụ, việc xóa sạch tập hợp của một slide không xóa các tập hợp ở mức presentation hoặc shape.

Để xóa mọi phần XML tùy chỉnh trong bản trình bày, lặp qua `AllCustomXmlParts` và xóa từng phần:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Xử lý các phần XML tùy chỉnh được liên kết hoặc chia sẻ**

Trong một bản trình bày Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ nhiều đối tượng bản trình bày. Ví dụ, một tệp hiện có thể chứa các quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh nền tảng.

Một phần chia sẻ nên được coi là một đối tượng dữ liệu duy nhất với nhiều tham chiếu:

- Cập nhật `XmlAsString`, `XmlData` hoặc `ItemId` của nó sẽ thay đổi phần XML tùy chỉnh nền tảng, vì vậy thay đổi áp dụng ở mọi nơi mà phần đó được tham chiếu.
- `ItemId` có thể dùng để xác định cùng một phần XML tùy chỉnh khi kiểm tra các tập hợp mức đối tượng.
- Xóa một phần khỏi một tập hợp `CustomXmlParts` cụ thể chỉ xóa nó khỏi tập hợp đó. Dùng `ICustomXmlPart.Remove()` khi muốn xóa phần đó hoàn toàn khỏi bản trình bày.
- Trước khi xóa hoặc thay thế một phần chia sẻ, kiểm tra các tập hợp mức đối tượng để xác định liệu các slide hoặc shape khác còn tham chiếu tới nó không.

Các overload của `Add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một `ICustomXmlPart` đã tồn tại. Do đó, các quan hệ chia sẻ thường xuất hiện khi tải các bản trình bày đã có chúng.

Ví dụ sau kiểm tra các tập hợp ở mức presentation, slide và shape bằng `ItemId` và báo cáo các phần được tham chiếu từ hơn một vị trí:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Loại kiểm tra này hữu ích trước khi chỉnh sửa hoặc xóa dữ liệu XML tùy chỉnh trong các bản trình bày do hệ thống bên ngoài tạo, vì cùng một phần siêu dữ liệu có thể tham gia vào nhiều quan hệ.

## **Lấy giá trị của các thẻ**

Trong slides, một thẻ tương ứng với thuộc tính `IDocumentProperties.Keywords`. Đoạn mã mẫu dưới đây cho thấy cách lấy giá trị thẻ bằng Aspose.Slides for .NET cho [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Thêm thẻ vào Presentation**

Aspose.Slides cho phép bạn thêm thẻ vào các bản trình bày. Một thẻ thường gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ `My Tag Value`.

Nếu bạn cần phân loại các bản trình bày dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại các bản trình bày từ các quốc gia Bắc Mỹ, bạn có thể tạo một thẻ North American và gán quốc gia tương ứng làm giá trị.

Đoạn mã mẫu dưới đây cho thấy cách thêm thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) bằng Aspose.Slides for .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Thẻ cũng có thể được đặt cho một [Slide](https://reference.aspose.com/slides/vi/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Hoặc cho một [Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/shape) riêng lẻ:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Giới hạn**

Thẻ được thêm thông qua tập hợp `CustomData.Tags` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình bày được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể lấy lại từ PDF có thẻ.

**Giải pháp**: Bạn có thể lưu định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.AlternativeText = "MyId"`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một presentation, slide hoặc shape trong một thao tác không?**

Có. [tag collection](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/) hỗ trợ thao tác [Clear](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/clear/) để xoá tất cả các cặp khóa‑giá trị một lúc.

**Làm sao xóa một thẻ duy nhất theo tên mà không phải duyệt toàn bộ tập hợp?**

Dùng [Remove(name)](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/remove/) trên [TagCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/) để xoá thẻ theo khóa.

**Làm sao lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Dùng [GetNamesOfTags](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/getnamesoftags/) trên [tag collection](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/); nó trả về một mảng các tên thẻ.

**Làm sao tìm tất cả các phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**

Dùng [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/allcustomxmlparts/) để lấy mọi phần XML tùy chỉnh trong bản trình bày.

**Nên dùng `XmlAsString` hay `XmlData` để cập nhật một phần XML tùy chỉnh?**

Dùng `XmlAsString` khi ứng dụng làm việc với văn bản XML UTF‑8. Dùng `XmlData` khi XML đã có sẵn dưới dạng mảng byte hoặc khi xử lý dạng nhị phân thuận tiện hơn. Cả hai thuộc tính đều đại diện cho nội dung XML của cùng một phần XML tùy chỉnh.