---
title: Lưu bản trình chiếu trong .NET
linktitle: Lưu bản trình chiếu
type: docs
weight: 80
url: /vi/net/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản trình chiếu
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản trình chiếu thành tệp
- bản trình chiếu thành luồng
- kiểu xem được định nghĩa trước
- Định dạng Office Open XML Strict
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- .NET
- C#
- Aspose.Slides
description: "Lưu các bản trình chiếu PowerPoint và OpenDocument thành tệp hoặc luồng trong C# với Aspose.Slides cho .NET, và cấu hình đầu ra PPTX cùng báo cáo tiến độ."
---
## **Tổng quan**

Sau khi bạn tạo một bản trình chiếu hoặc [mở một bản trình chiếu hiện có](/slides/vi/net/open-presentation/), hãy sử dụng phương thức [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) để ghi kết quả. Aspose.Slides for .NET có thể lưu một bản trình chiếu vào tệp hoặc luồng ở các định dạng PowerPoint, OpenDocument, PDF và các định dạng khác. Các phần tiếp theo đề cập đến các thao tác lưu chuẩn và các tùy chọn có sẵn cho đầu ra PPTX.

## **Lưu bản trình chiếu vào tệp**

Để lưu một bản trình chiếu vào tệp, truyền đường dẫn đầu ra và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/) vào phương thức [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/). Giá trị định dạng xác định loại tệp mà Aspose.Slides tạo ra.

Ví dụ sau tạo một bản trình chiếu và lưu nó dưới dạng tệp PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Lưu bản trình chiếu ở định dạng gốc của chúng**

Đối với các ví dụ phát hiện tệp và luồng, hành vi của các bản trình chiếu mới tạo, và sự khác biệt giữa định dạng nguồn và đầu ra, xem [Determine the Original Presentation Format](/slides/vi/net/detect-presentation-source-format/).

Trong một ứng dụng xử lý theo lô, định dạng đầu vào có thể không được biết trước. Sau khi tải một tệp, đọc định dạng gốc của nó từ thuộc tính [IPresentation.SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/sourceformat/). Truyền giá trị [SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/sourceformat/) thu được vào [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/tosaveformat/) để lấy giá trị [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/) tương ứng, sau đó sử dụng [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) để ghi bản trình chiếu đã sửa đổi.

Ví dụ hoàn chỉnh dưới đây xử lý mọi tệp trong một thư mục nhập, cập nhật tiêu đề và lưu nó vào thư mục xuất ở định dạng mà nó đã được tải:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/tosaveformat/) ánh xạ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP và PowerPoint XML sang các định dạng lưu bản trình chiếu tương ứng. Nó chỉ ánh xạ các định dạng nguồn của bản trình chiếu; không nhằm mục đích chọn các định dạng xuất như PDF, HTML, TIFF hoặc hình ảnh. Truyền một giá trị [SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/sourceformat/) không hỗ trợ hoặc không hợp lệ sẽ gây ra một [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Các tệp PPT, PPS và POT kế thừa sử dụng cùng một container nhị phân. Khi một bản trình chiếu như vậy được tải từ luồng mà không có phần mở rộng tệp, một tệp PPS hoặc POT có thể bị nhận dạng là PPT. Nếu cần bảo tồn các kiểu phụ kế thừa này, hãy giữ lại tên tệp hoặc siêu dữ liệu định dạng gốc riêng và sử dụng chúng khi chọn tên tệp và định dạng đầu ra.

## **Lưu bản trình chiếu vào luồng**

Để ghi một bản trình chiếu mà không phụ thuộc vào đường dẫn tệp cuối cùng, truyền một [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) có khả năng ghi và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/) vào phương thức [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/). Cách tiếp cận này hữu ích khi đầu ra phải được trả về từ một dịch vụ web, lưu trong cơ sở dữ liệu hoặc xử lý trong bộ nhớ.

Ví dụ sau lưu một bản trình chiếu mới vào một luồng tệp:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Lưu bản trình chiếu với Kiểu xem được xác định trước**

Bạn có thể chỉ định kiểu xem mà PowerPoint sẽ mở bản trình chiếu đã lưu ban đầu. Đặt thuộc tính [ViewProperties.LastView](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/lastview/) thành một giá trị [ViewType](https://reference.aspose.com/slides/vi/net/aspose.slides/viewtype/) trước khi lưu.

Ví dụ sau cấu hình kiểu xem Slide Master làm kiểu xem ban đầu:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Lưu bản trình chiếu ở Định dạng Office Open XML Strict**

Để tạo một tệp PPTX tuân thủ hồ sơ Strict của Office Open XML, tạo một đối tượng [PptxOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pptxoptions/) và đặt thuộc tính [Conformance](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pptxoptions/conformance/) của nó thành `Conformance.Iso29500_2008_Strict`. Sau đó truyền các tùy chọn này vào phương thức [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Lưu bản trình chiếu ở Định dạng Office Open XML ở chế độ Zip64**

Một kho nén ZIP chuẩn giới hạn kích thước nén và không nén của mỗi mục, tổng kích thước kho và số mục. Vì tệp PPTX là một kho ZIP, một bản trình chiếu rất lớn có thể vượt quá các giới hạn này. Các phần mở rộng ZIP64 nâng cao các giới hạn kích thước và số mục.

Sử dụng thuộc tính [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pptxoptions/zip64mode/) để điều khiển việc Aspose.Slides ghi các phần mở rộng ZIP64:

- `IfNecessary` chỉ sử dụng ZIP64 khi bản trình chiếu vượt quá giới hạn ZIP tiêu chuẩn. Đây là chế độ mặc định.
- `Never` vô hiệu hoá các phần mở rộng ZIP64.
- `Always` luôn ghi các phần mở rộng ZIP64.

Ví dụ sau luôn bật các phần mở rộng ZIP64 cho bản trình chiếu đầu ra:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Nếu `Zip64Mode` được đặt thành `Never` và bản trình chiếu không thể vừa trong giới hạn ZIP tiêu chuẩn, thao tác lưu sẽ ném ra một [PptxException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Lưu bản trình chiếu ở Định dạng Office Open XML với Mức nén**

Đối với đầu ra PPTX, bạn có thể cân bằng tốc độ lưu và kích thước tệp bằng cách đặt thuộc tính [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pptxoptions/compressionlevel/). Các giá trị của enum [CompressionLevel](https://reference.aspose.com/slides/vi/net/aspose.slides.export/compressionlevel/) bao gồm:

- `None` lưu dữ liệu mà không nén.
- `Level1` cung cấp nén nhanh nhất và kích thước nén lớn nhất.
- `Level2` đến `Level5` dần ưu tiên kích thước nhỏ hơn hơn tốc độ lưu.
- `Level6` cân bằng giữa tốc độ lưu và kích thước tệp. Đây là mức mặc định.
- `Level7` và `Level8` tiếp tục ưu tiên kích thước nhỏ hơn hơn tốc độ lưu.
- `Level9` cung cấp mức nén mạnh nhất và yêu cầu thời gian xử lý lâu nhất.

Ví dụ sau lưu một bản trình chiếu mà không nén:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

Ví dụ sau sử dụng mức nén tối đa:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Lưu bản trình chiếu mà không làm mới hình thu nhỏ**

Khi một bản trình chiếu được lưu dưới dạng PPTX, thuộc tính [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pptxoptions/refreshthumbnail/) điều khiển hình thu nhỏ tài liệu:

- `true` tạo lại hình thu nhỏ trong quá trình lưu. Đây là giá trị mặc định.
- `false` giữ nguyên hình thu nhỏ hiện có. Nếu bản trình chiếu không có hình thu nhỏ, Aspose.Slides sẽ không tạo hình thu nhỏ mới.

Ví dụ sau lưu một bản trình chiếu mà không làm mới hình thu nhỏ:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Vô hiệu hoá việc làm mới hình thu nhỏ có thể giảm thời gian cần thiết để lưu tệp PPTX.
{{% /alert %}}

## **Cập nhật tiến độ lưu dưới dạng phần trăm**

Để giám sát một thao tác lưu, triển khai giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/iprogresscallback/) và gán triển khai đó cho thuộc tính [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isaveoptions/progresscallback/). Aspose.Slides sẽ gọi phương thức [IProgressCallback.Reporting](https://reference.aspose.com/slides/vi/net/aspose.slides/iprogresscallback/reporting/) với các giá trị tiến độ trong quá trình xuất.

Ví dụ sau báo cáo tiến độ xuất PDF lên bảng console:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ [PowerPoint Splitter](https://products.aspose.app/slides/vi/splitter) miễn phí được xây dựng bằng API Aspose.Slides. Nó lưu các slide đã chọn từ một bản trình chiếu thành các tệp PPT hoặc PPTX riêng biệt.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ lưu tăng dần hoặc “fast save” không?**

Không. Mỗi thao tác lưu ghi một tệp đầu ra hoàn chỉnh thay vì chỉ cập nhật các phần đã thay đổi.

**Nhiều luồng có thể lưu cùng một đối tượng Presentation không?**

Không. Một đối tượng [Presentation] [không an toàn với đa luồng](/slides/vi/net/multithreading/). Chỉ truy cập và lưu mỗi đối tượng từ một luồng tại một thời điểm.

**Điều gì xảy ra với siêu liên kết và các tệp được liên kết bên ngoài khi tôi lưu một bản trình chiếu?**

[Hyperlinks](/slides/vi/net/manage-hyperlinks/) vẫn còn trong bản trình chiếu. Aspose.Slides không sao chép các tệp được liên kết bên ngoài, vì vậy bản trình chiếu đã lưu vẫn phải có khả năng truy cập tới vị trí của chúng.

**Tôi có thể lưu siêu dữ liệu tài liệu như tác giả, tiêu đề, công ty và ngày tạo không?**

Có. Đặt các [thuộc tính tài liệu](/slides/vi/net/presentation-properties/) phù hợp trước khi lưu, và Aspose.Slides sẽ ghi chúng vào tệp đầu ra.