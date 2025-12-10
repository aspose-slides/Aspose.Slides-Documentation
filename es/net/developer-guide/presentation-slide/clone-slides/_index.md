---
title: Clonar diapositivas de presentación en .NET
linktitle: Clonar diapositivas
type: docs
weight: 40
url: /es/net/clone-slides/
keywords:
- clonar diapositiva
- copiar diapositiva
- guardar diapositiva
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Duplica rápidamente diapositivas de PowerPoint con Aspose.Slides para .NET. Sigue nuestros claros ejemplos de código para automatizar la creación de PPT en segundos y eliminar el trabajo manual."
---

## **Clonar diapositivas en una presentación**
La clonación es el proceso de crear una copia exacta o réplica de algo. Aspose.Slides for .NET también permite hacer una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que los desarrolladores pueden modificar sin cambiar la diapositiva original. Existen varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides for .NET, (una colección de [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) objetos) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) proporciona los métodos [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) y [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) para realizar los tipos de clonación de diapositivas descritos arriba.

## **Clonar una diapositiva al final de una presentación**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, use el método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) siguiendo los pasos enumerados a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) haciendo referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Llame al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pase la diapositiva a clonar como parámetro del método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Guarde el archivo de presentación modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (situada en la primera posición – índice cero – de la presentación) al final de la presentación.
```c#
// Instanciar la clase Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Guardar la presentación modificada en disco
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **Clonar una diapositiva a otra posición dentro de una presentación**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, use el método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instancie la clase haciendo referencia a la colección **Slides** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Llame al método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pase la diapositiva a clonar junto con el índice de la nueva posición como parámetros del método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Guarde la presentación modificada como archivo PPTX.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (situada en el índice cero – posición 1 – de la presentación) al índice 1 – posición 2 – de la presentación.
```c#
// Instanciar la clase Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    ISlideCollection slds = pres.Slides;

    // Clonar la diapositiva deseada al índice especificado en la misma presentación
    slds.InsertClone(2, pres.Slides[1]);

    // Guardar la presentación modificada en disco
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Clonar una diapositiva al final de otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otra presentación, al final de las diapositivas existentes:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga la presentación de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga la presentación de destino a la que se añadirá la diapositiva.
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) haciendo referencia a la colección **Slides** expuesta por el objeto Presentation de la presentación de destino.
1. Llame al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pase la diapositiva de la presentación origen como parámetro del método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Guarde el archivo de la presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del primer índice de la presentación origen) al final de la presentación de destino.
```c#
// Instanciar la clase Presentation para cargar el archivo de presentación fuente
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    using (Presentation destPres = new Presentation())
    {
        // Clonar la diapositiva deseada de la presentación fuente al final de la colección de diapositivas en la presentación de destino
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Guardar la presentación de destino en disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Clonar una diapositiva a otra posición en otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otra presentación, en una posición específica:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga la presentación origen de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga la presentación de destino a la que se añadirá la diapositiva.
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) haciendo referencia a la colección Slides del objeto Presentation de la presentación de destino.
1. Llame al método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pase la diapositiva de la presentación origen junto con la posición deseada como parámetros del método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Guarde el archivo de la presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del índice cero de la presentación origen) al índice 1 (posición 2) de la presentación de destino.
```c#
// Instanciar la clase Presentation para cargar el archivo de presentación fuente
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Guardar la presentación de destino en disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Clonar una diapositiva en una posición específica en otra presentación**
Si necesita clonar una diapositiva con una diapositiva maestra de una presentación y usarla en otra presentación, primero debe clonar la diapositiva maestra deseada de la presentación origen a la presentación destino. Luego debe usar esa diapositiva maestra para clonar la diapositiva con maestra. El método **AddClone(ISlide, IMasterSlide)** espera una diapositiva maestra de la presentación destino, no de la presentación origen. Para clonar la diapositiva con maestra, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga la presentación origen de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga la presentación de destino a la que se clonará la diapositiva.
1. Acceda a la diapositiva a clonar junto con su diapositiva maestra.
1. Instancie la clase [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) haciendo referencia a la colección Masters expuesta por el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la presentación de destino.
1. Llame al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) expuesto por el objeto [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) y pase la maestra del PPTX origen que se va a clonar como parámetro del método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) estableciendo la referencia a la colección Slides del objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la presentación de destino.
1. Llame al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pase la diapositiva de la presentación origen que se va a clonar y la diapositiva maestra como parámetros del método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Guarde el archivo de la presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva con maestra (situada en el índice cero de la presentación origen) al final de la presentación de destino usando una maestra de la diapositiva origen.
```c#
// Instanciar la clase Presentation para cargar el archivo de presentación fuente

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instanciar la clase Presentation para la presentación de destino (donde se clonará la diapositiva)
    using (Presentation destPres = new Presentation())
    {

        // Instanciar ISlide a partir de la colección de diapositivas en la presentación fuente junto con
        // diapositiva maestra
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clonar la diapositiva maestra deseada de la presentación fuente a la colección de maestros en la
        // presentación de destino
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clonar la diapositiva maestra deseada de la presentación fuente a la colección de maestros en la
        // presentación de destino
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Clonar la diapositiva deseada de la presentación fuente con la maestra deseada al final de la
        // colección de diapositivas en la presentación de destino
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Clonar la diapositiva maestra deseada de la presentación fuente a la colección de maestros en la // presentación de destino
        // Guardar la presentación de destino en disco
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **Clonar una diapositiva al final de una sección especificada**

Con Aspose.Slides for .NET, puede clonar una diapositiva de una sección de una presentación e insertar esa diapositiva en otra sección de la misma presentación. En este caso, debe usar el método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) de la interfaz [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection).

Este código C# muestra cómo clonar una diapositiva e insertarla en una sección especificada:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // para clonar
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**¿Se clonan las notas del orador y los comentarios del revisor?**

Sí. La página de notas y los comentarios de revisión se incluyen en el clon. Si no los desea, [elimínelos](/slides/es/net/presentation-notes/) después de la inserción.

**¿Cómo se manejan los gráficos y sus fuentes de datos?**

El objeto del gráfico, su formato y los datos incrustados se copian. Si el gráfico estaba vinculado a una fuente externa (p. ej., un libro de trabajo OLE incrustado), ese vínculo se conserva como un [objeto OLE](/slides/es/net/manage-ole/). Después de moverlo entre archivos, verifique la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones del clon?**

Sí. Puede insertar el clon en un índice de diapositiva específico y colocarlo en una [sección](/slides/es/net/slide-section/) elegida. Si la sección de destino no existe, créela primero y luego mueva la diapositiva a ella.