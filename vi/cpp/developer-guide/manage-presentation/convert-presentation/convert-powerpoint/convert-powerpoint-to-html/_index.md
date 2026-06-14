---
title: Chuyển đổi bài thuyết trình PowerPoint sang HTML trong C++
linktitle: PowerPoint sang HTML
type: docs
weight: 30
url: /vi/cpp/convert-powerpoint-to-html/
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
- lưu PowerPoint dưới dạng HTML
- lưu bài thuyết trình dưới dạng HTML
- lưu slide dưới dạng HTML
- lưu PPT dưới dạng HTML
- lưu PPTX dưới dạng HTML
- xuất PPT sang HTML
- xuất PPTX sang HTML
- C++
- Aspose.Slides
description: Chuyển đổi bài thuyết trình PowerPoint sang HTML trong C++. Sử dụng Aspose.Slides để xuất các tệp PPT và PPTX, các slide đã chọn, ghi chú, phông chữ, hình ảnh, SVG và phương tiện.
---
## **Tổng quan**

Aspose.Slides for C++ có thể lưu các bài thuyết trình PowerPoint dưới dạng HTML mà không cần Microsoft PowerPoint. Việc chuyển đổi cơ bản chỉ cần tải một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và gọi `Save` với [SaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/). Sử dụng [HtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/) khi bạn cần kiểm soát bố cục xuất, phông chữ, hình ảnh, ghi chú, bình luận, đầu ra SVG hoặc các tài nguyên được liên kết.

Hướng dẫn này tập trung vào các kịch bản xuất HTML thực tế:

- Xuất toàn bộ bài thuyết trình hoặc các slide được chọn.
- Tạo HTML có bố cục cố định, đáp ứng hoặc dựa trên SVG.
- Bao gồm ghi chú người thuyết trình và bình luận.
- Kiểm soát chất lượng hình ảnh và dữ liệu ảnh đã cắt.
- Nhúng phông chữ hoặc lưu các tệp phông chữ riêng biệt.
- Chọn cách các tài nguyên bên ngoài và tệp phương tiện được ghi và tham chiếu.

Mặc định, xuất HTML tạo một tài liệu HTML tự chứa, trong đó hầu hết các tài nguyên được nhúng. Điều này thuận tiện cho việc chia sẻ một tệp, nhưng có thể làm tăng kích thước đầu ra. Đối với việc xuất bản trên web, hãy cân nhắc sử dụng tài nguyên bên ngoài, giảm DPI của hình ảnh và chỉ nhúng các phông chữ không có sẵn một cách đáng tin cậy trong môi trường đích.

## **Chuyển đổi một Presentation sang HTML**

Để xuất một bài thuyết trình sang HTML, tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và lưu bằng `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Ví dụ này ghi một tệp HTML. Lệnh gọi `Dispose` giải phóng các tay cầm tệp và tài nguyên render sau khi xuất.

## **Sử dụng HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/) là lớp cấu hình chính cho việc xuất HTML. Các cài đặt phổ biến bao gồm:

- `SlidesLayoutOptions`: thêm ghi chú, bình luận, tài liệu phát tay hoặc các thông tin bố cục khác.
- `HtmlFormatter`: thay đổi cấu trúc tài liệu HTML hoặc ủy quyền định dạng cho một bộ điều khiển.
- `SlideImageFormat`: thay đổi cách biểu diễn slide, ví dụ dưới dạng SVG.
- `PicturesCompression`: kiểm soát DPI ảnh và kích thước đầu ra.
- `DeletePicturesCroppedAreas`: giữ hoặc xóa dữ liệu ảnh đã cắt.
- `SvgResponsiveLayout`: làm cho nội dung SVG xuất ra thích ứng với vùng chứa của nó.
- `ShowHiddenSlides`: bao gồm các slide ẩn khi cần.

Các phần sau đây hiển thị các tùy chọn phổ biến nhất riêng biệt để bạn có thể kết hợp chỉ những tùy chọn cần thiết cho quy trình của mình.

## **Chuyển đổi các Slide đã Chọn sang HTML**

Phương thức `Presentation::Save` có overload chấp nhận số slide sử dụng vị trí slide dựa trên chỉ số 1. Vòng lặp bên dưới lưu mỗi slide vào một tệp HTML riêng.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Sử dụng mẫu này khi một trang web hoặc ứng dụng cần một trang HTML cho mỗi slide. Nếu mỗi slide đều có cùng bố cục, tạo một thể hiện [HtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/) và truyền nó vào mỗi lời gọi `Save`.

## **Tạo HTML Đáp Ứng**

[ResponsiveHtmlController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/responsivehtmlcontroller/) cung cấp đầu ra HTML đáp ứng thông qua [HtmlFormatter](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmlformatter/). Sử dụng nó khi trang xuất ra cần thích nghi tốt hơn với độ rộng trình duyệt.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Đối với bố cục đáp ứng dựa trên SVG, đặt `SvgResponsiveLayout` trên [HtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/). Điều này hữu ích khi nội dung slide được xuất dưới dạng mã SVG có thể mở rộng.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Bao gồm Ghi chú Người Thuyết Trình và Bình luận**

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/) thông qua `HtmlOptions.SlidesLayoutOptions` để bao gồm ghi chú người thuyết trình hoặc bình luận. Ghi chú và bình luận mặc định được ẩn trừ khi bạn chọn vị trí của chúng.

Giả sử bài thuyết trình nguồn chứa ghi chú người thuyết trình:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Mã dưới đây xuất nội dung slide cùng với ghi chú người thuyết trình phía dưới slide.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

HTML xuất ra bao gồm khu vực ghi chú:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Để xuất bình luận, đặt `CommentsPosition`, ví dụ `CommentsPositions::Right` hoặc `CommentsPositions::Bottom`. Nếu chỉ cần bình luận, bỏ qua `NotesPosition`. Nếu cần cả ghi chú và bình luận, đặt cả hai thuộc tính.

## **Kiểm soát Chất lượng Hình ảnh và Các Khu vực Đã Cắt**

Xuất HTML có thể nén hình ảnh slide để giảm kích thước đầu ra. Đặt `PicturesCompression` thành một giá trị từ [PicturesCompression](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/picturescompression/) khi bạn cần chất lượng hình ảnh cao hơn.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Mặc định, các khu vực đã cắt của ảnh có thể bị loại bỏ khỏi đầu ra xuất. Giữ lại dữ liệu đã cắt chỉ khi người dùng cần khôi phục hoặc kiểm tra các phần ảnh ẩn đó. Việc giữ lại có thể làm tăng kích thước HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Thêm CSS**

Đối với việc tạo kiểu đơn giản, truyền chuỗi CSS vào `HtmlFormatter::CreateDocumentFormatter`. Điều này thay đổi tài liệu HTML bao quanh trong khi Aspose.Slides vẫn tiếp tục render nội dung slide.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Đối với tiêu đề tài liệu tùy chỉnh, tệp CSS được liên kết, hoặc markup tùy chỉnh xung quanh slide và shape, triển khai [IHtmlFormattingController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ihtmlformattingcontroller/) và truyền nó vào [HtmlFormatter](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmlformatter/) bằng `CreateCustomFormatter`.

## **Nhúng Phông chữ**

Nếu môi trường đích có thể không có các phông chữ của bài thuyết trình được cài đặt, hãy nhúng phông chữ vào HTML bằng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Nhúng phông chữ cải thiện độ trung thực hình ảnh nhưng làm tăng kích thước đầu ra.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Loại trừ phông chữ chỉ khi bạn chắc chắn rằng các trình duyệt hoặc hệ thống đích đã cung cấp chúng. Đối với phông chữ thương hiệu hoặc các phông chữ ít phổ biến, việc nhúng thường an toàn hơn.

## **Liên Kết Tệp Phông Chữ Thay vì Nhúng Chúng**

Để giảm kích thước tệp HTML, bạn có thể ghi dữ liệu phông chữ vào các tệp WOFF riêng và thêm quy tắc `@font-face` vào HTML. Trợ giúp dưới đây mở rộng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/embedallfontshtmlcontroller/) và ghi đè `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Trong ví dụ này, các tệp phông chữ được lưu vào `html-output/fonts`, và HTML tham chiếu chúng bằng các URL như `fonts/BrandFont-normal-400.woff`. Nếu tệp HTML và phông chữ được triển khai ở vị trí khác, chọn `fontUrlPrefix` sao cho phù hợp với đường dẫn URL đã triển khai.

## **Lưu Tài Nguyên Bên Ngoài**

HTML tự chứa dễ di chuyển, nhưng các tài nguyên Base64 được nhúng có thể làm tệp lớn. Nếu ứng dụng của bạn cần các tệp ảnh bên ngoài, triển khai [ILinkEmbedController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ilinkembedcontroller/) và truyền nó vào hàm khởi tạo [HtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/).

Khi bạn tách tài nguyên ra bên ngoài, hãy chọn hai đường dẫn một cách cố ý:

- Đường dẫn đầu ra hệ thống tập tin, nơi ứng dụng của bạn ghi các hình ảnh, phông chữ, âm thanh hoặc video được tạo.
- Đường dẫn URL, là đường dẫn mà trình duyệt sử dụng từ tài liệu HTML để tải các tệp đó.

## **Xuất Tệp Phương Tiện**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/videoplayerhtmlcontroller/) xuất các tệp video và âm thanh và tạo HTML có thể phát chúng trong trình duyệt. Bộ khởi tạo của nó nhận:

- `path`: thư mục nơi các tệp phương tiện được tạo sẽ được ghi.
- `fileName`: tên tệp HTML đang được tạo.
- `baseUri`: tiền tố URI tuyệt đối được sử dụng trong các liên kết HTML tới các tệp phương tiện.

Nếu tệp HTML là `html-output/presentation.html` và các tệp phương tiện được lưu trong `html-output/media`, `path` nên chỉ tới thư mục phương tiện trên đĩa, trong khi `baseUri` nên chỉ tới cùng thư mục từ quan điểm của trình duyệt. Đối với preview cục bộ, bạn có thể tạo URI `file:///` từ thư mục phương tiện. Đối với ứng dụng đã triển khai, sử dụng URL tuyệt đối của thư mục phương tiện đã xuất bản.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Sử dụng các thư mục đầu ra độc nhất cho mỗi công việc xuất, đặc biệt trong các ứng dụng máy chủ. Các đường dẫn đầu ra chung có thể gây ghi đè lẫn lộn giữa các chuyển đổi khác nhau.

## **Hiệu Năng và Quản Lý Tài Nguyên**

Chuyển đổi HTML là một thao tác render, vì vậy thời gian xử lý và bộ nhớ tiêu thụ phụ thuộc vào số slide, độ phân giải ảnh, phông chữ, hiệu ứng, biểu đồ và media được nhúng. Giá trị DPI cao hơn của `PicturesCompression`, phông chữ được nhúng, đầu ra SVG và việc giữ lại các khu vực ảnh đã cắt có thể cải thiện độ trung thực nhưng thường làm tăng kích thước đầu ra.

Đối với chuyển đổi hàng loạt:

- Gỡ bỏ (Dispose) mỗi thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) ngay khi không còn sử dụng.
- Sử dụng các thư mục đầu ra riêng biệt cho các công việc khác nhau.
- Tránh nhúng các phông chữ phổ biến trừ khi độ trung thực yêu cầu.
- Giảm DPI ảnh khi HTML chỉ dùng để preview hoặc làm ảnh thu nhỏ.
- Giữ nguyên bài thuyết trình nguồn, HTML đã tạo và các tài nguyên bên ngoài cùng nhau cho đến khi đường dẫn triển khai cuối cùng được xác định.

## **Câu Hỏi Thường Gặp**

**Liên kết siêu văn bản có được giữ lại trong đầu ra HTML không?**

Có. Các liên kết siêu văn bản trong Presentation được xuất sang HTML và vẫn có thể nhấp khi URL đích hợp lệ.

**Tôi có thể chuyển đổi các bài thuyết trình sang HTML song song không?**

Có, nhưng không chia sẻ một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) giữa các luồng. Xử lý các tệp khác nhau với các thể hiện Presentation riêng, các luồng riêng và các thư mục đầu ra riêng. Xem hướng dẫn [multithreading guidance](/slides/vi/cpp/multithreading/) để biết chi tiết.

**Đối tượng Presentation có thread-safe không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) nên được tải, chỉnh sửa, lưu và gỡ bỏ trên một luồng duy nhất. Đối với công việc song song, tạo một thể hiện độc lập cho mỗi luồng hoặc mỗi quy trình.

**Tại sao tệp HTML được tạo ra lại lớn?**

Mặc định, xuất có thể nhúng tài nguyên trực tiếp vào HTML. Các phông chữ được nhúng, ảnh DPI cao, media, nội dung SVG và việc giữ lại các khu vực ảnh đã cắt cũng làm tăng kích thước. Sử dụng tài nguyên bên ngoài, loại bỏ các phông chữ phổ biến khỏi việc nhúng và giảm `PicturesCompression` khi kích thước nhỏ hơn quan trọng hơn độ trung thực tối đa.

**Tại sao kích thước phông chữ PowerPoint như 24 pt xuất hiện là 17.999819 pt trong HTML?**

Điều này có thể xảy ra vì PowerPoint và HTML sử dụng các mô hình DPI khác nhau. PowerPoint lưu kích thước văn bản bằng điểm kiểu chữ dựa trên 72 DPI, trong khi bố cục HTML dựa trên pixel CSS trong mô hình 96 DPI. Khi Aspose.Slides xuất một Presentation sang HTML, kích thước phông chữ được dịch chuyển giữa các hệ thống này và quá trình chuyển đổi có thể tạo ra các sai số làm tròn nhỏ.

Các giá trị này không cho thấy sự thay đổi thực tế về kích thước phông chữ hiển thị. Chúng chỉ là tác dụng phụ toán học của việc chuyển đổi các chỉ số văn bản giữa PowerPoint và HTML.

**Làm thế nào để chọn baseUri cho việc xuất media?**

Chọn `baseUri` dựa trên quan điểm của trình duyệt và truyền nó dưới dạng URI tuyệt đối. Đối với preview cục bộ, bạn có thể suy ra nó từ thư mục đầu ra bằng `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Đối với triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố. `path` trên hệ thống tập tin và `baseUri` trong trình duyệt không nhất thiết phải là cùng một chuỗi, nhưng chúng phải mô tả cùng một vị trí tài nguyên.

**Tôi có thể bao gồm các slide ẩn không?**

Có. Đặt `ShowHiddenSlides` thành `true` trên [HtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/) khi các slide ẩn phải được xuất.