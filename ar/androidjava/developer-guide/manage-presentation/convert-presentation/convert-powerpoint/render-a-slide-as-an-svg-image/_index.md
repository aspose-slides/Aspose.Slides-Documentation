---
title: تحويل شرائح العرض التقديمي إلى صور SVG على Android
linktitle: الشريحة إلى SVG
type: docs
weight: 50
url: /ar/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG على Android والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML قابل للتوسع يعمل بشكل جيد للنشر على الويب، وعارضات الشرائح، وسير عمل إمكانية الوصول، والمعالجة التلقائية بعد الإنشاء. تقوم Aspose.Slides for Android عبر Java بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص، والخطوط، والصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، ومتوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق باستخدام [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

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

يستخدم اسم الملف [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) عندما تحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) يتحكم في تصوير SVG. لإطارات النص، يضمّن [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) إطار النص في مساحة التصوير، وتحدد [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) ما إذا كان يتم تطبيق دوران الإطار. عيّن [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) إلى `true` عندما يجب أن يُعرض النص بدون ربط الحروف.

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

SVG 1.1 لا يحتوي على إعداد إدخال العلامة لتحديد مكان توقف الخط تحت رأس السهم. بصورة افتراضية، تقوم Aspose.Slides بتقصير الخط المُصدَّر حتى لا يبرز ضربة الخط عبر العلامة. استدعِ [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) مع `true` لرسم الضربة حتى نقطة النهاية الأصلية للخط. يؤثر هذا الإعداد فقط على إخراج SVG. يبقى الخط في موضعه وطوله على الشريحة.

```java
import com.aspose.slides.*;
import android.graphics.Color;
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
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

المقارنة تُظهر رأس السهم المثلث على الخط بسمك 10 نقاط. مع تمكين القص، يكون الطرف حادًا. مع تعطيل القص، تبرز الضربة عبر الجوانب المائلة للعلامة وتترك طرفًا مسطحًا.

![مكبر مثلث 10 نقاط مع طرف حاد عندما يكون القص مفعلاً وطرف مسطح عندما يكون القطع معطلًا](line-end-cropping.png)

في الخطوط الأخرى من المثال، يكون الضربة البارزة أقل وضوحًا على المثلث بسمك نقطتين. يغطي الماس المملوء طرف الضربة في كلا العرضين.

## **التحكم في النص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان النص يبقى كنص أو يُحوَّل إلى رسومات متجهية، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية على موازنة التناسق البصري، واختيار النص، واعتماد الخطوط في SVG المُصدَّر.

### **تحويل كل النص إلى رسومات متجهية**

عيّن [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) إلى `true` لكتابة كل نص الشريحة كرسومات متجهية. هذا يزيل اعتماد الخطوط ويجعل النتيجة بصريةً أكثر اتساقًا عبر المتصفحات، لكن النص لن يكون قابلًا للتحديد أو البحث كـ SVG نصي.

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

### **اختر طريقة التعامل مع الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) للإشارة إلى ملفات الخط المنفصلة، أو [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) لتضمين بيانات الخط داخل SVG، أو [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) لتصوير النص الذي يستخدم خطوطًا خارجية كرسومات. تحقق من ترخيص الخط قبل تضمينه.

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

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) لتقليل دقة الصور المضمنة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) لحذف مناطق الصور المقصوصة، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو البيانات المحتفظ بها.

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

## **التحكم في دقة تجسيد ملفات الميتافايل**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) يحدد الحد الأدنى لدقة التجسيد للميتافايل أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تجسيد صورة EMF أو WMF. لا يحدد DPI عالميًا لـ SVG ولا يجبر كل كائن على الشريحة أن يتحول إلى صورة نقطية.

قم بتنزيل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF بخطوط قطرية متقاربة. المثال التالي يصدر شريحة الأولى في عرض تقديمي بثلاث دقات تجسيد عبر [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). تبقى جميع إعدادات التصدير الأخرى متماثلة بحيث يمكن مقارنة النتائج.

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

في الإخراج، تحولت صورة EMF إلى PNG مضمن واحد في كل SVG. القياسات التالية خاصة بالعرض التقديمي المرفق؛ هي ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| DPI تجسيد ملف الميتافايل | أبعاد PNG المضمن | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تُظهر نفس منطقة الصورة النقطية المضمنة عند نفس حجم العرض المكبر. تُظهر الخطوط القطرية بكسلية واضحة عند 72 DPI وحوافًا أكثر سلاسة عند الدقات الأعلى، بينما يزداد حجم ملف SVG. رفع القيمة لا يعني بالضرورة تحسين كل تفصيل أو تغيير كل صورة تم تصديرها.

![مكبر تفاصيل الخط القطرية عند 72 و150 و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) يتحكم في تقليل دقة الصورة ويمكن أن يُخفي تأثير تغيير دقة تجسيد الميتافايل. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) يتحكم في جودة ترميز JPEG، وليس في دقة تجسيد الميتافايل.

## **تعيين معرفات ثابتة للأشكال والنص**

استخدم [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) لتعيين [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) لكل شكل SVG. لتعيين قيم [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) على عناصر `tspan` النصية أيضًا، نفّذ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). قم بتعيين أحد المتحكمين عبر [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

المتحكم التالي يستخدم [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--)، وهو ثابت طوال عمر الشكل، ومعدل عدٍّ قابل للتكرار لنصوص `tspan`. يجعل ذلك المعرفات المُولَّدة مناسبة للمعالجة اللاحقة لعرض تقديمي لم يتغير.

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

في [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/)، استدعِ [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) مع قيمة [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) لإضافة معالج حدث JavaScript إلى الشكل المُصدَّر. عيّن المتحكم عبر [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) وعَرِّف دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

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

يمكن للصفحة المستضيفة تعريف دالة JavaScript المشار إليها من قبل المعالج. يسمح تعيين المعرفات ومعالجات الأحداث لعارضات الشرائح، وتعزيزات إمكانية الوصول، وسير عمل SVG تفاعلية أخرى.

## **الأسئلة الشائعة**

**متى يجب علي استخدام [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) بدلًا من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) عندما يُراد تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل ملف SVG أصغر؟**

ابدأ بضغط الصور المضمنة، حذف مناطق الصور المقصوصة، واختيار ملفات الخطوط المرتبطة عندما يستطيع بيئة الهدف خدمتها. اختبر النتيجة لأن انخفاض دقة الصورة، وانخفاض جودة JPEG، وتحويل النص إلى رسومات كلّها لها مفاضلات مختلفة بين الجودة والحجم.

**هل يمكن تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر متحكم التنسيق، ثم حدد عناصر SVG المطابقة في أداة المعالجة اللاحقة أو برنامج النصوص المتصفح.