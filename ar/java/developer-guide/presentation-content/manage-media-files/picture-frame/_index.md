---
title: إدارة إطارات الصور في العروض التقديمية باستخدام Java
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/java/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مدمجة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- اقتصاص صورة
- حذف المناطق المقصوصة
- ضغط صورة
- إزاحة التمدد
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة العرض إلى الارتفاع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: إنشاء، تنسيق، ربط، اقتصاص، استخراج، وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides للـ Java.
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، تكون مورد الصورة والشكل الذي يعرضها كائنين منفصلين: [العرض التقديمي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) يملك موارد الصور المضمنة عبر [IImageCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagecollection/)، بينما يتحكم [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) في موضع الصورة وحجمها وتنسيق الخط والدوران والاقتصاص وتأثيرات الصورة وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما تُعرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) المعاد، واستخدم هذا المورد عند إنشاء إطارات الصورة.

يمكن لإطارات الصورة احتواء صور نقطية مثل PNG أو JPEG وصور متجهية SVG. ويمكنها أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. يؤثر الاختيار على قابلية النقل وحجم الملف والاستخراج وسلوك التصدير، لذا من المفيد تحديد طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة صورة مدمجة وتنسيقها**

للصور المدمجة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). تصبح الصورة جزءًا من حزمة العرض، لذا يظل العرض مكتملًا ذاتيًا عندما يُنقل إلى كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوران:

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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزنة في مورد الصورة المدمج. يصبح هذا التمييز مهمًا عند اقتصاص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

[IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) يتيح ضبط مقياس العرض والارتفاع النسبيين للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). القيمة `1.0` تمثل 100٪ من حجم الصورة الأصلي. المقياس النسبي مفيد عندما تحتاج سير العمل إلى الحفاظ على علاقة بحجم صورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

تغيّر مقياس النسبي إعدادات مقياس الإطار؛ لا يعيد تحييد أو ضغط الصورة المدمجة.

## **الصور المدمجة والمرتبطة**

الصورة المدمجة تخزن بيانات الصورة داخل العرض وبالتالي هي الخيار الأكثر أمانًا من حيث القابلية للنقل وتثبيت العرض. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) بدلًا من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تُضيف اعتمادًا خارجيًا. يجب أن يظل الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار أو نُقل الملف أو أصبح المورد غير متوفر، قد لا تُعرض الصورة المرتبطة كما هو متوقع. بالنسبة للعرض الذي يجب إرساله بالبريد الإلكتروني أو أرشفته أو عرضه في بيئات منعزلة، تكون الصور المدمجة عادةً أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يُدمج عمدًا في هذا المثال.

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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل عن الضغط فقط: ملف PPTX صغير مع تبعيات صور مكسورة عادةً ما يكون أقل فائدة من عرض أكبر مكتمل ذاتيًا.

## **استخراج الصور من إطارات الصورة**

قبل استخراج صورة من عرض موجود، تأكد أن الشكل هو فعلاً [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) وأنه يحتوي على صورة مدمجة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة تستخدم [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) مباشرة ولا تتطلب غلاف الصورة Java القديم. المثال التالي يجد أول صورة نقطية مدمجة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-) يحوّل الصورة المستخرجة إلى صيغة الإخراج المطلوبة. إذا كنت تحتاج إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوّل، استخدم البيانات الثنائية لمورد الصورة مباشرة.

### **استخراج صورة SVG**

لصورة SVG، يُظهر [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرةً بدلاً من تحويل الصورة إلى نقطية أولًا.

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

الإبقاء على محتوى SVG كـ SVG يحافظ على المصدر المتجهي داخل العرض. تصدير الرستر مثل PNG أو JPEG يلزم تحويل ذلك المحتوى المتجهي إلى بكسلات. تصدير الشرائح إلى PDF أو SVG أيضًا عملية تحويل، لذا لا تُعامل الرسومات المصدرة كنسخة بايت-بايت من SVG المدمج الأصلي؛ استخدم بيانات [ISvgImage.getSvgData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/#getSvgData--) عندما يكون المورد المتجهي الأصلي مطلوبًا.

## **اقتصاص صورة**

يغيّر الاقتصاص الجزء الظاهر من الصورة داخل الإطار. قيم الاقتصاص على [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) هي نسب مئوية لأبعاد صورة المصدر. لا يحذف الاقتصاص البكسلات المخفية من الصورة المدمجة مباشرةً؛ إنه فقط يغيّر المنطقة المرئية.

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل الاقتصاص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القدرة على التراجع، يمكن إزالة المناطق المقصوصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المُقتَصَة**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) يزيل بيانات الصورة خارج مستطيل الاقتصاص الحالي ويُعيد مورد الصورة الناتج. يمكن لهذا أن يقلل حجم الملف، لكنه تحسين تدميري: بعد حفظ العرض، لا تكون البكسلات التي أزيلت متاحة لعملية عدم اقتصاص لاحقة.

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

قد تضيف الطريقة مورد صورة جديدًا إلى العرض. إذا كانت الصورة الأصلية مستخدمة أيضًا في إطارات صورة أخرى، ما زالت تلك الإطارات تحتاج إلى المورد الموجود، لذا حذف المناطق المقصوصة لا يقلل بالضرورة من إجمالي عدد الصور. اقتصاص محتوى WMF أو EMF بهذه الطريقة يحوّل النتيجة المقتصة إلى PNG.

## **ضغط الصور النقطية**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) يقلل دقة الصورة النقطية نسبةً إلى حجم عرض الصورة. يمكنه أيضًا إزالة المناطق المقصوصة في نفس العملية. تُرجع الطريقة `true` عندما تم تغيير حجم الصورة أو اقتصاصها و`false` عندما لا يلزم أي تغيير.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/java/com.aspose.slides/picturescompression/) محددة مسبقًا عندما يكون مستوى الدقة المستهدف قياسيًا كافيًا:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من القيمة المحددة مسبقًا عندما يُطلب هدف معين.

الضغط موجه للصور النقطية. لا تُقلل محتويات SVG أو ملفات الميتافييل هذا النوع من الضغط النقطي. وتذكر أن الدقة المنخفضة والمناطق المقصوصة المحذوفة لا يمكن استعادتها من العرض المُحسّن. اختر دقة الهدف بناءً على أكبر حجم سيُعرض فيه الصورة فعليًا أو يُصدّر إليه بدلاً من تطبيق أقل DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

للتعرف على سير عمل كامل يغطي السطوع، التباين، تحويلات اللون، الضبابية، تأثيرات ألفا، السلاسل المرتبة، الفحص، الإزالة، والتحقق المتبادل، راجع [تأثيرات تحويل الصورة](/slides/ar/java/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات [IPictureFrameLock](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframelock/) تتحكم في أي عمليات تحرير تُعطَّل لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) يحافظ على نسب الشكل أثناء تغيير حجمه.

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

القفل ينطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة التحجيم أو تغيير دائم لنفس نسبة العرض إلى الارتفاع.

## **ضبط قيم StretchOffset**

عند كون وضع ملء الصورة هو تمديد، تُحدد قيم الـ stretch‑offset على [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) مستطيل الملء بالنسبة لمربع إطارات الصورة. النسب المئوية الموجبة تُنشئ إدخالًا من حافة، بينما النسب السالبة تُنشئ خروجًا.

هذا مختلف عن الاقتصاص. قيم الاقتصاص تحدد أي جزء من صورة المصدر يُظهر، بينما تغير إزاحات التمديد المستطيل الذي يُمدد فيه ملء الصورة المرئي.

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

استخدم إزاحات التمديد لتحديد موضع الملء. استخدم خصائص الاقتصاص عندما يكون الهدف إخفاء حواف صورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

المقايضات الرئيسية تصبح أسهل إدارةً عندما يُعامل تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المدمجة** تجعل العرض مكتملًا ذاتيًا وتُعد الأكثر موثوقية للمشاركة والعرض على الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستهلاك الذاكرة.
- **الصور المرتبطة** يمكن أن تُصغر الحزمة، لكن العرض يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزنة.
- **الاقتصاص** غير مدمر في البداية. تبقى البكسلات المخفية مدمجة حتى تُحذف المناطق المقصوصة صراحةً أو تُزال أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الكبيرة، لكنه يفتقد الدقة الأصلية. ينبغي تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب تركها كـ SVG عندما تكون حفظ المتجهات مهمًا. استخرج SVG المدمج مباشرةً عندما تحتاج المورد المتجهي نفسه. تصدير الشرائح إلى رستر دائمًا ما يحول الشريحة المُصدرة إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) موجود عندما يكون ذلك ممكنًا بدلاً من تحميل نفس الملف مرارًا وتكرارًا في سير عمل العرض.

في العروض الكبيرة، عادةً ما يكون تحسين الصورة أكثر فاعلية عند تطبيقه بشكل انتقائي: حافظ على الشعارات والرسوم التخطيطية كمتجهات، اضغط الصور الفوتوغرافية وفقًا لحجم عرضها الفعلي، احذف البكسلات المقصوصة فقط عندما لا تكون هناك حاجة للتحرير لاحقًا، وتجنب الروابط الخارجية ما لم يكن إدارة الاعتماد جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

[IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) يمثل مورد صورة مرتبط بالعرض. [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) هو شكل على شريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، الدوران، قيم الاقتصاص، التأثيرات، والقفل.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يجب أن يكون العرض قابلًا للنقل أو مؤرشفًا أو مُعرضًا بدون الوصول إلى موارد خارجية. اربط الصور فقط عندما يكون حفظ ملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل الاقتصاص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات الاقتصاص العادية تُخفي أجزاء من صورة المصدر لكنها تبقي البكسلات الأساسية. استخدم [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) أو ضغط الصورة مع حذف المناطق المقصوصة عندما يمكن إهمال تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. يمكن للضغط تقليل دقة الصورة المخزنة، وإزالة المناطق المقصوصة تحذف بيانات الصورة. احتفظ بصورة المصدر الأصلية خارج العرض إذا كان قد يُطلب تعديل عالي الدقة لاحقًا.

**كيف ينبغي التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون وفاء المتجه مهمًا. يمكن استخراج [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/) المدمج مباشرةً. تحويل شريحة إلى صيغة رستر مثل PNG أو JPEG يحول SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكنني تجنّب التحويلات غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام الأعضاء الخاصة بإطار الصورة. فحص `instanceof` ضد [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) يمنع التحويلات غير الصالحة ويسمح للكود بمعالجة الشرائح التي لا تحتوي على إطارات صورة.