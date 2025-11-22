---
title: Конвертировать слайды PowerPoint в PNG на Python
linktitle: Слайд в PNG
type: docs
weight: 30
url: /ru/python-net/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint в PNG
- конвертировать презентацию в PNG
- конвертировать слайд в PNG
- конвертировать PPT в PNG
- конвертировать PPTX в PNG
- конвертировать ODP в PNG
- PowerPoint в PNG
- презентация в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- ODP в PNG
- Python
- Aspose.Slides
description: "Конвертировать презентации PowerPoint и OpenDocument в высококачественные PNG-изображения быстро с помощью Aspose.Slides for Python via .NET, обеспечивая точные, автоматизированные результаты."
---

## **Обзор**

Aspose.Slides for Python via .NET упрощает преобразование презентаций PowerPoint в PNG. Вы загружаете презентацию, проходите её слайды, рендерите каждый в растровое изображение и сохраняете результат в виде файлов PNG. Это идеально подходит для создания превью слайдов, встраивания слайдов в веб-страниц или создания статических ресурсов для последующей обработки.

## **Преобразование слайдов в PNG**

В этом разделе показан самый простой пример преобразования презентации PowerPoint в изображения PNG с использованием Aspose.Slides for Python via .NET.

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите слайд из коллекции `Presentation.slides` (см. класс [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)).
3. Вызовите метод `Slide.get_image` для создания миниатюры слайда.
4. Вызовите метод `Presentation.save` для сохранения миниатюры слайда в формате PNG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **Преобразование слайдов в PNG с пользовательскими размерами**

Для экспорта слайдов в PNG с пользовательским масштабом вызовите `Slide.get_image`, передав коэффициенты горизонтального и вертикального масштабирования. Эти множители изменяют размер вывода относительно оригинальных размеров слайда — например, `2.0` удваивает и ширину, и высоту. Используйте одинаковые значения для `scale_x` и `scale_y`, чтобы сохранить пропорции.

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **Преобразование слайдов в PNG с пользовательским размером**

Если необходимо создать файлы PNG заданного размера, передайте желаемые значения `width` и `height`. Приведённый ниже код демонстрирует, как преобразовать PowerPoint в PNG, указав размер изображения: 

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


{{% alert title="Tip" color="primary" %}}
Возможно, вам будет интересно попробовать бесплатные **конвертеры PowerPoint в PNG** от Aspose — [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Они предоставляют живую реализацию процесса, описанного на этой странице.
{{% /alert %}}

## **FAQ**

**Как экспортировать только конкретную фигуру (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/python-net/create-shape-thumbnails/); вы можете отрендерить фигуру в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**

Да, но [не делите](/slides/ru/python-net/multithreading/) один экземпляр презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**

В режиме оценки к изображениям добавляется водяной знак, а также применяются [другие ограничения](/slides/ru/python-net/licensing/) до установки лицензии.