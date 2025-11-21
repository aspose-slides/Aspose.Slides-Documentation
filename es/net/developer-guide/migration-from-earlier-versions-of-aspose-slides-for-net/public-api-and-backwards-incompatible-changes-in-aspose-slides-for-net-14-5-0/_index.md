---
title: API pública y cambios incompatibles retroactivos en Aspose.Slides para .NET 14.5.0
linktitle: Aspose.Slides para .NET 14.5.0
type: docs
weight: 70
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migración
- código legado
- código moderno
- enfoque legado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/), cualquier nueva [restricciones](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) y otros [cambios](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introducidos con la API de Aspose.Slides para .NET 14.5.0.

{{% /alert %}} 
## **API pública y cambios incompatibles retroactivos**
### **Interfaces, clases, propiedades y métodos añadidos**
#### **Añadida la interfaz Aspose.Slides.IPresentationInfo y la clase PresentationInfo**
Representa información sobre la presentación.

- La propiedad Boolean IsEncrypted devuelve True si una presentación está cifrada, de lo contrario devuelve False.
- La propiedad LoadFormat obtiene el tipo de una presentación.
#### **Añadida la propiedad Aspose.Slides.IShape.IsGrouped**
La propiedad Aspose.Slides.IShape.IsGrouped determina si una forma está agrupada.
#### **Añadida la propiedad Aspose.Slides.IShape.ParentGroup**
La propiedad Aspose.Slides.IShape.ParentGroup devuelve el objeto GroupShape padre si una forma está agrupada. De lo contrario devuelve null.
#### **Añadido el método Aspose.Slides.IShapeCollection.AddGroupShape()**
El método Aspose.Slides.IShapeCollection.AddGroupShape() crea un nuevo GroupShape y lo agrega al final de la colección.
El tamaño y posición del marco del GroupShape se ajustarán al contenido cuando se añada una nueva forma.
#### **Añadido el método Aspose.Slides.IShapeCollection.Clear()**
El método Aspose.Slides.IShapeCollection.Clear() elimina todas las formas de la colección.
#### **Añadido el método Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
El método Aspose.Slides.IShapeCollection.InsertGroupShape(int) crea un nuevo GroupShape y lo inserta en la colección en la posición de índice especificada.
El tamaño y posición del marco del GroupShape se ajustarán al contenido cuando se añada una nueva forma.
#### **Añadidos los métodos IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Estos métodos permiten obtener información sobre un archivo o flujo de presentación sin cargar completamente la presentación.
#### **Añadida la propiedad IPresentationFactory PresentationFactory.Instance**
Esta propiedad permite a los desarrolladores usar la funcionalidad de la fábrica sin instanciar.
### **Restricciones**
#### **Restricciones a IShape.Frame**
Se han añadido restricciones para el uso de valores indefinidos en IShape.Frame. El código que intenta asignar un marco indefinido a IShape.Frame no tiene sentido en la mayoría de los casos (particularmente cuando el GroupShape padre está anidado múltiples veces dentro de otros {{GroupShape}}s). Por ejemplo:

```csharp
 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

or

```csharp
 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Tal código puede conducir a situaciones poco claras. Por lo tanto, se han añadido restricciones para el uso de valores indefinidos en IShape.Frame. Los valores de x, y, width, height, flipH, flipV y rotationAngle deben estar definidos (y no establecidos a float.NaN o NullableBool.NotDefined). El código de ejemplo anterior ahora lanza una excepción ArgumentException.
Esto se aplica a los siguientes casos de uso:

```csharp
 IShape shape = ...;

shape.Frame = ...; // Cannot be undefined

IShapeCollection shapes = ...;

// x, y, width, height parameters cannot be float.NaN:

{
    shapes.AddAudioFrameCD(...);
    shapes.AddAudioFrameEmbedded(...);
    shapes.AddAudioFrameLinked(...);
    shapes.AddAutoShape(...);
    shapes.AddChart(...);
    shapes.AddConnector(...);
    shapes.AddOleObjectFrame(...);
    shapes.AddPictureFrame(...);
    shapes.AddSmartArt(...);
    shapes.AddTable(...);
    shapes.AddVideoFrame(...);
    shapes.InsertAudioFrameEmbedded(...);
    shapes.InsertAudioFrameLinked(...);
    shapes.InsertAutoShape(...);
    shapes.InsertChart(...);
    shapes.InsertConnector(...);
    shapes.InsertOleObjectFrame(...);
    shapes.InsertPictureFrame(...);
    shapes.InsertTable(...);
    shapes.InsertVideoFrame(...);
}
``` 

Sin embargo, las propiedades del marco IShape.RawFrame pueden ser indefinidas. Esto tiene sentido cuando una forma está vinculada a un marcador de posición. Entonces los valores indefinidos del marco de la forma son sobrescritos por el marcador de posición padre. Si no existe un marcador de posición padre, la forma usa valores predeterminados al evaluar el marco efectivo basado en su IShape.RawFrame. Los valores predeterminados son 0 y NullableBool.False para x, y, width, height, flipH, flipV y rotationAngle. Por ejemplo:

```csharp
 IShape shape = ...; // shape is linked to placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);
``` 

### **Propiedades cambiadas**
#### **Cambiado el nombre y tipo de la propiedad Aspose.Slides.IShapeCollection.Parent**
- El tipo de la propiedad Aspose.Slides.IShapeCollection.Parent ha cambiado de ISlideComponent a la nueva interfaz IGroupShape. La interfaz IGroupShape es descendiente de ISlideComponent, por lo que el código existente no requiere adaptaciones.
- El nombre de la propiedad Aspose.Slides.IShapeCollection.Parent ha sido cambiado de Parent a ParentGroup.
#### **Cambiados los tipos de las propiedades Aspose.Slides.IShapeFrame.FlipH y .FlipV**
- El tipo de la propiedad Aspose.Slides.IShapeFrame.FlipH ha cambiado de bool a NullableBool.
- La propiedad IShape.Frame devuelve una instancia efectiva de IShapeFrame (cuyas propiedades tienen valores efectivos definidos).
- La propiedad IShape.RawFrame devuelve una instancia de IShapeFrame donde cada propiedad puede tener un valor indefinido (particularmente FlipH o FlipV pueden tener el valor NullableBool.NotDefined).