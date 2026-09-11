---
title: مدیریت گرافیک‌های SmartArt در ارائه‌ها با استفاده از Python
linktitle: گرافیک‌های SmartArt
type: docs
weight: 20
url: /fa/python-java/manage-smartart-shape/
keywords:
- شیء SmartArt
- گرافیک SmartArt
- سبک SmartArt
- رنگ SmartArt
- ایجاد SmartArt
- اضافه کردن SmartArt
- ویرایش SmartArt
- تغییر SmartArt
- دسترسی به SmartArt
- نوع طرح SmartArt
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ایجاد، ویرایش و استایل‌دهی خودکار SmartArt در PowerPoint با استفاده از Python و Aspose.Slides، شامل مثال‌های کد مختصر و راهنمایی‌های متمرکز بر عملکرد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد گرافیک‌های SmartArt را به‌صورت برنامه‌نویسی در ارائه‌های PowerPoint ایجاد و مدیریت کنید. این مقاله توضیح می‌دهد چگونه یک شکل SmartArt را به اسلاید اضافه کنید، به شکل‌های SmartArt موجود دسترسی پیدا کنید، SmartArt را بر اساس نوع طرح خاص پیدا کنید و ظاهر بصری آن را با تغییر سبک SmartArt یا سبک رنگی به‌روز کنید.

مثال‌ها نشان می‌دهند چگونه با شکل‌های SmartArt از طریق مجموعه اشکال اسلاید ارائه کار کنید، بررسی کنید آیا یک شکل SmartArt است و سپس ویژگی‌های آن را تغییر یا بررسی کنید.

## **ایجاد یک شکل SmartArt**

Aspose.Slides برای Python از طریق Java یک API برای ایجاد شکل‌های SmartArt فراهم می‌کند. برای ایجاد یک شکل SmartArt در یک اسلاید، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. [یک شکل SmartArt اضافه کنید](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addSmartArt) با مشخص کردن یک [SmartArtLayoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartlayouttype/).
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # دریافت اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک شکل SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # ذخیره ارائه.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شکل: شکل SmartArt اضافه شده به اسلاید**|

## **دسترسی به یک شکل SmartArt روی اسلاید**

مثال زیر به شکل‌های SmartArt روی اسلاید ارائه دسترسی پیدا می‌کند. این مثال بر روی هر شکل در اسلاید تکرار می‌کند و بررسی می‌کند آیا شکل یک نمونه [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # پیمایش تمام اشکال در اولین اسلاید.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **دسترسی به یک شکل SmartArt با نوع طرح خاص**

مثال زیر به یک شکل [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) با نوع طرح خاص دسترسی پیدا می‌کند که توسط [SmartArt.getLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/#getLayout) برگردانده می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که شامل یک شکل SmartArt است را بارگذاری کنید.
1. اولین اسلاید را بر اساس اندیس آن دریافت کنید.
1. بر روی هر شکل در اولین اسلاید تکرار کنید.
1. بررسی کنید آیا شکل یک نمونه [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.
1. بررسی کنید آیا شکل SmartArt دارای نوع طرح مشخص شده است و عملیات مورد نیاز را انجام دهید.

```python
import jpype
import asposeslides

if not jpame.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # پیمایش همه اشکال در اولین اسلاید.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # بررسی طرح SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **تغییر سبک شکل SmartArt**

این مثال نشان می‌دهد چگونه سبک سریع یک شکل SmartArt را تغییر دهید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که شامل یک شکل SmartArt است را بارگذاری کنید.
1. اولین اسلاید را بر اساس اندیس آن دریافت کنید.
1. بر روی هر شکل در اولین اسلاید تکرار کنید.
1. بررسی کنید آیا شکل یک نمونه [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.
1. شکل SmartArt با سبک مشخص‌شده را پیدا کنید.
1. سبک جدید را برای شکل SmartArt تنظیم کنید.
1. ارائه را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # پیمایش هر شکل در اولین اسلاید.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # بررسی و تغییر سبک SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شکل: شکل SmartArt با سبک تغییر یافته**|

## **تغییر سبک رنگی شکل SmartArt**

این مثال به یک شکل SmartArt با سبک رنگی خاص دسترسی پیدا می‌کند و آن سبک را تغییر می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که شامل یک شکل SmartArt است را بارگذاری کنید.
1. اولین اسلاید را بر اساس اندیس آن دریافت کنید.
1. بر روی هر شکل در اولین اسلاید تکرار کنید.
1. بررسی کنید آیا شکل یک نمونه [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.
1. شکل SmartArt با سبک رنگی مشخص‌شده را پیدا کنید.
1. سبک رنگی جدید را برای شکل SmartArt تنظیم کنید.
1. ارائه را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # پیمایش تمام اشکال در اولین اسلاید.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # بررسی و تغییر سبک SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**شکل: شکل SmartArt با سبک رنگی تغییر یافته**|

## **سوالات متداول**

**آیا می‌توانم SmartArt را به‌عنوان یک شیء واحد انیمیشن‌دهم؟**

بله. SmartArt یک شکل است، بنابراین می‌توانید [انیمیشن‌های استاندارد](/slides/fa/python-java/powerpoint-animation/) را از طریق API انیمیشن‌ها (ورودی، خروجی، تأکید، مسیرهای حرکتی) همانند سایر شکل‌ها اعمال کنید.

**اگر شناسه داخلی یک SmartArt را ندانم، چگونه می‌توانم یک SmartArt خاص را در اسلاید پیدا کنم؟**

متن جایگزین را تنظیم و استفاده کنید ([alternative text](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setAlternativeText)) و با آن مقدار شکل را جستجو کنید—این یک روش توصیه‌شده برای پیدا کردن شکل هدف است.

**آیا می‌توانم SmartArt را با سایر شکل‌ها گروه‌بندی کنم؟**

بله. می‌توانید SmartArt را با سایر شکل‌ها (تصاویر، جداول و غیره) گروه‌بندی کنید و سپس [گروه را دستکاری کنید](/slides/fa/python-java/group/).

**چگونه می‌توانم تصویر یک SmartArt خاص دریافت کنم (مثلاً برای پیش‌نمایش یا گزارش)؟**

یک تصویر/نماد کوچک از شکل را استخراج کنید؛ کتابخانه می‌تواند [شکل‌های جداگانه را رندر کند](/slides/fa/python-java/create-shape-thumbnails/) به فایل‌های رستر (PNG/JPG/TIFF).

**آیا ظاهر SmartArt هنگام تبدیل کل ارائه به PDF حفظ می‌شود؟**

بله. موتور رندرینگ برای [صادرات PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) با دقت بالا هدف‌گذاری می‌کند و مجموعه‌ای از گزینه‌های کیفیت و سازگاری را ارائه می‌دهد.