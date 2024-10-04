---
title: Convertir PowerPoint a Word
type: docs
weight: 110
url: /python-net/convert-powerpoint-to-word/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Word, DOCX, DOC, PPTX a DOCX, PPT a DOC, PPTX a DOC, PPT a DOCX, Python, Aspose.Slides"
description: "Convertir Presentación de PowerPoint a Word en Python"
---

Si planeas utilizar contenido textual o información de una presentación (PPT o PPTX) de nuevas maneras, puedes beneficiarte al convertir la presentación a Word (DOC o DOCX).

* En comparación con Microsoft PowerPoint, la aplicación Microsoft Word está mejor equipada con herramientas o funcionalidades para contenido. 
* Además de las funciones de edición en Word, también puedes beneficiarte de una colaboración mejorada, impresión y funciones de compartición.

{{% alert color="primary" %}} 

Puede que desees probar nuestro [**Convertidor de Presentación a Word en Línea**](https://products.aspose.app/slides/conversion/ppt-to-word) para ver qué puedes ganar al trabajar con contenido textual de las diapositivas. 

{{% /alert %}} 

## **Aspose.Slides y Aspose.Words**

Para convertir un archivo de PowerPoint (PPTX o PPT) a Word (DOCX o DOCX), necesitas tanto [Aspose.Slides for Python via .NET](https://products.aspose.com/slides/python-net/) como [Aspose.Words for Python via .NET](https://products.aspose.com/words/python-net/).

Como una API independiente, [Aspose.Slides](https://products.aspose.com/slides/python-net/) para Python via .NET proporciona funciones que te permiten extraer textos de presentaciones.

[Aspose.Words](https://products.aspose.com/words/python-net/) es una API avanzada de procesamiento de documentos que permite a las aplicaciones generar, modificar, convertir, renderizar, imprimir archivos y realizar otras tareas con documentos sin utilizar Microsoft Word.

## **Convertir PowerPoint a Word en Python**

1. Agrega estos espacios de nombres a tu archivo program.py:

```py
import aspose.slides as slides
import aspose.words as words
```

2. Utiliza este fragmento de código para convertir PowerPoint a Word:

```py
with slides.Presentation("sample.pptx") as presentation:
    doc = words.Document()
    builder = words.DocumentBuilder(doc)

    for index in range(presentation.slides.length):
        slide = presentation.slides[index]

        file_name = "slide_{i}.png".format(i=index)

        # genera una imagen de la diapositiva
        with slide.get_image(1, 1) as image:
            image.save(file_name, slides.ImageFormat.PNG)

        builder.insert_image(file_name)

        for shape in slide.shapes:
            # inserta los textos de la diapositiva
            if type(shape) is slides.AutoShape:
                builder.writeln(shape.text_frame.text)

        builder.insert_break(words.BreakType.PAGE_BREAK)
    doc.save("output.docx")
```