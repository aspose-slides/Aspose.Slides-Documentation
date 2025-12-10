---
title: تحسين حسابات المخطط للعروض التقديمية في C++
linktitle: حسابات المخطط
type: docs
weight: 50
url: /ar/cpp/chart-calculations/
keywords:
- حسابات المخطط
- عناصر المخطط
- موضع العنصر
- الموضع الفعلي
- عنصر فرعي
- عنصر أب
- قيم المخطط
- القيمة الفعلية
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "فهم حسابات المخطط، وتحديثات البيانات، والتحكم في الدقة في Aspose.Slides لـ C++ لملفات PPT و PPTX، مع أمثلة عملية لكود C++."
---

## **حساب القيم الفعلية لعناصر المخطط**
توفر Aspose.Slides for C++ واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. سيساعدك ذلك على حساب القيم الفعلية لعناصر المخطط. تشمل القيم الفعلية موضع العناصر التي تنفذ واجهة IActualLayout (IActualLayout::get_ActualX()، IActualLayout::get_ActualY()، IActualLayout::get_ActualWidth()، IActualLayout::get_ActualHeight()) والقيم الفعلية للمحاور (IAxis::get_ActualMaxValue()، IAxis::get_ActualMinValue()، IAxis::get_ActualMajorUnit()، IAxis::get_ActualMinorUnit()، IAxis::get_ActualMajorUnitScale()، IAxis::get_ActualMinorUnitScale()).
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


## **حساب الموضع الفعلي لعناصر المخطط الأب**
توفر Aspose.Slides for C++ واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر طرق IActualLayout معلومات حول الموضع الفعلي لعنصر المخطط الأب. من الضروري استدعاء الطريقة IChart::ValidateChartLayout() مسبقًا لملء الخصائص بالقيم الفعلية.
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


## **إخفاء عناصر المخطط**
يساعدك هذا الموضوع على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for C++ يمكنك إخفاء **العنوان، المحور العمودي، المحور الأفقي** و **خطوط الشبكة** من المخطط. يوضح المثال البرمجي أدناه كيفية استخدام هذه الخصائص.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **تعيين نطاق بيانات للمخطط**
قدمت Aspose.Slides for C++ أبسط واجهة برمجة تطبيقات لتعيين نطاق البيانات للمخطط بأبسط طريقة. لتعيين نطاق البيانات للمخطط:

- فتح مثال من فئة Presentation تحتوي على مخطط.
- الحصول على مرجع الشريحة باستخدام مؤشرها.
- التنقل عبر جميع الأشكال للعثور على المخطط المطلوب.
- الوصول إلى بيانات المخطط وتعيين النطاق.
- حفظ العرض التقديمي المعدل كملف PPTX.

الأمثلة البرمجية التالية توضح كيفية تحديث المخطط.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **الأسئلة المتكررة**

**هل تعمل دفاتر عمل Excel الخارجية كمصدر للبيانات، وكيف يؤثر ذلك على إعادة الحساب؟**

نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عندما تقوم بالاتصال أو تحديث المصدر الخارجي، يتم جلب الصيغ والقيم من ذلك الدفتر، ويعكس المخطط التحديثات أثناء عمليات الفتح/التحرير. تتيح لك الواجهة برمجة التطبيقات [تحديد دفتر العمل الخارجي](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) والمسار وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**

نعم. يتم إضافة [خطوط الاتجاه](/slides/ar/cpp/trend-line/) (الخطية، الأسية وغيرها) وتحديثها بواسطة Aspose.Slides؛ تُعاد حساب معلماتها تلقائيًا من بيانات السلسلة، لذا لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان هناك عرض تقديمي يحتوي على مخططات متعددة بروابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**

نعم. يمكن لكل مخطط الإشارة إلى [دفتر عمل خارجي](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) خاص به، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.