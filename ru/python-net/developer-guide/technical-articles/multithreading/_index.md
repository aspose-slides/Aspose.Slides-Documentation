---
title: Многопоточность в Aspose.Slides для Python
linktitle: Многопоточность
type: docs
weight: 200
url: /ru/python-net/multithreading/
keywords:
- многопоточность
- множество потоков
- параллельная работа
- конвертация слайдов
- слайды в изображения
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Aspose.Slides для Python через .NET многопоточность ускоряет обработку PowerPoint и OpenDocument. Узнайте лучшие практики эффективных рабочих процессов с презентациями."
---

## **Введение**

Хотя параллельная работа с презентациями возможна (кроме парсинга/загрузки/клонирования) и обычно всё проходит гладко (в большинстве случаев), существует небольшая вероятность получения неверных результатов при использовании библиотеки в нескольких потоках.

Мы настоятельно рекомендуем **не** использовать один экземпляр [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) в многопоточном окружении, так как это может привести к непредсказуемым ошибкам или сбоям, которые сложно обнаружить.

Неправильно загружать, сохранять и/или клонировать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) в нескольких потоках. Такие операции **не поддерживаются**. Если вам нужно выполнять такие задачи, распараллельте операции, используя несколько однопоточных процессов — каждый из этих процессов должен использовать свой собственный экземпляр презентации.

## **Конвертация слайдов презентации в изображения параллельно**

Предположим, что нужно конвертировать все слайды PowerPoint‑презентации в PNG‑изображения параллельно. Поскольку использовать один объект `Presentation` в нескольких потоках небезопасно, мы разбиваем слайды презентации на отдельные презентации и конвертируем слайды в изображения параллельно, используя каждый объект презентации в отдельном потоке. Ниже показан пример кода.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Извлечь слайд i в отдельную презентацию.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Конвертировать слайд в изображение.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Дождаться завершения всех задач.
for task in conversion_tasks:
    task.result()

del presentation
```

## **Часто задаваемые вопросы**

**Нужно ли вызывать настройку лицензии в каждом потоке?**

Нет. Достаточно выполнить её один раз для процесса/домена приложений до запуска потоков. Если [настройка лицензии](/slides/ru/python-net/licensing/) может вызываться одновременно (например, при ленивой инициализации), синхронизируйте этот вызов, потому что сам метод настройки лицензии не является потокобезопасным.

**Можно ли передавать объекты `Presentation` или `Slide` между потоками?**

Передача «живых» объектов презентации между потоками не рекомендуется: используйте независимые экземпляры для каждого потока или предварительно создайте отдельные презентации/контейнеры слайдов для каждого потока. Такой подход соответствует общему совету не делить один объект презентации между потоками.

**Безопасно ли параллелить экспорт в различные форматы (PDF, HTML, изображения), если каждый поток имеет свой собственный экземпляр `Presentation`?**

Да. При наличии независимых экземпляров и отдельных путей вывода такие задачи обычно успешно параллелятся; избегайте общих объектов презентации и общих потоков ввода‑вывода.

**Что делать с глобальными настройками шрифтов (папки, подстановки) в многопоточном режиме?**

Инициализируйте все глобальные настройки шрифтов до запуска потоков и не меняйте их во время параллельной работы. Это устраняет гонки при обращении к общим ресурсам шрифтов.