---
title: Управление ActiveX элементами управления в презентациях с помощью Python
linktitle: ActiveX
type: docs
weight: 80
url: /ru/python-net/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Python via .NET использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---

ActiveX‑элементы управления используются в презентациях. Aspose.Slides for Python via .NET позволяет управлять ActiveX‑элементами, но их обработка несколько сложнее и отличается от обычных фигур презентации. Начиная с Aspose.Slides for Python via .NET 6.9.0, компонент поддерживает управление ActiveX‑элементами. В данный момент вы можете получить доступ к уже добавленному ActiveX‑элементу в презентации и изменить его или удалить, используя различные свойства. Помните, что ActiveX‑элементы не являются фигурами и не входят в IShapeCollection презентации, а находятся в отдельном IControlCollection. В этой статье показано, как с ними работать.

## **Изменить ActiveX‑элементы управления**
Для управления простым ActiveX‑элементом, таким как текстовое поле и простая кнопка команды на слайде:

1. Создайте экземпляр класса Presentation и загрузите презентацию с ActiveX‑элементами.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к ActiveX‑элементам на слайде, обратившись к IControlCollection.
1. Получите ActiveX‑элемент TextBox1 с помощью объекта ControlEx.
1. Измените различные свойства ActiveX‑элемента TextBox1, включая текст, шрифт, высоту шрифта и позицию рамки.
1. Получите второй элемент управления под названием CommandButton1.
1. Измените подпись кнопки, шрифт и позицию.
1. Сместите позицию рамок ActiveX‑элементов.
1. Запишите изменённую презентацию в файл PPTX.

Ниже приведён фрагмент кода, который обновляет ActiveX‑элементы на слайдах презентации, как показано ниже.
```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Доступ к презентации с  ActiveX элементами
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Доступ к первому слайду в презентации
    slide = presentation.slides[0]

    # изменение текста TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # изменение заменяющего изображения. Powerpoint заменит это изображение при активации ActiveX, поэтому иногда допустимо оставить изображение без изменений.

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

    # изменение подписи кнопки
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # изменение заменяющего изображения
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
    
    # Перемещение рамок ActiveX на 100 пунктов вниз
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

    # Сохранение презентации с отредактированными элементами ActiveX
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Теперь удаляем элементы управления
    slide.controls.clear()

    # Сохранение презентации с удалёнными элементами ActiveX
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Добавить ActiveX‑элемент управления Media Player**
Чтобы добавить ActiveX‑элемент управления Media Player, выполните следующие шаги:

1. Создайте экземпляр класса Presentation и загрузите образец презентации с ActiveX‑элементом Media Player.
1. Создайте экземпляр целевого класса Presentation и создайте пустой объект презентации.
1. Клонируйте слайд с ActiveX‑элементом Media Player из шаблонной презентации в целевую презентацию.
1. Получите доступ к клонированному слайду в целевой презентации.
1. Получите доступ к ActiveX‑элементам на слайде, обратившись к IControlCollection.
1. Получите ActiveX‑элемент Media Player и задайте путь к видео, используя его свойства.
1. Сохраните презентацию в файл PPTX.
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего файл PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Создать пустой экземпляр презентации
    with slides.Presentation() as newPresentation:

        # Удалить слайд по умолчанию
        newPresentation.slides.remove_at(0)

        # Клонировать слайд с ActiveX‑элементом Media Player
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Получить доступ к ActiveX‑элементу Media Player и задать путь к видео
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Сохранить презентацию
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Часто задаваемые вопросы**

**Сохраняет ли Aspose.Slides ActiveX‑элементы при чтении и повторном сохранении, если они не могут быть выполнены в среде Python?**

Да. Aspose.Slides рассматривает их как часть презентации и может читать/изменять их свойства и рамки; выполнение самих элементов не требуется для их сохранения.

**Чем ActiveX‑элементы отличаются от OLE‑объектов в презентации?**

ActiveX‑элементы — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/python-net/manage-ole/) относится к встроенным объектам приложений (например, листу Excel). Они хранятся и обрабатываются по‑разному и имеют различную модель свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён Aspose.Slides?**

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы выполняются только в PowerPoint на Windows, когда позволяет безопасность. Библиотека не исполняет VBA.