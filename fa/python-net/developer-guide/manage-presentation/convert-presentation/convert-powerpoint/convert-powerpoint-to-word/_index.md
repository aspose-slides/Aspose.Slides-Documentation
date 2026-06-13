---
title: تبدیل ارائه‌های PowerPoint به اسناد Word در Python
linktitle: PowerPoint به Word
type: docs
weight: 110
url: /fa/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint به DOCX
- OpenDocument به DOCX
- ارائه به DOCX
- اسلاید به DOCX
- PPT به DOCX
- PPTX به DOCX
- ODP به DOCX
- PowerPoint به DOC
- OpenDocument به DOC
- ارائه به DOC
- اسلاید به DOC
- PPT به DOC
- PPTX به DOC
- ODP به DOC
- PowerPoint به Word
- OpenDocument به Word
- ارائه به Word
- اسلاید به Word
- PPT به Word
- PPTX به Word
- ODP به Word
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- تبدیل ODP
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه به راحتی ارائه‌های PowerPoint و OpenDocument را به اسناد Word تبدیل کنید با استفاده از Aspose.Slides for Python via .NET. راهنمای گام به گام ما به همراه مثال کد Python راه‌حل را برای توسعه‌دهندگانی که به دنبال بهینه‌سازی جریان کار اسناد خود هستند، فراهم می‌کند."
---
## **بررسی کلی**

این مقاله راه‌حلی برای توسعه‌دهندگان جهت تبدیل ارائه‌های PowerPoint و OpenDocument به سندهای Word با استفاده از Aspose.Slides for Python via .NET و Aspose.Words for Python via .NET ارائه می‌دهد. راهنمای گام‌به‌گام شما را در تمام مراحل فرآیند تبدیل همراهی می‌کند.

## **تبدیل یک ارائه به سند Word**

دستورالعمل‌های زیر را برای تبدیل یک ارائه PowerPoint یا OpenDocument به سند Word دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و فایل ارائه را بارگذاری کنید.
2. کلاس‌های [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) و [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) را برای تولید یک سند Word ایجاد کنید.
3. با استفاده از ویژگی [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) اندازه صفحه سند Word را برابر با اندازه صفحه ارائه تنظیم کنید.
4. با استفاده از ویژگی [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) حاشیه‌های سند Word را تنظیم کنید.
5. از ویژگی [Presentation.slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) برای مرور تمام اسلایدهای ارائه استفاده کنید.
    - با استفاده از متد `get_image` کلاس [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) یک تصویر اسلاید تولید کنید و آن را در یک جریان حافظه ذخیره کنید.
    - با استفاده از متد `insert_image` کلاس [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) تصویر اسلاید را به سند Word اضافه کنید.
6. سند Word را در یک فایل ذخیره کنید.

فرض کنید یک ارائه به نام «sample.pptx» داریم که به شکل زیر است:

![ارائه PowerPoint](PowerPoint.png)

```py
import aspose.slides as slides
import aspose.words as words

# بارگذاری یک فایل ارائه.
with slides.Presentation("sample.pptx") as presentation:

    # ایجاد اشیای Document و DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # تنظیم اندازه صفحه در سند Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # تنظیم حاشیه‌ها در سند Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # مرور تمام اسلایدهای ارائه.
    for slide in presentation.slides:

        # تولید تصویر اسلاید و ذخیره آن در یک جریان حافظه.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # افزودن تصویر اسلاید به سند Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # ذخیره سند Word در یک فایل.
    document.save("output.docx")
```

نتیجه:

![سند Word](Word.png)

{{% alert color="primary" %}} 
از [**Online PPT to Word Converter**](https://products.aspose.app/slides/fa/conversion/ppt-to-word) ما استفاده کنید تا ببینید با تبدیل ارائه‌های PowerPoint و OpenDocument به سندهای Word چه مزایایی می‌توانید به‌دست آورید. 
{{% /alert %}}

## **سوالات متداول**

**برای تبدیل ارائه‌های PowerPoint و OpenDocument به سندهای Word، چه کامپوننت‌هایی نیاز به نصب دارند؟**

تنها کافی است بسته‌های مربوطه برای [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) و [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) را به پروژهٔ Python خود اضافه کنید. هر دو بسته به‌عنوان APIهای مستقل عمل می‌کنند و نیازی به نصب Microsoft Office نیست.

**آیا تمام فرمت‌های ارائه PowerPoint و OpenDocument پشتیبانی می‌شوند؟**

Aspose.Slides for Python .NET [supports all presentation formats](/slides/fa/python-net/supported-file-formats/)، از جمله PPT، PPTX، ODP و سایر انواع فایل‌های رایج. این به شما امکان می‌دهد با ارائه‌های ساخته‌شده در نسخه‌های مختلف Microsoft PowerPoint کار کنید.