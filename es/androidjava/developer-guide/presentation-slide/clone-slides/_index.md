---
title: Clonar diapositivas
type: docs
weight: 35
url: /es/androidjava/clone-slides/
---


## **Clonar diapositivas en Presentación**
Clonar es el proceso de hacer una copia exacta o réplica de algo. Aspose.Slides para Android a través de Java también permite hacer una copia o clonar cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que puede ser modificada por los desarrolladores sin cambiar la diapositiva original. Hay varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides para Android a través de Java, (una colección de [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) objetos) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) proporciona los métodos [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) y [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) para realizar los tipos de clonación de diapositivas anteriores.

## **Clonar al final dentro de una Presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utiliza el método [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) según los pasos listados a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) haciendo referencia a la colección de diapositivas expuesta por el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Llama al método [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) y pasa la diapositiva a ser clonada como un parámetro al método [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Escribe el archivo de presentación modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (que se encuentra en la primera posición - índice cero - de la presentación) al final de la presentación.

```java
// Instancia la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clona la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Escribe la presentación modificada en el disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar en otra posición dentro de la Presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, utiliza el método [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Instancia la clase haciendo referencia a la colección de [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Llama al método [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) y pasa la diapositiva a ser clonada junto con el índice para la nueva posición como un parámetro al método [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos clonado una diapositiva (que se encuentra en el índice cero - posición 1 - de la presentación) al índice 1 - Posición 2 - de la presentación.

```java
// Instancia la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clona la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    ISlideCollection slds = pres.getSlides();

    // Clona la diapositiva deseada al índice especificado en la misma presentación
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Escribe la presentación modificada en el disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar al final en otra Presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, al final de las diapositivas existentes:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que contiene la presentación de la que se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que contiene la presentación de destino a la que se agregará la diapositiva.
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) haciendo referencia a la colección de [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) expuesta por el objeto Presentation de la presentación de destino.
1. Llama al método [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) y pasa la diapositiva de la presentación de origen como un parámetro al método [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Escribe el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (del primer índice de la presentación de origen) al final de la presentación de destino.

```java
// Instancia la clase Presentation para cargar el archivo de presentación fuente
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancia la clase Presentation para PPTX de destino (donde se clonará la diapositiva)
    Presentation destPres = new Presentation();
    try {
        // Clona la diapositiva deseada de la presentación de origen al final de la colección de diapositivas en la presentación de destino
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Escribe la presentación de destino en el disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar en otra posición en otra Presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, en una posición específica:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que contiene la presentación fuente de la que se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que contiene la presentación a la que se agregará la diapositiva.
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) haciendo referencia a la colección de diapositivas expuesta por el objeto Presentation de la presentación de destino.
1. Llama al método [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) y pasa la diapositiva de la presentación de origen junto con la posición deseada como un parámetro al método [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) method.
1. Escribe el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (del índice cero de la presentación de origen) al índice 1 (posición 2) de la presentación de destino.

```java
// Instancia la clase Presentation para cargar el archivo de presentación fuente
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancia la clase Presentation para PPTX de destino (donde se clonará la diapositiva)
    Presentation destPres = new Presentation();
    try {
        // Clona la diapositiva deseada de la presentación de origen al final de la colección de diapositivas en la presentación de destino
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Escribe la presentación de destino en el disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar en una posición específica en otra Presentación**
Si necesitas clonar una diapositiva con una diapositiva maestra de una presentación y usarla en otra presentación, primero debes clonar la diapositiva maestra deseada de la presentación fuente a la presentación de destino. Luego debes usar esa diapositiva maestra para clonar la diapositiva con la diapositiva maestra. El método [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) espera una diapositiva maestra de la presentación de destino en lugar de la de la presentación fuente. Para clonar la diapositiva con una maestra, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que contiene la presentación fuente de la que se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que contiene la presentación de destino a la que se clonará la diapositiva.
1. Accede a la diapositiva que se clonará junto con la diapositiva maestra.
1. Instancia la clase [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) haciendo referencia a la colección de Maestros expuesta por el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) de la presentación de destino.
1. Llama al método [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) y pasa la maestra de la presentación fuente a ser clonada como un parámetro al método [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) haciendo referencia a la colección de diapositivas expuesta por el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) de la presentación de destino.
1. Llama al método [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) y pasa la diapositiva de la presentación fuente a ser clonada y la diapositiva maestra como un parámetro al método [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) method.
1. Escribe el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva con una maestra (que se encuentra en el índice cero de la presentación fuente) al final de la presentación de destino usando una maestra de la diapositiva fuente.

```java
// Instancia la clase Presentation para cargar el archivo de presentación fuente
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instancia la clase Presentation para la presentación de destino (donde se clonará la diapositiva)
    Presentation destPres = new Presentation();
    try {
        // Instancia ISlide de la colección de diapositivas en la presentación fuente junto con
        // la diapositiva maestra
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clona la diapositiva maestra deseada de la presentación fuente a la colección de maestros en la
        // presentación de destino
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clona la diapositiva maestra deseada de la presentación fuente a la colección de maestros en la
        // presentación de destino
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Clona la diapositiva deseada de la presentación fuente con la maestra deseada al final de la
        // colección de diapositivas en la presentación de destino
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Guarda la presentación de destino en el disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar al final en una sección especificada**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una sección diferente, utiliza el método [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) expuesto por la interfaz [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides para Android a través de Java hace posible clonar una diapositiva de la primera sección y luego insertar esa diapositiva clonada en la segunda sección de la misma presentación.

El siguiente fragmento de código muestra cómo clonar una diapositiva e insertar la diapositiva clonada en una sección especificada.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Sección 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Sección 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Guarda la presentación de destino en el disco
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```