---
title: إدارة كائنات الحبر في العروض التقديمية باستخدام JavaScript
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/nodejs-java/manage-ink/
keywords:
- حبر
- كائن الحبر
- مسار الحبر
- إدارة الحبر
- رسم الحبر
- الرسم
- تصدير الحبر
- رندرة الحبر
- إخفاء الحبر
- InkOptions
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint، تحرير المسارات وخصائص الفرشاة، والتحكم في مظهر الحبر أثناء تصدير PDF وHTML وSVG وTIFF والصور باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **المقدمة**

يوفر PowerPoint ميزة الحبر التي تسمح لك برسم خطوط حرّة. يمكن استخدام الحبر لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة في الشريحة.

توفر Aspose.Slides الأنواع اللازمة للعمل مع كائنات الحبر. على سبيل المثال، الفئة [Ink](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ink/) تمثل كائن حبر على شريحة.

## **الفروقات بين الكائنات العادية وكائنات الحبر**

يتم تمثيل الكائنات على شريحة PowerPoint عادةً بواسطة كائنات الشكل. في أبسط أشكالها، الشكل هو حاوية تحدد مساحة الكائن نفسه (إطاره) بالإضافة إلى خصائص مثل حجم الحاوية، الشكل، والخلفية. لمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/ar/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية باستخدام الطريقتين القياسيتين [Shape.getWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getWidth--) و [Shape.getHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getHeight--):

![ink_powerpoint1](ink_powerpoint1.png)

## **مسارات الحبر**

تُعتبر مسار الحبر عنصرًا أساسيًا يُستخدم لتسجيل مسار القلم عندما يكتب المستخدم حبرًا رقميًا. يخزن المسار تسلسلًا من النقاط المتصلة.

أبسط شكل للترميز يحدد إحداثيات X و Y لكل نقطة عينة. عندما يتم رسم جميع النقاط المتصلة، ينتج عنها صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

تُستخدم الفرشاة لرسم الخطوط التي تربط نقاط مسار الحبر. للفرشاة لونها وحجمها الخاص، يُمثَّلان بواسطة الطريقتين [InkBrush.getColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/inkbrush/#getColor--) و [InkBrush.getSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/inkbrush/#getSize--).

### **ضبط لون فرشاة الحبر**

يظهر هذا الشيفرة JavaScript كيفية ضبط لون فرشاة الحبر:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **ضبط حجم فرشاة الحبر**

يظهر هذا الشيفرة JavaScript كيفية ضبط حجم فرشاة الحبر:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

عمومًا، لا يتطابق عرض الفرشاة مع ارتفاعها، لذا لا يعرض PowerPoint حجم الفرشاة (يُظلّ القسم المقابل من البيانات رماديًا). عندما يتطابق عرض الفرشاة مع ارتفاعها، يعرض PowerPoint حجمها بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، لنقم بزيادة ارتفاع كائن الحبر ومراجعة الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ في الاعتبار حجم الفرش؛ فهي تفترض دائمًا أن سمك الخط هو صفر (انظر الصورة السابقة).

لذلك، لتحديد المنطقة المرئية لكائن الحبر بالكامل، يجب مراعاة حجم الفرشاة لآثاره. هنا، تم تحجيم الكائن المستهدف (مسار النص المكتوب يدويًا) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية، يبقى حجم الفرشاة ثابتًا، والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يستخدم PowerPoint سلوكًا مشابهًا لكائنات النص:

![ink_powerpoint6](ink_powerpoint6.png)

## **التحكم في مظهر الحبر أثناء التصدير والرندرة**

توفر Aspose.Slides الفئة [InkOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/inkoptions/) للتحكم في كيفية ظهور كائنات الحبر في النتيجة المصدّرة أو المُرَندَة. يمكنك استخدام خصائصها لإخفاء الحبر تمامًا أو لتغيير طريقة تفسير عمليات قناع فرشاة الحبر.

تتوفر خيارات الحبر عبر خيارات التصدير أو الرندرة لعدة أنواع من المخرجات:

| الإخراج | خاصية خيارات الحبر |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

الطرق التالية في الفئة [InkOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/inkoptions/) تعرض نفس الإعدادين:

- `[InkOptions.getHideInk]` يحدّد ما إذا كانت كائنات الحبر تُضمّن في النتيجة. القيمة الافتراضية هي `false`.
- `[InkOptions.getInterpretMaskOpAsOpacity]` يحدّد ما إذا كانت عملية القناع تُفسَّر كعتام عند رندرة فرشاة الحبر. القيمة الافتراضية هي `true`؛ استدعِ `[InkOptions.setInterpretMaskOpAsOpacity]` مع `false` لاستخدام عملية ROP بدلًا من ذلك.

### **إخفاء كائنات الحبر في مخرجات PDF**

بشكل افتراضي، تبقى كائنات الحبر مرئية أثناء التصدير. لإنشاء مخرج نظيف بدون تعليقات مكتوبة يدويًا أو أي محتوى حبر آخر، استدعِ `[InkOptions.setHideInk]` مع `true`.

المثال التالي بلغة JavaScript يصدر عرضًا تقديميًا إلى PDF مع إخفاء جميع كائنات الحبر:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **إخفاء كائنات الحبر عند رندرة شريحة كصورة**

لإخفاء كائنات الحبر عند رندرة الشرائح كصور bitmap، قم بتهيئة `[RenderingOptions.getInkOptions]` ومرّر خيارات الرندرة إلى `[Slide.getImage]`.

المثال التالي بلغة JavaScript يرند أول شريحة كصورة PNG بدون كائنات الحبر:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **التحكم في رندرة قناع الحبر**

الإعداد `[InkOptions.getInterpretMaskOpAsOpacity]` يتحكم في طريقة تفسير عمليات القناع عند رندرة فرشاة الحبر. القيمة الافتراضية هي `true`، التي تستخدم العتامة. لاستخدام عملية ROP بدلًا من ذلك، استدعِ `[InkOptions.setInterpretMaskOpAsOpacity]` مع `false`.

المثال التالي بلغة JavaScript يصدر شريحة إلى SVG ويستخدم رندرة مبنية على ROP لعمليات قناع الحبر:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

يمكن تطبيق الإعداد نفسه من خلال `[TiffOptions.getInkOptions]` عندما يتم تصدير عرض تقديمي أو رندرة شريحة إلى TIFF.

### **اختر إما إخفاء الحبر أو الحفاظ عليه**

عند الحاجة إلى نسخة نظيفة من عرض تقديمي مُعلّق للتوزيع بدون علامات مراجعة، استدعِ `[InkOptions.setHideInk]` مع `true` أثناء التصدير.

اترك `[InkOptions.getHideInk]` عند قيمته الافتراضية `false` عندما تكون تعليقات الحبر جزءًا من المحتوى المقصود، مثل تعليقات المراجعة، الملاحظات المكتوبة يدويًا، التحديدات، أو الرسومات التي يجب أن تبقى مرئية في النتيجة المصدّرة. يتيح ذلك للتطبيقات إنشاء مخرجات مراجعة ونهائية منفصلة من نفس العرض دون تعديل كائنات الحبر المصدرية.

## **الأسئلة الشائعة**

**هل يمكنني تغيير لون أو حجم ضربة حبر موجودة؟**

نعم. احصل على المسار من `[Ink.getTraces]` ثم غيّر `[InkTrace.getBrush]`. استدعِ `[InkBrush.setColor]` أو `[InkBrush.setSize]` لتغيير الفرشاة.

**هل يؤدي إخفاء الحبر إلى تعديل العرض التقديمي الأصلي؟**

لا. استدعاء `[InkOptions.setHideInk]` يؤثر فقط على النتيجة المصدّرة أو المُرَندَة؛ ولا يزيل أو يغيّر كائنات الحبر في العرض الأصلي.

**ما تنسيقات التصدير التي تدعم خيارات الحبر؟**

يمكنك تكوين خيارات الحبر للـ PDF، HTML، SVG، TIFF، وصور الشرائح bitmap من خلال خيارات التصدير أو الرندرة المناسبة المذكورة أعلاه.

**قراءة إضافية**

- لقراءة حول الأشكال بشكل عام، انظر قسم [PowerPoint Shapes](https://docs.aspose.com/slides/ar/nodejs-java/powerpoint-shapes/).
- لمزيد من المعلومات حول القيم الفعّالة، راجع [Shape Effective Properties](https://docs.aspose.com/slides/ar/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
- لتفاصيل تصدير PDF، راجع [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ar/nodejs-java/convert-powerpoint-to-pdf/).
- لتفاصيل تصدير HTML، راجع [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ar/nodejs-java/convert-powerpoint-to-html/).
- لتفاصيل تصدير SVG، راجع [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/).
- لتفاصيل تصدير TIFF، راجع [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ar/nodejs-java/convert-powerpoint-to-tiff/).
- لتفاصيل رندرة شريحة إلى صورة، راجع [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ar/nodejs-java/convert-slide/).