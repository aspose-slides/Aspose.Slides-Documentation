---
title: Agregar Diapositiva a la Presentación
type: docs
weight: 10
url: /es/androidjava/add-slide-to-presentation/
---

## **Agregar Diapositiva a la Presentación**
{{% alert color="primary" %}} 

Antes de hablar sobre cómo agregar diapositivas a los archivos de presentación, discutamos algunos hechos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva **Maestra / Diseño** y otras diapositivas **Normales**. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides para Android a través de Java. Cada diapositiva tiene un Id único y todas las Diapositivas Normales están organizadas en un orden específico por el índice basado en cero.

{{% /alert %}} 

Aspose.Slides para Android a través de Java permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía en la presentación, por favor siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) configurando una referencia a la propiedad [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (colección de objetos Slide de contenido) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando al método [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection).
- Realice alguna tarea con la diapositiva vacía recién agregada.
- Finalmente, escriba el archivo de presentación utilizando el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).

```java
// Instanciar la clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation();
try {
    // Instanciar la clase SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Agregar una diapositiva vacía a la colección de Diapositivas
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Realizar alguna tarea en la diapositiva recién agregada

    // Guardar el archivo PPTX en el disco
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```