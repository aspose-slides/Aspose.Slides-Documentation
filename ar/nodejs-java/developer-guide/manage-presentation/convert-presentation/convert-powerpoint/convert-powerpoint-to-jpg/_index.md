---
title: تحويل PPT و PPTX إلى JPG باستخدام JavaScript
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى JPG
- العرض التقديمي إلى JPG
- الشريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- حفظ PowerPoint كـ JPG
- حفظ العرض التقديمي كـ JPG
- حفظ الشريحة كـ JPG
- حفظ PPT كـ JPG
- حفظ PPTX كـ JPG
- تصدير PPT إلى JPG
- تصدير PPTX إلى JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة باستخدام JavaScript مع Aspose.Slides لـ Node.js عبر Java باستخدام أمثلة شفرة سريعة وموثوقة."
---

## **حول تحويل PowerPoint إلى JPG**
باستخدام [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) يمكنك تحويل عرض PowerPoint PPT أو PPTX إلى صورة JPG. كما يمكنك أيضًا تحويل PPT/PPTX إلى JPEG أو PNG أو SVG. مع هذه الميزات يصبح من السهل تنفيذ عارض عرضك الخاص، وإنشاء الصورة المصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا رغبت في حماية شرائح العرض من النسخ، أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض بالكامل أو شريحة معينة إلى تنسيقات الصور.

{{% alert color="primary" %}} 
لرؤية كيفية تحويل Aspose.Slides لـ PowerPoint إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و [PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**
فيما يلي الخطوات لتحويل PPT/PPTX إلى JPG:

1. إنشاء كائن من النوع [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على كائن الشريحة من النوع [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--).
3. إنشاء الصورة المصغرة لكل شريحة ثم تحويلها إلى JPG. تُستخدم الطريقة [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) للحصول على صورة مصغرة لشريحة، وتُعيد كائن [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images) كنتيجة. يجب استدعاء الطريقة [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) من الشريحة المطلوبة من النوع [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)، ويتم تمرير مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على الصورة المصغرة للشريحة، استدعِ الطريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) من كائن الصورة المصغرة. مرّر اسم الملف الناتج وتنسيق الصورة إليها. 

{{% alert color="primary" %}}

**ملاحظة**: التحويل من PPT/PPTX إلى JPG يختلف عن التحويل إلى أنواع أخرى في Aspose.Slides API. بالنسبة للأنواع الأخرى، عادةً ما تستخدم طريقة [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-)، لكن هنا تحتاج إلى طريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). 

{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // ينشئ صورة بمقياس كامل
        var slideImage = sld.getImage(1.0, 1.0);
        // يحفظ الصورة إلى القرص بتنسيق JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل PowerPoint PPT/PPTX إلى JPG بأبعاد مخصصة**
لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك تعيين قيم *ScaleX* و *ScaleY* بتمريرها إلى طرق [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-):

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // تحديد الأبعاد
    var desiredX = 1200;
    var desiredY = 800;
    // الحصول على القيم المقاسة للمحور X و Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // إنشاء صورة بمقياس كامل
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // حفظ الصورة إلى القرص بتنسيق JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **عرض التعليقات عند حفظ العرض كصورة**
يوفر Aspose.Slides لـ Node.js عبر Java إمكانية تسمح لك بعرض التعليقات في شرائح العرض عند تحويل تلك الشرائح إلى صور. يُظهر هذا الشيفرة JavaScript العملية:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Tip" color="primary" %}}

توفر Aspose تطبيق ويب [Collage مجاني](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

{{% /alert %}}

## **انظر أيضًا**

انظر إلى خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/).

## **الأسئلة الشائعة**

**هل تدعم هذه الطريقة التحويل الدفعي؟**

نعم، يتيح Aspose.Slides التحويل الدفعي لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل SmartArt والرسوم البيانية وغيرها من الكائنات المعقدة؟**

نعم، يقوم Aspose.Slides بتصيير جميع المحتويات، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال وغيرها. ومع ذلك، قد تختلف دقة التصيير قليلاً مقارنةً بـ PowerPoint، خصوصًا عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides نفسه أي حدود صريحة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور عالية الدقة.