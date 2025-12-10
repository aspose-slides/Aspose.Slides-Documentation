---
title: إدارة رسومات SmartArt في العروض التقديمية باستخدام Java
linktitle: رسومات SmartArt
type: docs
weight: 20
url: /ar/java/manage-smartart-shape/
keywords:
- كائن SmartArt
- رسم SmartArt
- نمط SmartArt
- لون SmartArt
- إنشاء SmartArt
- إضافة SmartArt
- تحرير SmartArt
- تغيير SmartArt
- الوصول إلى SmartArt
- نوع تخطيط SmartArt
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "أتمتة إنشاء وتحرير وتنسيق SmartArt في PowerPoint باستخدام Java و Aspose.Slides، مع أمثلة شيفرة مختصرة وإرشادات تركّز على الأداء."
---

## **إنشاء شكل SmartArt**
قدمت Aspose.Slides for Java واجهة برمجة تطبيقات لإنشاء أشكال SmartArt. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. إضافة شكل SmartArt عبر [Add a SmartArt shape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) عن طريق تعيينه [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType) .
1. حفظ العرض التقديمي المعدل كملف PPTX.
```java
// إنشاء مثيل لفئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة شكل Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // حفظ العرض التقديمي
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**الشكل: تم إضافة شكل SmartArt إلى الشريحة**|

## **الوصول إلى شكل SmartArt على شريحة**
سيتم استخدام الشيفرة التالية للوصول إلى أشكال SmartArt المضافة في شريحة العرض التقديمي. في الشيفرة النموذجية سنقوم بالتنقل عبر كل شكل داخل الشريحة والتحقق مما إذا كان شكلًا من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) . إذا كان الشكل من نوع SmartArt فسنقوم بتحويله إلى نسخة [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) .
```java
// تحميل العرض التقديمي المطلوب
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الوصول إلى شكل SmartArt بنوع تخطيط معين**
ستساعد الشيفرة النموذجية التالية في الوصول إلى شكل [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) بنوع LayoutType معين. يرجى ملاحظة أنه لا يمكن تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) .

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt .
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
1. التحقق من شكل SmartArt بنوع LayoutType معين وإجراء ما يلزم بعد ذلك.
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape instanceof ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // التحقق من تخطيط SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير نمط شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير النمط السريع لأي شكل SmartArt.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt .
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
1. العثور على شكل SmartArt بنمط معين.
1. تعيين النمط الجديد لشكل SmartArt.
1. حفظ العرض التقديمي.
```java
// إنشاء مثيل لفئة Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
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

## **تغيير نمط لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. في الشيفرة النموذجية التالية سيتم الوصول إلى شكل SmartArt بنمط لون معين وتغيير نمطه.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt .
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
1. العثور على شكل SmartArt بنمط لون معين.
1. تعيين نمط اللون الجديد لشكل SmartArt.
1. حفظ العرض التقديمي.
```java
// إنشاء مثيل لفئة Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // التنقل عبر كل شكل داخل الشريحة الأولى
    for (IShape shape : slide.getShapes()) 
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
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
|**الشكل: شكل SmartArt بنمط لون متغير**|

## **الأسئلة الشائعة**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذلك يمكنك تطبيق [standard animations](/slides/ar/java/powerpoint-animation/) عبر واجهة برمجة التطبيقات للرسوم المتحركة (الدخول، الخروج، التشديد، مسارات الحركة) كما هو الحال مع الأشكال الأخرى.

**كيف يمكنني العثور على SmartArt محدد في شريحة إذا لم أعرف معرّفه الداخلي؟**

قم بتعيين واستخدام النص البديل (AltText) وابحث عن الشكل باستخدام هذه القيمة—هذه طريقة موصى بها لتحديد موقع الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [manipulate the group](/slides/ar/java/group/).

**كيف أحصل على صورة لـ SmartArt معين (مثلاً للمعاينة أو التقرير)؟**

قم بتصدير صورة مصغرة/صورة للشكل؛ يمكن للمكتبة [render individual shapes](/slides/ar/java/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل سيتم الحفاظ على مظهر SmartArt عند تحويل العرض التقديمي كاملًا إلى PDF؟**

نعم. يهدف محرك العرض إلى الحفاظ على الدقة العالية لتصدير [PDF export](/slides/ar/java/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.