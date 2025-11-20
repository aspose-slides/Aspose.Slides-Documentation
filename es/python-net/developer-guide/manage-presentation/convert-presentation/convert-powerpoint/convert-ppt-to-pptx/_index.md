---
title: Convertir PPT a PPTX en Python
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/python-net/convert-ppt-to-pptx/
keywords:
- convertir PPT
- PPT a PPTX
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Convierta presentaciones PPT heredadas a PPTX modernos rápidamente en Python con Aspose.Slides — tutorial claro, ejemplos de código gratuitos, sin dependencia de Microsoft Office."
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato PPT a formato PPTX utilizando Python y una aplicación en línea de conversión de PPT a PPTX. El tema siguiente se cubre:

- Convertir PPT a PPTX en Python

## **Python Convertir PPT a PPTX**

Para obtener código de ejemplo en Python para convertir PPT a PPTX, consulte la sección a continuación, es decir, [Convertir PPT a PPTX](#convert-ppt-to-pptx). Simplemente carga el archivo PPT y lo guarda en formato PPTX. Al especificar diferentes formatos de guardado, también puede guardar un archivo PPT en muchos otros formatos como PDF, XPS, ODP, HTML, etc., como se discute en estos artículos:

- [Python Convertir PPT a PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convertir PPT a XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convertir PPT a HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convertir PPT a ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convertir PPT a Imagen](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **Acerca de la conversión de PPT a PPTX**

Convierta el formato PPT antiguo a PPTX con Aspose.Slides API. Si necesita convertir miles de presentaciones PPT a formato PPTX, la mejor solución es hacerlo programáticamente. Con Aspose.Slides API, es posible hacerlo en solo unas pocas líneas de código. La API admite compatibilidad total para convertir una presentación PPT a PPTX, y es posible:

- Convertir estructuras complejas de masters, diseños y diapositivas.
- Convertir una presentación con gráficos.
- Convertir una presentación con formas agrupadas, autoformas (como rectángulos y elipses) y formas con geometría personalizada.
- Convertir una presentación que tiene texturas y estilos de relleno de imagen para autoformas.
- Convertir una presentación con marcadores de posición, marcos de texto y portadores de texto.

{{% alert color="primary" %}}

Eche un vistazo a la aplicación [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Esta aplicación está construida sobre la **Aspose.Slides API**, por lo que puede ver un ejemplo en vivo de las capacidades básicas de conversión de PPT a PPTX. Aspose.Slides Conversion es una aplicación web que le permite arrastrar un archivo de presentación en formato PPT y descargarlo convertido a PPTX.

Encuentre otros ejemplos en vivo de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .
{{% /alert %}}

## **Convertir PPT a PPTX**

Para convertir un PPT a PPTX, simplemente pase el nombre del archivo y el formato de guardado al método [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la clase [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). El ejemplo de código Python a continuación convierte una presentación de PPT a PPTX utilizando las opciones predeterminadas.
```python
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# Guardar la presentación en formato PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


Lea más sobre los formatos de presentación [**PPT vs PPTX**](/slides/es/python-net/ppt-vs-pptx/) y cómo [**Aspose.Slides soporta la conversión de PPT a PPTX**](/slides/es/python-net/convert-ppt-to-pptx/).

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre los formatos PPT y PPTX?**

PPT es el formato de archivo binario más antiguo utilizado por Microsoft PowerPoint, mientras que PPTX es el formato basado en XML más reciente introducido con Microsoft Office 2007. Los archivos PPTX ofrecen mejor rendimiento, tamaño de archivo reducido y recuperación de datos mejorada.

**¿Puedo convertir PPT a PPTX usando Python?**

Sí, utilizando la biblioteca Aspose.Slides para Python a través de .NET, puede cargar fácilmente un archivo PPT y guardarlo en formato PPTX con solo unas pocas líneas de código.

**¿Aspose.Slides admite la conversión por lotes de varios archivos PPT a PPTX?**

Sí, puede usar Aspose.Slides en un bucle para convertir varios archivos PPT a PPTX de forma programática, lo que lo hace adecuado para escenarios de conversión por lotes.

**¿Se mantendrán el contenido y el formato después de la conversión?**

Aspose.Slides mantiene una alta fidelidad al convertir presentaciones. Los diseños de diapositivas, animaciones, formas, gráficos y otros elementos de diseño se conservan durante la conversión de PPT a PPTX.

**¿Puedo convertir otros formatos como PDF o HTML a partir de archivos PPT?**

Sí, Aspose.Slides admite la conversión de archivos PPT a varios formatos, incluidos PDF, XPS, HTML, ODP y formatos de imagen como PNG y JPEG.

**¿Es posible convertir PPT a PPTX sin tener Microsoft PowerPoint instalado?**

Sí, Aspose.Slides para Python a través de .NET es una API independiente y no requiere Microsoft PowerPoint ni ningún software de terceros para realizar la conversión.

**¿Existe una herramienta en línea disponible para la conversión de PPT a PPTX?**

Sí, puede usar la aplicación web gratuita [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) para realizar la conversión directamente en su navegador sin escribir código.