---
title: Chuyển đổi bản trình chiếu PowerPoint sang HTML trong PHP
linktitle: PowerPoint sang HTML
type: docs
weight: 30
url: /vi/php-java/convert-powerpoint-to-html/
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
- PHP
- Aspose.Slides
description: "Chuyển đổi bản trình chiếu PowerPoint sang HTML trong PHP. Sử dụng Aspose.Slides để xuất các tệp PPT và PPTX, các slide đã chọn, ghi chú, phông chữ, hình ảnh, SVG và phương tiện."
---
## **Tổng quan**

Aspose.Slides cho PHP qua Java có thể lưu các bản thuyết trình PowerPoint dưới dạng HTML mà không cần Microsoft PowerPoint. Việc chuyển đổi cơ bản là tải một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) duy nhất và gọi `save` với [SaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/). Sử dụng [HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/) khi bạn cần kiểm soát bố cục, phông chữ, hình ảnh, ghi chú, bình luận, đầu ra SVG hoặc các tài nguyên được liên kết.

Hướng dẫn này tập trung vào các kịch bản xuất HTML thực tế:

- Xuất toàn bộ bản thuyết trình hoặc các slide đã chọn.
- Tạo HTML có bố cục cố định, đáp ứng hoặc dựa trên SVG.
- Bao gồm ghi chú người thuyết trình và bình luận.
- Kiểm soát chất lượng hình ảnh và dữ liệu hình ảnh đã cắt.
- Nhúng phông chữ hoặc lưu các tệp phông chữ riêng biệt.
- Chọn cách ghi và tham chiếu các tài nguyên bên ngoài và tệp media.

Theo mặc định, xuất HTML tạo ra một tài liệu HTML tự chứa trong đó hầu hết các tài nguyên được nhúng. Điều này tiện lợi cho việc chia sẻ một tệp duy nhất, nhưng có thể làm tăng kích thước đầu ra. Đối với việc xuất bản trên web, nên xem xét sử dụng tài nguyên bên ngoài, giảm DPI của hình ảnh và chỉ nhúng các phông chữ không chắc chắn có sẵn trong môi trường đích.

## **Chuyển đổi bản thuyết trình sang HTML**

Để xuất một bản thuyết trình sang HTML, tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và lưu bằng [SaveFormat.Html](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Ví dụ này ghi một tệp HTML. Đối tượng presentation được giải phóng trong khối `finally`, giúp giải phóng các tay cầm tệp và tài nguyên render sau khi xuất.

## **Sử dụng HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/) là lớp cấu hình chính cho việc xuất HTML. Các cài đặt phổ biến bao gồm:

- `SlidesLayoutOptions`: thêm ghi chú, bình luận, tài liệu phát tay hoặc các thông tin bố cục khác.
- `HtmlFormatter`: thay đổi cấu trúc tài liệu HTML hoặc ủy thác việc định dạng cho một bộ điều khiển.
- `SlideImageFormat`: thay đổi cách biểu diễn slide, ví dụ dưới dạng SVG.
- `PicturesCompression`: kiểm soát DPI của hình ảnh và kích thước đầu ra.
- `DeletePicturesCroppedAreas`: giữ hoặc xóa dữ liệu hình ảnh đã cắt.
- `SvgResponsiveLayout`: làm cho nội dung SVG xuất ra thích ứng với vùng chứa của nó.
- `ShowHiddenSlides`: bao gồm các slide ẩn khi cần.

Các phần tiếp theo trình bày các tùy chọn phổ biến nhất riêng biệt để bạn chỉ kết hợp những tùy chọn cần thiết cho quy trình làm việc của mình.

## **Chuyển đổi các slide đã chọn sang HTML**

Trong phương thức `save` nhận số slide, các vị trí slide được đếm bắt đầu từ 1. Vòng lặp dưới đây lưu mỗi slide vào một tệp HTML riêng.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Sử dụng mẫu này khi một trang web hoặc ứng dụng cần một trang HTML cho mỗi slide. Nếu mỗi slide phải có cùng bố cục, tạo một thể hiện [HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/) và truyền nó cho mỗi lệnh `save`.

## **Tạo HTML đáp ứng**

[ResponsiveHtmlController](https://reference.aspose.com/slides/vi/php-java/aspose.slides/responsivehtmlcontroller/) cung cấp đầu ra HTML đáp ứng thông qua [HtmlFormatter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmlformatter/). Sử dụng nó khi trang xuất ra cần thích nghi tốt hơn với chiều rộng trình duyệt.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Đối với bố cục đáp ứng dựa trên SVG, đặt `SvgResponsiveLayout` trên [HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/). Điều này hữu ích khi nội dung slide được xuất dưới dạng markup SVG có thể mở rộng.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Bao gồm ghi chú người thuyết trình và bình luận**

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/) qua `HtmlOptions.SlidesLayoutOptions` để bao gồm ghi chú người thuyết trình hoặc bình luận. Ghi chú và bình luận được ẩn theo mặc định trừ khi bạn chọn vị trí của chúng.

Giả sử bản thuyết trình nguồn chứa ghi chú người thuyết trình:

![Slide với ghi chú người thuyết trình trong PowerPoint](slide_with_notes.png)

Đoạn mã sau xuất nội dung slide cùng với ghi chú người thuyết trình phía dưới slide.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

HTML đã xuất bao gồm vùng ghi chú:

![Kết quả HTML với slide và ghi chú người thuyết trình](HTML_with_notes.png)

Để xuất bình luận, đặt `CommentsPosition`, ví dụ `CommentsPositions.Right` hoặc `CommentsPositions.Bottom`. Nếu chỉ cần bình luận, bỏ qua `NotesPosition`. Nếu cần cả ghi chú và bình luận, đặt cả hai thuộc tính.

## **Kiểm soát chất lượng hình ảnh và vùng đã cắt**

Xuất HTML có thể nén hình ảnh slide để giảm kích thước đầu ra. Đặt `PicturesCompression` thành một giá trị từ [PicturesCompression](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturescompression/) khi bạn cần chất lượng hình ảnh cao hơn.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Theo mặc định, các vùng đã cắt của hình ảnh có thể bị loại bỏ khỏi đầu ra đã xuất. Giữ dữ liệu đã cắt chỉ khi người dùng phải có khả năng khôi phục hoặc kiểm tra các phần hình ảnh ẩn đó. Việc giữ lại có thể làm tăng kích thước HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Thêm CSS**

Đối với việc tạo kiểu đơn giản, truyền một chuỗi CSS cho [HtmlFormatter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmlformatter/) thông qua `createDocumentFormatter`. Điều này thay đổi tài liệu HTML bao quanh trong khi Aspose.Slides vẫn tiếp tục render nội dung slide.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Đối với tiêu đề tài liệu tùy chỉnh, tệp CSS liên kết, hoặc markup tùy chỉnh quanh các slide và shape, sử dụng bộ điều khiển định dạng tùy chỉnh và truyền nó cho [HtmlFormatter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmlformatter/) bằng `createCustomFormatter`.

## **Nhúng phông chữ**

Nếu môi trường đích có thể không cài đặt các phông chữ của bản thuyết trình, hãy nhúng phông chữ vào HTML bằng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/php-java/aspose.slides/embedallfontshtmlcontroller/). Việc nhúng cải thiện độ chính xác hình ảnh nhưng làm tăng kích thước đầu ra.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Loại trừ phông chữ chỉ khi bạn chắc chắn rằng các trình duyệt hoặc hệ thống đích đã cung cấp chúng. Đối với phông chữ thương hiệu hoặc ít phổ biến, nhúng thường an toàn hơn.

## **Liên kết tệp phông chữ thay vì nhúng chúng**

Để giảm kích thước tệp HTML, bạn có thể ghi dữ liệu phông chữ vào các tệp WOFF riêng và thêm các quy tắc `@font-face` vào HTML. Trong PHP qua Java, kịch bản này thường được thực hiện bằng một lớp trợ giúp Java nhỏ mở rộng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/php-java/aspose.slides/embedallfontshtmlcontroller/), ghi byte phông chữ vào thư mục đầu ra và chèn các quy tắc `@font-face` vào HTML được tạo. Biên dịch lớp trợ giúp đó, thêm nó vào classpath của PHP Java Bridge, sau đó khởi tạo từ PHP bằng `new Java(...)`.

Khi xây dựng trợ giúp như vậy, hãy chọn cố ý hai đường dẫn:

- Đường dẫn hệ thống tập tin, nơi các tệp phông chữ được tạo ra.
- Đường dẫn URL, là đường dẫn mà trình duyệt sử dụng từ tài liệu HTML để tải các tệp phông chữ đó.

## **Lưu tài nguyên ra ngoài**

HTML tự chứa dễ di chuyển, nhưng các tài nguyên Base64 nhúng có thể làm tệp lớn. Nếu ứng dụng của bạn cần các tệp hình ảnh bên ngoài, cung cấp một bộ điều khiển liên kết/nhúng tùy chỉnh cho hàm khởi tạo [HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/).

Khi bạn tách rời tài nguyên ra ngoài, hãy chọn cố ý hai đường dẫn:

- Đường dẫn hệ thống tập tin, nơi ứng dụng của bạn ghi các hình ảnh, phông chữ, âm thanh hoặc video đã tạo.
- Đường dẫn URL, là đường dẫn mà trình duyệt sử dụng từ tài liệu HTML để tải các tệp đó.

Giữ các đường dẫn này nhất quán với bố trí triển khai để HTML đã tạo có thể tải các tài nguyên bên ngoài sau khi được chuyển tới máy chủ web hoặc thư mục khác.

## **Xuất tệp đa phương tiện**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoplayerhtmlcontroller/) xuất các tệp video và audio và ghi HTML có thể phát chúng trong trình duyệt. Hàm khởi tạo của nó nhận:

- `path`: thư mục đầu ra được HTML và các tệp media tạo ra sử dụng.
- `fileName`: tên tệp HTML đang được tạo.
- `baseUri`: tiền tố URI tuyệt đối được dùng trong các liên kết HTML tới các tệp media.

Nếu tệp HTML là `html-output/presentation.html`, `path` nên trỏ tới `html-output`, và `baseUri` nên trỏ tới cùng thư mục từ góc nhìn của trình duyệt. Đối với preview cục bộ, bạn có thể tạo một URI `file:///` từ thư mục đầu ra. Đối với ứng dụng đã triển khai, sử dụng URL tuyệt đối của thư mục đầu ra đã công bố.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Sử dụng các thư mục đầu ra duy nhất cho mỗi công việc xuất, đặc biệt trong các ứng dụng máy chủ. Các đường dẫn đầu ra chung có thể gây ghi đè tệp từ các lần chuyển đổi khác nhau.

## **Hiệu suất và quản lý tài nguyên**

Chuyển đổi HTML là một thao tác render, vì vậy thời gian xử lý và mức sử dụng bộ nhớ phụ thuộc vào số slide, độ phân giải hình ảnh, phông chữ, hiệu ứng, biểu đồ và media được nhúng. Giá trị DPI cao hơn của `PicturesCompression`, phông chữ nhúng, đầu ra SVG và việc giữ lại các vùng hình ảnh đã cắt có thể cải thiện độ trung thực nhưng thường làm tăng kích thước đầu ra.

Đối với chuyển đổi hàng loạt:

- Giải phóng nhanh mọi thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) ngay khi không còn cần.
- Sử dụng các thư mục đầu ra riêng biệt cho các công việc khác nhau.
- Tránh nhúng phông chữ chung trừ khi độ trung thực yêu cầu.
- Giảm DPI của hình ảnh khi HTML chỉ dùng để preview hoặc tạo thumbnail.
- Giữ bản thuyết trình nguồn, HTML đã tạo và các tài nguyên bên ngoài cùng nhau cho đến khi đường dẫn triển khai cuối cùng được xác định.

## **Câu hỏi thường gặp**

**Liên kết có được giữ lại trong đầu ra HTML không?**

Có. Các liên kết trong bản thuyết trình được xuất sang HTML và vẫn có thể nhấp được khi URL đích hợp lệ.

**Tôi có thể chuyển đổi các bản thuyết trình sang HTML song song không?**

Có, nhưng không chia sẻ một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) giữa các luồng. Xử lý các tệp khác nhau với các thể hiện presentation riêng, các stream riêng và các thư mục đầu ra riêng.

**Đối tượng Presentation có thread‑safe không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) nên được tải, sửa đổi, lưu và giải phóng trên cùng một luồng. Đối với công việc song song, tạo một thể hiện độc lập cho mỗi luồng hoặc mỗi tiến trình.

**Tại sao tệp HTML được tạo ra lại lớn?**

Mặc định xuất sẽ nhúng các tài nguyên trực tiếp vào HTML. Các phông chữ nhúng, hình ảnh DPI cao, media, nội dung SVG và việc giữ lại các vùng hình ảnh đã cắt cũng làm tăng kích thước. Sử dụng tài nguyên bên ngoài, loại trừ các phông chữ phổ biến khỏi việc nhúng, và giảm `PicturesCompression` khi kích thước nhỏ hơn độ trung thực tối đa là ưu tiên.

**Tại sao kích thước phông chữ PowerPoint như 24 pt hiển thị là 17.999819 pt trong HTML?**

Điều này có thể xảy ra vì PowerPoint và HTML sử dụng các mô hình DPI khác nhau. PowerPoint lưu kích thước văn bản bằng điểm typographic dựa trên 72 DPI, trong khi bố cục HTML dựa trên pixel CSS trong mô hình 96 DPI. Khi Aspose.Slides xuất bản thuyết trình sang HTML, kích thước phông chữ được chuyển đổi giữa các hệ thống này và quá trình chuyển đổi có thể gây ra chênh lệch làm tròn nhỏ.

Các giá trị này không phản ánh sự thay đổi thực tế về kích thước hiển thị của phông chữ. Chúng chỉ là hiệu ứng toán học phụ trợ của việc chuyển đổi số liệu văn bản giữa PowerPoint và HTML.

**Làm thế nào để chọn baseUri cho việc xuất media?**

Chọn `baseUri` từ góc nhìn của trình duyệt và truyền nó dưới dạng URI tuyệt đối. Đối với preview cục bộ, bạn có thể suy ra nó từ thư mục đầu ra bằng một URI tệp Java. Đối với triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố. `path` trên hệ thống tập tin và `baseUri` trong trình duyệt không nhất thiết phải là cùng một chuỗi, nhưng chúng phải mô tả cùng một vị trí tài nguyên.

**Tôi có thể bao gồm các slide ẩn không?**

Có. Đặt `ShowHiddenSlides` thành `true` trên [HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/) khi cần xuất các slide ẩn.