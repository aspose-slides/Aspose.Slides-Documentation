---
title: رندر اسلایدهای ارائه به عنوان تصاویر SVG در C++
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/cpp/render-a-slide-as-an-svg-image/
keywords:
- پاورپوینت به SVG
- ارائه به SVG
- اسلاید به SVG
- PPT به SVG
- PPTX به SVG
- گزینه‌های استخراج SVG
- SVG تعاملی
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "صادر کردن اسلایدهای پاورپوینت به عنوان تصاویر SVG در C++ و کنترل قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها با Aspose.Slides."
---
## **مرور کلی**

SVG یک فرمت تصویر مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش اسلاید، گردش‌کارهای دسترسی‌پذیری و پس‌پردازش خودکار به خوبی عمل می‌کند. Aspose.Slides برای C++ هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان می‌دهد که نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/) زمانی که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر در مرورگرها یا برای استفاده تعاملی آماده باشد، استفاده کنید.

## **صدور اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به عنوان یک فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [ISlide::get_SlideNumber](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/get_slidenumber/) به جای شاخص حلقه استفاده می‌کند. همچنین می‌توانید یک شکل منفرد را با [IShape::WriteAsSvg](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/writeassvg/) صادر کنید وقتی که یک نمایش‌دهنده اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/) رندرینگ SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_useframesize/) فریم متنی را در ناحیه رندرینگ گنجانده و [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_useframerotation/) تعیین می‌کند که آیا چرخش فریم اعمال شود یا نه. هنگامیکه متن باید بدون لیگاتور رندر شود، [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) را به `true` تنظیم کنید.

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

## **کنترل متن و قلم‌ها**

### **وکتوریزه کردن تمام متن**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) را به `true` تنظیم کنید تا تمام متن اسلاید به صورت گرافیک‌های برداری نوشته شود. این کار وابستگی‌های قلم را از بین می‌برد و نتیجه بصری را در مرورگرها ثابت‌تر می‌کند، اما متن دیگر به عنوان متن SVG قابل انتخاب یا جستجو نخواهد بود.

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

### **انتخاب نحوه‌ی مدیریت قلم‌های خارجی**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) از یک مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند استفاده می‌کند. `AddLinksToFontFiles` را انتخاب کنید تا به فایل‌های قلم جداگانه ارجاع داده شود، `Embed` برای گنجاندن داده‌های قلم در SVG، یا `Vectorize` برای رندر کردن تنها متن‌هایی که از قلم‌های خارجی استفاده می‌کنند به صورت گرافیک. قبل از گنجاندن قلم‌ها، مجوزهای قلم را تأیید کنید.

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

## **کاهش حجم تصویر داخلی**

از [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_picturescompression/) برای کاهش وضوح تصاویر داخلی، [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) برای حذف نواحی بریده‌شده منبع، و [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_jpegquality/) برای کنترل کیفیت کدگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را با هزینهٔ وفاداری تصویر یا حفظ داده‌های تصویر کاهش می‌دهند.

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

## **اختصاص شناسه‌های ثابت به شکل‌ها و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape::set_Id](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isvgshape/set_id/) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan::set_Id](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isvgtspan/set_id/) بر روی عناصر متن `tspan` نیز، [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) را پیاده‌سازی کنید. هر یک از کنترل‌کننده‌ها را با [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) اختصاص دهید.

کنترل‌کننده زیر از [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_officeinteropshapeid/) استفاده می‌کند، که برای طول عمر شکل ثابت است، و یک شمارندهٔ قابل تکرار برای بازه‌های متنی آن. این باعث می‌شود شناسه‌های تولید شده برای پس‌پردازش ارائه‌ای که تغییر نکرده مناسب باشند.

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

## **افزودن پردازشگرهای رویداد SVG**

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isvgshapeformattingcontroller/)، با مقدار [SvgEvent](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgevent/) متد [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isvgshape/seteventhandler/) را فراخوانی کنید تا یک پردازشگر رویداد JavaScript به شکل صادر شده اضافه شود. کنترل‌کننده را با [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

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

صفحهٔ میزبان می‌تواند تابع JavaScript referenced توسط پردازشگر را تعریف کند. اختصاص شناسه‌ها و پردازشگرهای رویداد، نمایش‌دهنده‌های اسلاید، بهبودهای دسترسی و سایر گردش‌کارهای تعاملی SVG را امکان‌پذیر می‌سازد.

## **سوالات متداول**

**چه زمانی باید از [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) به جای [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) زمانی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgexternalfontshandling/) زمانی استفاده کنید که فقط متنی که از قلم‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود.

**بهترین روش برای کوچک کردن یک SVG چیست؟**

ابتدا با فشرده‌سازی تصاویر داخلی، حذف نواحی بریده‌شده تصویر و انتخاب فایل‌های قلم پیوندی (در صورتی که محیط هدف بتواند آن‌ها را سرو کند) شروع کنید. نتیجه را تست کنید زیرا کاهش وضوح تصویر، کاهش کیفیت JPEG و وکتوریزه کردن متن هر کدام تعادل متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم عناصر SVG صادر شده را پس از استخراج اصلاح کنم؟**

بله. با استفاده از یک کنترل‌کنندهٔ فرمت‌بندی شناسه‌ها را اختصاص دهید، سپس عناصر SVG مطابق را در ابزار پس‌پردازش یا اسکریپت مرورگر خود انتخاب کنید.