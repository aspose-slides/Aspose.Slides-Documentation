---
title: "إدارة عناصر تحكم ActiveX في العروض التقديمية باستخدام Python"
linktitle: "ActiveX"
type: docs
weight: 80
url: /ar/python-java/activex/
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
description: "تعلم كيف يستخدم Aspose.Slides لـ Python عبر Java عناصر ActiveX لأتمتة وتحسين عروض PowerPoint التقديمية، مما يمنح المطورين سيطرة قوية على الشرائح."
---
## **مقدمة**

تُستخدم عناصر تحكم ActiveX في العروض التقديمية. Aspose.Slides لـ Python عبر Java يتيح لك إضافة وإدارة عناصر تحكم ActiveX، لكنها تكون أكثر صعوبة في الإدارة مقارنةً بالأشكال العادية في العرض التقديمي. يدعم Aspose.Slides إضافة عناصر تحكم Media Player ActiveX. لاحظ أن عناصر تحكم ActiveX ليست أشكالًا؛ فهي ليست جزءًا من العرض التقديمي في [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/). إنها جزء من [ControlCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/controlcollection/) المنفصل. في هذا الموضوع، سنوضح لك كيفية العمل معها.

## **إضافة عنصر تحكم Media Player ActiveX إلى شريحة**

لإضافة عنصر تحكم Media Player ActiveX، افعل ذلك:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتوليد نسخة فارغة من العرض التقديمي.
2. الوصول إلى الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
3. إضافة عنصر تحكم Media Player ActiveX باستخدام طريقة [addControl](https://reference.aspose.com/slides/ar/python-java/aspose.slides/controlcollection/#addControl) التي تُكشف عبر [ControlCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/controlcollection/).
4. الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
5. حفظ العرض التقديمي كملف PPTX.

يعرض هذا الكود النموذجي، استنادًا إلى الخطوات السابقة، كيفية إضافة عنصر تحكم Media Player ActiveX إلى شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# إنشاء عرض تقديمي فارغ.
presentation = Presentation()
try:
    # إضافة عنصر تحكم Media Player ActiveX.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # تعيين مسار الفيديو.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # حفظ العرض التقديمي.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعديل عنصر تحكم ActiveX**

{{% alert color="info" title="Note" %}}
يوفر Aspose.Slides لـ Python عبر Java مكونات لإدارة عناصر تحكم ActiveX. يمكنك الوصول إلى عنصر تحكم ActiveX الذي تم إضافته بالفعل في عرضك التقديمي وتعديله أو حذفه عبر خصائصه.
{{% /alert %}}

لإدارة عنصر تحكم ActiveX بسيط مثل مربع النص وزر الأمر البسيط على شريحة، قم بما يلي:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.
2. الحصول على مرجع الشريحة باستخدام مؤشرها.
3. الوصول إلى عناصر تحكم ActiveX في الشريحة عبر الوصول إلى [ControlCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/controlcollection/).
4. الوصول إلى عنصر تحكم ActiveX TextBox1 باستخدام كائن [Control](https://reference.aspose.com/slides/ar/python-java/aspose.slides/control/).
5. تغيير خصائص عنصر تحكم ActiveX TextBox1 التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.
6. الوصول إلى عنصر التحكم ActiveX الثاني المسمى CommandButton1.
7. تغيير تسمية الزر، الخط، وموقعه.
8. تحريك موقع إطارات عناصر تحكم ActiveX.
9. كتابة العرض التقديمي المعدل إلى ملف PPTM.

يعرض هذا الكود النموذجي، استنادًا إلى الخطوات السابقة، كيفية إدارة عنصر تحكم ActiveX بسيط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# تحميل العرض التقديمي مع عناصر تحكم ActiveX.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # الوصول إلى الشريحة الأولى.
        slide = presentation.getSlides().get_Item(0)

        # تغيير نص مربع النص.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # تغيير الصورة البديلة. يقوم PowerPoint باستبدالها أثناء تنشيط ActiveX،
            # لذلك قد تُترك أحيانًا دون تعديل.
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

        # تغيير تسمية الزر.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # تغيير الصورة البديلة.
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

        # نقل عناصر التحكم للأسفل بمقدار 100 نقطة.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # إزالة عناصر التحكم.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يحافظ Aspose.Slides على عناصر تحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة تشغيل Python؟**

نعم. يعتبر Aspose.Slides عناصر التحكم جزءًا من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ عناصر التحكم نفسها للحفاظ عليها.

**كيف تختلف عناصر تحكم ActiveX عن كائنات OLE في العرض التقديمي؟**

تُعد عناصر تحكم ActiveX ضوابط تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما يشير [OLE](/slides/ar/python-java/manage-ole/) إلى كائنات تطبيق مضمنة (مثل ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة ولها نماذج خصائص متميزة.

**هل تعمل أحداث ActiveX وماكرو VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات والبيانات الوصفية الحالية؛ ومع ذلك، تُنفّذ الأحداث والماكروهات فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. المكتبة لا تقوم بتنفيذ VBA.