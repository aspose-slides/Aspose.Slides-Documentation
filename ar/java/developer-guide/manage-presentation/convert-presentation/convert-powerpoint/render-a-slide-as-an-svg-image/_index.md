---
title: عرض شرائح العرض التقديمي كصور SVG في جافا
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- الشريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- SVG تفاعلي
- باوربوينت
- العرض التقديمي
- جافا
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في جافا والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML وقابل للتوسع يعمل بشكل جيد للنشر على الويب، وعارضات الشرائح، وسير عمل إمكانية الوصول، والمعالجة اللاحقة الآلية. يقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل ويسمح لك بالتحكم في كيفية كتابة النصوص والخطوط والصور وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) عندما يجب أن يكون SVG المُصدّر مضغوطًا، ويمكن التنبؤ به عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، حدّد شريحة، واكتبها إلى دفق باستخدام [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

يستخدم اسم الملف [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تهيئة إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) يتحكم في تصيير SVG. بالنسبة لإطارات النص، تشمل [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) إطار النص في مساحة التصيير، وتحدد [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) ما إذا كان يتم تطبيق دوران الإطار. اضبط [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) إلى `true` عندما يجب تصيير النص بدون الروابط الحرفية.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **التحكم في النص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان يبقى النص كنص أو يتحول إلى رسومات متجهية، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية على موازنة اتساق الشكل البصري، إمكانية اختيار النص، واعتمادية الخطوط في SVG المُصدّر.

### **تحويل كل النص إلى رسومات متجهية**

اضبط [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) إلى `true` لكتابة كل نص الشريحة كرسومات متجهية. يزيل هذا الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لا يبقى قابلًا للاختيار أو للبحث كنص SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **اختيار طريقة معالجة الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، أو `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لتصية النص الذي يستخدم خطوطًا خارجية كرسومات. تحقق من تراخيص الخط قبل تضمين الخطوط.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **تقليل حجم الصور المضمنة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) لتقليل دقة الصور المضمنة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) لحذف المناطق المقتطعة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب جودة الصورة أو البيانات المحتفظ بها.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **التحكم في دقة تحويل ملف الميتافيل إلى نقطية**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) يحدد الحد الأدنى لدقة التحويل النقطي للملفات الميتافيل أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى نقطية. لا يحدد DPI عالميًا للـ SVG ولا يجبر كل كائن على الشريحة على أن يصبح صورة نقطية.

قم بتنزيل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF بخطوط مائلة متقاربة. المثال التالي يصدر شريحته الأولى بثلاث دقات تحويل نقطية عبر [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). تبقى جميع إعدادات التصدير الأخرى متطابقة لتسهيل المقارنة.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

في الناتج، تحولت صورة EMF إلى PNG مضمّن واحد في كل SVG. القياسات التالية تخص العرض المقدم؛ ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| دقة تحويل ملف الميتافيل DPI | أبعاد PNG المضمنة | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تُظهر نفس منطقة الصورة النقطية المضمنة عند نفس حجم العرض المكبّر. الخطوط المائلة تظهر بكسلة واضحة عند 72 DPI وحواف أكثر سلاسة عند الدقات الأعلى، بينما يزداد حجم ملف SVG. زيادة القيمة لا تحسن بالضرورة كل التفاصيل ولا تغير كل صورة مُصدّرة.

![تفاصيل الخط المائل المكبّر عند 72 و150 و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) يتحكم في تقليل دقة الصورة وقد يُخفي تأثير تغيير دقة تحويل الميتافيل النقطية. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) يتحكم في جودة ترميز JPEG، وليس في دقة تحويل الميتافيل النقطية.

## **تعيين معرفات ثابتة للأشكال والنص**

استخدم [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) لتعيين [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) لكل شكل SVG. لتعيين قيم [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) لعناصر `tspan` النصية أيضًا، نفّذ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). عيّن أحد المراقبين باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

المراقب التالي يستخدم [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--)، وهو ثابت طوال عمر الشكل، وعدادًا قابلًا للتكرار لنصوصه. يجعل هذا المعرفات المولدة مناسبة للمعالجة اللاحقة لعرض تقديمي لم يتغير.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **إضافة معالجات أحداث SVG**

في [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/)، استدعِ [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) مع قيمة [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) لإضافة معالج JavaScript إلى الشكل المُصدّر. عيّن المراقب باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) وعّرف دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

يمكن للصفحة المستضيفة تعريف دالة JavaScript التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يتيح لعارضات الشرائح، وتعزيزات إمكانية الوصول، وسير عمل SVG التفاعلي.

## **الأسئلة المتكررة**

**متى يجب علي استخدام [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) عندما يجب تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لتصغير حجم SVG؟**

ابدأ بضغط الصور المضمنة، حذف مناطق الصور المقصوصة، واختيار ملفات الخطوط المرتبطة عندما يمكن للبيئة المستهدفة توفيرها. اختبر النتيجة لأن تقليل دقة الصورة، تقليل جودة JPEG، وتحويل النص إلى متجهات لكل منها تأثيرات مختلفة على الجودة والحجم.

**هل يمكنني تعديل عناصر SVG المُصدّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر مراقب تنسيق، ثم حدد عناصر SVG المطابقة في أداة المعالجة اللاحقة أو سكربت المتصفح الخاص بك.