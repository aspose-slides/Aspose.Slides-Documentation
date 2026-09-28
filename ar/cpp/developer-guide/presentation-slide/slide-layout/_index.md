---
title: "تطبيق أو تعديل تخطيطات الشرائح في C++"
linktitle: "تخطيط الشريحة"
type: docs
weight: 60
url: /ar/cpp/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- رؤية التذييل
- شريحة عنوان
- عنوان ومحتوى
- عنوان القسم
- محتوى مزدوج
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع توضيح
- صورة مع توضيح
- عنوان ونص عمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تطبيق وإ إنشاء وتعديل تخطيطات الشرائح في Aspose.Slides للغة C++، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في رؤية التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والرسوم البيانية والجداول. يمنح تطبيق التخطيط الشرائح بنيةً متسقةً مع السماح لكل شريحة بوجود محتواها الخاص.

أكثر التخطيطات شيوعًا تشمل:

- **شريحة العنوان**: تحتوي على عناصر نائبة للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: تحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **فارغ**: لا يحتوي على أي عناصر نائبة، وهو مفيد عندما يتم وضع كل شكل يدويًا.

## **فهم توريث التخطيط**

للعرض التقديمي ثلاث مستويات مرتبطة:

1. [شريحة رئيسية](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/) تُعرّف السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
1. [شريحة تخطيط](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/) تنتمي إلى شريحة رئيسية وتحدد ترتيبًا معينًا للعناصر النائبة.
1. [شريحة عادية](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المدخل لهذه الشريحة.

ترث الشريحة العادية السمة والتنسيق من تخطيطها، ويورّث التخطيط من شريحته الرئيسية. أي قيمة تم تعيينها مباشرةً على شريحة عادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُنشأ أشكال العناصر النائبة من التخطيط المحدد، بينما المحتوى المدخل في تلك العناصر النائبة يخص الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء الشرائح منه. إضافة عنصر نائب آخر إلى التخطيط لاحقًا لا يضيف تلقائيًا شكل عنصر نائب مقابل إلى الشرائح العادية الموجودة.

هذه العلاقة لها نتيجتان مهمتان:

- تغيير التنسيق الموروث أو هندسة العناصر النائبة الموجودة في التخطيط يمكن أن يحدّث كل شريحة تعتمد عليه. قبل تعديل تخطيط مستخدم بالفعل، راجع الشرائح المعتمدة وتحقق من العرض الناتج.
- لا يمكن حذف تخطيط لا يزال مستخدمًا من قبل شريحة. أعد تعيين الشرائح المعتمدة إلى تخطيط آخر أولاً، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى الأعلى من هذه السلسلة الهرمية، راجع [Slide Master](/slides/ar/cpp/slide-master/).

لإخفاء الشعارات الموروثة أو الأشكال الزخرفية في الشريحة الرئيسية على شريحة واحدة أو عبر تخطيط مشترك، راجع [Control the Visibility of Master Graphics](/slides/ar/cpp/slide-master/). المقارنة في المثال تُظهر شريحتين تستخدمان نفس الشريحة الرئيسية.

## **اختيار وتطبيق تخطيط الشريحة**

استخدم نوع التخطيط عندما يتبع العرض التقديمي تعريفات تخطيط PowerPoint القياسية. أسماء التخطيطات قابلة للتحرير من قبل المستخدم ويمكن تعريبها، لذا فإن الاختيار القائم على الاسم أقل موثوقية ما لم تتحكم في القالب المصدر.

المثال التالي يبحث عن **العنوان والمحتوى** في الشريحة الرئيسية الأولى. إذا كان ذلك التخطيط غير متاح، يتم العودة عمدًا إلى **فارغ**. الفحص الثاني للـ null ضروري لأن العرض التقديمي قد يحتوي فقط على تخطيطات مخصصة. يتم بعد ذلك تطبيق التخطيط المحدد على أول شريحة عادية عبر طريقة [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/set_layoutslide/).

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

تغيير تخطيط الشريحة لا يزيل الأشكال العادية المضافة مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع العناصر النائبة، التنسيق الموروث، والارتباط بين العناصر النائبة الموجودة والتخطيط الجديد، لذا تحقق من النتيجة عند التبديل بين تخطيطات مختلفة اختلافًا كبيرًا.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterlayoutslidecollection/add/) على مجموعة تخطيطات الشريحة الرئيسية المستهدفة.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **العنوان والمحتوى** يُسمى `Report Title and Content`، ثم يضيف شريحة عادية تستند إليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

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

أضف تخطيطًا فقط عندما يحتاج القالب حقًا إلى هيكل قابل لإعادة الاستخدام آخر. إذا كان تخطيط مناسب موجودًا بالفعل، فاختره وأعد استخدامه بدلاً من إنشاء نسخة مكررة.

## **إضافة عناصر نائبة إلى شريحة تخطيط**

توفر طريقة [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) كائنًا من نوع [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/) لإضافة أشكال عناصر نائبة إلى التخطيط.

| عنصر نائب في PowerPoint | طريقة `ILayoutPlaceholderManager` |
| ------------------------ | --------------------------------- |
| ![المحتوى](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![المحتوى (عمودي)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![نص](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![نص (عمودي)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![صورة](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![مخطط](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![جدول](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![وسائط](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![صورة عبر الإنترنت](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

المثال التالي يتحقق من وجود تخطيط **فارغ**، يضيف أربعة عناصر نائبة إليه، ثم ينشئ شريحة عادية تستخدم التخطيط المعدَّل. الترتيب مقصود: يُضاف العناصر النائبة قبل إنشاء الشريحة العادية، بحيث يمكن Aspose.Slides إنشاء أشكال العناصر النائبة المقابلة على تلك الشريحة.

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

{{% alert color="warning" title="Warning" %}}
تغيير التنسيق الموروث أو هندسة العناصر النائبة الموجودة في التخطيط يمكن أن يؤثر على الشرائح المعتمدة. العنصر النائب الذي يُضاف حديثًا لا يُملأ تلقائيًا في الشرائح العادية القائمة. اختبر تغييرات التخطيط على نسخة من العرض التقديمي وتفقد كل شريحة معتمدة.
{{% /alert %}}

## **إزالة تخطيطات الشرائح غير المستخدمة**

استخدم طريقة [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تُترك التخطيطات ما زالت قيد الاستخدام كما هي.

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

لإزالة تخطيط محدد واحد، استخدم أولاً طريقة [get_HasDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) أو طريقة [GetDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/getdependingslides/). أعد تعيين أي شرائح معتمدة قبل استدعاء طريقة [ILayoutSlide::Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/remove/). محاولة إزالة تخطيط مستخدم تُثير استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxeditexception/).

## **التحكم في ظهور التذييل على شريحة تخطيط**

للتخطيط مجال تذييل، رقم شريحة، ووقت التاريخ الخاص به. استخدم طريقة [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) للتحكم في تلك العناصر النائبة لتخطيط واحد. هذا مفيد عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى التذييلات لكن تخطيطات العنوان لا يجب أن تُظهرها.

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

## **التحكم في ظهور التذييل على شريحة رئيسية وتخطيطاتها الفرعية**

لتطبيق إعدادات تذييل موحدة عبر تسلسل هرمي لشريحة رئيسية، استخدم طريقة [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/get_headerfootermanager/). تُنفّذ طرق النشر في [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslideheaderfootermanager/) على الشريحة الرئيسية وتخطيطاتها الفرعية والشرائح العادية؛ لا تستهدف شريحة عادية واحدة فقط.

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

**ما الفرق بين شريحة رئيسية وشريحة تخطيط؟**

تُعرّف الشريحة الرئيسية سمة العرض التقديمي والتنسيق المشترك. شريحة التخطيط تنتمي إلى شريحة رئيسية وتحدد ترتيبًا قابلاً لإعادة الاستخدام للعناصر النائبة. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوىً خاصًا بالشريحة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igloballayoutslidecollection/addclone/). عند النسخ بين العروض، تحقق أيضًا من الخطوط، السمات، الصور، والموارد الأخرى المستخدمة في التخطيط المصدر.

**ماذا يحدث إذا عدّلت تخطيطًا مُستخدمًا بالفعل؟**

تورّث الشرائح المعتمدة تغيرات التخطيط ما لم تتجاوز التنسيقات أو الكائنات المتأثرة محليًا. يمكن أن تتغير هندسة العناصر النائبة والأسلوب الموروث على العديد من الشرائح دفعة واحدة. استخدم طريقة [GetDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/getdependingslides/) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا أزلت تخطيطًا لا يزال قيد الاستخدام؟**

ترمي Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxeditexception/). أعد تعيين الشرائح المعتمدة أولاً، أو استخدم طريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) لإزالة التخطيطات غير المشار إليها فقط.