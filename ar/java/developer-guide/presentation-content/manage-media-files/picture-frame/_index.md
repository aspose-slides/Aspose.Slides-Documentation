---
title: إدارة إطارات الصورة في العروض التقديمية باستخدام Java
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/java/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مضمّنة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- قص صورة
- حذف المناطق المقصوصة
- ضغط صورة
- StretchOffset
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء وتنسيق وربط وقص واستخراج وضغط إطارات الصورة في العروض التقديمية باستخدام Aspose.Slides للغة Java."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضه كائنان منفصلان: يمتلك [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) موارد الصور المضمنة عبر [IImageCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagecollection/)، بينما يتحكم [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) في موضع الصورة، حجمها، تنسيق الخط، الدوران، القص، تأثيرات الصورة، وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما تُعرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض التقديمي مرة واحدة، احتفظ بـ [IPPImage] المسترجعة، واستخدم مورد الصورة هذا عند إنشاء إطارات الصورة.

يمكن لإطارات الصورة أن تحتوي على صور نقطية مثل PNG أو JPEG وصور SVG متجهة. ويمكن أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة في العرض التقديمي. يؤثر الاختيار على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد كيفية تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمّنة**

للصورة المضمّنة، أضف بيانات الصورة إلى العرض التقديمي وأنشئ إطار صورة باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). تصبح الصورة جزءًا من حزمة العرض التقديمي، وبالتالي يبقى العرض التقديمي مستقلاً عند نقله إلى جهاز كمبيوتر آخر.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغير أبعاد البكسل الأصلية المخزنة في مورد الصورة المضمّن. يصبح هذا التمييز مهمًا عند القص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

[IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) يوفّر مقياس العرض والارتفاع النسبي للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). القيمة `1.0` تمثل 100٪ من الحجم الأصلي للصورة. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تغيّر المقياس النسبي إعدادات مقياس الإطار؛ ولا يعيد تشكيل أو ضغط الصورة المضمّنة.

## **الصور المضمّنة والمرتبطة**

الصورة المضمّنة تخزن بيانات الصورة داخل العرض التقديمي وبالتالي تُعد الخيار الأكثر أمانًا للقابلية للنقل والعرض المتسق. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية البيانات المخزنة في PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يبقى الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض التقديمي. إذا تغير المسار أو تم نقل الملف أو كان المورد غير متاح، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. بالنسبة للعرض التقديمي الذي يجب إرساله بالبريد الإلكتروني أو أرشفته أو عرضه في بيئات معزولة، تكون الصور المضمّنة عادةً أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يتم دمجه في هذا المثال.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل للضغط فقط: PPTX صغير مع تبعيات صور مكسورة عادةً ما يكون أقل فائدة من عرض تقديمي أكبر ومستقل.

## **استخراج الصور من إطارات الصورة**

قبل استخراج صورة من عرض تقديمي موجود، تحقق من أن الشكل فعليًا هو [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) وأنه يحتوي على صورة مضمّنة. إطارات الصورة المرتبطة قد لا تحتوي على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

يستخدم API الصورة الحديث [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) مباشرة ولا يتطلب أداة تغليف الصورة Java القديمة. المثال التالي يجد أول صورة نقطية مضمّنة على شريحة ويحفظها كـ PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

الحفظ عبر [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-) يحوّل الصورة المستخرجة إلى التنسيق المطلوب. إذا كنت بحاجة إلى بايتات الترميز المخزنة في العرض التقديمي بدلاً من ملف نقطي محوّل، استخدم بيانات الصورة الثنائية بدلاً من ذلك.

### **استخراج صورة SVG**

بالنسبة لصورة SVG، يوفّر [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرة بدلاً من تحويل الصورة إلى نقطية أولًا.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجهي داخل العرض التقديمي. عمليات التصدير النقطية مثل PNG أو JPEG تُعيد تمثيل ذلك المحتوى المتجهي إلى بكسلات. تصدير الشريحة إلى PDF أو SVG يُعد أيضًا عملية عرض، لذا لا ينبغي اعتبار الرسومات المصدرة نسخة بايتية مطابقة للـ SVG المضمّن الأصلي؛ استخدم بيانات [ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/#getSvgData--) عندما تكون الحاجة إلى المورد المتجهي نفسه.

## **قص صورة**

يغيّر القص الجزء المرئي من الصورة داخل الإطار. قيم القص على [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. لا يحذف القص البكسلات المخفية من الصورة المضمّنة في البداية؛ بل يغيّر المنطقة المرئية فقط.

المثال التالي يجد إطار صورة بأمان ويطبّق قيم القص:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

نظرًا لبقاء بيانات الصورة المخفية، يمكن تغيير القص لاحقًا دون فقد البكسلات الأصلية. إذا كان حجم الملف أكثر أهمية من إمكانية العكس، يمكن إزالة المناطق المقصوصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) يزيل بيانات الصورة خارج مستطيل القص الحالي ويعيد مورد الصورة الناتج. هذا قد يقلل من حجم الملف، لكنه تحسين مدمر: بعد حفظ العرض التقديمي، لا تعود البكسلات المحذوفة متاحة لعملية إلغاء القص لاحقًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

قد تضيف الطريقة مورد صورة جديد إلى العرض التقديمي. إذا كانت الصورة الأصلية مستخدمة أيضًا في إطارات صورة أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا حذف المناطق المقصوصة لا يقلل بالضرورة من إجمالي عدد الصور. قص محتوى WMF أو EMF بهذه الطريقة يحوّل النتيجة المقصوصة إلى PNG.

## **ضغط الصور النقطية**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) يقلل من دقة الصورة النقطية نسبة إلى الحجم الذي تُعرض فيه الصورة. يمكنه أيضًا حذف المناطق المقصوصة في نفس العملية. تُعيد الطريقة `true` عندما تم تغيير حجم الصورة أو قصها و`false` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/java/com.aspose.slides/picturescompression/) معرفة مسبقًا عندما تكون دقة هدف قياسية كافية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من القيمة المعرفة مسبقًا عندما تكون هناك حاجة إلى هدف محدد.

الضغط مخصص للصور النقطية. لا يتم تقليل محتوى SVG أو ملفات الميتافايل بهذه العملية. تذكر أيضًا أن الدقة المنخفضة والمناطق المقصوصة المحذوفة لا يمكن استعادتها من العرض التقديمي المُحسّن. اختر دقة الهدف بناءً على أكبر حجم ستُعرض فيه الصورة فعليًا أو تُصدّر بدلاً من تطبيق أقل DPI عالميًا.

## **فحص تأثيرات الصورة**

تُخزن تأثيرات الصورة على الصورة المستخدمة في الإطار. قد يحتوي مجموعة تحويلات الصورة على تأثيرات مثل تعديل ألفا ثابت للشفافية والسطوع للتباين. يقرأ المثال أدناه بأمان كلا النوعين من التأثيرات من أول إطار صورة على شريحة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

تُغيّر هذه التأثيرات طريقة عرض الصورة في الإطار؛ ولا تعيد كتابة بايتات الصورة المضمّنة الأصلية.

## **قفل هندسة إطار الصورة**

إعدادات [IPictureFrameLock](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframelock/) تتحكم في أي عمليات تحرير تُعطل لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) يحافظ على نسب الشكل أثناء تغيير حجمه.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

القفل يُطبق على شكل إطار الصورة. ولا يجبر الصورة المصدر على أن تُعاد تشكيلها أو تُغيّر دائمًا لتتناسب مع نفس نسبة العرض إلى الارتفاع.

## **ضبط قيم StretchOffset**

عندما يكون وضع ملء الصورة هو تمدد، تُحدد قيم الـ stretch‑offset على [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) مستطيل الملء نسبة إلى مربع إطارات الصورة. النسب المئوية الإيجابية تُنشئ فجوة من الحافة، بينما النسب السالبة تُنشئ بروزًا.

هذا مختلف عن القص. قيم القص تحدد أي جزء من الصورة المصدر يُظهر، بينما تُغيّر قيم الـ stretch‑offset المستطيل الذي يُمدد إليه ملء الصورة المرئي.

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

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

استخدم الـ stretch‑offset لتحديد موضع الملء. استخدم خصائص القص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين وحجم الملف والتصدير**

تكون المقايضات الرئيسية أسهل في الإدارة عندما تُعامل تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المضمّنة** تجعل العرض التقديمي مستقلاً وتُعد الأكثر موثوقية للمشاركة والعرض على الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستهلاك الذاكرة.
- **الصور المرتبطة** يمكن أن تحافظ على حجم الحزمة أصغر، لكن العرض التقديمي يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزنة.
- **القص** غير مدمر في البداية. تبقى البكسلات المخفية مضمّنة حتى يتم حذف المناطق المقصوصة صراحةً أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يضحي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم الفعلي على الشريحة.
- **صور SVG** يجب أن تبقى كـ SVG عندما تكون المحافظة على المتجهات مهمة. استخرج SVG المضمّن مباشرة عندما تحتاج إلى المورد المتجهي نفسه. تصدير الشرائح إلى تنسيقات نقطية دائمًا ما يحوّل المحتوى المتجهي إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [IPPImage] موجود عندما يكون ذلك ممكنًا بدلاً من تحميل نفس الملف مرارًا إلى سير عمل العرض التقديمي.

للعروض التقديمية الكبيرة، يكون تحسين الصور أكثر فاعلية عندما يُجرى انتقائيًا: احتفظ بالشعارات والرسوم التخطيطية كمحتوى متجهي، اضغط الصور الفوتوغرافية وفقًا لحجم عرضها الفعلي، أزل البكسلات المقصوصة فقط عندما لا تكون تعديل لاحق مطلوبًا، وتجنب الروابط الخارجية إلا إذا كان إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

[IPPImage] يمثل مورد صورة مرتبط بالعرض التقديمي. [IPictureFrame] هو شكل على شريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، الدوران، قيم القص، التأثيرات، والقفل.

**هل يجب أن أضمّن الصور أم أربطها؟**

ضمّن الصور عندما يكون العرض التقديمي بحاجة إلى أن يكون قابلًا للنقل أو مؤرشفًا أو مُعرضًا دون الاعتماد على موارد خارجية. اربط الصور فقط عندما يكون الاحتفاظ بملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل القص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات القص العادية تُخفِي أجزاء من الصورة المصدر لكن تحتفظ بالبكسلات الأساسية. استخدم [IPictureFillFormat.deletePictureCroppedAreas] أو ضغط الصورة مع حذف المناطق المقصوصة عندما يمكن التخلص من تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة المخزنة، وإزالة المناطق المقصوصة تحذف بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض التقديمي إذا كان قد يلزم تحريرها بدقة عالية لاحقًا.

**كيف يجب معالجة صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون الدقة المتجهية مهمة. يمكن استخراج [ISvgImage] المضمّن مباشرة. تحويل الشريحة إلى تنسيق نقطي مثل PNG أو JPEG سيؤدي إلى تحويل SVG إلى بكسلات.

**كيف يمكنني تجنب التحويلات غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام الأعضاء الخاصة بإطار الصورة. فحص `instanceof` ضد [IPictureFrame] يُجنب التحويلات غير الصالحة ويسمح للشفرة بالتعامل مع الشرائح التي لا تحتوي على إطارات صورة.