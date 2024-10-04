---
title: API Pública y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para Java 14.9.0
type: docs
weight: 80
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) añadidas, métodos, propiedades, y así sucesivamente, cualquier nueva restricción y otros [cambios](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introducidos con la API Aspose.Slides para Java 14.9.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Métodos Añadidos para Reemplazar Imagen en PPImage, IPPImage**
Métodos añadidos:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//La primera forma

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//La segunda forma

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Métodos Añadidos para Guardar Diapositivas Manteniendo Números de Página**
Se han añadido los siguientes métodos:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Estos métodos permiten guardar las diapositivas de presentación especificadas en formatos PDF, XPS, TIFF, HTML. El array 'slides' permite especificar los números de página, comenzando desde 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array de posiciones de diapositivas

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Valor de Enum SmartArtLayoutType.Custom Añadido**
Este tipo de diseño SmartArt representa un diagrama con una plantilla personalizada. Los diagramas personalizados solo pueden ser cargados desde un archivo de presentación y no pueden ser creados a través del método ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Clase SmartArtShape e Interfaz ISmartArtShape Añadidas**
La clase Aspose.Slides.SmartArt.SmartArtShape (y su interfaz Aspose.Slides.SmartArt.ISmartArtShape) añaden acceso a formas individuales dentro del diagrama SmartArt. SmartArtShape se puede utilizar para cambiar FillFormat, LineFormat, añadir hiperenlaces, etc.

{{% alert color="primary" %}} 

SmartArtShape no soporta las propiedades IShape RawFrame, Frame, Rotation, X, Y, Width, Height y lanza System.NotSupportedException al intentar acceder a ellas.

{{% /alert %}} 

Ejemplo de uso:

``` java

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
### **Clase SmartArtShapeCollection, interfaz ISmartArtShapeCollection y método ISmartArtNode.getShapes() añadidos**
La clase Aspose.Slides.SmartArt.SmartArtShapeCollection (y su interfaz Aspose.Slides.SmartArt.ISmartArtShapeCollection) añaden acceso a formas individuales dentro del diagrama SmartArt. La colección contiene formas asociadas con SmartArtNode. La propiedad SmartArtNode.Shapes devuelve colecciones de todas las formas asociadas con el nodo.

{{% alert color="primary" %}} 

Dependiendo de SmartArtLayoutType, una SmartArtShape puede ser compartida entre varios nodos.

{{% /alert %}} 

﻿

``` java

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