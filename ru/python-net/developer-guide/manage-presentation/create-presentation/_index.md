---
title: Создать презентацию на Python
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
description: "Создавайте презентации PowerPoint на Python с помощью Aspose.Slides — генерируйте файлы PPT, PPTX и ODP, получайте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Обзор**

Aspose.Slides for Python позволяет полностью в коде создать новую презентацию. В этой статье показан базовый процесс — создание объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), получение первого слайда, добавление простой фигуры и сохранение результата — чтобы вы увидели, как мало требуется настроек для генерации презентации без Microsoft Office. Поскольку один и тот же API записывает файлы PPT, PPTX и ODP, вы можете работать как с традиционным PowerPoint, так и с форматами OpenDocument из единой кодовой базы. Aspose.Slides подходит для настольных, веб‑ и серверных окружений, предоставляя вашему Python‑приложению эффективный старт для добавления более сложного контента, такого как текст, изображения или диаграммы, после создания начального набора слайдов.

## **Создать презентацию**

Создание файла PowerPoint с нуля в Aspose.Slides for Python столь же просто, как инстанцирование класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Конструктор автоматически создает пустую презентацию с одним слайдом, предоставляя вам сразу холст для фигур, текста, диаграмм или любого другого контента, необходимого вашему приложению. После изменения этого слайда — или добавления новых — вы можете сохранить результат в PPTX, устаревший PPT или даже форматы OpenDocument. Ниже приведён короткий пример кода, демонстрирующий процесс добавления простой фигуры на первый слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `CLOUD` с помощью метода `add_auto_shape`, доступного в коллекции `shapes`.
1. Вставьте текст в автоконтур.
1. Сохраните изменённую презентацию как файл PPTX.

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

## **Вопросы и ответы**

**В какие форматы можно сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/python-net/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), [SVG](/slides/ru/python-net/convert-powerpoint-to-png/) и [изображения](/slides/ru/python-net/convert-powerpoint-to-png/), среди прочих.

**Можно ли начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в требуемом формате; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/python-net/supported-file-formats/).

**Как управлять размером/соотношением сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/python-net/slide-size/) (включая готовые варианты 4:3 и 16:9 или пользовательские размеры) и выберите, как должен масштабироваться контент.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм = 72 единицы.

**Как работать с очень большими презентациями (много медиа‑файлов), чтобы снизить расход памяти?**

Используйте [стратегии управления BLOB](/slides/ru/python-net/manage-blob/), ограничивая хранение в памяти за счёт временных файлов, и отдавайте предпочтение файловым рабочим процессам вместо полностью потоковых операций в памяти.

**Можно ли создавать/сохранять презентации параллельно?**

Вы не можете работать с одним и тем же экземпляром [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/python-net/multithreading/). Запускайте отдельные изолированные экземпляры на каждый поток или процесс.

**Как удалить тестовую водяную метку и ограничения?**

[Примените лицензию](/slides/ru/python-net/licensing/) один раз за процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована при работе нескольких потоков.

**Можно ли цифрово подписать создаваемый PPTX?**

Да. [Цифровые подписи](/slides/ru/python-net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать VBA‑проекты](/slides/ru/python-net/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.