---
title: إدارة تأثيرات تحويل الصور في العروض التقديمية باستخدام Java
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/java/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- السطوع
- التباين
- تدرج رمادي
- ثنائي اللون
- صبغة
- HSL
- استبدال اللون
- تمويه
- الشفافية
- تأثير Alpha
- سلسلة تأثير
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides للـ Java."
---
## **نظرة عامة**

Aspose.Slides يمثل تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [ISlidesPicture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidespicture/) ثم احصل على [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidespicture/#getImageTransform--). المجموعة التي يتم إرجاعها من [IImageTransformOperationCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/) تسمح لك بإضافة، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

توضح هذه المقالة سير عمل كامل للسطوع والتباين، تحويلات الألوان، التشويش، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مصدر الصورة والصورة التي تعرضه كائنات مختلفة:

- [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) يخزن أو يشير إلى بيانات الصورة المصدر التي تملكها العرض.
- [ISlidesPicture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidespicture/) تنتمي إلى تعبئة الصورة وتشير إلى مورد صورة مع تخزين مجموعة تحويل الصورة.
- [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) هو شكل الشريحة الذي يملك تعبئة الصورة ذات الصلة، الهندسة، إعدادات الاقتصاص، وتنسيق المستوى الإطاري الآخر.

لذلك، عمليات تحويل الصورة لا تعدّل البايتات في [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/). عندما يتم تمرير نفس `IPPImage` إلى [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) أكثر من مرة، يحصل كل إطار صورة جديد على `ISlidesPicture` خاص به ومجموعة تحويل خاصة به. تطبيق تدرج الرمادي على إطار واحد لا يجعل الأطر الأخرى تدرج رمادي، رغم أن جميعها تعيد استخدام نفس مورد الصورة المضمّن.

نموذج `ISlidesPicture.getImageTransform` نفسه يُستخدم أيضًا بواسطة تعبئات صور أخرى، مثل شكل أو خلفية شريحة. التركيز في الأمثلة أدناه يكون على إطارات الصور.

## **استخدام نطاقات المعاملات والوحدات الصالحة**

الطرق المعروضة تستخدم النطاقات والمعاني الدلالية التالية. احتفظ بالقيم داخل هذه النطاقات حتى إذا لم ترفض نسخة المكتبة المحددة القيمة الخارجة عن النطاق على الفور؛ قد يقوم تنسيق العرض المستهدف بالتطبيع أو الإغفال أو الرفض أثناء الحفظ أو عند فتح الملف في PowerPoint.

| العملية | المعاملات | النطاق والوحدة الصالحة |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | لا معاملات عددية. لا يتغيّر ألفا. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | لونان للبيكسلات الداكنة والفاتحة. القنوات RGB و Alpha في `java.awt.Color` تستخدم `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | الـ hue من `0` شامل إلى `360` غير شامل، بالدرجات؛ الكمية من `-100` إلى `100`، نسبة مئوية. |
| [addHSLEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | الـ hue من `0` شامل إلى `360` غير شامل، بالدرجات؛ التشبع والإضاءة من `-100` إلى `100`، نسبة مئوية. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | لون الاستبدال يستخدم قيم القناة من `0` إلى `255`. قيم Alpha الحالية لا تتغيّر. |
| [addBlurEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | الـ radius غير سالب ويقاس بالنقاط؛ `grow` هو Boolean يتحكم فيما إذا كان المحتوى المشوش قد يخرج خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادي: `0` شفاف تماماً و`100` يحافظ على Alpha الحالي. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` إلى `100`، نسبة مئوية للشفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` إلى `100`، نسبة مئوية للحد Alpha. القيم الأقل تصبح شفافة؛ القيم بالمساواة أو الأعلى تصبح غير شفافة. |

بالنسبة لتعديل Alpha الثابت، الشفافية والعتامة متكاملتان. على سبيل المثال، الشفافية بنسبة 35 % تعادل مقدار تعديل Alpha بنسبة 65 %.

## **تطبيق السطوع والتباين**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) تُعيد عملية [IBrightnessContrast](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibrightnesscontrast/). تُزوَّد إعداداته القياسية عند إنشاء العملية. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) تُعيد القيم المحسوبة للقراءة فقط التي يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15 % والتباين بنسبة 20 %، ثم يعرض معاينة دون تعديل الصورة المضمَّنة:

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

[BrightnessContrast](https://reference.aspose.com/slides/ar/java/com.aspose.slides/brightnesscontrast/) هو امتداد تأثير صورة لـ Office 2010 وهو أقل قابلية للنقل من تأثير الإضاءة القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابلة للتحرير بعد جولة PPTX، استخدم [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) وتحقق من النتيجة بعد إعادة فتح الملف. يوضح قسم قيود الصيغة هذا التمييز بمزيد من التفصيل.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمسة إطارات ويطبق تدرج رمادي، ثنائي اللون، صبغة، تعديل HSL، واستبدال اللون.

[IDuotone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iduotone/) يحتوي على معاملين لونيين قابلين للتحرير بشكل مستقل: `color1` يطابق البيكسلات الداكنة، بينما `color2` يطابق البيكسلات الفاتحة. هذا يجعله مثالاً مفيداً لتأثير تكون إعداداته أكثر تعقيداً من قيمة قياسية واحدة.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) يستبدل لون كل بيكسل بلون ثابت واحد مع الحفاظ على Alpha. يختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) الذي يطابق لون مصدر بلون هدف ويعرض صيغ كل من اللون المصدر والهدف.

## **إضافة التشويش، الشفافية، وتأثيرات Alpha**

[addBlurEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) يؤثر على جميع قنوات اللون، بما فيها Alpha. اضبط `grow` إلى `true` عندما قد يمتد حافة التشويش خارج حدود الصورة الأصلية.

للشفافية الموحدة، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). إنه يضرب كل قيمة Alpha موجودة، لذا تبقى البيكسلات ذات الشفافية الجزئية ذات فرق نسبي. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) يعيّن قيمة Alpha واحدة لجميع البيكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) يحول Alpha إلى مستويين بناءً على حد معين.

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

تشمل عمليات Alpha دون معاملات أخرى [addAlphaCeilingEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)، التي تجعل كل Alpha غير صفرية غير شفافة تماماً؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)، التي تجعل كل Alpha أقل من 100 % شفافة تماماً؛ و[addAlphaInverseEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)، التي تغير Alpha إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `add...Effect` تُضيف عملية جديدة إلى نهاية المجموعة. يستخدم المُصوِّر المجموعة كخط أنابيب مرتّب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، قد تُنتج نفس العمليات بترتيب مختلف صورة مختلفة.

على سبيل المثال، تدرج رمادي يليه صبغة يزيل أولاً المعلومات اللونية ثم يعيد تلوين النتيجة الضوئية. صبغة يليه تدرج رمادي يزيل الصبغة مرة أخرى. بالمثل، استبدال Alpha يمكنه أن يتجاوز قيم Alpha التي حسبتها عمليات سابقة، بينما تعديل Alpha يحافظ على الفروق النسبية بينها.

المثال التالي يبني سلسلة من أربع عمليات، يحفظها كـ PPTX، يفتح العرض مرة أخرى، يتحقق من نوعية العمليات وترتيبها، ثم يعرض النتيجة المعاد فتحها:

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

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، Alpha، والتشويش إلى سلاسل منفصلة. يمكن دمجها، لكن ليس كل الدمجات مفيدة. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات لونية سابقة؛ تدرج رمادي بعد ثنائي اللون يزيل اللونين المختارين؛ عمليات Alpha السقفية، الأرضية، الاستبدال أو الثنائية قد تتجاهل تفاصيل Alpha التي أنشئت سابقاً. ابنِ السلسلة وفقاً لتسلسل معالجة البيكسل المرغوب بدلاً من اعتبار عناصرها كأعلام تنسيق غير مرتبة.

## **فحص القيم القابلة للتحرير والفعّالة**

العملية القابلة للتحرير هي الكائن المخزن في `ISlidesPicture.getImageTransform`. اعتماداً على التأثير، قد تُظهر أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [IBlur](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iblur/) يُظهر قيم `radius` و `grow` القابلة للكتابة، [IAlphaModulateFixed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ialphamodulatefixed/) يُظهر `amount` القابل للكتابة، و[IAlphaBiLevel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ialphabilevel/) يُظهر `threshold` القابل للكتابة. تأثيرات اللون مثل [IDuotone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iduotone/) تُظهر كائنات [IColorFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icolorformat/) قابلة للتعديل.

بعض واجهات العمليات، بما فيها [IBrightnessContrast](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ihsl/)، [ITint](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itint/)، و[IAlphaReplace](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ialphareplace/)، لا تُظهر المتغيّرات الإنشائية كخصائص قابلة للكتابة. لتغيير تلك الإعدادات، احذف العملية وأضف بديلة في الموقع المطلوب.

البيانات الفعّالة التي تُعيدها `getEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل ألوان تعتمد على السمة وقراءة القيم المُعَدلَة التي يستخدمها المُصوِّر، لكنها ليست سطح تحرير آخر. المثال التالي يُعدد السلسلة ويفحص القيم الفعّالة حيث تُوفر الـ API ما يلزم:

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

التأثيرات دون معلمات مثل تدرج الرمادي، السقيفة، والعكس Alpha لا يزال لها كائن بيانات فعّالة، ولكن لا توجد إعدادات قياسية للطباعة. وجودها وموقعها في المجموعة هو ما يهم.

## **إزالة أو مسح تحويلات الصورة**

استخدم [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) لإزالة عملية واحدة بحسب الفهرس. نظرًا لأن الفهارس تت Shift بعد الإزالة، ابحث أولاً عن الهدف ثم احذفه بعد التعداد. استخدم [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imagetransformoperationcollection/#clear--) لإزالة السلسلة بالكامل.

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

إزالة أو مسح التحويلات يغيّر فقط تنسيق الصورة. لا يحذف، يعيد ضغط، أو يغيّر مورد [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) المعاد استخدامه.

## **مراعاة صيغ العروض وأهداف التصدير**

تنشأ تحويلات الصورة في DrawingML، لذا فإن PPTX هو الصيغة القابلة للتحرير المفضلة لسلاسل التأثير. حتى مع PPTX، ليست كل عملية لها قابلية نقل متساوية:

- عمليات DrawingML القياسية مثل الإضاءة، تدرج الرمادي، ثنائي اللون، الصبغة، HSL، التشويش، والعمليات Alpha الشائعة لديها أفضل فرصة للبقاء بعد جولة PPTX. احرص دائمًا على إعادة فتح الملف المُنشأ وتفحص المجموعة عندما تكون المحافظة مطلوبة.
- [BrightnessContrast](https://reference.aspose.com/slides/ar/java/com.aspose.slides/brightnesscontrast/) هو امتداد Office 2010 وليس عملية إضاءة DrawingML القياسية. يمكن استخدامه للتصوير داخل الذاكرة، لكنه ليس مضمونًا أن يظل كـ [IBrightnessContrast](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibrightnesscontrast/) قابل للتحرير بعد حفظ وإعادة فتح PPTX. الأفضلية لـ [addLuminanceEffect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) للتعديلات المستمرة للسطوع والتباين.
- صيغة PPT الثنائية سابقة لنموذج تأثير DrawingML الكامل. قد يحذف الحفظ إلى PPT عمليات غير مدعومة، أو يقلل السلسلة إلى مجموعة جزئية مدعومة، أو يُقرب المظهر. لا تستخدم PPT كصيغة تحقق لسلسلة تحريرية معقدة.
- التصيير إلى PNG، JPEG، TIFF، PDF، SVG، HTML أو أي مخرجات بصرية أخرى يطبق السلسلة المدعومة على المظهر المصور. تلك المخرجات لا تحتوي على `IImageTransformOperationCollection` قابلة للتحرير؛ صيغ Raster تُسقِط النتيجة إلى بيكسلات، وتصديرات المستند/الرسوم المتجهة تخزن تمثيلها الخاص للتصوير.
- التأثيرات لا تجعل الصورة المرتبطة ذاتيًا. لا يزال تصوير صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض.

قد تُظهر مستهلكات العروض المختلفة الحالات الحدية بطرق مختلفة، خاصة عندما تُدمج عدة عمليات Alpha أو عمليات تكميم ألوان. للنتائج الحرجة، اختبر كلًا من جولة التحرير النهائية وصيغة التصدير النهائية باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة المتكررة**

**هل تعدّل تأثيرات تحويل الصورة بيانات الصورة المضمَّنة؟**

لا. العمليات تنتمي إلى `ISlidesPicture` المستخدمة في تعبئة الصورة. تبقى بايتات `IPPImage` الأساسية دون تغيير.

**هل تتشارك إطارات الصورة التي تُعيد استخدام نفس الصورة تأثيراتها؟**

لا. إعادة استخدام `IPPImage` تُجنّب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يكون له `ISlidesPicture` خاص به ومجموعة تحويل منفصلة.

**هل يمكن دمج تأثيرات اللون، التشويش، وAlpha؟**

نعم. تقبل المجموعة دمجها في سلسلة مرتّبة واحدة. ضع في اعتبارك ما تفعله كل عملية على مخرج العملية السابقة لأن عمليات الاستبدال والحد قد تتخلص من تفاصيل اللون أو Alpha السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة في التصيير، بما فيها الألوان المُحَلَّة. حرّر العملية المخزنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلة بمعلمات إنشائية جديدة.

**أي صيغة يجب أن أستخدمها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن لصيغة PPT القديمة تمثيل نموذج تأثير DrawingML الكامل، وتُحافظ صيغ التصدير المصورة على المظهر فقط وليس على عمليات التحويل القابلة للتحرير.