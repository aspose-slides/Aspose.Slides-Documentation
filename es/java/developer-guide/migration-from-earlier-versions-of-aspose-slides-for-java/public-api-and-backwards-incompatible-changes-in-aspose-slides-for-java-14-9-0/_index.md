---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para Java 14.9.0
linktitle: Aspose.Slides para Java 14.9.0
type: docs
weight: 80
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
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
description: "Revisa las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para Java para migrar sin problemas tus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las [añadidos](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) clases, métodos, propiedades, etc., así como cualquier nueva restricción y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introducidos con la API de Aspose.Slides para Java 14.9.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Métodos añadidos para reemplazar Image por PPImage, IPPImage**
Nuevos métodos añadidos:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // La primera forma
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // La segunda forma
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Métodos añadidos para guardar diapositivas manteniendo los números de página**
Se han añadido los siguientes métodos:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Estos métodos permiten guardar diapositivas especificadas de la presentación en formatos PDF, XPS, TIFF, HTML. El array 'slides' permite especificar los números de página, comenzando desde 1.

``` java
// Sobrecargas añadidas a IPresentation (los valores de SaveFormat son constantes int en Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Array de posiciones de diapositivas

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Añadido el valor Enum SmartArtLayoutType.Custom**
Este tipo de diseño SmartArt representa un diagrama con una plantilla personalizada. Los diagramas personalizados solo pueden cargarse desde un archivo de presentación y no pueden crearse mediante el método ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Añadida la clase SmartArtShape y la interfaz ISmartArtShape**
La clase Aspose.Slides.SmartArt.SmartArtShape (y su interfaz Aspose.Slides.SmartArt.ISmartArtShape) añaden acceso a las formas individuales dentro del diagrama SmartArt. SmartArtShape puede usarse para cambiar FillFormat, LineFormat, añadir hipervínculos, etc.

{{% alert color="info" %}} 

SmartArtShape no admite las propiedades IShape RawFrame, Frame, Rotation, X, Y, Width, Height y lanza System.NotSupportedException al intentar acceder a ellas.

{{% /alert %}} 

Ejemplo de uso:

``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Añadida la clase SmartArtShapeCollection, la interfaz ISmartArtShapeCollection y el método ISmartArtNode.getShapes()**
La clase Aspose.Slides.SmartArt.SmartArtShapeCollection (y su interfaz Aspose.Slides.SmartArt.ISmartArtShapeCollection) añaden acceso a las formas individuales dentro del diagrama SmartArt. La colección contiene las formas asociadas a SmartArtNode. La propiedad SmartArtNode.Shapes devuelve colecciones de todas las formas asociadas al nodo.

{{% alert color="info" %}} 

Dependiendo del SmartArtLayoutType, una SmartArtShape puede compartirse entre varios nodos.

{{% /alert %}} 




``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```