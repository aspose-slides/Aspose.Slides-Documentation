---
title: "اتوماسیون تولید پاورپوینت در پایتون: ایجاد ارائه‌های پویا به آسانی"
linktitle: اتوماسیون تولید پاورپوینت
type: docs
weight: 20
url: /fa/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- پلتفرم‌های ابری
- یکپارچه‌سازی ابری
- اتوماسیون تولید پاورپوینت
- ایجاد ارائه‌ها به‌صورت برنامه‌ای
- اتوماسیون پاورپوینت
- ایجاد اسلایدهای پویا
- گزارش‌های تجاری خودکار
- اتوماسیون PPT
- ارائه پایتون
- پایتون
- Aspose.Slides
description: "اتوماسیون تولید پاورپوینت با Aspose.Slides برای پایتون از طریق جاوا: ایجاد یک ارائه تجاری با نمودارها، جداول و نقاط بولت در برنامه‌های ابری."
---
## **مقدمه**

ایجاد ارائه‌ها به صورت دستی وقتی محتوای آن‌ها به‌طور مکرر تغییر می‌کند، کار تکراری می‌شود. گزارش‌های هفتگی، مطالب آموزشی و ارائه‌های مشتریان اغلب ساختار مشترکی دارند اما برای هر بار تحویل به داده‌های جدیدی نیاز دارند.

Aspose.Slides for Python via Java به شما این امکان را می‌دهد که این ارائه‌ها را از برنامه‌های Python تولید کنید. می‌توانید ایجاد اسلاید را در پورتال‌های وب، کارهای زمان‌بندی‌شده و سرویس‌های ابری، با استفاده از داده‌های استخراج‌شده از پایگاه داده‌ها، APIها یا فایل‌های بارگذاری‌شده، یکپارچه کنید.

## **موردهای استفاده رایج برای خودکارسازی PowerPoint در Python**

- **گزارش‌ها و داشبوردهای تجاری:** تبدیل ارقام فروش و معیارهای عملکرد به نمودارها و جداول.
- **ارائه‌های فروش شخصی‌سازی‌شده:** پر کردن اسلایدها با داده‌های مخصوص هر مشتری در حالی که طراحی یکسان باقی می‌ماند.
- **محتوای آموزشی:** ترکیب درس‌ها، آزمون‌ها و خلاصه‌های دوره از مطالب ساختاریافته.
- **بینش‌های مبتنی بر داده و هوش مصنوعی:** استفاده از نتایج تجزیه و تحلیل یا سرویس‌های پردازش زبان به عنوان محتوای ارائه.
- **اسلایدهای مبتنی بر رسانه:** ترکیب تصاویر یا اسکرین‌شات‌های بارگذاری‌شده با متن توضیحی.
- **گردش کار اسناد:** نقشه‌برداری محتوا استخراج‌شده توسط ابزارهای دیگر به طرح‌بندی‌های ارائه.
- **ابزارهای توسعه‌دهنده:** تولید خلاصه‌های انتشار، مرورهای فنی یا دموی‌ها از داده‌های پروژه.

## **پیش‌نیازها**

[نصب](/slides/fa/python-java/installation/) را برای تنظیم Python، Java، JPype و Aspose.Slides دنبال کنید. برای استقرار در ابر، همچنین به [Slides on Cloud Platforms](/slides/fa/python-java/slides-on-cloud-platforms/) مراجعه کنید.

این مثال از داده‌های تجاری ثابت استفاده می‌کند تا بدون نیاز به پایگاه داده یا سرویس خارجی قابل اجرا باشد. هنگام ادغام آن در جریان کاری گزارش، این مقادیر را با داده‌های برنامه خود جایگزین کنید.

{{% alert color="info" title="Note" %}}

می‌توانید مثال را بدون لایسنس امتحان کنید، اما خروجی ارزیابی شامل یک واترمارک است و تحت محدودیت‌های ارزیابی قرار می‌گیرد. برای جزئیات و اطلاعات لایسنس موقت، به [Evaluate Aspose.Slides](/slides/fa/python-java/evaluate-aspose-slides/) مراجعه کنید.

{{% /alert %}}

## **ساخت ارائه**

اسکریپت کامل زیر یک ارائه با چهار اسلاید ایجاد می‌کند. هر مرحله از همان ارائه استفاده می‌کند و در پایان آن را به صورت `presentation.pptx` ذخیره می‌کند.

### **ایجاد اسلاید عنوان**

از اسلاید اولیه در یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) جدید استفاده کنید و قالب عنوان را اعمال کنید. محتویات نگهدارنده‌های عنوان و زیرعنوان را با سرعنوان گزارش و مخاطب پر کنید.

![اسلاید عنوان](slide_0.png)

### **افزودن اسلاید با نمودار ستونی**

یک اسلاید خالی اضافه کنید و با استفاده از [ShapeCollection.addChart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addChart) یک نمودار ایجاد کنید. کتاب‌کار توکار آن را با پنج منطقه و یک سری فروش پر کنید. مقادیر در PowerPoint قابل ویرایش باقی می‌مانند.

![اسلاید با نمودار](slide_1.png)

### **افزودن اسلاید با جدول**

با استفاده از [ShapeCollection.addTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addTable) یک جدول ایجاد کنید و دو ستون را با نام‌های معیار و مقادیر پر کنید. مثال آرایه‌های Java صریح از اعداد double برای عرض ستون‌ها و ارتفاع ردیف‌ها را از طریق JPype می‌گذارد.

![اسلاید با جدول](slide_2.png)

### **افزودن اسلاید خلاصه با نکات بولت‌شده**

یک شکل متنی ایجاد کنید و برای هر مورد عملی یک [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) اضافه کنید. برای هر پاراگراف یک علامت بولت سمبولیک و متن سیاه اعمال کنید و پر و خطوط مرزی شکل را حذف کنید.

![اسلاید خلاصه](slide_3.png)

### **ذخیره ارائه**

از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای نوشتن فایل PowerPoint استفاده کنید. ارائه را با [Presentation.dispose](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#dispose) در یک بلوک `finally` آزاد کنید.

### **مثال کامل Python**

این اسکریپت را در یک پوشه قابل نوشتن ذخیره کنید و با محیط Python پیکربندی‌شده در بالا اجرا کنید. در صورت نیاز تنها JVM را راه‌اندازی می‌کند و تا پایان پردازش فعال می‌ماند. برای استفاده در نوت‌بوک و سرویس، به [JVM lifecycle guidance](/slides/fa/python-java/limitations-and-api-differences/#import-the-library) مراجعه کنید.

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # ایجاد اسلاید عنوان.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # افزودن اسلاید نمودار.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # افزودن اسلاید جدول.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # افزودن اسلاید خلاصه.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تصاویر مربوط به اسلایدهای معادل در مثال Java را نشان می‌دهند. ظاهر می‌تواند بسته به فونت‌های نصب‌شده و حالت ارزیابی متفاوت باشد.

## **استفاده از مثال در برنامه ابری**

داده‌های گزارش را پیش از ساخت ارائه دریافت کنید، سپس آن را به مراحل نمودار، جدول و تولید متن پاس کنید. برای هر کار مسیر خروجی جداگانه‌ای استفاده کنید. پس از ذخیره، برنامه شما می‌تواند فایل را به ذخیره‌ساز شیء بارگذاری یا به عنوان دانلود برگرداند.

JVM را در طول کارهای مختلف در همان فرآیند کارگر فعال نگه دارید و هر بار ارائه را پس از اتمام کار آزاد کنید. فونت‌های مورد نیاز طراحی گزارش خود را همراه با استقرار بسته‌بندی کنید تا تفاوت‌های محیطی کاهش یابد.

## **نتیجه‌گیری**

این مثال یک ارائه تجاری کامل را از Python تولید می‌کند که شامل نمودارها، جدول‌ها و متن‌های قابل ویرایش است. جایگزینی داده‌های نمونه با داده‌های برنامه، این روش را برای گزارش‌های دوره‌ای، ارائه‌های مشتری و مطالب آموزشی مفید می‌سازد.

## **سوالات متداول**

**آیا اسکریپت به Microsoft PowerPoint یا Excel نیاز دارد؟**

خیر. Aspose.Slides اسلایدها و کتاب‌کار توکار نمودار را بدون هیچ‌یک از این برنامه‌ها ایجاد می‌کند.

**چرا مثال جدول از آرایه‌های Java استفاده می‌کند؟**

متد پایه آرایه‌هایی از نوع Java double می‌پذیرد. استفاده صریح از آرایه‌ها نوع عددی عبوری از طریق JPype را واضح می‌سازد.

**آیا می‌توانم همان ارائه را به PDF یا ODP ذخیره کنم؟**

بله. پیش از آزاد کردن، با نام فایل خروجی دیگری و مقدار مربوط به [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) ذخیره کنید. برای قابلیت‌های خاص فرمت‌ها به [Supported File Formats](/slides/fa/python-java/supported-file-formats/) مراجعه کنید.

**آیا می‌توانم از یک قالب برند شده استفاده کنم؟**

بله. به جای ایجاد یک ارائه خالی، قالب خود را بارگذاری کنید، سپس طرح و انتخاب نگه‌دارنده‌ها را متناسب با آن قالب تنظیم کنید. نمونه فرض می‌کند طرح‌ها و ترتیب نگه‌دارنده‌ها همان یک ارائه پیش‌فرض جدید هستند.