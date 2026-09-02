---
title: Aspose.Slides para Python mediante .NET
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
- Editar PowerPoint con Python
- PowerPoint de Python sin Microsoft Office
- Gestionar PPTX con Python
- Vista previa de diapositivas con Python
- Python añadir audio a diapositivas
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides para Python mediante .NET ofrece un conjunto completo de funcionalidades, que incluyen la gestión de texto, formas, tablas y animaciones, la incorporación de audio y vídeo a las diapositivas, la previsualización de diapositivas y la exportación a SVG, PDF y mucho más."
---
{{% alert color="info" %}}

**Bienvenido a Aspose.Slides para Python mediante .NET**

![Aspose.Slides for Python via .NET Product Logo](aspose_slides-for-python.png)

Aspose.Slides para Python mediante .NET es una biblioteca de clases robusta que permite a sus aplicaciones leer y escribir presentaciones PowerPoint® sin requerir Microsoft PowerPoint®.

Es el primer y único componente que ofrece gestión completa de documentos PowerPoint® para desarrolladores Python.

Aspose.Slides para Python mediante .NET incluye una amplia gama de funciones, como trabajar con texto, formas, tablas y animaciones; añadir audio y vídeo; previsualizar diapositivas; y exportar diapositivas a formatos como SVG, PDF y otros.

{{% /alert %}}

## Instalar Aspose.Slides para Python mediante .NET

```bash
pip install aspose.slides
```

El paquete incluye el tiempo de ejecución .NET que necesita, por lo que no hay nada más que instalar y no se requiere Microsoft PowerPoint. Python 3.7 o posterior en Windows, Linux o macOS.

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

Al ejecutarlo se generan `presentation.pptx` (aprox. 34 KB) y `presentation.pdf` (aprox. 36 KB) en el directorio de trabajo.

Sin una licencia, la biblioteca se ejecuta en modo de evaluación, lo que añade una marca de agua y limita el número de diapositivas. Consulte [Licensing](/slides/es/python-net/licensing/) para aplicar una.

## Recursos de Aspose.Slides para Python mediante .NET

Explore estos recursos útiles::

- [Aspose.Slides para Python mediante .NET Documentación en línea](/slides/es/python-net/)
- [Aspose.Slides para Python mediante .NET Características](/slides/es/python-net/features-overview/)
- [Aspose.Slides para Python mediante .NET Notas de la versión](https://releases.aspose.com/slides/es/python-net/release-notes/)
- [Aspose.Slides para Python mediante .NET Página del producto](https://products.aspose.com/slides/es/python-net/)
- [Descargar Aspose.Slides para Python mediante .NET](https://releases.aspose.com/slides/es/python-net/)
- [Instalar Aspose.Slides para Python mediante .NET paquete PyPi](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides para Python mediante .NET Guía de referencia de API](https://reference.aspose.com/slides/es/python-net/)
- [Aspose.Slides para Python mediante .NET Foro de soporte gratuito](https://forum.aspose.com/c/slides/es/11)
- [Aspose.Slides para Python mediante .NET Servicio de ayuda con soporte de pago](https://helpdesk.aspose.com/)

## Preguntas frecuentes

### ¿Qué es Aspose.Slides para Python mediante .NET?

Aspose.Slides para Python mediante .NET es una potente biblioteca Python que permite crear, editar y convertir presentaciones PowerPoint (PPT, PPTX, ODP) programáticamente sin necesidad de Microsoft PowerPoint instalado.

### ¿Qué funciones de presentación admite Aspose.Slides?

La biblioteca admite la gestión de texto, formas, tablas, gráficos, animaciones, diapositivas maestras, audio, vídeo y más. También permite la previsualización de diapositivas, renderizado y exportación a formatos como PDF, SVG, HTML e imágenes.

### ¿Puedo convertir presentaciones a otros formatos con Aspose.Slides?

Sí. Aspose.Slides permite la conversión de archivos PowerPoint a PDF, SVG, HTML, JPG, PNG, TIFF y otros formatos con alta fidelidad y rendimiento.

### ¿Se requiere Microsoft PowerPoint para usar Aspose.Slides?

No. Aspose.Slides es una API independiente y no necesita Microsoft Office ni ningún software de terceros.

### ¿Qué plataformas son compatibles con Aspose.Slides para Python mediante .NET?

Es multiplataforma y funciona en entornos Windows, Linux y macOS.

### ¿Cómo empiezo a usar Aspose.Slides para Python?

Puede instalarlo mediante PyPi y explorar la [Developer Guide](/slides/es/python-net/developer-guide/) para comenzar con ejemplos, referencias de API y tutoriales.