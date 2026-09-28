---
title: Chuyển đổi Bản trình chiếu PowerPoint sang XML trong .NET
linktitle: PowerPoint sang XML
type: docs
weight: 145
url: /vi/net/convert-powerpoint-to-xml/
keywords:
- chuyển đổi PowerPoint sang XML
- chuyển đổi bản trình chiếu sang XML
- PPT sang XML
- PPTX sang XML
- ODP sang XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- lưu bản trình chiếu dưới dạng XML
- xuất bản trình chiếu sang XML
- luồng XML
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang tệp hoặc luồng PowerPoint XML trong C# với Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET có thể chuyển đổi các bản trình chiếu PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần biểu diễn dựa trên văn bản để kiểm tra cấu trúc trình chiếu, khắc phục sự cố tài liệu được tạo, so sánh đầu ra trong các bài kiểm tra tự động, hoặc tích hợp với quy trình làm việc tiêu thụ XML thay vì một gói trình chiếu.

Sử dụng phương thức [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) với giá trị `Xml` từ enum [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào luồng.

{{% alert color="info" title="Lưu ý" %}}

`SaveFormat.Xml` tạo một PowerPoint XML Presentation. Nó không trích xuất các phần Office Open XML riêng lẻ được lưu trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn `ppt/presentation.xml` hoặc các tệp XML slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.

{{% /alert %}}

## **Chuyển đổi Bản trình chiếu sang Tệp XML**

Tải một bản trình chiếu nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/), sau đó truyền đường dẫn đầu ra và `SaveFormat.Xml` vào [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/). Nguồn có thể là bất kỳ định dạng trình chiếu nào được hỗ trợ để tải, chẳng hạn PPT, PPTX hoặc ODP.

Ví dụ sau chuyển đổi một bản trình chiếu PPTX sang tệp XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Ghi Đầu ra XML vào Luồng**

Sử dụng overload luồng của [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) khi XML phải ở trong bộ nhớ hoặc được truyền cho thành phần khác, chẳng hạn dịch vụ web, nhà cung cấp lưu trữ hoặc pipeline xử lý XML. Ví dụ sau ghi kết quả vào một [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) và quay lại đầu để đọc tiếp:

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

## **So sánh XML với Định dạng Bản trình chiếu và Xuất**

Chọn định dạng đầu ra tùy theo cách kết quả sẽ được sử dụng:

| Định dạng | Đầu ra | Cách sử dụng điển hình |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Một PowerPoint XML Presentation | Kiểm tra cấu trúc, khắc phục sự cố, so sánh đầu ra được tạo, và tích hợp dựa trên XML |
| PPT (`.ppt`) | Một tệp trình chiếu nhị phân kế thừa | Tương thích với các quy trình làm việc PowerPoint cũ |
| PPTX (`.pptx`) | Một gói Office Open XML chứa nhiều phần | Chỉnh sửa PowerPoint thông thường và trao đổi bản trình chiếu |
| PDF hoặc TIFF | Các trang bố cục cố định hoặc hình ảnh TIFF | Xem, in và lưu trữ |
| PNG, JPEG hoặc SVG | Đại diện đã render của một slide riêng lẻ | Hình thu nhỏ, bản xem trước và tài sản hình ảnh |
| HTML hoặc HTML5 | Đầu ra trình chiếu hướng web | Xem trong trình duyệt và xuất bản web |

Không giống như PPT và PPTX, đầu ra XML chủ yếu nhằm mục đích kiểm tra và quy trình làm việc dựa trên dữ liệu. Không giống như PDF, TIFF, HTML và các định dạng hình ảnh slide, nó biểu diễn dữ liệu trình chiếu thay vì render slide thành các trang hoặc tài sản hình ảnh. Bảng [định dạng tệp được hỗ trợ](/slides/vi/net/supported-file-formats/) liệt kê mọi định dạng mà Aspose.Slides có thể tải, nhập, lưu hoặc render.

## **Câu hỏi thường gặp**

**`SaveFormat.Xml` có giống như lưu một tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi `SaveFormat.Xml` tạo một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Truyền một luồng có thể ghi được vào [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/). Ví dụ, dùng một [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) cho xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Có. Truyền tệp XML hoặc một luồng vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/presentation/). [Presentation.SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sourceformat/) sau đó trả về `SourceFormat.Xml`. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/getpresentationinfo/) báo cáo `LoadFormat.Unknown` cho định dạng này, vì vậy không sử dụng nó để quyết định xem một tệp XML có thể mở được hay không.

**Việc chuyển đổi XML có render mỗi slide thành trang hoặc hình ảnh không?**

Không. Việc chuyển đổi XML ghi dữ liệu trình chiếu có cấu trúc. Sử dụng PDF hoặc TIFF cho đầu ra dạng trang, hoặc PNG, JPEG và SVG cho hình ảnh slide riêng lẻ.