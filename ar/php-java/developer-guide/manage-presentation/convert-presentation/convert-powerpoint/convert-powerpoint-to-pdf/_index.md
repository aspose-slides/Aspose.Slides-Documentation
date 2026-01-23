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

يقدم تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF في PHP عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في الصيغ التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض إلى PDF، مرّر اسم الملف كمعامل إلى فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. تُظهر فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

يقوم Aspose.Slides for PHP via Java بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض إلى PDF، يملأ Aspose.Slides حقل التطبيق بـ "*Aspose.Slides*" وحقل منتج PDF بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

يتيح Aspose.Slides لك تحويل:

* العروض بالكامل إلى PDF
* شرائح محددة من عرض إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مما يضمن أن تطابق ملفات PDF الناتجة العروض الأصلية بأقرب صورة. يتم عرض العناصر والسمات بدقة في التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثلى بأعلى مستويات الجودة.

يوضح هذا الكود كيفية تحويل عرض (PPT، PPTX، ODP، إلخ) إلى PDF:
```php
# إنشاء كائن من الفئة Presentation التي تمثّل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # حفظ العرض كملف PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


{{%  alert  color="primary"  %}} 

يقدم Aspose مُحوّلًا مجانيًا على الإنترنت لـ[**PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية التحويل من العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذا المحوّل لتجربة تنفيذ مباشر للإجراء الموضح هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)—تسمح لك بتخصيص PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى ضغط للنص، وتكوين DPI للصور، والمزيد.

يُظهر مثال الكود أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```php
# إنشاء كائن من الفئة PdfOptions.
$pdfOptions = new PdfOptions();

# تعيين جودة صور JPG.
$pdfOptions->setJpegQuality(90);

# تعيين DPI للصور.
$pdfOptions->setSufficientResolution(300);

# تعيين سلوك ملفات الميتافايل.
$pdfOptions->setSaveMetafilesAsPng(true);

# تعيين مستوى ضغط النص للمحتوى النصي.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# تحديد وضع الامتثال لـ PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # حفظ العرض كملف PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) من فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```php
# إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # إنشاء كائن من الفئة PdfOptions.
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

يُظهر هذا الكود كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معلمات الحماية من فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/):
```php
# إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # إنشاء كائن من الفئة PdfOptions.
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

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتتيح لك اكتشاف استبدالات الخطوط أثناء عملية التحويل من العرض إلى PDF.

يظهر هذا الكود كيفية اكتشاف استبدالات الخطوط:
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

// تعيين رد الاتصال التحذيري في خيارات PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // حفظ العرض كملف PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{%  alert color="primary"  %}} 

لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/php-java/font-substitution/).

{{% /alert %}} 

## **تحويل شرائح محددة في PowerPoint إلى PDF**

يُظهر هذا الكود كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```php
# إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
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


## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

يُظهر هذا الكود كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# إنشاء عرض تقديمي جديد بحجم شريحة معدل.
$resizedPresentation = new Presentation();

try {
    # تعيين حجم الشريحة المخصص.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # استنساخ الشريحة الأولى من العرض الأصلي.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # حفظ العرض المعاد تحجيمه كملف PDF مع الملاحظات.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```


## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشرائح**

يُظهر هذا الكود كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```php
# إنشاء كائن من الفئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # ضبط خيارات PDF مع تخطيط الملاحظات.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # حفظ العرض إلى ملف PDF مع الملاحظات.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


## **معايير الوصول والامتثال لـ PDF**

يتيح Aspose.Slides لك استخدام إجراء تحويل يتوافق مع [إرشادات الوصول إلى محتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

يُظهر هذا الكود عملية تحويل PowerPoint إلى PDF تنتج عدة ملفات PDF بناءً على معايير امتثال مختلفة:
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


{{% alert title="Note" color="warning" %}} 

يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك تنفيذ التحويلات إلى [PDF إلى HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). تدعم عمليات التحويل إلى صيغ متخصصة أخرى—[PDF إلى SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—أيضًا.

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك تكرار الملفات وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**

بالتأكيد. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**

استخدم طريقة `setShowHiddenSlides` في فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يستطيع Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**

نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل `setJpegQuality` و`setSufficientResolution` في فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح Aspose.Slides تصدير PDFs تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، لضمان توافق مستنداتك مع متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for PHP via Java](/slides/ar/php-java/)
- [مرجع API لـ Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/php-java/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)