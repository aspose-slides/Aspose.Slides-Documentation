---
title: Tùy chỉnh phông chữ PowerPoint trong Java
linktitle: Phông chữ tùy chỉnh
type: docs
weight: 20
url: /vi/java/custom-font/
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
- Java
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho Java để giữ cho bản trình bày của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong các bản trình bày mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản trình bày cụ thể thông qua các nguồn phông chữ ở mức tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bản trình bày được render hoặc xuất ra, ví dụ sang PDF, hình ảnh và các định dạng hỗ trợ khác. Điều này giúp duy trì tính nhất quán của đầu ra bản trình bày trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ do Aspose.Slides sử dụng và cách xóa bộ nhớ đệm phông chữ sau khi làm việc với phông chữ bên ngoài.

Việc đăng ký phông chữ tùy chỉnh để render riêng biệt với việc nhúng phông chữ vào tệp PPTX. Nếu một phông chữ phải được lưu trong bản trình bày, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

{{% alert color="primary" %}} 
Aspose Slides cho phép bạn tải các phông chữ này bằng phương thức [loadExternalFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Phông chữ TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Phông chữ OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Tải phông chữ tùy chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong một bản trình bày mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra xuất ra—như PDF, hình ảnh và các định dạng hỗ trợ khác—để các tài liệu kết quả trông nhất quán trên các môi trường. Phông chữ được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa các tệp phông chữ.  
2. Gọi phương thức tĩnh [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) để tải phông chữ từ các thư mục đó.  
3. Tải và render/​xuất bản trình bày.  
4. Gọi [FontsLoader.clearCache](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsLoader#clearCache--) để xóa bộ nhớ đệm phông chữ.

Ví dụ mã sau minh họa quá trình tải phông chữ:

```java
// Xác định các thư mục chứa các tệp phông chữ tùy chỉnh.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Render/​xuất bản trình bày (ví dụ, sang PDF, hình ảnh, hoặc các định dạng khác) bằng các phông chữ đã tải.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn thành.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Lưu ý" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) thêm các thư mục vào đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.  
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.  
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Lấy các thư mục phông chữ tùy chỉnh**

Aspose.Slides cung cấp phương thức [getFontFolders](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#getFontFolders--) để cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Đoạn mã Java dưới đây cho thấy cách sử dụng [getFontFolders](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Dòng này xuất ra các thư mục nơi các tệp phông chữ được tìm kiếm.
// Đó là các thư mục được thêm thông qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Chỉ định các phông chữ tùy chỉnh được sử dụng với một bản trình bày**

Aspose.Slides cung cấp thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng với bản trình bày.

Đoạn mã Java dưới đây cho thấy cách sử dụng thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Làm việc với bản trình bày
    // CustomFont1, CustomFont2 và các phông chữ từ các thư mục assets\fonts & global\fonts và các thư mục con của chúng có sẵn cho bản trình bày
} finally {
    if (pres != null) pres.dispose();
}
```

## **Quản lý phông chữ bên ngoài**

Aspose.Slides cung cấp phương thức [loadExternalFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) để cho phép bạn tải phông chữ bên ngoài từ dữ liệu nhị phân.

Đoạn mã Java dưới đây minh họa quá trình tải phông chữ từ mảng byte:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // phông chữ bên ngoài được tải trong suốt thời gian sống của bản trình bày
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Câu hỏi thường gặp**

**Các phông chữ tùy chỉnh có ảnh hưởng đến việc xuất ra tất cả các định dạng (PDF, PNG, SVG, HTML) không?**

Có. Các phông chữ đã kết nối được renderer sử dụng cho mọi định dạng xuất.

**Các phông chữ tùy chỉnh có tự động được nhúng vào tệp PPTX kết quả không?**

Không. Đăng ký phông chữ để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang trong tệp bản trình bày, phải sử dụng các [tính năng nhúng](/slides/vi/java/embedded-font/).

**Tôi có thể kiểm soát hành vi thay thế khi một phông chữ tùy chỉnh thiếu một số glyph không?**

Có. Cấu hình [font substitution](/slides/vi/java/font-substitution/), [replacement rules](/slides/vi/java/font-replacement/) và [fallback sets](/slides/vi/java/fallback-font/) để xác định chính xác phông chữ nào sẽ được dùng khi glyph yêu cầu không có.

**Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên toàn hệ thống không?**

Có. Chỉ định các thư mục phông chữ riêng hoặc tải phông chữ từ mảng byte. Điều này loại bỏ bất kỳ phụ thuộc nào vào thư mục phông chữ hệ thống trong hình ảnh container.

**Về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không bị hạn chế không?**

Bạn chịu trách nhiệm tuân thủ giấy phép của phông chữ. Các điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn xem xét EULA của phông chữ trước khi phân phối kết quả.