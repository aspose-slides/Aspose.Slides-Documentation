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
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++، مع تحسين الأداء وأتمتة سير العمل الخاص بك."
---
## **مقدمة**

تجعل الصور العروض التقديمية أكثر جاذبية وإبهارًا بصريًا. في Microsoft PowerPoint، يمكنك إدراج صور على الشرائح من الملفات أو الإنترنت أو مصادر أخرى. بالمثل، يتيح لك Aspose.Slides إضافة صور إلى شرائح العرض بطرق متعددة. 

{{% alert title="Tip" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تتيح لك إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
إذا كنت ترغب في إضافة صورة كإطار صورة—خاصة إذا كنت تخطط لتغيير حجمها أو تطبيق تأثيرات أو استخدام خيارات تنسيق قياسية أخرى—انظر إلى [Picture Frame](/slides/ar/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
يمكنك تحويل الصور من تنسيق إلى آخر. راجع الصفحات التالية: تحويل [image to JPG](https://products.aspose.com/slides/ar/cpp/conversion/image-to-jpg/)، [JPG to image](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-image/)، [JPG to PNG](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-png/)، [PNG to JPG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-jpg/)، [PNG to SVG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-svg/)، و[SVG to PNG](https://products.aspose.com/slides/ar/cpp/conversion/svg-to-png/). 
{{% /alert %}}

يدعم Aspose.Slides الصور بالتنسيقات الشائعة مثل JPEG وPNG وBMP وGIF وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو أكثر مخزنة على جهازك إلى شريحة عرض. يوضح كود المثال التالي بلغة C++ كيفية إضافة صورة إلى شريحة:

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

إذا كانت الصورة التي ترغب في إضافتها إلى شريحة غير مخزنة على جهازك، يمكنك إضافتها مباشرةً من الويب. 

يوضح كود المثال التالي بلغة C++ كيفية إضافة صورة من الويب إلى شريحة:

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

## **إضافة صور إلى ماستر الشرائح**

يخزن ماستر الشريحة ويتحكم في معلومات مثل السمة وتخطيط الشرائح التي تستخدمه. عند إضافة صورة إلى ماستر الشريحة، تظهر الصورة على كل شريحة تعتمد على ذلك الماستر. 

يوضح كود المثال التالي بلغة C++ كيفية إضافة صورة إلى ماستر الشريحة:

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

## **إضافة صور كخلفيات للشرائح**

يمكنك استخدام صورة كخلفية لشريحة أو أكثر. لمزيد من التفاصيل، راجع *[Setting Images as Backgrounds for Slides](/slides/ar/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكن إضافة محتوى SVG إلى عرض تقديمي باستخدام الفئة [SvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/svgimage/). يمكن بعد ذلك إضافة كائن [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) الناتج إلى مجموعة صور العرض واستخدامه لإنشاء إطار صورة. 

يعرض المثال التالي بلغة C++ استيراد سلسلة SVG ذاتية المحتوى. جميع الصور والأنماط والموارد الأخرى المستخدمة في هذا الـ SVG مدمجة مباشرةً في محتوى الـ SVG. 

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

## **استيراد محتوى SVG مع موارد خارجية**

قد تحتوي ملفات SVG المُصدرة من أدوات التصميم أو محررات المخططات أو أنظمة الأيقونات أو خطوط أنابيب الويب على مراجع لموارد مخزنة خارج مستند SVG. على سبيل المثال، قد يحتوي SVG على رابط صورة مثل `images/photo.png` أو قيمة CSS `url(...)` أو عنوان URL للخط. 

لإستيراد مثل هذا المحتوى من SVG، أنشئ تنفيذًا لـ[IExternalResourceResolver](https://reference.aspose.com/slides/ar/cpp/aspose.slides.import/iexternalresourceresolver/) ومرره، مع URI أساسي، إلى مُنشئ `SvgImage` المناسب. يحدد الـ URI الأساسي موقع مستند SVG ويُستخدم لحل الروابط النسبية. 

توفر واجهة [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) إمكانية الوصول إلى معلومات حول الـ SVG المستورد:

- `get_SvgContent()` يعيد ترميز SVG كسلسلة. 
- `get_SvgData()` يعيد محتوى SVG كمصفوفة بايت. 
- `get_BaseUri()` يعيد الـ URI الأساسي المستخدم للروابط النسبية. 
- `get_ExternalResourceResolver()` يعيد محلل الموارد المخصص لصورة SVG. 

### **تنفيذ محلل موارد خارجي**

المحلل يحتوي على طريقتين:

- [ResolveUri](https://reference.aspose.com/slides/ar/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) يجمع الـ URI الأساسي والرابط النسبي للموارد ويعيد URI مطلق. أعد سلسلة فارغة عندما لا يمكن حل الرابط أو غير مسموح به. 
- [GetEntity](https://reference.aspose.com/slides/ar/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) يعيد تدفقًا قابلًا للقراءة لـ URI المورد المطلق. أعد `nullptr` عندما يكون المورد مفقودًا أو محظورًا أو غير متاح. يمكن أيضًا إرجاع تدفق احتياطي عندما يكون ذلك مناسبًا. 

يقوم المحلل التالي بتحميل الموارد المرتبطة فقط من دليل محلي مسموح به. تُحظر الموارد الشبكية والمسارات خارج الدليل المسموح به. يتم إرجاع صورة احتياطية اختيارية للروابط الصورية غير المُحلّدة. 

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

        // هذا المحلل يسمح بملفات محلية فقط عن قصد.
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

        // استخدم احتياطيًا فقط لموارد الصور. إرجاع تدفق صورة
        // لمورد خط أو ورقة أنماط مفقودة لن يكون ذلك صالحًا.
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

### **حل الموارد المرتبطة أثناء استيراد SVG**

افترض أن `assets/diagram.svg` يحتوي على مرجع نسبي مثل:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

يمرر المثال التالي بلغة C++ URI ملف SVG كـ URI أساسي ويُوفر محللًا مخصصًا. يقوم المحلل بتحويل رابط الصورة النسبي إلى URI مطلق ويُعيد تدفقًا يحتوي على المورد المرتبط بينما تقوم Aspose.Slides بمعالجة الـ SVG. 

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

// يمثل الـ URI الأساسي موقع مستند SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage تعرض المحتوى المصدر، البيانات الثنائية، الـ URI الأساسي، والمحَلِّل.
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

توفر فئة `SvgImage` أيضًا overloads التي تقبل بيانات SVG كمصفوفة بايت أو تدفق، مع محلل مورد خارجي وURI أساسي. 

{{% alert title="Important" color="warning" %}}
يقوم محلل الموارد بجعل الموارد الخارجية متاحة أثناء معالجة Aspose.Slides للـ SVG وعرضه. لا يقوم بتعديل ترميز SVG الأصلي أو تضمين الموارد المحلولة فيه تلقائيًا. 

عند إضافة `ISvgImage` إلى مجموعة صور العرض، قد يحتوي ملف PPTX على كل من تمثيل SVG الأصلي وصورة احتياطية نقطية. قد يظهر المورد المرتبط في الصورة الاحتياطية المُولَّدة بينما يظل الرابط النسبي مثل `images/photo.png` دون تغيير في الـ SVG المخزن. قد تتجاهل التطبيقات التي تعرض تمثيل SVG الأصلي المحتوى المرتبط عندما يكون المورد الخارجي الأصلي غير متوفر. 
{{% /alert %}}

### **إنشاء صورة SVG محمولة**

لإنشاء صورة SVG لا تعتمد على ملفات خارجية، اجعل الـ SVG ذاتي المحتوى قبل إنشاء `SvgImage`. على سبيل المثال، استبدل عناوين URL للصور المرتبطة بـURIs من نوع `data:` التي تحتوي على بيانات الصورة: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

بعد دمج جميع الموارد المطلوبة في محتوى SVG، أنشئ `SvgImage`، أضفه إلى مجموعة صور العرض، وأدرجه في إطار صورة كما هو موضح في المثال السابق. 

### **معالجة الموارد المفقودة أو المحجوبة**

أعد سلسلة فارغة من `ResolveUri` عندما يكون URI المورد غير صالح أو محظور أو لا يمكن حله. أعد `nullptr` من `GetEntity` عندما لا يمكن قراءة المورد. تستمر Aspose.Slides في معالجة الـ SVG بدون هذا المورد إذا أمكن. 

يمكن إرجاع تدفق احتياطي لمورد مفقود، لكن محتواه يجب أن يكون متوافقًا مع نوع المورد المطلوب. على سبيل المثال، أعد تدفق صورة فقط لمورد صورة مفقود، وليس للخط أو ورقة الأنماط. 

{{% alert title="Security" color="warning" %}}
لا تقم بحل مسارات ملفات عشوائية أو عناوين URL شبكية غير مقيدة من ملفات SVG غير موثوقة. قيد الأنظمة، الأدلة، والمضيفين المسموح بها. بالنسبة للموارد الشبكية، طبّق أيضًا مهلات الاتصال، حدود حجم الاستجابة، والتحقق من صحة المحتوى. 
{{% /alert %}}

## **تحويل SVG إلى مجموعة من الأشكال**
يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من الأشكال، مماثلة للوظيفة المقابلة في PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة من خلال overload لطريقة [AddGroupShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/) في واجهة [IShapeCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/) التي تأخذ كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) كوسيط أول. 

يوضح كود المثال التالي بلغة C++ كيفية استخدام هذه الطريقة لتحويل ملف SVG إلى مجموعة من الأشكال:

```cpp
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

// اسم ملف العرض الناتج
auto outPptxPath = System::String(u"presentation.pptx");

// إنشاء عرض تقديمي جديد
auto presentation = System::MakeObject<Presentation>();

// قراءة محتوى ملف SVG
auto svgContent = File::ReadAllText(svgFileName);

// إنشاء كائن SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// الحصول على حجم الشريحة
auto slideSize = presentation->get_SlideSize()->get_Size();

// تحويل صورة SVG إلى مجموعة من الأشكال وتكييفها لحجم الشريحة
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// حفظ العرض التقديمي بصيغة PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **إضافة صور كـ EMF إلى الشرائح**
تتيح لك Aspose.Slides for C++ إنشاء صور EMF من أوراق Excel باستخدام Aspose.Cells وإضافتها إلى شرائح العرض. 

يوضح كود المثال التالي بلغة C++ كيفية القيام بذلك:

```cpp
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

// يجب تشغيل Aspose.Cells لـ C++ قبل استخدام أي من أنواعها.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// تجسيد ورقة العمل كـ EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // تُعيد Aspose.Cells الصفحة المُجسدة كعامل تخزين مؤقت، وتضيف Aspose.Slides ذلك كصورة.
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

تتيح لك Aspose.Slides استبدال الصور المخزنة في مجموعة صور العرض، بما في ذلك الصور المستخدمة في أشكال الشرائح. تصف هذه القسم عدة طرق لتحديث الصور في المجموعة. يمكنك استبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة. 

اتبع الخطوات التالية:

1. حمّل ملف العرض الذي يحتوي على صور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). 
2. حمّل صورة جديدة من ملف إلى مصفوفة بايت. 
3. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت. 
4. في النهج الثاني، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) واستبدل الصورة المستهدفة بهذا الكائن. 
5. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض. 
6. اكتب العرض المعدل كملف PPTX. 

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

// إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
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

{{% alert title="Info" color="info" %}}
باستخدام محول Aspose المجاني من [Text to GIF](https://products.aspose.app/slides/ar/text-to-gif)، يمكنك بسهولة تحريك النص وإنشاء صور GIF من النص. 
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تبقى دقة الصورة الأصلية محفوظة بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تكبير/تصغير الـ [picture](/slides/ar/cpp/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ. 

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح دفعة واحدة؟**

ضع الشعار على ماستر الشريحة أو تخطيطها واستبدله في مجموعة صور العرض—ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد. 

**هل يمكن تحويل SVG المُدرج إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك يمكن تحرير الأجزاء الفردية باستخدام خصائص الشكل القياسية. 

**كيف يمكنني ضبط صورة كخلفية لعدة شرائح في آن واحد؟**

[Assign the image as the background](/slides/ar/cpp/presentation-background/) على ماستر الشريحة أو التخطيط المناسب—ستورث أي شريحة تستخدم ذلك الماستر/التخطيط الخلفية. 

**كيف أمنع أن يصبح العرض كبيرًا جدًا بسبب كثرة الصور؟**

أعد استخدام مورد صورة واحد بدلاً من النسخ المكررة، اختر دقات معقولة، طبّق ضغطًا عند الحفظ، واحتفظ بالرسومات المتكررة على الماستر حيثما يكون ذلك مناسبًا.