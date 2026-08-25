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
- تحميل الخط
- إدارة الخطوط
- مجلد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للغة C++ للحفاظ على عروضك التقديمية واضحة ومتسقة عبر أي جهاز."
---
## **نظرة عامة**

Aspose.Slides يتيح لك استخدام الخطوط المخصصة في العروض التقديمية دون الحاجة إلى تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير الخطوط لعروض تقديمية محددة عبر مصادر الخطوط على مستوى المستند، أو تحميل الخطوط الخارجية مباشرة من البيانات الثنائية.

تُستعمل الخطوط التي تم تحميلها عندما يتم عرض أو تصدير العرض، على سبيل المثال إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على اتساق مخرجات العرض عبر بيئات مختلفة. توضح المقالة أيضاً كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتصيير منفصل عن تضمين الخطوط داخل ملف PPTX. إذا كان لابد من تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخطوط صراحةً.

يمكن لمظهر العرض الإشارة إلى عائلات خطوط مختلفة لأنظمة كتابة فردية. تخزن هذه الخرائط أسماء الخطوط لكنها لا تثبت أو تحمل ملفات الخط. راجع [خطوط السمة المحددة للسكريبت](/slides/ar/cpp/script-specific-font-mappings/) لإدارة هذه الخرائط، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة لتصيير متسق.

{{% alert color="info" title="ملاحظة" %}}

Aspose Slides يتيح لك تحميل هذه الخطوط باستخدام [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* خطوط TrueType (.ttf) وTrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يتيح لك تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير—مثل PDF، الصور، والصيغ المدعومة الأخرى—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من أدلة مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الساكنة [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمّل واعرض/صدّر العرض التقديمي.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

يوضح المثال البرمجي التالي عملية تحميل الخطوط:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// حدد المجلدات التي تحتوي على ملفات الخطوط المخصصة.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// حمّل الخطوط المخصصة من المجلدات المحددة.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// اعرض/صدّر العرض التقديمي (على سبيل المثال إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحمّلة.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// امسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
FontsLoader::ClearCache();
```

{{% alert color="info" title="ملاحظة" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/) يضيف مجلدات إضافية إلى مسارات بحث الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بهذا الترتيب:

1. مسار خطوط نظام التشغيل الافتراضي.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

Aspose.Slides يوفر [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/getfontfolders/) للسماح لك باكتشاف مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات خطوط النظام.

يعرض هذا الكود C++ كيفية استخدام طريقة [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// تقوم هذه السطر بطباعة المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي تم إضافتها عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

Aspose.Slides يوفر الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) للسماح لك بتحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يعرض هذا الكود C++ كيفية استخدام الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

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
    //خطوط CustomFont1 و CustomFont2 بالإضافة إلى الخطوط الموجودة في مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
}
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides يوفر الطريقة [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfont/) للسماح لك بتحميل الخطوط الخارجية إلى مصفوفة بايتات.

يوضح هذا الكود C++ عملية تحميل الخط إلى مصفوفة بايتات:

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

## **الأسئلة الشائعة**

### هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟

نعم. تُستخدم الخطوط المتصلة من قبل المصدّر في جميع صيغ التصدير.

### هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل الخط للتصيير ليس هو نفسه تضمينه داخل PPTX. إذا كنت بحاجة إلى أن يُحمل الخط داخل ملف العرض، يجب عليك استخدام ميزات [التضمين](/slides/ar/cpp/embedded-font/) الصريحة.

### هل يمكنني التحكم في سلوك السقوط عندما يفتقد الخط المخصص بعض الرموز؟

نعم. قم بتكوين [استبدال الخط](/slides/ar/cpp/font-substitution/)، [قواعد الاستبدال](/slides/ar/cpp/font-replacement/)، و[مجموعات السقوط](/slides/ar/cpp/fallback-font/) لتحديد الخط الذي يُستخدم عندما تكون الرموز المطلوبة غير موجودة.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

نعم. يمكنك الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات بايتات. هذا يلغي أي اعتماد على أدلة الخطوط النظامية داخل صورة الحاوية.

### ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟

أنت مسؤول عن الامتثال لترخيص الخط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. تأكد دائمًا من مراجعة اتفاقية ترخيص الخط قبل توزيع المخرجات.