---
title: Crear un visor de presentaciones en Python
linktitle: Visor de presentaciones
type: docs
weight: 50
url: /es/python-net/presentation-viewer/
keywords:
- ver presentación
- visor de presentaciones
- crear visor de presentaciones
- ver PPT
- ver PPTX
- ver ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aprenda a crear un visor de presentaciones personalizado en Python usando Aspose.Slides. Visualice fácilmente archivos de PowerPoint (PPTX, PPT) y OpenDocument (ODP) sin Microsoft PowerPoint ni otro software de oficina."
---

Aspose.Slides para Python a través de .NET se utiliza para crear archivos de presentación, completos con diapositivas. Estas diapositivas se pueden ver abriendo presentaciones con Microsoft PowerPoint. Pero a veces, los desarrolladores también pueden necesitar ver diapositivas como imágenes en su visor de imágenes favorito o crear su propio visor de presentaciones. En tales casos, Aspose.Slides para Python a través de .NET le permite exportar una diapositiva individual a una imagen. Este artículo describe cómo hacerlo.
## **Ejemplo en Vivo**
Puede probar la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

![powerpoint-en-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **Generar Imagen SVG desde Diapositiva**
Para generar una imagen SVG desde cualquier diapositiva deseada con Aspose.Slides para Python, siga los pasos a continuación:

- Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
- Obtenga la referencia de la diapositiva deseada utilizando su ID o índice.
- Obtenga la imagen SVG en un flujo de memoria.
- Guarde el flujo de memoria en un archivo.

```py
import aspose.slides as slides

# Instanciar una clase Presentation que representa el archivo de presentación
with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    # Acceder a la primera diapositiva
    sld = pres.slides[0]

    # Crear un objeto de flujo de memoria
    with open("Aspose_out-1.svg", "wb") as svg_stream:
        # Generar imagen SVG de la diapositiva y guardar en el flujo de memoria
        sld.write_as_svg(svg_stream)
```


## **Generar SVG con IDs de Forma Personalizados**
Aspose.Slides para Python a través de .NET se puede utilizar para generar [SVG ](https://docs.fileformat.com/page-description-language/svg/)de una diapositiva con ID de forma personalizada. Para ello, use la propiedad ID de [ISvgShape](https://reference.aspose.com/slides/python-net/aspose.slides.export/isvgshape/), que representa el ID personalizado de las formas en el SVG generado. CustomSvgShapeFormattingController se puede utilizar para establecer el ID de la forma.

```py
import aspose.slides as slides

with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    with open("Aspose_out-2.svg", "wb") as svg_stream:
        svgOptions = slides.export.SVGOptions()
        pres.slides[0].write_as_svg(svg_stream, svgOptions)
```


## **Crear Imagen en Miniatura de Diapositivas**
Aspose.Slides para Python a través de .NET le ayuda a generar imágenes en miniatura de las diapositivas. Para generar la miniatura de cualquier diapositiva deseada utilizando Aspose.Slides para Python a través de .NET:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```py
import aspose.slides as slides

# Instanciar una clase Presentation que representa el archivo de presentación
with slides.Presentation("pres.pptx") as pres:
    # Acceder a la primera diapositiva
    sld = pres.slides[0]

    # Crear una imagen a escala completa
    with sld.get_image(1, 1) as bmp:
        # guardar la imagen en disco en formato JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


## **Crear Miniatura con Dimensiones Definidas por el Usuario**
1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```py
import aspose.slides as slides

# Instanciar una clase Presentation que representa el archivo de presentación
with slides.Presentation("pres.pptx") as pres:
    # Acceder a la primera diapositiva
    sld = pres.slides[0]

    # Dimensiones definidas por el usuario
    desiredX = 1200
    desiredY = 800

    # Obtener valor escalado de X e Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY


    # Crear una imagen a escala completa
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # guardar la imagen en disco en formato JPEG
        bmp.save("Thumbnail2_out.jpg", slides.ImageFormat.JPEG)
```


## **Crear Miniatura de Diapositiva en Vista de Notas**
Para generar la miniatura de cualquier diapositiva deseada en Vista de Notas usando Aspose.Slides para Python a través de .NET:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada en la vista de Notas.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

El fragmento de código a continuación produce una miniatura de la primera diapositiva de una presentación en Vista de Notas.

```py
import aspose.slides as slides

# Instanciar una clase Presentation que representa el archivo de presentación
with slides.Presentation("pres.pptx") as pres:
    # Acceder a la primera diapositiva
    sld = pres.slides[0]

    # Dimensiones definidas por el usuario
    desiredX = 1200
    desiredY = 800

    # Obtener valor escalado de X e Y
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY

   
    # Crear una imagen a escala completa                
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # guardar la imagen en disco en formato JPEG
        bmp.save("Notes_tnail_out.jpg", slides.ImageFormat.JPEG)
```