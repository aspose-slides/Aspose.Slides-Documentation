---
title: تحويل عروض PowerPoint إلى Markdown في C++
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/cpp/convert-powerpoint-to-markdown/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى MD
- عرض تقديمي إلى MD
- شريحة إلى MD
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
- عرض تقديمي
- Markdown
- C++
- Aspose.Slides
description: "تحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيف باستخدام Aspose.Slides للغة C++، أتمتة الوثائق والحفاظ على التنسيق."
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

التصدير من PowerPoint إلى markdown يكون **بدون صور** افتراضيًا. إذا رغبت في تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى تعيين `SaveOptions::MarkdownExportType::Visual)` وأيضًا تعيين `BasePath` حيث سُتحفظ الصور المشار إليها في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتمثيل كائن عرض تقديمي.
2. استخدم طريقة [حفظ ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)method لحفظ الكائن كملف markdown.

هذا الكود C++ يوضح لك كيفية تحويل PowerPoint إلى markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **تحويل PowerPoint إلى صيغ Markdown**

يسمح لك Aspose.Slides بتحويل PowerPoint إلى markdown (بما يحتوي على البنية الأساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و17 صيغة markdown أخرى.

هذا الكود C++ يوضح لك كيفية تحويل PowerPoint إلى CommonMark: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


الصيغ الـ23 المدعومة للـmarkdown مدرجة تحت تعداد Flavor من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات أو إعدادات معينة لملف الـmarkdown الناتج. يمكن، على سبيل المثال، تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) إلى قيم تحدد كيفية معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور بشكل تسلسلي**

إذا أردت ظهور الصور واحدةً تلو الأخرى في الـmarkdown الناتج، عليك اختيار الخيار التسلسلي. هذا الكود C++ يوضح لك كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا أردت ظهور الصور معًا في الـmarkdown الناتج، عليك اختيار الخيار البصري. في هذه الحالة، ستُحفظ الصور في الدليل الحالي للتطبيق (وسيُبنى مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار واسم المجلد المفضلة لديك.

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


## **الأسئلة الشائعة**

**هل تبقى الروابط التشعبية محفوظة بعد التصدير إلى Markdown؟**

نعم. يتم الحفاظ على الروابط التشعبية في النص كما هي كروابط Markdown قياسية. روابط [الارتباطات التشعبية](/slides/ar/cpp/manage-hyperlinks/) تُحفظ، بينما [الانتقالات](/slides/ar/cpp/slide-transition/) و[الرسوم المتحركة](/slides/ar/cpp/powerpoint-animation/) لا يتم تحويلها.

**هل يمكن تسريع التحويل بتشغيله على عدة خيوط؟**

يمكنك تنفيذ عمليات موازية عبر الملفات، لكن لا [تشترك](/slides/ar/cpp/multithreading/) في نفس كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) عبر الخيوط. استخدم مثيلات أو عمليات منفصلة لكل ملف لتجنب التنافس.

**ماذا يحدث للصور—أين تُحفظ، وهل المسارات نسبية؟**

يتم تصدير [الصور](/slides/ar/cpp/image/) إلى مجلد مخصص، ويشير ملف الـMarkdown إليها باستخدام مسارات نسبية افتراضيًا. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.