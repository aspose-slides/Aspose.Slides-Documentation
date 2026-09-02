---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình chiếu bằng .NET
linktitle: Thẻ và Dữ liệu Tùy chỉnh
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bản trình chiếu PowerPoint với Aspose.Slides cho .NET, bao gồm thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình chiếu PowerPoint. Dữ liệu đặc thù cho bản trình chiếu có thể được lưu dưới dạng thẻ hoặc các phần XML tùy chỉnh. Thẻ là các cặp chuỗi khóa-giá trị đơn giản, trong khi các phần XML tùy chỉnh có thể lưu siêu dữ liệu có cấu trúc và dữ liệu XML đặc thù cho ứng dụng.

Aspose.Slides cung cấp các API để thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh ở mức bản trình chiếu, slide và hình dạng. Các phần XML tùy chỉnh hữu ích cho các tích hợp lưu thông tin như định danh quản lý tài liệu, trạng thái quy trình công việc, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu, hoặc các dữ liệu ứng dụng có cấu trúc khác trong một bản trình chiếu.

## **Lưu trữ Dữ liệu trong Tệp Bản Trình Chiếu**

Các tệp PPTX—các tệp có phần mở rộng `.pptx`—được lưu ở định dạng PresentationML, một phần của tiêu chuẩn Office Open XML. Office Open XML xác định cấu trúc gói và các mối quan hệ được dùng để lưu nội dung bản trình chiếu và dữ liệu liên quan.

Bản trình chiếu chứa nhiều phần được kết nối bằng các mối quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các mối quan hệ rõ ràng với các phần khác được định nghĩa bởi ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/itagcollection)) hoặc các phần XML tùy chỉnh ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection)). Cả hai đều khả dụng thông qua giao diện [`ICustomData`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}
Thẻ lưu các cặp khóa-giá trị chuỗi đơn giản. Các phần XML tùy chỉnh lưu dữ liệu XML có cấu trúc và có thể được gắn với bản trình chiếu, slide hoặc hình dạng.
{{% /alert %}}

## **Làm việc với Các Phần XML Tùy Chỉnh**

Thuộc tính [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomdata/customxmlparts/) trả về bộ sưu tập các phần XML tùy chỉnh liên kết với một đối tượng bản trình chiếu cụ thể. Ví dụ:

- `presentation.CustomData.CustomXmlParts` chứa các phần XML tùy chỉnh liên kết với bản trình chiếu tự nó.
- `slide.CustomData.CustomXmlParts` chứa các phần XML tùy chỉnh liên kết với một slide cụ thể.
- `shape.CustomData.CustomXmlParts` chứa các phần XML tùy chỉnh liên kết với một hình dạng cụ thể.

Sử dụng [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/allcustomxmlparts/) khi bạn cần kiểm tra tất cả các phần XML tùy chỉnh trong bản trình chiếu bất kể chúng được gắn ở đâu.

### **Thêm một Phần XML Tùy Chỉnh vào Bản Trình Chiếu**

Sử dụng [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection/add/) để thêm dữ liệu XML vào bộ sưu tập các phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào bộ sưu tập dữ liệu tùy chỉnh ở mức bản trình chiếu:

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

Phương thức `Add` cũng có thể nhận XML dưới dạng mảng byte hoặc luồng, hữu ích khi nội dung XML đã có sẵn ở dạng nhị phân.

### **Thêm một Phần XML Tùy Chỉnh vào Slide hoặc Shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bản trình chiếu. Điều này hữu ích khi siêu dữ liệu chỉ mô tả một đối tượng, như khóa mẫu, định danh bản ghi bên ngoài, hoặc thông tin ràng buộc.

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

Mức mà phần được thêm vào xác định bộ sưu tập `CustomData.CustomXmlParts` của đối tượng nào chứa mối quan hệ tới phần đó. Dữ liệu ở mức bản trình chiếu phù hợp cho siêu dữ liệu toàn tài liệu, dữ liệu ở mức slide cho thông tin thuộc về một slide cụ thể, và dữ liệu ở mức shape cho siêu dữ liệu gắn với một shape cá nhân.

### **Liệt kê và Kiểm tra Tất cả Các Phần XML Tùy Chỉnh**

Sử dụng [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/allcustomxmlparts/) để lấy tất cả các phần XML tùy chỉnh từ một bản trình chiếu. Mỗi [`ICustomXmlPart`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/) cung cấp định danh, nội dung XML và các schema không gian tên liên quan.

Ví dụ sau liệt kê tất cả các phần XML tùy chỉnh và các schema không gian tên của chúng:

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

`ICustomXmlPart.NamespaceSchemas` trả về các schema XML liên kết với phần XML tùy chỉnh. Thông tin này hữu ích khi kiểm tra các bản trình chiếu chứa XML do hệ thống bên ngoài tạo ra.

### **Đọc và Cập nhật Nội dung XML và ItemId**

Sử dụng [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/xmlasstring/) để làm việc với XML dưới dạng chuỗi UTF-8, hoặc [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/xmldata/) để làm việc với dữ liệu XML thô dạng byte. Cả hai thuộc tính đều có thể đọc và cập nhật.

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

Khi gán `XmlAsString` hoặc `XmlData`, hãy cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai đại diện tùy thuộc vào việc ứng dụng làm việc chủ yếu với chuỗi hay dữ liệu byte.

### **Xóa một Phần XML Tùy Chỉnh**

Aspose.Slides cung cấp một số cách để xóa dữ liệu XML tùy chỉnh:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpart/remove/) xóa phần XML tùy chỉnh khỏi bản trình chiếu.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection/remove/) xóa một phần cụ thể khỏi bộ sưu tập các phần XML tùy chỉnh.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection/removeat/) xóa phần tại chỉ mục bộ sưu tập được chỉ định.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/vi/net/aspose.slides/icustomxmlpartcollection/clear/) xóa tất cả các phần khỏi một bộ sưu tập cụ thể.

Ví dụ sau xóa một phần XML tùy chỉnh ở mức bản trình chiếu bằng tham chiếu:

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

Nếu bạn đã có một `ICustomXmlPart` và muốn xóa phần đó khỏi bản trình chiếu thay vì truy cập một bộ sưu tập cụ thể, gọi `customXmlPart.Remove()`.

Bạn cũng có thể xóa một mục theo chỉ mục:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Xóa Tất cả Các Phần XML Tùy Chỉnh trong Bộ Sưu Tập**

Sử dụng `Clear` khi mọi phần XML tùy chỉnh liên kết với một đối tượng bản trình chiếu cụ thể cần được xóa.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` chỉ ảnh hưởng đến bộ sưu tập đã chọn. Ví dụ, việc xóa bộ sưu tập của một slide không làm xóa các bộ sưu tập ở mức bản trình chiếu hoặc shape.

Để xóa mọi phần XML tùy chỉnh trong bản trình chiếu, lặp qua `AllCustomXmlParts` và xóa từng phần:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Xử lý Các Phần XML Tùy Chỉnh Liên kết hoặc Chia sẻ**

Trong một bản trình chiếu Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ hơn một đối tượng bản trình chiếu. Ví dụ, một tệp hiện có có thể chứa các mối quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh cơ bản.

Một phần được chia sẻ nên được xem như một đối tượng dữ liệu duy nhất với nhiều tham chiếu:

- Cập nhật `XmlAsString`, `XmlData` hoặc `ItemId` của nó thay đổi phần XML tùy chỉnh cơ bản, do đó thay đổi áp dụng ở mọi nơi phần đó được tham chiếu.
- `ItemId` có thể được dùng để nhận dạng cùng một phần XML tùy chỉnh khi kiểm tra các bộ sưu tập ở mức đối tượng.
- Xóa một phần khỏi một bộ sưu tập `CustomXmlParts` cụ thể sẽ xóa nó khỏi bộ sưu tập đó. Sử dụng `ICustomXmlPart.Remove()` khi phần đó cần được xóa khỏi bản trình chiếu.
- Trước khi xóa hoặc thay thế một phần được chia sẻ, hãy kiểm tra các bộ sưu tập ở mức đối tượng để xác định liệu các slide hoặc shape khác còn tham chiếu tới nó hay không.

Các overload của `Add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một `ICustomXmlPart` đã tồn tại. Do đó, các mối quan hệ chia sẻ thường gặp nhất khi tải các bản trình chiếu đã có sẵn chúng.

Ví dụ sau kiểm tra các bộ sưu tập ở mức bản trình chiếu, slide và shape bằng `ItemId` và báo cáo các phần được tham chiếu từ nhiều vị trí:

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

Loại kiểm tra này hữu ích trước khi sửa đổi hoặc xóa dữ liệu XML tùy chỉnh trong các bản trình chiếu được tạo bởi hệ thống bên ngoài, vì cùng một phần siêu dữ liệu có thể tham gia vào nhiều mối quan hệ.

## **Lấy Giá trị của Thẻ**

Trong Slides, một thẻ tương ứng với thuộc tính `IDocumentProperties.Keywords`. Mã mẫu này cho thấy cách lấy giá trị thẻ bằng Aspose.Slides cho .NET cho [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Thêm Thẻ vào Bản Trình Chiếu**

Aspose.Slides cho phép bạn thêm thẻ vào bản trình chiếu. Một thẻ thường bao gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ `My Tag Value`.

Nếu bạn cần phân loại bản trình chiếu dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại các bản trình chiếu từ các quốc gia Bắc Mỹ, bạn có thể tạo một thẻ North American và gán quốc gia tương ứng làm giá trị.

Mã mẫu này cho thấy cách thêm một thẻ vào [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) bằng Aspose.Slides cho .NET:

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

Hoặc cho một [Shape](https://reference.aspose.com/slides/vi/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Giới hạn**

Các thẻ được thêm qua bộ sưu tập `CustomData.Tags` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình chiếu được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được lấy lại từ PDF có thẻ.

**Giải pháp thay thế**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.AlternativeText = "MyId"`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả các thẻ khỏi một bản trình chiếu, slide hoặc shape trong một thao tác duy nhất không?**

Có. [Bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/) hỗ trợ thao tác [Clear](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/clear/) để xóa tất cả các cặp khóa-giá trị cùng lúc.

**Làm sao tôi có thể xóa một thẻ duy nhất theo tên mà không cần lặp qua toàn bộ bộ sưu tập?**

Sử dụng [Remove(name)](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/remove/) trên [TagCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Sử dụng [GetNamesOfTags](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/getnamesoftags/) trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/net/aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.

**Làm sao tôi có thể tìm tất cả các phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**

Sử dụng [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/allcustomxmlparts/) để lấy tất cả các phần XML tùy chỉnh trong bản trình chiếu.

**Tôi nên dùng `XmlAsString` hay `XmlData` để cập nhật một phần XML tùy chỉnh?**

Dùng `XmlAsString` khi ứng dụng làm việc với văn bản XML UTF-8. Dùng `XmlData` khi XML đã có dưới dạng mảng byte hoặc khi xử lý dựa trên nhị phân thuận tiện hơn. Cả hai thuộc tính đều biểu thị nội dung XML của cùng một phần XML tùy chỉnh.