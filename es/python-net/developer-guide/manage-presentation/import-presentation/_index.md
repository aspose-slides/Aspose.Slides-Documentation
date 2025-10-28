---
title: Importar presentaciones con Python
linktitle: Importar presentación
type: docs
weight: 60
url: /es/python-net/import-presentation/
keywords:
- importar PowerPoint
- importar presentación
- importar diapositiva
- PDF a presentación
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentación
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- Python
- Aspose.Slides
description: "Importe sin esfuerzo documentos PDF y HTML en presentaciones PowerPoint y OpenDocument en Python con Aspose.Slides para un procesamiento de diapositivas fluido y de alto rendimiento."
---

## **Resumen**

Con [**Aspose.Slides para Python mediante .NET**](https://products.aspose.com/slides/python-net/), puede importar contenido a una presentación desde otros formatos de archivo. La clase [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) proporciona métodos para importar diapositivas desde PDF, HTML y otras fuentes.

## **Convertir un PDF a una presentación**

Esta sección muestra cómo convertir un PDF en una presentación usando Aspose.Slides. Le guía a través de la importación del PDF, la transformación de sus páginas en diapositivas y el guardado del resultado como un archivo PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Llame al método [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) y pase el archivo PDF.
3. Utilice el método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) para guardar la presentación en formato PowerPoint.

El siguiente ejemplo en Python muestra cómo convertir un PDF a una presentación:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Consejo" color="primary" %}}

Puede probar la aplicación web gratuita de **Aspose** [PDF a PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint); es una implementación en vivo del proceso descrito aquí.

{{% /alert %}}

## **Convertir un HTML a una presentación**

Esta sección muestra cómo importar contenido HTML a una presentación usando Aspose.Slides. Cubre la carga del HTML, su transformación en diapositivas con texto, imágenes y formato básico preservados, y el guardado del resultado como un archivo PPTX.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Llame al método [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) y pase el archivo HTML. 
3. Utilice el método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) para guardar la presentación en formato PowerPoint.

El siguiente ejemplo en Python muestra cómo convertir un HTML a una presentación:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Se conservan las tablas al importar un PDF y puede mejorarse su detección?**

Las tablas pueden detectarse durante la importación; [PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) incluye un parámetro [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) que habilita el reconocimiento de tablas. La efectividad depende de la estructura del PDF.

{{% alert title="Nota" color="info" %}}

También puede usar Aspose.Slides para convertir HTML a otros formatos de archivo populares:

* [HTML a imagen](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}