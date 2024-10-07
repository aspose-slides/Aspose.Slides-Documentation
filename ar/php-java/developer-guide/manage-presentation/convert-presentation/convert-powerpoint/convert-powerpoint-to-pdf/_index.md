---
title: تحويل PowerPoint إلى PDF
linktitle: تحويل PowerPoint إلى PDF
type: docs
weight: 40
url: /php-java/convert-powerpoint-to-pdf/
keywords: "تحويل PowerPoint، عرض تقديمي، PowerPoint إلى PDF، PPT إلى PDF، PPTX إلى PDF، حفظ PowerPoint كـ PDF، PDF/A1a، PDF/A1b، PDF/UA، Java"
description: "تحويل عرض PowerPoint إلى PDF. حفظ PowerPoint كـ PDF مع الامتثال أو معايير الوصول"

---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل تنسيقات ملفات PowerPoint إلى PDF باستخدام PHP. تغطي مجموعة واسعة من المواضيع مثل:

- تحويل PPT إلى PDF
- تحويل PPTX إلى PDF
- تحويل ODP إلى PDF
- تحويل PowerPoint إلى PDF

## **تحويلات Java من PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض التقديمية في هذه التنسيقات إلى PDF:

* PPT
* PPTX
* ODP

لتحويل عرض تقديمي إلى PDF، عليك ببساطة تمرير اسم الملف كوسيط في فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) ثم حفظ العرض التقديمي كـ PDF باستخدام طريقة [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-). تعرض فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) طريقة [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) التي تستخدم عادة لتحويل عرض تقديمي إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

يكتب Aspose.Slides لـ PHP عبر Java معلومات واجهة برمجة التطبيقات و رقم الإصدار مباشرة في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يقوم Aspose.Slides لـ PHP عبر Java بملء حقل التطبيق بقيمة '*Aspose.Slides*' وحقل منتج PDF بقيمة في شكل '*Aspose.Slides v XX.XX*'. **ملاحظة** أنك لا تستطيع توجيه Aspose.Slides لـ PHP عبر Java لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}


يسمح Aspose.Slides لك بتحويل:

* عرض تقديمي كامل إلى PDF
* شريحة معينة في عرض تقديمي إلى PDF
* عرض تقديمي 

يصدر Aspose.Slides العروض التقديمية إلى PDF بطريقة تجعل محتويات الـ PDFs الناتجة متشابهة جدًا لتلك الموجودة في العروض التقديمية الأصلية. يتم عرض هذه العناصر والخصائص المعروفة بشكل صحيح غالبًا في تحويلات العروض التقديمية إلى PDF:

* الصور
* صناديق النص والأشكال الأخرى
* النصوص وتنسيقاتها
* الفقرات وتنسيقاتها
* الروابط التشعبية
* العناوين والتذييلات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

يتم تنفيذ عملية تحويل PDF القياسية لـ PowerPoint باستخدام الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض التقديمي المقدم إلى PDF باستخدام إعدادات مثالية على مستويات جودة قصوى.

يوضح هذا الكود PHP كيفية تحويل PowerPoint إلى PDF:

```php
  # ينشئ فئة Presentation التي تمثل ملف PowerPoint
  $pres = new Presentation("PowerPoint.ppt");
  try {
    # يحفظ العرض التقديمي كـ PDF
    $pres->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  color="primary"  %}} 

يوفر Aspose محول [**PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) مجاني على الإنترنت يوضح عملية تحويل العرض التقديمي إلى PDF. لإجراء اختبار حي للإجراء الموضح هنا، يمكنك إجراء اختبار مع المحول.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة - خصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) - تسمح لك بتخصيص PDF (الذي ينتج عن عملية التحويل)، قفل PDF بكلمة مرور، أو حتى تحديد كيفية تنفيذ عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تعيين إعداد الجودة المفضل لديك لصور JPG، تحديد كيفية التعامل مع ملفات التعريف، تعيين مستوى ضغط للنصوص، وما إلى ذلك.

يوضح هذا الكود PHP عملية يتم فيها تحويل PowerPoint إلى PDF مع عدة خيارات مخصصة:

```php
// ينشئ فئة Presentation التي تمثل ملف PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # ينشئ فئة PdfOptions
    $pdfOptions = new PdfOptions();
    # يحدد جودة Jpeg
    $pdfOptions->setJpegQuality(90);
    # يحدد سلوك ملفات التعريف
    $pdfOptions->setSaveMetafilesAsPng(true);
    # يحدد مستوى ضغط النصوص
    $pdfOptions->setTextCompression(PdfTextCompression::Flate);
    # يحدد معيار PDF
    $pdfOptions->setCompliance(PdfCompliance::Pdf15);
    # يحفظ العرض التقديمي كـ PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **تحويل PowerPoint إلى PDF مع شرائح مخفية**

إذا كان العرض التقديمي يحتوي على شرائح مخفية، يمكنك استخدام خيار مخصص - خاصية [ShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IPdfOptions#getShowHiddenSlides--) من فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) - لإرشاد Aspose.Slides لضم الشرائح المخفية كصفحات في PDF الناتج.

يوضح هذا الكود PHP كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```php
// ينشئ فئة Presentation التي تمثل ملف PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # ينشئ فئة PdfOptions
    $pdfOptions = new PdfOptions();
    # يضيف الشرائح المخفية
    $pdfOptions->setShowHiddenSlides(true);
    # يحفظ العرض التقديمي كـ PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يوضح هذا الكود PHP كيفية تحويل PowerPoint إلى PDF محمي بكلمة مرور (باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)):

```php
// ينشئ كائن Presentation الذي يمثل ملف PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # ينشئ فئة PdfOptions
    $pdfOptions = new PdfOptions();
    # يحدد كلمة مرور PDF وأذونات الوصول
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);
    # يحفظ العرض التقديمي كـ PDF
    $pres->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **كشف استبدالات الخطوط**

يوفر Aspose.Slides وظيفة [getWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#getWarningCallback--) تحت فئة [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) للسماح لك بكشف استبدالات الخطوط في عملية تحويل عرض تقديمي إلى PDF.

يوضح هذا الكود PHP كيفية كشف استبدالات الخطوط:

```php

class FontSubstSendsWarningCallback {
    function warning($warning)
    {
          if (java_values($warning->getWarningType() == WarningType::CompatibilityIssue)) {
            return ReturnAction::Continue;
          }
          if (java_values($warning->getWarningType() == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted"))) {
            echo ("تحذير استبدال الخط: " . $warning->getDescription());
          }
          return ReturnAction::Continue;
    }
}

  $loadOptions = new LoadOptions();
  $warningCallback = java_closure(new FontSubstSendsWarningCallback(), null, java("com.aspose.slides.IWarningCallback"));
  $loadOptions->setWarningCallback($warningCallback);
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

للحصول على مزيد من المعلومات حول الحصول على ردود النداء لاستبدالات الخطوط في عملية العرض، راجع [الحصول على ردود النداء لتحذيرات استبدال الخطوط](https://docs.aspose.com/slides/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

للحصول على مزيد من المعلومات حول استبدال الخطوط، راجع مقال [استبدال الخطوط](https://docs.aspose.com/slides/php-java/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة في PowerPoint إلى PDF**

يوضح هذا الكود PHP كيفية تحويل شرائح معينة في عرض PowerPoint إلى PDF:

```php
// ينشئ كائن Presentation الذي يمثل ملف PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # يحدد مصفوفة من مواضع الشرائح
    $slides = array(1, 3 );
    # يحفظ العرض التقديمي كـ PDF
    $pres->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

يوضح هذا الكود PHP كيفية تحويل PowerPoint عندما يتم تحديد حجم شريحته إلى PDF:

```php
// ينشئ كائن Presentation الذي يمثل ملف PowerPoint 
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $outPres = new Presentation();
    try {
      $slide = $pres->getSlides()->get_Item(0);
      $outPres->getSlides()->insertClone(0, $slide);
      # يحدد نوع وحجم الشريحة
      $outPres->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
      $pdfOptions = new PdfOptions();
      $options = $pdfOptions->getNotesCommentsLayouting();
      $options->setNotesPosition(NotesPositions::BottomFull);
      $outPres->save("PDFnotes_out.pdf", SaveFormat::Pdf, $pdfOptions);
    } finally {
      if (!java_is_null($pres)) {
        $pres->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشرائح**

يوضح هذا الكود PHP كيفية تحويل PowerPoint إلى PDF ملاحظات:

```php
// ينشئ فئة Presentation التي تمثل ملف PowerPoint
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $options = $pdfOptions->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    $pres->save("Pdf_With_Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **معايير الوصول والامتثال لـ PDF**

يسمح Aspose.Slides لك باستخدام إجراء تحويل يتوافق مع [معايير الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يوضح هذا الكود PHP عملية تحويل PowerPoint إلى PDF حيث يتم الحصول على عدة PDFs بناءً على معايير الامتثال المختلفة:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $pres->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $pres->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $pres->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ملحوظة" color="warning" %}} 

يدعم Aspose.Slides عمليات تحويل PDF حتى تسمح لك بتحويل PDF إلى أكثر تنسيقات الملفات شيوعًا. يمكنك إجراء [PDF إلى HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) تحويلات. كما أن عمليات تحويل PDF إلى تنسيقات متخصصة - [PDF إلى SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) - مدعومة أيضًا.

{{% /alert %}}