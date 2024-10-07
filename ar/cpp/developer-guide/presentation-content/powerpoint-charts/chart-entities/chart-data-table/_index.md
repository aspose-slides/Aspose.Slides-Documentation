---
title: جدول بيانات المخطط
type: docs
url: /cpp/chart-data-table/
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
تسمح Aspose.Slides لـ C++ بتغيير خصائص الخط لجدول بيانات المخطط.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. إضافة مخطط على الشريحة.
1. تعيين جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

فيما يلي مثال توضيحي.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```