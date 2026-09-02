---
title: إدارة إطارات الصور في العروض باستخدام JavaScript
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/nodejs-java/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مضمّنة
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
- تأثير صورة
- نسبة الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء، تنسيق، ربط، قص، استخراج، وضغط إطارات الصور في العروض باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنات منفصلة: تمتلك [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) موارد الصور المضمَّنة عبر [ImageCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagecollection/)، بينما يتحكم [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) في موضع الصورة وحجمها وتنسيق الخطوط والدوران والاقتصاص وتأثيرات الصورة وغيرها من إعدادات الإطار.

هذا الفصل مفيد عندما تُعرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ ب‏[PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) المعادة، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور أن تحتوي على صور نقطية مثل PNG أو JPEG وصور SVG المتجهة. يمكنها أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. الاختيار يؤثّر على قابلية النقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد كيفية تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمَّنة**

لصورة مضمَّنة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). تصبح الصورة جزءًا من حزمة العرض، وبالتالي يبقى العرض مستقلًا عندما يُنقل إلى جهاز كمبيوتر آخر.

المثال التالي يضيف صورة PNG، يخلق إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخطوط والدوران:

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

إطار الصورة يتحكم في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزنة في مورد الصورة المضمَّن. هذا التمييز يصبح مهمًا عند اقتصاص الصورة أو ضغطها لاحقًا.

## **استخدام المقياس النسبي**

[PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) يوفّر مقياس العرض والارتفاع النسبي للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). القيمة `1.0` تمثّل 100٪ من حجم الصورة الأصلي. المقياس النسبي مفيد عندما تحتاج سير عملية العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

المقياس النسبي يغيّر إعدادات مقياس الإطار؛ لا يعيد أخذ عينات أو ضغط الصورة المضمَّنة.

## **الصور المضمَّنة والمرتبطة**

الصورة المضمَّنة تخزن بيانات الصورة داخل العرض وبالتالي هي الخيار الأكثر أمانًا للنقل والعرض المتوقَّع. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [Picture.setLinkPathLong](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

الصور المرتبطة يمكن أن تقلل كمية بيانات الصورة المخزنة في PPTX، لكنها تُضيف اعتمادًا خارجيًا. يجب أن يبقى الملف المرتبط قابلًا للوصول من قبل التطبيق الذي يفتح أو يعرض العرض. إذا تغيّر المسار، أو نُقل الملف، أو أصبح المورد غير متاح، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. للعروض التي يجب إرسالها بالبريد الإلكتروني، أرشفتها، أو عرضها في بيئات منعزلة، تكون الصور المضمَّنة عادة أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يُدمج عمدًا في هذا المثال.

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

استخدم الروابط عندما يكون إدارة الملف الخارجي مقصودة. لا تستخدمها كبديل للضغط فقط: ملف PPTX صغير به تبعيات صورة مكسورة عادةً ما يكون أقل فائدة من عرض أكبر مستقل.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض موجود، تأكد أن الشكل هو فعلاً [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) وأنه يحتوي على صورة مضمَّنة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة تطبيقات الصورة الحديثة تستخدم [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) مباشرة. المثال التالي يجد أول صورة نقطية مضمَّنة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/#save) يحوّل الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت بحاجة إلى البايتات المشفّرة المخزنة في العرض بدلاً من ملف نقطي محوَّل، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

لصورة SVG، يُظهر [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/). هذا يتيح لك استرجاع بيانات SVG مباشرة بدلاً من تحويل الصورة إلى نقطية أولاً.

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

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض. الصادرات النقطية مثل PNG أو JPEG لا بدّ أن تُحوّل هذا المحتوى المتجه إلى بكسلات. تصدير الشريحة إلى PDF أو SVG أيضًا عملية عرض، لذا لا ينبغي اعتبار الرسومات المُصدَّرة نسخة مطابقة للبايت لكل بايت من SVG المضمَّن الأصلي؛ استخدم بيانات [SvgImage.getSvgData](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/#getSvgData--) المضمَّنة عندما يكون المورد المتجه الأصلي مطلوبًا.

## **اقتصاص صورة**

الاقتصاص يغيّر أي جزء من الصورة يكون مرئيًا داخل الإطار. قيم الاقتصاص على [PictureFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد صورة المصدر. الاقتصاص لا يحذف البكسلات المخفية من الصورة المضمَّنة في البداية؛ بل يغيّر المنطقة المرئية فقط.

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تغيير الاقتصاص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القابلية للعكس، يمكن إزالة المناطق المقصوصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) يزيل بيانات الصورة خارج مستطيل الاقتصاص الحالي ويعيد مورد الصورة الناتج. يمكن لهذا أن يقلل من حجم الملف، لكنه تحسين مدمر: بعد حفظ العرض، لا تكون البكسلات التي أزيلت متاحة لاحقًا لإجراء إلغاء الاقتصاص.

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

قد تُضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية مستخدمة أيضًا من قبل إطارات صور أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا فإن حذف المناطق المقصوصة لا يقلل بالضرورة من إجمالي عدد الصور. اقتصاص محتوى WMF أو EMF بهذه الطريقة يُحوِّل النتيجة المقصوصة إلى PNG.

## **ضغط الصور النقطية**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) يقلل من دقة الصورة النقطية بالنسبة للحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقصوصة في نفس العملية. تُرجع الطريقة `true` عندما تم تغيير حجم الصورة أو قصها و`false` عندما لم يكن هناك حاجة لتغيير.

استخدم قيمة مسبقة التعريف من [PicturesCompression](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturescompression/) عندما تكون الدقة المستهدفة القياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من القيمة المسبقة عندما يكون هدف محدد مطلوبًا.

الضغط مخصص للصور النقطية. محتوى SVG والملفات الوصفية لا يُقلَّص بهذا التدفق للضغط النقطي. وتذكر أيضًا أن الدقة المنخفضة والمناطق المقصوصة المحذوفة لا يمكن استرجاعها من العرض المُحسَّن. اختر دقة الهدف بناءً على أكبر حجم ستُعرض فيه الصورة فعليًا أو تُصدَّر بدلاً من تطبيق أقل DPI عالميًا.

## **فحص تأثيرات الصورة**

تُخزن تأثيرات الصورة على الصورة المستخدمة من قبل الإطار. مجموعة تحويلات الصورة يمكن أن تحتوي على تأثيرات مثل تعديل ألفا ثابت للشفافية والسطوع للإنارة والتباين. المثال أدناه يقرأ بأمان كلا النوعين من التأثيرات من أول إطار صورة على الشريحة:

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
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

هذه التأثيرات تغير طريقة عرض الصورة في الإطار؛ لا تعيد كتابة بايتات الصورة المضمَّنة الأصلية.

## **قفل هندسة إطار الصورة**

إعدادات [PictureFrameLock](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframelock/) تتحكم في عمليات التحرير التي تُعطَّل لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) يحافظ على نسب الشكل أثناء تغيير حجمه.

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

القفل يطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة أخذ عينات أو تغيير دائم إلى نفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على وضع التمدد، تُعرّف قيم الـ stretch‑offset على [PictureFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/) مستطيل التعبئة نسبة إلى صندوق إطار الصورة. النسب المئوية الإيجابية تُنشئ تقليمًا من الحافة، بينما النسب السالبة تُنشئ بُعدًا.

هذا مختلف عن الاقتصاص. قيم الاقتصاص تحدد أي جزء من صورة المصدر يظهر؛ قيم الـ stretch تُغيّر المستطيل الذي يتم فيه تمديد ملء الصورة المرئي.

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

استخدم قيم الـ stretch لتحديد موضع الملء. استخدم خصائص الاقتصاص عندما يكون الهدف إخفاء حواف صورة المصدر.

## **الاعتبارات المتعلقة بالتخزين وحجم الملف والتصدير**

من الأسهل إدارة المقايضات الرئيسية عندما تُعامل تخزين الصور وتنسيق إطارات الصور بشكل منفصل:

- **الصور المضمَّنة** تجعل العرض مستقلًا وتُعدّ الأكثر موثوقية للمشاركة والعرض من جانب الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تُصغّر الحزمة، لكن العرض يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزّنة.
- **الاقتصاص** غير مدمر في البداية. تظل البكسلات المخفية مضمَّنة حتى تُحذف المناطق المقصوصة صراحةً أو تُزال أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل ملحوظ للصور النقطية الضخمة، لكنه يَفْقَد الدقة الأصلية. يجب تطبيقه بعد معرفة الحجم المقصود على الشريحة.
- **صور SVG** يجب أن تبقى كـ SVG عندما تكون الحفاظ على المتجه مهمًا. استخرج الـ SVG المضمَّن مباشرة عندما تحتاج إلى المورد المتجه نفسه. تصدير الشرائح إلى نقطية دائمًا ما يحوّل الشريحة المرسومة إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) الحالي عندما يكون ذلك ممكنًا بدلاً من تحميل الملف نفسه مرارًا في سير عمل العرض.

للعروض الكبيرة، عادةً ما تكون تحسينات الصورة أكثر فاعلية عندما تُجرى بشكل انتقائي: احتفظ بالشعارات والمخططات كمتجهات، اضغط الصور الفوتوغرافية وفقًا لحجم العرض الفعلي، أزل البكسلات المقصوصة فقط عندما لا تكون التعديلات المستقبلية مطلوبة، وتجنّب الروابط الخارجية ما لم يكن إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتداولة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

[PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) يمثل مورد صورة مرتبط بالعرض. [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) هو شكل على شريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، الدوران، قيم الاقتصاص، التأثيرات، والقفل.

**هل يجب أن أدرج الصور أم أربطها؟**

استخدم الإدراج عندما يجب أن يكون العرض قابلاً للنقل، مؤرشفًا، أو معروضًا دون الاعتماد على موارد خارجية. اربط الصور فقط عندما يكون حفظ ملفات الصورة خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل الاقتصاص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات الاقتصاص العادية تُخفي أجزاء من صورة المصدر لكن تظل البكسلات الأساسية مخزَّنة. استخدم [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) أو ضغط الصورة مع إزالة المناطق المقصوصة عندما يمكن التخلص من تلك البكسلات نهائيًا.

**هل يمكنني استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة النقطية المخزَّنة، وإزالة المناطق المقصوصة تُفقد بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض إذا كان قد يلزم تعديل عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

حافظ على محتوى SVG كـ SVG عندما تكون دقة المتجه مهمة. يمكن استخراج الـ [SvgImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/) المضمَّن مباشرة. تحويل شريحة إلى تنسيق نقطي مثل PNG أو JPEG يُحوِّل الـ SVG كجزء من صورة الشريحة.

**كيف يمكنني تجنب عمليات التحويل غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام أعضاء خاصة بإطار الصورة. فحص `java.instanceOf` مقابل [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) يُجنب التحويلات غير الصالحة ويسمح للكود بالتعامل مع الشرائح التي لا تحتوي على إطارات صور.