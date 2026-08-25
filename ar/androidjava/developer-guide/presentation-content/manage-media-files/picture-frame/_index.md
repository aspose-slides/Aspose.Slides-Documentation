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
- صورة مضمّنة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- قطع صورة
- حذف المناطق المقتصة
- ضغط صورة
- إزاحة التمدد
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
description: إنشاء وتنسيق وربط واقتصاص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides للـ Android عبر Java.
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنات منفصلة: يملك [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) موارد الصور المضمّنة عبر [IImageCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagecollection/)، بينما يتحكم [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) في موضع الصورة، حجمها، تنسيق الخط، التدوير، الاقتصاص، تأثيرات الصورة، وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما تُعرض الصورة نفسها أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) المرجع، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور احتواء صور نقطية مثل PNG أو JPEG وصور متجهة SVG. يمكنها أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. يؤثر الاختيار على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمّنة**

بالنسبة لصورة مضمّنة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). تصبح الصورة جزءًا من حزمة العرض، لذا يظل العرض ذاتيًا عند نقله إلى جهاز كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والتدوير:

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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزّنة في مورد الصورة المضمّن. يصبح هذا التمييز مهمًا عند الاقتصاص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

[IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) يوفّر مقياس العرض والارتفاع النسبيين للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). القيمة `1.0` تمثل 100٪ من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

تغيّر المقياس النسبي إعدادات مقياس الإطار؛ لا يعيد أخذ عينات أو ضغط الصورة المضمّنة.

## **الصور المضمّنة والمرتبطة**

الصورة المضمّنة تخزّن بيانات الصورة داخل العرض ولذلك فهي الاختيار الأكثر أمانًا للنقل وعرض ثابت. الصورة المرتبطة تخزّن موقعًا خارجيًا عبر طريقة [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزّنة في PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يبقى الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار، أو نُقل الملف، أو أصبح المورد غير متاح، قد لا يُعرض الإطار المرتبط كما هو متوقع. بالنسبة للعروض التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المضمّنة عادةً أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولم يُدمج عمدًا في هذا المثال.

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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها فقط كبديل للضغط: ملف PPTX صغير مع تبعيات صور مكسورة عادةً ما يكون أقل فائدة من عرض أكبر ذاتيًا.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض موجود، تأكد من أن الشكل هو فعلاً [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) وأنه يحتوي على صورة مضمّنة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة للصور تستخدم [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) مباشرة ولا تحتاج إلى مغلف Java للصور القديم. المثال التالي يجد أول صورة نقطية مضمّنة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) يحول الصورة المستخرجة إلى صيغة الإخراج المطلوبة. إذا كنت تحتاج إلى البايتات المشفّرة المخزّنة في العرض بدلاً من ملف نقطي محوّل، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

بالنسبة لصورة SVG، يُظهر [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/). يتيح لك ذلك استرداد بيانات SVG مباشرةً بدلاً من تحويل الصورة إلى نقطية أولًا.

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

الاحتفاظ بمحتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض. تصديرات نقطية مثل PNG أو JPEG تُعيد تحميل ذلك المحتوى المتجه إلى بكسلات. تصدير الشريحة إلى PDF أو SVG هو أيضًا عملية عرض، لذا لا ينبغي اعتبار الرسوم المصدّرة نسخة بايت-بايت من SVG المضمّن الأصلي؛ استخدم بيانات [ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/#getSvgData--) عندما تكون المورد المتجه الأصلي مطلوبًا.

## **اقتصاص الصورة**

يغيّر الاقتصاص الجزء المرئي من الصورة داخل الإطار. قيم الاقتصاص على [IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. لا يحذف الاقتصاص البكسلات المخفية من الصورة المضمّنة في البداية؛ بل يغيّر المنطقة المرئية فقط.

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تغيير الاقتصاص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القابلية للعكس، يمكن إزالة المناطق المقتصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقتصة**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) يزيل بيانات الصورة خارج مستطيل الاقتصاص الحالي ويعيد مورد الصورة الناتج. يمكن أن يقلل ذلك من حجم الملف، ولكنه تحسين تدميري: بعد حفظ العرض، لا تكون البكسلات المُزالة متاحة لعملية إلغاء الاقتصاص لاحقًا.

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

قد تُضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية مستخدمة أيضًا بواسطة إطارات صور أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا حذف المناطق المقتصة لا يقلل بالضرورة من إجمالي عدد الصور. اقتصاص محتوى WMF أو EMF بهذه الطريقة يحول النتيجة المقتصة إلى PNG.

## **ضغط الصور النقطية**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) يقلل من دقة الصورة النقطية نسبةً إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقتصة في العملية نفسها. تُعيد الطريقة `true` عندما يتم تغيير حجم الصورة أو اقتصاصها و`false` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/picturescompression/) محددة مسبقًا عندما تكون الدقة المستهدفة القياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من القيمة المحددة مسبقًا عندما يتطلب الهدف دقة معينة.

الضغط مخصص للصور النقطية. لا يتم تقليل محتوى SVG أو ملفات الميتا عبر عمل ضغط نقطي. تذكر أيضًا أن الدقة المنخفضة والمناطق المقتصة التي تم حذفها لا يمكن استعادتها من العرض المُحسّن. اختر الدقة المستهدفة بناءً على أكبر حجم سيُعرض فيه الصورة فعليًا أو يتم تصديره بدلاً من تطبيق أقل قيمة DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

للحصول على سير عمل كامل يغطي السطوع، التباين، تحويلات اللون، التشويش، تأثيرات ألفا، السلاسل المرتبة، الفحص، الإزالة، والتحقق الدائري، راجع [Image Transform Effects](/androidjava/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات [IPictureFrameLock](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframelock/) تتحكم في أي عمليات تحرير تُعطل لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) يحافظ على نسب الشكل أثناء تغيير حجمه.

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

القفل يُطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة أخذ عينات أو تغيير دائم لنفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على وضع التمدد، تُحدد قيم الـ stretch‑offset على [IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/) مستطيل الملء بالنسبة لمربع حد إطار الصورة. النسب المئوية الإيجابية تُنشئ تقليصًا من الحافة، بينما النسب السالبة تُنشئ توسيعًا.

هذا مختلف عن الاقتصاص. قيم الاقتصاص تحدد أي جزء من الصورة المصدر يُظهر، بينما تغيّر قيم الـ stretch‑offset المستطيل الذي يُمدد فيه ملء الصورة المرئي.

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

استخدم الـ stretch‑offset لتحديد موضع الملء. استخدم خصائص الاقتصاص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

تكون المقايضات الرئيسية أسهل في الإدارة عندما يتم التعامل مع تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المضمّنة** تجعل العرض ذاتيًا وتُعد الأكثر موثوقية للمشاركة والعرض على الخوادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تُصغّر الحزمة، لكن العرض يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزّنة.
- **الاقتصاص** غير تدميري في البداية. تظل البكسلات المخفية مضمّنة حتى يتم حذف المناطق المقتصة صراحةً أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يضحّي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم الفعلي على الشريحة.
- **صور SVG** يجب أن تُبقى كـ SVG عندما تكون المحافظة على المتجه مهمة. استخرج الـ SVG المضمّن مباشرةً عندما تحتاج إلى المورد المتجه نفسه. تصديرات الشرائح النقطية دائمًا تحوّل الشريحة إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) الموجود عندما يكون ذلك ممكنًا بدلًا من تحميل نفس الملف مرارًا وتكرارًا في سير عمل العرض.

بالنسبة للعروض الكبيرة، يكون تحسين الصور أكثر فعالية عندما يُطبق انتقائيًا: احتفظ بالشعارات والرسوم التوضيحية كمتجهات، اضغط الصور الفوتوغرافية وفق حجم العرض الفعلي، احذف البكسلات المقتصة فقط عندما لا تكون هناك حاجة للتعديل لاحقًا، وتجنب الروابط الخارجية إلا إذا كان إدارة الاعتماد جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

يمثل [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) مورد صورة مرتبط بالعرض. بينما يعتبر [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) شكلًا على شريحة يعرض صورة ويخزن هندسة الإطار وتنسيقاته مثل الحجم، التدوير، قيم الاقتصاص، التأثيرات، والقفلات.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يحتاج العرض إلى أن يكون قابلًا للنقل، مؤرشفًا، أو معروضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون حفظ ملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية موثوقة.

**هل يقلل الاقتصاص من حجم ملف PPTX؟**

ليس من تلقاء نفسه. إعدادات الاقتصاص العادية تخفي أجزاء من الصورة المصدر لكنها تحتفظ بالبكسلات الأساسية. استخدم [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) أو ضغط الصورة مع حذف المناطق المقتصة عندما يمكن إهمال تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة النقطية المخزنة، وإزالة المناطق المقتصة تُحذف بيانات الصورة. احتفظ بالصورة المصدر الأصلية خارج العرض إذا كان من المحتمل الحاجة إلى تعديل عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون دقة المتجه مهمة. يمكن استخراج [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/) المضمّن مباشرةً. عرض الشريحة إلى صيغة نقطية مثل PNG أو JPEG يحوّل الـ SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف أتجنب عمليات التحويل غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقّق من نوع الشكل قبل استخدام أعضاء خاصة بإطار الصورة. فحص `instanceof` ضد [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) يمنع التحويلات غير الصالحة ويسمح للشفرة بمعالجة الشرائح التي لا تحتوي على إطارات صور.