---
title: Convertir presentaciones de PowerPoint a documentos Word en Python
linktitle: PowerPoint a Word
type: docs
weight: 110
url: /es/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint a DOCX
- OpenDocument a DOCX
- presentación a DOCX
- diapositiva a DOCX
- PPT a DOCX
- PPTX a DOCX
- ODP a DOCX
- PowerPoint a DOC
- OpenDocument a DOC
- presentación a DOC
- diapositiva a DOC
- PPT a DOC
- PPTX a DOC
- ODP a DOC
- PowerPoint a Word
- OpenDocument a Word
- presentación a Word
- diapositiva a Word
- PPT a Word
- PPTX a Word
- ODP a Word
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- convertir ODP
- Python
- Aspose.Slides
description: "Aprenda cómo convertir sin esfuerzo presentaciones de PowerPoint y OpenDocument a documentos Word usando Aspose.Slides para Python a través de .NET. Nuestra guía paso a paso con código de ejemplo en Python ofrece la solución para los desarrolladores que buscan optimizar sus flujos de trabajo de documentos."
---

## **Visión general**

Este artículo ofrece una solución para desarrolladores sobre cómo convertir presentaciones de PowerPoint y OpenDocument a documentos Word usando Aspose.Slides para Python a través de .NET y Aspose.Words para Python a través de .NET. La guía paso a paso le acompañará en cada etapa del proceso de conversión.

## **Convertir una presentación a un documento Word**

Siga las instrucciones a continuación para convertir una presentación de PowerPoint o OpenDocument a un documento Word:

1. Instancie la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue un archivo de presentación.  
2. Instancie las clases [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) y [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) para generar un documento Word.  
3. Establezca el tamaño de página del documento Word para que coincida con el de la presentación usando la propiedad [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
4. Establezca los márgenes en el documento Word usando la propiedad [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
5. Recorra todas las diapositivas de la presentación usando la propiedad [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/).  
    - Genere una imagen de diapositiva mediante el método `get_image` de la clase [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) y guárdela en un flujo de memoria.  
    - Añada la imagen de la diapositiva al documento Word mediante el método `insert_image` de la clase [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/).  
6. Guarde el documento Word en un archivo.

Supongamos que tenemos una presentación “sample.pptx” que se ve así:

![Presentación de PowerPoint](PowerPoint.png)

El siguiente ejemplo de código Python muestra cómo convertir la presentación de PowerPoint a un documento Word:
```py
import aspose.slides as slides
import aspose.words as words

# Cargar un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:

    # Crear objetos Document y DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Establecer el tamaño de página en el documento Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Establecer márgenes en el documento Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Recorrer todas las diapositivas de la presentación.
    for slide in presentation.slides:

        # Generar una imagen de diapositiva y guardarla en un flujo de memoria.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Añadir la imagen de la diapositiva al documento Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Guardar el documento Word en un archivo.
    document.save("output.docx")
```


El resultado:

![Documento Word](Word.png)

{{% alert color="primary" %}} 

Pruebe nuestro **Convertidor en línea de PPT a Word**(https://products.aspose.app/slides/conversion/ppt-to-word) para ver lo que puede obtener al convertir presentaciones de PowerPoint y OpenDocument a documentos Word. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué componentes es necesario instalar para convertir presentaciones de PowerPoint y OpenDocument a documentos Word?**

Solo necesita agregar los paquetes respectivos para [Aspose.Slides para Python a través de .NET](https://pypi.org/project/Aspose.Slides/) y [Aspose.Words para Python .NET](https://pypi.org/project/aspose-words/) a su proyecto Python. Ambos paquetes funcionan como API independientes, y no es necesario tener Microsoft Office instalado.

**¿Se admiten todos los formatos de presentación de PowerPoint y OpenDocument?**

Aspose.Slides para Python .NET [admite todos los formatos de presentación](/slides/es/python-net/supported-file-formats/), incluidos PPT, PPTX, ODP y otros tipos de archivo comunes. Esto garantiza que pueda trabajar con presentaciones creadas en diversas versiones de Microsoft PowerPoint.