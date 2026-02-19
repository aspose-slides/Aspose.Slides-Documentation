---
title: مخطط
type: docs
weight: 60
url: /ar/cpp/examples/elements/chart/
keywords:
- مثال على الكود
- مخطط
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرف على المخططات باستخدام Aspose.Slides for C++: إنشاء، تنسيق، ربط البيانات، وتصدير المخططات بتنسيقات PPT و PPTX و ODP مع أمثلة C++."
---
أمثلة لإضافة، والوصول، وإزالة، وتحديث أنواع مختلفة من المخططات باستخدام **Aspose.Slides for C++**. يوضح المقاطع البرمجية أدناه عمليات المخططات الأساسية.

## **إضافة مخطط**

تضيف هذه الطريقة مخطط منطقة بسيط إلى الشريحة الأولى.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // أضف مخطط منطقة بسيط إلى الشريحة الأولى.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **الوصول إلى مخطط**

بعد إنشاء مخطط، يمكنك استرجاعه عبر مجموعة الأشكال.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // الوصول إلى المخطط الأول على الشريحة.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **إزالة مخطط**

الشفرة التالية تقوم بإزالة مخطط من شريحة.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // إزالة المخطط.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **تحديث بيانات المخطط**

يمكنك تغيير خصائص المخطط مثل العنوان.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // تغيير عنوان المخطط.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```