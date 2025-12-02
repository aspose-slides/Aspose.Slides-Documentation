---
title: Создание презентаций в Python
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/python-net/create-presentation/
keywords:
- создание презентации
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
description: "Создавайте презентации PowerPoint на Python с помощью Aspose.Slides — создавайте файлы PPT, PPTX и ODP, получайте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Обзор**

Aspose.Slides for Python позволяет полностью программно создавать новую презентацию. Эта статья демонстрирует основной процесс — создание объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), получение первого слайда, вставку простой фигуры и сохранение результата — чтобы вы увидели, насколько мало настроек требуется для генерации презентации без Microsoft Office. Поскольку один и тот же API записывает файлы PPT, PPTX и ODP, вы можете работать как с традиционным PowerPoint, так и с форматами OpenDocument из единой кодовой базы. Aspose.Slides подходит для настольных, веб‑ и серверных сред, предоставляя вашему Python‑приложению эффективную отправную точку для добавления более богатого контента, например текста, изображений или диаграмм, после создания базовой колоды слайдов.

## **Создание презентации**

Создание PowerPoint‑файла с нуля в Aspose.Slides for Python так же просто, как создание экземпляра класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Конструктор автоматически создает пустую презентацию с одним слайдом, предоставляя сразу же холст для фигур, текста, диаграмм или любого другого контента, необходимого вашему приложению. После изменения этого слайда — или добавления новых — вы можете сохранить результат в PPTX, старый PPT или даже форматы OpenDocument. Краткий пример кода ниже иллюстрирует этот процесс добавлением простой фигуры на первый слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `CLOUD`, используя метод `add_auto_shape`, доступный в коллекции `shapes`.
1. Добавьте текст в автофигуру.
1. Сохраните изменённую презентацию как файл PPTX.

В примере ниже на первый слайд презентации добавлена облачная фигура.
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, который представляет файл презентации.
with slides.Presentation() as presentation:
    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить автофигуру типа CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Сохранить презентацию как файл PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![Новая презентация](new_presentation.png)

## **Вопросы и ответы**

**В каких форматах можно сохранить новую презентацию?**

Можно сохранять в [PPTX, PPT и ODP](/slides/ru/python-net/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), [SVG](/slides/ru/python-net/convert-powerpoint-to-png/) и [изображения](/slides/ru/python-net/convert-powerpoint-to-png/), и др.

**Можно ли начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужном формате; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/python-net/supported-file-formats/).

**Как задать размер/соотношение сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/python-net/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и выберите способ масштабирования контента.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм = 72 пункта.

**Как уменьшить использование памяти при работе с очень большими презентациями (много медиа‑файлов)?**

Используйте [стратегии управления BLOB](/slides/ru/python-net/manage-blob/), ограничивайте хранение в памяти, используя временные файлы, и предпочтительно применяйте файловые потоки вместо полностью оперативных.

**Можно ли создавать/сохранять презентации параллельно?**

Нельзя работать с одним экземпляром [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/python-net/multithreading/). Запускайте отдельные изолированные экземпляры в каждом потоке или процессе.

**Как убрать водяной знак пробной версии и ограничения?**

[Примените лицензию](/slides/ru/python-net/licensing/) один раз для процесса. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована при работе нескольких потоков.

**Можно ли цифрово подписать создаваемый PPTX?**

Да. [Цифровые подписи](/slides/ru/python-net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/python-net/presentation-via-vba/) и сохранять файлы с макросами, такие как PPTM/PPSM.