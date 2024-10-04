---
title: API público y cambios incompatibles hacia atrás en Aspose.Slides para Java 14.5.0
type: docs
weight: 40
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) añadidas, métodos, propiedades, etc., cualquier nueva [restricción](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) y otros [cambios](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introducidos con la API de Aspose.Slides para Java 14.5.0.

{{% /alert %}} 
## **API Público y Cambios Incompatibles Hacia Atrás**
### **Clases y Métodos Añadidos**
#### **Añadida la interfaz Aspose.Slides.IPresentationInfo y las clases PresentationInfo**
Representa la información sobre la presentación.

El método Boolean isEncrypted() devuelve True si una presentación está encriptada, de lo contrario devuelve False.

El método LoadFormat getLoadFormat() obtiene el tipo de presentación.
#### **Añadido el método Aspose.Slides.IShape.isGrouped()**
El método Aspose.Slides.IShape.isGrouped() determina si la forma está agrupada.
#### **Añadido el método Aspose.Slides.IShape.getParentGroup()**
El método Aspose.Slides.IShape.getParentGroup() devuelve el objeto GroupShape padre si la forma está agrupada. De lo contrario, devuelve null.
#### **Añadido el método Aspose.Slides.IShapeCollection.addGroupShape()**
El método Aspose.Slides.IShapeCollection.addGroupShape() crea un nuevo GroupShape y lo añade al final de la colección.

El tamaño y la posición del marco de GroupShape se ajustarán al contenido cuando se añada una nueva forma al GroupShape.
#### **Añadido el método Aspose.Slides.IShapeCollection.clear()**
El método Aspose.Slides.IShapeCollection.clear() elimina todas las formas de la colección.
#### **Añadido el método Aspose.Slides.IShapeCollection.insertGroupShape(int)**
El método Aspose.Slides.IShapeCollection.insertGroupShape(int) crea un nuevo GroupShape y lo inserta en la colección en el índice especificado.
El tamaño y la posición del marco de GroupShape se ajustarán al contenido cuando se añada una nueva forma al GroupShape.
#### **Añados los métodos IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Estos métodos permiten a los desarrolladores obtener información sobre un archivo/flujo de presentación sin necesidad de cargar completamente la presentación.
#### **Añadido el método IPresentationFactory PresentationFactory.getInstance()**
Permite utilizar la funcionalidad de fábrica sin instanciación.
### **Restricciones**
#### **Se han añadido restricciones para usar valores indefinidos para IShape.getFrame()**
El código que intenta asignar un marco indefinido a IShape.setFrame(IShapeFrame) no tiene sentido en casos generales (particularmente cuando el GroupShape padre está anidado múltiples veces en otros {{GroupShape}}s). Por ejemplo:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

o

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Tal código puede llevar a situaciones poco claras. Así que se han añadido restricciones para usar valores indefinidos para IShape.Frame. Los valores de x, y, ancho, alto, flipH, flipV y rotationAngle deben estar definidos (no Float.NaN o NullableBool.NotDefined). El código de ejemplo anterior ahora lanza una excepción ArgumentException.
Esto aplica a estos casos de uso:

``` java

 IShape shape = ...;

shape.setFrame(...); // no puede ser indefinido

IShapeCollection shapes = ...;

// los parámetros x, y, ancho, alto no pueden ser Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

Pero el marco IShape.getRawFrame() puede ser indefinido. Esto tiene sentido cuando una forma está vinculada a un marcador de posición. Luego, los valores de marco indefinidos de la forma se sobrescriben desde el marcador de posición padre. Si no hay un marcador de posición padre para esa forma, entonces se utilizan valores predeterminados cuando evalúa el marco efectivo basado en su IShape.getRawFrame(). Los valores predeterminados son 0 y NullableBool.False para x, y, ancho, alto, flipH, flipV y rotationAngle. Por ejemplo:

``` java

 IShape shape = ...; // la forma está vinculada a un marcador de posición

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// ahora la forma hereda los valores x, y, alto, flipH, flipV del marcador de posición y sobrescribe ancho=100 y rotationAngle=0.

```
### **Propiedades Cambiadas**
#### **Cambiado el Tipo y Nombre del Método Aspose.Slides.IShapeCollection.getParent()**
El tipo de la propiedad Aspose.Slides.IShapeCollection.Parent ha sido cambiado de ISlideComponent a la nueva interfaz IGroupShape. La interfaz IGroupShape es descendiente de ISlideComponent, por lo que el código existente no necesita adaptación.

El nombre del método Aspose.Slides.IShapeCollection.getParent() ha sido cambiado de getParent a getParentGroup().
#### **Cambia el Tipo de los Métodos Aspose.Slides.IShapeFrame.getFlipH() y .getFlipV()**
El tipo del método Aspose.Slides.IShapeFrame.getFlipH() ha sido cambiado de bool a NullableBool.

El método IShape.getFrame() devuelve la instancia efectiva de IShapeFrame (todas cuyas propiedades tienen valores efectivos definidos).

El método IShape.getRawFrame() devuelve una instancia de IShapeFrame de la cual cada propiedad puede tener un valor indefinido (particularmente FlipH o FlipV pueden tener el valor NullableBool.NotDefined).