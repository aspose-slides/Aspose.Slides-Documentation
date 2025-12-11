---
title: دمج العروض التقديمية بفاعلية على Android
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/androidjava/merge-presentation/
keywords:
  - دمج PowerPoint
  - دمج العروض
  - دمج الشرائح
  - دمج PPT
  - دمج PPTX
  - دمج ODP
  - دمج PowerPoint
  - دمج العروض
  - دمج الشرائح
  - دمج PPT
  - دمج PPTX
  - دمج ODP
  - Android
  - Java
  - Aspose.Slides
description: "دمج PowerPoint (PPT، PPTX) و OpenDocument (ODP) بسهولة باستخدام Aspose.Slides لـ Android عبر Java، مما يبسط سير العمل الخاص بك."
---

{{% alert title="نصيحة" color="primary" %}} 

قد ترغب في تجربة **Aspose free online** [تطبيق الدمج](https://products.aspose.app/slides/merger). يتيح للأشخاص دمج عروض PowerPoint بالتنسيق نفسه (PPT إلى PPT، PPTX إلى PPTX، وما إلى ذلك) ودمج العروض بتنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، وما إلى ذلك).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عند دمج عرض تقديمي مع آخر، فإنك في الواقع تجمع شرائحهما في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="معلومات" color="info" %}}

معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) تفتقر إلى وظائف تمكّن المستخدمين من دمج العروض بهذه الطريقة. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)، مع ذلك، يتيح لك دمج العروض بطرق مختلفة. يمكنك دمج العروض مع جميع الأشكال، الأنماط، النصوص، التنسيق، التعليقات، الحركات، وما إلى ذلك دون القلق بشأن فقدان الجودة أو البيانات.

**انظر أيضًا**

[استنساخ الشرائح](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **ما الذي يمكن دمجه**

مع Aspose.Slides، يمكنك دمج

* العروض الكاملة. جميع الشرائح من العروض تُجمع في عرض تقديمي واحد
* شرائح محددة. الشرائح المختارة تُجمع في عرض تقديمي واحد
* العروض بتنسيق واحد (PPT إلى PPT، PPTX إلى PPTX، إلخ) وبتنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) إلى بعضها البعض. 

{{% alert title="ملاحظة" color="warning" %}} 

بالإضافة إلى العروض، يتيح لك Aspose.Slides دمج ملفات أخرى:

* [الصور](https://products.aspose.com/slides/androidjava/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* المستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* وملفّين مختلفين مثل [صورة إلى PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان

* كل شريحة في العرض الناتج تحتفظ بنمط فريد
* يُستخدم نمط محدد لجميع الشرائح في العرض الناتج. 

لدمج العروض، يقدم Aspose.Slides طرقًا [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)). هناك عدة تطبيقات لطريقة `AddClone` التي تحدد معاملات عملية دمج العروض. كل كائن Presentation يحتوي على مجموعة [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)، لذا يمكنك استدعاء طريقة `AddClone` من العرض الذي تريد دمج الشرائح إليه.

طريقة `AddClone` تُعيد كائن `ISlide`، وهو نسخة من الشريحة الأصلية. الشرائح في العرض الناتج هي مجرد نسخة من الشرائح في المصدر. لذلك يمكنك تعديل الشرائح الناتجة (مثل تطبيق الأنماط أو خيارات التنسيق أو التخطيطات) دون القلق من تأثير ذلك على العروض الأصلية.

## **دمج العروض التقديمية** 

يوفر Aspose.Slides الطريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تسمح لك بدمج الشرائح مع احتفاظها بتخطيطاتها وأنماطها (المعلمات الافتراضية).

يوضح لك هذا الكود بلغة Java كيفية دمج العروض:
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


## **دمج العروض مع شريحة رئيسية**

يوفر Aspose.Slides الطريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تسمح لك بدمج الشرائح مع تطبيق قالب شريحة رئيسية في العرض. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في العرض الناتج.

هذا الكود بلغة Java يوضح العملية الموضحة:
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

يتم تحديد تخطيط الشريحة الرئيسة تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم تعيين المعامل المنطقي `allowCloneMissingLayout` في طريقة `AddClone` إلى true، يُستخدم تخطيط الشريحة المصدر. وإلا سيُرمى استثناء [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

إذا رغبت أن تكون للشرائح في العرض الناتج تخطيط مختلف، استخدم الطريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) بدلاً من ذلك عند الدمج.

## **دمج شرائح محددة من العروض**

يُعد دمج شرائح محددة من عروض متعددة مفيدًا لإنشاء مجموعة شرائح مخصصة. يتيح لك Aspose.Slides for Android via Java اختيار واستيراد الشرائح التي تحتاجها فقط. تحافظ الـ API على التنسيق والتخطيط وتصميم الشرائح الأصلية.

الكود Java التالي ينشئ عرضًا تقديميًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة إلى ملف:
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


## **دمج العروض مع تخطيط شريحة**

هذا الكود بلغة Java يوضح لك كيفية دمج الشرائح من العروض مع تطبيق تخطيط الشرائح المفضل لديك للحصول على عرض تقديمي واحد ناتج:
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

لا يمكنك دمج عروض ذات أحجام شرائح مختلفة.

{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، يجب تعديل حجم أحد العروض ليتطابق مع حجم العرض الآخر.

هذا الكود المثال يوضح العملية المذكورة:
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


## **دمج الشرائح إلى قسم من العرض**

هذا الكود بلغة Java يوضح لك كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:
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

توفر Aspose تطبيق ويب [Collage مجاني](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

{{% /alert %}}

## **الأسئلة المتكررة**

**هل هناك أي قيود على عدد الشرائح عند دمج العروض؟**

لا توجد قيود صارمة. يمكن لـ Aspose.Slides معالجة ملفات كبيرة، لكن الأداء يعتمد على حجم الملف وموارد النظام. بالنسبة للعروض الكبيرة جدًا، يُنصح باستخدام JVM 64-bit وتخصيص ذاكرة heap كافية.

**هل يمكنني دمج العروض التي تحتوي على فيديو أو صوت مدمج؟**

نعم، يحافظ Aspose.Slides على المحتوى متعدد الوسائط المدمج في الشرائح، لكن قد يصبح العرض النهائي أكبر حجمًا بشكل ملحوظ.

**هل سيتم الحفاظ على الخطوط عند دمج العروض؟**

نعم. الخطوط المستخدمة في العروض المصدرية تُحفظ في الملف الناتج، بشرط أن تكون مثبتة على النظام أو [embedded](/slides/ar/androidjava/embedded-font/).