---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام Java
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/java/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- تدرج رمادي
- ثنائي اللون
- تلوين
- HSL
- استبدال اللون
- ضبابية
- شفافية
- تأثير ألفا
- سلسلة تأثير
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides للـ Java."
---
## **نظرة عامة**

Aspose.Slides يمثل تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) الخاص بالإطار وادخل إلى [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--). المجموعة المرجعة [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) تسمح لك بإضافة، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

هذه المقالة توضح سير عمل كامل للسطوع والتباين، تحويلات اللون، الضبابية، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مصدر الصورة والصورة التي تعرضه كائنات مختلفة:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) يخزن أو يشير إلى بيانات الصورة المصدر التي تملكها العرض التقديمي.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) ينتمى إلى تعبئة الصورة ويشير إلى مصدر الصورة بينما يخزن مجموعة تحويل الصورة.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) هو شكل الشريحة الذي يملك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القص، وتنسيق الإطار الآخر.

لذلك، عمليات تحويل الصورة لا تعدل البايتات في [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). عندما يتم تمرير نفس `IPPImage` إلى [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) أكثر من مرة، يحصل كل إطار صورة جديد على `ISlidesPicture` خاص به ومجموعة تحويل خاصة به. تطبيق التحويل إلى تدرج الرمادي على إطار واحد لا يجعل الأطر الأخرى ذات تدرج رمادي، على الرغم من أن جميعها يعيد استخدام نفس مورد الصورة المضمّن.

نفس نموذج `ISlidesPicture.getImageTransform` يُستخدم أيضاً بواسطة تعبئات صور أخرى، مثل الشكل أو خلفية الشريحة. الأمثلة أدناه تركز على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعلمات**

الطرق المشروحة تستخدم النطاقات الدلالية والوحدات التالية. حافظ على القيم ضمن هذه النطاقات حتى إذا لم يرفض إصدار مكتبة معين كل قيمة خارج النطاق فوراً؛ قد يقوم تنسيق العرض الهدف بتطبيع، حذف، أو رفض البيانات غير الصالحة أثناء الحفظ أو عند فتح الملف بواسطة PowerPoint.

| العملية | المعلمات | النطاق والوحدة الصالحين |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | لا شيء | لا معلمات رقمية. الألفا يبقى دون تغيير. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | لونان للبيكسلات الداكنة والفاتحة. قنوات RGB والألفا في `java.awt.Color` تستخدم القيم من `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ `amount` من `-100` إلى `100`، نسبة مئوية. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ التشبع والإضاءة من `-100` إلى `100`، نسبة مئوية. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | لون الاستبدال يستخدم قيم القناة من `0` إلى `255`. قيم الألفا الحالية تبقى دون تغيير. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | نصف القطر غير سالب ويقاس بالنقاط؛ `grow` هو منطق يتحكم فيما إذا كان المحتوى الضبابي قد يمتد خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | نسبة مئوية غير سالبة. استخدم `0` إلى `100` للتحكم العادي بالشفافية: `0` شفاف تماماً و`100` يحافظ على الألفا الموجود. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` إلى `100`، نسبة مئوية للشفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` إلى `100`، نسبة مئوية للعتبة الألفا. القيم الأقل تصبح شفافة؛ القيم عندها أو أعلى تصبح معتمة. |

بالنسبة لتعديل الألفا الثابت، الشفافية والعتامة متكاملتان. على سبيل المثال، 35 % شفافية تعادل مقدار تعديل ألفا قدره 65 %.

## **تطبيق السطوع والتباين**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) يرجع عملية [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). يتم توفير إعداداته العددية عند إنشاء العملية. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) يرجع قيماً محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15 % والتباين بنسبة 20 %، ثم يعرض معاينة دون تعديل الصورة المضمّنة:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) هو امتداد تأثير صورة Office 2010 وهو أقل قابلية للنقل مقارنة بتأثير الإضاءة القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابلين للتعديل بعد جولة PPTX، استخدم [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) وتحقق من النتيجة بعد إعادة فتح الملف. يشرح قسم قيود التنسيق هذا الفرق بمزيد من التفصيل.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تعيد استخدام نفس مصدر الصورة. المثال التالي ينشئ خمسة إطارات ويطبق تدرج رمادي، ثنائي اللون، تلوين، تعديل HSL، واستبدال اللون.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) يحتوي على معاملين للون يمكن تحريرهما بشكل مستقل: `color1` يحدد البيكسلات الداكنة، بينما `color2` يحدد البيكسلات الفاتحة. هذا يجعله مثالاً مفيداً لتأثير إعداداته أكثر تعقيداً من قيمة عددية واحدة.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) يستبدل لون كل بيكسل بلون ثابت مع الحفاظ على الألفا. وهو مختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) الذي يطابق لون مصدر بلون هدف ويظهر تنسيقات كل من اللون المصدر والهدف.

### **تطبيق عتبة الإضاءة**

عتبة الإضاءة يمكن أن تجعل العلامات الخفيفة على صفحة ممسوحة ضوئياً أسهل للتمييز عن الخلفية. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) يحافظ على درجات الرمادي المتوسطة. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) يحول الإضاءة إلى أسود أو أبيض، بينما [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) يطبق عتبة على الشفافية.

عتبة الإضاءة تتراوح من 0 % إلى 100 % شاملين. البيكسلات تحت العتبة تصبح سوداء. البيكسلات عندها أو فوقها تصبح بيضاء. رفع العتبة يجعل المزيد من الدرجات سوداء لأن المزيد منها يقع تحت الحد.

حمّل [grayscale-swatches.png](grayscale-swatches.png) إلى دليل العمل. كل تسمية تعطي مستوى الرمادي الأصلي على مقياس من 0 إلى 255. يضع المثال الأصلي بجوار نسختين ويحفظ عتبة كل نسخة في العرض التقديمي.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

افتح العرض الناتج في PowerPoint لمقارنة الإطارات الثلاث. العينة المسمّاة 96 لها تقريباً 38 % إضاءة (96 من 255). تتحول إلى أبيض عند عتبة 20 % وإلى أسود عند عتبة 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **إضافة ضبابية، شفافية، وتأثيرات ألفا**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) يؤثر على جميع قنوات اللون، بما في ذلك الألفا. عيّن `grow` إلى `true` عندما قد يمتد الحافة الضبابية خارج حدود الصورة الأصلية.

للحصول على شفافية موحدة، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). فهو يضرب كل قيمة ألفا موجودة، لذا تبقى البيكسلات شبه الشفافة بنسب متفاوتة. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) يعيّن قيمة ألفا واحدة لكل البيكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) يحول الألفا إلى مستويين بناءً على عتبة.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

عمليات ألفا بدون معلمات تشمل [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) الذي يجعل كل ألفا غير صفرية معتمة تماماً؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) الذي يجعل كل ألفا أدنى من 100 % شفافة تماماً؛ و[addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) الذي يغيّر الألفا إلى `100% - alpha`.

## **إنشاء سلسلة تأثير مرتبة**

كل طريقة `add...Effect` تضيف عملية جديدة إلى نهاية المجموعة. يستخدم المرسِّخ المجموعة كخط أنابيب مرتب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، نفس العمليات بترتيب مختلف قد تنتج صورة مختلفة.

على سبيل المثال، تطبيق تدرج رمادي ثم تلوين يزيل المعلومات اللونية أولاً ثم يعيد تلوين نتيجة الإضاءة. تطبيق تلوين ثم تدرج رمادي يزيل التلوين مرة أخرى. بالمثل، استبدال ألفا يمكن أن يتجاوز قيم الألفا التي حسبتها عمليات سابقة، بينما تعديل ألفا يحافظ على الفروق النسبية بينها.

المثال التالي يبني سلسلة مكوّنة من أربع عمليات، يحفظها كـ PPTX، يعيد فتح العرض، يتحقق من أنواع العمليات وترتيبها، ثم يرسم النتيجة المعاد فتحها:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

المجموعة لا تفرض مصفوفة توافق تقيد العمليات اللونية، الألفا، والضبابية إلى سلاسل منفصلة. يمكن دمجها، لكن الدمج ليس دائماً مفيداً. استبدال لون ثابت يزيل تباين RGB الناتج عن تأثيرات لونية سابقة؛ تدرج رمادي بعد ثنائي اللون يزيل اللونين المختارين؛ وعمليات ألفا السقيفة، الأرضية، الاستبدال، أو ذات المستويين يمكن أن تتجاهل تفاصيل الألفا التي أُنشئت سابقاً. ابنِ السلسلة وفق التسلسل المطلوب لمعالجة البيكسل بدلاً من اعتبار عناصرها كأعلام تنسيق غير مرتبة.


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*في هذا العرض التوضيحي لـ Aspose.Slides for .NET 26.11، تلوين 220° بنسبة 25 % لا يغيّر صورة التدرج الرمادي. تطبيق نفس التلوين قبل التدرج الرمادي ينتج نغمات مختلفة.*
<!-- visual-explanation:image-transform-effects:end -->

## **فحص القيم القابلة للتحرير والفعّالة**

العملية القابلة للتحرير هي الكائن المخزن في `ISlidesPicture.getImageTransform`. بناءً على التأثير، قد تعرض أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) ي exposición `radius` و `grow` القابلين للكتابة، [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) ي exposición `amount` القابل للكتابة، و[IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) ي exposición `threshold` القابل للكتابة. تأثيرات اللون مثل [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) تعرض كائنات [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) قابلة للتعديل.

بعض واجهات العملية، بما في ذلك [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/), و[IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), لا تعرض القيم العددية التي أُنشئت كخصائص قابلة للكتابة. لتغيير تلك الإعدادات، احذف العملية وأضف بديلة في الموقع المطلوب.

البيانات الفعّالة التي تُرجعها `getEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل الألوان المعتمدة على السمة وقراءة القيم المُطَبَّقة التي يستخدمها المرسِّخ، لكنها ليست سطح تحرير آخر. المثال التالي يعدد السلسلة ويفحص القيم الفعّالة حيث توفر الواجهة المقابلة تلك المعلومات:

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

التأثيرات بدون معلمات مثل تدرج الرمادي، سقيف الألفا، والعكس الألفا لا يزال لديها كائن بيانات فعّالة، لكن لا توجد إعدادات عددية للطباعة. وجودها وموقعها في المجموعة هو المعلومات المهمة.

## **إزالة أو مسح عمليات تحويل الصورة**

استخدم [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) لإزالة عملية واحدة بحسب الفهرس. لأن الفهارس تتغيّر بعد الإزالة، ابحث عن الهدف أولاً وأزله بعد التعداد. استخدم [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) لإزالة السلسلة بأكملها.

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

إزالة أو مسح التحويلات يغيّر فقط تنسيق الصورة. لا يحذف، يعيد ضغط، أو يغيّر مصدر الصورة [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) الذي يُعاد استخدامه.

## **مراعاة تنسيقات العرض وأهداف التصدير**

تُولد تحويلات الصورة في DrawingML، لذا فإن PPTX هو التنسيق القابل للتحرير المفضّل لسلاسل التأثير. حتى مع PPTX، ليست كل عملية لها قابلية نقل متساوية:

- عمليات DrawingML القياسية مثل الإضاءة، تدرج الرمادي، ثنائي اللون، التلوين، HSL، الضبابية، والعمليات الألفا الشائعة لديها أفضل فرصة للبقاء بعد جولة PPTX. أعد دائماً فتح الملف المُولد وافحص المجموعة عندما تكون المحافظة مطلباً.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) هو امتداد Office 2010 وليس عملية إضاءة DrawingML القياسية. يمكن استخدامه للتصوير داخل الذاكرة، لكنه غير مضمون أن يبقى كـ [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) قابل للتحرير بعد حفظ وإعادة فتح PPTX. فضّل [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) لضبط السطوع والتباين المستمر.
- تنسيق PPT الثنائي يسبق نموذج تأثير DrawingML الكامل. الحفظ إلى PPT قد يحذف عمليات غير مدعومة، يقلل السلسلة إلى مجموعة فرعية مدعومة، أو يقرب المظهر. لا تستخدم PPT كتنسيق تحقق لسلسلة تحريرية معقّدة.
- التصوير إلى PNG، JPEG، TIFF، PDF، SVG، HTML، أو أي مخرج بصري آخر يطبق السلسلة المدعومة على المظهر المرسوم. تلك المخرجات لا تحتوي على `IImageTransformOperationCollection` قابل للتحرير؛ صيغ الرسوم النقطية تسطّح النتيجة إلى بيكسلات، والصادرات المستندية/الفيكتورية تخزن تمثيلها الخاص للعرض.
- التأثيرات لا تجعل الصورة المرتبطة ذاتية المحتوى. تصوير صورة مرتبطة ما زال يعتمد على توفر المورد المرتبط عند تحميل العرض.

مستهلكو العروض المختلفون قد يعرضون الحالات الحدّية بطرق مختلفة، خاصةً عندما تُدمج عدة عمليات ألفا أو تكميم ألوان. للنتائج الحرجة، اختبر كلً من جولة التحرير النهائية وتنسيق التصدير النهائي باستخدام نفس إصدار Aspose.Slides المستخدم في الإنتاج.

## **الأسئلة المتكررة**

**هل تؤثر تأثيرات تحويل الصورة على بيانات الصورة المضمّنة؟**

لا. العمليات تندرج تحت `ISlidesPicture` المستخدمة في تعبئة الصورة. بايتات `IPPImage` الأساسية تبقى دون تغيير.

**هل سيشارك إطاري صورة يستخدمان نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `IPPImage` يتجنّب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يمتلك `ISlidesPicture` ومجموعة تحويل منفصلة.

**هل يمكن دمج تأثيرات اللون، الضبابية، والألفا؟**

نعم. المجموعة تقبلها في سلسلة مرتبة واحدة. فكر في ما تفعله كل عملية على ناتج العملية السابقة لأن عمليات الاستبدال والعتبة قد تزيل تفاصيل لون أو ألفا سابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة في العرض، بما في ذلك الألوان التي تم حلّها. عدّل العملية المخزّنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلة بمعلمات إنشاء جديدة.

**أي تنسيق يجب استخدمه للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتأكد من الملف بإعادة فتحه. PPT القديم لا يمكنه تمثيل نموذج تأثير DrawingML الكامل، وصيغ التصدير النهائية تحتفظ بالمظهر فقط دون عمليات تحويل قابلة للتحرير.