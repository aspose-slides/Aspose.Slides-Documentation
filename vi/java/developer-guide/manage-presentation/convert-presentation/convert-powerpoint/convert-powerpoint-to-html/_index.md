---
title: Chuyển đổi bản trình chiếu PowerPoint sang HTML trong Java
linktitle: PowerPoint sang HTML
type: docs
weight: 30
url: /vi/java/convert-powerpoint-to-html/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang HTML
- bản trình chiếu sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- lưu PowerPoint dưới dạng HTML
- lưu bản trình chiếu dưới dạng HTML
- lưu slide dưới dạng HTML
- lưu PPT dưới dạng HTML
- lưu PPTX dưới dạng HTML
- xuất PPT sang HTML
- xuất PPTX sang HTML
- Java
- Aspose.Slides
description: "Chuyển đổi bản trình chiếu PowerPoint sang HTML trong Java. Sử dụng Aspose.Slides để xuất các tệp PPT và PPTX, các slide đã chọn, ghi chú, phông chữ, hình ảnh, SVG và media."
---
## **Tổng quan**

Aspose.Slides for Java có thể lưu các bản thuyết trình PowerPoint dưới dạng HTML mà không cần Microsoft PowerPoint. Việc chuyển đổi cơ bản chỉ là tải một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và gọi `save` với [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/). Sử dụng [HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/) khi bạn cần kiểm soát bố cục xuất, phông chữ, hình ảnh, ghi chú, bình luận, đầu ra SVG hoặc các tài nguyên liên kết.

Hướng dẫn này tập trung vào các kịch bản xuất HTML thực tế:

- Xuất toàn bộ bản thuyết trình hoặc các slide đã chọn.
- Tạo HTML có bố cục cố định, đáp ứng hoặc dựa trên SVG.
- Bao gồm ghi chú người thuyết trình và bình luận.
- Kiểm soát chất lượng hình ảnh và dữ liệu hình ảnh đã cắt.
- Nhúng phông chữ hoặc lưu các tệp phông chữ riêng.
- Chọn cách ghi và tham chiếu các tài nguyên và tệp media bên ngoài.

Mặc định, xuất HTML tạo một tài liệu HTML tự chứa, trong đó hầu hết các tài nguyên được nhúng. Điều này thuận tiện cho việc chia sẻ một tệp, nhưng có thể làm tăng kích thước đầu ra. Đối với việc công bố trên web, hãy cân nhắc sử dụng tài nguyên bên ngoài, giảm DPI của hình ảnh và chỉ nhúng các phông chữ không có sẵn đáng tin cậy trong môi trường mục tiêu.

## **Chuyển đổi một bản thuyết trình sang HTML**

Để xuất một bản thuyết trình sang HTML, tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và lưu bằng [SaveFormat.Html](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Ví dụ này ghi một tệp HTML. Đối tượng presentation được giải phóng trong khối `finally`, giúp giải phóng các handle tệp và tài nguyên render sau khi xuất.

## **Sử dụng HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/) là lớp cấu hình chính cho việc xuất HTML. Các cài đặt phổ biến bao gồm:

- `SlidesLayoutOptions`: thêm ghi chú, bình luận, tài liệu phát tay hoặc các thông tin bố cục khác.
- `HtmlFormatter`: thay đổi cấu trúc tài liệu HTML hoặc ủy quyền định dạng cho một controller.
- `SlideImageFormat`: thay đổi cách biểu diễn slide, ví dụ dưới dạng SVG.
- `PicturesCompression`: kiểm soát DPI của hình ảnh và kích thước đầu ra.
- `DeletePicturesCroppedAreas`: giữ hoặc xóa dữ liệu hình ảnh đã cắt.
- `SvgResponsiveLayout`: làm cho nội dung SVG xuất ra thích ứng với container của nó.
- `ShowHiddenSlides`: bao gồm các slide ẩn khi cần.

Các phần sau đây trình bày các tùy chọn phổ biến nhất riêng biệt để bạn có thể kết hợp chỉ những tùy chọn cần thiết cho quy trình làm việc của mình.

## **Chuyển đổi các slide đã chọn sang HTML**

Phương thức `Presentation.save` có tham số chấp nhận số slide sử dụng vị trí slide bắt đầu từ 1. Vòng lặp dưới đây lưu mỗi slide vào một tệp HTML riêng.

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

Sử dụng mẫu này khi một trang web hoặc ứng dụng cần một trang HTML cho mỗi slide. Nếu mỗi slide cần cùng một bố cục, tạo một thể hiện [HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/) và truyền nó vào mỗi lời gọi `save`.

## **Tạo HTML đáp ứng**

[ResponsiveHtmlController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/responsivehtmlcontroller/) cung cấp đầu ra HTML đáp ứng thông qua [HtmlFormatter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmlformatter/). Sử dụng nó khi trang xuất ra cần thích nghi tốt hơn với độ rộng trình duyệt.

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

Đối với bố cục đáp ứng dựa trên SVG, đặt `SvgResponsiveLayout` trên [HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/). Điều này hữu ích khi nội dung slide được xuất dưới dạng markup SVG có khả năng mở rộng.

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

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/) qua `HtmlOptions.setSlidesLayoutOptions` để bao gồm ghi chú hoặc bình luận. Mặc định, ghi chú và bình luận bị ẩn trừ khi bạn chỉ định vị trí của chúng.

Giả sử bản thuyết trình nguồn chứa ghi chú người thuyết trình:

![Slide có ghi chú người thuyết trình trong PowerPoint](slide_with_notes.png)

Đoạn mã sau xuất nội dung slide cùng ghi chú người thuyết trình phía dưới slide.

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

HTML đã xuất bao gồm khu vực ghi chú:

![Kết quả HTML với slide và ghi chú người thuyết trình](HTML_with_notes.png)

Để xuất bình luận, đặt `CommentsPosition`, ví dụ `CommentsPositions.Right` hoặc `CommentsPositions.Bottom`. Nếu bạn chỉ cần bình luận, bỏ qua `NotesPosition`. Nếu cần cả ghi chú và bình luận, đặt cả hai thuộc tính.

## **Kiểm soát chất lượng hình ảnh và khu vực đã cắt**

Xuất HTML có thể nén hình ảnh slide để giảm kích thước đầu ra. Đặt `PicturesCompression` thành một giá trị từ [PicturesCompression](https://reference.aspose.com/slides/vi/java/com.aspose.slides/picturescompression/) khi bạn cần chất lượng hình ảnh cao hơn.

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

Mặc định, các khu vực đã cắt của hình ảnh có thể bị loại bỏ khỏi đầu ra đã xuất. Giữ lại dữ liệu đã cắt chỉ khi người dùng cần khôi phục hoặc kiểm tra các phần hình ảnh ẩn đó. Việc giữ lại có thể làm tăng kích thước HTML.

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

Đối với việc tạo kiểu đơn giản, truyền một chuỗi CSS vào `HtmlFormatter.createDocumentFormatter`. Điều này thay đổi tài liệu HTML xung quanh trong khi Aspose.Slides vẫn tiếp tục render nội dung slide.

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

Đối với tiêu đề tài liệu tùy chỉnh, tệp CSS liên kết hoặc markup tùy chỉnh quanh các slide và shape, triển khai [IHtmlFormattingController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihtmlformattingcontroller/) và truyền nó vào [HtmlFormatter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmlformatter/) bằng `createCustomFormatter`.

## **Nhúng phông chữ**

Nếu môi trường mục tiêu có thể không cài đặt các phông chữ của bản thuyết trình, hãy nhúng phông chữ trong HTML bằng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/embedallfontshtmlcontroller/). Việc nhúng cải thiện độ trung thực hình ảnh nhưng tăng kích thước đầu ra.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Loại bỏ phông chữ chỉ khi bạn chắc chắn rằng các trình duyệt hoặc hệ thống mục tiêu đã cung cấp chúng. Đối với phông chữ thương hiệu hoặc các phông chữ ít phổ biến, việc nhúng thường an toàn hơn.

## **Liên kết tệp phông chữ thay vì nhúng**

Để giảm kích thước tệp HTML, bạn có thể ghi dữ liệu phông chữ vào các tệp WOFF riêng và thêm các quy tắc `@font-face` vào HTML. Trợ giúp dưới đây mở rộng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/embedallfontshtmlcontroller/) và ghi đè `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
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
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

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

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Trong ví dụ này, các tệp phông chữ được lưu vào `html-output/fonts`, và HTML tham chiếu chúng bằng các URL như `fonts/BrandFont-normal-400.woff`. Nếu tệp HTML và phông chữ được triển khai ở vị trí khác, hãy chọn `fontUrlPrefix` sao cho khớp với đường dẫn URL đã triển khai.

## **Lưu tài nguyên bên ngoài**

HTML tự chứa dễ di chuyển, nhưng các tài nguyên Base64 được nhúng có thể làm tệp lớn. Nếu ứng dụng của bạn cần các tệp hình ảnh bên ngoài, triển khai [ILinkEmbedController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) và truyền nó vào hàm khởi tạo [HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/).

Khi bạn tách tài nguyên ra bên ngoài, hãy chọn hai đường dẫn một cách có chủ ý:

- Đường dẫn đầu ra trên hệ thống tệp, nơi ứng dụng của bạn ghi các hình ảnh, phông chữ, âm thanh hoặc video được tạo.
- Đường dẫn URL, là gì trình duyệt sẽ sử dụng từ tài liệu HTML để tải các tệp đó.

## **Xuất tệp media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/videoplayerhtmlcontroller/) xuất các tệp video và audio và ghi HTML cho phép chúng phát trong trình duyệt. Hàm khởi tạo của nó nhận:

- `path`: thư mục mà các tệp media được tạo sẽ được ghi.
- `fileName`: tên tệp HTML đang được tạo.
- `baseUri`: tiền tố URI tuyệt đối được sử dụng trong các liên kết HTML tới các tệp media.

Nếu tệp HTML là `html-output/presentation.html` và các tệp media được lưu trong `html-output/media`, `path` nên trỏ tới thư mục media trên đĩa, trong khi `baseUri` nên trỏ tới cùng thư mục từ quan điểm của trình duyệt. Đối với xem trước cục bộ, bạn có thể xây dựng một URI `file:///` từ thư mục media. Đối với ứng dụng đã triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Sử dụng các thư mục đầu ra độc nhất cho mỗi công việc xuất, đặc biệt trong các ứng dụng máy chủ. Các đường dẫn đầu ra chia sẻ có thể gây ghi đè các tệp từ các chuyển đổi khác nhau.

## **Hiệu năng và quản lý tài nguyên**

Chuyển đổi HTML là một thao tác render, vì vậy thời gian xử lý và sử dụng bộ nhớ phụ thuộc vào số slide, độ phân giải hình ảnh, phông chữ, hiệu ứng, biểu đồ và media được nhúng. Giá trị DPI cao hơn của `PicturesCompression`, phông chữ được nhúng, đầu ra SVG và giữ lại các khu vực hình ảnh đã cắt có thể cải thiện độ trung thực nhưng thường làm tăng kích thước đầu ra.

Đối với chuyển đổi hàng loạt:

- Giải phóng ngay mọi thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) sau khi dùng.
- Sử dụng các thư mục đầu ra riêng cho các công việc riêng.
- Tránh nhúng các phông chữ chung trừ khi độ trung thực yêu cầu.
- Giảm DPI hình ảnh khi HTML chỉ dùng để xem trước hoặc làm thumbnail.
- Giữ bản thuyết trình nguồn, HTML đã tạo và các tài nguyên bên ngoài cùng nhau cho đến khi đường dẫn triển khai cuối cùng được xác định.

## **Câu hỏi thường gặp**

**Liên kết có được giữ trong đầu ra HTML không?**

Có. Các liên kết trong bản thuyết trình được xuất sang HTML và vẫn có thể nhấp được khi URL đích hợp lệ.

**Tôi có thể chuyển đổi các bản thuyết trình sang HTML đồng thời không?**

Có, nhưng không chia sẻ một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) giữa các luồng. Xử lý các tệp khác nhau với các thể hiện presentation riêng, các stream riêng và các thư mục đầu ra riêng. Xem hướng dẫn [multithreading guidance](/slides/vi/java/multithreading/) để biết chi tiết.

**Đối tượng Presentation có an toàn với đa luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) nên được tải, sửa đổi, lưu và giải phóng trên cùng một luồng. Đối với công việc song song, tạo một thể hiện độc lập cho mỗi luồng hoặc quy trình.

**Tại sao tệp HTML được tạo ra lại lớn?**

Mặc định, quá trình xuất có thể nhúng tài nguyên trực tiếp vào HTML. Các phông chữ được nhúng, hình ảnh DPI cao, media, nội dung SVG và việc giữ lại các khu vực hình ảnh đã cắt cũng làm tăng kích thước. Hãy sử dụng tài nguyên bên ngoài, loại bỏ việc nhúng các phông chữ phổ biến và giảm `PicturesCompression` khi kích thước nhỏ hơn là ưu tiên hơn độ trung thực tối đa.

**Tại sao kích thước phông chữ trong PowerPoint như 24 pt lại xuất hiện là 17.999819 pt trong HTML?**

Điều này có thể xảy ra vì PowerPoint và HTML sử dụng mô hình DPI khác nhau. PowerPoint lưu kích thước văn bản theo điểm chữ dựa trên 72 DPI, trong khi bố cục HTML dựa trên pixel CSS trong mô hình 96 DPI. Khi Aspose.Slides xuất bản thuyết trình sang HTML, kích thước phông chữ được dịch giữa hai hệ thống này và quá trình chuyển đổi có thể gây ra một số sai số làm tròn nhỏ.

Các giá trị này không cho thấy sự thay đổi thực tế về kích thước phông chữ trên giao diện. Chúng chỉ là một hiệu ứng toán học phụ khi chuyển đổi các chỉ số văn bản giữa PowerPoint và HTML.

**Làm sao để chọn baseUri cho việc xuất media?**

Chọn `baseUri` dựa trên quan điểm của trình duyệt và truyền nó dưới dạng URI tuyệt đối. Đối với xem trước cục bộ, bạn có thể suy ra nó từ thư mục đầu ra bằng `mediaDirectory.toUri().toString()`. Đối với triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố. Đường dẫn hệ thống `path` và `baseUri` của trình duyệt không cần phải là cùng một chuỗi, nhưng chúng phải mô tả cùng một vị trí tài nguyên.

**Tôi có thể bao gồm các slide ẩn không?**

Có. Đặt `ShowHiddenSlides` thành `true` trên [HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/) khi các slide ẩn cần được xuất.