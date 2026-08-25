---
title: إدارة إطارات الصور في العروض التقديمية باستخدام Java
linktitle: إطار صورة
type: docs
weight: 10
url: /ar/java/picture-frame/
keywords:
- إطار صورة
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
- Java
- Aspose.Slides
description: "إنشاء، تنسيق، ربط، قص، استخراج، وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides للـ Java."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضه هما كائنان منفصلان: يمتلك [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) موارد الصور المضمنة من خلال [IImageCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagecollection/)، بينما يتحكم [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) في موضع الصورة وحجمها وتنسيق الخط وتدويرها واقتطاعها وتأثيرات الصورة وغيرها من إعدادات مستوى الإطار.

هذا الفصل مفيد عندما تُعرض الصورة نفسها أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) المسترجعة، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور أن تحتوي على صور نقطية مثل PNG أو JPEG وصور SVG متجهة. يمكنها أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بيانات الصورة داخل العرض. يؤثر هذا الاختيار على قابلية النقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمَّنة**

لصورة مضمَّنة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). تصبح الصورة جزءًا من حزمة العرض، وبالتالي يظل العرض مستقلاً عند نقله إلى جهاز كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والتدوير:

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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزنة في مورد الصورة المضمَّن. يصبح هذا التمييز مهمًا عند اقتطاع الصورة أو ضغطها لاحقًا.

## **استخدام المقياس النسبي**

يُظهر [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) مقياس العرض والارتفاع النسبي للإطار من خلال [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). القيمة `1.0` تمثل 100٪ من حجم الصورة الأصلي. المقياس النسبي مفيد عندما تحتاج سير العملية إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

تغيّر المقياس النسبي إعدادات مقياس الإطار؛ لا يعيد أخذ العينات ولا يضغط الصورة المضمَّنة.

## **صور مضمَّنة ومربوطة**

الصورة المضمَّنة تخزن بيانات الصورة داخل العرض وبالتالي تُعد الخيار الأكثر أمانًا للنقل وعرض ثابت. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) بدلًا من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل مقدار بيانات الصورة المخزنة في PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يظل الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار أو تم نقل الملف أو أصبح المورد غير متوفر، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. بالنسبة للعرضات التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المضمَّنة عادةً أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويوجهّه إلى ملف صورة محلي. يتعامل فقط مع ربط الصورة؛ ربط الفيديو هو سير عمل وسائط منفصل ولم يُدمج عمدًا في هذا المثال.

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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل للضغط فقط: PPTX صغير يحتوي على تبعيات صور مكسورة يكون عادةً أقل فائدة من عرض كبير مكتمل.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض موجود، تأكد من أن الشكل هو فعلاً [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) وأنه يحتوي على صورة مضمَّنة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

تستخدم واجهة برمجة التطبيقات الحديثة للصور [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) مباشرة ولا تتطلب غلاف Java للصورة القديم. المثال التالي يجد أول صورة نقطية مضمَّنة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-) يحول الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت بحاجة إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوَّل، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

لصورة SVG، يُظهر [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرةً بدلاً من تمثيل الصورة أولاً.

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

الإبقاء على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض. تصدير النقطي مثل PNG أو JPEG يُعيد تمثيل المحتوى المتجه إلى بكسلات. تصدير الشريحة كـ PDF أو SVG هو أيضًا عملية تمثيل، لذا لا ينبغي اعتبار الرسومات المصدرة نسخة مطابقة البايت للـ SVG المضمّن الأصلي؛ استخدم بيانات [ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/#getSvgData--) عندما يتطلب الأمر المورد المتجه الأصلي.

## **اقتطاع صورة**

يغيّر الاقتطاع الجزء المرئي من الصورة داخل الإطار. قيم الاقتطاع على [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. لا يحذف الاقتطاع البكسلات المخفية من الصورة المضمَّنة في البداية؛ فقط يغيّر المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم الاقتطاع:

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل الاقتطاع لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أكثر أهمية من إمكانية الرجوع، يمكن إزالة المناطق المقتطعة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) يزيل بيانات الصورة خارج مستطيل الاقتطاع الحالي ويعيد مورد الصورة الناتج. يمكن لهذا أن يقلل حجم الملف، لكنه تحسين مدمر: بعد حفظ العرض، لا تتوفر البكسلات التي أزيلت لعملية إلغاء الاقتطاع لاحقًا.

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

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية مستخدمة أيضًا من قبل إطارات صور أخرى، فلا يزال تلك الإطارات تحتاج إلى المورد الحالي، لذا حذف المناطق المقتطعة لا يقلل بالضرورة عدد الصور الإجمالي. قص محتوى WMF أو EMF بهذه الطريقة يتحول إلى PNG.

## **ضغط الصور النقطية**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) يقلل دقة الصورة النقطية نسبةً إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقتطعة في نفس العملية. تُعيد الطريقة `true` عندما تم تغيير حجم الصورة أو قصها و`false` عندما لا يلزم أي تغيير.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/java/com.aspose.slides/picturescompression/) معرفة مسبقًا عندما تكون دقة الهدف القياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من القيمة المعرفة مسبقًا عندما يتطلب الهدف دقة معينة.

الضغط مخصص للصور النقطية. لا يتم تقليل محتوى SVG أو ملفات الميتا في هذا التدفق. تذكر أيضًا أن الدقة المنخفضة والمناطق المقتطعة المحذوفة لا يمكن استعادتها من العرض المُحسّن. اختر دقة الهدف بناءً على أكبر حجم ستُعرض فيه الصورة فعليًا أو تُصدَّر وليس بفرض أدنى DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

للحصول على سير عمل كامل يغطي السطوع، التباين، تحويلات الألوان، التشويش، تأثيرات الألفا، السلاسل المرتبة، الفحص، الإزالة، والتحقق من الجولة، راجع [Image Transform Effects](/java/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات [IPictureFrameLock](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframelock/) تتحكم في أي عمليات تحرير يتم تعطيلها لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) يحافظ على نسب الشكل أثناء تغيير حجمه.

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

القفل يطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة أخذ عينات أو تغيير دائم لنفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عندما يكون نمط ملء الصورة هو التمدد، تحدد قيم StretchOffset على [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) مستطيل الملء نسبةً إلى صندوق إطاري إطار الصورة. النسب المئوية الإيجابية تُنشئ تقليلًا من الحافة، بينما النسب السلبية تُنشئ توسعة.

هذا مختلف عن الاقتطاع. قيم الاقتطاع تحدد أي جزء من الصورة المصدر يُظهر، بينما تغير إزاحات التمدد المستطيل الذي يُمدد فيه ملء الصورة المرئي.

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

استخدم إزاحات التمدد لتحديد موضع الملء. استخدم خصائص الاقتطاع عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

تكون المقايضات الرئيسية أسهل في الإدارة عندما يتم التعامل مع تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المضمَّنة** تجعل العرض مكتملًا ذاتيًا وتعد الأكثر موثوقية للمشاركة والعرض على الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستهلاك الذاكرة.
- **الصور المرتبطة** يمكن أن تحافظ على حجم الحزمة أصغر، لكن العرض يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزنة.
- **الاقتطاع** غير مدمر في البداية. البكسلات المخفية تظل مضمَّنة حتى يتم حذف المناطق المقصوصة صراحةً أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يضحي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** ينبغي أن تبقى كـ SVG عندما يكون حفظ المتجه مهمًا. استخرج SVG المضمَّن مباشرة عندما تحتاج إلى المورد المتجه نفسه. تصديرات الشرائح النقطية دائمًا ما تحوّل الشريحة المرسومة إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) الموجود عندما يكون ذلك ممكنًا بدلًا من تحميل نفس الملف مرارًا وتكرارًا في سير العمل.

للعروض الكبيرة، يكون تحسين الصور عادةً أكثر فاعلية عندما يُجرى بشكل انتقائي: احتفظ بالشعارات والمخططات كمحتوى متجه، اضغط الصور الفوتوغرافية وفقًا لحجم العرض الفعلي، أزل البكسلات المقتطعة فقط عندما لا تكون هناك حاجة لتحرير لاحق، وتجنب الروابط الخارجية ما لم تكن إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

[IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) يمثل مورد صورة مرتبط بالعرض. [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) هو شكل على شريحة يعرض صورة ويخزن هندسة وإعدادات الإطار مثل الحجم، التدوير، قيم الاقتطاع، التأثيرات، والقفل.

**هل يجب أن أضمّن الصور أم أربطها؟**

امضمّن الصور عندما يجب أن يكون العرض قابلًا للنقل أو الأرشفة أو العرض دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون الاحتفاظ بملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل الاقتطاع حجم ملف PPTX؟**

ليس بمفرده. إعدادات الاقتطاع العادية تُخفي أجزاءً من الصورة المصدر لكن تحتفظ بالبكسلات الأساسية. استخدم [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) أو ضغط الصورة مع حذف المناطق المقتطعة عندما يمكن حذف تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة المخزنة، وإزالة المناطق المقتطعة تحذف بيانات الصورة. احتفظ بالصورة المصدر الأصلية خارج العرض إذا قد تحتاج إلى تحرير عالي الدقة لاحقًا.

**كيف ينبغي التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون دقة المتجه مهمة. يمكن استخراج [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/) المضمَّن مباشرة. تحويل الشريحة إلى تنسيق نقطي مثل PNG أو JPEG يحول SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكن تجنب التحويلات غير الآمنة عند قراءة شرائح موجودة؟**

تحقق من نوع الشكل قبل استخدام أعضاء إطار الصورة. فحص `instanceof` مقابل [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) يمنع التحويلات غير الصالحة ويسمح للشفرة بالتعامل مع الشرائح التي لا تحتوي على إطارات صور.