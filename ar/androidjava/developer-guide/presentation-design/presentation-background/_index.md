---
title: إ管理 خلفيات العروض التقديمية على Android
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/androidjava/presentation-background/
keywords:
- خلفية العرض التقديمي
- خلفية الشريحة
- لون صلب
- لون متدرج
- خلفية صورة
- شفافية الخلفية
- خصائص الخلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية ضبط خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android عبر Java، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، التدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تنطبق على عدة شرائح في آن واحد).

![خلفية PowerPoint](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

Aspose.Slides يتيح لك تعيين لون صلب كخلفية لشريحة معينة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. يقتصر التغيير على الشريحة المحددة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. تعيين [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) لخلفية الشريحة إلى `Solid`.
4. استخدم طريقة [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) على [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

يوضح مثال Java التالي كيفية تعيين لون أزرق صلب كخلفية لشريحة عادية:
```java
// إنشاء مثيل من الفئة Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // تعيين لون خلفية الشريحة إلى الأزرق.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // حفظ العرض التقديمي إلى القرص.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين خلفية بلون صلب لشريحة رئيسية**

Aspose.Slides يتيح لك تعيين لون صلب كخلفية لشريحة الرئيس في عرض تقديمي. شريحة الرئيس تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عندما تختار لون صلب لخلفية شريحة الرئيس، سيُطبق على كل شريحة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. تعيين [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) لشريحة الرئيس (عبر `getMasters`) إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) لخلفية شريحة الرئيس إلى `Solid`.
4. استخدم طريقة [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

يوضح مثال Java التالي كيفية تعيين لون صلب (أخضر) كخلفية لشريحة الرئيس:
```java
// إنشاء مثيل من فئة Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // تعيين لون خلفية شريحة Master إلى الأخضر الغابي.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // حفظ العرض التقديمي إلى القرص.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يُنشأ بتغير تدريجي في اللون. عند استخدامه كخلفية للشريحة، يمكن أن يجعل العروض التقديمية أكثر فنًا واحترافية. Aspose.Slides يتيح لك تعيين لون متدرج كخلفية للشرائح.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. تعيين [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) لخلفية الشريحة إلى `Gradient`.
4. استخدم طريقة [getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) على [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. احفظ العرض التقديمي المعدل.

يوضح مثال Java التالي كيفية تعيين لون متدرج كخلفية لشريحة:
```java
// إنشاء مثيل من فئة Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // تطبيق تأثير متدرج على الخلفية.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // حفظ العرض التقديمي إلى القرص.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين صورة كخلفية للشفرة**

بالإضافة إلى التعبئة الصلبة والمتدرجة، Aspose.Slides يتيح لك استخدام الصور كخلفيات للشرائح.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. تعيين [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) لخلفية الشريحة إلى `Picture`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشفرة.
5. إضافة الصورة إلى مجموعة صور العرض التقديمي.
6. استخدم طريقة [getPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) على [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدل.

يوضح مثال Java التالي كيفية تعيين صورة كخلفية لشريحة:
```java
// إنشاء مثيل من فئة Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // تعيين خصائص صورة الخلفية.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // تحميل الصورة.
    IImage image = Images.fromFile("Tulips.jpg");
    // إضافة الصورة إلى مجموعة صور العرض التقديمي.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // حفظ العرض التقديمي إلى القرص.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


يوضح مثال الشيفرة التالي كيفية تعيين نوع تعبئة الخلفية إلى صورة متكررة وتعديل خصائص التكرار:
```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // تعيين الصورة المستخدمة لتعبئة الخلفية.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // تعيين وضع تعبئة الصورة إلى نمط البلاط وضبط خصائص البلاط.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}
اقرأ المزيد: [**صورة متكررة كنقشة**](/slides/ar/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لتبرز محتويات الشريحة. يوضح رمز Java التالي كيفية تغيير شفافية صورة خلفية الشريحة:
```java
int transparencyValue = 30; // على سبيل المثال.

// الحصول على مجموعة عمليات تحويل الصورة.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// العثور على تأثير شفافية ثابت النسبة المئوية موجود.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// تعيين قيمة الشفافية الجديدة.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **الحصول على قيمة خلفية الشريحة**

Aspose.Slides يوفر واجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعّالة لخلفية الشريحة. هذه الواجهة تكشف عن [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و[EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) الفعّالين.

باستخدام طريقة `getBackground` للفئة [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعّالة لشريحة.

يوضح مثال Java التالي كيفية الحصول على قيمة الخلفية الفعّالة للشريحة:
```java
// إنشاء مثيل من فئة Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // استرجاع الخلفية الفعّالة مع مراعاة الشريحة الرئيسة، التخطيط، والسمة.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية السمة/التخطيط؟**

نعم. أزل التعبئة المخصصة للشفرة، وستُستعاد الخلفية مرة أخرى من [التخطيط](/slides/ar/androidjava/slide-layout/)/[الرئيس](/slides/ar/androidjava/slide-master/) المقابل (أي [خلفية السمة](/slides/ar/androidjava/presentation-theme/)).

**ماذا يحدث للخلفية إذا قمت بتغيير سمة العرض التقديمي لاحقًا؟**

إذا كانت الشريحة تحتوي على تعبئتها الخاصة، فسيظل الخلفية دون تغيير. إذا كانت الخلفية مُستَهدَفة من [التخطيط](/slides/ar/androidjava/slide-layout/)/[الرئيس](/slides/ar/androidjava/slide-master/)، فستُحدَّث لتتماشى مع [السمة الجديدة](/slides/ar/androidjava/presentation-theme/).