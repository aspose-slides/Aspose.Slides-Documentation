---
title: Clonar diapositivas de presentación en Java
linktitle: Clonar diapositivas
type: docs
weight: 35
url: /es/java/clone-slides/
keywords:
- clonar diapositiva
- copiar diapositiva
- guardar diapositiva
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Duplica rápidamente diapositivas de PowerPoint con Aspose.Slides para Java. Sigue nuestros claros ejemplos de código para automatizar la creación de PPT en segundos y eliminar el trabajo manual."
---

## **Clonar diapositivas en una presentación**
Cloning es el proceso de crear una copia exacta o réplica de algo. Aspose.Slides for Java también permite hacer una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que puede ser modificada por los desarrolladores sin cambiar la diapositiva original. Hay varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides for Java, (una colección de [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) objetos) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) proporciona los métodos [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) y [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) para realizar los tipos anteriores de clonación de diapositivas

## **Clonar una diapositiva al final de una presentación**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utilice el método [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) según los pasos enumerados a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) haciendo referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Llame al método [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) y pase la diapositiva a clonar como parámetro del método [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Escriba el archivo de presentación modificado.

En el ejemplo a continuación, hemos clonado una diapositiva (que se encuentra en la primera posición – índice cero – de la presentación) al final de la presentación.
```java
// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Guardar la presentación modificada en disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Clonar una diapositiva a otra posición dentro de una presentación**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, utilice el método [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Instancie la clase haciendo referencia a la colección [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Llame al método [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) y pase la diapositiva a clonar junto con el índice para la nueva posición como parámetro del método [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Escriba la presentación modificada como archivo PPTX.

En el ejemplo a continuación, hemos clonado una diapositiva (que se encuentra en el índice cero – posición 1 – de la presentación) al índice 1 – Posición 2 – de la presentación.
```java
// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    ISlideCollection slds = pres.getSlides();

    // Clonar la diapositiva deseada al índice especificado en la misma presentación
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Guardar la presentación modificada en disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Clonar una diapositiva al final de otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otra presentación, al final de las diapositivas existentes:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que contenga la presentación de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que contenga la presentación de destino a la que se añadirá la diapositiva.
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) haciendo referencia a la colección [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) expuesta por el objeto Presentation de la presentación de destino.
1. Llame al método [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) y pase la diapositiva de la presentación origen como parámetro del método [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Escriba el archivo de presentación de destino modificado.

En el ejemplo a continuación, hemos clonado una diapositiva (del primer índice de la presentación origen) al final de la presentación de destino.
```java
// Instanciar la clase Presentation para cargar el archivo de presentación fuente
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    Presentation destPres = new Presentation();
    try {
        // Clonar la diapositiva deseada de la presentación fuente al final de la colección de diapositivas en la presentación de destino
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Guardar la presentación de destino en disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Clonar una diapositiva a otra posición en otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otra presentación, en una posición específica:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que contenga la presentación origen de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que contenga la presentación a la que se añadirá la diapositiva.
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) haciendo referencia a la colección Slides expuesta por el objeto Presentation de la presentación de destino.
1. Llame al método [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) y pase la diapositiva de la presentación origen junto con la posición deseada como parámetro del método [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Escriba el archivo de presentación de destino modificado.

En el ejemplo a continuación, hemos clonado una diapositiva (del índice cero de la presentación origen) al índice 1 (posición 2) de la presentación de destino.
```java
// Instanciar la clase Presentation para cargar el archivo de presentación fuente
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    Presentation destPres = new Presentation();
    try {
        // Clonar la diapositiva deseada de la presentación fuente al final de la colección de diapositivas en la presentación de destino
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Guardar la presentación de destino en disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Clonar una diapositiva en una posición específica en otra presentación**
Si necesita clonar una diapositiva con una diapositiva maestra de una presentación y usarla en otra, primero debe clonar la diapositiva maestra deseada de la presentación origen a la presentación de destino. Luego debe usar esa maestra para clonar la diapositiva con maestra. El método [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) espera una maestra de la presentación de destino y no de la origen. Para clonar la diapositiva con maestra, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que contenga la presentación origen de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que contenga la presentación de destino a la que se clonará la diapositiva.
1. Acceda a la diapositiva a clonar junto con la diapositiva maestra.
1. Instancie la clase [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) haciendo referencia a la colección Masters expuesta por el objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) de la presentación de destino.
1. Llame al método [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) y pase la diapositiva maestra del PPTX origen a clonar como parámetro del método [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) estableciendo la referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) de la presentación de destino.
1. Llame al método [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) y pase la diapositiva de la presentación origen a clonar y la diapositiva maestra como parámetro del método [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Escriba el archivo de presentación de destino modificado.

En el ejemplo a continuación, hemos clonado una diapositiva con una maestra (que se encuentra en el índice cero de la presentación origen) al final de la presentación de destino usando una maestra de la diapositiva origen.
```java
// Instanciar la clase Presentation para cargar el archivo de presentación fuente
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanciar la clase Presentation para la presentación de destino (donde se clonará la diapositiva)
    Presentation destPres = new Presentation();
    try {
        // Instanciar ISlide a partir de la colección de diapositivas en la presentación fuente junto con
        // Diapositiva maestra
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clonar la diapositiva maestra deseada de la presentación fuente a la colección de maestros en la
        // presentación de destino
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clonar la diapositiva maestra deseada de la presentación fuente a la colección de maestros en la
        // presentación de destino
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Clonar la diapositiva deseada de la presentación fuente con la maestra deseada al final de la
        // colección de diapositivas en la presentación de destino
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Guardar la presentación de destino en disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Clonar una diapositiva al final de una sección especificada**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una sección diferente, utilice el método [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) expuesto por la interfaz [**ISlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java permite clonar una diapositiva de la primera sección y luego insertar esa diapositiva clonada en la segunda sección de la misma presentación.

El siguiente fragmento de código muestra cómo clonar una diapositiva e insertarla en una sección especificada.
```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
	
	// Guardar la presentación de destino en disco
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**¿Se clonan las notas del presentador y los comentarios de revisión?**

Sí. La página de notas y los comentarios de revisión se incluyen en la clonación. Si no los desea, [elimínelos](/slides/es/java/presentation-notes/) después de la inserción.

**¿Cómo se manejan los gráficos y sus fuentes de datos?**

El objeto de gráfico, su formato y los datos incrustados se copian. Si el gráfico estaba vinculado a una fuente externa (p. ej., un libro de trabajo OLE incrustado), ese vínculo se conserva como un [objeto OLE](/slides/es/java/manage-ole/). Después de moverlo entre archivos, verifique la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones para la clonación?**

Sí. Puede insertar la clonación en un índice de diapositiva específico y ubicarla en una [sección](/slides/es/java/slide-section/) elegida. Si la sección de destino no existe, créela primero y luego mueva la diapositiva a ella.