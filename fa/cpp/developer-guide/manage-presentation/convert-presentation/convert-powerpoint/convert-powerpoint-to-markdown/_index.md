---
title: "تبدیل ارائه‌های PowerPoint به Markdown در C++"
linktitle: "PowerPoint به Markdown"
type: docs
weight: 140
url: /fa/cpp/convert-powerpoint-to-markdown/
keywords:
- "تبدیل PowerPoint"
- "تبدیل ارائه"
- "تبدیل اسلاید"
- "تبدیل PPT"
- "تبدیل PPTX"
- "PowerPoint به MD"
- "ارائه به MD"
- "اسلاید به MD"
- "PPT به MD"
- "PPTX به MD"
- "ذخیره PowerPoint به‌عنوان Markdown"
- "ذخیره ارائه به‌عنوان Markdown"
- "ذخیره اسلاید به‌عنوان Markdown"
- "ذخیره PPT به‌عنوان MD"
- "ذخیره PPTX به‌عنوان MD"
- "صادر کردن PPT به MD"
- "صادر کردن PPTX به MD"
- "صادرات تصویر Markdown"
- "پیوندهای تصویر CDN"
- "PowerPoint"
- "ارائه"
- "Markdown"
- "C++"
- "Aspose.Slides"
description: "PPT و ارائه‌های PPTX را به Markdown در C++ تبدیل کنید و مکان ذخیره‌سازی و ارجاع تصاویر bitmap، metafile و SVG صادرشده را کنترل کنید."
---
## **نمای کلی**

Aspose.Slides for C++ می‌تواند ارائه‌های PPT و PPTX را به Markdown برای مستندسازی، سایت‌های ثابت، مهاجرت محتوا و جریان‌های کاری کنترل نسخه تبدیل کند. شما می‌توانید یک نوع Markdown را انتخاب کنید، نحوه رندر محتوای اسلاید را کنترل کنید و تعیین کنید که تصاویر صادر شده در کجا ذخیره شوند و Markdown تولید شده چگونه به آن‌ها ارجاع دهد.

به طور پیش‌فرض، خروجی Markdown فقط متن را تولید می‌کند. برای خروجی محتوای بصری، متد [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) را به مقدار `Sequential` یا `Visual` از enumeration [MarkdownExportType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownexporttype/) تنظیم کنید. `Sequential` آیتم‌های اسلاید را به‌صورت جداگانه و به ترتیب رندر می‌کند، در حالی که `Visual` آیتم‌های گروه‌بندی‌شده را همراه هم نگه می‌دارد تا رابطه بصری آن‌ها حفظ شود. مقدار `TextOnly` هیچ منبع تصویری تولید نمی‌کند، بنابراین رویدادهای ذخیره‌سازی تصویر در آن حالت فراخوانی نمی‌شوند.

## **تبدیل یک ارائه به Markdown**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید و سپس متد [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) را با مقدار `Md` از enumeration [SaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) فراخوانی کنید.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **انتخاب یک نوع Markdown**

متد [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) مشخص می‌کند که کدام مشخصات Markdown برای خروجی استفاده شود. enumeration [Flavor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/flavor/) شامل CommonMark، GitHub Flavored Markdown و دیگر واریانت‌های پشتیبانی‌شده است.

مثال زیر یک ارائه را به‌صورت CommonMark صادر می‌کند:

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

## **ذخیره‌سازی تصاویر با رفتار پیش‌فرض ذخیره‌سازی محلی**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/) دو متد برای پیکربندی ذخیره‌سازی محلی تصاویر فراهم می‌کند:

- [set_BasePath](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) مسیر پایه برای سند Markdown و منابع آن را تعیین می‌کند.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) زیرپوشه تصویر را مشخص می‌کند. مقدار پیش‌فرض آن `Images` است.

مثال زیر محتوای بصری را رندر می‌کند، تصاویر را در `output/assets` می‌نویسد و ارجاعات نسبی تصویر را در سند Markdown ایجاد می‌کند:

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

این رفتار همچنین به‌عنوان بازگشت‌پذیری عمل می‌کند وقتی یک پردازش‌کننده سفارشی ذخیره‌سازی تصویر `false` برمی‌گرداند.

## **سفارشی‌سازی ذخیره‌سازی تصویر و لینک‌های Markdown**

از رویداد `MarkdownSaveOptions::ImageSaving` برای منابع bitmap و metafile غیر‑SVG که هنگام صادرات Markdown تولید می‌شوند استفاده کنید. نمایندهٔ آن، [MarkdownImageSavingHandler](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/)، شیء [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/)، [ImageFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imageformat/) و لینک Markdown تولید شده به‌صورت پارامتر `System::String&` دریافت می‌کند. تصویر را با فرمت ارائه‌شده ذخیره یا بارگذاری کنید و `link` را با ارجاعی که باید در خروجی Markdown ظاهر شود جایگزین کنید.

منابع تولید‌شده به فرمت SVG به‌صورت جداگانه مدیریت می‌شود. به رویداد `MarkdownSaveOptions::SvgImageSaving` مشترک شوید؛ نمایندهٔ [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) شیء [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) و پارامتر `System::String& link` را دریافت می‌کند. برای SVG آرگومان `ImageFormat` وجود ندارد؛ به‌جای آن دادهٔ XML را از متد [ISvgImage::get_SvgData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/get_svgdata/) بنویسید یا بارگذاری کنید. بسته به حالت خروجی و گروه‌بندی بصری، یک SVG در ارائه منبع می‌تواند رستریزه یا با محتوای دیگر ترکیب شود؛ منبع غیر‑SVG حاصل سپس به `ImageSaving` ارسال می‌شود. هر دو رویداد را زمانی که هر منبع بصری صادرشده نیاز به پردازش سفارشی دارد، مشترک شوید.

مقدار بازگشتی پردازش‌کننده تعیین می‌کند که چه کسی تصویر را پردازش می‌کند:

- پس از این‌که پردازش‌کننده تصویر را ذخیره، بارگذاری، تبدیل یا به‌هر شکل دیگر پردازش کرد و مقدار معتبری به `link` اختصاص داد، `true` برگردانید. Aspose.Slides آن مقدار را به‌صورت لینک در سند Markdown می‌نویسد و ذخیره‌سازی محلی پیش‌فرض را انجام نمی‌دهد.
- `false` برگردانید تا Aspose.Slides تصویر را به‌صورت محلی ذخیره کند و لینک آن را بر اساس [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) و [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) تولید کند.

{{% alert color="warning" title="Important" %}}
یک پردازش‌کننده که `true` برمی‌گرداند مسئولیت تصویر را بر عهده می‌گیرد. اگر بدون اختصاص یک لینک معتبر و غیرخالی `true` برگرداند، صادرات با `InvalidOperationException` شکست می‌خورد.
{{% /alert %}}

### **ذخیره‌سازی تصاویر در یک پوشهٔ مبدأ CDN و استفاده از URLهای خارجی**

مثال زیر پوشهٔ `cdn-origin/presentations/quarterly-report` را به‌عنوان یک پوشهٔ مبدأ CDN سوار یا همگام‌سازی‌شده در نظر می‌گیرد. هر پردازش‌کننده نام فایل تولید شده را استخراج می‌کند، تصویر را در آن پوشهٔ سفارشی ذخیره می‌کند و مرجع محلی تولید شده را با یک URL عمومی CDN جایگزین می‌کند. خود نمونه هیچ بارگذاری شبکه‌ای انجام نمی‌دهد: URL تنها پس از سوار شدن پوشه به‌عنوان مبدأ CDN یا انتشار فایل‌ها در CDN معتبر می‌شود. برای ذخیره‌سازی شیء، نوشتن بر روی سیستم‌فایل را با عملیات بارگذاری SDK ذخیره‌سازی جایگزین کنید و `link` را فقط پس از موفقیت بارگذاری اختصاص دهید.

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

پردازش‌کنندهٔ bitmap به‌صراحت برای تصاویر کوچکتر از 128 × 128 پیکسل `false` برمی‌گرداند، بنابراین Aspose.Slides این تصاویر را به‌صورت پیش‌فرض در `output/fallback-images` ذخیره می‌کند. منابع bitmap و metafile بزرگ‌تر و همچنین منابع SVG توسط کد سفارشی پردازش می‌شوند. برای مثال، مرجع محلی تولید‌شده‌ای مانند `fallback-images/image1.png` به `https://cdn.example.com/presentations/quarterly-report/image1.png` تبدیل می‌شود. پردازش‌کننده‌ها فقط هنگام نوشتن فایل‌ها از مسیرهای سیستم‌عامل استفاده می‌کنند؛ لینک‌های نوشته‌شده در Markdown از اسلش‌های جلو (`/`) و نام‌های فایل URL‑escaped استفاده می‌کنند. هنگام ساخت لینک‌های نسبی همین قاعده را اعمال کنید: از `/` استفاده کنید، نه جداکنندهٔ مخصوص پلتفرم.

## **سؤالات متداول**

**آیا یک پردازش‌کننده می‌تواند هم تصاویر رستری و هم تصاویر SVG را پردازش کند؟**

خیر. برای منابع bitmap و metafile غیر‑SVG از `MarkdownSaveOptions::ImageSaving` و برای منابع تولید‌شده به‌صورت SVG از `MarkdownSaveOptions::SvgImageSaving` استفاده کنید. اولی شیء [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) و [ImageFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imageformat/) را فراهم می‌کند؛ دومی شیء [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) که دادهٔ SVG آن را می‌توانید با [ISvgImage::get_SvgData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/get_svgdata/) بخوانید، ارائه می‌دهد. یک SVG منبع که هنگام صادرات رستریزه می‌شود توسط `ImageSaving` پردازش می‌شود.

**وقتی یک پردازش‌کنندهٔ ذخیره‌سازی تصویر `false` برمی‌گرداند چه رخ می‌دهد؟**

Aspose.Slides از رفتار پیش‌فرض ذخیره‌سازی محلی خود استفاده می‌کند. مکان تصویر و مرجع تولید‌شده توسط [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) و [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) کنترل می‌شوند.

**آیا یک پردازش‌کننده می‌تواند بدون ذخیرهٔ محلی تصویر، یک URL ارائه دهد؟**

بله. پردازش‌کننده می‌تواند تصویر را در ذخیره‌سازی شیء بارگذاری کند یا به سرویس دیگری بفرستد، URL حاصل را به `link` اختصاص دهد و `true` برگرداند. پردازش‌کننده باید خود تمام پردازش را تکمیل کند؛ بازگشت `true` مانع ذخیره‌سازی محلی پیش‌فرض می‌شود.

**چرا صادرات Markdown یک `InvalidOperationException` از یک پردازش‌کننده می‌تابد؟**

این استثناء زمانی رخ می‌دهد که پردازش‌کننده `true` برگرداند اما لینک معتبری ارائه ندهد. پیش از بازگشت `true` مسیر نسبی یا URL خارجی که باید در Markdown نوشته شود را به `link` اختصاص دهید.

**کدام جداکننده مسیر باید برای لینک‌های تصویر استفاده شود؟**

در لینک‌های Markdown و URL از اسلش‌های جلو (`/`) استفاده کنید. برای مسیرهای سیستم‌فایل فقط از `Path::Combine` بهره بگیرید و سپس مرجع Markdown را جداگانه ساخت یا نرمال‌سازی کنید.

**آیا پیوندهای ابرمتنی در طول صادرات Markdown حفظ می‌شوند؟**

بله. پیوندهای متنی [hyperlinks](/slides/fa/cpp/manage-hyperlinks/) به‌صورت لینک‌های استاندارد Markdown نگهداری می‌شوند. انتقال‌های اسلاید [transitions](/slides/fa/cpp/slide-transition/) و انیمیشن‌های اسلاید [animations](/slides/fa/cpp/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توان ارائه‌ها را به‌صورت موازی به Markdown تبدیل کرد؟**

می‌توانید فایل‌های ارائه مختلف را به‌صورت موازی پردازش کنید، اما نباید همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک بگذارید. دستورالعمل‌های [multithreading](/slides/fa/cpp/multithreading/) را دنبال کنید و برای هر فایل یک نمونهٔ جداگانه استفاده کنید.