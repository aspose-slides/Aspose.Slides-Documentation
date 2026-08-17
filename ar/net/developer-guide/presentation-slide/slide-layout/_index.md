---
title: "تطبيق أو تغيير تخطيطات الشرائح في .NET"
linktitle: "تخطيط الشريحة"
type: docs
weight: 60
url: /ar/net/slide-layout/
keywords:
- "تخطيط الشريحة"
- "تخطيط المحتوى"
- "عنصر نائب"
- "تصميم العرض التقديمي"
- "تصميم الشريحة"
- "تخطيط غير مستخدم"
- "ظهور الفوتر"
- "شريحة العنوان"
- "العنوان والمحتوى"
- "عنوان القسم"
- "محتوى مزدوج"
- "مقارنة"
- "العنوان فقط"
- "تخطيط فارغ"
- "محتوى مع شرح"
- "صورة مع شرح"
- "العنوان والنص العمودي"
- "عنوان عمودي ونص"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لـ .NET، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في ظهور الفوتر."
---
## **نظرة عامة**

يحدد تخطيط الشريحة المواقع وتنسيق العناصر النائبة مثل العناوين والنص والصور والرسوم البيانية والجداول. يعطى تطبيق التخطيط الشرائح بنية متسقة مع السماح لكل شريحة بمحتواها الخاص.

تشمل أكثر التخطيطات شيوعًا:

- **شريحة العنوان**: تحتوي على عناصر نائبة للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: تحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **فارغة**: لا تحتوي على عناصر نائبة للمحتوى وتكون مفيدة عندما يتم تموضع كل شكل يدويًا.

## **فهم توريث التخطيط**

تحتوي العرض التقديمي على ثلاثة مستويات مرتبطة:

1. [الشريحة الرئيسية](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/) تُعرِّف السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
2. [شريحة التخطيط](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/) تنتمي إلى شريحة رئيسية وتحدد ترتيبًا معينًا للعناصر النائبة.
3. [شريحة عادية](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المُدخل لتلك الشريحة.

تُورّث شريحة عادية السمة والتنسيق من تخطيطها، ويورّث التخطيط من الشريحة الرئيسية. القيمة التي تُحدد مباشرةً على شريحة عادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُنشأ أشكال العناصر النائبة منها بناءً على التخطيط المحدد، بينما ينتمي المحتوى المدخل في تلك العناصر النائبة إلى الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء الشرائح منه. إضافة عنصر نائب آخر إلى التخطيط في وقت لاحق لا يُضيف تلقائيًا شكل عنصر نائب مماثل إلى الشرائح العادية الموجودة.

هذا العلاقة لها نتيجتان مهمتان:

- تغيير التنسيق الموروث أو هندسة العنصر النائب الموجود على التخطيط يمكن أن يُحدّث كل شريحة تعتمد عليه. قبل تعديل تخطيط مُستَخدَم، افحص الشرائح التابعة وراجع العرض الناتج.
- لا يمكن إزالة تخطيط لا يزال مستخدمًا من قبل شريحة. أعد تعيين الشرائح التابعة إلى تخطيط آخر أولاً، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى الأعلى من هذه الهرمية، راجع [الشريحة الرئيسية](/slides/ar/net/slide-master/).

## **اختيار وتطبيق تخطيط الشريحة**

استخدم نوعًا من التخطيط عندما يتبع العرض التقديمي تعريفات التخطيط القياسية في PowerPoint. أسماء التخطيطات قابلة للتحرير من قبل المستخدم ويمكن تعريبها، لذا فإن الاختيار القائم على الاسم أقل موثوقية ما لم تتحكم في القالب المصدر.

المثال التالي يبحث عن **العنوان والمحتوى** في أول شريحة رئيسية. إذا كان ذلك التخطيط غير متاح، فإنه ينتقل عمدًا إلى **فارغة**. الفحص الثاني للعنصر الفارغ ضروري لأن العرض التقديمي قد يحتوي فقط على تخطيطات مخصصة. ثم يتم تطبيق التخطيط المختار على أول شريحة عادية عبر خاصية [ISlide.LayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/layoutslide/).

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

تغيير تخطيط الشريحة لا يزيل الأشكال العادية المضافة مباشرةً إلى الشريحة. ومع ذلك، قد تتغيّر مواضع العناصر النائبة، والتنسيق الموروث، وتطابق العناصر النائبة الموجودة مع التخطيط الجديد، لذا افحص النتيجة عند التبديل بين تخطيطات مختلفة بشكل كبير.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/ar/net/aspose.slides/masterlayoutslidecollection/add/) على مجموعة تخطيطات الشريحة الرئيسية المستهدفة.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **العنوان والمحتوى** يُسمّى `Report Title and Content`، ثم يضيف شريحة عادية تستند إليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

أضف تخطيطًا فقط عندما يحتاج القالب فعليًا إلى بنية قابلة لإعادة الاستخدام. إذا كان هناك تخطيط مناسب موجود بالفعل، فاختره وأعد استخدامه بدلاً من إنشاء نسخة مكررة.

## **إضافة عناصر نائبة إلى شريحة تخطيط**

خاصية [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/placeholdermanager/) تُوفِّر كائنًا من النوع [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutplaceholdermanager/) لإضافة أشكال عناصر نائبة إلى التخطيط.

| عنصر نائبة في PowerPoint | طريقة ILayoutPlaceholderManager |
| -------------------------- | -------------------------------- |
| ![محتوى](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![محتوى (عمودي)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![نص](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![نص (عمودي)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![صورة](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![مخطط](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![جدول](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![وسائط](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![صورة عبر الإنترنت](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

المثال التالي يتحقق من وجود التخطيط **فارغة**، يضيف أربع عناصر نائبة إليه، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب مقصود: يتم إضافة العناصر النائبة قبل إنشاء الشريحة العادية، حتى يتمكن Aspose.Slides من توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

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

{{% alert color="warning" title="تحذير" %}}
تغيير التنسيق الموروث أو هندسة العناصر النائبة الموجودة في التخطيط يمكن أن يؤثر على الشرائح التابعة. العنصر النائب المضاف حديثًا إلى التخطيط لا يُعاد ملء الشرائح العادية الموجودة. اختبر تغييرات التخطيط على نسخة من العرض التقديمي وفحص كل شريحة تابعة.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

استخدم طريقة [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تترك الطريقة التخطيطات التي لا تزال قيد الاستخدام كما هي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

لإزالة تخطيط محدد واحد، استخدم أولاً خاصية [HasDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/hasdependingslides/) أو طريقة [GetDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/getdependingslides/). أعد تعيين أي شرائح تابعة قبل استدعاء [ILayoutSlide.Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/remove/). محاولة إزالة تخطيط مُستَخدَم تُثير استثناءً من النوع [PptxEditException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxeditexception/).

## **التحكم في ظهور الفوتر على شريحة التخطيط**

يحتوي التخطيط على فوتر خاص به وعناصر نائبة لرقم الشريحة وتاريخ/وقت. استخدم خاصية [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/headerfootermanager/) للتحكم في تلك العناصر النائبة لتخطيط واحد. يكون هذا مفيدًا عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى الفوترات بينما لا تُظهر تخطيطات العناوين ذلك.

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

## **التحكم في ظهور الفوتر على الشريحة الرئيسية وتخطيطاتها الفرعية**

لتطبيق إعدادات فوتر متسقة عبر هيكل الشريحة الرئيسية، استخدم خاصية [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/headerfootermanager/). تعمل طرق النشر في [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslideheaderfootermanager/) على الشريحة الرئيسية وتخطيطاتها التابعة والشرائح العادية؛ لا تستهدف شريحة عادية واحدة فقط.

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

## **الأسئلة المتكررة**

**ما هو الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

تُعرِّف الشريحة الرئيسية سمة العرض وتنسيق العناصر المشتركة. شريحة التخطيط تنتمي إلى شريحة رئيسية وتحدد ترتيبًا قابلاً لإعادة الاستخدام للعناصر النائبة. تستخدم الشرائح العادية هذه التخطيطات وتخزن المحتوى الخاص بكل شريحة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/globallayoutslidecollection/addclone/). عند النسخ بين العروض، تحقق أيضًا من الخطوط والسمات والصور والموارد الأخرى المستخدمة في التخطيط المصدر.

**ماذا يحدث عندما أُعدِّل تخطيطًا مُستَخدَمًا بالفعل؟**

تُورّث الشرائح التابعة تغييرات التخطيط ما لم تُزيل التنسيق أو الكائنات المتأثرة محليًا. يمكن أن يتغيّر شكل العناصر النائبة والأنماط الموروثة على العديد من الشرائح دفعة واحدة. استخدم طريقة [GetDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/getdependingslides/) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا أزلت تخطيطًا لا يزال قيد الاستخدام؟**

يرمي Aspose.Slides استثناءً من النوع [PptxEditException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولاً، أو استخدم طريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) لإزالة التخطيطات غير المشار إليها فقط.