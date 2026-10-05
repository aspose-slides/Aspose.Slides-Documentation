---
title: "تحويل PPT و PPTX إلى PDF في PHP [الميزات المتقدمة مشمولة]"
linktitle: "PowerPoint إلى PDF"
type: docs
weight: 40
url: /ar/php-java/convert-powerpoint-to-pdf/
keywords:
- "تحويل PowerPoint"
- "تحويل العرض التقديمي"
- "PowerPoint إلى PDF"
- "العرض التقديمي إلى PDF"
- "PPT إلى PDF"
- "تحويل PPT إلى PDF"
- "PPTX إلى PDF"
- "تحويل PPTX إلى PDF"
- "حفظ PowerPoint كـ PDF"
- "حفظ PPT كـ PDF"
- "حفظ PPTX كـ PDF"
- "تصدير PPT إلى PDF"
- "تصدير PPTX إلى PDF"
- "مرفق"
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في PHP باستخدام Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT و PPTX و ODP وغيرها) إلى صيغة PDF في PHP يقدم عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي الخاص بك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات متعددة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الالتزام على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) يوفّر طريقة [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) التي تُستخدم عادةً لتحويل العرض إلى PDF.

{{% alert color="info" title="Note" %}}
يضيف Aspose.Slides for PHP via Java معلومات API ورقم الإصدار إلى المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يملأ Aspose.Slides حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة على الشكل "*Aspose.Slides v XX.XX*". **ملاحظة** أنك لا تستطيع توجيه Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يتيح Aspose.Slides لك تحويل:
* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مع ضمان أن تكون ملفات PDF الناتجة مطابقة للعرض الأصلي قدر الإمكان. يتم عرض العناصر والسمات بدقة في عملية التحويل، بما في ذلك:

* الصور
* مربعات النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* القوئم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

المثال التالي يحمل عرضًا تقديميًا ويحفظ جميع الشرائح الظاهرة إلى PDF باستخدام إعدادات التصدير الافتراضية.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
يوفر Aspose أداة مجانية على الإنترنت [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تظهر عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذا المحول لتجربة تنفيذ العملية مباشرة.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصصة—خصائص ضمن الصنف [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—تتيح لك تخصيص ملف PDF الناتج، أو قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية التعامل مع ملفات الميتا، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وأكثر من ذلك.

المثال التالي يصدر عرضًا تقديميًا إلى PDF 1.5 مع ضبط جودة JPEG إلى 90، ودقة الصورة إلى 300 DPI، وحفظ ملفات الميتا كـ PNG، وضغط نص Flate.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **الحفاظ على ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر عمل Excel مضمّن، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى مشاهدة الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) مع `true` للحفاظ على ملفات OLE المضمنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة المعاينة أو الأيقونة لكائن OLE على صفحة PDF، لكن ملفه المضمّن لا يُدرج كمرفق. ضبط الخيار على `true` يضيف بيانات الملف كمرفق. تظل المعاينة تمثيلًا بصريًا؛ أما المرفق فيتيح للمستلمين فتح أو حفظ الملف المضمّن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية داخل صفحة PDF.

المثال التالي يحمل عرضًا تقديميًا يحتوي بالفعل على دفتر عمل Excel مضمّن ويصدّره إلى PDF مع إرفاق دفتر العمل.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

للتحقق من النتيجة:

1. افتح ملف PDF المُصدّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد دفتر العمل المضمّن.
3. احفظ المرفق وافتحه في Excel لتفحص بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يمنع الملفات المضمنة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى بما فيها دفاتر Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال الإعداد الافتراضي للامتثال إلى PDF ولا يوضح تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) من الصنف [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا تقديميًا إلى PDF مع تضمين أي شرائح مخفية.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **تحويل PowerPoint إلى PDF محمي بكلمة مرور**

المثال التالي يصدر عرضًا تقديميًا إلى PDF يتطلب كلمة المرور `password` لفتحه. تسمح أذونات الوصول بالطباعة، بما فيها الطباعة عالية الجودة.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **اكتشاف استبدالات الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) ضمن الصنف [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتتيح لك اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا تقديميًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. تُطبع التحذيرات فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
لمزيد من المعلومات حول استبدال الخطوط، راجع مقال [Font Substitution](/slides/ar/php-java/font-substitution/).
{{% /alert %}} 

## **تحويل شرائح مختارة من PowerPoint إلى PDF**

المثال التالي يصدر الشرائح 1 و 3 من عرض تقديمي إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **تحويل PowerPoint إلى PDF مع حجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض تقديمي إلى عرض تقديمي جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يتم تعديل محتوى الشريحة لتناسب الحجم ويصدر الشريحة الواحدة إلى PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // إزالة الشريحة الفارغة التي تم إنشاء العرض التقديمي الجديد بها.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

المثال التالي يصدر عرضًا تقديميًا إلى PDF، حيث يتم وضع ملاحظات المتحدث أسفل كل شريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **معايير الوصول والامتثال لملفات PDF**

يتيح Aspose.Slides لك اتباع إجراء تحويل يتوافق مع [إرشادات إمكانية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يعرض هذا الشيفرة عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير الامتثال المختلفة:

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

{{% alert color="info" title="Note" %}}
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء التحويلات التالية: [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). كما تُدعم عمليات تحويل PDF إلى صيغ متخصصة—[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—أيضًا.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt، المخططات، والصيغ ككائن واحد. لا يتم حفظ العناصر الفردية للمسار كمحتوى منفصل وقد تُصنَّف كعناصر صناعية؛ النص البديل يُقدَّم فقط للكائن بأكمله.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**  
نعم، يدعم Aspose.Slides تحويل دفعة من ملفات PPT أو PPTX إلى PDF. يمكنك تكرار الملفات وتطبيق عملية التحويل برمجياً.

**هل يمكن حماية PDF الناتج بكلمة مرور؟**  
نعم. استخدم الصنف [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكن تضمين الشرائح المخفية في PDF؟**  
استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) مع `true` في الصنف [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يحتفظ Aspose.Slides بجودة الصورة العالية في PDF؟**  
نعم، يمكنك التحكم في جودة الصورة باستخدام أساليب مثل [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) و[setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) في الصنف [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**  
نعم، يتيح Aspose.Slides لك تصدير PDFs تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/)، بما فيها PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides لـ PHP عبر Java](/slides/ar/php-java/)
- [مرجع API لـ Aspose.Slides لـ PHP عبر Java](https://reference.aspose.com/slides/php-java/)
- [محولات مجانية على الإنترنت من Aspose](https://products.aspose.app/slides/conversion)