---
title: تحويل عروض PowerPoint التقديمية إلى Markdown في .NET
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
description: "تحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيفة باستخدام Aspose.Slides لـ .NET، أتمتة التوثيق والحفاظ على التنسيق."
---

{{% alert color="info" %}} 
تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).
{{% /alert %}} 

{{% alert color="warning" %}} 
يكون تصدير PowerPoint إلى markdown **بدون صور** بشكل افتراضي. إذا أردت تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى تعيين `ExportType = MarkdownExportType.Visual` وتحديد BasePath حيث سيتم حفظ الصور المشار إليها في وثيقة markdown.
{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتمثيل كائن العرض التقديمي.
2. استخدم طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الكائن كملف markdown.

يعرض هذا الكود C# طريقة تحويل PowerPoint إلى markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **تحويل PowerPoint إلى نكهة Markdown**

يسمح Aspose.Slides لك بتحويل PowerPoint إلى markdown (يتضمن بناءً أساسيًا)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 نكهة markdown أخرى.

يعرض هذا الكود C# طريقة تحويل PowerPoint إلى CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


الـ 23 نكهة markdown المدعومة مُدرجة تحت تعداد Flavor من الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات أو إعدادات معينة لملف markdown الناتج. يمكن، على سبيل المثال، تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) إلى قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور تسلسليًا**

إذا كنت ترغب في ظهور الصور واحدة تلو الأخرى في markdown الناتج، عليك اختيار الخيار التسلسلي. يعرض هذا الكود C# طريقة تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا كنت ترغب في ظهور الصور معًا في markdown الناتج، عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم بناء مسار نسبي لها في وثيقة markdown)، أو يمكنك تحديد المسار واسم المجلد المفضل لديك.

يعرض هذا الكود C# العملية:
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

**هل يتم الحفاظ على الروابط الفوقية عند التصدير إلى Markdown؟**

نعم. تُحافظ على الروابط النصية [hyperlinks](/slides/ar/net/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل انتقالات الشرائح [transitions](/slides/ar/net/slide-transition/) والرسوم المتحركة [animations](/slides/ar/net/powerpoint-animation/).

**هل يمكنني تسريع التحويل عن طريق تشغيله في عدة خيوط؟**

يمكنك التوازي عبر الملفات، لكن لا تشارك نفس نسخة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) عبر الخيوط. استخدم نسخًا/عمليات منفصلة لكل ملف لتجنب التعارض.

**ماذا يحدث للصور—أين تُحفظ، وهل المسارات نسبية؟**

يتم تصدير [Images](/slides/ar/net/image/) إلى مجلد مخصص، وتُشير ملف Markdown إليها بمسارات نسبية بشكل افتراضي. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.