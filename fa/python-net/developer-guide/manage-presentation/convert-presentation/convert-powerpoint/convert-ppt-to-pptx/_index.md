---
title: تبدیل PPT به PPTX در پایتون
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/python-net/convert-ppt-to-pptx/
keywords:
  - تبدیل PPT
  - PPT به PPTX
  - PowerPoint
  - ارائه
  - پایتون
  - Aspose.Slides
description: "پیشنهاد تبدیل ارائه‌های PPT قدیمی به PPTX مدرن به سرعت در پایتون با Aspose.Slides — آموزش واضح، نمونه کد رایگان، بدون نیاز به Microsoft Office."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه یک ارائهٔ PowerPoint با فرمت PPT را به فرمت PPTX تبدیل کنید با استفاده از Python و یک برنامهٔ آنلاین تبدیل PPT به PPTX. موضوع زیر پوشش داده شده است:

- تبدیل PPT به PPTX در Python

## **Python تبدیل PPT به PPTX**

برای مشاهدهٔ نمونه کد Python برای تبدیل PPT به PPTX، لطفاً به بخش زیر، یعنی [Convert PPT to PPTX](#convert-ppt-to-pptx) مراجعه کنید. این کد به سادگی فایل PPT را بارگذاری و در فرمت PPTX ذخیره می‌کند. با تعیین فرمت‌های ذخیرهٔ مختلف، می‌توانید فایل PPT را به بسیاری از فرمت‌های دیگر مانند PDF، XPS، ODP، HTML و غیره ذخیره کنید، همان‌طور که در این مقالات بحث شده است:

- [تبدیل PPT به PDF در Python](/slides/fa/python-net/convert-powerpoint-to-pdf/)
- [تبدیل PPT به XPS در Python](/slides/fa/python-net/convert-powerpoint-to-xps/)
- [تبدیل PPT به HTML در Python](/slides/fa/python-net/convert-powerpoint-to-html/)
- [تبدیل PPT به ODP در Python](/slides/fa/python-net/save-presentation/)
- [تبدیل PPT به PNG در Python](/slides/fa/python-net/convert-powerpoint-to-png/)

## **دربارهٔ تبدیل PPT به PPTX**

تبدیل فرمت قدیمی PPT به PPTX با Aspose.Slides API. اگر نیاز به تبدیل هزاران ارائهٔ PPT به فرمت PPTX دارید، بهترین راه‌حل انجام آن به صورت برنامه‌نویسی است. با Aspose.Slides API می‌توانید این کار را تنها در چند خط کد انجام دهید. این API سازگاری کامل برای تبدیل یک ارائهٔ PPT به PPTX فراهم می‌کند و امکان انجام کارهای زیر را دارد:

- تبدیل ساختارهای پیچیدهٔ مسترها، طرح‌بندی‌ها و اسلایدها.
- تبدیل ارائه‌ای با نمودارها.
- تبدیل ارائه‌ای با شکل‌های گروهی، اشکال خودکار (مانند مستطیل‌ها و بیضی‌ها) و اشکالی با هندسهٔ سفارشی.
- تبدیل ارائه‌ای که دارای بافت‌ها و سبک‌های پرکردن تصویر برای اشکال خودکار است.
- تبدیل ارائه‌ای با نگهدارنده‌ها، فریم‌های متن و نگه‌دارنده‌های متن.

{{% alert color="primary" %}}

به برنامهٔ [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) نگاهی بیندازید:

[](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx)

این برنامه بر پایه **Aspose.Slides API** ساخته شده است، بنابراین می‌توانید یک مثال زنده از قابلیت‌های تبدیل پایه‌ای PPT به PPTX را ببینید. Aspose.Slides Conversion یک برنامهٔ وب است که به شما امکان می‌دهد یک فایل ارائهٔ PPT را بارگذاری کرده و پس از تبدیل، به فرمت PPTX دانلود کنید.

نمونه‌های زندهٔ دیگر [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fa/conversion/) را بیابید.
{{% /alert %}}

## **تبدیل PPT به PPTX**
برای تبدیل یک PPT به PPTX، به سادگی نام فایل و فرمت ذخیره را به متد [**Save**](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) کلاس [**Presentation**](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) پاس دهید. نمونه کد Python زیر یک ارائهٔ PPT را با گزینه‌های پیش‌فرض به PPTX تبدیل می‌کند.

```python
import aspose.slides as slides

# یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل PPT است
pres = slides.Presentation("PPTtoPPTX.ppt")

# ارائه را در فرمت PPTX ذخیره می‌کند
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

برای اطلاعات بیشتر دربارهٔ فرمت‌های ارائهٔ [**PPT vs PPTX**](/slides/fa/python-net/ppt-vs-pptx/) و چگونگی [**پشتیبانی Aspose.Slides از تبدیل PPT به PPTX**](/slides/fa/python-net/convert-ppt-to-pptx/) مطالعه کنید.

## **سوالات متداول**

**فرق بین فرمت‌های PPT و PPTX چیست؟**

PPT فرمت باینری قدیمی مورد استفاده توسط Microsoft PowerPoint است، در حالی که PPTX فرمت مبتنی بر XML جدیدی است که از Microsoft Office 2007 معرفی شد. فایل‌های PPTX عملکرد بهتر، اندازهٔ فایل کمتر و بهبود بازیابی داده‌ها را ارائه می‌دهند.

**آیا می‌توانم PPT را به PPTX با Python تبدیل کنم؟**

بله، با استفاده از کتابخانهٔ Aspose.Slides for Python via .NET می‌توانید به راحتی یک فایل PPT را بارگذاری و در فرمت PPTX ذخیره کنید تنها با چند خط کد.

**آیا Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT به PPTX پشتیبانی می‌کند؟**

بله، می‌توانید از Aspose.Slides در یک حلقه برای تبدیل برنامه‌نویسی چندین فایل PPT به PPTX استفاده کنید، که این امکان را برای سناریوهای تبدیل دسته‌ای فراهم می‌آورد.

**آیا محتوا و قالب‌بندی پس از تبدیل حفظ می‌شوند؟**

Aspose.Slides وفاداری بالایی در تبدیل ارائه‌ها دارد. طرح‌بندی اسلایدها، انیمیشن‌ها، شکل‌ها، نمودارها و سایر عناصر طراحی در طول تبدیل PPT به PPTX حفظ می‌شوند.

**آیا می‌توانم فرمت‌های دیگری مانند PDF یا HTML را از فایل‌های PPT تبدیل کنم؟**

بله، Aspose.Slides از تبدیل فایل‌های PPT به فرمت‌های متعدد شامل PDF، XPS، HTML، ODP و فرمت‌های تصویری مانند PNG و JPEG پشتیبانی می‌کند.

**آیا امکان تبدیل PPT به PPTX بدون نصب Microsoft PowerPoint وجود دارد؟**

بله، Aspose.Slides for Python via .NET یک API مستقل است و نیازی به Microsoft PowerPoint یا هر نرم‌افزار ثالث دیگری برای انجام تبدیل ندارد.

**آیا ابزار آنلاین برای تبدیل PPT به PPTX موجود است؟**

بله، می‌توانید از برنامهٔ وب رایگان [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) برای انجام تبدیل مستقیم در مرورگر خود بدون نوشتن کد استفاده کنید.