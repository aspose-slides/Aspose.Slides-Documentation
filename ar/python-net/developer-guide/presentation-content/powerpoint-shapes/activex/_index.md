---
title: إدارة عناصر ActiveX في العروض التقديمية باستخدام Python
linktitle: ActiveX
type: docs
weight: 80
url: /ar/python-net/activex/
keywords:
- ActiveX
- تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية استفادة Aspose.Slides لـ Python عبر .NET من ActiveX لأتمتة وتعزيز عروض PowerPoint، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

يتم استخدام عناصر ActiveX في العروض التقديمية. يتيح لك Aspose.Slides لـ Python عبر .NET إدارة عناصر ActiveX، لكن إدارتها أصعب قليلًا ومختلفة عن الأشكال العادية في العرض. بدءًا من Aspose.Slides لـ Python عبر .NET 6.9.0، يدعم المكوّن إدارة عناصر ActiveX. في الوقت الحالي، يمكنك الوصول إلى عنصر ActiveX مضاف مسبقًا في عرضك وتعديله أو حذفه باستخدام خصائصه المتنوعة. تذكر أن عناصر ActiveX ليست أشكالًا وليست جزءًا من IShapeCollection في العرض بل هي جزء من IControlCollection المستقلة. يوضح هذا المقال كيفية العمل معها.  

## **تعديل عناصر ActiveX**
لإدارة عنصر ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة:

1. أنشئ كائنًا من فئة Presentation وحمّل العرض الذي يحتوي على عناصر ActiveX.  
2. احصل على مرجع الشريحة عبر فهرستها.  
3. ادخل إلى عناصر ActiveX في الشريحة عبر IControlCollection.  
4. ادخل إلى عنصر TextBox1 ActiveX باستخدام كائن ControlEx.  
5. غير الخصائص المختلفة لعنصر TextBox1 ActiveX بما في ذلك النص، الخط، ارتفاع الخط وموقع الإطار.  
6. ادخل إلى عنصر التحكم الثاني المسمى CommandButton1.  
7. غير تسمية الزر، الخط والموقع.  
8. حرّك موقع إطارات عناصر ActiveX.  
9. احفظ العرض المعدل إلى ملف PPTX.  

المقتطف البرمجي أدناه يحدّث عناصر ActiveX في شرائح العرض كما هو موضح أدناه.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# الوصول إلى العرض الذي يحتوي على عناصر ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # الوصول إلى الشريحة الأولى في العرض
    slide = presentation.slides[0]

    # تغيير نص TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # تغيير الصورة البديلة. سيستبدل PowerPoint هذه الصورة أثناء تنشيط ActiveX، لذا قد يكون ترك الصورة دون تغيير مقبولًا في بعض الأحيان.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # الخط = draw.Font(control.properties["FontName"], 14)
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

        # تغيير البديل
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # الخط = draw.Font(control.properties["FontName"], 14)
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
    
    # تحريك إطارات ActiveX إلى أسفل 100 نقطة
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

    # حفظ العرض مع عناصر ActiveX المعدلة
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # الآن إزالة العناصر
    slide.controls.clear()

    # حفظ العرض مع عناصر ActiveX الممسوحة
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **إضافة عنصر تحكم مشغل وسائط ActiveX**
لإضافة عنصر تحكم مشغل وسائط ActiveX، يرجى اتباع الخطوات التالية:

1. أنشئ كائنًا من فئة Presentation وحمّل العرض التجريبي الذي يحتوي على عنصر تحكم مشغل وسائط ActiveX.  
2. أنشئ كائنًا من فئة Presentation المستهدفة وابدأ عرضًا فارغًا.  
3. استنسخ الشريحة التي تحتوي على عنصر تحكم مشغل وسائط ActiveX من العرض القالب إلى العرض المستهدف.  
4. ادخل إلى الشريحة المستنسخة في العرض المستهدف.  
5. ادخل إلى عناصر ActiveX في الشريحة عبر IControlCollection.  
6. ادخل إلى عنصر تحكم مشغل وسائط ActiveX واضبط مسار الفيديو باستخدام خصائصه.  
7. احفظ العرض إلى ملف PPTX.  

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # إنشاء عرض فارغ
    with slides.Presentation() as newPresentation:

        # إزالة الشريحة الافتراضية
        newPresentation.slides.remove_at(0)

        # استنساخ الشريحة التي تحتوي على عنصر تحكم مشغل وسائط ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # الوصول إلى عنصر تحكم مشغل وسائط ActiveX وتعيين مسار الفيديو
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # حفظ العرض
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يحتفظ Aspose.Slides بعناصر ActiveX عند القراءة وإعادة الحفظ إذا لم يتم تنفيذها في بيئة Python؟**

نعم. يعامل Aspose.Slides هذه العناصر كجزء من العرض ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ العناصر نفسها للحفاظ عليها.

**كيف تختلف عناصر ActiveX عن كائنات OLE في العرض؟**

عناصر ActiveX هي عناصر تحكم تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما تشير [OLE](/slides/ar/python-net/manage-ole/) إلى كائنات تطبيق مدمجة (مثل ورقة Excel). يتم تخزينها ومعالجتها بطرق مختلفة ولها نماذج خصائص مميزة.

**هل تعمل أحداث ActiveX وماكرو VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات الوصفية والبيانات الحالية؛ ومع ذلك، تُنفّذ الأحداث والماكروات فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. المكتبة لا تقوم بتنفيذ VBA.