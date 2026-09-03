---
title: Nhúng Phông Chữ trong Bản Trình Chiếu bằng JavaScript
linktitle: Phông Chữ Nhúng
type: docs
weight: 40
url: /vi/nodejs-java/embedded-font/
keywords:
- thêm phông chữ
- nhúng phông chữ
- việc nhúng phông chữ
- lấy phông chữ đã nhúng
- thêm phông chữ đã nhúng
- xóa phông chữ đã nhúng
- nén phông chữ đã nhúng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý phông chữ nhúng trong PowerPoint với Aspose.Slides cho Node.js qua Java. Thêm, lấy, xóa và nén phông chữ để giữ nguyên giao diện văn bản và giảm kích thước tệp."
---
## **Giới thiệu**

Nhúng phông chữ lưu trữ dữ liệu phông chữ bên trong một bản trình chiếu PowerPoint. Khi một trình xem hỗ trợ phông chữ nhúng, nó có thể hiển thị văn bản bằng các phông chữ đó ngay cả khi chúng không được cài đặt trên hệ thống đích. Điều này giúp giữ nguyên ngắt dòng, khoảng cách chữ và bố cục slide.

Aspose.Slides for Node.js via Java cho phép bạn truy xuất, thêm và xóa phông chữ nhúng thông qua lớp [FontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/) được trả về bởi [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getfontsmanager/). Bạn cũng có thể giảm kích thước dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự mà bản trình chiếu không sử dụng.

Các ví dụ dưới đây làm việc với tệp PPTX. Trước khi nhúng một phông chữ, hãy chắc chắn rằng dữ liệu phông chữ của nó có sẵn cho Aspose.Slides và giấy phép của nó cho phép nhúng.

## **Lấy và Xóa Phông Chữ Nhúng**

Sử dụng [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) để liệt kê các phông chữ được lưu trong một bản trình chiếu. Để xóa một phông chữ, truyền một phông chữ từ danh sách đó vào [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), sau đó lưu bản trình chiếu.

Ví dụ sau liệt kê các phông chữ nhúng trong `EmbeddedFonts.pptx` và xóa Calibri nếu nó có mặt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Việc xóa một phông chữ nhúng sẽ xóa dữ liệu phông chữ đã lưu; nó không thay đổi phông chữ được gán cho văn bản. Nếu phông chữ đã được cài đặt trên hệ thống đích, văn bản vẫn có thể sử dụng nó. Nếu không, việc render có thể yêu cầu [font substitution](/slides/vi/nodejs-java/font-substitution/), điều này có thể ảnh hưởng đến bố cục.

## **Kiểm Tra Dữ Liệu Phông Chữ và Quyền Nhúng**

Sử dụng lớp [FontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/) để kiểm tra phông chữ trước khi nhúng chúng. Gọi [FontsManager.getFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getfonts/) để lấy các phông chữ được sử dụng trong bản trình chiếu. Đối với mỗi phông chữ, truyền một đối tượng [FontData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontdata/) và giá trị [FontStyleType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontstyletype/) yêu cầu vào [FontsManager.getFontBytes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). Phương thức này trả về dữ liệu nhị phân cho kiểu phông chữ đó, hoặc `null` khi phông chữ hoặc kiểu yêu cầu không khả dụng. Không truyền kết quả `null` vào [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), vì phương thức này yêu cầu một mảng byte. Trong Node.js, chuyển mảng JavaScript trả về thành mảng byte Java bằng `java.newArray` trước khi truyền vào `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/embeddinglevel/) báo cáo các hạn chế nhúng được lưu trong phông chữ dưới dạng một tập hợp các cờ:

- `Installable` cho phép nhúng và cài đặt vĩnh viễn trên hệ thống khác, tùy thuộc vào giấy phép phông chữ.
- `Restricted` cấm nhúng trừ khi có sự cho phép từ chủ sở hữu pháp lý của phông chữ khi đây là cờ quyền sử dụng duy nhất.
- `PreviewPrint` cho phép sử dụng tạm thời để xem và in; tài liệu chứa phông chữ phải ở chế độ chỉ đọc.
- `Editable` cho phép sử dụng tạm thời và cho phép tài liệu được chỉnh sửa và lưu lại.
- `NoSubsetting` là một hạn chế bổ sung cấm nhúng chỉ một phần con của các glyph. Khi cờ này có mặt, phải nhúng tất cả các ký tự.
- `BitmapOnly` là một hạn chế bổ sung chỉ cho phép nhúng các dạng bitmap, không nhúng dữ liệu dạng outline. Nếu phông chữ không có bitmap, nó không thể được nhúng.

Bốn giá trị đầu mô tả quyền sử dụng, trong khi `NoSubsetting` và `BitmapOnly` có thể được kết hợp với chúng. Kiểm tra các bộ điều chế bằng các phép toán bitwise. Vì `Installable` bằng zero, hãy tạo mặt nạ cho các bit quyền sử dụng và so sánh kết quả với `Installable` thay vì kiểm tra nó như một cờ. Các phông chữ hiện tại nên đặt tối đa một bit quyền sử dụng. Đối với tính tương thích với các phông chữ cũ hơn có thể đặt nhiều hơn một bit, hàm trợ giúp bên dưới sẽ chọn quyền ít hạn chế nhất: `Editable`, sau đó `PreviewPrint`, rồi `Restricted`.

Ví dụ sau kiểm tra dữ liệu thường, in đậm, in nghiêng và in đậm-nghiêng có sẵn cho mỗi phông chữ trả về bởi `getFonts`. Nó bỏ qua các kiểu không khả dụng, phông chữ bị hạn chế, phông chữ chỉ bitmap, phông chữ giới hạn ở chế độ xem và in vì đầu ra vẫn có thể chỉnh sửa, và các phông chữ đã được nhúng. Nếu bất kỳ kiểu nào có `NoSubsetting`, nó sẽ nhúng tất cả các ký tự cho họ họ phông chữ đó.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kiểm tra này báo cáo các hạn chế được mã hoá trong mỗi tệp phông chữ. Nó không cấp giấy phép, không chứng minh rằng bạn đã có được phông chữ một cách hợp pháp, và không thay thế việc kiểm tra thỏa thuận giấy phép của phông chữ trước khi phân phối bản sao nhúng.

## **Thêm Phông Chữ Nhúng**

Sử dụng [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) để nhúng một phông chữ. Các overload của nó chấp nhận một đối tượng [FontData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontdata/) hoặc một mảng byte chứa dữ liệu phông chữ. [EmbedFontCharacters](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/embedfontcharacters/) điều khiển các ký tự sẽ được bao gồm:

- `All` nhúng tất cả các ký tự trong phông chữ. Sử dụng tùy chọn này khi người nhận cần chỉnh sửa bản trình chiếu và nhập văn bản mới.
- `OnlyUsed` chỉ nhúng các ký tự được sử dụng trong bản trình chiếu để giảm kích thước tệp. Chọn tùy chọn này cho bản trình chiếu đã hoàn thiện và chủ yếu được dùng để xem.

Ví dụ sau sử dụng [FontsManager.getFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getfonts/) để lấy các phông chữ được sử dụng trong `Fonts.pptx` và nhúng những phông chữ chưa được nhúng. Các phông chữ cần thêm phải có sẵn trên máy chạy mã. Các phông chữ đã nhúng sẽ giữ nguyên bộ ký tự hiện tại.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nén Phông Chữ Nhúng**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/compressembeddedfonts/) giảm dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự không dùng tới. Nó hoạt động trên các phông chữ đã được nhúng, vì vậy mức giảm kích thước phụ thuộc vào lượng dữ liệu phông chữ không sử dụng trong bản trình chiếu.

Ví dụ sau nén các phông chữ trong `EmbeddedFonts.pptx` và lưu kết quả thành một tệp riêng:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Giữ lại tệp gốc nếu người nhận có thể cần thêm văn bản sau này. Các ký tự bị loại bỏ trong quá trình nén sẽ không còn khả dụng từ phông chữ đã nhúng, ngay cả khi bạn đã nhúng tất cả ký tự ban đầu.

## **FAQ**

**Làm thế nào để kiểm tra xem một phông chữ nhúng có vẫn bị thay thế trong quá trình render không?**

Gọi [FontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) trong môi trường bạn render bản trình chiếu để xem Aspose.Slides sẽ thay thế phông chữ nào. Đồng thời kiểm tra cài đặt [font substitution](/slides/vi/nodejs-java/font-substitution/) và quy tắc [font fallback](/slides/vi/nodejs-java/fallback-font/). Fallback xử lý các ký tự thiếu, vì vậy việc nhúng phông chữ không giải quyết các ký tự mà phông chữ tự nó không chứa.

**Tôi có nên nhúng các phông chữ phổ biến như Arial và Calibri không?**

Đưa ra quyết định dựa trên môi trường đích. Nếu các phông chữ cần thiết đã có sẵn trên mọi máy mở hoặc render bản trình chiếu, việc nhúng chúng có thể làm tăng kích thước tệp không cần thiết. Nếu người nhận hoặc máy chủ có thể thiếu các phông chữ đó, việc nhúng chúng có thể giúp duy trì giao diện mong muốn, với điều kiện giấy phép của chúng cho phép.