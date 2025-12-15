---
title: إدارة رسومات SmartArt في العروض التقديمية على Android
linktitle: رسومات SmartArt
type: docs
weight: 20
url: /ar/androidjava/manage-smartart-shape/
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
- Android
- Java
- Aspose.Slides
description: "أتمتة إنشاء وتحرير وتنسيق SmartArt في PowerPoint باستخدام Aspose.Slides لـ Android، مع أمثلة شفرة Java مختصرة وإرشادات تركّز على الأداء."
---

## **إنشاء شكل SmartArt**
قدمت Aspose.Slides for Android عبر Java واجهة برمجة تطبيقات لإنشاء أشكال SmartArt. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
3. [إضافة شكل SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) عن طريق تعيينه إلى [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType).
4. حفظ العرض التقديمي المعدل كملف PPTX.
```java
// إنشاء فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
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
|**الشكل: تم إضافة شكل SmartArt إلى الشريحة**|

## **الوصول إلى شكل SmartArt في الشريحة**
سيتم استخدام الكود التالي للوصول إلى أشكال SmartArt المضافة في شريحة العرض التقديمي. في كود العينة سنجتاز كل شكل داخل الشريحة ونتحقق مما إذا كان شكلًا من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). إذا كان الشكل من نوع SmartArt فسنقوم بتحويله إلى نسخة من [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).
```java
// تحميل العرض التقديمي المطلوب
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
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الوصول إلى شكل SmartArt بنوع تخطيط معين**
سيساعدك الكود العيني التالي على الوصول إلى شكل [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) بنوع تخطيط معين. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType لخصائص SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وتحميل العرض التقديمي مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. المرور عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
5. التحقق من شكل SmartArt بنوع التخطيط المحدد والقيام بما يلزم بعد ذلك.
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

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وتحميل العرض التقديمي مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. المرور عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
5. البحث عن شكل SmartArt بنمط معين.
6. تعيين النمط الجديد لشكل SmartArt.
7. حفظ العرض التقديمي.
```java
// إنشاء فئة Presentation
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
|**الشكل: شكل SmartArt مع نمط تم تغييره**|

## **تغيير نمط لون SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. في الكود العيني التالي سيتم الوصول إلى شكل SmartArt بنمط لون معين وتغيير نمطه.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وتحميل العرض التقديمي مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
3. المرور عبر كل شكل داخل الشريحة الأولى.
4. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
5. البحث عن شكل SmartArt بنمط لون معين.
6. تعيين نمط اللون الجديد لشكل SmartArt.
7. حفظ العرض التقديمي.
```java
// إنشاء فئة Presentation
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
|**الشكل: شكل SmartArt مع نمط لون تم تغييره**|

## **الأسئلة الشائعة**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذا يمكنك تطبيق [الرسوم المتحركة القياسية](/slides/ar/androidjava/powerpoint-animation/) عبر واجهة برمجة تطبيقات الرسوم المتحركة (دخول، خروج، تأكيد، مسارات الحركة) كما هو الحال مع الأشكال الأخرى.

**كيف يمكنني العثور على SmartArt محدد في شريحة إذا لم أكن أعرف معرفه الداخلي؟**

قم بتعيين واستخدام النص البديل (AltText) وابحث عن الشكل باستخدام تلك القيمة—هذه طريقة موصى بها لتحديد موقع الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [التعامل مع المجموعة](/slides/ar/androidjava/group/).

**كيف أحصل على صورة لـ SmartArt محدد (مثلاً للمعاينة أو التقرير)؟**

صدّر صورة مصغرة/صورة للشكل؛ يمكن للمكتبة [إنتاج أشكال فردية](/slides/ar/androidjava/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل سيحافظ شكل SmartArt على مظهره عند تحويل العرض التقديمي بالكامل إلى PDF؟**

نعم. تُستهدف محرك التصيير دقة عالية لتصدير [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.