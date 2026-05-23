---
title: إدارة ماسترات شرائح العروض التقديمية في C++
linktitle: ماستر الشريحة
type: docs
weight: 80
url: /ar/cpp/slide-master/
keywords:
- ماستر الشريحة
- شريحة رئيسية
- شريحة رئيسية لـ PPT
- شرائح ماستر متعددة
- مقارنة شرائح الماستر
- خلفية
- عنصر نائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة ماسترات الشرائح في Aspose.Slides للغة C++: الوصول، التحرير، الاستنساخ، المقارنة، وإزالة شرائح الماستر في عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

**الشريحة الرئيسية** (slide master) تُعرّف إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن تحتوي على أشكال مشتركة، شعارات، خلفيات، أنماط نصية، إعدادات موضوع، وإعدادات تذييل. في PowerPoint، تعديل الشريحة الرئيسية هو الطريقة المعتادة للحفاظ على تناسق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

يدعم Aspose.Slides للغة C++ نفس النموذج. يمكن للعرض التقديمي أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى شريحة رئيسية مباشرةً. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيطية تنتمي إلى شريحة رئيسية.

التسلسل الهيكلي هو:

1. **الشريحة الرئيسية** - تُعرّف التصميم المشترك والموضوع.
1. **شريحة التخطيط** - تُعرّف ترتيبًا محددًا للعنصر النائب وتنسيق على مستوى التخطيط.
1. **الشريحة العادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل الشريحة الرئيسية، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، تُمثّل الشريحة الرئيسية بواجهة [IMasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/). جميع الشرائح الرئيسية في العرض التقديمي متاحة عبر مجموعة [Presentation::get_Masters](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_masters/) التي تُنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
عندما يتم تعريف الخاصية نفسها في أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة رئيسية وشريحة تخطيط خلفية، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، انظر [Apply or Change Slide Layouts](/slides/ar/cpp/slide-layout/).
{{% /alert %}}

## **الوصول إلى الشرائح الرئيسية**

في PowerPoint، يمكنك فتح عرض الشريحة الرئيسية من **View** > **Slide Master**.

![أمر شريحة رئيسية في علامة تبويب العرض في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `get_Masters()` للوصول إلى الشرائح الرئيسية:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

يمكنك أيضًا الحصول على الشريحة الرئيسية المستخدمة من قبل شريحة عادية عبر تخطيطها:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **ما الذي تحتويه شريحة رئيسية**

الشريحة الرئيسية هي كائن شبيه بالشريحة. تُنفّذ [IBaseSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/)، لذا تُظهر العديد من خصائص الشرائح نفسها المستخدمة في الشرائح العادية وتخطيطات الشرائح. تُدرج الأعضاء الخاصة بالماستر في صفحة API لـ[IMasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/).

تشمل الأعضاء الشائعة الاستخدام في الشريحة الرئيسية:

| Member | Purpose |
| --- | --- |
| `get_Background()` | يضبط خلفية الشريحة على مستوى الماستر. |
| `get_Shapes()` | يخزن الأشكال الموضوعة على الماستر، مثل الشعارات وإطارات الصور والنص المشترك. |
| `get_LayoutSlides()` | يخزن شرائح التخطيط التي تنتمي إلى الماستر. |
| `get_ThemeManager()` | يوفّر الوصول إلى واجهات برمجة تطبيقات موضوع الماستر. |
| `get_HeaderFooterManager()` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للماستر وتخطيطاته الفرعية. |
| `GetDependingSlides()` | يُعيد الشرائح العادية التي تعتمد على الماستر عبر تخطيطاتها. |

## **إضافة صورة إلى شريحة رئيسية**

عند إضافة صورة إلى شريحة رئيسية، تظهر على الشرائح التي تستخدم تخطيطات من ذلك الماستر. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، والعناصر البصرية المتكررة الأخرى.

المثال التالي يضيف شعارًا إلى الشريحة الرئيسية الأولى:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لمزيد من المعلومات حول إطارات الصور، انظر [Picture Frame](/slides/ar/cpp/picture-frame/).

## **العمل مع العناصر النائبة**

عادةً ما تُعرّف العناصر النائبة في شرائح التخطيط. تُوفر الشريحة الرئيسية النمط والموضوع المشتركين الذين يرثهما تلك التخطيطات، بينما يحدد كل تخطيط أي العناصر النائبة متاحة وأين توضع.

في PowerPoint، تتوفر أوامر العنصر النائب في عرض شريحة رئيسية.

![أمر إدراج عنصر نائب في عرض شريحة رئيسية في PowerPoint](slide-master_5.png)

لإضافة عناصر نائب جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى الماستر:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يمكنك أيضًا تنسيق أشكال العنصر النائب الموجودة بالفعل في شريحة رئيسية. المثال التالي يجد العنصر النائب للعنوان ويطبق تعبئة تدرج خطي:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![عنصر نائب للعنوان مُنسق يُورّثه الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، انظر [Set Prompt Text in Placeholder](/slides/ar/cpp/manage-placeholder/) و[Text Formatting](/slides/ar/cpp/text-formatting/).

## **تغيير خلفية الشريحة الرئيسية**

تُورّث خلفية الماستر إلى التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يضبط لون خلفية صلب للشريحة الرئيسية الأولى:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لمواضيع ذات صلة، انظر [Presentation Background](/slides/ar/cpp/presentation-background/) و[Presentation Theme](/slides/ar/cpp/presentation-theme/).

## **استنساخ شريحة رئيسية إلى عرض تقديمي آخر**

استخدم [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/) لنسخ شريحة رئيسية إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الماستر المنسخ في التخطيطات والشرائح في العرض الهدف.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع الماستر الخاص بها، انظر [Clone Slides](/slides/ar/cpp/clone-slides/).

## **إضافة عدة شرائح رئيسية**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب أقسام مختلفة علامات تجارية أو هيكل صفحة أو إعدادات موضوع مختلفة.

![أوامر PowerPoint لإدراج وإدارة الشرائح الرئيسية](slide-master_9.jpg)

المثال التالي يستنسخ الماستر الافتراضي، يمنح النسخة نسخة خلفية مختلفة، ينشئ تخطيطًا تحت ذلك الماستر المستنسخ، ويضيف شريحة جديدة تستند إلى ذلك التخطيط:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **مقارنة الشرائح الرئيسية**

يمكن مقارنة الشرائح الرئيسية باستخدام طريقة `Equals` الموروثة من [IBaseSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/). تتحقق المقارنة من الهيكل والمحتوى الثابت، مثل الأشكال والنص والتنسيق والرسوم المتحركة وإعدادات الشريحة الأخرى. لا تُقارن المعرفات الفريدة مثل معرفات الشرائح، ولا القيم الديناميكية للعناصر النائبة مثل التاريخ الحالي.

```cpp
auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

لمزيد من المعلومات، انظر [Compare Presentation Slides](/slides/ar/cpp/compare-slides/).

## **تعيين عرض شريحة رئيسية كعرض افتراضي**

استخدم طريقة `set_LastView` على [ViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتح PowerPoint أولاً. المثال التالي يفتح العرض التقديمي في عرض شريحة رئيسية:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لمزيد من إعدادات العرض، انظر [Save Presentation](/slides/ar/cpp/save-presentation/).

## **إزالة الشرائح الرئيسية غير المستخدمة**

أحيانًا يحتوي العروض التقديمية على شرائح رئيسية لم تعد تُستَخدم من قبل أي شرائح عادية. يمكن أن يقلل إزالة الماسترات غير المستخدمة من حجم الملف ويبسط صيانة القالب.

استخدم [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/ar/cpp/aspose.slides/masterslidecollection/removeunused/) لإزالة الماسترات غير المستخدمة من مجموعة `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يمكنك أيضًا استخدام طريقة الكود القليل [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الأسئلة المتكررة**

**ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

الشريحة الرئيسية تُعرّف إعدادات التصميم المشتركة مثل الموضوع، الخلفية، الأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى شريحة رئيسية وتُعرّف ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم شريحة تخطيط، لذا فهي ترث من كل من التخطيط والماستر.

**هل يمكن أن يحتوي عرض تقديمي واحد على عدة شرائح رئيسية؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. استخدم عدة ماسترات عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى شريحة رئيسية أم إلى شريحة تخطيط؟**

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على الشريحة الرئيسية، ثم ضع عناصر النائب على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكن حذف شريحة رئيسية لا تزال مستخدمة؟**

لا. لا يمكن حذف شريحة رئيسية لديها شرائح معتمدة بأمان مباشرةً. انقل تلك الشرائح أولاً إلى تخطيطات تحت ماستر آخر، أو استخدم طريقة تنظيف الماسترات غير المستخدمة التي تُزيل فقط الماسترات غير المستعملة.