---
title: دمج العروض التقديمية بكفاءة باستخدام Python
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/python-net/merge-presentation/
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
- Python
- Aspose.Slides
description: "قم بدمج عروض PowerPoint (PPT, PPTX) و OpenDocument (ODP) بسهولة باستخدام Aspose.Slides للبايثون عبر .NET، مما يُبسّط سير عملك."
---

## **تحسين دمج العروض التقديمية**

مع [Aspose.Slides للبايثون](https://products.aspose.com/slides/python-net/)، يمكنك دمج عروض PowerPoint بسلاسة مع الحفاظ على الأنماط والتخطيطات وجميع العناصر. على عكس الأدوات الأخرى، يدمج Aspose.Slides العروض دون التضحية بالجودة أو فقدان البيانات. دمج مجموعات كاملة، شرائح محددة، أو حتى صيغ ملفات مختلفة (مثل PPT إلى PPTX).

### **ميزات الدمج**

- **دمج كامل للعرض:** تجميع جميع الشرائح في ملف واحد.
- **دمج شرائح محددة:** اختيار ودمج الشرائح المختارة.
- **دمج عبر الصيغ:** دمج عروض بصيغ مختلفة مع الحفاظ على سلامتها.

## **دمج العروض التقديمية**

عند دمج عرض توضيحي في آخر، تقوم فعليًا بدمج الشرائح في عرض واحد لتنتج ملفًا موحدًا. معظم برامج العروض—مثل PowerPoint أو OpenOffice—لا توفر ميزات تسمح بدمج العروض بهذه الطريقة.

ومع ذلك، يتيح لك [Aspose.Slides للبايثون](https://products.aspose.com/slides/python-net/) دمج العروض بطرق متعددة. يمكنك دمج العروض مع جميع الأشكال والأنماط والنصوص والتنسيقات والتعليقات والرسوم المتحركة، دون أي فقدان للجودة أو البيانات.

**انظر أيضًا**

[استنساخ شرائح PowerPoint في بايثون](/slides/ar/python-net/clone-slides/)

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج:

- العروض الكاملة: جميع الشرائح من مجموعة المصدر تُدمج في عرض واحد.
- الشرائح المحددة: تُدمج الشرائح المختارة فقط في عرض واحد.
- العروض ذات الصيغة نفسها (مثل PPT→PPT، PPTX→PPTX) أو عبر صيغ مختلفة (مثل PPT→PPTX، PPTX→ODP).

{{% alert title="Note" color="info" %}}
إلى جانب العروض، يتيح Aspose.Slides أيضًا دمج ملفات أخرى:

- [الصور](https://products.aspose.com/slides/python-net/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).
- المستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).
- نوعين مختلفين من الملفات، مثل [صورة إلى PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/)، [JPG إلى PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/)، أو [TIFF إلى PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).
{{% /alert %}}

### **خيارات الدمج**

يمكنك التحكم فيما إذا:
- احتفظ كل شريحة في العرض الناتج بنمطها الأصلي، أو
- يتم تطبيق نمط واحد على جميع الشرائح في العرض الناتج.

لدمج العروض، توفر Aspose.Slides طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) على فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/). تُعرِّف هذه التحميلات طريقة تنفيذ الدمج. كل كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يحتوي على مجموعة [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)، لذا تستدعي `add_clone` على مجموعة شرائح العرض الوجهة.

ترجع طريقة `add_clone` كائن `Slide`—نسخة متماثلة من الشريحة الأصلية. الشرائح في العرض الناتج هي نسخ من الأصل، وبالتالي يمكنك تعديل الشرائح الناتجة (مثلاً، تطبيق الأنماط أو التنسيقات أو التخطيطات) دون التأثير على العروض المصدر.

## **دمج العروض**

توفر Aspose.Slides طريقة [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) التي تسمح بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (باستخدام المعلمات الافتراضية).

يُظهر المثال التالي بلغة Python كيفية دمج العروض:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```


## **دمج العروض مع القالب الرئيسي للشرائح**

توفر Aspose.Slides طريقة [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) التي تسمح بدمج الشرائح مع تطبيق قالب رئيسي من نموذج. بهذه الطريقة، يمكنك تعديل نمط الشرائح في العرض الناتج حسب الحاجة.

يوضح المثال التالي بلغة Python هذه العملية:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```


{{% alert title="Note" color="warning" %}}
يُحدد التخطيط المناسب تحت القالب الرئيسي المحدد تلقائيًا. إذا تعذر العثور على تخطيط مناسب وتم تعيين المتغيّر البولياني `allow_clone_missing_layout` في طريقة `add_clone` إلى `True`، يُستخدم تخطيط الشريحة المصدر بدلًا من ذلك. وإلا، يُطلق استثناء [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

لتطبيق تخطيط شريحة مختلف على الشرائح في العرض الناتج، استخدم طريقة [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) عند الدمج.

## **دمج شرائح محددة من العروض**

يعد دمج شرائح محددة من عروض متعددة مفيدًا عند إنشاء مجموعات شرائح مخصصة. يتيح لك Aspose.Slides اختيار واستيراد الشرائح التي تحتاجها فقط، مع الحفاظ على تنسيق وتصميم وتخطيط الشرائح الأصلية.

ينشئ المثال التالي بلغة Python عرضًا جديدًا، يضيف شرائح عنوان من عرضين آخرين، ويحفظ النتيجة في ملف:
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


## **دمج العروض مع تخطيط شريحة**

يوضح المثال التالي بلغة Python كيفية دمج شرائح من عروض متعددة مع تطبيق تخطيط شريحة محدد لإنتاج عرض واحد موحد:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```


## **دمج العروض بأحجام شرائح مختلفة**

{{% alert title="Note" color="warning" %}}
لا يمكنك دمج العروض التي تحتوي على أحجام شرائح مختلفة مباشرة.
{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، قم أولًا بتغيير حجم أحد العروض بحيث يتطابق حجم شريحته مع الآخر.

يوضح الكود التالي هذه العملية:
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

يوضح المثال التالي بلغة Python كيفية دمج شريحة محددة في قسم من العرض:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```


تُضاف الشريحة في نهاية القسم.

{{% alert title="Tip" color="primary" %}}
هل تبحث عن أداة **مجانية على الإنترنت** لدمج عروض PowerPoint؟ جرّب [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **دمج ملفات PowerPoint بسهولة**: دمج عروض **PPT، PPTX، ODP** متعددة في ملف واحد.  
- **دعم صيغ مختلفة**: دمج **PPT إلى PPTX**، **PPTX إلى ODP**، وأكثر.  
- **بدون تثبيت**: يعمل مباشرة في المتصفح، سريع وآمن.  

[![دمج ملفات PowerPoint على الإنترنت](slides-merger.png)](https://products.aspose.app/slides/merger)  

ابدأ دمج ملفات PowerPoint باستخدام أداة Aspose المجانية على الإنترنت اليوم!  
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
توفر Aspose تطبيقًا ويب **مجانيًا** لإنشاء كولاج [هنا](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid) وغيرها. 
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تُحفظ ملاحظات المتحدثين أثناء الدمج؟**

نعم. عند استنساخ الشرائح، تنقل Aspose.Slides جميع عناصر الشريحة، بما في ذلك الملاحظات، والتنسيقات، والرسوم المتحركة.

**هل تُنقل التعليقات ومؤلفوها؟**

تُنسخ التعليقات كجزء من محتوى الشريحة وتُحافظ على تسميات مؤلفي التعليق ككائنات تعليق في العرض الناتج.

**ماذا لو كان العرض المصدر محميًا بكلمة مرور؟**

يجب [فتح العرض باستخدام كلمة المرور](/slides/ar/python-net/password-protected-presentation/) عبر [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/). بعد التحميل، يمكن استنساخ تلك الشرائح بأمان إلى ملف هدف غير محمي (أو محمي أيضًا).

**ما مدى أمان العملية من حيث تعدد الخيوط؟**

لا تستخدم نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). القاعدة الموصى بها هي "وثيقة واحدة — خيط واحد"؛ يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.