---
title: Nhúng Phông chữ trong Bản Thuyết trình bằng Java
linktitle: Nhúng Phông chữ
type: docs
weight: 40
url: /vi/java/embedded-font/
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
- bản thuyết trình
- Java
- Aspose.Slides
description: "Nhúng phông chữ TrueType trong các bản thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Java, đảm bảo việc render chính xác trên mọi nền tảng."
---
## **Giới thiệu**

**Phông chữ được nhúng trong PowerPoint** rất hữu ích khi bạn muốn bản thuyết trình của mình hiển thị đúng trên bất kỳ hệ thống hoặc thiết bị nào. Nếu bạn đã sử dụng phông chữ bên thứ ba hoặc không chuẩn vì đã sáng tạo trong công việc, thì bạn có nhiều lý do hơn để nhúng phông chữ. Ngược lại (không có phông chữ được nhúng), văn bản hoặc số trên các slide, bố cục, kiểu dáng, v.v. có thể thay đổi hoặc chuyển thành các hình chữ nhật gây nhầm lẫn.

Lớp [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager) , lớp [FontData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontdata/) , lớp [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/) và các giao diện của chúng chứa hầu hết các thuộc tính và phương thức bạn cần để làm việc với phông chữ được nhúng trong các bản thuyết trình PowerPoint. 

## **Lấy và Xóa Phông chữ Được Nhúng**

Aspose.Slides cung cấp phương thức [getEmbeddedFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (được công bố bởi lớp [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager)) cho phép bạn lấy (hoặc tìm hiểu) các phông chữ được nhúng trong một bản thuyết trình. Để xóa phông chữ, phương thức [removeEmbeddedFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (được công bố bởi cùng lớp) được sử dụng.

```java
// Tạo một đối tượng Presentation đại diện cho file bản thuyết trình
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Render một slide chứa khung văn bản sử dụng phông chữ được nhúng "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Lưu hình ảnh vào đĩa ở định dạng JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Lấy tất cả các phông chữ được nhúng
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

    // Render bản thuyết trình; phông chữ "Calibri" được thay thế bằng một phông chữ hiện có
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Lưu hình ảnh vào đĩa ở định dạng JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Lưu bản thuyết trình mà không có phông chữ "Calibri" được nhúng vào đĩa
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Phông chữ Được Nhúng**

Bằng cách sử dụng enum [EmbedFontCharacters](https://reference.aspose.com/slides/vi/java/com.aspose.slides/embedfontcharacters/) và hai overload của phương thức [addEmbeddedFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), bạn có thể chọn quy tắc (nhúng) ưa thích để nhúng phông chữ vào bản thuyết trình. Đoạn mã Java này cho bạn thấy cách nhúng và thêm phông chữ vào bản thuyết trình:

```java
// Tải bản thuyết trình
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

    // Lưu bản thuyết trình vào đĩa
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nén Phông chữ Được Nhúng**

Để cho phép bạn nén các phông chữ được nhúng trong một bản thuyết trình và giảm kích thước tệp, Aspose.Slides cung cấp phương thức [compressEmbeddedFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (được công bố bởi lớp [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/)).

Đoạn mã Java này cho bạn thấy cách nén các phông chữ PowerPoint đã nhúng:

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

**Làm sao tôi biết rằng một phông chữ cụ thể trong bản thuyết trình vẫn sẽ bị thay thế khi render dù đã được nhúng?**

Kiểm tra [substitution information](/slides/vi/java/font-substitution/) trong trình quản lý phông chữ và [fallback/substitution rules](/slides/vi/java/fallback-font/): nếu phông chữ không khả dụng hoặc bị hạn chế, một dự phòng sẽ được sử dụng.

**Có đáng để nhúng các phông chữ "hệ thống" như Arial/Calibri không?**

Thường thì không — chúng hầu hết luôn có sẵn. Nhưng để đảm bảo khả năng chuyển đổi đầy đủ trong các môi trường "mỏng" (Docker, máy chủ Linux không có sẵn phông chữ), việc nhúng phông chữ hệ thống có thể loại bỏ rủi ro thay thế không mong muốn.