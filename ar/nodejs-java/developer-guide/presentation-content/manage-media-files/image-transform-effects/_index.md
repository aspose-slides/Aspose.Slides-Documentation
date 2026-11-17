---
title: إدارة تأثيرات تحويل الصور في العروض التقديمية باستخدام JavaScript
linktitle: تأثيرات تحويل الصور
type: docs
weight: 11
url: /ar/nodejs-java/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- السطوع
- التباين
- تدرج رمادي
- دوتون
- صبغ
- HSL
- استبدال اللون
- ضبابية
- شفافية
- تأثير ألفا
- سلسلة تأثير
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصور لإطارات الصور باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

يمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) الخاص بالإطار وادخل إلى [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). تسمح لك مجموعة [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) التي يتم إرجاعها بإضافة، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

تُظهر هذه المقالة سير عمل كامل للسطوع والتباين، تحويلات اللون، الضبابية، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من صحة جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مورد الصورة والصورة التي تعرضها كائنات مختلفة:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) يخزن أو يشير إلى بيانات الصورة المصدر التي تملكها العرض التقديمي.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) ينتمي إلى تعبئة صورة ويشير إلى مورد صورة مع تخزين مجموعة تحويل الصورة.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) هو شكل الشريحة الذي يملك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القص، وتنسيق المستوى الإطاري الآخر.

لذلك، لا تقوم عمليات تحويل الصورة بتعديل البايتات في [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/). عندما يتم تمرير نفس [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) إلى [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) أكثر من مرة، يحصل كل إطار صورة جديد على [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) خاص به ومجموعة تحويل خاصة به. تطبيق التدرج الرمادي على إطار واحد لا يجعل الإطارات الأخرى تدرجًا رماديًا، رغم أن جميعها يعيد استخدام نفس مورد الصورة المضمّن.

نموذج [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) يُستخدم أيضًا من قبل تعبئات الصور الأخرى، مثل الشكل أو خلفية الشريحة. تركز الأمثلة أدناه على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعاملات**

تستخدم الطرق الموضحة النطاقات الدلالية والوحدات التالية. احتفظ بالقيم داخل هذه النطاقات حتى إذا لم يرفض إصدار مكتبة معين كل قيمة خارجة عن النطاق على الفور؛ قد يقوم تنسيق العرض المستهدف بعملية تطبيع أو حذف أو رفض البيانات غير الصالحة أثناء الحفظ أو عندما يفتح PowerPoint الملف.

| العملية | المعاملات | النطاق والوحدة الصالحة |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` إلى `100`، بالمائة؛ `0` يترك المكوّن دون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | لا شيء | لا توجد معاملات رقمية. يبقى Alpha دون تغيير. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | لونان للبيكسلات الداكنة والفاتحة. القنوات RGB وAlpha في `java.awt.Color` تستخدم `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue من `0` شامل إلى `360` غير شامل، بالدرجات؛ amount من `-100` إلى `100` بالمائة. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue من `0` شامل إلى `360` غير شامل، بالدرجات؛ saturation وluminance من `-100` إلى `100` بالمائة. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | يستخدم لون الاستبدال قيم القنوات من `0` إلى `255`. قيم Alpha الحالية تظل دون تغيير. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Radius غير سالب ويقاس بالنقاط؛ `grow` هو Boolean يتحكم فيما إذا كان المحتوى الضبابي قد يمتد خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادي: `0` شفاف بالكامل و`100` يحافظ على Alpha الحالي. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` إلى `100` بالمائة للشفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` إلى `100` بالمائة كعتبة Alpha. القيم الأقل تصبح شفافة؛ القيم التي تساوي العتبة أو تتجاوزها تصبح غير شفافة. |

بالنسبة لتعديل Alpha الثابت، الشفافية والعتامة متكاملتان. على سبيل المثال، الشفافية بنسبة 35% تعادل تعديل Alpha بنسبة 65%.

## **تطبيق السطوع والتباين**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) تُعيد عملية [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). تُزود الإعدادات القياسية عند إنشاء العملية. تُعيد [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) قيمًا محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15% والتباين بنسبة 20%، ثم يعرض معاينة دون تعديل الصورة المضمّنة:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) هو امتداد تأثير صورة Office 2010 وأقل محمولية من تأثير الإضاءة القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابلين للتعديل بعد جولة PPTX، استخدم [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) وتحقق من النتيجة بعد إعادة فتح الملف. يوضح قسم قيود الصيغة هذا التمييز بمزيد من التفصيل.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمسة إطارات ويطبق التدرج الرمادي، الدوتون، الصبغ، تعديل HSL، واستبدال اللون.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) يحتوي على معاملين لونيين يمكن تعديلهما بشكل مستقل: `color1` يطابق البيكسلات الداكنة، بينما `color2` يطابق البيكسلات الفاتحة. هذا يجعله مثالًا مفيدًا لتأثير إعداداته أكثر تعقيدًا من قيمة قياسية واحدة.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) يستبدل لون كل بيكسل بلون ثابت واحد مع الحفاظ على Alpha. وهو مختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)، الذي يطابق لون مصدر بلون هدف ويظهر صيغ اللون للمصدر والهدف.

### **تطبيق عتبة إضاءة**

يمكن أن تجعل عتبة الإضاءة العلامات الخفيفة على صفحة ممسوحة ضوئيًا أسهل للتمييز عن الخلفية. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) يحافظ على درجات الرمادي المتوسطة. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) يطابق الإضاءة إلى أسود أو أبيض، بينما [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) يطبق عتبة على العتامة.

تتراوح عتبة الإضاءة من 0% إلى 100% شاملًا. البيكسلات التي تقل عن العتبة تصبح سوداء. البيكسلات التي تساوي العتبة أو تتجاوزها تصبح بيضاء. رفع العتبة يجعل المزيد من الظلال سوداء لأن المزيد منها يقع تحت الحد.

حمّل [grayscale-swatches.png](grayscale-swatches.png) إلى دليل العمل. كل تسمية تعطي مستوى الرمادي الأصلي على مقياس من 0 إلى 255. يضع المثال الأصلي بجوار نسختين ويحفظ عتبة كل نسخة في العرض التقديمي.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

افتح العرض التقديمي الناتج في PowerPoint للمقارنة بين الإطارات الثلاثة. العينة ذات التسمية 96 لها تقريبًا 38% إضاءة (96 من 255). تتحول إلى أبيض عند عتبة 20% وإلى أسود عند عتبة 60%.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **إضافة الضبابية، الشفافية، وتأثيرات Alpha**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) يؤثر على جميع قنوات اللون، بما فيها Alpha. اضبط `grow` إلى `true` عندما قد يمتد الحافة الضبابية خارج حدود الصورة الأصلية.

لشفافية موحدة، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). فهو يضرب كل قيمة Alpha موجودة، لذا تظل البيكسلات شبه الشفافة نسبياً مختلفة. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) بدلاً من ذلك يخصص قيمة Alpha واحدة لجميع البيكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) يحول Alpha إلى مستويين بناءً على عتبة.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تشمل عمليات Alpha الخالية من المعاملات الأخرى [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)، التي تجعل كل Alpha غير صفري غير شفاف بالكامل؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)، التي تجعل كل Alpha أقل من 100% شفافًا بالكامل؛ و[addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)، التي تغير Alpha إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `add...Effect` تُضيف عملية جديدة إلى نهاية المجموعة. يستخدم المصرّف المجموعة كخط أنابيب مرتب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، قد تُنتج نفس العمليات بترتيب مختلف صورة مختلفة.

على سبيل المثال، التدرج الرمادي يليه الصبغ يزيل أولاً المعلومات اللونية ثم يعيد تلوين النتيجة الضوئية. الصبغ يليه التدرج الرمادي يزيل الصبغ مجددًا. بالمثل، استبدال Alpha يمكن أن يتجاوز قيم Alpha المحسوبة بواسطة عمليات سابقة، بينما تعديل Alpha يحافظ على اختلافاتها النسبية.

المثال التالي يبني سلسلة مكوّنة من أربع عمليات، يحفظها كـ PPTX، يعيد فتح العرض، يتحقق من نوعيات العمليات وترتيبها، ويظهر النتيجة المعاد فتحها:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، Alpha، والضبابية إلى سلاسل منفصلة. يمكن دمجها، لكن الجمع ليس دائمًا مفيدًا. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات لونية سابقة؛ التدرج الرمادي بعد الدوتون يزيل اللونين المختارين؛ وعملية السقف أو الأرضية أو الاستبدال أو الثنائية للـ Alpha يمكن أن تُهمل تفاصيل Alpha التي أُنشئت مسبقًا. ابنِ السلسلة وفقًا لتسلسل معالجة البيكسل المطلوب بدلاً من اعتبار عناصرها كعلامات تنسيق غير مرتبة.


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*في هذا التمثيل التوضيحي لـ Aspose.Slides for .NET 26.11، تركت صبغة 220° بنسبة 25% الصورة الرمادية دون تغيير. تطبيق نفس الصبغة قبل التحويل إلى رمادي ينتج ألوانًا مختلفة.*
<!-- visual-explanation:image-transform-effects:end -->

## **فحص القيم القابلة للتحرير والفعّالة**

العملية القابلة للتحرير هي الكائن المخزن في [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). بناءً على التأثير، قد تُظهر أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) يُظهر قيم `radius` و `grow` القابلة للكتابة، و[AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) يُظهر `amount` قابلًا للكتابة، و[AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) يُظهر `threshold` قابلًا للكتابة. تأثيرات اللون مثل [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) تُظهر كائنات [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) قابلة للتعديل.

بعض العمليات، بما في ذلك [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/)، [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/)، و[AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/)، لا تُظهر الثوابت الإنشائية كخصائص قابلة للكتابة. لتغيير تلك الإعدادات، احذف العملية وأضف بديلًا في الموضع المطلوب.

البيانات الفعّالة التي تُرجعها `getEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل الألوان المعتمدة على السمة وقراءة القيم المُعدَّلة التي يستخدمها المصرّف، لكنها ليست سطح تحرير آخر. المثال التالي يعدد السلسلة ويفحص القيم الفعّالة حيث تُوفر API ما لها:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

التأثيرات الخالية من المعاملات مثل التدرج الرمادي، السقف Alpha، والعكس Alpha لا يزال لها كائن بيانات فعّالة، لكن لا توجد إعدادات قياسية لطباعتها. وجودها وموقعها في المجموعة هو المعلومات المهمة.

## **إزالة أو مسح تحويلات الصورة**

استخدم [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) لإزالة عملية واحدة حسب الفهرس. نظرًا لأن الفهارس تتغير بعد الإزالة، ابحث عن الهدف أولًا ثم احذفه بعد التعداد. استخدم [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) لإزالة السلسلة بالكامل.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

إزالة أو مسح التحويلات يغيّر فقط تنسيق الصورة. لا يحذف، ولا يُعيد ضغط، ولا يغيّر مورد [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) المعاد استخدامه.

## **مراعاة صيغ العروض التقديمية وأهداف التصدير**

تنشأ تحويلات الصورة في DrawingML، لذا فإن PPTX هو الصيغة القابلة للتحرير المفضلة لسلاسل التأثير. حتى مع PPTX، ليس كل عملية لها قابلية نقل متطابقة:

- عمليات DrawingML القياسية مثل الإضاءة، التدرج الرمادي، الدوتون، الصبغ، HSL، الضبابية، والعمليات Alpha الشائعة لديها أفضل فرص للبقاء بعد جولة PPTX. أعد دائمًا فتح الملف المُنشأ وتفحص المجموعة عندما يكون الحفاظ مطلوبًا.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) هو امتداد Office 2010 وليس عملية الإضاءة القياسية في DrawingML. يمكن استخدامها للتصيّر في الذاكرة، لكنها غير مضمونة كعملية [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) قابلة للتحرير بعد حفظ وإعادة فتح PPTX. فضلًا استخدم [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) لتعديلات السطوع والتباين الدائمة.
- صيغ PPT الثنائية تسبق نموذج تأثير DrawingML الكامل. قد يحذف الحفظ إلى PPT عمليات غير مدعومة، أو يقلل السلسلة إلى مجموعة فرعية مدعومة، أو يُقرب المظهر. لا تستخدم PPT كصيغة للتحقق من سلسلة معقدة قابلة للتحرير.
- يُطبق التصدير إلى PNG أو JPEG أو TIFF أو PDF أو SVG أو HTML أو أي مخرج بصري آخر السلسلة المدعومة على المظهر المُصرّف. لا تحتوي تلك المخرجات على [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) قابل للتحرير؛ تنسيقات الصور الثابتة تُسطّح النتيجة إلى بيكسلات، وتصديرات المستند/الرسوم المتجهة تخزن تمثيلها الخاص للعرض.
- لا تجعل التأثيرات صورة مرتبطة ذاتيًا. لا يزال عرض صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض التقديمي.

قد يعرض مستهلكو العروض التقديمية المختلفون حالات الحافة بصورة مختلفة، خاصة عندما تُدمج عدة عمليات Alpha أو لون. للاختبارات الحرجة، اختبر كل من جولة التحرير النهائية وتنسيق التصدير النهائي باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة المتكررة**

**هل تعدّ تأثيرات تحويل الصورة بيانات الصورة المضمّنة؟**

لا. العمليات تنتمي إلى الـ [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) المستخدم في تعبئة الصورة. تبقى بايتات الـ [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) الأساسية دون تعديل.

**هل يشارك إطارا صورة يعيدان استخدام نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) يتجنب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يكون له [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) ومجموعة تحويل صورة منفصلة.

**هل يمكن دمج تأثيرات اللون، الضبابية، وAlpha؟**

نعم. تقبل المجموعة دمجها في سلسلة مرتبة واحدة. ضع في اعتبارك ما تفعله كل عملية على ناتج السابقة لأن عمليات الاستبدال والعتبة قد تُهمل تفاصيل اللون أو Alpha السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

تمثل البيانات الفعّالة القيم المحسوبة المستخدمة في التصيّر، بما فيها الألوان المحلولة. عدّل العملية المخزنة في مجموعة التحويل حيث تتوفر أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلًا بمعلمات إنشاء جديدة.

**أي صيغة يجب أن أستخدمها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن لصيغة PPT القديمة تمثيل نموذج تأثير DrawingML الكامل، وتُحافظ صيغ التصدير المرئية على المظهر فقط دون عمليات تحويل قابلة للتحرير.