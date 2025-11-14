---
title: Convertir PPT a PPTX en Python
linktitle: Convertir PPT a PPTX
type: docs
weight: 20
url: /es/python-net/convert-ppt-to-pptx/
keywords: "Python Convertir PPT a PPTX, Convertir Presentación de PowerPoint, PPT a PPTX, Python, Aspose.Slides"
description: "Convertir PowerPoint PPT a PPTX en Python"
---

## **Resumen**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX utilizando Python y una aplicación en línea de conversión de PPT a PPTX. Se cubre el siguiente tema.

- Convertir PPT a PPTX en Python

## **Python Convertir PPT a PPTX**

Para obtener el código de ejemplo en Python para convertir PPT a PPTX, consulte la sección a continuación, es decir, [Convertir PPT a PPTX](#convert-ppt-to-pptx). Solo carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar el archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos.

- [Python Convertir PPT a PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convertir PPT a XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convertir PPT a HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convertir PPT a ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convertir PPT a Imagen](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **Acerca de la Conversión de PPT a PPTX**
Convierta el antiguo formato PPT a PPTX con la API de Aspose.Slides. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo programáticamente. Con la API de Aspose.Slides, es posible hacerlo en solo unas pocas líneas de código. La API admite compatibilidad total para convertir presentaciones PPT a PPTX y es posible:

- Convertir estructuras complicadas de maestros, diseños y diapositivas.
- Convertir presentaciones con gráficos.
- Convertir presentaciones con formas agrupadas, formas automáticas (como rectángulos y elipses), formas con geometría personalizada.
- Convertir presentaciones que tienen estilos de relleno de texturas e imágenes para formas automáticas.
- Convertir presentaciones, teniendo marcadores de posición, cuadros de texto y portadores de texto.

{{% alert color="primary" %}}

Eche un vistazo a la aplicación [**Conversión de Aspose.Slides PPT a PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre la **API de Aspose.Slides**, por lo que puede ver un ejemplo en vivo de las capacidades básicas de conversión de PPT a PPTX. La conversión de Aspose.Slides es una aplicación web que permite soltar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentre otros ejemplos en vivo de [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **Convertir PPT a PPTX**
Para convertir un PPT a PPTX, simplemente pase el nombre del archivo y el formato de guardado al método [**Guardar**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la clase [**Presentación**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). El siguiente ejemplo de código en Python convierte una presentación de PPT a PPTX utilizando opciones predeterminadas.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo PPTX
pres = slides.Presentation("PPTtoPPTX.ppt")

# Guardar la presentación PPTX en formato PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

Lea más sobre los formatos de presentación [**PPT vs PPTX**](/slides/es/python-net/ppt-vs-pptx/) y cómo [**Aspose.Slides admite la conversión de PPT a PPTX**](/slides/es/python-net/convert-ppt-to-pptx/).