---
title: تطبيق أو تغيير تخطيط شريحة في C#
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/net/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- رؤية التذييل
- شريحة العنوان
- العنوان والمحتوى
- رأس القسم
- محتوى مزدوج
- مقارنة
- العنوان فقط
- تخطيط فارغ
- محتوى مع توضيح
- صورة مع توضيح
- العنوان والنص العمودي
- العنوان العمودي والنص
- C#
- .NET
- Aspose.Slides
description: "تعرف على كيفية إدارة وتخصيص تخطيطات الشرائح في Aspose.Slides لـ .NET. استكشف أنواع التخطيطات، والتحكم في العناصر النائبة، ورؤية التذييل، وتعديل التخطيط من خلال أمثلة شفرة في C#."
---

## **نظرة عامة**

يحدد تخطيط الشريحة ترتيب صناديق العنصر النائب وتنسيق المحتوى على الشريحة. يتحكم في العناصر النائبة المتاحة ومكان ظهورها. تساعد تخطيطات الشرائح في تصميم العروض التقديمية بسرعة وبشكل موحد—سواءً كنت تنشئ شيئًا بسيطًا أو أكثر تعقيدًا. بعض أكثر تخطيطات الشرائح شيوعًا في PowerPoint تشمل:

**Title Slide layout** – يتضمن عنصرين نصيين نائبين: واحد للعنوان والآخر للعنوان الفرعي.

**Title and Content layout** – يضم عنصر نائب للعنوان أصغر في الأعلى وآخر أكبر أسفله للمحتوى الرئيسي (مثل النص، النقاط، المخططات، الصور، والمزيد).

**Blank layout** – لا يحتوي على عناصر نائب، مما يمنحك السيطرة الكاملة لتصميم الشريحة من الصفر.

تعد تخطيطات الشرائح جزءًا من الشريحة الرئيسية (slide master)، وهي الشريحة ذات المستوى الأعلى التي تحدد أنماط التخطيط للعرض التقديمي. يمكنك الوصول إلى تخطيطات الشرائح وتعديلها عبر الشريحة الرئيسية—إما حسب النوع أو الاسم أو المعرف الفريد. بدلاً من ذلك، يمكنك تحرير تخطيط شريحة معين مباشرة داخل العرض التقديمي.

للعمل مع تخطيطات الشرائح في Aspose.Slides for .NET، يمكنك استخدام:

- الخصائص مثل [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) و[Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) ضمن فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)
- الأنواع مثل [ILayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/)، [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/)، [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/)، و[ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
لتعلم المزيد حول العمل مع الشرائح الرئيسية، اطلع على مقالة [Slide Master](/slides/ar/net/slide-master/).
{{% /alert %}}

## **إضافة تخطيطات الشرائح إلى العروض التقديمية**

لضبط مظهر وهيكل الشرائح الخاصة بك، قد تحتاج إلى إضافة تخطيطات شرائح جديدة إلى عرض تقديمي. يسمح لك Aspose.Slides for .NET بالتحقق مما إذا كان تخطيط معين موجودًا بالفعل، وإضافة واحد جديد إذا لزم الأمر، واستخدامه لإدراج شرائح بناءً على ذلك التخطيط.

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. وصول إلى [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/).
1. تحقق مما إذا كان تخطيط الشريحة المطلوب موجودًا بالفعل في المجموعة. إذا لم يكن كذلك، أضف تخطيط الشريحة الذي تحتاجه.
1. أضف شريحة فارغة تستند إلى تخطيط الشريحة الجديد.
1. احفظ العرض التقديمي.

الكود C# التالي يوضح كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:
```cs
// إنشاء كائن من فئة Presentation الذي يمثل ملف PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // استعراض أنواع تخطيطات الش... لاختيار تخطيط شريحة.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // حالة لا يحتوي فيها العرض التقديمي على جميع أنواع التخطيطات.
        // يحتوي ملف العرض التقديمي فقط على أنواع التخطيط Blank و Custom.
        // ومع ذلك، قد تحتوي شرائح التخطيط ذات الأنواع المخصصة على أسماء يمكن التعرف عليها,
        // مثل "Title"، "Title and Content"، إلخ، والتي يمكن استخدامها لاختيار تخطيط الشريحة.
        // يمكنك أيضًا الاعتماد على مجموعة من أنواع أشكال العنصر النائب.
        // على سبيل المثال، يجب أن تحتوي شريحة العنوان فقط على نوع العنصر النائب Title، وهكذا.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
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
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // إضافة شريحة فارغة باستخدام تخطيط الشريحة المضاف.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // حفظ العرض التقديمي إلى القرص.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **إزالة تخطيطات الشرائح غير المستخدمة**

توفر Aspose.Slides الطريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) من فئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) لتسمح لك بحذف تخطيطات الشرائح غير المرغوب فيها وغير المستخدمة.

الكود C# التالي يوضح كيفية إزالة تخطيط شريحة من عرض PowerPoint:
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **إضافة عناصر نائب إلى تخطيطات الشرائح**

توفر Aspose.Slides الخاصية [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/placeholdermanager/)، والتي تتيح لك إضافة عناصر نائب جديدة إلى تخطيط شريحة.

يحتوي هذا المدير على طرق للأنواع التالية من العناصر النائبة:

| عنصر نائب في PowerPoint              | طريقة [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![المحتوى](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![المحتوى (عمودي)](contentV.png)   | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![نص](text.png)                     | AddTextPlaceholder(float x, float y, float width, float height) |
| ![نص (عمودي)](textV.png)           | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![صورة](picture.png)                | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![مخطط](chart.png)                  | AddChartPlaceholder(float x, float y, float width, float height) |
| ![جدول](table.png)                  | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![وسائط](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![صورة عبر الإنترنت](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

الكود C# التالي يوضح كيفية إضافة أشكال عنصر نائب جديدة إلى تخطيط الشريحة الفارغة:
```cs
using (var presentation = new Presentation())
{
    // احصل على شريحة التخطيط الفارغ.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // احصل على مدير العناصر النائبة لشريحة التخطيط.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // أضف عناصر نائب مختلفة إلى شريحة التخطيط الفارغ.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // أضف شريحة جديدة باستخدام التخطيط الفارغ.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![العناصر النائبة على تخطيط الشريحة](add_placeholders.png)

## **تعيين رؤية التذييل لتخطيط شريحة**

في عروض PowerPoint، يمكن إظهار أو إخفاء عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص اعتمادًا على تخطيط الشريحة. يتيح لك Aspose.Slides for .NET التحكم في رؤية هذه العناصر النائبة للتذييل. هذا مفيد عندما تريد لبعض التخطيطات عرض معلومات التذييل بينما يبقى البعض الآخر نظيفًا وموجزًا.

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع لتخطيط شريحة عبر فهرسه.
1. عيّن عنصر نائب التذييل في الشريحة إلى ظاهر.
1. عيّن عنصر نائب رقم الشريحة إلى ظاهر.
1. عيّن عنصر نائب التاريخ/الوقت إلى ظاهر.
1. احفظ العرض التقديمي.

الكود C# التالي يوضح كيفية تعيين رؤية تذييل الشريحة وإجراء المهام ذات الصلة:
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```


## **تعيين رؤية تذييل الطفل لشريحة**

​في عروض PowerPoint، يمكن التحكم في عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص على مستوى الشريحة الرئيسية لضمان الاتساق عبر جميع تخطيطات الشرائح. يتيح لك Aspose.Slides for .NET تعيين رؤية ومحتوى هذه العناصر النائبة للتذييل على الشريحة الرئيسية ونشر هذه الإعدادات إلى جميع تخطيطات الشرائح الفرعية. يضمن هذا النهج توحيد معلومات التذييل في جميع أنحاء العرض التقديمي.​

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة الرئيسية عبر فهرستها.
1. عيّن جميع عناصر نائب التذييل في الرئيسية والطفل إلى ظاهر.
1. عيّن جميع عناصر نائب رقم الشريحة في الرئيسية والطفل إلى ظاهر.
1. عيّن جميع عناصر نائب التاريخ/الوقت في الرئيسية والطفل إلى ظاهر.
1. احفظ العرض التقديمي.

الكود C# التالي يوضح هذه العملية:
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**ما الفرق بين الشريحة الرئيسية وتخطيط الشريحة؟**

تحدد الشريحة الرئيسية السمة العامة والتنسيق الافتراضي، بينما تحدد تخطيطات الشرائح ترتيبات محددة للعناصر النائبة لأنواع المحتوى المختلفة.

**هل يمكنني نسخ تخطيط شريحة من عرض تقديمي إلى آخر؟**

نعم، يمكنك استنساخ تخطيط شريحة من مجموعة [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) الخاصة بعرض تقديمي وإدراجه في آخر باستخدام طريقة `AddClone`.

**ماذا يحدث إذا حذفت تخطيط شريحة لا يزال يُستخدم في شريحة أخرى؟**

إذا حاولت حذف تخطيط شريحة لا يزال مُشارًا إليه من قبل شريحة واحدة على الأقل في العرض التقديمي، ستستقصي Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception/). لتجنب ذلك، استخدم [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) الذي يزيل بأمان فقط تخطيطات الشرائح غير المستخدمة.