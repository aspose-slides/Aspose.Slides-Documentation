---
title: افزودن مستطیل‌ها به ارائه‌ها در Python از طریق Java
linktitle: مستطیل
type: docs
weight: 80
url: /fa/python-java/rectangle/
keywords:
- افزودن مستطیل
- ایجاد مستطیل
- شکل مستطیل
- مستطیل ساده
- مستطیل قالب‌بندی‌شده
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "ارائه‌های PowerPoint خود را با افزودن مستطیل‌ها با Aspose.Slides برای Python از طریق Java تقویت کنید—به راحتی اشکال را به‌صورت برنامه‌نویسی طراحی و اصلاح کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه با استفاده از Aspose.Slides اشکال مستطیلی را به اسلایدهای PowerPoint اضافه کنید. این مقاله ایجاد یک مستطیل ساده، ایجاد یک مستطیل قالب‌بندی‌شده، و ذخیرهٔ ارائه به‌روز شده به صورت فایل PPTX را پوشش می‌دهد.

همچنین خواهید دید چگونه قالب‌بندی پایهٔ مستطیل، مانند رنگ پرشدن یکدست، رنگ خط و ضخامت خط را اعمال کنید. علاوه بر این، بخش پرسش‌های متداول مقاله به کارهای مرتبط با مستطیل اشاره می‌کند، از جمله گوشه‌های گرد، پرکردن با تصویر، جلوه‌های بصری، پیوندهای ابرمتنی، قفل‌کردن شکل، گزینه‌های صادرات و ویژگی‌های مؤثر.

## **اضافه کردن یک مستطیل به اسلاید**

برای اضافه کردن یک مستطیل ساده به اسلایدی انتخاب‌شده در ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- یک ارجاع به اسلاید را بر اساس ایندکس آن دریافت کنید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) از نوع مستطیل را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/) فراهم می‌شود، اضافه کنید.
- ارائهٔ تغییر یافته را به عنوان یک فایل PPTX بنویسید.

در مثال زیر، یک مستطیل ساده به اولین اسلاید ارائه اضافه شده است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# نمونه‌سازی کلاس Presentation که نشانگر فایل PPTX است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک شکل مستطیل.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # نوشتن فایل PPTX به دیسک.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اضافه کردن یک مستطیل قالب‌بندی‌شده به اسلاید**

برای اضافه کردن یک مستطیل قالب‌بندی‌شده به اسلاید، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- یک ارجاع به اسلاید را بر اساس ایندکس آن دریافت کنید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) از نوع مستطیل را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/) فراهم می‌شود، اضافه کنید.
- نوع [fill type](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/) مستطیل را به solid تنظیم کنید.
- رنگ مستطیل را با استفاده از متد [setColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/colorformat/#setColor) روی رنگ پرشدن یکدست شیء [FillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/) مرتبط با شیء [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) تنظیم کنید.
- رنگ خط مرزی مستطیل را تنظیم کنید.
- عرض خط مرزی مستطیل را تنظیم کنید.
- ارائهٔ تغییر یافته را به عنوان یک فایل PPTX بنویسید.

مراحل فوق در مثال زیر پیاده‌سازی شده‌اند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# نمونه‌سازی کلاس Presentation که نشانگر فایل PPTX است.
presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک شکل مستطیل.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # قالب‌بندی پرشدن مستطیل.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # قالب‌بندی خط مرزی مستطیل.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # نوشتن فایل PPTX به دیسک.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**چگونه یک مستطیل با گوشه‌های گرد اضافه کنم؟**

از نوع شکل [shape type](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapetype/) با گوشه‌های گرد استفاده کنید و شعاع گوشه‌ها را در ویژگی‌های شکل تنظیم کنید؛ گرد کردن می‌تواند به‌صورت جداگانه برای هر گوشه از طریق تنظیمات هندسی نیز اعمال شود.

**چگونه یک مستطیل را با تصویر (بافت) پر کنم؟**

نوع پرکردن تصویر [fill type](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/) را انتخاب کنید، منبع تصویر را ارائه دهید و حالت‌های کشیدن/کاشی [stretching/tiling modes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillmode/) را پیکربندی کنید.

**آیا می‌توان یک مستطیل را سایه‌دار و درخشان کرد؟**

بله. [سایهٔ بیرونی/درونی، درخشندگی و لبه‌های نرم](/slides/fa/python-java/shape-effect/) در دسترس هستند و می‌توان پارامترهای آن‌ها را تنظیم کرد.

**آیا می‌توانم مستطیل را به دکمه‌ای با پیوند ابرمتنی تبدیل کنم؟**

بله. می‌توانید [پیوند ابرمتنی](/slides/fa/python-java/manage-hyperlinks/) را به کلیک روی شکل اختصاص دهید (رفتن به اسلاید، فایل، آدرس وب یا ایمیل).

**چگونه می‌توانم از جابجایی و تغییرات مستطیل محافظت کنم؟**

از [قفل‌کردن شکل](/slides/fa/python-java/applying-protection-to-presentation/) استفاده کنید: می‌توانید جابجایی، تغییر اندازه، انتخاب یا ویرایش متن را ممنوع کنید تا طرح حفظ شود.

**آیا می‌توانم مستطیل را به تصویر راستری یا SVG تبدیل کنم؟**

بله. می‌توانید [شکل را رندر](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) کنید و به تصویر با اندازه/مقیاس مشخص تبدیل کنید یا آن را به صورت SVG [صادر](/slides/fa/python-java/create-shape-thumbnails/) کنید برای استفادهٔ برداری.

**چگونه می‌توانم به‌سرعت ویژگی‌های واقعی (effective) یک مستطیل را با در نظر گرفتن تم و ارث‌بری به‌دست آورم؟**

از [ویژگی‌های مؤثر شکل](/slides/fa/python-java/shape-effective-properties/) استفاده کنید: API مقادیر محاسبه‌شده‌ای را برمی‌گرداند که سبک‌های تم، لایه‌بندی و تنظیمات محلی را دربر می‌گیرد و تحلیل قالب‌بندی را ساده می‌کند.