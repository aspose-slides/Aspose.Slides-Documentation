---
title: Tùy chỉnh phông chữ PowerPoint trong Java
linktitle: Phông chữ tùy chỉnh
type: docs
weight: 20
url: /vi/java/custom-font/
keywords:
- phông chữ
- phông chữ tùy chỉnh
- phông chữ ngoại vi
- tải phông chữ
- quản lý phông chữ
- thư mục phông chữ
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint bằng Aspose.Slides cho Java để giữ cho bản trình bày của bạn luôn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong bản trình bày mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản trình bày cụ thể thông qua nguồn phông chữ cấp tài liệu, hoặc tải phông chữ ngoại vi trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi một bản trình bày được render hoặc xuất, ví dụ sang PDF, hình ảnh và các định dạng hỗ trợ khác. Điều này giúp giữ đầu ra của bản trình bày nhất quán trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ mà Aspose.Slides sử dụng và cách xóa bộ nhớ đệm phông chữ sau khi làm việc với phông chữ ngoại vi.

Đăng ký phông chữ tùy chỉnh cho việc render là riêng biệt so với việc nhúng phông chữ vào tệp PPTX. Nếu một phông chữ phải được lưu trong bản trình bày, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

{{% alert color="info" %}} 
Aspose Slides cho phép bạn tải các phông chữ này bằng phương thức [loadExternalFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Phông chữ TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Phông chữ OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Tải phông chữ tùy chỉnh**

Aspose.Slides cho phép bạn tải phông chữ được sử dụng trong một bản trình bày mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra xuất—như PDF, hình ảnh và các định dạng hỗ trợ khác—để các tài liệu kết quả trông nhất quán trên các môi trường. Phông chữ được tải từ các thư mục tùy chỉnh.

1. Chỉ định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) để tải phông chữ từ các thư mục đó.
3. Tải và render/​xuất bản trình bày.
4. Gọi [FontsLoader.clearCache](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsLoader#clearCache--) để xóa bộ nhớ đệm phông chữ.

Ví dụ mã bên dưới minh họa quy trình tải phông chữ:

```java
import com.aspose.slides.*;

// Định nghĩa các thư mục chứa tệp phông chữ tùy chỉnh.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Render/xuất bản trình bày (ví dụ, sang PDF, hình ảnh hoặc các định dạng khác) bằng cách sử dụng các phông chữ đã tải.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn thành.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) thêm các thư mục bổ sung vào các đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Lấy các thư mục phông chữ tùy chỉnh**
Aspose.Slides cung cấp phương thức [getFontFolders](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#getFontFolders--) cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Mã Java này cho bạn thấy cách sử dụng [getFontFolders](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Dòng này xuất ra các thư mục nơi tìm kiếm tệp phông chữ.
// Đó là các thư mục được thêm thông qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Chỉ định phông chữ tùy chỉnh dùng cho một bản trình bày**
Aspose.Slides cung cấp thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) cho phép bạn chỉ định các phông chữ ngoại vi sẽ được sử dụng với bản trình bày.

Mã Java này cho bạn thấy cách sử dụng thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Làm việc với bản trình bày
    // CustomFont1, CustomFont2, và các phông chữ từ thư mục assets\fonts & global\fonts và các thư mục con của chúng đều có sẵn cho bản trình bày
} finally {
    if (pres != null) pres.dispose();
}
```

## **Quản lý phông chữ ngoại vi**

Aspose.Slides cung cấp phương thức [loadExternalFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) cho phép bạn tải phông chữ ngoại vi từ dữ liệu nhị phân.

Mã Java này minh họa quy trình tải phông chữ từ mảng byte:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // phông chữ ngoại vi được tải trong thời gian sống của bản trình bày
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Câu hỏi thường gặp**

### Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất sang tất cả các định dạng (PDF, PNG, SVG, HTML) không?
Có. Các phông chữ được kết nối sẽ được trình render sử dụng cho tất cả các định dạng xuất.

### Phông chữ tùy chỉnh có được tự động nhúng vào tệp PPTX kết quả không?
Không. Đăng ký một phông chữ để render không giống với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang trong tệp bản trình bày, phải sử dụng các [tính năng nhúng](/slides/vi/java/embedded-font/) một cách rõ ràng.

### Tôi có thể kiểm soát hành vi dự phòng khi một phông chữ tùy chỉnh thiếu một số glyph không?
Có. Cấu hình [thay thế phông chữ](/slides/vi/java/font-substitution/), [quy tắc thay thế](/slides/vi/java/font-replacement/) và [bộ phông chữ dự phòng](/slides/vi/java/fallback-font/) để xác định chính xác phông chữ nào sẽ được dùng khi glyph được yêu cầu không có.

### Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên toàn hệ thống không?
Có. Chỉ định các thư mục phông chữ của riêng bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ mọi phụ thuộc vào các thư mục phông chữ hệ thống trong ảnh container.

### Còn về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không bị hạn chế không?
Bạn chịu trách nhiệm tuân thủ giấy phép phông chữ. Các điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn luôn xem xét EULA của phông chữ trước khi phân phối các đầu ra.