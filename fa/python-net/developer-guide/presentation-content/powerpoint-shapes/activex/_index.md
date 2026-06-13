---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها با پایتون
linktitle: ActiveX
type: docs
weight: 80
url: /fa/python-net/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- تغییر ActiveX
- پخش‌کننده رسانه
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید Aspose.Slides برای Python از طریق .NET چگونه از ActiveX برای خودکارسازی و بهبود ارائه‌های PowerPoint استفاده می‌کند و به توسعه‌دهندگان کنترل قدرتمندی بر اسلایدها می‌دهد."
---
## **مقدمه**

کنترل‌های ActiveX در ارائه‌ها استفاده می‌شوند. Aspose.Slides for Python via .NET به شما امکان مدیریت کنترل‌های ActiveX را می‌دهد، اما مدیریت آن‌ها کمی پیچیده‌تر و متفاوت از اشکال معمولی ارائه است. از نسخه Aspose.Slides for Python via .NET 6.9.0 به بعد، این مؤلفه از مدیریت کنترل‌های ActiveX پشتیبانی می‌کند. در حال حاضر می‌توانید به کنترل ActiveX که پیشاپیش به ارائه اضافه شده دسترسی پیدا کنید و با استفاده از ویژگی‌های مختلف آن را اصلاح یا حذف کنید. به یاد داشته باشید که کنترل‌های ActiveX اشکال نیستند و بخشی از IShapeCollection ارائه نیستند بلکه در IControlCollection جداگانه قرار دارند. این مقاله نشان می‌دهد چگونه با آن‌ها کار کنید.

## **تغییر کنترل‌های ActiveX**

1. یک نمونه از کلاس Presentation ایجاد کنید و ارائه‌ای که شامل کنترل‌های ActiveX است بارگذاری کنید.  
2. با استفاده از ایندکس، مرجع اسلاید را دریافت کنید.  
3. با دسترسی به IControlCollection، به کنترل‌های ActiveX در اسلاید دسترسی پیدا کنید.  
4. کنترل ActiveX TextBox1 را با استفاده از شیء ControlEx دسترسی پیدا کنید.  
5. ویژگی‌های مختلف کنترل ActiveX TextBox1 شامل متن، قلم، ارتفاع قلم و موقعیت فریم را تغییر دهید.  
6. دسترسی به کنترل دوم به نام CommandButton1 را بدست آورید.  
7. عنوان دکمه، قلم و موقعیت آن را تغییر دهید.  
8. موقعیت فریم‌های کنترل‌های ActiveX را جابجا کنید.  
9. ارائهٔ اصلاح‌شده را در یک فایل PPTX ذخیره کنید.

قطعه کد زیر کنترل‌های ActiveX در اسلایدهای ارائه را به شکلی که در ادامه نشان داده شده است به‌روزرسانی می‌کند.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# دسترسی به ارائه با کنترل‌های ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # دسترسی به اولین اسلاید در ارائه
    slide = presentation.slides[0]

    # تغییر متن TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # تغییر تصویر جایگزین. PowerPoint این تصویر را هنگام فعال‌سازی ActiveX جایگزین می‌کند، بنابراین گاهی می‌توانید تصویر را بدون تغییر بگذارید.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # تغییر عنوان دکمه
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # تغییر جایگزین
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # جابه‌جایی فریم‌های ActiveX به سمت پایین ۱۰۰ نقطه
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # ذخیرهٔ ارائه با کنترل‌های ActiveX ویرایش‌شده
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # حالا در حال حذف کنترل‌ها
    slide.controls.clear()

    # ذخیرهٔ ارائه با کنترل‌های ActiveX پاک‌شده
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **افزودن کنترل Media Player ActiveX**

برای افزودن کنترل Media Player ActiveX، لطفاً مراحل زیر را انجام دهید:

1. یک نمونه از کلاس Presentation ایجاد کنید و ارائه نمونه‌ای که شامل کنترل‌های Media Player ActiveX است بارگذاری کنید.  
2. یک نمونه از کلاس Presentation هدف ایجاد کنید و یک نمونهٔ ارائهٔ خالی تولید کنید.  
3. اسلاید حاوی کنترل Media Player ActiveX در ارائهٔ قالب را به ارائهٔ هدف کپی (کلون) کنید.  
4. به اسلاید کپی‌شده در ارائهٔ هدف دسترسی پیدا کنید.  
5. با دسترسی به IControlCollection، به کنترل‌های ActiveX در اسلاید دسترسی پیدا کنید.  
6. کنترل Media Player ActiveX را دسترسی پیدا کنید و مسیر ویدیو را با استفاده از ویژگی‌های آن تنظیم کنید.  
7. ارائه را در یک فایل PPTX ذخیره کنید.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که فایل PPTX را نشان می‌دهد
with slides.Presentation(path + "template.pptx") as presentation:

    # ایجاد یک نمونهٔ خالی از ارائه
    with slides.Presentation() as newPresentation:

        # حذف اسلاید پیش‌فرض
        newPresentation.slides.remove_at(0)

        # کلون اسلاید با کنترل Media Player ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # دسترسی به کنترل Media Player ActiveX و تنظیم مسیر ویدیو
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # ذخیرهٔ ارائه
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا Aspose.Slides کنترل‌های ActiveX را هنگام خواندن و ذخیره مجدد حفظ می‌کند اگر نتوانند در زمان اجرا Python اجرا شوند؟**  
بله. Aspose.Slides این کنترل‌ها را به‌عنوان بخشی از ارائه در نظر می‌گیرد و می‌تواند ویژگی‌ها و فریم‌های آن‌ها را بخواند/اصلاح کند؛ برای حفظ آن‌ها نیازی به اجرای خود کنترل‌ها نیست.

**چگونه کنترل‌های ActiveX با اشیاء OLE در یک ارائه متفاوت هستند؟**  
کنترل‌های ActiveX کنترل‌های تعاملی مدیریت‌شده هستند (دکمه‌ها، جعبه‌های متن، پخش‌کننده رسانه)، در حالی که [OLE](/slides/fa/python-net/manage-ole/) به اشیاء برنامه تعبیه‌شده (مثلاً یک جدول کاربرگ Excel) اشاره دارد. آن‌ها به‌صورت متفاوت ذخیره و مدیریت می‌شوند و مدل‌های ویژگی متفاوتی دارند.

**آیا رویدادهای ActiveX و ماکروهای VBA کار می‌کنند اگر فایل توسط Aspose.Slides اصلاح شده باشد؟**  
Aspose.Slides نشانه‌گذاری و متادیتای موجود را حفظ می‌کند؛ با این حال، رویدادها و ماکروها فقط داخل PowerPoint در ویندوز و هنگامی که امنیت اجازه دهد اجرا می‌شوند. کتابخانه VBA را اجرا نمی‌کند.