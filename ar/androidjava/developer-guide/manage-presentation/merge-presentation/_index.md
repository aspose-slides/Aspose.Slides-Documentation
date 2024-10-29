---
title: دمج العرض التقديمي
type: docs
weight: 40
url: /ar/androidjava/merge-presentation/
keywords: "دمج PowerPoint، PPTX، PPT، دمج PowerPoint، دمج العروض التقديمية، دمج العروض التقديمية، Java"
description: "دمج أو تجميع عرض PowerPoint في Java"
---

{{% alert  title="نصيحة" color="primary" %}} 

قد ترغب في تجربة **تطبيق Aspose المجاني عبر الإنترنت** [Merger app](https://products.aspose.app/slides/merger). يتيح للناس دمج العروض التقديمية في نفس التنسيق (PPT إلى PPT، PPTX إلى PPTX، إلخ) ودمج العروض التقديمية في تنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عند دمج عرض تقديمي مع آخر، فإنك في الأساس تجمع الشرائح الخاصة بهم في عرض تقديمي واحد للحصول على ملف واحد.

{{% alert title="معلومات" color="info" %}}

تفتقر معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) إلى الوظائف التي تسمح للمستخدمين بدمج العروض التقديمية بهذه الطريقة. 

ومع ذلك، يتيح لك [**Aspose.Slides لـ Android عبر Java**](https://products.aspose.com/slides/androidjava/) دمج العروض التقديمية بطرق مختلفة. يمكنك دمج العروض التقديمية مع جميع الأشكال والأنماط والنصوص والتنسيق والتعليقات والرسوم المتحركة، إلخ، دون الحاجة إلى القلق بشأن فقدان الجودة أو البيانات.

**انظر أيضًا**

[نسخ الشرائح](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 

* العروض التقديمية الكاملة. تنتهي جميع الشرائح من العروض التقديمية في عرض تقديمي واحد
* شرائح معينة. تصبح الشرائح المحددة في عرض تقديمي واحد
* العروض التقديمية في تنسيق واحد (PPT إلى PPT ، PPTX إلى PPTX، إلخ) وفي تنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) مع بعضها البعض. 

{{% alert title="ملاحظة" color="warning" %}} 

بخلاف العروض التقديمية، يتيح لك Aspose.Slides دمج ملفات أخرى:

* [صور](https://products.aspose.com/slides/androidjava/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* مستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* وملفين مختلفين، مثل [صورة إلى PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان

* يحتفظ كل شريحة في العرض التقديمي الناتج بأسلوب فريد
* تم استخدام أسلوب محدد لجميع الشرائح في العرض التقديمي الناتج. 

لدمج العروض التقديمية، يوفر Aspose.Slides طرق [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)). هناك عدة تنفيذات لطرق `AddClone` التي تحدد معلمات عملية دمج العروض التقديمية. كل كائن Presentation له مجموعة [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)، لذا يمكنك استدعاء طريقة `AddClone` من العرض التقديمي الذي تريد دمج الشرائح معه.

تُعيد طريقة `AddClone` كائن `ISlide`، وهو نسخة من الشريحة المصدر. الشرائح في العرض التقديمي الناتج هي ببساطة نسخة من الشرائح من المصدر. لذلك، يمكنك إجراء تغييرات على الشرائح الناتجة (على سبيل المثال، تطبيق أنماط أو خيارات تنسيق أو تخطيطات) دون القلق بشأن تأثر العروض التقديمية المصدر. 

## **دمج العروض التقديمية** 

يوفر Aspose.Slides طريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تتيح لك دمج الشرائح بينما تحتفظ الشرائح بتخطيطاتهم وأنماطهم (معلمات افتراضية).

يوضح هذا الكود Java كيفية دمج العروض التقديمية:

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

## **دمج العروض التقديمية مع المعلم الشريطي**

يوفر Aspose.Slides طريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تتيح لك دمج الشرائح مع تطبيق قالب عرض خاص. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير الأسلوب للشرائح في العرض التقديمي الناتج.

يوضح هذا الكود في Java العملية الموصوفة:

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

يتم تحديد تخطيط الشريحة لمعلم الشريحة تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم تعيين معلمة البولين `allowCloneMissingLayout` في طريقة `AddClone` على true، يتم استخدام التخطيط للشريحة المصدر. خلاف ذلك، سيتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

إذا كنت تريد أن تحتوي الشرائح في العرض التقديمي الناتج على تخطيط شريحة مختلف، استخدم بدلاً من ذلك طريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) عند الدمج.

## **دمج شرائح معينة من العروض التقديمية**

يوضح هذا الكود Java كيفية تحديد ودمج شرائح معينة من عروض تقديمية مختلفة للحصول على عرض تقديمي ناتج واحد:

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

## **دمج العروض التقديمية مع تخطيط الشريحة**

يوضح هذا الكود Java كيفية دمج الشرائح من العروض التقديمية مع تطبيق تخطيط الشريحة المفضل لديك عليهم للحصول على عرض تقديمي ناتج واحد:

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

## **دمج العروض التقديمية مع أحجام شرائح مختلفة**

{{% alert title="ملاحظة" color="warning" %}} 

لا يمكنك دمج العروض التقديمية بأحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين تقديميين بأحجام شرائح مختلفة، عليك تغيير حجم أحد العروض التقديمية لتناسب حجم العرض الآخر.

يوضح هذا الكود التجريبي العملية الموصوفة:

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

## **دمج الشرائح في قسم العرض التقديمي**

يوضح هذا الكود Java كيفية دمج شريحة معينة في قسم من عرض تقديمي:

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

تُضاف الشريحة في نهاية القسم.

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيق ويب [مجاني Collage](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

{{% /alert %}}