---
title: Nhúng Phông chữ trong Bản trình bày bằng .NET
linktitle: Nhúng Phông chữ
type: docs
weight: 40
url: /vi/net/embedded-font/
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
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Nhúng phông chữ TrueType vào các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho .NET, đảm bảo việc render chính xác trên mọi nền tảng."
---
## **Giới thiệu**

**Nhúng phông chữ trong PowerPoint** đảm bảo bản trình bày của bạn giữ nguyên giao diện dự định trên các hệ thống khác nhau. Cho dù sử dụng phông chữ độc đáo để sáng tạo hay các phông chữ tiêu chuẩn, việc nhúng phông chữ ngăn chặn sự gián đoạn văn bản và bố cục.

Nếu bạn đã sử dụng phông chữ của bên thứ ba hoặc phông chữ không chuẩn vì muốn sáng tạo trong công việc, thì bạn có thêm nhiều lý do để nhúng phông chữ. Ngược lại (không nhúng phông chữ), văn bản hoặc số trên các slide, bố cục, kiểu dáng, v.v. có thể thay đổi hoặc biến thành các hình chữ nhật gây nhầm lẫn.

Sử dụng các lớp [FontsManager](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/vi/net/aspose.slides/fontdata/) và [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/) để quản lý phông chữ đã nhúng.

## **Lấy và Xóa Phông chữ Đã Nhúng**

Lấy hoặc xóa phông chữ đã nhúng khỏi bản trình bày một cách dễ dàng với các phương thức [GetEmbeddedFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getembeddedfonts) và [RemoveEmbeddedFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/removeembeddedfont).

Mã C# này cho bạn thấy cách lấy và xóa phông chữ đã nhúng khỏi một bản trình bày:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Hiển thị một slide chứa khung văn bản sử dụng phông chữ đã nhúng "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Tìm phông chữ "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Xóa phông chữ "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Hiển thị bản trình bày; phông chữ "Calibri" sẽ được thay thế bằng một phông chữ có sẵn
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Lưu bản trình bày mà không có phông chữ "Calibri" đã nhúng vào đĩa
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Thêm Phông chữ Đã Nhúng**

Sử dụng enum [EmbedFontCharacters](https://reference.aspose.com/slides/vi/net/aspose.slides.export/embedfontcharacters/) và hai overload của phương thức [AddEmbeddedFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/addembeddedfont/), bạn có thể chọn quy tắc (nhúng) ưa thích để nhúng phông chữ vào bản trình bày. Mã C# này cho bạn thấy cách nhúng và thêm phông chữ vào một bản trình bày:

```c#
// Tải bản trình bày
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Lưu bản trình bày vào đĩa
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Nén Phông chữ Đã Nhúng**

Tối ưu kích thước tệp bằng cách nén các phông chữ đã nhúng bằng [CompressEmbeddedFonts](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Mã ví dụ cho việc nén:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Làm sao tôi biết rằng một phông chữ cụ thể trong bản trình bày vẫn sẽ bị thay thế khi render dù đã nhúng?**

Kiểm tra [thông tin thay thế](/slides/vi/net/font-substitution/) trong font manager và [quy tắc dự phòng/thay thế](/slides/vi/net/fallback-font/): nếu phông chữ không khả dụng hoặc bị hạn chế, sẽ sử dụng phông chữ dự phòng.

**Liệu có đáng nhúng các phông chữ "hệ thống" như Arial/Calibri không?**

Thường không—chúng hầu như luôn có sẵn. Tuy nhiên, để đạt tính di động đầy đủ trong các môi trường "mỏng" (Docker, máy chủ Linux không có phông chữ được cài sẵn), việc nhúng phông chữ hệ thống có thể loại bỏ rủi ro thay thế không mong muốn.