---
title: إدارة إطارات الصور في العروض التقديمية على Android
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/androidjava/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مضمَّنة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- قص صورة
- حذف المناطق المقتصة
- ضغط صورة
- StretchOffset
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتنسيق وربط واقتصاص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنان منفصلان: فإن الـ[العرض التقديمي](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) يمتلك موارد الصور المضمَّنة من خلال الـ[IImageCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagecollection/)، بينما يتحكم الـ[IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) في موضع الصورة، وحجمها، وتنسيق الخط، والدوران، والاقتطاع، وتأثيرات الصورة، وإعدادات المستوى الإطاري الأخرى.

هذا الفصل مفيد عندما يتم عرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض التقديمي مرة واحدة، احتفظ بالـ[IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) المعاد، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور أن تحتوي على صور نقطية مثل PNG أو JPEG وصور SVG المتجهة. كما يمكنها الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة في العرض التقديمي. يؤثر الاختيار على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد طريقة حفظ الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمَّنة**

بالنسبة لصورة مضمَّنة، أضف بيانات الصورة إلى العرض التقديمي وأنشئ إطار صورة باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). تصبح الصورة جزءًا من حزمة العرض التقديمي، وبالتالي يظل العرض التقديمي ذاتيًا عندما يتم نقله إلى جهاز كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ويُنشئ إطارًا بأبعاد الصورة الأصلية، ويُطبق تنسيق الخط والدوران:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزَّنة في مورد الصورة المضمَّن. يصبح هذا التمييز مهمًا عند قص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

يفضح الـ[IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) إمكانية ضبط مقياس العرض والارتفاع النسبيين للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). القيمة `1.0` تمثّل 100٪ من حجم الصورة الأصلي. يكون المقياس النسبي مفيدًا عندما تحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

المقياس النسبي يغيّر إعدادات مقياس الإطار؛ ولا يعيد أخذ عينات أو يضغط الصورة المضمَّنة.

## **الصور المضمَّنة والمرتبطة**

تخزن الصورة المضمَّنة بيانات الصورة داخل العرض التقديمي وبالتالي هي الخيار الأكثر أمانًا للنقل والتصيير المتوقع. تخزن الصورة المرتبطة موقعًا خارجيًا عبر طريقة [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزَّنة في ملف PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يظل الملف المرتبط متاحًا للتطبيق الذي يفتح أو يُصوّر العرض التقديمي. إذا تغير المسار أو تم نقل الملف أو أصبح المورد غير متوفر، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. بالنسبة للعروض التقديمية التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المضمَّنة عادةً أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولم يُدمج عن قصد في هذا المثال.

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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل للتضغط فقط؛ فملف PPTX صغير يحتوي على تبعيات صور مكسورة عادةً ما يكون أقل فائدة من عرض تقديمي larger ذاتيًا.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض تقديمي موجود، تأكد من أن الشكل هو فعلاً ‎[IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) وأنه يحتوي على صورة مضمَّنة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

تستخدم واجهة برمجة التطبيقات الحديثة للصور ‎[IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) مباشرة ولا تتطلب الغلاف القديم للصور في Java. المثال التالي يجد أول صورة نقطية مضمَّنة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) يحول الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت بحاجة إلى البايتات المشفَّرة المخزَّنة في العرض التقديمي بدلاً من ملف نقطي محوَّل، فاستخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

لصورة SVG، يوضح ‎[IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) كائن ‎[ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرة بدلاً من تحويل الصورة إلى نقطية أولًا.

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

إبقاء محتوى SVG كـ SVG يحافظ على المصدر المتجهي داخل العرض التقديمي. التحويلات النقطية مثل PNG أو JPEG تحوِّل المحتوى المتجهي إلى بكسلات بالضرورة. تصدير شريحة كـ PDF أو SVG هو أيضًا عملية تصيير، لذا لا يجب اعتبار الرسومات المُصدَّرة نسخة مطابقة بايت-بايت من SVG المضمَّن الأصلي؛ استخدم بيانات ‎[ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/#getSvgData--)‎ عندما تكون الحاجة إلى المورد المتجهي نفسه.

## **قص صورة**

يغير الاقتصاص الجزء المرئي من الصورة داخل الإطار. قيم الاقتصاص في ‎[IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/)‎ هي نسب مئوية لأبعاد صورة المصدر. لا يحذف الاقتصاص في البداية البكسلات المخفية من الصورة المضمَّنة؛ بل يغيّر فقط المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم الاقتصاص:

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل الاقتصاص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القابلية للعكس، يمكن إزالة المناطق المقتصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصور المقتصة**

تقوم ‎[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) بإزالة بيانات الصورة خارج مستطيل الاقتصاص الحالي وتُعيد مورد الصورة الناتج. يمكن لهذا أن يقلل من حجم الملف، لكنه تحسين هدمى: بعد حفظ العرض التقديمي، لا تكون البكسلات المُزالة متاحة بعد ذلك لإجراء إلغاء الاقتصاص.

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

قد تُضيف الطريقة مورد صورة جديد إلى العرض التقديمي. إذا كانت الصورة الأصلية مستخدمة أيضًا من قِبل إطارات صور أخرى، فإن هذه الإطارات ما تزال بحاجة إلى موردها الحالي، لذا حذف المناطق المقتصة لا يقلل بالضرورة من إجمالي عدد الصور. اقتصاص محتوى WMF أو EMF بهذه الطريقة يحوِّل النتيجة المقتصة إلى PNG.

## **ضغط الصور النقطية**

تقلل ‎[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) دقة الصورة النقطية بالنسبة إلى حجم عرض الصورة. يمكنها أيضًا إزالة المناطق المقتصة في نفس العملية. تُعيد الطريقة `true` عندما يتم تغيير حجم الصورة أو اقتصاصها و `false` عندما لا يكون هناك حاجة لتغيير.

استخدم قيمة ‎[PicturesCompression](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/picturescompression/)‎ معرفة مسبقًا عندما تكون دقة الهدف القياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من قيمة معرفة مسبقًا عندما يكون هناك هدف محدد مطلوب.

الضغط مخصص للصور النقطية. لا يتم تقليل محتوى SVG أو ملفات الميتا عبر هذه العملية. كذلك تذكر أن الدقة المنخفضة والمناطق المقتصة المحذوفة لا يمكن استعادتها من العرض المُحسَّن. اختر دقة الهدف بناءً على أكبر حجم ستُشاهد أو تُصدَّر فيه الصورة فعليًا بدلاً من تطبيق أقل DPI على المستوى العالمي.

## **فحص تأثيرات الصورة**

يتم تخزين تأثيرات الصورة على الصورة المستخدمة في الإطار. قد تحتوي مجموعة تحويلات الصورة على تأثيرات مثل تعديل ألفا ثابت للشفافية والسطوع للتباين. المثال أدناه يقرأ بأمان كلا النوعين من التأثيرات من أول إطار صورة على شريحة:

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

تُغيّر هذه التأثيرات طريقة تصيير الصورة داخل الإطار؛ ولا تعيد كتابة بايتات الصورة المضمَّنة الأصلية.

## **قفل هندسة إطار الصورة**

تتحكم إعدادات ‎[IPictureFrameLock](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframelock/)‎ في عمليات التحرير التي تُعطَّل لإطار الصورة. على سبيل المثال، يحافظ ‎[setAspectRatioLocked](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)‎ على نسب الشكل أثناء تغيير حجمه.

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

القفل يُطبق على شكل إطار الصورة. ولا يجبر صورة المصدر على إعادة أخذ عينات أو تغيير دائم إلى نفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة كامتداد، تُعرِّف قيم الإزاحة ‎[IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/)‎ (stretch-offset) مستطيل التعبئة نسبةً إلى صندوق إطار الصورة. النسب المئوية الموجبة تُنشئ إدخالًا من الحافة، بينما النسب السالبة تُنشئ خروجًا.

هذا يختلف عن الاقتصاص. قيم الاقتصاص تُحدِّد أي جزء من صورة المصدر يُعرض؛ بينما تغير إزاحات الامتداد المستطيل الذي يُمتد فيه ملء الصورة المرئي.

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

استخدم إزاحات الامتداد لتحديد موضع التعبئة. واستخدم خصائص الاقتصاص عندما يكون الهدف إخفاء حواف صورة المصدر.

## **التحزين، حجم الملف، واعتبارات التصدير**

تكون المساومات الرئيسية أسهل في الإدارة عندما يُعالج تخزين الصور وتنسيق إطارات الصورة بشكل منفصل:

- **الصور المضمَّنة** تجعل العرض التقديمي ذاتيًا وتُعد الأكثر موثوقية للمشاركة والتصيير على الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستهلاك الذاكرة.
- **الصور المرتبطة** يمكن أن تُصغر حجم الحزمة، لكن العرض التقديمي يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزَّة.
- **الاقتصاص** غير تدميري في البداية. تظل البكسلات المخفية مضمَّنة حتى يتم حذف أو إزالة المناطق المقتصة صراحةً أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يضحّي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم المقصود على الشريحة.
- **صور SVG** يجب أن تبقى كـ SVG عندما تكون المحافظة على المتجهات مهمة. استخرج الـ SVG المضمَّن مباشرةً عندما تحتاج إلى المورد المتجهي نفسه. تصدير الشرائح إلى تنسيق نقطي دائمًا يحول الشريحة المصوَّرة إلى بكسلات.
- **الصور المتكررة** يجب أن تُعيد استخدام مورد ‎[IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/)‎ موجود عند الإمكان بدلاً من تحميل الملف نفسه مرارًا في سير عمل العرض التقديمي.

في العروض التقديمية الكبيرة، يكون تحسين الصور أكثر فاعلية عندما يُجرى بشكل انتقائي: احتفظ بالشعارات والرسوم البيانية كمحتوى متجهي، اضغط الصور الفوتوغرافية وفقًا لحجم العرض الفعلي، أزل البكسلات المقتصة فقط عندما لا تكون تعديلات لاحقة مطلوبة، وتجنَّب الروابط الخارجية ما لم يكن إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما هو الفرق بين إطار الصورة ومورد الصورة؟**

يُمثل ‎[IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/)‎ مورد صورة مرتبط بالعرض التقديمي. بينما يُعد ‎[IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/)‎ شكلاً على الشريحة يعرض صورة ويخزن إعدادات هندسة الإطار وتنسيقه مثل الحجم، والدوران، وقيم الاقتصاص، والتأثيرات، والقفل.

**هل يجب أن أضمّن الصور أم أربطها؟**

قم بضمّ الصور عندما يجب أن يكون العرض التقديمي قابلًا للنقل أو مؤرشفًا أو يُصوَّر دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون حفظ ملفات الصور خارج ملف PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل الاقتصاص من حجم ملف PPTX؟**

ليس بمفرده. تُخفي إعدادات الاقتصاص العادية أجزاء من صورة المصدر لكن تظل البكسلات الأصلية موجودة. استخدم ‎[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)‎ أو ضغط الصورة مع حذف المناطق المقتصة عندما يمكن التخلص من تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. لا يمكن استعادة الجودة بعد الضغط، وإزالة المناطق المقتصة تحذف بيانات الصورة. احفظ الصورة الأصلية خارج العرض إذا كان قد تحتاج إلى تحرير بدقة عالية لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون دقة المتجهات مهمة. يمكن استخراج ‎[ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/)‎ المضمَّن مباشرةً. عند تصيير شريحة إلى تنسيق نقطي مثل PNG أو JPEG يتم تحويل SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكن تجنب التحويلات غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام الأعضاء الخاصة بإطار الصورة. فحص `instanceof` مقابل ‎[IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/)‎ يجنّب التحويلات غير الصالحة ويسمح للشفرة بالتعامل مع الشرائح التي لا تحتوي على إطارات صور.