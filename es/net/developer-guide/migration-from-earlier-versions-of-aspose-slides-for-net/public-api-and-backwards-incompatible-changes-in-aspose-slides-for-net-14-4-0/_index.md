---
title: API público y cambios incompatibles hacia atrás en Aspose.Slides para .NET 14.4.0
type: docs
weight: 60
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
---

## **API público y cambios incompatibles hacia atrás**
### **Interfaces, Clases, Métodos y Propiedades Agregados**
#### **Se ha agregado la propiedad Aspose.Slides.ILayoutSlide.HasDependingSlides**
La propiedad Aspose.Slides.ILayoutSlide.HasDependingSlides devuelve verdadero si existe al menos una diapositiva que depende de esta diapositiva de diseño. Por ejemplo:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Método Aspose.Slides.ILayoutSlide.Remove()**
El método Aspose.Slides.ILayoutSlide.Remove() te permite eliminar un diseño de una presentación con un mínimo de código. Por ejemplo:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Método Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
El método Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) te permite eliminar un diseño de la colección. Ejemplos de código:

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
El método Aspose.Slides.ILayoutSlideCollection.RemoveUnused() te permite eliminar diapositivas de diseño no utilizadas (diapositivas de diseño cuya HasDependingSlides es falso). Ejemplos de código:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

o

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Propiedad Aspose.Slides.IMasterSlide.HasDependingSlides**
La propiedad Aspose.Slides.IMasterSlide.HasDependingSlides devuelve verdadero si existe al menos una diapositiva que depende de esta diapositiva maestra. Por ejemplo:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Método Aspose.Slides.ISlide.Remove()**
El método Aspose.Slides.ISlide.Remove() te permite eliminar una diapositiva de una presentación con un mínimo de código. Por ejemplo:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat devuelve IFillFormat para una viñeta de nodo de SmartArt si el diseño proporciona viñetas. Se puede usar para establecer la imagen de la viñeta.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Propiedad Aspose.Slides.SmartArt.ISmartArtNode.Level**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.Level devuelve el nivel anidado para los nodos de SmartArt.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "Primer nivel";

``` 
#### **Propiedad Aspose.Slides.SmartArt.ISmartArtNode.Position**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.Position devuelve la posición de un nodo entre sus hermanos.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Se ha agregado el método Aspose.Slides.SmartArt.ISmartArtNode.Remove()**
El método Aspose.Slides.SmartArt.ISmartArtNode.Remove() permite la eliminación de un nodo de un diagrama.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **Interfaz IGlobalLayoutSlideCollection y clase GlobalLayoutSlideCollection**
La interfaz IGlobalLayoutSlideCollection y la clase GlobalLayoutSlideCollection se han agregado al espacio de nombres Aspose.Slides.

La clase GlobalLayoutSlideCollection implementa la interfaz IGlobalLayoutSlideCollection.

La interfaz IGlobalLayoutSlideCollection representa una colección de todas las diapositivas de diseño en una presentación. La propiedad IPresentation.LayoutSlides es del tipo IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection extiende la interfaz ILayoutSlideCollection con métodos para agregar y clonar diapositivas de diseño en el contexto de la unificación de las colecciones individuales de las diapositivas de diseño de los maestros:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Se puede usar para agregar una copia de una diapositiva de diseño especificada a la presentación. Este método mantiene el formato de origen (al clonar un diseño entre diferentes presentaciones, el maestro del diseño también puede clonarse. Se utiliza un registro interno para rastrear automáticamente los maestros clonados para evitar la creación de múltiples clones de la misma diapositiva maestra).
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Usado para agregar una copia de una diapositiva de diseño especificada a una presentación. El nuevo diseño se vinculará al maestro definido en la presentación de destino. Esta opción es análoga a copiar o pegar con la opción **Usar tema de destino** en Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Usado para agregar una nueva diapositiva de diseño a una presentación. Tipos de diseño soportados: Título, SoloTítulo, En blanco, TítuloYObjeto, TextoVertical, TítuloYTextoVertical, DosObjetos, EncabezadoDeSección, DosTextosYDOSObjetos, TítuloObjetoYSubtítulo, ImagenYSubtítulo, Personalizado. El nombre del diseño se puede generar automáticamente. Un diseño agregado del tipo SlideLayoutType.Custom no contiene marcadores de posición ni formas. Un análogo de este método es el método IMasterLayoutSlideCollection.Add(SlideLayoutType, string) accesible con la propiedad IMasterSlide.LayoutSlides.
#### **Interfaz IMasterLayoutSlideCollection y clase MasterLayoutSlideCollection**
Se ha agregado la interfaz IMasterLayoutSlideCollection y la clase MasterLayoutSlideCollection al espacio de nombres Aspose.Slides. La clase MasterLayoutSlideCollection implementa la interfaz IMasterLayoutSlideCollection.

La interfaz IMasterLayoutSlideCollection representa una colección de todas las diapositivas de diseño de una diapositiva maestra definida. Extiende la interfaz ILayoutSlideCollection con métodos para agregar, insertar, eliminar o clonar diapositivas de diseño en el contexto de las colecciones individuales de las diapositivas de diseño de un maestro:

``` csharp

 // Firma del método:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Ejemplo de código que adjunta una copia del sourceLayout al destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

El método se puede usar para agregar una copia de una diapositiva de diseño especificada al final de la colección. El nuevo diseño se vinculará con la diapositiva maestra padre para esta colección de diapositivas de diseño. Así que este es análogo a copiar o pegar con la opción **Usar tema de destino** en PowerPoint. Un análogo de este método es el método IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) accesible con la propiedad IPresentation.LayoutSlides.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Usado para insertar una copia de una diapositiva de diseño especificada en la posición especificada de la colección. El nuevo diseño se vinculará con la diapositiva maestra padre para esta colección de diapositivas de diseño. Así que este es análogo a copiar y pegar con la opción **Usar tema de destino** en PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Usado para agregar o insertar una nueva diapositiva de diseño. Tipos de diseño soportados: Título, SoloTítulo, En blanco, TítuloYObjeto, TextoVertical, TítuloYTextoVertical, DosObjetos, EncabezadoDeSección, DosTextosYDOSObjetos, TítuloObjetoYSubtítulo, ImagenYSubtítulo, Personalizado. El nombre del diseño se puede generar automáticamente. Un diseño agregado del tipo SlideLayoutType.Custom no contiene marcadores de posición ni formas. Un análogo de este método es el método IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) accesible con la propiedad IPresentation.LayoutSlides.
- void RemoveAt(int index); – Usado para eliminar el diseño en el índice especificado de la colección.
- void Reorder(int index, ILayoutSlide layoutSlide); – Usado para mover la diapositiva de diseño de la colección a la posición especificada.
### **Métodos y Propiedades Cambiadas**
#### **Firma del método Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
La firma del método ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

es obsoleta ahora y se reemplaza por la firma

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

El parámetro allowCloneMissingLayout especifica qué hacer si no hay un diseño apropiado en el destMaster para la nueva (clonada) diapositiva. El diseño apropiado es el diseño con el mismo tipo o nombre que el diseño de la diapositiva de origen. Si no hay un diseño apropiado en el maestro especificado, entonces el diseño de la diapositiva de origen será clonado (si allowCloneMissingLayout es verdadero) o se lanzará una PptxEditException (si allowCloneMissingLayout es falso).

La llamada al método obsoleto como

AddClone(sourceSlide, destMaster);

asume que allowCloneMissingLayout es igual a falso (es decir, se lanzará PptxEditException si no hay un diseño apropiado). La llamada funcionalmente idéntica que utiliza la nueva firma se ve así:
AddClone(sourceSlide, destMaster, false);

Si deseas que los diseños faltantes sean clonados automáticamente en lugar de lanzar PptxEditException, entonces pasa el parámetro allowCloneMissingLayout como verdadero.

Lo mismo se refiere al método ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

también está obsoleto ahora y se reemplaza por la firma

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Tipo de la propiedad Aspose.Slides.IMasterSlide.LayoutSlides**
El tipo de la propiedad Aspose.Slides.IMasterSlide.LayoutSlides ha sido cambiado de ILayoutSlideCollection a la nueva interfaz IMasterLayoutSlideCollection. La interfaz IMasterLayoutSlideCollection es un descendiente de la ILayoutSlideCollection por lo que el código existente no necesita adaptaciones.
#### **Tipo de la propiedad Aspose.Slides.IPresentation.LayoutSlides ha sido cambiado**
El tipo de la propiedad Aspose.Slides.IPresentation.LayoutSlides ha sido cambiado de ILayoutSlideCollection a la nueva interfaz IGlobalLayoutSlideCollection. La interfaz IGlobalLayoutSlideCollection es un descendiente de la ILayoutSlideCollection por lo que el código existente no necesita adaptaciones.