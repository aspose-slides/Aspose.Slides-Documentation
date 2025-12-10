---
title: إدارة خلفيات العرض التقديمي في جافا
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/java/presentation-background/
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
- جافا
- Aspose.Slides
description: "تعلم كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides لجافا، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، التدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تنطبق على عدة شرائح في آن واحد).

![خلفية PowerPoint](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

تسمح لك Aspose.Slides بتعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. يتم تطبيق التغيير على الشريحة المحددة فقط.

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. عيّن [BackgroundType] للشريحة إلى `OwnBackground` .
3. عيّن [FillType] لخلفية الشريحة إلى `Solid` .
4. استخدم طريقة [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) على الفئة [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) لتحديد لون الخلفية الصلبة.
5. احفظ العرض التقديمي المعدل.

يوضح مثال Java التالي كيفيّة تعيين لون أزرق صلب كخلفية لشريحة عادية:
```java
// إنشاء مثيل من فئة Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // تعيين لون خلفية الشريحة إلى اللون الأزرق.
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

تسمح لك Aspose.Slides بتعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عند اختيار لون صلب لخلفية الشريحة الرئيسية، سيتم تطبيقه على كل الشريحة.

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. عيّن [BackgroundType] للشريحة الرئيسية (عبر `getMasters`) إلى `OwnBackground` .
3. عيّن [FillType] لخلفية الشريحة الرئيسية إلى `Solid` .
4. استخدم طريقة [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

يوضح مثال Java التالي كيفيّة تعيين لون صلب (أخضر) كخلفية لشريحة رئيسية:
```java
// إنشاء مثيل من فئة Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // تعيين لون خلفية شريحة الماستر إلى اللون الأخضر الغابوي.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // حفظ العرض التقديمي إلى القرص.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين خلفية بتدرّج لشريحة**

التدرّج هو تأثير رسومي يُنشئ بواسطة تغير تدريجي في اللون. عند استخدامه كخلفية للشرائح، يمكن للتدرجات أن تجعل العروض التقديمية تبدو أكثر إبداعًا واحترافية. تسمح لك Aspose.Slides بتعيين لون متدرّج كخلفية للشرائح.

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. عيّن [BackgroundType] للشريحة إلى `OwnBackground` .
3. عيّن [FillType] لخلفية الشريحة إلى `Gradient` .
4. استخدم طريقة [getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getGradientFormat--) على الفئة [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) لتكوين إعدادات التدرّج المفضلة.
5. احفظ العرض التقديمي المعدل.

يوضح مثال Java التالي كيفيّة تعيين لون متدرّج كخلفية لشريحة:
```java
// إنشاء مثيل من فئة Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // تطبيق تأثير تدرج على الخلفية.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // حفظ العرض التقديمي إلى القرص.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين صورة كخلفية للشريحة**

بالإضافة إلى التعبئات الصلبة والمتدرجة، تسمح لك Aspose.Slides باستخدام الصور كخلفيات للشرائح.

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. عيّن [BackgroundType] للشريحة إلى `OwnBackground` .
3. عيّن [FillType] لخلفية الشريحة إلى `Picture` .
4. حمّل الصورة التي تريد استخدامها كخلفية للشريحة.
5. أضف الصورة إلى مجموعة صور العرض التقديمي.
6. استخدم طريقة [getPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getPictureFillFormat--) على الفئة [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدل.

يوضح مثال Java التالي كيفيّة تعيين صورة كخلفية لشريحة:
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


يوضح عينة الكود التالية كيفيّة تعيين نوع تعبئة الخلفية إلى صورة متكررة وتعديل خصائص التكرار:
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

    // تعيين الصورة المستخدمة لملء الخلفية.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // تعيين وضع ملء الصورة إلى تكرار وضبط خصائص التكرار.
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
اقرأ المزيد: [**صورة متكررة كنقشة**](/slides/ar/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز أكثر. يوضح الكود Java التالي كيفية تغيير شفافية صورة خلفية الشريحة:
```java
int transparencyValue = 30; // على سبيل المثال.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **الحصول على قيمة خلفية الشريحة**

توفر Aspose.Slides الواجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعّالة لخلفية الشريحة. تكشف هذه الواجهة عن [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و[EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) الفعّاليين.

باستخدام طريقة `getBackground` من الفئة [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعّالة لشريحة.

يوضح مثال Java التالي كيفيّة الحصول على قيمة الخلفية الفعّالة لشريحة:
```java
// إنشاء مثيل من فئة Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // استرجاع الخلفية الفعّالة مع مراعاة الشريحة الرئيسية، التخطيط، والسمة.
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

**هل يمكنني إعادة ضبط خلفية مخصصة واستعادة خلفية السمة/التخطيط؟**  
نعم. قم بإزالة التعبئة المخصصة للشريحة، وسيتم وراثة الخلفية مرة أخرى من [التخطيط](/slides/ar/java/slide-layout/)/[الماستر](/slides/ar/java/slide-master/) (أي [خلفية السمة](/slides/ar/java/presentation-theme/)).

**ماذا يحدث للخلفية إذا قمت بتغيير سمة العرض التقديمي لاحقًا؟**  
إذا كانت الشريحة تحتوي على تعبئة خاصة بها، فستظل دون تغيير. إذا كانت الخلفية موروثة من [التخطيط](/slides/ar/java/slide-layout/)/[الماستر](/slides/ar/java/slide-master/)، فستُحدَّث لتطابق [السمة الجديدة](/slides/ar/java/presentation-theme/).