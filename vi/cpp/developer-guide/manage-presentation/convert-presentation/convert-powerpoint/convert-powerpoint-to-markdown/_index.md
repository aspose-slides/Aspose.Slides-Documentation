---
title: "Chuyển đổi bài thuyết trình PowerPoint sang Markdown trong C++"
linktitle: "PowerPoint sang Markdown"
type: docs
weight: 140
url: /vi/cpp/convert-powerpoint-to-markdown/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi bài thuyết trình"
- "chuyển đổi slide"
- "chuyển đổi PPT"
- "chuyển đổi PPTX"
- "PowerPoint sang MD"
- "bài thuyết trình sang MD"
- "slide sang MD"
- "PPT sang MD"
- "PPTX sang MD"
- "lưu PowerPoint dưới dạng Markdown"
- "lưu bài thuyết trình dưới dạng Markdown"
- "lưu slide dưới dạng Markdown"
- "lưu PPT dưới dạng MD"
- "lưu PPTX dưới dạng MD"
- "xuất PPT sang MD"
- "xuất PPTX sang MD"
- "xuất ảnh Markdown"
- "liên kết ảnh CDN"
- "PowerPoint"
- "bài thuyết trình"
- "Markdown"
- "C++"
- "Aspose.Slides"
description: "Chuyển đổi các bài thuyết trình PPT và PPTX sang Markdown trong C++ và kiểm soát vị trí lưu và tham chiếu của các hình ảnh bitmap, metafile và SVG đã xuất."
---
## **Tổng quan**

Aspose.Slides for C++ có thể chuyển đổi các bài thuyết trình PPT và PPTX sang Markdown để phục vụ tài liệu, trang tĩnh, chuyển đổi nội dung và quy trình kiểm soát phiên bản. Bạn có thể chọn kiểu Markdown, kiểm soát cách nội dung slide được kết xuất và quyết định nơi lưu trữ hình ảnh xuất ra cũng như cách các liên kết Markdown được tạo ra.

Mặc định, xuất Markdown chỉ tạo ra đầu ra dạng văn bản thuần. Để xuất nội dung hình ảnh, đặt phương thức [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) thành giá trị `Sequential` hoặc `Visual` từ liệt kê [MarkdownExportType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownexporttype/). `Sequential` sẽ render các mục slide riêng biệt và theo thứ tự, trong khi `Visual` giữ các mục được nhóm lại với nhau để bảo toàn mối quan hệ hình ảnh. Giá trị `TextOnly` không tạo ra tài nguyên hình ảnh, vì vậy các sự kiện lưu hình ảnh sẽ không được gọi trong chế độ này.

## **Chuyển đổi bài thuyết trình sang Markdown**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/), rồi gọi phương thức [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) với giá trị `Md` từ liệt kê [SaveFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Chọn Kiểu Markdown**

Phương thức [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) kiểm soát chuẩn Markdown được sử dụng cho đầu ra. Liệt kê [Flavor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/flavor/) bao gồm CommonMark, GitHub Flavored Markdown và các biến thể được hỗ trợ khác.

Ví dụ sau xuất một bài thuyết trình dưới dạng CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Xuất Hình Ảnh Bằng Hành Vi Lưu Nội Bộ Mặc Định**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/) cung cấp hai phương thức để cấu hình việc lưu ảnh cục bộ:

- [set_BasePath](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) chỉ định thư mục gốc cho tài liệu Markdown và các tài nguyên của nó.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) chỉ định thư mục con chứa hình ảnh. Giá trị mặc định là `Images`.

Ví dụ sau render nội dung hình ảnh, ghi ảnh vào `output/assets`, và tạo các liên kết hình ảnh tương đối trong tài liệu Markdown:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Hành vi này cũng được dùng làm dự phòng khi một trình xử lý lưu ảnh tùy chỉnh trả về `false`.

## **Tùy chỉnh việc lưu hình ảnh và liên kết Markdown**

Sử dụng sự kiện `MarkdownSaveOptions::ImageSaving` cho các tài nguyên bitmap và metafile không phải SVG được phát sinh trong quá trình xuất Markdown. Đối tượng [MarkdownImageSavingHandler](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) nhận đối tượng [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/), [ImageFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imageformat/) và liên kết Markdown đã tạo dưới dạng tham số `System::String&`. Lưu hoặc tải lên hình ảnh với định dạng đã cung cấp, và thay thế `link` bằng tham chiếu mà phải xuất hiện trong đầu ra Markdown.

Các tài nguyên xuất ra ở định dạng SVG được xử lý riêng. Đăng ký sự kiện `MarkdownSaveOptions::SvgImageSaving`, trong đó delegate [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) nhận một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) và tham số `System::String& link`. SVG không có tham số `ImageFormat`; thay vào đó hãy ghi hoặc tải lên dữ liệu XML của nó bằng phương thức [ISvgImage::get_SvgData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/get_svgdata/). Tùy thuộc vào chế độ xuất và cách nhóm hình ảnh, một SVG trong bài thuyết trình nguồn có thể được raster hoá hoặc kết hợp với nội dung khác; tài nguyên không phải SVG kết quả sẽ được truyền cho `ImageSaving`. Hãy đăng ký cả hai sự kiện khi mọi tài nguyên hình ảnh xuất ra đều cần xử lý tùy chỉnh.

Giá trị trả về của trình xử lý quyết định ai sẽ xử lý hình ảnh:

- Trả về `true` sau khi trình xử lý đã lưu, tải lên, chuyển đổi hoặc xử lý hình ảnh theo cách riêng và đã gán một giá trị hợp lệ cho `link`. Aspose.Slides sẽ ghi giá trị đó vào tài liệu Markdown và không thực hiện lưu cục bộ mặc định.
- Trả về `false` để cho phép Aspose.Slides lưu hình ảnh cục bộ và tạo liên kết dựa trên [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) và [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Một trình xử lý trả về `true` sẽ chịu trách nhiệm toàn bộ đối với hình ảnh. Nếu nó trả về `true` mà không gán một liên kết hợp lệ, không rỗng, quá trình xuất sẽ thất bại với `InvalidOperationException`.
{{% /alert %}}

### **Lưu Hình Ảnh vào Thư Mục Gốc CDN và Sử Dụng URL Ngoài**

Ví dụ dưới đây xem `cdn-origin/presentations/quarterly-report` như một thư mục gốc CDN được gắn hoặc đồng bộ. Mỗi trình xử lý trích xuất tên tệp đã tạo, lưu hình ảnh vào thư mục tùy chỉnh đó, và thay thế tham chiếu cục bộ đã tạo bằng URL CDN công cộng. Mẫu này không thực hiện tải lên mạng: URL chỉ hợp lệ sau khi thư mục được gắn làm gốc CDN hoặc các tệp của nó được công bố lên CDN. Đối với lưu trữ đối tượng, thay thế việc ghi file hệ thống bằng thao tác tải lên của SDK lưu trữ và gán `link` chỉ sau khi việc tải lên thành công.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Trình xử lý bitmap cố ý trả về `false` cho các hình ảnh nhỏ hơn 128 × 128 pixel, vì vậy Aspose.Slides sẽ lưu những hình ảnh này vào `output/fallback-images` theo hành vi mặc định. Các tài nguyên bitmap và metafile lớn hơn, cũng như các tài nguyên SVG, được xử lý bởi mã tùy chỉnh. Ví dụ, một tham chiếu cục bộ đã tạo như `fallback-images/image1.png` sẽ trở thành `https://cdn.example.com/presentations/quarterly-report/image1.png`. Các trình xử lý chỉ sử dụng đường dẫn hệ điều hành khi ghi tệp; các liên kết ghi vào Markdown dùng dấu xuyệc `/` và tên tệp đã được mã hoá URL. Áp dụng quy tắc tương tự khi xây dựng liên kết tương đối: dùng `/`, không phải dấu phân tách thư mục riêng của nền tảng.

## **Câu hỏi thường gặp**

**Một trình xử lý có thể xử lý cả ảnh raster và ảnh SVG không?**

Không. Sử dụng `MarkdownSaveOptions::ImageSaving` cho các tài nguyên bitmap và metafile được phát sinh và `MarkdownSaveOptions::SvgImageSaving` cho các tài nguyên được phát sinh dưới dạng SVG. Trình xử lý đầu tiên cung cấp đối tượng [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) và [ImageFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imageformat/); trình xử lý thứ hai cung cấp đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/) mà dữ liệu SVG có thể đọc bằng [ISvgImage::get_SvgData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/get_svgdata/). Một SVG nguồn bị raster hoá trong quá trình xuất sẽ được xử lý bởi `ImageSaving` thay vì `SvgImageSaving`.

**Điều gì xảy ra khi một trình xử lý lưu ảnh trả về `false`?**

Aspose.Slides sẽ sử dụng hành vi lưu cục bộ mặc định. Vị trí hình ảnh và tham chiếu đã tạo được điều khiển bởi [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) và [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**Một trình xử lý có thể cung cấp URL mà không lưu hình ảnh cục bộ không?**

Có. Trình xử lý có thể tải lên hình ảnh tới lưu trữ đối tượng hoặc chuyển cho dịch vụ khác, gán URL thu được cho `link`, và trả về `true`. Trình xử lý phải tự mình hoàn thành việc xử lý; việc trả về `true` sẽ ngăn chặn lưu cục bộ mặc định.

**Tại sao việc xuất Markdown gây ra `InvalidOperationException` từ một trình xử lý?**

Ngoại lệ này xuất hiện khi trình xử lý trả về `true` nhưng không cung cấp một liên kết hợp lệ. Hãy gán đường dẫn tương đối hoặc URL bên ngoài mà cần ghi vào Markdown trước khi trả về `true`.

**Dấu phân tách đường dẫn nào nên được sử dụng cho liên kết hình ảnh?**

Sử dụng dấu xuyệc (`/`) trong các liên kết Markdown và URL. Dùng `Path::Combine` chỉ cho các đường dẫn hệ thống, sau đó tạo hoặc chuẩn hoá tham chiếu Markdown riêng biệt.

**Liên kết siêu văn bản có được giữ lại khi xuất Markdown không?**

Có. Các [hyperlinks](/slides/vi/cpp/manage-hyperlinks/) trong văn bản được giữ dưới dạng liên kết Markdown tiêu chuẩn. Các [transitions](/slides/vi/cpp/slide-transition/) và [animations](/slides/vi/cpp/powerpoint-animation/) của slide không được chuyển đổi.

**Có thể chuyển đổi nhiều bài thuyết trình sang Markdown đồng thời không?**

Bạn có thể xử lý các tệp bài thuyết trình khác nhau song song, nhưng không chia sẻ cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) giữa các luồng. Tuân thủ [multithreading guidelines](/slides/vi/cpp/multithreading/) và sử dụng một thể hiện riêng cho mỗi tệp.