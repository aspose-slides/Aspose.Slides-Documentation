---
title: تحويل عروض PowerPoint إلى Markdown على Android
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيفة باستخدام Aspose.Slides لأندرويد عبر Java، أتمتة التوثيق والحفاظ على التنسيق."
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى Markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

التصدير من PowerPoint إلى Markdown هو **بدون صور** افتراضيًا. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، يجب عليك تعيين `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند Markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) لتمثيل كائن العرض التقديمي.  
2. استخدم طريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) لحفظ الكائن كملف Markdown.

يظهر هذا الشيفرة Java كيفية تحويل PowerPoint إلى Markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحويل PowerPoint إلى نكهة Markdown**

تسمح لك Aspose.Slides بتحويل PowerPoint إلى Markdown (متضمنًا الصياغة الأساسية)، CommonMark، Markdown بنكهة GitHub، Trello، XWiki، GitLab، و 17 نكهة أخرى من Markdown.

يظهر هذا الشيفرة Java كيفية تحويل PowerPoint إلى CommonMark:
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


الـ 23 نكهة Markdown مدعومة مُدرجة في [المذكورة تحت تعداد Flavor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) خصائص وتعدادات تتيح لك استخدام خيارات أو إعدادات معينة لملف Markdown الناتج. يمكن، على سبيل المثال، تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) إلى قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور بشكل تسلسلي**

إذا كنت تريد ظهور الصور بشكل فردي واحدةً تلو الأخرى في Markdown الناتج، عليك اختيار الخيار التسلسلي. يوضح هذا الشيفرة Java كيفية تحويل عرض تقديمي يحتوي على صور إلى Markdown:
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

إذا كنت تريد ظهور الصور معًا في Markdown الناتج، عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في دليل التطبيق الحالي (وسيتم إنشاء مسار نسبي لها في مستند Markdown)، أو يمكنك تحديد المسار والمجلد المفضل لديك.

يُظهر هذا الشيفرة Java العملية:
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


## **الأسئلة الشائعة**

**هل تحتفظ الروابط التشعبية بالتصدير إلى Markdown؟**

نعم. يتم الحفاظ على الروابط النصية [الروابط التشعبية](/slides/ar/androidjava/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل انتقالات الشرائح [الانتقالات](/slides/ar/androidjava/slide-transition/) و[الرسوم المتحركة](/slides/ar/androidjava/powerpoint-animation/).

**هل يمكنني تسريع التحويل بتشغيله في عدة خيوط؟**

يمكنك إجراء التوازي عبر الملفات، ولكن [لا تشارك](/slides/ar/androidjava/multithreading/) نفس مثال [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) عبر الخيوط. استخدم أمثلة/عمليات منفصلة لكل ملف لتجنب التضارب.

**ماذا يحدث للصور — أين يتم حفظها، وهل المسارات نسبية؟**

يتم تصدير [الصور](/slides/ar/androidjava/image/) إلى مجلد مخصص، وتشير ملف Markdown إليها باستخدام مسارات نسبية افتراضيًا. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع توقعية.