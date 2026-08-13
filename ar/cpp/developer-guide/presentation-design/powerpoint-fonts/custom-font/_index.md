---
title: تخصيص خطوط PowerPoint في C++
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/cpp/custom-font/
keywords:
- خط
- خط مخصص
- خط خارجي
- تحميل خط
- إدارة الخطوط
- مجلد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لـ C++ للحفاظ على عروضك التقديمية واضحة ومتسقة عبر أي جهاز."
---
## **نظرة عامة**

Aspose.Slides يتيح لك استخدام الخطوط المخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير خطوط لعروض تقديمية معينة من خلال مصادر الخط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من بيانات ثنائية.

تُستَخدم الخطوط المحمَّلة عند تصيير العرض أو تصديره، مثل إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على تناسق مخرجات العرض عبر بيئات مختلفة. توضح المقالة أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتصيير منفصل عن تضمين الخطوط داخل ملف PPTX. إذا كان يجب تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخطوط صراحةً.

{{% alert color="info" %}} 
Aspose Slides يتيح لك تحميل هذه الخطوط باستخدام [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يتيح لك تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. هذا يؤثر على مخرجات التصدير—مثل PDF والصور والصيغ المدعومة الأخرى—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. تُحمَّل الخطوط من أدلة مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الساكنة [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمّل وقم بتصيير/تصدير العرض التقديمي.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

المثال البرمجي التالي يوضح عملية تحميل الخطوط:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// تحديد المجلدات التي تحتوي على ملفات خطوط مخصصة.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// تصيير/تصدير العرض التقديمي (مثل PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحملة.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// مسح ذاكرة التخزين المؤقت للخطوط بعد انتهاء العمل.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/) يضيف مجلدات إضافية إلى مسارات بحث الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط.
تُهيَّأ الخطوط بهذا الترتيب:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

Aspose.Slides يقدم [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/getfontfolders/) لتسمح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أُضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

هذا الكود C++ يوضح كيفية استخدام طريقة [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// هذا السطر يطبع المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

Aspose.Slides يتيح الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) لتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

هذا الكود C++ يوضح كيفية استخدام الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //العمل مع العرض التقديمي
    //CustomFont1، CustomFont2 بالإضافة إلى الخطوط من المجلدين assets\fonts و global\fonts ومجلداتهما الفرعية متاحة للعرض التقديمي
}
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides يقدم الطريقة [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfont/) لتسمح لك بتحميل الخطوط الخارجية إلى مصفوفة بايت.

هذا الكود C++ يوضح عملية تحميل الخط إلى مصفوفة بايت:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// مسار دليل المستندات
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **الأسئلة المتكررة**

### هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟

نعم. تُستخدم الخطوط المتصلة من قبل المصدِّر عبر جميع صيغ التصدير.

### هل تُضمَّن الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل الخط للتصيير ليس هو نفسه تضمينه داخل ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض، يجب عليك استخدام [embedding features](/slides/ar/cpp/embedded-font/) صراحةً.

### هل يمكنني التحكم في سلوك الاستبدال عندما يفتقر خط مخصص إلى بعض الرموز؟

نعم. يمكنك تكوين [font substitution](/slides/ar/cpp/font-substitution/)، [replacement rules](/slides/ar/cpp/font-replacement/)، و[fallback sets](/slides/ar/cpp/fallback-font/) لتحديد الخط المستخدم بالضبط عندما تكون الرموز المطلوبة غير متوفرة.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

نعم. يمكنك الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات بايت. يزيل ذلك أي اعتماد على مجلدات الخطوط النظامية في صورة الحاوية.

### ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟

أنت مسؤول عن الامتثال لتراخيص الخطوط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. دائمًا راجع اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.