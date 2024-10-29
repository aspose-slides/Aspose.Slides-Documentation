---
title: دمج عروض PowerPoint PPT و PPTX باستخدام C#
linktitle: دمج العرض التقديمي
type: docs
weight: 40
url: /ar/net/merge-presentation/
keywords: "دمج PowerPoint, PPTX, PPT, دمج PowerPoint, دمج العرض التقديمي, دمج, C#, Csharp, .NET"
description: "دمج أو تجميع عروض PowerPoint في C# أو .NET"
---

{{% alert title="نصيحة" color="primary" %}} 

يمكنك التحقق من تطبيق **Aspose المجاني عبر الإنترنت** [Merger](https://products.aspose.app/slides/merger). يتيح للناس دمج عروض PowerPoint بنفس التنسيق (PPT إلى PPT، PPTX إلى PPTX، إلخ) ودمج العروض بتنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **دمج العروض التقديمية**

عندما تقوم [بدمج عرض تقديمي بآخر](https://products.aspose.com/slides/net/merger/ppt/)، فإنك تقوم فعليًا بدمج الشرائح الخاصة بهم في عرض تقديمي واحد للحصول على ملف واحد. 

{{% alert title="معلومات" color="info" %}}

تفتقر معظم برامج العروض التقديمية (PowerPoint أو OpenOffice) إلى الوظائف التي تسمح للمستخدمين بدمج العروض التقديمية بهذه الطريقة.

ومع ذلك، فإن [**Aspose.Slides لـ .NET**](https://products.aspose.com/slides/net/) يتيح لك دمج العروض التقديمية بطرق مختلفة. يمكنك دمج العروض التقديمية مع جميع أشكالها وأنماطها ونصوصها وتنسيقاتها وتعليقاتها وحركاتها، إلخ، دون الحاجة إلى القلق بشأن فقدان الجودة أو البيانات.

**انظر أيضًا**

[نسخ الشرائح](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **ما الذي يمكن دمجه**

باستخدام Aspose.Slides، يمكنك دمج 

* العروض التقديمية الكاملة. جميع الشرائح من العروض التقديمية تنتهي في عرض تقديمي واحد
* شرائح محددة. تنتهي الشرائح المحددة في عرض تقديمي واحد
* العروض التقديمية بتنسيق واحد (PPT إلى PPT، PPTX إلى PPTX، إلخ) وفي تنسيقات مختلفة (PPT إلى PPTX، PPTX إلى ODP، إلخ) مع بعضها البعض. 

{{% alert title="ملاحظة" color="warning" %}} 

بجانب العروض التقديمية، يسمح لك Aspose.Slides بدمج ملفات أخرى:

* [صور](https://products.aspose.com/slides/net/merger/image-to-image/)، مثل [JPG إلى JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) أو [PNG إلى PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* مستندات، مثل [PDF إلى PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) أو [HTML إلى HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* وملفين مختلفين مثل [صورة إلى PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) أو [JPG إلى PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) أو [TIFF إلى PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **خيارات الدمج**

يمكنك تطبيق خيارات تحدد ما إذا كانت

* كل شريحة في العرض التقديمي الناتج تحتفظ بأسلوب فريد
* يُستخدم أسلوب محدد لجميع الشرائح في العرض التقديمي الناتج. 

لدمج العروض التقديمية، يوفر Aspose.Slides طرق [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) (من واجهة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)). هناك عدة تنفيذات لطرق `AddClone` التي تحدد معلمات عملية دمج العروض التقديمية. كل كائن Presentation لديه مجموعة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)، لذا يمكنك استدعاء طريقة `AddClone` من العرض التقديمي الذي ترغب في دمج الشرائح فيه. 

ترجع طريقة `AddClone` كائن `ISlide`، وهو نسخة من الشريحة المصدر. الشرائح في العرض التقديمي الناتج هي ببساطة نسخة من الشرائح من المصدر. لذلك، يمكنك إجراء تغييرات على الشرائح الناتجة (على سبيل المثال، تطبيق أنماط أو خيارات تنسيق أو تخطيطات) دون القلق بشأن تأثيرها على العروض التقديمية المصدر. 

## **دمج العروض التقديمية** 

يوفر Aspose.Slides طريقة [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) التي تسمح لك بدمج الشرائح بينما تحتفظ الشرائح بتنسيقاتها وأنماطها (الإعدادات الافتراضية). 

يظهر لك هذا الكود بلغة C# كيفية دمج العروض التقديمية:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **دمج العروض التقديمية مع شريحة ماسك**

يوفر Aspose.Slides الطريقة [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) التي تتيح لك دمج الشرائح مع تطبيق قالب عرض تقديمي لماسك الشريحة. بهذه الطريقة، إذا لزم الأمر، يمكنك تغيير النمط للشرائح في العرض التقديمي الناتج. 

يظهر هذا الكود بلغة C# العملية الموضحة:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ملاحظة" color="warning" %}} 

يتم تحديد تخطيط الشريحة لماسك الشريحة تلقائيًا. عندما لا يمكن تحديد تخطيط مناسب، إذا كانت قيمة المعلمة المنطقية `allowCloneMissingLayout` لطريقة `AddClone` مضبوطة على true، يُستخدم التخطيط للشريحة المصدر. خلاف ذلك، سيتم طرح [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

إذا كنت ترغب في أن تحتوي الشرائح في العرض التقديمي الناتج على تخطيط شريحة مختلف، استخدم الطريقة [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) بدلاً من ذلك عند الدمج. 

## **دمج شرائح محددة من العروض التقديمية**

يعرض لك هذا الكود بلغة C# كيفية تحديد ودمج شرائح محددة من عروض تقديمية مختلفة للحصول على عرض تقديمي الناتج:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **دمج العروض التقديمية مع تخطيط الشريحة**

يعرض لك هذا الكود بلغة C# كيفية دمج الشرائح من العروض التقديمية مع تطبيق تخطيط الشريحة المفضل لديك للحصول على عرض تقديمي واحد:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **دمج العروض التقديمية مع أحجام شرائح مختلفة**

{{% alert title="ملاحظة" color="warning" %}} 

لا يمكنك دمج العروض التقديمية مع أحجام شرائح مختلفة. 

{{% /alert %}}

لدمج عرضين تقديميين بأحجام شرائح مختلفة، عليك إعادة ضبط حجم أحد العروض التقديمية ليطابق حجم العرض الآخر. 

يظهر هذا الكود المصدري العملية الموضحة:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **دمج الشرائح في قسم العرض التقديمي**

يعرض لك هذا الكود بلغة C# كيفية دمج شريحة محددة في قسم معين داخل عرض تقديمي:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

تُضاف الشريحة في نهاية القسم. 

{{% alert title="نصيحة" color="primary" %}}

يوفر Aspose تطبيق ويب [مجانًا](https://products.aspose.app/slides/collage) Collage. باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

{{% /alert %}}