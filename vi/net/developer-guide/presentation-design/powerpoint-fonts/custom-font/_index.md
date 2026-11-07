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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho .NET để giữ cho bản trình chiếu của bạn sắc nét và nhất quán trên bất kỳ thiết bị nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong các bản trình chiếu mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản trình chiếu cụ thể thông qua các nguồn phông chữ cấp tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bản trình chiếu được render hoặc xuất ra, ví dụ như sang PDF, hình ảnh và các định dạng hỗ trợ khác. Điều này giúp duy trì tính nhất quán của kết quả trình chiếu trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ mà Aspose.Slides sử dụng và cách xóa bộ nhớ đệm phông chữ sau khi làm việc với phông chữ bên ngoài.

Việc đăng ký phông chữ tùy chỉnh để render tách biệt khỏi việc nhúng phông chữ vào tệp PPTX. Nếu một phông chữ cần được lưu trữ bên trong bản trình chiếu, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

Một giao diện chủ đề bản trình chiếu có thể tham chiếu các họ phông chữ khác nhau cho các hệ thống viết riêng lẻ. Các ánh xạ này lưu tên phông chữ nhưng không cài đặt hay tải các tệp phông chữ. Xem [Phông chữ giao diện theo kịch bản](/slides/vi/net/script-specific-font-mappings/) để quản lý các ánh xạ, và sử dụng các tùy chọn tải dưới đây để làm cho các phông chữ được tham chiếu sẵn sàng cho việc render nhất quán.

{{% alert color="info" title="Note" %}}

Aspose Slides cho phép bạn tải những phông chữ này bằng phương thức [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) và TrueType Collection (.ttc) fonts. Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonts. Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Tải Phông Tùy Chỉnh**

Aspose.Slides cho phép bạn tải phông chữ được sử dụng trong một bản trình chiếu mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra xuất – chẳng hạn như PDF, hình ảnh và các định dạng hỗ trợ khác – để các tài liệu tạo ra trông nhất quán trên mọi môi trường. Phông chữ được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) để tải phông chữ từ các thư mục đó.
3. Tải và render/xuất bản trình chiếu.
4. Gọi [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) để xóa bộ nhớ đệm phông chữ.

Ví dụ mã sau minh họa quy trình tải phông chữ:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Xác định các thư mục chứa các tệp phông chữ tùy chỉnh.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/xuất bản trình chiếu (ví dụ, sang PDF, hình ảnh, hoặc các định dạng khác) bằng cách sử dụng các phông chữ đã tải.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn tất.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) thêm các thư mục bổ sung vào các đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.
Phông chữ được khởi tạo theo thứ tự này:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Lấy Các Thư Mục Phông Tùy Chỉnh**
Aspose.Slides cung cấp phương thức [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) để cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Mã C# dưới đây cho bạn thấy cách sử dụng [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Dòng này xuất ra các thư mục được kiểm tra cho các tệp phông chữ.
// Đó là các thư mục được thêm thông qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Chỉ Định Phông Tùy Chỉnh Được Sử Dụng Với Một Bản Trình Chiếu**
Aspose.Slides cung cấp thuộc tính [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng với bản trình chiếu.

Mã C# dưới đây cho bạn thấy cách sử dụng thuộc tính [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Làm việc với bản trình chiếu
    // CustomFont1, CustomFont2, và các phông chữ từ thư mục assets\fonts & global\fonts cùng các thư mục con của chúng đều khả dụng cho bản trình chiếu
}
```

## **Quản Lý Phông Bên Ngoài**

Aspose.Slides cung cấp phương thức [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) để cho phép bạn tải phông chữ bên ngoài từ dữ liệu nhị phân.

Mã C# dưới đây minh họa quá trình tải phông chữ từ mảng byte:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // phông chữ bên ngoài được tải trong thời gian tồn tại của bản trình chiếu
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

Để cho phép một phông chữ đã đăng ký phù hợp được ưu tiên trong quá trình xuất mà không loại bỏ phông chữ đã nhúng, xem [Ưu tiên Phông chữ Đã Đăng ký so với Phông chữ Được Nhúng](/slides/vi/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 hoặc sau).

## **Câu hỏi thường gặp**

**Các phông chữ tùy chỉnh có ảnh hưởng đến việc xuất sang tất cả các định dạng (PDF, PNG, SVG, HTML) không?**

Có. Các phông chữ được kết nối được sử dụng bởi bộ render trên tất cả các định dạng xuất.

**Các phông chữ tùy chỉnh có tự động được nhúng vào PPTX kết quả không?**

Không. Đăng ký một phông chữ để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang trong tệp trình chiếu, phải sử dụng các [tính năng nhúng](/slides/vi/net/embedded-font/).

**Tôi có thể kiểm soát hành vi dự phòng khi một phông chữ tùy chỉnh thiếu một số glyph không?**

Có. Cấu hình [thay thế phông chữ](/slides/vi/net/font-substitution/), [quy tắc thay thế](/slides/vi/net/font-replacement/) và [bộ phông dự phòng](/slides/vi/net/fallback-font/) để xác định chính xác phông chữ nào sẽ được dùng khi glyph yêu cầu không có.

**Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên toàn hệ thống không?**

Có. Chỉ định các thư mục phông chữ của riêng bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ bất kỳ phụ thuộc nào vào các thư mục phông chữ hệ thống trong ảnh container.

> **Lưu ý cho Linux/Docker**: Khi gọi `FontsLoader.LoadExternalFonts`, hãy đảm bảo rằng mỗi mục trong mảng `directories` chứa một đường dẫn không rỗng tới một thư mục tồn tại. Nếu một biến môi trường được sử dụng để tạo đường dẫn phông chữ không được định nghĩa hoặc rỗng, Aspose.Slides có thể cố gắng giải quyết giá trị rỗng như một đường dẫn đầy đủ, dẫn đến `System.ArgumentException`.

**Về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không bị hạn chế không?**

Bạn chịu trách nhiệm tuân thủ giấy phép phông chữ. Điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn xem lại EULA của phông chữ trước khi phân phối các đầu ra.