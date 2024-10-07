---
title: تحويل PowerPoint إلى Markdown في C++
type: docs
weight: 140
url: /cpp/convert-powerpoint-to-markdown/
keywords: "تحويل PowerPoint إلى Markdown, تحويل ppt إلى md, PowerPoint, PPT, PPTX, عرض تقديمي, Markdown, C++, CPP, Aspose.Slides for C++"
description: "تحويل PowerPoint إلى Markdown في C++"
---

{{% alert color="info" %}} 

تم تنفيذ الدعم لتحويل PowerPoint إلى Markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

تصدير PowerPoint إلى Markdown هو **بدون صور** بشكل افتراضي. إذا كنت ترغب في تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى تعيين `SaveOptions::MarkdownExportType::Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند Markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتمثيل كائن العرض التقديمي.
2. استخدم [Save ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)لحفظ الكائن كملف Markdown.

هذا الكود C++ يوضح لك كيفية تحويل PowerPoint إلى Markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## تحويل PowerPoint إلى أنواع Markdown مختلفة

يسمح Aspose.Slides لك بتحويل PowerPoint إلى Markdown (تتضمن البنية الأساسية)، CommonMark، Markdown بنكهة GitHub، Trello، XWiki، GitLab، و17 نوعًا آخر من Markdown.

هذا الكود C++ يوضح لك كيفية تحويل PowerPoint إلى CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

تم سرد 23 نوع مدعوم من Markdown [تحت تعداد Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل العروض التقديمية التي تحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات معينة أو إعدادات لملف Markdown الناتج. يمكن، على سبيل المثال، تعيين التعداد [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) إلى قيم تحدد كيفية عرض الصور أو التعامل معها: `Sequential`, `TextOnly`, `Visual`.

### **تحويل الصور بشكل تسلسلي**

إذا كنت ترغب في ظهور الصور بشكل فردي الواحدة تلو الأخرى في Markdown الناتج، يجب عليك اختيار الخيار التسلسلي. هذا الكود C++ يوضح لك كيفية تحويل عرض تقديمي يحتوي على صور إلى Markdown:

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

إذا كنت ترغب في ظهور الصور معًا في Markdown الناتج، يجب عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم بناء مسار نسبي لها في وثيقة Markdown)، أو يمكنك تحديد المسار واسم المجلد المفضلين لديك.

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