---
title: مخطط
type: docs
weight: 60
url: /ar/net/examples/elements/chart/
keywords:
- مثال مخطط
- إضافة مخطط
- الوصول إلى مخطط
- إزالة مخطط
- تحديث مخطط
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في C# باستخدام Aspose.Slides: إضافة بيانات، تنسيق السلاسل، المحاور والتسميات، تغيير الأنواع، وتصدير—يعمل مع PPT و PPTX و ODP."
---

أمثلة على الإضافة والوصول والإزالة وتحديث أنواع المخططات المختلفة باستخدام **Aspose.Slides for .NET**. توضح المقاطع البرمجية أدناه عمليات المخطط الأساسية.

## **إضافة مخطط**

تضيف هذه الطريقة مخطط منطقة بسيط إلى الشريحة الأولى.
```csharp
static void Add_Chart()
{
    using var pres = new Presentation();

    // أضف مخطط عمودي بسيط إلى الشريحة الأولى
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```


## **الوصول إلى مخطط**

بعد إنشاء المخطط، يمكنك استرجاعه عبر مجموعة الأشكال.
```csharp
static void Access_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // الوصول إلى المخطط الأول في الشريحة
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```


## **إزالة مخطط**

يقوم الكود التالي بإزالة مخطط من شريحة.
```csharp
static void Remove_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // إزالة المخطط
    slide.Shapes.Remove(chart);
}
```


## **تحديث بيانات المخطط**

يمكنك تغيير خصائص المخطط مثل العنوان.
```csharp
static void Update_Chart_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // تغيير عنوان المخطط
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
