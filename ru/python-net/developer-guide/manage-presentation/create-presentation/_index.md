---
title: Создание презентаций на Python
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

В этой статье показано, как создать презентацию с помощью Aspose.Slides для Python через .NET, добавить форму с текстом на первый слайд и сохранить результат в файл PPTX. Тот же API также сохраняет презентации как PPT и ODP, поэтому вы можете работать с форматами PowerPoint и OpenDocument из одной кодовой базы, без Microsoft Office. Краткий FAQ в конце охватывает часто задаваемые вопросы о форматах, шаблонах, размере слайдов, единицах измерения, использовании памяти, многопоточности, лицензировании, цифровой подписи и поддержке VBA.

Перед началом установите пакет из PyPI с помощью `pip install aspose.slides`. См.[Установка](/slides/ru/python-net/installation/) для библиотек, необходимых также на Linux и macOS, а также для виртуального окружения, требуемого системным Python в Debian и Ubuntu.

## **Создать презентацию**

Чтобы создать презентацию и разместить форму с текстом на её первом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Новая презентация уже содержит один пустой слайд.
2. Получите этот слайд из коллекции [slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/slides/ru/) по индексу 0.
3. Добавьте облакообразную [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) с помощью метода [add_auto_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_auto_shape/) коллекции [shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/shapes/) слайда и установите её [text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/text/).
4. Сохраните презентацию в файл PPTX с помощью метода [save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/).

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

Левый верхний угол облака находится на расстоянии 20 пунктов от левой границы и 20 пунктов от верхней границы слайда, а ширина облака составляет 200 пунктов, а высота — 80 пунктов. Оператор `with` освобождает ресурсы презентации по завершении блока. Скрипт сохраняет *new_presentation.pptx* в текущей папке, содержащий один слайд с облаком и его текстом. Без лицензии Aspose.Slides также добавляет водяной знак оценки к каждому сохраняемому слайду; см. [Licensing](/slides/ru/python-net/licensing/).

Результат:

![Новая презентация](new_presentation.png)

## **FAQ**

### Какие форматы доступны для сохранения новой презентации?

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/python-net/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), [SVG](/slides/ru/python-net/render-a-slide-as-an-svg-image/), и [изображения](/slides/ru/python-net/convert-powerpoint-to-png/), среди прочего.

### Можно ли начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/python-net/supported-file-formats/).

### Как управлять размером/соотношением сторон слайда при создании презентации?

Установите [slide size](/slides/ru/python-net/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и выберите, как должно масштабироваться содержимое.

### В каких единицах измеряются размеры и координаты?

В пунктах: 1 дюйм равен 72 единицам.

### Как работать с очень большими презентациями (с множеством медиафайлов), чтобы сократить использование памяти?

Используйте [BLOB management strategies](/slides/ru/python-net/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочтительно применяйте файловые рабочие процессы вместо полностью в‑памяти потоков.

### Можно ли создавать/сохранять презентации параллельно?

Вы не можете работать с тем же экземпляром [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/python-net/multithreading/). Запускайте отдельные, изолированные экземпляры для каждого потока или процесса.

### Как удалить пробный водяной знак и ограничения?

[Применить лицензию](/slides/ru/python-net/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна синхронизироваться, если задействовано несколько потоков.

### Можно ли цифрово подписать создаваемый PPTX?

Да. [Digital signatures](/slides/ru/python-net/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

### Поддерживаются ли макросы (VBA) в созданных презентациях?

Да. Вы можете [create/edit VBA projects](/slides/ru/python-net/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.