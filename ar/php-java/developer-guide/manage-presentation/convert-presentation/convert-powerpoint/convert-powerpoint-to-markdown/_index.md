---
title: تحويل PowerPoint إلى Markdown
type: docs
weight: 140
url: /php-java/convert-powerpoint-to-markdown/
keywords: "تحويل PowerPoint إلى Markdown, تحويل ppt إلى md, PowerPoint, PPT, PPTX, عرض, Markdown, Java, Aspose.Slides لـ PHP عبر Java"
description: "تحويل PowerPoint إلى Markdown "
---

{{% alert color="info" %}} 

تم تنفيذ دعم تحويل PowerPoint إلى Markdown في [Aspose.Slides 23.7](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

تصدير PowerPoint إلى Markdown هو **بدون صور** بشكل افتراضي. إذا كنت تريد تصدير مستند PowerPoint يحتوي على صور، تحتاج إلى تعيين `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` وأيضًا تعيين `BasePath` حيث سيتم حفظ الصور الم referenced في مستند Markdown.

{{% /alert %}} 

## **تحويل PowerPoint إلى Markdown**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) لتمثيل كائن العرض.
2. استخدم طريقة [Save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) لحفظ الكائن كملف Markdown.

هذا الكود PHP يوضح لك كيفية تحويل PowerPoint إلى Markdown:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.md", SaveFormat::Md);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## تحويل PowerPoint إلى نكهة Markdown

يتيح لك Aspose.Slides تحويل PowerPoint إلى Markdown (يحتوي على بناء الجملة الأساسي)، CommonMark، Markdown بنكهة GitHub، Trello، XWiki، GitLab، و 17 نكهة Markdown أخرى.

هذا الكود PHP يوضح لك كيفية تحويل PowerPoint إلى CommonMark:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setFlavor(Flavor->CommonMark);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

تدعم 23 نكهة Markdown [مدرجة تحت تعداد Flavor](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/) من فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/).

## **تحويل العرض الذي يحتوي على صور إلى Markdown**

تقدم فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) خصائص وتعدادات تسمح لك باستخدام خيارات أو إعدادات معينة لملف Markdown الناتج. يمكن على سبيل المثال تعيين التعداد [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) إلى قيم تحدد كيفية عرض الصور أو التعامل معها: `Sequential`, `TextOnly`, `Visual`.

### **تحويل الصور بشكل تسلسلي**

إذا كنت تريد أن تظهر الصور فرديًا واحدة تلو الأخرى في Markdown الناتج، يجب عليك اختيار الخيار التسلسلي. هذا الكود PHP يوضح لك كيفية تحويل عرض يحتوي على صور إلى Markdown:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setShowHiddenSlides(true);
    $markdownSaveOptions->setShowSlideNumber(true);
    $markdownSaveOptions->setFlavor(Flavor->Github);
    $markdownSaveOptions->setExportType(MarkdownExportType::Sequential);
    $markdownSaveOptions->setNewLineType(NewLineType::Windows);
    $pres->save("doc.md", array(1, 2, 3, 4, 5, 6, 7, 8, 9 ), SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **تحويل الصور بصريًا**

إذا كنت تريد أن تظهر الصور معًا في Markdown الناتج، يجب عليك اختيار الخيار البصري. في هذه الحالة، سيتم حفظ الصور في الدليل الحالي للتطبيق (وسيتم بناء مسار نسبي لها في مستند Markdown)، أو يمكنك تحديد مسارك المفضل واسم المجلد.

هذا الكود PHP يوضح العملية:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $outPath = "c:/documents";
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setExportType(MarkdownExportType::Visual);
    $markdownSaveOptions->setImagesSaveFolderName("md-images");
    $markdownSaveOptions->setBasePath($outPath);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```