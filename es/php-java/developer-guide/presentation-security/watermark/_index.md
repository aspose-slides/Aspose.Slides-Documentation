---
title: Marca de agua
type: docs
weight: 40
url: /es/php-java/watermark/
keywords: "marca de agua en presentación"
description: "Usa marca de agua en PowerPoint con Aspose.Slides. Añade marca de agua en presentación ppt o elimina marca de agua. Inserta marca de agua de imagen o de texto."
---


## **Acerca de la Marca de Agua**
La **marca de agua** en presentación es un sello de texto o imagen, utilizado en una diapositiva o en todas las diapositivas de la presentación. Generalmente, la marca de agua se usa para indicar que la presentación es un borrador (por ejemplo, la marca de agua "Borrador"); que contiene información confidencial (por ejemplo, la marca de agua "Confidencial"); especificar a qué empresa pertenece (por ejemplo, la marca de agua "Nombre de la empresa"); identificar al autor de la presentación, etc. La marca de agua ayuda a prevenir la violación de derechos de autor en presentaciones, indicando que la presentación no debe ser copiada. Las marcas de agua se utilizan tanto en formatos de presentación de PowerPoint como de OpenOffice. En Aspose.Slides puedes añadir marcas de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) hay varias formas de crear marcas de agua en PowerPoint o OpenOffice, envolverla en diferentes formas, cambiar el diseño y el comportamiento, etc. Lo común es que, para añadir marcas de agua de texto, debes usar la clase [**TextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) y para añadir una marca de agua de imagen - [**PictureFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame/). [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame/) implementa la interfaz [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) y puede utilizar toda la potencia de la configuración flexible del objeto de forma. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) no es una forma y sus configuraciones son limitadas. Por lo tanto, se aconseja envolver el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) en un objeto [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).

Hay dos formas en que se puede aplicar una marca de agua: a una sola diapositiva y a todas las diapositivas de la presentación. Se utiliza el Maestro de Diapositivas para aplicar la marca de agua a todas las diapositivas de la presentación: la marca de agua se añade al Maestro de Diapositivas, se diseña completamente allí y se aplica a todas las diapositivas sin modificar el permiso para modificar la marca de agua en las diapositivas.

La marca de agua generalmente se considera no disponible para ser editada por otros usuarios. Para prevenir la edición de la marca de agua (o más bien, de la forma principal de la marca de agua), Aspose.Slides proporciona una funcionalidad de bloqueo de forma. Una forma determinada puede ser bloqueada en una diapositiva normal o en un Maestro de Diapositivas. Al bloquear la forma de la marca de agua en un Maestro de Diapositivas, se bloqueará en todas las diapositivas de la presentación.

Puedes establecer el nombre de la marca de agua, para que en el futuro, si deseas eliminar la marca de agua, puedas encontrarla en las formas de la diapositiva por nombre.

Puedes diseñar la marca de agua de cualquier manera, sin embargo, generalmente hay características comunes dentro de las marcas de agua, como: alineación al centro, rotación, posición frontal, etc. A continuación, consideraremos cómo utilizarlas en los ejemplos a continuación.
## **Marca de Agua de Texto**
### **Añadir Marca de Agua de Texto a la Diapositiva**
Para añadir una marca de agua de texto en PPT, PPTX o ODP puedes primero añadir una forma a la diapositiva, luego añadir un marco de texto a esta forma. El marco de texto está representado por el tipo [**TextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame). Este tipo no hereda de [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape), que tiene un amplio conjunto de propiedades para establecer la marca de agua de manera flexible. Por lo tanto, se aconseja envolver el objeto de [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) en un objeto [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape). Para añadir la marca de agua en la forma, utiliza el método [**addTextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-) con el texto de la marca de agua pasado en él:

```php
  # Abrir presentación
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 0, 0, 0, 0);
    $watermarkTextFrame = $watermarkShape->addTextFrame("Marca de agua");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```



{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/php-java/slide-master/)[TextFrame](/slides/es/php-java/adding-and-formatting-text/)
{{% /alert %}}

### **Añadir Marca de Agua de Texto a la Presentación**
Si deseas añadir una marca de agua en la presentación (es decir, en todas las diapositivas a la vez), añádela al [**MasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide).
Toda la lógica es la misma que al añadir la marca de agua a una sola diapositiva: crea un objeto [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) y luego añade la marca de agua en él con el método [**addTextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-):

```php
  # Abrir presentación
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $watermarkShape = $master->getShapes()->addAutoShape(ShapeType::Triangle, 0, 0, 0, 0);
    $watermarkTextFrame = $watermarkShape->addTextFrame("Marca de agua");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/php-java/slide-master/)[Maestro de Diapositivas](/slides/es/php-java/slide-master/)
{{% /alert %}}

### **Establecer Fuente de la Marca de Agua de Texto**
Puedes cambiar la fuente de la marca de agua de texto:

```php
  $watermarkPortion = $watermarkTextFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
  $watermarkPortion->getPortionFormat()->setFontBold(NullableBool::True);
  $watermarkPortion->getPortionFormat()->setFontHeight(52);

```


### **Establecer Transparencia de la Marca de Agua de Texto**
Para establecer la transparencia de la marca de agua de texto, utiliza este código:

```php
  $alpha = 150;
  $red = 200;
  $green = 200;
  $blue = 200;
  $watermarkPortion = $watermarkTextFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
  $watermarkPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $watermarkPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", $red, $green, $blue, $alpha));

```


### **Centrar Marca de Agua de Texto**
Es posible centrar la marca de agua en una diapositiva y para eso puedes hacer lo siguiente:



```php
  $center = new Point2DFloat($pres->getSlideSize()->getSize()->getWidth() / 2, $pres->getSlideSize()->getSize()->getHeight() / 2);
  $width = 300;
  $height = 300;
  $x = $center->getX() - $width / 2;
  $y = $center->getY() - $height / 2;
  # ...
  $watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, $x, $y, $width, $height);

```


## **Marca de Agua de Imagen**
### **Añadir Marca de Agua de Imagen a la Presentación**
Para añadir una marca de agua de imagen a todas las diapositivas de la presentación, puedes hacer lo siguiente:

```php
  $picture;
  $image = Images->fromFile("watermark.png");
  try {
    $picture = $pres->getImages()->addImage($image);
  } finally {
    if (!java_is_null($image)) {
      $image->dispose();
    }
  }
  # ...
  $watermarkShape->getFillFormat()->setFillType(FillType::Picture);
  $watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
  $watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);

```




## **Bloquear Marca de Agua de la Edición**
Si es necesario prevenir la edición de la marca de agua, usa el método [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape#getShapeLock--) en la forma que la envuelve. Con este método, puedes proteger la forma de selección, redimensionar, cambiar de posición, agruparla con otros elementos, bloquear su texto de la edición y muchas otras:

```php
  # Bloquear Formas para modificar
  $watermarkShape->getShapeLock()->setSelectLocked(true);
  $watermarkShape->getShapeLock()->setSizeLocked(true);
  $watermarkShape->getShapeLock()->setTextLocked(true);
  $watermarkShape->getShapeLock()->setPositionLocked(true);
  $watermarkShape->getShapeLock()->setGroupingLocked(true);

```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo Bloquear Formas de la Edición](/slides/es/php-java/presentation-locking/)
{{% /alert %}}

## **Traer Marca de Agua al Frente**
En Aspose.Slides, el Z-Order de las formas puede configurarse a través del método [**SlideCollection.reorder**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#reorder-int-com.aspose.slides.ISlide...-). Para eso, debes llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta manera es posible poner la forma al frente o atrás de la diapositiva. Esta función es especialmente útil si necesitas colocar la marca de agua al frente de la presentación:

```php
  $slide->getShapes()->reorder($slide->getShapes()->size() - 1, $watermarkShape);

```


## **Establecer Rotación de la Marca de Agua**
Aquí hay un ejemplo de cómo establecer la rotación de la marca de agua (y su forma madre):

```php
  $h = $pres->getSlideSize()->getSize()->getHeight();
  $w = $pres->getSlideSize()->getSize()->getWidth();
  $watermarkShape->setX($w - $watermarkShape->getWidth() / 2);
  $watermarkShape->setY($h - $watermarkShape->getHeight() / 2);
  $watermarkShape->setRotation(calculateRotation($h, $w));

```

```php

```


## **Establecer Nombre a la Marca de Agua**
Aspose.Slides permite establecer el nombre de la forma. Por el nombre de la forma puedes acceder a ella en el futuro para modificar o eliminar. Para establecer el nombre de la forma madre de la marca de agua, colócalo en el método [**AutoShape.getName**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getName--) :



```php
  $watermarkShape->setName("marca de agua");

```


## **Eliminar Marca de Agua**
Para eliminar la forma de marca de agua y sus controles secundarios de la diapositiva, usa el método [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getName--) para encontrarla en las formas de la diapositiva. Luego pasa la forma de marca de agua al método [**ShapeCollection.remove**](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeCollection#remove-com.aspose.slides.IShape-) :

```php
  for($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
    $shape = $slide->getShapes()->get_Item($i);
    if ("marca de agua"->equals($shape->getName())) {
      $slide->getShapes()->remove($watermarkShape);
    }
  }
```


## **Ejemplo en Vivo**
Puedes querer probar **Aspose.Slides** **gratis** [**Añadir Marca de Agua** ](https://products.aspose.app/slides/watermark) y [**Eliminar Marca de Agua**](https://products.aspose.app/slides/watermark/remove-watermark) herramientas en línea.

![todo:image_alt_text](slides-watermark.png)