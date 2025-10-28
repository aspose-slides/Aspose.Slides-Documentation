---
title: Создать презентацию в Python
linktitle: Создать презентацию
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
description: "Создавайте презентации PowerPoint на Python с помощью Aspose.Slides — создавайте файлы PPT, PPTX и ODP, получайте преимущества поддержки OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Обзор**

Aspose.Slides for Python позволяет полностью в коде построить совершенно новую презентацию. Эта статья демонстрирует основной процесс — создание объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), получение первого слайда, вставку простой фигуры и сохранение результата — чтобы вы увидели, насколько минимум настроек нужен для генерации презентации без Microsoft Office. Поскольку один и тот же API записывает файлы PPT, PPTX и ODP, вы можете работать как с традиционными форматами PowerPoint, так и с OpenDocument из единой кодовой базы. Aspose.Slides подходит для настольных, веб‑ и серверных сред, предоставляя вашему Python‑приложению эффективную стартовую точку для добавления более богатого контента, такого как текст, изображения или диаграммы, после того как базовый набор слайдов готов.

## **Создать презентацию**

Создание PowerPoint‑файла с нуля в Aspose.Slides for Python так же просто, как создание экземпляра класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Конструктор автоматически предоставляет пустую презентацию с одним слайдом, давая вам мгновенно готовый холст для фигур, текста, диаграмм или любого другого контента, необходимого вашему приложению. После изменения этого слайда — или добавления новых — вы можете сохранить результат в PPTX, старый PPT или даже OpenDocument форматы. Небольшой пример кода ниже иллюстрирует этот процесс, добавляя простую фигуру на первый слайд.

1. Создать экземпляр класса [Presentation].
2. Получить ссылку на слайд по его индексу.
3. Добавить объект [AutoShape] типа `CLOUD` с помощью метода `add_auto_shape`, доступного через коллекцию `shapes`.
4. Добавить текст в автофигуру.
5. Сохранить изменённую презентацию как файл PPTX.

В примере ниже к первому слайду презентации добавлена облачная фигура.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto-shape of type CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Save the presentation as a PPTX file.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Новая презентация](new_presentation.png)

## **Часто задаваемые вопросы**

**В какие форматы я могу сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/python-net/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), [SVG](/slides/ru/python-net/convert-powerpoint-to-png/), и [изображения](/slides/ru/python-net/convert-powerpoint-to-png/), среди прочего.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужном формате; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/python-net/supported-file-formats/).

**Как управлять размером/соотношением сторон слайдов при создании презентации?**

Установите [размер слайда](/slides/ru/python-net/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и выберите способ масштабирования содержимого.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как работать с очень большими презентациями (с множеством медиа‑файлов), чтобы уменьшить потребление памяти?**

Используйте [стратегии управления BLOB](/slides/ru/python-net/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочтительно применяйте файловые рабочие процессы вместо полностью потоковых операций в памяти.

**Могу ли я создавать/сохранять презентации параллельно?**

Нельзя работать с одним и тем же объектом [Presentation] из [нескольких потоков](/slides/ru/python-net/multithreading/). Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

**Как убрать водяной знак версии для оценки и ограничения?**

[Примените лицензию](/slides/ru/python-net/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована при работе нескольких потоков.

**Могу ли я цифрово подписать создаваемый PPTX?**

Да. [Цифровые подписи](/slides/ru/python-net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/python-net/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.