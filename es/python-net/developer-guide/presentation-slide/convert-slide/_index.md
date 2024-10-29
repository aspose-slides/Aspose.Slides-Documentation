---
title: Convertir Diapositiva
type: docs
weight: 41
url: /es/python-net/convert-slide/
keywords: 
- convertir diapositiva a imagen
- exportar diapositiva como imagen
- guardar diapositiva como imagen
- diapositiva a imagen
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a bitmap
- PHP
- Aspose.Slides para Python a través de .NET
description: "Convertir diapositiva de PowerPoint a imagen (Bitmap, PNG o JPG) en Python"
---

Aspose.Slides para Python a través de .NET te permite convertir diapositivas (en presentaciones) a imágenes. Estos son los formatos de imagen admitidos: BMP, PNG, JPG (JPEG), GIF y otros. 

Para convertir una diapositiva a una imagen, haz lo siguiente: 

1. Primero, establece los parámetros de conversión y los objetos de la diapositiva para convertir utilizando:
   * la interfaz [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) o
   * la interfaz [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/). 

2. Segundo, convierte la diapositiva a una imagen utilizando el método [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/). 

## **Acerca de Bitmap y Otros Formatos de Imagen**

En .NET, un [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) es un objeto que te permite trabajar con imágenes definidas por datos de píxeles. Puedes utilizar una instancia de esta clase para guardar imágenes en una amplia gama de formatos (BMP, JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose desarrolló recientemente un convertidor en línea [Texto a GIF](https://products.aspose.app/slides/text-to-gif). 

{{% /alert %}}

## **Convertir Diapositivas a Bitmap y Guardar las Imágenes en PNG**

Este código en Python te muestra cómo convertir la primera diapositiva de una presentación a un objeto bitmap y luego cómo guardar la imagen en formato PNG:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Convierte la primera diapositiva en la presentación a un objeto Bitmap
    with pres.slides[0].get_image() as bmp:
        # Guarda la imagen en formato PNG
        bmp.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert title="Consejo" color="primary" %}} 

Puedes convertir una diapositiva a un objeto bitmap y luego usar el objeto directamente en algún lugar. O puedes convertir una diapositiva a un bitmap y luego guardar la imagen en JPEG o cualquier otro formato que prefieras. 

{{% /alert %}}  

## **Convertir Diapositivas a Imágenes con Tamaños Personalizados**

Puede que necesites obtener una imagen de un tamaño determinado. Usando una sobrecarga del método [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), puedes convertir una diapositiva a una imagen con dimensiones específicas (longitud y ancho). 

Este código de ejemplo demuestra la conversión propuesta utilizando el método [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) en Python:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Convierte la primera diapositiva en la presentación a un Bitmap con el tamaño especificado
    with pres.slides[0].get_image(draw.Size(1820, 1040)) as bmp:
        # Guarda la imagen en formato JPEG
        bmp.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Convertir Diapositivas Con Notas y Comentarios a Imágenes**

Algunas diapositivas contienen notas y comentarios. 

Aspose.Slides proporciona dos interfaces—[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) y [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/)—que te permiten controlar el renderizado de las diapositivas de la presentación a imágenes. Ambas interfaces albergan la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) que te permite agregar notas y comentarios en una diapositiva cuando conviertes esa diapositiva a una imagen.

{{% alert title="Info" color="info" %}} 

Con la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/), puedes especificar tu posición preferida para notas y comentarios en la imagen resultante. 

{{% /alert %}} 

Este código en Python demuestra el proceso de conversión para una diapositiva con notas y comentarios:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("AddNotesSlideWithNotesStyle_out.pptx") as pres:
    # Crea las opciones de renderizado
    options = slides.export.RenderingOptions()
                
    # Establece la posición de las notas en la página
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
                
    # Establece la posición de los comentarios en la página 
    options.notes_comments_layouting.comments_position = slides.export.CommentsPositions.RIGHT

    # Establece el ancho del área de salida de comentarios
    options.notes_comments_layouting.comments_area_width = 500
                
    # Establece el color para el área de comentarios
    options.notes_comments_layouting.comments_area_color = draw.Color.antique_white
                
    # Convierte la primera diapositiva de la presentación a un objeto Bitmap
    with pres.slides[0].get_image(options, 2, 2) as bmp:
        # Guarda la imagen en formato GIF
        bmp.save("Slide_Notes_Comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Nota" color="warning" %}} 

En cualquier proceso de conversión de diapositivas a imágenes, la propiedad [NotesPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) no puede configurarse en BottomFull (para especificar la posición para notas) porque el texto de una nota puede ser grande, lo que significa que podría no encajar en el tamaño de imagen especificado. 

{{% /alert %}} 

## **Convertir Diapositivas a Imágenes Usando ITiffOptions**

La interfaz [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) te brinda más control (en términos de parámetros) sobre la imagen resultante. Usando esta interfaz, puedes especificar el tamaño, la resolución, la paleta de colores y otros parámetros para la imagen resultante. 

Este código en Python demuestra un proceso de conversión donde se utiliza ITiffOptions para generar una imagen en blanco y negro con una resolución de 300dpi y un tamaño de 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "Comments1.pptx") as pres:
    # Obtiene una diapositiva por su índice
    slide = pres.slides[0]

    # Crea un objeto TiffOptions
    options = slides.export.TiffOptions() 
    options.image_size = draw.Size(2160, 2880)

    # Establece la fuente utilizada en caso de que no se encuentre la fuente original
    options.default_regular_font = "Arial Black"

    # Establece la posición de las notas en la página 
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    # Establece el formato de píxeles (blanco y negro)
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED

    # Establece la resolución
    options.dpi_x = 300
    options.dpi_y = 300

    # Convierte la diapositiva a un objeto Bitmap
    with slide.get_image(options) as bmp:
        # Guarda la imagen en formato BMP
        bmp.save("PresentationNotesComments.tiff", slides.ImageFormat.TIFF)
```

## **Convertir Todas las Diapositivas a Imágenes**

Aspose.Slides te permite convertir todas las diapositivas en una sola presentación a imágenes. Esencialmente, puedes convertir la presentación (en su totalidad) a imágenes. 

Este código de ejemplo te muestra cómo convertir todas las diapositivas en una presentación a imágenes en Python:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Renderiza la presentación a un array de imágenes diapositiva por diapositiva
    for i in range(len(pres.slides)):
        # Especifica la configuración para diapositivas ocultas (no renderizar diapositivas ocultas)
        if pres.slides[i].hidden:
            continue

        # Convierte la diapositiva a un objeto Bitmap
        with pres.slides[i].get_image() as bmp:
            # Guarda la imagen en formato JPEG
            bmp.save("image_{0}.jpeg".format(i), slides.ImageFormat.JPEG)
```