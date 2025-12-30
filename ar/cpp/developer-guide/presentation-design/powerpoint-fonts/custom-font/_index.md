---
title: تخصيص خطوط PowerPoint في С++
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
- С++
- Aspose.Slides
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للغة С++ للحفاظ على عروضك التقديمية واضحة ومتسقة عبر أي جهاز."
---

{{% alert color="primary" %}} 

تتيح لك Aspose Slides تحميل هذه الخطوط باستخدام [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل خطوط مخصصة**

تتيح لك Aspose.Slides تحميل الخطوط المستخدمة في العرض التقديمي دون تثبيتها على النظام. يؤثر هذا على مخرجات التصدير—مثل PDF، الصور، وغيرها من الصيغ المدعومة—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من أدلة مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الثابتة [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمّل وقدّم/صدّر العرض التقديمي.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

يوضح مثال الشفرة التالي عملية تحميل الخطوط:
```cpp
// تحديد المجلدات التي تحتوي على ملفات خطوط مخصصة.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// حمّل الخطوط المخصصة من المجلدات المحددة.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// اعرض/صدّر العرض التقديمي (مثال: إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحمّلة.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// امسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
FontsLoader::ClearCache();
```


{{% alert color="info" title="ملاحظة" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) يضيف مجلدات إضافية إلى مسارات بحث الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بهذا الترتيب:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

توفر Aspose.Slides الدالة [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) للسماح لك بالعثور على مجلدات الخطوط. تُرجع هذه الدالة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات خطوط النظام.

يعرض هذا الكود C++ كيفية استخدام طريقة [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/):
``` cpp
// هذا السطر يطبع المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي أضيفت عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

توفر Aspose.Slides الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) للسماح لك بتحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يعرض هذا الكود C++ كيفية استخدام الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //العمل مع العرض التقديمي
    //CustomFont1, CustomFont2 بالإضافة إلى الخطوط من مجلدي assets\fonts & global\fonts ومجلداتهما الفرعية متاحة للعرض التقديمي
}
```


## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) للسماح لك بتحميل الخطوط الخارجية إلى مصفوفة بايت.

يعرض هذا الكود C++ عملية تحميل الخطوط إلى مصفوفة بايت:
```cpp
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

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟**

نعم. تُستخدم الخطوط المتصلة من قبل المُعالج عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للتص rendering لا يعني تضمينه في ملف PPTX. إذا كنت بحاجة إلى تضمين الخط داخل ملف العرض التقديمي، يجب عليك استخدام ميزات التضمين الصريحة [ميزات التضمين](/slides/ar/cpp/embedded-font/).

**هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الحروف؟**

نعم. قم بتكوين [استبدال الخط](/slides/ar/cpp/font-substitution/)، [قواعد الاستبدال](/slides/ar/cpp/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/cpp/fallback-font/) لتحديد بالضبط أي خط يُستخدم عندما تكون الحرف المطلوب غير موجود.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. اشِر إلى مجلدات الخط الخاصة بك أو حمّل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على أدلة الخط في نظام الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت مسؤول عن الامتثال لترخيص الخط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. دائمًا راجع اتفاقية الترخيص الخاصة بالخط قبل توزيع المخرجات.