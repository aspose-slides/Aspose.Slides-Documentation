---
title: دریافت محدوده بخش متن از ارائه‌ها در پایتون از طریق جاوا
linktitle: محدوده بخش
type: docs
weight: 47
url: /fa/python-java/portion-bounds/
keywords:
- محدوده بخش متن
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "با استفاده از Aspose.Slides برای پایتون از طریق جاوا، یاد بگیرید چگونه محدوده بخش متن را در ارائه‌های PowerPoint بازیابی کنید."
---
## **نمای کلی**

یک بخش متن نمایانگر یک قطعه خاص از متن داخل یک پاراگراف است و به شما امکان می‌دهد تا به‌صورت مستقل از محتوای اطراف بر روی آن قطعه کار کنید. در Aspose.Slides، می‌توانید از بخش‌ها زمانی استفاده کنید که نیاز به دریافت محدوده یک قطعه متن، اعمال قالب‌بندی فقط بر بخشی از یک پاراگراف، یا کنترل رفتار متن در سطح جزئی‌تری داشته باشید.

این مقاله نشان می‌دهد چگونه با استفاده از [Portion.getRect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getRect) مستطیل محدوده یک بخش را دریافت کنید. همچنین نشان می‌دهد چگونه با استفاده از [Portion.getCoordinates](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getCoordinates) مختصات شروع یک بخش را به دست آورید. به‌علاوه سناریوهای رایج مرتبط با بخش‌ها را برجسته می‌کند، مانند اعمال پیوند به یک قطعه متن واحد، درک چگونگی حل قالب‌بندی از طریق بخش، پاراگراف، فریم متن و وراثت تم، و مدیریت مواردی که یک فونت مشخص در دسترس نیست.

## **دریافت محدوده یک بخش متن**

از [Portion.getRect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getRect) برای دریافت مستطیل محدوده یک بخش متن استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **دریافت مختصات یک بخش متن**

از [Portion.getCoordinates](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getCoordinates) برای دریافت مختصات شروع یک بخش متن استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا می‌توانم یک پیوند را فقط به بخشی از متن در یک پاراگراف واحد اعمال کنم؟**

بله، می‌توانید [یک پیوند اختصاص دهید](/slides/fa/python-java/manage-hyperlinks/) به یک بخش منفرد؛ فقط آن قطعه قابل کلیک خواهد بود، نه کل پاراگراف.

**چگونه وراثت سبک کار می‌کند: یک بخش چه چیزی را بازنویسی می‌کند و چه چیزی از پاراگراف یا فریم متن گرفته می‌شود؟**

ویژگی‌های سطح بخش بالاترین اولویت را دارند. اگر ویژگی‌ای در [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) تنظیم نشده باشد، Aspose.Slides آن را از [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) می‌گیرد. اگر آنجا نیز تنظیم نشده باشد، Aspose.Slides از سبک [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) یا [theme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/theme/) استفاده می‌کند.

**اگر فونت مشخص‌شده برای یک بخش بر روی ماشین یا سرور هدف موجود نباشد چه اتفاقی می‌افتد؟**

قواعد جایگزینی فونت [Font substitution rules](/slides/fa/python-java/font-selection-sequence/) اعمال می‌شوند. متن ممکن است دوباره جریان یابد: معیارها، حذف هجایی و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق مهم است.

**آیا می‌توانم شفافیت پر کردن متن یا گرادیان مختص به بخش را به‌طور مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر کردن و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) می‌تواند با قطعات همسایه متفاوت باشد.