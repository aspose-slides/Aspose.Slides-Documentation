---
title: دمج العروض التقديمية بفعالية باستخدام بايثون
linktitle: دمج العروض
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
- بايثون
- Aspose.Slides
description: "دمج عروض PowerPoint (PPT، PPTX) وعروض OpenDocument (ODP) بسهولة مع Aspose.Slides للبايثون عبر .NET، مما يُسهل سير عملك."
---

## **تحسين دمج العروض التقديمية**

مع [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/)، يمكنك دمج عروض PowerPoint بسلاسة مع الحفاظ على الأنماط والتخطيط وجميع العناصر. على عكس الأدوات الأخرى، يقوم Aspose.Slides بدمج العروض دون التضحية بالجودة أو فقدان البيانات. ادمج مجموعات كاملة، شرائح محددة، أو حتى صيغ ملفات مختلفة (مثل PPT إلى PPTX).

### **ميزات الدمج**

- **Full Presentation Merge:** تجميع جميع الشرائح في ملف واحد.  
- **Specific Slide Merge:** اختيار ودمج الشرائح المحددة.  
- **Cross-Format Merge:** دمج العروض بأشكال مختلفة مع الحفاظ على السلامة.

## **دمج العروض التقديمية**

عند دمج عرض تقديمي مع آخر، تقوم فعليًا بدمج شرائحه في عرض تقديمي واحد لإنتاج ملف واحد. معظم برامج العروض التقديمية — مثل PowerPoint أو OpenOffice — لا توفر ميزات تسمح بدمج العروض بهذه الطريقة.

ومع ذلك، يتيح [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) دمج العروض بطرق متعددة. يمكنك دمج العروض مع جميع الأشكال والأنماط والنص والتنسيق والتعليقات والرسوم المتحركة، دون أي فقدان في الجودة أو البيانات.

**انظر أيضًا**  
[استنساخ شرائح PowerPoint في Python](/slides/ar/python-net/clone-slides/)

### **ما الذي يمكن دمجه**

مع Aspose.Slides، يمكنك دمج:

- العروض الكاملة: جميع الشرائح من مجموعة المصادر تُدمج في عرض تقديمي واحد.  
- شرائح محددة: فقط الشرائح المختارة تُدمج في عرض تقديمي واحد.  
- العروض بنفس الصيغة (مثل PPT→PPT، PPTX→PPTX) أو عبر صيغ مختلفة (مثل PPT→PPTX، PPTX→ODP).

### **خيارات الدمج**

يمكنك التحكم فيما إذا كان:
- كل شريحة في العرض الناتج تحتفظ بالنمط الأصلي لها، أو
- يُطبق نمط موحد على جميع الشرائح في العرض الناتج.

لدمج العروض، يوفر Aspose.Slides طرق [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) على فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/). تُحدد هذه التحميلات الزائدة كيفية تنفيذ الدمج. كل كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يعرض مجموعة [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)، لذا تقوم باستدعاء `add_clone` على مجموعة شرائح العرض الهدف.

طريقة `add_clone` تُعيد كائن `Slide` — نسخة من الشريحة المصدر. الشرائح في العرض الناتج هي نسخ من الأصل، لذا يمكنك تعديل الشرائح الناتجة (مثلاً، تطبيق الأنماط أو التنسيق أو التخطيطات) دون التأثير على العروض المصدر.

## **دمج العروض**

يوفر Aspose.Slides طريقة [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) التي تسمح بدمج الشرائح مع الحفاظ على تخطيطاتها وأنماطها (باستخدام المعلمات الافتراضية).

يُظهر المثال التالي بلغة Python كيفية دمج العروض:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```


## **دمج العروض باستخدام رئيس شرائح**

يوفر Aspose.Slides طريقة [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) التي تسمح بدمج الشرائح مع تطبيق رئيس شريحة من نموذج. بهذه الطريقة، عند الحاجة، يمكنك إعادة تنسيق الشرائح في العرض الناتج.

يُظهر المثال التالي بلغة Python هذه العملية:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```


{{% alert title="Note" color="warning" %}}
يتم تحديد التخطيط المناسب تحت رئيس الشريحة المحدد تلقائيًا. إذا تعذر العثور على تخطيط مناسب وتم تعيين معلمة `allow_clone_missing_layout` البوليانية في طريقة `add_clone` إلى `True`، يتم استخدام تخطيط الشريحة المصدر بدلاً من ذلك. وإلا، يتم إطلاق استثناء [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).  
{{% /alert %}}

لتطبيق تخطيط شريحة مختلف على الشرائح في العرض الناتج، استخدم طريقة [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) عند الدمج.

## **دمج شرائح محددة من العروض**

يعد دمج شرائح محددة من عدة عروض مفيدًا عند إنشاء مجموعات شرائح مخصصة. يتيح لك Aspose.Slides اختيار واستيراد الشرائح التي تحتاجها فقط، مع الحفاظ على تنسيق وتخطيط وتصميم الشرائح الأصلية.

يُظهر المثال التالي بلغة Python إنشاء عرض تقديمي جديد، إضافة شرائح عنوان من عرضين آخرين، وحفظ النتيجة في ملف:
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


## **دمج العروض باستخدام تخطيط شريحة**

يُظهر المثال التالي بلغة Python كيفية دمج الشرائح من عدة عروض مع تطبيق تخطيط شريحة محدد لإنتاج عرض تقديمي واحد ناتج:
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
لا يمكنك دمج العروض التي لها أحجام شرائح مختلفة مباشرة.  
{{% /alert %}}

لدمج عرضين بأحجام شرائح مختلفة، يجب أولاً تعديل حجم أحد العروض بحيث يتطابق حجم شريحته مع الآخر.

يُظهر الكود التالي هذه العملية:
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

يُظهر المثال التالي بلغة Python كيفية دمج شريحة محددة في قسم من عرض تقديمي:
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
هل تبحث عن أداة سريعة **مجانية عبر الإنترنت** ل**دمج عروض PowerPoint**؟ جرّب [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **دمج ملفات PowerPoint بسهولة**: دمج عدة عروض **PPT, PPTX, ODP** في ملف واحد.  
- **يدعم صيغًا مختلفة**: دمج **PPT إلى PPTX**، **PPTX إلى ODP**، وأكثر.  
- **لا يلزم تثبيت**: يعمل مباشرة في المتصفح، سريع وآمن.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

ابدأ دمج ملفات PowerPoint باستخدام **أداة Aspose المجانية عبر الإنترنت** اليوم!  
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
تقدم Aspose تطبيق [Collage ويب FREE](https://products.aspose.app/slides/collage) مجانًا. باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.  
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يتم حفظ ملاحظات المتحدث أثناء الدمج؟**  
نعم. عند استنساخ الشرائح، يقوم Aspose.Slides بنقل جميع عناصر الشريحة، بما في ذلك الملاحظات والتنسيق والرسوم المتحركة.

**هل يتم نقل التعليقات ومؤلفوها؟**  
التعليقات، كجزء من محتوى الشريحة، تُنسخ مع الشريحة. تُحافظ على تسميات مؤلفي التعليقات ككائنات تعليق في العرض الناتج.

**ماذا لو كان العرض المصدر محميًا بكلمة مرور؟**  
يجب [فتحها باستخدام كلمة المرور](/slides/ar/python-net/password-protected-presentation/) عبر [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); بعد التحميل، يمكن استنساخ تلك الشرائح بأمان إلى ملف هدف غير محمي (أو محمي أيضًا).

**ما مدى أمان الخيوط لعملية الدمج؟**  
لا تُستخدم نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). القاعدة الموصى بها هي "مستند واحد — خيط واحد"؛ يمكن معالجة ملفات مختلفة بالتوازي في خيوط منفصلة.