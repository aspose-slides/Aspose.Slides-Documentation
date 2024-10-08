---
title: إدارة شكل SmartArt
type: docs
weight: 20
url: /ar/androidjava/manage-smartart-shape/
---


## **إنشاء شكل SmartArt**
قدمت Aspose.Slides لـ Android عبر Java واجهة برمجة تطبيقات لإنشاء أشكال SmartArt. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات التالية:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
1. احصل على مرجع لشريحة باستخدام العنصر الخاص بها.
1. [أضف شكلاً من أشكال SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) عن طريق تعيين [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType).
1. قم بحفظ العرض التقديمي المعدل كملف PPTX.

```java
// Instantiate Presentation Class
Presentation pres = new Presentation();
try {
    // Get first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add Smart Art Shape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Saving presentation
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**الشكل: تم إضافة شكل SmartArt إلى الشريحة**|

## **الوصول إلى شكل SmartArt في الشريحة**
سيتم استخدام الكود التالي للوصول إلى أشكال SmartArt المضافة في شريحة العرض التقديمي. في الكود العينة، سنتنقل عبر كل شكل داخل الشريحة ونفحص ما إذا كان شكلًا من [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). إذا كان الشكل من نوع SmartArt، فسنجري تحويل نوعه إلى [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) مثيل.

```java
// Load the desired the presentation
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Traverse through every shape inside first slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("اسم الشكل:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى شكل SmartArt بنوع تخطيط معين**
سيساعد الكود العينة التالي في الوصول إلى شكل [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) بنوع تخطيط معين. يرجى ملاحظة أنه لا يمكنك تغيير نوع التخطيط لشكل SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) الشكل.

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class وقم بتحميل العرض التقديمي مع شكل SmartArt.
1. احصل على مرجع الشريحة الأولى باستخدام العنصر الخاص بها.
1. تنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
1. تحقق من شكل SmartArt بنوع تخطيط معين وقم بأداء ما يجب القيام به بعد ذلك.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Traverse through every shape inside first slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Checking SmartArt Layout
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("قم بشيء هنا....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير نمط شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير النمط السريع لأي شكل SmartArt.

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class وقم بتحميل العرض التقديمي مع شكل SmartArt.
1. احصل على مرجع الشريحة الأولى باستخدام العنصر الخاص بها.
1. تنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
1. ابحث عن شكل SmartArt بنمط معين.
1. قم بتعيين النمط الجديد لشكل SmartArt.
1. قم بحفظ العرض التقديمي.

```java
// Instantiate Presentation Class
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Get first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Traverse through every shape inside first slide
    for (IShape shape : slide.getShapes()) 
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Checking SmartArt style
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Changing SmartArt Style
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Saving presentation
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**الشكل: شكل SmartArt مع نمط متغير**|

## **تغيير نمط لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. في الكود العينة التالي، سنصل إلى شكل SmartArt بنمط لون معين وسنغير نمطه.

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class وقم بتحميل العرض التقديمي مع شكل SmartArt.
1. احصل على مرجع الشريحة الأولى باستخدام العنصر الخاص بها.
1. تنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
1. ابحث عن شكل SmartArt بنمط لون معين.
1. قم بتعيين نمط اللون الجديد لشكل SmartArt.
1. قم بحفظ العرض التقديمي.

```java
// Instantiate Presentation Class
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Get first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Traverse through every shape inside first slide
    for (IShape shape : slide.getShapes()) 
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Checking SmartArt color type
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Changing SmartArt color type
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Saving presentation
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**الشكل: شكل SmartArt مع نمط لون متغير**|