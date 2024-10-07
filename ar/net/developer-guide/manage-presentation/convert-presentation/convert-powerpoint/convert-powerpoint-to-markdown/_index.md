---
title: تحويل PowerPoint إلى Markdown في C#
type: docs
weight: 140
url: /net/convert-powerpoint-to-markdown/
keywords: "تحويل PowerPoint إلى Markdown, تحويل ppt إلى md, PowerPoint, PPT, PPTX, عرض تقديمي, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "تحويل PowerPoint إلى Markdown في C#"
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى Markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

التصدير من PowerPoint إلى Markdown هو **بدون صور** بشكل افتراضي. إذا كنت ترغب في تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى ضبط `ExportType = MarkdownExportType.Visual` وتحديد BasePath حيث سيتم حفظ الصور المشار إليها في مستند Markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتمثيل كائن العرض التقديمي.
2. استخدم طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الكائن كملف Markdown.

هذا الشيفرة C# توضح لك كيفية تحويل PowerPoint إلى Markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## تحويل PowerPoint إلى نكهة Markdown

تسمح Aspose.Slides لك بتحويل PowerPoint إلى Markdown (الذي يحتوي على بناء جملة أساسي)، CommonMark، Markdown ذو نكهة GitHub، Trello، XWiki، GitLab، و17 نكهة أخرى من Markdown.

هذه الشيفرة C# توضح لك كيفية تحويل PowerPoint إلى CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

تم سرد 23 نكهة مدعومة من Markdown في [تعداد Flavor](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) .

## **تحويل عرض يتضمن صوراً إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) خصائص وعددات تتيح لك استخدام خيارات أو إعدادات معينة لملف Markdown الناتج. على سبيل المثال، يمكن تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) إلى قيم تحدد كيفية عرض الصور أو التعامل معها: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور بطريقة متتالية**

إذا كنت ترغب في ظهور الصور بشكل فردي واحد تلو الآخر في Markdown الناتج، يجب عليك اختيار الخيار المتتالي. هذا الشيفرة C# توضح لك كيفية تحويل عرض يتضمن صوراً إلى Markdown:

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

### **تحويل الصور بصرياً**

إذا كنت ترغب في ظهور الصور معاً في Markdown الناتج، يجب عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في المجلد الحالي للتطبيق (وسيتم بناء مسار نسبي لها في مستند Markdown)، أو يمكنك تحديد مسارك المفضل واسم المجلد.

هذه الشيفرة C# توضح لك العملية:

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