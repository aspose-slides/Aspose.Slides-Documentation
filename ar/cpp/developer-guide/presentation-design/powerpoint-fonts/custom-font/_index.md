---
title: خط مخصص في C++
type: docs
weight: 20
url: /ar/cpp/custom-font/
keywords: "خطوط، خطوط مخصصة، عرض PowerPoint، C++، CPP، Aspose.Slides لـ C++"
description: "خطوط PowerPoint مخصصة في C++"
---

{{% alert color="primary" %}} 

يسمح لك Aspose Slides بتحميل هذه الخطوط باستخدام [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* خطوط TrueType (.ttf) ومجموعات TrueType (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل خطوط مخصصة**

يسمح لك Aspose.Slides بتحميل خطوط يتم عرضها في العروض التقديمية دون الحاجة إلى تثبيت تلك الخطوط. يتم تحميل الخطوط من دليل مخصص.

1. قم بإنشاء نسخة من فئة [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) واستدعاء الطريقة [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/).
2. قم بتحميل العرض التقديمي الذي سيتم عرضه.
3. قم بإفراغ الذاكرة المؤقتة في فئة [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

يوضح هذا الكود C++ عملية تحميل الخط:

``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// تعيين مسار الخطوط
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// تحميل خطوط الدليل المخصص
FontsLoader::LoadExternalFonts(folders);

// قم ببعض العمل وإجراء عرض تقديمي/تقديم الشرائح
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// إفراغ ذاكرة الخط
FontsLoader::ClearCache();
```

## **احصل على مجلد الخطوط المخصصة**
يوفر Aspose.Slides [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) للسماح لك بالعثور على مجلدات الخطوط. تعيد هذه الطريقة المجلدات المضافة من خلال طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يوضح هذا الكود C++ كيفية استخدام طريقة [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// هذه السطر يخرج المجلدات التي تم التحقق منها لملفات الخطوط.
// هذه هي المجلدات المضافة عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **حدد الخطوط المخصصة المستخدمة مع العرض التقديمي**
يوفر Aspose.Slides خاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) للسماح لك بتحديد خطوط خارجية سيتم استخدامها مع العرض التقديمي.

يوضح هذا الكود C++ كيفية استخدام خاصية [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // العمل مع العرض التقديمي
    // خط CustomFont1 و CustomFont2 وكذلك الخطوط من مجلدات assets\fonts و global\fonts متاحة للعرض التقديمي
}
```

## **إدارة الخطوط خارجيًا**
يوفر Aspose.Slides طريقة [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) للسماح لك بتحميل الخطوط الخارجية إلى مصفوفة بايت.

يوضح هذا الكود C++ عملية تحميل الخط إلى مصفوفة بايت:

```cpp
// مسار دليل الوثائق
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```