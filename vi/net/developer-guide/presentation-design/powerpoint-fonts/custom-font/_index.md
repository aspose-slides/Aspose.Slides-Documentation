---
title: Tùy chỉnh phông chữ PowerPoint trong .NET
linktitle: Phông chữ tùy chỉnh
type: docs
weight: 20
url: /vi/net/custom-font/
keywords:
- phông chữ
- phông chữ tùy chỉnh
- phông chữ bên ngoài
- tải phông chữ
- quản lý phông chữ
- thư mục phông chữ
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho .NET để giữ cho bản trình bày của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong các bản trình bày mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản trình bày cụ thể thông qua các nguồn phông chữ ở mức tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bản trình bày được render hoặc xuất, ví dụ sang PDF, hình ảnh và các định dạng được hỗ trợ khác. Điều này giúp giữ cho đầu ra của bản trình bày nhất quán trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ được Aspose.Slides sử dụng và cách xóa bộ nhớ đệm phông chữ sau khi làm việc với phông chữ bên ngoài.

Việc đăng ký phông chữ tùy chỉnh để render là riêng biệt so với việc nhúng phông chữ vào tệp PPTX. Nếu một phông chữ phải được lưu trong bản trình bày, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

{{% alert color="info" %}} 

Aspose Slides cho phép bạn tải các phông chữ này bằng phương pháp [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/loadexternalfonts/):

* Phông chữ TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Phông chữ OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Tải phông chữ tùy chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong một bản trình bày mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng tới đầu ra khi xuất — như PDF, hình ảnh và các định dạng hỗ trợ khác — để các tài liệu tạo ra trông nhất quán trên các môi trường. Các phông chữ được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương pháp tĩnh [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/loadexternalfonts/) để tải phông chữ từ các thư mục đó.
3. Tải và render/​xuất bản trình bày.
4. Gọi [FontsLoader.ClearCache](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/clearcache/) để xóa bộ nhớ đệm phông chữ.

Ví dụ mã sau minh họa quy trình tải phông chữ:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Định nghĩa các thư mục chứa tệp phông chữ tùy chỉnh.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/​xuất bản trình bày (ví dụ: sang PDF, hình ảnh, hoặc các định dạng khác) bằng cách sử dụng các phông chữ đã tải.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn thành.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/loadexternalfonts/) thêm các thư mục bổ sung vào các đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.
Phông chữ được khởi tạo theo thứ tự này:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Lấy các thư mục phông chữ tùy chỉnh**
Aspose.Slides cung cấp phương pháp [GetFontFolders](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/getfontfolders/) để cho phép bạn tìm các thư mục phông chữ. Phương pháp này trả về các thư mục được thêm thông qua phương pháp `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Đoạn mã C# sau cho thấy cách sử dụng [GetFontFolders](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Dòng này trả về các thư mục được kiểm tra cho tệp phông chữ.
// Đây là các thư mục được thêm qua phương pháp LoadExternalFonts và các thư mục phông chữ hệ thống.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Xác định phông chữ tùy chỉnh được sử dụng với một bản trình bày**
Aspose.Slides cung cấp thuộc tính [DocumentLevelFontSources](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/documentlevelfontsources/) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng cùng với bản trình bày.

Đoạn mã C# sau cho thấy cách sử dụng thuộc tính [DocumentLevelFontSources](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Làm việc với bản trình bày
    // CustomFont1, CustomFont2 và các phông chữ từ thư mục assets\fonts & global\fonts và các thư mục con của chúng đều có sẵn cho bản trình bày
}
```

## **Quản lý phông chữ từ bên ngoài**

Aspose.Slides cung cấp phương pháp [LoadExternalFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) để cho phép bạn tải phông chữ bên ngoài từ dữ liệu nhị phân.

Đoạn mã C# sau minh họa quy trình tải phông chữ từ mảng byte:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // phông chữ bên ngoài được tải trong thời gian tồn tại của bản trình bày
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **Câu hỏi thường gặp**

**Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất sang tất cả các định dạng (PDF, PNG, SVG, HTML) không?**

Có. Các phông chữ được kết nối sẽ được trình render sử dụng cho mọi định dạng xuất.

**Phông chữ tùy chỉnh có tự động được nhúng vào tệp PPTX kết quả không?**

Không. Đăng ký một phông chữ để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang trong tệp bản trình bày, phải sử dụng các [tính năng nhúng](/slides/vi/net/embedded-font/).

**Tôi có thể kiểm soát hành vi dự phòng khi một phông chữ tùy chỉnh thiếu một số glyph không?**

Có. Cấu hình [font substitution](/slides/vi/net/font-substitution/), [replacement rules](/slides/vi/net/font-replacement/) và [fallback sets](/slides/vi/net/fallback-font/) để xác định chính xác phông chữ nào sẽ được dùng khi glyph yêu cầu không có.

**Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên toàn hệ thống không?**

Có. Chỉ định các thư mục phông chữ của bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ bất kỳ phụ thuộc nào vào các thư mục phông chữ hệ thống trong hình ảnh container.

> **Lưu ý cho Linux/Docker**: Khi gọi `FontsLoader.LoadExternalFonts`, đảm bảo rằng mỗi mục trong mảng `directories` chứa một đường dẫn không rỗng tới một thư mục tồn tại. Nếu biến môi trường dùng để xây dựng đường dẫn phông chữ không được định nghĩa hoặc rỗng, Aspose.Slides có thể cố gắng giải quyết giá trị rỗng như một đường dẫn đầy đủ, dẫn đến `System.ArgumentException`.

**Về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không có hạn chế không?**

Bạn chịu trách nhiệm tuân thủ giấy phép phông chữ. Các điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn xem xét EULA của phông chữ trước khi phân phối các đầu ra.