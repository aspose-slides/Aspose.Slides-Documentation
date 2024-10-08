---
title: تحويل PowerPoint إلى Markdown في Java
type: docs
weight: 140
url: /ar/java/convert-powerpoint-to-markdown/
keywords: "تحويل PowerPoint إلى Markdown، تحويل ppt إلى md، PowerPoint، PPT، PPTX، عرض تقديمي، Markdown، Java، Aspose.Slides لـ Java"
description: "تحويل PowerPoint إلى Markdown في Java"
---

{{% alert color="info" %}} 

تم تنفيذ الدعم لتحويل PowerPoint إلى Markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

تصدير PowerPoint إلى Markdown هو **بدون صور** بشكل افتراضي. إذا كنت ترغب في تصدير وثيقة PowerPoint تحتوي على صور، يتعين عليك تعيين `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند Markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) لتمثيل كائن العرض التقديمي.
2. استخدم طريقة [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) لحفظ الكائن كملف Markdown.

يعرض هذا الشيفرة البرمجية في Java كيفية تحويل PowerPoint إلى Markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## تحويل PowerPoint إلى نكهة Markdown

يتيح لك Aspose.Slides تحويل PowerPoint إلى Markdown (يحتوي على بناء جملة أساسي)، CommonMark، Markdown بنكهة GitHub، Trello، XWiki، GitLab، و17 نكهة أخرى من Markdown.

يعرض هذا الشيفرة البرمجية في Java كيفية تحويل PowerPoint إلى CommonMark:

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

توجد 23 نكهة مدعومة من Markdown [مدرجة تحت تعداد Flavor](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) .

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

تقدم فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات معينة أو إعدادات لملف Markdown الناتج. يمكن تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) على قيم تحدد كيفية عرض الصور أو التعامل معها: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور بشكل متسلسل**

إذا كنت ترغب في أن تظهر الصور بشكل منفصل واحدة تلو الأخرى في Markdown الناتج، يجب عليك اختيار الخيار المتسلسل. يعرض هذا الشيفرة البرمجية في Java كيفية تحويل عرض تقديمي يحتوي على صور إلى Markdown:

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

إذا كنت ترغب في أن تظهر الصور معًا في Markdown الناتج، يجب عليك اختيار الخيار المرئي. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم بناء مسار نسبي لها في مستند Markdown) ، أو يمكنك تحديد المسار المفضل واسم المجلد.

توضح هذه الشيفرة البرمجية في Java العملية:

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