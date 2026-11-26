---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها با استفاده از Python
linktitle: ActiveX
type: docs
weight: 80
url: /fa/python-java/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- تغییر ActiveX
- پخش‌کننده رسانه‌ای
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ویرایش جعبه‌های متن و دکمه‌های ActiveX، به‌روزرسانی پیش‌نمایش‌های کنترل، و استفاده مجدد از کنترل Windows Media Player در ارائه‌های PowerPoint با Aspose.Slides برای Python از طریق Java."
---
## **مقدمه**

کنترل‌های ActiveX عناصر تعاملی مانند جعبه‌های متن، دکمه‌های فرمان و پخش‌کننده‌های رسانه‌ای را به اسلاید PowerPoint می‌دهند. Aspose.Slides برای Python از طریق Java کنترل‌های یک اسلاید را از طریق [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls) نمایش می‌دهد. از این مجموعه برای ویرایش یک کنترل، جابجا کردن آن در اسلاید یا حذف آن استفاده کنید.

## **فهرست کنترل‌های ActiveX و خصوصیات ذخیره‌شده آن‌ها**

برای بررسی یک قالب ناشناخته، آن را برای خواندن باز کنید و روی کنترل‌های هر اسلاید تکرار کنید. مثال شماره اسلاید، نام کنترل، [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId) و هر جفت کلید-مقدار در [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) را گزارش می‌دهد. ارائه را بدون فعال‌سازی کنترل‌ها، فراخوانی رویدادها یا ماکروها، تغییر مقادیر یا ذخیره‌سازی فایل می‌خواند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
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

یک مجموعه ویژگی خالی به صورت `[]` ظاهر می‌شود. برای کنترل‌هایی که از ذخیره‌سازی باینری استفاده می‌کنند، [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) می‌تواند `None` برگرداند که به صورت `Properties unavailable` نمایش داده می‌شود. اگر فقط به نام‌ها نیاز دارید، پس از اطمینان از موجود بودن مجموعه، از [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) استفاده کنید. گزارش خصوصیات موجود در ارائه را فهرست می‌کند. یک کنترل ممکن است در زمان اجرا ویژگی‌های اضافی پشتیبانی کند.

## **تغییر کنترل‌های ActiveX**

این مثال انتظار یک ارائه‌ماکرو‌پذیر با یک جعبه متن به نام `TextBox1` و یک دکمه فرمان به نام `CommandButton1` در اسلاید اول دارد. برای تغییر مقدار جعبه متن و عنوان دکمه از [مجموعه ویژگی‌های کنترل](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) استفاده می‌کند. هر کنترل همچنین یک پیش‌نمایش ثابت دارد که PowerPoint می‌تواند قبل از فعال‌سازی نمایش دهد. برای هر کنترل یک تصویر PNG که متن و ظاهر به‌روز شده آن را نشان می‌دهد، فراهم کنید. مثال این تصاویر را از طریق [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat) اختصاص می‌دهد.

این مثال همه کنترل‌ها در اسلاید اول را به میزان ۱۰۰ پوینت به سمت پایین حرکت می‌دهد با تنظیم قاب آن‌ها با [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). ارائه ویرایش‌شده را در قالب PPTM ذخیره می‌کند، سپس با استفاده از [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) نسخه دوم را که تمام کنترل‌های ActiveX از آن اسلاید حذف شده‌اند، ذخیره می‌کند.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **افزودن کنترل ActiveX Media Player**

برای استفاده مجدد از یک کنترل Windows Media Player پیکربندی‌شده، با قالبی شروع کنید که اسلاید اول آن حاوی یک پخش‌کننده به نام `WindowsMediaPlayer1` باشد. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) کل اسلاید را به ارائه جدید کپی می‌کند. مثال `URL` پخش‌کننده را در [مجموعه ویژگی‌ها](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) تنظیم می‌کند و اسلاید کپی‌شده را به عنوان تنها اسلاید در خروجی ذخیره می‌نماید. ویدئو به صورت خارجی باقی می‌ماند، بنابراین مسیر دسترسی‌پذیر برای پخش‌کننده را انتخاب کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **پرسش‌های متداول**

**آیا Aspose.Slides می‌تواند کنترل‌های ActiveX را بدون اجرا حفظ کند؟**

بله. Aspose.Slides می‌تواند کنترل‌ها را بخواند و ذخیره کند، از جمله ویژگی‌ها و موقعیت‌های آن‌ها، بدون اینکه آن‌ها را فعال کند.

**تفاوت کنترل‌های ActiveX با اشیاء OLE چیست؟**

کنترل‌های ActiveX به کاربران امکان تعامل با اسلاید را می‌دهند، به عنوان مثال با وارد کردن متن یا کلیک کردن روی یک دکمه. یک [شی OLE](/slides/fa/python-java/manage-ole/) اجازه می‌دهد یک اسلاید محتوا را که توسط برنامه دیگری مدیریت می‌شود، شامل یا به آن لینک کند، مانند یک کاربرگ Excel.

**آیا رویدادهای ActiveX پس از ذخیره یک ارائه با Aspose.Slides هنوز ماکروهای VBA را فعال می‌کنند؟**

نمایش را در قالب ماکرو‌پذیر مانند PPTM ذخیره کنید تا پروژه VBA آن حفظ شود. PowerPoint برای ویندوز می‌تواند هندلرهای رویداد موجود را اجرا کند هنگامی که تنظیمات امنیتی آن اجازهٔ هم کنترل‌های ActiveX و هم ماکروها را می‌دهند.