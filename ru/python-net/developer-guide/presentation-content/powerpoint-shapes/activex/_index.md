---
title: Управление элементами ActiveX в презентациях с помощью Python
linktitle: ActiveX
type: docs
weight: 80
url: /ru/python-net/activex/
keywords:
- ActiveX
- элемент ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для Python через .NET использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---

Элементы ActiveX используются в презентациях. Aspose.Slides для Python через .NET позволяет управлять элементами ActiveX, но их управление несколько сложнее и отличается от обычных фигур презентации. Начиная с Aspose.Slides для Python через .NET 6.9.0 компонент поддерживает управление элементами ActiveX. В данный момент вы можете получить доступ к уже добавленному элементу ActiveX в презентации и изменять или удалять его, используя различные свойства. Помните, что элементы ActiveX не являются фигурами и не входят в IShapeCollection презентации, а находятся в отдельном IControlCollection. В этой статье показано, как работать с ними.

## **Изменение элементов ActiveX**
Для управления простым элементом ActiveX, таким как текстовое поле и простая кнопка командного управления на слайде:

1. Создайте экземпляр класса Presentation и загрузите презентацию с элементами ActiveX.
2. Получите ссылку на слайд по его индексу.
3. Доступ к элементам ActiveX на слайде осуществляется через IControlCollection.
4. Получите элемент TextBox1 через объект ControlEx.
5. Измените различные свойства элемента TextBox1, включая текст, шрифт, высоту шрифта и положение рамки.
6. Доступ к второму управлению под названием CommandButton1.
7. Измените подпись кнопки, шрифт и позицию.
8. Сдвиньте позицию рамок элементов ActiveX.
9. Запишите изменённую презентацию в файл PPTX.

Ниже приведён фрагмент кода, который обновляет элементы ActiveX на слайдах презентации, как показано ниже.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Доступ к презентации с элементами ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Доступ к первому слайду в презентации
    slide = presentation.slides[0]

    # изменение текста TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # замена изображения‑подстановки. PowerPoint заменит это изображение при активации ActiveX, поэтому иногда можно оставить изображение без изменений.

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

        # замена подстановочного изображения
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
    
    # Сдвиг рамок элементов ActiveX на 100 пунктов вниз
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


    # Теперь удаляем элементы
    slide.controls.clear()

    # Сохранение презентации с очищенными элементами ActiveX
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Добавление элемента ActiveX Media Player**
Чтобы добавить элемент Media Player ActiveX, выполните следующие шаги:

1. Создайте экземпляр класса Presentation и загрузите пример презентации с элементом Media Player ActiveX.
2. Создайте экземпляр целевого класса Presentation и создайте пустой объект презентации.
3. Клонируйте слайд с элементом Media Player ActiveX из шаблонной презентации в целевую презентацию.
4. Получите клонированный слайд в целевой презентации.
5. Доступ к элементам ActiveX на слайде осуществляется через IControlCollection.
6. Доступ к элементу Media Player ActiveX и задание пути к видео с помощью его свойств.
7. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides

# Создание экземпляра класса Presentation, представляющего файл PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Создание пустой презентации
    with slides.Presentation() as newPresentation:

        # Удаление слайда по умолчанию
        newPresentation.slides.remove_at(0)

        # Клонирование слайда с элементом Media Player ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Доступ к элементу Media Player ActiveX и задание пути к видео
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Сохранение презентации
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Сохраняет ли Aspose.Slides элементы ActiveX при чтении и повторном сохранении, если они не могут быть выполнены в среде Python?**

Да. Aspose.Slides рассматривает их как часть презентации и может читать/изменять их свойства и рамки; выполнение самих элементов не требуется для их сохранения.

**Чем элементы ActiveX отличаются от OLE‑объектов в презентации?**

Элементы ActiveX — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/python-net/manage-ole/) относится к встроенным объектам приложений (например, лист Excel). Они хранятся и обрабатываются по‑разному и имеют разные модели свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён Aspose.Slides?**

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы выполняются только внутри PowerPoint на Windows, если политика безопасности это разрешает. Библиотека не выполняет VBA.