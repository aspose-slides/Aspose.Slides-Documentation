---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في .NET
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/net/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تقسيم عمودي تلقائي
- عرض مفرد
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخدام Aspose.Slides for .NET لتكوين تخطيط العرض العادي، تكبير الشريحة والملاحظات، تباعد الشبكة، وإظهار التعليقات في عروض PowerPoint التقديمية."
---
## **المقدمة**

في طريقة العرض العادية لبرنامج PowerPoint، تظهر الشريحة بين لوحة جانبية للصور المصغرة أو المخطط ولوحة ملاحظات في الأسفل. تعرض Aspose.Slides for .NET تفضيلات التحرير المحفوظة للعرض التقديمي من خلال [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). تشمل هذه التفضيلات تخطيط اللوحات، مستويات التكبير، تباعد الشبكة، وإظهار التعليقات.

## **حول INormalViewProperties**

استخدم [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) للوصول إلى واجهة [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). يتحكم [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) فيما إذا كانت الأيقونات تظهر بجوار عناوين الشرائح في المخطط. يسمح [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) للوحة الجانبية بالانتقال إلى حالتها المصغرة عندما يقوم المستخدم بتقليل عرضها. يشير [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) إلى تفضيل عرض لوحة واحدة في النافذة الكاملة.

يتحكم [VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) في الفاصل بين اللوحة الجانبية والشريحة. يتحكم [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) في الفاصل فوق لوحة الملاحظات. كلاهما يقبل قيمة من نوع [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) وهي `Minimized` أو `Maximized` أو `Restored`.

## **حول استعادة INormalViewProperties**

عند استعادة الفاصل، يزود [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) بحجم اللوحة الجانبية المحفوظ و[RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) بحجم المنطقة العلوية للشريحة المحفوظ. كلاهما يكشف عن [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). خاصية [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) الخاصة به تقبل نسبة مئوية من 0 إلى 100، و[AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) يتحكم فيما إذا كان المحرر يضبط الحجم عند تغيير حجم النافذة.

يوضح هذا المثال كيفية تحديث عرض تقديمي موجود. يستعيد الفاصل الأفقي، يضبط [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) إلى 80٪ مع تمكين الضبط التلقائي، ويكبر الفاصل العمودي. كما يُمكّن [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) لعرض المخطط.
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **تعيين قيمة التكبير الافتراضية**

تخزن [SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) و[NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) إعدادات تكبير مستقلة للمحرر. هذه الإعدادات لا تؤثر على أبعاد الشرائح أو تشغيل العرض التقديمي أو دقة تصدير الصور.

يفتح هذا المثال عرضًا تقديميًا موجودًا ويُفعّل [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) لتلائم الشريحة نافذة التحرير. بالنسبة لصفحة الملاحظات، يتم تعطيل التكبير التلقائي وضبط [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) إلى تكبير ثابت بنسبة 80٪.
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **تعيين تباعد الشبكة**

يحدد [GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) المسافة بين خطوط الشبكة التحريرية في جميع أنحاء العرض التقديمي. يأخذ قيمة موجبة بالنقاط، حيث يوجد 72 نقطة لكل بوصة. يطبع هذا المثال التباعد الحالي في عرض تقديمي موجود ويحفظ شبكة ربع بوصة بضبط الفاصل إلى 18 نقطة.
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

تتكرر الشبكة على فاصل ثابت. [إرشادات الرسم](/slides/ar/net/drawing-guides/) تحدد المواقع الأفقية أو العمودية الفردية. كلاهما أدوات مساعدة للتحرير وتظهر فقط في المحررات التي تعرضها. لا تظهر في عروض الشرائح أو عند تصدير إلى PDF أو صور أو SVG.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

يخزن [ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) تفضيلًا تستخدمه المحررات المتوافقة عند فتح العرض التقديمي. بالنسبة لعرض تقديمي موجود يحتوي على تعليقات، يطبع هذا المثال الإعداد الحالي ويحفظ نسخة مع إخفاء التعليقات. كما يضبط [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) إلى [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) بحيث تفتح النسخة في عرض الشريحة.
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

إخفاء التعليقات يحافظ على نصها والمؤلفين والمواقع والردود والحالات. لتغيير التعليقات نفسها، راجع [تعليقات العرض التقديمي](/slides/ar/net/presentation-comments/). تتحكم إعدادات التصدير فيما إذا كانت التعليقات تظهر في PDF أو HTML أو صور أو ملاحظات أو ملخصات.

## **الأسئلة المتكررة**

**لماذا تكون الشبكة مخفية عند إعادة فتح العرض التقديمي؟**

يخزن العرض التقديمي فاصل الشبكة. لرؤية الشبكة، فعّل رؤية الشبكة في المحرر.

**هل يؤثر مسح إرشادات الرسم على تباعد الشبكة؟**

لا. إضافة أو نقل أو مسح دليل لا يغيّر فاصل الشبكة.

**هل يمكن لأقسام مختلفة من العرض التقديمي أن تكون لها إعدادات عرض مختلفة؟**

لا. يطبق [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) على كامل العرض التقديمي.

**هل يمكنني حفظ إعدادات عرض مختلفة لمستخدمين مختلفين؟**

الملف يخزن مجموعة واحدة من خصائص العرض للجميع. قد يطبق المحرر أيضًا تفضيلات المستخدم المحلية.

**هل يمكنني حفظ إعدادات العرض في قالب؟**

نعم. العروض التقديمية التي تُنشأ من القالب ترث إعدادات العرض المحفوظة.