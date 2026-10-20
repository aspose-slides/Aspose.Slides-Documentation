---
title: تحويل PPT و PPTX إلى PDF في PHP [الميزات المتقدمة مشمولة]
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
- مرفق
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "تحويل عروض PowerPoint PPT/PPTX إلى ملفات PDF عالية الجودة ويمكن البحث فيها باستخدام PHP و Aspose.Slides، مع أمثلة كود سريعة وخيارات تحويل متقدمة."
---
## **نظرة عامة**

تحويل عروض PowerPoint (PPT و PPTX و ODP وما إلى ذلك) إلى تنسيق PDF في PHP يوفر عدة مزايا، بما في ذلك التوافق عبر الأجهزة المختلفة والحفاظ على تخطيط وتنسيق عرضك. يوضح هذا الدليل كيفية تحويل العروض إلى مستندات PDF، واستخدام خيارات مختلفة للتحكم في جودة الصور، وتضمين الشرائح المخفية، وحprotect ملفات PDF بكلمة مرور، واكتشاف استبدال الخطوط، واختيار شرائح محددة للتحويل، وتطبيق معايير الامتثال على المستندات الناتجة.

## **تحويل PowerPoint إلى PDF**

باستخدام Aspose.Slides، يمكنك تحويل العروض بالتنسيقات التالية إلى PDF:

* **PPT**
* **PPTX**
* **ODP**

لتحويل عرض تقديمي إلى PDF، مرّر اسم الملف كمعامل إلى الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ثم احفظ العرض كملف PDF باستخدام طريقة [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). تُظهر فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) طريقة [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) التي تُستخدم عادةً لتحويل عرض تقديمي إلى PDF.

{{% alert color="info" title="Note" %}}
يضيف Aspose.Slides for PHP via Java معلومات واجهة برمجة التطبيقات ورقم الإصدار إلى المستندات الناتجة. على سبيل المثال، عند تحويل عرض تقديمي إلى PDF، يقوم Aspose.Slides بملء حقل التطبيق بـ "*Aspose.Slides*" وحقل منتج PDF بقيمة بصيغة "*Aspose.Slides v XX.XX*". **ملاحظة** أنك لا تستطيع إرشاد Aspose.Slides لتغيير أو إزالة هذه المعلومات من المستندات الناتجة.
{{% /alert %}}

يسمح لك Aspose.Slides بالتحويل:

* العروض الكاملة إلى PDF
* شرائح محددة من عرض تقديمي إلى PDF

يصدّر Aspose.Slides العروض إلى PDF، مما يضمن أن ملفات PDF الناتجة تتطابق تقريبًا مع العروض الأصلية. يتم عرض العناصر والسمات بدقة أثناء التحويل، بما في ذلك:

* الصور
* صناديق النص والأشكال
* تنسيق النص
* تنسيق الفقرة
* الارتباطات التشعبية
* الترويسات والتذييلات
* القوائم النقطية
* الجداول

## **تحويل PowerPoint إلى PDF**

تستخدم عملية التحويل القياسية من PowerPoint إلى PDF الخيارات الافتراضية. في هذه الحالة، يحاول Aspose.Slides تحويل العرض المقدم إلى PDF باستخدام إعدادات مثالية بأعلى مستويات الجودة.

يعرض المثال التالي كيفية تحميل عرض وت保存 جميع الشرائح المرئية إلى PDF باستخدام إعدادات التصدير الافتراضية.

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
توفر Aspose محولًا مجانيًا عبر الإنترنت لـ [**محول PowerPoint إلى PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) يوضح عملية التحويل من العرض إلى PDF. يمكنك تشغيل اختبار باستخدام هذا المحول لتطبيق حي للإجراء الموصوف هنا.
{{% /alert %}}

## **تحويل PowerPoint إلى PDF مع الخيارات**

يوفر Aspose.Slides خيارات مخصصة — خصائص تحت فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) — والتي تتيح لك تخصيص PDF الناتج، قفل PDF بكلمة مرور، أو تحديد كيفية تقدم عملية التحويل.

### **تحويل PowerPoint إلى PDF مع خيارات مخصصة**

باستخدام خيارات التحويل المخصصة، يمكنك تحديد إعداد الجودة المفضلة للصور النقطية، وتحديد كيفية معالجة ملفات الميتا، وتعيين مستوى ضغط للنص، وتكوين DPI للصور، وأكثر.

يعرض المثال التالي كيفية تصدير عرض إلى PDF 1.5 مع جودة JPEG مضبوطة على 90، ودقة الصورة مضبوطة على 300 DPI، وحفظ ملفات الميتا كـ PNG، وضغط نص Flate.

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

### **اختيار ضغط الصور تلقائيًا**

عندما يحتوي العرض على العديد من الصور الفوتوغرافية أو لقطات الشاشة، يمكن أن يقلل تقليل حجم PDF المصدّر من صعوبة إرساله عبر البريد الإلكتروني أو تنزيله. استدعِ [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) مع `true` لتحديد خوارزمية الضغط الأنسب لكل صورة تلقائيًا أثناء تصدير PDF.

يعرض المثال التالي كيفية تحميل عرض موجود، وتمكين اختيار ضغط الصور تلقائيًا، وحفظه كمستند PDF. تحتفظ جميع إعدادات تصدير PDF الأخرى بقيمها الافتراضية.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

تختار هذه الخيار خوارزمية ضغط لكل صورة. خفض القيمة المُمرَّرة إلى [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) يقلل بدلاً من ذلك من جودة صورة JPEG، بينما خفض القيمة المُمرَّرة إلى [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) يسمح بتمثيل الصور بدقة أقل، مما قد يقلل التفاصيل. لا يؤدي تمكين اختيار الضغط التلقائي بحد ذاته إلى خفض أي من هذين الإعدادين.

يتطلب اختيار خوارزميات ضغط الصور وقت معالجة إضافي وذاكرة. يعتمد تقليل الحجم على صور العرض وإعدادات التصدير؛ لا يُضمن تقليل ثابت لكل عرض.

### **الحفاظ على ملفات OLE المضمنة كمرفقات PDF**

إذا كان العرض يحتوي على دفتر عمل Excel مدمج، قد ترغب في أن يتمكن مستلمو PDF من الوصول إلى بيانات دفتر العمل بالإضافة إلى عرض الشرائح. استدعِ [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) مع `true` للحفاظ على ملفات OLE المضمنة كمرفقات في PDF الناتج.

القيمة الافتراضية هي `false`: يتم عرض صورة المعاينة أو أيقونة كائن OLE على صفحة PDF، لكن ملفه المضمن لا يُضمّن كمرفق. ضبط الخيار على `true` يضيف بيانات الملف أيضًا. تظل المعاينة تمثيلًا بصريًا؛ يسمح المرفق للمستلمين بفتح أو حفظ الملف المضمن بشكل منفصل. لا يتحول كائن OLE إلى ورقة عمل Excel تفاعلية على صفحة PDF.

يعرض المثال التالي كيفية تحميل عرض يحتوي بالفعل على دفتر عمل Excel مدمج وتصديره إلى PDF مع إرفاق دفتر العمل.

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
1. افتح ملف PDF المصدَّر في عارض يدعم المرفقات، مثل Adobe Acrobat Reader.
2. افتح لوحة **Attachments** في العارض وحدد موقع دفتر العمل المدمج.
3. احفظ المرفق وافتحه في Excel لاستعراض بياناته، أو افتحه مباشرة إذا سمح العارض بذلك. المعاينة على صفحة PDF منفصلة عن المرفق.

{{% alert color="info" title="Note" %}}
تفرض معايير PDF/A قيودًا على المرفقات: يمنع PDF/A-1 الملفات المضمنة، ويُسمح في PDF/A-2 فقط بمرفقات PDF/A، ويسمح PDF/A-3 بأنواع ملفات أخرى، بما في ذلك دفاتر عمل Excel. هذه متطلبات المعايير، ليست قيودًا خاصة بـ Aspose.Slides. يستخدم هذا المثال إعداد الامتثال الافتراضي لـ PDF ولا يوضح تصدير PDF/A.
{{% /alert %}}

### **تحويل PowerPoint إلى PDF مع الشرائح المخفية**

إذا كان العرض يحتوي على شرائح مخفية، يمكنك استخدام طريقة [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) من فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية كصفحات في PDF الناتج.

يعرض المثال التالي كيفية تصدير عرض إلى PDF، مع تضمين أي شرائح مخفية.

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

يعرض المثال التالي كيفية تصدير عرض إلى PDF يتطلب كلمة المرور `password` للفتح. تسمح أذونات الوصول بالطباعة، بما في ذلك الطباعة عالية الجودة.

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

### **اكتشاف استبدال الخطوط**

يوفر Aspose.Slides طريقة [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) ضمن فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)، مما يتيح لك اكتشاف استبدال الخطوط أثناء عملية تحويل العرض إلى PDF.

يعرض المثال التالي كيفية تصدير عرض إلى PDF وطباعة تحذيرات استبدال الخطوط إلى وحدة التحكم. يُطبع التحذير فقط عندما يتم استبدال خط غير متوفر أثناء التصدير.

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
لمزيد من المعلومات حول استبدال الخطوط، راجع مقالة [Font Substitution](/slides/ar/php-java/font-substitution/).
{{% /alert %}}

### **معالجة الخطوط التي لا تحتوي على نسخة غامقة مخصصة**

يمكن للعرض تطبيق تنسيق غامق للنص حتى إذا لم يحتوي الخط على نسخة غامقة مخصصة. لا يزال يمكن أن يظهر النص غامقًا عبر الغموض الاصطناعي، الذي يزيد سماكة الأحرف العادية. عندما يبدو هذا النص ثقيلًا جدًا أو يختلف عن المظهر المقصود في PDF، جرّب استدعاء [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) مع `true`. هذا الخيار يقوم برسم النص المتأثر كصورة نقطية أثناء تصدير PDF ويمكن أن يحسّن مظهره لبعض الخطوط. قيمته الافتراضية هي `false`.

يتضمن العرض النموذجي صندوقي نص: أحدهما بنص عادي والآخر بنص غامق مطبق على نفس الخط الذي لا يحتوي على نسخة غامقة مخصصة. يعرض المثال التالي كيفية تحميل العرض، وتمكين تحويل الأنماط الخطية غير المدعومة إلى صورة نقطية، وتصديره إلى PDF:

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

تُظهر المعاينات التالية المخرجات مع تعطيل الخيار وتمكينه. في هذا المثال، يكون النص الغامق ذو خطوط أسمك عندما يكون الخيار معطلًا. عند تمكين الخيار، تصبح خطوطه أخف؛ النص العادي يبقى كما هو. قارن النتائج قبل اختيار الإعداد لعرضك.

| الخيار معطل (`false`، الافتراضي) | الخيار مفعل (`true`) |
|---|---|
| ![PDF مع تحويل نمط الخط غير المدعوم إلى صورة نقطية معطل](unsupported-bold-disabled.png) | ![PDF مع تحويل نمط الخط غير المدعوم إلى صورة نقطية مفعل](unsupported-bold-enabled.png) |

في هذا المثال، يؤدي تمكين الخيار إلى تحويل النص الغامق فقط إلى صورة نقطية: لا يمكن تحديده أو نسخه أو البحث فيه كنص دون OCR، وتظهر حدوده أكثر نعومة عند تكبير 800٪. يظل النص العادي قابلًا للبحث. عند تعطيل الخيار، يظل كلا السلسلتين نصًا.

يقوم هذا الخيار بتحويل النص المنسق كغامق إلى صورة نقطية عندما لا يحتوي الخط على نسخة غامقة مخصصة. بدلاً من ذلك، تقوم [Font substitution](/slides/ar/php-java/font-substitution/) باختيار خط آخر عندما يكون الأصلي غير متوفر.

## **تحويل الشرائح المحددة من PowerPoint إلى PDF**

يعرض المثال التالي كيفية تصدير الشرائح 1 و 3 من عرض إلى PDF. أرقام الشرائح في هذا المصفوفة تبدأ من 1، ويجب أن يحتوي العرض المدخل على ثلاث شرائح على الأقل.

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

يعرض المثال التالي كيفية نسخ الشريحة الأولى من عرض إلى عرض جديد بحجم شريحة 612 × 792 نقطة (8.5 × 11 بوصة). يقوم بتقليل حجم محتوى الشريحة ليتناسب ويصدر الشريحة الواحدة إلى PDF.

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

    // إزالة الشريحة الفارغة التي تم إنشاء العرض الجديد بها.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **تحويل PowerPoint إلى PDF في عرض ملاحظات الشريحة**

يعرض المثال التالي كيفية تصدير عرض إلى PDF، مع وضع ملاحظات المتحدث لكل شريحة أسفل الشريحة. استخدم عرضًا يحتوي على ملاحظات المتحدث لرؤية النتيجة.

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

## **معايير الوصول والامتثال لـ PDF**

يسمح لك Aspose.Slides باستخدام إجراء تحويل يتوافق مع [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). يمكنك تصدير وثيقة PowerPoint إلى PDF باستخدام أي من معايير الامتثال هذه: **PDF/A1a**، **PDF/A1b**، و **PDF/UA**.

يوضح هذا الكود عملية تحويل PowerPoint إلى PDF تنتج ملفات PDF متعددة بناءً على معايير امتثال مختلفة:

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
يدعم Aspose.Slides عمليات تحويل PDF، مما يتيح لك تحويل ملفات PDF إلى صيغ ملفات شائعة. يمكنك إجراء التحويلات [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)، و[PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). كما يتم دعم عمليات تحويل PDF إلى صيغ متخصصة — [PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)، و[PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) —.
{{% /alert %}}

> **ملاحظة:** عند التصدير إلى PDF/UA، يتعامل Aspose.Slides مع الرسومات المعقدة مثل SmartArt، والرسوم البيانية، والصيغ ككائن واحد. لا يتم الحفاظ على عناصر المسار الفردية كمحتوى منفصل وقد يتم تعليمها كآثار؛ يتم توفير النص البديل فقط للكائن بالكامل.

## **الأسئلة الشائعة**

**هل يمكنني تحويل عدة ملفات PowerPoint إلى PDF دفعيًا؟**

نعم، يدعم Aspose.Slides التحويل الدفعي للعديد من ملفات PPT أو PPTX إلى PDF. يمكنك التكرار عبر ملفاتك وتطبيق عملية التحويل برمجيًا.

**هل يمكن حماية PDF المحول بكلمة مرور؟**

نعم. استخدم فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتعيين كلمة مرور وتحديد أذونات الوصول أثناء عملية التحويل.

**كيف يمكنني تضمين الشرائح المخفية في PDF؟**

استدعِ [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) مع `true` في فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لتضمين الشرائح المخفية في PDF الناتج.

**هل يمكن لـ Aspose.Slides الحفاظ على جودة صور عالية في PDF؟**

نعم، يمكنك التحكم في جودة الصور باستخدام طرق مثل [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) و[setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) في فئة [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) لضمان صور عالية الجودة في PDF الخاص بك.

**هل يدعم Aspose.Slides معايير الامتثال PDF/A؟**

نعم، يتيح لك Aspose.Slides تصدير ملفات PDF تتوافق مع [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/)، بما في ذلك PDF/A1a، PDF/A1b، وPDF/UA، مما يضمن أن مستنداتك تلبي متطلبات الوصول والأرشفة.

## **الموارد الإضافية**

- [توثيق Aspose.Slides for PHP via Java](/slides/ar/php-java/)
- [مرجع API لـ Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/php-java/)
- [محولات Aspose المجانية عبر الإنترنت](https://products.aspose.app/slides/conversion)