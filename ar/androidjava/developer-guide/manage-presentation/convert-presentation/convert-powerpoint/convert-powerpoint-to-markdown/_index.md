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
description: "تحويل شرائح PowerPoint—PPT، PPTX—إلى Markdown نظيف باستخدام Aspose.Slides لأندرويد عبر جافا، أتمتة الوثائق والحفاظ على التنسيق."
---

يدعم Aspose.Slides تحويل العروض التقديمية إلى تنسيق markdown.

{{% alert color="warning" %}} 
تصدير PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا كنت ترغب في تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى تعيين `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` وأيضًا تحديد `BasePath` حيث سيتم حفظ الصور المشار إليها في وثيقة markdown.
{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) لتمثيل كائن العرض التقديمي.  
2. استخدم طريقة [حفظ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) لحفظ الكائن كملف markdown.

يظهر لك هذا الكود Java كيفية تحويل PowerPoint إلى markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحويل PowerPoint إلى نكهة Markdown**

يتيح لك Aspose.Slides تحويل PowerPoint إلى markdown (يتضمن الصياغة الأساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 نكهة markdown أخرى.

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


الـ 23 نكهة markdown المدعومة مُدرجة [تحت تعداد Flavor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) خصائص وتعدادات تتيح لك استخدام خيارات أو إعدادات معينة لملف markdown الناتج. يمكن ضبط تعداد [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) على قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور تسلسليًا**

إذا كنت ترغب في ظهور الصور بشكل فردي واحدة تلو الأخرى في markdown الناتج، عليك اختيار الخيار التسلسلي. يُظهر لك هذا الكود Java كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا كنت ترغب في ظهور الصور معًا في markdown الناتج، عليك اختيار الخيار البصري.   في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم إنشاء مسار نسبي لها في وثيقة markdown)، أو يمكنك تحديد المسار واسم المجلد المفضل لديك.

يظهر لك هذا الكود Java عملية التنفيذ:
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

**هل تبقى الروابط الفائقة محفوظة بعد التصدير إلى Markdown؟**

نعم. يتم الحفاظ على [الروابط الفائقة](/slides/ar/androidjava/manage-hyperlinks/) في النص كروابط Markdown قياسية. أما [انتقالات الشرائح](/slides/ar/androidjava/slide-transition/) و[الرسوم المتحركة](/slides/ar/androidjava/powerpoint-animation/) فلا يتم تحويلها.

**هل يمكنني تسريع التحويل بتشغيله في عدة خيوط؟**

يمكنك إجراء المعالجة المتوازية عبر الملفات، لكن [لا تشارك](/slides/ar/androidjava/multithreading/) نفس مثيل [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) عبر الخيوط. استخدم مثيلات/عمليات منفصلة لكل ملف لتجنّب التداخل.

**ماذا يحدث للصور—أين يتم حفظها، وهل المسارات نسبية؟**

[الصور](/slides/ar/androidjava/image/) تُصدَّر إلى مجلد مخصص، وتُشير إليها ملف Markdown باستخدام مسارات نسبية بشكل افتراضي. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.