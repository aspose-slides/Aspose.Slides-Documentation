---
title: دمج العروض التقديمية بكفاءة في JavaScript
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/nodejs-java/merge-presentation/
keywords:
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- جمع PowerPoint
- جمع العروض التقديمية
- جمع الشرائح
- جمع PPT
- جمع PPTX
- جمع ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "دمج عروض PowerPoint (PPT, PPTX) وOpenDocument (ODP) بسهولة في JavaScript باستخدام Aspose.Slides لـ Node.js، مما يبسط سير عملك."
---

## **دمج العروض التقديمية**

عند دمج عرض تقديمي بآخر، فإنك فعليًا تجمع شرائحه في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="معلومات" color="info" %}}

معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) تفتقر إلى وظائف تسمح للمستخدمين بدمج العروض بهذه الطريقة. 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/)، يسمح لك بدمج عروض تقديمية بطرق مختلفة. يمكنك دمج العروض مع جميع الأشكال والأنماط والنصوص والتنسيقات والتعليقات والرسوم المتحركة، إلخ، دون القلق بشأن فقدان الجودة أو البيانات.

**انظر أيضًا**

[استنساخ الشرائح](https://docs.aspose.com/slides/nodejs-java/clone-slides/).

{{% /alert %}}

### **ما الذي يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 

* العروض الكاملة. جميع الشرائح من العروض تنتهي في عرض واحد  
* شرائح محددة. الشرائح المختارة تنتهي في عرض واحد  
* عروض بصيغة واحدة (PPT إلى PPT، PPTX إلى PPTX، إلخ) وبصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) إلى بعضها البعض.  

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان

* كل شريحة في عرض الإخراج تحتفظ بنمط فريد  
* يُستخدم نمط محدد لجميع الشرائح في عرض الإخراج.  

لدمج العروض، توفر Aspose.Slides طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (من فئة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)). هناك عدة تطبيقات لطريقة `addClone` تحدد معاملات عملية دمج العروض. كل كائن Presentation يمتلك مجموعة [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)، لذا يمكنك استدعاء طريقة `addClone` من العرض الذي تريد دمج الشرائح إليه.

طريقة `addClone` تُعيد كائن `Slide`، وهو نسخة مستنسخة من الشريحة المصدر. الشرائح في عرض الإخراج هي مجرد نسخة من الشرائح المصدر. لذلك يمكنك تعديل الشرائح الناتجة (مثلاً تطبيق أنماط أو خيارات تنسيق أو تخطيطات) دون القلق من تأثيرها على العروض المصدر.

## **دمج العروض**

توفر Aspose.Slides الطريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي تسمح لك بدمج الشرائح مع الاحتفاظ بتخطيطاتها وأنماطها (معلمات افتراضية).

هذا الكود JavaScript يوضح كيفية دمج العروض:
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


## **دمج العروض مع القالب الرئيسي للشرائح**

توفر Aspose.Slides الطريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) التي تسمح لك بدمج الشرائح مع تطبيق قالب رئيسي للشرائح. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في عرض الإخراج.

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


{{% alert title="ملاحظة" color="warning" %}} 

يتم تحديد تخطيط الشريحة للقالب الرئيسي تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم ضبط المعامل المنطقي `allowCloneMissingLayout` في طريقة `addClone` على true، يُستخدم تخطيط الشريحة المصدر. خلاف ذلك، سيتم إلقاء [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

إذا كنت تريد أن تكون للشرائح في عرض الإخراج تخطيط شريحة مختلف، استخدم طريقة [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) عند الدمج.

## **دمج شرائح محددة من العروض**

دمج شرائح محددة من عروض متعددة مفيد لإنشاء مجموعات شرائح مخصصة. يسمح Aspose.Slides for Node.js via Java لك باختيار واستيراد الشرائح التي تحتاجها فقط. يحافظ API على التنسيق والتخطيط وتصميم الشرائح الأصلية.

الكود JavaScript التالي ينشئ عرضًا تقديميًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة في ملف:
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


## **دمج العروض مع تخطيط الشرائح**

هذا الكود JavaScript يوضح كيفية دمج الشرائح من العروض مع تطبيق تخطيط شريحة مفضل للحصول على عرض إخراج واحد:
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


## **دمج العروض بأحجام شرائح مختلفة**

{{% alert title="ملاحظة" color="warning" %}} 

لا يمكنك دمج عروض بأحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، عليك تغيير حجم أحد العروض لتطابق حجم العرض الآخر.

هذا الكود النموذجي يوضح العملية الموصوفة:
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


## **دمج الشرائح إلى قسم في العرض**

هذا الكود JavaScript يوضح كيفية دمج شريحة محددة إلى قسم في عرض:
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


تُضاف الشريحة في نهاية القسم. 

## **الأسئلة المتكررة**

**هل يتم الحفاظ على ملاحظات المتحدث أثناء الدمج؟**

نعم. عند استنساخ الشرائح، تنقل Aspose.Slides جميع عناصر الشريحة، بما في ذلك الملاحظات والتنسيق والرسوم المتحركة.

**هل يتم نقل التعليقات ومؤلفيها؟**

التعليقات، كجزء من محتوى الشريحة، تُنسخ مع الشريحة. تُحافظ تسميات مؤلفي التعليقات ككائنات تعليق في العرض الناتج.

**ماذا لو كان العرض المصدر محمياً بكلمة مرور؟**

يجب [فتح العرض باستخدام كلمة المرور](/slides/ar/nodejs-java/password-protected-presentation/) عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/); بعد التحميل، يمكن استنساخ تلك الشرائح بأمان إلى ملف هدف غير محمي (أو محمي كذلك).

**ما مدى أمان العملية من حيث الترابط (thread‑safe)؟**

لا تستخدم نفس كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/nodejs-java/multithreading/). القاعدة الموصى بها هي "مستند واحد — خيط واحد"؛ يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.

## **انظر أيضًا**

توفر Aspose أداة [صانع كولاج مجاني على الإنترنت](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة على الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، إنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، والمزيد.

جرب [أداة الدمج المجانية على الإنترنت من Aspose](https://products.aspose.app/slides/merger). تسمح لك بدمج عروض PowerPoint بنفس الصيغة (مثل PPT إلى PPT، PPTX إلى PPTX) أو عبر صيغ مختلفة (مثل PPT إلى PPTX، PPTX إلى ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)