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
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho .NET để giữ cho bản trình chiếu của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong bản trình chiếu mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản trình chiếu cụ thể thông qua nguồn phông chữ cấp tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Phông chữ đã tải sẽ được sử dụng khi bản trình chiếu được render hoặc xuất, ví dụ sang PDF, hình ảnh và các định dạng hỗ trợ khác. Điều này giúp duy trì kết quả bản trình chiếu nhất quán trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ mà Aspose.Slides sử dụng và cách xóa bộ nhớ đệm phông chữ sau khi làm việc với phông chữ bên ngoài.

Đăng ký phông chữ tùy chỉnh để render riêng biệt với việc nhúng phông chữ vào tệp PPTX. Nếu một phông chữ phải được lưu trong bản trình chiếu, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

{{% alert color="primary" %}} 
Aspose Slides cho phép bạn tải các phông chữ này bằng phương thức [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/loadexternalfonts/) :

* Phông chữ TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Phông chữ OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Tải Phông Chữ Tùy Chỉnh**

Aspose.Slides cho phép bạn tải phông chữ được sử dụng trong một bản trình chiếu mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng tới kết quả xuất — như PDF, hình ảnh và các định dạng hỗ trợ khác — để các tài liệu tạo ra có giao diện nhất quán trên các môi trường. Phông chữ được tải từ các thư mục tùy chỉnh.

1. Chỉ định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/loadexternalfonts/) để tải phông chữ từ các thư mục đó.
3. Tải và render/xuất bản trình chiếu.
4. Gọi [FontsLoader.ClearCache](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/clearcache/) để xóa bộ nhớ đệm phông chữ.

Ví dụ mã sau minh họa quy trình tải phông chữ:

```cs
// Xác định các thư mục chứa tệp phông chữ tùy chỉnh.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Tải các phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/xuất bản trình chiếu (ví dụ, sang PDF, hình ảnh hoặc các định dạng khác) bằng các phông chữ đã tải.
presentation.Save("output.pdf", SaveFormat.Pdf");

// Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn tất.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/loadexternalfonts/) thêm các thư mục bổ sung vào các đường dẫn tìm kiếm phông chữ, nhưng nó không thay đổi thứ tự khởi tạo phông chữ.
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Lấy Các Thư Mục Phông Chữ Tùy Chỉnh**
Aspose.Slides cung cấp phương thức [GetFontFolders](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/getfontfolders/) để cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Mã C# sau cho bạn thấy cách sử dụng [GetFontFolders](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/getfontfolders/):

```c#
 // Dòng này xuất ra các thư mục được kiểm tra để tìm tệp phông chữ.
 // Đó là các thư mục được thêm thông qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Xác Định Phông Chữ Tùy Chỉnh Được Sử Dụng Với Một Bản Trình Chiếu**
Aspose.Slides cung cấp thuộc tính [DocumentLevelFontSources](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/documentlevelfontsources/) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng với bản trình chiếu.

Mã C# sau cho bạn thấy cách sử dụng thuộc tính [DocumentLevelFontSources](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Làm việc với bản trình chiếu
    // CustomFont1, CustomFont2, và các phông chữ từ thư mục assets\fonts & global\fonts và các thư mục con của chúng có sẵn cho bản trình chiếu
}
```

## **Quản Lý Phông Chữ Bên Ngoài**

Aspose.Slides cung cấp phương thức [LoadExternalFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) để cho phép bạn tải phông chữ bên ngoài từ dữ liệu nhị phân.

Mã C# sau minh họa quy trình tải phông chữ từ mảng byte: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // phông chữ bên ngoài được tải trong vòng đời của bản trình chiếu
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất sang tất cả các định dạng (PDF, PNG, SVG, HTML)?**

Có. Các phông chữ đã kết nối được trình render sử dụng cho tất cả các định dạng xuất.

**Phông chữ tùy chỉnh có được tự động nhúng vào PPTX kết quả không?**

Không. Đăng ký một phông chữ để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang trong tệp bản trình chiếu, bạn phải sử dụng các [tính năng nhúng](/slides/vi/net/embedded-font/) một cách rõ ràng.

**Tôi có thể kiểm soát hành vi dự phòng khi phông chữ tùy chỉnh thiếu một số glyph không?**

Có. Cấu hình [font substitution](/slides/vi/net/font-substitution/), [replacement rules](/slides/vi/net/font-replacement/) và [fallback sets](/slides/vi/net/fallback-font/) để xác định chính xác phông chữ nào sẽ được sử dụng khi glyph yêu cầu không có.

**Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên toàn hệ thống không?**

Có. Chỉ định các thư mục phông chữ của bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ mọi phụ thuộc vào thư mục phông chữ hệ thống trong ảnh container.

**Còn về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không có hạn chế không?**

Bạn chịu trách nhiệm tuân thủ giấy phép phông chữ. Các điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn xem xét EULA của phông chữ trước khi phân phối các kết quả.