---
title: تحويل PowerPoint إلى Markdown في جافا
type: docs
weight: 140
url: /androidjava/convert-powerpoint-to-markdown/
keywords: "تحويل PowerPoint إلى Markdown, تحويل ppt إلى md, PowerPoint, PPT, PPTX, عرض تقديمي, Markdown, جافا, Aspose.Slides لـ Android عبر جافا"
description: "تحويل PowerPoint إلى Markdown في جافا"
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى Markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

تصدير PowerPoint إلى Markdown هو **بدون صور** بشكل افتراضي. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى ضبط  `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` وأيضًا ضبط `BasePath` حيث سيتم حفظ الصور المرجعية في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) لتمثيل كائن عرض تقديمي.
2. استخدم الطريقة [Save ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)لحفظ الكائن كملف markdown.

هذا رمز جافا يظهر لك كيفية تحويل PowerPoint إلى markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## تحويل PowerPoint إلى نكهة Markdown

يتيح لك Aspose.Slides تحويل PowerPoint إلى markdown (بما في ذلك النحو الأساسي)، CommonMark، Markdown بنكهة GitHub، Trello، XWiki، GitLab، و 17 نكهة أخرى من markdown.

هذا رمز جافا يظهر لك كيفية تحويل PowerPoint إلى CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

تدعم 23 نكهة من markdown [مذكورة تحت تعداد Flavor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) .

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) خصائص وتعدادات تتيح لك استخدام خيارات أو إعدادات معينة لملف markdown الناتج. يمكن، على سبيل المثال، ضبط تعداد [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) إلى قيم تحدد كيفية عرض أو التعامل مع الصور: `الترتيب`, `نص فقط`, `مرئي`.

### **تحويل الصور بالتسلسل**

إذا كنت تريد أن تظهر الصور بشكل فردي واحدة تلو الأخرى في markdown الناتج، يجب عليك اختيار الخيار التسلسلي. هذا رمز جافا يظهر لك كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تحويل الصور بصريًا**

إذا كنت تريد أن تظهر الصور معًا في markdown الناتج، يجب عليك اختيار الخيار المرئي. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم بناء مسار نسبي لها في مستند markdown)، أو يمكنك تحديد مسارك المفضل واسم المجلد.

هذا رمز جافا يوضح العملية:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```