---
title: صادرات نمودارهای ارائه با پایتون
linktitle: صادرات نمودار
type: docs
weight: 90
url: /fa/python-net/export-chart/
keywords:
- نمودار
- نمودار به تصویر
- نمودار به‌صورت تصویر
- استخراج تصویر نمودار
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای ارائه را با Aspose.Slides برای پایتون از طریق .NET صادر کنید، از قالب‌های PPT, PPTX و ODP پشتیبانی می‌کند و گزارش‌دهی را در هر جریان کاری ساده می‌سازد."
---
## **بررسی اجمالی**

Aspose.Slides به شما امکان می‌دهد یک نمودار را از یک ارائه به عنوان تصویر استخراج کنید. این مقاله نشان می‌دهد چگونه از یک نمودار تصویر دریافت کنید و آن را ذخیره کنید، که زمانی مفید است که نیاز به استفاده مجدد از تصاویر نمودار خارج از ارائهٔ PowerPoint داشته باشید.

## **دریافت تصویر نمودار**
Aspose.Slides for Python via .NET پشتیبانی از استخراج تصویر یک نمودار خاص را فراهم می‌کند. نمونهٔ زیر ارائه شده است.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **سوالات متداول**

**آیا می‌توانم یک نمودار را به‌جای تصویر رستر به‌صورت برداری (SVG) صادر کنم؟**

بله. یک نمودار یک شکل است و محتوای آن می‌تواند با استفاده از [روش ذخیره‌سازی shape-to-SVG](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/write_as_svg/) به SVG ذخیره شود.

**چگونه می‌توانم اندازه دقیق نمودار صادرشده را بر حسب پیکسل تنظیم کنم؟**

از overloadهای رندر تصویر استفاده کنید که به شما امکان تعیین اندازه یا مقیاس را می‌دهند—کتابخانه از رندر اشیاء با ابعاد/مقیاس مشخص پشتیبانی می‌کند.

**اگر قلم‌های برچسب‌ها و افسانه پس از صادرات نادرست به‌نظر برسند، باید چه کار کنم؟**

[فونت‌های مورد نیاز را بارگذاری کنید](/slides/fa/python-net/custom-font/) از طریق [FontsLoader](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsloader/) تا رندر نمودار متریک‌ها و ظاهر متن را حفظ کند.

**آیا صادرات، تم، سبک‌ها و افکت‌های PowerPoint را رعایت می‌کند؟**

بله. رندرکنندهٔ Aspose.Slides قالب‌بندی ارائه (تم‌ها، سبک‌ها، پرکننده‌ها، افکت‌ها) را دنبال می‌کند، بنابراین ظاهر نمودار حفظ می‌شود.

**کجا می‌توانم قابلیت‌های رندر/صادرات موجود فراتر از تصاویر نمودار را پیدا کنم؟**

بخش صادرات [API](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/)/[مستندات](/slides/fa/python-net/convert-powerpoint/) را برای اهداف خروجی (مانند [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)، [SVG](/slides/fa/python-net/render-a-slide-as-an-svg-image/)، [XPS](/slides/fa/python-net/convert-powerpoint-to-xps/)، [HTML](/slides/fa/python-net/convert-powerpoint-to-html/)، و غیره) و گزینه‌های مربوط به رندر مشاهده کنید.