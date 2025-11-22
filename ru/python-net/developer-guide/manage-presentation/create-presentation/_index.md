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
description: "Создавайте презентации PowerPoint на Python с помощью Aspose.Slides—создавайте файлы PPT, PPTX и ODP, получайте преимущества поддержки OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Обзор**

Aspose.Slides for Python позволяет полностью создавать новый файл презентации с помощью кода. Эта статья демонстрирует основной рабочий процесс — создание объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), получение первого слайда, вставку простой формы и сохранение результата — чтобы вы увидели, как мало настроек требуется для генерации презентации без Microsoft Office. Поскольку один и тот же API записывает файлы PPT, PPTX и ODP, вы можете работать как с традиционными форматами PowerPoint, так и с OpenDocument из единой кодовой базы. Aspose.Slides подходит для настольных, веб‑ и серверных сред, предоставляя вашему Python‑приложению эффективную отправную точку для добавления более богатого контента, такого как текст, изображения или диаграммы, после создания базовой колоды слайдов.

## **Создание презентации**

Создание файла PowerPoint с нуля в Aspose.Slides for Python так же просто, как создание экземпляра класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Конструктор автоматически создает пустую презентацию с одним слайдом, предоставляя вам сразу готовое полотно для фигур, текста, диаграмм или любого другого контента, необходимого вашему приложению. После изменения этого слайда — либо после добавления новых — вы можете сохранить результат в PPTX, устаревший PPT или даже в форматы OpenDocument. Небольшой пример кода ниже иллюстрирует этот процесс, добавляя простую форму на первый слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `CLOUD`, используя метод `add_auto_shape`, предоставляемый коллекцией `shapes`.
1. Добавьте текст в автокоманду.
1. Сохраните изменённую презентацию как файл PPTX.

В примере ниже к первому слайду презентации добавляется облачная форма.
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

![Новая презентация](new_presentation.png)

## **Часто задаваемые вопросы**

**В какие форматы можно сохранить новую презентацию?**

Можно сохранять в [PPTX, PPT и ODP](/slides/ru/python-net/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), [SVG](/slides/ru/python-net/convert-powerpoint-to-png/) и [изображения](/slides/ru/python-net/convert-powerpoint-to-png/), среди прочих.

**Можно ли начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/python-net/supported-file-formats/).

**Как управлять размером/соотношением сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/python-net/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и задайте, как должен масштабироваться контент.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как работать с очень большими презентациями (много медиа‑файлов), чтобы снизить потребление памяти?**

Используйте стратегии управления [BLOB](/slides/ru/python-net/manage-blob/), ограничивайте хранение в памяти, используя временные файлы, и предпочтительно применяйте файловые рабочие процессы вместо полностью памятиных потоков.

**Можно ли создавать/сохранять презентации параллельно?**

Вы не можете работать с одним и тем же объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/python-net/multithreading/). Запускайте отдельные изолированные экземпляры на каждый поток или процесс.

**Как удалить пробный водяной знак и ограничения?**

[Примените лицензию](/slides/ru/python-net/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована при использовании нескольких потоков.

**Можно ли цифрово подписать созданный PPTX?**

Да. [Цифровые подписи](/slides/ru/python-net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/python-net/presentation-via-vba/) и сохранять файлы с включёнными макросами, такие как PPTM/PPSM.