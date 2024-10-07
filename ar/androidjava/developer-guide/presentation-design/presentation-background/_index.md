---
title: خلفية العرض التقديمي
type: docs
weight: 20
url: /androidjava/presentation-background/
keywords: "خلفية باوربوينت، تعيين خلفية في جافا"
description: "تعيين الخلفية في عرض تقديمي لباوربوينت باستخدام جافا"
---

تستخدم الألوان الصلبة، والألوان المتدرجة، والصور غالبًا كصور خلفية للشرائح. يمكنك تعيين الخلفية إما لــ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (عدة شرائح في وقت واحد)

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **تعيين لون صلب كخلفية لشريحة عادية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة معينة في عرض تقديمي (حتى لو كان هذا العرض يحتوي على شريحة رئيسية). تؤثر تغيير الخلفية فقط على الشريحة المحددة.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. عيّن تعداد [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. عيّن تعداد [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) لخلفية الشريحة إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) التي توفرها [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. احفظ العرض التقديمي المعدل.

يظهر لك هذا الرمز بلغة جافا كيفية تعيين لون صلب (أزرق) كخلفية لشريحة عادية:

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

تتيح لك Aspose.Slides تعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. تعمل الشريحة الرئيسية كقالب يحتوي على إعدادات التنسيق الخاصة بجميع الشرائح. لذلك، عند اختيار لون صلب كخلفية للشريحة الرئيسية، ستستخدم هذه الخلفية الجديدة لجميع الشرائح.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. عيّن تعداد [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) للشريحة الرئيسية (`Masters`) إلى `OwnBackground`.
3. عيّن تعداد [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) لخلفية الشريحة الرئيسية إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) التي توفرها [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. احفظ العرض التقديمي المعدل.

يظهر لك هذا الرمز بلغة جافا كيفية تعيين لون صلب (أخضر غابة) كخلفية لشريحة رئيسية في عرض تقديمي:

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

التدرج هو تأثير رسومي يعتمد على تغيير تدريجي في اللون. تجعل الألوان المتدرجة، عند استخدامها كخلفيات للشرائح، العروض التقديمية تبدو فنية واحترافية. تسمح لك Aspose.Slides بتعيين لون متدرج كخلفية للشرائح في العروض التقديمية.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. عيّن تعداد [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. عيّن تعداد [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) لخلفية الشريحة الرئيسية إلى `Gradient`.
4. استخدم خاصية [GradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) التي توفرها [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) لتحديد إعدادات التدرج المفضلة لديك.
5. احفظ العرض التقديمي المعدل.

يظهر لك هذا الرمز بلغة جافا كيفية تعيين لون متدرج كخلفية لشريحة:

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

بجانب الألوان الصلبة والألوان المتدرجة، تتيح لك Aspose.Slides أيضًا تعيين الصور كخلفية للشرائح في العروض التقديمية.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. عيّن تعداد [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. عيّن تعداد [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) لخلفية الشريحة الرئيسية إلى `Picture`.
4. قم بتحميل الصورة التي تريد استخدامها كخلفية للعرض.
5. أضف الصورة إلى مجموعة الصور الخاصة بالعرض.
6. استخدم خاصية [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) التي توفرها [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدل.

يظهر لك هذا الرمز بلغة جافا كيفية تعيين صورة كخلفية لشريحة:

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

قد ترغب في ضبط شفافية صورة الخلفية لشريحة لجعل محتويات الشريحة تبرز. يوضح لك هذا الرمز بلغة جافا كيفية تغيير الشفافية لصورة خلفية الشريحة:

```java
int transparencyValue = 30; // على سبيل المثال

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

تقدم Aspose.Slides واجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/) لتسمح لك بالحصول على القيم الفعالة لخلفيات الشرائح. تحتوي هذه الواجهة على معلومات حول [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

باستخدام خاصية [Background](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getBackground--) من فئة [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/)، يمكنك الحصول على القيمة الفعالة لخلفية الشريحة.

يظهر لك هذا الرمز بلغة جافا كيفية الحصول على قيمة الخلفية الفعالة لشريحة:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```