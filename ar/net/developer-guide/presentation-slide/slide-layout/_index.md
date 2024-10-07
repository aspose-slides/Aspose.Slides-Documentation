---
title: تخطيط الشريحة
type: docs
weight: 60
url: /net/slide-layout/
keyword: "تعيين حجم الشريحة، تعيين خيارات الشريحة، تحديد حجم الشريحة، رؤية تذييل الشريحة، تذييل فرعي، تغيير محتوى الشريحة، حجم الصفحة، C#، Csharp، .NET، Aspose.Slides"
description: "تعيين حجم خيارات الشريحة في PowerPoint باستخدام C# أو .NET"
---

يتضمن تخطيط الشريحة مربعات الحجز ومعلومات التنسيق لجميع المحتويات التي تظهر على الشريحة. يحدد التخطيط أماكن المحتوى المتاحة ومكان وجودها.

تسمح تخطيطات الشرائح لك بإنشاء وتصميم العروض التقديمية بسرعة (سواء كانت بسيطة أو معقدة). إليك بعض من أشهر تخطيطات الشرائح المستخدمة في عروض PowerPoint:

* **تخطيط شريحة العنوان**. يتكون هذا التخطيط من مربعين نصيين. واحد للحجز لعنوان الشريحة والآخر للاحتياطي الفرعي.
* **تخطيط العنوان والمحتوى**. يحتوي هذا التخطيط على مربع حجز صغير نسبيًا في الأعلى لعنوان الشريحة ومربع حجز أكبر للمحتوى الأساسي (رسوم بيانية، فقرات، قائمة نقطية، قائمة مرقمة، صور، إلخ).
* **تخطيط فارغ**. يخلو هذا التخطيط من صناديق الحجز، لذا فإنه يسمح لك بإنشاء العناصر من الصفر.

نظرًا لأن الماستر الخاص بالشريحة هو أعلى شريحة هرمية تقوم بتخزين معلومات عن تخطيطات الشرائح، يمكنك استخدام الشريحة الرئيسية للوصول إلى تخطيطات الشرائح وإجراء تغييرات عليها. يمكن الوصول إلى تخطيط الشريحة إما بواسطة النوع أو الاسم. وبالمثل، تحتوي كل شريحة على معرف فريد، يمكن استخدامه للوصول إليها.

بدلاً من ذلك، يمكنك إجراء تغييرات مباشرة على تخطيط شريحة معينة في عرض تقديمي.

* للسماح لك بالعمل مع تخطيطات الشرائح (بما في ذلك تلك الموجودة في الشرائح الرئيسية)، توفر Aspose.Slides خصائص مثل [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) و[Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) ضمن فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
* لأداء المهام ذات الصلة، توفر Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)، [MasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterlayoutslidecollection/)، [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/)، [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/)، والعديد من الأنواع الأخرى.

{{% alert title="معلومات" color="info" %}}

للحصول على مزيد من المعلومات حول العمل مع الشرائح الرئيسية بشكل خاص، راجع المقالة [تخطيط الشريحة](https://docs.aspose.com/slides/net/slide-master/).

{{% /alert %}}

## **إضافة تخطيط شريحة إلى العرض التقديمي**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الوصول إلى مجموعة [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/).
1. قم بمراجعة تخطيطات الشرائح الموجودة لتأكيد وجود تخطيط الشريحة المطلوب بالفعل في مجموعة التخطيط. إذا لم يكن، أضف التخطيط الذي تريده.
1. أضف شريحة فارغة استنادًا إلى تخطيط الشريحة الجديدة.
1. احفظ العرض التقديمي.

يوضح هذا الكود بلغة C# كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:

```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // مراجعة أنواع تخطيط الشرائح
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // الحالة التي لا يحتوي فيها العرض التقديمي على بعض أنواع التخطيط.
        // يحتوي ملف العرض التقديمي فقط على تخطيطات فارغة ومخصصة.
        // لكن شرائح التخطيط التي تحتوي على أنواع مخصصة لها أسماء شرائح مختلفة،
        // مثل "عنوان"، "عنوان ومحتوى"، إلخ. من الممكن استخدام هذه
        // الأسماء لاختيار تخطيط الشريحة.
        // يمكنك أيضًا استخدام مجموعة من أنواع الأشكال الاحتياطية. على سبيل المثال،
        // يجب أن يحتوي تخطيط الشريحة على نوع حجز بعنوان فقط، إلخ.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "عنوان ومحتوى")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "عنوان")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "عنوان ومحتوى");
                }
            }
        }
    }

    // إضافة شريحة فارغة بالتخطيط المضاف
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // حفظ العرض التقديمي على القرص  
    presentation.Save("AddLayoutSlides_out.pptx", SaveFormat.Pptx);
}
```

## **إزالة تخطيط الشريحة غير المستخدم**

توفر Aspose.Slides الطريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) من فئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) للسماح لك بحذف تخطيطات الشرائح غير المرغوب فيها وغير المستخدمة. يوضح كود C# كيفية إزالة تخطيط شريحة من عرض PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **تعيين الحجم والنوع لتخطيط الشريحة**

للسماح لك بتعيين الحجم والنوع لتخطيط شريحة معينة، توفر Aspose.Slides خصائص [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/type) و[Size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/size) (من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)). يوضح هذا المثال باللغة C# العملية:

```c#
// إنشاء مثيل لموضوع Presentation الذي يمثل ملف العرض التقديمي 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// تعيين حجم الشريحة للعرض التقديمي الناتج ليكون مثل المصدر
auxPresentation.SlideSize.SetSize(presentation.SlideSize.Type, SlideSizeScaleType.EnsureFit);

auxPresentation.Slides.InsertClone(0, slide);
auxPresentation.Slides.RemoveAt(0);
// حفظ العرض التقديمي على القرص
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **تعيين رؤية التذييل داخل الشريحة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على مرجع الشريحة من خلال مؤشرها.
1. تعيين حجز التذييل للشريحة ليكون مرئيًا.
1. تعيين حجز التاريخ والوقت ليكون مرئيًا.
1. حفظ العرض التقديمي.

يوضح هذا الكود بلغة C# كيفية تعيين الرؤية لتذييل شريحة (وأداء المهام ذات الصلة):

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[0].HeaderFooterManager;
    if (!headerFooterManager.IsFooterVisible) // يتم استخدام خاصية IsFooterVisible للإشارة إلى أن حجز تذييل الشريحة مفقود
    {
        headerFooterManager.SetFooterVisibility(true); // يتم استخدام أسلوب SetFooterVisibility لتعيين حجز تذييل الشريحة ليكون مرئيًا
    }
    if (!headerFooterManager.IsSlideNumberVisible) // يتم استخدام خاصية IsSlideNumberVisible للإشارة إلى أن حجز رقم الشريحة مفقود
    {
        headerFooterManager.SetSlideNumberVisibility(true); // يتم استخدام أسلوب SetSlideNumberVisibility لتعيين حجز رقم الشريحة ليكون مرئيًا
    }
    if (!headerFooterManager.IsDateTimeVisible) // يتم استخدام خاصية IsDateTimeVisible للإشارة إلى أن حجز التاريخ والوقت مفقود
    {
        headerFooterManager.SetDateTimeVisibility(true); // يتم استخدام أسلوب SetFooterVisibility لتعيين حجز تاريخ ووقت الشريحة ليكون مرئيًا
    }
    headerFooterManager.SetFooterText("نص التذييل"); // يتم استخدام أسلوب SetFooterText لتعيين نص لحجز تذييل الشريحة
    headerFooterManager.SetDateTimeText("نص التاريخ والوقت"); // يتم استخدام أسلوب SetDateTimeText لتعيين نص لحجز التاريخ والوقت للشريحة.

    presentation.Save("Presentation.ppt", SaveFormat.ppt);
}
```

## **تعيين رؤية التذييل الفرعي داخل الشريحة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على مرجع الشريحة الرئيسية من خلال مؤشرها.
1. تعيين رؤية الشريحة الرئيسية وجميع حجوز التذييلات الفرعية لتكون مرئية.
1. تعيين نص للشريحة الرئيسية وجميع حجوز التذييلات الفرعية.
1. تعيين نص للشريحة الرئيسية وجميع حجوز التاريخ والوقت الفرعية.
1. حفظ العرض التقديمي.

يوضح هذا الكود بلغة C# العملية:

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
    headerFooterManager.SetFooterAndChildFootersVisibility(true); // يتم استخدام أسلوب SetFooterAndChildFootersVisibility لتعيين رؤية الشريحة الرئيسية وجميع حجوز التذييلات الفرعية لتكون مرئية
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // يتم استخدام أسلوب SetSlideNumberAndChildSlideNumbersVisibility لتعيين رؤية الشريحة الرئيسية وجميع حجوز أرقام الصفحات الفرعية لتكون مرئية
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // يتم استخدام أسلوب SetDateTimeAndChildDateTimesVisibility لتعيين رؤية الشريحة الرئيسية وجميع حجوز التاريخ والوقت الفرعية لتكون مرئية

    headerFooterManager.SetFooterAndChildFootersText("نص التذييل"); // يتم استخدام أسلوب SetFooterAndChildFootersText لتعيين نصوص للشريحة الرئيسية وجميع حجوز التذييلات الفرعية
    headerFooterManager.SetDateTimeAndChildDateTimesText("نص التاريخ والوقت"); // يتم استخدام أسلوب SetDateTimeAndChildDateTimesText لتعيين نص للشريحة الرئيسية وجميع حجوز التاريخ والوقت الفرعية
}
```

## **تعيين حجم الشريحة بالنسبة لتغيير المحتوى**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الشريحة التي تريد تعيين حجمها.
1. قم بإنشاء مثيل آخر من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لإنشاء عرض تقديمي جديد.
1. احصل على مرجع الشريحة (من العرض التقديمي الأول) من خلال مؤشرها.
1. تعيين حجز التذييل للشريحة ليكون مرئيًا.
1. تعيين حجز التاريخ والوقت ليكون مرئيًا.
1. حفظ العرض التقديمي.

يوضح هذا الكود بلغة C# العملية:

```c#
// إنشاء مثيل لموضوع Presentation الذي يمثل ملف العرض التقديمي 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// تعيين حجم الشريحة للعروض التقديمية الناتجة ليكون مثل المصدر
presentation.SlideSize.SetSize(540, 720, SlideSizeScaleType.EnsureFit); // يتم استخدام أسلوب SetSize لتعيين حجم الشريحة مع تغيير المحتوى لضمان التناسب
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // يتم استخدام أسلوب SetSize لتعيين حجم الشريحة مع الحجم الأقصى للمحتوى
           
// حفظ العرض التقديمي على القرص
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **تعيين حجم الصفحة عند إنشاء PDF**

غالبًا ما يتم تحويل عروض معينة (مثل الملصقات) إلى مستندات PDF. إذا كنت تبحث عن تحويل PowerPoint الخاص بك إلى PDF للوصول إلى أفضل خيارات الطباعة والوصول، تريد تعيين شرائحك إلى أحجام تناسب مستندات PDF (مثل A4، على سبيل المثال).

توفر Aspose.Slides فئة [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/) للسماح لك بتحديد إعداداتك المفضلة للشرائح. يوضح كود C# كيفية استخدام خاصية [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/type/) (من فئة `SlideSize`) لتعيين حجم ورق معين للشرائح في عرض تقديمي:

```c#
// إنشاء مثيل لموضوع Presentation الذي يمثل ملف العرض التقديمي 
Presentation presentation = new Presentation();

// تعيين خاصية SlideSize.Type 
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.EnsureFit);

// تعيين خصائص مختلفة لخيارات PDF
PdfOptions opts = new PdfOptions();
opts.SufficientResolution = 600;

// حفظ العرض التقديمي على القرص
presentation.Save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
```