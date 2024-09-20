---
title: ActiveX
type: docs
weight: 80
url: /python-net/activex/
keywords: "ActiveX, контролы ActiveX, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Управление контролами ActiveX в презентации PowerPoint на Python"
---

Контролы ActiveX используются в презентациях. Aspose.Slides для Python через .NET позволяет управлять контролами ActiveX, но управление ими несколько сложнее и отличается от обычных фигур презентации. Начиная с версии 6.9.0 Aspose.Slides для Python через .NET, компонент поддерживает управление контролами ActiveX. В данный момент вы можете получить доступ к уже добавленному контролу ActiveX в вашей презентации и изменить или удалить его, используя различные свойства. Помните, что контролы ActiveX не являются фигурами и не входят в IShapeCollection презентации, а представляют собой отдельную IControlCollection. Эта статья показывает, как работать с ними.
## **Изменение контролей ActiveX**
Чтобы управлять простым контролем ActiveX, таким как текстовое поле и простая кнопка команд на слайде:

1. Создайте экземпляр класса Presentation и загрузите презентацию с контролами ActiveX.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к контролам ActiveX на слайде, обратившись к IControlCollection.
1. Получите доступ к контролю ActiveX TextBox1 с помощью объекта ControlEx.
1. Измените различные свойства контроля ActiveX TextBox1, включая текст, шрифт, высоту шрифта и позицию рамки.
1. Получите доступ ко второму контролю, называемому CommandButton1.
1. Измените заголовок кнопки, шрифт и позицию.
1. Сдвиньте позицию рамок контролей ActiveX.
1. Запишите измененную презентацию в файл PPTX.

Ниже приведен фрагмент кода, который обновляет контролы ActiveX на слайдах презентации, как показано ниже.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Доступ к презентации с контролами ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Доступ к первому слайду в презентации
    slide = presentation.slides[0]

    # изменение текста TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Измененный текст"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # изменение заменяемого изображения. PowerPoint заменит это изображение при активации ActiveX, поэтому иногда его можно оставить неизменным.

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

    # изменение заголовка кнопки
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # изменение заменяемого изображения
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
    
    # Перемещение рамок ActiveX на 100 точек вниз
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

    # Сохранение презентации с измененными контролами ActiveX
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Теперь удаление контролей
    slide.controls.clear()

    # Сохранение презентации с очищенными контролями ActiveX
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Добавить контроль активного медиаплеера ActiveX**
Чтобы добавить контроль активного медиаплеера ActiveX, выполните следующие шаги:

1. Создайте экземпляр класса Presentation и загрузите образец презентации с контролями медиаплеера ActiveX.
1. Создайте экземпляр целевого класса Presentation и создайте пустой экземпляр презентации.
1. Клонируйте слайд с контролем медиаплеера ActiveX из шаблонной презентации в целевую презентацию.
1. Получите доступ к клонированному слайду в целевой презентации.
1. Получите доступ к контролям ActiveX на слайде, обратившись к IControlCollection.
1. Получите доступ к контролю медиаплеера ActiveX и задайте путь к видео, используя его свойства.
1. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides

# Создание экземпляра класса Presentation, представляющего файл PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Создание пустого экземпляра презентации
    with slides.Presentation() as newPresentation:

        # Удаление стандартного слайда
        newPresentation.slides.remove_at(0)

        # Клонирование слайда с контролем медиаплеера ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Получение доступа к контролю медиаплеера ActiveX и задайте путь к видео
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Сохранение презентации
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```