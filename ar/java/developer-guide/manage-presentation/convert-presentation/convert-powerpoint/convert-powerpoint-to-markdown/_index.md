---
title: تحويل عروض PowerPoint إلى Markdown في Java
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيفة باستخدام Aspose.Slides للغة Java، أتمتة التوثيق والحفاظ على التنسيق."
---

{{% alert color="info" %}} 

تم تنفيذ دعم التحويل من PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

تصدير PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا أردت تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى ضبط `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` وأيضًا تحديد `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) لتمثيل كائن عرض تقديمي.  
2. استخدام طريقة [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) لحفظ الكائن كملف markdown.

هذا الكود Java يوضح لك كيفية تحويل PowerPoint إلى markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحويل PowerPoint إلى نمط Markdown**

يتيح Aspose.Slides لك تحويل PowerPoint إلى markdown (الذي يحتوي على الصياغة الأساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 نمطًا آخرًا من markdown.

هذا الكود Java يوضح لك كيفية تحويل PowerPoint إلى CommonMark:
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


الـ23 نمط markdown المدعومة مُدرجة [في تعداد Flavor](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات أو إعدادات معينة لملف markdown الناتج. يمكن ضبط تعداد [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/)، على سبيل المثال، إلى قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`, `TextOnly`, `Visual`.

### **تحويل الصور بالتسلسل**

إذا أردت أن تظهر الصور بشكل منفرد واحدةً تلو الأخرى في markdown الناتج، يجب اختيار الخيار المتسلسل. هذا الكود Java يوضح لك كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا أردت أن تظهر الصور معًا في markdown الناتج، يجب اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم إنشاء مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار واسم المجلد المفضل لديك.

هذا الكود Java يوضح العملية:
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


## **الأسئلة المتكررة**

**هل تحتفظ الروابط التشعبية أثناء التصدير إلى Markdown؟**

نعم. يتم الحفاظ على نص [hyperlinks](/slides/ar/java/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل [transitions](/slides/ar/java/slide-transition/) و[animations](/slides/ar/java/powerpoint-animation/) الخاصة بالشرائح.

**هل يمكنني تسريع التحويل بتشغيله في عدة خيوط؟**

يمكنك تنفيذ التحويل بالتوازي عبر الملفات، ولكن لا يجب [لا تشارك](/slides/ar/java/multithreading/) نفس مثيل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) عبر الخيوط. استخدم مثيلات/عمليات منفصلة لكل ملف لتجنب التعارض.

**ماذا يحدث للصور—أين يتم حفظها، وهل المسارات نسبية؟**

يتم تصدير [الصور](/slides/ar/java/image/) إلى مجلد مخصص، ويشير ملف Markdown إليها باستخدام مسارات نسبية بشكل افتراضي. يمكنك ضبط مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.