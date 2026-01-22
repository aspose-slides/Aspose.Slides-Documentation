---
title: دمج العروض التقديمية بكفاءة على Android
linktitle: دمج العروض
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
- تجميع PowerPoint
- تجميع العروض التقديمية
- تجميع الشرائح
- تجميع PPT
- تجميع PPTX
- تجميع ODP
- Android
- Java
- Aspose.Slides
description: "دمج عروض PowerPoint (PPT، PPTX) و OpenDocument (ODP) بسهولة باستخدام Aspose.Slides لنظام Android عبر Java، مما يبسط سير العمل الخاص بك."
---

{{% alert  title="نصيحة" color="primary" %}} 

قد ترغب في تجربة **Aspose مجاني عبر الإنترنت** [تطبيق الدمج](https://products.aspose.app/slides/merger). يتيح للمستخدمين دمج عروض PowerPoint بنفس الصيغة (PPT إلى PPT، PPTX إلى PPTX، إلخ) ودمج العروض بصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عند دمج عرض تقديمي إلى آخر، فإنك فعليًا تجمع شرائحهم في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="معلومات" color="info" %}}

معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) تفتقر إلى وظائف تسمح للمستخدمين بدمج العروض بطريقة كهذه. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)، however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data.

**انظر أيضًا**

[استنساخ الشرائح](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 

* العروض الكاملة. جميع الشرائح من العروض تنتهي في عرض تقديمي واحد
* شرائح محددة. الشرائح المختارة تنتهي في عرض تقديمي واحد
* عروض بصيغة واحدة (PPT إلى PPT، PPTX إلى PPTX، إلخ) وبصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) إلى بعضها البعض. 

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا

* كل شريحة في عرض الإخراج تحتفظ بنمط فريد
* يُستخدم نمط محدد لجميع الشرائح في عرض الإخراج. 

لدمج العروض، توفر Aspose.Slides طرق [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (من الواجهة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) ). هناك عدة تطبيقات لطرق `AddClone` تحدد معلمات عملية دمج العروض. كل كائن Presentation يحتوي على مجموعة [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)، لذا يمكنك استدعاء طريقة `AddClone` من العرض الذي تريد دمج الشرائح إليه.

طريقة `AddClone` تُعيد كائن `ISlide`، وهو نسخة من الشريحة المصدر. الشرائح في عرض الإخراج هي ببساطة نسخة من الشرائح في المصدر. لذلك يمكنك تعديل الشرائح الناتجة (على سبيل المثال، تطبيق أنماط أو خيارات تنسيق أو تخطيطات) دون القلق من تأثير ذلك على العروض المصدر.

## **دمج العروض** 

توفر Aspose.Slides الطريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تسمح لك بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (معلمات افتراضية).

يظهر هذا الكود Java كيفية دمج العروض:
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


## **دمج العروض باستخدام القالب الرئيسي للشرائح**

توفر Aspose.Slides الطريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تسمح لك بدمج الشرائح مع تطبيق قالب رئيسي للشرائح. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في عرض الإخراج.

هذا الكود Java يوضح العملية الموضحة:
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


{{% alert title="ملاحظة" color="warning" %}} 

يتم تحديد تخطيط الشريحة للقالب الرئيسي تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم تعيين معامل `allowCloneMissingLayout` من نوع boolean إلى true، يُستخدم تخطيط الشريحة المصدر. وإلا سيتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

إذا كنت تريد أن تكون للشرائح في عرض الإخراج تخطيط شريحة مختلف، استخدم طريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) بدلاً من ذلك عند الدمج.

## **دمج شرائح محددة من العروض**

دمج شرائح محددة من عروض متعددة مفيد لإنشاء مجموعة شرائح مخصصة. تتيح Aspose.Slides for Android via Java لك اختيار واستيراد الشرائح التي تحتاجها فقط. يحافظ API على تنسيق وتخطيط وتصميم الشرائح الأصلية.

الكود Java التالي ينشئ عرض تقديمي جديد، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة إلى ملف:
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


## **دمج العروض باستخدام تخطيط شريحة**

يظهر هذا الكود Java كيفية دمج الشرائح من العروض مع تطبيق تخطيط شريحة مفضل لديك للحصول على عرض إخراج واحد:
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


## **دمج العروض بأحجام شرائح مختلفة**

{{% alert title="ملاحظة" color="warning" %}} 

لا يمكنك دمج عروض بأحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، عليك تعديل حجم أحد العروض لتتطابق حجمه مع حجم العرض الآخر.

هذا الكود يوضح العملية الموضحة:
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


## **دمج الشرائح إلى قسم في العرض التقديمي**

هذا الكود Java يوضح كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:
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

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيق ويب [مجاني لإنشاء كولاج](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

{{% /alert %}}

## **الأسئلة الشائعة**

**هل هناك أي حدود لعدد الشرائح عند دمج العروض؟**

لا توجد حدود صارمة. يمكن لـ Aspose.Slides التعامل مع ملفات كبيرة، لكن الأداء يعتمد على حجم الملف وموارد النظام. للعروض الكبيرة جدًا يُنصح باستخدام JVM 64‑bit وتخصيص ذاكرة heap كافية.

**هل يمكنني دمج عروض تحتوي على فيديو أو صوت مدمج؟**

نعم، يحافظ Aspose.Slides على المحتوى متعدد الوسائط المدمج في الشرائح، لكن قد يصبح حجم العرض النهائي كبيرًا بشكل كبير.

**هل سيتم حفظ الخطوط عند دمج العروض؟**

نعم. يتم حفظ الخطوط المستخدمة في العروض المصدر في الملف الناتج، بشرط أن تكون مثبتة على النظام أو [مضمن](/slides/ar/androidjava/embedded-font/).