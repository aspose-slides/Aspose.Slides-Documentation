---
title: Создание презентаций в Python
linktitle: Создание презентации
type: docs
weight: 10
url: /ru/python-net/create-presentation/
keywords:
- создать презентацию
- новая презентация
- создать PPT
- новый PPT
- создать PPTX
- новый PPTX
- создать ODP
- новый ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Создавайте презентации PowerPoint на Python с помощью Aspose.Slides - создавайте файлы PPT, PPTX и ODP, пользуйтесь поддержкой OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Обзор**

Aspose.Slides for Python позволяет создать полностью новую презентацию программным способом. Эта статья демонстрирует основной рабочий процесс — создание объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), получение первого слайда, добавление простой фигуры и сохранение результата — чтобы вы увидели, как мало настроек требуется для генерации презентации без Microsoft Office. Поскольку один и тот же API записывает файлы PPT, PPTX и ODP, вы можете работать как с традиционными форматами PowerPoint, так и с OpenDocument из единой кодовой базы. Aspose.Slides подходит для настольных, веб‑ и серверных сред, предоставляя вашему Python‑приложению эффективную отправную точку для добавления более богатого контента, такого как текст, изображения или диаграммы, после создания базовой колоды слайдов.

## **Создание презентации**

Создание PowerPoint‑файла с нуля в Aspose.Slides for Python так же просто, как инстанцировать класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Конструктор автоматически предоставляет пустую презентацию с одним слайдом, давая вам сразу же полотно для фигур, текста, диаграмм или любого другого содержания, необходимого вашему приложению. После того как вы измените этот слайд — или добавите новые — вы можете сохранить результат в PPTX, устаревший PPT или даже форматы OpenDocument. Ниже приведён короткий пример кода, который иллюстрирует этот процесс, добавляя простую фигуру на первый слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `CLOUD` с помощью метода `add_auto_shape`, доступного в коллекции `shapes`.
1. Добавьте текст в автофигуру.
1. Сохраните изменённую презентацию в файл PPTX.

В примере ниже к первому слайду презентации добавлена облачная фигура.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Сохраните презентацию в файл PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The new presentation](new_presentation.png)

## **Вопросы и ответы**

**В какие форматы я могу сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/python-net/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), [SVG](/slides/ru/python-net/convert-powerpoint-to-png/), и [изображения](/slides/ru/python-net/convert-powerpoint-to-png/), среди прочего.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и подобные [поддерживаются](/slides/ru/python-net/supported-file-formats/).

**Как задать размер/соотношение сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/python-net/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите способ масштабирования содержимого.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как работать с очень большими презентациями (с множеством медиа‑файлов), чтобы уменьшить расход памяти?**

Используйте [Стратегии управления BLOB](/slides/ru/python-net/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и отдавайте предпочтение файловым процессам вместо полностью оперативных потоков.

**Могу ли я создавать/сохранять презентации параллельно?**

Вы не можете работать с тем же объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/python-net/multithreading/). Запускайте отдельные изолированные экземпляры на каждый поток или процесс.

**Как удалить водяной знак пробной версии и ограничения?**

[Применить лицензию](/slides/ru/python-net/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться без изменений, а настройку лицензии следует синхронизировать, если используется несколько потоков.

**Могу ли я цифрово подписать созданный PPTX?**

Да. [Цифровые подписи](/slides/ru/python-net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в создаваемых презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/python-net/presentation-via-vba/) и сохранять файлы с включёнными макросами, такие как PPTM/PPSM.