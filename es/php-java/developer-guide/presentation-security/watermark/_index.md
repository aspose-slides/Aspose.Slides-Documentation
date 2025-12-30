---
title: Añadir marcas de agua a presentaciones en PHP
linktitle: Marca de agua
type: docs
weight: 40
url: /es/php-java/watermark/
keywords:
- marca de agua
- marca de agua de texto
- marca de agua de imagen
- añadir marca de agua
- cambiar marca de agua
- eliminar marca de agua
- borrar marca de agua
- añadir marca de agua a PPT
- añadir marca de agua a PPTX
- añadir marca de agua a ODP
- eliminar marca de agua de PPT
- eliminar marca de agua de PPTX
- eliminar marca de agua de ODP
- borrar marca de agua de PPT
- borrar marca de agua de PPTX
- borrar marca de agua de ODP
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Gestione marcas de agua de texto e imagen en presentaciones PowerPoint y OpenDocument en PHP para indicar un borrador, información confidencial, derechos de autor y más."
---

## **Acerca de las marcas de agua**

**Una marca de agua** en una presentación es un sello de texto o imagen que se usa en una diapositiva o en todas las diapositivas de la presentación. Normalmente, una marca de agua se utiliza para indicar que la presentación es un borrador (p. ej., una marca de agua “Borrador”), que contiene información confidencial (p. ej., una marca de agua “Confidencial”), para especificar a qué empresa pertenece (p. ej., una marca de agua “Nombre de la empresa”), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir infracciones de derechos de autor al indicar que la presentación no debe copiarse. Las marcas de agua se usan tanto en formatos de presentación PowerPoint como OpenOffice. En Aspose.Slides, puedes añadir una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/php-java/), existen varias formas de crear marcas de agua en documentos PowerPoint u OpenOffice y de modificar su diseño y comportamiento. El aspecto común es que, para añadir marcas de agua de texto, debes usar la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), y para añadir marcas de agua de imagen, usar la clase [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) o rellenar una forma de marca de agua con una imagen. `PictureFrame` implementa la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), lo que permite usar todas las configuraciones flexibles del objeto forma. Como `ITextFrame` no es una forma y sus configuraciones son limitadas, se envuelve en un objeto [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Hay dos formas de aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El Slide Master se usa para aplicar una marca de agua a todas las diapositivas: la marca de agua se añade al Slide Master, se diseña allí completamente y se aplica a todas las diapositivas sin afectar el permiso de modificar la marca de agua en diapositivas individuales.

Una marca de agua suele considerarse no disponible para edición por otros usuarios. Para evitar que la marca de agua (o más concretamente la forma que la contiene) sea editada, Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una forma específica puede bloquearse en una diapositiva normal o en un Slide Master. Cuando la forma de la marca de agua está bloqueada en el Slide Master, estará bloqueada en todas las diapositivas de la presentación.

Puedes asignar un nombre a la marca de agua para que, en el futuro, si deseas eliminarla, puedas encontrarla entre las formas de la diapositiva por nombre.

Puedes diseñar la marca de agua de cualquier manera; sin embargo, suelen existir características comunes en las marcas de agua, como alineación centrada, rotación, posición frontal, etc. Consideraremos cómo usar estas características en los ejemplos a continuación.

## **Marca de agua de texto**

### **Añadir una marca de agua de texto a una diapositiva**

Para añadir una marca de agua de texto en PPT, PPTX o ODP, puedes primero añadir una forma a la diapositiva y luego agregar un marco de texto a esa forma. El marco de texto está representado por la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). Este tipo no hereda de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), que posee un amplio conjunto de propiedades para posicionar la marca de agua de forma flexible. Por ello, el objeto [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) se envuelve en un objeto [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Para añadir texto de marca de agua a la forma, usa el método [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) como se muestra a continuación.
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar la clase TextFrame](/slides/es/php-java/text-formatting/)
{{% /alert %}}

### **Añadir una marca de agua de texto a una presentación**

Si deseas añadir una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), añádela al [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). El resto de la lógica es idéntico al de añadir una marca de agua a una sola diapositiva: crea un objeto [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) y luego añade la marca de agua mediante el método [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame).
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar el Slide Master](/slides/es/php-java/slide-master/)
{{% /alert %}}

### **Establecer la transparencia de la forma de la marca de agua**

Por defecto, la forma rectangular tiene colores de relleno y de línea. Las siguientes líneas de código hacen que la forma sea transparente.
```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```


### **Establecer la fuente de una marca de agua de texto**

Puedes cambiar la fuente de la marca de agua de texto como se muestra a continuación.
```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```


### **Establecer el color del texto de la marca de agua**

Para establecer el color del texto de la marca de agua, usa este código:
```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```


### **Centrar una marca de agua de texto**

Es posible centrar la marca de agua en una diapositiva; para ello, puedes hacer lo siguiente:
```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```


La imagen siguiente muestra el resultado final.

![The text watermark](text_watermark.png)

## **Marca de agua de imagen**

### **Añadir una marca de agua de imagen a una presentación**

Para añadir una marca de agua de imagen a una diapositiva de la presentación, puedes hacer lo siguiente:
```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```


### **Bloquear una marca de agua para que no se edite**

Si es necesario impedir que una marca de agua sea editada, usa el método [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) sobre la forma. Con esta propiedad, puedes proteger la forma contra la selección, el cambio de tamaño, el reposicionamiento, la agrupación con otros elementos, bloquear su texto de la edición y mucho más:
```php
// Bloquear la forma de la marca de agua para que no se modifique
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```


### **Traer una marca de agua al frente**

En Aspose.Slides, el orden Z de las formas puede establecerse mediante el método [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder). Para ello, debes invocar este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De este modo, es posible llevar una forma al frente o enviarla al fondo de la diapositiva. Esta función es especialmente útil si necesitas colocar una marca de agua delante del contenido de la presentación:
```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```


### **Establecer la rotación de la marca de agua**

A continuación se muestra un ejemplo de código que ajusta la rotación de la marca de agua para que quede posicionada diagonalmente a través de la diapositiva:
```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```


### **Asignar un nombre a una marca de agua**

Aspose.Slides permite establecer el nombre de una forma. Mediante el nombre de la forma, puedes acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de la marca de agua, asígnalo al método [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName):
```php
$watermarkShape->setName("watermark");
```


### **Eliminar una marca de agua**

Para eliminar la forma de la marca de agua, usa el método [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) para encontrarla entre las formas de la diapositiva. Luego, pasa la forma de la marca de agua al método [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove):
```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```


## **FAQ**

**¿Qué es una marca de agua y por qué debería usarla?**

Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, a reforzar el reconocimiento de marca o a impedir el uso no autorizado de presentaciones.

**¿Puedo añadir una marca de agua a todas las diapositivas de una presentación?**

Sí, Aspose.Slides permite añadir programáticamente una marca de agua a cada diapositiva de una presentación. Puedes iterar por todas las diapositivas y aplicar la configuración de la marca de agua individualmente.

**¿Cómo puedo ajustar la transparencia de la marca de agua?**

Puedes ajustar la transparencia de la marca de agua modificando la configuración de relleno ([getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getfillformat/)) de la forma. Esto garantiza que la marca de agua sea sutil y no distraiga del contenido de la diapositiva.

**¿Qué formatos de imagen son compatibles para marcas de agua?**

Aspose.Slides admite varios formatos de imagen como PNG, JPEG, GIF, BMP, SVG y otros.

**¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?**

Sí, puedes elegir cualquier fuente, tamaño y estilo para que coincidan con el diseño de tu presentación y mantengan la coherencia de la marca.

**¿Cómo cambio la posición o la orientación de una marca de agua?**

Puedes ajustar la posición y la orientación de la marca de agua programáticamente modificando las coordenadas, el tamaño y las propiedades de rotación de la forma.