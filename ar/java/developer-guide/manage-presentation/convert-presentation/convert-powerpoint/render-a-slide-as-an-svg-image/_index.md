---
title: تحويل شرائح العرض التقديمي إلى صور SVG في Java
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
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في Java والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة مبني على XML وقابل للتوسع يعمل جيدًا للنشر على الويب، وعارضات الشرائح، وسير العمل المتعلقة بإمكانية الوصول، والمعالجة التلقائية بعد الإنشاء. Aspose.Slides تقوم بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص والخطوط والصور وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) عندما يجب أن يكون ملف SVG المُصدَّر مضغوطًا، متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كملف SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق باستخدام [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). المثال التالي يصدر كل شريحة في العرض التقديمي كملف SVG منفصل.

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

اسم الملف يستخدم [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين مخرجات SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) يتحكم في عرض SVG. لإطارات النص، يقوم [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) بتضمين إطار النص في مساحة العرض، و[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) يحدد ما إذا كان يتم تطبيق تدوير الإطار. عيّن [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) إلى `true` عندما يجب عرض النص دون الروابط الحرفية.

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

## **التحكم في قص نهاية الخط عند رؤوس السهام**

لا يحتوي SVG 1.1 على إعداد إزاحة العلامة لتحديد أين يجب أن يتوقف الخط تحت رأس السهم. بشكل افتراضي، تقوم Aspose.Slides بتقصير الخط المُصدَّر حتى لا يبرز حدّه من خلال العلامة. استدعِ [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) مع `true` لرسم الحد حتى نقطة النهاية الأصلية للخط. هذا الإعداد يؤثر فقط على مخرجات SVG. يبقى الخط في موقعه وطوله الأصلي على الشريحة.

الرسم التوضيحي يرسم رؤوس أسهم على شكل مثلث وماسّة على خطوط بعرض نقطتين وعشرة نقاط. يقوم بتصدير الشريحة نفسها مرتين، مع تغيير خيار القص فقط.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

المقارنة تُظهر رأس السهم المثلث على الخط بعرض 10 نقاط. عندما يكون القص مفعَّلًا، تكون الطرف حادًا. عندما يكون القص معطَّلًا، يبرز الحد عبر جوانب العلامة المائلة ويترك طرفًا مسطحًا.

![مثلث مبسط بعرض 10 نقاط مع طرف حاد عندما يكون القص مفعَّلًا ونهاية مسطحة عندما يكون القص معطَّلًا](line-end-cropping.png)

في الخطوط الأخرى من المثال، يكون الحد البارز أقل وضوحًا على المثلث بعرض نقطتين. يُغطي الماس المملوء نهاية الحد في كلا العرضين.

## **التحكم في النصوص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان يبقى النص كنص أو يتحول إلى رسومات متجهة، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. الخيارات التالية تساعدك على موازنة التناسق البصري، اختيار النص، واعتمادية الخطوط في SVG المُصدَّر.

### **تحويل كل النص إلى متجهات**

عيّن [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) إلى `true` لكتابة كل نص الشريحة كرسم متجه. هذا يزيل الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر تناسقًا عبر المتصفحات، لكن النص لن يكون قابلًا للاختيار أو البحث كنص SVG.

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

### **اختيار كيفية التعامل مع الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) للخطوط التي تُحمَّل خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط في SVG، أو `Vectorize` لتحويل النص الذي يستخدم خطوطًا خارجية إلى رسومات. تحقق من ترخيص الخط قبل تضمينه.

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

## **تقليل حجم الصور المضمَّنة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) لتقليل دقة الصور المضمَّنة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) لحذف المناطق المقتطعة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب جودة الصورة أو البيانات المحتفظ بها.

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

## **التحكم في دقة تحويل الميتافايل إلى نقاط raster**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) يحدد الحد الأدنى للدقة عند تحويل الميتافايل إلى raster خلال تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى raster. لا يحدد DPI عالميًا للـ SVG ولا يجبر كل عنصر على الشريحة على أن يصبح صورة raster.

حمّل [metafile-rasterization.pptx](metafile-rasterization.pptx) الذي يحتوي على صورة EMF ذات خطوط مائلة متقاربة. المثال التالي يصدر الشريحة الأولى بثلاث دقات raster مختلفة عبر [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). تبقى جميع إعدادات التصدير الأخرى متطابقة لتسهيل المقارنة.

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

في المخرج، أصبحت صورة EMF PNG مضمَّنة واحدة في كل SVG. القياسات التالية تخص العرض المقدم؛ ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| دقة raster للميتا ملف (DPI) | أبعاد PNG المضمّن | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تُظهر نفس المنطقة من الصورة raster المضمَّنة بنفس حجم العرض المكبر. الخطوط المائلة تُظهر بكسلة واضحة عند 72 DPI وحواف أكثر سلاسة عند دقات أعلى، بينما حجم ملف SVG يزداد. زيادة القيمة لا تحسن كل تفاصيل الصورة بالضرورة ولا تُغيّر كل صورة مُصدَّرة.

![تفاصيل خط مائل مكبر عند 72، 150، و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) يتحكم في تقليل دقة الصورة وقد يُخفى تأثير تغيير دقة raster للميتا ملف. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) يتحكم في جودة ترميز JPEG، وليس في دقة raster للميتا ملف.

## **تعيين معرفات ثابتة للأشكال والنصوص**

استخدم [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) لتعيين [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) لكل شكل SVG. لتعيين قيم [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) على عناصر `tspan` النصية كذلك، نفّذ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). عيّن أيٍ من المتحكمين باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

المتحكم التالي يستخدم [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--)، وهو ثابت طوال عمر الشكل، ومِعدادًا قابلًا لإعادة الاستخدام لمقاطع النص الخاصة به. يجعل ذلك المعرفات المولدة مناسبة لمعالجة العرض التقديمي غير المُغيَّر لاحقًا.

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

في [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/)، استدعِ [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) مع قيمة [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) لإضافة معالج حدث JavaScript إلى الشكل المُصدَّر. عيّن المتحكم باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) وعَرِّف دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

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

يمكن للصفحة المستضيفة تعريف دالة JavaScript التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يُمكّن عارضات الشرائح، تحسينات إمكانية الوصول، وسير عمل SVG التفاعلية الأخرى.

## **الأسئلة المتكررة**

**متى يجب علي استخدام [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) عندما يجب أن يكون كل النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) عندما يجب تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل ملف SVG أصغر؟**

ابدأ بضغط الصور المدمجة، حذف مناطق الصورة المقصوصة، واختيار ملفات الخطوط المرتبطة عندما يمكن للبيئة المستهدفة تقديمها. اختبر النتيجة لأن خفض دقة الصورة، خفض جودة JPEG، وتحويل النص إلى متجهات كل منهم يؤثر على الجودة والحجم بطرق مختلفة.

**هل يمكنني تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر متحكم التنسيق، ثم حدد عناصر SVG المطابقة في أداة ما بعد المعالجة أو سكريبت المتصفح.