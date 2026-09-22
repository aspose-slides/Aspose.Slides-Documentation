---
title: Xác định Định dạng Bản trình bày Gốc trong .NET
linktitle: Định dạng Nguồn
type: docs
weight: 35
url: /vi/net/detect-presentation-source-format/
keywords:
- định dạng nguồn
- phát hiện định dạng bản trình bày
- PowerPoint
- OpenDocument
- bản trình bày
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Đọc định dạng gốc của một bản trình bày đã được tải trong C# với Aspose.Slides cho .NET, so sánh các API phát hiện, và xử lý tệp, luồng và các định dạng cổ."
---
## **Tổng quan**

Sau khi tải một bản trình bày, đọc thuộc tính chỉ đọc [Presentation.SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sourceformat/) để xác định định dạng gốc của nó. Thuộc tính này cũng có sẵn thông qua [IPresentation.SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/sourceformat/). Sử dụng nó khi quá trình xử lý tiếp theo phụ thuộc vào định dạng mà thể hiện hiện tại được tải.

Định dạng nguồn khác với [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/) được chọn cho tệp đầu ra. Lưu dưới định dạng khác không làm thay đổi định dạng nguồn của thể hiện hiện có.

## **Đọc Định dạng Nguồn của Tệp**

Ví dụ này yêu cầu một tệp `sample.pptx` hiện có. Nó tải tệp và chọn chính sách xử lý ứng dụng bằng cách sử dụng [Presentation.SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sourceformat/), thay vì tên tệp. Thay đổi đường dẫn đầu vào để thử các định dạng khác. Ví dụ in ra chính sách đã chọn; thay thế các thông báo bằng logic ứng dụng của bạn.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Nhận dạng Các Giá trị Hỗ trợ**

Kiểu liệt kê [SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/sourceformat/) phân biệt các định dạng bản trình bày sau. Các phần mở rộng dưới đây là phần mở rộng thông thường, không phải là việc tái tạo tên tệp gốc.

| Giá trị SourceFormat | Phần mở rộng | Định dạng |
| --- | --- | --- |
| `Ppt` | `.ppt` | Bản trình bày PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Bản trình bày Office Open XML |
| `Pptm` | `.pptm` | Bản trình bày Office Open XML có hỗ trợ macro |
| `Pps` | `.pps` | Trình chiếu PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Trình chiếu Office Open XML |
| `Ppsm` | `.ppsm` | Trình chiếu Office Open XML có hỗ trợ macro |
| `Pot` | `.pot` | Mẫu PowerPoint 97–2003 |
| `Potx` | `.potx` | Mẫu Office Open XML |
| `Potm` | `.potm` | Mẫu Office Open XML có hỗ trợ macro |
| `Odp` | `.odp` | Bản trình bày OpenDocument |
| `Otp` | `.otp` | Mẫu trình bày OpenDocument |
| `Fodp` | `.fodp` | Bản trình bày Flat XML ODF |
| `Xml` | `.xml` | Bản trình bày PowerPoint XML |

## **Đọc Định dạng Nguồn của Luồng**

Ví dụ này yêu cầu một tệp `sample.pps` hiện có. Đọc các byte của nó vào một luồng bộ nhớ mô phỏng đầu vào nhận được mà không có tên tệp, chẳng hạn như giá trị trong cơ sở dữ liệu hoặc mảng byte được tải lên. Hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) chỉ nhận luồng.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS và POT sử dụng cùng một định dạng nhị phân nền. Khi tải bằng đường dẫn tệp, phần mở rộng có thể giúp phân biệt trình chiếu hoặc mẫu. Khi không có tên tệp, nội dung PPS và POT cũ có thể được báo cáo là `SourceFormat.Ppt`; ví dụ PPS ở trên báo cáo `Ppt`.

Nếu ứng dụng của bạn cần giữ lại sự phân biệt này, hãy lưu tên tệp gốc hoặc siêu dữ liệu phụ loại riêng biệt. Phần mở rộng là gợi ý hữu ích cho các phụ loại cũ này, nhưng không nên là cơ sở duy nhất để xác định nội dung bản trình bày bất kỳ.

## **So sánh Phát hiện Trước và Sau Khi Tải**

Sử dụng [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/getpresentationinfo/) và [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentationinfo/loadformat/) khi bạn cần kiểm tra tệp trước khi tải toàn bộ mô hình đối tượng bản trình bày. Sử dụng [Presentation.SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sourceformat/) khi thể hiện đã tồn tại.

Ví dụ này yêu cầu `sample.pptx` và in ra `Pptx` cho cả hai kiểm tra. Trong môi trường thực tế, chọn API phù hợp với giai đoạn xử lý của bạn; một bản trình bày đã được tải không cần kiểm tra lại chỉ để lấy định dạng nguồn.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Kết quả có các kiểu liệt kê khác nhau: [LoadFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/loadformat/) và [SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/sourceformat/). Không so sánh chúng bằng cách ép kiểu giá trị số hoặc giả định rằng mọi định dạng đều có kết quả phát hiện giống nhau. Trong kiểm tra lưu và mở lại được mô tả dưới đây, PowerPoint XML được báo cáo là `LoadFormat.Unknown` trước khi tải và `SourceFormat.Xml` sau khi tải.

## **Giữ Định dạng Nguồn và Định dạng Đầu ra Riêng biệt**

Ví dụ này yêu cầu `sample.pptx` và ghi `converted.odp`. Nó in ra `Pptx` cả trước và sau khi lưu thể hiện gốc. Chỉ thể hiện mới được tải từ đầu ra ODP mới báo cáo `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

Một bản trình bày được tạo mới từ đầu bằng `new Presentation()` báo cáo `SourceFormat.Pptx`. Nó không có tệp đầu vào: đây là giá trị mặc định cho một thể hiện mới tạo, không phải bằng chứng rằng một tệp PPTX đã được tải. Theo dõi riêng việc ứng dụng của bạn tạo hay tải thể hiện nếu sự phân biệt này quan trọng.

## **Ánh xạ Định dạng Nguồn sang Phần mở rộng**

Ví dụ sau yêu cầu `sample.pptx`. Nó ánh xạ mỗi giá trị [SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/sourceformat/) hiện được hỗ trợ sang một phần mở rộng thông thường, mà không phân tích tên tệp đầu vào. Cơ chế dự phòng tránh việc gán phần mở rộng một cách im lặng cho giá trị không nhận dạng được.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Ánh xạ này không chuyển đổi tệp hoặc khôi phục phụ loại PPS/POT cũ bị mất trong quá trình tải luồng. Đối với việc lưu thực tế, hãy chọn một [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/) một cách rõ ràng, hoặc sử dụng chuyển đổi được trình bày trong [Save Presentations in Their Original Format](/slides/vi/net/save-presentation/#save-presentations-in-their-original-format).

## **Xác minh Định dạng bằng cách Lưu và Mở lại**

Ví dụ tự chứa này tạo một bản trình bày và ghi ba tệp trong thư mục làm việc, ghi đè các tệp cùng tên. Nó mở lại mỗi đầu ra cả bằng đường dẫn và qua luồng bộ nhớ. Đối với PPTX và ODP, cả hai cách đều báo cáo định dạng đã lưu. Đối với PPS, tải bằng đường dẫn báo cáo `Pps`, trong khi tải cùng các byte mà không có tên tệp báo cáo `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

Kiểm tra tương tự với tất cả các định dạng đã liệt kê ở trên đã cho ra các kết quả sau cho các bản trình bày được tạo ra với phần mở rộng phù hợp:

| Định dạng đã lưu | SourceFormat từ đường dẫn tệp | SourceFormat từ luồng không tên |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Giống như đường dẫn tệp |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Giống như đường dẫn tệp |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Giống như đường dẫn tệp |
| ODP, OTP | `Odp`, `Otp` respectively | Giống như đường dẫn tệp |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Trong các kiểm tra này, việc chuẩn hoá định dạng nguồn duy nhất là PPS/POT thành `Ppt` cho các luồng không tên. Bảng mô tả việc xác định định dạng, không phải việc bảo tồn mọi tính năng của bản trình bày trong quá trình chuyển đổi.

## **Câu hỏi thường gặp**

**Lưu dưới dạng ODP có thay đổi định dạng nguồn của bản trình bày được tải từ PPTX không?**

Không. Thể hiện hiện có vẫn báo cáo `Pptx`. Một thể hiện được tải từ tệp ODP đã lưu sẽ báo cáo `Odp`.

**Luồng có thể luôn phân biệt được bản trình bày, trình chiếu và mẫu cổ không?**

Không. PPT, PPS và POT chia sẻ cùng định dạng nhị phân. Hãy giữ tên tệp hoặc siêu dữ liệu phụ loại riêng biệt khi cần phân biệt.

**Nên sử dụng API nào nếu bản trình bày đã được tải?**

Đọc [Presentation.SourceFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sourceformat/). Sử dụng [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationfactory/getpresentationinfo/) để kiểm tra trước khi tải.