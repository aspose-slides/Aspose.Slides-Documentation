---
title: تحويل عروض PowerPoint إلى Markdown في PHP
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/php-java/convert-powerpoint-to-markdown/
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
- PHP
- Aspose.Slides
description: "تحويل شرائح PowerPoint — PPT ، PPTX — إلى Markdown نظيف باستخدام Aspose.Slides للـ PHP عبر Java، أتمتة التوثيق والحفاظ على التنسيق."
---

## **نظرة عامة**

Aspose.Slides for PHP via Java يتيح تحويل محتوى العروض التقديمية إلى Markdown، مما يسمح لك بإعادة استخدام ملفات PowerPoint (PPT، PPTX) وOpenDocument (ODP) في الويكي، مستودعات Git، ومولدات المواقع الثابتة. تحافظ API على تسلسل الشرائح الهرمي مع إنتاج Markdown خفيف الوزن وسهل القراءة، حتى تتمكن من أتمتة خطوط وثائقك والحفاظ على تزامن العروض الأصلية وملفات Markdown بشكل مثالي.

تم تنفيذ دعم تحويل PowerPoint إلى Markdown في [Aspose.Slides 23.7](https://releases.aspose.com/slides/php-java/release-notes/2023/aspose-slides-for-php-via-java-23-7-release-notes/).

## **تحويل عرض تقديمي إلى Markdown**

يوضح هذا القسم كيف يقوم Aspose.Slides بتحويل عروض PowerPoint وOpenDocument (PPT، PPTX، ODP) إلى Markdown نظيف، مع الحفاظ على تسلسل الشرائح الأصلي، النص، والتنسيق الأساسي، بحيث يمكنك إعادة استخدام المحتوى في الوثائق أو عمليات سير العمل التي تُدار عبر نظام التحكم بالإصدارات دون جهد يدوي إضافي.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) لتمثيل العرض التقديمي.  
1. استخدم الطريقة [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) لتصديره كملف Markdown.

يعرض هذا الكود PHP كيفية تحويل عرض PowerPoint إلى Markdown:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```


## **تحويل عرض تقديمي إلى نكهة Markdown**

يسمح Aspose.Slides لك بتحويل عروض PowerPoint إلى Markdown باستخدام البنية الأساسية، وكذلك إلى CommonMark، GitHub‑flavored Markdown، Trello، XWiki، GitLab، وسبع عشرة نكهة أخرى من Markdown.

يعرض الكود PHP التالي كيفية تحويل عرض PowerPoint إلى CommonMark:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


يتم سرد النكهات الـ23 المدعومة في [Flavor enumeration](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/).

## **تحويل عرض تقديمي يحتوي على صور إلى Markdown**

توفر الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) خصائص وتعدادات تسمح لك بتكوين ملف Markdown الناتج. على سبيل المثال، يحدد تعداد [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) كيفية معالجة الصور: `Sequential` أو `TextOnly` أو `Visual`.

{{% alert color="warning" %}}
بشكل افتراضي، تصدير PowerPoint‑to‑Markdown **لا يتضمن الصور**. لتضمين الصور، استدعِ `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` وحدد `BasePath` الذي يحدد مكان حفظ الصور المشار إليها في ملف Markdown.
{{% /alert %}}

### **تحويل الصور تسلسلياً**

إذا كنت ترغب في ظهور الصور بشكل فردي، واحدةً تلو الأخرى، في Markdown الناتج، عليك اختيار الخيار `Sequential`. يظهر الكود PHP التالي كيفية تحويل عرض يحتوي على صور إلى Markdown:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


### **تحويل الصور بصرياً**

إذا كنت تريد ظهور الصور معاً في Markdown الناتج، عليك اختيار الخيار `Visual`. في هذه الحالة تُحفظ الصور في دليل التطبيق الحالي (ويُولد مسار نسبي لها في مستند Markdown)، أو يمكنك تحديد الدليل والمجلد المفضل لديك.

يعرض الكود PHP التالي عملية التحويل:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


## **الأسئلة المتداولة**

**هل تبقى الروابط الفائقة (hyperlinks) بعد التصدير إلى Markdown؟**  
نعم. يتم الحفاظ على روابط النص [hyperlinks](/slides/ar/php-java/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل انتقالات الشرائح [transitions](/slides/ar/php-java/slide-transition/) أو الرسوم المتحركة [animations](/slides/ar/php-java/powerpoint-animation/).

**هل يمكن تسريع التحويل بتشغيله في عدة خيوط (threads)؟**  
يمكنك تقسيم العمل عبر ملفات متعددة، ولكن لا تُشارك نفس مثيل الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بين الخيوط. استخدم مثيلات/عمليات منفصلة لكل ملف لتجنب التنافس.

**ماذا يحدث للصور—أين تُحفظ، وهل المسارات نسبية؟**  
تُصدّر الصور إلى مجلد مخصص، وتُشير ملفات Markdown إليها باستخدام مسارات نسبية بشكل افتراضي. يمكنك تكوين مسار الإخراج الأساسي واسم مجلد الأصول للحفاظ على بنية مستودع متوقعة.