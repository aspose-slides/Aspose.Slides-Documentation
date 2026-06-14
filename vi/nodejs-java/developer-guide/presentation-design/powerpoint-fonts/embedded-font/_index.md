---
title: Nhúng phông chữ trong bản trình chiếu bằng JavaScript
linktitle: Nhúng phông chữ
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
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Nhúng phông chữ TrueType trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js thông qua Java, đảm bảo việc render chính xác trên mọi nền tảng."
---
## **Giới thiệu**

**Embedded fonts in PowerPoint** rất hữu ích khi bạn muốn bản trình chiếu của mình hiển thị đúng trên bất kỳ hệ thống hoặc thiết bị nào. Nếu bạn đã sử dụng phông chữ của bên thứ ba hoặc không chuẩn vì muốn sáng tạo trong công việc, thì bạn có thêm lý do để nhúng phông chữ. Ngược lại (không có phông chữ được nhúng), văn bản hoặc số trên các slide, bố cục, kiểu dáng, v.v. có thể thay đổi hoặc chuyển thành các hình chữ nhật gây khó hiểu. 

Lớp [FontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontsManager), lớp [FontData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontdata/) , lớp [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/) và các lớp của chúng chứa hầu hết các thuộc tính và phương thức bạn cần để làm việc với phông chữ được nhúng trong bản trình chiếu PowerPoint.

## **Lấy hoặc Xóa Phông chữ Được Nhúng trong Bản trình chiếu**

Aspose.Slides cung cấp phương thức [getEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (được khai báo bởi lớp [FontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontsManager)) để cho phép bạn lấy (hoặc biết) các phông chữ đã được nhúng trong một bản trình chiếu. Để xóa phông chữ, phương thức [removeEmbeddedFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (được khai báo bởi cùng lớp) được sử dụng.

Mã JavaScript sau cho bạn thấy cách lấy và xóa phông chữ được nhúng khỏi một bản trình chiếu:

```javascript
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Kết xuất một slide chứa khung văn bản sử dụng phông chữ nhúng "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Lưu ảnh vào đĩa ở định dạng JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Lấy tất cả các phông chữ đã nhúng
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Tìm phông chữ "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Xóa phông chữ "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Kết xuất bản trình chiếu; phông chữ "Calibri" được thay thế bằng một phông chữ có sẵn
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Lưu ảnh vào đĩa ở định dạng JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Lưu bản trình chiếu mà không có phông chữ "Calibri" đã nhúng vào đĩa
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm Phông chữ Được Nhúng vào Bản trình chiếu**

Bằng cách sử dụng enum [EmbedFontCharacters](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/embedfontcharacters/) và hai overload của phương thức [addEmbeddedFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-), bạn có thể chọn quy tắc (nhúng) ưa thích để nhúng phông chữ vào bản trình chiếu. Mã JavaScript sau cho bạn thấy cách nhúng và thêm phông chữ vào một bản trình chiếu:

```javascript
// Tải bản trình chiếu
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Lưu bản trình chiếu vào đĩa
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nén Phông chữ Được Nhúng**

Để cho phép bạn nén các phông chữ đã được nhúng trong một bản trình chiếu và giảm kích thước tệp, Aspose.Slides cung cấp phương thức [compressEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (được khai báo bởi lớp [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/)).

Mã JavaScript sau cho bạn thấy cách nén phông chữ PowerPoint đã được nhúng:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết một phông chữ cụ thể trong bản trình chiếu vẫn sẽ bị thay thế khi render mặc dù đã nhúng?**

Kiểm tra [thông tin thay thế](/slides/vi/nodejs-java/font-substitution/) trong trình quản lý phông chữ và [quy tắc dự phòng/thay thế](/slides/vi/nodejs-java/fallback-font/): nếu phông chữ không khả dụng hoặc bị hạn chế, một phông chữ dự phòng sẽ được sử dụng.

**Có nên nhúng các phông chữ “hệ thống” như Arial/Calibri không?**

Thường không—chúng hầu hết luôn có sẵn. Nhưng để đạt khả năng di động đầy đủ trong các môi trường “gọn nhẹ” (Docker, máy chủ Linux chưa cài sẵn phông chữ), việc nhúng phông chữ hệ thống có thể loại bỏ rủi ro thay thế không mong muốn.