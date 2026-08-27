---
title: تحويل عروض PowerPoint إلى Markdown في C++
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/cpp/convert-powerpoint-to-markdown/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى MD
- العرض التقديمي إلى MD
- الشريحة إلى MD
- PPT إلى MD
- PPTX إلى MD
- حفظ PowerPoint كـ Markdown
- حفظ العرض التقديمي كـ Markdown
- حفظ الشريحة كـ Markdown
- حفظ PPT كـ MD
- حفظ PPTX كـ MD
- تصدير PPT إلى MD
- تصدير PPTX إلى MD
- تصدير صور Markdown
- روابط صور CDN
- PowerPoint
- العرض التقديمي
- Markdown
- C++
- Aspose.Slides
description: تحويل عروض PPT و PPTX إلى Markdown في C++ والتحكم في مكان حفظ الصور المصدرة من نوع bitmap و metafile و SVG وكيفية الإشارة إليها.
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ تحويل عروض PPT و PPTX إلى Markdown للتوثيق، مواقع ثابتة، ترحيل المحتوى، وسير عمل التحكم في الإصدارات. يمكنك اختيار نكهة Markdown، التحكم في طريقة عرض محتوى الشريحة، وتحديد مكان حفظ الصور المصدرة وكيفية إشارة Markdown المُولدة إليها.

بشكل افتراضي، يستخدم تصدير Markdown مخرجات نصية فقط. لتصدير المحتوى البصري، قم بتعيين طريقة [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) إلى القيمة `Sequential` أو `Visual` من تعدد [MarkdownExportType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownexporttype/). تقوم `Sequential` بعرض عناصر الشريحة بشكل منفصل ووفق الترتيب، بينما تحافظ `Visual` على تجميع العناصر معًا للحفاظ على العلاقة البصرية بينها. قيمة `TextOnly` لا تُصدر موارد صور، لذا لا يتم استدعاء أحداث حفظ الصور في هذا الوضع.

## **تحويل عرض تقديمي إلى Markdown**

قم بتحميل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)، ثم استدعِ طريقة [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) مع القيمة `Md` من تعدد [SaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **اختيار نكهة Markdown**

تتحكم طريقة [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) في مواصفة Markdown المستخدمة للإخراج. يتضمن تعدد [Flavor](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/flavor/) CommonMark، GitHub Flavored Markdown، ومتغيرات أخرى مدعومة.

المثال التالي يصدر عرضًا تقديميًا كـ CommonMark:

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

## **تصدير الصور باستخدام سلوك الحفظ المحلي الافتراضي**

توفر الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/) طريقتين لتكوين الصور المحفوظة محليًا:

- [set_BasePath](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) تحدد الدليل الأساسي لمستند Markdown وموارده.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) تحدد المجلد الفرعي للصور. القيمة الافتراضية هي `Images`.

المثال التالي يعرض المحتوى البصري، يكتب الصور إلى `output/assets`، ويُنشئ مراجع صور نسبية في مستند Markdown:

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

هذا السلوك يعمل أيضًا كخطة احتياطية عندما يُعيد معالج حفظ الصور المخصص القيمة `false`.

## **تخصيص حفظ الصور وروابط Markdown**

استخدم حدث `MarkdownSaveOptions::ImageSaving` للموارد غير SVG من الصور النقطية وملفات الميتافايل التي تُصدر أثناء تصدير Markdown. يتلقى المفوض [MarkdownImageSavingHandler](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/)، و[ImageFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imageformat/)، ورابط Markdown المُولد كمعامل `System::String&`. احفظ أو حمل الصورة بالتنسيق المقدم، واستبدل `link` بالإشارة التي يجب أن تظهر في خرج Markdown.

يتم التعامل مع الموارد المصدرة بصيغة SVG بشكل منفصل. اشترك في حدث `MarkdownSaveOptions::SvgImageSaving`، حيث يتلقى المفوض [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) كائن [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) ومعامل `System::String& link`. لا يحتوي SVG على وسيط `ImageFormat`؛ اكتب أو حمل بيانات XML عبر طريقة [ISvgImage::get_SvgData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/get_svgdata/) بدلاً من ذلك. حسب وضع التصدير وتجميع العناصر البصرية، قد يتم تحويل SVG في العرض المصدر إلى نقطية أو دمجه مع محتوى آخر؛ يتم تمرير المورد غير SVG الناتج إلى `ImageSaving`. اشترك في الحدثين عندما يتطلب كل مورد بصري مُصدر معالجة مخصصة.

تحدد قيمة الإرجاع للمعالج من سيعالج الصورة:

- إرجاع `true` بعد أن يقوم المعالج بحفظ الصورة أو تحميلها أو تحويلها أو معالجتها بأي طريقة وتعيين قيمة صالحة إلى `link`. تقوم Aspose.Slides بكتابة تلك القيمة إلى مستند Markdown ولا تنفذ الحفظ المحلي الافتراضي.
- إرجاع `false` للسماح لـ Aspose.Slides بحفظ الصورة محليًا وإنشاء رابطها وفقًا لـ [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) و[MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
معالج يُرجع `true` يتحمل مسؤولية الصورة. إذا أعاد `true` دون تعيين رابط صالح غير فارغ، سيفشل التصدير بـ `InvalidOperationException`.
{{% /alert %}}

### **حفظ الصور في دليل أصل CDN واستخدام عناوين URL خارجية**

المثال التالي يُعامل `cdn-origin/presentations/quarterly-report` كدليل أصل CDN مركب أو مُزامن. يستخرج كل معالج اسم الملف المُولد، يحفظ الصورة في ذلك الدليل المخصص، ويستبدل الإشارة المحلية المُولدة بعنوان URL عام على CDN. لا يقوم المثال نفسه برفع الشبكة: يصبح عنوان URL صالحًا فقط بعد تركيب الدليل كأصل CDN أو نشر ملفاته على CDN. للتخزين ككائن، استبدل كتابة نظام الملفات بعملية رفع SDK التخزيني وعيّن `link` فقط بعد نجاح الرفع.

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

المعالج الخاص بالصور النقطية يُعيد عن عمد القيمة `false` للصور أصغر من 128 × 128 بكسل، وبالتالي تقوم Aspose.Slides بحفظ تلك الصور إلى `output/fallback-images` باستخدام السلوك الافتراضي. تُعالج الموارد النقطية والميتافايل الكبيرة، بالإضافة إلى موارد SVG، عبر الكود المخصص. على سبيل المثال، تتحول إشارة محلية مُولدة مثل `fallback-images/image1.png` إلى `https://cdn.example.com/presentations/quarterly-report/image1.png`. يستخدم المعالجون مسارات نظام التشغيل فقط عند كتابة الملفات؛ الروابط المكتوبة في Markdown تستخدم شرطات مائلة أمامية وأسماء ملفات مُشفَّرة URL. طبّق القاعدة نفسها عند بناء الروابط النسبية: استخدم `/`، لا فاصل المسار الخاص بالنظام.

## **الأسئلة الشائعة**

**هل يمكن لمعالج واحد معالجة كل من الصور النقطية وSVG؟**

لا. استخدم `MarkdownSaveOptions::ImageSaving` للموارد النقطية وملفات الميتافايل المُصدرة، و`MarkdownSaveOptions::SvgImageSaving` للموارد المُصدرة كـ SVG. الأول يوفر كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) و[ImageFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imageformat/)، بينما الثاني يوفر كائن [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) يمكن قراءة بيانات SVG عبر [ISvgImage::get_SvgData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/get_svgdata/). يتم معالجة SVG المصدر الذي يتحول إلى نقطية أثناء التصدير عبر `ImageSaving` بدلاً من ذلك.

**ماذا يحدث عندما يُعيد معالج حفظ الصورة القيمة `false`؟**

تستخدم Aspose.Slides سلوك الحفظ المحلي الافتراضي. يتم التحكم في موقع الصورة والإشارة المُولدة بواسطة [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) و[MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**هل يمكن للمعالج توفير عنوان URL دون حفظ الصورة محليًا؟**

نعم. يمكن للمعالج رفع الصورة إلى تخزين ككائن أو تمريرها إلى خدمة أخرى، تعيين عنوان URL الناتج إلى `link`، وإرجاع `true`. يجب أن يُنهي المعالج المعالجة بنفسه؛ إرجاع `true` يمنع الحفظ المحلي الافتراضي.

**لماذا يطرح تصدير Markdown استثناء `InvalidOperationException` من معالج؟**

يحدث هذا الاستثناء عندما يُعيد المعالج `true` دون توفير رابط صالح. عيّن المسار النسبي أو عنوان URL الخارجي الذي ينبغي كتابته إلى Markdown قبل إرجاع `true`.

**أي فاصل مسار يجب أن تستخدمه روابط الصور؟**

استخدم الشرطات المائلة الأمامية في روابط Markdown وعناوين URL. استخدم `Path::Combine` فقط لمسارات نظام الملفات، ثم أنشئ أو صحّح مرجع Markdown بشكل منفصل.

**هل يتم الحفاظ على الروابط التشعبية أثناء تصدير Markdown؟**

نعم. يتم الحفاظ على النصوص [hyperlinks](/slides/ar/cpp/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل [transitions](/slides/ar/cpp/slide-transition/) و[animations](/slides/ar/cpp/powerpoint-animation/) الخاصة بالشرائح.

**هل يمكن تحويل العروض التقديمية إلى Markdown بشكل متوازي؟**

يمكنك معالجة ملفات عروض تقديمية مختلفة بشكل متوازي، ولكن لا تشارك نفس كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) بين الخيوط. اتبع [multithreading guidelines](/slides/ar/cpp/multithreading/) واستخدم كائنًا منفصلًا لكل ملف.