---
title: Tùy chỉnh phông chữ PowerPoint trên Android
linktitle: Phông chữ tùy chỉnh
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
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho Android bằng Java để giữ cho bản trình chiếu của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong bản trình chiếu mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông cho một bản trình chiếu cụ thể thông qua các nguồn phông ở mức tài liệu, hoặc tải phông bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông đã tải sẽ được sử dụng khi bản trình chiếu được render hoặc xuất ra, ví dụ sang PDF, hình ảnh và các định dạng hỗ trợ khác. Điều này giúp duy trì tính nhất quán của đầu ra bản trình chiếu trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông được Aspose.Slides sử dụng và cách xóa bộ nhớ cache phông sau khi làm việc với phông bên ngoài.

Việc đăng ký phông tùy chỉnh để render là riêng biệt so với việc nhúng phông vào tệp PPTX. Nếu một phông cần được lưu trữ bên trong bản trình chiếu, hãy sử dụng các tính năng nhúng phông một cách rõ ràng.

{{% alert color="info" %}} 

Aspose Slides cho phép bạn tải các phông này bằng phương pháp [loadExternalFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Phông TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Phông OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Tải Phông Tùy Chỉnh**

Aspose.Slides cho phép bạn tải các phông được sử dụng trong bản trình chiếu mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra khi xuất – như PDF, hình ảnh và các định dạng hỗ trợ khác – để các tài liệu kết quả trông nhất quán trên mọi môi trường. Các phông được tải từ các thư mục tùy chỉnh.

1. Chỉ định một hoặc nhiều thư mục chứa các tệp phông.
2. Gọi phương pháp tĩnh [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) để tải phông từ các thư mục đó.
3. Tải và render/​xuất bản trình chiếu.
4. Gọi [FontsLoader.clearCache](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontsLoader#clearCache--) để xóa bộ nhớ cache phông.

Ví dụ mã sau minh họa quá trình tải phông:

```java
import com.aspose.slides.*;

// Xác định các thư mục chứa tệp phông chữ tùy chỉnh.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Tải các phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Render/​xuất bản trình chiếu (ví dụ: sang PDF, hình ảnh hoặc các định dạng khác) bằng cách sử dụng các phông chữ đã tải.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Xóa bộ nhớ cache phông sau khi công việc hoàn thành.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) thêm các thư mục bổ sung vào đường dẫn tìm kiếm phông, nhưng không thay đổi thứ tự khởi tạo phông. Phông được khởi tạo theo thứ tự sau:

1. Đường dẫn phông mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Lấy Các Thư Mục Phông Tùy Chỉnh**

Aspose.Slides cung cấp phương pháp [getFontFolders](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) để cho phép bạn tìm các thư mục phông. Phương pháp này trả về các thư mục được thêm thông qua phương pháp `LoadExternalFonts` và các thư mục phông hệ thống.

Đoạn mã Java sau cho bạn thấy cách sử dụng [getFontFolders](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Dòng này trả về các thư mục nơi các tệp phông chữ được tìm kiếm.
// Đó là các thư mục được thêm thông qua phương pháp LoadExternalFonts và các thư mục phông chữ hệ thống.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Chỉ Định Phông Tùy Chỉnh Được Sử Dụng Cùng Bản Trình Chiếu**

Aspose.Slides cung cấp thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) để cho phép bạn chỉ định các phông bên ngoài sẽ được sử dụng cùng với bản trình chiếu.

Đoạn mã Java sau cho bạn thấy cách sử dụng thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // Làm việc với bản trình chiếu
    // CustomFont1, CustomFont2 và các phông chữ từ thư mục assets\fonts & global\fonts cùng các thư mục con của chúng đều khả dụng cho bản trình chiếu
} finally {
    if (pres != null) pres.dispose();
}
```

## **Quản Lý Phông Bên Ngoài**

Aspose.Slides cung cấp phương pháp [loadExternalFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) để cho phép bạn tải phông bên ngoài từ dữ liệu nhị phân.

Đoạn mã Java sau trình bày quá trình tải phông từ mảng byte:

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
        // phông chữ bên ngoài được tải trong suốt thời gian tồn tại của bản trình chiếu
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Câu hỏi thường gặp**

### Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất ra tất cả các định dạng (PDF, PNG, SVG, HTML) không?

Có. Các phông đã kết nối sẽ được renderer sử dụng trên mọi định dạng xuất.

### Các phông tùy chỉnh có tự động được nhúng vào tệp PPTX kết quả không?

Không. Đăng ký một phông để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông được mang bên trong tệp bản trình chiếu, phải sử dụng các [tính năng nhúng](/slides/vi/androidjava/embedded-font/).

### Tôi có thể kiểm soát hành vi dự phòng khi một phông tùy chỉnh thiếu một số glyph không?

Có. Cấu hình [font substitution](/slides/vi/androidjava/font-substitution/), [replacement rules](/slides/vi/androidjava/font-replacement/) và [fallback sets](/slides/vi/androidjava/fallback-font/) để xác định chính xác phông nào sẽ được dùng khi glyph yêu cầu không có.

### Tôi có thể sử dụng phông trong các container Linux/Docker mà không cần cài đặt chúng trên hệ thống không?

Có. Chỉ định các thư mục phông riêng của bạn hoặc tải phông từ mảng byte. Điều này loại bỏ mọi phụ thuộc vào các thư mục phông hệ thống trong ảnh container.

### Về giấy phép—tôi có thể nhúng bất kỳ phông tùy chỉnh nào mà không bị hạn chế không?

Bạn chịu trách nhiệm tuân thủ giấy phép phông. Các điều khoản khác nhau; một số giấy phép cấm nhúng hoặc sử dụng thương mại. Luôn kiểm tra EULA của phông trước khi phân phối các đầu ra.