---
title: Chuyển đổi bản trình chiếu PowerPoint sang XML trong .NET
linktitle: PowerPoint sang XML
type: docs
weight: 145
url: /vi/net/convert-powerpoint-to-xml/
keywords:
- chuyển PowerPoint sang XML
- chuyển bản trình chiếu sang XML
- PPT sang XML
- PPTX sang XML
- ODP sang XML
- Bản trình chiếu XML PowerPoint
- SaveFormat.Xml
- lưu bản trình chiếu dưới dạng XML
- xuất bản trình chiếu ra XML
- luồng XML
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang tệp XML PowerPoint hoặc luồng trong C# với Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET có thể chuyển đổi các bản trình chiếu PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần một biểu diễn dạng văn bản để kiểm tra cấu trúc bản trình chiếu, khắc phục sự cố tài liệu được tạo, so sánh kết quả trong các bài kiểm tra tự động, hoặc tích hợp với quy trình công việc tiêu thụ XML thay vì gói bản trình chiếu.

Sử dụng phương thức [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) với giá trị `Xml` từ enumeration [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào luồng.

{{% alert color="info" title="Ghi chú" %}}

`SaveFormat.Xml` tạo một PowerPoint XML Presentation. Nó không trích xuất các phần Office Open XML riêng lẻ được lưu trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn như `ppt/presentation.xml` hoặc các tệp XML của slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.

{{% /alert %}}

## **Chuyển đổi bản trình chiếu thành tệp XML**

Tải một bản trình chiếu nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) , sau đó truyền đường dẫn đầu ra và `SaveFormat.Xml` vào [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/). Nguồn có thể ở bất kỳ định dạng bản trình chiếu nào được hỗ trợ để tải, chẳng hạn như PPT, PPTX hoặc ODP.

Ví dụ sau chuyển đổi một bản trình chiếu PPTX thành tệp XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Ghi đầu ra XML vào luồng**

Sử dụng phiên bản overload nhận luồng của [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) khi XML cần giữ trong bộ nhớ hoặc được truyền cho thành phần khác, chẳng hạn như web service, nhà cung cấp lưu trữ, hoặc pipeline xử lý XML. Ví dụ sau ghi kết quả vào một [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) và đưa con trỏ quay lại để đọc tiếp theo:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Chuyển xmlStream sang thành phần tiếp theo trong quy trình làm việc.
```

## **So sánh XML với các định dạng bản trình chiếu và xuất**

Chọn định dạng đầu ra tùy theo cách kết quả sẽ được sử dụng:

| Định dạng | Đầu ra | Sử dụng thường xuyên |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Kiểm tra cấu trúc, khắc phục sự cố, so sánh kết quả được tạo và tích hợp dựa trên XML |
| PPT (`.ppt`) | Tệp bản trình chiếu nhị phân cổ điển | Tương thích với quy trình PowerPoint cũ |
| PPTX (`.pptx`) | Gói Office Open XML chứa nhiều phần | Chỉnh sửa PowerPoint thông thường và trao đổi bản trình chiếu |
| PDF hoặc TIFF | Các trang bố cục cố định hoặc ảnh đa trang | Xem, in và lưu trữ |
| PNG, JPEG hoặc SVG | Ảnh đại diện được render của một slide riêng lẻ | Hình thu nhỏ, xem trước và tài nguyên hình ảnh |
| HTML hoặc HTML5 | Đầu ra bản trình chiếu hướng web | Xem trên trình duyệt và xuất bản web |

Khác với PPT và PPTX, đầu ra XML chủ yếu nhằm mục đích kiểm tra và các quy trình dựa trên dữ liệu. Khác với PDF, TIFF, HTML và các định dạng hình ảnh slide, nó biểu diễn dữ liệu bản trình chiếu thay vì render slide thành các trang hoặc tài sản hình ảnh. Bảng [supported file formats](/slides/vi/net/supported-file-formats/) liệt kê PowerPoint XML Presentation là định dạng chỉ lưu, vì vậy không nên sử dụng khi một quy trình cần tải lại tệp đã xuất vào Aspose.Slides để tiếp tục chỉnh sửa.

## **Câu hỏi thường gặp**

**`SaveFormat.Xml` có giống như lưu tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi `SaveFormat.Xml` tạo một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Truyền một luồng có thể ghi tới [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/). Ví dụ, sử dụng một [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) để xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Không. PowerPoint XML Presentation hiện chỉ được hỗ trợ để lưu, không hỗ trợ tải. Sử dụng PPTX hoặc một định dạng bản trình chiếu được hỗ trợ khác khi cần chỉnh sửa vòng lặp.

**Quá trình chuyển đổi XML có render mỗi slide thành trang hoặc hình ảnh không?**

Không. Chuyển đổi XML ghi dữ liệu bản trình chiếu có cấu trúc. Sử dụng PDF hoặc TIFF cho đầu ra dạng trang, hoặc PNG, JPEG và SVG cho hình ảnh slide riêng lẻ.