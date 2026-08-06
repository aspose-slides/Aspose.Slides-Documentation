---
title: Aspose.Slides برای Python از طریق .NET
second_title: Aspose.Slides برای Python
type: docs
weight: 35
url: /fa/python-net/
is_root: true
keywords:
- Aspose.Slides برای Python
- اتوماتیک‌سازی PowerPoint با Python
- کتابخانه PPT برای Python
- تبدیل PowerPoint به PDF با Python
- تبدیل PowerPoint به SVG با Python
- ویرایش PowerPoint در Python
- PowerPoint Python بدون Microsoft Office
- مدیریت PPTX با Python
- پیش‌نمایش اسلایدها با Python
- افزودن صدا به اسلایدها با Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides برای Python از طریق .NET مجموعه کاملی از ویژگی‌ها را ارائه می‌دهد که شامل مدیریت متن، اشکال، جداول و انیمیشن‌ها، افزودن صدا و ویدئو به اسلایدها، پیش‌نمایش اسلایدها و خروجی به SVG، PDF و موارد دیگر است."
---
{{% alert color="primary" %}}

**به Aspose.Slides برای Python از طریق .NET خوش آمدید**

![آرم محصول Aspose.Slides برای Python از طریق .NET](aspose_slides-for-python.png)

Aspose.Slides برای Python از طریق .NET کتابخانه‌ای قدرتمند است که به برنامه‌های شما امکان خواندن و نوشتن ارائه‌های PowerPoint® را بدون نیاز به Microsoft PowerPoint® می‌دهد.  
این اولین و تنها مؤلفه‌ای است که مدیریت کامل اسناد PowerPoint® را برای توسعه‌دهندگان Python فراهم می‌کند.  
Aspose.Slides برای Python از طریق .NET شامل مجموعه گسترده‌ای از ویژگی‌ها مانند کار با متن، اشکال، جداول و انیمیشن‌ها؛ افزودن صدا و ویدئو؛ پیش‌نمایش اسلایدها؛ و استخراج اسلایدها به قالب‌هایی مانند SVG، PDF و موارد دیگر است.

{{% /alert %}}

## نصب Aspose.Slides برای Python از طریق .NET

```bash
pip install aspose.slides
```

این بسته زمان اجرا (runtime) .NET مورد نیاز خود را به‌همراه دارد، بنابراین نیازی به نصب چیز دیگری نیست و Microsoft PowerPoint نیز لازم نیست. Python 3.7 یا بالاتر بر روی Windows، Linux یا macOS.

## ایجاد یک ارائه PowerPoint در Python

این مثال یک ارائه ایجاد می‌کند، یک شکل با متن را به اسلاید اول اضافه می‌کند و نتیجه را به‌صورت PPTX و PDF ذخیره می‌نماید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

اجرای آن فایل‌های `presentation.pptx` (حدود ۳۴ کیلوبایت) و `presentation.pdf` (حدود ۳۶ کیلوبایت) را در مسیر کاری می‌نویسد.  
بدون لایسنس، کتابخانه در حالت ارزیابی اجرا می‌شود که یک واترمارک اضافه می‌کند و تعداد اسلایدها را محدود می‌سازد. برای اعمال لایسنس، به بخش [Licensing](/slides/fa/python-net/licensing/) مراجعه کنید.

## منابع Aspose.Slides برای Python از طریق .NET

این منابع مفید را بررسی کنید:

- [مستندات آنلاین Aspose.Slides برای Python از طریق .NET](/slides/fa/python-net/)
- [امکانات Aspose.Slides برای Python از طریق .NET](/slides/fa/python-net/features-overview/)
- [یادداشت‌های انتشار Aspose.Slides برای Python از طریق .NET](https://releases.aspose.com/slides/fa/python-net/release-notes/)
- [صفحه محصول Aspose.Slides برای Python از طریق .NET](https://products.aspose.com/slides/fa/python-net/)
- [دانلود Aspose.Slides برای Python از طریق .NET](https://releases.aspose.com/slides/fa/python-net/)
- [نصب بسته PyPi Aspose.Slides برای Python از طریق .NET](https://pypi.org/project/aspose.slides/)
- [راهنمای مرجع API Aspose.Slides برای Python از طریق .NET](https://reference.aspose.com/slides/fa/python-net/)
- [انجمن پشتیبانی رایگان Aspose.Slides برای Python از طریق .NET](https://forum.aspose.com/c/slides/fa/11)
- [پشتیبانی تجاری Aspose.Slides برای Python از طریق .NET](https://helpdesk.aspose.com/)

## سؤالات متداول

### Aspose.Slides برای Python از طریق .NET چیست؟

Aspose.Slides برای Python از طریق .NET یک کتابخانه قدرتمند Python است که به شما امکان ایجاد، ویرایش و تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP) را به‌صورت برنامه‌نویسی بدون نیاز به نصب Microsoft PowerPoint می‌دهد.

### چه ویژگی‌های ارائه‌ای را Aspose.Slides پشتیبانی می‌کند؟

این کتابخانه از مدیریت متن، اشکال، جداول، نمودارها، انیمیشن‌ها، اسلایدهای اصلی، صدا، ویدئو و موارد دیگر پشتیبانی می‌کند. همچنین پیش‌نمایش اسلاید، رندرینگ، چاپ و استخراج به قالب‌هایی مانند PDF، SVG، HTML و تصاویر را فراهم می‌آورد.

### آیا می‌توانم ارائه‌ها را به قالب‌های دیگر با استفاده از Aspose.Slides تبدیل کنم؟

بله. Aspose.Slides امکان تبدیل فایل‌های PowerPoint به PDF، SVG، HTML، JPG، PNG، TIFF و سایر قالب‌ها را با دقت و عملکرد بالا فراهم می‌کند.

### آیا برای استفاده از Aspose.Slides نیاز به Microsoft PowerPoint است؟

خیر. Aspose.Slides یک API مستقل است و نیازی به Microsoft Office یا هر نرم‌افزار شخص ثالثی ندارد.

### کدام پلتفرم‌ها توسط Aspose.Slides برای Python از طریق .NET پشتیبانی می‌شوند؟

این کتابخانه چندپلتفرمی بوده و بر روی محیط‌های Windows، Linux و macOS کار می‌کند.

### چگونه می‌توانم با Aspose.Slides برای Python شروع کنم؟

شما می‌توانید آن را از طریق PyPi نصب کنید و برای شروع با مثال‌ها، مراجع API و آموزش‌ها، [راهنمای توسعه‌دهنده](/slides/fa/python-net/developer-guide/) را بررسی کنید.