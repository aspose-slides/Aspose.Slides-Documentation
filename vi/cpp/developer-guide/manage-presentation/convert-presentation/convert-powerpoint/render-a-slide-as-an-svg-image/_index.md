---
title: Xuất các slide thuyết trình dưới dạng hình ảnh SVG trong C++
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- bản trình bày sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong C++ và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện bằng Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có thể mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình truy cập và xử lý hậu kỳ tự động. Aspose.Slides cho C++ xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các yếu tố SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/) khi SVG xuất ra cần gọn gàng, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc sử dụng tương tác.

## **Xuất một Slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/), chọn một slide và ghi nó vào một luồng. Ví dụ sau xuất mỗi slide trong một bản trình bày thành một tệp SVG riêng.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

Tên tệp sử dụng [ISlide::get_SlideNumber](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/get_slidenumber/) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [IShape::WriteAsSvg](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/writeassvg/) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/) điều khiển việc render SVG. Đối với khung văn bản, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_useframesize/) bao gồm khung văn bản trong khu vực render, và [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_useframerotation/) xác định liệu việc xoay khung có được áp dụng hay không. Đặt [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) thành `true` khi văn bản phải được render mà không có ligature.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Kiểm soát Văn bản và Phông chữ**

### **Vector hoá toàn bộ văn bản**

Đặt [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc vào phông chữ và làm cho kết quả hình ảnh nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể lựa chọn hoặc tìm kiếm dưới dạng văn bản SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Chọn cách xử lý Phông chữ ngoài**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgexternalfontshandling/) cho các phông chữ được tải ra ngoài. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để nhúng dữ liệu phông chữ vào SVG, hoặc `Vectorize` để render chỉ văn bản sử dụng phông chữ ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Giảm kích thước hình ảnh nhúng**

Sử dụng [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_picturescompression/) để giảm độ phân giải của các hình ảnh nhúng, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) để bỏ qua các khu vực nguồn đã cắt, và [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_jpegquality/) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với chi phí là độ trung thực hoặc dữ liệu hình ảnh được giữ lại.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Gán ID ổn định cho Hình dạng và Văn bản**

Sử dụng [ISvgShapeFormattingController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isvgshapeformattingcontroller/) để đặt [ISvgShape::set_Id](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isvgshape/set_id/) cho mỗi hình dạng SVG. Để đặt giá trị [ISvgTSpan::set_Id](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isvgtspan/set_id/) cho các phần tử `tspan` văn bản, hãy triển khai [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Gán một trong hai controller với [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Controller sau sử dụng [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_officeinteropshapeid/), giá trị này ổn định trong suốt vòng đời của hình dạng, và một bộ đếm có thể lặp lại cho các đoạn văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc hậu xử lý một bản trình bày không thay đổi.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Thêm trình xử lý sự kiện SVG**

Trong một [ISvgShapeFormattingController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isvgshapeformattingcontroller/), gọi [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isvgshape/seteventhandler/) với giá trị [SvgEvent](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgevent/) để thêm trình xử lý sự kiện JavaScript vào một hình dạng được xuất. Gán controller với [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

Trang chủ có thể định nghĩa hàm JavaScript được trình xử lý tham chiếu. Việc gán ID và trình xử lý sự kiện cho phép các trình xem slide, cải thiện tính truy cập và các quy trình làm việc SVG tương tác khác.

## **FAQ**

**Khi nào tôi nên sử dụng [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) thay vì [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Sử dụng [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) khi tất cả văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgexternalfontshandling/) khi chỉ văn bản sử dụng phông chữ ngoài cần được chuyển đổi thành đồ họa.

**Cách tốt nhất để làm cho SVG nhỏ hơn là gì?**

Bắt đầu bằng cách nén các hình ảnh nhúng, xoá các khu vực ảnh đã cắt, và chọn tệp phông chữ liên kết khi môi trường đích có thể cung cấp chúng. Kiểm tra kết quả vì giảm độ phân giải hình ảnh, giảm chất lượng JPEG và văn bản vector hoá mỗi cái đều có sự đánh đổi khác nhau giữa chất lượng và kích thước.

**Tôi có thể chỉnh sửa các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một controller định dạng, sau đó chọn các phần tử SVG tương ứng trong công cụ hậu xử lý hoặc script trình duyệt của bạn.