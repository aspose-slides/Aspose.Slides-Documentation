---
title: ActiveX
type: docs
weight: 80
url: /ar/python-net/activex/
keywords: "ActiveX, عناصر التحكم في ActiveX, عرض PowerPoint, بايثون, Aspose.Slides لـ بايثون عبر .NET"
description: "إدارة عناصر التحكم في ActiveX في عرض PowerPoint باستخدام بايثون"
---

تستخدم عناصر التحكم في ActiveX في العروض التقديمية. يسمح لك Aspose.Slides لـ بايثون عبر .NET بإدارة عناصر التحكم في ActiveX، ولكن إدارتها أكثر تعقيدًا وتختلف عن الأشكال العادية في العرض التقديمي. اعتبارًا من Aspose.Slides لـ بايثون عبر .NET 6.9.0، يدعم المكون إدارة عناصر التحكم في ActiveX. في الوقت الحالي، يمكنك الوصول إلى عنصر التحكم في ActiveX المضاف بالفعل في عرضك التقديمي وتعديله أو حذفه باستخدام خصائصه المختلفة. تذكر، عناصر التحكم في ActiveX ليست أشكالًا وليست جزءًا من IShapeCollection في العرض التقديمي ولكنها جزء من IControlCollection المنفصلة. يوضح هذا المقال كيفية العمل معهم.
## **تعديل عناصر التحكم في ActiveX**
لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة:

1. إنشاء مثيل من فئة Presentation وتحميل العرض التقديمي مع عناصر التحكم في ActiveX بداخله.
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. الوصول إلى عناصر التحكم في ActiveX في الشريحة عن طريق الوصول إلى IControlCollection.
1. الوصول إلى عنصر تحكم ActiveX المسمى TextBox1 باستخدام كائن ControlEx.
1. تغيير الخصائص المختلفة لعنصر التحكم في ActiveX المسمى TextBox1 بما في ذلك النص، الخط، ارتفاع الخط وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
1. تغيير عنوان الزر، الخط والموقع.
1. نقل موقع إطارات عناصر التحكم في ActiveX.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

تقوم الشيفرة البرمجية أدناه بتحديث عناصر التحكم في ActiveX على الشرائح في العرض التقديمي كما هو موضح أدناه.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Accessing the presentation with  ActiveX controls
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Accessing the first slide in presentation
    slide = presentation.slides[0]

    # changing TextBox text
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # changing substitute image. Powerpoint will replace this image during activeX activation, so sometime it's OK to leave image unchanged.

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

    # changing Button caption
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # changing substitute
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
    
    # Moving ActiveX frames 100 points down
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

    # Save the presentation with Edited ActiveX Controls
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Now removing controls
    slide.controls.clear()

    # Saving the presentation with cleared ActiveX controls
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **إضافة عنصر التحكم في مشغل وسائط ActiveX**
لإضافة عنصر التحكم في مشغل وسائط ActiveX، يرجى تنفيذ الخطوات التالية:

1. إنشاء مثيل من فئة Presentation وتحميل العرض التقديمي النموذجي مع عناصر التحكم في مشغل الوسائط ActiveX بداخله.
1. إنشاء مثيل من فئة Presentation الهدف وإنشاء مثيل فارغ للعرض التقديمي.
1. استنساخ الشريحة مع عنصر التحكم في مشغل الوسائط ActiveX في العرض التقديمي النموذجي إلى Presentation الهدف.
1. الوصول إلى الشريحة المستنسخة في Presentation الهدف.
1. الوصول إلى عناصر التحكم في ActiveX في الشريحة عن طريق الوصول إلى IControlCollection.
1. الوصول إلى عنصر التحكم في مشغل الوسائط ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
1. حفظ العرض التقديمي إلى ملف PPTX.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX file
with slides.Presentation(path + "template.pptx") as presentation:

    # Create empty presentation instance
    with slides.Presentation() as newPresentation:

        # Remove default slide
        newPresentation.slides.remove_at(0)

        # Clone slide with Media Player ActiveX Control
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Access the Media Player ActiveX control and set the video path
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Save the Presentation
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```