---
title: تحويل PPT و PPTX إلى PDF في PHP [يتضمن ميزات متقدمة]
linktitle: PowerPoint إلى PDF
type: docs
weight: 40
url: /ar/php-java/convert-powerpoint-to-pdf/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- PowerPoint إلى PDF
- العرض التقديمي إلى PDF
- PPT إلى PDF
- تحويل PPT إلى PDF
- PPTX إلى PDF
- تحويل PPTX إلى PDF
- حفظ PowerPoint كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "تحويل ملفات PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة وقابلة للبحث في PHP باستخدام Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

يوفر تحويل عروض PowerPoint (PPT، PPTX، ODP، إلخ) إلى صيغة PDF باستخدام PHP عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق العرض التقديمي. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وإدراج الشرائح المخفية، وحماية ملفات PDF بكلمة مرور، واكتشاف استبدالات الخطوط، واختيار شرائح معينة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويلات PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، قم بتمرير اسم الملف كمعامل إلى فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [حفظ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). فئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) تعرض طريقة [حفظ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل العرض التقديمي إلى PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for PHP via Java يدرج معلومات API ورقم الإصدار في المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، تقوم Aspose.Slides بملء حقل Application بـ "*Aspose.Slides*" وحقل PDF Producer بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنه لا يمكنك إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.

{{% /alert %}}

تسمح لك Aspose.Slides بـ:

* تحويل العروض بالكامل إلى PDF
* تحويل شرائح معينة من العرض إلى PDF

تُصدّر Aspose.Slides العروض إلى PDF، مع ضمان تطابق ملفات PDF الناتجة مع العروض الأصلية بأكبر قدر ممكن. يتم عرض العناصر والسمات بدقة خلال التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرات
* الروابط التشعبية
* رؤوس وتذييلات الصفحات
* النقاط التعداد
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، تحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية عند أقصى مستويات الجودة.

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

تُقدم Aspose أداة تحويل مجانية على الإنترنت تُدعى [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) تُظهر عملية تحويل العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذا المحول لرؤية التنفيذ الفعلي للإجراءات الموضحة هنا.

{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع خيارات**

توفر Aspose.Slides خيارات مخصصة—خصائص ضمن فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—تتيح لك تخصيص ملف PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية سير عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات تحويل مخصصة، يمكنك تحديد إعداد الجودة المفضل للصور النقطية، وتحديد طريقة معالجة ملفات الميتا، وتعيين مستوى ضغط النص، وتكوين DPI للصور، وأكثر.

المثال التالي يصدر عرضًا تقديميًا إلى PDF 1.5 بجودة JPEG تبلغ 90، ودقة الصورة 300 DPI، وحفظ ملفات الميتا بصيغة PNG، وضغط نص Flate.

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

### **الحفاظ على ملفات OLE المدمجة كمرفقات PDF**

إذا كان العرض يحتوي على مصنف Excel مدمج، قد ترغب في تمكين مستلمي PDF من الوصول إلى بيانات المصنف بالإضافة إلى عرض الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) مع `true` للحفاظ على ملفات OLE المدمجة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة معاينة كائن OLE أو أيقونته على صفحة PDF، لكن ملفه المدمج غير مضمن كمرفق. ضبط الخيار على `true` يضيف بيانات الملف كمرفق. تظل المعاينة تمثيلًا بصريًا؛ المرفق يتيح للمستلمين فتح الملف المدمج أو حفظه منفصلًا. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

المثال التالي يحمل عرضًا تقديميًا يحتوي بالفعل على مصنف Excel مدمج ويصدّره إلى PDF مع إرفاق المصنف.

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

1. افتح ملف PDF المصدر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **المرفقات** في العارض وحدد المصنف المدمج.
3. احفظ المرفق وافتحه في Excel لفحص البيانات، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}

تفرض معايير PDF/A قيودًا على المرفقات: PDF/A-1 يحظر الملفات المدمجة، PDF/A-2 يسمح فقط بمرفقات PDF/A، وPDF/A-3 يسمح بأنواع ملفات أخرى بما فيها مصنفات Excel. هذه متطلبات المعايير وليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال الافتراضي ولا يُظهر تصدير PDF/A.

{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لإدراج الشرائح المخفية كصفحات في PDF الناتج.

المثال التالي يصدر عرضًا تقديميًا إلى PDF متضمنًا أي شرائح مخفية.

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

المثال التالي يُصدر عرضًا تقديميًا إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما فيها الطباعة عالية الجودة.

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

توفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) تمكنك من اكتشاف استبدالات الخطوط أثناء عملية تحويل العرض إلى PDF.

المثال التالي يصدر عرضًا تقديميًا إلى PDF ويطبع تحذيرات استبدال الخطوط إلى وحدة التحكم. يُطبع التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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

للمزيد من المعلومات حول استبدال الخطوط، راجع مقال [استبدال الخطوط](/slides/ar/php-java/font-substitution/).

{{% /alert %}} 

### **معالجة الخطوط دون نوع خط غامق مخصص**

يمكن للعرض تطبيق تنسيق غامق على النص حتى عندما لا يتوفر للخط نوع غامق مخصص. يظل النص يبدو غامقًا من خلال "الغامق الاصطناعي"، الذي يجعل الحروف العادية أكثر سمكًا. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرب استدعاء [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) مع `true`. هذا الخيار يرسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسن مظهره لبعض الخطوط. القيمة الافتراضية هي `false`.

العرض التجريبي يحتوي على صندوقي نص: أحدهما بنص عادي والآخر بنص غامق بنفس الخط الذي لا يتوفر له نوع غامق مخصص. المثال التالي يحمل العرض، ويفعّل تحويل أنماط الخط غير المدعومة إلى نقطية، ويصدّره إلى PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

المعاينات التالية تُظهر النتيجة مع تعطيل الخيار ومع تفعيل الخيار. في هذا المثال، يحتوي النص الغامق على خطوط أثقل عندما يكون الخيار معطلًا. مع تفعيل الخيار، تصبح خطوطه أخف؛ النص العادي يبقى دون تغيير. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطل (`false`، الافتراضي) | الخيار مفعّل (`true`) |
|---|---|
| ![PDF مع تعطيل تحويل نمط الخط غير المدعوم إلى نقطية](unsupported-bold-disabled.png) | ![PDF مع تمكين تحويل نمط الخط غير المدعوم إلى نقطية](unsupported-bold-enabled.png) |

في هذا المثال، يؤدي تفعيل الخيار إلى تحويل النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حدوده أكثر نعومة عند تكبير 800٪. يبقى النص العادي قابلاً للبحث. مع تعطيل الخيار، يبقى كلا السلسلتين نصًا.

هذا الخيار يحول النص المنسق كغامق عندما لا يتوفر للخط نوع غامق مخصص. بدلاً من ذلك، تقوم [استبدال الخطوط](/slides/ar/php-java/font-substitution/) باختيار خط آخر عندما يكون الأصلي غير متاح.

## **تحويل شرائح محددة من PowerPoint إلى PDF**

المثال التالي يصدر الشريحة 1 و3 من عرض تقديمي إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من الواحد، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

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

## **تحويل PowerPoint إلى PDF بحجم شريحة مخصص**

المثال التالي ينسخ الشريحة الأولى من عرض تقديمي إلى عرض تقديمي جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يقوم بتكبير محتوى الشريحة ليناسب الحجم ويصدّر الشريحة الوحيدة إلى PDF.

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

    // إزالة الشريحة الفارغة التي تم إنشاء العرض الجديد معها.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **تحويل PowerPoint إلى PDF في وضع ملاحظات الشريحة**

المثال التالي يصدر عرضًا تقديميًا إلى PDF، حيث يتم وضع ملاحظات المتحدث أسفل كل شريحة. استخدم عرضًا يتضمن ملاحظات المتحدث لرؤية النتيجة.

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

## **إمكانية الوصول ومعايير الامتثال للـ PDF**

تسمح لك Aspose.Slides باستخدام إجراء تحويل يتوافق مع [إرشادات إمكانية الوصول لمحتوى الويب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير مستند PowerPoint إلى PDF باستخدام أي من معايير الامتثال التالية: **PDF/A1a**، **PDF/A1b**، و**PDF/UA**.

هذا الكود يوضح عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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

تدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى تنسيقات ملفات شائعة. يمكنك تنفيذ التحويلات التالية: [PDF إلى HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)، [PDF إلى صورة](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)، [PDF إلى JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)، و[PDF إلى PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). تدعم أيضًا عمليات تحويل PDF إلى تنسيقات متخصصة—[PDF إلى SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)، [PDF إلى TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)، و[PDF إلى XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—.

{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، تتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt والرسوم البيانية والصيغ ككائن واحد. لا تُحافظ عناصر المسار الفردية كمحتوى منفصل وقد يُصنَّف كـ "ملحقات"؛ يتم توفير النص البديل فقط للكائن بالكامل.

## **الأسئلة المتكررة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعة واحدة؟**

نعم، يدعم Aspose.Slides التحويل المجمع لملفات PPT أو PPTX متعددة إلى PDF. يمكنك تكرار ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المُحوّل بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتعريف أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) مع `true` في فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة الصور العالية في PDF؟**

نعم، يمكنك التحكم في جودة الصورة باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) و[setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) في فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، تتيح لك Aspose.Slides تصدير PDFs تتوافق مع [معايير مختلفة](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات إمكانية الوصول والأرشفة.

## **موارد إضافية**

- [توثيق Aspose.Slides for PHP via Java](/slides/ar/php-java/)
- [مرجع API لـ Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/php-java/)
- [محولات Aspose المجانية على الإنترنت](https://products.aspose.app/slides/conversion)