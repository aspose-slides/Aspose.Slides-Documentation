---
title: Acceder a la diapositiva en la presentación
type: docs
weight: 20
url: /es/nodejs-java/access-slide-in-presentation/
keywords: "Acceder a presentación de PowerPoint, Acceder a diapositiva, Editar propiedades de diapositiva, Cambiar posición de diapositiva, Establecer número de diapositiva, índice, ID, posición Java, Aspose.Slides"
description: "Acceder a diapositiva de PowerPoint por índice, ID o posición en JavaScript. Editar propiedades de diapositiva"
---

Aspose.Slides le permite acceder a las diapositivas de dos maneras: por índice y por ID.

## **Acceso a la diapositiva por índice**

Todas las diapositivas de una presentación se organizan numéricamente según la posición de la diapositiva, comenzando en 0. La primera diapositiva es accesible mediante el índice 0; la segunda diapositiva se accede mediante el índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) (colección de objetos [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)). Este código JavaScript le muestra cómo acceder a una diapositiva mediante su índice:
```javascript
// Instancia un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Accede a una diapositiva usando su índice de diapositiva
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **Acceso a la diapositiva por ID**

Cada diapositiva de una presentación tiene un ID único asociado. Puede utilizar el método [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)) para dirigirse a ese ID. Este código JavaScript le muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva mediante el método [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-):
```javascript
// Instancia un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Obtiene el ID de una diapositiva
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Accede a la diapositiva mediante su ID
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **Cambiar la posición de la diapositiva**

Aspose.Slides le permite cambiar la posición de una diapositiva. Por ejemplo, puede especificar que la primera diapositiva pase a ser la segunda.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva (cuya posición desea cambiar) mediante su índice
1. Establezca una nueva posición para la diapositiva mediante la propiedad [setSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
1. Guarde la presentación modificada.

Este código JavaScript demuestra una operación en la que la diapositiva en la posición 1 se mueve a la posición 2:
```javascript
// Instancia un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Obtiene la diapositiva cuya posición será cambiada
    var sld = pres.getSlides().get_Item(0);
    // Establece la nueva posición para la diapositiva
    sld.setSlideNumber(2);
    // Guarda la presentación modificada
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


La primera diapositiva pasó a ser la segunda; la segunda diapositiva pasó a ser la primera. Cuando cambia la posición de una diapositiva, las demás diapositivas se ajustan automáticamente.

## **Establecer número de diapositiva**

Utilizando la propiedad [setFirstSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)), puede especificar un nuevo número para la primera diapositiva de una presentación. Esta operación hace que los números de las demás diapositivas se recalculen.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenga el número de la diapositiva.
1. Establezca el número de la diapositiva.
1. Guarde la presentación modificada.

Este código JavaScript demuestra una operación en la que el número de la primera diapositiva se establece en 10:
```javascript
// Instancia un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Obtiene el número de la diapositiva
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Establece el número de diapositiva
    pres.setFirstSlideNumber(10);
    // Guarda la presentación modificada
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Si prefiere omitir la primera diapositiva, puede iniciar la numeración a partir de la segunda diapositiva (y ocultar la numeración de la primera diapositiva) de esta manera:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Establece el número de la primera diapositiva de la presentación
    presentation.setFirstSlideNumber(0);
    // Muestra los números de diapositiva en todas las diapositivas
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // Oculta el número de diapositiva en la primera diapositiva
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // Guarda la presentación modificada
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**¿El número de diapositiva que ve el usuario coincide con el índice basado en cero de la colección?**

El número que se muestra en una diapositiva puede comenzar desde un valor arbitrario (p. ej., 10) y no tiene que coincidir con el índice; la relación está controlada por la configuración del [first slide number](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) de la presentación.

**¿Las diapositivas ocultas afectan la indexación?**

Sí. Una diapositiva oculta permanece en la colección y se cuenta en la indexación; "oculta" se refiere a la visualización, no a su posición en la colección.

**¿Cambia el índice de una diapositiva cuando se añaden o eliminan otras diapositivas?**

Sí. Los índices siempre reflejan el orden actual de las diapositivas y se recalculan al insertar, eliminar o mover diapositivas.