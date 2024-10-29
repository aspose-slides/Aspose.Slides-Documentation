---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para Java 14.5.0
type: docs
weight: 40
url: /es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) añadidas, métodos, propiedades y así sucesivamente, cualquier nueva [restricción](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) y otros [cambios](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introducidos con la API de Aspose.Slides para Java 14.5.0.

{{% /alert %}} 
## **API Público y Cambios Incompatibles con Versiones Anteriores**
### **Clases y Métodos Añadidos**
#### **Añadida la interfaz Aspose.Slides.IPresentationInfo y la clase PresentationInfo**
Representa información sobre la presentación.

El método Boolean isEncrypted() devuelve True si una presentación está encriptada, de lo contrario devuelve False.

El método LoadFormat getLoadFormat() obtiene el tipo de presentación.
#### **Añadido el Método Aspose.Slides.IShape.isGrouped()**
El método Aspose.Slides.IShape.isGrouped() determina si la forma está agrupada.
#### **Añadido el Método Aspose.Slides.IShape.getParentGroup()**
El método Aspose.Slides.IShape.getParentGroup() devuelve el objeto GroupShape padre si la forma está agrupada. De lo contrario, devuelve null.
#### **Añadido el Método Aspose.Slides.IShapeCollection.addGroupShape()**
El método Aspose.Slides.IShapeCollection.addGroupShape() crea un nuevo GroupShape y lo añade al final de la colección.

El tamaño y la posición del marco de GroupShape se ajustarán al contenido cuando se añada una nueva forma al GroupShape.
#### **Añadido el Método Aspose.Slides.IShapeCollection.clear()**
El método Aspose.Slides.IShapeCollection.clear() elimina todas las formas de la colección.
#### **Añadido el Método Aspose.Slides.IShapeCollection.insertGroupShape(int)**
El método Aspose.Slides.IShapeCollection.insertGroupShape(int) crea un nuevo GroupShape e inserta en la colección en el índice especificado.
El tamaño y la posición del marco de GroupShape se ajustarán al contenido cuando se añada una nueva forma al GroupShape.
#### **Añadidos los Métodos IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Estos métodos permiten a los desarrolladores recibir información sobre un archivo/stream de presentación sin cargar la presentación completa.
#### **Añadido el Método IPresentationFactory PresentationFactory.getInstance()**
Permite utilizar la funcionalidad de la fábrica sin instanciación.
### **Restricciones**
#### **Se han añadido restricciones para usar valores no definidos para IShape.getFrame()**
El código que intenta asignar un marco indefinido a IShape.setFrame(IShapeFrame) no tiene sentido en casos generales (particularmente cuando el GroupShape padre está anidado en otros {{GroupShape}}). Por ejemplo:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

o

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Tal código puede llevar a situaciones poco claras. Por lo tanto, se han añadido restricciones para usar valores no definidos para IShape.Frame. Los valores de x, y, ancho, altura, flipH, flipV y rotationAngle deben estar definidos (no Float.NaN o NullableBool.NotDefined). El código de ejemplo anterior ahora lanza una excepción ArgumentException.
Esto se aplica a estos casos de uso:

``` java

 IShape shape = ...;

shape.setFrame(...); // no puede ser indefinido

IShapeCollection shapes = ...;

// los parámetros x, y, ancho, altura no pueden ser Float.NaN:

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

Pero el marco IShape.getRawFrame() puede ser indefinido. Esto tiene sentido cuando una forma está vinculada a un marcador de posición. Entonces, los valores de marco de forma indefinidos se sobreescriben desde el marcador de posición padre. Si no hay un marcador de posición padre para esa forma, entonces utiliza valores predeterminados cuando evalúa el marco efectivo basado en su IShape.getRawFrame(). Los valores predeterminados son 0 y NullableBool.False para x, y, ancho, altura, flipH, flipV y rotationAngle. Por ejemplo:

``` java

 IShape shape = ...; // la forma está vinculada al marcador de posición

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// ahora la forma hereda los valores x, y, altura, flipH, flipV del marcador de posición y sobreescribe ancho=100 y rotationAngle=0.

```
### **Propiedades Cambiadas**
#### **Cambio del Tipo y Nombre del Método Aspose.Slides.IShapeCollection.getParent()**
El tipo de la propiedad Aspose.Slides.IShapeCollection.Parent ha cambiado de ISlideComponent a la nueva interfaz IGroupShape. La interfaz IGroupShape es un descendiente de ISlideComponent, por lo que el código existente no necesita adaptación.

El nombre del método Aspose.Slides.IShapeCollection.getParent() ha cambiado de getParent a getParentGroup().
#### **Cambio del Tipo de los Métodos Aspose.Slides.IShapeFrame.getFlipH() y .getFlipV()**
El tipo del método Aspose.Slides.IShapeFrame.getFlipH() ha cambiado de bool a NullableBool.

El método IShape.getFrame() devuelve la instancia efectiva de IShapeFrame (todas cuyas propiedades tienen valores efectivos definidos).

El método IShape.getRawFrame() devuelve una instancia de IShapeFrame de la cual cada propiedad puede tener un valor indefinido (particularmente FlipH o FlipV pueden tener el valor NullableBool.NotDefined).