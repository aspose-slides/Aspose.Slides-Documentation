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
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في PHP باستخدام Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---

## **نظرة عامة**

تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF في PHP يوفر عدة مزايا، بما في ذلك التوافق عبر مختلف الأجهزة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الالتزام على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض في الصيغ التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) ثم احفظ العرض كملف PDF باستخدام طريقة `save`. تُظهر الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) طريقة `save` التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
يقوم Aspose.Slides for PHP via Java بإدراج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بالقيمة "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يتيح لك Aspose.Slides التحويل:
* كل العروض إلى PDF
* شرائح محددة من عرض إلى PDF

يصدر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق عن كثب مع العروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:
* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يظهر هذا الشيفرة كيفية تحويل عرض تقديمي (PPT، PPTX، ODP، إلخ) إلى PDF:
```php
# إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # حفظ العرض كملف PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


{{%  alert  color="primary"  %}} 
تقدم Aspose أداة تحويل مجانية على الإنترنت من [**PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) توضح عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذه الأداة لتجربة تطبيقية حية للإجراءات الموضحة هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصصة — خصائص ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) — تتيح لك تخصيص PDF الناتج، أو تأمينه بكلمة مرور، أو تحديد طريقة سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وغير ذلك.

يوضح مثال الشيفرة أدناه كيفية تحويل عرض PowerPoint إلى PDF مع عدة خيارات مخصصة.
```php
# إنشاء كائن من فئة PdfOptions.
$pdfOptions = new PdfOptions();

# تعيين جودة صور JPG.
$pdfOptions->setJpegQuality(90);

# تعيين DPI للصور.
$pdfOptions->setSufficientResolution(300);

# تعيين سلوك ملفات الميتا.
$pdfOptions->setSaveMetafilesAsPng(true);

# تعيين مستوى ضغط النص للمحتوى النصي.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# تعريف وضع الامتثال لـ PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # حفظ العرض كوثيقة PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) من الفئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) لإدراج الشرائح المخفية كصفحات في PDF الناتج.

تظهر هذه الشيفرة كيفية تحويل عرض PowerPoint إلى PDF مع تضمين الشرائح المخفية:
```php
# إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # إنشاء كائن من فئة PdfOptions.
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

توضح هذه الشيفرة كيفية تحويل عرض PowerPoint إلى PDF محمي بكلمة مرور باستخدام معايير الحماية من الفئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/):
```php
# إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # إنشاء كائن من فئة PdfOptions.
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


### **اكتشاف استبدال الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) ضمن الفئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) تمكّنك من اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

تظهر هذه الشيفرة كيفية اكتشاف استبدال الخطوط:
```php
// تعيين استدعاء التحذير في خيارات PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // حفظ العرض كملف PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{%  alert color="primary"  %}} 
لمزيد من المعلومات حول استلام ردود الفعل لاستبدال الخطوط أثناء عملية التصيير، راجع [Getting Warning Callbacks for Fonts Substitution](/slides/ar/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).  
للمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/php-java/font-substitution/).
{{% /alert %}} 

## **تحويل الشرائح المحددة في PowerPoint إلى PDF**

توضح هذه الشيفرة كيفية تحويل شرائح محددة فقط من عرض PowerPoint إلى PDF:
```php
# إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
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

توضح هذه الشيفرة كيفية تحويل عرض PowerPoint إلى PDF بحجم شريحة محدد:
```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# إنشاء عرض تقديمي جديد مع حجم شريحة معدّل.
$resizedPresentation = new Presentation();

try {
    # تعيين حجم الشريحة المخصص.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # استنساخ الشريحة الأولى من العرض التقديمي الأصلي.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # حفظ العرض المعاد تحجيمه كملف PDF مع الملاحظات.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```


## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

توضح هذه الشيفرة كيفية تحويل عرض PowerPoint إلى PDF يتضمن الملاحظات:
```php
# إنشاء كائن من فئة Presentation التي تمثل ملف PowerPoint أو OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # تهيئة خيارات PDF مع تخطيط الملاحظات.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # حفظ العرض كملف PDF مع الملاحظات.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


## **معايير إمكانية الوصول والامتثال للـ PDF**

يسمح لك Aspose.Slides باستخدام إجراء تحويل يتوافق مع [إرشادات إمكانية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

توضح هذه الشيفرة عملية تحويل PowerPoint إلى PDF تنتج عدة ملفات PDF بناءً على معايير امتثال مختلفة:
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
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى تنسيقات شائعة. يمكنك إجراء التحويلات [PDF إلى HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). تدعم عمليات التحويل الأخرى إلى تنسيقات متخصصة — [PDF إلى SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — كذلك.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**  
نعم، يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT أو PPTX إلى PDF. يمكنك المرور على ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المحول بكلمة مرور؟**  
بالطبع. استخدم الفئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**  
استخدم طريقة `setShowHiddenSlides` في الفئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة عالية للصور في PDF؟**  
نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل `setJpegQuality` و `setSufficientResolution` في الفئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لضمان صور ذات جودة عالية في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير امتثال PDF/A؟**  
نعم، يتيح لك Aspose.Slides تصدير ملفات PDF التي تتوافق مع معايير مختلفة، بما في ذلك PDF/A1a، PDF/A1b، و PDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for PHP via Java](/slides/ar/php-java/)
- [مرجع API لـ Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/php-java/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)