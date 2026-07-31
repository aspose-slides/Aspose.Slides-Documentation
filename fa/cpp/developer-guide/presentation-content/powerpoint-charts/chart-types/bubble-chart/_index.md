---
title: سفارشی‌سازی نمودارهای حبابی در ارائه‌ها با استفاده از C++
linktitle: نمودار حبابی
type: docs
url: /fa/cpp/bubble-chart/
keywords:
- نمودار حبابی
- اندازه حباب
- مقیاس‌بندی اندازه
- نمایش اندازه
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نمودارهای حبابی قدرتمند را در PowerPoint با Aspose.Slides برای C++ ایجاد و سفارشی‌سازی کنید تا به‌راحتی تجسم داده‌های خود را ارتقا دهید."
---
## **Overview**

این مقاله نشان می‌دهد چگونه با نمودارهای حبابی در Aspose.Slides کار کنید. دو گزینه سفارشی‌سازی خاص را پوشش می‌دهد: مقیاس‌بندی اندازه حباب‌ها از طریق متد `set_BubbleSizeScale` و کنترل نحوه نمایش مقادیر اندازه حباب از طریق متد `set_BubbleSizeRepresentation`.

مثال‌ها نشان می‌دهند چگونه یک نمودار حبابی ایجاد کنید، مقیاس‌بندی اندازه آن را تنظیم کنید و نمایش اندازه حباب را به استفاده از عرض تغییر دهید. مقاله همچنین شامل بخش کوتاهی از پرسش‌های متداول است که پشتیبانی از نوع نمودار “Bubble with 3‑D” را روشن می‌کند، ذکر می‌کند محدودیت‌های عملی نمودار به عملکرد و نسخه هدف PowerPoint بستگی دارد، و توضیح می‌دهد خروجی ظاهر نمودار را از طریق موتور رندرینگ Aspose.Slides حفظ می‌کند.

## **Bubble Chart Size Scaling**

Aspose.Slides برای C++ پشتیبانی از مقیاس‌بندی اندازه نمودار حبابی را فراهم می‌کند. در Aspose.Slides برای **C++ IChartSeries.BubbleSizeScale** و **IChartSeriesGroup.BubbleSizeScale** ویژگی‌ها افزوده شده‌اند. نمونه مثال زیر ارائه می‌شود. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Represent Data as Bubble Chart Sizes**

متد جدید **get_BubbleSizeRepresentation()** به کلاس‌های **IChartSeries** و **ChartSeries** اضافه شده است. **BubbleSizeRepresentation** تعیین می‌کند مقادیر اندازه حباب در نمودار حبابی چگونه نمایش داده شوند. مقادیر ممکن عبارتند از: **BubbleSizeRepresentationType.Area** و **BubbleSizeRepresentationType.Width**. به همین ترتیب، شمارنده **BubbleSizeRepresentationType** برای مشخص کردن روش‌های ممکن نمایش داده‌ها به عنوان اندازه‌های نمودار حبابی افزوده شده است. کد نمونه در ادامه آورده شده است.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **پرسش‌های متداول**

**آیا نمودار “bubble chart with 3‑D effect” پشتیبانی می‌شود و چه تفاوتی با یک نمودار معمولی دارد؟**

بله. یک نوع نمودار جداگانه به نام “Bubble with 3‑D” وجود دارد. این نوع استایل‌دهی سه‌بعدی را به حباب‌ها اعمال می‌کند اما محور اضافی اضافه نمی‌کند؛ داده‌ها همچنان X‑Y‑S (اندازه) باقی می‌مانند. این نوع در شمارش‌گر [نوع نمودار](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/charttype/) موجود است.

**آیا محدودیتی در تعداد سِری‌ها و نقاط در یک نمودار حبابی وجود دارد؟**

در سطح API محدودیت سختی وجود ندارد؛ محدودیت‌ها توسط عملکرد و نسخه هدف PowerPoint تعیین می‌شوند. توصیه می‌شود تعداد نقاط را برای خوانایی و سرعت رندر معقول نگه دارید.

**خروجی (Export) چطور بر ظاهر نمودار حبابی (PDF، تصاویر) تاثیر می‌گذارد؟**

خروجی به فرمت‌های پشتیبانی‌شده ظاهر نمودار را حفظ می‌کند؛ رندرینگ توسط موتور Aspose.Slides انجام می‌شود. برای فرمت‌های رستر/وبکتور، قوانین کلی رندرینگ گرافیک نمودار اعمال می‌شود (رزولوشن، ضد لبه‌دار کردن)، بنابراین برای چاپ DPI کافی انتخاب کنید.