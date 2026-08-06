---
title: Aspose.Slides para Python vía .NET
second_title: Aspose.Slides para Python
type: docs
weight: 35
url: /es/python-net/
is_root: true
keywords:
- Aspose.Slides para Python
- Automatización de PowerPoint con Python
- Biblioteca PPT de Python
- Exportar PowerPoint a PDF con Python
- Exportar PowerPoint a SVG con Python
- Editar PowerPoint en Python
- PowerPoint de Python sin Microsoft Office
- Gestionar PPTX con Python
- Previsualización de diapositivas con Python
- Python añadir audio a diapositivas
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides para Python vía .NET ofrece un conjunto completo de funcionalidades, que incluye la gestión de texto, formas, tablas y animaciones, la incorporación de audio y vídeo a las diapositivas, la previsualización de diapositivas y la exportación a SVG, PDF y más."
---
{{% alert color="primary" %}}

**Bienvenido a Aspose.Slides para Python vía .NET**

![Logotipo del producto Aspose.Slides para Python vía .NET](aspose_slides-for-python.png)

Aspose.Slides para Python vía .NET es una robusta biblioteca de clases que permite a sus aplicaciones leer y escribir presentaciones PowerPoint® sin requerir Microsoft PowerPoint®.

Es el primer y único componente que ofrece una gestión de documentos PowerPoint® completa para desarrolladores Python.

Aspose.Slides para Python vía .NET incluye una amplia gama de funciones como trabajar con texto, formas, tablas y animaciones; añadir audio y vídeo; previsualizar diapositivas; y exportar diapositivas a formatos como SVG, PDF y más.

{{% /alert %}}

## Instalar Aspose.Slides para Python vía .NET

```bash
pip install aspose.slides
```

El paquete incluye el runtime de .NET necesario, por lo que no hay nada más que instalar y no se requiere Microsoft PowerPoint. Python 3.7 o posterior en Windows, Linux o macOS.

## Crear una presentación PowerPoint en Python

Este ejemplo crea una presentación, añade una forma con texto a la primera diapositiva y guarda el resultado tanto en PPTX como en PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Al ejecutarlo escribe `presentation.pptx` (aprox. 34 KB) y `presentation.pdf` (aprox. 36 KB) en el directorio de trabajo.

Sin una licencia, la biblioteca funciona en modo de evaluación, lo que añade una marca de agua y limita el número de diapositivas. Consulte [Licencias](/slides/es/python-net/licensing/) para aplicar una.

## Recursos de Aspose.Slides para Python vía .NET

Explore estos recursos útiles:

- [Documentación en línea de Aspose.Slides para Python vía .NET](/slides/es/python-net/)
- [Características de Aspose.Slides para Python vía .NET](/slides/es/python-net/features-overview/)
- [Notas de la versión de Aspose.Slides para Python vía .NET](https://releases.aspose.com/slides/es/python-net/release-notes/)
- [Página del producto Aspose.Slides para Python vía .NET](https://products.aspose.com/slides/es/python-net/)
- [Descargar Aspose.Slides para Python vía .NET](https://releases.aspose.com/slides/es/python-net/)
- [Instalar el paquete PyPi de Aspose.Slides para Python vía .NET](https://pypi.org/project/aspose.slides/)
- [Guía de referencia de la API de Aspose.Slides para Python vía .NET](https://reference.aspose.com/slides/es/python-net/)
- [Foro gratuito de soporte de Aspose.Slides para Python vía .NET](https://forum.aspose.com/c/slides/es/11)
- [Helpdesk de soporte de pago de Aspose.Slides para Python vía .NET](https://helpdesk.aspose.com/)

## Preguntas frecuentes

### ¿Qué es Aspose.Slides para Python vía .NET?

Aspose.Slides para Python vía .NET es una potente biblioteca Python que le permite crear, editar y convertir presentaciones PowerPoint (PPT, PPTX, ODP) programáticamente sin necesidad de Microsoft PowerPoint instalado.

### ¿Qué funciones de presentación admite Aspose.Slides?

La biblioteca admite la gestión de texto, formas, tablas, gráficos, animaciones, diapositivas maestras, audio, video y más. También permite la previsualización de diapositivas, el renderizado, la impresión y la exportación a formatos como PDF, SVG, HTML e imágenes.

### ¿Puedo convertir presentaciones a otros formatos con Aspose.Slides?

Sí. Aspose.Slides permite la conversión de archivos PowerPoint a PDF, SVG, HTML, JPG, PNG, TIFF y otros formatos con alta fidelidad y rendimiento.

### ¿Se requiere Microsoft PowerPoint para usar Aspose.Slides?

No. Aspose.Slides es una API independiente y no requiere Microsoft Office ni ningún software de terceros.

### ¿Qué plataformas admite Aspose.Slides para Python vía .NET?

Es multiplataforma y funciona en entornos Windows, Linux y macOS.

### ¿Cómo empezar con Aspose.Slides para Python?

Puede instalarlo a través de PyPi y explorar la [Guía del desarrollador](/slides/es/python-net/developer-guide/) para comenzar con ejemplos, referencias de API y tutoriales.