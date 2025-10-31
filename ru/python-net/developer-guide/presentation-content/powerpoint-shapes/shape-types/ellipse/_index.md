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
description: "Узнайте, как создавать, форматировать и изменять формы эллипса в Aspose.Slides for Python via .NET для презентаций PPT, PPTX и ODP — включены примеры кода."
---

## **Создать эллипс**
В этой теме мы расскажем разработчикам, как добавлять формы эллипса на их слайды с помощью Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET предоставляет более простой набор API для рисования различных форм всего в несколько строк кода. Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Получите ссылку на слайд, используя его Index
3. Добавьте AutoShape типа Ellipse, используя метод AddAutoShape, предоставленный объектом IShapes
4. Сохраните изменённую презентацию в файл PPTX

В приведённом ниже примере мы добавили эллипс на первый слайд.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить AutoShape типа ellipse
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Сохранить файл PPTX на диск
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Создать отформатированный эллипс**
Чтобы добавить более отформатированный эллипс на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Получите ссылку на слайд, используя его Index
3. Добавьте AutoShape типа Ellipse, используя метод AddAutoShape, предоставленный объектом IShapes
4. Установите тип заливки эллипса как Solid
5. Установите цвет заливки эллипса с помощью свойства SolidFillColor.Color, предоставленного объектом FillFormat, связанным с объектом IShape
6. Установите цвет линий эллипса
7. Установите ширину линий эллипса
8. Сохраните изменённую презентацию в файл PPTX

В приведённом ниже примере мы добавили отформатированный эллипс на первый слайд презентации.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить AutoShape типа ellipse
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Применить форматирование к форме эллипса
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Применить форматирование к линии эллипса
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Сохранить файл PPTX на диск
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Как задать точную позицию и размер эллипса относительно единиц измерения слайда?**

Координаты и размеры обычно указываются **в пунктах**. Чтобы получить предсказуемые результаты, основывайте расчёты на размере слайда и преобразуйте требуемые миллиметры или дюймы в пункты перед присвоением значений.

**Как разместить эллипс выше или ниже других объектов (управление порядком наложения)?**

Отрегулируйте порядок рисования объекта, переместив его на передний план или отправив назад. Это позволяет эллипсу перекрывать другие объекты или показывать находящиеся под ним.

**Как анимировать появление или акцентирование эллипса?**

[Применить](/slides/ru/python-net/shape-animation/) эффекты входа, акцентирования или выхода к форме и настроить триггеры и тайминг, чтобы определить, когда и как воспроизводится анимация.