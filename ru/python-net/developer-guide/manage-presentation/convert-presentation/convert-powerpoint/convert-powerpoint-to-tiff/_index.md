---
title: Конвертация PowerPoint в TIFF
type: docs
weight: 90
url: /python-net/convert-powerpoint-to-tiff/
keywords: "Конвертация презентации PowerPoint, PowerPoint в TIFF, PPT в TIFF, PPTX в TIFF, Python, Aspose.Slides"
description: "Конвертация презентации PowerPoint в TIFF на Python"
---

**TIFF** (формат файла с метками изображений) — это без потерь растровый и качественный формат изображения. Профессионалы используют TIFF для своих дизайнерских, фотографических и издательских целей. Например, если вы хотите сохранить слои и настройки в своем дизайне или изображении, вы можете сохранить свою работу в виде TIFF-файла изображения.

Aspose.Slides позволяет вам конвертировать слайды в PowerPoint напрямую в TIFF.

{{% alert title="Совет" color="primary" %}}

Вы можете ознакомиться с [БЕСПЛАТНЫМ конвертером PowerPoint в постер](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) от Aspose.

{{% /alert %}}

## **Конвертация PowerPoint в TIFF**

Используя метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods), предоставленный классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), вы можете быстро конвертировать всю презентацию PowerPoint в TIFF. Полученные TIFF-изображения соответствуют стандартному размеру слайдов.

Этот код на Python показывает, как конвертировать PowerPoint в TIFF:

```python
import aspose.slides as slides

# Инициализация объекта Presentation, представляющего файл презентации
presentation = slides.Presentation("pres.pptx")
# Сохранение презентации как TIFF
presentation.save("Tiffoutput_out.tiff", slides.export.SaveFormat.TIFF)
```

## **Конвертация PowerPoint в черно-белый TIFF**

В Aspose.Slides 23.10 добавлено новое свойство `bw_conversion_mode` в класс [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/), которое позволяет вам указать алгоритм, который используется при конвертации цветного слайда или изображения в черно-белый TIFF. Обратите внимание, что эта настройка применяется только в том случае, если свойство `compression_type` установлено на `CCITT4` или `CCITT3`.

Этот код на Python показывает, как конвертировать цветной слайд или изображение в черно-белый TIFF:

```python
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

presentation = slides.Presentation("sample.pptx")
presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Конвертация PowerPoint в TIFF с заданным размером**

Если вам требуется TIFF-изображение с определенными размерами, вы можете задать ваши предпочтительные параметры через свойства, предоставленные в [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/). Например, используя свойство `image_size`, вы можете установить размер для полученного изображения.

Этот код на Python показывает, как конвертировать PowerPoint в TIFF-изображения с заданным размером:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

# Инициализация объекта Presentation, представляющего файл презентации
pres = slides.Presentation("pres.pptx")

# Инициализация класса TiffOptions
opts = slides.export.TiffOptions()

# Установка типа сжатия
opts.compression_type = slides.export.TiffCompressionTypes.DEFAULT
opts.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Установка DPI изображения
opts.dpi_x = 200
opts.dpi_y = 100

# Установка размера изображения
opts.image_size = drawing.Size(1728, 1078)

# Сохранение презентации в TIFF с указанным размером
pres.save("TiffWithCustomSize_out.tiff", slides.export.SaveFormat.TIFF, opts)
```

## **Конвертация PowerPoint в TIFF с заданным форматом пикселя изображения**

Используя свойство `pixel_format` в классе [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/), вы можете указать предпочтительный формат пикселей для полученного TIFF-изображения.

Этот код на Python показывает, как конвертировать PowerPoint в TIFF-изображение с заданным форматом пикселя:

```python
import aspose.slides as slides

# Инициализация объекта Presentation, представляющего файл презентации
pres = slides.Presentation("pres.pptx")

# Инициализация класса TiffOptions
options = slides.export.TiffOptions()

options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED

# Сохранение презентации в TIFF с указанным форматом изображения
pres.save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", slides.export.SaveFormat.TIFF, options)
```