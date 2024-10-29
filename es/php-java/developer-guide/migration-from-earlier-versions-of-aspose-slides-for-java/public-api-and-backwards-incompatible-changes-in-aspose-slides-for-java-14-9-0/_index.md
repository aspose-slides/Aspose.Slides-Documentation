---
title: API Público y Cambios Incompatibles hacia Atrás en Aspose.Slides para PHP a través de Java 14.9.0
type: docs
weight: 80
url: /es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/), métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introducidos con la API de Aspose.Slides para PHP a través de Java 14.9.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Métodos Añadidos para Reemplazar Imagen a PPImage, IPPImage**
Nuevos métodos añadidos:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

```php
  $presentation = new Presentation("presentation.pptx");
  # La primera manera
  # ...
  $imageData = $presentation->getImages()->get_Item(0)->replaceImage($imageData);
  # La segunda manera
  $presentation->getImages()->get_Item(1)->replaceImage($presentation->getImages()->get_Item(0));
  $presentation->save("presentation_out.pptx", SaveFormat::Pptx);

```
### **Métodos Añadidos para Guardar Diapositivas Manteniendo Números de Página**
Se han añadido los siguientes métodos:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Estos métodos permiten guardar las diapositivas de presentación especificadas en formatos PDF, XPS, TIFF, HTML. El array 'slides' permite especificar números de página, comenzando desde 1.

```php
  save($string, $slides, SaveFormat);

```




```php
  $presentation = new Presentation($presentationFileName);
  $slides = array(2, 3, 5 );// Array de posiciones de diapositivas

  $presentation->save($outFileName, $slides, SaveFormat::Pdf);

```
### **Se Añadió el Valor de Enum SmartArtLayoutType::Custom**
Este tipo de diseño de SmartArt representa un diagrama con una plantilla personalizada. Los diagramas personalizados solo pueden cargarse desde un archivo de presentación y no se pueden crear a través del método ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType::Custom)
### **Se Añadió la Clase SmartArtShape y la Interfaz ISmartArtShape**
La clase Aspose.Slides.SmartArt.SmartArtShape (y su interfaz Aspose.Slides.SmartArt.ISmartArtShape) añaden acceso a formas individuales dentro del diagrama de SmartArt. SmartArtShape puede usarse para cambiar FillFormat, LineFormat, agregar Hipervínculos, etc.

{{% alert color="primary" %}} 

SmartArtShape no soporta las propiedades IShape RawFrame, Frame, Rotation, X, Y, Width, Height y lanza System.NotSupportedException al intentar acceder a ellas.

{{% /alert %}} 

Ejemplo de uso:

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **Se Añadió la clase SmartArtShapeCollection, la interfaz ISmartArtShapeCollection y el método ISmartArtNode.getShapes()**
La clase Aspose.Slides.SmartArt.SmartArtShapeCollection (y su interfaz Aspose.Slides.SmartArt.ISmartArtShapeCollection) añaden acceso a formas individuales dentro del diagrama de SmartArt. La colección contiene formas asociadas con SmartArtNode. La propiedad SmartArtNode.Shapes devuelve colecciones de todas las formas asociadas con el nodo.

{{% alert color="primary" %}} 

Dependiendo del SmartArtLayoutType, una SmartArtShape puede compartirse entre varios nodos.

{{% /alert %}} 

﻿

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```