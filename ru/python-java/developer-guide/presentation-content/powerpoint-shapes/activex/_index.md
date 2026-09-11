---
title: Управление ActiveX‑контролями в презентациях с помощью Python
linktitle: ActiveX
type: docs
weight: 80
url: /ru/python-java/activex/
keywords:
- ActiveX
- ActiveX‑контрол
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Python via Java использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---
## **Введение**

ActiveX‑контролы используются в презентациях. Aspose.Slides for Python via Java позволяет добавлять и управлять ActiveX‑контролами, но они несколько сложнее в управлении по сравнению с обычными фигурами презентации. Aspose.Slides поддерживает добавление ActiveX‑контролей Media Player. Обратите внимание, что ActiveX‑контролы не являются фигурами; они не являются частью презентации [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/). Они находятся в отдельной [ControlCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/controlcollection/) вместо этого. В этой статье мы покажем, как работать с ними.

## **Добавление ActiveX‑контроля Media Player на слайд**

Чтобы добавить ActiveX‑контрол Media Player, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и создайте пустую презентацию.  
2. Получите доступ к целевому слайду в [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).  
3. Добавьте ActiveX‑контрол Media Player, используя метод [addControl](https://reference.aspose.com/slides/ru/python-java/aspose.slides/controlcollection/#addControl), предоставляемый [ControlCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/controlcollection/).  
4. Получите доступ к ActiveX‑контролу Media Player и задайте путь к видео, используя его свойства.  
5. Сохраните презентацию в файле PPTX.

Этот пример кода, основанный на вышеописанных шагах, показывает, как добавить ActiveX‑контрол Media Player на слайд:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Создать пустую презентацию.
presentation = Presentation()
try:
    # Добавить ActiveX‑контрол Media Player.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Установить путь к видео.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Сохранить презентацию.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Изменение ActiveX‑контроля**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java предоставляет компоненты для управления ActiveX‑контролями. Вы можете получить доступ к уже добавленному ActiveX‑контролю в вашей презентации и изменить или удалить его через его свойства.
{{% /alert %}}

Чтобы управлять простым ActiveX‑контролем, например текстовым полем и простой кнопкой команд на слайде, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую ActiveX‑контролы.  
2. Получите ссылку на слайд по его индексу.  
3. Получите доступ к ActiveX‑контролям на слайде, обратившись к [ControlCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/controlcollection/).  
4. Получите доступ к ActiveX‑контролю TextBox1, используя объект [Control](https://reference.aspose.com/slides/ru/python-java/aspose.slides/control/).  
5. Измените свойства ActiveX‑контроля TextBox1, включающие текст, шрифт, высоту шрифта и положение рамки.  
6. Получите доступ ко второму ActiveX‑контролю под названием CommandButton1.  
7. Измените подпись кнопки, шрифт и позицию.  
8. Смещение положения рамок ActiveX‑контролей.  
9. Запишите изменённую презентацию в файл PPTM.

Этот пример кода, основанный на вышеописанных шагах, показывает, как управлять простым ActiveX‑контролем:

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

# Загрузить презентацию с ActiveX‑контролями.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Получить доступ к первому слайду.
        slide = presentation.getSlides().get_Item(0)

        # Изменить текст в текстовом поле.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Изменить заменяющее изображение. PowerPoint заменяет его при активации ActiveX,
            # поэтому иногда его можно оставить без изменений.
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

        # Изменить подпись кнопки.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Изменить заменяющее изображение.
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

        # Переместить контролы вниз на 100 пунктов.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Удалить контролы.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Сохраняет ли Aspose.Slides ActiveX‑контролы при чтении и повторном сохранении, если они не могут быть выполнены в среде выполнения Python?**

Да. Aspose.Slides рассматривает их как часть презентации и может считывать/изменять их свойства и рамки; для их сохранения не требуется выполнение самих контролей.

**Чем ActiveX‑контролы отличаются от объектов OLE в презентации?**

ActiveX‑контролы — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/python-java/manage-ole/) относится к встроенным объектам приложений (например, листу Excel). Они хранятся и обрабатываются иначе и имеют другую модель свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён с помощью Aspose.Slides?**

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы работают только внутри PowerPoint в Windows при разрешённой безопасности. Библиотека не выполняет VBA.