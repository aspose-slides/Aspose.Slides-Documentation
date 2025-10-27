---
title: دمج العروض التقديمية بكفاءة باستخدام بايثون
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/python-net/merge-presentation/
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
description: "دمج عروض PowerPoint (PPT، PPTX) وعروض OpenDocument (ODP) بسهولة باستخدام Aspose.Slides لبايثون عبر .NET، مما يبسط سير العمل الخاص بك."
---

## **حسّن دمج العروض التقديمية الخاصة بك**

مع [Aspose.Slides لبايثون](https://products.aspose.com/slides/python-net/)، يمكنك دمج عروض PowerPoint بسلاسة مع الحفاظ على الأنماط والتخطيطات وكل العناصر. على عكس الأدوات الأخرى، يقوم Aspose.Slides بدمج العروض دون المساس بالجودة أو فقدان البيانات. دمج مجموعات الشرائح بالكامل، أو شرائح معينة، أو حتى صيغ ملفات مختلفة (مثل PPT إلى PPTX).

### **ميزات الدمج**

- **دمج العرض الكامل:** تجميع جميع الشرائح في ملف واحد.
- **دمج شرائح محددة:** اختيار ودمج الشرائح المحددة.
- **دمج عبر الصيغ:** دمج عروض مختلفة الصيغ مع الحفاظ على سلامتها.

## **دمج العروض التقديمية**

عند دمج عرض تقديمي في آخر، فإنك في الواقع تجمع شرائحه في عرض واحد لإنتاج ملف موحّد. معظم برامج العروض—مثل PowerPoint أو OpenOffice—لا توفر ميزات تسمح بدمج العروض بهذه الطريقة.

مع ذلك، يتيح لك [Aspose.Slides لبايثون](https://products.aspose.com/slides/python-net/) دمج العروض بطرق متعددة. يمكنك دمج العروض مع جميع الأشكال، الأنماط، النصوص، التنسيقات، التعليقات، والرسوم المتحركة، دون أي فقدان للجودة أو البيانات.

**انظر أيضًا**

[استنساخ شرائح PowerPoint في بايثون](/slides/ar/python-net/clone-slides/)

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج:

- العروض الكاملة: جميع الشرائح من مجموعات المصدر تُدمج في عرض واحد.
- شرائح محددة: الشرائح المختارة فقط تُدمج في عرض واحد.
- عروض بنفس الصيغة (مثل PPT→PPT، PPTX→PPTX) أو عبر صيغ مختلفة (مثل PPT→PPTX، PPTX→ODP).

{{% alert title="ملاحظة" color="info" %}}

إلى جانب العروض، يتيح لك Aspose.Slides دمج ملفات أخرى:

- [الصور](https://products.aspose.com/slides/python-net/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).
- المستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).
- نوعين مختلفين من الملفات، مثل [صورة إلى PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/)، [JPG إلى PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/)، أو [TIFF إلى PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك التحكم فيما إذا:
- احتفظ كل شريحة في العرض الناتج بنمطها الأصلي، أو
- يُطبق نمط موحَّد على جميع الشرائح في العرض الناتج.

لدمج العروض، يوفر Aspose.Slides طرق `[add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/)` على فئة `[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)`. تُحدِّد هذه التحميلات كيفية تنفيذ الدمج. كل كائن `[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)` يُظهر مجموعة `[slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)`، لذا تستدعي `add_clone` على مجموعة شرائح العرض الهدف.

تعيد طريقة `add_clone` كائن `Slide`—نسخة من الشريحة المصدر. الشرائح في العرض الناتج هي نسخ من الأصل، لذا يمكنك تعديل الشرائح الناتجة (مثل تطبيق الأنماط أو التنسيقات أو التخطيطات) دون التأثير على العروض المصدر.

## **دمج العروض التقديمية**

يوفر Aspose.Slides طريقة `[add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide)` التي تسمح بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (باستخدام المعلمات الافتراضية).

المثال التالي بايثون يوضح كيفية دمج العروض:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **دمج العروض مع شريحة ماستر**

يوفر Aspose.Slides طريقة `[add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool)` التي تسمح بدمج الشرائح مع تطبيق شريحة ماستر من قالب. بهذه الطريقة، يمكنك تعديل نمط الشرائح في العرض الناتج عند الحاجة.

المثال التالي بايثون يُظهر هذه العملية:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="ملاحظة" color="warning" %}}

يتم تحديد التخطيط المناسب تحت شريحة الماستر المحددة تلقائيًا. إذا لم يُعثر على تخطيط مناسب وتم تعيين معامل `allow_clone_missing_layout` المنطقي في طريقة `add_clone` إلى `True`، فسيُستخدم تخطيط الشريحة المصدر بدلاً من ذلك. وإلا، سيتم إلقاء [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).

{{% /alert %}}

لتطبيق تخطيط شريحة مختلف على الشرائح في العرض الناتج، استخدم طريقة `[add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide)` أثناء الدمج.

## **دمج شرائح محددة من العروض**

يُعد دمج شرائح محددة من عدة عروض مفيدًا عند إنشاء مجموعات شرائح مخصَّصة. يتيح لك Aspose.Slides اختيار واستيراد الشرائح التي تحتاجها فقط، مع الحفاظ على تنسيق وتخطيط وتصميم الشرائح الأصلية.

المثال التالي بايثون ينشئ عرضًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة في ملف:

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

المثال التالي بايثون يُظهر كيفية دمج الشرائح من عدة عروض مع تطبيق تخطيط شريحة محدد لإنتاج عرض موحَّد:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **دمج العروض بأحجام شرائح مختلفة**

{{% alert title="ملاحظة" color="warning" %}}

لا يمكن دمج العروض التي لها أحجام شرائح مختلفة مباشرةً.

{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، قم أولاً بتغيير حجم أحد العروض لتطابق حجم الشرائح للآخر.

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

المثال التالي بايثون يُظهر كيفية دمج شريحة محددة في قسم من العرض:

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

تبحث عن أداة **مجانًا عبر الإنترنت** لدمج عروض PowerPoint؟ جرّب [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **دمج ملفات PowerPoint بسهولة**: دمج عدة عروض **PPT، PPTX، ODP** في ملف واحد.  
- **دعم صيغ مختلفة**: دمج **PPT إلى PPTX**، **PPTX إلى ODP**، وأكثر.  
- **بدون تثبيت**: يعمل مباشرةً في المتصفح، سريع وآمن.  

[![دمج ملفات PowerPoint عبر الإنترنت](slides-merger.png)](https://products.aspose.app/slides/merger)  

ابدأ دمج ملفات PowerPoint باستخدام **أداة Aspose المجانية عبر الإنترنت** اليوم!  

{{% /alert %}}

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيق ويب **مجاني لتجميع الصور** ([FREE Collage](https://products.aspose.app/slides/collage)). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid) وغيرها. 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل تُحفظ ملاحظات المتحدث أثناء الدمج؟**

نعم. عند استنساخ الشرائح، ينقل Aspose.Slides جميع عناصر الشريحة بما في ذلك الملاحظات والتنسيقات والرسوم المتحركة.

**هل تُنقل التعليقات ومؤلفوها؟**

التعليقات، كجزء من محتوى الشريحة، تُنسخ مع الشريحة. تُحفظ تسميات مؤلفي التعليقات ككائنات تعليق في العرض الناتج.

**ماذا لو كان العرض المصدر محميًا بكلمة مرور؟**

يجب [فتح العرض باستخدام كلمة المرور](/slides/ar/python-net/password-protected-presentation/) عبر [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); بعد التحميل، يمكن استنساخ تلك الشرائح بأمان إلى ملف هدف غير محمي (أو محمي أيضًا).

**ما مدى أمان عملية الدمج من الناحية المتزامنة؟**

لا تقم باستخدام نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). القاعدة الموصى بها هي "مستند واحد — خيط واحد"; يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.