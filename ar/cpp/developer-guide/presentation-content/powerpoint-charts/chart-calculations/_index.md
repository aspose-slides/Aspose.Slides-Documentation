---
title: حسابات المخطط
type: docs
weight: 50
url: /cpp/chart-calculations/
---

## **حساب القيم الفعلية لعناصر المخطط**
توفر Aspose.Slides لـ C++ واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. سيساعدك ذلك على حساب القيم الفعلية لعناصر المخطط. تشمل القيم الفعلية موضع العناصر التي تنفذ واجهة IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) والقيم الفعلية للمحاور (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// حفظ العرض التقديمي
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **حساب الموضع الفعلي لعناصر المخطط الأم**
توفر Aspose.Slides لـ C++ واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر طرق IActualLayout معلومات حول الموضع الفعلي لعنصر المخطط الأم. من الضروري استدعاء طريقة IChart::ValidateChartLayout() مسبقًا لملء الخصائص بالقيم الفعلية.

``` cpp
// إنشاء عرض تقديمي فارغ
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **إخفاء المعلومات من المخطط**
تساعدك هذه الموضوع على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides لـ C++ يمكنك إخفاء **العنوان، المحور العمودي، المحور الأفقي** و**خطوط الشبكة** من المخطط. المثال البرمجي أدناه يوضح كيفية استخدام هذه الخصائص.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **تعيين نطاق البيانات للمخطط**
قدمت Aspose.Slides لـ C++ أبسط واجهة برمجة تطبيقات لتعيين نطاق البيانات للمخطط بأبسط طريقة. لتعيين نطاق البيانات للمخطط:

- افتح مثيل من فئة Presentation التي تحتوي على المخطط.
- احصل على مرجع الشريحة باستخدام فهرسها.
- مر عبر جميع الأشكال للعثور على المخطط المطلوب.
- الوصول إلى بيانات المخطط وتعيين النطاق.
- حفظ العرض التقديمي المعدل كملف PPTX.

المثال البرمجي الذي يتبع يوضح كيفية تحديث المخطط.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}