---
title: إدارة شرائح الماستر في العروض التقديمية باستخدام .NET
linktitle: الشريحة الرئيسية
type: docs
weight: 80
url: /ar/net/slide-master/
keywords:
- شريحة ماستر
- شريحة ماستر
- شريحة ماستر PPT
- عدة شرائح ماستر
- مقارنة شرائح ماستر
- الخلفية
- عنصر نائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة شرائح الماستر في Aspose.Slides لـ .NET: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة شرائح الماستر في عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

يحدد **الشريحة الرئيسية** إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن يحتوي على أشكال مشتركة، شعارات، خلفيات، أنماط نصية، إعدادات سمة، وإعدادات تذييل. في PowerPoint، تعديل الشريحة الرئيسية هو الطريقة المعتادة للحفاظ على اتساق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

يدعم Aspose.Slides لـ .NET نفس النموذج. يمكن للعرض التقديمي أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى شريحة رئيسية مباشرةً. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيطية تنتمي إلى شريحة رئيسية.

التسلسل الهرمي هو:

1. **الشريحة الرئيسية** - تحدد التصميم المشترك والسمة.
1. **شريحة تخطيط** - تحدد ترتيبًا محددًا لعناصر النائب وتنسيق على مستوى التخطيط.
1. **شريحة عادية** - تحتوي على محتوى العرض التقديمي الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل الشرائح الرئيسية، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، تمثل الشريحة الرئيسية الواجهة [IMasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/) . جميع الشرائح الرئيسية في عرض تقديمي متاحة من خلال مجموعة [Presentation.Masters](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/masters/) ، التي تنفذ الواجهة [IMasterSlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت الشريحة الرئيسية وشريحة التخطيط كلاهما خلفية، فإن الشرائح القائمة على ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/slides/ar/net/slide-layout/) .
{{% /alert %}}

## **الوصول إلى الشرائح الرئيسية**

في PowerPoint، يمكنك فتح طريقة عرض الشريحة الرئيسية من **عرض** > **الشريحة الرئيسية**.

![أمر الشريحة الرئيسية في تبويب عرض PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `Masters` للوصول إلى الشرائح الرئيسية:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

يمكنك أيضًا الحصول على الشريحة الرئيسية التي يستخدمها شريحة عادية من خلال تخطيطها:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **ما يحتويه الشريحة الرئيسية**

الشريحة الرئيسية هي كائن شبيه بالشريحة. تنفذ الواجهة [IBaseSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/) ، لذا فهي تعرض العديد من خصائص الشرائح نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. يتم سرد الأعضاء الخاصة بالشرائح الرئيسية في صفحة API الخاصة بـ [IMasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/) .

الأعضاء الشائعة المستخدمة في الشريحة الرئيسية تشمل:

| عضو | الغرض |
| --- | --- |
| `Background` | يحدد خلفية الشريحة على مستوى الشريحة الرئيسية. |
| `Shapes` | يخزن الأشكال الموضوعة على الشريحة الرئيسية، مثل الشعارات، إطارات الصور، والنص المشترك. |
| `LayoutSlides` | يخزن شرائح التخطيط التي تنتمي إلى الشريحة الرئيسية. |
| `ThemeManager` | يوفر الوصول إلى واجهات برمجة تطبيقات سمة الشريحة الرئيسية. |
| `HeaderFooterManager` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للشريحة الرئيسية وتخطيطاتها الفرعية. |
| `GetDependingSlides` | يرجع الشرائح العادية التي تعتمد على الشريحة الرئيسية عبر تخطيطاتها. |

## **إضافة صورة إلى الشريحة الرئيسية**

عند إضافة صورة إلى شريحة رئيسية، تظهر في الشرائح التي تستخدم تخطيطات من تلك الشريحة. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، وغيرها من العناصر البصرية المتكررة.

المثال التالي يضيف شعارًا إلى الشريحة الرئيسية الأولى:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

لمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/slides/ar/net/picture-frame/) .

## **التحكم في رؤية الرسومات الرئيسية**

استخدم [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/showmastershapes/) لإخفاء الرسومات الموروثة من الشريحة الرئيسية، مثل الشعارات أو الأشكال الزخرفية، دون حذفها من الشريحة الرئيسية. اضبط [Slide.ShowMasterShapes](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/showmastershapes/) على `false` في الشريحة التي يجب أن تستبعد تلك الرسومات واتركه `true` في الشرائح التي يجب أن تعرضها.

المثال المستقل التالي ينشئ شريطًا زخرفيًا أزرق على الشريحة الرئيسية وشرائحتين تستخدمان نفس التخطيط الفارغ. يكون الشريط مرئيًا في الشريحة الأولى ومخفيًا في الشريحة الثانية. لا يلزم أي عرض تقديمي أو صورة كمدخل.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

يستخدم المثال التخطيط **Blank** المرفق مع عرض تقديمي جديد ويزيل العناصر النائبة الخاصة بالشريحة الأولية.

### **اختر نطاق الإعداد**

تستخدم الشريحة العادية رئيسها عبر [ISlide.LayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/layoutslide/) و[ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/masterslide/) . ضبط الخاصية على شريحة فردية يؤثر فقط على تلك الشريحة. ضبط [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutslide/showmastershapes/) على `false` يخفي رسومات الشريحة الرئيسية للشرائح التي تستخدم ذلك التخطيط المشترك، حتى لو كان إعدادها الخاص `true`. لإخفاء الرسومات في شريحة واحدة فقط، غيّر خاصية الشريحة واترك التخطيط المشترك دون تغيير.

الإعداد غير مدعوم كتحكم في الرؤية على الشريحة الرئيسية نفسها. على الشريحة الرئيسية يعيد دائمًا `false`، وتعيين `true` يثير `NotSupportedException`. استخدمه على شريحة عادية أو تخطيط بدلاً من ذلك.

### **التمييز بين الرسومات والخلفية**

| العملية | التأثير |
| --- | --- |
| إخفاء رسومات الشريحة الرئيسية | يتحكم في رؤية الأشكال الموروثة من الشريحة الرئيسية دون حذفها أو تغيير أشكال الشريحة الخاصة. |
| تغيير تعبئة خلفية الشريحة | يغير لون الخلفية أو التدرج أو الصورة. رسومات الشريحة الرئيسية هي أشكال منفصلة ويمكن أن تبقى مرئية فوق تلك الخلفية. راجع [Presentation Background](/slides/ar/net/presentation-background/). |
| حذف شكل من الشريحة الرئيسية | يزيل الشكل المصدر المشترك، بحيث لا يكون متاحًا لأي شريحة تستخدم تلك الشريحة الرئيسية. |

## **العمل مع العناصر النائبة**

عادةً ما تُعرّف العناصر النائبة على شرائح التخطيط. توفر الشريحة الرئيسية النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي العناصر النائبة متاحة وأين توضع.

في PowerPoint، تكون أوامر العناصر النائبة متاحة في عرض الشريحة الرئيسية.

![أمر إدراج عنصر نائبي في عرض الشريحة الرئيسية في PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى الشريحة الرئيسية:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على شريحة رئيسية. المثال التالي يبحث عن عنصر عنوان نائبي ويطبق تعبئة تدرج خطية:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![عنصر عنوان نائبي منسق يتم وراثته من الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [Set Prompt Text in Placeholder](/slides/ar/net/manage-placeholder/) و[Text Formatting](/slides/ar/net/text-formatting/) .

## **تغيير خلفية الشريحة الرئيسية**

تُورّث خلفية الشريحة الرئيسية من قبل التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يحدد لون خلفية صلبة للشريحة الرئيسية الأولى:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

لمواضيع ذات صلة، راجع [Presentation Background](/slides/ar/net/presentation-background/) و[Presentation Theme](/slides/ar/net/presentation-theme/) .

## **استنساخ شريحة رئيسية إلى عرض تقديمي آخر**

استخدم [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/) لنسخ شريحة رئيسية إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الشريحة المنسوخة من قبل التخطيطات والشرائح في العرض الهدف.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع رئيسها، راجع [Clone Slides](/slides/ar/net/clone-slides/) .

## **إضافة عدة شرائح رئيسية**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب الأقسام المختلفة علامات تجارية مختلفة أو هيكل صفحة أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة الشرائح الرئيسية](slide-master_9.jpg)

المثال التالي يستنسخ الشريحة الرئيسية الافتراضية، يمنح النسخة المستنسخة خلفية مختلفة، ينشئ تخطيطًا تحت تلك الشريحة المستنسخة، ويضيف شريحة جديدة تستند إلى ذلك التخطيط:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **مقارنة الشرائح الرئيسية**

يمكن مقارنة الشرائح الرئيسية باستخدام طريقة `Equals` الموروثة من [IBaseSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/) . تقوم المقارنة بفحص البنية والمحتوى الثابت، مثل الأشكال والنص والتنسيق والرسوم المتحركة وإعدادات الشريحة الأخرى. لا تقارن المعرفات الفريدة، مثل معرفات الشرائح، أو قيم العناصر النائبة الديناميكية، مثل التاريخ الحالي.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

لمزيد من المعلومات، راجع [Compare Presentation Slides](/slides/ar/net/compare-slides/) .

## **تعيين عرض الشريحة الرئيسية كالعرض الافتراضي**

استخدم خاصية `LastView` على [ViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتح PowerPoint أولًا. المثال التالي يفتح العرض التقديمي في طريقة عرض الشريحة الرئيسية:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

لمزيد من إعدادات العرض، راجع [Save Presentation](/slides/ar/net/save-presentation/) .

## **إزالة الشرائح الرئيسية غير المستخدمة**

أحيانًا يحتوي العروض التقديمية على شرائح رئيسية لم تعد تُستخدم من قبل أي شرائح عادية. إزالة الشرائح الرئيسية غير المستخدمة يمكن أن يقلل من حجم الملف ويسهل صيانة القالب.

استخدم [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/ar/net/aspose.slides/masterslidecollection/removeunused/) لإزالة الشرائح الرئيسية غير المستخدمة من مجموعة `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

يمكنك أيضًا استخدام طريقة منخفضة الكود [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **الأسئلة المتكررة**

**ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

الشريحة الرئيسية تحدد إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى شريحة رئيسية وتحدد ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم شريحة تخطيط، لذا فإنها ترث من كلٍ من التخطيط والشريحة الرئيسية.

**هل يمكن لعرض تقديمي واحد أن يحتوي على عدة شرائح رئيسية؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. استخدم عدة شرائح رئيسية عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب أن أضيف عناصر نائبة إلى الشريحة الرئيسية أم شريحة التخطيط؟**

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على الشريحة الرئيسية، ثم ضع عناصر النائب للمحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكنني حذف شريحة رئيسية لا تزال مستخدمة؟**

لا. لا يمكن حذف شريحة رئيسية لديها شرائح معتمدة بأمان مباشرةً. عليك أولاً نقل تلك الشرائح إلى تخطيطات تحت شريحة رئيسية أخرى، أو استخدام طريقة تنظيف للشرائح الرئيسية غير المستخدمة التي تزيل فقط الشرائح التي لا تُستعمل.