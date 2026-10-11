---
title: تغيير حجم صفحة الملاحظات والاتجاه في PHP
linktitle: حجم صفحة الملاحظات
type: docs
weight: 10
url: /ar/php-java/notes-size/
keywords:
- حجم صفحة الملاحظات
- اتجاه الملاحظات
- ملاحظات أفقية
- ملاحظات رأسية
- حجم النشرة
- PowerPoint
- عرض
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "قراءة وتغيير أبعاد صفحة الملاحظات في Aspose.Slides للـ PHP عبر Java، تغيير الاتجاه، التحقق من الأحجام المحفوظة، وتصدير الملاحظات أو النشرات إلى PDF وصور."
---
## **نظرة عامة**

استخدم [Presentation::getNotesSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getnotessize/) للوصول إلى إعدادات صفحة ملاحظات العرض. تُعيد كائنًا من نوع [NotesSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notessize/) حيث تُعيّن طريقة [setSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notessize/setsize/) أبعاد الصفحة. على الرغم من أنه لا يمكن استبدال كائن الإعدادات نفسه، إلا أنه يمكنك تعيين أبعاد جديدة عبر هذه الطريقة.

يتم تحديد العرض والارتفاع بوحدة **النقاط**، بحيث يوجد 72 نقطة لكل بوصة. على سبيل المثال، 900 × 600 نقطة يساوي 12.5 × 8⅓ بوصة. تُطبق هذه الإعدادات على العرض ككل، وليس على ملاحظات شريحة فردية.

| الإعداد | الغرض |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getnotessize/) | يتحكم في أبعاد صفحة الملاحظات وأبعاد الصفحة المستخدمة لتصدير النشرات. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getslidesize/) | يتحكم في أبعاد شرائح العرض العادية عبر [SlideSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesize/). |

تغيير أي من الإعدادين لا يغيّر الآخر تلقائيًا. تغيير اتجاه صفحة الملاحظات لا يدور أيضًا الشرائح العادية. راجع [Slide Size](/slides/ar/php-java/slide-size/) لتغيير حجم الشرائح العادية.

تستخدم الأمثلة أدناه ملفًا موجودًا `sample.pptx`. بالنسبة لأمثلة التصدير، استخدم عرضًا يحتوي على شريحة واحدة على الأقل مع ملاحظات المتحدث. يمكن تشغيل كل مثال بشكل مستقل بعد تحميل جسر PHP/Java ومغلف Aspose.Slides PHP. يتم تحويل القيم الرقمية التي تعيدها Java إلى قيم PHP باستخدام `java_values` قبل المقارنة أو الحساب.

## **قراءة حجم صفحة الملاحظات واتجاهها**

اقرأ العرض والارتفاع وقارنهما لتحديد الاتجاه: الصفحة الأوسع هي أفقية، والصفحة الأطول هي رأسية، والأبعاد المتساوية تصف صفحة مربعة. يطبع هذا المثال الأبعاد الفعلية بالنقاط، دون افتراض حجم ورق قياسي.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **تحويل إلى الوضع الأفقي دون تغيير حجم الورق**

لتغيير الاتجاه فقط، قم بتبديل العرض والارتفاع الحاليين. يحافظ هذا على أطوال الجانبين، بما في ذلك تلك الخاصة بحجم ورق مخصص. الشرط أدناه يمنع تحويل صفحة أفقية بالفعل إلى وضع رأسي ويترك الصفحة المربعة دون تغيير.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

للحصول على وضع رأسي، استخدم نفس التعيين عندما يكون `java_values($size->getWidth()) > java_values($size->getHeight())`. لا تستبدل أبعاد A4 أو Letter ما لم ترغب أيضًا في تغيير حجم الورق.

## **تعيين والتحقق من حجم صفحة ملاحظات مخصص**

قم بتعيين كلا البعدين معًا، ثم استخدم [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/save/) لكتابة العرض. يحدد هذا المثال صفحة أفقية بحجم 900 × 600 نقطة، يحفظها كملف PPTX، ثم يفتح الملف المحفوظ مرة أخرى للتحقق من القيم المخزنة. يسمح المقارنة بفرق 0.01 نقطة للقيم ذات الفاصلة العائمة؛ وهذا ليس ضمانًا للدقة لجميع تنسيقات الملفات.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

النتيجة المتوقعة هي `900 x 600 points` و `Size preserved: true`. فحص عرض تم فتحه حديثًا يتحقق من الملف المحفوظ، وليس فقط الإعدادات الموجودة في الذاكرة.

## **تصدير الملاحظات والنشرات**

تحدد أبعاد الصفحة المنطقة المتاحة لتصميمات الملاحظات أو النشرات. هذه الأبعاد لا تُفعّل تلك التصميمات بوحدها: يجب أيضًا تكوين خيارات التصدير. يستمر تصدير الشرائح العادية في استخدام أبعاد الشريحة.

### **تصدير الملاحظات إلى PDF و PNG**

قم بتعيين [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notescommentslayoutingoptions/) إلى [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) لتضمين الملاحظات في ملف PDF. يطبق هذا المثال أيضًا تحويل الشريحة الأولى مع الملاحظات إلى PNG باستخدام [Slide::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getImage) و [RenderingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/renderingoptions/).

وضع [BottomTruncated](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notespositions/) يحتفظ بالملاحظات في صفحة واحدة؛ يمكن قطع الملاحظات التي لا تتناسب. يستخدم ملف PDF صفحات بحجم 900 × 600 نقطة. عند مقياس الصورة 1 × 1 المستخدم أدناه، يكون PNG بحجم 900 × 600 بكسل. تصف النقاط هندسة الصفحة؛ وتصف البكسلات الناتج النقطي، الذي تعتمد أبعاده أيضًا على مقياس التصيير.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

لتصدير PDF مع ملاحظات طويلة، يسمح [BottomFull](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notespositions/) بصفحات إضافية حسب الحاجة. لا تستخدم هذا الوضع مع استدعاء الصورة لشريحة واحدة أعلاه، الذي لا يدعم ذلك. بعد تعديل الحجم، افحص الناتج للتحقق من تقليم الملاحظات وموقع كائنات notes‑master الحالية؛ لا ينبغي اعتبار تغيير أبعاد الصفحة وحده ضمانًا لتناسب جميع المحتويات. راجع [Convert PowerPoint to PDF with Notes](/slides/ar/php-java/convert-powerpoint-to-pdf-with-notes/) لمزيد من المعلومات حول تصدير الملاحظات.

### **تصدير النشرات إلى PDF**

استخدم [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/handoutlayoutingoptions/) للحصول على عدة مصغرات شرائح في صفحة واحدة. يحدد المثال التالي صفحة بحجم 900 × 600 نقطة ويستخدم [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/ar/php-java/aspose.slides/handouttype/) لترتيب ما يصل إلى أربع شرائح في كل صفحة. يحدد الإعداد الأفقي ترتيب الشرائح؛ ويستمد اتجاه الصفحة من عرضها وارتفاعها.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

تغيير حجم الصفحة يغيّر المنطقة المتاحة لشبكة النشرات دون تغيير أبعاد الشرائح الأصلية. للحصول على صور النشرات، استخدم [Presentation::getImages](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getimages/) مع تخطيط النشرة، بدلاً من طريقة صورة الشريحة الفردية. في Aspose.Slides، يستخدم تصيير النشرة على مستوى العرض أبعاد صفحة الملاحظات، بينما لا ينتج استدعاء صورة الشريحة الفردية صفحة النشرة. راجع [Handout Mode](/slides/ar/php-java/convert-powerpoint-in-handout-mode/) للحصول على خيارات التخطيط.

## **حجم الصفحة في العارضات، التصدير، والطباعة**

احتفظ بأحجام العرض المخزنة، وحجم الصفحة المُصدَّر، وحجم الورق المطبوع متميزة:

- **عارضات العرض:** يمكن للعارض عرض أو طباعة الملاحظات باستخدام قواعد التخطيط الخاصة به. إذا حفظ تطبيق آخر الملف، أعد فتحه وتحقق من الأبعاد مرة أخرى؛ قد تقوم عملية تحويل الصيغ في ذلك التطبيق بتطبيعها.
- **تنسيقات التصدير:** تستخدم أمثلة PDF للملاحظات والنشرات أعلاه أبعاد الصفحة التي تم تكوينها. تستخدم الصور النقطية أبعاد بكسل صحيحة ومقياس تصيير، لذا قد تُقرب القيم النقطية العشرية في مخرجات الصورة. لا يطبق تصدير الشرائح العادية حجم صفحة الملاحظات.
- **مشغلات الطابعة:** يمكن لاختيار الورق، والدوران التلقائي، وإعدادات ملاءمة الصفحة أن تغير المخرجات الفعلية دون تعديل الأبعاد المخزنة في العرض أو PDF. للحصول على حجم ورق معين، طابق إعدادات الطابعة وافحص معاينة الطباعة.

## **الأسئلة الشائعة**

**هل يمكنني ضبط حجم الملاحظات لشريحة واحدة فقط؟**

حجم صفحة الملاحظات هو إعداد على مستوى العرض. يمكن أن تحتوي الشرائح الفردية على محتوى ملاحظات مختلف، لكن هذه الخاصية لا توفر حجم صفحة منفصل لكل شريحة.

**لماذا لم يؤدي تغيير اتجاه الملاحظات إلى تغيير الشرائح الخاصة بي؟**

صفحات الملاحظات والشرائح العادية لها أبعاد مستقلة. استخدم إعدادات حجم الشريحة العادية عندما تريد تغيير حجم الشرائح نفسها.

**لماذا يكون للنتيجة المحفوظة أو المطبوعة حجم مختلف؟**

أولاً أعد فتح العرض المحفوظ وقارن أبعاد ملاحظاته. إذا تغيرت، تحقق مما إذا كان حفظ الملف أو تحويله في تطبيق آخر قد غير إعدادات الصفحة. إذا لم يحدث ذلك، فافحص تخطيط التصدير، مقياس الصورة، إعدادات العارض، واختيار ورق الطابعة.