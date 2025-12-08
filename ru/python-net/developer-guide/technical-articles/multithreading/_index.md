---
title: Многопоточность в Aspose.Slides для Python
linktitle: Многопоточность
type: docs
weight: 200
url: /ru/python-net/multithreading/
keywords:
- многопоточность
- многопоточные задачи
- параллельная работа
- конвертация слайдов
- слайды в изображения
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Aspose.Slides для Python с помощью .NET многопоточности ускоряет обработку PowerPoint и OpenDocument. Откройте лучшие практики для эффективных рабочих процессов презентаций."
---

## **Введение**

Хотя параллельная работа с презентациями возможна (кроме парсинга/загрузки/клонирования) и в большинстве случаев всё проходит успешно, существует небольшая вероятность получения некорректных результатов при использовании библиотеки в нескольких потоках.

Мы настоятельно рекомендуем **не** использовать один экземпляр [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) в многопоточной среде, так как это может привести к непредсказуемым ошибкам или отказам, которые трудно обнаружить. 

Не безопасно загружать, сохранять и/или клонировать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) в нескольких потоках. Такие операции **не** поддерживаются. Если необходимо выполнять такие задачи, следует параллелить операции, используя несколько однопоточных процессов — каждый из этих процессов должен использовать свой собственный экземпляр презентации. 

## **Параллельное конвертирование слайдов презентации в изображения**

Допустим, мы хотим параллельно конвертировать все слайды PowerPoint‑презентации в PNG‑изображения. Поскольку использование одного экземпляра `Presentation` в нескольких потоках небезопасно, мы разбиваем слайды презентации на отдельные презентации и конвертируем слайды в изображения параллельно, используя каждую презентацию в отдельном потоке. Ниже приведён пример кода, показывающий, как это сделать.
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

        # Преобразовать слайд в изображение.
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


## **FAQ**

**Нужно ли вызывать настройку лицензии в каждом потоке?**

Нет. Достаточно сделать это один раз на процесс/домен приложения до запуска потоков. Если настройка [license setup](/slides/ru/python-net/licensing/) может вызываться одновременно (например, при ленивой инициализации), синхронизируйте этот вызов, так как метод настройки лицензии сам по себе не является потокобезопасным.

**Можно ли передавать объекты `Presentation` или `Slide` между потоками?**

Передача «живых» объектов презентации между потоками не рекомендуется: используйте независимые экземпляры для каждого потока или предварительно создайте отдельные презентации/контейнеры слайдов для каждого потока. Такой подход соответствует общему совету не делиться одним экземпляром презентации между потоками.

**Безопасно ли параллелить экспорт в разные форматы (PDF, HTML, изображения), если у каждого потока свой экземпляр `Presentation`?**

Да. При независимых экземплярах и отдельных путях вывода такие задачи обычно корректно параллелятся; избегайте общих объектов презентации и общих потоков ввода‑вывода.

**Что делать с глобальными настройками шрифтов (папки, подстановки) в многопоточном режиме?**

Инициализируйте все глобальные настройки шрифтов до запуска потоков и не меняйте их во время параллельной работы. Это устраняет гонки при доступе к общим ресурсам шрифтов.