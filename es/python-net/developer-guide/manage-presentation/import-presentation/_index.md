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
description: "Importa fácilmente documentos PDF y HTML en presentaciones de PowerPoint y OpenDocument en Python con Aspose.Slides for Python via .NET para un procesamiento de diapositivas fluido y de alto rendimiento."
---

Usando [**Aspose.Slides para Python a través de .NET**](https://products.aspose.com/slides/python-net/), puedes importar presentaciones de archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) para permitirte importar presentaciones desde PDFs, documentos HTML, etc.

## **Importar PowerPoint desde PDF**

En este caso, puedes convertir un PDF a una presentación de PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instancia un objeto de la clase presentación. 
2. Llama al método `add_from_pdf` y pasa el archivo PDF. 
3. Usa el método `save` para guardar el archivo en formato PowerPoint.

Este código Python demuestra la operación de PDF a PowerPoint:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides.remove_at(0)
    pres.slides.add_from_pdf("welcome-to-powerpoint.pdf")
    pres.save("OutputPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Consejo" color="primary" %}} 

Es posible que desees revisar la aplicación web **Aspose gratis** [PDF a PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí.

{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, puedes convertir un documento HTML a una presentación de PowerPoint.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Llama al método `add_from_html` y pasa el archivo HTML. 
3. Usa el método `save` para guardar el archivo como un documento de PowerPoint.

Este código Python demuestra la operación de HTML a PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("page.html", "rb") as htmlStream:
        pres.slides.add_from_html(htmlStream)

    pres.save("MyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Nota" color="warning" %}} 

También puedes usar Aspose.Slides para convertir HTML a otros formatos de archivo populares:

* [HTML a imagen](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}