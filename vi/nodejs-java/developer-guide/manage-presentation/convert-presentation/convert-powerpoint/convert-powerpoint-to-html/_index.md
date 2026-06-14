---
title: Chuyển đổi bản trình bày PowerPoint sang HTML trong Node.js
linktitle: PowerPoint sang HTML
type: docs
weight: 30
url: /vi/nodejs-java/convert-powerpoint-to-html/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang HTML
- bản trình bày sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- lưu PowerPoint dưới dạng HTML
- lưu bản trình bày dưới dạng HTML
- lưu slide dưới dạng HTML
- lưu PPT dưới dạng HTML
- lưu PPTX dưới dạng HTML
- xuất PPT sang HTML
- xuất PPTX sang HTML
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi bản trình bày PowerPoint sang HTML trong Node.js. Sử dụng Aspose.Slides cho Node.js qua Java để xuất các tệp PPT và PPTX, slide đã chọn, ghi chú, phông chữ, hình ảnh, SVG và media."
---
## **Tổng quan**

Aspose.Slides cho Node.js qua Java có thể lưu các bản trình bày PowerPoint dưới dạng HTML mà không cần Microsoft PowerPoint. Quá trình chuyển đổi cơ bản chỉ gồm một lần tải [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và một lời gọi `save` với [SaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/). Sử dụng [HtmlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/) khi cần kiểm soát bố cục, phông chữ, hình ảnh, ghi chú, bình luận, đầu ra SVG hoặc các tài nguyên được liên kết.

Hướng dẫn này tập trung vào các kịch bản xuất HTML thực tế:

- Xuất toàn bộ bản trình bày hoặc các slide đã chọn.
- Tạo HTML cố định, đáp ứng hoặc dựa trên SVG.
- Bao gồm ghi chú diễn giả và bình luận.
- Kiểm soát chất lượng hình ảnh và dữ liệu ảnh đã cắt.
- Nhúng phông chữ hoặc lưu các tệp phông chữ riêng biệt.
- Chọn cách ghi và tham chiếu các tài nguyên bên ngoài và tệp media.

Mặc định, xuất HTML tạo ra một tài liệu HTML tự chứa, trong đó hầu hết tài nguyên được nhúng. Điều này tiện lợi để chia sẻ một tệp duy nhất, nhưng có thể làm tăng kích thước đầu ra. Đối với việc xuất bản trên web, hãy cân nhắc sử dụng tài nguyên bên ngoài, giảm DPI hình ảnh và chỉ nhúng các phông chữ không có sẵn đáng tin cậy trong môi trường đích.

## **Chuyển đổi bản trình bày sang HTML**

Để xuất bản trình bày sang HTML, tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và lưu bằng [SaveFormat.Html](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Ví dụ này ghi một tệp HTML. Đối tượng presentation được giải phóng trong khối `finally`, giải phóng các handle tệp và tài nguyên render sau khi xuất.

## **Sử dụng HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/) là lớp cấu hình chính cho việc xuất HTML. Các thiết lập phổ biến bao gồm:

- `SlidesLayoutOptions`: thêm ghi chú, bình luận, tài liệu phát tay hoặc các thông tin bố cục khác.
- `HtmlFormatter`: thay đổi cấu trúc tài liệu HTML hoặc ủy quyền định dạng cho một controller.
- `SlideImageFormat`: thay đổi cách biểu diễn slide, ví dụ dưới dạng SVG.
- `PicturesCompression`: kiểm soát DPI ảnh và kích thước đầu ra.
- `DeletePicturesCroppedAreas`: giữ hoặc loại bỏ dữ liệu ảnh đã cắt.
- `SvgResponsiveLayout`: làm cho nội dung SVG xuất ra thích ứng với container.
- `ShowHiddenSlides`: bao gồm các slide ẩn khi cần.

Các phần sau đây trình bày các tùy chọn phổ biến nhất riêng biệt để bạn chỉ kết hợp những tùy chọn cần thiết cho quy trình làm việc của mình.

## **Chuyển đổi các slide đã chọn sang HTML**

Phương thức `Presentation.save` có overload nhận số thứ tự slide sử dụng vị trí slide bắt đầu từ 1. Vòng lặp dưới đây lưu mỗi slide vào một tệp HTML riêng.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Sử dụng mẫu này khi một trang web hoặc ứng dụng cần một trang HTML cho mỗi slide. Nếu mỗi slide có cùng bố cục, tạo một thể hiện [HtmlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/) và truyền nó cho mỗi lời gọi `save`.

## **Tạo HTML đáp ứng**

[ResponsiveHtmlController](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/responsivehtmlcontroller/) cung cấp đầu ra HTML đáp ứng thông qua [HtmlFormatter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmlformatter/). Sử dụng nó khi trang xuất ra cần thích nghi tốt hơn với chiều rộng trình duyệt.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Đối với bố cục đáp ứng dựa trên SVG, đặt `SvgResponsiveLayout` trên [HtmlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/). Điều này hữu ích khi nội dung slide được xuất dưới dạng markup SVG có thể mở rộng.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Bao gồm ghi chú diễn giả và bình luận**

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) qua `HtmlOptions.setSlidesLayoutOptions` để bao gồm ghi chú diễn giả hoặc bình luận. Ghi chú và bình luận mặc định bị ẩn trừ khi bạn chỉ định vị trí của chúng.

Giả sử bản trình bày nguồn chứa ghi chú diễn giả:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Mã sau xuất nội dung slide cùng với ghi chú diễn giả nằm dưới slide.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

HTML đã xuất bao gồm khu vực ghi chú:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Để xuất bình luận, đặt `CommentsPosition`, ví dụ `CommentsPositions.Right` hoặc `CommentsPositions.Bottom`. Nếu chỉ cần bình luận, bỏ qua `NotesPosition`. Nếu cần cả ghi chú và bình luận, đặt cả hai thuộc tính.

## **Kiểm soát chất lượng hình ảnh và khu vực đã cắt**

Xuất HTML có thể nén ảnh slide để giảm kích thước đầu ra. Đặt `PicturesCompression` thành một giá trị từ [PicturesCompression](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturescompression/) khi cần chất lượng hình ảnh cao hơn.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Mặc định, các khu vực đã cắt của ảnh có thể bị loại bỏ khỏi đầu ra đã xuất. Giữ lại dữ liệu đã cắt chỉ khi người dùng cần phục hồi hoặc kiểm tra các phần ảnh ẩn đó. Việc giữ lại có thể làm tăng kích thước HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Thêm CSS**

Đối với việc tạo kiểu đơn giản, truyền một chuỗi CSS cho `HtmlFormatter.createDocumentFormatter`. Điều này thay đổi tài liệu HTML bao quanh trong khi Aspose.Slides vẫn tiếp tục render nội dung slide.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Đối với tiêu đề tài liệu tùy chỉnh, tệp CSS liên kết, hoặc markup tùy chỉnh xung quanh slide và shape, sử dụng [HtmlFormatter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmlformatter/) cùng một controller định dạng.

## **Nhúng phông chữ**

Nếu môi trường đích có thể không có các phông chữ của bản trình bày được cài đặt, nhúng phông chữ vào HTML bằng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Việc nhúng cải thiện độ trung thực hình ảnh nhưng làm tăng kích thước đầu ra.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Loại bỏ phông chữ chỉ khi bạn chắc chắn rằng các trình duyệt hoặc hệ thống đích đã cung cấp chúng. Đối với phông chữ thương hiệu hoặc các phông chữ ít phổ biến, việc nhúng thường an toàn hơn.

## **Liên kết tệp phông chữ thay vì nhúng**

Để giảm kích thước tệp HTML, bạn có thể ghi dữ liệu phông chữ vào các tệp WOFF riêng biệt và thêm các quy tắc `@font-face` vào HTML. Trong Node.js qua Java, kịch bản này thường được triển khai bằng một lớp trợ giúp Java nhỏ mở rộng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), ghi byte phông chữ vào thư mục đầu ra và chèn các quy tắc `@font-face` vào HTML được tạo. Biên dịch lớp trợ giúp đó, thêm vào classpath của mô-đun Node.js, sau đó khởi tạo nó từ JavaScript bằng `java.newInstanceSync`.

Khi xây dựng trợ giúp này, hãy chọn hai đường dẫn một cách có chủ ý:

- Đường dẫn đầu ra hệ thống tập tin, nơi các tệp phông chữ được ghi.
- Đường dẫn URL, là đường mà trình duyệt sử dụng từ tài liệu HTML để tải các tệp phông chữ đó.

## **Lưu tài nguyên bên ngoài**

HTML tự chứa dễ di chuyển, nhưng các tài nguyên Base64 được nhúng có thể làm tệp trở nên lớn. Nếu ứng dụng của bạn cần các tệp ảnh, phông chữ, âm thanh hoặc video bên ngoài, hãy sử dụng một controller xuất mà ghi tài nguyên vào thư mục đã chọn và tạo các URL có thể truy cập từ trình duyệt. Giữ cho đường dẫn hệ thống tập tin và đường dẫn URL đồng nhất với bố trí triển khai của bạn.

## **Xuất tệp media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) xuất các tệp video và âm thanh và viết HTML có thể phát chúng trong trình duyệt. Constructor của nó nhận:

- `path`: thư mục nơi các tệp media được tạo sẽ được ghi.
- `fileName`: tên tệp HTML đang được tạo.
- `baseUri`: tiền tố URI tuyệt đối được dùng trong các liên kết HTML tới tệp media.

Nếu tệp HTML là `html-output/presentation.html` và các tệp media được lưu trong `html-output/media`, `path` nên trỏ tới thư mục media trên đĩa, trong khi `baseUri` nên trỏ đến cùng thư mục từ góc nhìn của trình duyệt. Đối với xem thử cục bộ, bạn có thể tạo một URI `file:///` từ thư mục media. Đối với ứng dụng đã triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Sử dụng các thư mục đầu ra độc đáo cho mỗi công việc xuất, đặc biệt trong các ứng dụng server. Các đường dẫn đầu ra chung có thể gây ghi đè lẫn nhau giữa các lần chuyển đổi khác nhau.

## **Hiệu năng và quản lý tài nguyên**

Chuyển đổi HTML là một thao tác render, vì vậy thời gian xử lý và mức bộ nhớ phụ thuộc vào số slide, độ phân giải ảnh, phông chữ, hiệu ứng, biểu đồ và media được nhúng. Các giá trị DPI `PicturesCompression` cao hơn, phông chữ nhúng, đầu ra SVG và việc giữ lại các khu vực ảnh đã cắt có thể cải thiện độ trung thực nhưng thường làm tăng kích thước đầu ra.

Đối với chuyển đổi hàng loạt:

- Giải phóng ngay mỗi thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) khi không còn cần.
- Sử dụng các thư mục đầu ra riêng cho các công việc riêng biệt.
- Tránh nhúng các phông chữ chung trừ khi độ trung thực yêu cầu.
- Giảm DPI ảnh khi HTML chỉ dùng để xem trước hoặc làm thumbnail.
- Giữ bản trình bày nguồn, HTML đã tạo và các tài nguyên bên ngoài cùng nhau cho tới khi các đường dẫn triển khai cuối cùng được xác định.

## **FAQ**

**Liên kết siêu văn bản có được giữ lại trong đầu ra HTML không?**

Có. Các liên kết siêu văn bản trong bản trình bày được xuất sang HTML và vẫn có thể nhấp được khi URL đích hợp lệ.

**Tôi có thể chuyển đổi nhiều bản trình bày sang HTML đồng thời không?**

Có, nhưng không chia sẻ một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) giữa các worker. Xử lý các tệp khác nhau với các thể hiện presentation riêng, luồng riêng và thư mục xuất riêng. Xem hướng dẫn [multithreading guidance](/slides/vi/nodejs-java/multithreading/) để biết chi tiết.

**Đối tượng Presentation có thread-safe không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) duy nhất nên được tải, chỉnh sửa, lưu và giải phóng trong cùng một worker. Đối với công việc song song, tạo một thể hiện độc lập cho mỗi worker hoặc mỗi tiến trình.

**Tại sao tệp HTML được tạo ra lại lớn?**

Mặc định, xuất có thể nhúng tài nguyên trực tiếp vào HTML. Các phông chữ nhúng, ảnh DPI cao, media, nội dung SVG và việc giữ lại các khu vực ảnh đã cắt đều làm tăng kích thước. Sử dụng tài nguyên bên ngoài, loại bỏ các phông chữ phổ biến khỏi việc nhúng và giảm `PicturesCompression` khi độ nhỏ hơn quan trọng hơn độ trung thực tối đa.

**Tại sao kích thước phông chữ trong PowerPoint như 24 pt lại xuất hiện là 17.999819 pt trong HTML?**

Điều này có thể xảy ra vì PowerPoint và HTML sử dụng các mô hình DPI khác nhau. PowerPoint lưu kích thước văn bản bằng điểm typographic dựa trên 72 DPI, trong khi bố cục HTML dựa trên pixel CSS theo mô hình 96 DPI. Khi Aspose.Slides xuất bản trình bày sang HTML, kích thước phông chữ được chuyển đổi giữa hai hệ thống, và quá trình chuyển đổi có thể gây ra sự chênh lệch làm tròn nhỏ.

Các giá trị này không cho thấy sự thay đổi thực tế về kích thước phông chữ trên màn hình. Chúng chỉ là hiệu ứng toán học khi chuyển đổi các chỉ số văn bản giữa PowerPoint và HTML.

**Làm thế nào để chọn baseUri cho việc xuất media?**

Chọn `baseUri` dựa trên góc nhìn của trình duyệt và truyền nó dưới dạng URI tuyệt đối. Đối với xem trước cục bộ, bạn có thể tạo nó từ thư mục đầu ra bằng một URI `file:///`. Đối với triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố. Đường dẫn hệ thống `path` và `baseUri` của trình duyệt không nhất thiết phải là cùng một chuỗi, nhưng chúng phải mô tả cùng một vị trí tài nguyên.

**Tôi có thể bao gồm các slide ẩn không?**

Có. Đặt `ShowHiddenSlides` thành `true` trên [HtmlOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/) khi cần xuất các slide ẩn.