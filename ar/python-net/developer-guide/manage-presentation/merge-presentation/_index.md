---
title: دمج العروض التقديمية بكفاءة باستخدام Python
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
description: "دمج عروض PowerPoint (PPT، PPTX) و OpenDocument (ODP) بسهولة باستخدام Aspose.Slides للـ Python عبر .NET، مما يبسط سير عملك."
---

## **تحسين دمج العروض التقديمية**

مع [Aspose.Slides للـ Python](https://products.aspose.com/slides/python-net/)، يمكنك دمج عروض PowerPoint بسلاسة مع الحفاظ على الأنماط والتخطيطات وجميع العناصر. على عكس الأدوات الأخرى، تقوم Aspose.Slides بدمج العروض دون التضحية بالجودة أو فقدان البيانات. يمكنك دمج مجموعات الشرائح بالكامل، أو شرائح محددة، أو حتى صيغ ملفات مختلفة (مثل PPT إلى PPTX).

### **ميزات الدمج**

- **دمج العرض الكامل:** تجميع جميع الشرائح في ملف واحد.
- **دمج شرائح محددة:** اختيار ودمج الشرائح المختارة.
- **دمج عبر الصيغ:** دمج عروض بصيغ مختلفة مع الحفاظ على سلامتها.

## **دمج العروض التقديمية**

عند دمج عرض تقديمي في آخر، فإنك فعليًا تجمع شرائحه في عرض واحد لتنتج ملفًا موحدًا. معظم برامج العروض—مثل PowerPoint أو OpenOffice—لا توفر ميزات تسمح بدمج العروض بهذه الطريقة.

ومع ذلك، يتيح لك [Aspose.Slides للـ Python](https://products.aspose.com/slides/python-net/) دمج العروض بطرق متعددة. يمكنك دمج العروض مع جميع الأشكال والأنماط والنصوص والتنسيقات والتعليقات والرسوم المتحركة دون أي فقدان للجودة أو البيانات.

**انظر أيضًا**

[استنساخ شرائح PowerPoint في Python](/slides/ar/python-net/clone-slides/)

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج:

- العروض الكاملة: جميع الشرائح من مجموعات المصدر تُدمج في عرض تقديمي واحد.
- شرائح محددة: تُدمج الشرائح المختارة فقط في عرض تقديمي واحد.
- عروض بنفس الصيغة (مثل PPT→PPT، PPTX→PPTX) أو عبر صيغ مختلفة (مثل PPT→PPTX، PPTX→ODP).

{{% alert title="ملاحظة" color="info" %}}

إلى جانب العروض التقديمية، يتيح Aspose.Slides أيضًا دمج ملفات أخرى:

- [الصور](https://products.aspose.com/slides/python-net/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).
- المستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).
- نوعان مختلفان من الملفات، مثل [صورة إلى PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/)، [JPG إلى PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/)، أو [TIFF إلى PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك التحكم فيما إذا:
- احتفظ كل شريحة في العرض الناتج بنمطها الأصلي، أو
- يُطبق نمط موحد على جميع الشرائح في العرض الناتج.

لدمج العروض، توفر Aspose.Slides طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) على فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/). تحدد هذه التحميلات المفرطة كيفية تنفيذ الدمج. كل كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يُظهر مجموعة [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)، لذا تستدعي `add_clone` على مجموعة شرائح العرض الوجهة.

ترجع طريقة `add_clone` كائن `Slide`—نسخة مستنسخة من الشريحة المصدر. الشرائح في العرض الناتج هي نسخ من الأصل، لذا يمكنك تعديل الشرائح الناتجة (مثل تطبيق الأنماط أو التنسيقات أو التخطيطات) دون التأثير على العروض المصدر.

## **دمج العروض التقديمية**

توفر Aspose.Slides طريقة [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) التي تسمح بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (باستخدام المعلمات الافتراضية).

المثال التالي بلغة Python يوضح كيفية دمج العروض:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **دمج العروض مع شريحة رئيسية (Slide Master)**

توفر Aspose.Slides طريقة [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) التي تسمح بدمج الشرائح مع تطبيق شريحة رئيسية من قالب. بهذه الطريقة، عند الحاجة، يمكنك إعادة تنسيق الشرائح في العرض الناتج.

المثال التالي بلغة Python يوضح هذه العملية:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="تحذير" color="warning" %}}

يتم تحديد التخطيط المناسب تحت الشريحة الرئيسية المحددة تلقائيًا. إذا لم يُعثر على تخطيط مناسب وكان معامل `allow_clone_missing_layout` من نوع Boolean في طريقة `add_clone` مُعينًا إلى `True`، يُستخدم تخطيط الشريحة المصدر بدلًا منه. وإلا، يُطرح استثناء [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).

{{% /alert %}}

لتطبيق تخطيط شريحة مختلف على الشرائح في العرض الناتج، استخدم طريقة [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) عند الدمج.

## **دمج شرائح محددة من العروض**

دمج شرائح محددة من عدة عروض مفيد عند إنشاء مجموعات شرائح مخصصة. يتيح لك Aspose.Slides اختيار واستيراد الشرائح التي تحتاجها فقط، مع الحفاظ على تنسيق وشكل وتصميم الشرائح الأصلية.

المثال التالي بلغة Python ينشئ عرضًا تقديميًا جديدًا، ويضيف شرائح عنوان من عرضين آخرين، ثم يحفظ النتيجة في ملف:

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

## **دمج العروض مع تخطيط شريحة محدد**

المثال التالي بلغة Python يوضح كيفية دمج شرائح من عروض متعددة مع تطبيق تخطيط شريحة محدد لإنتاج عرض تقديمي واحد:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **دمج العروض بأحجام شرائح مختلفة**

{{% alert title="تحذير" color="warning" %}}

لا يمكنك دمج عروض مباشرةً إذا كان لديها أحجام شرائح مختلفة.

{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، قم أولاً بتغيير حجم أحد العروض لتتطابق حجم شريحته مع الآخر.

الكود التالي يوضح العملية:

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

## **دمج الشرائح في قسم من العرض**

المثال التالي بلغة Python يوضح كيفية دمج شريحة محددة في قسم من عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

تُضاف الشريحة في نهاية القسم. 

{{% alert title="نصيحة" color="primary" %}}

تبحث عن أداة **مجانية عبر الإنترنت** لدمج عروض PowerPoint؟ جرّب [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **دمج ملفات PowerPoint بسهولة**: دمج عدة عروض **PPT، PPTX، ODP** في ملف واحد.  
- **دعم صيغ مختلفة**: دمج **PPT إلى PPTX**، **PPTX إلى ODP**، وغيرها.  
- **بدون تثبيت**: يعمل مباشرة في متصفحك، سريع وآمن.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

ابدأ بدمج ملفات PowerPoint باستخدام أداة Aspose المجانية عبر الإنترنت اليوم!  

{{% /alert %}}

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيق ويب **مجاني** لإنشاء كولاجات ([FREE Collage web app](https://products.aspose.app/slides/collage)). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وغيرها. 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يتم الحفاظ على ملاحظات المتحدث أثناء الدمج؟**

نعم. عند استنساخ الشرائح، تقوم Aspose.Slides بنقل جميع عناصر الشريحة، بما في ذلك الملاحظات، والتنسيقات، والرسوم المتحركة.

**هل يتم نقل التعليقات ومؤلفيها؟**

التعليقات، كجزء من محتوى الشريحة، تُنسخ مع الشريحة. تُحافظ تسميات مؤلفي التعليقات ككائنات تعليق في العرض الناتج.

**ماذا لو كان العرض المصدر محميًا بكلمة سر؟**

يجب [فتح العرض باستخدام كلمة السر](/slides/ar/python-net/password-protected-presentation/) عبر [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); بعد التحميل، يمكن استنساخ تلك الشرائح بأمان إلى ملف هدف غير محمي (أو محمي أيضًا).

**ما مدى أمان عملية الدمج من حيث التزامن؟**

لا تستخدم نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). القاعدة الموصى بها هي "مستند واحد — خيط واحد"; يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.