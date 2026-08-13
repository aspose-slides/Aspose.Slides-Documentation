---
title: إدارة خلفيات العرض التقديمي على Android
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
description: "تعلم كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لأندرويد عبر Java، مع نصائح برمجية لتعزيز عروضك التقديمية."
---
## **المقدمة**

الألوان الصلبة، التدرجات اللونية، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تنطبق على عدة شرائح في آنٍ واحد).

![خلفية PowerPoint](powerpoint-background.png)

## **تعيين خلفية صلبة اللون لشريحة عادية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي— حتى إذا كان العرض يستخدم شريحة رئيسية. التغيير يُطبق فقط على الشريحة المختارة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. تعيين [BackgroundType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/backgroundtype/) الخاص بالشريحة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) الخلفي للشريحة إلى `Solid`.
4. استخدم طريقة [getSolidFillColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) على فئة [FillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة Java يوضح كيفية تعيين لون أزرق صلب كخلفية لشريحة عادية:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation.
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

## **تعيين خلفية صلبة اللون لشريحة رئيسية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. تعمل الشريحة الرئيسية كقالب يتحكم في تنسيق جميع الشرائح، لذا عندما تختار لونًا صلبًا لخلفية الشريحة الرئيسية، يُطبق على كل شريحة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. تعيين [BackgroundType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/backgroundtype/) الخاص بالشريحة الرئيسية (عبر `getMasters`) إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) الخلفي للشريحة الرئيسية إلى `Solid`.
4. استخدم طريقة [getSolidFillColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة Java يوضح كيفية تعيين لون صلب (أخضر) كخلفية للشريحة الرئيسية:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // تعيين لون خلفية الشريحة الرئيسية إلى اللون الأخضر.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // حفظ العرض التقديمي إلى القرص.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين خلفية متدرجة للشريحة**

التدرج اللوني هو تأثير رسومي يُنشأ بتغير تدريجي في اللون. عند استخدامه كخلفية للشريحة، يمكن أن يجعل العروض التقديمية تبدو أكثر فنيةً ومهنيةً. تتيح لك Aspose.Slides تعيين لون متدرج كخلفية للشرائح.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. تعيين [BackgroundType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/backgroundtype/) الخاص بالشريحة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) الخلفي للشريحة إلى `Gradient`.
4. استخدم طريقة [getGradientFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) على فئة [FillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة Java يوضح كيفية تعيين لون متدرج كخلفية لشريحة:

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من فئة Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // تطبيق تأثير التدرج على الخلفية.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // إضافة ألوان التدرج. بدون نقاط التدرج، ستعود الخلفية إلى تدرج افتراضي من الأسود إلى الأبيض.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // حفظ العرض التقديمي إلى القرص.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين صورة كخلفية للشريحة**

بالإضافة إلى التعبئات الصلبة والمتدرجة، تتيح لك Aspose.Slides استخدام الصور كخلفيات للشرائح.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/).
2. تعيين [BackgroundType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/backgroundtype/) الخاص بالشريحة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) الخلفي للشريحة إلى `Picture`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. إضافة الصورة إلى مجموعة صور العرض التقديمي.
6. استخدم طريقة [getPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) على فئة [FillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدل.

المثال التالي بلغة Java يوضح كيفية تعيين صورة كخلفية لشريحة:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation.
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

المثال التالي يوضح كيفية تعيين نوع تعبئة الخلفية إلى صورة متكررة وتعديل خصائص التكرار:

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}

اقرأ المزيد: [**صورة متكررة كملمس**](/slides/ar/androidjava/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتويات الشريحة تبرز. يوضح الكود التالي بلغة Java كيفية تغيير شفافية صورة خلفية الشريحة:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // على سبيل المثال.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // الحصول على مجموعة عمليات تحويل الصورة.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // البحث عن تأثير شفافية ثابت النسبة المئوية موجود.
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

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الحصول على قيمة خلفية الشريحة**

توفر Aspose.Slides واجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibackgroundeffectivedata/) لاسترجاع قيم الخلفية الفعلية للشريحة. تعرض هذه الواجهة [FillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و[EffectFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) الفعليين.

باستخدام طريقة `getBackground` الخاصة بفئة [BaseSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعلية لشريحة.

المثال التالي بلغة Java يوضح كيفية الحصول على قيمة الخلفية الفعلية لشريحة:

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // استرجاع الخلفية الفعلية مع مراعاة الشريحة الرئيسية، التخطيط، والسمة.
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

### هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية السمة/التخطيط؟

نعم. أزل تعبئة الشريحة المخصصة، وستُورث الخلفية مرة أخرى من شريحة [layout](/slides/ar/androidjava/slide-layout/)/[master](/slides/ar/androidjava/slide-master/) المقابلة (أي خلفية [theme background](/slides/ar/androidjava/presentation-theme/)).

### ماذا يحدث للخلفية إذا غيرت سمة العرض التقديمي لاحقًا؟

إذا كان لدى الشريحة تعبئة خاصة بها، ستظل دون تغيير. إذا كانت الخلفية مُورّثة من [layout](/slides/ar/androidjava/slide-layout/)/[master](/slides/ar/androidjava/slide-master/)، فستُحدَّث لمطابقة السمة [new theme](/slides/ar/androidjava/presentation-theme/).