---
title: Clonar diapositivas de presentación en JavaScript
linktitle: Clonar diapositivas
type: docs
weight: 35
url: /es/nodejs-java/clone-slides/
keywords:
- clonar diapositiva
- copiar diapositiva
- guardar diapositiva
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Duplica rápidamente diapositivas de PowerPoint con Aspose.Slides para Node.js. Sigue nuestros ejemplos de código para automatizar la creación de PPT en segundos y eliminar el trabajo manual."
---
## **Introducción**

La clonación es el proceso de crear una copia idéntica o réplica de algo. Aspose.Slides for Node.js via Java también permite crear una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que puede ser modificada por los desarrolladores sin cambiar la diapositiva original. Existen varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar a otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar a otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides for Node.js via Java, (una colección de [Slide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Slide) objetos) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) proporciona los métodos [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) y [insertClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) para realizar los tipos de clonación de diapositivas descritos arriba.

## **Clonar al final dentro de una presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utiliza el método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) según los pasos enumerados a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation).
1. Instancia la clase [SlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation#getSlides--) haciendo referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation).
1. Llama al método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva a clonar como parámetro al método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Guarda el archivo de presentación modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (situada en la primera posición – índice cero – de la presentación) al final de la presentación.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar la clase Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Guardar la presentación modificada en disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar a otra posición dentro de la presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, utiliza el método [insertClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation).
1. Instancia la clase haciendo referencia a la colección **Slides** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation).
1. Llama al método [insertClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva a clonar junto con el índice de la nueva posición como parámetro al método [insertClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Guarda la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (situada en el índice 1 – posición 2 – de la presentación) al índice 2 – posición 3 – de la presentación.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar la clase Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    var slds = pres.getSlides();
    // Clonar la diapositiva deseada al índice especificado en la misma presentación
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Guardar la presentación modificada en disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar al final en otra presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, al final de las diapositivas existentes:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) que contenga la presentación de la cual se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) que contenga la presentación de destino a la que se añadirá la diapositiva.
1. Instancia la clase [SlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection) haciendo referencia a la colección **Slides** expuesta por el objeto Presentation de la presentación de destino.
1. Llama al método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva de la presentación origen como parámetro al método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Guarda el archivo de la presentación de destino modificada.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del primer índice de la presentación origen) al final de la presentación de destino.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar la clase Presentation para cargar el archivo de presentación de origen
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clonar la diapositiva deseada de la presentación de origen al final de la colección de diapositivas en la presentación de destino
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Guardar la presentación de destino en disco
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar a otra posición en otra presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, en una posición específica:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) que contenga la presentación origen de la cual se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) que contenga la presentación a la que se añadirá la diapositiva.
1. Instancia la clase [SlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation#getSlides--) haciendo referencia a la colección Slides expuesta por el objeto Presentation de la presentación de destino.
1. Llama al método [insertClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva de la presentación origen junto con la posición deseada como parámetro al método [insertClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Guarda el archivo de la presentación de destino modificada.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del índice cero de la presentación origen) al índice 1 (posición 2) de la presentación de destino.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar la clase Presentation para cargar el archivo de presentación de origen
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clonar la diapositiva deseada de la presentación de origen al final de la colección de diapositivas en la presentación de destino
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Guardar la presentación de destino en disco
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar en una posición específica en otra presentación**
Si necesitas clonar una diapositiva con una diapositiva maestra de una presentación y usarla en otra presentación, primero debes clonar la diapositiva maestra deseada de la presentación origen a la presentación de destino. Después deberás usar esa diapositiva maestra para clonar la diapositiva con maestra. El método [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) espera una diapositiva maestra de la presentación de destino en lugar de la presentación origen. Para clonar la diapositiva con una maestra, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) que contenga la presentación origen de la cual se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) que contenga la presentación de destino a la que se clonará la diapositiva.
1. Accede a la diapositiva a clonar junto con la diapositiva maestra.
1. Instancia la clase [MasterSlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/MasterSlideCollection) haciendo referencia a la colección Masters expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) de la presentación de destino.
1. Llama al método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) expuesto por el objeto [MasterSlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/MasterSlideCollection) y pasa la maestra del PPTX origen a clonar como parámetro al método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Instancia la clase [SlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation#getSlides--) estableciendo la referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation) de la presentación de destino.
1. Llama al método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/Presentation#getSlides--) y pasa la diapositiva de la presentación origen que se va a clonar y la diapositiva maestra como parámetros al método [addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Guarda el archivo de la presentación de destino modificada.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva con maestra (situada en el índice cero de la presentación origen) al final de la presentación de destino usando una maestra de la diapositiva origen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar la clase Presentation para cargar el archivo de presentación de origen
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanciar la clase Presentation para la presentación de destino (donde se clonará la diapositiva)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instanciar ISlide a partir de la colección de diapositivas de la presentación de origen junto con
        // Diapositiva maestra
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clonar la diapositiva maestra deseada de la presentación de origen a la colección de maestras en la
        // presentación de destino
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Clonar la diapositiva deseada de la presentación de origen con la maestra deseada al final de la
        // colección de diapositivas de la presentación de destino
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Guardar la presentación de destino en disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar al final en una sección especificada**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una sección diferente, utiliza el método [**addClone**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) expuesto por la clase [**SlideCollection**]. Aspose.Slides for Node.js via Java permite clonar una diapositiva de la primera sección y luego insertar esa diapositiva clonada en la segunda sección de la misma presentación.

El siguiente fragmento de código muestra cómo clonar una diapositiva e insertar la diapositiva clonada en una sección especificada.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Guardar la presentación de destino en disco
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Asegurar coincidencia del tamaño de la diapositiva**

Al clonar diapositivas en otra presentación, asegúrate de que la presentación de destino tenga el mismo tamaño de diapositiva que la de origen. Si los tamaños de diapositiva difieren, Aspose.Slides no redimensiona automáticamente las formas clonadas; sus coordenadas y dimensiones originales se conservan, lo que puede provocar que el contenido aparezca desalineado o se extienda más allá de los límites de la diapositiva.

Puedes establecer el tamaño de diapositiva de la presentación de destino para que coincida con el de origen antes de clonar la maestra y la diapositiva:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Haz esto antes de clonar la maestra y la diapositiva.

## **Preguntas frecuentes**

**¿Se clonan las notas del orador y los comentarios de revisión?**

Sí. La página de notas y los comentarios de revisión se incluyen en el clon. Si no los deseas, [elimínalos](/slides/es/nodejs-java/presentation-notes/) después de la inserción.

**¿Cómo se manejan los gráficos y sus fuentes de datos?**

El objeto del gráfico, su formato y los datos incrustados se copian. Si el gráfico estaba vinculado a una fuente externa (por ejemplo, un libro de trabajo incrustado como OLE), ese vínculo se conserva como un [objeto OLE](/slides/es/nodejs-java/manage-ole/). Después de moverlos entre archivos, verifica la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones del clon?**

Sí. Puedes insertar el clon en un índice de diapositiva específico y colocarlo en una [sección](/slides/es/nodejs-java/slide-section/) elegida. Si la sección de destino no existe, créala primero y luego mueve la diapositiva a ella.