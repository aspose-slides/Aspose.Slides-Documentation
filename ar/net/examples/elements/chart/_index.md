---
title: مخطط
type: docs
weight: 60
url: /ar/net/examples/elements/chart/
keywords:
- مخطط
- إضافة مخطط
- الوصول إلى مخطط
- إزالة مخطط
- تحديث مخطط
- مثال على الشفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إجادة المخططات باستخدام Aspose.Slides لـ .NET: إنشاء، تنسيق، ربط البيانات، وتصدير المخططات بصيغ PPT و PPTX و ODP مع أمثلة بلغة C#."
---
أمثلة على إضافة، والوصول، وإزالة، وتحديث أنواع المخططات المختلفة باستخدام **Aspose.Slides for .NET**. يوضح المقاطع البرمجية أدناه عمليات المخطط الأساسية.

## **إضافة مخطط**

تضيف هذه الطريقة مخطط منطقة بسيط إلى الشريحة الأولى.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // أضف مخطط منطقة بسيط إلى الشريحة الأولى.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **الوصول إلى مخطط**

بعد إنشاء المخطط، يمكنك استرجاعه عبر مجموعة الأشكال.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // الوصول إلى المخطط الأول على الشريحة.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **إزالة مخطط**

يقوم الكود التالي بإزالة مخطط من الشريحة.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // إزالة المخطط.
    slide.Shapes.Remove(chart);
}
```

## **تحديث بيانات المخطط**

يمكنك تغيير خصائص المخطط مثل العنوان.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // تغيير عنوان المخطط.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```