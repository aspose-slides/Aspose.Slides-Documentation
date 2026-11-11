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
  - گزینه‌های صادرات SVG
  - SVG تعاملی
  - پاورپوینت
  - ارائه
  - C++
  - Aspose.Slides
description: "اسلایدهای PowerPoint را به عنوان تصاویر SVG در C++ صادر کنید و فونت‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **نمای کلی**

SVG یک قالب تصویر مبتنی بر XML قابل گسترش است که برای انتشار وب، نمایش اسلاید، جریان‌های کاری دسترس‌پذیری و پردازش پس‌زمینه خودکار عملکرد خوبی دارد. Aspose.Slides برای C++ هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) استفاده کنید وقتی که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر در مرورگرها یا آماده برای استفاده تعاملی باشد.

## **صادرات اسلاید به عنوان SVG**

یک [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به صورت فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) استفاده می‌کند نه از اندیس حلقه. همچنین می‌توانید یک شکل جداگانه را با [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) صادر کنید وقتی یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) فریم متن را در ناحیه رندر گنجانده و [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) تعیین می‌کند که آیا چرخش فریم اعمال شود یا نه. برای اینکه متن بدون لیگچرها رندر شود، [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) را به `true` تنظیم کنید.

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

## **کنترل متن و فونت‌ها**

هنگام صادرات اسلایدها به SVG، می‌توانید کنترل کنید که آیا متن به عنوان متن باقی می‌ماند یا به گرافیک برداری تبدیل می‌شود و فونت‌های خارجی چگونه گنجانده یا ارجاع داده می‌شوند. گزینه‌های زیر به شما کمک می‌کنند تا تعادل بین سازگاری بصری، انتخاب متن و وابستگی‌های قلم در SVG صادر شده را برقرار کنید.

### **وکتوریزه کردن تمام متن**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) را به `true` تنظیم کنید تا تمام متن اسلاید به عنوان گرافیک برداری نوشته شود. این کار وابستگی‌های قلم را حذف می‌کند و نتیجه بصری را در مرورگرها یکدست‌تر می‌کند، اما متن دیگر قابل انتخاب یا جستجو به عنوان متن SVG نخواهد بود.

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

### **انتخاب نحوهٔ مدیریت فونت‌های خارجی**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) برای فونت‌های بارگذاری‌شده به صورت خارجی استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه انتخاب کنید، `Embed` برای گنجاندن داده‌های قلم در SVG، یا `Vectorize` برای رندر کردن فقط متنی که از فونت‌های خارجی استفاده می‌کند به صورت گرافیک. پیش از گنجاندن قلم‌ها، مجوزهای مربوطه را بررسی کنید.

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

## **کاهش اندازه تصویر جاسازی‌شده**

از [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) برای حذف نواحی برش‌خورده منبع، و [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) برای کنترل کیفیت کدگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را به هزینهٔ وفاداری تصویر یا دادهٔ تصویر نگه‌داری‑شده کاهش می‌دهند.

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

## **کنترل وضوح رستر‌سازی متافایل**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) حد پایین وضوح برای رستر‌سازی متافایل‌ها در طول صادرات SVG را تعیین می‌کند. از آن برای تعادل بین جزئیات و حجم فایل وقتی یک تصویر EMF یا WMF رستر می‌شود استفاده کنید. این مقدار DPI کلی برای SVG را تعریف نمی‌کند و همهٔ اشیای اسلاید را به تصویر رستر تبدیل نمی‌کند.

[metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این پرونده شامل یک تصویر EMF با خطوط قطری نزدیک به هم است. مثال زیر اولین اسلاید آن را در سه وضوح رستر‌سازی مختلف از طریق [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/) صادر می‌کند. تمام تنظیمات دیگر صادرات یکسان باقی می‌مانند تا نتایج قابل مقایسه باشند.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ ارائه‌شده است؛ این‌ها فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیستند.

| DPI رستر‌سازی متافایل | ابعاد PNG جاسازی‌شده | حجم فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستر جاسازی‌شده را در همان اندازهٔ نمایش بزرگ‌نمایی شده نشان می‌دهد. خطوط قطری در DPI 72 پیکسل‌پراکندگی قابل مشاهده دارند و در وضوح‌های بالاتر لبه‌های صاف‌تری دارند، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً همه جزئیات را بهتر نمی‌کند و نه تمام تصاویر صادرشده را تغییر می‌دهد.

![جزئیات بزرگ‌نمایی شدهٔ خط قطری در DPIهای 72، 150 و 300](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) کنترل کاهش وضوح تصویر را بر عهده دارد و می‌تواند اثر تغییر وضوح رستر‌سازی متافایل را پنهان کند. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) کیفیت کدگذاری JPEG را کنترل می‌کند، نه وضوح رستر‌سازی متافایل.

## **تخصیص شناسه‌های ثابت به اشکال و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) بر روی عناصر `tspan` متنی نیز، پیاده‌سازی [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) را در نظر بگیرید. هر یک از این کنترل‌کننده‌ها را با [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) اختصاص دهید.

کنترل‌کنندهٔ زیر از [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/) استفاده می‌کند، که برای طول عمر شکل ثابت است، و یک شمارندهٔ قابل تکرار برای بخش‌های متنی آن دارد. این باعث می‌شود شناسه‌های تولیدشده برای پردازش پس از یک ارائهٔ بدون تغییر مناسب باشند.

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

## **افزودن مدیرهای رویداد SVG**

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/)، با [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) و مقدار [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) یک مدیر رویداد JavaScript به یک شکل صادرشده اضافه کنید. کنترل‌کننده را با [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

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

صفحهٔ میزبان می‌تواند تابع JavaScript ارجاع‌شده توسط مدیر را تعریف کند. تخصیص شناسه‌ها و مدیرهای رویداد امکان‌پذیر می‌کند تا نمایشگرهای اسلاید، بهبودهای دسترسی‌پذیری و سایر جریان‌های کاری تعاملی SVG فعال شوند.

## **سوالات متداول**

**چه زمانی باید از [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) به جای [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) استفاده کنید وقتی همهٔ متن‌ها باید مستقل از قلم‌ها باشند. از [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) استفاده کنید وقتی فقط متنی که از قلم‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود.

**بهترین روش برای کوچک‌تر کردن SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خوردهٔ تصویر و انتخاب فایل‌های قلم پیوندی وقتی محیط هدف می‌تواند آن‌ها را سرویس‌دهی کند، شروع کنید. نتیجه را آزمایش کنید زیرا کاهش وضوح تصویر، کیفیت پایین‌تر JPEG و متن وکتوریزه‌شده هر کدام تعادل متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم پس از صادرات عناصر SVG را تغییر دهم؟**

بله. شناسه‌ها را از طریق یک کنترل‌کنندهٔ قالب‌بندی اختصاص دهید، سپس عناصر SVG مطابقت‌دار را در ابزار پردازش پس یا اسکریپت مرورگر خود انتخاب کنید.