---
title: دمج العروض التقديمية بكفاءة على Android
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
description: "دمج PowerPoint (PPT، PPTX) وعروض OpenDocument (ODP) بسهولة باستخدام Aspose.Slides لنظام Android عبر Java، مما يبسط سير عملك."
---
## **نظرة عامة**

يعد دمج عروض PowerPoint وOpenDocument مهمة شائعة في العديد من تطبيقات Android، خاصةً عند إنشاء التقارير، وتجميع الشرائح من مصادر مختلفة، أو أتمتة سير عمل العروض التقديمية. توفر Aspose.Slides واجهة برمجة تطبيقات قوية وسهلة الاستخدام لدمج ملفات PPT أو PPTX أو ODP المتعددة في عرض تقديمي واحد دون الحاجة لتثبيت Microsoft PowerPoint أو LibreOffice أو OpenOffice.

في هذا الدليل، ستتعلم كيفية دمج عروض PowerPoint وOpenDocument باستخدام عدد قليل من أسطر الشيفرة فقط. سنوفر أمثلة جاهزة للاستخدام، وسنوضح كيفية الحفاظ على تنسيق الشرائح، وتخطيطاتها، وعناصر العرض التقديمي الأخرى خلال عملية الدمج.

سواء كنت تبني تطبيقًا على مستوى المؤسسات أو أداة أتمتة بسيطة، تجعل Aspose.Slides دمج العروض التقديمية سريعًا، موثوقًا، وقابلًا للتوسع. تتيح لك Aspose.Slides دمج العروض بطرق مختلفة. يمكنك دمج العروض مع جميع أشكالها، أنماطها، نصوصها، تنسيقاتها، تعليقاتها، حراكها، وغير ذلك—دون القلق بشأن فقدان الجودة أو البيانات.

{{% alert color="info" %}}
انظر أيضًا: [Clone Slides](https://docs.aspose.com/slides/ar/androidjava/clone-slides/)
{{% /alert %}}

### **ما يمكن دمجه**

* العروض التقديمية بالكامل. جميع الشرائح من العروض تُدمج في عرض تقديمي واحد
* شرائح محددة. الشرائح المختارة تُدمج في عرض تقديمي واحد
* العروض التقديمية بصيغة واحدة (PPT إلى PPT، PPTX إلى PPTX، إلخ) وبصيغ مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) إلى بعضها البعض. 

### **خيارات الدمج**

يمكنك تطبيق الخيارات التي تحدد ما إذا كان
* كل شريحة في العرض الناتج تحتفظ بنمط فريد
* نمط محدد يُستخدم لجميع الشرائح في العرض الناتج. 

لدمج العروض التقديمية، توفر Aspose.Slides طرقًا [AddClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection)). هناك عدة تطبيقات لطرق `AddClone` التي تحدد معلمات عملية دمج العرض. كل كائن Presentation يحتوي على مجموعة [Slides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--)، لذلك يمكنك استدعاء طريقة `AddClone` من العرض الذي ترغب في دمج الشرائح إليه.

طريقة `AddClone` تُعيد كائنًا من نوع `ISlide`، وهو نسخة مستنسخة من الشريحة المصدرية. الشرائح في العرض الناتج هي ببساطة نسخة من الشرائح في المصدر. لذلك، يمكنك تعديل الشرائح الناتجة (على سبيل المثال، تطبيق الأنماط أو خيارات التنسيق أو التخطيطات) دون القلق من تأثر العروض المصدرية.

## **دمج العروض التقديمية** 

توفر Aspose.Slides الطريقة [**AddClone(ISlide)**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تتيح لك دمج الشرائح مع احتفاظها بتخطيطاتها وأنماطها (معلمات افتراضية).

يعرض لك هذا الشيفرة Java كيفية دمج العروض التقديمية:

```java
import com.aspose.slides.*;

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

## **دمج العروض التقديمية مع نموذج شريحة رئيسي** 

توفر Aspose.Slides الطريقة [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) التي تتيح لك دمج الشرائح مع تطبيق قالب نموذج شريحة رئيسي للعرض. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في العرض الناتج.

يوضح هذا الشيفرة في Java العملية الموصوفة:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
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
يتم تحديد تخطيط الشريحة للنموذج الرئيسي تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا تم ضبط المعامل المنطقي `allowCloneMissingLayout` في طريقة `AddClone` على true، يُستخدم تخطيط الشريحة المصدرية. وإلا، سيتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

إذا كنت تريد أن تكون للشرائح في العرض الناتج تخطيط شريحة مختلف، استخدم طريقة [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) بدلاً من ذلك عند الدمج.

## **دمج شرائح محددة من العروض التقديمية** 

يعد دمج شرائح محددة من عدة عروض تقديمية مفيدًا لإنشاء مجموعات شرائح مخصصة. تمكّن Aspose.Slides لنظام Android عبر Java من اختيار واستيراد الشرائح التي تحتاجها فقط. تحافظ الواجهة البرمجية على تنسيق وتخطيط وتصميم الشرائح الأصلية.

يقوم الشيفرة Java التالية بإنشاء عرض تقديمي جديد، وإضافة شرائح عنوان من عرضين آخرين، وحفظ النتيجة في ملف:

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

## **دمج العروض التقديمية مع تخطيط شريحة** 

يعرض لك هذا الشيفرة Java كيفية دمج الشرائح من العروض التقديمية مع تطبيق تخطيط الشريحة المفضل لديك للحصول على عرض تقديمي واحد ناتج:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
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

{{% alert title="ملاحظة" color="warning" %}} 
لا يمكنك دمج عروض تقديمية ذات أحجام شرائح مختلفة. 
{{% /alert %}}

لدمج عرضين تقديميين بأحجام شرائح مختلفة، عليك تغيير حجم أحد العروض ليطابق حجم العرض الآخر. 

يوضح هذا الشيفرة العينة العملية الموصوفة:

```java
import com.aspose.slides.*;

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

يعرض لك هذا الشيفرة Java كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:

```java
import com.aspose.slides.*;

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

{{% alert title="نصيحة" color="info" %}} 
توفر Aspose تطبيق ويب مجاني للـ Collage [FREE Collage web app](https://products.aspose.app/slides/ar/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/ar/collage/photo-grid)، وما إلى ذلك. 
{{% /alert %}}

## **الأسئلة المتكررة** 

### هل هناك أي قيود على عدد الشرائح عند دمج العروض التقديمية؟

لا توجد قيود صارمة. يمكن لـ Aspose.Slides معالجة ملفات كبيرة، لكن الأداء يعتمد على حجم الملف وموارد النظام. بالنسبة للعروض التقديمية الكبيرة جدًا، يُنصح باستخدام JVM 64-bit وتخصيص كمية كافية من ذاكرة الـ heap.

### هل يمكنني دمج عروض تقديمية تحتوي على فيديو أو صوت مدمج؟

نعم، تحافظ Aspose.Slides على المحتوى متعدد الوسائط المدمج في الشرائح، لكن قد يصبح العرض النهائي أكبر حجمًا بشكل كبير.

### هل سيتم الحفاظ على الخطوط عند دمج العروض التقديمية؟

نعم. يتم الحفاظ على الخطوط المستخدمة في العروض المصدرية في الملف الناتج، بشرط أن تكون مثبتة على النظام أو [مضمنة](/slides/ar/androidjava/embedded-font/).