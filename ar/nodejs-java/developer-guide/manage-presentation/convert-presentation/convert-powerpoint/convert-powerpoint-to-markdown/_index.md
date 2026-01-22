---
title: تحويل عروض PowerPoint إلى Markdown باستخدام JavaScript
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/nodejs-java/convert-powerpoint-to-markdown/
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
- حفظ PowerPoint كملف Markdown
- حفظ العرض التقديمي كملف Markdown
- حفظ الشريحة كملف Markdown
- حفظ PPT كملف MD
- حفظ PPTX كملف MD
- تصدير PPT إلى MD
- تصدير PPTX إلى MD
- PowerPoint
- العرض التقديمي
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: تحويل شرائح PowerPoint في JavaScript - PPT، PPTX - إلى Markdown نظيف باستخدام Aspose.Slides لـ Node.js عبر Java، أتمتة توثيق المستندات والحفاظ على التنسيق.
---

{{% alert color="warning" %}} 
التصدير من PowerPoint إلى markdown يكون **بدون صور** بشكل افتراضي. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، يجب عليك استدعاء `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` وتحديد `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند markdown.
{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) لتمثيل كائن عرض تقديمي.  
2. استخدام الطريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) لحفظ الكائن كملف markdown.

هذا الكود JavaScript يوضح لك كيفية تحويل PowerPoint إلى markdown:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل PowerPoint إلى صيغة Markdown**

تمكنك Aspose.Slides من تحويل PowerPoint إلى markdown (يحتوي على صيغ أساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 صيغة أخرى من markdown.

هذا الكود JavaScript يوضح لك كيفية تحويل PowerPoint إلى CommonMark:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


الصيغ الـ23 المدعومة للـ markdown مُدرجة [في تعداد Flavor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) من الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) خصائص وتعدادات تتيح لك استخدام خيارات أو إعدادات معينة لملف markdown الناتج. يمكن، على سبيل المثال، ضبط تعداد [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) إلى قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور تسلسليًا**

إذا كنت تريد أن تظهر الصور بشكل فردي واحدة تلو الأخرى في markdown الناتج، عليك اختيار الخيار المتسلسل. يظهر لك هذا الكود JavaScript كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **تحويل الصور بصريًا**

إذا كنت تريد أن تظهر الصور معًا في markdown الناتج، عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في المجلد الحالي للتطبيق (وسيتم بناء مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار واسم المجلد المفضل لديك.

هذا الكود JavaScript يوضح العملية:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل تبقى الروابط الفائقة بعد التصدير إلى Markdown؟**

نعم. يتم الحفاظ على النصوص [hyperlinks](/slides/ar/nodejs-java/manage-hyperlinks/) كروابط Markdown قياسية. ولا يتم تحويل [transitions](/slides/ar/nodejs-java/slide-transition/) و[animations](/slides/ar/nodejs-java/powerpoint-animation/) الخاصة بالشرائح.

**هل يمكنني تسريع التحويل بتشغيله في عدة خيوط؟**

يمكنك تنفيذ التحويل بالتوازي عبر الملفات، لكن لا يجب [مشاركة](/slides/ar/nodejs-java/multithreading/) نفس مثيل [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) عبر الخيوط. استخدم مثيلات/عمليات منفصلة لكل ملف لتجنب التضارب.

**ماذا يحدث للصور — أين يتم حفظها، وهل المسارات نسبية؟**

يتم تصدير [Images](/slides/ar/nodejs-java/image/) إلى مجلد مخصص، ويشير ملف Markdown إليها باستخدام مسارات نسبية بشكل افتراضي. يمكنك ضبط مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على هيكل مستودع يمكن التنبؤ به.