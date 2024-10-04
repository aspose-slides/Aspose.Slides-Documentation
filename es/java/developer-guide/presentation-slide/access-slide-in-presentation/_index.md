---
title: Acceder a las Diapositivas en la Presentación
type: docs
weight: 20
url: /java/access-slide-in-presentation/
keywords: "Acceder a la Presentación de PowerPoint, Acceder a la diapositiva, Editar propiedades de la diapositiva, Cambiar posición de la diapositiva, Establecer número de diapositiva, índice, ID, posición Java, Aspose.Slides"
description: "Acceda a la diapositiva de PowerPoint por índice, ID o posición en Java. Edite propiedades de la diapositiva"
---

Aspose.Slides le permite acceder a las diapositivas de dos maneras: por índice y por ID.

## **Acceder a la Diapositiva por Índice**

Todas las diapositivas en una presentación están organizadas numéricamente según la posición de la diapositiva comenzando desde 0. La primera diapositiva es accesible a través del índice 0; la segunda diapositiva se accede a través del índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) (colección de objetos [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)). Este código Java le muestra cómo acceder a una diapositiva a través de su índice:

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("demo.pptx");
try {
    // Accede a una diapositiva utilizando su índice de diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Acceder a la Diapositiva por ID**

Cada diapositiva en una presentación tiene un ID único asociado. Puede utilizar el método [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)) para apuntar a ese ID. Este código Java le muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva a través del método [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-):

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("demo.pptx");
try {
    // Obtiene un ID de diapositiva
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Accede a la diapositiva a través de su ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Cambiar la Posición de la Diapositiva**

Aspose.Slides permite cambiar la posición de una diapositiva. Por ejemplo, puede especificar que la primera diapositiva debe convertirse en la segunda diapositiva.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva (cuyo posición desea cambiar) a través de su índice.
1. Establezca una nueva posición para la diapositiva a través de la propiedad [setSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#setSlideNumber-int-).
1. Guarde la presentación modificada.

Este código Java demuestra una operación en la que la diapositiva en la posición 1 se mueve a la posición 2:

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Obtiene la diapositiva cuya posición se cambiará
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Establece la nueva posición para la diapositiva
    sld.setSlideNumber(2);
    
    // Guarda la presentación modificada
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

La primera diapositiva se convirtió en la segunda; la segunda diapositiva se convirtió en la primera. Cuando cambia la posición de una diapositiva, las otras diapositivas se ajustan automáticamente.

## **Establecer el Número de Diapositiva**

Utilizando la propiedad [setFirstSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)), puede especificar un nuevo número para la primera diapositiva en una presentación. Esta operación provoca que se recalculen los números de las otras diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenga el número de diapositiva.
1. Establezca el número de la diapositiva.
1. Guarde la presentación modificada.

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

Si prefiere omitir la primera diapositiva, puede comenzar la numeración desde la segunda diapositiva (y ocultar la numeración para la primera diapositiva) de esta manera:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Establece el número para la primera diapositiva de la presentación
    presentation.setFirstSlideNumber(0);

    // Muestra los números de las diapositivas para todas las diapositivas
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Oculta el número de la diapositiva para la primera diapositiva
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Guarda la presentación modificada
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```