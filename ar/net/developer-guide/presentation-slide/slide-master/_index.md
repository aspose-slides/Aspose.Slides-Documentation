---
title: إدارة ماسترات شرائح العرض التقديمي في .NET
linktitle: ماستر الشريحة
type: docs
weight: 80
url: /ar/net/slide-master/
keywords:
- ماستر الشريحة
- شريحة ماستر
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح ماستر
- خلفية
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
description: "إدارة ماسترات الشرائح في Aspose.Slides لـ .NET: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة شرائح ماستر في عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

يحدد **slide master** إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن يحتوي على أشكال مشتركة، شعارات، خلفيات، أنماط نص، إعدادات موضوع، وإعدادات تذييل. في PowerPoint، يُعد تعديل slide master الطريقة المعتادة للحفاظ على تناسق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

يدعم Aspose.Slides for .NET النموذج نفسه. يمكن للعرض التقديمي أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى الشريحة الرئيسية مباشرة. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتكون تلك الشريحة التخطيطية جزءًا من شريحة رئيسية.

التسلسل الهرمي هو:

1. **Slide master** - يحدد التصميم المشترك والموضوع.
1. **Layout slide** - يحدد ترتيبًا معينًا للعنصر النائب وتنسيق على مستوى التخطيط.
1. **Normal slide** - يحتوي على محتوى العرض الفعلي ويستخدم شريحة تخطيط واحدة.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

في Aspose.Slides، يتم تمثيل slide master بواجهة [IMasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/). جميع الشرائح الرئيسية في عرض تقديمي متاحة من خلال مجموعة [Presentation.Masters](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/masters/)، التي تُطبق [IMasterSlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، ينتصر المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة رئيسية وشريحة تخطيط خلفية، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/slides/ar/net/slide-layout/).
{{% /alert %}}

## **الوصول إلى Slide Masters**

في PowerPoint، يمكنك فتح عرض Slide Master من **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `Masters` للوصول إلى الشرائح الرئيسية:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

يمكنك أيضًا الحصول على الشريحة الرئيسية التي تستخدمها شريحة عادية من خلال تخطيطها:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **ما يحتويه Slide Master**

الشريحة الرئيسية هي كائن يشبه الشريحة. إنها تُطبق [IBaseSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/)، وبالتالي تُظهر العديد من خصائص الشرائح نفسها المستخدمة في الشرائح العادية وتخطيطات الشرائح. تُدرج الأعضاء الخاصة بالماستر في صفحة API الخاصة بـ [IMasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/).

من بين الأعضاء الشائعة الاستخدام في slide master:

| Member | Purpose |
| --- | --- |
| `Background` | يحدد خلفية الشريحة على مستوى الماستر. |
| `Shapes` | يخزن الأشكال الموضوعة على الماستر، مثل الشعارات، إطارات الصور، والنص المشترك. |
| `LayoutSlides` | يخزن شرائح التخطيط التي تنتمي إلى الماستر. |
| `ThemeManager` | يوفر الوصول إلى واجهات برمجة تطبيقات موضوع الماستر. |
| `HeaderFooterManager` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للماستر وتخطيطات الطفل. |
| `GetDependingSlides` | يُعيد الشرائح العادية التي تعتمد على الماستر عبر تخطيطاتها. |

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى شريحة رئيسية، تظهر هذه الصورة في الشرائح التي تستخدم التخطيطات من هذا الماستر. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، والعناصر المرئية المتكررة الأخرى.

المثال التالي يضيف شعارًا إلى أول شريحة رئيسية:

```csharp
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

لمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/slides/ar/net/picture-frame/).

## **العمل مع Placeholders**

عادةً ما تُعرَّف العنصر النائب في شرائح التخطيط. يوفر الماستر النمط والموضوع المشتركين الذين يرثهما تلك التخطيطات، بينما يقرر كل تخطيط أي العنصر النائب متاح وأين يُوضع.

في PowerPoint، تتوفر أوامر العنصر النائب في عرض Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

لإضافة عنصر نائب جديد باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى الماستر:

```csharp
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

يمكنك أيضًا تنسيق أشكال العنصر النائب الموجودة بالفعل في شريحة رئيسية. المثال التالي يجد عنصر نائب العنوان ويطبق تعبئة تدرجية خطية:

```csharp
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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

لمزيد من خيارات تنسيق العنصر النائب والنص، راجع [Set Prompt Text in Placeholder](/slides/ar/net/manage-placeholder/) و[Text Formatting](/slides/ar/net/text-formatting/).

## **تغيير خلفية Slide Master**

تُورّث خلفية الماستر إلى التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يحدد لون خلفية صلبة لأول شريحة رئيسية:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

للموضوعات ذات الصلة، راجع [Presentation Background](/slides/ar/net/presentation-background/) و[Presentation Theme](/slides/ar/net/presentation-theme/).

## **استنساخ Slide Master إلى عرض تقديمي آخر**

استخدم [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/) لنسخ شريحة رئيسية إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الماستر المنسوخ من قبل التخطيطات والشرائح في العرض الهدف.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع الماستر الخاص بها، راجع [Clone Slides](/slides/ar/net/clone-slides/).

## **إضافة عدة Slide Masters**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب الأقسام المختلفة علامات تجارية مختلفة أو هيكل صفحات أو إعدادات موضوع مختلفة.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

المثال التالي يستنسخ الماستر الافتراضي، يمنح النسخة المستنسخة خلفية مختلفة، ينشئ تخطيطًا تحت ذلك الماستر المستنسخ، ويضيف شريحة جديدة تعتمد على ذلك التخطيط:

```csharp
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

## **مقارنة Slide Masters**

يمكن مقارنة الشرائح الرئيسية باستخدام طريقة `Equals` الموروثة من [IBaseSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/). تتحقق المقارنة من الهيكل والمحتوى الثابت مثل الأشكال والنص والتنسيق والرسوم المتحركة وإعدادات الشريحة الأخرى. لا تتم مقارنة المعرفات الفريدة مثل معرفات الشرائح، أو قيم العنصر النائب الديناميكية مثل التاريخ الحالي.

```csharp
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

لمزيد من المعلومات، راجع [Compare Presentation Slides](/slides/ar/net/compare-slides/).

## **تعيين عرض Slide Master كالعرض الافتراضي**

استخدم الخاصية `LastView` على [ViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولاً. المثال التالي يفتح العرض التقديمي في عرض Slide Master:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

لمزيد من إعدادات العرض، راجع [Save Presentation](/slides/ar/net/save-presentation/).

## **إزالة Slide Masters غير المستخدمة**

أحيانًا تحتوي العروض التقديمية على شرائح رئيسية لم تعد تستخدمها أي شريحة عادية. يمكن أن يقلل إزالة الماسترات غير المستخدمة من حجم الملف ويبسط صيانة القالب.

استخدم [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/ar/net/aspose.slides/masterslidecollection/removeunused/) لإزالة الماسترات غير المستخدمة من مجموعة `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

يمكنك أيضًا استخدام طريقة الكود المنخفض [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**ما الفرق بين Slide Master و Layout Slide؟**

يحدد Slide Master إعدادات التصميم المشتركة مثل الموضوع، الخلفية، الأشكال الشائعة، وأنماط النص. تنتمي Layout Slide إلى Slide Master وتحدد ترتيبًا معينًا للعناصر النائبة. تستخدم الشريحة العادية Layout Slide، وبالتالي ترث من كل من التخطيط والماستر.

**هل يمكن لعرض تقديمي واحد أن يحتوي على عدة Slide Masters؟**

نعم. يمكن لعرض تقديمي أن يحتوي على عدة Slide Masters. استخدم عدة ماسترات عندما تحتاج الأقسام المختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى Slide Master أم إلى Layout Slide؟**

في معظم الحالات، أضف العناصر النائبة إلى Layout Slides. ضع العناصر البصرية المشتركة والتنسيقات المشتركة على Slide Master، ثم ضع عناصر النائب الخاصة بالمحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكن حذف Slide Master لا يزال مستخدمًا؟**

لا. لا يمكن حذف Slide Master يحتوي على شرائح依赖 مباشرة بأمان. يجب أولاً نقل تلك الشرائح إلى تخطيطات تحت ماستر آخر، أو استخدام طريقة تنظيف الماسترات غير المستخدمة التي تزيل فقط الماسترات التي لا تُستَخدم.