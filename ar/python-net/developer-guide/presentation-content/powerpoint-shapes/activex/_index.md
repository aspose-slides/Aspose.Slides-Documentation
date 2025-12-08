---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام بايثون
linktitle: ActiveX
type: docs
weight: 80
url: /ar/python-net/activex/
keywords:
- ActiveX
- عنصر تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية استفادة Aspose.Slides for Python عبر .NET من ActiveX لأتمتة وتحسين عروض PowerPoint التقديمية، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

تُستخدم عناصر التحكم ActiveX في العروض التقديمية. يتيح Aspose.Slides for Python عبر .NET إدارة عناصر التحكم ActiveX، لكن إدارتها أكثر تعقيدًا وتختلف عن الأشكال العادية في العرض. بدءًا من Aspose.Slides for Python عبر .NET 6.9.0، يدعم المكوّن إدارة عناصر التحكم ActiveX. في الوقت الحالي، يمكنك الوصول إلى عنصر التحكم ActiveX المضاف بالفعل في عرضك وتعديله أو حذفه باستخدام خصائصه المختلفة. تذكر أن عناصر التحكم ActiveX ليست أشكالًا ولا تُعد جزءًا من IShapeCollection في العرض بل هي جزء منفصل من IControlCollection. تُظهر هذه المقالة كيفية العمل معها.

## **تعديل عناصر التحكم ActiveX**
لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة:

1. إنشاء مثيل لفئة Presentation وتحميل العرض الذي يحتوي على عناصر تحكم ActiveX.
1. الحصول على مرجع الشريحة حسب فهرستها.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة عبر IControlCollection.
1. الوصول إلى عنصر التحكم ActiveX TextBox1 باستخدام كائن ControlEx.
1. تغيير الخصائص المختلفة لعنصر التحكم ActiveX TextBox1 بما في ذلك النص، الخط، ارتفاع الخط وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
1. تغيير تسمية الزر، الخط والموقع.
1. تحريك موقع إطارات عناصر التحكم ActiveX.
1. كتابة العرض المعدل إلى ملف PPTX.

يُحدّث المقتطف البرمجي أدناه عناصر التحكم ActiveX في شرائح العرض كما هو موضح أدناه.
```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# الوصول إلى العرض مع عناصر التحكم ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # الوصول إلى الشريحة الأولى في العرض
    slide = presentation.slides[0]

    # تغيير نص مربع النص
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # تغيير صورة الاستبدال. سيستبدل PowerPoint هذه الصورة أثناء تنشيط ActiveX، لذا في بعض الأحيان يمكن ترك الصورة دون تعديل.

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

    # تغيير تسمية الزر
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # تغيير الاستبدال
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
    
    # تحريك إطارات ActiveX للأسفل بمقدار 100 نقطة
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

    # حفظ العرض مع عناصر التحكم ActiveX المعدلة
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # الآن يتم إزالة العناصر
    slide.controls.clear()

    # حفظ العرض مع عناصر التحكم ActiveX التي تم مسحها
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **إضافة عنصر تحكم ActiveX مشغل وسائط**
لإضافة عنصر تحكم ActiveX مشغل وسائط، يرجى تنفيذ الخطوات التالية:

1. إنشاء مثيل لفئة Presentation وتحميل عرض العينة الذي يحتوي على عناصر تحكم ActiveX لمشغل الوسائط.
1. إنشاء مثيل لفئة Presentation الهدف وتوليد مثيل عرض فارغ.
1. استنساخ الشريحة التي تحتوي على عنصر تحكم ActiveX مشغل الوسائط في عرض القالب إلى عرض الهدف.
1. الوصول إلى الشريحة المستنسخة في عرض الهدف.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة عبر IControlCollection.
1. الوصول إلى عنصر التحكم ActiveX مشغل الوسائط وتحديد مسار الفيديو عبر خصائصه.
1. حفظ العرض إلى ملف PPTX.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # إنشاء نسخة عرض فارغة
    with slides.Presentation() as newPresentation:

        # إزالة الشريحة الافتراضية
        newPresentation.slides.remove_at(0)

        # استنساخ الشريحة التي تحتوي على عنصر تحكم Media Player ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # حفظ العرض
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**هل يحتفظ Aspose.Slides بعناصر التحكم ActiveX عند القراءة وإعادة الحفظ إذا تعذّر تنفيذها في بيئة تشغيل Python؟**

نعم. يعامل Aspose.Slides هذه العناصر كجزء من العرض ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يتطلب تنفيذ العناصر نفسها للحفاظ عليها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE في العرض؟**

عناصر التحكم ActiveX هي عناصر تحكم تفاعلية مُدارة (أزرار، مربعات نص، مشغّل وسائط)، بينما تشير [OLE](/slides/ar/python-net/manage-ole/) إلى كائنات تطبيق مدمجة (على سبيل المثال، ورقة عمل Excel). تُخزن وتُعالج بطريقة مختلفة وتملك نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX والماكروهات VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات الوصفية والبيانات الموجودة؛ إلا أن الأحداث والماكروهات تعمل فقط داخل PowerPoint على ويندوز عندما تسمح الأمان بذلك. المكتبة لا تُنفّذ VBA.