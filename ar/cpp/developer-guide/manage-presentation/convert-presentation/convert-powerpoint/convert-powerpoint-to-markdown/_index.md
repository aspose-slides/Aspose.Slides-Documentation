---
title: تحويل عروض PowerPoint التقديمية إلى Markdown في C++
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
- PowerPoint
- العرض التقديمي
- Markdown
- C++
- Aspose.Slides
description: تحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيف باستخدام Aspose.Slides للـ C++، أتمتة التوثيق والحفاظ على التنسيق.
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

تصدير PowerPoint إلى markdown يكون **بدون صور** افتراضيًا. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، عليك تعيين `SaveOptions::MarkdownExportType::Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتمثيل كائن العرض التقديمي.
2. استخدم طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) لحفظ الكائن كملف markdown.

هذا الكود C++ يوضح لك كيفية تحويل PowerPoint إلى markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **تحويل PowerPoint إلى صيغة Markdown**

تتيح لك Aspose.Slides تحويل PowerPoint إلى markdown (بالبنية الأساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 صيغة markdown أخرى.

هذا الكود C++ يوضح لك كيفية تحويل PowerPoint إلى CommonMark:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


الصيغ الـ23 المدعومة للmarkdown مدرجة في تعداد [Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) ضمن فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات أو إعدادات معينة للملف markdown الناتج. يمكن، على سبيل المثال، ضبط تعداد [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) إلى قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور تسلسليًا**

إذا أردت أن تظهر الصور بشكل فردي واحدة تلو الأخرى في markdown الناتج، عليك اختيار الخيار المتسلسل. هذا الكود C++ يوضح لك كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```


### **تحويل الصور بصريًا**

إذا أردت أن تظهر الصور معًا في markdown الناتج، عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في المجلد الحالي للتطبيق (وسيُبنى مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار واسم المجلد المفضل لديك.

هذا الكود C++ يوضح العملية:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```


## **FAQ**

**هل تبقى الروابط الفائقة بعد التصدير إلى Markdown؟**

نعم. يتم الحفاظ على النصوص [hyperlinks](/slides/ar/cpp/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل [transitions](/slides/ar/cpp/slide-transition/) و[animations](/slides/ar/cpp/powerpoint-animation/) الخاصة بالشرائح.

**هل يمكن تسريع التحويل بتشغيله عبر عدة خيوط؟**

يمكنك تنفيذ التحويل بالتوازي عبر الملفات، ولكن لا تشارك [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) نفسه بين الخيوط. استخدم مثيلات/عمليات منفصلة لكل ملف لتجنب التنازع.

**ماذا يحدث للصور—أين تُحفظ، وهل المسارات نسبية؟**

يتم تصدير [Images](/slides/ar/cpp/image/) إلى مجلد مخصص، ويشير ملف Markdown إليها بمسارات نسبية افتراضيًا. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.