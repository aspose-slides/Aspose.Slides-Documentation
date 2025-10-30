---
title: Создать презентацию на Python
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
description: "Создавайте презентации PowerPoint на Python с помощью Aspose.Slides — создавайте файлы PPT, PPTX и ODP, используйте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Обзор**

Aspose.Slides for Python позволяет полностью в коде создавать новый файл презентации. Эта статья показывает основной рабочий процесс — создание объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , получение первого слайда, вставка простой фигуры и сохранение результата — чтобы вы увидели, насколько мало настроек требуется для генерации презентации без Microsoft Office. Поскольку один и тот же API пишет файлы PPT, PPTX и ODP, вы можете работать как с традиционными PowerPoint, так и с форматами OpenDocument из единой кодовой базы. Aspose.Slides подходит для настольных, веб‑ или серверных окружений, предоставляя вашему приложению на Python эффективную отправную точку для добавления более богатого контента, такого как текст, изображения или диаграммы, после создания начального набора слайдов.

## **Создание презентации**

Создание файла PowerPoint с нуля в Aspose.Slides for Python так же просто, как создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Конструктор автоматически предоставляет пустую презентацию с одним слайдом, давая вам сразу же холст для фигур, текста, диаграмм или любого другого контента, который нужен вашему приложению. После того как вы измените этот слайд — или добавите новые — вы можете сохранить результат в PPTX, устаревший PPT или даже форматы OpenDocument. Краткий пример кода ниже иллюстрирует этот процесс, добавляя простую фигуру на первый слайд.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получить ссылку на слайд по его индексу.
3. Добавить объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа CLOUD, используя метод `add_auto_shape` коллекции `shapes`.
4. Добавить текст в автоформу.
5. Сохранить изменённую презентацию в файл PPTX.

В приведённом ниже примере к первой слайду презентации добавляется облако.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, который представляет файл презентации.
with slides.Presentation() as presentation:
    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить автоформу типа CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Сохранить презентацию в файл PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Новая презентация](new_presentation.png)

## **Часто задаваемые вопросы**

**В какие форматы я могу сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/python-net/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), [SVG](/slides/ru/python-net/convert-powerpoint-to-png/) и [изображения](/slides/ru/python-net/convert-powerpoint-to-png/), среди прочих.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в желаемый формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/python-net/supported-file-formats/).

**Как управлять размером/соотношением сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/python-net/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите, как должен масштабироваться контент.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как работать с очень большими презентациями (с множеством медиафайлов), чтобы снизить расход памяти?**

Используйте [стратегии управления BLOB](/slides/ru/python-net/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и отдавайте предпочтение файловым воркфлоу вместо полностью потоковых решений в памяти.

**Можно ли создавать/сохранять презентации параллельно?**

Вы не можете работать с тем же [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) из [многих потоков](/slides/ru/python-net/multithreading/). Запускайте отдельные изолированные экземпляры на каждый поток или процесс.

**Как удалить пробный водяной знак и ограничения?**

[Применить лицензию](/slides/ru/python-net/licensing/) один раз за процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована, если задействовано несколько потоков.

**Могу ли я добавить цифровую подпись к создаваемому PPTX?**

Да. [Цифровые подписи](/slides/ru/python-net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/python-net/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.