---
title: "تطبيق أو تغيير تخطيطات الشرائح في C++"
linktitle: "تخطيط الشريحة"
type: docs
weight: 60
url: /ar/cpp/slide-layout/
keywords:
- "تخطيط الشريحة"
- "تخطيط المحتوى"
- "عنصر نائب"
- "تصميم العرض التقديمي"
- "تصميم الشريحة"
- "تخطيط غير مستخدم"
- "إظهار التذييل"
- "شريحة العنوان"
- "العنوان والمحتوى"
- "عنوان القسم"
- "محتوى مزدوج"
- "مقارنة"
- "العنوان فقط"
- "تخطيط فارغ"
- "محتوى مع تعليق"
- "صورة مع تعليق"
- "العنوان والنص العمودي"
- "عنوان عمودي ونص"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لـ C++، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في إظهار التذييل."
---
## **نظرة عامة**

يعرف تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والرسوم البيانية والجداول. يمنح تطبيق التخطيط الشرائح بنية متسقة مع السماح لكل شريحة بأن تحتوي على محتواها الخاص.

أكثر التخطيطات شيوعًا تشمل:

- **شريحة العنوان**: تحتوي على عناصر نائبة للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: يحتوي على عنصر نائب للعنوان وعنصر نائب للمحتوى متعدد الاستخدامات.
- **فارغ**: لا يحتوي على أي عناصر نائبة للمحتوى ويكون مفيدًا عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

العرض التقديمي يحتوي على ثلاث مستويات مترابطة:

1. A [شريحة رئيسية](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/) تُعرّف السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
2. A [شريحة تخطيط](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/) تنتمى إلى شريحة رئيسية وتُعرّف ترتيبًا معينًا للعناصر النائبة.
3. A [شريحة عادية](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المُدخل لتلك الشريحة.

تُورث الشريحة العادية السمة والتنسيق من التخطيط الخاص بها، ويُورّث التخطيط من شريحة الماستر. أي قيمة تم ضبطها مباشرة على الشريحة العادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُنشأ أشكال العناصر النائبة منها بناءً على التخطيط المختار، بينما المحتوى المُدخل في تلك العناصر النائبة يُنتمي إلى الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء الشرائح منه. إضافة عنصر نيّب آخر إلى التخطيط لاحقًا لا يضيف تلقائيًا شكل عنصر نيّب مماثل إلى الشرائح العادية الموجودة.

هذه العلاقة لها نتيجتين مهمتين:

- تغيير التنسيق الموروث أو هندسة العناصر النائبة الموجودة على التخطيط يمكن أن يحدّث كل الشريحة التي تعتمد عليه. قبل تحرير تخطيط قيد الاستخدام، افحص الشرائح التابعة له وراجع العرض الناتج.
- لا يمكن إزالة تخطيط لا يزال مستخدمًا من قبل شريحة. أعد تعيين الشرائح التابعة له إلى تخطيط آخر أولاً، أو أزل فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى الأعلى لهذا التسلسل الهرمي، راجع [ماستر الشرائح](/slides/ar/cpp/slide-master/).

## **اختيار وتطبيق تخطيط شريحة**

استخدم نوع تخطيط عندما يتبع العرض التقديمي تعريفات تخطيطات PowerPoint القياسية. أسماء التخطيطات قابلة للتحرير من قبل المستخدم ويمكن تعريبها، لذا يكون الاختيار القائم على الاسم أقل موثوقية ما لم تتحكم في القالب المصدري.

المثال التالي يبحث عن **العنوان والمحتوى** في أول ماستر. إذا كان ذلك التخطيط غير متوفر، يتراجع عمدًا إلى **فارغ**. الفحص الثاني للـ null ضروري لأن العرض التقديمي قد يحتوي على تخطيطات مخصصة فقط. ثم يتم تطبيق التخطيط المختار على أول شريحة عادية عبر طريقة [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/set_layoutslide/).

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تغيير تخطيط الشريحة لا يزيل الأشكال العادية التي أُضيفت مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع العناصر النائبة، التنسيق الموروث، والارتباط بين العناصر النائبة الموجودة والتخطيط الجديد، لذا افحص النتيجة عند التبديل بين تخطيطات مختلفة بشكل كبير.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterlayoutslidecollection/add/) على مجموعة تخطيطات الماستر المستهدف.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **العنوان والمحتوى** باسم `Report Title and Content`، ثم يضيف شريحة عادية بناءً عليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

أضف تخطيطًا فقط عندما يحتاج القالب حقًا إلى بنية قابلة لإعادة الاستخدام. إذا كان هناك تخطيط مناسب موجود بالفعل، اختره وأعد استخدامه بدلاً من إنشاء نسخة مكررة.

## **إضافة عناصر نائبة إلى شريحة تخطيط**

توفر طريقة [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) كائنًا من النوع [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/) لإضافة أشكال نائبة إلى التخطيط.

| عنصر نائب في PowerPoint          | `ILayoutPlaceholderManager` Method |
| -------------------------------- | ---------------------------------- |
| محتوى                            | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| محتوى (عمودي)                    | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| نص                               | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| نص (عمودي)                       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| صورة                             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| مخطط                            | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| جدول                             | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| SmartArt                         | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| وسائط                            | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| صورة عبر الإنترنت                | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

المثال التالي يتحقق من وجود تخطيط **فارغ**، يضيف إليه أربعة عناصر نائبة، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب مقصود: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، بحيث يمكن Aspose.Slides توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![العناصر النائبة على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="تحذير" %}}
تغيير التنسيق الموروث أو هندسة العناصر النائبة الموجودة على التخطيط يمكن أن يؤثر على الشرائح التابعة. العنصر النائب المضاف حديثًا إلى التخطيط لا يُملأ تلقائيًا في الشرائح العادية الموجودة. اختبر تغييرات التخطيط على نسخة من العرض التقديمي وافحص كل شريحة تابعة.
{{% /alert %}}

## **إزالة تخطيطات الشرائح غير المستخدمة**

استخدم طريقة [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) لإزالة التخطيطات التي لا تربطها أي شريحة عادية. تُبقي الطريقة التخطيطات التي لا تزال قيد الاستخدام دون تعديل.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لإزالة تخطيط محدد، استخدم أولاً طريقة [get_HasDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) أو طريقة [GetDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/getdependingslides/). أعد تعيين أي شرائح تابعة قبل استدعاء طريقة [ILayoutSlide::Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/remove/). محاولة إزالة تخطيط مُستخدم تُحدث استثناءً من النوع [PptxEditException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxeditexception/).

## **التحكم في ظهور تذييل الصفحة على شريحة تخطيط**

للتخطيط خاصيته في تذييل الصفحة، رقم الشريحة، وعناصر نائبة للوقت/التاريخ. استخدم طريقة [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) للتحكم في تلك العناصر النائبة لتخطيط واحد. يكون هذا مفيدًا عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى التذييل بينما لا يجب أن تُظهر تخطيطات العنوان ذلك.

المثال التالي يختار تخطيطًا بأمان ويجعل عناصر التذييل الخاصة به مرئية:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **التحكم في ظهور تذييل الصفحة على الماستر وتخطيطاته الفرعية**

لتطبيق إعدادات تذييل موحدة عبر تسلسل هرمي للماستر، استخدم طريقة [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/get_headerfootermanager/). تعمل طرق النشر في [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslideheaderfootermanager/) على الماستر وتخطيطاته التابعة والشرائح العادية؛ لا تستهدف شريحة عادية واحدة فقط.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الأسئلة المتكررة**

**ما هو الفرق بين شريحة الماستر وشريحة التخطيط؟**

تعرّف شريحة الماستر سمة العرض التقديمي وتنسيقاته المشتركة. شريحة التخطيط تنتمي إلى الماستر وتُعرّف ترتيبًا واحدًا قابلاً لإعادة الاستخدام من العناصر النائبة. تستخدم الشرائح العادية تلك التخطيطات وتخزن المحتوى الخاص بكل شريحة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igloballayoutslidecollection/addclone/). عند النسخ بين عروض تقديمية، تحقق أيضًا من الخطوط، السمات، الصور، والموارد الأخرى المستخدمة من قبل التخطيط المصدر.

**ماذا يحدث عندما أقوم بتعديل تخطيط تم استخدامه بالفعل؟**

تُورّث الشرائح التابعة تغييرات التخطيط ما لم تُقّلِب التنسيق أو الكائنات المتأثرة محليًا. يمكن أن تتغيّر هندسة العناصر النائبة والأسلوب الموروث على العديد من الشرائح دفعة واحدة. استخدم طريقة [GetDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/getdependingslides/) لتحديد الشرائح المتأثرة قبل تحرير التخطيط.

**ماذا يحدث إذا قمت بإزالة تخطيط لا يزال قيد الاستخدام؟**

ترمي Aspose.Slides استثناءً من النوع [PptxEditException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولاً، أو استخدم طريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) لإزالة التخطيطات غير المشار إليها فقط.