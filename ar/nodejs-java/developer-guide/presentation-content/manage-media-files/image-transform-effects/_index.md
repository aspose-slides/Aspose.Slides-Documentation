---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام JavaScript
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/nodejs-java/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- تدرج رمادي
- ثنائي اللون
- تلون
- HSL
- استبدال اللون
- ضبابية
- شفافية
- تأثير ألفا
- سلسلة التأثير
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصورة باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

Aspose.Slides تمثّل تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/) الخاص بالإطار واحصل على [Picture.getImageTransform](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/). المجموعة المرجعية [ImageTransformOperationCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) التي تُعاد لك تتيح لك إلحاق، تعداد، فحص، إزالة، وتصفية التأثيرات دون الحاجة إلى إعادة كتابة بايتات الصورة الأصلية.

توضح هذه المقالة سير عمل كامل للسطوع والتباين، تحويلات اللون، الضبابية، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

موارد الصورة والصورة التي تعرضها كائنات مختلفة:

- [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) يخزن أو يشير إلى بيانات الصورة المصدرية المملوكة للعرض.
- [Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/) ينتمي إلى تعبئة الصورة ويشير إلى مورد صورة مع حفظ مجموعة تحويل الصورة.
- [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) هو شكل الشريحة الذي يمتلك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القص، وتنسيق مستوى الإطار الآخر.

لذلك، عمليات تحويل الصورة لا تُعدّل البايتات في [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/). عندما يتم تمرير نفس [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) إلى [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/) أكثر من مرة، يحصل كل إطار صورة جديد على [Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/) خاص به ومجموعة تحويل خاصة به. تطبيق تدرج الرمادي على إطار واحد لا يجعل الإطارات الأخرى رمادية، رغم أن جميعها يعيد استخدام نفس مورد الصورة المدمج.

نموذج [Picture.getImageTransform](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/) يُستخدم أيضاً من قبل تعبئات صور أخرى، مثل شكل أو خلفية شريحة. تركز الأمثلة أدناه على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعلمات**

الطرق الموضحة تستخدم النطاقات الدلالية والوحدات التالية. احتفظ بالقيم ضمن هذه النطاقات حتى لو لم ترفض نسخة المكتبة الحالية القيم غير الصالحة على الفور؛ قد يقوم تنسيق العرض الهدف بتطبيع أو حذف أو رفض البيانات غير الصالحة أثناء الحفظ أو عند فتح PowerPoint للملف.

| العملية | المعلمات | النطاق والوحدة الصالحة |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` إلى `100`،٪؛ `0` يترك المكوّن دون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | لا شيء | لا توجد معلمات رقمية. لا يتغيّر ألفا. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | لونان للبيكسلات الداكنة والفاتحة. القنوات RGB و alpha في `java.awt.Color` تتراوح بين `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ `amount` من `-100` إلى `100`،٪. |
| [addHSLEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ `saturation` و `luminance` من `-100` إلى `100`،٪. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | لون الاستبدال يستخدم قيم القنوات من `0` إلى `255`. قيم ألفا الحالية لا تُغيّر. |
| [addBlurEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | `radius` غير سالب ويقاس بالنقاط؛ `grow` قيمة Boolean تتحكم فيما إذا كان المحتوى الضبابي قد يمتد خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادي: `0` شفافية كاملة و `100` يحافظ على ألفا الحالي. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` إلى `100`،٪ شفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` إلى `100`،٪ عتبة ألفا. القيم الأقل تصبح شفافة؛ القيم عند أو فوق العتبة تصبح معتمة. |

للتحكم الثابت في تعديل الألفا، الشفافية والعتامة متكاملتان. مثال: شفافية 35٪ تعادل تعديل ألفا بقيمة 65٪.

## **تطبيق السطوع والتباين**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) يُعيد عملية [BrightnessContrast](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/brightnesscontrast/). تُحدد الإعدادات القياسية عند إنشاء العملية. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/brightnesscontrast/) تُعيد قيماً محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15٪ والتباين بنسبة 20٪، ثم يعرض معاينة دون تعديل الصورة المدمجة:

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

[BrightnessContrast](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/brightnesscontrast/) هو امتداد تأثير صورة Office 2010 وأقل قابلية للنقل مقارنةً بتأثير luminance القياسي في DrawingML. عندما يجب أن تبقى قيم السطوع والتباين قابلة للتحرير بعد جولة PPTX، استخدم [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) وتحقق من النتيجة بعد إعادة فتح الملف. يشرح قسم قيود التنسيق هذا الفرق بمزيد من التفاصيل.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تُعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمسة إطارات ويطبق تدرج الرمادي، duotone، tint، تعديل HSL، واستبدال اللون.

[Duotone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/duotone/) يحتوي على معلمتين لونيتين يمكن تعديلهما بشكل مستقل: `color1` يطابق البيكسلات الداكنة، بينما `color2` يطابق البيكسلات الفاتحة. هذا يجعلها مثالاً مفيداً لتأثير إعداداته أكثر تعقيداً من قيمة قياسية واحدة.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) يستبدل كل لون بيكسل بلون ثابت واحد مع الحفاظ على ألفا. يختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/)، الذي يطابق لون مصدر بلون هدف ويُظهر كلا تنسيقَي اللون المصدر والهدف.

## **إضافة تأثيرات الضبابية والشفافية والألفا**

[addBlurEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) يؤثر على جميع قنوات اللون، بما فيها ألفا. عيّن `grow` إلى `true` عندما قد يمتد الحافة الضبابية خارج حدود الصورة الأصلية.

لشفافية موحدة، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/). يضرب كل قيمة ألفا موجودة، لذا يبقى البكسل شبه شفاف بنسب متفاوتة. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) يعيّن قيمة ألفا واحدة لكل البكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) يحول ألفا إلى مستويين استناداً إلى عتبة.

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

تشمل عمليات ألفا الأخرى غير المعتمدة على معلمات [addAlphaCeilingEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/)، التي تجعل كل ألفا غير صفرية غير شفافة بالكامل؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/)، التي تجعل كل ألفا أقل من 100٪ شفافة بالكامل؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/)، التي تغيّر ألفا إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `add...Effect` تُلحق عملية جديدة إلى نهاية المجموعة. يستخدم المُصيّر المجموعة كسلسلة مرتبة: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، قد تُنتج نفس العمليات بترتيب مختلف صورة مختلفة.

على سبيل المثال، تدرج الرمادي متبوعاً بـ tint يزيل أولاً المعلومات اللونية ثم يُعيد تلوين النتيجة اللونية. tint متبوعاً بـ grayscale يزيل tint مرة أخرى. وبالمثل، يمكن لاستبدال ألفا أن يتجاوز قيم ألفا التي حسبتها عمليات سابقة، بينما يحافظ تعديل ألفا على الفروقات النسبية بينها.

المثال التالي يبني سلسلة مكوّنة من أربع عمليات، يحفظها كـ PPTX، يعيد فتح العرض، يتحقق من كلا نوعي العملية وترتيبهما، ويُصيّر النتيجة المعاد فتحها:

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

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، الألفا، والضبابية بسلاسل منفصلة. يمكن دمجها، لكن ليست كل التركيبات مفيدة. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات اللون السابقة؛ تدرج الرمادي بعد duotone يزيل اللونين المختارين؛ وعملية سقف، أرضية، أو استبدال ألفا أو ثنائية المستوى قد تُزيل تفاصيل ألفا التي أُنشئت سابقاً. ابنِ السلسلة وفق تسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها علامات تنسيق غير مرتبة.

## **فحص القيم القابلة للتحرير والفعّالة**

العملية القابلة للتحرير هي الكائن المخزن في [Picture.getImageTransform](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/). بحسب التأثير، قد تُظهر أعضاء قابلة للكتابة مباشرة. مثال: [Blur](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/blur/) يُظهر قيم `radius` و `grow` القابلة للكتابة، [AlphaModulateFixed](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/alphamodulatefixed/) يُظهر `amount` القابل للكتابة، و [AlphaBiLevel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/alphabilevel/) يُظهر `threshold` القابل للكتابة. تأثيرات اللون مثل [Duotone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/duotone/) تُظهر كائنات [ColorFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/colorformat/) قابلة للتعديل.

بعض العمليات، بما فيها [BrightnessContrast](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tint/), و [AlphaReplace](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/alphareplace/)، لا تُظهر معاملات الإنشاء كخصائص قابلة للكتابة. لتغيير هذه الإعدادات، احذف العملية وأضف بديلة في الموضع المطلوب.

البيانات الفعّالة التي تُعيدها `getEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل ألوان الموضوع وقراءة القيم المُعيرة التي يستخدمها المُصيّر، لكنها ليست سطح تحرير آخر. المثال التالي يعدد السلسلة ويفحص القيم الفعّالة حيث توفر API ما لها:

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

التأثيرات غير المعتمدة على معلمات مثل grayscale، سقف ألفا، والعكس لا يزال لها كائن بيانات فعّالية، لكن لا توجد إعدادات قياسية لطباعة. وجودها وموقعها في المجموعة هو المعلومات المهمّة.

## **إزالة أو تصفية تحويلات الصورة**

استخدم [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) لإزالة عملية واحدة بحسب الفهرس. لأن الفهارس تتغير بعد الإزالة، ابحث عن الهدف أولاً وأزِلّه بعد العد. استخدم [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) لإزالة السلسلة بأكملها.

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

إزالة أو تصفية التحويلات تُغيّر تنسيق الصورة فقط. لا تحذف، ولا تعيد ضغط، ولا تُغيّر مورد [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) المُعاد استخدامه.

## **اعتبار تنسيقات العرض وأهداف التصدير**

تنشأ تحويلات الصورة في DrawingML، لذلك يُفضَّل تنسيق PPTX القابل للتحرير لسلاسل التأثير. حتى مع PPTX، ليست كل عملية لها قابلية نقل متساوية:

- العمليات القياسية في DrawingML مثل luminance، grayscale، duotone، tint، HSL، blur، والعمليات الشائعة للألفا لديها أفضل فرصة للبقاء بعد جولة PPTX. أعد دائمًا فتح الملف المُنشأ وتفقد المجموعة عندما تكون المحافظة مطلوبة.
- [BrightnessContrast](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/brightnesscontrast/) هو امتداد Office 2010 وليس عملية luminance القياسية في DrawingML. يمكن استخدامه للتصيير داخل الذاكرة، لكنه ليس مضمونًا أن يبقى عملية [BrightnessContrast](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/brightnesscontrast/) قابلة للتحرير بعد حفظ وإعادة فتح PPTX. فضلًا عن ذلك استخدم [addLuminanceEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) لتعديلات سطوع وتباين مستديمة.
- تنسيق PPT الثنائي قديم قبل نموذج تأثير DrawingML الكامل. الحفظ إلى PPT قد يُحذف عمليات غير مدعومة، أو يقلل السلسلة إلى مجموعة فرعية مدعومة، أو يقترب من الشكل. لا تستخدم PPT كتنسيق تحقق لسلسلة تحريرية معقّدة.
- التصيير إلى PNG، JPEG، TIFF، PDF، SVG، HTML أو مخرجات بصرية أخرى يطبق السلسلة المدعومة على المظهر المصوَّر. هذه المخرجات لا تحتوي على [ImageTransformOperationCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagetransformoperationcollection/) قابل للتحرير؛ تنسيقات الرستر تُسطّح النتيجة إلى بكسلات، وتصديرات المستند/الفيكتور تخزن تمثيلها الخاص للتصيير.
- التأثيرات لا تجعل الصورة المرتبطة ذاتية المحتوى. تصيير صورة مرتبطة لا يزال يعتمد على توفر المورد المرتبط عند تحميل العرض.

قد يقوم مستهلكو العروض المختلفون بتصيير الحالات الحدّية بطرق مختلفة، خاصةً عند دمج عدة عمليات ألفا أو تكميم لون. للنتائج الحرجة، اختبر كلًّا من جولة التحرير النهائية وتنسيق التصدير النهائي باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة الشائعة**

**هل تُعدّل تأثيرات تحويل الصورة بيانات الصورة المدمجة؟**

لا. العمليات تنتمي إلى الـ [Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/) المستخدم في تعبئة الصورة. بايتات الـ [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) الأساسية تظل دون تغيير.

**هل تُشارك إطاري صورة يستخدمان نفس المورد الصورة تأثيراتهما؟**

لا. إعادة استخدام [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) يتجنّب تكرار بيانات الصورة، لكن كل إطار صورة يمتلك عادةً [Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/) ومجموعة تحويل خاصة به.

**هل يمكن دمج تأثيرات اللون والضبابية والألفا؟**

نعم. المجموعة تقبلها في سلسلة مرتبة واحدة. فكر فيما تفعله كل عملية على مخرجات العملية السابقة لأن عمليات الاستبدال والعتبة قد تُزيل تفاصيل لونية أو ألفا سابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل قيمًا مُحسوبة تُستَخدم في التصيير، بما فيها الألوان التي تم حلّها. حرّر العملية المخزنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلة بمعلمات الإنشاء الجديدة.

**أي تنسيق ينبغي استخدامه للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. تنسيق PPT القديم لا يستطيع تمثيل نموذج تأثير DrawingML الكامل، وتنسيقات التصدير المصورة تُحافظ على المظهر فقط دون عمليات تحويل قابلة للتحرير.