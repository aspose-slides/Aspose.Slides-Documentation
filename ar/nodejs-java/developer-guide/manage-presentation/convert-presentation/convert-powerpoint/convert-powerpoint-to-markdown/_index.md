---
title: تحويل PowerPoint إلى Markdown باستخدام JavaScript
type: docs
weight: 140
url: /ar/nodejs-java/convert-powerpoint-to-markdown/
keywords: "تحويل PowerPoint إلى Markdown, تحويل ppt إلى md, PowerPoint, PPT, PPTX, عرض تقديمي, Markdown, Java, Aspose.Slides لـ Node.js عبر Java"
description: تحويل PowerPoint إلى Markdown باستخدام JavaScript
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

يكون تصدير PowerPoint إلى markdown **بدون صور** بشكل افتراضي. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى استدعاء `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور المشار إليها في مستند markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) لتمثيل كائن عرض تقديمي.  
2. استخدام طريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) لحفظ الكائن كملف markdown.

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

تتيح لك Aspose.Slides تحويل PowerPoint إلى markdown (بصيغة أساسية)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab، و 17 صيغة markdown أخرى.

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


الصيغ الـ23 المدعومة للـmarkdown مدرجة تحت تعداد [Flavor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) خصائص وتعدادات تتيح لك استخدام خيارات أو إعدادات معينة للملف markdown الناتج. على سبيل المثال، يمكن ضبط تعداد [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) إلى قيم تحدد كيفية عرض أو معالجة الصور: `Sequential`، `TextOnly`، `Visual`.

### **تحويل الصور تسلسليًا**

إذا كنت تريد ظهور الصور بشكل فردي واحدة تلو الأخرى في markdown الناتج، يجب اختيار الخيار التسلسلي. هذا الكود JavaScript يوضح لك كيفية تحويل عرض تقديمي يحتوي على صور إلى markdown:
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

إذا كنت تريد ظهور الصور معًا في markdown الناتج، يجب اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم إنشاء مسار نسبي لها في مستند markdown)، أو يمكنك تحديد المسار المفضل واسم المجلد.

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


## **الأسئلة الشائعة**

**هل تحافظ الارتباطات التشعبية على وجودها بعد التصدير إلى Markdown؟**

نعم. يتم الحفاظ على النصوص [الارتباطات التشعبية](/slides/ar/nodejs-java/manage-hyperlinks/) كروابط Markdown قياسية. ولا يتم تحويل [الانتقالات](/slides/ar/nodejs-java/slide-transition/) و[الرسوم المتحركة](/slides/ar/nodejs-java/powerpoint-animation/).

**هل يمكنني تسريع التحويل عبر تشغيله في عدة خيوط؟**

يمكنك تنفيذ التحويل بالتوازي عبر الملفات، لكن لا يجب [عدم المشاركة](/slides/ar/nodejs-java/multithreading/) لنفس نسخة [Presentation] عبر الخيوط. استخدم نسخًا/عمليات منفصلة لكل ملف لتجنب النزاع.

**ماذا يحدث للصور — أين يتم حفظها، وهل المسارات نسبية؟**

[الصور](/slides/ar/nodejs-java/image/) يتم تصديرها إلى مجلد مخصص، ويشير ملف Markdown إليها باستخدام مسارات نسبية بشكل افتراضي. يمكنك تكوين المسار الأساسي للإخراج واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.