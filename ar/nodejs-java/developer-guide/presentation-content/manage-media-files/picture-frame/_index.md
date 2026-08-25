---
title: إدارة إطارات الصور في العروض التقديمية باستخدام JavaScript
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/nodejs-java/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مدمجة
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
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء، تنسيق، ربط، قص، استخراج، وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنان منفصلان: تقوم [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) بامتلاك موارد الصور المتضمنة من خلال [ImageCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagecollection/)، بينما يتحكم [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) في موضع الصورة، حجمها، تنسيق الخط، الدوران، القص، تأثيرات الصورة، وغيرها من إعدادات الإطار.

هذا الفصل مفيد عندما تُعرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ[PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) المرجع، واستخدم هذا المورد عند إنشاء إطارات الصورة.

يمكن لإطارات الصورة أن تحتوي على صور نقطية مثل PNG أو JPEG وصور متجهة SVG. يمكنها أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة في العرض. الاختيار يؤثر على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مدمجة**

لصورة مدمجة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). تصبح الصورة جزءًا من حزمة العرض، لذا يظل العرض مكتملًا عندما يُنقل إلى جهاز كمبيوتر آخر.

المثال التالي يضيف صورة PNG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوران:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغير أبعاد البكسل الأصلية المخزنة في مورد الصورة المدمجة. يصبح هذا التمييز مهمًا عند قص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

[PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) يتيح ضبط مقياس العرض والارتفاع النسبي للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). القيمة `1.0` تمثل 100% من حجم الصورة الأصلي. المقياس النسبي مفيد عندما تحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يغير المقياس النسبي إعدادات مقياس الإطار؛ لا يُعيد أخذ عينات أو ضغط الصورة المدمجة.

## **الصور المدمجة والمرتبطة**

الصورة المدمجة تخزن بيانات الصورة داخل العرض وبالتالي تُعد الخيار الأكثر أمانًا للنقل والعرض المتنبأ به. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [Picture.setLinkPathLong](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تُدخل تبعية خارجية. يجب أن يبقى الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار، أو تم نقل الملف، أو أصبح المورد غير متوفر، قد لا تُعرض الصورة المرتبطة كما هو متوقع. للعرض الذي يُرسل بالبريد الإلكتروني أو يُؤرشف أو يُعرض في بيئات معزولة، تكون الصور المدمجة عادةً أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويوجهه إلى ملف صورة محلي. يتعامل فقط مع ربط الصورة؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يُدمج في هذا المثال.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل للضغط فقط: PPTX صغير مع تبعيات صور مكسورة عادةً ما يكون أقل فائدة من عرض أكبر مكتمل ذاتيًا.

## **استخراج الصور من إطارات الصورة**

قبل استخراج صورة من عرض موجود، تأكد من أن الشكل هو فعلاً [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) وأنه يحتوي على صورة مدمجة. إطارات الصورة المرتبطة قد لا تحتوي على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات للصور الحديثة تستخدم [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) مباشرة. المثال التالي يجد أول صورة نقطية مدمجة على شريحة ويحفظها كـ PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

الحفظ عبر [IImage.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/#save) يحول الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت تحتاج إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محول، استخدم البيانات الثنائية لمورد الصورة.

### **استخراج صورة SVG**

لصورة SVG، يتيح [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرة بدلاً من تحويل الصورة أولاً.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجهي داخل العرض. تصدير النقطية مثل PNG أو JPEG يضطر إلى تحويل ذلك المحتوى المتجهي إلى بكسلات. تصدير الشريحة إلى PDF أو SVG أيضًا عملية تصيير، لذا لا ينبغي اعتبار الرسومات المصدرة نسخة بايت-بايت من SVG المدمج الأصلي؛ استخدم [SvgImage.getSvgData](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/#getSvgData--) عندما تكون الحاجة إلى المورد المتجهي الأصلي.

## **قص صورة**

القص يغيّر أي جزء من الصورة يكون مرئيًا داخل الإطار. قيم القص على [PictureFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. القص لا يحذف البكسلات المخفية من الصورة المدمجة في البداية؛ بل يغيّر المنطقة المرئية فقط.

المثال التالي يجد إطار صورة بأمان ويطبق قيم القص:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تغيير القص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أكثر أهمية من القابلية للعكس، يمكن إزالة المناطق المقصوصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) يزيل بيانات الصورة خارج مستطيل القص الحالي ويعيد مورد الصورة الناتج. يمكن أن يقلل ذلك من حجم الملف، لكنه تحسين مدمر: بعد حفظ العرض، لا تصبح البكسلات التي أزيلت متاحة لعملية إلغاء القص لاحقًا.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية مستخدمة أيضًا بواسطة إطارات صورة أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا حذف المناطق المقصوصة لا يقلل بالضرورة من إجمالي عدد الصور. قص محتوى WMF أو EMF بهذه الطريقة يُحول النتيجة المقصوصة إلى PNG.

## **ضغط الصور النقطية**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) يقلل من دقة الصورة النقطية نسبةً إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقصوصة في نفس العملية. تُعيد الطريقة `true` عندما تم تغيير حجم الصورة أو قصها و`false` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة مسبقة التعريف من [PicturesCompression](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturescompression/) عندما تكون دقة هدف قياسية كافية:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من قيمة مسبقة التعريف عندما يكون هدف محدد مطلوبًا.

الضغط مخصص للصور النقطية. لا يُقلل SVG أو محتوى ملفات الميتا هذا الضغط النقطي. وتذكر أيضًا أن الدقة الأقل والمناطق المقصوصة المحذوفة لا يمكن استردادها من العرض المُحسّن. اختر دقة الهدف بناءً على أكبر حجم ستُعرض به الصورة فعليًا أو تُصدّر بدلاً من تطبيق أقل DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

للحصول على سير عمل كامل يغطي السطوع، التباين، تحويلات اللون، الضبابية، تأثيرات الشفافية، السلاسل المرتبة، الفحص، الإزالة، والتحقق المتبادل، راجع [Image Transform Effects](/nodejs-java/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات [PictureFrameLock](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframelock/) تتحكم في عمليات التحرير التي تُعطّل لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) يحافظ على نسب الشكل أثناء تغيير حجمه.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

القفل يُطبق على شكل إطار الصورة. ولا يجبر الصورة المصدر على إعادة أخذ عينات أو تغيير دائم إلى نفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عندما يكون وضع تعبئة الصورة هو "stretch"، تحدد قيم الإزاحة على [PictureFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/) مستطيل التعبئة نسبةً إلى صندوق حد إطار الصورة. النسب المئوية الإيجابية تُنشئ مدخلًا من الحافة، بينما النسب السالبة تُنشئ خرجًا.

هذا يختلف عن القص. قيم القص تحدد أي جزء من الصورة المصدر يُظهر، بينما إزاحات التمدد تغير المستطيل الذي يُمتد إليه تعبئة الصورة المرئية.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

استخدم إزاحات التمدد لتحديد موضع التعبئة. استخدم خصائص القص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

تكون المقايضات الرئيسية أسهل في الإدارة عندما يتم التعامل مع تخزين الصور وتنسيق إطارات الصورة بصورة منفصلة:

- **الصور المدمجة** تجعل العرض مكتملًا ذاتيًا وتُعد الأكثر موثوقية للمشاركة والعرض على الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تحافظ على الحزمة أصغر، لكن العرض يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزنة.
- **القص** في البداية غير مدمر. تبقى البكسلات المخفية مدمجة حتى تُحذف المناطق المقصوصة صراحة أو تُزال أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الكبيرة الحجم، لكنه يضحي بدقة المصدر. ينبغي تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب أن تظل كـ SVG عندما تكون المحافظة على المتجه مهمة. استخرج SVG المدمج مباشرة عندما تحتاج إلى المورد المتجهي نفسه. تصدير الشرائح النقطية دائمًا يحول الشريحة المصدّر إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) موجود عندما يكون ذلك ممكنًا بدلًا من تحميل الملف نفسه repetitively في سير عمل العرض.

للعروض الكبيرة، يكون تحسين الصور أكثر فاعلية عادةً عندما يُطبق انتقائيًا: احتفظ بالشعارات والرسوم البيانية كمحتوى متجهي، اضغط الصور الفوتوغرافية وفقًا لحجم عرضها الفعلي، احذف البكسلات المقصوصة فقط عندما لا تكون الحاجة إلى تحرير لاحق، وتجنب الروابط الخارجية إلا إذا كان إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة الشائعة**

**ما هو الفرق بين إطار الصورة ومورد الصورة؟**

[PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) يمثل مورد صورة مرتبط بالعرض. [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) هو شكل على شريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، الدوران، قيم القص، التأثيرات، والقفل.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يجب أن يكون العرض قابلًا للنقل، مؤرشفًا، أو مُعرضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون الحفاظ على ملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يؤدي القص إلى تقليل حجم ملف PPTX؟**

ليس بمفرده. إعدادات القص العادية تخفي أجزاء من الصورة المصدر مع الحفاظ على البكسلات الأساسية. استخدم [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) أو ضغط الصورة مع إزالة المناطق المقصوصة عندما يمكن التخلص من تلك البكسلات نهائيًا.

**هل يمكنني استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة المخزنة، وإزالة المناطق المقصوصة تخلّص من بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض إذا كان قد يلزم تحرير عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون الدقة المتجهيّة مهمة. يمكن استخراج [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/) المدمج مباشرة. معالجة شريحة إلى تنسيق نقطي مثل PNG أو JPEG تُحوِّل SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكنني تجنب التحويلات غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام أعضاء خاصة بإطار الصورة. فحص `java.instanceOf` ضد [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) يمنع التحويلات غير الصالحة ويسمح للكود بمعالجة الشرائح التي لا تحتوي على إطارات صورة.