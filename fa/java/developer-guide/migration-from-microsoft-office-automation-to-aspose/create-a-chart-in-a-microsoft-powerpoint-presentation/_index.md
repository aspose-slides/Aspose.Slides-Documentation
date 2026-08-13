---
title: ایجاد نمودارها با استفاده از VSTO و Aspose.Slides برای جاوا
linktitle: ایجاد نمودار
type: docs
weight: 70
url: /fa/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- ایجاد نمودار
- مهاجرت
- VSTO
- اتوماسیون اداری
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه ایجاد نمودار PowerPoint را در جاوا خودکار کنید. این راهنمای گام‌به‌گام نشان می‌دهد چرا Aspose.Slides برای جاوا یک جایگزین سریع‌تر و قدرتمندتر برای Microsoft.Office.Interop است."
---
{{% alert color="info" %}} 
نمودارها نمایه‌های بصری داده‌ها هستند که به‌طور گسترده‌ای در ارائه‌ها استفاده می‌شوند. این مقاله کد ایجاد یک نمودار در Microsoft PowerPoint را به‌صورت برنامه‌نویسی با استفاده از [VSTO](/slides/fa/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) و [Aspose.Slides for Java](/slides/fa/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) نشان می‌دهد.
{{% /alert %}} 
## **ایجاد نمودار**
مثال‌های کد زیر فرایند افزودن یک نمودار ستون خوشه‌ای سه‌بعدی ساده با استفاده از VSTO را توصیف می‌کنند. شما یک نمونه از ارائه Microsoft PowerPoint ایجاد می‌کنید، یک نمودار پیش‌فرض به آن اضافه می‌کنید. سپس از کتاب‌کار Microsoft Excel برای دسترسی و اصلاح داده‌های نمودار به‌همراه تنظیم ویژگی‌های نمودار استفاده می‌کنید. در نهایت، ارائه را ذخیره می‌کنید.
### **مثال VSTO**
با استفاده از VSTO، گام‌های زیر انجام می‌شوند:
1. یک نمونه از ارائه Microsoft PowerPoint ایجاد کنید.
1. یک اسلاید خالی به ارائه اضافه کنید.
1. یک نمودار **ستون خوشه‌ای سه‌بعدی** اضافه کنید و به آن دسترسی پیدا کنید.
1. یک نمونه جدید از Microsoft Excel Workbook ایجاد کنید و داده‌های نمودار را بارگذاری کنید.
1. با استفاده از نمونه Microsoft Excel Workbook، به ورق کار داده‌های نمودار دسترسی پیدا کنید instancefromworkbook.
1. بازه نمودار را در ورق کار تنظیم کنید و سری‌های ۲ و ۳ را از نمودار حذف کنید.
1. داده‌های دسته‌بندی نمودار را در ورق کار داده‌های نمودار اصلاح کنید.
1. داده‌های سری ۱ نمودار را در ورق کار داده‌های نمودار اصلاح کنید.
1. اکنون، به عنوان نمودار دسترسی پیدا کنید و setthefontrelatedproperties را تنظیم کنید.
1. به محور مقدار نمودار دسترسی پیدا کنید و واحد اصلی، واحدهای جزئی، مقدار حداکثر و مقدار حداقل را تنظیم کنید.
1. به عمق نمودار یا محور سری دسترسی پیدا کنید و همان‌طور که در این مثال است، onlyoneserieisused را حذف کنید.
1. اکنون، زوایای چرخش نمودار را در جهت X و Y تنظیم کنید.
1. ارائه را ذخیره کنید.
1. نمونه‌های Microsoft Excel و PowerPoint را ببندید.
**ارائه خروجی، ایجاد شده با VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **مثال Aspose.Slides for Java**
با استفاده از Aspose.Slides for Java، گام‌های زیر انجام می‌شوند:
1. یک نمونه از ارائه Microsoft PowerPoint ایجاد کنید.
1. یک اسلاید خالی به ارائه اضافه کنید.
1. یک نمودار **ستون خوشه‌ای سه‌بعدی** اضافه کنید و به آن دسترسی پیدا کنید.
1. با استفاده از نمونه Microsoft Excel Workbook، به ورق کار داده‌های نمودار دسترسی پیدا کنید instancefromworkbook.
1. سری‌های استفاده نشده ۲ و ۳ را حذف کنید.
1. دسته‌بندی‌های نمودار را دسترسی پیدا کنید و برچسب‌ها را اصلاح کنید.
1. Accesseries1 را دسترسی پیدا کنید و مقادیر سری را اصلاح کنید.
1. اکنون، به عنوان نمودار دسترسی پیدا کنید و ویژگی‌های قلم را تنظیم کنید.
1. به محور مقدار نمودار دسترسی پیدا کنید و واحد اصلی، واحدهای جزئی، مقدار حداکثر و مقدار حداقل را تنظیم کنید.
1. اکنون، زوایای چرخش نمودار را در جهت X و Y تنظیم کنید.
1. ارائه را به فرمت PPTX ذخیره کنید.
**ارائه خروجی، ایجاد شده با Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **سوالات متداول**
### آیا می‌توانم انواع دیگری از نمودارها مانند نمودار دایره‌ای، خطی یا میله‌ای را با Aspose.Slides ایجاد کنم؟
بله. Aspose.Slides از طیف وسیعی از [انواع نمودار](/slides/fa/java/create-chart/) پشتیبانی می‌کند، از جمله نمودارهای دایره‌ای، خطی، میله‌ای، پراکندگی، حبابی و غیره. می‌توانید نوع نمودار دلخواه را با استفاده از کلاس [ChartType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) هنگام افزودن نمودار مشخص کنید.
### آیا می‌توانم سبک‌ها یا تم‌های سفارشی را روی نمودار اعمال کنم؟
بله. می‌توانید ظاهر نمودار را به‌صورت کامل سفارشی‌سازی کنید، شامل رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط حاشیه، خطوط شبکه و چیدمان. با این حال، اعمال تم‌های Office دقیقا همان‌طور که در PowerPoint دیده می‌شود، نیاز به تنظیم دستی سبک‌های جداگانه دارد.
### آیا می‌توانم نمودار را به‌عنوان یک تصویر جداگانه از اسلاید خروجی بگیرم؟
بله، Aspose.Slides به شما امکان می‌دهد هر شکلی—including نمودارها—را به‌عنوان یک تصویر جداگانه (مانند PNG، JPEG) با استفاده از متد `getImage` روی [shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/) خروجی بگیرید.