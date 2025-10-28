---
title: دمج العروض التقديمية بفاعلية باستخدام بايثون
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/python-net/merge-presentation/
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
- Python
- Aspose.Slides
description: "دمج عروض PowerPoint (PPT, PPTX) وOpenDocument (ODP) بسهولة باستخدام Aspose.Slides for Python عبر .NET، مما يبسط سير عملك."
---

## **تحسين دمج العروض التقديمية**

مع [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/)، يمكنك دمج عروض PowerPoint بسلاسة مع الحفاظ على الأنماط والتخطيطات وجميع العناصر. على عكس الأدوات الأخرى، يقوم Aspose.Slides بدمج العروض التقديمية دون التضحية بالجودة أو فقدان البيانات. يمكنك دمج مجموعات الشرائح بالكامل، أو شرائح محددة، أو حتى صيغ ملفات مختلفة (مثال: PPT إلى PPTX).

### **ميزات الدمج**

- **دمج العرض الكامل:** تجميع جميع الشرائح في ملف واحد.
- **دمج شرائح محددة:** اختيار ودمج الشرائح المختارة.
- **دمج عبر الصيغ:** دمج عروض بصيغ مختلفة مع الحفاظ على سلامتها.

## **دمج العروض التقديمية**

عند دمج عرض تقديمي في آخر، فأنت فعليًا تجمع شرائحهما في عرض تقديمي واحد لإنتاج ملف واحد. معظم برامج العروض التقديمية مثل PowerPoint أو OpenOffice لا توفر ميزات تسمح بدمج العروض بهذه الطريقة.

ومع ذلك، [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) يتيح لك دمج العروض بعدة طرق. يمكنك دمج العروض مع جميع الأشكال والأنماط والنصوص والتنسيقات والتعليقات والرسوم المتحركة، دون أي فقدان للجودة أو البيانات.

**انظر أيضًا**

[Clone PowerPoint Slides in Python](/slides/ar/python-net/clone-slides/)

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج:

- العروض الكاملة: جميع الشرائح من مجموعات المصدر يتم دمجها في عرض تقديمي واحد.
- شرائح محددة: فقط الشرائح المختارة تُدمج في عرض تقديمي واحد.
- عروض بنفس الصيغة (مثل PPT→PPT، PPTX→PPTX) أو عبر صيغ مختلفة (مثل PPT→PPTX، PPTX→ODP).

{{% alert title="ملاحظة" color="info" %}}

بالإضافة إلى العروض التقديمية، يتيح Aspose.Slides أيضًا دمج ملفات أخرى:

- [الصور](https://products.aspose.com/slides/python-net/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/) .
- المستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/) .
- نوعان مختلفان من الملفات، مثل [صورة إلى PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/)، [JPG إلى PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/)، أو [TIFF إلى PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/) .

{{% /alert %}}

### **خيارات الدمج**

يمكنك التحكم فيما إذا:

- كل شريحة في العرض الناتج تحتفظ بأسلوبها الأصلي، أو
- يتم تطبيق أسلوب واحد على جميع الشرائح في العرض الناتج.

لدمج العروض، يقدم Aspose.Slides طرق `add_clone` على فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) . تحدد هذه التحميلات كيفية تنفيذ الدمج. كل كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ي expose مجموعة `slides`، لذا تستدعي `add_clone` على مجموعة شرائح العرض الهدف.

طريقة `add_clone` تُعيد كائن `Slide`—نسخة من الشريحة المصدر. الشرائح في العرض الناتج هي نسخ من الأصل، لذا يمكنك تعديل الشرائح الناتجة (مثلاً، تطبيق الأنماط أو التنسيق أو التخطيطات) دون التأثير على العروض المصدر.

## **دمج العروض التقديمية** 

يقدم Aspose.Slides طريقة [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) التي تسمح بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (باستخدام القيم الافتراضية).

المثال التالي بلغة Python يوضح كيفية دمج العروض:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **دمج العروض التقديمية مع شريحة رئيسية (Slide Master)**

يقدم Aspose.Slides طريقة [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) التي تسمح بدمج الشرائح مع تطبيق شريحة رئيسية من قالب. بهذه الطريقة، عندما تحتاج، يمكنك إعادة تنسيق الشرائح في العرض الناتج.

المثال التالي بلغة Python يوضح هذه العملية:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="ملاحظة" color="warning" %}}

يتم تحديد التخطيط المناسب تحت الشريحة الرئيسية المحددة تلقائيًا. إذا لم يتم العثور على تخطيط مناسب وتم ضبط معامل `allow_clone_missing_layout` المنطقي للطريقة `add_clone` على `True`، يُستخدم تخطيط الشريحة المصدر. وإلا، سيتم رمي استثناء [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) .

{{% /alert %}}

لتطبيق تخطيط شريحة مختلف على الشرائح في العرض الناتج، استخدم طريقة [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) عند الدمج.

## **دمج شرائح محددة من العروض التقديمية**

دمج شرائح محددة من عروض متعددة مفيد عند إنشاء مجموعة شرائح مخصصة. يتيح لك Aspose.Slides اختيار واستيراد الشرائح التي تحتاجها فقط، مع الحفاظ على تنسيق وتخطيط وتصميم الشرائح الأصلية.

المثال التالي بلغة Python ينشئ عرضًا تقديميًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة في ملف:

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **دمج العروض التقديمية مع تخطيط شريحة**

المثال التالي بلغة Python يوضح كيفية دمج الشرائح من عروض متعددة مع تطبيق تخطيط شريحة محدد لإنتاج عرض تقديمي واحد:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **دمج العروض التقديمية بأحجام شرائح مختلفة**

{{% alert title="ملاحظة" color="warning" %}}

لا يمكن دمج العروض التقديمية ذات أحجام الشرائح المختلفة مباشرة.

{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، قم أولاً بتغيير حجم أحد العروض بحيث يتطابق حجم شريحته مع الآخر.

الكود التالي يوضح هذه العملية:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **دمج الشرائح في قسم من العرض التقديمي**

المثال التالي بلغة Python يوضح كيفية دمج شريحة محددة في قسم من عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

يتم إضافة الشريحة في نهاية القسم. 

{{% alert title="نصيحة" color="primary" %}}

هل تبحث عن أداة **مجانًا وسريعة على الإنترنت** لدمج عروض PowerPoint؟ جرّب **Aspose PowerPoint Merger**.

- **دمج ملفات PowerPoint بسهولة**: دمج عدة عروض **PPT, PPTX, ODP** في ملف واحد.  
- **يدعم صيغ مختلفة**: دمج **PPT إلى PPTX**, **PPTX إلى ODP**, وأكثر.  
- **لا تحتاج إلى تثبيت**: يعمل مباشرة في المتصفح، سريع وآمن.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

ابدأ دمج ملفات PowerPoint باستخدام أداة Aspose المجانية على الإنترنت اليوم!  

{{% /alert %}}

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيقًا ويبًا **مجانيًا للـ Collage**. باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يتم حفظ ملاحظات المتحدث أثناء الدمج؟**

نعم. عند استنساخ الشرائح، تنقل Aspose.Slides جميع عناصر الشريحة بما فيها الملاحظات والتنسيق والرسوم المتحركة.

**هل يتم نقل التعليقات ومؤلفيها؟**

التعليقات، كجزء من محتوى الشريحة، تُنسخ مع الشريحة. تُحفظ تسميات مؤلفي التعليقات ككائنات تعليقات في العرض الناتج.

**ماذا يحدث إذا كان العرض المصدر محميًا بكلمة مرور؟**

يجب [فتح الملف باستخدام كلمة المرور](/slides/ar/python-net/password-protected-presentation/) عبر [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); بعد التحميل، يمكن استنساخ تلك الشرائح بأمان إلى ملف هدف غير محمي (أو محمي أيضًا).

**ما درجة أمان الخيوط لعملية الدمج؟**

لا تستخدم نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). القاعدة الموصى بها هي "مستند واحد — خيط واحد"; يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.