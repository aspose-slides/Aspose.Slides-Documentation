---
title: تحويل عروض PowerPoint التقديمية إلى Markdown في Java
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيف باستخدام Aspose.Slides للـ Java، أتمتة التوثيق والحفاظ على التنسيق."
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

التصدير من PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا كنت ترغب في تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى تعيين `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) لتمثيل كائن العرض التقديمي.
2. استخدم طريقة [Save ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) لحفظ الكائن كملف markdown.

يظهر لك هذا الكود Java كيفية تحويل PowerPoint إلى markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## تحويل PowerPoint إلى نكهة Markdown

تتيح لك Aspose.Slides تحويل PowerPoint إلى markdown (يتضمن الصيغة الأساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 نكهة markdown أخرى.

يظهر لك هذا الكود Java كيفية تحويل PowerPoint إلى CommonMark:
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


الـ23 نكهة markdown المدعومة مدرجة [تحت تعداد Flavor](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات أو إعدادات معينة لملف markdown الناتج. على سبيل المثال، يمكن تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) إلى قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور بشكل متسلسل**

إذا كنت تريد ظهور الصور بشكل فردي واحدة تلو الأخرى في markdown الناتج، يجب اختيار الخيار المتسلسل. يوضح لك هذا الكود Java كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا كنت تريد ظهور الصور معًا في markdown الناتج، يجب اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم إنشاء مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار واسم المجلد المفضَل لديك.

يوضح لك هذا الكود Java العملية:
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
