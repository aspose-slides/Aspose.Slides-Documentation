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
- حذف المناطق المقصوصة
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
description: "إنشاء وتنسيق وربط وقص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides لأندرويد عبر جافا."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضه كائنات منفصلة: تمتلك [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) موارد الصور المضمَّنة عبر [IImageCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagecollection/)، بينما يتحكم [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) في موضع الصورة وحجمها وتنسيق الخط والدوران والقص وتأثيرات الصورة وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما يتم عرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض التقديمي مرة واحدة، احتفظ بـ [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) المُرجعة، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور أن تحتوي على صور نقطية مثل PNG أو JPEG وصور SVG المتجهة. يمكنها أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض التقديمي. يؤثر الاختيار على القابلية للنقل وحجم الملف والاستخراج وسلوك التصدير، لذا من المفيد تحديد طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمَّنة**

لصورة مضمَّنة، أضف بيانات الصورة إلى العرض التقديمي وأنشئ إطار صورة باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). تصبح الصورة جزءًا من حزمة العرض التقديمي، لذا يظل العرض التقديمي مكتفًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًٍاً
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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر الأبعاد بالبكسل الأصلية المخزنة في مورد الصورة المضمَّن. يصبح هذا التمييز مهمًا عند القص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

[IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) يُظهر تغيير العرض والارتفاع النسبي للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). القيمة `1.0` تمثّل 100 % من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة الأصلية بدلاً من حساب الأبعاد النهائية يدوياً.

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

المقياس النسبي يغيّر إعدادات مقياس الإطار؛ لا يقوم بإعادة تشكيل أو ضغط الصورة المضمَّنة.

## **الصور المضمَّنة والمرتبطة**

الصورة المضمَّنة تخزن بيانات الصورة داخل العرض التقديمي وبالتالي تكون الخيار الأكثر أمانًا للنقل وعرض ثابت. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة أن تقلل من كمية بيانات الصور المخزنة في PPTX، لكنها تُدخل واعتمادية خارجية. يجب أن يبقى الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض التقديمي. إذا تغير المسار أو تم نقل الملف أو أصبح المورد غير متاح، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. للعروض التقديمية التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المضمَّنة عادةً أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يتم خلطه في هذا المثال عن عمد.

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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل للضغط فقط: PPTX صغير مع تبعيات صور مكسورة يكون عادةً أقل فائدة من عرض تقديمي أكبر مكتفٍ ذاتيًا.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض تقديمي موجود، تحقق من أن الشكل هو فعليًا [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) وأنه يحتوي على صورة مضمَّنة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة للصور تستخدم [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) مباشرة ولا تتطلب الغلاف القديم للصور Java. المثال التالي يجد أول صورة نقطية مضمَّنة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) يحول الصورة المستخرجة إلى صيغة الإخراج المطلوبة. إذا كنت تحتاج إلى البايتات المشفّرة المخزنة في العرض التقديمي بدلاً من ملف نقطي محوَّل، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

للصورة SVG، يُظهر [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) كائن [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/). هذا يتيح لك استرجاع بيانات SVG مباشرةً بدلاً من تحويل الصورة إلى نقطية أولاً.

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

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض التقديمي. تصدير النقطية مثل PNG أو JPEG يتطلب تحويل ذلك المحتوى المتجه إلى بكسلات. تصدير شريحة إلى PDF أو SVG هو أيضًا عملية عرض، لذا لا ينبغي اعتبار الرسومات المصدَّرة نسخة بايت‑ل‑بايت من SVG المضمَّن الأصلي؛ استخدم بيانات [ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/#getSvgData--) عندما يكون المورد المتجه الأصلي مطلوبًا.

## **قص صورة**

القص يغيّر الجزء المرئي من الصورة داخل الإطار. قيم القص على [IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/) هي نسب مئوية لأبعاد الصورة الأصلية. لا يحذف القص في البداية البكسلات المخفية من الصورة المضمَّنة؛ إنه يغيّر فقط المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم القص:

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تغيير القص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القابلية للعكس، يمكن إزالة المناطق المقطوعة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) يزيل بيانات الصورة خارج مستطيل القص الحالي ويُرجع مورد الصورة الناتج. يمكن أن يقلل ذلك من حجم الملف، لكنه تحسين تدميري: بعد حفظ العرض التقديمي، لا تعود البكسلات التي أزيلت متاحة لعملية إلغاء القص لاحقًا.

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

قد تضيف الطريقة مورد صورة جديد إلى العرض التقديمي. إذا كانت الصورة الأصلية مستخدمة أيضًا من قبل إطارات صور أخرى، فإن تلك الإطارات لا تزال بحاجة إلى المورد الموجود، لذا حذف المناطق المقطوعة لا يقلل بالضرورة من العدد الإجمالي للصور. قص محتوى WMF أو EMF بهذه الطريقة يحول النتيجة المقطوعة إلى PNG.

## **ضغط الصور النقطية**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) يقلل من دقة الصورة النقطية نسبةً إلى الحجم الذي يتم عرض الصورة به. يمكنه أيضًا إزالة المناطق المقطوعة في نفس العملية. تُعيد الطريقة `true` عندما تم تغيير حجم الصورة أو قصها و`false` عندما لا يلزم أي تغيير.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/picturescompression/) المعرفة مسبقًا عندما تكون دقة الهدف القياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلًا من القيمة المعرفة مسبقًا عندما يكون هدف محدد مطلوبًا.

الضغط مخصص للصور النقطية. محتوى SVG وملفات الميتافايل لا يتم تقليصه بهذه الطريقة. تذكر أيضًا أن الدقة الأقل والمناطق المقطوعة المحذوفة لا يمكن استردادها من العرض التقديمي المحسّن. اختر دقة الهدف بناءً على أكبر حجم سيُعرض أو يُصدَّر به الصورة فعليًا بدلاً من تطبيق أدنى DPI عالميًا.

## **إدارة تأثيرات تحويل الصور**

للحصول على سير عمل كامل يغطي السطوع والتباين وتحولات اللون والطمس وتأثيرات ألفا والسلاسل المرتبة والفحص والإزالة والتحقق المتبادل، راجع [Image Transform Effects](/slides/ar/androidjava/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات [IPictureFrameLock](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframelock/) تتحكم في أي عمليات تحرير يتم تعطيلها لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) يحافظ على نسب الشكل أثناء إعادة الحجم.

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

القفل يُطبق على شكل إطار الصورة. لا يجبر الصورة الأصلية على إعادة تشكيل أو تغيير دائم لنفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على وضع التمدد، تحدّد قيم الـ stretch‑offset على [IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/) مستطيل الملء نسبةً إلى المربع المحيط لإطار الصورة. النسب المئوية الإيجابية تُنشئ مسافة داخلية من الحافة، بينما النسب السالبة تُنشئ مسافة خارجية.

هذا مختلف عن القص. قيم القص تُحدّد أي جزء من الصورة الأصلية يُظهر، بينما تغير إزاحات التمدد المستطيل الذي يُمدد فيه ملء الصورة المرئي.

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

استخدم إزاحات التمدد لتحديد موضع الملء. استخدم خصائص القص عندما يكون الهدف إخفاء حواف الصورة الأصلية.

## **الاعتبارات المتعلقة بالتخزين وحجم الملف والتصدير**

المقايضات الرئيسية تكون أسهل في الإدارة عندما يتم التعامل مع تخزين الصور وتنسيق إطارات الصور بشكل منفصل:

- **الصور المضمَّنة** تجعل العرض التقديمي مكتفٍ ذاتيًا وهي الأكثر موثوقية للمشاركة والعرض على الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تحافظ على الحزمة أصغر، لكن العرض التقديمي يعتمد على ملفات خارجية تظل متاحة في المسارات أو المواقع المخزنة.
- **القص** في البداية غير تدميري. تظل البكسلات المخفية مضمَّنة حتى يتم حذف المناطق المقطوعة صريحًا أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الكبيرة، لكنه يفتقد الدقة الأصلية. يجب تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب أن تبقى كـ SVG عندما تكون المحافظة على المتجه مهمة. استخرج SVG المضمَّن مباشرة عندما تحتاج إلى المورد المتجه ذاته. تصدير الشرائح إلى تنسيقات نقطية مثل PNG أو JPEG يحوّل دائمًا المحتوى المتجه إلى بكسلات.
- **الصور المتكررة** يجب إعادة استخدام مورد [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) الموجود عندما يكون ذلك ممكنًا بدلًا من تحميل نفس الملف مرارًا وتكرارًا في سير عمل العرض التقديمي.

للعروض التقديمية الكبيرة، عادةً ما يكون تحسين الصور أكثر فعالية عندما يُجرى انتقائيًا: احفظ الشعارات والرسوم التخطيطية كمتجهات، واضغط الصور الفوتوغرافية وفقًا لحجم عرضها الفعلي، وأزل البكسلات المقصوصة فقط عندما لا تكون هناك حاجة للتحرير لاحقًا، وتجنب الروابط الخارجية ما لم يُصمم إدارة التبعيات كجزء من عملية النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

[IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) يمثل مورد صورة مرتبط بالعرض التقديمي. [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) هو شكل على شريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، والدوران، وقيم القص، والتأثيرات، والقيود.

**هل يجب أن أضمّن الصور أم أُربطها؟**

ضمّن الصور عندما يجب أن يكون العرض التقديمي قابلًا للنقل، مؤرشفًا، أو معروضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون الاحتفاظ بملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بموثوقية.

**هل يقلل القص من حجم ملف PPTX؟**

ليس بنفسه. إعدادات القص العادية تُخفي أجزاء من الصورة الأصلية ولكنها تحتفظ بالبكسلات الأساسية. استخدم [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) أو ضغط الصورة مع حذف المناطق المقطوعة عندما يمكن التخلص من تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة المخزنة، وإزالة المناطق المقطوعة تُفقد بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض التقديمي إذا كان قد يُحتاج إلى تحرير عالي الدقة لاحقًا.

**كيف ينبغي التعامل مع صور SVG؟**

احفظ محتوى SVG كـ SVG عندما تكون دقة المتجه مهمة. يمكن استخراج [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/) المضمَّن مباشرةً. عرض شريحة إلى تنسيق نقطي مثل PNG أو JPEG يُحوِّل SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكنني تجنب التحويلات غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام الأعضاء الخاصة بإطار الصورة. فحص `instanceof` ضد [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) يمنع التحويلات غير الصالحة ويسمح للشفرة بمعالجة الشرائح التي لا تحتوي على إطارات صور.