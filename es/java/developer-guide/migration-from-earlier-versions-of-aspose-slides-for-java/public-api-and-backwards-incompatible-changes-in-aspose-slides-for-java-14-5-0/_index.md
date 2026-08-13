---
title: "API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para Java 14.5.0"
linktitle: "Aspose.Slides para Java 14.5.0"
type: docs
weight: 40
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para Java para migrar sin problemas tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás, cualquier nueva [restricciones](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introducidos con la API de Aspose.Slides para Java 14.5.0.

{{% /alert %}} 
## **API pública y cambios incompatibles con versiones anteriores**
### **Clases y métodos añadidos**
#### **Añadida la interfaz Aspose.Slides.IPresentationInfo y las clases PresentationInfo**
Representa información sobre la presentación.

El método Boolean isEncrypted() devuelve True si una presentación está cifrada, de lo contrario devuelve False.

El método LoadFormat getLoadFormat() devuelve el tipo de presentación.
#### **Añadido el método Aspose.Slides.IShape.isGrouped()**
El método Aspose.Slides.IShape.isGrouped() determina si la forma está agrupada.
#### **Añadido el método Aspose.Slides.IShape.getParentGroup()**
El método Aspose.Slides.IShape.getParentGroup() devuelve el objeto GroupShape padre si la forma está agrupada. En caso contrario devuelve null.
#### **Añadido el método Aspose.Slides.IShapeCollection.addGroupShape()**
El método Aspose.Slides.IShapeCollection.addGroupShape() crea un nuevo GroupShape y lo añade al final de la colección.

El tamaño y la posición del marco del GroupShape se ajustarán al contenido cuando se añada una nueva forma al GroupShape.
#### **Añadido el método Aspose.Slides.IShapeCollection.clear()**
El método Aspose.Slides.IShapeCollection.clear() elimina todas las formas de la colección.
#### **Añadido el método Aspose.Slides.IShapeCollection.insertGroupShape(int)**
El método Aspose.Slides.IShapeCollection.insertGroupShape(int) crea un nuevo GroupShape y lo inserta en la colección en el índice especificado.
El tamaño y la posición del marco del GroupShape se ajustarán al contenido cuando se añada una nueva forma al GroupShape.
#### **Añadidos los métodos IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Estos métodos permiten a los desarrolladores obtener información sobre un archivo/flujo de presentación sin cargar la presentación completa.
#### **Añadido el método IPresentationFactory PresentationFactory.getInstance()**
Permite usar la funcionalidad de la fábrica sin instanciarla.
### **Restricciones**
#### **Se han añadido restricciones para el uso de valores indefinidos en IShape.getFrame()**
El código que intenta asignar un marco indefinido a IShape.setFrame(IShapeFrame) no tiene sentido en casos generales (en particular cuando el GroupShape padre está anidado múltiples veces dentro de otros {{GroupShape}}). Por ejemplo:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Lanza una ArgumentException: los valores del marco deben estar definidos.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

o

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Lanza una ArgumentException: los valores de x, y, anchura y altura deben estar definidos.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Tal código puede conducir a situaciones poco claras. Por lo tanto, se han añadido restricciones para el uso de valores indefinidos en IShape.Frame. Los valores de x, y, width, height, flipH, flipV y rotationAngle deben estar definidos (no Float.NaN ni NullableBool.NotDefined). El código de ejemplo anterior ahora lanza una excepción ArgumentException.
Esto se aplica a los siguientes casos de uso:

``` java
// El marco pasado a IShape.setFrame(IShapeFrame) no puede contener valores indefinidos.

// Los parámetros x, y, anchura y altura de los siguientes métodos de IShapeCollection
// no pueden ser Float.NaN tampoco:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Sin embargo, el marco devuelto por IShape.getRawFrame() puede ser indefinido. Esto tiene sentido cuando una forma está vinculada a un marcador de posición. Entonces los valores indefinidos del marco de la forma se sobrescriben con los del marcador de posición padre. Si no hay un marcador de posición padre para esa forma, se utilizan valores predeterminados al evaluar el marco efectivo basándose en su IShape.getRawFrame(). Los valores predeterminados son 0 y NullableBool.False para x, y, width, height, flipH, flipV y rotationAngle. Por ejemplo:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // La forma está vinculada a un marcador de posición.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Ahora la forma hereda los valores de x, y, altura, flipH y flipV del marcador de posición
    // y sobrescribe ancho = 100 y rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Propiedades modificadas**
#### **Modificado el tipo y nombre del método Aspose.Slides.IShapeCollection.getParent()**
El tipo de la propiedad Aspose.Slides.IShapeCollection.Parent ha cambiado de ISlideComponent a la nueva interfaz IGroupShape. La interfaz IGroupShape es descendiente de ISlideComponent, por lo que el código existente no requiere adaptación.

El nombre del método Aspose.Slides.IShapeCollection.getParent() ha sido cambiado de getParent a getParentGroup().
#### **Cambiar el tipo de los métodos Aspose.Slides.IShapeFrame.getFlipH() y .getFlipV()**
El tipo del método Aspose.Slides.IShapeFrame.getFlipH() ha cambiado de bool a NullableBool.

El método IShape.getFrame() devuelve la instancia efectiva de IShapeFrame (cuyas propiedades tienen valores efectivos definidos).

El método IShape.getRawFrame() devuelve una instancia de IShapeFrame cuyas propiedades pueden tener valores indefinidos (en particular FlipH o FlipV pueden tener el valor NullableBool.NotDefined).