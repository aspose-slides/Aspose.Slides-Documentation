---
title: نمودار
type: docs
weight: 60
url: /fa/cpp/examples/elements/chart/
keywords:
- مثال کد
- نمودار
- پاورپوینت
- سند باز
- ارائه
- C++
- Aspose.Slides
description: "نمودارها را با Aspose.Slides برای C++ به‌طور کامل فراگیرید: ایجاد، قالب‌بندی، اتصال داده‌ها و صادر کردن نمودارها در قالب‌های PPT، PPTX و ODP با مثال‌های C++."
---
مثال‌هایی برای افزودن، دسترسی، حذف و به‌روزرسانی انواع مختلف نمودار با **Aspose.Slides for C++**. قطعه‌کدهای زیر عملیات پایه‌ای نمودار را نشان می‌دهند.

## **افزودن یک نمودار**

این متد یک نمودار منطقه‌ای ساده را به اسلاید اول اضافه می‌کند.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // یک نمودار ناحیه ساده به اسلاید اول اضافه کنید.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **دسترسی به یک نمودار**

پس از ایجاد یک نمودار، می‌توانید آن را از طریق مجموعه اشکال بازیابی کنید.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // دسترسی به اولین نمودار در اسلاید.
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

## **حذف یک نمودار**

کد زیر یک نمودار را از اسلاید حذف می‌کند.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // نمودار را حذف کنید.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **به‌روزرسانی داده‌های نمودار**

می‌توانید ویژگی‌های نمودار مانند عنوان را تغییر دهید.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // عنوان نمودار را تغییر دهید.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```