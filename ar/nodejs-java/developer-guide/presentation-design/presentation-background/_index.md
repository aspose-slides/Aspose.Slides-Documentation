---
title: إدارة خلفيات العروض التقديمية في JavaScript
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/nodejs-java/presentation-background/
keywords:
- خلفية العرض التقديمي
- خلفية الشريحة
- لون صلب
- لون متدرج
- خلفية الصورة
- شفافية الخلفية
- خصائص الخلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، التدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تُطبق على عدة شرائح في آن واحد).

![خلفية PowerPoint](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

يتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. ينطبق التغيير فقط على الشريحة المحددة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. تعيين خاصية [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) لخلفية الشريحة إلى `Solid`.
4. استخدام الطريقة [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) على الفئة [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة JavaScript يوضح كيفية تعيين لون أزرق صلب كخلفية لشريحة عادية:
```js
// إنشاء نسخة من الفئة Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // تعيين لون خلفية الشريحة إلى الأزرق.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // حفظ العرض التقديمي على القرص.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين خلفية بلون صلب للشريحة الرئيسية**

يتيح لك Aspose.Slides تعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عندما تختار لونًا صلبًا لخلفية الشريحة الرئيسية، فإنه يطبق على كل شريحة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. تعيين خاصية [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) (عبر `getMasters`) للشريحة الرئيسية إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) لخلفية الشريحة الرئيسية إلى `Solid`.
4. استخدام الطريقة [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة JavaScript يوضح كيفية تعيين لون صلب (أخضر) كخلفية للشريحة الرئيسية:
```js
// إنشاء نسخة من فئة Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // تعيين لون خلفية الشريحة الرئيسة إلى الأخضر الغابي.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // حفظ العرض التقديمي على القرص.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي ينتج عن تغيير اللون تدريجيًا. عند استخدامه كخلفية للشرائح، يمكن للتدرجات جعل العروض تبدو أكثر إبداعًا واحترافية. يتيح لك Aspose.Slides تعيين لون متدرج كخلفية للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. تعيين خاصية [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) لخلفية الشريحة إلى `Gradient`.
4. استخدام الطريقة [getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) على الفئة [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة JavaScript يوضح كيفية تعيين لون متدرج كخلفية للشفرة:
```js
// إنشاء نسخة من فئة Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // تطبيق تأثير تدرج على الخلفية.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // حفظ العرض التقديمي على القرص.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين صورة كخلفية للشريحة**

بالإضافة إلى التعبئة الصلبة والمتدرجة، يتيح لك Aspose.Slides استخدام الصور كخلفيات للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. تعيين خاصية [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) لخلفية الشريحة إلى `Picture`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشفرة.
5. إضافة الصورة إلى مجموعة صور العرض التقديمي.
6. استخدام الطريقة [getPictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) على الفئة [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدل.

المثال التالي بلغة JavaScript يوضح كيفية تعيين صورة كخلفية للشفرة:
```js
// إنشاء نسخة من الفئة Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // تعيين خصائص صورة الخلفية.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // تحميل الصورة.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // إضافة الصورة إلى مجموعة صور العرض التقديمي.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // حفظ العرض التقديمي على القرص.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


المثال التالي يوضح كيفية تعيين نوع ملء الخلفية إلى صورة مكررة وتعديل خصائص التكرار:
```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // تعيين الصورة المستخدمة لملء الخلفية.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // تعيين وضع ملء الصورة إلى تجانب وتعديل خصائص التجانب.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}
اقرأ المزيد: [**صورة متكررة كنسيج**](/slides/ar/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في ضبط شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز. يظهر الكود التالي بلغة JavaScript كيفية تغيير الشفافية لصورة خلفية الشريحة:
```js
var transparencyValue = 30; // كمثال.

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **الحصول على قيمة خلفية الشريحة**

توفر Aspose.Slides الفئة `BackgroundEffectiveData` لاسترجاع القيم الفعلية لخلفية الشريحة. تكشف هذه الفئة عن القيم الفعلية لـ [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) و[EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/).

باستخدام طريقة `getBackground` من الفئة [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعلية لشريحة.

المثال التالي بلغة JavaScript يوضح كيفية الحصول على قيمة الخلفية الفعلية لشريحة:
```js
// إنشاء نسخة من الفئة Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // استرجاع الخلفية الفعلية مع مراعاة الشريحة الرئيسية، التخطيط، والموضوع.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية القالب/التخطيط؟**

نعم. احذف التعبئة المخصصة للشفرة، وستتم وراثة الخلفية مرة أخرى من شريحة [layout](/slides/ar/nodejs-java/slide-layout/)/[master](/slides/ar/nodejs-java/slide-master/) المقابلة (أي من [theme background](/slides/ar/nodejs-java/presentation-theme/)).

**ماذا يحدث للخلفية إذا قمت بتغيير سمة العرض لاحقًا؟**

إذا كان للشفرة تعبئة خاصة بها، فستبقى دون تغيير. إذا كانت الخلفية موروثة من [layout](/slides/ar/nodejs-java/slide-layout/)/[master](/slides/ar/nodejs-java/slide-master/)، فستُحدَّث لتطابق [new theme](/slides/ar/nodejs-java/presentation-theme/).