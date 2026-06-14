---
title: Nhúng Phông chữ trong Bài thuyết trình trên Android
linktitle: Nhúng Phông chữ
type: docs
weight: 40
url: /vi/androidjava/embedded-font/
keywords:
- thêm phông chữ
- nhúng phông chữ
- nhúng phông chữ
- lấy phông chữ đã nhúng
- thêm phông chữ đã nhúng
- xóa phông chữ đã nhúng
- nén phông chữ đã nhúng
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Nhúng phông chữ TrueType trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Android qua Java, đảm bảo việc render chính xác trên mọi nền tảng."
---
## **Introduction**

Phông chữ nhúng trong PowerPoint rất hữu ích khi bạn muốn bản trình bày của mình hiển thị đúng trên bất kỳ hệ thống hoặc thiết bị nào. Nếu bạn đã sử dụng phông chữ của bên thứ ba hoặc không tiêu chuẩn vì bạn muốn sáng tạo trong công việc, thì bạn có thêm nhiều lý do để nhúng phông chữ. Ngược lại (không có phông chữ nhúng), văn bản hoặc số trên các slide, bố cục, kiểu dáng, v.v. có thể thay đổi hoặc biến thành những hình chữ nhật gây nhầm lẫn. 

Các lớp [FontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontdata/) và [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/) và các giao diện của chúng chứa hầu hết các thuộc tính và phương thức bạn cần để làm việc với phông chữ nhúng trong các bản trình bày PowerPoint.

## **Lấy và Xóa Phông chữ Nhúng**

Aspose.Slides cung cấp phương thức [getEmbeddedFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (được khai báo bởi lớp [FontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontsManager)) để cho phép bạn lấy (hoặc biết) các phông chữ đã được nhúng trong một bản trình bày. Để xóa phông chữ, phương thức [removeEmbeddedFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (cũng do cùng lớp này khai báo) được sử dụng.

Đoạn mã Java sau đây cho bạn thấy cách lấy và xóa phông chữ nhúng khỏi một bản trình bày:

```java
// Khởi tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Kết xuất một slide chứa khung văn bản sử dụng phông chữ nhúng "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Lưu ảnh ra đĩa ở định dạng JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Lấy tất cả các phông chữ đã nhúng
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Tìm phông chữ "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Xóa phông chữ "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Kết xuất bài thuyết trình; "Calibri" được thay thế bằng một phông chữ hiện có
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Lưu ảnh ra đĩa ở định dạng JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Lưu bài thuyết trình mà không có phông chữ "Calibri" đã nhúng ra đĩa
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Phông chữ Nhúng**

Bằng cách sử dụng enum [EmbedFontCharacters](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/embedfontcharacters/) và hai phiên bản tải quá tải của phương thức [addEmbeddedFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), bạn có thể chọn quy tắc (nhúng) ưa thích để nhúng phông chữ vào bản trình bày. Đoạn mã Java sau đây cho bạn thấy cách nhúng và thêm phông chữ vào bản trình bày:

```java
// Tải bài thuyết trình
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Lưu bài thuyết trình vào đĩa
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nén Phông chữ Nhúng**

Để cho phép bạn nén các phông chữ đã nhúng trong một bản trình bày và giảm kích thước tệp, Aspose.Slides cung cấp phương thức [compressEmbeddedFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (được khai báo bởi lớp [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/)).

Đoạn mã Java sau đây cho bạn thấy cách nén các phông chữ PowerPoint đã nhúng:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết một phông chữ cụ thể trong bản trình bày vẫn sẽ bị thay thế khi render mặc dù đã được nhúng?**

Kiểm tra [thông tin thay thế](/slides/vi/androidjava/font-substitution/) trong trình quản lý phông chữ và [quy tắc dự phòng/thay thế](/slides/vi/androidjava/fallback-font/): nếu phông chữ không khả dụng hoặc bị hạn chế, sẽ sử dụng phông chữ dự phòng.

**Việc nhúng các phông chữ “hệ thống” như Arial/Calibri có đáng không?**

Thường thì không — chúng hầu như luôn có sẵn. Tuy nhiên, để đạt tính di động hoàn toàn trong các môi trường “gọn” (Docker, máy chủ Linux không có phông chữ được cài sẵn), việc nhúng các phông chữ hệ thống có thể loại bỏ nguy cơ bị thay thế không mong muốn.