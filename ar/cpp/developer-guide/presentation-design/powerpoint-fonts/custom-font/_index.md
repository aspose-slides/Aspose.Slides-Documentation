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
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للغة C++ للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---
## **نظرة عامة**

يتيح لك Aspose.Slides استخدام الخطوط المخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير الخطوط لعروض تقديمية معينة عبر مصادر الخط على مستوى المستند، أو تحميل الخطوط الخارجية مباشرةً من بيانات ثنائية.

تُستخدم الخطوط التي تم تحميلها عند تصيّر العرض أو تصديره، على سبيل المثال إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك على الحفاظ على اتساق مخرجات العرض عبر بيئات مختلفة. توضح هذه المقالة أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتصيّر منفصل عن تضمين الخطوط داخل ملف PPTX. إذا كان يجب تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخط صراحةً.

{{% alert color="primary" %}} 

Aspose Slides يسمح لك بتحميل هذه الخطوط باستخدام [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* خطوط TrueType (.ttf) ومجموعات TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

يتيح لك Aspose.Slides تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير—مثل PDF والصور والصيغ المدعومة الأخرى—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. تُحمَّل الخطوط من دلائل مخصصة.

1. حدد مجلدًا واحدًا أو أكثر يحتوي على ملفات الخطوط.
2. استدعِ الطريقة الساكنة [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمّل وقم بتصيّر/تصدير العرض التقديمي.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

الكود التالي يوضح عملية تحميل الخطوط:

```cpp
// تحديد المجلدات التي تحتوي على ملفات خطوط مخصصة.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// تصيّر/تصدير العرض (مثلاً إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحمّلة.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
FontsLoader::ClearCache();
```

{{% alert color="info" title="ملاحظة" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/) يضيف مجلدات إضافية إلى مسارات بحث الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط.
تُهيأ الخطوط بهذا الترتيب:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

يوفر Aspose.Slides الدالة [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/getfontfolders/) لتتيح لك العثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

الكود C++ التالي يوضح كيفية استخدام الدالة [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// هذا السطر يخرج المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

يوفر Aspose.Slides الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) لتتيح لك تحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

الكود C++ التالي يوضح كيفية استخدام الخاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //العمل مع العرض التقديمي
    //CustomFont1، CustomFont2 بالإضافة إلى الخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
}
```

## **إدارة الخطوط خارجيًا**

يوفر Aspose.Slides الطريقة [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfont/) لتتيح لك تحميل الخطوط الخارجية إلى مصفوفة بايت.

الكود C++ التالي يوضح عملية تحميل الخطوط إلى مصفوفة بايت:

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

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. تُستخدم الخطوط المتصلة من قبل المصدّر عبر جميع صيغ التصدير.

**هل تُضمن الخطوط المخصصة تلقائيًا داخل ملف PPTX الناتج؟**

لا. تسجيل الخط للتصيّر ليس هو نفسه تضمينه داخل PPTX. إذا كنت بحاجة إلى أن يكون الخط مضمّنًا داخل ملف العرض، يجب عليك استخدام ميزات [التضمين](/slides/ar/cpp/embedded-font/).

**هل يمكن التحكم في سلوك الـ fallback عندما يفتقر الخط المخصص إلى بعض الحروف؟**

نعم. اضبط [استبدال الخط](/slides/ar/cpp/font-substitution/)، [قواعد الاستبدال](/slides/ar/cpp/font-replacement/)، و[مجموعات fallback](/slides/ar/cpp/fallback-font/) لتحديد الخط الذي يُستخدم عندما يكون الحرف المطلوب غير موجود.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. أشر إلى مجلدات الخطوط الخاصة بك أو حمّل الخطوط من مصفوفات بايت. هذا يلغي أي اعتماد على دلائل الخطوط النظامية داخل صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الامتثال لترخيص الخطوط. الشروط تختلف؛ بعض الترخيصات تحظر التضمين أو الاستخدام التجاري. راجع دائمًا اتفاقية ترخيص الخط قبل توزيع المخرجات.