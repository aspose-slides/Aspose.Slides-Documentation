---
title: "مدیریت کنترل‌های ActiveX در ارائه‌ها با استفاده از Python"
linktitle: "ActiveX"
type: docs
weight: 80
url: /fa/python-java/activex/
keywords:
- "ActiveX"
- "کنترل ActiveX"
- "مدیریت ActiveX"
- "افزودن ActiveX"
- "تغییر ActiveX"
- "پخش‌کننده رسانه"
- "PowerPoint"
- "ارائه"
- "Python"
- "Aspose.Slides"
description: "یاد بگیرید چگونه Aspose.Slides برای Python از طریق Java از ActiveX برای خودکارسازی و ارتقاء ارائه‌های PowerPoint استفاده می‌کند و به توسعه‌دهندگان کنترل قدرتمندی بر روی اسلایدها می‌دهد."
---
## **مقدمه**

کنترل‌های ActiveX در ارائه‌ها مورد استفاده قرار می‌گیرند. Aspose.Slides برای Python از طریق Java به شما امکان افزودن و مدیریت کنترل‌های ActiveX را می‌دهد، اما نسبت به اشکال معمولی ارائه مدیریت آن‌ها کمی دشوارتر است. Aspose.Slides از افزودن کنترل‌های Media Player ActiveX پشتیبانی می‌کند. توجه داشته باشید که کنترل‌های ActiveX شکل نیستند؛ آن‌ها بخشی از [ShapeCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/) ارائه نیستند. آن‌ها به جای آن بخشی از [ControlCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/controlcollection/) جداگانه هستند. در این بخش، نحوه کار با آن‌ها را نشان می‌دهیم.

## **افزودن کنترل Media Player ActiveX به اسلاید**

برای افزودن یک کنترل Media Player ActiveX، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کرده و یک ارائهٔ خالی تولید کنید.  
2. اسلاید هدف را در [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) دسترسی پیدا کنید.  
3. کنترل Media Player ActiveX را با استفاده از متد [addControl](https://reference.aspose.com/slides/fa/python-java/aspose.slides/controlcollection/#addControl) که توسط [ControlCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/controlcollection/) ارائه شده، اضافه کنید.  
4. به کنترل Media Player ActiveX دسترسی پیدا کنید و مسیر ویدئو را با استفاده از ویژگی‌های آن تنظیم کنید.  
5. ارائه را به عنوان یک فایل PPTX ذخیره کنید.

این کد نمونه، بر اساس مراحل بالا، نشان می‌دهد چگونه یک کنترل Media Player ActiveX به اسلاید اضافه شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# یک ارائهٔ خالی ایجاد کنید.
presentation = Presentation()
try:
    # کنترل Media Player ActiveX را اضافه کنید.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # مسیر ویدئو را تنظیم کنید.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # ارائه را ذخیره کنید.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغییر یک کنترل ActiveX**

{{% alert color="info" title="Note" %}}

Aspose.Slides برای Python از طریق Java مؤلفه‌هایی برای مدیریت کنترل‌های ActiveX فراهم می‌کند. می‌توانید به کنترل ActiveX افزوده‌شده در ارائه‌تان دسترسی پیدا کنید و از طریق ویژگی‌های آن آن را اصلاح یا حذف کنید.

{{% /alert %}}

برای مدیریت یک کنترل ActiveX ساده مانند یک جعبهٔ متنی و دکمهٔ فرمان ساده در اسلاید، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کرده و ارائه‌ای که شامل کنترل‌های ActiveX است را بارگذاری کنید.  
2. یک مرجع اسلاید را بر اساس اندیس آن دریافت کنید.  
3. به کنترل‌های ActiveX در اسلاید دسترسی پیدا کنید با دسترسی به [ControlCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/controlcollection/).  
4. کنترل ActiveX TextBox1 را با استفاده از شیء [Control](https://reference.aspose.com/slides/fa/python-java/aspose.slides/control/) دسترسی پیدا کنید.  
5. ویژگی‌های کنترل ActiveX TextBox1 را که شامل متن، قلم، ارتفاع قلم و موقعیت فریم هستند تغییر دهید.  
6. کنترل ActiveX دوم به نام CommandButton1 را دسترسی پیدا کنید.  
7. عنوان دکمه، قلم و موقعیت آن را تغییر دهید.  
8. موقعیت فریم‌های کنترل‌های ActiveX را جابجا کنید.  
9. ارائهٔ تغییر یافته را به یک فایل PPTM بنویسید.

این کد نمونه، بر اساس مراحل بالا، نشان می‌دهد چگونه یک کنترل ActiveX ساده را مدیریت کنید:

```python
import jpaste
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# ارائه را با کنترل‌های ActiveX بارگذاری کنید.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # دسترسی به اسلاید اول.
        slide = presentation.getSlides().get_Item(0)

        # متن جعبهٔ متن را تغییر دهید.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # تصویر جایگزین را تغییر دهید. PowerPoint در هنگام فعال‌سازی ActiveX آن را جایگزین می‌کند، بنابراین گاهی می‌تواند بدون تغییر بماند.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # عنوان دکمه را تغییر دهید.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # تصویر جایگزین را تغییر دهید.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # کنترل‌ها را ۱۰۰ نقطه به پایین حرکت دهید.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # کنترل‌ها را حذف کنید.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا Aspose.Slides کنترل‌های ActiveX را هنگام خواندن و ذخیره مجدد حفظ می‌کند اگر آنها نتوانند در زمان اجرای پایتون اجرا شوند؟**

بله. Aspose.Slides آنها را به عنوان بخشی از ارائه در نظر می‌گیرد و می‌تواند ویژگی‌ها و فریم‌های آنها را بخواند/تغییر دهد؛ برای حفظ آنها اجرای واقعی کنترل‌ها لازم نیست.

**کنترل‌های ActiveX چگونه با اشیاء OLE در یک ارائه متفاوت هستند؟**

کنترل‌های ActiveX کنترل‌های تعاملی مدیریت‌شده (دکمه‌ها، جعبه‌های متن، پلیر رسانه) هستند، در حالی که [OLE](/slides/fa/python-java/manage-ole/) به اشیاء برنامه‌ی جاسازی‌شده (مثلاً یک worksheet اکسل) اشاره دارد. آنها به‌صورت متفاوتی ذخیره و مدیریت می‌شوند و مدل‌های خاصی برای ویژگی‌ها دارند.

**آیا رویدادهای ActiveX و ماکروهای VBA در صورتی که فایل توسط Aspose.Slides تغییر یافته باشد، کار می‌کنند؟**

Aspose.Slides نشانه‌گذاری و متادیتای موجود را حفظ می‌کند؛ اما رویدادها و ماکروها فقط در PowerPoint در ویندوز اجرا می‌شوند وقتی امنیت اجازه دهد. این کتابخانه VBA را اجرا نمی‌کند.