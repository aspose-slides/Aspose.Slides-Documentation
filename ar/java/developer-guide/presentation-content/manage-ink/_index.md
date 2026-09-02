---
title: إدارة كائنات الحبر في العروض التقديمية باستخدام Java
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/java/manage-ink/
keywords:
- حبر
- كائن حبر
- آثار الحبر
- إدارة الحبر
- رسم الحبر
- رسم
- تصدير الحبر
- عرض الحبر
- إخفاء الحبر
- IInkOptions
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint، تعديل الآثار وخصائص الفُرْشاة، والتحكم في مظهر الحبر أثناء تصدير PDF وHTML وSVG وTIFF والصور باستخدام Aspose.Slides للـ Java."
---
## **المقدمة**

يقدم PowerPoint ميزة الحبر التي تسمح لك برسم خطوط حرة الشكل. يمكن استخدام الحبر لتسليط الضوء على كائنات أخرى، وإظهار الروابط والعمليات، وجذب الانتباه إلى عناصر محددة على الشريحة.

توفر Aspose.Slides الأنواع اللازمة للعمل مع كائنات الحبر. على سبيل المثال، تمثل الواجهة [IInk](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iink/) كائن الحبر على الشريحة.

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما تُمثَّل الكائنات على شريحة PowerPoint بواسطة كائنات الشكل. في أبسط صورها، الشكل هو حاوية تُحدد مساحة الكائن نفسه (إطارها) إلى جانب خصائص مثل حجم الحاوية وشكلها والخلفية. لمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/ar/java/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة الطريقتين القياسيتين [IShape.getWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getWidth--) و[IShape.getHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getHeight--):

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار الحبر**

آثار الحبر هي عنصر أساسي يُستخدم لتسجيل مسار القلم أثناء كتابة الحبر الرقمي. تخزن الآثار تسلسلًا من النقاط المتصلة.

أبسط شكل للترميز يحدد إحداثيات X وY لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، ينتج عنها صورة كهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفُرْشاة للرسم**

تُستخدم الفُرْشاة لرسم الخطوط التي تربط نقاط أثر الحبر. للفُرْشاة لونها وحجمها الخاصين، يُمثَّلان عبر طريقتي [IInkBrush.getColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkbrush/#getColor--) و[IInkBrush.getSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkbrush/#getSize--) .

### **تعيين لون فُرْشاة الحبر**

يوضح هذا الكود Java كيفية تعيين لون فُرْشاة الحبر:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **تعيين حجم فُرْشاة الحبر**

يوضح هذا الكود Java كيفية تعيين حجم فُرْشاة الحبر:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

بشكل عام، لا يتطابق عرض الفُرْشاة وارتفاعها، لذلك لا يعرض PowerPoint حجم الفُرْشاة (يكون قسم البيانات المقابل رماديًا). عندما يتطابق عرض الفُرْشاة وارتفاعها، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، لنزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ في الاعتبار حجم الفُرُش؛ فهي دائمًا تفترض أن سمك الخط صفر (انظر الصورة السابقة).

لذلك، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب أخذ حجم فُرْشاة الآثار في الاعتبار. هنا، تم تحجيم كائن الهدف (أثر النص المكتوب بخط اليد) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية، يبقى حجم الفُرْشاة ثابتًا، والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يستخدم PowerPoint سلوكًا مشابهًا لكائنات النص:

![ink_powerpoint6](ink_powerpoint6.png)

## **التحكم في مظهر الحبر أثناء التصدير والعرض**

توفر Aspose.Slides الواجهة [IInkOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/) للتحكم في طريقة ظهور كائنات الحبر في الناتج المُصدَّر أو المُرصَّد. يمكنك استخدام خصائصها لإخفاء الحبر بالكامل أو لتغيير طريقة تفسير عمليات قناع الفُرْشاة.

تتوفر خيارات الحبر من خلال خيارات التصدير أو العرض لعدة أنواع من المخرجات:

| المخرجات | خاصية خيارات الحبر |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| صورة الشريحة | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

الطريقتان التاليتان من [IInkOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/) تعرضان الإعدادين نفسهما:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/#getHideInk--) يحدد ما إذا كانت كائنات الحبر مُضمنة في الناتج. القيمة الافتراضية هي `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) يحدد ما إذا كانت عملية القناع تُفسَّر كشفافية عند عرض فُرْشاة الحبر. القيمة الافتراضية هي `true`؛ استدعِ [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) بـ `false` لاستخدام عملية ROP بدلاً من ذلك.

### **إخفاء كائنات الحبر في مخرجات PDF**

بشكل افتراضي، تظل كائنات الحبر مرئية أثناء التصدير. لإنشاء مخرج نظيف بدون ملاحظات مكتوبة بخط اليد أو محتوى حبر آخر، استدعِ [IInkOptions.setHideInk](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) بـ `true`.

يوضح المثال التالي بلغة Java كيفية تصدير عرض تقديمي إلى PDF مع إخفاء جميع كائنات الحبر:

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

لإخفاء كائنات الحبر عند عرض الشرائح كصور نقطية، قم بتكوين [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/renderingoptions/#getInkOptions--) ومرِّر خيارات العرض إلى [ISlide.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) .

يوضح المثال التالي بلغة Java كيفية عرض الشريحة الأولى كصورة PNG دون كائنات الحبر:

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

الإعداد [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) يتحكم في طريقة تفسير عمليات القناع عند عرض فُرْشاة الحبر. القيمة الافتراضية هي `true`، مما يستخدم الشفافية. لاستخدام عملية ROP بدلاً من ذلك، استدعِ [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) بـ `false`.

يوضح المثال التالي بلغة Java كيفية تصدير شريحة إلى SVG واستخدام العرض القائم على ROP لعمليات قناع الحبر:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

يمكن تطبيق الإعداد نفسه عبر [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#getInkOptions--) عند تصدير عرض تقديمي أو عرض شريحة إلى TIFF.

### **اختيار ما إذا كان يتم إخفاء الحبر أو الحفاظ عليه**

عندما تحتاج إلى نسخة نظيفة من عرض تقديمي مُعلَّم للتوزيع بدون علامات مراجعة، استدعِ [IInkOptions.setHideInk](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) بـ `true` أثناء التصدير.

اترك [IInkOptions.getHideInk](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/#getHideInk--) على قيمته الافتراضية `false` عندما تكون تعليقات الحبر جزءًا من المحتوى المقصود، مثل تعليقات المراجعة، الملاحظات المكتوبة بخط اليد، التظليل، أو الرسومات التي يجب أن تبقى مرئية في النتيجة المُصدَّرة. يتيح ذلك للتطبيقات إنشاء مخرجات مراجعة ونهائية منفصلة من نفس العرض التقديمي دون تعديل كائنات الحبر الأصلية.

## **الأسئلة الشائعة**

**هل يمكنني تغيير لون أو حجم خط حبر موجود؟**

نعم. احصل على الأثر من خلال [IInk.getTraces](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iink/#getTraces--)، ثم غيّر فُرْشاة الأثر عبر [IInkTrace.getBrush](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinktrace/#getBrush--) . استدعِ [IInkBrush.setColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) أو [IInkBrush.setSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) لتغيير الفُرْشاة.

**هل تغيير إخفاء الحبر يؤثر على العرض التقديمي المصدر؟**

لا. استدعاء [IInkOptions.setHideInk](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) يؤثر فقط على النتيجة المعروضة أو المُصدَّرة؛ ولا يزيل أو يغيّر كائنات الحبر في العرض التقديمي الأصلي.

**ما هي صيغ التصدير التي تدعم خيارات الحبر؟**

يمكنك تكوين خيارات الحبر لـ PDF وHTML وSVG وTIFF وصور الشرائح النقطية عبر خيارات التصدير أو العرض المقابلة المذكورة أعلاه.

**قراءة إضافية**

* لقراءة المزيد عن الأشكال عموماً، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/ar/java/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعّالة، راجع [Shape Effective Properties](https://docs.aspose.com/slides/ar/java/shape-effective-properties/#get-effective-font-height-value).
* لتفاصيل تصدير PDF، راجع [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ar/java/convert-powerpoint-to-pdf/).
* لتفاصيل تصدير HTML، راجع [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ar/java/convert-powerpoint-to-html/).
* لتفاصيل تصدير SVG، راجع [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ar/java/render-a-slide-as-an-svg-image/).
* لتفاصيل تصدير TIFF، راجع [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ar/java/convert-powerpoint-to-tiff/).
* لتفاصيل عرض الشريحة كصورة، راجع [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ar/java/convert-slide/).