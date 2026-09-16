---
title: Xuất bản trình chiếu sang XAML trong .NET
linktitle: Trình chiếu sang XAML
type: docs
weight: 30
url: /vi/net/export-to-xaml/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bản trình chiếu
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- PowerPoint sang XAML
- OpenDocument sang XAML
- bản trình chiếu sang XAML
- PPT sang XAML
- PPTX sang XAML
- ODP sang XAML
- lưu PPT dưới dạng XAML
- lưu PPTX dưới dạng XAML
- lưu ODP dưới dạng XAML
- xuất PPT sang XAML
- xuất PPTX sang XAML
- xuất ODP sang XAML
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML trong .NET bằng Aspose.Slides—giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm một phần giới thiệu ngắn về XAML, chỉ ra cách lưu một bản trình chiếu dưới dạng XAML với các cài đặt mặc định, và trình diễn cách tùy chỉnh việc xuất thông qua [XamlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/), bao gồm việc xuất các slide ẩn. Bài viết cũng trả lời một số câu hỏi thường gặp liên quan đến phông chữ dự phòng, khả năng tương thích với các ngăn xếp XAML, và hành vi xuất slide ẩn.

## **Về XAML**

XAML là một ngôn ngữ đánh dấu dựa trên XML được sử dụng để mô tả giao diện người dùng trong các khung như WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin.Forms.

Bạn có thể làm việc với các tệp XAML trong trình thiết kế trực quan hoặc viết và chỉnh sửa markup trực tiếp.

## **Xuất Bản Trình Chiếu sang XAML với Các Tùy Chọn Mặc Định**

Ví dụ C# sau đây cho thấy cách xuất một bản trình chiếu sang XAML với các cài đặt mặc định:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Mặc định, các slide đã xuất được lưu trong một thư mục con `pres` của thư mục làm việc hiện tại của tiến trình, được trả về bởi [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). Thư mục này được tạo tự động, và bất kỳ hình ảnh nào cần thiết cũng được lưu ở đó.

Tên thư mục đầu ra được lấy từ tên tệp nguồn mà không có phần mở rộng. Đối với `pres.pptx`, các tệp đầu ra sẽ có tên `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, v.v. Ngay cả khi bạn cung cấp một đường dẫn tuyệt đối cho bản trình chiếu đầu vào, thư mục đầu ra vẫn được tạo tương đối với thư mục làm việc hiện tại, thay vì bên cạnh tệp đầu vào.

## **Xuất Bản Trình Chiếu sang XAML với Các Tùy Chọn Tùy Chỉnh**

Sử dụng giao diện [IXamlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/ixamloptions/) để điều khiển cách Aspose.Slides xuất một bản trình chiếu sang XAML.

Để lưu đầu ra vào vị trí tùy chỉnh, triển khai [IXamlOutputSaver](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/ixamloutputsaver/) và gán một thể hiện của triển khai của bạn cho thuộc tính [OutputSaver](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/outputsaver/) của [XamlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/).

Để bao gồm các slide ẩn trong đầu ra XAML, đặt thuộc tính [ExportHiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) thành `true`, như được minh họa trong ví dụ C# sau:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Thu Thập Tất Cả Các Tài Nguyên XAML Được Tạo Ra**

Một quá trình xuất XAML có thể tạo ra một tài liệu XAML cho mỗi slide được xuất cộng với các hình ảnh riêng biệt và các tài nguyên hỗ trợ. Gán một [IXamlOutputSaver](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/ixamloutputsaver/) tùy chỉnh vào [XamlOptions.OutputSaver](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/outputsaver/) để nhận các tài nguyên này thay vì sử dụng bộ lưu mặc định trên hệ thống tập tin. Bắt đầu quá trình xuất bằng phương thức [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) đặc thù cho XAML, phiên bản chấp nhận các tùy chọn XAML.

### **Hiểu Vòng Đời Callback**

- `path` xác định tài nguyên và có thể bao gồm các thư mục tương đối. Giữ lại thông tin này vì XAML có thể tham chiếu tới các tài nguyên bằng các đường dẫn tương đối.
- `data` chứa các byte của tài nguyên. Hình ảnh và các tài nguyên nhị phân khác không được giải mã thành văn bản.
- Bộ lưu chịu trách nhiệm giữ lại hoặc lưu trữ dữ liệu trước khi trả về. Các ví dụ sao chép mỗi mảng byte vào bộ nhớ thuộc về ứng dụng.
- Xem việc xuất là thành công chỉ khi thao tác lưu bản trình chiếu trả về và mọi callback đã hoàn thành thành công. Không bỏ qua lỗi lưu trữ hoặc bắt đầu các ghi nền không được giám sát. Nếu việc lưu diễn ra sau đó, chỉ báo cáo thành công tổng thể sau khi bước đó cũng thành công.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) cũng áp dụng cho bộ lưu tùy chỉnh. Giá trị mặc định của nó là `false`, loại trừ các tài liệu XAML của slide ẩn. Đặt nó thành `true` sẽ bao gồm chúng và bất kỳ tài nguyên nào cần thiết cho việc xuất. Số lượng tài nguyên phụ thuộc vào bản trình chiếu; không giả định một callback cho mỗi slide hoặc một thứ tự callback cố định.

### **Xuất ra Bộ Nhớ và Kiểm Tra Các Tài Nguyên**

Ví dụ hoàn chỉnh này tải `pres.pptx`, thu thập mọi tài nguyên trong một [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2), và in ra tên, loại và số byte của chúng. Nó giữ nguyên các tên được cung cấp. Các tên trùng lặp sẽ làm việc thu thập thất bại thay vì ghi đè tài nguyên một cách im lặng.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Giải mã chỉ XAML, và chỉ khi cần kiểm tra văn bản.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Gọi `InMemoryXamlExample.Run` từ ứng dụng của bạn. Kiểm tra mở rộng hữu ích cho việc kiểm tra; giữ lại tất cả các tài nguyên, bao gồm các loại tài nguyên không quen thuộc. Để nguyên các byte khi lưu hoặc truyền chúng. Chỉ sử dụng [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) cho XAML cần xử lý dưới dạng văn bản.

### **Đóng Gói Các Tài Nguyên Đã Thu Thập vào Tập Tin ZIP**

Ví dụ độc lập này thu thập kết quả xuất, kiểm tra tính hợp lệ của các tên, và ghi các byte gốc vào một kho lưu ZIP. Một tên kho lưu duy nhất tách các công việc xuất đồng thời. Các mục ZIP sử dụng dấu gạch chéo xuôi và giữ các thư mục tương đối. Các tên không an toàn hoặc các tên trùng nhau sau khi chuẩn hoá sẽ từ chối toàn bộ gói trước khi nó được ghi.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // Thư mục ZIP đã được hoàn thiện bằng việc giải phóng trước khi báo cáo thành công.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Gọi `ZipXamlExample.Run` từ ứng dụng của bạn. Ví dụ này sử dụng [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) để ghi một kho lưu cục bộ; bộ xuất không ghi các tệp XAML hoặc hình ảnh rải rác. Đối với lưu trữ từ xa, thay thế giai đoạn ghi kho lưu bằng việc tải lên các mảng byte đã thu thập. Sử dụng một định danh công việc xuất cộng với tên tài nguyên tương đối đầy đủ làm khóa blob, hoặc lưu định danh công việc, tên tương đối và dữ liệu nhị phân trong một hàng cơ sở dữ liệu. Phát hành công việc chỉ sau khi tất cả các tải lên hoàn thành hoặc giao dịch cơ sở dữ liệu được cam kết. Dọn dẹp đầu ra một phần nếu việc lưu trữ thất bại.

Đối với các bản trình chiếu lớn, một bộ lưu tùy chỉnh có thể lưu mỗi tài nguyên trực tiếp vào bộ nhớ lưu trữ của ứng dụng để tránh việc giữ một bản sao bổ sung của toàn bộ kết quả xuất trong bộ nhớ ứng dụng. Bộ xuất vẫn thu thập tất cả các tài nguyên được tạo ra trong bộ nhớ trước khi gọi bộ lưu. Giữ mỗi callback đồng bộ từ góc độ của bộ xuất: chỉ trả về sau khi đích đã chấp nhận các byte, và cho phép lỗi truyền tới người gọi.

### **Giữ Tên Tài Nguyên và Xác Minh Tham Chiếu**

- Chuẩn hoá dấu phân cách đường dẫn khi đích yêu cầu, nhưng vẫn giữ các thư mục tương đối. Không chỉ sử dụng [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) trừ khi mọi tên được tạo ra đều được biết là duy nhất và các tham chiếu tài nguyên vẫn hợp lệ.
- Áp dụng kiểm tra tên riêng cho đích. Khi ghi các tệp rải rác, từ chối các đường dẫn gốc và các đoạn di chuyển, xác định đích bằng [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath), và xác minh nó vẫn nằm dưới thư mục xuất dự định, bao gồm dấu phân cách thư mục trong kiểm tra bao hàm. Sử dụng một thư mục do ứng dụng kiểm soát mà không có liên kết tượng trưng có thể chuyển hướng ghi.
- Sử dụng một bộ lưu và không gian tên lưu trữ riêng cho mỗi công việc xuất. Phát hiện va chạm sau khi chuẩn hoá dấu phân cách và tuân theo quy tắc phân biệt hoa thường của đích.
- Trước khi phát hành, phân tích mỗi tài liệu XAML dưới dạng XML và kiểm tra các tham chiếu tài nguyên dựa trên tệp, như thuộc tính `Source` hoặc `ImageSource` của hình ảnh. Giải quyết mỗi URI tương đối dựa trên thư mục chứa tài nguyên XAML, chuẩn hoá tên lưu trữ thu được, và xác nhận rằng khóa từ điển, mục ZIP, hoặc đối tượng đã lưu tương ứng tồn tại. Xử lý các URI bên ngoài và các biểu thức markup XAML riêng biệt so với các tên tệp tương đối.

Ví dụ, nếu `pres/Slide_1.xaml` tham chiếu đến `images/image1.png`, tài nguyên đã lưu phải có sẵn dưới dạng `pres/images/image1.png`. Chỉ giữ `image1.png` sẽ phá vỡ mối quan hệ đó. Đối với lưu trữ đối tượng, giữ cùng cấu trúc dưới tiền tố công việc và làm cho các URL tài nguyên đó có thể truy cập được bởi người tiêu thụ XAML. Mở lại ZIP đã hoàn thành để xác minh tên mục và byte tài nguyên, và tải các slide tiêu biểu trong môi trường XAML đích để xác nhận rằng hình ảnh được giải quyết đúng.

## **Câu hỏi thường gặp**

**Làm thế nào để tôi đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Đặt [DefaultRegularFont](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/defaultregularfont/) trong [XamlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/) — nó được dùng làm phông chữ dự phòng trong quá trình xuất khi phông chữ gốc thiếu. Điều này không đảm bảo rằng XAML được tạo ra sẽ tham chiếu tới phông chữ dự phòng hoặc rằng phông chữ đó có sẵn trên máy đích. Đảm bảo rằng các phông chữ mà XAML tham chiếu đều có trong môi trường nơi nó được hiển thị.

**XAML được xuất ra chỉ dành cho WPF, hay có thể dùng trong các ngăn xếp XAML khác không?**

Aspose.Slides xuất XAML WPF thông qua API công cộng của nó. Khả năng tương thích với các ngăn xếp XAML khác, như UWP và Xamarin.Forms, không được bảo đảm. Hãy kiểm tra markup đã tạo trong môi trường đích của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao để ngăn chúng được xuất mặc định?**

Mặc định, các slide ẩn không được bao gồm. Bạn có thể kiểm soát hành vi này qua [ExportHiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) trong [XamlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export.xaml/xamloptions/) — giữ nó tắt nếu bạn không cần xuất chúng.