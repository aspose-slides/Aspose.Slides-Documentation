---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها با استفاده از C++
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/cpp/image/
keywords:
- افزودن تصویر
- افزودن عکس
- افزودن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- منابع خارجی SVG
- حلال SVG
- تصاویر SVG پیوندی
- فونت‌های SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "مدیریت تصویر در PowerPoint و OpenDocument را با Aspose.Slides برای C++ بهینه کنید، عملکرد را بهبود بخشیده و گردش کار خود را خودکار کنید."
---
## **معرفی**

تصاویر، ارائه‌ها را جذاب‌تر و بصری‌تر می‌سازند. در مایکروسافت پاورپوینت می‌توانید تصاویر را از فایل‌ها، اینترنت یا منابع دیگر به اسلایدها اضافه کنید. به طور مشابه، Aspose.Slides به شما امکان می‌دهد تصاویر را به اسلایدهای ارائه به روش‌های مختلف اضافه کنید. 

{{% alert title="Tip" color="primary" %}} 

Aspose تبدیل‌کننده‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را ارائه می‌دهد که به شما امکان می‌دهد به سرعت ارائه‌ها را از تصاویر ایجاد کنید. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

اگر می‌خواهید تصویر را به‌عنوان فریم تصویر اضافه کنید—به‌ویژه اگر قصد تغییر اندازه، اعمال اثرات یا استفاده از گزینه‌های استاندارد قالب‌بندی را دارید—به [فریم تصویر](/slides/fa/cpp/picture-frame/) مراجعه کنید. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

شما می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. صفحات زیر را ببینید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/cpp/conversion/image-to-jpg/)، [JPG به تصویر](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-image/)، [JPG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-png/)، [PNG به JPG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-jpg/)، [PNG به SVG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-svg/)، و [SVG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides تصاویر را در فرمت‌های محبوبی مانند JPEG، PNG، BMP، GIF و سایر فرمت‌ها پشتیبانی می‌کند. 

## **اضافه کردن تصاویر ذخیره شده به‌صورت محلی به اسلایدها**

شما می‌توانید یک یا چند تصویر ذخیره‌شده بر روی کامپیوتر خود را به یک اسلاید ارائه اضافه کنید. کد نمونه C++ زیر نشان می‌دهد چگونه یک تصویر به اسلاید اضافه شود:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **اضافه کردن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید بر روی کامپیوتر شما ذخیره نشده باشد، می‌توانید آن را مستقیماً از وب اضافه کنید. 

کد نمونه C++ زیر نشان می‌دهد چگونه یک تصویر از وب به اسلاید اضافه شود:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **اضافه کردن تصاویر به اسلاید مسترها**

یک اسلاید مستر اطلاعاتی مانند تم و چینش را برای اسلایدهایی که از آن استفاده می‌کنند ذخیره و کنترل می‌کند. هنگامی که تصویری به اسلاید مستر اضافه می‌کنید، تصویر بر روی هر اسلایدی که بر پایه آن مستر ساخته شده است ظاهر می‌شود. 

کد نمونه C++ زیر نشان می‌دهد چگونه یک تصویر به اسلاید مستر اضافه شود:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **اضافه کردن تصاویر به‌عنوان پس‌زمینه اسلایدها**

شما می‌توانید از یک تصویر به‌عنوان پس‌زمینه برای یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[تنظیم تصاویر به‌عنوان پس‌زمینه اسلایدها](/slides/fa/cpp/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **اضافه کردن SVG به ارائه‌ها**

محتویات SVG می‌توانند با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/svgimage/) به یک ارائه اضافه شوند. شیء [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) حاصل می‌تواند سپس به مجموعه تصاویر ارائه اضافه شده و برای ایجاد فریم تصویر استفاده شود. 

مثال C++ زیر یک رشته SVG مستقل را وارد می‌کند. تمام تصاویر، سبک‌ها و سایر منابع استفاده‌شده توسط این SVG به‌صورت مستقیم در محتوای SVG تعبیه شده‌اند.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **وارد کردن محتوای SVG با منابع خارجی**

فایل‌های SVG صادر شده از ابزارهای طراحی، ویرایشگرهای دیاگرام، سیستم‌های آیکون و خطوط لوله وب ممکن است به منابعی که خارج از سند SVG ذخیره شده‌اند ارجاع دهند. به‌عنوان مثال، یک SVG ممکن است شامل لینک تصویری مانند `images/photo.png`، مقدار CSS `url(...)` یا URL فونت باشد. 

برای وارد کردن چنین محتوای SVG، یک پیاده‌سازی از [IExternalResourceResolver](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/iexternalresourceresolver/) ایجاد کنید و آن را به‌همراه یک URI پایه به سازنده مناسب `SvgImage` پاس بدهید. URI پایه مکان سند SVG را شناسایی می‌کند و برای حل لینک‌های نسبی استفاده می‌شود. 

رابط [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) دسترسی به اطلاعات مربوط به SVG وارد شده را فراهم می‌کند:

- `get_SvgContent()` کد مارکاپ SVG را به‌صورت رشته برمی‌گرداند.  
- `get_SvgData()` محتویات SVG را به‌صورت آرایه بایت برمی‌گرداند.  
- `get_BaseUri()` URI پایه استفاده‌شده برای لینک‌های نسبی را برمی‌گرداند.  
- `get_ExternalResourceResolver()` حل‌کننده‌ای که به تصویر SVG اختصاص داده شده است را برمی‌گرداند.  

### **پیاده‌سازی حل‌کننده منابع خارجی**

حل‌کننده دو متد دارد:

- [ResolveUri](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) URI پایه و لینک منبع نسبی را ترکیب کرده و یک URI مطلق برمی‌گرداند. زمانی که لینک قابل حل نیست یا اجازه ندارد، یک رشته null برگردانده شود.  
- [GetEntity](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) یک جریان قابل خواندن برای یک URI منبع مطلق برمی‌گرداند. وقتی منبع گمشده، مسدود یا در دسترس نیست، `nullptr` برگردانده شود. در موارد مناسب می‌توان یک جریان جایگزین نیز برگرداند.  

حل‌کننده زیر فقط منابع پیوندی را از یک دایرکتوری محلی مجاز بارگیری می‌کند. منابع شبکه‌ای و مسیرهای خارج از دایرکتوری مجاز مسدود می‌شوند. یک تصویر جایگزین اختیاری برای لینک‌های تصویری نامحلول برگردانده می‌شود.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // این حل‌کننده به‌صورت عمدی فقط به فایل‌های محلی اجازه می‌دهد.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // فقط برای منابع تصویری از تصویر جایگزین استفاده کنید. بازگرداندن یک جریان تصویر
        // برای یک فونت یا stylesheet گمشده معتبر نخواهد بود.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **حل منابع پیوندی هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` شامل یک ارجاع نسبی مانند زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

مثال C++ زیر URI فایل SVG را به‌عنوان URI پایه پاس می‌دهد و یک حل‌کننده سفارشی فراهم می‌کند. حل‌کننده لینک تصویر نسبی را به یک URI مطلق تبدیل کرده و یک جریان حاوی منبع پیوندی را باز می‌گرداند هنگامی که Aspose.Slides SVG را پردازش می‌کند.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// URI پایه موقعیت سند SVG را نشان می‌دهد.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage محتوا منبع، داده‌های باینری، URI پایه و حل‌کننده را در اختیار می‌گذارد.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

کلاس `SvgImage` همچنین overloadهایی ارائه می‌دهد که داده‌های SVG را به‌صورت آرایه بایت یا جریان می‌پذیرند، به‌همراه یک حل‌کننده منابع خارجی و یک URI پایه. 

{{% alert title="Important" color="warning" %}}

حل‌کننده منابع منابع خارجی را هنگام پردازش و رندر SVG توسط Aspose.Slides در دسترس می‌گذارد. این حل‌کننده کد مارکاپ اصلی SVG را تغییر نمی‌دهد یا به‌طور خودکار منابع حل‌شده را در آن تعبیه نمی‌کند.

هنگامی که یک `ISvgImage` به مجموعه تصاویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هم نمایهٔ اصلی SVG و هم یک تصویر جایگزین raster را شامل شود. یک منبع پیوندی می‌تواند در تصویر جایگزین تولیدشده ظاهر شود در حالی که یک لینک نسبی مانند `images/photo.png` در SVG ذخیره‌شده بدون تغییر می‌ماند. بنابراین برنامه‌ای که نمایهٔ بومی SVG را رندر می‌کند ممکن است محتویات پیوندی را هنگامی که منبع خارجی اصلی در دسترس نیست، حذف کند.

{{% /alert %}}

### **ایجاد تصویر SVG قابل حمل**

برای ایجاد یک تصویر SVG که وابسته به فایل‌های خارجی نباشد، قبل از ساخت `SvgImage`، SVG را به‌صورت خودکفا کنید. به‌عنوان مثال، URLهای تصاویر پیوندی را با URIهای `data:` که شامل داده‌های تصویر هستند، جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از اینکه تمام منابع مورد نیاز در محتوای SVG تعبیه شدند، `SvgImage` را ایجاد کنید، آن را به مجموعه تصاویر ارائه اضافه کنید و همان‌طور که در مثال قبلی نشان داده شد، در یک فریم تصویر وارد کنید. 

### **مدیریت منابع گمشده یا مسدودشده**

در زمانیکه URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد، یک رشته null از `ResolveUri` برگردانید. زمانی که منبع قابل خواندن نیست، `nullptr` از `GetEntity` برگردانید. Aspose.Slides در صورت امکان پردازش SVG را بدون آن منبع ادامه می‌دهد. 

یک جریان جایگزین می‌تواند برای منبع گمشده برگردانده شود، اما محتویات آن باید با نوع منبع درخواست‌شده سازگار باشد. به‌عنوان مثال، فقط برای تصویر غایب یک جریان تصویری برگردانید، نه برای فونت یا استایل‌شیت. 

{{% alert title="Security" color="warning" %}}

از حل مسیرهای فایل دلخواه یا URLهای شبکه‌ای نامحدود در فایل‌های SVG غیرقابل اعتماد خودداری کنید. طرح‌ها، دایرکتوری‌ها و میزبان‌های مجاز را محدود کنید. برای منابع شبکه‌ای، محدودیت‌های زمانی اتصال، حداکثر حجم پاسخ و اعتبارسنجی محتوا را نیز اعمال کنید. 

{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از اشکال**
Aspose.Slides می‌تواند یک SVG را به مجموعه‌ای از اشکال تبدیل کند، مشابه عملکرد متناظر در PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

این قابلیت توسط یک overload از متد [AddGroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/) رابط [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/) فراهم می‌شود که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) را به‌عنوان اولین آرگومان می‌گیرد. 

کد نمونه C++ زیر نشان می‌دهد چگونه از این متد برای تبدیل یک فایل SVG به مجموعه‌ای از اشکال استفاده شود:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// نام فایل SVG منبع
auto svgFileName = System::String(u"sample.svg");

// نام فایل خروجی ارائه
auto outPptxPath = System::String(u"presentation.pptx");

// ایجاد یک ارائه جدید
auto presentation = System::MakeObject<Presentation>();

// خواندن محتوای فایل SVG
auto svgContent = File::ReadAllText(svgFileName);

// ایجاد یک شیء SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// دریافت اندازه اسلاید
auto slideSize = presentation->get_SlideSize()->get_Size();

// تبدیل تصویر SVG به یک گروه از شکل‌ها و مقیاس‌بندی آن به اندازه اسلاید
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// ذخیره ارائه در قالب PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **اضافه کردن تصاویر به‌صورت EMF به اسلایدها**
Aspose.Slides برای C++ به شما امکان می‌دهد تصاویر EMF را از جداول Excel با Aspose.Cells تولید کرده و به اسلایدهای ارائه اضافه کنید.

کد نمونه C++ زیر نحوه انجام این کار را نشان می‌دهد:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells برای C++ باید قبل از استفاده از هر یک از انواع آن راه‌اندازی شود.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Render the worksheet as EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells صفحه رندر شده را به‌عنوان یک بافر برمی‌گرداند، که Aspose.Slides آن را به‌عنوان تصویر اضافه می‌کند.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **جایگزینی تصاویر در مجموعه تصاویر**
Aspose.Slides به شما امکان می‌دهد تصاویر ذخیره‌شده در مجموعه تصاویر یک ارائه، از جمله تصاویر استفاده‌شده توسط شکل‌های اسلاید را جایگزین کنید. این بخش چندین روش برای بروزرسانی تصاویر در مجموعه را توضیح می‌دهد. می‌توانید تصویر را با استفاده از داده‌های بایت خام، یک نمونهٔ [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه موجود است، جایگزین کنید.

مراحل زیر را دنبال کنید:

1. پرزنتیشن حاوی تصاویر را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید.  
2. یک تصویر جدید را از فایل به‌صورت آرایه بایت بارگذاری کنید.  
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.  
4. در روش دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) بارگذاری کرده و تصویر هدف را با آن شیء جایگزین کنید.  
5. در روش سوم، تصویر هدف را با تصویری که پیش از این در مجموعه تصاویر ارائه وجود دارد، جایگزین کنید.  
6. پرزنتیشن اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// یک شیء از کلاس Presentation که نشان‌دهنده یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// روش اول.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// روش دوم.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// روش سوم.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// ارائه را در یک فایل ذخیره کنید.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

با مبدل رایگان [متن به GIF](https://products.aspose.app/slides/fa/text-to-gif) Aspose، به‌راحتی می‌توانید متن را پویا کنید و GIFهایی از متن ایجاد کنید. 

{{% /alert %}}

## **FAQ**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی بستگی به نحوهٔ مقیاس‌گذاری [تصویر](/slides/fa/cpp/picture-frame/) در اسلاید و هر گونه فشرده‌سازی اعمال‌شده هنگام ذخیره دارد.

**بهترین روش برای جایگزینی یک لوگوی یکسان در ده‌ها اسلاید به‌صورت همزمان چیست؟**

لوگو را در اسلاید مستر یا یک لایه قرار دهید و آن را در مجموعه تصاویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، انتشار می‌یابد.

**آیا می‌توان SVG وارد شده را به اشکال قابل ویرایش تبدیل کرد؟**

بله. می‌توانید SVG را به یک گروه از اشکال تبدیل کنید، به‌طوری که پس از آن قسمت‌های جداگانه با ویژگی‌های استاندارد شکل قابل ویرایش شوند.

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چندین اسلاید به‌صورت همزمان تنظیم کرد؟**

[تصویر را به‌عنوان پس‌زمینه تنظیم](/slides/fa/cpp/presentation-background/) کنید در اسلاید مستر یا چیدمان مربوطه—هر اسلایدی که از آن مستر/چیدمان استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

**چگونه می‌توان از بزرگ شدگی بیش از حد یک ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کرد؟**

به‌جای استفاده از تصویرهای تکراری، یک منبع تصویر را دوباره استفاده کنید، رزولوشن‌های منطقی انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید، در صورت مناسب.