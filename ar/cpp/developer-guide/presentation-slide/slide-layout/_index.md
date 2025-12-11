---
title: "تطبيق أو تعديل تخطيطات الشرائح في C++"
linktitle: "تخطيط الشريحة"
type: docs
weight: 60
url: /ar/cpp/slide-layout/
keywords:
- "تخطيط الشريحة"
- "تخطيط المحتوى"
- "عنصر نائب"
- "تصميم العرض"
- "تصميم الشريحة"
- "تخطيط غير مستخدم"
- "إظهار التذييل"
- "شريحة العنوان"
- "العنوان والمحتوى"
- "رأس القسم"
- "محتويان"
- "مقارنة"
- "العنوان فقط"
- "تخطيط فارغ"
- "محتوى مع توضيح"
- "صورة مع توضيح"
- "العنوان والنص العمودي"
- "عنوان عمودي ونص"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "إدارة وتخصيص تخطيطات الشرائح في Aspose.Slides للغة C++. استكشف أنواع التخطيطات، التحكم في العناصر النائبة، وإظهار التذييل من خلال أمثلة كود C++."
---

## **نظرة عامة**

تحدد تخطيط الشريحة ترتيب صناديق العنصر النائب وتنسيق المحتوى على الشريحة. يتحكم في أي العناصر النائبة متاحة وأين تظهر. تساعد تخطيطات الشرائح على تصميم العروض بسرعة وتناسق—سواء كنت تنشئ شيئًا بسيطًا أو أكثر تعقيدًا. بعض أكثر تخطيطات الشرائح شيوعًا في PowerPoint تشمل:

**Title Slide layout** – يتضمن عنصرين نصيين: أحدهما للعنوان والآخر للعنوان الفرعي.

**Title and Content layout** – يحتوي على عنصر عنوان أصغر في الأعلى وعنصر أكبر أسفلًا للمحتوى الرئيسي (مثل النص، النقاط، المخططات، الصور، وأكثر).

**Blank layout** – لا يحتوي على أي عناصر نائبة، مما يمنحك التحكم الكامل لتصميم الشريحة من الصفر.

تعد تخطيطات الشرائح جزءًا من سابقة الشرائح (slide master)، وهي الشريحة العليا التي تحدد أنماط التخطيط للعرض. يمكنك الوصول إلى تخطيطات الشرائح وتعديلها عبر سابقة الشرائح—إما بواسطة النوع أو الاسم أو المعرف الفريد. بدلاً من ذلك، يمكنك تعديل تخطيط شريحة محدد مباشرة داخل العرض.

للعمل مع تخطيطات الشرائح في Aspose.Slides for Android، يمكنك استخدام:

- طرق مثل [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) و[get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) ضمن فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
- أنواع مثل [ILayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/)، [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/)، [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/)، و[ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
لتعلم المزيد حول العمل مع سابقة الشرائح، اطلع على مقالة [Slide Master](/slides/ar/cpp/slide-master/).
{{% /alert %}}

## **إضافة تخطيطات شرائح إلى العروض التقديمية**

لتخصيص مظهر وبنية شرائحك، قد تحتاج إلى إضافة تخطيطات شرائح جديدة إلى عرض تقديمي. يتيح لك Aspose.Slides for Android التحقق مما إذا كان تخطيط معين موجودًا بالفعل، إضافة واحد جديد إذا لزم الأمر، واستخدامه لإدراج شرائح بناءً على ذلك التخطيط.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. احصل على [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. تحقق مما إذا كان تخطيط الشريحة المطلوب موجودًا بالفعل في المجموعة. إذا لم يكن كذلك، أضف تخطيط الشريحة الذي تحتاجه.
1. أضف شريحة فارغة بناءً على تخطيط الشريحة الجديد.
1. احفظ العرض التقديمي.

الكود C++ التالي يوضح كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:
```cpp
// إنشاء كائن الفئة Presentation الذي يمثل ملف PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // حالة لا يحتوي فيها العرض على جميع أنواع التخطيطات.
    // ملف العرض يحتوي فقط على نوعي التخطيط فارغ ومخصص.
    // ومع ذلك، قد تحتوي شرائح التخطيط ذات الأنواع المخصصة على أسماء يمكن التعرف عليها،
    // مثل "Title" و "Title and Content" وغيرها، والتي يمكن استخدامها لاختيار شريحة التخطيط.
    // يمكنك أيضًا الاعتماد على مجموعة من أنواع أشكال العناصر النائبة.
    // على سبيل المثال، يجب أن تحتوي شريحة العنوان فقط على نوع العنصر النائب Title، وهكذا.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// إضافة شريحة فارغة باستخدام شريحة التخطيط المضافة.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// حفظ العرض على القرص.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **إزالة تخطيطات الشرائح غير المستخدمة**

توفر Aspose.Slides طريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) ضمن فئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) لتتيح لك حذف تخطيطات الشرائح غير المرغوبة وغير المستخدمة.

الكود C++ التالي يوضح كيفية إزالة تخطيط شريحة من عرض PowerPoint:
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **إضافة عناصر نائبة إلى تخطيطات الشرائح**

توفر Aspose.Slides الطريقة [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) التي تسمح لك بإضافة عناصر نائبة جديدة إلى تخطيط الشريحة.

يحتوي هذا المدير على طرق للأنواع التالية من العناصر النائبة:

| عنصر نائب في PowerPoint | طريقة [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/) |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

الكود C++ التالي يوضح كيفية إضافة أشكال عنصر نائب جديدة إلى تخطيط الشريحة الفارغة:
```cpp
auto presentation = MakeObject<Presentation>();

// احصل على شريحة التخطيط الفارغة.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// احصل على مدير العناصر النائبة لشريحة التخطيط.
auto placeholderManager = layout->get_PlaceholderManager();

// أضف عناصر نائبة مختلفة إلى شريحة التخطيط الفارغة.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// أضف شريحة جديدة باستخدام التخطيط الفارغ.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![The placeholders on the layout slide](add_placeholders.png)

## **تعيين إظهار التذييل لتخطيط شريحة**

في عروض PowerPoint، يمكن إظهار أو إخفاء عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص اعتمادًا على تخطيط الشريحة. يتيح لك Aspose.Slides for Android التحكم في إظهار هذه العناصر النائبة في التذييل. هذا مفيد عندما تريد بعض التخطيطات لعرض معلومات التذييل بينما تبقى أخرى نظيفة وبسيطة.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. احصل على مرجع لتخطيط الشريحة بحسب فهرسه.
1. عيّن عنصر نائب التذييل للشريحة إلى مرئي.
1. عيّن عنصر نائب رقم الشريحة إلى مرئي.
1. عيّن عنصر نائب التاريخ/الوقت إلى مرئي.
1. احفظ العرض التقديمي.

الكود C++ التالي يوضح كيفية تعيين إظهار تذييل شريحة وإجراء المهام ذات الصلة:
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```


## **تعيين إظهار تذييل الطفل لشريحة**

​في عروض PowerPoint، يمكن التحكم في عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص على مستوى سابقة الشريحة لضمان التناسق عبر جميع تخطيطات الشرائح. يتيح لك Aspose.Slides for Android تعيين إظهار ومحتوى هذه العناصر النائبة في سابقة الشريحة ونشر هذه الإعدادات إلى جميع تخطيطات الشرائح الفرعية. يضمن هذا النهج توحيد معلومات التذييل في جميع أنحاء العرض التقديمي.​

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. احصل على مرجع لسابقة الشريحة بحسب فهرسه.
1. عيّن جميع عناصر نائب التذييل في السابعة وجميع التخطيطات الفرعية إلى مرئي.
1. عيّن جميع عناصر نائب رقم الشريحة في السابعة وجميع التخطيطات الفرعية إلى مرئي.
1. عيّن جميع عناصر نائب التاريخ/الوقت في السابعة وجميع التخطيطات الفرعية إلى مرئي.
1. احفظ العرض التقديمي.

الكود C++ التالي يوضح هذا العملية:
```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **الأسئلة المتكررة**

**ما الفرق بين سابقة الشريحة وتخطيط الشريحة؟**

تحدد سابقة الشريحة الموضوع العام والتنسيق الافتراضي، بينما تحدد تخطيطات الشرائح ترتيبًا محددًا للعناصر النائبة لأنواع مختلفة من المحتوى.

**هل يمكنني نسخ تخطيط شريحة من عرض تقديمي إلى آخر؟**

نعم، يمكنك استنساخ تخطيط شريحة من مجموعة تخطيطات عرض تقديمي عبر طريقة [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/)، ثم إدراجه في عرض تقديمي آخر باستخدام طريقة `AddClone`.

**ماذا يحدث إذا حذفت تخطيط شريحة لا يزال مستخدمًا من قبل شريحة؟**

إذا حاولت حذف تخطيط شريحة لا يزال مُشارًا إليه من قبل شريحة واحدة على الأقل في العرض، ستطلق Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/). لتجنب ذلك، استخدم طريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) التي تزيل بأمان فقط تخطيطات الشرائح غير المستخدمة.