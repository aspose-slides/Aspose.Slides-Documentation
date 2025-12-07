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
- PowerPoint
- العرض التقديمي
- Markdown
- C++
- Aspose.Slides
description: "تحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيف باستخدام Aspose.Slides للـ C++، أتمتة الوثائق والحفاظ على التنسيق."
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

التصدير من PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى تعيين `SaveOptions::MarkdownExportType::Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتمثيل كائن عرض تقديمي.
2. استخدم طريقة [Save ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) لحفظ الكائن كملف markdown.

هذا الكود بلغة C++ يوضح لك كيفية تحويل PowerPoint إلى markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **تحويل PowerPoint إلى صيغة Markdown**

تتيح لك Aspose.Slides تحويل PowerPoint إلى markdown (الذي يحتوي على بنية أساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 صيغة markdown أخرى.

هذا الكود بلغة C++ يوضح لك كيفية تحويل PowerPoint إلى CommonMark: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


الـ 23 صيغة markdown المدعومة مدرجة في [Flavor enumeration](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات أو إعدادات معينة لملف markdown الناتج. يمكن تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/)، على سبيل المثال، إلى قيم تحدد طريقة عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور تسلسلياً**

إذا كنت تريد ظهور الصور بشكل فردي واحدة تلو الأخرى في markdown الناتج، عليك اختيار الخيار التسلسلي. هذا الكود بلغة C++ يوضح لك كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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


### **تحويل الصور بصرياً**

إذا كنت تريد ظهور الصور معًا في markdown الناتج، عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم إنشاء مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار المفضل واسم المجلد.

هذا الكود بلغة C++ يوضح العملية: 
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

نعم. يتم الحفاظ على نص [hyperlinks](/slides/ar/cpp/manage-hyperlinks/) كرابط Markdown قياسي. لا يتم تحويل [transitions](/slides/ar/cpp/slide-transition/) و [animations](/slides/ar/cpp/powerpoint-animation/) للشرائح.

**هل يمكنني تسريع التحويل باستخدام تشغيله في عدة خيوط؟**

يمكنك تنفيذ التوازي عبر الملفات، لكن يجب [don’t share](/slides/ar/cpp/multithreading/) نفس مثال [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) عبر الخيوط. استخدم أمثلة/عمليات منفصلة لكل ملف لتجنب التضارب.

**ماذا يحدث للصور — أين يتم حفظها، وهل المسارات نسبية؟**

[Images](/slides/ar/cpp/image/) يتم تصديرها إلى مجلد مخصص، ويقوم ملف Markdown بالإشارة إليها بمسارات نسبية بشكل افتراضي. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع قابلة للتنبؤ.