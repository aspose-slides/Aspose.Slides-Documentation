---
title: Convertir PPTX a PPT en Python
linktitle: Convertir PPTX a PPT
type: docs
weight: 21
url: /es/python-net/convert-pptx-to-ppt/
keywords: "Python Convertir PPTX a PPT, Convertir Presentación de PowerPoint, PPTX a PPT, Python, Aspose.Slides"
description: "Convertir PowerPoint PPTX a PPT en Python"
---

## **Descripción general**

Este artículo explica cómo convertir una Presentación de PowerPoint en formato PPTX a formato PPT utilizando Python. A continuación se cubre el siguiente tema.

- Convertir PPTX a PPT en Python

## **Python Convertir PPTX a PPT**

Para ver un código de muestra en Python para convertir PPTX a PPT, consulte la sección a continuación es decir, [Convertir PPTX a PPT](#convert-pptx-to-ppt). Solo carga el archivo PPTX y lo guarda en formato PPT. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPTX en muchos otros formatos como PDF, XPS, ODP, HTML, etc. como se discute en estos artículos.

- [Python Convertir PPTX a PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convertir PPTX a XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convertir PPTX a HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convertir PPTX a ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convertir PPTX a Imagen](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **Convertir PPTX a PPT**
Para convertir un PPTX a PPT, simplemente pase el nombre del archivo y el formato de guardado al método [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la clase [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). El siguiente ejemplo de código en Python convierte una Presentación de PPTX a PPT utilizando opciones predeterminadas.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo PPTX
pres = slides.Presentation("presentation.pptx")

# Guardar la presentación PPTX en formato PPT
pres.save("presentation.ppt", slides.export.SaveFormat.PPT)
```