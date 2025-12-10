---
title: تخصيص مناطق رسم المخططات في العروض التقديمية بلغة С++
linktitle: منطقة الرسم
type: docs
url: /ar/cpp/chart-plot-area/
keywords:
- مخطط
- منطقة رسم
- عرض منطقة الرسم
- ارتفاع منطقة الرسم
- حجم منطقة الرسم
- وضع التخطيط
- PowerPoint
- عرض تقديمي
- С++
- Aspose.Slides
description: "اكتشف كيفية تخصيص مناطق رسم المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ С++. حسّن مظهر الشرائح بسهولة."
---

## **الحصول على العرض والارتفاع لمنطقة رسم المخطط**
توفر Aspose.Slides للـ C++ واجهة برمجة تطبيقات بسيطة لـ .

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. استدعاء الطريقة IChart::ValidateChartLayout() قبل الحصول على القيم الفعلية.
1. الحصول على الموقع الفعلي للمحور X (اليسار) لعنصر المخطط بالنسبة إلى الزاوية العلوية اليسرى للمخطط.
1. الحصول على الموضع العلوي الفعلي لعنصر المخطط بالنسبة إلى الزاوية العلوية اليسرى للمخطط.
1. الحصول على العرض الفعلي لعنصر المخطط.
1. الحصول على الارتفاع الفعلي لعنصر المخطط.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// حفظ العرض التقديمي مع المخطط
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **تعيين وضع تخطيط منطقة رسم المخطط**
توفر Aspose.Slides للـ C++ واجهة برمجة تطبيقات بسيطة لتعيين وضع تخطيط منطقة رسم المخطط. تم إضافة الخاصية **LayoutTargetType** إلى فئتي **ChartPlotArea** و **IChartPlotArea**. إذا تم تعريف تخطيط منطقة الرسم يدويًا، تحدد هذه الخاصية ما إذا كان سيتم تخطيط المنطقة من داخلها (بدون المحاور وعناوين المحاور) أو من خارجها (مع المحاور وعناوين المحاور). هناك قيمتان ممكنتان معرفتان في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم منطقة الرسم سيحدد حجم المنطقة، دون تضمين العلامات والملصقات المحورية.
- **LayoutTargetType.Outer** - يحدد أن حجم منطقة الرسم سيحدد حجم المنطقة، والعلامات، وملصقات المحاور.

العينة البرمجية موضحة أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **الأسئلة المتكررة**

**بأي وحدات يتم إرجاع ActualX و ActualY و ActualWidth و ActualHeight؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف يختلف Plot Area عن Chart Area من حيث المحتوى؟**

Plot Area هو منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما Chart Area تشمل العناصر المحيطة (العنوان، المفتاح، إلخ). في المخططات ثلاثية الأبعاد، تشمل Plot Area أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم X و Y والعرض والارتفاع لمنطقة الرسم عندما يكون التخطيط يدويًا؟**

هي كسور (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم تعطيل التموقع التلقائي وتُستخدم الكسور التي تحددها.

**لماذا تغير موضع Plot Area بعد إضافة/تحريك المفتاح؟**

المفتاح يقع في منطقة المخطط خارج Plot Area لكنه يؤثر على التخطيط والمساحة المتاحة، لذا قد يتحرك Plot Area عندما يكون التموقع التلقائي مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)