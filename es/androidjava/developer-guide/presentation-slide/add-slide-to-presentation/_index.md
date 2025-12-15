---
title: Agregar diapositivas a presentaciones en Android
linktitle: Agregar diapositiva
type: docs
weight: 10
url: /es/androidjava/add-slide-to-presentation/
keywords:
- agregar diapositiva
- crear diapositiva
- diapositiva vacía
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Agregue diapositivas fácilmente a sus presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Android mediante Java: inserción de diapositivas sin problemas y eficiente en segundos."
---

## **Agregar una diapositiva a una presentación**
{{% alert color="primary" %}} 

Antes de hablar sobre cómo agregar diapositivas a los archivos de presentación, discutamos algunos hechos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva **Master / Layout** y otras diapositivas **Normal**. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides for Android via Java. Cada diapositiva tiene un Id único y todas las Diapositivas Normales se organizan en un orden especificado por el índice basado en cero.

{{% /alert %}} 

Aspose.Slides for Android via Java permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía en la presentación, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Instanciar la clase [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) estableciendo una referencia a la propiedad [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (colección de objetos Slide de contenido) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Agregar una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando a los métodos [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) expuestos por el objeto [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection).
- Realizar alguna operación con la diapositiva vacía recién añadida.
- Finalmente, escribir el archivo de presentación usando el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
```java
// Instanciar la clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation();
try {
    // Instanciar la clase SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Agregar una diapositiva vacía a la colección Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Realizar alguna operación en la diapositiva recién añadida

    // Guardar el archivo PPTX en el disco
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo insertar una nueva diapositiva en una posición específica, no solo al final?**

Sí. La biblioteca admite colecciones de diapositivas y operaciones de [insert](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) , por lo que puede agregar una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al agregar una diapositiva basada en un diseño?**

Sí. Un diseño hereda el formato de su master, y la nueva diapositiva hereda del diseño seleccionado y de su master asociado.

**¿Qué diapositiva está presente en una nueva presentación "vacía" antes de agregar diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con índice cero. Esto es importante considerar al calcular los índices de inserción.

**¿Cómo elijo el diseño "correcto" para una nueva diapositiva si el master tiene muchas opciones?**

Generalmente elija el [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) que coincida con la estructura requerida ([Título y contenido, Dos contenidos, etc.](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidelayouttype/)). Si falta dicho diseño, puede [añadirlo al master](/slides/es/androidjava/slide-layout/) y luego usarlo.