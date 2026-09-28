---
title: تطبيق أو تغيير تخطيطات الشرائح في .NET
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
- C#
- .NET
- Aspose.Slides
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لـ .NET، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في رؤية التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة مواقع وتنسيق العناصر النائبة مثل العناوين، النص، الصور، المخططات والجداول. يمنح تطبيق التخطيط الشرائح بنية متسقة مع السماح لكل شريحة بمحتواها الخاص.

أكثر التخطيطات شيوعًا تشمل:

- **شريحة عنوان**: تحتوي على عناصر نائبة للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: تحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **فارغ**: لا يحتوي على عناصر نائبة وهو مفيد عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

للعرض التقديمي ثلاث مستويات مترابطة:

1. تُعرّف [شريحة ماستر](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/) السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
1. تنتمي [شريحة تخطيط](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/) إلى ماستر وتحدد ترتيبًا معينًا للعناصر النائبة.
1. تستخدم [شريحة عادية](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/) تخطيطًا واحدًا وتخزّن المحتوى المدخل لتلك الشريحة.

ترث الشريحة العادية السمة والتنسيق من تخطيطها، ويرث التخطيط من ماسترها. أي قيمة تُضبط مباشرةً على الشريحة العادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُنشأ أشكال العناصر النائبة من التخطيط المختار، بينما المحتوى المدخل في تلك العناصر النائبة يخص الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى تخطيط قبل إنشاء الشرائح منه. إضافة عنصر نائب آخر إلى تخطيط لاحقًا لا يضيف تلقائيًا شكل عنصر نائب مماثل إلى الشرائح العادية الموجودة.

للعلاقة نتيجتان مهمتان:

- يمكن أن يؤدي تغيير التنسيق الموروث أو هندسة العنصر النائب الموجود في التخطيط إلى تحديث كل الشرائح المعتمدة عليه. قبل تحرير تخطيط مُستَخدم، راجع الشرائح التابعة وتأكّد من النتيجة.
- لا يمكن إزالة تخطيط لا يزال مستخدمًا من قبل شريحة. أعِد تعيين الشرائح التابعة إلى تخطيط آخر أولًا، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى العلوي لهذه الهرمية، راجع [شريحة ماستر](/slides/ar/net/slide-master/).

لإخفاء الشعارات أو الأشكال الزخرفية للماستر على شريحة واحدة أو عبر تخطيط مشترك، انظر [التحكم في رؤية رسومات الماستر](/slides/ar/net/slide-master/). المثال يقارن بين شريحتين تستخدمان نفس الماستر.

## **اختيار وتطبيق تخطيط شريحة**

استخدم نوع التخطيط عندما يتبع العرض التقديمي تعريفات تخطيط PowerPoint القياسية. أسماء التخطيطات قابلة للتحرير من قبل المستخدم ويمكن تعريبها، لذا يكون الاختيار القائم على الاسم أقل موثوقية إلا إذا كان بإمكانك التحكم في القالب المصدري.

المثال التالي يبحث عن **العنوان والمحتوى** في أول ماستر. إذا كان ذلك التخطيط غير متوفر، فإنه يعود عمدًا إلى **فارغ**. الفحص الثاني للـ null ضروري لأن العرض التقديمي قد يحتوي على تخطيطات مخصصة فقط. ثم يُطبق التخطيط المختار على أول شريحة عادية عبر خاصية [ISlide.LayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

تغيير تخطيط الشريحة لا يزيل الأشكال العادية المضافة مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع العناصر النائبة، التنسيق الموروث، والتطابق بين العناصر النائبة الحالية والتخطيط الجديد، لذا يُفضَّل فحص الناتج عند التبديل بين تخطيطات مختلفة جذريًا.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/ar/net/aspose.slides/masterlayoutslidecollection/add/) على مجموعة تخطيطات الماستر المستهدف.

المثال التالي يضيف دائمًا تخطيط **العنوان والمحتوى** جديدًا اسمه `Report Title and Content`، ثم يضيف شريحة عادية تعتمد عليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

أضف تخطيطًا فقط عندما يحتاج القالب فعليًا إلى تركيبة قابلة لإعادة الاستخدام. إذا كان هناك تخطيط مناسب بالفعل، فاختره وأعد استخدامه بدلًا من إنشاء نسخة مكررة.

## **إضافة عناصر نائبة إلى شريحة تخطيط**

توفر خاصية [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/placeholdermanager/) كائنًا من نوع [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutplaceholdermanager/) لإضافة أشكال عناصر نائبة إلى التخطيط.

| عنصر نائب في PowerPoint            | `ILayoutPlaceholderManager` طريقة |
| ----------------------------------- | --------------------------------- |
| ![محتوى](content.png)              | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![محتوى (عمودي)](contentV.png)    | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![نص](text.png)                    | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![نص (عمودي)](textV.png)          | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![صورة](picture.png)               | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![مخطط](chart.png)                 | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![جدول](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![وسائط](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![صورة عبر الإنترنت](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

المثال التالي يتحقق من وجود تخطيط **فارغ**، يضيف إليه أربعة عناصر نائبة، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب متعمد: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، بحيث يستطيع Aspose.Slides توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

النتيجة:

![العناصر النائبة على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
يمكن أن يؤثر تغيير التنسيق الموروث أو هندسة العناصر النائبة الموجودة في التخطيط على الشرائح التابعة. العنصر النائب المضاف حديثًا لا يُملأ تلقائيًا في الشرائح العادية الموجودة. اختبر تغييرات التخطيط على نسخة من العرض التقديمي وتفقد كل شريحة تابعة.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

استخدم طريقة [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تترك الطريقة التخطيطات التي لا يزال يُستَخدم فيها سليمة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

لإزالة تخطيط معين، استخدم أولًا خاصية [HasDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/hasdependingslides/) أو طريقة [GetDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/getdependingslides/). أعد تعيين أي شرائح تابعة قبل استدعاء [ILayoutSlide.Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/remove/). محاولة إزالة تخطيط مُستَخدم تُثير استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxeditexception/).

## **التحكم في رؤية تذييل الصفحة على شريحة التخطيط**

للخطيط تذييل صفحة، رقم شريحة، وعناصر نائبة للوقت/التاريخ خاصة به. استخدم خاصية [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/headerfootermanager/) للتحكم في تلك العناصر النائبة لتخطيط واحد. وهذا مفيد عندما يجب أن تُظهر تخطيطات المحتوى تذييلات ولكن لا تُظهر تخطيطات العناوين.

المثال التالي يختار تخطيطًا بأمان ويجعل عناصر تذييله مرئية:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **التحكم في رؤية تذييل الصفحة على ماستر وتخطيطاته الفرعية**

لتطبيق إعدادات تذييل متسقة عبر هرمية ماستر، استخدم خاصية [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/headerfootermanager/). تعمل طرق النشر الخاصة بـ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslideheaderfootermanager/) على الماستر وتخطيطاته التابعة والشرائح العادية؛ ولا تستهدف شريحة عادية واحدة فقط.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **الأسئلة الشائعة**

**ما الفرق بين شريحة ماستر وشريحة تخطيط؟**

تحدد شريحة الماستر سمة العرض التقديمي والتنسيق المشترك. تنتمي شريحة التخطيط إلى ماستر وتعرّف ترتيبًا قابلاً لإعادة الاستخدام من العناصر النائبة. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوى الشريحة الخاص.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/globallayoutslidecollection/addclone/). عند النسخ بين العروض، تحقق أيضًا من الخطوط، السمات، الصور، والموارد الأخرى المستخدمة في التخطيط المصدر.

**ماذا يحدث إذا قمت بتعديل تخطيط مُستَخدم بالفعل؟**

ترث الشرائح التابعة تغييرات التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. وبالتالي قد تتغير هندسة العناصر النائبة والتنسيق الموروث على العديد من الشرائح دفعة واحدة. استخدم [GetDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/getdependingslides/) لتحديد الشرائح المتأثرة قبل تحرير التخطيط.

**ماذا يحدث إذا أزلت تخطيطًا لا يزال قيد الاستخدام؟**

تطرح Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولًا، أو استخدم [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) لإزالة التخطيطات غير المرجعية فقط.