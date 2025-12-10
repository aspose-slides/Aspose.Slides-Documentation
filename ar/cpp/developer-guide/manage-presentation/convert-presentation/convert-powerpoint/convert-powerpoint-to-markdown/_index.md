---
title: تحويل عروض PowerPoint إلى Markdown بلغة C++
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
description: "قم بتحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيفة باستخدام Aspose.Slides للغة C++، وحسّن توثيقك مع الحفاظ على التنسيق."
---

{{% alert color="info" %}} 
تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).
{{% /alert %}} 

{{% alert color="warning" %}} 
تصدير PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى تعيين `SaveOptions::MarkdownExportType::Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند markdown.
{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتمثيل كائن عرض تقديمي.
2. استخدم طريقة [Save ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)method لحفظ الكائن كملف markdown.

يظهر لك هذا الكود بلغة C++ كيفية تحويل PowerPoint إلى markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **تحويل PowerPoint إلى نمط Markdown**

تتيح لك Aspose.Slides تحويل PowerPoint إلى markdown (يتضمن الصياغة الأساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 نمطًا آخر للـ markdown.

يظهر لك هذا الكود بلغة C++ كيفية تحويل PowerPoint إلى CommonMark: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


القائمة التي تضم 23 نمطًا مدعومًا للـ markdown موجودة [قائمة تحت تعداد Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) في الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تتيح لك استخدام خيارات أو إعدادات معينة لملف markdown الناتج. على سبيل المثال، يمكن تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) إلى قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`, `TextOnly`, `Visual`.

### **تحويل الصور تسلسليًا**

إذا كنت ترغب في ظهور الصور كلًّا على حدة واحدة تلو الأخرى في markdown الناتج، يجب اختيار الخيار التسلسلي. يوضح لك هذا الكود بلغة C++ كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا كنت ترغب في ظهور الصور معًا في markdown الناتج، يجب اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيُنشأ مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار واسم المجلد المفضل لديك.

يظهر لك هذا الكود بلغة C++ عملية التنفيذ: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```


## **الأسئلة المتكررة**

**هل تبقى الروابط التشعبية بعد التصدير إلى Markdown؟**

نعم. يتم الحفاظ على نص [hyperlinks](/slides/ar/cpp/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل [transitions](/slides/ar/cpp/slide-transition/) و[animations](/slides/ar/cpp/powerpoint-animation/) الخاصة بالشرائح.

**هل يمكنني تسريع التحويل بتشغيله عبر خيوط متعددة؟**

يمكنك تنفيذ التوازي عبر الملفات، لكن [لا تشارك](/slides/ar/cpp/multithreading/) نفس كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) عبر الخيوط. استخدم كائنات/عمليات منفصلة لكل ملف لتجنب التعارض.

**ماذا يحدث للصور — أين يتم حفظها، وهل المسارات نسبية؟**

يتم تصدير [Images](/slides/ar/cpp/image/) إلى مجلد مخصص، ويشير ملف Markdown إليها باستخدام مسارات نسبية بشكل افتراضي. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على هيكل مستودع متوقع.