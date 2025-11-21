---
title: دمج العرض التقديمي
type: docs
weight: 40
url: /ar/nodejs-java/merge-presentation/
keywords: "دمج PowerPoint, PPTX, PPT, دمج PowerPoint, دمج العرض التقديمي, دمج العرض, Java"
description: "دمج أو دمج عرض PowerPoint في JavaScript"
---

## **دمج العروض التقديمية**

عند دمج عرض تقديمي بآخر، فإنك في الواقع تجمع الشرائح الخاصة بهما في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="Info" color="info" %}}
معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) تفتقر إلى وظائف تسمح للمستخدمين بدمج العروض بهذه الطريقة. 
{{% /alert %}}

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/)، ومع ذلك، يتيح لك دمج العروض بطرق متعددة. يمكنك دمج العروض مع جميع الأشكال والأنماط والنصوص والتنسيقات والتعليقات والرسوم المتحركة، إلخ، دون القلق بشأن فقدان الجودة أو البيانات.

**انظر أيضًا**

[Clone Slides](https://docs.aspose.com/slides/nodejs-java/clone-slides/).

{{% alert title="Note" color="warning" %}} 
إلى جانب العروض التقديمية، يتيح لك Aspose.Slides دمج ملفات أخرى:

* [الصور](https://products.aspose.com/slides/nodejs-java/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/nodejs-java/merger/png-to-png/)
* المستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/nodejs-java/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/nodejs-java/merger/html-to-html/)
* ملفين مختلفين مثل [صورة إلى PDF](https://products.aspose.com/slides/nodejs-java/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/nodejs-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **ما يمكن دمجه**

باستخدام Aspose.Slides، يمكنك دمج 

* العروض التقديمية بالكامل. جميع الشرائح من العروض تنتهي في عرض تقديمي واحد
* شرائح محددة. الشرائح المختارة تنتهي في عرض تقديمي واحد
* العروض بصيغة واحدة (PPT إلى PPT، PPTX إلى PPTX، إلخ) أو بصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) مع بعضها البعض. 

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان

* كل شريحة في العرض الناتج تحتفظ بنمط فريد
* يُستخدم نمط محدد لجميع الشرائح في العرض الناتج. 

لدمج العروض، يوفر Aspose.Slides طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (من فئة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)). هناك عدة تطبيقات لطرق `addClone` تُعرِّف معايير عملية دمج العروض. كل كائن Presentation يحتوي على مجموعة [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)، لذا يمكنك استدعاء طريقة `addClone` من العرض الذي تريد دمج الشرائح إليه.

طريقة `addClone` تُعيد كائن `Slide`، وهو نسخة مستنسخة من شريحة المصدر. الشرائح في العرض الناتج هي مجرد نسخة من الشرائح الموجودة في المصدر. لذلك يمكنك تعديل الشرائح الناتجة (مثلاً تطبيق أنماط أو خيارات تنسيق أو تخطيطات) دون القلق من أن تتأثر عروض المصدر.

## **دمج العروض التقديمية** 

يوفر Aspose.Slides طريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي تسمح لك بدمج الشرائح مع احتفاظ الشرائح بتخطيطاتها وأنماطها (معلمات افتراضية).

يعرض هذا الكود JavaScript كيفية دمج العروض التقديمية:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **دمج العروض التقديمية مع Slide Master** 

يوفر Aspose.Slides طريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) التي تسمح لك بدمج الشرائح مع تطبيق قالب شريحة رئيسية. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في العرض الناتج.

هذا الكود JavaScript يوضح العملية الموصوفة:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 
يتم تحديد تخطيط الشريحة للـ slide master تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم تعيين المعامل المنطقي `allowCloneMissingLayout` لطريقة `addClone` إلى true، يُستخدم تخطيط شريحة المصدر. وإلا، سيتم إطلاق استثناء [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException). 
{{% /alert %}}

إذا رغبت في أن تكون الشرائح في العرض الناتج ذات تخطيط شريحة مختلف، استخدم طريقة [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) بدلاً من ذلك عند الدمج.

## **دمج شرائح محددة من العروض التقديمية** 

يُعد دمج شرائح محددة من عروض متعددة مفيدًا لإنشاء مجموعات شرائح مخصصة. يتيح لك Aspose.Slides for Node.js via Java تحديد واستيراد الشرائح التي تحتاجها فقط. يحافظ API على تنسيق وتخطيط وتصميم الشرائح الأصلية.

الكود JavaScript التالي ينشئ عرض تقديمي جديد، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة في ملف:
```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```

```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```


## **دمج العروض التقديمية مع تخطيط الشريحة** 

يعرض هذا الكود JavaScript كيفية دمج الشرائح من العروض التقديمية مع تطبيق تخطيط الشريحة المفضل لديك للحصول على عرض تقديمي ناتج واحد:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **دمج العروض التقديمية بأحجام شرائح مختلفة** 

{{% alert title="Note" color="warning" %}} 
لا يمكنك دمج عروض تقديمية ذات أحجام شرائح مختلفة. 
{{% /alert %}}

لدمج عرضين بحجم شريحة مختلف، يجب تغيير حجم أحد العروض ليتطابق مع حجم العرض الآخر.

يظهر هذا المثال الكود الذي يوضح العملية الموصوفة:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **دمج الشرائح إلى قسم في العرض التقديمي** 

يعرض هذا الكود JavaScript كيفية دمج شريحة محددة إلى قسم في العرض التقديمي:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


يتم إضافة الشريحة في نهاية القسم. 

## **الأسئلة المتكررة** 

**هل يتم الاحتفاظ بملاحظات المتحدث أثناء الدمج؟**  
نعم. عند استنساخ الشرائح، ينقل Aspose.Slides جميع عناصر الشريحة بما في ذلك الملاحظات والتنسيق والرسوم المتحركة.

**هل يتم نقل التعليقات ومؤلفيها؟**  
التعليقات، كجزء من محتوى الشريحة، تُنسخ مع الشريحة. تُحافظ تسميات مؤلفي التعليقات ككائنات تعليق في العرض الناتج.

**ماذا لو كان العرض المصدر محمياً بكلمة مرور؟**  
يجب [فتحه باستخدام كلمة المرور](/slides/ar/nodejs-java/password-protected-presentation/) عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/)؛ بعد التحميل، يمكن استنساخ تلك الشرائح بأمان إلى ملف هدف غير محمي (أو محمي كذلك).

**ما مدى أمان العملية من ناحية الخيوط المتعددة؟**  
لا تستخدم نفس كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/nodejs-java/multithreading/). القاعدة الموصى بها هي "مستند واحد — خيط واحد"؛ يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.

## **انظر أيضًا** 

توفر Aspose أداة [FREE Online Collage Maker](https://products.aspose.app/slides/collage) مجانية عبر الإنترنت. باستخدام هذه الخدمة يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، والمزيد.

تحقق من [Aspose FREE Online Merger](https://products.aspose.app/slides/merger). يتيح لك دمج عروض PowerPoint بنفس الصيغة (مثل PPT إلى PPT، PPTX إلى PPTX) أو عبر صيغ مختلفة (مثل PPT إلى PPTX، PPTX إلى ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)