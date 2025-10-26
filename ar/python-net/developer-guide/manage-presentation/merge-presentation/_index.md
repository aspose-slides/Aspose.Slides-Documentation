---
title: دمج العروض التقديمية بفعالية باستخدام بايثون
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/python-net/developer-guide/manage-presentation/merge-presentation/
keywords:
- merge PowerPoint
- merge presentations
- merge slides
- merge PPT
- merge PPTX
- merge ODP
- combine PowerPoint
- combine presentations
- combine slides
- combine PPT
- combine PPTX
- combine ODP
- Python
- Aspose.Slides
description: "دمج عروض PowerPoint (PPT, PPTX) وOpenDocument (ODP) بسهولة باستخدام Aspose.Slides for Python عبر .NET، مما يبسط سير عملك."
---

## **تحسين دمج العروض التقديمية**

مع [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/)، يمكنك دمج عروض PowerPoint بسلاسة مع الحفاظ على الأنماط والتخطيطات وجميع العناصر. على عكس الأدوات الأخرى، يقوم Aspose.Slides بدمج العروض دون التأثير على الجودة أو فقدان البيانات. دمج مجموعات الشرائح بالكامل، شرائح محددة، أو حتى صيغ ملفات مختلفة (مثلاً، PPT إلى PPTX).

### **ميزات الدمج**

- **دمج كامل للعرض:** تجميع جميع الشرائح في ملف واحد.
- **دمج شرائح محددة:** اختيار ودمج الشرائح المختارة.
- **دمج عبر صيغ مختلفة:** دمج عروض بصيغ متعددة مع الحفاظ على完整ية البيانات.

## **دمج العروض التقديمية**

عندما تقوم بدمج عرض تقديمي في آخر، فإنك فعليًا تجمع شرائحه في عرض واحد لإنتاج ملف موحّد. معظم برامج العروض—مثل PowerPoint أو OpenOffice—لا توفر ميزات تسمح بدمج العروض بهذه الطريقة.

ومع ذلك، يتيح لك [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) دمج العروض بطرق مختلفة. يمكنك دمج العروض مع جميع الأشكال، الأنماط، النصوص، التنسيقات، التعليقات، والرسوم المتحركة، دون أي فقدان للجودة أو البيانات.

**انظر أيضًا**

[استنساخ شرائح PowerPoint في بايثون](/slides/ar/python-net/clone-slides/)

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج:

- العروض بالكامل: جميع الشرائح من مجموعات المصدر تُدمج في عرض موحّد.
- شرائح محددة: يتم دمج الشرائح المختارة فقط في عرض موحّد.
- عروض بنفس الصيغة (مثل PPT→PPT، PPTX→PPTX) أو عبر صيغ مختلفة (مثل PPT→PPTX، PPTX→ODP).

{{% alert title="ملاحظة" color="info" %}}

بالإضافة إلى العروض، يتيح لك Aspose.Slides دمج ملفات أخرى:

- [صور](https://products.aspose.com/slides/python-net/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).
- مستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).
- نوعين مختلفين من الملفات، مثل [صورة إلى PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/)، [JPG إلى PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/)، أو [TIFF إلى PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك التحكم فيما إذا:

- احتفظ كل شريحة في العرض الناتج بأسلوبها الأصلي، أو
- يُطبَّق أسلوب موحّد على جميع الشرائح في العرض الناتج.

للدمج، توفر Aspose.Slides طريقة **add_clone** على فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/). تُعرِّف هذه التحميلات طريقة تنفيذ الدمج. كل كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يحتوي على مجموعة [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)، لذا تستدعي `add_clone` على مجموعة شرائح العرض الوجهة.

تُعيد طريقة `add_clone` كائن `Slide`—نسخة من الشريحة المصدر. الشرائح في العرض الناتج هي نسخ من الأصل، لذا يمكنك تعديل الشرائح الناتجة (مثلاً، تطبيق أنماط أو تنسيقات أو تخطيطات) دون التأثير على العروض المصدر.

## **دمج العروض التقديمية**

توفر Aspose.Slides طريقة [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) التي تسمح بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (باستخدام المعاملات الافتراضية).

المثال التالي بلغة بايثون يوضح كيفية دمج العروض:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **دمج العروض مع القالب الرئيسي للشرائح**

توفر Aspose.Slides طريقة [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) التي تسمح بدمج الشرائح مع تطبيق قالب رئيسي من نموذج. بهذه الطريقة، يمكنك إعادة تنسيق الشرائح في العرض الناتج عند الحاجة.

المثال التالي يوضح العملية:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="تحذير" color="warning" %}}

يتم تحديد التخطيط المناسب تحت القالب الرئيسي المحدد تلقائيًا. إذا لم يُعثر على تخطيط مناسب وتم تعيين المعامل `allow_clone_missing_layout` إلى `True`، يُستخدم تخطيط الشريحة المصدر. وإلا يُثار استثناء [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).

{{% /alert %}}

لتطبيق تخطيط شريحة مختلف على الشرائح في العرض الناتج، استخدم طريقة [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) أثناء الدمج.

## **دمج شرائح محددة من العروض**

يُعد دمج شرائح محددة من عروض متعددة مفيدًا عند إنشاء مجموعة شرائح مخصصة. يتيح لك Aspose.Slides اختيار واستيراد الشرائح التي تحتاجها فقط، مع الحفاظ على تنسيقها وتخطيطها وتصميمها الأصلي.

المثال التالي بلغة بايثون يُنشئ عرضًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة في ملف:

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

المثال التالي يوضح كيفية دمج الشرائح من عدة عروض مع تطبيق تخطيط شريحة معين لإنتاج عرض موحَّد:

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

لا يمكن دمج العروض ذات أحجام الشرائح المختلفة مباشرة.

{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، قم أولاً بتغيير حجم أحد العروض لتتطابق أبعاد الشرائح مع الآخر.

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

## **دمج شرائح في قسم من العرض**

المثال التالي يوضح دمج شريحة معينة في قسم من العرض:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

يُضاف الشريحة في نهاية القسم.

{{% alert title="نصيحة" color="primary" %}}

تبحث عن أداة مجانية على الإنترنت لدمج عروض PowerPoint؟ جرب [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **دمج ملفات PowerPoint بسهولة**: دمج عدة عروض **PPT, PPTX, ODP** في ملف واحد.  
- **دعم صيغ مختلفة**: دمج **PPT إلى PPTX**، **PPTX إلى ODP**، وغيرها.  
- **لا تحتاج لتثبيت**: يعمل مباشرة في المتصفح، سريع وآمن.  

[![دمج ملفات PowerPoint على الإنترنت](slides-merger.png)](https://products.aspose.app/slides/merger)  

ابدأ دمج ملفات PowerPoint الآن باستخدام أداة Aspose المجانية على الإنترنت!  

{{% /alert %}}

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيقًا ويبياً **مجانيًا** لإنشاء الكولاجات عبر [هذا الرابط](https://products.aspose.app/slides/collage). يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وغيرها. 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يتم الاحتفاظ بملاحظات المتحدث أثناء الدمج؟**

نعم. عند استنساخ الشرائح، تنقل Aspose.Slides جميع عناصر الشريحة بما فيها الملاحظات، التنسيقات، والرسوم المتحركة.

**هل تُنقل التعليقات ومؤلفوها؟**

تُنسخ التعليقات كجزء من محتوى الشريحة، وتُحافظ على تسميات مؤلفي التعليق ككائنات في العرض الناتج.

**ماذا إذا كان العرض المصدر محميًا بكلمة مرور؟**

يجب [فتح الملف باستخدام كلمة المرور](/slides/ar/python-net/password-protected-presentation/) عبر الخاصية [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); بعد التحميل يمكن استنساخ الشرائح بأمان إلى ملف غير محمي (أو محمي أيضًا).

**ما مدى أمان العملية في بيئات متعددة الخيوط؟**

تجنب استخدام نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). القاعدة المُوصى بها هي "مستند واحد — خيط واحد"؛ يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.