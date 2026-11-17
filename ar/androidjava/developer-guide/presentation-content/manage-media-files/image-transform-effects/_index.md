---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية على Android
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/androidjava/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- تدرج الرمادي
- ثنائي اللون
- صبغة
- HSL
- استبدال اللون
- تشويش
- شفافية
- تأثير ألفا
- سلسلة تأثير
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **لمحة عامة**

يمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) ثم الوصول إلى [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). مجموعة [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) المرتجعة تتيح لك إضافة، تعداد، فحص، إزالة، وتصفية التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

توضح هذه المقالة سير عمل كامل للسطوع والتباين، تحويلات اللون، التشويش، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من دورة الحياة في PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

موارد الصورة والصورة التي تُعرضها كائنات مختلفة:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) يخزن أو يشير إلى بيانات الصورة المصدر التي تملكها العروض التقديمية.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) ينتمي إلى تعبئة صورة ويشير إلى مورد صورة بينما يخزن مجموعة تحويلات الصورة.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) هو شكل الشريحة الذي يملك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القص، وتنسيق المستوى الإطاري الأخرى.

لذلك، لا تقوم عمليات تحويل الصورة بتعديل البايتات في [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/). عندما يُمرّر نفس `IPPImage` إلى [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) أكثر من مرة، يحصل كل إطار صورة جديد على `ISlidesPicture` خاص به ومجموعة تحويل خاصة به. تطبيق تدرج الرمادي على إطار واحد لا يجعل الإطارات الأخرى رمادية، حتى وإن أعادت جميعها استخدام نفس مورد الصورة المضمّن.

نموذج `ISlidesPicture.getImageTransform` نفسه يُستخدم أيضًا بواسطة تعبئات صور أخرى، مثل شكل أو خلفية شريحة. الأمثلة أدناه تركز على إطارات الصور.

## **استخدام نطاقات ومعلمات صحيحة ووحدات**

الطرق المعروضة تستخدم النطاقات الدلالية والوحدات التالية. حافظ على القيم ضمن هذه النطاقات حتى لو لم ترفض نسخة المكتبة المستخدمة القيم غير الصالحة فورًا؛ قد يقوم تنسيق العرض الهدف بتطبيع أو إهمال أو رفض البيانات غير الصالحة أثناء الحفظ أو عند فتح الملف في PowerPoint.

| العملية | المعلمات | النطاق والوحدة الصالحة |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | لا شيء | لا معلمات رقمية. قيم ألفا تظل دون تغيير. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | لونان للبكسلات الداكنة والفاتحة. قيم القنوات RGB والألفا المستخدمة بواسطة `android.graphics.Color` تتراوح من `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | درجة اللون من `0` شامل إلى `360` غير شامل، بالدرجات؛ الكمية من `-100` إلى `100`، نسبة مئوية. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | درجة اللون من `0` شامل إلى `360` غير شامل، بالدرجات؛ التشبع والسطوع من `-100` إلى `100`، نسبة مئوية. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | لون الاستبدال يستخدم قيم القنوات من `0` إلى `255`. قيم الألفا الحالية تظل دون تغيير. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | نصف القطر غير سالب ويقاس بالنقاط؛ `grow` هو قيمة منطقية تتحكم ما إذا كان المحتوى المشوش قد يمتد خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتقليل الشفافية العادي: `0` شفاف تمامًا و`100` يحافظ على قيمة ألفا الحالية. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` إلى `100`، نسبة مئوية للشفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` إلى `100`، نسبة مئوية للعتبة الألفا. القيم الأقل تصبح شفافة؛ القيم عند أو فوقها تصبح معتمة. |

للتعديل الثابت على الألفا، الشفافية والعتامة تكملان بعضهما. على سبيل المثال، شفافية 35% تعادل تعديل ألفا بنسبة 65%.

## **تطبيق السطوع والتباين**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) يُعيد عملية [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). تُعطى إعداداته القياسية عند إنشاء العملية. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) يُعيد قيمًا محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15% والتباين بنسبة 20%، ثم يعرض معاينة دون تعديل الصورة المضمّنة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) هو امتداد لتأثير الصورة في Office 2010 وهو أقل قابلية للنقل من تأثير الإضاءة القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابلين للتحرير بعد دورة PPTX، استخدم [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) وتحقق من النتيجة بعد إعادة فتح الملف. يوضح قسم قيود الصيغة هذا التمييز بمزيد من التفصيل.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بصورة مستقلة على إطارات صور مختلفة تُعيد استخدام مورد صورة واحد. المثال التالي يُنشئ خمسة إطارات ويُطبق تدرج الرمادي، الثنائي اللون، الصبغة، تعديل HSL، واستبدال اللون.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) يحتوي على معلمين لونيين قابلين للتحرير بشكل مستقل: `color1` يحدد البكسلات الداكنة، بينما `color2` يحدد البكسلات الفاتحة. هذا يجعله مثالًا مفيدًا لتأثير إعداداته أكثر تعقيدًا من قيمة قياسية واحدة.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) يستبدل لون كل بكسل بلون ثابت واحد مع الحفاظ على ألفا. يختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)، الذي يطابق لون مصدر إلى آخر ويظهر كل من صيغ اللون المصدر والهدف.

### **تطبيق عتبة الإضاءة**

يمكن أن تجعل عتبة الإضاءة العلامات الخفيفة على صفحة ممسوحة ضوئيًا أسهل للتمييز عن الخلفية. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) يحافظ على الظلال المتوسطة من الرمادي. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) يطابق الإضاءة إلى أسود أو أبيض، بينما [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) يطبق عتبة على العتمة.

عَتْبة الإضاءة تتراوح من 0% إلى 100% شاملًا. البكسلات الأقل من العتبة تصبح سوداء. البكسلات عند أو فوق العتبة تصبح بيضاء. رفع العتبة يحول مزيدًا من الظلال إلى سوداء لأن المزيد منها يقع تحت الحد.

حمِّل [grayscale-swatches.png](grayscale-swatches.png) إلى دليل العمل. كل تسمية تُظهر المستوى الرمادي الأصلي على مقياس من 0 إلى 255. يضع المثال الأصل بجانب نسختين ويحفظ عتبة كل نسخة في العرض التقديمي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

افتح العرض الناتج في PowerPoint لمقارنة الإطارات الثلاثة. العينة المسمّى 96 لها تقريبًا 38% إضاءة (96 من 255). تتحول إلى أبيض عند عتبة 20% وإلى أسود عند عتبة 60%.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **إضافة تشويش، شفافية، وتأثيرات ألفا**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) يؤثر على جميع قنوات اللون، بما في ذلك ألفا. اضبط `grow` إلى `true` عندما قد يمتد حافة التشويش خارج حدود الصورة الأصلية.

لشفافية موحدة، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). إنه يضرب كل قيمة ألفا موجودة، لذا تظل البكسلات شبه الشفافة متفاوتة نسبيًا. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) يعيّن قيمة ألفا واحدة لكل البكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) يحوّل ألفا إلى مستويين بناءً على عتبة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تشمل عمليات ألفا بدون معلمات أخرى [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)، الذي يجعل كل ألفا غير صفرية معتمة تمامًا؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)، الذي يجعل كل ألفا أقل من 100% شفافة تمامًا؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)، الذي يغيّر ألفا إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `add...Effect` تُضيف عملية جديدة إلى نهاية المجموعة. يستخدم المُصوِّر المجموعة كخط أنابيب مرتب: خرج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، يمكن أن تُنتج نفس العمليات بترتيب مختلف صورة مختلفة.

على سبيل المثال، تطبيق تدرج الرمادي ثم الصبغة أولًا يزيل المعلومات اللونية ثم يُعيد تلوين نتيجة الإضاءة. تطبيق الصبغة ثم تدرج الرمادي يزيل الصبغة مرةً أخرى. بالمثل، يمكن لاستبدال الألفا أن يتجاوز قيم الألفا التي حسبتها عمليات سابقة، بينما يحافظ تعديل الألفا على اختلافاتها النسبية.

المثال التالي يُنشئ سلسلة من أربع عمليات، يحفظها كـ PPTX، يعيد فتح العرض، يتحقق من نوعية العمليات وترتيبها، ثم يُظهر النتيجة المعاد فتحها:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، الألفا، والتشويش إلى سلاسل منفصلة. يمكن دمجها، لكن الجمع ليس دائمًا مفيدًا. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات لونية سابقة؛ تدرج الرمادي بعد الثنائي اللون يزيل اللونين المختارين؛ وعمليات الألفا السقفية، الأرضية، الاستبدال أو الثنائية يمكن أن تُقضي على تفاصيل الألفا التي أنشئت سابقًا. ابنِ السلسلة وفقًا لتسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها أعلام تنسيق غير مرتبة.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*في هذا التوضيح لـ Aspose.Slides for .NET 26.11، صبغة بزاوية 220° بنسبة 25% لا تغير الصورة الرمادية. تطبيق الصبغة نفسها قبل تحويل الصورة إلى رمادية ينتج ألوانًا مختلفة.*
<!-- visual-explanation:image-transform-effects:end -->

## **فحص القيم القابلة للتعديل والفعّالة**

العملية القابلة للتعديل هي الكائن المخزن في `ISlidesPicture.getImageTransform`. حسب التأثير، قد تعرض أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) يتيح كتابة قيم `radius` و `grow`، و[IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) يتيح كتابة `amount`، و[IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) يتيح كتابة `threshold`. تأثيرات اللون مثل [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) تكشف عن كائنات [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) قابلة للتغيير.

بعض واجهات العملية، بما في ذلك [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/)، [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/)، و[IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/)، لا تكشف عن القيم الإنشائية كخصائص قابلة للكتابة. لتغيير هذه الإعدادات، احذف العملية وأضف بديلًا في الموضع المطلوب.

البيانات الفعّالة التي تُعيدها `getEffective()` محسوبة للقراءة فقط. هي مفيدة لحل ألوان تعتمد على السمة وقراءة القيم المُعيّنة التي يستخدمها المُصوِّر، لكنها ليست سطح تحرير آخر. المثال التالي يُعدد السلسلة ويفحص القيم الفعّالة حيث توفر الـ API ما يلزم:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

التأثيرات بدون معلمات مثل تدرج الرمادي، السقيفة، والعكس لا تزال تملك كائن بيانات فعّال، لكن لا توجد إعدادات قياسية للطباعة. وجودها وموقعها في المجموعة هو ما يهم.

## **إزالة أو تصفير تحويلات الصورة**

استخدم [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) لإزالة عملية واحدة بحسب الفهرس. لأن الفهارس تتحرك بعد الإزالة، ابحث عن الهدف أولاً ثم احذفه بعد التعداد. استخدم [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) لإزالة السلسلة بالكامل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

إزالة أو تصفير التحويلات يغيّر تنسيق الصورة فقط. لا يحذف، ولا يُعيد ضغط، ولا يُغيّر مورد [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) المستخدم مرةً أخرى.

## **النظر في صيغ العروض والأهداف المصدرة**

تنشأ تحويلات الصورة من DrawingML، لذا يُفضَّل تنسيق PPTX القابل للتحرير لسلاسل التأثيرات. حتى مع PPTX، لا تتوفر كل عملية على قابلية نقل متساوية:

- عمليات DrawingML القياسية مثل الإضاءة، تدرج الرمادي، الثنائي اللون، الصبغة، HSL، التشويش، والعمليات الشائعة للألفا لديها أفضل فرصة للبقاء بعد دورة PPTX. دائمًا أعد فتح الملف المُولد وعاين المجموعة عندما تكون المحافظة مطلوبة.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) هو امتداد Office 2010 وليس عملية الإضاءة القياسية في DrawingML. يمكن استخدامه للتصوير في الذاكرة، لكنه غير مضمون أن يبقى كـ [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) قابل للتحرير بعد الحفظ وإعادة الفتح. فضِّل [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) لضبط السطوع والتباين بشكل دائم.
- صيغ PPT الثنائية سابقة لملف نموذج DrawingML الكامل. الحفظ إلى PPT قد يتجاهل عمليات غير مدعومة، يقلل السلسلة إلى مجموعة مدعومة، أو يُقَرِّب الشكل. لا تستخدم PPT كصيغة تحقق لسلسلة تحرير معقدة.
- التصيير إلى PNG أو JPEG أو TIFF أو PDF أو SVG أو HTML أو أي مخرجات بصرية أخرى يطبق السلسلة المدعومة على المظهر المُصوَّر. تلك المخرجات لا تحتوي على `IImageTransformOperationCollection` قابل للتحرير؛ صيغ الرافعات تُسطّح النتيجة إلى بكسلات، والصادرات المستندية/الرسومية تُخزّن تمثيلها الخاص بالتصيير.
- التأثيرات لا تجعل الصورة المرتبطة مكتملة ذاتيًا. لا يزال عرض صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض.

قد تُظهر مستهلكات العروض المختلفة حالات حافة مختلفة، خاصةً عندما تُدمج عمليات ألفا أو تكميم اللون. للمخرجات الحرجة، اختبر كلٍّ من دورة التحرير النهائية وصيغة التصدير النهائية باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة المتداولة**

**هل تُغيّر تأثيرات تحويل الصورة بيانات الصورة المضمَّنة؟**

لا. العمليات تنتمي إلى `ISlidesPicture` المستخدمة في تعبئة الصورة. تبقى بايتات `IPPImage` الأساسية دون تغيير.

**هل ستشارك إطارا صورة يعيدان استخدام نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `IPPImage` تُجنب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يملك `ISlidesPicture` ومجموعة تحويل خاصة به.

**هل يمكن دمج تأثيرات اللون، التشويش، والألفا؟**

نعم. تقبل المجموعة دمجها في سلسلة مرتبة واحدة. فكر فيما تفعله كل عملية على نتيجة السابقة لأن عمليات الاستبدال والعتبة قد تُزيل تفاصيل لونية أو ألفا سابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة في التصيير، بما فيها الألوان المُحلَّة. حرِّر العملية المخزَّنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلًا بمعاملات إنشاء جديدة.

**أي صيغة يجب أن أستخدمها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف عبر إعادة فتحه. لا يمكن للـ PPT القديم تمثيل نموذج تأثير DrawingML الكامل، وتحتفظ صيغ التصدير المُصوَّرة بالمظهر فقط دون عمليات تحويل قابلة للتحرير.