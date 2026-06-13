---
title: مدیریت اشیاء قلم‌داد در ارائه‌ها با پایتون
linktitle: مدیریت قلم‌داد
type: docs
weight: 95
url: /fa/python-net/manage-ink/
keywords:
- قلم‌داد
- شیء قلم‌داد
- ردیاب قلم‌داد
- مدیریت قلم‌داد
- رسم قلم‌داد
- رسم
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "مدیریت اشیاء قلم‌داد PowerPoint — ایجاد، ویرایش و سبک‌گذاری قلم دیجیتال با Aspose.Slides برای Python از طریق .NET. دریافت نمونه‌های کد برای ردیاب‌ها، رنگ و اندازه براش."
---
## **مقدمه**

PowerPoint عملکرد قلم‌داد (ink) را فراهم می‌کند تا به شما امکان رسم اشکال غیر استاندارد را بدهد، که می‌توان از آن برای برجسته‌سازی اشیاء دیگر، نشان دادن ارتباطات و فرآیندها و جلب توجه به موارد خاص در یک اسلاید استفاده کرد.  

Aspose.Slides فضای نام [aspose.slides.ink](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ink/) را ارائه می‌دهد که شامل انواع مورد نیاز برای ایجاد و مدیریت اشیاء قلم‌داد است.  

## **تفاوت بین اشیاء معمولی و اشیاء قلم‌داد**

اشیاء روی اسلاید PowerPoint معمولاً توسط اشیاء شکل (shape) نشان داده می‌شوند. یک شیء شکل، در ساده‌ترین فرم خود، یک محفظه است که ناحیه خود شیء (قاب آن) را همراه با ویژگی‌هایش تعریف می‌کند. ویژگی‌ها شامل اندازه ناحیه محفظه، شکل محفظه، پس‌زمینه محفظه و غیره می‌شود. برای اطلاعات بیشتر، به [فرمت چیدمان شکل](https://docs.aspose.com/slides/fa/python-net/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.  

اما وقتی PowerPoint با یک شیء قلم‌داد سروکار دارد، تمام ویژگی‌های قاب شیء (محفظه) را به جز اندازه آن نادیده می‌گیرد. اندازه ناحیه محفظه توسط مقادیر استاندارد `width` و `height` تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیاب‌های Inkshape**

ردیاب (Trace) یک عنصر اساسی یا استاندارد برای ثبت مسیر قلم هنگامی که کاربر جوهر دیجیتال می‌نویسد، است. ردیاب‌ها ضبط‌هایی هستند که توالی نقطه‌های متصل را توصیف می‌کنند.  

ساده‌ترین شکل کدگذاری، مختصات X و Y هر نقطه نمونه را مشخص می‌کند. وقتی تمام نقاط متصل رندر شوند، تصویر زیر ساخته می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های براش برای رسم**

می‌توانید از یک براش برای رسم خطوطی که نقاط عناصر ردیاب را به‑هم وصل می‌کنند، استفاده کنید. براش رنگ و اندازه خاص خود را دارد که به ویژگی‌های `Brush.color` و `Brush.size` مربوط می‌شود.  

### **تنظیم رنگ براش قلم‌داد**

این کد پایتون نشان می‌دهد چگونه رنگ یک براش را تنظیم کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **تنظیم اندازه براش قلم‌داد** 

این کد پایتون نشان می‌دهد چگونه اندازه یک براش را تنظیم کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

به طور کلی، عرض و ارتفاع یک براش برابر نیستند، بنابراین PowerPoint اندازه براش را نمایش نمی‌دهد (بخش داده‌ها خاکستری می‌شود). اما وقتی عرض و ارتفاع براش برابر باشند، PowerPoint اندازه آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء قلم‌داد را افزایش داده و ابعاد مهم را مرور می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

محفظه (قاب) اندازه براش‌ها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر آخر نگاه کنید).  

بنابراین، برای تعیین ناحیه قابل مشاهده کل شیء قلم‌داد باید اندازه براش‌های اشیاء ردیاب را در نظر بگیریم. در اینجا، شیء هدف (شیء ردیاب متن دست‌نویس) به اندازه محفظه (قاب) مقیاس‌بندی شده است. وقتی اندازه محفظه (قاب) تغییر می‌کند، اندازه براش ثابت می‌ماند و بالعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint هنگام کار با متن‌ها رفتار مشابهی دارد:

![ink_powerpoint6](ink_powerpoint6.png)

**مطالعه بیشتر**

* برای آشنایی کلی با اشکال، بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/python-net/powerpoint-shapes/) را ببینید.  
* برای اطلاعات بیشتر درباره مقادیر مؤثر، به [ویژگی‌های مؤثر شکل](https://docs.aspose.com/slides/fa/python-net/shape-effective-properties/#get-effective-font-height-value) مراجعه کنید.