---
title: تحسين إدارة الصور في العروض التقديمية باستخدام C++
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/cpp/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة صورة نقطية
- استبدال صورة
- استبدال صورة
- من الويب
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- موارد SVG الخارجية
- محلل SVG
- صور SVG المرتبطة
- خطوط SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++، مما يحسن الأداء ويُؤتمت سير العمل الخاص بك."
---
## **المقدمة**

تجعل الصور العروض التقديمية أكثر جاذبية وجمالاً بصرياً. في Microsoft PowerPoint، يمكنك إدراج صور إلى الشرائح من ملفات أو الإنترنت أو مصادر أخرى. وبالمثل، تسمح لك مكتبة Aspose.Slides بإضافة صور إلى شرائح العرض بطرق متعددة.

{{% alert title="نصيحة" color="info" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تتيح لك إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا أردت إضافة صورة كإطار صورة—خاصة إذا كنت تخطط لتغيير حجمها أو تطبيق تأثيرات أو استخدام خيارات تنسيق قياسية أخرى—راجع [إطار الصورة](/slides/ar/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}

يمكنك تحويل الصور من صيغة إلى أخرى. راجع الصفحات التالية: تحويل [صورة إلى JPG](https://products.aspose.com/slides/ar/cpp/conversion/image-to-jpg/)، [JPG إلى صورة](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-image/)، [JPG إلى PNG](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-png/)، [PNG إلى JPG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-jpg/)، [PNG إلى SVG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-svg/)، و[SVG إلى PNG](https://products.aspose.com/slides/ar/cpp/conversion/svg-to-png/).

{{% /alert %}}

تدعم Aspose.Slides الصور بصيغ شائعة مثل JPEG وPNG وBMP وGIF وغيرها.

## **إضافة صور مخزنة محلياً إلى الشرائح**

يمكنك إضافة صورة أو أكثر مخزنة على جهاز الكمبيوتر الخاص بك إلى شريحة عرض. يوضح الكود التجريبي التالي بلغة C++ كيفية إضافة صورة إلى شريحة:

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

## **إضافة صور من الويب إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير مخزنة على جهازك، يمكنك إضافتها مباشرة من الويب.

يظهر الكود التجريبي التالي بلغة C++ كيفية إضافة صورة من الويب إلى شريحة:

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

## **إضافة صور إلى القوالب الأساسية للشرائح**

القالب الأساسي للشرائح يخزن ويتحكم في معلومات مثل السمة وتنسيق الشرائح التي تستخدمه. عند إضافة صورة إلى القالب الأساسي، تظهر الصورة على كل شريحة تعتمد على ذلك القالب.

يظهر الكود التجريبي التالي بلغة C++ كيفية إضافة صورة إلى القالب الأساسي للشرائح:

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

## **إضافة صور كخلفية للشرائح**

يمكنك استخدام صورة كخلفية لشريحة أو أكثر. للحصول على تفاصيل، راجع *[تعيين الصور كخلفيات للشرائح](/slides/ar/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكن إضافة محتوى SVG إلى عرض تقديمي باستخدام فئة [SvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/svgimage/). يمكن بعد ذلك إضافة كائن [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) الناتج إلى مجموعة صور العرض واستخدامه لإنشاء إطار صورة.

يعرض المثال التالي بلغة C++ كيفية استيراد سلسلة SVG مضمونة. جميع الصور والأنماط والموارد الأخرى المستخدمة في هذا SVG مدمجة مباشرةً في محتوى SVG.

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

## **استيراد محتوى SVG بموارد خارجية**

قد تشير ملفات SVG المستخرجة من أدوات التصميم أو محررات المخططات أو أنظمة الأيقونات أو خطوط الأنابيب الويب إلى موارد مخزنة خارج مستند SVG. على سبيل المثال، قد يحتوي SVG على ارتباط صورة مثل `images/photo.png`، أو قيمة CSS `url(...)`، أو عنوان URL للخط.

لاستيراد مثل هذا المحتوى، أنشئ تنفيذًا لـ[IExternalResourceResolver](https://reference.aspose.com/slides/ar/cpp/aspose.slides.import/iexternalresourceresolver/) ومرره، إلى جانب عنوان URI أساسي، إلى مُنشئ `SvgImage` المناسب. يُحدد العنوان الأساسي موقع مستند SVG ويُستخدم لحل الروابط النسبية.

توفر واجهة [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) إمكانية الوصول إلى معلومات حول SVG المستورد:

- `get_SvgContent()` تُعيد ترميز SVG كسلسلة.
- `get_SvgData()` تُعيد محتوى SVG كمصفوفة بايتات.
- `get_BaseUri()` تُعيد العنوان الأساسي المستخدم للروابط النسبية.
- `get_ExternalResourceResolver()` تُعيد محلل الموارد المعين لصورة SVG.

### **تنفيذ محلل موارد خارجية**

يحتوي المحلل على طريقتين:

- [ResolveUri](https://reference.aspose.com/slides/ar/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) يجمع العنوان الأساسي ورابط المورد النسبي ويعيد عنوان URI مطلق. أعد سلسلة فارغة عندما لا يمكن حل الرابط أو غير مسموح به.
- [GetEntity](https://reference.aspose.com/slides/ar/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) تُعيد تدفقًا قابلًا للقراءة لعنوان URI مطلق للمورد. أعد `nullptr` عندما يكون المورد مفقودًا أو محجوبًا أو غير متاح. يمكن أيضًا إرجاع تدفق احتياطي عندما يكون ذلك مناسبًا.

يعرض المثال التالي محللًا يحمل الموارد المرتبطة فقط من دليل محلي مسموح به. تُحظر الموارد الشبكية والمسارات خارج الدليل المسموح. تُعاد صورة احتياطية اختيارية للروابط غير المحلولة.

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

        // هذا المحلل يسمح بشكل مقصود بالملفات المحلية فقط.
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

        // استخدم مرحلة احتياطية فقط لموارد الصورة. إرجاع تدفق صورة
        // لخط أو ورقة أنماط مفقودة لن يكون ذلك صالحًا.
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

### **حل الروابط المرتبطة أثناء استيراد SVG**

افترض أن `assets/diagram.svg` يحتوي على إشارة نسبية مثل:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

يعرض المثال التالي بلغة C++ كيفية تمرير URI ملف SVG كعنوان أساسي وتوفير محلل مخصص. يُحوّل المحلل رابط الصورة النسبي إلى عنوان URI مطلق ويُعيد تدفقًا يحتوي على المورد المرتبط بينما تقوم Aspose.Slides بمعالجة SVG.

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

// العنوان الأساسي يمثل موقع مستند SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage تعرض المحتوى الأصلي، البيانات الثنائية، العنوان الأساسي، والمحلل.
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

توفر فئة `SvgImage` أيضًا إصدارات تتقبل بيانات SVG كمصفوفة بايتات أو تدفق، إلى جانب محلل موارد خارجي وعنوان URI أساسي.

{{% alert title="هام" color="warning" %}}

يمكّن محلل الموارد الموارد الخارجية أثناء معالجة Aspose.Slides وعرض SVG. لا يُعدّل الترميز الأصلي لـ SVG ولا يدمج الموارد المحلولة تلقائيًا فيه.

عند إضافة `ISvgImage` إلى مجموعة صور العرض، قد يحتوي ملف PPTX على تمثيل SVG الأصلي وصورة نقطية احتياطية. قد يظهر مورد مرتبط في الصورة الاحتياطية المُولدة بينما يبقى الرابط النسبي مثل `images/photo.png` دون تغيير في SVG المخزن. لذلك قد تتجاهل التطبيقات التي تعرض تمثيل SVG الأصلي المحتوى المرتبط عندما يكون المورد الخارجي الأصلي غير متوفر.

{{% /alert %}}

### **إنشاء صورة SVG محمولة**

لإنشاء صورة SVG لا تعتمد على ملفات خارجية، اجعل SVG ذاتيًا قبل إنشاء `SvgImage`. على سبيل المثال، استبدل عناوين URL للصور المرتبطة بـ URIs من نوع `data:` التي تحتوي على بيانات الصورة:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

بعد دمج جميع الموارد المطلوبة في محتوى SVG، أنشئ `SvgImage`، أضفه إلى مجموعة صور العرض، وأدرجه في إطار صورة كما هو موضح في المثال السابق.

### **معالجة الموارد المفقودة أو المحجوبة**

أعد سلسلة فارغة من `ResolveUri` عندما يكون عنوان URI للمورد غير صالح أو محظور أو لا يمكن حله. أعد `nullptr` من `GetEntity` عندما لا يمكن قراءة المورد. تواصل Aspose.Slides معالجة SVG بدون هذا المورد عندما يكون ذلك ممكنًا.

يمكن إرجاع تدفق احتياطي لمورد مفقود، لكن يجب أن يكون محتواه متوافقًا مع نوع المورد المطلوب. على سبيل المثال، أعد تدفق صورة فقط لمورد صورة مفقود، وليس للخط أو ورقة الأنماط.

{{% alert title="الأمان" color="warning" %}}

لا تحلّ أي مسارات ملفات عشوائية أو عناوين URL شبكية غير مقيدة من ملفات SVG غير موثوقة. قيد المخططات المسموح بها، الأدلة، والمضيفين. بالنسبة للموارد الشبكية، طبّق أيضًا مهلات الاتصال، حدود حجم الاستجابة، والتحقق من المحتوى.

{{% /alert %}}

## **تحويل SVG إلى مجموعة من الأشكال**
يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من الأشكال، مماثلة للوظيفة المقابلة في PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة من خلال إصدارة من طريقة [AddGroupShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/) في واجهة [IShapeCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/) التي تستقبل كائن [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) كوسيط أول.

يعرض الكود التجريبي التالي بلغة C++ كيفية استخدام هذه الطريقة لتحويل ملف SVG إلى مجموعة من الأشكال:

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

// اسم ملف SVG المصدر
auto svgFileName = System::String(u"sample.svg");

// اسم ملف العرض التقديمي الناتج
auto outPptxPath = System::String(u"presentation.pptx");

// إنشاء عرض تقديمي جديد
auto presentation = System::MakeObject<Presentation>();

// قراءة محتوى ملف SVG
auto svgContent = File::ReadAllText(svgFileName);

// إنشاء كائن SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// الحصول على حجم الشريحة
auto slideSize = presentation->get_SlideSize()->get_Size();

// تحويل صورة SVG إلى مجموعة من الأشكال وتكبيرها لتتناسب مع حجم الشريحة
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// حفظ العرض التقديمي بصيغة PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **إضافة صور كـ EMF إلى الشرائح**
تتيح Aspose.Slides for C++ إنشاء صور EMF من أوراق عمل Excel باستخدام Aspose.Cells وإضافتها إلى شرائح العرض.

يعرض الكود التجريبي التالي بلغة C++ كيفية القيام بذلك:

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

// يجب تشغيل Aspose.Cells للـ C++ قبل استخدام أي من أنواعه.
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
    // تُعيد Aspose.Cells الصفحة المُرسَّمة كمت buffer، وتضيفها Aspose.Slides كصورة.
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

## **استبدال الصور في مجموعة الصور**

تتيح لك Aspose.Slides استبدال الصور المخزنة في مجموعة صور العرض، بما في ذلك الصور المستخدمة في أشكال الشرائح. تصف هذه الفقرة عدة طرق لتحديث الصور في المجموعة. يمكنك استبدال صورة باستخدام بيانات بايتية خام، أو كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/)، أو صورة أخرى موجودة مسبقًا في المجموعة.

اتبع الخطوات التالية:

1. حمّل ملف العرض الذي يحتوي على صور باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. حمّل صورة جديدة من ملف إلى مصفوفة بايتات.
1. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايتات.
1. في النهج الثاني، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) واستبدل الصورة المستهدفة بذلك الكائن.
1. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة مسبقًا في مجموعة صور العرض.
1. احفظ العرض المعدل كملف PPTX.

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

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// الطريقة الأولى.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// الطريقة الثانية.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// الطريقة الثالثة.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// حفظ العرض التقديمي إلى ملف.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="معلومات" color="info" %}}

باستخدام أداة Aspose المجانية للتحويل من نص إلى GIF، يمكنك بسهولة تحريك النص وإنشاء ملفات GIF من النص. 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل تبقى دقة الصورة الأصلية كما هي بعد الإدراج؟**

نعم. تُحافظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على طريقة تحجيم [الصورة](/slides/ar/cpp/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر عشرات الشرائح مرة واحدة؟**

ضع الشعار على الشريحة الرئيسية أو نموذج تخطيط واستبدله في مجموعة صور العرض—سيتردد التحديث إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG تم إدخاله إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، ثم تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[عيّن الصورة كخلفية](/slides/ar/cpp/presentation-background/) على الشريحة الرئيسية أو التخطيط المناسب—ست inherit أي شريحة تستخدم ذلك النموذج الخلفية.

**كيف أمنع أن يصبح العرض كبيرًا جدًا بسبب كثرة الصور؟**

أعد استخدام مورد صورة واحد بدلاً من النسخ المتعددة، اختر دقة معقولة، طبّق ضغطًا عند الحفظ، واحتفظ بالرسومات المتكررة على القالب الرئيسي حيثما كان ذلك مناسبًا.