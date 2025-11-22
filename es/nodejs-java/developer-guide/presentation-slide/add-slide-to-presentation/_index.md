---
title: Agregar diapositiva a la presentación
type: docs
weight: 10
url: /es/nodejs-java/add-slide-to-presentation/
---

## **Agregar diapositiva a la presentación**
{{% alert color="primary" %}} 

Antes de hablar sobre cómo agregar diapositivas a los archivos de presentación, discutamos algunos hechos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva **Master / Layout** y otras diapositivas **Normal**. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides for Node.js via Java. Cada diapositiva tiene un Id único y todas las diapositivas Normal están organizadas en un orden especificado por el índice basado en cero.

{{% /alert %}} 

Aspose.Slides for Node.js via Java permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía en la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Instancie la clase [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) estableciendo una referencia a la propiedad [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) (colección de objetos Slide de contenido) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando al método [**addEmptySlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection).
- Realice algunas operaciones con la nueva diapositiva vacía añadida.
- Finalmente, guarde el archivo de presentación usando el objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
```javascript
// Instanciar la clase Presentation que representa el archivo de presentación
var pres = new aspose.slides.Presentation();
try {
    // Instanciar la clase SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Agregar una diapositiva vacía a la colección Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Realizar algunas operaciones en la diapositiva recién añadida
    // Guardar el archivo PPTX en el disco
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo insertar una nueva diapositiva en una posición específica, no solo al final?**

Sí. La biblioteca soporta colecciones de diapositivas y operaciones de [insert](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertclone/), por lo que puede agregar una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al agregar una diapositiva basada en un diseño?**

Sí. Un diseño hereda el formato de su master, y la nueva diapositiva hereda del diseño seleccionado y de su master asociado.

**¿Qué diapositiva está presente en una nueva presentación "vacía" antes de agregar diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con índice cero. Esto es importante al calcular los índices de inserción.

**¿Cómo elijo el diseño "correcto" para una nueva diapositiva si el master tiene muchas opciones?**

Generalmente elija el [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) que coincida con la estructura requerida ([Título y contenido, Dos contenidos, etc.](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidelayouttype/)). Si falta dicho diseño, puede [agregarlo al master](/slides/es/nodejs-java/slide-layout/) y luego usarlo.