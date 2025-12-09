---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 14.4.0
linktitle: Aspose.Slides para .NET 14.4.0
type: docs
weight: 60
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios críticos en Aspose.Slides para .NET para migrar suavemente tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

## **API pública y cambios incompatibles hacia atrás**
### **Interfaces, clases, métodos y propiedades añadidos**
#### **Se ha añadido la propiedad Aspose.Slides.ILayoutSlide.HasDependingSlides**
La propiedad Aspose.Slides.ILayoutSlide.HasDependingSlides devuelve true si existe al menos una diapositiva que depende de esta diapositiva de diseño. Por ejemplo:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Método Aspose.Slides.ILayoutSlide.Remove()**
El método Aspose.Slides.ILayoutSlide.Remove() le permite eliminar un diseño de una presentación con la mínima cantidad de código. Por ejemplo:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Método Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
El método Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) le permite eliminar un diseño de la colección. Ejemplos de código:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

o

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
El método Aspose.Slides.ILayoutSlideCollection.RemoveUnused() le permite eliminar los diseños de diapositiva no usados (diseños cuya propiedad HasDependingSlides es false). Ejemplos de código:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

o

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Propiedad Aspose.Slides.IMasterSlide.HasDependingSlides**
La propiedad Aspose.Slides.IMasterSlide.HasDependingSlides devuelve true si existe al menos una diapositiva que depende de esta diapositiva maestra. Por ejemplo:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Método Aspose.Slides.ISlide.Remove()**
El método Aspose.Slides.ISlide.Remove() le permite eliminar una diapositiva de una presentación con la mínima cantidad de código. Por ejemplo:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat devuelve IFillFormat para una viñeta de nodo SmartArt si el diseño proporciona viñetas. Puede usarse para establecer la imagen de la viñeta.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Propiedad Aspose.Slides.SmartArt.ISmartArtNode.Level**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.Level devuelve el nivel anidado para los nodos SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Propiedad Aspose.Slides.SmartArt.ISmartArtNode.Position**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.Position devuelve la posición de un nodo entre sus hermanos.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Se ha añadido el método Aspose.Slides.SmartArt.ISmartArtNode.Remove()**
El método Aspose.Slides.SmartArt.ISmartArtNode.Remove() permite eliminar un nodo de un diagrama.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Interfaz IGlobalLayoutSlideCollection y clase GlobalLayoutSlideCollection**
Se han añadido la interfaz IGlobalLayoutSlideCollection y la clase GlobalLayoutSlideCollection al espacio de nombres Aspose.Slides.

La clase GlobalLayoutSlideCollection implementa la interfaz IGlobalLayoutSlideCollection.

La interfaz IGlobalLayoutSlideCollection representa una colección de todas las diapositivas de diseño en una presentación. La propiedad IPresentation.LayoutSlides es del tipo IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection amplía la interfaz ILayoutSlideCollection con métodos para añadir y clonar diapositivas de diseño en el contexto de la unión de las colecciones individuales de diseños de los maestros:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Puede usarse para añadir una copia de una diapositiva de diseño especificada a la presentación. Este método conserva el formato de origen (al clonar un diseño entre presentaciones diferentes, también puede clonarse el maestro del diseño. El registro interno se usa para rastrear automáticamente los maestros clonados y evitar la creación de varios clones del mismo maestro de diapositiva).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Se usa para añadir una copia de una diapositiva de diseño especificada a una presentación. El nuevo diseño quedará vinculado al maestro definido en la presentación de destino. Esta opción es análoga a copiar o pegar con la opción **Use Destination Theme** en Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Se usa para añadir una nueva diapositiva de diseño a una presentación. Tipos de diseño soportados: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. El nombre del diseño puede generarse automáticamente. Un diseño añadido del tipo SlideLayoutType.Custom no contiene marcadores de posición ni formas. Un análogo de este método es el método IMasterLayoutSlideCollection.Add(SlideLayoutType, string) al que se accede mediante la propiedad IMasterSlide.LayoutSlides.
#### **Interfaz IMasterLayoutSlideCollection y clase MasterLayoutSlideCollection**
Se han añadido la interfaz IMasterLayoutSlideCollection y la clase MasterLayoutSlideCollection al espacio de nombres Aspose.Slides. La clase MasterLayoutSlideCollection implementa la interfaz IMasterLayoutSlideCollection.

La interfaz IMasterLayoutSlideCollection representa una colección de todas las diapositivas de diseño de un maestro definido. Amplía la interfaz ILayoutSlideCollection con métodos para añadir, insertar, eliminar o clonar diapositivas de diseño en el contexto de las colecciones individuales de los diseños de un maestro:

``` csharp

 // Firma del método:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Ejemplo de código que adjunta una copia del sourceLayout al destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

El método puede usarse para añadir una copia de una diapositiva de diseño especificada al final de la colección. El nuevo diseño quedará vinculado al maestro padre de esta colección de diseños. Por lo tanto es análogo a copiar o pegar con la opción **Use Destination Theme** en PowerPoint. Un análogo de este método es el método IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) al que se accede mediante la propiedad IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Se usa para insertar una copia de una diapositiva de diseño especificada en la posición indicada de la colección. El nuevo diseño quedará vinculado al maestro padre de esta colección de diseños. Es análogo a copiar y pegar con la opción **Use Destination Theme** en PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Se usa para añadir o insertar una nueva diapositiva de diseño. Tipos de diseño soportados: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. El nombre del diseño puede generarse automáticamente. Un diseño añadido del tipo SlideLayoutType.Custom no contiene marcadores de posición ni formas. Un análogo de este método es el método IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) al que se accede mediante la propiedad IPresentation.LayoutSlides.
- void RemoveAt(int index); – Se usa para eliminar el diseño en el índice especificado de la colección.
- void Reorder(int index, ILayoutSlide layoutSlide); – Se usa para mover una diapositiva de diseño dentro de la colección a la posición especificada.
### **Métodos y propiedades modificados**
#### **Firma del método Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
La firma del método ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

está obsoleta y se reemplaza por la firma

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

El parámetro allowCloneMissingLayout especifica qué hacer si no hay un diseño apropiado en destMaster para la nueva diapositiva (clonada). El diseño apropiado es el que tiene el mismo tipo o nombre que el diseño de la diapositiva de origen. Si no existe un diseño apropiado en el maestro especificado, entonces se clonará el diseño de la diapositiva de origen (si allowCloneMissingLayout es true) o se lanzará una PptxEditException (si allowCloneMissingLayout es false).

Una llamada al método obsoleto como

AddClone(sourceSlide, destMaster);

asume que allowCloneMissingLayout es false (es decir, se lanzará PptxEditException si no hay un diseño apropiado). Una llamada funcionalmente idéntica que usa la nueva firma se ve así:
AddClone(sourceSlide, destMaster, false);

Si desea que los diseños faltantes se clonen automáticamente en lugar de lanzar PptxEditException, pase el parámetro allowCloneMissingLayout como true.

Lo mismo ocurre con el método ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

que también está obsoleto y se reemplaza por la firma

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Tipo de la propiedad Aspose.Slides.IMasterSlide.LayoutSlides**
El tipo de la propiedad Aspose.Slides.IMasterSlide.LayoutSlides ha cambiado de ILayoutSlideCollection a la nueva interfaz IMasterLayoutSlideCollection. La interfaz IMasterLayoutSlideCollection es descendiente de ILayoutSlideCollection, por lo que el código existente no necesita adaptaciones.
#### **Tipo de la propiedad Aspose.Slides.IPresentation.LayoutSlides ha cambiado**
El tipo de la propiedad Aspose.Slides.IPresentation.LayoutSlides ha cambiado de ILayoutSlideCollection a la nueva interfaz IGlobalLayoutSlideCollection. La interfaz IGlobalLayoutSlideCollection es descendiente de ILayoutSlideCollection, por lo que el código existente no necesita adaptaciones.