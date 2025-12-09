---
title: تحويل PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/nodejs-java/convert-powerpoint-to-jpg/
keywords: "تحويل PowerPoint إلى JPG, PPTX إلى JPEG, PPT إلى JPEG"
description: "تحويل PowerPoint إلى JPG: PPT إلى JPG, PPTX إلى JPG في JavaScript"
---

## **حول تحويل PowerPoint إلى JPG**
مع [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) يمكنك تحويل عرض تقديمي PowerPoint PPT أو PPTX إلى صورة JPG. كما يمكن تحويل PPT/PPTX إلى JPEG أو PNG أو SVG. باستخدام هذه الميزات يصبح من السهل تنفيذ عارض عروض تقديمية خاص بك، وإنشاء صورة مصغرة لكل شريحة. قد يكون هذا مفيدًا إذا رغبت في حماية شرائح العرض من النسخ، أو عرض العرض في وضع القراءة فقط. يسمح Aspose.Slides بتحويل العرض بالكامل أو شريحة معينة إلى صيغ صور.

{{% alert color="primary" %}} 

لمعرفة كيفية تحويل PowerPoint إلى صور JPG باستخدام Aspose.Slides، يمكنك تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و [PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**
فيما يلي خطوات تحويل PPT/PPTX إلى JPG:

1. إنشاء كائن من النوع [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على كائن الشريحة من نوع [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) عبر مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) .
3. إنشاء الصورة المصغرة لكل شريحة ثم تحويلها إلى JPG. يتم استخدام طريقة [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) للحصول على صورة مصغرة للشريحة، وتعيد كائن [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images). يجب استدعاء طريقة [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) من الشريحة المطلوبة من نوع [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)، حيث يتم تمرير مقاييس الصورة المصغرة إلى الطريقة.
4. بعد الحصول على الصورة المصغرة للشريحة، استدعِ طريقة [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) من كائن الصورة المصغرة. مرّر اسم الملف الناتج وصيغة الصورة إليها. 

{{% alert color="primary" %}}

**ملاحظة**: تختلف عملية تحويل PPT/PPTX إلى JPG عن التحويل إلى صيغ أخرى في Aspose.Slides API. بالنسبة للأنواع الأخرى، عادةً ما تستخدم طريقة [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-)، ولكن هنا تحتاج إلى طريقة [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)). 

{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // ينشئ صورة بحجم كامل
        var slideImage = sld.getImage(1.0, 1.0);
        // يحفظ الصورة على القرص بصيغة JPEG
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
لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك تعيين قيم *ScaleX* و *ScaleY* بتمريرها إلى طريقة [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-):
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // تعريف الأبعاد
    var desiredX = 1200;
    var desiredY = 800;
    // الحصول على قيم X و Y المُقاسة
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // إنشاء صورة بالحجم الكامل
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // حفظ الصورة على القرص بصيغة JPEG
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
يوفر Aspose.Slides للـ Node.js عبر Java إمكانية عرض التعليقات في شرائح العرض عند تحويلها إلى صور. يوضح هذا الكود JavaScript العملية:
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

تقدم Aspose تطبيقًا ويبًا مجانيًا للملصقات ([Collage](https://products.aspose.app/slides/collage)). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، إنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid) وغيرها. 

باستخدام نفس المبادئ المذكورة في هذه المقالة، يمكنك تحويل الصور من صيغة إلى أخرى. للمزيد من المعلومات، راجع الصفحات التالية: تحويل [صورة إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

## **انظر أيضًا**

انظر خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/).

## **الأسئلة الشائعة**

**هل يدعم هذا الأسلوب التحويل الدفعي؟**

نعم، يتيح Aspose.Slides التحويل الدفعي لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل كائنات SmartArt والرسوم البيانية والكائنات المعقدة الأخرى؟**

نعم، يقوم Aspose.Slides بتص rendering جميع المحتويات، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال وغيرها. ومع ذلك، قد تختلف دقة العرض قليلًا مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides حدًا صريحًا على عدد الشرائح التي يمكنك معالجتها. إلا أنه قد تواجه خطأ نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور بدقة عالية.