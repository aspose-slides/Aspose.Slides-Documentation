---
title: Truy xuất và Cập nhật Thông tin Bản trình bày trong .NET
linktitle: Thông tin Bản trình bày
type: docs
weight: 30
url: /vi/net/examine-presentation/
keywords:
- định dạng bản trình bày
- thuộc tính bản trình bày
- thuộc tính tài liệu
- lấy thuộc tính
- đọc thuộc tính
- thay đổi thuộc tính
- sửa đổi thuộc tính
- cập nhật thuộc tính
- kiểm tra PPTX
- kiểm tra PPT
- kiểm tra ODP
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong bản trình bày PowerPoint và OpenDocument bằng .NET để có những hiểu biết nhanh hơn và kiểm toán nội dung thông minh hơn."
---
## **Tổng quan**

Aspose.Slides có thể xác định định dạng của một bản trình bày và đọc siêu dữ liệu tài liệu mà không cần tạo mô hình đối tượng bản trình bày đầy đủ. Điều này hữu ích khi bạn cần phân loại tệp, xây dựng kho lưu trữ hoặc kiểm tra các thuộc tính trước khi quyết định tải và xử lý nội dung bản trình bày.

Bài viết này trình bày cách kiểm tra nhẹ nhàng thông qua [PresentationFactory](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/) và [IPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/), cũng như cách cập nhật mục tiêu thông qua [IDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/).

## **Kiểm tra định dạng bản trình bày**

Nếu bạn đã có một bản trình bày đã được tải, xem mục [Determine the Original Presentation Format](/slides/vi/net/detect-presentation-source-format/) để phát hiện sau khi tải và những hạn chế của các luồng PPT, PPS và POT cổ điển.

Sử dụng [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/getpresentationinfo/) để kiểm tra tệp mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Thuộc tính [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/loadformat/) báo cáo định dạng đã phát hiện, chẳng hạn như PPTX, PPT hoặc ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Xây dựng kho lưu trữ bản trình bày nhẹ**

Khi bạn xử lý nhiều tệp bản trình bày, có thể cần một kho lưu trữ gọn để xác thực, lập chỉ mục hoặc hệ thống quản lý tài liệu. Trong trường hợp này, hãy sử dụng [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/getpresentationinfo/) để lấy một đối tượng [IPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/), sau đó gọi [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) để đọc siêu dữ liệu tài liệu. Cách tiếp cận này không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và không yêu cầu bạn duyệt qua toàn bộ mô hình đối tượng bản trình bày.

Các thuộc tính mở rộng do [IDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/) cung cấp đưa ra các giá trị tồn kho sau:

| Thuộc tính | Giá trị tồn kho |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/slides/vi/) | Tổng số slide. |
| [HiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/hiddenslides/) | Số slide ẩn. |
| [Notes](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/notes/) | Số slide có ghi chú. |
| [Paragraphs](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/paragraphs/) | Tổng số đoạn văn, nếu có. |
| [Words](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/words/) | Tổng số từ. |
| [MultimediaClips](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/multimediaclips/) | Tổng số đoạn âm thanh và video. |

Ví dụ sau đọc các giá trị này mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và in ra một kho lưu trữ gọn. Nó cũng kết hợp [HeadingPairs](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/headingpairs/) với [TitlesOfParts](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/titlesofparts/) để hiển thị các nhóm nội dung như phông chữ, chủ đề và tiêu đề slide.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Mỗi [IHeadingPair](https://reference.aspose.com/slides/vi/net/aspose.slides/iheadingpair/) cung cấp một tên nhóm và số mục trong nhóm đó. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/titlesofparts/) là một mảng phẳng, có thứ tự, vì vậy hãy tiêu thụ số tiêu đề liên tiếp được chỉ định bởi mỗi cặp tiêu đề.

### **Siêu dữ liệu đã lưu và các hạn chế định dạng**

Các thuộc tính kho lưu trữ được trả về bởi [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) phản ánh siêu dữ liệu có trong tài liệu nguồn. Aspose.Slides không tải và duyệt mô hình đối tượng bản trình bày để tính lại các giá trị này cho lần gọi này. Các thuộc tính thiếu được biểu thị bằng giá trị mặc định, và các giá trị đã lưu có thể đã lỗi thời nếu ứng dụng lưu tệp lần cuối không cập nhật các thuộc tính tài liệu.

- **PPTX:** Định dạng cung cấp các thuộc tính tài liệu mở rộng cho số slide, ghi chú, slide ẩn, đoạn, từ và đoạn đa phương tiện, cũng như các cặp tiêu đề và tiêu đề phần. Khả dụng phụ thuộc vào các thuộc tính mà nhà sản xuất tài liệu đã ghi.
- **PPT:** Định dạng nhị phân có thể lưu các thuộc tính tóm tắt tài liệu tương ứng. Nếu một thuộc tính không tồn tại hoặc không được nhà sản xuất tài liệu làm mới, Aspose.Slides trả về giá trị đã lưu hoặc mặc định thay vì tính toán từ các slide.
- **ODP:** Siêu dữ liệu OpenDocument cung cấp thống kê chung của tài liệu, chẳng hạn như số trang, đoạn và từ, nhưng các giá trị này không ánh xạ tới mọi thuộc tính mở rộng đặc thù của PowerPoint. Siêu dữ liệu cho slide ẩn, slide ghi chú, đa phương tiện, cặp tiêu đề và tiêu đề phần có thể không có, và các thuộc tính kho lưu trữ có thể trả về giá trị mặc định. Đừng xem giá trị 0 hoặc mảng trống là bằng chứng chắc chắn cho việc nội dung tương ứng không tồn tại.

Sử dụng cách tiếp cận siêu dữ liệu nhẹ cho các kho lưu trữ và kiểm tra sơ bộ. Tải bản trình bày và kiểm tra mô hình đối tượng sống khi kết quả phải phản ánh các thay đổi trong bộ nhớ hoặc khi bạn cần xác thực nội dung thực tế của bản trình bày.

## **Cập nhật thuộc tính bản trình bày**

Các thuộc tính được trả về bởi [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) cũng có thể được thay đổi mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) nào. Áp dụng các thay đổi bằng [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), sau đó ghi bản trình bày đã ràng buộc bằng [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Hình ảnh sau hiển thị các thuộc tính tài liệu gốc.

![Original document properties of the PowerPoint presentation](input_properties.png)

Ví dụ sau thay đổi tiêu đề và thời gian lưu cuối cùng và ghi kết quả vào một tệp mới:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Hình ảnh sau hiển thị các thuộc tính tài liệu đã được cập nhật.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Liên kết hữu ích**

Đối với các kiểm tra bảo mật liên quan và cài đặt bảo vệ, xem các bài viết sau:

- [Password-Protect Presentations](/slides/vi/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/vi/net/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm sao tôi có thể kiểm tra xem phông chữ có được nhúng hay không và chúng là những phông nào?**

Tải bản trình bày và sử dụng [Presentation.FontsManager](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/fontsmanager/). Gọi [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getembeddedfonts/) để lấy các phông chữ đã nhúng và [FontsManager.GetFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getfonts/) để lấy các phông chữ được bản trình bày sử dụng. So sánh hai kết quả để tìm các phông chữ cần thiết cho việc hiển thị nhưng chưa được nhúng.

**Làm sao tôi có thể nhanh chóng biết tệp có slide ẩn và có bao nhiêu?**

Khi siêu dữ liệu tài liệu đã lưu đủ, đọc [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/idocumentproperties/hiddenslides/) thông qua [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/getpresentationinfo/) và [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Cách này phù hợp cho một kho lưu trữ nhẹ. Nếu bản trình bày đã được sửa đổi trong bộ nhớ, siêu dữ liệu đã lưu có thể thiếu hoặc lỗi thời, hoặc bạn cần xác thực các giá trị thực tế, hãy duyệt [Presentation.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slides/vi/) và kiểm tra thuộc tính [Slide.Hidden](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/hidden/) của mỗi slide.

**Tôi có thể phát hiện xem kích thước slide tùy chỉnh và hướng đặt có được sử dụng không, và chúng có khác với giá trị mặc định không?**

Có. Tải bản trình bày và đọc [Presentation.SlideSize](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slidesize/). Kiểm tra [ISlideSize.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/vi/net/aspose.slides/islidesize/size/), và [ISlideSize.Orientation](https://reference.aspose.com/slides/vi/net/aspose.slides/islidesize/orientation/) để so sánh cài đặt hiện tại với các thông số và kích thước dự kiến.

**Có cách nhanh để xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Xác định mỗi [Chart](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/) và kiểm tra [ChartData.DataSourceType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/datasourcetype/). Đối với một workbook bên ngoài, đọc [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/externalworkbookpath/). Kiểu nguồn dữ liệu và đường dẫn xác định tham chiếu bên ngoài, nhưng việc xác thực nguồn có sẵn cần một kiểm tra tài nguyên riêng.

**Làm sao tôi đánh giá các slide 'nặng' có thể làm chậm quá trình render hoặc xuất PDF?**

Không có thuộc tính phức tạp đơn lẻ. Duyệt [Presentation.Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slides/vi/) và bộ sưu tập [IBaseSlide.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/shapes/) của mỗi slide. Sử dụng số lượng hình dạng và sự hiện diện của hình ảnh lớn, hiệu ứng, hoạt ảnh hoặc đa phương tiện làm tín hiệu sàng lọc, và đo một lần render hoặc xuất mẫu trước khi xác định một slide là nút thắt hiệu năng đã được xác nhận.