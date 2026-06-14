---
title: Tùy chỉnh phông chữ PowerPoint trên Android
linktitle: Phông chữ Tùy chỉnh
type: docs
weight: 20
url: /vi/androidjava/custom-font/
keywords:
- phông chữ
- phông chữ tùy chỉnh
- phông chữ bên ngoài
- tải phông chữ
- quản lý phông chữ
- thư mục phông chữ
- PowerPoint
- OpenDocument
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho Android qua Java để giữ cho bản trình bày của bạn sắc nét và nhất quán trên bất kỳ thiết bị nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong các bản thuyết trình mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản thuyết trình cụ thể thông qua các nguồn phông chữ ở cấp độ tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bản thuyết trình được render hoặc xuất, ví dụ sang PDF, hình ảnh và các định dạng được hỗ trợ khác. Điều này giúp duy trì độ nhất quán của kết quả bản thuyết trình trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ mà Aspose.Slides sử dụng và cách xóa bộ nhớ đệm phông chữ sau khi làm việc với phông chữ bên ngoài.

Đăng ký phông chữ tùy chỉnh để render là một quá trình riêng biệt so với việc nhúng phông chữ vào tệp PPTX. Nếu một phông chữ cần được lưu trữ trong bản thuyết trình, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

{{% alert color="primary" %}} 
Aspose Slides cho phép bạn tải các phông chữ này bằng phương pháp [loadExternalFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) và TrueType Collection (.ttc) phông chữ. Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) phông chữ. Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Tải Phông Chữ Tùy Chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong một bản thuyết trình mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra khi xuất—như PDF, hình ảnh và các định dạng hỗ trợ khác—đảm bảo tài liệu kết quả trông nhất quán trên mọi môi trường. Các phông chữ được tải từ các thư mục tùy chỉnh.

1. Chỉ định một hoặc nhiều thư mục chứa các tệp phông chữ.  
2. Gọi phương thức tĩnh [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) để tải phông chữ từ các thư mục đó.  
3. Tải và render/ xuất bản thuyết trình.  
4. Gọi [FontsLoader.clearCache](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontsLoader#clearCache--) để xóa bộ nhớ đệm phông chữ.

Ví dụ mã sau đây minh họa quá trình tải phông chữ:

```java
// Xác định các thư mục chứa các tệp phông chữ tùy chỉnh.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Render/xuất bản thuyết trình (ví dụ: sang PDF, hình ảnh hoặc các định dạng khác) bằng các phông chữ đã tải.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn thành.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Ghi chú" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) thêm các thư mục bổ sung vào các đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.  
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.  
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Lấy Thư Mục Phông Chữ Tùy Chỉnh**

Aspose.Slides cung cấp phương thức [getFontFolders](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) để cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Đoạn mã Java này cho bạn thấy cách sử dụng [getFontFolders](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Dòng này xuất ra các thư mục nơi các tệp phông chữ được tìm kiếm.
// Đó là các thư mục được thêm thông qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Chỉ Định Phông Chữ Tùy Chỉnh Được Sử Dụng Với Bản Thuyết Trình**

Aspose.Slides cung cấp thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng với bản thuyết trình.

Đoạn mã Java này cho bạn thấy cách sử dụng thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Làm việc với bản thuyết trình
    // CustomFont1, CustomFont2, và các phông chữ từ thư mục assets\fonts & global\fonts và các thư mục con của chúng có sẵn cho bản thuyết trình
} finally {
    if (pres != null) pres.dispose();
}
```

## **Quản Lý Phông Chữ Bên Ngoài**

Aspose.Slides cung cấp phương thức [loadExternalFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) để cho phép bạn tải phông chữ bên ngoài từ dữ liệu nhị phân.

Đoạn mã Java này minh họa quá trình tải phông chữ từ mảng byte:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // phông chữ bên ngoài được tải trong thời gian sống của bản thuyết trình
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Câu Hỏi Thường Gặp**

**Phông chữ tùy chỉnh có ảnh hưởng đến xuất sang tất cả các định dạng (PDF, PNG, SVG, HTML) không?**

Có. Phông chữ được kết nối được sử dụng bởi bộ render trên tất cả các định dạng xuất.

**Phông chữ tùy chỉnh có tự động được nhúng vào tệp PPTX kết quả không?**

Không. Đăng ký phông chữ để render không giống như việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang trong tệp bản thuyết trình, bạn phải sử dụng các [tính năng nhúng](/slides/vi/androidjava/embedded-font/).

**Tôi có thể kiểm soát hành vi dự phòng khi một phông chữ tùy chỉnh thiếu một số glyph không?**

Có. Cấu hình [font substitution](/slides/vi/androidjava/font-substitution/), [replacement rules](/slides/vi/androidjava/font-replacement/), và [fallback sets](/slides/vi/androidjava/fallback-font/) để xác định chính xác phông chữ nào sẽ được sử dụng khi glyph yêu cầu không có.

**Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên toàn hệ thống không?**

Có. Chỉ định các thư mục phông chữ của riêng bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ bất kỳ phụ thuộc nào vào các thư mục phông chữ hệ thống trong ảnh container.

**Còn về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không có hạn chế không?**

Bạn chịu trách nhiệm tuân thủ giấy phép phông chữ. Các điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn xem lại EULA của phông chữ trước khi phân phối các kết quả.