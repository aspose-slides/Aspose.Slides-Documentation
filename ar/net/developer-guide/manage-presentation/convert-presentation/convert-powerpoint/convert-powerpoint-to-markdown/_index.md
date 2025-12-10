---
title: تحويل عروض PowerPoint إلى Markdown في .NET
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "قم بتحويل شرائح PowerPoint—PPT, PPTX—إلى Markdown نظيف باستخدام Aspose.Slides لـ .NET، قم بأتمتة التوثيق واحرص على الحفاظ على التنسيق."
---

{{% alert color="info" %}} 
تم تنفيذ دعم التحويل من PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).
{{% /alert %}} 

{{% alert color="warning" %}} 
تصدير PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى تعيين `ExportType = MarkdownExportType.Visual` وتحديد BasePath حيث سيتم حفظ الصور المشار إليها في مستند markdown.
{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتمثيل كائن عرض تقديمي.
2. استخدام طريقة [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)لحفظ الكائن كملف markdown.

يُظهر لك هذا الكود C# كيفية تحويل PowerPoint إلى markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **تحويل PowerPoint إلى تنسيق Markdown**

يسمح Aspose.Slides لك بتحويل PowerPoint إلى markdown (الذي يحتوي على بناء أساسي)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و17 نوعًا آخر من markdown.

يُظهر لك هذا الكود C# كيفية تحويل PowerPoint إلى CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


الـ 23 نوعًا المدعوم من markdown مُدرجة تحت تعداد Flavor في فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات أو إعدادات معينة للملف markdown الناتج. يمكن ضبط تعداد [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) على قيم تحدد كيفية معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور تسلسليًا**

إذا كنت تريد أن تظهر الصور واحدةً تلو الأخرى في markdown الناتج، يجب اختيار الخيار المتسلسل. يُظهر لك هذا الكود C# كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```


### **تحويل الصور بصريًا**

إذا كنت تريد أن تظهر الصور معًا في markdown الناتج، يجب اختيار الخيار البصري. في هذه الحالة، تُحفظ الصور في الدليل الحالي للتطبيق (ويُبنى مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار والمجلد المفضل لديك.

يُظهر لك هذا الكود C# العملية:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```


## **الأسئلة الشائعة**

**هل تبقى الروابط التشعبية بعد التصدير إلى Markdown؟**

نعم. نص [الروابط التشعبية](/slides/ar/net/manage-hyperlinks/) يتم الاحتفاظ به كروابط Markdown قياسية. الشرائح [الانتقالات](/slides/ar/net/slide-transition/) و[الرسوم المتحركة](/slides/ar/net/powerpoint-animation/) لا يتم تحويلها.

**هل يمكنني تسريع التحويل عن طريق تشغيله في عدة خيوط؟**

يمكنك تنفيذ التحويل بالتوازي عبر ملفات مختلفة، لكن لا تشارك نفس مثيل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بين الخيوط. استخدم مثيلات أو عمليات منفصلة لكل ملف لتجنب التضارب.

**ماذا يحدث للصور — أين يتم حفظها، وهل المسارات نسبية؟**

يتم تصدير [الصور](/slides/ar/net/image/) إلى مجلد مخصص، ويشير ملف Markdown إليها باستخدام مسارات نسبية بشكل افتراضي. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على هيكل مستودع متوقع.