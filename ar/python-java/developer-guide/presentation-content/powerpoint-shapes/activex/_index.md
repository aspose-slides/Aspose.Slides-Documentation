---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام Python
linktitle: ActiveX
type: docs
weight: 80
url: /ar/python-java/activex/
keywords:
- ActiveX
- عنصر تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغّل وسائط
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحرير مربعات النص وأزرار ActiveX، وتحديث معاينات عناصر التحكم، وإعادة استخدام عنصر تحكم Windows Media Player في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Python عبر Java."
---
## **المقدمة**

تُوفر عناصر التحكم ActiveX لشرائح PowerPoint عناصر تفاعلية مثل مربعات النص، أزرار الأوامر، ومشغلات الوسائط. تُتيح Aspose.Slides for Python عبر Java التحكم في عناصر الشريحة من خلال [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). استخدم هذه المجموعة لتعديل عنصر تحكم، نقلُه على الشريحة، أو إزالته.

## **قائمة عناصر التحكم ActiveX وخصائصها المخزنة**

لفحص قالب غير مألوف، افتحه للقراءة وت.iterate عبر عناصر التحكم في كل شريحة. تُظهر العينة رقم الشريحة، اسم عنصر التحكم، [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId)، وكل زوج مفتاح‑قيمة في [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). يقرأ العرض التقديمي دون تفعيل عناصر التحكم، أو استدعاء الأحداث أو الماكروات، أو تغيير القيم، أو حفظ الملف.

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

يعرض الإخراج المختار من `ActiveX.pptm` مربع نص وزر أمر.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

تظهر مجموعة الخصائص الفارغة كـ `[]`. للعناصر التي تستخدم تخزينًا ثنائيًا، قد تُعيد [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) القيمة `None`، وتُعرض كـ `Properties unavailable`. إذا كنت بحاجة إلى الأسماء فقط، استخدم [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) بعد التحقق من توفر المجموعة. يسرد التقرير الخصائص المتاحة من العرض التقديمي. قد يدعم العنصر خصائص إضافية وقت التشغيل.

## **تعديل عناصر التحكم ActiveX**

تتوقع العينة عرضًا تقديميًا يدعم الماكرو يحتوي على مربع نص اسمه `TextBox1` وزر أمر اسمه `CommandButton1` في الشريحة الأولى. تستخدم [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) لتغيير قيمة مربع النص وعنوان الزر. لكل عنصر تحكم معاينة ثابتة يمكن لـ PowerPoint عرضها قبل التفعيل. قدم ملف PNG لكل عنصر يظهر النص المحدث والمظهر. تُعيّن العينة هذه الصور عبر [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

تنقل العينة كل عنصر تحكم في الشريحة الأولى للأسفل بمقدار 100 نقطة عبر ضبط إطاره بـ [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). تحفظ العرض التقديمي المعدل بصيغة PPTM، ثم تستخدم [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) لحفظ نسخة ثانية مع إزالة جميع عناصر التحكم ActiveX من تلك الشريحة.

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

## **إضافة عنصر تحكم مشغل وسائط ActiveX**

لإعادة استخدام عنصر تحكم Windows Media Player مُكوّن، ابدأ بقالب تحتوي شريحته الأولى على مشغل اسمه `WindowsMediaPlayer1`. ينسخ [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) الشريحة بالكامل إلى عرض تقديمي جديد. تُضبط العينة عنوان `URL` الخاص بالمشغل في [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) وتُحفظ الشريحة المستنسخة كالشريحة الوحيدة في الناتج. يبقى الفيديو خارجيًا، لذا اختر مسارًا يمكن للمشغل الوصول إليه أثناء التشغيل.

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

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides الحفاظ على عناصر التحكم ActiveX دون تشغيلها؟**

نعم. يمكن لـ Aspose.Slides قراءة العناصر وحفظها، بما في ذلك خصائصها ومواقعها، دون تفعيلها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE؟**

تسمح عناصر التحكم ActiveX للمستخدمين بالتفاعل مع الشريحة، مثل إدخال نص أو النقر على زر. يتيح [OLE object](/slides/ar/python-java/manage-ole/) للشريحة احتواء أو ربط محتوى تُديره تطبيق آخر، مثل ورقة عمل Excel.

**هل ستستمر أحداث ActiveX في تشغيل ماكروات VBA بعد حفظ العرض التقديمي باستخدام Aspose.Slides؟**

احفظ العرض التقديمي بصيغة تدعم الماكرو مثل PPTM للاحتفاظ بمشروع VBA الخاص به. يمكن لـ PowerPoint لنظام Windows تشغيل معالجات الأحداث الحالية عندما تسمح إعدادات الأمان بوجود كل من عناصر التحكم ActiveX والماكروات.