---
title: دمج العرض التقديمي
type: docs
weight: 40
url: /ar/python-net/merge-presentation/
keywords: "دمج PowerPoint، PPTX، PPT، دمج PowerPoint، دمج العرض التقديمي، دمج العرض، بايثون"
description: "دمج أو الجمع بين عرض PowerPoint التقديمي في بايثون"
---

{{% alert  title="نصيحة" color="primary" %}} 

قد ترغب في الاطلاع على **تطبيق Aspose المجاني عبر الإنترنت** [Merger app](https://products.aspose.app/slides/merger). يسمح للأشخاص بدمج العروض التقديمية PowerPoint بنفس التنسيق (PPT إلى PPT، PPTX إلى PPTX، إلخ) ودمج العروض التقديمية بتنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عند دمج عرض تقديمي واحد بآخر، فإنك بشكل فعال تجمع بين شرائحهم في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="معلومات" color="info" %}}

تفتقر معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) إلى وظائف تسمح للمستخدمين بدمج العروض التقديمية بهذه الطريقة. 

ومع ذلك، يسمح لك [**Aspose.Slides لبايثون عبر .NET**](https://products.aspose.com/slides/python-net/) بدمج العروض التقديمية بطرق مختلفة. يمكنك دمج العروض التقديمية مع جميع أشكالها وأنماطها ونصوصها وتنسيقاتها وتعليقاتها ورسومها المتحركة، إلخ، دون الحاجة للقلق بشأن فقدان الجودة أو البيانات. 

**انظر أيضًا**

[نسخ الشرائح](https://docs.aspose.com/slides/python-net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **ما يمكن دمجه**

مع Aspose.Slides، يمكنك دمج 

* العروض التقديمية الكاملة. جميع الشرائح من العروض التقديمية تنتهي في عرض تقديمي واحد
* شرائح معينة. الشرائح المختارة تنتهي في عرض تقديمي واحد
* العروض التقديمية في نفس التنسيق (PPT إلى PPT، PPTX إلى PPTX، إلخ) وفي تنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

{{% alert title="ملاحظة" color="warning" %}} 

بجانب العروض التقديمية، يسمح لك Aspose.Slides بدمج ملفات أخرى:

* [صور](https://products.aspose.com/slides/python-net/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/)
* مستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/)
* وملفين مختلفين مثل [صورة إلى PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كانت 

* كل شريحة في العرض التقديمي الناتج تحتفظ بأسلوب فريد
* يتم استخدام أسلوب محدد لجميع الشرائح في العرض التقديمي الناتج. 

لدمج العروض التقديمية، يوفر Aspose.Slides طرق [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) ). هناك عدة تنفيذات لطرق `add_clone` التي تحدد معلمات عملية دمج العروض التقديمية. يحتوي كل كائن عرض تقديمي على مجموعة [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، بحيث يمكنك استدعاء طريقة `add_clone` من العرض التقديمي الذي تريد دمج الشرائح به. 

ترجع طريقة `add_clone` كائن `ISlide`، وهو نسخة من الشريحة المصدر. الشرائح في العرض التقديمي الناتج هي ببساطة نسخة من الشرائح من المصدر. لذلك، يمكنك إجراء تغييرات على الشرائح الناتجة (على سبيل المثال، تطبيق الأنماط أو خيارات التنسيق أو التخطيطات) دون القلق بشأن تأثر العروض التقديمية المصدر. 

## **دمج العروض التقديمية**

يوفر Aspose.Slides طريقة [**AddClone (ISlide)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) التي تسمح لك بدمج الشرائح بينما تحتفظ الشرائح بتخطيطاتهم وأنماطهم (معلمات افتراضية). 

يظهر لك هذا الكود في بايثون كيفية دمج العروض التقديمية:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **دمج العروض التقديمية مع شريحة التصميم**

يوفر Aspose.Slides طريقة [**add_clone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) التي تسمح لك بدمج الشرائح بينما تطبق قالب تقديمي لشريحة التصميم. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير الأسلوب للشرائح في العرض التقديمي الناتج. 

يوضح هذا الكود في بايثون العملية المذكورة:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.masters[0], allow_clone_missing_layout = True)
        pres1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="ملاحظة" color="warning" %}} 

يتم تحديد تخطيط الشريحة لشريحة التصميم تلقائيًا. عند عدم إمكانية تحديد التخطيط المناسب، إذا كانت قيمة البوليان `allowCloneMissingLayout` في طريقة `add_clone` محددة على true، يتم استخدام التخطيط للشريحة المصدر. بخلاف ذلك، سيتم إطلاق [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).

{{% /alert %}}

إذا كنت تريد للشرائح في العرض التقديمي الناتج أن يكون لها تخطيط شرائح مختلف، استخدم طريقة [add_clone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) بدلاً من ذلك عند الدمج. 

## **دمج شرائح محددة من العروض التقديمية**

يوضح لك هذا الكود في بايثون كيفية اختيار ودمج شرائح محددة من عروض تقديمية مختلفة للحصول على عرض تقديمي ناتج واحد:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **دمج العروض التقديمية مع تخطيط الشريحة**

يوضح لك هذا الكود في بايثون كيفية دمج شرائح من العروض التقديمية بينما تطبق تخطيط الشريحة المفضل لديك عليهم للحصول على عرض تقديمي ناتج واحد:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **دمج العروض التقديمية مع أحجام شرائح مختلفة**

{{% alert title="ملاحظة" color="warning" %}} 

لا يمكنك دمج العروض التقديمية بأحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين تقديميين بأحجام شرائح مختلفة، يجب عليك تغيير حجم أحد العروض التقديمية ليتناسب مع حجم العرض الآخر. 

هذا الكود التوضيحي يوضح العملية المذكورة:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        pres2.slide_size.set_size(pres1.slide_size.size.width, pres1.slide_size.size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **دمج الشرائح إلى قسم العرض التقديمي**

يوضح لك هذا الكود في بايثون كيفية دمج شريحة محددة إلى قسم في عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.sections[0])
        pres1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

يتم إضافة الشريحة في نهاية القسم. 

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيق ويب [مجاني لتجميع الصور](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

{{% /alert %}}