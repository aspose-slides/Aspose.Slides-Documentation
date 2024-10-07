---
title: خلفية العرض
type: docs
weight: 20
url: /java/presentation-background/
keywords: "خلفية باوربوينت، تعيين خلفية في جافا"
description: "تعيين الخلفية في عرض باوربوينت في جافا"
---

تُستخدم الألوان الصلبة، والألوان المتدرجة، والصور غالبًا كصور خلفية للشرائح. يمكنك تعيين الخلفية إما لــ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (عدة شرائح دفعة واحدة)

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **تعيين لون صلب كخلفية لشريحة عادية**

يتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة معينة في العرض (حتى لو كان هذا العرض يحتوي على شريحة رئيسية). يؤثر تغيير الخلفية فقط على الشريحة المحددة.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. عيّن قيمة [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) لــ الشريحة إلى `OwnBackground`.
3. عيّن قيمة [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) لــ خلفية الشريحة إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) الظاهرة في [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. احفظ العرض المعدل.

يوضح لك هذا الكود جافا كيفية تعيين لون صلب (أزرق) كخلفية لشريحة عادية: 

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Sets the background color for the first ISlide to Blue
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Writes the presentation to disk
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين لون صلب كخلفية لشريحة رئيسية**

يتيح لك Aspose.Slides تعيين لون صلب كخلفية للشريحة الرئيسية في العرض. تعمل الشريحة الرئيسية كقالب يحتوي على ويضبط إعدادات التنسيق لجميع الشرائح. لذلك، عندما تختار لونًا صلبًا كخلفية للشريحة الرئيسية، ستستخدم جميع الشرائح تلك الخلفية الجديدة.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. عيّن قيمة [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) لــ الشريحة الرئيسية (`Masters`) إلى `OwnBackground`.
3. عيّن قيمة [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) لــ خلفية الشريحة الرئيسية إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) الظاهرة في [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. احفظ العرض المعدل.

يوضح لك هذا الكود جافا كيفية تعيين لون صلب (أخضر غامق) كخلفية لشريحة رئيسية في عرض:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation();
try {
    // Sets the background color for the Master ISlide to Forest Green
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // Writes the presentation to disk
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين لون متدرج كخلفية لشريحة**

التدرج هو تأثير رسومي يعتمد على تغير تدريجي في اللون. تجعل الألوان المتدرجة، عند استخدامها كخلفيات للشرائح، العروض تبدو فنية واحترافية. يتيح لك Aspose.Slides تعيين لون متدرج كخلفية للشرائح في العروض.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. عيّن قيمة [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) لــ الشريحة إلى `OwnBackground`.
3. عيّن قيمة [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) لــ خلفية الشريحة الرئيسية إلى `Gradient`.
4. استخدم خاصية [GradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getGradientFormat--) الظاهرة في [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) لتحديد إعدادات التدرج المفضلة لديك.
5. احفظ العرض المعدل.

يوضح لك هذا الكود جافا كيفية تعيين لون متدرج كخلفية لشريحة:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Apply Gradient effect to the Background
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Gradient);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);
    
    // Writes the presentation to disk
    pres.save("ContentBG_Grad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين صورة كخلفية لشريحة**

بجانب الألوان الصلبة والألوان المتدرجة، يتيح لك Aspose.Slides أيضًا تعيين صور كخلفية للشرائح في العروض.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. عيّن قيمة [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) لــ الشريحة إلى `OwnBackground`.
3. عيّن قيمة [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) لــ خلفية الشريحة الرئيسية إلى `Picture`.
4. قم بتحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. أضف الصورة إلى مجموعة الصور في العرض.
6. استخدم خاصية [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getPictureFillFormat--) الظاهرة في [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض المعدل.

يوضح لك هذا الكود جافا كيفية تعيين صورة كخلفية لشريحة: 

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation();
try {
    // Sets conditions for background image
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Picture);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat()
            .setPictureFillMode(PictureFillMode.Stretch);
    
    // Loads the image
    IPPImage imgx;
    IImage image = Images.fromFile("Desert.jpg");
    try {
        imgx = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Adds image to presentation's images collection
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // Writes the presentation to disk
    pres.save("ContentBG_Img.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **تغيير شفافية صورة الخلفية**

قد ترغب في ضبط شفافية صورة خلفية الشريحة لجعل محتويات الشريحة تبرز. يوضح لك هذا الكود جافا كيفية تغيير الشفافية لصورة خلفية الشريحة:

```java
int transparencyValue = 30; // for example

// Gets a collection of picture transform operations
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Finds a transparency effect with fixed percentage.
AlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform)
{
    if (operation instanceof AlphaModulateFixed)
    {
        transparencyOperation = (AlphaModulateFixed)operation;
        break;
    }
}

// Sets the new transparency value.
if (transparencyOperation == null)
{
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **الحصول على قيمة خلفية الشريحة**

يوفر Aspose.Slides واجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/) للسماح لك بالحصول على القيم الفعالة لخلفيات الشرائح. تحتوي هذه الواجهة على معلومات حول [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

باستخدام خاصية [Background](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getBackground--) من فئة [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/)، يمكنك الحصول على القيمة الفعالة لخلفية شريحة.

يوضح لك هذا الكود جافا كيفية الحصول على قيمة الخلفية الفعالة لشريحة:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("لون التعبئة: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("نوع التعبئة: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```