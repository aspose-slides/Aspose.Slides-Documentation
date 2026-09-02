---
title: "Chuyển đổi Slide Bài thuyết trình thành Hình ảnh trong C++"
linktitle: "Slide sang Hình ảnh"
type: docs
weight: 41
url: /vi/cpp/convert-slide/
keywords:
- "chuyển đổi slide"
- "xuất slide"
- "slide sang hình ảnh"
- "lưu slide dưới dạng hình ảnh"
- "slide sang EMF"
- "slide sang PNG"
- "slide sang JPEG"
- "slide sang bitmap"
- "slide sang TIFF"
- PowerPoint
- OpenDocument
- "bài thuyết trình"
- C++
- Aspose.Slides
description: "Chuyển đổi slide từ các bản trình bày PPT, PPTX và ODP sang PNG, JPEG, GIF, TIFF, EMF và các định dạng hình ảnh khác trong C++ với Aspose.Slides cho C++."
---
## **Giới thiệu**

Aspose.Slides for C++ có thể render các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument thành các định dạng ảnh PNG, JPEG, GIF, TIFF và các định dạng ảnh khác.

Để chuyển đổi một slide thành hình ảnh, làm theo các bước sau:

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Chọn slide mà bạn muốn render.
3. Nếu cần, cấu hình việc render bằng lớp [RenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/renderingoptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/) .
4. Gọi phương thức [ISlide::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/) . Nó trả về một đối tượng [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) .
5. Gọi phương thức [IImage::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/save/) và chỉ định định dạng đầu ra bằng một giá trị [ImageFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imageformat/) .

## **Chuyển đổi Slide sang hình PNG**

Việc chuyển đổi đơn giản nhất sử dụng các cài đặt render mặc định. Đối tượng [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) kết quả có thể được xử lý trong bộ nhớ hoặc lưu vào tệp.

Ví dụ C++ sau render slide đầu tiên và lưu nó dưới dạng ảnh PNG:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Chuyển đổi Slides sang hình ảnh với kích thước tùy chỉnh**

Sử dụng overload của [ISlide::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/) chấp nhận một giá trị [Size](https://reference.aspose.com/slides/vi/cpp/system.drawing/size/) để render slide với kích thước pixel chính xác.

Ví dụ sau tạo ảnh JPEG kích thước 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Chuyển đổi Slides có Ghi chú và Bình luận sang hình ảnh**

Mặc định, hình ảnh slide không bao gồm ghi chú hay bình luận. Gán một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/) vào phương thức [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) để kiểm soát vị trí hiển thị ghi chú và bình luận.

Ví dụ sau đặt ghi chú bị cắt ngắn phía dưới slide và bình luận sang phía bên phải:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Đối với chuyển đổi slide‑to‑image, không đặt phương thức [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) thành [BottomFull](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notespositions/) . Ghi chú có thể chứa nhiều văn bản hơn kích thước ảnh cố định cho phép. Hãy sử dụng [BottomTruncated](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notespositions/) thay thế.
{{% /alert %}}

## **Chuyển đổi Slides sang hình ảnh bằng tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/tiffoptions/) cho phép bạn kiểm soát kích thước, độ phân giải và các thuộc tính khác của ảnh TIFF được render.

Ví dụ sau render slide đầu tiên thành ảnh TIFF kích thước 2160 × 2880 với 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Chuyển đổi Tất cả Slides sang hình ảnh**

Duyệt qua bộ sưu tập slide để chuyển đổi toàn bộ bản trình bày thành một loạt ảnh. Các slide ẩn sẽ được bao gồm trừ khi bạn bỏ qua chúng một cách rõ ràng.

Ví dụ sau render mọi slide thành ảnh JPEG với hệ số tỷ lệ ngang và dọc là 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Tạo Đầu ra Enhanced Metafile**

Enhanced Metafile (EMF) hữu ích khi đồ họa dựa trên vector cần được trao đổi với Microsoft Office hoặc các ứng dụng Windows khác hỗ trợ metafile của Windows. Khác với ảnh dựa trên pixel, EMF có thể giữ lại các thao tác vẽ vector mà không giảm độ sắc nét khi phóng to. Tuy nhiên, EMF chủ yếu là định dạng tương thích cho các ứng dụng có hỗ trợ metafile Windows, không phải là định dạng trao đổi chung. Ngoài ra, nội dung slide phức tạp, như ảnh bitmap và một số hiệu ứng, có thể được lưu dưới dạng các phần tử rasterized bên trong container metafile vector.

### **Xuất Slide sang EMF**

Phương thức [ISlide::WriteAsEmf](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/writeasemf/) ghi một [ISlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/) vào một stream mục tiêu ở định dạng EMF. Ví dụ sau tải bản trình bày, chọn slide đầu tiên và ghi nó vào một stream file EMF:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Người gọi sở hữu stream được truyền vào [ISlide::WriteAsEmf](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/writeasemf/) và phải đóng hoặc giải phóng nó. Aspose.Slides ghi tại vị trí hiện tại của stream và để stream mở.

### **Chuyển đổi hình ảnh SVG sang EMF và thêm vào Bản trình bày**

Sử dụng [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/writeasemf/) để chuyển đổi nội dung SVG sang EMF. Các byte kết quả có thể được thêm vào bản trình bày thông qua [IImageCollection::AddImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimagecollection/addimage/) và đặt lên slide bằng [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ishapecollection/addpictureframe/) .

Ví dụ sau tạo một [SvgImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/svgimage/) từ markup SVG, chuyển đổi nó thành EMF trong bộ nhớ, chèn metafile vào slide đầu tiên và lưu bản trình bày:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isvgimage/writeasemf/) không nhận quyền sở hữu stream đích. Sau khi ghi, vị trí stream sẽ ở cuối dữ liệu tạo ra. Ví dụ gọi [MemoryStream::ToArray](https://reference.aspose.com/slides/vi/cpp/system.io/memorystream/toarray/) để lấy toàn bộ buffer bất kể vị trí hiện tại của stream, sau đó truyền mảng byte này vào [IImageCollection::AddImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimagecollection/addimage/) . Giữ stream mở cho đến khi người tiêu dùng hoàn thành việc đọc, rồi đóng lại sau đó.

Việc tạo EMF khả dụng trên các hệ điều hành được Aspose.Slides for C++ hỗ trợ, nhưng quá trình render có thể khác nhau giữa các nền tảng khi phông chữ hoặc các phụ thuộc đồ họa gốc không có. Cài đặt các phông chữ được sử dụng trong nội dung nguồn hoặc cấu hình các thay thế thích hợp, tuân thủ [yêu cầu nền tảng](/slides/vi/cpp/system-requirements/) cho Aspose.Slides for C++, và kiểm tra kết quả trong ứng dụng tiêu thụ EMF mục tiêu. Các ứng dụng trên Linux và macOS thường có hỗ trợ hạn chế hoặc không đồng nhất trong việc hiển thị và chỉnh sửa metafile Windows.

## **Hiển thị Emoji màu**

{{% alert title="Note" color="info" %}}
Để render emoji màu đúng khi chuyển đổi slide của bản trình bày thành ảnh, các phông chữ emoji được sử dụng trong bản trình bày phải được cài đặt và có sẵn trên hệ thống thực hiện quá trình chuyển đổi. Ví dụ, nếu bản trình bày sử dụng **Segoe UI Emoji** mà phông chữ này thiếu, emoji có thể xuất hiện dưới dạng đơn sắc trong các ảnh đầu ra.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide có hoạt cảnh không?**

Không. Phương thức [ISlide::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/) render một hình ảnh tĩnh của slide và không xuất hoạt cảnh.

**Có thể xuất các slide ẩn dưới dạng hình ảnh không?**

Có. Các slide ẩn có thể được render như các slide thường. Bao gồm chúng trong vòng lặp xử lý, như trong ví dụ ở trên.

**Các bóng và hiệu ứng khác có được giữ lại trong hình ảnh slide không?**

Có. Aspose.Slides render các bóng, độ trong suốt và các hiệu ứng đồ họa được hỗ trợ khác trong hình ảnh slide.