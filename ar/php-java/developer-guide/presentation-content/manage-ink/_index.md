---
title: إدارة كائنات الحبر في عروض PowerPoint بلغة PHP
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/php-java/manage-ink/
keywords:
- حبر
- كائن حبر
- أثر حبر
- إدارة الحبر
- رسم الحبر
- رسم
- تصدير الحبر
- تصيير الحبر
- إخفاء الحبر
- InkOptions
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint، تعديل الآثار وخصائص الفرشاة، والتحكم في مظهر الحبر أثناء تصدير PDF وHTML وSVG وTIFF والصور باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **المقدمة**

PowerPoint يوفر ميزة الحبر التي تسمح لك برسم خطوط حرة. يمكن استخدام الحبر لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة على الشريحة.

Aspose.Slides يوفر الأنواع اللازمة للعمل مع كائنات الحبر. على سبيل المثال، فئة [Ink](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ink/) تمثل كائن حبر على شريحة.

## **الفرق بين الكائنات العادية وكائنات الحبر**

الكائنات على شريحة PowerPoint تمثل عادةً بواسطة كائنات [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/). في أبسط أشكالها، الشكل هو حاوية تحدد مساحة الكائن نفسه (إطارها) إلى جانب خصائص مثل حجم الحاوية، الشكل، والخلفية. للمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/ar/php-java/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة الطريقتين القياسيتين [Shape.getWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getWidth) و[Shape.getHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار الحبر**

آثار الحبر هي عنصر أساسي يستخدم لتسجيل مسار القلم عندما يكتب المستخدم حبرًا رقميًا. تخزن الآثار سلسلة من النقاط المتصلة.

أبسط أشكال الترميز تحدد إحداثيات X وY لكل نقطة عينة. عندما يتم رسم جميع النقاط المتصلة، ينتج صورة كهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

الفرشاة تُستخدم لرسم الخطوط التي تربط نقاط أثر الحبر. للفرشاة لونها وحجمها الخاص، ويُمثل ذلك الطريقتين [InkBrush.getColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkbrush/#getColor) و[InkBrush.getSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkbrush/#getSize).

### **ضبط لون فرشاة الحبر**

هذا الشيفرة PHP تُظهر كيفية ضبط لون فرشاة الحبر:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **ضبط حجم فرشاة الحبر**

هذا الشيفرة PHP تُظهر كيفية ضبط حجم فرشاة الحبر:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

عامةً، عرض وارتفاع الفرشاة لا يتطابقان، لذا لا يعرض PowerPoint حجم الفرشاة (القسم المقابل من البيانات يكون مُظللاً). عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، لنزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

الإطار (الحاوية) لا يُراعي حجم الفرشاة—دائمًا يفترض أن سمك الخط صفر (انظر الصورة السابقة).

وبالتالي، لتحديد المنطقة المرئية لكائن الحبر بالكامل، يجب أخذ حجم فرشاة آثاره في الاعتبار. هنا، تم تعديل الكائن المستهدف (أثر النص المكتوب بخط اليد) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية، يبقى حجم الفرشاة ثابتًا، والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint يستخدم سلوكًا مشابهًا لكائنات النص:

![ink_powerpoint6](ink_powerpoint6.png)

## **التحكم في مظهر الحبر أثناء التصدير والتصيير**

Aspose.Slides يوفر فئة [InkOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/) للتحكم في كيفية ظهور كائنات الحبر في المخرجات المُصدَّرة أو المُصيَّرة. يمكنك استخدام خصائصها لإخفاء الحبر بالكامل أو لتغيير طريقة تفسير عمليات قناع فرشاة الحبر.

خيارات الحبر متاحة من خلال خيارات التصدير أو التصيير لعدة أنواع من المخرجات:

| الإخراج | خاصية خيارات الحبر |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| صورة الشريحة | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/renderingoptions/#getInkOptions) |

الطرق التالية في فئة [InkOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/) تكشف عن نفس الإعدادين:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/#getHideInk) يحدد ما إذا كانت كائنات الحبر تُدرج في المخرج. القيمة الافتراضية هي `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) يحدد ما إذا كانت عملية القناع تُفسَّر كعتامة عند تصيير فرشاة الحبر. القيمة الافتراضية هي `true`؛ استدعِ [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) مع `false` لاستخدام عملية ROP بدلاً من ذلك.

### **إخفاء كائنات الحبر في ناتج PDF**

افتراضيًا، تظل كائنات الحبر مرئية أثناء التصدير. لإنشاء مخرج نظيف دون تعليقات يدوية أو محتوى حبر آخر، استدعِ [InkOptions.setHideInk](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/#setHideInk) مع `true`.

مثال PHP التالي يصدر عرضًا تقديميًا إلى PDF مع إخفاء جميع كائنات الحبر:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **إخفاء كائنات الحبر عند تصيير شريحة كصورة**

لإخفاء كائنات الحبر عند تصيير الشرائح كصور نقطية، قم بتكوين [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/renderingoptions/#getInkOptions) ومرّر خيارات التصيير إلى [Slide.getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getImage).

مثال PHP التالي يصدر الشريحة الأولى كصورة PNG دون كائنات حبر:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **التحكم في تصيير قناع الحبر**

الإعداد [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) يتحكم في كيفية تفسير عمليات القناع عند تصيير فرشات الحبر. القيمة الافتراضية هي `true`، والتي تستخدم العتامة. لاستخدام عملية ROP بدلاً من ذلك، استدعِ [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) مع `false`.

مثال PHP التالي يصدر شريحة إلى SVG ويستخدم تصييرًا قائمًا على ROP لعمليات قناع الحبر:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

نفس الإعداد يمكن تطبيقه عبر [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/#getInkOptions) عند تصدير عرض تقديمي أو تصيير شريحة إلى TIFF.

### **اختيار ما إذا كان يجب إخفاء أو حفظ الحبر**

عندما تحتاج إلى نسخة نظيفة من عرض تقديمي مُعلق للتوزيع بدون علامات مراجعة، استدعِ [InkOptions.setHideInk](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/#setHideInk) مع `true` أثناء التصدير.

اترك [InkOptions.getHideInk](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/#getHideInk) على قيمته الافتراضية `false` عندما تكون تعليقات الحبر جزءًا من المحتوى المقصود، مثل تعليقات المراجعة، الملاحظات المكتوبة يدويًا، التحديدات، أو الرسومات التي يجب أن تبقى مرئية في النتيجة المُصدَّرة. يتيح ذلك للتطبيقات إنشاء مخرجات مراجعة ونهائية منفصلة من نفس العرض التقديمي دون تعديل كائنات الحبر الأصلية.

## **الأسئلة الشائعة**

**هل يمكنني تغيير لون أو حجم خط الحبر الموجود؟**

نعم. احصل على الأثر عبر [Ink.getTraces](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ink/#getTraces)، ثم غيّر [InkTrace.getBrush](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inktrace/#getBrush). استدعِ [InkBrush.setColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkbrush/#setColor) أو [InkBrush.setSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkbrush/#setSize) لتغيير الفرشاة.

**هل إخفاء الحبر يغير عرض الشرائح الأصلي؟**

لا. استدعاء [InkOptions.setHideInk](https://reference.aspose.com/slides/ar/php-java/aspose.slides/inkoptions/#setHideInk) يؤثر فقط على النتيجة المُصيَّرة أو المُصدَّرة؛ ولا يزيل أو يغيّر كائنات الحبر في العرض الأصلي.

**ما هي صيغ التصدير التي تدعم خيارات الحبر؟**

يمكنك تكوين خيارات الحبر لـ PDF، HTML، SVG، TIFF، وصور الشرائح النقطية من خلال خيارات التصدير أو التصيير المقابلة المذكورة أعلاه.

**مزيد من القراءة**

* لقراءة عن الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/ar/php-java/powerpoint-shapes/).
* للمزيد من المعلومات حول القيم الفعالة، راجع [Shape Effective Properties](https://docs.aspose.com/slides/ar/php-java/shape-effective-properties/#get-effective-font-height-value).
* لتفاصيل تصدير PDF، راجع [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ar/php-java/convert-powerpoint-to-pdf/).
* لتفاصيل تصدير HTML، راجع [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ar/php-java/convert-powerpoint-to-html/).
* لتفاصيل تصدير SVG، راجع [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ar/php-java/render-a-slide-as-an-svg-image/).
* لتفاصيل تصدير TIFF، راجع [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ar/php-java/convert-powerpoint-to-tiff/).
* لتفاصيل تصيير الشريحة إلى صورة، راجع [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ar/php-java/convert-slide/).