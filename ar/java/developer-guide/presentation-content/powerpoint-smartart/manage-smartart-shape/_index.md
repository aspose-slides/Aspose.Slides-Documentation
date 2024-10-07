---
title: إدارة شكل SmartArt
type: docs
weight: 20
url: /java/manage-smartart-shape/
---


## **إنشاء شكل SmartArt**
قدمت Aspose.Slides لـ Java واجهة برمجة التطبيقات لإنشاء أشكال SmartArt. لإنشاء شكل SmartArt في شريحة، يرجى seguir los pasos a continuación:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. [إضافة شكل SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) عن طريق تعيينه [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType).
1. حفظ العرض التقديمي المعدل كملف PPTX.

```java
// قم بإنشاء مثيل لفئة العرض التقديمي
Presentation pres = new Presentation();
try {
    // احصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // حفظ العرض التقديمي
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**الشكل: شكل SmartArt مضاف إلى الشريحة**|

## **الوصول إلى شكل SmartArt في الشريحة**
سيتم استخدام الكود التالي للوصول إلى أشكال SmartArt المضافة في شريحة العرض التقديمي. في الكود التجريبي سنقوم بالتنقل عبر كل شكل داخل الشريحة والتحقق مما إذا كان هو شكل [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). إذا كان الشكل من نوع SmartArt، فسوف نقوم بتحويله إلى مثيل [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).

```java
// قم بتحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("اسم الشكل:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى شكل SmartArt بنوع تخطيط محدد**
سيساعد الكود التجريبي التالي في الوصول إلى شكل [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) بنوع تخطيط معين. يرجى ملاحظة أنه لا يمكنك تغيير نوع التخطيط لشكل SmartArt لأنه للعرض فقط ويتم تعيينه فقط عند إضافة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
1. تحقق من شكل SmartArt بنوع تخطيط معين وقم بما هو مطلوب بعد ذلك.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // التحقق من تخطيط SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("قم بفعل شيء هنا....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير نمط شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير النمط السريع لأي شكل SmartArt.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
1. العثور على شكل SmartArt بنمط معين.
1. تعيين النمط الجديد لشكلم SmartArt.
1. حفظ العرض التقديمي.

```java
// قم بإنشاء مثيل لفئة العرض التقديمي
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // احصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // التحقق من نمط SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // تغيير نمط SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // حفظ العرض التقديمي
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**الشكل: شكل SmartArt مع نمط متغير**|

## **تغيير نمط اللون لشكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. في الكود التجريبي التالي، سنصل إلى شكل SmartArt بنمط لون معين وسنغير نمطه.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) وقم بتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
1. العثور على شكل SmartArt بنمط لون معين.
1. تعيين نمط اللون الجديد لشكل SmartArt.
1. حفظ العرض التقديمي.

```java
// قم بإنشاء مثيل لفئة العرض التقديمي
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // احصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // تحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt) 
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // التحقق من نوع لون SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // تغيير نوع لون SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // حفظ العرض التقديمي
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**الشكل: شكل SmartArt مع نمط لون متغير**|