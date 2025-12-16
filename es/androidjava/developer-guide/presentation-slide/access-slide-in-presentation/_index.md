---
title: Acceder a diapositivas de presentación en Android
linktitle: Acceder a diapositiva
type: docs
weight: 20
url: /es/androidjava/access-slide-in-presentation/
keywords:
- acceder a diapositiva
- índice de diapositiva
- id de diapositiva
- posición de diapositiva
- cambiar posición
- propiedades de diapositiva
- número de diapositiva
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo acceder y gestionar diapositivas en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Android. Mejore la productividad con ejemplos de código Java."
---

Aspose.Slides le permite acceder a las diapositivas de dos maneras: por índice y por ID.

## **Acceder a una diapositiva por índice**

Todas las diapositivas de una presentación se organizan numéricamente según la posición de la diapositiva comenzando desde 0. La primera diapositiva es accesible mediante el índice 0; la segunda diapositiva se accede mediante el índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) (colección de objetos [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)). Este código Java le muestra cómo acceder a una diapositiva mediante su índice:
```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("demo.pptx");
try {
    // Accede a una diapositiva usando su índice de diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **Acceder a una diapositiva por ID**

Cada diapositiva en una presentación tiene un ID único asociado. Puede utilizar el método [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)) para dirigirse a ese ID. Este código Java le muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva mediante el método [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-):
```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("demo.pptx");
try {
    // Obtiene el ID de una diapositiva
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Accede a la diapositiva a través de su ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **Cambiar la posición de la diapositiva**

Aspose.Slides permite cambiar la posición de una diapositiva. Por ejemplo, puede especificar que la primera diapositiva se convierta en la segunda diapositiva.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Obtener la referencia de la diapositiva (cuya posición desea cambiar) mediante su índice
3. Establecer una nueva posición para la diapositiva mediante la propiedad [setSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).
4. Guardar la presentación modificada.

Este código Java demuestra una operación en la que la diapositiva en la posición 1 se mueve a la posición 2:
```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Obtiene la diapositiva cuya posición será cambiada
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Establece la nueva posición de la diapositiva
    sld.setSlideNumber(2);
    
    // Guarda la presentación modificada
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


La primera diapositiva pasó a ser la segunda; la segunda diapositiva pasó a ser la primera. Cuando cambia la posición de una diapositiva, las demás diapositivas se ajustan automáticamente.

## **Establecer el número de diapositiva**

Utilizando la propiedad [setFirstSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)), puede especificar un nuevo número para la primera diapositiva de una presentación. Esta operación hace que los demás números de diapositiva se recalculen.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Obtener el número de la diapositiva.
3. Establecer el número de la diapositiva.
4. Guardar la presentación modificada.

Este código Java demuestra una operación donde el número de la primera diapositiva se establece en 10:
```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Obtiene el número de la diapositiva
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Establece el número de la diapositiva
    pres.setFirstSlideNumber(10);
    
    // Guarda la presentación modificada
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Si prefiere omitir la primera diapositiva, puede iniciar la numeración a partir de la segunda diapositiva (y ocultar la numeración para la primera diapositiva) de esta manera:
```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Establece el número para la primera diapositiva de la presentación
    presentation.setFirstSlideNumber(0);

    // Muestra los números de diapositiva para todas las diapositivas
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Oculta el número de diapositiva de la primera diapositiva
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Guarda la presentación modificada
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿El número de diapositiva que ve el usuario coincide con el índice basado en cero de la colección?**

El número mostrado en una diapositiva puede comenzar desde un valor arbitrario (p. ej., 10) y no tiene que coincidir con el índice; la relación se controla mediante la configuración del [primer número de diapositiva](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) de la presentación.

**¿Las diapositivas ocultas afectan la indexación?**

Sí. Una diapositiva oculta permanece en la colección y se cuenta en la indexación; "oculta" se refiere a la visualización, no a su posición en la colección.

**¿Cambia el índice de una diapositiva cuando se añaden o eliminan otras diapositivas?**

Sí. Los índices siempre reflejan el orden actual de las diapositivas y se recalculan al insertar, eliminar o mover diapositivas.