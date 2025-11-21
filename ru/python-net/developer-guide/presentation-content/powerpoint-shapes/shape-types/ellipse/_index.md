---
title: Добавление эллипсов в презентации на Python
linktitle: Эллипс
type: docs
weight: 30
url: /ru/python-net/ellipse/
keywords:
- эллипс
- форма
- добавить эллипс
- создать эллипс
- нарисовать эллипс
- отформатированный эллипс
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать, форматировать и управлять формами эллипсов в Aspose.Slides for Python via .NET в презентациях PPT, PPTX и ODP — включены примеры кода."
---

## **Создать эллипс**
В этой статье мы расскажем разработчикам, как добавить форму эллипса на слайды с помощью Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET предоставляет упрощённый набор API для рисования различных фигур всего в несколько строк кода. Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Получите ссылку на слайд, используя его Index
3. Добавьте AutoShape типа Ellipse с помощью метода AddAutoShape, доступного через объект IShapes
4. Сохраните изменённую презентацию в файл PPTX

В примере ниже мы добавили эллипс на первый слайд.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить автофигуру типа эллипс
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Записать файл PPTX на диск
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Создать отформатированный эллипс**
Чтобы добавить более отформатированный эллипс на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Получите ссылку на слайд, используя его Index
3. Добавьте AutoShape типа Ellipse с помощью метода AddAutoShape, доступного через объект IShapes
4. Установите Fill Type эллипса в Solid
5. Задайте цвет эллипса через свойство SolidFillColor.Color объекта FillFormat, связанного с объектом IShape
6. Задайте цвет линий эллипса
7. Задайте толщину линий эллипса
8. Сохраните изменённую презентацию в файл PPTX

В примере ниже мы добавили отформатированный эллипс на первый слайд презентации.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить автофигуру типа эллипс
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Применить некоторое форматирование к форме эллипса
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Применить некоторое форматирование к линии эллипса
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Записать файл PPTX на диск
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Как задать точное положение и размер эллипса относительно единиц измерения слайда?**

Координаты и размеры обычно указываются **в пунктах**. Для предсказуемых результатов рассчитывайте на основе размеров слайда и преобразуйте требуемые миллиметры или дюймы в пункты перед присвоением значений.

**Как разместить эллипс выше или ниже других объектов (управление порядком наложения)?**

Измените порядок отрисовки объекта, переместив его на передний план или отправив назад. Это позволит эллипсу перекрывать другие объекты или показывать те, что находятся под ним.

**Как анимировать появление или акцентирование эллипса?**

[Apply](/slides/ru/python-net/shape-animation/) входные, акцентные или выходные эффекты к форме, а также настройте триггеры и тайминг, чтобы определить, когда и как будет воспроизводиться анимация.