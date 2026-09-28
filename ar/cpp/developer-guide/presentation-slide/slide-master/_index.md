---
title: إدارة قوالب شرائح العرض التقديمي في C++
linktitle: قالب الشريحة
type: docs
weight: 80
url: /ar/cpp/slide-master/
keywords:
- قالب الشريحة
- شريحة رئيسية
- شريحة رئيسية PPT
- شرائح رئيسية متعددة
- مقارنة شرائح رئيسية
- خلفية
- عنصر نائب
- استنساخ شريحة رئيسية
- نسخ شريحة رئيسية
- تكرار شريحة رئيسية
- شريحة رئيسية غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة قوالب الشرائح في Aspose.Slides لـ C++: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة الشرائح الرئيسية في عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

**قالب الشريحة الرئيسي** يعرّف إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن يحتوي على أشكال مشتركة، شعارات، خلفيات، أنماط نص، إعدادات سمة، وإعدادات تذييل. في PowerPoint، يُعد تحرير قالب الشريحة الرئيسي الطريقة المعتادة للحفاظ على اتساق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

يدعم Aspose.Slides for C++ نفس النموذج. يمكن للعرض التقديمي أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى شريحة رئيسية مباشرة. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتعود شريحة التخطيط إلى شريحة رئيسية.

التسلسل الهرمي هو:

1. **قالب الشريحة الرئيسي** - يحدد التصميم المشترك والسمة.
1. **شريحة التخطيط** - تحدد ترتيبًا محددًا للعناصر النائبة وتنسيق المستوى التخطيط.
1. **الشريحة العادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل شريحة القالب الرئيسي، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، يتم تمثيل قالب الشريحة الرئيسي بواسطة الواجهة [IMasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/). جميع القوالب الرئيسية في العرض التقديمي متاحة عبر مجموعة [Presentation::get_Masters](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_masters/) التي تُطبق [IMasterSlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="الوراثة" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة رئيسية وشريحة تخطيط خلفيةً، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/slides/ar/cpp/slide-layout/).
{{% /alert %}}

## **الوصول إلى قوالب الشرائح**

في PowerPoint، يمكنك فتح عرض قالب الشريحة من **View** > **Slide Master**.

![أمر قالب الشريحة في علامة تبويب العرض في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `get_Masters()` للوصول إلى القوالب الرئيسية:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

يمكنك أيضًا الحصول على الشريحة الرئيسية المستخدمة بواسطة شريحة عادية عبر تخطيطها:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **ما يحتويه قالب الشريحة الرئيسي**

قالب الشريحة هو كائن شبيه بالشريحة. يتم تطبيق [IBaseSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/) عليه، لذا فهو يعرض العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. الأعضاء الخاصة بالقالب مُدرجة في صفحة API [IMasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/).

الأعضاء الشائعة الاستخدام في قالب الشريحة تشمل:

| عضو | الغرض |
| --- | --- |
| `get_Background()` | يضبط خلفية الشريحة على مستوى القالب. |
| `get_Shapes()` | يخزن الأشكال الموضوعة على القالب، مثل الشعارات وإطارات الصور والنص المشترك. |
| `get_LayoutSlides()` | يخزن شرائح التخطيط التي تنتمي إلى القالب. |
| `get_ThemeManager()` | يوفر وصولًا إلى واجهات برمجة تطبيقات سمة القالب. |
| `get_HeaderFooterManager()` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للقالب وتخطيطاته الفرعية. |
| `GetDependingSlides()` | يرجع الشرائح العادية التي تعتمد على القالب عبر تخطيطاتها. |

## **إضافة صورة إلى قالب الشريحة الرئيسي**

عند إضافة صورة إلى قالب شريحة رئيسية، تظهر على الشرائح التي تستخدم تخطيطات من ذلك القالب. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، وعناصر بصرية أخرى متكررة.

المثال التالي يضيف شعارًا إلى أول قالب شريحة رئيسية:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

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

لمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/slides/ar/cpp/picture-frame/).

## **التحكم في رؤية رسومات القالب**

استخدم [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/set_showmastershapes/) لإخفاء الرسومات الموروثة من القالب، مثل الشعارات أو الأشكال الزخرفية، دون حذفها من القالب. مرّر `false` إلى [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/set_showmastershapes/) على الشريحة التي يجب أن تُحذف تلك الرسومات و`true` على الشرائح التي يجب أن تُظهرها.

المثال التالي المستقل يُنشئ شريطًا زمنيًا أزرقًا زخرفيًا على قالب شريحة رئيسية وشريحتيْن تستخدمان نفس التخطيط الفارغ. الشريط مرئي على الشريحة الأولى ومُخفي على الثانية. لا يُطلب عرض تقديمي أو صورة إدخال.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يستخدم المثال تخطيط **Blank** المرفق مع عرض تقديمي جديد ويحذف العناصر النائبة الخاصة بالشريحة الأولية.

### **اختر نطاق الإعداد**

تستخدم الشريحة العادية القالب الخاص بها عبر [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/get_layoutslide/) و[ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_masterslide/). ضبط الخاصية على شريحة فردية يؤثر فقط على تلك الشريحة. تمرير `false` إلى [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/layoutslide/set_showmastershapes/) يخفي رسومات القالب للشرائح التي تستخدم ذلك التخطيط المشترك، حتى وإن كان إعدادها الخاص `true`. لإخفاء الرسومات على شريحة واحدة فقط، غير الخاصية على الشريحة واترك التخطيط المشترك دون تغيير.

الإعداد غير مدعوم كعنصر تحكم في الرؤية على القالب نفسه. في القالب يعيد دائمًا `false`، وتعيين `true` يثير استثناء `System::NotSupportedException`. طبّق الإعداد على شريحة عادية أو تخطيط بدلاً من ذلك.

### **تمييز الرسومات عن الخلفية**

| العملية | التأثير |
| --- | --- |
| إخفاء رسومات القالب | يتحكم في رؤية الأشكال الموروثة من القالب دون حذفها أو تغيير أشكال الشريحة نفسها. |
| تغيير تعبئة خلفية الشريحة | يغيّر لون الخلفية أو التدرج أو الصورة. رسومات القالب هي أشكال منفصلة ويمكن أن تظل مرئية فوق تلك الخلفية. راجع [Presentation Background](/slides/ar/cpp/presentation-background/). |
| حذف شكل من القالب | يزيل الشكل المشترك المصدر، وبالتالي لا يصبح متاحًا لأي شريحة تستخدم ذلك القالب. |

## **العمل مع العناصر النائبة**

عادةً ما تُعرّف العناصر النائبة على شرائح التخطيط. يوفر القالب الرئيسي النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي العناصر النائبة متاحة وأين توضع.

في PowerPoint، أوامر العنصر النائب متاحة في عرض قالب الشريحة.

![أمر إدراج عنصر نائب في عرض قالب الشريحة في PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى القالب:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على قالب الشريحة. المثال التالي يجد العنصر النائب للعنوان ويطبق تعبئة تدرج خطية:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

![العنصر النائب للعنوان المُنسق الموروث من الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [Set Prompt Text in Placeholder](/slides/ar/cpp/manage-placeholder/) و[Text Formatting](/slides/ar/cpp/text-formatting/).

## **تغيير خلفية قالب الشريحة الرئيسي**

تُورث خلفية القالب من قبل التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يضبط لون خلفية صلبة للصفحة الأولى من القالب الرئيسي:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

للمواضيع ذات الصلة، راجع [Presentation Background](/slides/ar/cpp/presentation-background/) و[Presentation Theme](/slides/ar/cpp/presentation-theme/).

## **استنساخ قالب شريحة رئيسية إلى عرض تقديمي آخر**

استخدم [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/) لنسخ قالب شريحة رئيسية إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام القالب المنسوخ بواسطة التخطيطات والشرائح في العرض الوجهة.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع القالب الخاص بها، راجع [Clone Slides](/slides/ar/cpp/clone-slides/).

## **إضافة عدة قوالب شرائح**

يمكن للعرض التقديمي أن يحتوي على عدة قوالب شرائح. هذا مفيد عندما تتطلب الأقسام المختلفة علامات تجارية مختلفة أو بنية صفحات أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة قوالب الشرائح](slide-master_9.jpg)

المثال التالي يستنسخ القالب الافتراضي، يعطي النسخة خلفية مختلفة، يُنشئ تخطيطًا تحت القالب المستنسخ، ثم يضيف شريحة جديدة بناءً على ذلك التخطيط:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

## **مقارنة قوالب الشرائح**

يمكن مقارنة قوالب الشرائح باستخدام طريقة `Equals` الموروثة من [IBaseSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/). تتحقق المقارنة من الهيكل والمحتوى الثابت مثل الأشكال والنص والتنسيق والرسوم المتحركة وإعدادات الشريحة الأخرى. لا تقارن المعرفات الفريدة مثل معرفات الشرائح أو قيم العناصر النائبة الديناميكية مثل التاريخ الحالي.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

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

لمزيد من المعلومات، راجع [Compare Presentation Slides](/slides/ar/cpp/compare-slides/).

## **تعيين عرض قالب الشريحة كعرض افتراضي**

استخدم طريقة `set_LastView` على [ViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتح PowerPoint أولاً. المثال التالي يفتح العرض التقديمي في وضع قالب الشريحة:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لمزيد من إعدادات العرض، راجع [Save Presentation](/slides/ar/cpp/save-presentation/).

## **إزالة قوالب الشرائح غير المستخدمة**

في بعض الأحيان يحتوي العرض التقديمي على قوالب شرائح لم تعد تُستَخدم من قبل أي شرائح عادية. إزالة القوالب غير المستخدمة يمكن أن يقلل من حجم الملف ويبسّط صيانة القالب.

استخدم [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/ar/cpp/aspose.slides/masterslidecollection/removeunused/) لإزالة القوالب غير المستخدمة من مجموعة `get_Masters()`:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يمكنك أيضًا استخدام طريقة الكود المنخفض [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**ما الفرق بين قالب الشريحة الرئيسي وشريحة التخطيط؟**

قالب الشريحة الرئيسي يحدد إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى قالب الشريحة الرئيسي وتحدد ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم شريحة التخطيط، لذا ترث من كل من التخطيط والقالب.

**هل يمكن لعرض تقديمي واحد أن يحتوي على عدة قوالب شرائح؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة قوالب شرائح. استخدم قوالب متعددة عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى قالب الشريحة الرئيسي أم إلى شريحة التخطيط؟**

في أغلب الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيقات المشتركة على القالب الرئيسي، ثم ضع عناصر النائب على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكن حذف قالب شريحة رئيسية لا يزال قيد الاستخدام؟**

لا. لا يمكن حذف قالب شريحة رئيسية لديه شرائح معتمدة بأمان مباشرة. انقل تلك الشرائح إلى تخطيطات تحت قالب آخر، أو استخدم طريقة تنظيف القوالب غير المستخدمة التي تزيل فقط القوالب التي لا تُستَخدم.