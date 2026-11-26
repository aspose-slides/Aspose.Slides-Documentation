---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها با Python
linktitle: ActiveX
type: docs
weight: 80
url: /fa/python-net/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- ویرایش ActiveX
- پخش‌کننده رسانه‌ای
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "جعبه‌های متن و دکمه‌های ActiveX را ویرایش کنید، پیش‌نمایش کنترل‌ها را به‌روز کنید و یک کنترل Windows Media Player را در ارائه‌های PowerPoint با Aspose.Slides برای Python از طریق .NET دوباره استفاده کنید."
---
## **مقدمه**

کنترل‌های ActiveX عناصر تعاملی مانند جعبه‌های متن، دکمه‌های فرمان و پخش‌کننده‌های رسانه‌ای را به یک اسلاید PowerPoint می‌دهند. Aspose.Slides برای Python از طریق .NET کنترل‌های یک اسلاید را از طریق [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/) در دسترس می‌گذارد. از این مجموعه برای ویرایش یک کنترل، جابجا کردن آن در اسلاید یا حذف آن استفاده کنید.

## **فهرست کنترل‌های ActiveX و ویژگی‌های ذخیره‌شده آن‌ها**

برای بررسی یک الگوی ناآشنا، آن را برای خواندن باز کنید و در هر اسلاید بر روی کنترل‌ها پیمایش کنید. مثال شماره اسلاید، نام کنترل، [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/) و هر جفت کلید‑مقدار در [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties) را گزارش می‌دهد. این کار ارائه را بدون فعال‌سازی کنترل‌ها، فراخوانی رویدادها یا ماکروها، تغییر مقادیر یا ذخیره فایل می‌خواند.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

خروجی انتخاب‌شده از `ActiveX.pptm` یک جعبه متن و یک دکمه فرمان را نشان می‌دهد.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

یک مجموعه ویژگی خالی به صورت `[]` نمایش داده می‌شود. برای کنترل‌هایی که از ذخیره‌سازی باینری استفاده می‌کنند، `properties` می‌تواند `None` برگرداند که به صورت `Properties unavailable` نمایش داده می‌شود. اگر فقط به نام‌ها نیاز دارید، پس از بررسی `None` از [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) استفاده کنید. گزارش ویژگی‌های موجود در ارائه را فهرست می‌کند. یک کنترل ممکن است ویژگی‌های اضافی در زمان اجرا داشته باشد.

## **تغییر کنترل‌های ActiveX**

مثال یک ارائه با ماکرو انتظار دارد که در اسلاید اول یک جعبه متن به نام `TextBox1` و یک دکمه فرمان به نام `CommandButton1` داشته باشد. برای تغییر مقدار جعبه متن و عنوان دکمه از [مجموعه ویژگی‌های کنترل](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) استفاده می‌شود. هر کنترل همچنین یک پیش‌نمایش ثابت دارد که PowerPoint می‌تواند قبل از فعال‌سازی نمایش دهد. برای هر کنترل یک تصویر PNG حاوی متن و ظاهر به‌روزشده فراهم کنید. مثال این تصاویر را از طریق [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/) اختصاص می‌دهد.

مثال تمام کنترل‌های اسلاید اول را با تغییر [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/) به سمت پایین ۱۰۰ نقطه جابه‌جا می‌کند. سپس ارائه ویرایش‌شده را در قالب PPTM ذخیره می‌کند و با استفاده از [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) یک نسخه دوم بدون هیچ کنترل ActiveX‌ای از همان اسلاید ذخیره می‌‌کند.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **افزودن کنترل پخش‌کننده رسانه‌ای ActiveX**

برای استفاده مجدد از یک کنترل Windows Media Player پیکربندی‌شده، با یک قالبی آغاز کنید که اسلاید اول آن شامل یک پخش‌کننده به نام `WindowsMediaPlayer1` باشد. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) کل اسلاید را به یک ارائه جدید کپی می‌کند. مثال آدرس `URL` پخش‌کننده را در [مجموعه ویژگی‌های کنترل](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) تنظیم می‌کند و اسلاید کپی‌شده را به‌عنوان تنها اسلاید خروجی ذخیره می‌نماید. ویدئو به‌صورت خارجی باقی می‌ماند، بنابراین مسیری را انتخاب کنید که پخش‌کننده در زمان پخش به آن دسترسی داشته باشد.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا Aspose.Slides می‌تواند کنترل‌های ActiveX را بدون اجرا کردن حفظ کند؟**

بله. Aspose.Slides می‌تواند کنترل‌ها را بخواند و ذخیره کند، از جمله ویژگی‌ها و موقعیت‌های آن‌ها، بدون اینکه آن‌ها را فعال کند.

**کنترل‌های ActiveX چه تفاوتی با شیء OLE دارند؟**

کنترل‌های ActiveX به کاربر اجازه می‌دهند با اسلاید تعامل داشته باشد، برای مثال با وارد کردن متن یا کلیک کردن روی یک دکمه. یک [شی OLE](/slides/fa/python-net/manage-ole/) اجازه می‌دهد یک اسلاید شامل محتوایی باشد یا به محتوایی که توسط برنامهٔ دیگری مدیریت می‌شود، مانند یک ورک‌شیت Excel، لینک بدهد.

**آیا پس از ذخیرهٔ ارائه با Aspose.Slides، رویدادهای ActiveX همچنان ماکروهای VBA را اجرا می‌کنند؟**

ارائه را در قالبی که ماکرو پشتیبانی می‌کند مانند PPTM ذخیره کنید تا پروژهٔ VBA حفظ شود. PowerPoint برای ویندوز می‌تواند هنگامیکه تنظیمات امنیتی اجازهٔ استفاده همزمان از کنترل‌های ActiveX و ماکروها را می‌دهد، هندلرهای رویداد موجود را اجرا کند.