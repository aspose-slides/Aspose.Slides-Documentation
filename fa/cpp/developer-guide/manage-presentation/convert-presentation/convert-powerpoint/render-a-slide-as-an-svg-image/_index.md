---
title: رندر اسلایدهای ارائه به‌صورت تصاویر SVG در C++
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint به SVG
- ارائه به SVG
- اسلاید به SVG
- PPT به SVG
- PPTX به SVG
- گزینه‌های خروجی SVG
- SVG تعاملی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "اسلایدهای PowerPoint را به‌عنوان تصاویر SVG در C++ صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **بررسی کلی**

SVG یک قالب تصویری مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش اسلایدها، جریان‌های دسترسی‌پذیری و پردازش پس‌زمینه خودکار مناسب است. Aspose.Slides for C++ هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان می‌دهد نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) زمانی استفاده کنید که SVG صادر شده باید فشرده، در مرورگرها پیش‌بینی‌پذیر یا آماده استفاده تعاملی باشد.

## **صادرات یک اسلاید به SVG**

یک [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به صورت یک فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) به جای شاخص حلقه استفاده می‌کند. همچنین می‌توانید یک شکل منفرد را با [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) زمانی که یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد، صادر کنید.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) رندر SVG را کنترل می‌کند. برای چارچوب‌های متنی، [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) چارچوب متن را در ناحیه رندر گنجانده و [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) تعیین می‌کند آیا چرخش چارچوب اعمال شود یا نه. هنگام نیاز به رندر متن بدون لیگارفی‌ها، [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) را به `true` تنظیم کنید.

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

## **کنترل برش انتهای خط در سرهای پیکانی**

در SVG 1.1 تنظیمی برای مشخص کردن نقطه توقف خط زیر سر پیکان وجود ندارد. به‌طور پیش‌فرض، Aspose.Slides طول خط صادر شده را کوتاه می‌کند تا خط آن از نشانگر عبور نکند. برای رسم خط تا نقطهٔ انتهای اصلی آن، [SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) را به `true` تنظیم کنید. این تنظیم تنها بر خروجی SVG تأثیر دارد؛ موقعیت و طول خط در اسلاید ثابت می‌مانند.

مثال سرهای پیکانی مثلثی و لوزی را بر روی خطوط با عرض ۲ و ۱۰ نقطه رسم می‌کند. همان اسلاید دو بار صادر می‌شود و فقط گزینهٔ برش تغییر می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/ShapeType.h>
#include <Export/SVGOptions.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto y = 40;
const LineArrowheadStyle styles[] = { LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond };
const int widths[] = { 2, 10 };

for (auto style : styles)
{
    for (auto width : widths)
    {
        auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 40, y, 200, 0);
        auto format = line->get_LineFormat();
        format->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
        format->set_Width(width);
        format->set_EndArrowheadStyle(style);
        y += 50;
    }
}

auto options = MakeObject<SVGOptions>();
options->set_DisableLineEndCropping(false);
auto cropped = File::Create(u"cropped.svg");
slide->WriteAsSvg(cropped, options);
cropped->Dispose();

options->set_DisableLineEndCropping(true);
auto uncropped = File::Create(u"uncropped.svg");
slide->WriteAsSvg(uncropped, options);
uncropped->Dispose();

presentation->Dispose();
```

مقایسهٔ سر پیکان مثلثی روی خط ۱۰‑نقطه‌ای را نشان می‌دهد. با فعال‌سازی برش، نوک تیز است. با غیرفعال‌سازی برش، خط از طرف‌های مایل نشانگر عبور می‌کند و انتهایی صاف می‌شود.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

در خطوط دیگر مثال، خط برجسته در مثلث ۲‑نقطه‌ای کمتر مشهود است. لوزی پر شده انتهای خط را در هر دو عرض پوشش می‌دهد.

## **کنترل متن و قلم‌ها**

هنگام صادرات اسلایدها به SVG می‌توانید تصمیم بگیرید که متن به عنوان متن باقی بماند یا به گرافیک‌های برداری تبدیل شود و نحوهٔ گنجاندن یا ارجاع به قلم‌های خارجی را تنظیم کنید. گزینه‌های زیر به شما کمک می‌کند تا بین سازگاری بصری، قابلیت انتخاب متن و وابستگی‌های قلم در SVG صادر شده تعادل برقرار کنید.

### **بردارسازی تمام متن‌ها**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) را به `true` تنظیم کنید تا تمام متن اسلاید به صورت گرافیک برداری نوشته شود. این کار وابستگی‌های قلم را حذف می‌کند و نتیجه بصری را در مرورگرها یکنواخت‌تر می‌سازد، اما متن دیگر قابل انتخاب یا جستجو به عنوان متن SVG نیست.

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

### **انتخاب نحوهٔ پردازش قلم‌های خارجی**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) برای قلم‌هایی که به صورت خارجی بارگذاری می‌شوند، استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه، `Embed` را برای گنجاندن داده‌های قلم در SVG یا `Vectorize` را برای رندر کردن فقط متن‌های استفاده‌کننده از قلم‌های خارجی به صورت گرافیک انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوزهای آن‌ها را بررسی کنید.

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

## **کاهش اندازهٔ تصویر تعبیه‌شده**

از [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) برای کاهش وضوح تصاویر تعبیه‌شده، [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) برای حذف نواحی برش‌خوردهٔ منبع و [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) برای کنترل کیفیت کدگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را با هزینهٔ کاهش وضوح تصویر یا داده‌های تصویر حفظ‌شده کاهش می‌دهند.

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

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) حد پایین رزولوشن رستر‌سازی متافایل‌ها را هنگام صادرات SVG تنظیم می‌کند. از آن برای تعادل بین جزئیات و حجم فایل زمانی که تصویری EMF یا WMF رستر می‌شود، استفاده کنید. این مقدار یک DPI کلی برای SVG تعریف نمی‌کند و همهٔ اشیاء اسلاید را به تصویر رستر تبدیل نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل حاوی یک تصویر EMF با خطوط قطری فشرده است. مثال زیر اسلاید اول آن را در سه وضوح رستر‌سازی مختلف از طریق [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/) صادر می‌کند. سایر تنظیمات صادرات همان‌گونه باقی می‌مانند تا نتایج قابل مقایسه باشند.

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

در خروجی، EMF به یک PNG تعبیه‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ ارائه‌شده است؛ این‌ها فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیستند.

| وضوح رستر‌سازی متافایل (DPI) | ابعاد PNG تعبیه‌شده | حجم فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستر تعبیه‌شده را با همان اندازهٔ نمایش بزرگ‌شده نشان می‌دهد. خطوط قطری در ۷۲ DPI پیکسل‌دار می‌شوند و در وضوح‌های بالاتر لبه‌های صاف‌تری دارند، در حالی که حجم فایل SVG بزرگ‌تر می‌شود. افزایش مقدار لزوماً تمام جزئیات را بهبود نمی‌بخشد یا هر تصویر صادرشدهٔ دیگری را تغییر نمی‌دهد.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) کاهش وضوح تصویر را کنترل می‌کند و می‌تواند تأثیر تغییر وضوح رستر‌سازی متافایل را پنهان کند. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) کیفیت کدگذاری JPEG را کنترل می‌کند، نه وضوح رستر‌سازی متافایل.

## **تخصیص شناسه‌های ثابت به اشکال و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) روی عناصر `tspan` متن نیز، [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) را پیاده‌سازی کنید. هر یک از این کنترلرها را با [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) اختصاص دهید.

کنترلر زیر از [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/) استفاده می‌کند که برای طول عمر شکل ثابت است و یک شمارندهٔ تکرارپذیر برای بازه‌های متنی آن دارد. این باعث می‌شود شناسه‌های تولیدشده برای پردازش پس از زمان ارائه‌ای که تغییری نکرده مناسب باشند.

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

## **افزودن رویدادهای SVG**

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/)، با فراخوانی [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) و مقدار [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) یک هندلر جاوااسکریپت به یک شکل صادرشده اضافه کنید. کنترلر را با [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) اختصاص دهید و تابع جاوااسکریپت را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند، تعریف کنید.

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

صفحه میزبان می‌تواند تابع جاوااسکریپت ارجاع‌داده‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان‌پذیر می‌سازد تا نمایشگرهای اسلاید، بهبودهای دسترسی و سایر جریان‌های کاری تعاملی SVG استفاده شوند.

## **سؤالات متداول**

**چه زمانی باید از [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) به جای [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) استفاده کنم؟**

وقتی همهٔ متن‌ها باید بدون وابستگی به قلم‌ها باشند، از [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) استفاده کنید. وقتی فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند باید به گرافیک تبدیل شوند، از [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) استفاده کنید.

**بهترین راه برای کوچک‌تر کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر تعبیه‌شده، حذف نواحی برش‌خوردهٔ تصویر و انتخاب فایل‌های قلم پیوندی آغاز کنید؛ به‌خصوص اگر محیط هدف می‌تواند آن‌ها را سرو کند. نتیجه را آزمایش کنید زیرا کاهش وضوح تصویر، کیفیت پایین‌تر JPEG و بردارسازی متن هرکدام تعادلی متفاوت بین کیفیت و حجم دارند.

**آیا می‌توانم پس از خروجی‌گیری عناصر SVG صادرشده را تغییر دهم؟**

بله. شناسه‌ها را از طریق یک کنترلر قالب‌بندی اختصاص دهید، سپس در ابزار پس‌پردازش یا اسکریپت مرورگر خود عناصر SVG مطابق را انتخاب کنید.