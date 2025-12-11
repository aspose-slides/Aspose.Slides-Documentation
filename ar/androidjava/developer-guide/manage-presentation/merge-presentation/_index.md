---
title: دمج العروض التقديمية بفعالية على Android
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/androidjava/merge-presentation/
keywords:
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- Android
- Java
- Aspose.Slides
description: "دمج PowerPoint (PPT، PPTX) وعروض OpenDocument (ODP) بسهولة باستخدام Aspose.Slides للأندرويد عبر Java، مما يبسط سير عملك."
---

{{% alert  title="Tip" color="primary" %}} 

قد ترغب في تجربة **Aspose free online** [تطبيق الدمج](https://products.aspose.app/slides/merger). يسمح للأشخاص بدمج عروض PowerPoint بنفس الصيغة (PPT إلى PPT، PPTX إلى PPTX، إلخ) ودمج العروض بصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عند دمج عرض تقديمي مع آخر، فإنك في الواقع تجمع شرائحهما في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="Info" color="info" %}}

معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) تفتقر إلى وظائف تسمح للمستخدمين بدمج العروض بهذه الطريقة. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)، مع ذلك، يسمح لك بدمج العروض بطرق مختلفة. يمكنك دمج العروض مع جميع الأشكال والأنماط والنصوص والتنسيقات والتعليقات والرسوم المتحركة، دون القلق بشأن فقدان الجودة أو البيانات.

**انظر أيضًا**

[استنساخ الشرائح](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 

* العروض الكاملة. جميع الشرائح من العروض تنتهي في عرض تقديمي واحد
* شرائح معينة. الشرائح المحددة تنتهي في عرض تقديمي واحد
* عروض بصيغة واحدة (PPT إلى PPT، PPTX إلى PPTX، إلخ) وبصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) مع بعضها البعض. 

{{% alert title="Note" color="warning" %}} 

إلى جانب العروض التقديمية، يسمح لك Aspose.Slides بدمج ملفات أخرى:

* [الصور](https://products.aspose.com/slides/androidjava/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* [المستندات](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/)، مثل [PDF إلى PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* وملفين مختلفين مثل [صورة إلى PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان

* كل شريحة في العرض الناتج تحتفظ بنمط فريد
* يُستخدم نمط محدد لجميع الشرائح في العرض الناتج. 

لدمج العروض، توفر Aspose.Slides طريقة [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)). هناك عدة تطبيقات لطريقة `AddClone` تحدد معلمات عملية دمج العروض. كل كائن Presentation يحتوي على مجموعة [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)، لذلك يمكنك استدعاء طريقة `AddClone` من العرض الذي تريد دمج الشرائح إليه.

طريقة `AddClone` تُعيد كائن `ISlide`، وهو نسخة من الشريحة المصدر. الشرائح في العرض الناتج هي مجرد نسخة من الشرائح في المصدر. لذلك يمكنك تعديل الشرائح الناتجة (مثل تطبيق الأنماط أو خيارات التنسيق أو التخطيطات) دون القلق من تأثير ذلك على العروض المصدر.

## **دمج العروض التقديمية** 

توفر Aspose.Slides الطريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تسمح لك بدمج الشرائح مع بقاء تخطيطاتها وأنماطها (معلمات افتراضية).

هذا الكود في Java يظهر لك كيفية دمج العروض:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **دمج العروض التقديمية مع ماستر شريحة** 

توفر Aspose.Slides الطريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تسمح لك بدمج الشرائح مع تطبيق قالب ماستر شريحة. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير نمط الشرائح في العرض الناتج.

هذا الكود في Java يوضح العملية الموصوفة:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

يتم تحديد تخطيط الشريحة للماستر تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم تعيين المعامل `allowCloneMissingLayout` من طريقة `AddClone` إلى true، يُستخدم تخطيط الشريحة المصدر. وإلا سيتم رمي استثناء [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

إذا كنت تريد أن تكون للشرائح في العرض الناتج تخطيط شريحة مختلف، استخدم الطريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) بدلاً من ذلك عند الدمج.

## **دمج شرائح محددة من العروض** 

دمج شرائح محددة من عروض متعددة مفيد لإنشاء مجموعات شرائح مخصصة. يسمح Aspose.Slides for Android via Java لك باختيار واستيراد الشرائح التي تحتاجها فقط. يحافظ الـ API على التنسيق والتخطيط وتصميم الشرائح الأصلية.

الكود التالي في Java ينشئ عرضًا تقديميًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة في ملف:
```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```


## **دمج العروض التقديمية مع تخطيط شريحة** 

هذا الكود في Java يوضح لك كيفية دمج الشرائح من العروض مع تطبيق تخطيط شريحة مفضل للحصول على عرض تقديمي واحد ناتج:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **دمج العروض التقديمية بأحجام شرائح مختلفة** 

{{% alert title="Note" color="warning" %}} 

لا يمكنك دمج العروض ذات أحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، عليك تعديل حجم أحد العروض لتطابق حجم العرض الآخر. 

هذا الكود النموذجي يوضح العملية الموصوفة:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **دمج شرائح إلى قسم في العرض التقديمي** 

هذا الكود في Java يوضح لك كيفية دمج شريحة معينة إلى قسم في عرض تقديمي:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


يتم إضافة الشريحة في نهاية القسم. 

{{% alert title="Tip" color="primary" %}}

توفر Aspose تطبيق ويب مجاني للملصقات [FREE Collage web app](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وغيرها. 

{{% /alert %}}

## **الأسئلة الشائعة** 

**هل هناك أي قيود على عدد الشرائح عند دمج العروض التقديمية؟**

لا توجد قيود صارمة. يمكن لـ Aspose.Slides التعامل مع ملفات كبيرة، لكن الأداء يعتمد على حجم الملف وموارد النظام. للعرض التقديمي كبير الحجم، يُنصح باستخدام JVM 64 بت وتخصيص ذاكرة كافية.

**هل يمكنني دمج عروض تحتوي على فيديو أو صوت مدمجين؟**

نعم، يحتفظ Aspose.Slides بالمحتوى المتعدد الوسائط المدمج في الشرائح، لكن قد يصبح العرض النهائي أكبر حجمًا بشكل ملحوظ.

**هل سيتم الحفاظ على الخطوط عند دمج العروض؟**

نعم. الخطوط المستخدمة في العروض المصدر تُحفظ في الملف الناتج، بشرط أن تكون مثبتة على النظام أو [embedded](/slides/ar/androidjava/embedded-font/).