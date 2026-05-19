---
title: تحويل PPT و PPTX إلى PDF في PHP [متضمنة الميزات المتقدمة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/php-java/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل العرض
- PowerPoint إلى PDF
- العرض إلى PDF
- PPT إلى PDF
- تحويل PPT إلى PDF
- PPTX إلى PDF
- تحويل PPTX إلى PDF
- حفظ PowerPoint كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في PHP باستخدام Aspose.Slides، مع أمثلة شفرة سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يوفر تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى تنسيق PDF في PHP عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في الصيغ التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كوسيطة إلى فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) توفر طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="ملاحظة"  color="warning"   %}} 

يدرج Aspose.Slides for PHP via Java معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل التطبيق بـ "*Aspose.Slides*" وحقل منتج PDF بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يسمح Aspose.Slides لك بتحويل:

* العروض الكاملة إلى PDF
* شرائح معينة من عرض إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مع ضمان مطابقة ملفات PDF الناتجة للعرض الأصلي بشكل كبير. تُعرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط الفائقة
* رؤوس وتذييلات الصفحات
* النقاط
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثلى بأعلى مستويات الجودة.

يظهر الكود التالي كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:

```php
# إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # حفظ العرض كملف PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

تقدم Aspose محولًا مجانيًا على الإنترنت للـ[**PowerPoint إلى PDF**](https://products.aspose.app/slides/ar/conversion/ppt-to-pdf) يوضح عملية تحويل العرض إلى PDF. يمكنك تجربة هذا المحول لتنفيذ العملية المذكورة هنا مباشرة.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—الخصائص الموجودة تحت فئة [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PdfOptions)—التي تتيح لك تخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، وتحديد طريقة معالجة ملفات الميتافايل، وتعيين مستوى ضغط النص، وتكوين DPI للصور، والمزيد.

يوضح المثال البرمجي أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.

```php
# إنشاء كائن فئة PdfOptions.
$pdfOptions = new PdfOptions();

# ضبط جودة صور JPG.
$pdfOptions->setJpegQuality(90);

# ضبط DPI للصور.
$pdfOptions->setSufficientResolution(300);

# ضبط سلوك ملفات الميتا.
$pdfOptions->setSaveMetafilesAsPng(true);

# ضبط مستوى ضغط النص للمحتوى النصي.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# تعريف وضع الامتثال لملف PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # حفظ العرض كملف PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) من فئة [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PdfOptions) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يظهر الكود التالي كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:

```php
# إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # إنشاء كائن فئة PdfOptions.
    $pdfOptions = new PdfOptions();

    # إضافة الشرائح المخفية.
    $pdfOptions->setShowHiddenSlides(true);

    # حفظ العرض كملف PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معايير الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/) :

```php
# إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # إنشاء كائن فئة PdfOptions.
    $pdfOptions = new PdfOptions();

    # تعيين كلمة مرور PDF وأذونات الوصول.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # حفظ العرض كملف PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **اكتشاف استبدالات الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveoptions/#setWarningCallback) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/) تمكّنك من اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

يظهر الكود التالي كيفية اكتشاف استبدالات الخطوط:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// تعيين رد الاتصال للتحذير في خيارات PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // حفظ العرض كملف PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/php-java/font-substitution/) .

{{% /alert %}} 

## **تحويل شرائح مختارة في PowerPoint إلى PDF**

يوضح هذا الكود كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:

```php
# إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # تعيين مصفوفة أرقام الشرائح.
    $slides = array(1, 3);

    # حفظ العرض كملف PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# إنشاء عرض جديد بحجم شريحة معدل.
$resizedPresentation = new Presentation();

try {
    # تعيين حجم الشريحة المخصص.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # استنساخ الشريحة الأولى من العرض الأصلي.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # حفظ العرض المعاد تحجيمه إلى PDF مع الملاحظات.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:

```php
# إنشاء كائن فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # تكوين خيارات PDF مع تخطيط الملاحظات.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # حفظ العرض إلى PDF مع الملاحظات.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **معايير الوصول والامتثال للـ PDF**

يتيح Aspose.Slides لك استخدام إجراء تحويل يتوافق مع [إرشادات إمكانية وصول محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يوضح هذا الكود عملية تحويل PowerPoint إلى PDF تُنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

يدعم Aspose.Slides عمليات تحويل PDF، مما يسمح لك بتحويل ملفات PDF إلى صيغ شائعة. يمكنك إجراء تحويلات مثل [PDF إلى HTML](https://products.aspose.com/slides/ar/php-java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/ar/php-java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/ar/php-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/ar/php-java/conversion/pdf-to-png/). تدعم عمليات تحويل PDF إلى صيغ متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/ar/php-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/ar/php-java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/ar/php-java/conversion/pdf-to-xml/) أيضًا.

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والمعادلات كشكل واحد. لا تُحافظ على عناصر المسار الفردية كفواصل محتوى منفصلة وقد تُصنّف كملحقات؛ يُوفر النص البديل فقط للشكل بأكمله.

## **الأسئلة المتداولة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك التنقل بين ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالتأكيد. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استخدم الطريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `setJpegQuality` و`setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF.

**هل يدعم Aspose.Slides معايير الامتثال لـ PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع معايير مختلفة بما فيها PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن توافق مستنداتك مع متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for PHP via Java](/slides/ar/php-java/)
- [مرجع API لـ Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/ar/php-java/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/ar/conversion)