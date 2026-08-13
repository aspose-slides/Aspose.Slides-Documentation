---
title: دمج العروض التقديمية بفعالية في Java
linktitle: دمج العروض
type: docs
weight: 40
url: /ar/java/merge-presentation/
keywords:
- دمج PowerPoint
- دمج العروض
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- جمع PowerPoint
- جمع العروض
- جمع الشرائح
- جمع PPT
- جمع PPTX
- جمع ODP
- Java
- Aspose.Slides
description: "دمج عروض PowerPoint (PPT، PPTX) و OpenDocument (ODP) بسهولة باستخدام Aspose.Slides for Java، لتبسيط سير العمل الخاص بك."
---
## **نظرة عامة**

يعد دمج عروض PowerPoint وOpenDocument مهمة شائعة في العديد من تطبيقات Java، خاصةً عند إنشاء تقارير، تجميع شرائح من مصادر مختلفة، أو أتمتة عمليات العروض التقديمية. توفر Aspose.Slides for Java واجهة برمجة تطبيقات قوية وسهلة الاستخدام لدمج ملفات PPT وPPTX أو ODP متعددة في عرض تقديمي واحد دون الحاجة لتثبيت Microsoft PowerPoint أو LibreOffice أو OpenOffice.

في هذا الدليل، ستتعلم كيفية دمج عروض PowerPoint وOpenDocument باستخدام بضع أسطر من شفرة Java فقط. سنقدم أمثلة جاهزة للاستخدام، ونوضح كيفية الحفاظ على تنسيق الشرائح، وتخطيطاتها، والعناصر الأخرى للعرض أثناء عملية الدمج.

سواءً كنت تبني تطبيقًا على مستوى المؤسسة أو أداة أتمتة بسيطة، تجعل Aspose.Slides عملية دمج العروض في Java سريعة، موثوقة، وقابلة للتوسع. تتيح لك Aspose.Slides for Java دمج العروض بطرق مختلفة. يمكنك دمج العروض مع جميع الأشكال، الأنماط، النصوص، التنسيقات، التعليقات، الرسوم المتحركة، وأكثر—دون القلق بشأن فقدان الجودة أو البيانات.

{{% alert color="info" %}}
انظر أيضًا: [نسخ الشرائح](https://docs.aspose.com/slides/ar/java/clone-slides/)
{{% /alert %}}

### **ما الذي يمكن دمجه؟**

مع Aspose.Slides، يمكنك دمج:

**العروض بالكامل** – يتم دمج جميع الشرائح من عروض متعددة في عرض واحد.

**شرائح محددة** – تُدمج فقط الشرائح المختارة في عرض تقديمي واحد.

**العروض بنفس الصيغة** (مثل PPT إلى PPT، PPTX إلى PPTX) **وبصيغ مختلفة** (مثل PPT إلى PPTX، PPTX إلى ODP).

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كان:

- كل شريحة في العرض الناتج تحتفظ بالنمط الأصلي الخاص بها
- يتم تطبيق نمط محدد على جميع الشرائح في العرض الناتج

لدمج العروض، توفر Aspose.Slides طرق `AddClone` من واجهة [ISlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/) . هناك عدة إصدارات لطريقة `AddClone` تحدد سلوك عملية الدمج. كل كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) يمتلك مجموعة Slides. لذا، يمكنك استدعاء طريقة `AddClone` على العرض الهدف الذي تريد دمج الشرائح فيه.

طريقة `AddClone` تُعيد كائن [ISlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/) ، وهو نسخة مستنسخة من الشريحة المصدر. الشرائح الناتجة في العرض النهائي هي مجرد نسخ من الشرائح الأصلية. وهذا يعني أنه يمكنك تعديل الشرائح المستنسخة بأمان—مثل تطبيق الأنماط، خيارات التنسيق، أو التخطيطات—دون التأثير على العرض المصدر.

## **دمج العروض**

توفر Aspose.Slides طريقة [AddClone(ISlide)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) التي تسمح بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها الأصلية (السلوك الافتراضي).

يظهر الشفرة التالية بلغة Java كيفية دمج العروض:

```java
import com.aspose.slides.*;

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

## **دمج العروض مع شريحة رئيسية**

توفر Aspose.Slides طريقة [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تسمح بدمج الشرائح مع تطبيق شريحة رئيسية من قالب عرض. بهذه الطريقة، يمكنك تعديل نمط الشرائح في العرض الناتج إذا لزم الأمر.

توضح الشفرة التالية بلغة Java هذا الإجراء:

```java
import com.aspose.slides.*;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation1.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}}
يتم تحديد تخطيط الشريحة تلقائيًا. عندما لا يمكن العثور على تخطيط مناسب، وإذا تم تعيين المعامل `allowCloneMissingLayout` في طريقة `AddClone` إلى `true`، يُستخدم التخطيط من الشريحة المصدر. وإلا، يتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **دمج شرائح محددة من العروض**

يُعد دمج شرائح محددة من عدة عروض مفيدًا لإنشاء مجموعة شرائح مخصصة. يتيح لك Aspose.Slides for Java اختيار واستيراد الشرائح التي تحتاجها فقط. يحافظ API على التنسيق، التخطيط، وتصميم الشرائح الأصلية.

تظهر الشفرة التالية بلغة Java إنشاء عرض جديد، إضافة شرائح عنوان من عرضين آخرين، وحفظ النتيجة في ملف:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

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

لتطبيق تخطيط شريحة مختلف على الشرائح الناتجة أثناء الدمج، استخدم طريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) بدلاً من ذلك.

تُظهر الشفرة التالية بلغة Java كيفية دمج الشرائح من عروض متعددة مع تطبيق التخطيط المفضل لديك، مما ينتج عرضًا تقديميًا واحدًا:

```java
import com.aspose.slides.*;

int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation1.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **دمج العروض بأحجام شرائح مختلفة**

لدمج عرضين بأحجام شرائح مختلفة، يجب تعديل حجم أحدهما لتطابق حجم الشرائح في العرض الآخر.

تُظهر الشفرة التالية بلغة Java هذا الإجراء:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

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

## **دمج الشرائح إلى قسم من العرض**

يساعد دمج الشرائح في قسم معين من العرض على تنظيم المحتوى وتحسين تنقل الشرائح. تسمح لك Aspose.Slides بدمج الشرائح إلى الأقسام الموجودة. يضمن ذلك هيكلًا واضحًا مع الحفاظ على تنسيق كل شريحة أصلي.

تُظهر الشفرة التالية بلغة Java كيفية دمج شريحة محددة في قسم من العرض:

```java
import com.aspose.slides.*;

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

يُضاف الشريحة إلى نهاية القسم.

## **انظر أيضًا**

توفر Aspose أداة [صانعة كولاج مجانية عبر الإنترنت](https://products.aspose.app/slides/ar/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG إلى PNG، إنشاء [شبكات صور](https://products.aspose.app/slides/ar/collage/photo-grid)، وأكثر.

جرب [أداة دمج مجانية عبر الإنترنت من Aspose](https://products.aspose.app/slides/ar/merger). تتيح لك دمج عروض PowerPoint بنفس الصيغة (مثل PPT إلى PPT، PPTX إلى PPTX) أو عبر صيغ مختلفة (مثل PPT إلى PPTX، PPTX إلى ODP).

[![Aspose دمج مجاني عبر الإنترنت](slides-merger.png)](https://products.aspose.app/slides/ar/merger)

بالإضافة إلى العروض، تسمح Aspose.Slides بدمج ملفات أخرى:

- [**صور**](https://products.aspose.com/slides/ar/java/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/ar/java/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/ar/java/merger/png-to-png/)
- **مستندات**، مثل [PDF إلى PDF](https://products.aspose.com/slides/ar/java/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/ar/java/merger/html-to-html/)
- **أنواع ملفات مختلطة**، مثل [صورة إلى PDF](https://products.aspose.com/slides/ar/java/merger/image-to-pdf/)، [JPG إلى PDF](https://products.aspose.com/slides/ar/java/merger/jpg-to-pdf/)، أو [TIFF إلى PDF](https://products.aspose.com/slides/ar/java/merger/tiff-to-pdf/)

## **الأسئلة الشائعة**

### هل هناك أي حدود على عدد الشرائح عند دمج العروض؟

لا توجد حدود صارمة. يمكن لـ Aspose.Slides معالجة ملفات كبيرة، لكن الأداء يعتمد على حجم الملف وموارد النظام. بالنسبة للعروض الكبيرة جدًا، يُنصح باستخدام JVM 64‑bit وتخصيص ذاكرة heap كافية.

### هل يمكنني دمج عروض تحتوي على فيديو أو صوت مدمج؟

نعم، يحافظ Aspose.Slides على المحتوى المتعدد الوسائط المدمج في الشرائح، لكن قد يصبح حجم العرض النهائي أكبر بشكل ملحوظ.

### هل سيتم الحفاظ على الخطوط عند دمج العروض؟

نعم. يتم الحفاظ على الخطوط المستخدمة في العروض المصدر في الملف الناتج، بشرط أن تكون مثبتة على النظام أو [مُضمَّنة](/slides/ar/java/embedded-font/).