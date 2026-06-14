---
title: Tùy chỉnh phông chữ PowerPoint trong JavaScript
linktitle: Phông chữ tùy chỉnh
type: docs
weight: 20
url: /vi/nodejs-java/custom-font/
keywords:
- phông chữ
- phông chữ tùy chỉnh
- phông chữ bên ngoài
- tải phông chữ
- quản lý phông chữ
- thư mục phông chữ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint bằng JavaScript và Aspose.Slides cho Node.js thông qua Java để giữ cho bài thuyết trình của bạn sắc nét và nhất quán trên bất kỳ thiết bị nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong bài thuyết trình mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bài thuyết trình cụ thể thông qua nguồn phông chữ ở cấp độ tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bài thuyết trình được render hoặc xuất, ví dụ sang PDF, hình ảnh và các định dạng được hỗ trợ khác. Điều này giúp duy trì đầu ra của bài thuyết trình nhất quán trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ mà Aspose.Slides sử dụng và cách xóa bộ nhớ cache phông chữ sau khi làm việc với phông chữ bên ngoài.

Đăng ký phông chữ tùy chỉnh để render là một quá trình riêng biệt so với việc nhúng phông chữ vào file PPTX. Nếu một phông chữ phải được lưu trong chính bài thuyết trình, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

{{% alert color="primary" %}} 
Aspose Slides cho phép bạn tải các phông chữ này bằng phương thức [loadExternalFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Phông TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Phông OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Tải Phông Chữ Tùy Chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong một bài thuyết trình mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra khi xuất—như PDF, hình ảnh và các định dạng hỗ trợ khác—để các tài liệu tạo ra trông nhất quán trên các môi trường. Các phông chữ được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) để tải phông chữ từ các thư mục đó.
3. Tải và render/ xuất bài thuyết trình.
4. Gọi [FontsLoader.clearCache](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/clearcache/) để xóa bộ nhớ cache phông chữ.

```js
// Xác định các thư mục chứa tệp phông chữ tùy chỉnh.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Tải phông chữ tùy chỉnh từ các thư mục được chỉ định.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Render/ xuất bài thuyết trình (ví dụ: sang PDF, hình ảnh hoặc các định dạng khác) bằng cách sử dụng các phông chữ đã tải.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Xóa bộ nhớ cache phông chữ sau khi công việc hoàn thành.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Lưu ý" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) thêm các thư mục bổ sung vào đường dẫn tìm kiếm phông chữ, nhưng nó không thay đổi thứ tự khởi tạo phông chữ.
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Lấy Thư Mục Phông Chữ Tùy Chỉnh**
Aspose.Slides cung cấp phương thức [getFontFolders](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) để cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

```javascript
// Dòng này xuất ra các thư mục nơi các tệp phông chữ được tìm kiếm.
// Đó là các thư mục được thêm thông qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Xác Định Phông Chữ Tùy Chỉnh Được Sử Dụng Cùng Bài Thuyết Trình**
Aspose.Slides cung cấp thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng cùng với bài thuyết trình.

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Làm việc với bài thuyết trình
    // CustomFont1, CustomFont2, và các phông chữ từ thư mục assets\fonts & global\fonts và các thư mục con của chúng đều có sẵn cho bài thuyết trình
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Quản Lý Phông Chữ Bên Ngoài**

Aspose.Slides cung cấp phương thức [loadExternalFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) để cho phép bạn tải phông chữ bên ngoài từ dữ liệu nhị phân.

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // phông chữ bên ngoài được tải trong suốt thời gian tồn tại của bài thuyết trình
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **Câu hỏi thường gặp**

**Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất sang tất cả các định dạng (PDF, PNG, SVG, HTML) không?**

Có. Các phông chữ được kết nối được trình render sử dụng cho tất cả các định dạng xuất.

**Phông chữ tùy chỉnh có tự động được nhúng vào PPTX kết quả không?**

Không. Đăng ký một phông chữ để render không giống với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang trong file bài thuyết trình, bạn phải sử dụng các [tính năng nhúng](/slides/vi/nodejs-java/embedded-font/).

**Tôi có thể kiểm soát hành vi dự phòng khi một phông chữ tùy chỉnh thiếu một số glyph không?**

Có. Cấu hình [font substitution](/slides/vi/nodejs-java/font-substitution/), [replacement rules](/slides/vi/nodejs-java/font-replacement/), và [fallback sets](/slides/vi/nodejs-java/fallback-font/) để xác định chính xác phông chữ nào sẽ được sử dụng khi glyph yêu cầu không có.

**Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên toàn hệ thống không?**

Có. Chỉ định các thư mục phông chữ của bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ bất kỳ sự phụ thuộc nào vào các thư mục phông chữ hệ thống trong hình ảnh container.

**Còn về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không có hạn chế không?**

Bạn chịu trách nhiệm tuân thủ giấy phép phông chữ. Các điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn luôn xem lại EULA của phông chữ trước khi phát hành các kết quả.