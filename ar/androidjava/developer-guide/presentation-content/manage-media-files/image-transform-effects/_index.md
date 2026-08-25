---
title: إدارة تأثيرات تحويل الصور في العروض التقديمية على Android
linktitle: تأثيرات تحويل الصور
type: docs
weight: 11
url: /ar/androidjava/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- تدرج رمادي
- ثنائي اللون
- صبغ
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
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصورة باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

يمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [ISlidesPicture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidespicture/) وتابع إلى [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). المجموعة المرتجعة من نوع [IImageTransformOperationCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/) تسمح لك بإضافة، تعداد، فحص، إزالة، وتصفية التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

توضح هذه المقالة سير عمل كامل للسطوع والتباين، تحويلات الألوان، التشويش، الشفافية، سلاسل التأثير المرتبة، القيم الفعلية، الإزالة، والتحقق من دورة حياة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مصدر الصورة والصورة التي تعرضها كائنات مختلفة:

- [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) يخزن أو يشير إلى بيانات الصورة الأصلية التي تملكها العروض.
- [ISlidesPicture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidespicture/) ينتمي إلى تعبئة صورة ويشير إلى مورد صورة مع تخزين مجموعة تحويل الصورة.
- [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) هو شكل الشريحة الذي يمتلك التعبئة ذات الصلة، الهندسة، إعدادات القص، وتنسيق الإطار.

لذلك لا تقوم عمليات تحويل الصورة بتعديل بايتات [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/). عندما يتم تمرير نفس `IPPImage` إلى [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) أكثر من مرة، يحصل كل إطار صورة جديد على `ISlidesPicture` خاص به ومجموعة تحويل خاصة به. تطبيق اللون الرمادي على إطار واحد لا يجعل الأطر الأخرى رمادية، رغم أن جميعها يعيد استخدام نفس مورد الصورة المضمّن.

نموذج `ISlidesPicture.getImageTransform` نفسه يستخدمه تعبئات صور أخرى، مثل شكل أو خلفية شريحة. تركز الأمثلة أدناه على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعلمات**

الطرق الموضحة تستخدم النطاقات الدلالية والوحدات التالية. احتفظ بالقيم ضمن هذه النطاقات حتى لو لم ترفض نسخة المكتبة الحالية القيم غير الصالحة مباشرة؛ قد يقوم تنسيق العرض المستهدف بتطبيع أو حذف أو رفض البيانات غير الصالحة أثناء الحفظ أو عند فتح الملف في PowerPoint.

| العملية | المعلمات | النطاق وال وحدة الصالحة |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | لا شيء | لا توجد معلمات رقمية. قيمة ألفا تبقى دون تعديل. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | لونان للبكسلات الداكنة والفاتحة. قيم قنوات RGB وألفا المستخدمة بواسطة `android.graphics.Color` تتراوح من `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | درجة اللون من `0` بما فيها إلى `360` غير شاملة، بالدرجات؛ الكمية من `-100` إلى `100`، نسبة مئوية. |
| [addHSLEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | درجة اللون من `0` بما فيها إلى `360` غير شاملة، بالدرجات؛ التشبع والسطوع من `-100` إلى `100`، نسبة مئوية. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | اللون البديل يستخدم قيم القنوات من `0` إلى `255`. قيم ألفا الحالية تبقى دون تعديل. |
| [addBlurEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | نصف القطر غير سالب ويقاس بالنقاط؛ `grow` هو قيمة منطقية تتحكم فيما إذا كان المحتوى المشوش قد يمتد خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادي: `0` يعني شفافية كاملة و`100` يحافظ على قيمة ألفا الحالية. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` إلى `100`، نسبة مئوية للشفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` إلى `100`، نسبة مئوية لعتبة ألفا. القيم أقل من العتبة تصبح شفافة؛ القيم مساوية أو أعلى تصبح غير شفافة. |

للتعديل الثابت لألفا، الشفافية والعتامة متكاملتان. على سبيل المثال، الشفافية بنسبة 35% تعادل مقدار تعديل ألفا بنسبة 65%.

## **تطبيق السطوع والتباين**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) يُعيد عملية من نوع [IBrightnessContrast](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibrightnesscontrast/). تُحدد الإعدادات العددية عند إنشاء العملية. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) يُعيد قيمًا محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

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

[BrightnessContrast](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/brightnesscontrast/) هو امتداد لتأثيرات الصور في Office 2010 وأقل قابلية للنقل مقارنة بتأثير اللمعان القياسي في DrawingML. عندما يجب أن يظل السطوع والتباين قابلة للتحرير بعد دورة PPTX، استخدم [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) وتحقق من النتيجة بعد إعادة فتح الملف. يشرح قسم قيود الصيغة هذا الاختلاف بمزيد من التفصيل.

## **تطبيق تحويلات الألوان**

يمكن تطبيق تأثيرات الألوان بشكل مستقل على إطارات صور مختلفة تعيد استخدام نفس مورد الصورة. المثال التالي ينشئ خمس إطارات ويطبق اللون الرمادي، الثنائي اللون، الصبغ، تعديل HSL، واستبدال اللون.

[IDuotone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iduotone/) يحتوي على معلمتين لونيين قابلتين للتحرير بشكل مستقل: `color1` للبيكسلات الداكنة، و`color2` للبيكسلات الفاتحة. هذا يجعلها مثالًا مفيدًا لتأثير إعداداته أكثر تعقيدًا من قيمة عددية واحدة.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) يستبدل كل بكسل بلون ثابت مع الحفاظ على ألفا. وهو مختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) الذي يطابق لون مصدر بلون هدف ويظهر صيغتي اللون المصدر والهدف.

## **إضافة تشويش، شفافية، وتأثيرات ألفا**

[addBlurEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) يؤثر على جميع القنوات اللونية، بما فيها ألفا. اضبط `grow` إلى `true` عندما قد يمتد الحد المشوش خارج حدود الصورة الأصلية.

لشفافية ثابتة، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). إنه يضرب كل قيمة ألفا موجودة، لذا تبقى البكسلات نصف شفافة متفاوتة نسبيًا. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) يعيّن قيمة ألفا واحدة لجميع البكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) يحوّل ألفا إلى مستويين بناءً على عتبة.

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

تشمل عمليات ألفا الأخرى الخالية من المعلمات [addAlphaCeilingEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) الذي يجعل كل قيمة ألفا غير صفرية غير شفافة تمامًا؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) الذي يجعل كل ألفا أقل من 100% شفافة تمامًا؛ و[addAlphaInverseEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) الذي يغيّر ألفا إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `add...Effect` تُضيف عملية جديدة إلى نهاية المجموعة. يستخدم المُظهر المجموعة كخط أنابيب مرتب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، قد تنتج نفس العمليات بترتيب مختلف صورة مختلفة.

على سبيل المثال، تطبيق اللون الرمادي ثم الصبغ يزيل أولاً المعلومات اللونية ثم يعيد تلوين النتيجة اللمعية. الصبغ ثم اللون الرمادي يزيل الصبغ مرة أخرى. بالمثل، استبدال ألفا يمكن أن يتجاوز قيم ألفا التي حسبتها عمليات سابقة، بينما تعديل ألفا يحافظ على الفروقات النسبية بينها.

المثال التالي يبني سلسلة من أربع عمليات، يحفظها كملف PPTX، يفتح العرض مرة أخرى، يتحقق من نوعية العمليات وترتيبها، ويعرض النتيجة المعاد فتحها:

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

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، ألفا، والتشويش لتكون في سلاسل منفصلة. يمكن دمجها، لكن الدمج ليس دائمًا مفيدًا. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات لونية سابقة؛ اللون الرمادي بعد الثنائي اللون يزيل اللونين المحددين؛ وعمليات ألفا السقيفة، القاعية، الاستبدال أو الثنوية قد تتخلص من تفاصيل ألفا التي أنشئت سابقًا. ابنِ السلسلة وفقًا لتسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها كأعلام تنسيق غير مرتبة.

## **فحص القيم القابلة للتحرير والفعّالة**

العملية القابلة للتحرير هي الكائن المخزّن في `ISlidesPicture.getImageTransform`. اعتمادًا على التأثير، قد يُظهر أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [IBlur](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iblur/) يُظهر قيم `radius` و `grow` القابلة للكتابة، [IAlphaModulateFixed](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ialphamodulatefixed/) يُظهر `amount` القابل للكتابة، و[IAlphaBiLevel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ialphabilevel/) يُظهر `threshold` القابل للكتابة. توجهات اللون مثل [IDuotone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iduotone/) تُظهر كائنات [IColorFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icolorformat/) قابلة للتغيير.

بعض واجهات العمليات، بما فيها [IBrightnessContrast](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihsl/)، [ITint](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itint/)، و[IAlphaReplace](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ialphareplace/)، لا تُظهر القيم العددية لإنشائها كخصائص قابلة للكتابة. لتغيير تلك الإعدادات، احذف العملية وأضف بديلًا في الموضع المطلوب.

البيانات الفعلية التي تُعيدها `getEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لتحديد الألوان المعتمدة على السمة وقراءة القيم الطبيعية التي يستخدمها المُظهر، لكنها ليست سطح تحرير آخر. المثال التالي يعدد السلسلة ويفحص القيم الفعلية حيث توفر API ذلك:

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

التأثيرات الخالية من المعلمات مثل اللون الرمادي، السقيفة، والعكس لا يزال لديها كائن بيانات فعّال، لكن لا توجد إعدادات عددية لطبعها. وجودها وموقعها في المجموعة هو ما يهم.

## **إزالة أو مسح تحويلات الصورة**

استخدم [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) لإزالة عملية واحدة بحسب الفهرس. لأن الفهارس تتshift بعد الإزالة، ابحث عن الهدف أولًا ثم احذفه بعد التعداد. استخدم [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) لإزالة السلسلة الكاملة.

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

إزالة أو مسح التحويلات يغيّر فقط تنسيق الصورة. لا يحذف، ولا يُعيد ضغط، ولا يغير مصدر [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) المعاد استخدامه.

## **مراعاة صيغ العروض وأهداف التصدير**

تبدأ تحويلات الصورة في DrawingML، لذا يُفضَّل استخدام PPTX كصيغة قابلة للتحرير لسلاسل التأثير. حتى مع PPTX، ليست كل عملية لها قابلية نقل متساوية:

- عمليات DrawingML القياسية مثل اللمعان، اللون الرمادي، الثنائي اللون، الصبغ، HSL، التشويش، والعمليات الشائعة للألفا لديها أفضل فرصة للبقاء بعد دورة PPTX. دائمًا أعد فتح الملف المُنتج وتفقد المجموعة عندما يكون الحفاظ مطلوبًا.
- [BrightnessContrast](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/brightnesscontrast/) هو امتداد Office 2010 وليس عملية اللمعان القياسية في DrawingML. يمكن استخدامه للعرض في الذاكرة، لكنه غير مضمون أن يبقى كـ[IBrightnessContrast](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibrightnesscontrast/) قابل للتحرير بعد الحفظ وإعادة الفتح. فضلًا عن ذلك استخدم [addLuminanceEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) لتعديلات السطوع والتباين المستمرة.
- صيغة PPT الثنائية سابقة لنموذج تأثير DrawingML الكامل. قد يحذف حفظ إلى PPT عمليات غير مدعومة، يقلّل السلسلة إلى مجموعة فرعية مدعومة، أو يقرّب المظهر. لا تستخدم PPT كصيغة تحقق لسلسلة تحريرية معقدة.
- التصدير إلى PNG أو JPEG أو TIFF أو PDF أو SVG أو HTML أو أي مخرج بصري آخر يطبق السلسلة المدعومة على النتيجة المرئية. هذه المخرجات لا تحتوي على [IImageTransformOperationCollection] قابلة للتحرير؛ تنسيق الرستر يسطّح النتيجة إلى بكسلات، وتصديرات المستند/الفيكتور تخزن تمثيلها الخاص للعرض.
- التأثيرات لا تجعل الصورة المرتبطة مستقلة. لا يزال عرض صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض.

قد يعرض مستهلكو العروض المختلفون الحالات الحدية بطرق مختلفة، خاصة عندما تُدمج عدة عمليات ألفا أو تكميم الألوان. للنتائج الحرجة، اختبر كلًا من دورة التحرير النهائية وتنسيق التصدير النهائي باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة الشائعة**

**هل تعدل تأثيرات تحويل الصورة بيانات الصورة المضمّنة؟**

لا. العمليات تنتمي إلى `ISlidesPicture` المستخدمة في تعبئة الصورة. تظل بايتات `IPPImage` الأساسية دون تغيير.

**هل تشارك إطاري صور يعيدان استخدام نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `IPPImage` تُجنب تكرار بيانات الصورة، لكن كل إطار صورة يكون عادةً لديه `ISlidesPicture` منفصل ومجموعة تحويل منفصلة.

**هل يمكن دمج تأثيرات اللون، التشويش، والألفا؟**

نعم. تقبل المجموعة دمجها في سلسلة واحدة مرتبة. تأمل ما يفعله كل عملية على ناتج السابقة لأن عمليات الاستبدال والعتبة قد تُزيل تفاصيل اللون أو الألفا السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

تمثل البيانات الفعّالة القيم المحسوبة المستخدمة في العرض، بما فيها الألوان المُحلّلة. عدِّل العملية المخزّنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلًا بمعلمات إنشاء جديدة.

**ما الصيغة التي يجب استخدامها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن لصيغة PPT القديمة تمثيل نموذج تأثير DrawingML الكامل، وتُحافظ صيغ التصدير المرئية على المظهر فقط دون عمليات تحويل قابلة للتحرير.