---
title: Clonar Diapositivas
type: docs
weight: 40
url: /es/net/clone-slides/
keywords: "Clonar diapositiva, Copiar diapositiva, Guardar copia de la diapositiva, PowerPoint, Presentación, C#, Csharp, .NET, Aspose.Slides"
description: "Clonar diapositiva de PowerPoint en C# o .NET"
---

## **Clonar Diapositivas en Presentación**
El clonado es el proceso de hacer una copia exacta o réplica de algo. Aspose.Slides para .NET también hace posible hacer una copia o clonar cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonado de diapositivas crea una nueva diapositiva que puede ser modificada por los desarrolladores sin cambiar la diapositiva original. Hay varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides para .NET, (una colección de [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) objetos) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) proporciona los métodos [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) y [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) para realizar los tipos de clonado de diapositivas mencionados anteriormente.

## **Clonar al Final Dentro de una Presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utiliza el método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) de acuerdo con los pasos listados a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) haciendo referencia a la colección de Diapositivas expuesta por el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Llama al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pasa la diapositiva a clonar como un parámetro al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Escribe el archivo de presentación modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (que se encuentra en la primera posición – índice cero – de la presentación) al final de la presentación.

```c#
// Instanciar la clase Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Escribir la presentación modificada en el disco
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **Clonar en Otra Posición Dentro de la Presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, utiliza el método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instancia la clase haciendo referencia a la colección de **Slides** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Llama al método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pasa la diapositiva a clonar junto con el índice para la nueva posición como un parámetro al método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos clonado una diapositiva (que se encuentra en el índice cero – posición 1 – de la presentación) al índice 1 – Posición 2 – de la presentación.

```c#
// Instanciar la clase Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    ISlideCollection slds = pres.Slides;

    // Clonar la diapositiva deseada al índice especificado en la misma presentación
    slds.InsertClone(2, pres.Slides[1]);

    // Escribir la presentación modificada en el disco
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Clonar al Final en Otra Presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, al final de las diapositivas existentes:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contiene la presentación de la que se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contiene la presentación destino a la que se añadirá la diapositiva.
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) haciendo referencia a la colección de **Slides** expuesta por el objeto Presentation de la presentación destino.
1. Llama al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pasa la diapositiva de la presentación fuente como un parámetro al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Escribe el archivo de presentación destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (del primer índice de la presentación fuente) al final de la presentación destino.

```c#
// Instanciar la clase Presentation para cargar el archivo de presentación fuente
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanciar la clase Presentation para el destino PPTX (donde se clonará la diapositiva)
    using (Presentation destPres = new Presentation())
    {
        // Clonar la diapositiva deseada de la presentación fuente al final de la colección de diapositivas en la presentación destino
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Escribir la presentación destino en el disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Clonar en Otra Posición en Otra Presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, en una posición específica:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contiene la presentación fuente de la que se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contiene la presentación a la que se añadirá la diapositiva.
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) haciendo referencia a la colección de Slides expuesta por el objeto Presentation de la presentación destino.
1. Llama al método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pasa la diapositiva de la presentación fuente junto con la posición deseada como un parámetro al método [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Escribe el archivo de presentación destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (del índice cero de la presentación fuente) al índice 1 (posición 2) de la presentación destino.

```c#
// Instanciar la clase Presentation para cargar el archivo de presentación fuente
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanciar la clase Presentation para el destino PPTX (donde se clonará la diapositiva)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Escribir la presentación destino en el disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Clonar en una Posición Específica en Otra Presentación**
Si necesitas clonar una diapositiva con un diseño maestra de una presentación y usarla en otra presentación, primero necesitas clonar el diseño maestra deseado de la presentación fuente a la presentación destino. Luego necesitas usar ese diseño maestra para clonar la diapositiva con diseño maestra. El **AddClone(ISlide, IMasterSlide)** espera un diseño maestra de la presentación destino en lugar de la presentación fuente. Para clonar la diapositiva con un diseño maestra, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contiene la presentación fuente de la que se clonará la diapositiva.
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contiene la presentación destino a la que se clonará la diapositiva.
1. Accede a la diapositiva que se clonará junto con el diseño maestra.
1. Instancia la clase [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) haciendo referencia a la colección de Masters expuesta por el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la presentación destino.
1. Llama al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) expuesto por el objeto [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) y pasa el diseño maestra de la presentación fuente a clonar como un parámetro al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Instancia la clase [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) configurando la referencia a la colección de Diapositivas expuesta por el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la presentación destino.
1. Llama al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) y pasa la diapositiva de la presentación fuente a clonar y el diseño maestra como un parámetro al método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Escribe el archivo de presentación destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva con un diseño maestra (que se encuentra en el índice cero de la presentación fuente) al final de la presentación destino usando un diseño maestra de la diapositiva fuente.

```c#
// Instanciar la clase Presentation para cargar el archivo de presentación fuente

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instanciar la clase Presentation para la presentación destino (donde se clonará la diapositiva)
    using (Presentation destPres = new Presentation())
    {

        // Instanciar ISlide de la colección de diapositivas en la presentación fuente junto con
        // el diseño maestra
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clonar el diseño maestra deseado de la presentación fuente a la colección de maestrías en la
        // presentación destino
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clonar el diseño maestra deseado de la presentación fuente a la colección de maestrías en la
        // presentación destino
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Clonar la diapositiva deseada de la presentación fuente con el diseño maestra deseado al final de la
        // colección de diapositivas en la presentación destino
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Clonar el diseño maestra deseado de la presentación fuente a la colección de maestrías en la // presentación destino
        // Guardar la presentación destino en el disco
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## Clonar al Final en una Sección Específica

Con Aspose.Slides para .NET, puedes clonar una diapositiva de una sección de una presentación e insertar esa diapositiva en otra sección en la misma presentación. En este caso, debes usar el método [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) de la interfaz [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection).

Este código C# te muestra cómo clonar una diapositiva e insertar la diapositiva clonada en una sección específica:

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