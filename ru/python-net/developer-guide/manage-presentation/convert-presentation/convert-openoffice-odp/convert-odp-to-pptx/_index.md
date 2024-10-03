---
title: Конвертация ODP в PPTX
type: docs
weight: 10
url: /ru/python-net/convert-odp-to-pptx/
keywords: "Конвертация OpenOffice Презентации, ODP, ODP в PPTX, Python"
description: "Конвертация OpenOffice ODP в PowerPoint Презентацию PPTX на Python"
---

Aspose.Slides для Python через .NET предлагает класс Presentation, который представляет собой файл презентации. Класс [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) теперь также может получать доступ к ODP через конструктор Presentation при создании объекта. Следующий пример показывает, как конвертировать презентацию ODP в PPTX.

```py
# Импортируйте модуль Aspose.Slides для Python через .NET
import aspose.slides as slides

# Откройте файл ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Сохранение презентации ODP в формате PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Живой пример**
Вы можете посетить веб-приложение [**Конвертация Aspose.Slides**](https://products.aspose.app/slides/conversion/), которое создано с использованием **Aspose.Slides API.** Приложение демонстрирует, как может быть реализована конвертация ODP в PPTX с помощью Aspose.Slides API.