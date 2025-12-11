---
title: تخصيص خطوط PowerPoint في С++
linktitle: الخط المخصص
type: docs
weight: 20
url: /ar/cpp/custom-font/
keywords:
- الخط
- خط مخصص
- خط خارجي
- تحميل الخط
- إدارة الخطوط
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- С++
- Aspose.Slides
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لـ С++ للحفاظ على جودة وعرض تقديمياتك متسقة على أي جهاز."
---

{{% alert color="primary" %}} 
Aspose Slides يسمح لك بتحميل هذه الخطوط باستخدام [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

يتيح Aspose.Slides لك تحميل الخطوط التي يتم عرضها في العروض التقديمية دون الحاجة إلى تثبيت تلك الخطوط. يتم تحميل الخطوط من دليل مخصص. 

1. أنشئ مثيلاً من الفئة [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) واستدع طريقة [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/).
2. حمّل العرض التقديمي الذي سيتم عرضه.
3. امسح التخزين المؤقت في الفئة [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

هذا الكود C++ يوضح عملية تحميل الخطوط:
``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// تعيين مسار الخطوط
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// تحميل خطوط دليل الخطوط المخصص
FontsLoader::LoadExternalFonts(folders);

// تنفيذ بعض الأعمال وعرض الشرائح
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// مسح ذاكرة التخزين المؤقت للخطوط
FontsLoader::ClearCache();
```


## **الحصول على مجلدات الخطوط المخصصة**
يوفر Aspose.Slides الدالة [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) لتتيح لك العثور على مجلدات الخطوط. تُعيد هذه الدالة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

هذا الكود C++ يوضح كيفية استخدام الدالة [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/):
``` cpp
// يعرض هذا السطر المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**
يوفر Aspose.Slides الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) لتتيح لك تحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

هذا الكود C++ يوضح كيفية استخدام الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //العمل مع العرض التقديمي
    //CustomFont1, CustomFont2 وكذلك الخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
}
```


## **إدارة الخطوط خارجيًا**
يوفر Aspose.Slides الطريقة [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) لتتيح لك تحميل الخطوط الخارجية إلى مصفوفة بايت.

هذا الكود C++ يوضح عملية تحميل الخطوط إلى مصفوفة بايت:
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


## **الأسئلة الشائعة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟**

نعم. يتم استخدام الخطوط المتصلة بواسطة المرسِّم عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض لا يعني تضمينه في PPTX. إذا كنت بحاجة إلى تضمين الخط داخل ملف العرض، يجب عليك استخدام ميزات التضمين الصريحة [embedding features](/slides/ar/cpp/embedded-font/).

**هل يمكنني التحكم في سلوك التراجع عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. قم بتكوين [font substitution](/slides/ar/cpp/font-substitution/)، [replacement rules](/slides/ar/cpp/font-replacement/)، و[fallback sets](/slides/ar/cpp/fallback-font/) لتحديد الخط الذي يُستخدم عندما يكون الرمز المطلوب غير موجود.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. اشّر إلى مجلدات الخطوط الخاصة بك أو حمّل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على مجلدات الخطوط النظامية في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الامتثال لترخيص الخط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. راجع دائمًا اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.