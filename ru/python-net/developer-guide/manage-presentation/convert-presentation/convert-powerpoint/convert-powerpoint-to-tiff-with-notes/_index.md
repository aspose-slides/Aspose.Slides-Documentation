---
title: Конвертация PowerPoint в TIFF с заметками
type: docs
weight: 100
url: /ru/python-net/convert-powerpoint-to-tiff-with-notes/
keywords: "Конвертация PowerPoint в TIFF с заметками"
description: "Конвертация PowerPoint в TIFF с заметками в Aspose.Slides."
---

{{% alert title="Совет" color="primary" %}}

Вам может быть интересно ознакомиться с бесплатным конвертером PowerPoint в постер от Aspose [БЕСПЛАТНЫЙ конвертер PowerPoint в постер](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

TIFF является одним из нескольких широко используемых форматов изображений, которые Aspose.Slides для Python через .NET поддерживает для конвертации презентаций PowerPoint PPT и PPTX с заметками в изображения. Вы также можете создавать миниатюры слайдов в представлении заметок слайдов. Метод [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса Presentation может быть использован для конвертации всей презентации в представлении заметок слайдов в TIFF. Сохранение презентации Microsoft PowerPoint в TIFF с заметками с использованием Aspose.Slides для Python через .NET — это процесс из двух строк. Вы просто открываете презентацию и сохраняете ее в формат TIFF с заметками. Вы также можете создавать миниатюры слайдов в представлении заметок для отдельных слайдов. Приведенные ниже фрагменты кода обновляют пример презентации в TIFF изображения в представлении заметок, как показано ниже:

```py
import aspose.slides as slides

# Создание объекта Presentation, который представляет файл презентации
presentation = slides.Presentation("pres.pptx")

# Сохранение презентации в TIFF с заметками
presentation.save("Notes_In_Tiff_out.tiff", slides.export.SaveFormat.TIFF)
```