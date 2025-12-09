---
title: Cambios de API pública y cambios incompatibles retroactivos en Aspose.Slides para .NET 14.4.0
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
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

## **API pública y cambios incompatibles retroactivos**
### **Interfaces, clases, métodos y propiedades añadidos**
#### **Propiedad Aspose.Slides.ILayoutSlide.HasDependingSlides añadida**
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
#### **Método Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
El método Aspose.Slides.ILayoutSlideCollection.RemoveUnused() le permite eliminar diseños de diapositivas no utilizados (diseños cuya propiedad HasDependingSlides es false). Ejemplos de código:

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
#### **Propiedad Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat devuelve IFillFormat para la viñeta de un nodo SmartArt si el diseño proporciona viñetas. Puede usarse para establecer la imagen de la viñeta.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Propiedad Aspose.Slides.SmartArt.ISmartArtNode.Level**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.Level devuelve el nivel de anidación para los nodos SmartArt.

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
#### **Método Aspose.Slides.SmartArt.ISmartArtNode.Remove() añadido**
El método Aspose.Slides.SmartArt.ISmartArtNode.Remove() permite eliminar un nodo de un diagrama.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Interfaz IGlobalLayoutSlideCollection y clase GlobalLayoutSlideCollection**
Se han añadido la interfaz IGlobalLayoutSlideCollection y la clase GlobalLayoutSlideCollection al espacio de nombres Aspose.Slides.

La clase GlobalLayoutSlideCollection implementa la interfaz IGlobalLayoutSlideCollection.

La interfaz IGlobalLayoutSlideCollection representa una colección de todas las diapositivas de diseño en una presentación. La propiedad IPresentation.LayoutSlides es del tipo IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection amplía la interfaz ILayoutSlideCollection con métodos para agregar y clonar diseños de diapositiva en el contexto de la unión de las colecciones individuales de diseños de diapositivas de los maestros:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Se puede usar para agregar una copia de un diseño de diapositiva especificado a la presentación. Este método conserva el formato origen (al clonar un diseño entre diferentes presentaciones, también puede clonarse el maestro del diseño. El registro interno se usa para rastrear maestros clonados automáticamente y evitar la creación de múltiples clones del mismo maestro de diapositiva).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Se utiliza para agregar una copia de un diseño de diapositiva especificado a una presentación. El nuevo diseño quedará vinculado al maestro definido en la presentación de destino. Esta opción es análoga a copiar o pegar con la opción **Use Destination Theme** en Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Se utiliza para agregar una nueva diapositiva de diseño a una presentación. Tipos de diseño admitidos: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. El nombre del diseño puede generarse automáticamente. Un diseño añadido del tipo SlideLayoutType.Custom no contiene marcadores de posición ni formas. Un análogo de este método es el método IMasterLayoutSlideCollection.Add(SlideLayoutType, string) accesible mediante la propiedad IMasterSlide.LayoutSlides.

#### **Interfaz IMasterLayoutSlideCollection y clase MasterLayoutSlideCollection**
Se han añadido la interfaz IMasterLayoutSlideCollection y la clase MasterLayoutSlideCollection al espacio de nombres Aspose.Slides. La clase MasterLayoutSlideCollection implementa la interfaz IMasterLayoutSlideCollection.

La interfaz IMasterLayoutSlideCollection representa una colección de todas las diapositivas de diseño de un maestro definido. Amplía la interfaz ILayoutSlideCollection con métodos para agregar, insertar, eliminar o clonar diseños de diapositiva en el contexto de las colecciones individuales de diseños de diapositiva de un maestro:

``` csharp

 // Firma del método:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Ejemplo de código que adjunta una copia del sourceLayout al destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

El método puede usarse para agregar una copia de un diseño de diapositiva especificado al final de la colección. El nuevo diseño quedará vinculado al maestro padre de esta colección de diseños. Por lo tanto, es análogo a copiar o pegar con la opción **Use Destination Theme** en PowerPoint. Un análogo de este método es el método IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) accesible mediante la propiedad IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Se usa para insertar una copia de un diseño de diapositiva especificado en una posición determinada de la colección. El nuevo diseño quedará vinculado al maestro padre de esta colección de diseños. Es análogo a copiar y pegar con la opción **Use Destination Theme** en PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Se usa para agregar o insertar una nueva diapositiva de diseño. Tipos de diseño admitidos: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. El nombre del diseño puede generarse automáticamente. Un diseño añadido del tipo SlideLayoutType.Custom no contiene marcadores de posición ni formas. Un análogo de este método es el método IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) accesible mediante la propiedad IPresentation.LayoutSlides.
- void RemoveAt(int index); – Se usa para eliminar el diseño en el índice especificado de la colección.
- void Reorder(int index, ILayoutSlide layoutSlide); – Se usa para mover una diapositiva de diseño dentro de la colección a la posición especificada.

### **Métodos y propiedades modificados**
#### **Firma del método Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
La firma del método ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

está obsoleta y se reemplaza por la firma

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

El parámetro allowCloneMissingLayout especifica qué hacer si no existe un diseño adecuado en destMaster para la nueva diapositiva (clonada). El diseño adecuado es aquel con el mismo tipo o nombre que el diseño de la diapositiva origen. Si no hay un diseño adecuado en el maestro especificado, el diseño de la diapositiva origen se clonará (si allowCloneMissingLayout es true) o se lanzará una PptxEditException (si allowCloneMissingLayout es false).

Una llamada al método obsoleto como

AddClone(sourceSlide, destMaster);

asume que allowCloneMissingLayout es false (es decir, se lanzará PptxEditException si no hay un diseño adecuado). La llamada funcionalmente idéntica que usa la nueva firma se ve así:
AddClone(sourceSlide, destMaster, false);

Si desea que los diseños faltantes se clonen automáticamente en lugar de lanzar una PptxEditException, pase el parámetro allowCloneMissingLayout como true.

Lo mismo ocurre con el método ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

también está obsoleto y se reemplaza por la firma

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Tipo de la propiedad Aspose.Slides.IMasterSlide.LayoutSlides**
El tipo de la propiedad Aspose.Slides.IMasterSlide.LayoutSlides ha cambiado de ILayoutSlideCollection a la nueva interfaz IMasterLayoutSlideCollection. La interfaz IMasterLayoutSlideCollection es descendiente de ILayoutSlideCollection, por lo que el código existente no necesita adaptaciones.
#### **Tipo de la propiedad Aspose.Slides.IPresentation.LayoutSlides ha cambiado**
El tipo de la propiedad Aspose.Slides.IPresentation.LayoutSlides ha cambiado de ILayoutSlideCollection a la nueva interfaz IGlobalLayoutSlideCollection. La interfaz IGlobalLayoutSlideCollection es descendiente de ILayoutSlideCollection, por lo que el código existente no necesita adaptaciones.