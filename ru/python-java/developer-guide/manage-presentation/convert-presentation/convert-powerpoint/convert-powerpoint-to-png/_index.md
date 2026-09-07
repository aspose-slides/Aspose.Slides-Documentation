---
title: Конвертировать слайды PowerPoint в PNG на Python
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/python-java/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- Python
- Java
- Aspose.Slides
description: "Конвертировать слайды PowerPoint в PNG‑изображения на Python через Java. Экспортировать презентации PPT, PPTX и ODP с пользовательскими масштабами или точными размерами изображений."
---
## **Обзор**

В этой статье объясняется, как конвертировать презентации PowerPoint в изображения PNG с помощью Aspose.Slides for Python via Java. Вы можете загружать файлы PPT, PPTX и ODP, рендерить каждый слайд и сохранять его как отдельное изображение PNG.  

Примеры также демонстрируют, как управлять размерами вывода с помощью коэффициентов масштабирования или точных ширины и высоты. Каждый пример при необходимости запускает виртуальную машину Java и освобождает ресурсы презентации и изображения после использования.

## **Конвертировать PowerPoint в PNG**

1. Загрузите входной файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите слайды, используя [Presentation.getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides).
3. Отрендерьте каждый слайд с помощью [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage).
4. Сохраните каждое отрендеренное изображение с помощью [ImageFormat.Png](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imageformat/#Png), затем освободите его ресурсы.

Следующий пример на Python экспортирует все слайды в их размере по умолчанию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Конвертировать PowerPoint в PNG с пользовательским масштабом**

Передайте горизонтальные и вертикальные коэффициенты масштабирования в [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage), чтобы увеличить или уменьшить размеры вывода. Например, слайд размером 720 × 540 пунктов, отрендеренный с коэффициентом масштабирования 2 по обоим осям, создаст изображение 1440 × 1080 пикселей.  

Используйте одинаковые коэффициенты масштабирования, чтобы сохранить соотношение сторон слайда. Разные коэффициенты растягивают слайд по горизонтали или вертикали.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Конвертировать PowerPoint в PNG с пользовательским размером**

Чтобы указать точные размеры в пикселях, передайте объект Java `Dimension` с требуемой шириной и высотой в [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage). Выбирайте размеры с тем же соотношением сторон, что и у исходного слайда, чтобы избежать искажения.  

Следующий пример сохраняет каждый слайд как PNG‑изображение размером 960 × 720 пикселей:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я экспортировать отдельную форму, например диаграмму или изображение, вместо всего слайда?**  
Да. Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/python-java/create-shape-thumbnails/), которые можно сохранять как PNG‑изображения.

**Могу ли я конвертировать презентации параллельно на сервере?**  
Используйте отдельный экземпляр презентации для каждого потока или процесса и уникальные пути вывода, чтобы файлы не перезаписывались. Не используйте один экземпляр презентации в нескольких потоках. См. [Многопоточность](/slides/ru/python-java/multithreading/).

**Каковы ограничения trial‑версии при экспорте в PNG?**  
Режим оценки добавляет водяной знак к выходным изображениям и применяет [другие ограничения](/slides/ru/python-java/licensing/). Примените лицензию, чтобы снять эти ограничения.