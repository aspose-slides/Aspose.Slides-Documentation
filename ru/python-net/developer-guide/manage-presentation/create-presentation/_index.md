---
title: Создание презентаций на Python
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

Aspose.Slides for Python позволяет полностью в коде создать новую презентацию. В этой статье показан основной рабочий процесс — создание объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), получение первого слайда, вставка простой формы и сохранение результата — чтобы вы увидели, как мало настроек требуется для генерации презентации без Microsoft Office. Поскольку один и тот же API записывает файлы PPT, PPTX и ODP, вы можете работать как с традиционными форматами PowerPoint, так и с OpenDocument из единой кодовой базы. Aspose.Slides подходит для настольных, веб‑ и серверных сред, предоставляя вашему Python‑приложению эффективную отправную точку для добавления более богатого контента, такого как текст, изображения или диаграммы, после создания начального набора слайдов.

## **Создание презентации**

Создание файла PowerPoint с нуля в Aspose.Slides for Python так же просто, как создание экземпляра класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Конструктор автоматически предоставляет пустую презентацию с одним слайдом, давая вам сразу же холст для форм, текста, диаграмм или любого другого контента, необходимого вашему приложению. После изменения этого слайда — или добавления новых — можно сохранить результат в PPTX, старый PPT или даже в форматы OpenDocument. Краткий пример кода ниже иллюстрирует этот процесс, добавляя простую форму на первый слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `CLOUD`, используя метод `add_auto_shape`, доступный в коллекции `shapes`.
4. Добавьте текст в автоформу.
5. Сохраните изменённую презентацию как файл PPTX.

В примере ниже на первый слайд презентации добавлена облачная форма.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, который представляет файл презентации.
with slides.Presentation() as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автоформу типа CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Сохраните презентацию в файл PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![Новая презентация](new_presentation.png)

## **Часто задаваемые вопросы**

**В какие форматы я могу сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/python-net/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), [SVG](/slides/ru/python-net/convert-powerpoint-to-png/) и [изображения](/slides/ru/python-net/convert-powerpoint-to-png/), и многое другое.

**Можно ли начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/python-net/supported-file-formats/).

**Как контролировать размер/соотношение сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/python-net/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и выберите способ масштабирования содержимого.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм = 72 единицы.

**Как работать с очень большими презентациями (много медифайлов), чтобы снизить использование памяти?**

Используйте [стратегии управления BLOB](/slides/ru/python-net/manage-blob/), ограничивайте хранение в памяти, используя временные файлы, и предпочитайте файловые рабочие процессы вместо полностью оперативных потоков.

**Можно ли создавать/сохранять презентации параллельно?**

Нельзя работать с одним и тем же объектом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/python-net/multithreading/). Запускайте отдельные, изолированные экземпляры для каждого потока или процесса.

**Как удалить водяной знак trial и ограничения?**

[Примените лицензию](/slides/ru/python-net/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна синхронизироваться при работе нескольких потоков.

**Можно ли цифрово подписать создаваемый PPTX?**

Да. [Цифровые подписи](/slides/ru/python-net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/python-net/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.