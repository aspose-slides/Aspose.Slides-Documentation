---
title: API Pública y Cambios Incompatibles hacia Atrás en Aspose.Slides para .NET 14.5.0
type: docs
weight: 70
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/), métodos, propiedades, etc., cualquier nueva [restricción](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) y otros [cambios](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introducidos con la API de Aspose.Slides para .NET 14.5.0.

{{% /alert %}} 
## **API Pública y Cambios Incompatibles hacia Atrás**
### **Interfaces, Clases, Propiedades y Métodos Añadidos**
#### **Añadida la Interfaz Aspose.Slides.IPresentationInfo y la Clase PresentationInfo**
Representa información sobre la presentación.

- La propiedad booleana IsEncrypted obtiene True si una presentación está encriptada, de lo contrario obtiene False.
- La propiedad LoadFormat obtiene el tipo de una presentación.
#### **Añadida la Propiedad Aspose.Slides.IShape.IsGrouped**
La propiedad Aspose.Slides.IShape.IsGrouped determina si una forma está agrupada.
#### **Añadida la Propiedad Aspose.Slides.IShape.ParentGroup**
La propiedad Aspose.Slides.IShape.ParentGroup devuelve el objeto GroupShape padre si una forma está agrupada. De lo contrario, devuelve null.
#### **Añadido el Método Aspose.Slides.IShapeCollection.AddGroupShape()**
El método Aspose.Slides.IShapeCollection.AddGroupShape() crea un nuevo GroupShape y lo añade al final de la colección.
El tamaño y la posición del marco de GroupShape se ajustarán al contenido cuando se añada una nueva forma.
#### **Añadido el Método Aspose.Slides.IShapeCollection.Clear()**
El método Aspose.Slides.IShapeCollection.Clear() elimina todas las formas de la colección.
#### **Añadido el Método Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
El método Aspose.Slides.IShapeCollection.InsertGroupShape(int) crea un nuevo GroupShape e lo inserta en la colección en la posición de índice especificada.
El tamaño y la posición del marco de GroupShape se ajustarán al contenido cuando se añada una nueva forma.
#### **Añadidos los Métodos IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Estos métodos permiten recibir información sobre un archivo de presentación o un flujo sin cargar completamente la presentación.
#### **Añadida la Propiedad IPresentationFactory PresentationFactory.Instance**
Esta propiedad permite a los desarrolladores utilizar la funcionalidad de la fábrica sin la necesidad de una instancia.
### **Restricciones**
#### **Restricciones a IShape.Frame**
Se han añadido restricciones para usar valores indefinidos para IShape.Frame. El código que intenta asignar un marco indefinido a IShape.Frame no tiene sentido en la mayoría de los casos (particularmente cuando el GroupShape padre está anidado múltiples veces en otros {{GroupShape}}s). Por ejemplo:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

o

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Tal código puede llevar a situaciones poco claras. Por lo tanto, se han añadido restricciones para usar valores indefinidos para IShape.Frame. Los valores de x, y, width, height, flipH, flipV y rotationAngle deben estar definidos (y no establecidos en float.NaN o NullableBool.NotDefined). El código de ejemplo anterior ahora lanza una excepción ArgumentException.
Esto se aplica a estos casos de uso:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // No puede ser indefinido

IShapeCollection shapes = ...;

// los parámetros x, y, width, height no pueden ser float.NaN:

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

Pero las propiedades de marco IShape.RawFrame pueden ser indefinidas. Esto tiene sentido cuando una forma está vinculada a un marcador de posición. Entonces, los valores de marco de forma indefinidos se sobrescriben desde el marco de forma del marcador de posición padre. Si no hay un marco de forma de marcador de posición padre, entonces esa forma utiliza valores predeterminados cuando evalúa el marco efectivo basado en su IShape.RawFrame. Los valores predeterminados son 0 y NullableBool.False para x, y, width, height, flipH, flipV y rotationAngle. Por ejemplo:

``` csharp

 IShape shape = ...; // La forma está vinculada al marcador de posición

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// ahora la forma hereda valores de x, y, height, flipH, flipV del marcador de posición y sobrescribe width=100 y rotationAngle=0.

``` 
### **Propiedades Cambiadas**
#### **Cambiado el Nombre y el Tipo de la Propiedad Aspose.Slides.IShapeCollection.Parent**
- El tipo de la propiedad Aspose.Slides.IShapeCollection.Parent ha cambiado de ISlideComponent a la nueva interfaz IGroupShape. La interfaz IGroupShape es un descendiente de ISlideComponent, por lo que el código existente no necesita adaptaciones.
- El nombre de la propiedad Aspose.Slides.IShapeCollection.Parent ha cambiado de Parent a ParentGroup.
#### **Cambiados los Tipos de las Propiedades Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- El tipo de la propiedad Aspose.Slides.IShapeFrame.FlipH ha cambiado de bool a NullableBool.
- La propiedad IShape.Frame devuelve una instancia efectiva de IShapeFrame (todas sus propiedades tienen valores efectivos definidos).
- La propiedad IShape.RawFrame devuelve una instancia de IShapeFrame de la cual cada propiedad puede tener un valor indefinido (particularmente FlipH o FlipV pueden tener el valor NullableBool.NotDefined).