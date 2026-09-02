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
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint bằng JavaScript và Aspose.Slides cho Node.js qua Java để giữ cho bản trình bày của bạn sắc nét và nhất quán trên bất kỳ thiết bị nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong các bản trình bày mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản trình bày cụ thể thông qua các nguồn phông chữ cấp tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bản trình bày được kết xuất hoặc xuất ra, ví dụ như PDF, hình ảnh và các định dạng được hỗ trợ khác. Điều này giúp giữ cho kết quả của bản trình bày nhất quán trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ mà Aspose.Slides sử dụng và cách xóa bộ nhớ đệm phông chữ sau khi làm việc với phông chữ bên ngoài.

Đăng ký phông chữ tùy chỉnh để kết xuất là một quy trình riêng biệt với việc nhúng phông chữ vào tệp PPTX. Nếu cần lưu phông chữ bên trong bản trình bày, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

Một chủ đề trình bày có thể tham chiếu các họ phông chữ khác nhau cho các hệ thống viết riêng lẻ. Các ánh xạ này lưu trữ tên phông chữ nhưng không cài đặt hoặc tải các tệp phông chữ. Xem [Script-Specific Theme Fonts](/slides/vi/nodejs-java/script-specific-font-mappings/) để quản lý các ánh xạ, và sử dụng các tùy chọn tải dưới đây để làm cho các phông chữ được tham chiếu có sẵn cho việc kết xuất nhất quán.

{{% alert color="info" title="Note" %}}
Aspose Slides cho phép bạn tải các phông chữ này bằng phương thức [loadExternalFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Tải phông chữ tùy chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong một bản trình bày mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra khi xuất—như PDF, hình ảnh và các định dạng được hỗ trợ—để tài liệu kết quả trông nhất quán trên các môi trường. Các phông chữ được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) để tải phông chữ từ các thư mục đó.
3. Tải và kết xuất/định dạng bản trình bày.
4. Gọi [FontsLoader.clearCache](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/clearcache/) để xóa bộ nhớ đệm phông chữ.

Ví dụ mã sau minh họa quá trình tải phông chữ:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Xác định các thư mục chứa các tệp phông chữ tùy chỉnh.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Kết xuất/định dạng bản trình bày (vd: sang PDF, hình ảnh hoặc các định dạng khác) bằng các phông chữ đã tải.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn thành.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) thêm các thư mục bổ sung vào đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Lấy thư mục phông chữ tùy chỉnh**

Aspose.Slides cung cấp phương thức [getFontFolders](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) để cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục đã được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Mã JavaScript dưới đây cho bạn thấy cách sử dụng [getFontFolders](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Dòng này hiển thị các thư mục mà các tệp phông chữ được tìm kiếm.
// Đó là các thư mục được thêm thông qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Xác định phông chữ tùy chỉnh sẽ dùng cho bản trình bày**

Aspose.Slides cung cấp thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng với bản trình bày.

Mã JavaScript dưới đây cho bạn thấy cách sử dụng thuộc tính [setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Làm việc với bản trình bày
    // CustomFont1, CustomFont2, và các phông chữ từ các thư mục assets\fonts & global\fonts cùng các thư mục con của chúng có sẵn cho bản trình bày
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Quản lý phông chữ bên ngoài**

Aspose.Slides cung cấp phương thức [loadExternalFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) để cho phép bạn tải phông chữ bên ngoài từ dữ liệu nhị phân.

Mã JavaScript này minh họa quá trình tải phông chữ từ mảng byte:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // phông chữ bên ngoài được tải trong suốt thời gian tồn tại của bản trình bày
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **Câu hỏi thường gặp**

### Các phông chữ tùy chỉnh có ảnh hưởng tới việc xuất ra tất cả các định dạng (PDF, PNG, SVG, HTML) không?

Có. Các phông chữ đã kết nối được trình kết xuất sử dụng cho tất cả các định dạng xuất.

### Các phông chữ tùy chỉnh có tự động được nhúng vào tệp PPTX kết quả không?

Không. Đăng ký một phông chữ để kết xuất không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang bên trong tệp bản trình bày, phải sử dụng các [tính năng nhúng](/slides/vi/nodejs-java/embedded-font/).

### Tôi có thể kiểm soát hành vi dự phòng khi một phông chữ tùy chỉnh thiếu một số glyph không?

Có. Cấu hình [font substitution](/slides/vi/nodejs-java/font-substitution/), [replacement rules](/slides/vi/nodejs-java/font-replacement/) và [fallback sets](/slides/vi/nodejs-java/fallback-font/) để xác định chính xác phông chữ sẽ được dùng khi glyph yêu cầu không có.

### Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên hệ thống không?

Có. Chỉ định thư mục phông chữ của riêng bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ bất kỳ phụ thuộc nào vào thư mục phông chữ hệ thống trong hình ảnh container.

### Về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không bị hạn chế không?

Bạn chịu trách nhiệm tuân thủ giấy phép của phông chữ. Các điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn luôn xem xét EULA của phông chữ trước khi phân phối kết quả.