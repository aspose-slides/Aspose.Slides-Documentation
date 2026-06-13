---
title: وارد کردن ارائه‌ها با پایتون
linktitle: وارد کردن ارائه
type: docs
weight: 60
url: /fa/python-net/import-presentation/
keywords:
- وارد کردن پاورپوینت
- وارد کردن ارائه
- وارد کردن اسلاید
- PDF به ارائه
- PDF به PPT
- PDF به PPTX
- PDF به ODP
- HTML به ارائه
- HTML به PPT
- HTML به PPTX
- HTML به ODP
- پایتون
- Aspose.Slides
description: "به راحتی اسناد PDF و HTML را در پایتون با Aspose.Slides به ارائه‌های PowerPoint و OpenDocument وارد کنید برای پردازش اسلایدهای بدون درنگ و با عملکرد بالا."
---
## **مقدمه**

با [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/fa/python-net/)، می‌توانید محتوا را از فرمت‌های دیگر به یک ارائه وارد کنید. کلاس [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) روش‌هایی برای وارد کردن اسلایدها از PDF، HTML و سایر منابع فراهم می‌کند.

## **تبدیل PDF به ارائه**

این بخش نشان می‌دهد چگونه یک PDF را با استفاده از Aspose.Slides به یک ارائه تبدیل کنید. این راهنما شما را از وارد کردن PDF، تبدیل صفحات آن به اسلایدها و ذخیره نتیجه به‌عنوان فایل PPTX راهنمایی می‌کند.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بسازید.  
2. متد [add_from_pdf](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_from_pdf/) را فراخوانی کنید و فایل PDF را به آن پاس دهید.  
3. از متد [save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) برای ذخیره ارائه در قالب PowerPoint استفاده کنید.

مثال زیر به زبان Python تبدیل PDF به یک ارائه را نشان می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
ممکن است بخواهید برنامه وب **رایگان Aspose** [PDF to PowerPoint](https://products.aspose.app/slides/fa/import/pdf-to-powerpoint) را امتحان کنید—این یک پیاده‌سازی زنده از فرآیند توضیح داده شده در اینجا است.
{{% /alert %}}

## **تبدیل HTML به ارائه**

این بخش نشان می‌دهد چگونه محتوای HTML را با استفاده از Aspose.Slides به یک ارائه وارد کنید. این راهنما بارگذاری HTML، تبدیل آن به اسلایدها با حفظ متن، تصاویر و قالب‌بندی پایه‌ای را پوشش می‌دهد و نتیجه را به‌عنوان فایل PPTX ذخیره می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بسازید.  
2. متد [add_from_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_from_html/) را فراخوانی کنید و فایل HTML را به آن پاس دهید.  
3. از متد [save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) برای ذخیره ارائه در قالب PowerPoint استفاده کنید.

مثال زیر به زبان Python تبدیل HTML به یک ارائه را نشان می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا جداول هنگام وارد کردن PDF حفظ می‌شوند و آیا می‌توان تشخیص آن‌ها را بهبود داد؟**

جداول می‌توانند در طول واردسازی شناسایی شوند؛ [PdfImportOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.importing/pdfimportoptions/) شامل پارامتر [detect_tables](https://reference.aspose.com/slides/fa/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) است که امکان تشخیص جدول را فعال می‌کند. اثرگذاری آن به ساختار PDF بستگی دارد.

{{% alert title="Note" color="info" %}}
می‌توانید از Aspose.Slides برای تبدیل HTML به سایر فرمت‌های محبوب نیز استفاده کنید:

* [HTML به تصویر](https://products.aspose.com/slides/fa/python-net/conversion/html-to-image/)
* [HTML به JPG](https://products.aspose.com/slides/fa/python-net/conversion/html-to-jpg/)
* [HTML به XML](https://products.aspose.com/slides/fa/python-net/conversion/html-to-xml/)
* [HTML به TIFF](https://products.aspose.com/slides/fa/python-net/conversion/html-to-tiff/)

{{% /alert %}}