---
title: تحويل PowerPoint إلى Markdown باستخدام C#
type: docs
weight: 140
url: /ar/net/convert-powerpoint-to-markdown/
keywords: "تحويل PowerPoint إلى Markdown, تحويل ppt إلى md, PowerPoint, PPT, PPTX, عرض تقديمي, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "تحويل PowerPoint إلى Markdown باستخدام C#"
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

التصدير من PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا كنت ترغب في تصدير مستند PowerPoint يحتوي على صور، عليك تعيين `ExportType = MarkdownExportType.Visual` وتحديد BasePath حيث سيتم حفظ الصور المشار إليها في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتمثيل كائن العرض التقديمي.
2. استخدم الطريقة [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الكائن كملف markdown.

هذا الكود C# يوضح كيفية تحويل PowerPoint إلى markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **تحويل PowerPoint إلى صيغة Markdown**

يسمح Aspose.Slides لك بتحويل PowerPoint إلى markdown (مع الصياغة الأساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 صيغة markdown أخرى.

هذا الكود C# يوضح كيفية تحويل PowerPoint إلى CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


الصيغ الـ23 المدعومة للmarkdown مدرجة في [قائمة Flavor enumeration](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) داخل فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات أو إعدادات معينة لملف markdown الناتج. على سبيل المثال، يمكن تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) إلى قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور بشكل تسلسلي**

إذا رغبت في ظهور الصور بشكل فردي متتابع في markdown الناتج، عليك اختيار الخيار التسلسلي. هذا الكود C# يوضح كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا رغبت في ظهور الصور معًا في markdown الناتج، عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم بناء مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار واسم المجلد المفضل لديك.

هذا الكود C# يوضح العملية:
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


## **الأسئلة المتكررة**

**هل تبقى الروابط الفائقة بعد التصدير إلى Markdown؟**

نعم. النص [الروابط الفائقة](/slides/ar/net/manage-hyperlinks/) يتم الاحتفاظ به كرابط Markdown قياسي. شرائح [الانتقالات](/slides/ar/net/slide-transition/) و[الرسوم المتحركة](/slides/ar/net/powerpoint-animation/) لا يتم تحويلها.

**هل يمكنني تسريع التحويل بتشغيله في عدة خيوط؟**

يمكنك تنفيذ التحويل على عدة ملفات بصورة متوازية، لكن لا تُشَـارِك نفس مثيل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) عبر الخيوط. استخدم مثيلات/عمليات منفصلة لكل ملف لتفادي التداخل.

**ماذا يحدث للصور—أين تُحفظ، وهل المسارات نسبية؟**

يتم تصدير [الصور](/slides/ar/net/image/) إلى مجلد مخصص، ويشير ملف Markdown إليها بمسارات نسبية بشكل افتراضي. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.