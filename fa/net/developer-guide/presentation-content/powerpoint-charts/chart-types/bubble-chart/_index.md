---
title: سفارشی‌سازی نمودارهای حبابی در ارائه‌ها در .NET
linktitle: نمودار حبابی
type: docs
url: /fa/net/bubble-chart/
keywords:
- نمودار حبابی
- اندازه حباب
- مقیاس‌گذاری اندازه
- نمایش اندازه
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نمودارهای حبابی قدرتمند را در PowerPoint با Aspose.Slides برای .NET ایجاد و سفارشی‌سازی کنید تا تجسم داده‌های خود را به آسانی ارتقا دهید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه با نمودارهای حبابی در Aspose.Slides کار کنید. دو گزینه سفارشی‌سازی خاص را پوشش می‌دهد: مقیاس‌گذاری اندازه‌های حباب از طریق ویژگی `BubbleSizeScale` و کنترل نحوه نمایش مقادیر اندازه حباب با ویژگی `BubbleSizeRepresentation`.

مثال‌ها نشان می‌دهند چگونه یک نمودار حبابی ایجاد کنید، مقیاس اندازه آن را تنظیم کنید و نمایش اندازه حباب را به استفاده از عرض تغییر دهید. مقاله همچنین شامل بخش کوتاهی از سؤالات متداول است که پشتیبانی از نوع نمودار «Bubble with 3‑D» را روشن می‌کند، اشاره می‌کند که محدودیت‌های عملی نمودار به عملکرد و نسخه هدف PowerPoint وابسته است، و توضیح می‌دهد که خروجی ظاهر نمودار را از طریق موتور رندر Aspose.Slides حفظ می‌کند.

## **مقیاس‌گذاری اندازه نمودار حبابی**

Aspose.Slides for .NET پشتیبانی از مقیاس‌گذاری اندازه نمودار حبابی را فراهم می‌کند. در Aspose.Slides for .NET ویژگی‌های **IChartSeries.BubbleSizeScale** و **IChartSeriesGroup.BubbleSizeScale** اضافه شده‌اند. نمونه کد زیر ارائه شده است.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **نمایش داده‌ها به‌عنوان اندازه‌های نمودار حبابی**

ویژگی **BubbleSizeRepresentation** به اینترفیس‌های IChartSeries، IChartSeriesGroup و کلاس‌های مرتبط اضافه شده است. **BubbleSizeRepresentation** تعیین می‌کند که مقادیر اندازه حباب در نمودار حبابی چگونه نشان داده شوند. مقادیر ممکن عبارتند از: **BubbleSizeRepresentationType.Area** و **BubbleSizeRepresentationType.Width**. بر این اساس، enum **BubbleSizeRepresentationType** برای مشخص کردن روش‌های ممکن نمایش داده‌ها به‌عنوان اندازه‌های نمودار حبابی اضافه شده است. نمونه کد در زیر آورده شده است.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا «نمودار حبابی با اثر سه‌بعدی» پشتیبانی می‌شود و چگونه با یک نمودار معمولی متفاوت است؟**

بله. یک نوع نمودار جداگانه به نام «Bubble with 3‑D» وجود دارد. این نوع استایل سه‌بعدی را بر روی حباب‌ها اعمال می‌کند اما محور اضافی اضافه نمی‌کند؛ داده‌ها همچنان به صورت X‑Y‑S (اندازه) باقی می‌مانند. این نوع در شمارشگر [chart type](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) موجود است.

**آیا محدودیتی برای تعداد سری‌ها و نقاط در یک نمودار حبابی وجود دارد؟**

در سطح API محدودیت سختی وجود ندارد؛ محدودیت‌ها توسط عملکرد و نسخه هدف PowerPoint تعیین می‌شوند. توصیه می‌شود تعداد نقاط را به‌گونه‌ای معقول نگه دارید تا خوانایی و سرعت رندر حفظ شود.

**خروجی (Export) چه تاثیری بر ظاهر یک نمودار حبابی (PDF، تصاویر) دارد؟**

خروجی به فرمت‌های پشتیبانی‌شده ظاهر نمودار را حفظ می‌کند؛ رندر توسط موتور Aspose.Slides انجام می‌شود. برای فرمت‌های رستری/وکتور، قوانین عمومی رندر نمودار (وضوح، ضد لبه‌زنی) اعمال می‌شود، بنابراین برای چاپ DPI کافی انتخاب کنید.