---
title: خروجی نمودارهای ارائه در Python از طریق Java
linktitle: صادر کردن نمودار
type: docs
weight: 90
url: /fa/python-java/export-chart/
keywords:
- نمودار
- نمودار به تصویر
- نمودار به عنوان تصویر
- استخراج تصویر نمودار
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای ارائه را با Aspose.Slides برای Python از طریق Java صادر کنید، از فرمت‌های PPT و PPTX پشتیبانی می‌کند و گزارش‌گیری را در هر جریان کاری ساده می‌سازد."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد یک نمودار را از یک ارائه به عنوان تصویر استخراج کنید. این مقاله نشان می‌دهد چطور از یک نمودار تصویر دریافت کرده و آن را ذخیره کنید، که وقتی نیاز به استفاده مجدد از جلوه‌های گرافیکی نمودار خارج از ارائه PowerPoint داشته باشید، مفید است.

علاوه بر گردش کار پایه‌ای خروجی تصویر، این مقاله به سوالات رایج مربوط به خروجی نیز می‌پردازد، از جمله ذخیرهٔ محتوای نمودار به SVG، کنترل اندازهٔ خروجی از طریق گزینه‌های رندرینگ، بارگذاری فونت‌ها برای حفظ ظاهر برچسب‌ها و افسانه، و نگه داشتن قالب‌بندی اصلی ارائه مانند تم‌ها، سبک‌ها، پرکننده‌ها و اثرات در طول رندرینگ.

## **دریافت تصویر نمودار**
Aspose.Slides برای Python از طریق Java از استخراج تصویر یک نمودار خاص پشتیبانی می‌کند. مثال زیر نشان می‌دهد چگونه این کار انجام شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم یک نمودار را به صورت برداری (SVG) به‌جای تصویر نقطه‌ای خروجی بگیرم؟**

بله. یک نمودار یک شکل است و محتویات آن می‌تواند با استفاده از [متد ذخیره‌سازی شکل به SVG](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#writeAsSvgToBytes) به SVG ذخیره شود.

**چگونه می‌توانم اندازهٔ دقیق نمودار خروجی را برحسب پیکسل تنظیم کنم؟**

از overloadهای رندرینگ تصویر که امکان تعیین اندازه یا مقیاس را می‌دهند استفاده کنید—کتابخانه از رندر کردن اشیا با ابعاد/مقیاس دلخواه پشتیبانی می‌کند.

**اگر پس از خروجی‌گیری فونت‌های برچسب‌ها و افسانه نادرست به نظر برسند، چه کاری باید انجام دهم؟**

[بارگذاری فونت‌های مورد نیاز](/slides/fa/python-java/custom-font/) از طریق [FontsLoader](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/) باعث می‌شود رندرینگ نمودار معیارها و ظاهر متن را حفظ کند.

**آیا خروجی‌گیری تم، سبک‌ها و اثرات PowerPoint را رعایت می‌کند؟**

بله. رندرر Aspose.Slides قالب‌بندی ارائه (تم‌ها، سبک‌ها، پرکننده‌ها، اثرات) را دنبال می‌کند، بنابراین ظاهر نمودار حفظ می‌شود.

**کجا می‌توانم قابلیت‌های رندرینگ/خروجی‌گیری موجود فراتر از تصاویر نمودار را پیدا کنم؟**

به [API](https://reference.aspose.com/slides/fa/python-java/aspose.slides/)/[مستندات](/slides/fa/python-java/convert-powerpoint/) برای اهداف خروجی مانند ([PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/fa/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/fa/python-java/convert-powerpoint-to-xps/), [HTML](/slides/fa/python-java/convert-powerpoint-to-html/), و غیره) و گزینه‌های رندرینگ مرتبط مراجعه کنید.