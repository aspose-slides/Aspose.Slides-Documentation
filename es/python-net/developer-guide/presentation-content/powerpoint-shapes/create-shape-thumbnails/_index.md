---
title: Crear miniaturas de formas
type: docs
weight: 70
url: /python-net/create-shape-thumbnails/
keywords: "Miniatura de forma. Presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Miniatura de forma en presentación de PowerPoint en Python"
---

Aspose.Slides para Python a través de .NET se utiliza para crear archivos de presentación donde cada página es una diapositiva. Estas diapositivas se pueden visualizar abriendo los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las imágenes de las formas por separado en un visor de imágenes. En tales casos, Aspose.Slides para Python a través de .NET le ayuda a generar imágenes en miniatura de las formas de la diapositiva. Cómo utilizar esta función se describe en este artículo.  
Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generando una miniatura de forma dentro de una diapositiva.
- Generando una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generando una miniatura de forma dentro de los límites de la apariencia de una forma.
- Generando una miniatura de un nodo hijo de SmartArt.  
## **Generar miniatura de forma desde una diapositiva**  
Para generar una miniatura de forma desde cualquier diapositiva usando Aspose.Slides para Python a través de .NET:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen en miniatura de la forma referenciada de la diapositiva en la escala predeterminada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

El siguiente ejemplo genera una miniatura de forma.

```py
import aspose.slides as slides

# Instanciar una clase Presentation que representa el archivo de presentación
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Crear una imagen a escala completa
    with presentation.slides[0].shapes[0].get_image() as bitmap:
        # Guardar la imagen en el disco en formato PNG
        bitmap.save("Shape_thumbnail_out.png", slides.ImageFormat.PNG)
```


## **Generar miniatura de factor de escala definido por el usuario**  
Para generar la miniatura de forma de cualquier forma de diapositiva usando Aspose.Slides para Python a través de .NET:

1. Cree una instancia de la clase `Presentation`.
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

El siguiente ejemplo genera una miniatura con un factor de escala definido por el usuario.

```py
import aspose.slides as slides

# Instanciar una clase Presentation que representa el archivo de presentación
with slides.Presentation(path + "HelloWorld.pptx") as p:
    # Crear una imagen a escala completa
    with p.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.SHAPE, 1, 1) as bitmap:
        # Guardar la imagen en el disco en formato PNG
        bitmap.save("Scaling Factor Thumbnail_out.png", slides.ImageFormat.PNG)
```


## **Crear miniatura de límites de la apariencia de la forma**  
Este método para crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de cualquier forma de diapositiva dentro de los límites de su apariencia, use el siguiente código de muestra:

1. Cree una instancia de la clase `Presentation`.
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

El siguiente ejemplo crea una miniatura con un factor de escala definido por el usuario.

```py
import aspose.slides as slides

# Instanciar una clase Presentation que representa el archivo de presentación
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Crear una imagen de forma con límites de apariencia
    with presentation.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.APPEARANCE, 1, 1) as bitmap:
        # Guardar la imagen en el disco en formato PNG
        bitmap.save("Shape_thumbnail_Bound_Shape_out.png", slides.ImageFormat.PNG)
```