---
title: Agregar Diapositiva a la Presentación
type: docs
weight: 10
url: /es/python-net/add-slide-to-presentation/
keywords: "Agregar diapositiva a la presentación, Python, Aspose.Slides"
description: "Agregar diapositiva a la presentación en Python"
---

## **Agregar Diapositiva a la Presentación**
Antes de hablar sobre cómo agregar diapositivas a los archivos de presentación, discutamos algunos hechos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva Maestra / Diseño y otras diapositivas Normales. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides para Python a través de .NET. Cada diapositiva tiene un Id único y todas las Diapositivas Normales están dispuestas en un orden especificado por el índice basado en cero. Aspose.Slides para Python a través de .NET permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía en la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) configurando una referencia a la propiedad Slides (colección de objetos Slide de contenido) expuesta por el objeto Presentation.
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando al método AddEmptySlide expuesto por el objeto ISlideCollection.
- Haga algún trabajo con la nueva diapositiva vacía agregada.
- Finalmente, guarde el archivo de presentación usando el objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el archivo de presentación
with slides.Presentation() as pres:
    # Instanciar la clase SlideCollection
    slds = pres.slides

    for i in range(len(pres.layout_slides)):
        # Agregar una diapositiva vacía a la colección de Diapositivas
        slds.add_empty_slide(pres.layout_slides[i])
        
    # Hacer algún trabajo en la diapositiva recién añadida

    # Guardar el archivo PPTX en el disco
    pres.save("EmptySlide.pptx", slides.export.SaveFormat.PPTX)
```