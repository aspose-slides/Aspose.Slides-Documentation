---
title: إدارة إطارات الصور في العروض التقديمية باستخدام JavaScript
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/nodejs-java/picture-frame/
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
- حذف المناطق المُقتَصَة
- ضغط صورة
- إزاحة التمدد
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير صورة
- نسبة عرض إلى ارتفاع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء، تنسيق، ربط، اقتصاص، استخراج، وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides ، مورد الصورة والشكل الذي يعرضها كائنات منفصلة: يمتلك كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) موارد الصور المضمنة عبر [ImageCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagecollection/)، بينما يتحكم كائن [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) في موضع الصورة وحجمها وتنسيق الخط والدوران والاقتصاص وتأثيرات الصورة وغيرها من إعدادات الإطار.

هذا الفصل مفيد عندما يتم عرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بكائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) الذي تم إرجاعه، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور احتواء صور نقطية مثل PNG أو JPEG وصور SVG المتجهة. يمكنها أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. يؤثر الاختيار على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد كيفية تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مدمجة**

لصورة مدمجة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). تصبح الصورة جزءًا من حزمة العرض، وبالتالي يبقى العرض مستقلًا عند نقله إلى كمبيوتر آخر.

المثال التالي يضيف صورة PNG، وينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوران:

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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر الأبعاد البكسلية الأصلية المخزنة في مورد الصورة المدمجة. يصبح هذا التمييز مهمًا عند اقتصاص الصورة أو ضغطها لاحقًا.

## **استخدام المقياس النسبي**

يقدم كائن [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) مقياس العرض والارتفاع النسبي للإطار من خلال [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). القيمة `1.0` تمثل 100٪ من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

تغيّر المقياس النسبي إعدادات مقياس الإطار؛ لا يعيد أخذ عينات أو ضغط الصورة المدمجة.

## **الصور المدمجة والمرتبطة**

الصورة المدمجة تخزن بيانات الصورة داخل العرض وبالتالي تُعتبر الخيار الأكثر أمانًا للنقل وعرض ثابت. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [Picture.setLinkPathLong](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يبقى الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار، أو تم نقل الملف، أو أصبح المورد غير متاح، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. بالنسبة للعروض التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المدمجة عادةً أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصورة؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يتم خلطه عمدًا في هذا المثال.

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

استخدم الروابط عندما يكون إدارة الملف الخارجي مقصودة. لا تستخدمها كبديل عن الضغط فقط: PPTX صغير يحتوي على تبعيات صور مكسورة عادةً ما يكون أقل فائدة من عرض أكبر مستقل.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض موجود، تحقق من أن الشكل هو فعليًا [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) وأنه يحتوي على صورة مدمجة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

يستخدم API الصورة الحديث كائن [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) مباشرة. المثال التالي يجد أول صورة نقطية مدمجة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/#save) يحول الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت تحتاج إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محول، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

لصورة SVG، يوفر كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) كائن [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرةً بدلاً من تحويل الصورة إلى نقطية أولاً.

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

الحفاظ على محتوى SVG كـ SVG يحفظ المصدر المتجهي داخل العرض. تصدير النقطية مثل PNG أو JPEG يُجبر على تحويل ذلك المحتوى المتجهي إلى بكسلات. تصدير الشريحة كـ PDF أو SVG هو أيضًا عملية عرض، لذا لا يجب اعتبار الرسومات المصدرة نسخة بايت-ل-بايت من SVG المدمج الأصلي؛ استخدم بيانات [SvgImage.getSvgData](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/#getSvgData--) عندما تكون الحاجة إلى المورد المتجهي الأصلي.

## **اقتصاص صورة**

يغيّر الاقتصاص الجزء الظاهر من الصورة داخل الإطار. قيم الاقتصاص على [PictureFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. لا يحذف الاقتصاص البكسلات المخفية من الصورة المدمجة في البداية؛ بل يغيّر المنطقة الظاهرة فقط.

المثال التالي يجد إطار صورة بأمان ويطبق قيم الاقتصاص:

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تغيير الاقتصاص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أكثر أهمية من القابلية للعودة، يمكن إزالة المناطق المُقتَصَة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المُقتَصَة**

يُزيل [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) بيانات الصورة خارج مستطيل الاقتصاص الحالي ويُعيد مورد الصورة الناتج. يمكن أن يقلل هذا من حجم الملف، لكنه تحسين مدمر: بعد حفظ العرض، لا تعود البكسلات التي تم إزالتها متاحة لعملية إلغاء الاقتصاص لاحقًا.

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

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية تُستخدم أيضًا من قبل إطارات صور أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا لا يؤدي حذف المناطق المُقتَصَة بالضرورة إلى تقليل إجمالي عدد الصور. اقتصاص محتوى WMF أو EMF بهذه الطريقة يحول النتيجة المقتَصَة إلى PNG.

## **ضغط الصور النقطية**

يقلل [PictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) دقة الصورة النقطية بالنسبة إلى الحجم الذي تُعرض عليه الصورة. يمكنه أيضًا إزالة المناطق المُقتَصَة في نفس العملية. تُرجع الطريقة `true` عندما يتم تغيير حجم الصورة أو اقتصاصها و`false` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturescompression/) معرفة مسبقًا عندما يكون دقة هدف قياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من قيمة معرفة مسبقًا عندما يكون هدف محدد مطلوبًا.

الضغط مخصص للصور النقطية. لا يتم تقليل محتوى SVG أو ملفات الميتافايل بهذه العملية. تذكر أيضًا أن الدقة المنخفضة والمناطق المُقتَصَة المحذوفة لا يمكن استعادتها من العرض المُحسّن. اختر دقة الهدف بناءً على أكبر حجم ستُعرض فيه الصورة فعليًا أو تُصدر بدلاً من تطبيق أقل DPI على المستوى العام.

## **إدارة تأثيرات تحويل الصورة**

للحصول على سير عمل كامل يغطي السطوع، التباين، تحويلات اللون، التشويش، تأثيرات ألفا، السلاسل المرتبة، الفحص، الإزالة، والتحقق من دورة الحياة، راجع [Image Transform Effects](/slides/ar/nodejs-java/image-transform-effects/).

## **قفل هندسة إطار الصورة**

تتحكم إعدادات [PictureFrameLock](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframelock/) في أي عمليات تحرير تُعطَّل لإطار الصورة. على سبيل المثال، يحافظ [setAspectRatioLocked](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) على نسب الشكل أثناء تغيير حجمه.

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

القفل يُطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة أخذ عينات أو تغيير دائم إلى نفس نسبة العرض إلى الارتفاع.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على وضع التمدد، تحدد قيم الـ stretch‑offset على [PictureFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/) مستطيل الملء بالنسبة إلى صندوق الإطار. النسب المئوية الموجبة تُنشئ إزاحة داخلية من الحافة، بينما النسب السالبة تُنشئ إزاحة خارجية.

هذا مختلف عن الاقتصاص. قيم الاقتصاص تحدد أي جزء من الصورة المصدر يُظهر، بينما تغير إزاحات التمدد المستطيل الذي يُتمدد فيه ملء الصورة الظاهر.

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

استخدم إزاحات التمدد لتحديد موضع الملء. استخدم خصائص الاقتصاص عندما يكون الهدف إخفاء حدود الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

تكون المقايضات الرئيسية أسهل في الإدارة عند التعامل مع تخزين الصور وتنسيق إطارات الصور بشكل منفصل:

- **الصور المدمجة** تجعل العرض مستقلًا وتُعد الأكثر موثوقية للمشاركة وعرض الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستهلاك الذاكرة.
- **الصور المرتبطة** يمكن أن تجعل الحزمة أصغر، لكن العرض يعتمد على الملفات الخارجية المتاحة في المسارات المخزنة.
- **الاقتصاص** في البداية غير مدمر. تظل البكسلات المخفية مدمجة حتى يتم حذف المناطق المُقتَصَة صراحةً أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يفضح دقة المصدر. يجب تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب أن تظل كـ SVG عندما تكون المحافظة على المتجه مهمة. استخرج SVG المدمج مباشرةً عندما تحتاج إلى المورد المتجهي ذاته. تصدير الشرائح كصور نقطية دائمًا يحول الشريحة إلى بكسلات.
- **الصور المتكررة** يجب إعادة استخدام مورد [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) موجود عندما يكون ذلك ممكنًا بدلاً من تحميل الملف نفسه مرارًا وتكرارًا في سير عمل العرض.

في العروض الكبيرة، يكون تحسين الصور عادةً أكثر فاعلية عندما يُجرى بشكل انتقائي: حافظ على الشعارات والمخططات كمحتوى متجه، اضغط الصور الفوتوغرافية وفقًا لحجم العرض الفعلي، احذف البكسلات المُقتَصَة فقط عندما لا تكون هناك حاجة لتحرير لاحق، وتجنب الروابط الخارجية إلا إذا كان إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة الشائعة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

يمثل كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) مورد صورة مرتبط بالعرض. بينما يعد كائن [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) شكلاً على شريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، الدوران، قيم الاقتصاص، التأثيرات، والقفلات.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يجب أن يكون العرض قابلًا للنقل أو مؤرشفًا أو مُعرضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون الحفاظ على الملفات خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل الاقتصاص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات الاقتصاص العادية تخفي أجزاء من الصورة المصدر لكن تحتفظ بالبكسلات الأساسية. استخدم [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) أو ضغط الصورة مع إزالة المناطق المُقتَصَة عندما يمكن حذف هذه البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة النقطية المخزنة، وإزالة المناطق المُقتَصَة تحذف بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض إذا كان قد يُطلب تحرير عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

حافظ على محتوى SVG كـ SVG عندما تكون الدقة المتجهية مهمة. يمكن استخراج كائن [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/) المدمج مباشرةً. عرض شريحة إلى تنسيق نقطي مثل PNG أو JPEG يُحول SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكن تجنب التحويلات غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام الأعضاء الخاصة بإطار الصورة. فحص `java.instanceOf` ضد [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) يجنب التحويلات غير الصحيحة ويسمح للكود بمعالجة الشرائح التي لا تحتوي على إطارات صور.