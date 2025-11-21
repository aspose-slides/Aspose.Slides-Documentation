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
description: "تحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيف باستخدام Aspose.Slides لـ .NET، أتمتة الوثائق والحفاظ على التنسيق."
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

تصدير PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا كنت ترغب في تصدير مستند PowerPoint يحتوي على صور، يجب عليك ضبط `ExportType = MarkdownExportType.Visual` وتحديد BasePath حيث سيتم حفظ الصور المشار إليها في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتمثيل كائن عرض تقديمي.
2. استخدم [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)method لحفظ الكائن كملف markdown.

يعرض لك هذا الكود C# كيفية تحويل PowerPoint إلى markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **تحويل PowerPoint إلى نكهة Markdown**

يتيح لك Aspose.Slides تحويل PowerPoint إلى markdown (يتضمن الصياغة الأساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 نكهة markdown أخرى.

يعرض لك هذا الكود C# كيفية تحويل PowerPoint إلى CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


الـ 23 نكهة markdown المدعومة مُدرجة [في تعداد Flavor](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تتيح لك استخدام خيارات أو إعدادات معينة لملف markdown الناتج. يمكن ضبط تعداد [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) على قيم تحدد طريقة عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور تسلسليًا**

إذا كنت تريد أن تظهر الصور بصورة منفردة واحدة تلو الأخرى في markdown الناتج، يجب عليك اختيار الخيار التسلسلي. يعرض لك هذا الكود C# كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا كنت تريد أن تظهر الصور معًا في markdown الناتج، يجب عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيُنشأ مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار واسم المجلد المفضل لديك.

يعرض لك هذا الكود C# العملية:
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

نعم. يتم الحفاظ على نص [hyperlinks](/slides/ar/net/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل [transitions](/slides/ar/net/slide-transition/) و [animations](/slides/ar/net/powerpoint-animation/) للشرائح.

**هل يمكنني تسريع التحويل بتشغيله في عدة خيوط؟**

يمكنك تنفيذ معالجة متوازية عبر الملفات، ولكن يجب [عدم مشاركة](/slides/ar/net/multithreading/) نفس مثيل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) عبر الخيوط. استخدم مثيلات/عمليات منفصلة لكل ملف لتجنب التضارب.

**ماذا يحدث للصور—أين يتم حفظها، وهل المسارات نسبية؟**

يتم تصدير [Images](/slides/ar/net/image/) إلى مجلد مخصص، ويشير ملف Markdown إليها باستخدام مسارات نسبية بشكل افتراضي. يمكنك ضبط مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع يمكن التنبؤ بها.