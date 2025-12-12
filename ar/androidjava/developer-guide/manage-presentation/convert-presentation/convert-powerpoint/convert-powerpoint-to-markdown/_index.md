---
title: "تحويل عروض PowerPoint إلى Markdown على Android"
linktitle: "PowerPoint إلى Markdown"
type: docs
weight: 140
url: /ar/androidjava/convert-powerpoint-to-markdown/
keywords:
- "تحويل PowerPoint"
- "تحويل العرض التقديمي"
- "تحويل الشريحة"
- "تحويل PPT"
- "تحويل PPTX"
- "PowerPoint إلى MD"
- "العرض التقديمي إلى MD"
- "الشريحة إلى MD"
- "PPT إلى MD"
- "PPTX إلى MD"
- "حفظ PowerPoint بصيغة Markdown"
- "حفظ العرض التقديمي بصيغة Markdown"
- "حفظ الشريحة بصيغة Markdown"
- "حفظ PPT بصيغة MD"
- "حفظ PPTX بصيغة MD"
- "تصدير PPT إلى MD"
- "تصدير PPTX إلى MD"
- "PowerPoint"
- "العرض التقديمي"
- "Markdown"
- "Android"
- "Java"
- "Aspose.Slides"
description: "تحويل شرائح PowerPoint-PPT، PPTX-إلى Markdown نظيف باستخدام Aspose.Slides لنظام Android عبر Java، أتمتة الوثائق والحفاظ على التنسيق."
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

تصدير PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى ضبط `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) لتمثيل كائن عرض تقديمي.
2. استخدم طريقة [حفظ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)-لحفظ الكائن كملف markdown.

هذا الكود Java يوضح لك كيفية تحويل PowerPoint إلى markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحويل PowerPoint إلى صيغة Markdown**

يتيح لك Aspose.Slides تحويل PowerPoint إلى markdown (بما يحتوي على الصياغة الأساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 صيغة markdown أخرى.

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


الصيغ الـ23 المدعومة لـ markdown مدرجة في [قائمة Flavor enumeration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) خصائص وتعدادات تتيح لك استخدام خيارات أو إعدادات معينة لملف markdown الناتج. يمكن تعيين تعداد [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/)، على سبيل المثال، إلى قيم تحدد كيفية معالجة أو عرض الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور بشكل تسلسلي**

إذا كنت تريد ظهور الصور واحدة تلو الأخرى بشكل فردي في markdown الناتج، عليك اختيار الخيار التسلسلي. يوضح لك هذا الكود Java كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا كنت تريد ظهور الصور معًا في markdown الناتج، عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم إنشاء مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار المفضل واسم المجلد.

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


## **الأسئلة الشائعة**

**هل تبقى الروابط التشعبية بعد التصدير إلى Markdown؟**

نعم. يتم حفظ نص [الروابط التشعبية](/slides/ar/androidjava/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل [الانتقالات](/slides/ar/androidjava/slide-transition/) و[الرسوم المتحركة](/slides/ar/androidjava/powerpoint-animation/) للشرائح.

**هل يمكنني تسريع التحويل عن طريق تشغيله في عدة خيوط؟**

يمكنك إجراء التوازي عبر الملفات، لكن لا [تشترك](/slides/ar/androidjava/multithreading/) في نفس كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) عبر الخيوط. استخدم كائنات/عمليات منفصلة لكل ملف لتجنب التضارب.

**ماذا يحدث للصور—أين يتم حفظها، وهل المسارات نسبية؟**

[الصور](/slides/ar/androidjava/image/) يتم تصديرها إلى مجلد مخصص، ويشير ملف Markdown إليها باستخدام مسارات نسبية بشكل افتراضي. يمكنك ضبط مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.