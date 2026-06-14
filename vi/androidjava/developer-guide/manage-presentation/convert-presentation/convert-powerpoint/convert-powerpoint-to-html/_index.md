---
title: Chuyển đổi bản trình chiếu PowerPoint sang HTML trên Android
linktitle: PowerPoint sang HTML
type: docs
weight: 30
url: /vi/androidjava/convert-powerpoint-to-html/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang HTML
- bài thuyết trình sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- lưu PowerPoint thành HTML
- lưu bài thuyết trình thành HTML
- lưu slide thành HTML
- lưu PPT thành HTML
- lưu PPTX thành HTML
- xuất PPT sang HTML
- xuất PPTX sang HTML
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi bản trình chiếu PowerPoint sang HTML trên Android. Sử dụng Aspose.Slides cho Android thông qua Java để xuất các tệp PPT và PPTX, các slide đã chọn, ghi chú, phông chữ, hình ảnh, SVG và media."
---
## **Tổng quan**

Aspose.Slides cho Android thông qua Java có thể lưu các bản trình chiếu PowerPoint dưới dạng HTML mà không cần Microsoft PowerPoint. Việc chuyển đổi cơ bản chỉ bao gồm một lần tải [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và một lời gọi `save` với [SaveFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/). Sử dụng [HtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/) khi bạn cần kiểm soát bố cục xuất khẩu, phông chữ, hình ảnh, ghi chú, bình luận, đầu ra SVG hoặc các tài nguyên được liên kết.

Hướng dẫn này tập trung vào các kịch bản xuất HTML thực tế:

- Xuất toàn bộ bản trình chiếu hoặc các slide đã chọn.
- Tạo HTML có bố cục cố định, đáp ứng hoặc dựa trên SVG.
- Bao gồm ghi chú người thuyết trình và bình luận.
- Kiểm soát chất lượng hình ảnh và dữ liệu hình ảnh đã cắt.
- Nhúng phông chữ hoặc lưu các tệp phông chữ riêng biệt.
- Chọn cách các tài nguyên bên ngoài và tệp media được ghi và tham chiếu.

Mặc định, xuất HTML tạo ra một tài liệu HTML độc lập, trong đó hầu hết các tài nguyên được nhúng. Điều này tiện lợi cho việc chia sẻ một tệp duy nhất, nhưng có thể làm tăng kích thước kết quả. Đối với việc xuất bản trên web, hãy cân nhắc sử dụng tài nguyên bên ngoài, giảm DPI hình ảnh và chỉ nhúng các phông chữ không có sẵn một cách tin cậy trong môi trường mục tiêu.

## **Chuyển đổi một bản trình chiếu sang HTML**

Để xuất một bản trình chiếu sang HTML, tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và lưu nó bằng [SaveFormat.Html](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Ví dụ này ghi một tệp HTML. Đối tượng presentation được giải phóng trong khối `finally`, giúp giải phóng các tay cầm tệp và tài nguyên rendering sau khi xuất.

## **Sử dụng HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/) là lớp cấu hình chính cho việc xuất HTML. Các thiết lập thường dùng bao gồm:

- `SlidesLayoutOptions`: thêm ghi chú, bình luận, tài liệu phát tay hoặc các thông tin bố cục khác.
- `HtmlFormatter`: thay đổi cấu trúc tài liệu HTML hoặc ủy quyền định dạng cho một bộ điều khiển.
- `SlideImageFormat`: thay đổi cách các slide được biểu diễn, ví dụ dưới dạng SVG.
- `PicturesCompression`: kiểm soát DPI hình ảnh và kích thước đầu ra.
- `DeletePicturesCroppedAreas`: giữ hoặc xóa dữ liệu hình ảnh đã cắt.
- `SvgResponsiveLayout`: làm cho nội dung SVG được xuất thích nghi với vùng chứa của nó.
- `ShowHiddenSlides`: bao gồm các slide ẩn khi cần.

Các phần sau đây hiển thị các tùy chọn phổ biến nhất riêng biệt để bạn có thể kết hợp chỉ những tùy chọn cần thiết cho quy trình của mình.

## **Chuyển đổi các slide đã chọn sang HTML**

Phương thức `Presentation.save` cho phép truyền số slide sử dụng vị trí slide tính từ 1. Vòng lặp dưới đây lưu mỗi slide vào một tệp HTML riêng.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Sử dụng mẫu này khi một website hoặc ứng dụng cần một trang HTML cho mỗi slide. Nếu mỗi slide cần cùng một bố cục, hãy tạo một thể hiện [HtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/) và truyền nó vào mỗi lời gọi `save`.

## **Tạo HTML đáp ứng**

[ResponsiveHtmlController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/responsivehtmlcontroller/) cung cấp đầu ra HTML đáp ứng thông qua [HtmlFormatter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmlformatter/). Sử dụng nó khi trang xuất cần thích nghi tốt hơn với độ rộng trình duyệt.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Đối với bố cục đáp ứng dựa trên SVG, đặt `SvgResponsiveLayout` trên [HtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/). Điều này hữu ích khi nội dung slide được xuất dưới dạng markup SVG có thể mở rộng.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Bao gồm ghi chú người thuyết trình và bình luận**

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) qua `HtmlOptions.SlidesLayoutOptions` để bao gồm ghi chú người thuyết trình hoặc bình luận. Ghi chú và bình luận bị ẩn theo mặc định trừ khi bạn chọn vị trí của chúng.

Giả sử bản trình chiếu nguồn chứa ghi chú người thuyết trình:

![Slide có ghi chú người thuyết trình trong PowerPoint](slide_with_notes.png)

Mã dưới đây xuất nội dung slide kèm ghi chú người thuyết trình bên dưới slide.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

HTML được xuất bao gồm khu vực ghi chú:

![Kết quả HTML với slide và ghi chú người thuyết trình](HTML_with_notes.png)

Để xuất bình luận, đặt `CommentsPosition`, ví dụ `CommentsPositions.Right` hoặc `CommentsPositions.Bottom`. Nếu chỉ cần bình luận, bỏ qua `NotesPosition`. Nếu cần cả ghi chú và bình luận, đặt cả hai thuộc tính.

## **Kiểm soát chất lượng hình ảnh và các khu vực đã cắt**

Xuất HTML có thể nén hình ảnh slide để giảm kích thước đầu ra. Đặt `PicturesCompression` thành một giá trị từ [PicturesCompression](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/picturescompression/) khi bạn cần chất lượng hình ảnh cao hơn.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Theo mặc định, các khu vực đã cắt của hình ảnh có thể bị loại bỏ khỏi đầu ra được xuất. Giữ dữ liệu đã cắt chỉ khi người dùng cần khôi phục hoặc kiểm tra các phần hình ảnh ẩn đó. Giữ lại có thể làm tăng kích thước HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Thêm CSS**

Đối với việc tạo kiểu đơn giản, truyền một chuỗi CSS vào `HtmlFormatter.createDocumentFormatter`. Điều này thay đổi tài liệu HTML bao quanh trong khi Aspose.Slides vẫn tiếp tục render nội dung slide.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Đối với tiêu đề tài liệu tùy chỉnh, tệp CSS liên kết hoặc markup tùy chỉnh xung quanh slide và shape, triển khai [IHtmlFormattingController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihtmlformattingcontroller/) và truyền nó vào [HtmlFormatter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmlformatter/) bằng `createCustomFormatter`.

## **Nhúng phông chữ**

Nếu môi trường đích có thể không có sẵn các phông chữ của bản trình chiếu, hãy nhúng phông chữ vào HTML bằng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). Nhúng cải thiện độ trung thực hình ảnh nhưng làm tăng kích thước đầu ra.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Loại trừ phông chữ chỉ khi bạn chắc chắn rằng các trình duyệt hoặc hệ thống đích đã cung cấp chúng. Đối với phông chữ thương hiệu hoặc phông chữ ít phổ biến, việc nhúng thường an toàn hơn.

## **Liên kết tệp phông chữ thay vì nhúng chúng**

Để giảm kích thước tệp HTML, bạn có thể ghi dữ liệu phông chữ vào các tệp WOFF riêng và thêm quy tắc `@font-face` vào HTML. Trợ giúp dưới đây mở rộng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) và ghi đè `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Trong ví dụ này, các tệp phông chữ được lưu vào `html-output/fonts`, và HTML tham chiếu chúng bằng các URL như `fonts/BrandFont-normal-400.woff`. Nếu tệp HTML và phông chữ được triển khai ở vị trí khác, chọn `fontUrlPrefix` sao cho phù hợp với đường dẫn URL đã triển khai.

## **Lưu tài nguyên bên ngoài**

HTML độc lập dễ di chuyển, nhưng các tài nguyên Base64 được nhúng có thể làm tệp lớn. Nếu ứng dụng của bạn cần các tệp hình ảnh bên ngoài, hãy triển khai [ILinkEmbedController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinkembedcontroller/) và truyền nó vào hàm tạo [HtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/).

Khi bạn tách tài nguyên ra bên ngoài, hãy lựa chọn hai đường dẫn một cách cố ý:

- Đường dẫn đầu ra hệ thống tệp, nơi ứng dụng của bạn ghi các hình ảnh, phông chữ, âm thanh hoặc video được tạo.
- Đường dẫn URL, là đường mà trình duyệt sử dụng từ tài liệu HTML để tải các tệp đó.

## **Xuất tệp media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) xuất các tệp video và âm thanh và ghi HTML cho phép chúng chạy trong trình duyệt. Hàm tạo của nó nhận:

- `path`: thư mục nơi các tệp media được tạo sẽ được ghi.
- `fileName`: tên tệp HTML đang được tạo.
- `baseUri`: tiền tố URI tuyệt đối được sử dụng trong các liên kết HTML tới tệp media.

Nếu tệp HTML là `html-output/presentation.html` và các tệp media được lưu trong `html-output/media`, `path` nên trỏ tới thư mục media trên đĩa, trong khi `baseUri` nên trỏ tới cùng thư mục từ quan điểm của trình duyệt. Đối với việc xem trước cục bộ, bạn có thể tạo URI `file:///` từ thư mục media. Đối với ứng dụng đã triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Sử dụng các thư mục đầu ra duy nhất cho mỗi công việc xuất, đặc biệt trong các ứng dụng máy chủ. Các đường dẫn đầu ra chung có thể khiến các tệp từ các lần chuyển đổi khác nhau ghi đè lên nhau.

## **Hiệu suất và quản lý tài nguyên**

Chuyển đổi HTML là một thao tác render, do đó thời gian xử lý và sử dụng bộ nhớ phụ thuộc vào số slide, độ phân giải hình ảnh, phông chữ, hiệu ứng, biểu đồ và media được nhúng. Các giá trị DPI `PicturesCompression` cao hơn, phông chữ được nhúng, đầu ra SVG và việc giữ lại các khu vực hình ảnh đã cắt có thể cải thiện độ trung thực nhưng thường tăng kích thước đầu ra.

Đối với chuyển đổi hàng loạt:

- Giải phóng nhanh mọi thể hiện [Presentation] ngay khi không còn dùng.
- Sử dụng các thư mục đầu ra riêng biệt cho các công việc riêng.
- Tránh nhúng các phông chữ phổ biến trừ khi cần độ trung thực cao.
- Giảm DPI hình ảnh khi HTML chỉ dùng để xem trước hoặc làm hình thu nhỏ.
- Giữ bản trình chiếu nguồn, HTML đã tạo và các tài nguyên bên ngoài cùng nhau cho tới khi các đường dẫn triển khai được xác định.

## **Câu hỏi thường gặp**

**Liệu các siêu liên kết có được giữ lại trong đầu ra HTML không?**

Có. Các siêu liên kết trong bản trình chiếu được xuất ra HTML và vẫn có thể nhấp được khi URL mục tiêu hợp lệ.

**Tôi có thể chuyển đổi các bản trình chiếu sang HTML song song không?**

Có, nhưng không chia sẻ một thể hiện [Presentation] giữa các luồng. Xử lý các tệp khác nhau với các thể hiện presentation riêng biệt, các stream riêng và các thư mục đầu ra riêng. Xem hướng dẫn [multithreading guidance](/slides/vi/androidjava/multithreading/) để biết chi tiết.

**Đối tượng Presentation có an toàn với đa luồng không?**

Không. Một thể hiện [Presentation] duy nhất nên được tải, sửa đổi, lưu và giải phóng trên một luồng. Đối với công việc song song, tạo một thể hiện độc lập cho mỗi luồng hoặc mỗi tiến trình.

**Tại sao tệp HTML được tạo ra lại lớn?**

Mặc định, xuất có thể nhúng tài nguyên trực tiếp vào HTML. Các phông chữ được nhúng, hình ảnh DPI cao, media, nội dung SVG và việc giữ lại các khu vực hình ảnh đã cắt cũng làm tăng kích thước. Sử dụng tài nguyên bên ngoài, loại trừ phông chữ chung khỏi việc nhúng và giảm `PicturesCompression` khi kích thước nhỏ hơn quan trọng hơn độ trung thực tối đa.

**Tại sao kích thước phông chữ PowerPoint như 24 pt lại hiển thị là 17.999819 pt trong HTML?**

Điều này có thể xảy ra vì PowerPoint và HTML sử dụng các mô hình DPI khác nhau. PowerPoint lưu kích thước văn bản theo điểm kiểu chữ dựa trên 72 DPI, trong khi bố cục HTML dựa trên pixel CSS trong mô hình 96 DPI. Khi Aspose.Slides xuất bản trình chiếu sang HTML, kích thước phông chữ được dịch giữa hai hệ thống này và quá trình chuyển đổi có thể gây ra sự chênh lệch làm tròn nhỏ.

Các giá trị này không cho thấy sự thay đổi thực tế về kích thước phông chữ trên giao diện. Chúng chỉ là hiệu ứng toán học phụ khi chuyển đổi số liệu văn bản giữa PowerPoint và HTML.

**Làm thế nào để chọn baseUri cho việc xuất media?**

Chọn `baseUri` từ quan điểm của trình duyệt và truyền nó dưới dạng URI tuyệt đối. Đối với việc xem trước cục bộ, bạn có thể xây dựng nó từ thư mục đầu ra bằng `mediaDirectory.toUri().toString()`. Đối với triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố. Đường dẫn hệ thống `path` và `baseUri` của trình duyệt không cần phải là cùng một chuỗi, nhưng chúng phải mô tả cùng một vị trí tài nguyên.

**Tôi có thể bao gồm các slide ẩn không?**

Có. Đặt `ShowHiddenSlides` thành `true` trên [HtmlOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/) khi cần xuất các slide ẩn.