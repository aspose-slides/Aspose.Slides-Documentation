---
title: دمج العروض التقديمية بفعالية في جافا
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/java/merge-presentation/
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
- جافا
- Aspose.Slides
description: "دمج عروض PowerPoint (PPT, PPTX) وOpenDocument (ODP) بسهولة باستخدام Aspose.Slides for Java، مما يبسط سير عملك."
---

## **نظرة عامة**

يُعد دمج عروض PowerPoint وOpenDocument مهمة شائعة في العديد من تطبيقات Java، خاصةً عند إنشاء تقارير، تجميع شرائح من مصادر مختلفة، أو أتمتة سير عمل العروض التقديمية. يوفر Aspose.Slides for Java واجهة برمجة تطبيقات قوية وسهلة الاستخدام لدمج ملفات PPT وPPTX أو ODP متعددة في عرض تقديمي واحد دون الحاجة لتثبيت Microsoft PowerPoint أو LibreOffice أو OpenOffice.

في هذا الدليل، ستتعلم كيفية دمج عروض PowerPoint وOpenDocument باستخدام بضع أسطر فقط من كود Java. سنوفر أمثلة جاهزة للاستخدام، ونظهر كيفية الحفاظ على تنسيق الشرائح وتخطيطاتها والعناصر الأخرى للعرض أثناء عملية الدمج.

سواءً كنت تبني تطبيقًا على مستوى المؤسسات أو أداة أتمتة بسيطة، يجعل Aspose.Slides دمج العروض التقديمية في Java سريعًا، موثوقًا، وقابلاً للتوسع. يتيح Aspose.Slides for Java دمج العروض بطرق مختلفة. يمكنك دمج العروض مع جميع الأشكال، الأنماط، النصوص، التنسيقات، التعليقات، الرسوم المتحركة، وأكثر—دون القلق بشأن فقدان الجودة أو البيانات.

{{% alert color="primary" %}}
انظر أيضًا: [استنساخ الشرائح](https://docs.aspose.com/slides/java/clone-slides/)
{{% /alert %}}

### **ما الذي يمكن دمجه؟**

مع Aspose.Slides، يمكنك دمج:

**العروض التقديمية بالكامل** – تُدمج جميع الشرائح من عروض متعددة في عرض واحد.

**شرائح محددة** – تُدمج فقط الشرائح المختارة في عرض تقديمي واحد.

**العروض بنفس التنسيق** (مثل PPT إلى PPT، PPTX إلى PPTX) **وبتنسيقات مختلفة** (مثل PPT إلى PPTX، PPTX إلى ODP).

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا:

- تحتفظ كل شريحة في العرض الناتج بنمطها الأصلي
- يُطبق نمط محدد على جميع الشرائح في العرض الناتج

لدمج العروض، يقدم Aspose.Slides طرق `AddClone` من واجهة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/). هناك عدة إصدارات مفرطة لـ `AddClone` تحدد سلوك عملية الدمج. كل كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) يحتوي على مجموعة Slides. لذا يمكنك استدعاء طريقة `AddClone` على العرض الهدف الذي تريد دمج الشرائح فيه.

تُعيد طريقة `AddClone` كائنًا من نوع [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)، وهو نسخة مستنسخة من الشريحة المصدر. الشرائح الناتجة في العرض النهائي هي نسخ بسيطة من الشرائح الأصلية. هذا يعني أنه يمكنك تعديل الشرائح المستنسخة بأمان—مثل تطبيق الأنماط أو خيارات التنسيق أو التخطيطات—دون التأثير على العرض المصدر.

## **دمج العروض التقديمية**

يوفر Aspose.Slides طريقة [AddClone(ISlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) التي تسمح بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها الأصلية (السلوك الافتراضي).

الكود التالي Java يوضح كيفية دمج العروض التقديمية:
```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


## **دمج العروض التقديمية مع شريحة رئيسية**

يوفر Aspose.Slides طريقة [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تسمح بدمج الشرائح مع تطبيق شريحة رئيسية من قالب عرض تقديمي. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير نمط الشرائح في العرض الناتج.

الكود التالي Java يوضح هذا العملية:
```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation2.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


{{% alert title="ملاحظة" color="warning" %}}
يتم تحديد تخطيط الشريحة تلقائيًا. عندما لا يمكن العثور على تخطيط مناسب، وإذا تم تعيين المعامل المنطقي `allowCloneMissingLayout` في طريقة `AddClone` إلى `true`، يُستخدم التخطيط من الشريحة المصدر. وإلا، يُرمى استثناء [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **دمج شرائح محددة من العروض التقديمية**

يعد دمج شرائح محددة من عدة عروض مفيدًا لإنشاء مجموعات شرائح مخصصة. يتيح Aspose.Slides for Java اختيار واستيراد الشرائح التي تحتاجها فقط. يحافظ API على تنسيق وتخطيط وتصميم الشرائح الأصلية.

الكود التالي Java ينشئ عرضًا تقديميًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة في ملف:
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

لتطبيق تخطيط شريحة مختلف على الشرائح الناتجة أثناء الدمج، استخدم طريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) بدلاً من ذلك.

الكود التالي Java يوضح كيفية دمج الشرائح من عدة عروض مع تطبيق تخطيط شريحة مفضل لديك، لينتج عرضًا تقديميًا واحدًا:
```java
int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation2.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


## **دمج العروض التقديمية بأحجام شرائح مختلفة**

لدمج عرضين بحجم شريحة مختلف، يجب تعديل أحدهما ليتطابق مع حجم شريحة العرض الآخر.

الكود التالي Java يوضح هذه العملية:
```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    Dimension2D slideSize = presentation1.getSlideSize().getSize();
    float slideWidth = (float) slideSize.getWidth();
    float slideHeight = (float) slideSize.getHeight();
    
    presentation2.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


## **دمج الشرائح إلى قسم في العرض التقديمي**

يساعد دمج الشرائح في قسم محدد من العرض على تنظيم المحتوى وتحسين تنقل الشرائح. يسمح Aspose.Slides بدمج الشرائح إلى أقسام موجودة، مما يضمن بنية واضحة مع الحفاظ على تنسيق كل شريحة أصلي.

الكود التالي Java يوضح كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:
```java
int sectionIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ISection section = presentation1.getSections().get_Item(sectionIndex);
        presentation1.getSlides().addClone(slide, section);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


تُضاف الشريحة إلى نهاية القسم.

## **انظر أيضًا**

توفر Aspose أداة **صانع كولاج مجاني عبر الإنترنت**(https://products.aspose.app/slides/collage). باستخدام هذه الخدمة على الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وأكثر.

جرب **أداة الدمج المجانية عبر الإنترنت**(https://products.aspose.app/slides/merger). تتيح لك دمج عروض PowerPoint بنفس التنسيق (مثل PPT إلى PPT، PPTX إلى PPTX) أو عبر تنسيقات مختلفة (مثل PPT إلى PPTX، PPTX إلى ODP).

[![Aspose أداة دمج مجانية عبر الإنترنت](slides-merger.png)](https://products.aspose.app/slides/merger)

إلى جانب العروض التقديمية، يتيح Aspose.Slides دمج ملفات أخرى:

- [**الصور**](https://products.aspose.com/slides/java/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/java/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/java/merger/png-to-png/)
- **المستندات**، مثل [PDF إلى PDF](https://products.aspose.com/slides/java/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/java/merger/html-to-html/)
- **أنواع ملفات مختلطة**، مثل [صورة إلى PDF](https://products.aspose.com/slides/java/merger/image-to-pdf/)، [JPG إلى PDF](https://products.aspose.com/slides/java/merger/jpg-to-pdf/)، أو [TIFF إلى PDF](https://products.aspose.com/slides/java/merger/tiff-to-pdf/)

## **الأسئلة المتكررة**

**هل هناك أي حدود لعدد الشرائح عند دمج العروض التقديمية؟**

ليس هناك حدود صارمة. يمكن لـ Aspose.Slides التعامل مع ملفات كبيرة، لكن الأداء يعتمد على حجم الملف وموارد النظام. بالنسبة للعروض الكبيرة جدًا، يُنصح باستخدام JVM بنسخة 64‑bit وتخصيص ذاكرة كافية.

**هل يمكنني دمج عروض تحتوي على فيديو أو صوت مدمج؟**

نعم، يحافظ Aspose.Slides على المحتوى متعدد الوسائط المدمج في الشرائح، لكن قد يصبح حجم العرض النهائي أكبر بكثير.

**هل يتم الحفاظ على الخطوط عند دمج العروض؟**

نعم. تُحافظ الخطوط المستخدمة في العروض المصدر في الملف الناتج، شريطة أن تكون مثبتة على النظام أو [مضمنة](/slides/ar/java/embedded-font/).