---
title: "إدارة عناصر تحكم ActiveX في العروض التقديمية باستخدام Python"
linktitle: "ActiveX"
type: docs
weight: 80
url: /ar/python-net/activex/
keywords:
- "ActiveX"
- "عنصر تحكم ActiveX"
- "إدارة ActiveX"
- "إضافة ActiveX"
- "تعديل ActiveX"
- "مشغل وسائط"
- "PowerPoint"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "تحرير صناديق النص وأزرار ActiveX، تحديث معاينات عناصر التحكم، وإعادة استخدام عنصر تحكم Windows Media Player في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Python عبر .NET."
---
## **المقدمة**

تمنح عناصر تحكم ActiveX شريحة PowerPoint عناصر تفاعلية مثل صناديق النص وأزرار الأوامر ومشغلات الوسائط. Aspose.Slides for Python عبر .NET يكشف عن عناصر التحكم في الشريحة عبر [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). استخدم هذه المجموعة لتعديل عنصر تحكم، أو تحريكه على الشريحة، أو إزالته.

## **قائمة عناصر تحكم ActiveX وخصائصها المخزنة**

لفحص قالب غير مألوف، افتحه للقراءة وتكرّر عبر عناصر التحكم في كل شريحة. يُبلّغ المثال عن رقم الشريحة، اسم عنصر التحكم، [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/)، وكل زوج مفتاح‑قيمة في [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). يقرأ العرض التقديمي بدون تنشيط عناصر التحكم، أو استدعاء الأحداث أو الماكروهات، أو تغيير القيم، أو حفظ الملف.

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

يعرض الناتج المختار من `ActiveX.pptm` صندوق نص وزر أمر.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

تظهر مجموعة خصائص فارغة كـ `[]`. بالنسبة لعناصر التحكم التي تستخدم التخزين الثنائي، يمكن أن تُعيد `properties` قيمة `None`، وتظهر كـ `Properties unavailable`. إذا كنت تحتاج فقط إلى الأسماء، استخدم [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) بعد التحقق من وجود `None`. تُدرج التقرير الخصائص المتاحة من العرض التقديمي. قد يدعم عنصر التحكم خصائص إضافية أثناء وقت التشغيل.

## **تعديل عناصر تحكم ActiveX**

يتوقع المثال عرضًا تمكين الماكرو يحتوي على صندوق نص اسمه `TextBox1` وزر أمر اسمه `CommandButton1` في الشريحة الأولى. يستخدم [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) لتغيير قيمة صندوق النص وعنوان الزر. لكل عنصر تحكم معاينة ثابتة يمكن لبرنامج PowerPoint عرضها قبل التنشيط. قدم ملف PNG لكل عنصر تحكم يُظهر النص والمظهر المحدث. يخصص المثال هذه الصور عبر [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

يقوم المثال بنقل كل عنصر تحكم في الشريحة الأولى للأسفل بمقدار 100 نقطة عن طريق تغيير [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). يحفظ العرض التقديمي المعدل بصيغة PPTM، ثم يستخدم [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) لحفظ نسخة ثانية مع إزالة جميع عناصر تحكم ActiveX من تلك الشريحة.

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

## **إضافة عنصر تحكم مشغل وسائط ActiveX**

لإعادة استخدام عنصر تحكم Windows Media Player المُكوّن، ابدأ بقالب تحتوي شريحته الأولى على مشغل اسمه `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) ينسخ الشريحة بأكملها إلى عرض تقديمي جديد. يحدد المثال الـ `URL` الخاص بالمشغل في [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) ويحفظ الشريحة المستنسخة كالشريحة الوحيدة في الناتج. يبقى الفيديو خارجيًا، لذا اختر مسارًا يمكن للمشغل الوصول إليه أثناء التشغيل.

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

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides الحفاظ على عناصر تحكم ActiveX دون تشغيلها؟**

نعم. يمكن لـ Aspose.Slides قراءة وحفظ عناصر التحكم، بما في ذلك خصائصها ومواقعها، دون تنشيطها.

**كيف تختلف عناصر تحكم ActiveX عن كائنات OLE؟**

تُتيح عناصر تحكم ActiveX للمستخدمين التفاعل مع الشريحة، مثلاً بإدخال نص أو النقر على زر. يتيح [OLE object](/slides/ar/python-net/manage-ole/) للشريحة احتواء أو ربط محتوى تتم إدارته بواسطة تطبيق آخر، مثل ورقة عمل Excel.

**هل ستستمر أحداث ActiveX في تشغيل ماكروهات VBA بعد حفظ عرض تقديمي باستخدام Aspose.Slides؟**

احفظ العرض التقديمي بصيغة تمكين الماكرو مثل PPTM للاحتفاظ بمشروع VBA الخاص به. يمكن لـ PowerPoint لنظام Windows تشغيل معالجات الأحداث الحالية عندما تسمح إعدادات الأمان الخاصة به لكل من عناصر تحكم ActiveX والماكروهات.