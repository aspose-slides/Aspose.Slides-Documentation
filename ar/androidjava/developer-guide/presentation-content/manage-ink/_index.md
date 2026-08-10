---
title: إدارة كائنات الحبر في العروض التقديمية على Android
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/androidjava/manage-ink/
keywords:
- حبر
- كائن حبر
- أثر الحبر
- إدارة الحبر
- رسم الحبر
- رسم
- تصدير الحبر
- عرض الحبر
- إخفاء الحبر
- IInkOptions
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint، تعديل الآثار وخصائص الفرشاة، والتحكم في مظهر الحبر أثناء تصدير PDF وHTML وSVG وTIFF والصور باستخدام Aspose.Slides لنظام Android."
---
## **المقدمة**

يقدم PowerPoint ميزة الحبر التي تسمح لك برسم خطوط حرة الشكل. يمكن استخدام الحبر لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة في الشريحة.

توفر Aspose.Slides الأنواع اللازمة للعمل مع كائنات الحبر. على سبيل المثال، تمثل الواجهة [IInk](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iink/) كائن الحبر على الشريحة.

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات على شريحة PowerPoint بواسطة كائنات الشكل. في أبسط صوره، الشكل هو حاوية تحدد مساحة الكائن نفسه (إطارها) بالإضافة إلى خصائص مثل حجم الحاوية والشكل والخلفية. لمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/ar/androidjava/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة طريقتي [IShape.getWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getWidth--) و[IShape.getHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getHeight--) القياسيتين:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار الحبر**

آثار الحبر هي العنصر الأساسي المستخدم لتسجيل مسار القلم بينما يكتب المستخدم حبرًا رقميًا. تخزن الآثار سلسلة من النقاط المتصلة.

أبسط أشكال الترميز تحدد إحداثيات X وY لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، ينتج عنها صورة كهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

تُستخدم الفرشاة لرسم الخطوط التي تربط نقاط أثر الحبر. للفرشاة لونها وحجمها الخاصين، يُمثَّلان بالطرقتين [IInkBrush.getColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkbrush/#getColor--) و[IInkBrush.getSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkbrush/#getSize--) .

### **تعيين لون فرشاة الحبر**

هذا الكود Java يوضح كيفية تعيين لون فرشاة الحبر:

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **تعيين حجم فرشاة الحبر**

هذا الكود Java يوضح كيفية تعيين حجم فرشاة الحبر:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

عمومًا، لا تتطابق عرض وارتفاع الفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (القسم المقابل يكون مظللًا). عندما يتطابق عرض الفرشاة مع ارتفاعها، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

لتوضيح ذلك، لنزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ في الاعتبار حجم الفرشاة – فهو يفترض دائمًا أن سمك الخط صفر (انظر الصورة السابقة).

لذلك، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب أخذ حجم فرشاة آثاره في الاعتبار. هنا، تم تحجيم الكائن الهدف (أثر النص المكتوب يدويًا) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية، يبقى حجم الفرشاة ثابتًا، والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يستخدم PowerPoint سلوكًا مشابهًا لكائنات النص:

![ink_powerpoint6](ink_powerpoint6.png)

## **التحكم في مظهر الحبر أثناء التصدير والعرض**

توفر Aspose.Slides الواجهة [IInkOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/) للتحكم في كيفية ظهور كائنات الحبر في الناتج المُصدّر أو المُعرض. يمكنك استخدام خصائصها لإخفاء الحبر بالكامل أو لتغيير طريقة تفسير عمليات قناع فرشاة الحبر.

تتوفر خيارات الحبر من خلال خيارات التصدير أو العرض للعديد من أنواع المخرجات:

| Output | Ink options property |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

الطرق التالية في [IInkOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/) تكشف عن نفس الإعدادين:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) يحدد ما إذا كانت كائنات الحبر تُضمّن في الناتج. القيمة الافتراضية هي `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) يحدد ما إذا كانت عملية القناع تُفسَّر كعتامة عند عرض فرشاة الحبر. القيمة الافتراضية هي `true`؛ استدعِ [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) مع `false` لاستخدام عملية ROP بدلاً من ذلك.

### **إخفاء كائنات الحبر في الناتج PDF**

بشكل افتراضي، تبقى كائنات الحبر مرئية أثناء التصدير. لإنشاء ناتج نظيف بدون ملاحظات مكتوبة يدويًا أو محتوى حبر آخر، استدعِ [IInkOptions.setHideInk](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) مع `true`.

الكود Java التالي يصدر عرضًا تقديميًا إلى PDF مع إخفاء جميع كائنات الحبر:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **إخفاء كائنات الحبر عند عرض شريحة كصورة**

لإخفاء كائنات الحبر عند عرض الشرائح كصور بت ماب، قم بتكوين [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) ومرّر خيارات العرض إلى [ISlide.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

الكود Java التالي يعرض الشريحة الأولى كصورة PNG بدون كائنات الحبر:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **التحكم في عرض قناع الحبر**

الإعداد [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) يتحكم في كيفية تفسير عمليات القناع عند عرض فرشاة الحبر. القيمة الافتراضية هي `true`، مما يستخدم العتامة. لاستخدام عملية ROP بدلاً من ذلك، استدعِ [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) مع `false`.

الكود Java التالي يصدر شريحة إلى SVG ويستخدم عرضًا قائمًا على ROP لعمليات قناع الحبر:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

يمكن تطبيق نفس الإعداد عبر [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) عند تصدير عرض تقديمي أو عرض شريحة إلى TIFF.

### **اختيار إما إخفاء أو حفظ الحبر**

عند الحاجة إلى نسخة نظيفة من عرض تقديمي معلق للتوزيع دون علامات مراجعة، استدعِ [IInkOptions.setHideInk](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) مع `true` أثناء التصدير.

اترك [IInkOptions.getHideInk](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) على قيمته الافتراضية `false` عندما تكون ملاحظات الحبر جزءًا من المحتوى المقصود، مثل تعليقات المراجعة أو الملاحظات المكتوبة يدويًا أو التحديدات أو الرسومات التي يجب أن تظل مرئية في النتيجة المصدَّرة. يتيح ذلك للتطبيقات إنشاء نواتج مراجعة ونهائية منفصلة من نفس العرض التقديمي دون تعديل كائنات الحبر الأصلية.

## **الأسئلة المتكررة**

**هل يمكنني تغيير لون أو حجم خط حبر موجود؟**

نعم. احصل على الأثر من [IInk.getTraces](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iink/#getTraces--)، ثم غيّر [IInkTrace.getBrush](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinktrace/#getBrush--). استدعِ [IInkBrush.setColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) أو [IInkBrush.setSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) لتغيير الفرشاة.

**هل يؤدي إخفاء الحبر إلى تعديل العرض التقديمي الأصلي؟**

لا. استدعاء [IInkOptions.setHideInk](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) يؤثر فقط على النتيجة المعروضة أو المصدَّرة؛ لا يزيل أو يعدل كائنات الحبر في العرض التقديمي الأصلي.

**ما هي صيغ التصدير التي تدعم خيارات الحبر؟**

يمكنك تكوين خيارات الحبر لـ PDF وHTML وSVG وTIFF وصور الشرائح bitmap من خلال خيارات التصدير أو العرض المقابلة المعروظة أعلاه.

**قراءات إضافية**

* لقراءة حول الأشكال عامةً، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/ar/androidjava/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعّالة، انظر [Shape Effective Properties](https://docs.aspose.com/slides/ar/androidjava/shape-effective-properties/#get-effective-font-height-value).
* لتفاصيل تصدير PDF، راجع [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ar/androidjava/convert-powerpoint-to-pdf/).
* لتفاصيل تصدير HTML، راجع [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ar/androidjava/convert-powerpoint-to-html/).
* لتفاصيل تصدير SVG، راجع [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ar/androidjava/render-a-slide-as-an-svg-image/).
* لتفاصيل تصدير TIFF، راجع [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ar/androidjava/convert-powerpoint-to-tiff/).
* لتفاصيل عرض الشرائح كصور، راجع [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ar/androidjava/convert-slide/).