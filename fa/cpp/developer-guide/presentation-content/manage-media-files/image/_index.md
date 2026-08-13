---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها با استفاده از C++
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/cpp/image/
keywords:
- اضافه کردن تصویر
- اضافه کردن عکس
- اضافه کردن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- اضافه کردن PNG
- اضافه کردن JPG
- اضافه کردن SVG
- منابع خارجی SVG
- حل‌کننده SVG
- تصاویر SVG پیوندی
- فونت‌های SVG
- اضافه کردن EMF
- اضافه کردن WMF
- اضافه کردن TIFF
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "مدیریت تصویر را در PowerPoint و OpenDocument با Aspose.Slides برای C++ ساده کنید، عملکرد را بهینه‌سازی کرده و جریان کار خود را خودکار کنید."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب‌تر و دیدنی‌تر می‌کنند. در Microsoft PowerPoint می‌توانید عکس‌ها را از فایل‌ها، اینترنت یا منابع دیگر به اسلایدها اضافه کنید. به‌طور مشابه Aspose.Slides به شما امکان می‌دهد تصاویر را به اسلایدهای ارائه به چندین روش اضافه کنید.

{{% alert title="نکته" color="info" %}} 
Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به سرعت امکان ساخت ارائه از تصاویر را فراهم می‌کنند. 
{{% /alert %}} 

{{% alert title="اطلاعات" color="info" %}}
اگر می‌خواهید تصویر را به‌صورت قاب تصویر اضافه کنید—به‌ویژه اگر قصد تغییر اندازه، اعمال افکت یا استفاده از گزینه‌های استاندارد قالب‌بندی را دارید—به [قاب تصویر](/slides/fa/cpp/picture-frame/) مراجعه کنید. 
{{% /alert %}} 

{{% alert title="تذکر" color="warning" %}}
می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. صفحات زیر را ببینید: تبدیل [image به JPG](https://products.aspose.com/slides/fa/cpp/conversion/image-to-jpg/)، [JPG به image](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-image/)، [JPG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-png/)، [PNG به JPG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-jpg/)، [PNG به SVG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-svg/)، و [SVG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides از تصاویر در فرمت‌های محبوبی همچون JPEG، PNG، BMP، GIF و سایر فرمت‌ها پشتیبانی می‌کند. 

## **افزودن تصاویر ذخیره شده به صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر ذخیره شده روی کامپیوتر خود را به اسلایدی از ارائه اضافه کنید. کد نمونه C++ زیر نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:

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

## **افزودن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید روی کامپیوتر شما ذخیره نشده باشد، می‌توانید آن را مستقیماً از وب اضافه کنید. 

کد نمونه C++ زیر نشان می‌دهد چگونه یک تصویر را از وب به اسلاید اضافه کنید:

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

## **افزودن تصاویر به اسلاید مسترها**

یک اسلاید مستر اطلاعاتی مانند قالب و چیدمان اسلایدهای استفاده‌کننده از آن را ذخیره و کنترل می‌کند. وقتی یک تصویر را به اسلاید مستر اضافه می‌کنید، تصویر بر روی تمام اسلایدهای مبتنی بر آن مستر ظاهر می‌شود. 

کد نمونه C++ زیر نشان می‌دهد چگونه یک تصویر را به اسلاید مستر اضافه کنید:

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

## **افزودن تصاویر به عنوان پس‌زمینه اسلایدها**

می‌توانید یک عکس را به‌عنوان پس‌زمینه برای یک یا چند اسلاید استفاده کنید. برای جزئیات بیشتر، به *[تنظیم تصاویر به‌عنوان پس‌زمینه برای اسلایدها](/slides/fa/cpp/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **افزودن SVG به ارائه‌ها**

محتوای SVG را می‌توان با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/svgimage/) به یک ارائه اضافه کرد. شیء حاصل [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) سپس می‌تواند به مجموعهٔ تصاویر ارائه اضافه شده و برای ساخت یک قاب تصویر استفاده شود.

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

فایل‌های SVG که از ابزارهای طراحی، ویرایشگرهای دیاگرام، سیستم‌های آیکن یا خطوط لوله وب استخراج می‌شوند ممکن است به منابعی که خارج از سند SVG ذخیره شده‌اند ارجاع دهند. به‌عنوان مثال، یک SVG می‌تواند شامل یک لینک تصویر مانند `images/photo.png`، مقدار CSS `url(...)` یا URL یک فونت باشد. 

برای وارد کردن چنین محتوای SVG‌ای، یک پیاده‌سازی از [IExternalResourceResolver](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/iexternalresourceresolver/) ایجاد کنید و همراه با یک URI پایه، به سازندهٔ مناسب `SvgImage` پاس دهید. URI پایه محل سند SVG را شناسایی می‌کند و برای حل لینک‌های نسبی استفاده می‌شود. 

اینترفیس [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) دسترسی به اطلاعات SVG وارد شده را فراهم می‌کند:

- `get_SvgContent()` رشتهٔ markup SVG را برمی‌گرداند.  
- `get_SvgData()` محتوا را به‌صورت آرایهٔ بایت برمی‌گرداند.  
- `get_BaseUri()` URI پایهٔ استفاده‌شده برای لینک‌های نسبی را برمی‌گرداند.  
- `get_ExternalResourceResolver()` حل‌کنندهٔ اختصاص داده‌شده به تصویر SVG را برمی‌گرداند.  

### **پیاده‌سازی حل‌کننده منبع خارجی**

حل‌کننده دو متد دارد:

- [ResolveUri](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) URI پایه و یک لینک منبع نسبی را ترکیب کرده و URI مطلقی برمی‌گرداند. هنگام عدم امکان حل یا غیرمجاز بودن لینک، یک رشتهٔ null برگردانید.  
- [GetEntity](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) یک جریان قابل خواندن برای URI منبع مطلق برمی‌گرداند. وقتی منبع گم شده، مسدود یا در دسترس نیست، `nullptr` برگردانید. در صورت مناسب بودن می‌توان یک جریان جایگزین نیز برگرداند.  

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

        // فقط برای منابع تصویری از یک جایگزین استفاده کنید. بازگشت یک جریان تصویر
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

### **حل کردن منابع پیوندی هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` شامل یک ارجاع نسبی مانند زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

کد نمونه C++ زیر URI فایل SVG را به‌عنوان URI پایه پاس می‌دهد و یک حل‌کنندهٔ سفارشی فراهم می‌کند. حل‌کننده لینک تصویر نسبی را به URI مطلق تبدیل کرده و یک جریان حاوی منبع پیوندی را برمی‌گرداند در حالی که Aspose.Slides SVG را پردازش می‌کند.

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

// URI پایه مکان سند SVG را نشان می‌دهد.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage محتوای منبع، داده‌های باینری، URI پایه و حل‌کننده را در اختیار می‌گذارد.
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

کلاس `SvgImage` همچنین overloadهایی دارد که داده‌های SVG را به‌صورت آرایهٔ بایت یا جریان می‌پذیرند، به‌همراه حل‌کنندهٔ منابع خارجی و URI پایه. 

{{% alert title="مهم" color="warning" %}}
حل‌کنندهٔ منابع، منابع خارجی را در حین پردازش و رندر SVG توسط Aspose.Slides در دسترس می‌گذارد. این کار هیچ تغییری در markup اصلی SVG ایجاد نمی‌کند و به‌صورت خودکار منابع حل‌شده را درون SVG جاسازی نمی‌کند.  

وقتی یک `ISvgImage` به مجموعهٔ تصاویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هم نمای اصلی SVG و هم یک تصویر رستر جایگزین را داشته باشد. یک منبع پیوندی می‌تواند در تصویر جایگزین تولیدشده ظاهر شود در حالی که لینک نسبی مانند `images/photo.png` بدون تغییر در SVG ذخیره‌شده باقی می‌ماند. برنامه‌ای که نمای SVG بومی را رندر می‌کند ممکن است هنگام عدم دسترسی به منبع خارجی اصلی، محتوای پیوندی را نادیده بگیرد.  
{{% /alert %}}

### **ساخت یک تصویر SVG قابل حمل**

برای ساخت یک تصویر SVG که به فایل‌های خارجی وابسته نیست، پیش از ایجاد `SvgImage`، SVG را به‌صورت خودکفا کنید. به‌عنوان مثال، URLهای تصویر پیوندی را با URIهای `data:` که شامل داده تصویر هستند، جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از جاسازی تمام منابع مورد نیاز در محتوای SVG، `SvgImage` را ایجاد کنید، به مجموعهٔ تصاویر ارائه اضافه کنید و همان‌طور که در مثال قبلی نشان داده شد، در یک قاب تصویر قرار دهید. 

### **مدیریت منابع گم‌شده یا مسدود شده**

وقتی یک URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد، از `ResolveUri` یک رشتهٔ null برگردانید. وقتی منبع قابل خواندن نیست، از `GetEntity` `nullptr` برگردانید. Aspose.Slides در صورت امکان، پردازش SVG را بدون آن منبع ادامه می‌دهد.  

یک جریان جایگزین می‌تواند برای منبع گم‌شده بازگردانده شود، اما محتوا باید با نوع منبع درخواست‌شده سازگار باشد. به‌عنوان مثال، فقط برای تصویر گم‌شده یک جریان تصویر برگردانید؛ نه برای فونت یا stylesheet. 

{{% alert title="امنیت" color="warning" %}}
از حل مسیرهای فایل دلخواه یا URLهای شبکه‌ای بدون محدودیت در فایل‌های SVG ناشناخته خودداری کنید. طرح‌واره‌ها، مسیرها و میزبان‌های مجاز را محدود کنید. برای منابع شبکه‌ای، زمان‑انتهای اتصال، محدودیت‌های اندازه پاسخ و اعتبارسنجی محتوا را نیز اعمال کنید.  
{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از اشکال**
Aspose.Slides می‌تواند یک SVG را به مجموعه‌ای از اشکال تبدیل کند، مشابه عملکرد مشابه در PowerPoint:

![منوی پاپ‑آپ پاورپوینت](img_01_01.png)

این قابلیت توسط overloadی از متد [AddGroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/) در اینترفیس [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/) که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) را به‌عنوان اولین آرگومان می‌گیرد، فراهم می‌شود. 

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

// ایجاد شیء SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// دریافت اندازه اسلاید
auto slideSize = presentation->get_SlideSize()->get_Size();

// تبدیل تصویر SVG به یک گروه از اشکال و مقیاس‌بندی آن به اندازه اسلاید
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// ذخیره ارائه در قالب PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **افزودن تصاویر به‌صورت EMF به اسلایدها**
Aspose.Slides برای C++ به شما امکان می‌دهد تصاویر EMF را از کاربرگ‌های Excel با Aspose.Cells تولید کرده و به اسلایدهای ارائه اضافه کنید. 

کد نمونه C++ زیر نشان می‌دهد چگونه این کار انجام شود:

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

// Aspose.Cells برای C++ باید پیش از استفاده از هر یک از انواع آن راه‌اندازی شود.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// رندر کردن برگه کاری به صورت EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
        // Aspose.Cells صفحه رندر شده را به‌صورت یک بافر بازمی‌گرداند که Aspose.Slides به‌عنوان تصویر اضافه می‌کند.
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

## **جایگزینی تصاویر در مجموعهٔ تصاویر**
Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعهٔ تصاویر یک ارائه، از جمله تصاویری که توسط اشکال اسلاید استفاده می‌شوند، را جایگزین کنید. این بخش چندین روش برای به‌روزرسانی تصاویر در مجموعه را توصیف می‌کند. می‌توانید یک تصویر را با داده‌های بایتی خام، یک نمونهٔ [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) یا تصویر دیگری که پیشاپیش در مجموعه وجود دارد، جایگزین کنید.

مراحل زیر را دنبال کنید:

1. ارائه‌ای که شامل تصاویر است را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید.  
2. یک تصویر جدید را از فایل به آرایهٔ بایت بارگذاری کنید.  
3. تصویر هدف را با تصویر جدید با استفاده از آرایهٔ بایت جایگزین کنید.  
4. در روش دوم، تصویر را به‌صورت شیء [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.  
5. در روش سوم، تصویر هدف را با تصویری که پیشاپیش در مجموعهٔ تصاویر ارائه وجود دارد، جایگزین کنید.  
6. ارائه‌ٔ اصلاح‌شده را به‌صورت فایل PPTX بنویسید.  

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

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

// ذخیرهٔ ارائه در یک فایل.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="اطلاعات" color="info" %}}
با مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) از Aspose می‌توانید به‌سادگی متن را متحرک کنید و GIFهایی از متن ایجاد کنید. 
{{% /alert %}}

## **پرسش‌های متداول**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**  
بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی به نحوهٔ مقیاس‌گذاری [قاب](/slides/fa/cpp/picture-frame/) در اسلاید و هر فشرده‌سازی انجام‌شده هنگام ذخیره‌سازی بستگی دارد.  

**بهترین روش برای جایگزینی همان لوگو در ده‌ها اسلاید به‌صورت همزمان چیست؟**  
لوگو را در اسلاید مستر یا یک چیدمان قرار داده و در مجموعهٔ تصاویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، منتشر می‌شود.  

**آیا می‌توان SVG وارد‌شده را به اشکال قابل ویرایش تبدیل کرد؟**  
بله. می‌توانید یک SVG را به‌صورت گروهی از اشکال تبدیل کنید؛ سپس هر بخش به‌صورت جداگانه با ویژگی‌های استاندارد اشکال قابل ویرایش می‌شود.  

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چندین اسلاید به‌صورت همزمان تنظیم کرد؟**  
[تصویر را به‌عنوان پس‌زمینه](/slides/fa/cpp/presentation-background/) در اسلاید مستر یا چیدمان مربوطه اختصاص دهید—هر اسلایدی که از آن مستر/چیدمان استفاده می‌کند، پس‌زمینه را به ارث می‌برد.  

**چگونه می‌توان از بزرگ‌شدن بیش از حد یک ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کرد؟**  
به‌جای استفادهٔ تکراری از تصاویر، یک منبع تصویر واحد را دوباره استفاده کنید، وضوح مناسب را انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر جایگزین کنید.