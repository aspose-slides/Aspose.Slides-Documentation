---
title: إدارة شكل SmartArt
type: docs
weight: 20
url: /ar/nodejs-java/manage-smartart-shape/
---

## **إنشاء شكل SmartArt**
قامت Aspose.Slides لـ Node.js عبر Java بتوفير API لإنشاء أشكال SmartArt. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. [إضافة شكل SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) عن طريق تعيينه باستخدام [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType).
1. حفظ العرض المعدل كملف PPTX.
```javascript
// إنشاء فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة شكل Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // حفظ العرض
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شكل: SmartArt مضافة إلى الشريحة**|

## **الوصول إلى شكل SmartArt في الشريحة**
سيتم استخدام الشيفرة التالية للوصول إلى أشكال SmartArt المضافة في شريحة العرض. في الشيفرة النموذجية سنقوم بت traversing (استعراض) كل شكل داخل الشريحة والتحقق مما إذا كان شكلًا من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). إذا كان الشكل من نوع SmartArt فسنقوم بتحويله إلى كائن [**SmartArt**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt).
```javascript
// تحميل العرض المطلوب
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // استعراض كل شكل داخل الشريحة الأولى
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تحويل الشكل إلى SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الوصول إلى شكل SmartArt بنوع Layout محدد**
ستساعد الشيفرة النموذجية التالية في الوصول إلى شكل [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) بنوع Layout محدد. يرجى ملاحظة أنه لا يمكن تغيير LayoutType الخاص بـ SmartArt لأنه قراءة‑فقط ويتم تعيينه فقط عند إضافة الشكل.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) وتحميل العرض الذي يحتوي على شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
1. استعراض كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتحويله إلى SmartArt إذا كان كذلك.
1. فحص شكل SmartArt بنوع Layout المحدد وتنفيذ ما يلزم بعد ذلك.
```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // استعراض كل شكل داخل الشريحة الأولى
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تحويل الشكل إلى SmartArtEx
            var smart = shape;
            // التحقق من تخطيط SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تغيير نمط شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير النمط السريع لأي شكل SmartArt.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) وتحميل العرض الذي يحتوي على شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
1. استعراض كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتحويله إلى SmartArt إذا كان كذلك.
1. العثور على شكل SmartArt بالنمط المحدد.
1. تعيين النمط الجديد لشكل SmartArt.
1. حفظ العرض.
```javascript
// إنشاء فئة Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // استعراض كل شكل داخل الشريحة الأولى
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تحويل الشكل إلى SmartArtEx
            var smart = shape;
            // التحقق من نمط SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // تغيير نمط SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // حفظ العرض
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شكل: SmartArt بنمط تم تغييره**|

## **تغيير نمط لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. ستصل الشيفرة النموذجية التالية إلى شكل SmartArt بنمط لون محدد وتقوم بتغيير نمطه.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) وتحميل العرض الذي يحتوي على شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
1. استعراض كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) وتحويله إلى SmartArt إذا كان كذلك.
1. العثور على شكل SmartArt بنمط اللون المحدد.
1. تعيين نمط اللون الجديد لشكل SmartArt.
1. حفظ العرض.
```javascript
// إنشاء فئة Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // استعراض كل شكل داخل الشريحة الأولى
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تحويل الشكل إلى SmartArtEx
            var smart = shape;
            // التحقق من نوع لون SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // تغيير نوع لون SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // حفظ العرض
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**شكل: SmartArt بنمط لون تم تغييره**|

## **FAQ**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذا يمكنك تطبيق [الرسوم المتحركة القياسية](/slides/ar/nodejs-java/powerpoint-animation/) عبر API الرسوم المتحركة (دخول، خروج، تأكيد، مسارات الحركة) تمامًا مثل الأشكال الأخرى.

**كيف يمكنني العثور على SmartArt محدد في شريحة إذا لم أعرف معرفه الداخلي؟**

قم بتعيين واستخدام النص البديل (AltText) وابحث عن الشكل باستخدام تلك القيمة—هذه طريقة موصى بها لتحديد الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [التعامل مع المجموعة](/slides/ar/nodejs-java/group/).

**كيف أحصل على صورة لـ SmartArt معين (مثلاً للمعاينة أو التقرير)؟**

صدّر صورة مصغرة/صورة للشكل؛ المكتبة يمكنها [رسم الأشكال الفردية](/slides/ar/nodejs-java/create-shape-thumbnails/) إلى ملفات raster (PNG/JPG/TIFF).

**هل سيتم الحفاظ على مظهر SmartArt عند تحويل العرض الكامل إلى PDF؟**

نعم. محرك العرض يستهدف دقة عالية لتصدير [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.