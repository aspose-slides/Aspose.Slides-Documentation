---
title: دمج العروض التقديمية
type: docs
weight: 40
url: /java/merge-presentation/
keywords: "دمج PowerPoint, PPTX, PPT, دمج PowerPoint, دمج العروض, دمج العرض, Java"
description: "دمج أو دمج العروض التقديمية في Java"
---


{{% alert  title="نصيحة" color="primary" %}} 

قد ترغب في الاطلاع على **تطبيق Aspose المجاني عبر الإنترنت** [Merger app](https://products.aspose.app/slides/merger). يسمح للناس بدمج عروض PowerPoint في نفس التنسيق (PPT إلى PPT، PPTX إلى PPTX، إلخ) ودمج العروض في تنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عند دمج عرض تقديمي مع آخر، فإنك بشكل فعال تجمع شريحتهما في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="معلومات" color="info" %}}

تفتقر معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) إلى الوظائف التي تسمح للمستخدمين بدمج العروض بهذه الطريقة. 

ومع ذلك، فإن [**Aspose.Slides for Java**](https://products.aspose.com/slides/java/) يتيح لك دمج العروض بطرق مختلفة. يمكنك دمج العروض التقديمية مع جميع أشكالها، أنماطها، نصوصها، تنسيقاتها، تعليقاتها، حركاتها، إلخ، دون الحاجة للقلق بشأن فقدان الجودة أو البيانات. 

**انظر أيضًا**

[Clone Slides](https://docs.aspose.com/slides/java/clone-slides/). 

{{% /alert %}}

### **ما الذي يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 

* العروض التقديمية بالكامل. جميع الشرائح من العروض التقديمية تنتهي في عرض تقديمي واحد
* شرائح محددة. الشرائح المحددة تنتهي في عرض تقديمي واحد
* العروض في نفس التنسيق (PPT إلى PPT، PPTX إلى PPTX، إلخ) وفي تنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) مع بعضها البعض. 

{{% alert title="ملاحظة" color="warning" %}} 

بجانب العروض، يتيح لك Aspose.Slides دمج ملفات أخرى:

* [صور](https://products.aspose.com/slides/java/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/java/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/java/merger/png-to-png/)
* مستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/java/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/java/merger/html-to-html/)
* وملفات مختلفة مثل [صورة إلى PDF](https://products.aspose.com/slides/java/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/java/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/java/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان:

* كل شريحة في العرض الناتج تحتفظ بأسلوب فريد
* يتم استخدام أسلوب محدد لجميع الشرائح في العرض الناتج. 

لدمج العروض، يوفر Aspose.Slides طرق [AddClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)). هناك عدة تطبيقات لطرق `AddClone` التي تحدد معلمات عملية دمج العرض التقديمي. يحتوي كل كائن عرض تقديمي على مجموعة [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)، لذا يمكنك استدعاء طريقة `AddClone` من العرض الذي تريد دمج الشرائح فيه. 

تُرجع طريقة `AddClone` كائن `ISlide`، وهو نسخة من الشريحة المصدر. الشرائح في العرض الناتج هي ببساطة نسخة من الشرائح من المصدر. لذلك، يمكنك إجراء تغييرات على الشرائح الناتجة (على سبيل المثال، تطبيق أنماط أو خيارات تنسيق أو تخطيطات) دون القلق بشأن تأثير العروض المصدر. 

## **دمج العروض التقديمية** 

يوفر Aspose.Slides طريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تتيح لك دمج الشرائح مع الحفاظ على تخطيطاتهم وأنماطهم (معلمات افتراضية). 

يوضح لك هذا الرمز Java كيفية دمج العروض التقديمية:

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

## **دمج العروض التقديمية مع الشريحة الرئيسية**

يوفر Aspose.Slides طريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تتيح لك دمج الشرائح مع تطبيق قالب العرض الرئيسي. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير الأسلوب الخاص بالشرائح في العرض الناتج. 

يوضح هذا الرمز في Java العملية الموصوفة:

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

تحدد تخطيط الشريحة للقالب الرئيسي تلقائيًا. عند عدم إمكانية تحديد تخطيط مناسب، إذا كانت المعلمة البولية `allowCloneMissingLayout` لطريقة `AddClone` ذات قيمة true، يتم استخدام تخطيط الشريحة المصدر. خلاف ذلك، ستظهر [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException). 

{{% /alert %}}

إذا كنت ترغب في أن تحتوي الشرائح في العرض الناتج على تخطيط شريحة مختلف، استخدم بدلاً من ذلك طريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) عند الدمج. 

## **دمج شرائح محددة من العروض التقديمية**

يوضح لك هذا الرمز Java كيفية اختيار ودمج شرائح معينة من عروض تقديمية مختلفة للحصول على عرض تقديمي ناتج واحد:

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

يوضح لك هذا الرمز Java كيفية دمج الشرائح من العروض التقديمية مع تطبيق التخطيط المفضل لديك عليها للحصول على عرض تقديمي ناتج واحد:

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

لا يمكنك دمج العروض التقديمية مع أحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين تقديميين بحجم شريحة مختلف، يتعين عليك تغيير حجم أحد العروض ليطابق حجم العرض الآخر. 

يوضح هذا الرمز عينة العملية الموصوفة:

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

يوضح لك هذا الرمز Java كيفية دمج شريحة محددة في قسم عرض تقديمي:

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

تتم إضافة الشريحة في نهاية القسم. 

{{% alert title="نصيحة" color="primary" %}}

تقدم Aspose تطبيق ويب [مجاني للكلوج](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

{{% /alert %}}