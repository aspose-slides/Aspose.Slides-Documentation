---
title: API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para .NET 14.5.0
linktitle: Aspose.Slides para .NET 14.5.0
type: docs
weight: 70
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
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
description: "Revisa las actualizaciones de la API pública y los cambios disruptivos en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las clases, métodos, propiedades [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/), cualquier nueva [restricción](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) y otros [cambios](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introducidos con la API de Aspose.Slides para .NET 14.5.0.

{{% /alert %}} 
## **API pública y cambios incompatibles con versiones anteriores**
### **Interfaces, clases, propiedades y métodos añadidos**
#### **Añadida la interfaz Aspose.Slides.IPresentationInfo y la clase PresentationInfo**
Representa información sobre la presentación.

- La propiedad booleana IsEncrypted devuelve True si una presentación está encriptada, de lo contrario devuelve False.
- La propiedad LoadFormat devuelve el tipo de una presentación.
#### **Añadida la propiedad Aspose.Slides.IShape.IsGrouped**
La propiedad Aspose.Slides.IShape.IsGrouped determina si una forma está agrupada.
#### **Añadida la propiedad Aspose.Slides.IShape.ParentGroup**
La propiedad Aspose.Slides.IShape.ParentGroup devuelve el objeto GroupShape padre si una forma está agrupada. En caso contrario devuelve null.
#### **Añadido el método Aspose.Slides.IShapeCollection.AddGroupShape()**
El método Aspose.Slides.IShapeCollection.AddGroupShape() crea un nuevo GroupShape y lo añade al final de la colección.
El tamaño y posición del marco del GroupShape se ajustarán al contenido cuando se añada una nueva forma.
#### **Añadido el método Aspose.Slides.IShapeCollection.Clear()**
El método Aspose.Slides.IShapeCollection.Clear() elimina todas las formas de la colección.
#### **Añadido el método Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
El método Aspose.Slides.IShapeCollection.InsertGroupShape(int) crea un nuevo GroupShape y lo inserta en la colección en la posición de índice especificada.
El tamaño y posición del marco del GroupShape se ajustarán al contenido cuando se añada una nueva forma.
#### **Añadidos los métodos IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Estos métodos permiten obtener información sobre un archivo o flujo de presentación sin cargar completamente la presentación.
#### **Añadida la propiedad IPresentationFactory PresentationFactory.Instance**
Esta propiedad permite a los desarrolladores usar la funcionalidad de la fábrica sin instanciarla.
### **Restricciones**
#### **Restricciones a IShape.Frame**
Se han añadido restricciones para usar valores indefinidos en IShape.Frame. El código que intenta asignar un marco indefinido a IShape.Frame no tiene sentido en la mayoría de los casos (en particular cuando el GroupShape padre está anidado varias veces dentro de otros {{GroupShape}}s). Por ejemplo:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Lanza ArgumentException: los valores del marco deben estar definidos.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

o

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Lanza ArgumentException: x, y, width y height deben estar definidos.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Ese código puede generar situaciones poco claras. Por ello se han añadido restricciones para usar valores indefinidos en IShape.Frame. Los valores de x, y, width, height, flipH, flipV y rotationAngle deben estar definidos (y no configurados como float.NaN o NullableBool.NotDefined). El código de ejemplo anterior ahora lanza una excepción ArgumentException.
Esto se aplica a los siguientes casos de uso:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Los parámetros x, y, width y height no pueden ser float.NaN, y flipH, flipV
// no pueden ser NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// La misma restricción se aplica a cada método que crea una forma:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Sin embargo, las propiedades del marco IShape.RawFrame pueden estar indefinidas. Esto tiene sentido cuando una forma está vinculada a un marcador de posición. Entonces los valores de marco indefinidos de la forma se sobrescriben con los del marcador de posición padre. Si no existe un marcador de posición padre, la forma utiliza los valores predeterminados al evaluar el marco efectivo basándose en su IShape.RawFrame. Los valores predeterminados son 0 y NullableBool.False para x, y, width, height, flipH, flipV y rotationAngle. Por ejemplo:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // La forma está vinculada a un marcador de posición
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // ahora la forma hereda los valores x, y, height, flipH, flipV del marcador de posición y sobrescribe width=100 y rotationAngle=0.
}
``` 
### **Propiedades modificadas**
#### **Modificado el nombre y tipo de la propiedad Aspose.Slides.IShapeCollection.Parent**
- El tipo de la propiedad Aspose.Slides.IShapeCollection.Parent se ha cambiado de ISlideComponent a la nueva interfaz IGroupShape. La interfaz IGroupShape es descendiente de ISlideComponent, por lo que el código existente no necesita adaptaciones.
- El nombre de la propiedad Aspose.Slides.IShapeCollection.Parent se ha cambiado de Parent a ParentGroup.
#### **Modificados los tipos de las propiedades Aspose.Slides.IShapeFrame.FlipH y .FlipV**
- El tipo de la propiedad Aspose.Slides.IShapeFrame.FlipH se ha cambiado de bool a NullableBool.
- La propiedad IShape.Frame devuelve una instancia efectiva de IShapeFrame (cuyas propiedades tienen valores efectivos definidos).
- La propiedad IShape.RawFrame devuelve una instancia de IShapeFrame cuya cada propiedad puede tener un valor indefinido (en particular FlipH o FlipV pueden tener el valor NullableBool.NotDefined).