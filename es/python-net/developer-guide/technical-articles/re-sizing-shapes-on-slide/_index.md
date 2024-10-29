---
title: Redimensionar Formas en la Diapositiva
type: docs
weight: 130
url: /es/python-net/redimensionar-formas-en-la-diapositiva/
---

## **Redimensionar Formas en la Diapositiva**
Una de las preguntas más frecuentes que hacen los clientes de Aspose.Slides para Python a través de .NET es cómo redimensionar formas para que, al cambiar el tamaño de la Diapositiva, los datos no se corten. Este breve consejo técnico muestra cómo lograr esto.

Para evitar la desorientación de las formas, cada forma en la diapositiva necesita actualizarse de acuerdo con el nuevo tamaño de la diapositiva.

```py
import aspose.slides as slides

#Cargar una presentación
with slides.Presentation("pres.pptx") as presentation:
    #Tamaño de diapositiva antiguo
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #Cambiando el tamaño de la diapositiva
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #Nuevo tamaño de diapositiva
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #Redimensionar posición
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Redimensionar tamaño de la forma si es necesario 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

    presentation.save("Resize-1.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Si hay alguna tabla en la diapositiva, entonces el código anterior no funcionará perfectamente. En ese caso, cada celda de la tabla necesita ser redimensionada.

{{% /alert %}} 

Necesitas usar el siguiente código de tu parte si necesitas redimensionar las diapositivas con tablas. Establecer el ancho o alto de la tabla es un caso especial en formas donde necesitas alterar la altura de cada fila y el ancho de cada columna para alterar la altura y el ancho de la tabla.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    #Tamaño de diapositiva antiguo
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #Cambiando el tamaño de la diapositiva
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #Nuevo tamaño de diapositiva
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width


    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for master in presentation.masters:
        for shape in master.shapes:
            #Redimensionar posición
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Redimensionar tamaño de la forma si es necesario 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

        for layoutslide in master.layout_slides:
            for shape in layoutslide.shapes:
                #Redimensionar posición
                shape.height = shape.height * ratioHeight
                shape.width = shape.width * ratioWidth

                #Redimensionar tamaño de la forma si es necesario 
                shape.y = shape.y * ratioHeight
                shape.x = shape.x * ratioWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #Redimensionar posición
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Redimensionar tamaño de la forma si es necesario 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth
            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * ratioHeight
                for col in shape.columns:
                    col.width = col.width * ratioWidth

    presentation.save("Resize-2.pptx", slides.export.SaveFormat.PPTX)
```