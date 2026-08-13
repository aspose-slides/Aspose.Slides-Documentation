---
title: إدارة خلفيات العروض التقديمية في جافا
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
description: "تعلم كيفية ضبط خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للغة جافا، مع نصائح برمجية لتعزيز عروضك التقديمية."
---
## **مقدمة**

الألوان الصلبة، والتدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية ل**شريحة عادية** (شريحة واحدة) أو ل**شريحة رئيسية** (تُطبّق على عدة شرائح في آن واحد).

![خلفية PowerPoint](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

Aspose.Slides يسمح لك بتعيين لون صلب كخلفية لشريحة معينة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. التغيير يطبق فقط على الشريحة المختارة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/backgroundtype/) للـشريحة إلى `OwnBackground`.
3. تعيين نوع تعبئة خلفية الشريحة [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) إلى `Solid`.
4. استخدام طريقة [getSolidFillColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/#getSolidFillColor--) على [FillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/) لتحديد اللون الصلب للخلفية.
5. حفظ العرض التقديمي المعدل.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من الفئة Presentation.
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

Aspose.Slides يسمح لك بتعيين لون صلب كخلفية لشريحة الرئيسة في عرض تقديمي. شريحة الرئيسة تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عند اختيار لون صلب لخلفية شريحة الرئيسة، يطبق ذلك على كل الشريحة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/backgroundtype/) (عبر `getMasters`) لشريحة الرئيسة إلى `OwnBackground`.
3. تعيين نوع تعبئة خلفية شريحة الرئيسة [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) إلى `Solid`.
4. استخدام طريقة [getSolidFillColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/#getSolidFillColor--) لتحديد اللون الصلب للخلفية.
5. حفظ العرض التقديمي المعدل.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من الفئة Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // تعيين لون خلفية شريحة الرئيسة إلى اللون الأخضر.
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

التدرج هو تأثير رسومي ينشأ من تغير تدريجي في اللون. عند استخدامه كخلفية للشريحة، يمكن للتدرجات أن تجعل العروض تبدو أكثر فنًا واحترافية. Aspose.Slides يسمح لك بتعيين لون متدرج كخلفية للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/backgroundtype/) للـشريحة إلى `OwnBackground`.
3. تعيين نوع تعبئة خلفية الشريحة [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) إلى `Gradient`.
4. استخدام طريقة [getGradientFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/#getGradientFormat--) على [FillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. حفظ العرض التقديمي المعدل.

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن من الفئة Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // تطبيق تأثير متدرج على الخلفية.
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

بالإضافة إلى التعبئات الصلبة والمتدرجة، Aspose.Slides يسمح لك باستخدام الصور كخلفيات للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/backgroundtype/) للـشريحة إلى `OwnBackground`.
3. تعيين نوع تعبئة خلفية الشريحة [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) إلى `Picture`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. إضافة الصورة إلى مجموعة صور العرض التقديمي.
6. استخدام طريقة [getPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/#getPictureFillFormat--) على [FillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. حفظ العرض التقديمي المعدل.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation.
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

    // تعيين وضع ملء الصورة إلى Tile وضبط خصائص البلاط.
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
اقرأ المزيد: [**صورة موزعة كنقش**](/slides/ar/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز. يوضح لك كود Java التالي كيفية تغيير الشفافية لصورة خلفية الشريحة:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // على سبيل المثال.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // الحصول على مجموعة عمليات تحويل الصورة.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // العثور على تأثير شفافية ثابت النسبة مئوية موجود.
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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الحصول على قيمة خلفية الشريحة**

Aspose.Slides توفر الواجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعّالة لخلفية الشريحة. هذه الواجهة تكشف عن الـ[FillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) والـ[EffectFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) الفعّالين.

باستخدام طريقة `getBackground` في الفئة [BaseSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعّالة لشريحة.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // استرداد الخلفية الفعّالة، مع مراعاة الشريحة الرئيسة، التخطيط، والموضوع.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

### هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية القالب/التخطيط؟

نعم. إزالة التعبئة المخصصة للشفريحة، وستُسترجع الخلفية مرة أخرى من شريحة [layout](/slides/ar/java/slide-layout/)/[master](/slides/ar/java/slide-master/) المقابلة (أي خلفية [theme](/slides/ar/java/presentation-theme/)).

### ماذا يحدث للخلفية إذا قمت بتغيير قالب العرض لاحقًا؟

إذا كان للشفريحة تعبئة خاصة بها، فستظل دون تغيير. إذا كانت الخلفية مُورّثة من شريحة [layout](/slides/ar/java/slide-layout/)/[master](/slides/ar/java/slide-master/)، فستُحدّث لتطابق [القالب الجديد](/slides/ar/java/presentation-theme/).