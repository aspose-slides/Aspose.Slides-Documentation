---
title: منطقة رسم المخطط
type: docs
url: /cpp/chart-plot-area/
---

## **احصل على عرض وارتفاع منطقة رسم المخطط**
توفر Aspose.Slides لـ C++ واجهة برمجة تطبيقات بسيطة لـ.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. استدعاء دالة IChart::ValidateChartLayout() قبل الحصول على القيم الفعلية.
1. الحصول على الموقع الفعلي لـ X (اليسار) لعنصر المخطط بالنسبة للزاوية العلوية اليسرى من المخطط.
1. الحصول على الجزء العلوي الفعلي لعنصر المخطط بالنسبة للزاوية العلوية اليسرى من المخطط.
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
توفر Aspose.Slides لـ C++ واجهة برمجة تطبيقات بسيطة لتعيين وضع التخطيط لمنطقة رسم المخطط. تم إضافة خاصية **LayoutTargetType** إلى فئات **ChartPlotArea** و**IChartPlotArea**. إذا تم تعريف تخطيط منطقة الرسم يدويًا، فإن هذه الخاصية تحدد ما إذا كان يجب تخطيط منطقة الرسم من داخلها (دون تضمين المحاور وتسميات المحاور) أو من خارجها (بما في ذلك المحاور وتسميات المحاور). هناك قيمتان ممكنتان تم تعريفهما في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - تحدد أن حجم منطقة الرسم يجب أن يحدد حجم منطقة الرسم، دون تضمين علامات الت ticks وتسميات المحاور.
- **LayoutTargetType.Outer** - تحدد أن حجم منطقة الرسم يجب أن يحدد حجم منطقة الرسم، وعلامات الت ticks، وتسميات المحاور.

تم إعطاء نموذج الرمز أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}