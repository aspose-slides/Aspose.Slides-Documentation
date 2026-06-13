---
title: مدیریت بخش‌های متن در ارائه‌ها با پایتون
linktitle: بخش متن
type: docs
weight: 70
url: /fa/python-net/portion/
keywords:
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه بخش‌های متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET مدیریت کنید، کارایی و سفارشی‌سازی را ارتقا دهید."
---
## **معرفی**

یک بخش متن نمایانگر یک قطعه خاص از متن داخل یک پاراگراف است و به شما امکان می‌دهد که به طور مستقل از محتوای اطراف با آن قطعه کار کنید. در Aspose.Slides، بخش‌ها می‌توانند زمانی که نیاز به دریافت موقعیت یک قطعه متن دارید، قالب‌بندی تنها بخشی از یک پاراگراف را اعمال کنید، یا رفتار متن را در سطح جزئی‌تری کنترل کنید، استفاده شوند.

## **دریافت مختصات بخش‌های متن**

متد [get_coordinates](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/get_coordinates/) به کلاس [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) اضافه شده است که امکان بازیابی مختصات بخش‌های متن را فراهم می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **سوالات متداول**

**آیا می‌توانم یک پیوند (hyperlink) را فقط به بخشی از متن داخل یک پاراگراف واحد اعمال کنم؟**

بله، می‌توانید [assign a hyperlink](/slides/fa/python-net/manage-hyperlinks/) را به یک بخش جداگانه اختصاص دهید؛ فقط همان قطعه قابل کلیک خواهد بود و نه کل پاراگراف.

**نحوه کار ارث‌بری سبک چگونه است: یک Portion چه چیزی را بازنویسی می‌کند و چه چیزی از Paragraph/TextFrame گرفته می‌شود؟**

ویژگی‌های سطح Portion دارای الویت بالاترین هستند. اگر ویژگی‌ای بر روی [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) تنظیم نشده باشد، موتور آن را از [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) می‌گیرد؛ اگر در آنجا نیز تنظیم نشده باشد، از سبک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) یا [theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/theme/) گرفته می‌شود.

**اگر قلم (font) مشخص‌شده برای یک Portion در ماشین/سرور هدف موجود نباشد چه اتفاقی می‌افتد؟**

[Font substitution rules](/slides/fa/python-net/font-selection-sequence/) اعمال می‌شوند. متن ممکن است دوباره جریان پیدا کند: معیارها، تقسیم‌بندی واژه و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق مهم است.

**آیا می‌توانم شفافیت یا گرادیان پر متن خاص یک Portion را به‌صورت مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پرکردن و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) می‌توانند متفاوت از قطعات همسایه باشند.