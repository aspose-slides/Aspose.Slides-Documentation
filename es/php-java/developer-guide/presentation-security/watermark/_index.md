---
title: Marca de Agua
type: docs
weight: 40
url: /php-java/watermark/
keywords:
- marca de agua
- agregar marca de agua
- marca de agua de texto
- marca de agua de imagen
- PowerPoint
- presentación
- PHP
- Java
- Aspose.Slides para PHP a través de Java
description: "Agregue marcas de agua de texto e imagen a presentaciones de PowerPoint en PHP"
---

## **Acerca de las Marcas de Agua**

**Una marca de agua** en una presentación es un sello de texto o imagen utilizado en una diapositiva o en todas las diapositivas de la presentación. Por lo general, se utiliza una marca de agua para indicar que la presentación es un borrador (por ejemplo, una marca de agua de "Borrador"), que contiene información confidencial (por ejemplo, una marca de agua de "Confidencial"), para especificar a qué empresa pertenece (por ejemplo, una marca de agua de "Nombre de la Empresa"), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe ser copiada. Las marcas de agua se utilizan tanto en formatos de presentación de PowerPoint como de OpenOffice. En Aspose.Slides, puedes agregar una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/php-java/), hay varias maneras de crear marcas de agua en documentos de PowerPoint u OpenOffice y modificar su diseño y comportamiento. El aspecto común es que para agregar marcas de agua de texto, debes usar la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), y para agregar marcas de agua de imagen, usa la clase [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) o llena una forma de marca de agua con una imagen. `PictureFrame` implementa la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), permitiéndote usar todos los ajustes flexibles del objeto de forma. Dado que `ITextFrame` no es una forma y sus ajustes son limitados, se envuelve en un objeto [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Hay dos formas en que se puede aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El patrón de diapositivas se utiliza para aplicar una marca de agua a todas las diapositivas de la presentación: la marca de agua se agrega al patrón de la diapositiva, se diseña completamente allí y se aplica a todas las diapositivas sin afectar la permisividad de modificar la marca de agua en diapositivas individuales.

Se considera que una marca de agua no está disponible para su edición por otros usuarios. Para prevenir que la marca de agua (o más bien la forma que la contiene) sea editada, Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una forma específica se puede bloquear en una diapositiva normal o en un patrón de diapositivas. Cuando la forma de marca de agua está bloqueada en el patrón de diapositivas, estará bloqueada en todas las diapositivas de la presentación.

Puedes establecer un nombre para la marca de agua de modo que en el futuro, si deseas eliminarla, puedas encontrarla en las formas de la diapositiva por su nombre.

Puedes diseñar la marca de agua de la manera que desees; sin embargo, generalmente hay características comunes en las marcas de agua, como alineación centrada, rotación, posición frontal, etc. Consideraremos cómo usar estas características en los ejemplos a continuación.

## **Marca de Agua de Texto**

### **Agregar una Marca de Agua de Texto a una Diapositiva**

Para agregar una marca de agua de texto en PPT, PPTX u ODP, primero puedes agregar una forma a la diapositiva, luego agregar un marco de texto a esta forma. El marco de texto está representado por la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). Este tipo no se hereda de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), que tiene un amplio conjunto de propiedades para posicionar la marca de agua de manera flexible. Por lo tanto, el objeto [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) se envuelve en un objeto [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Para agregar texto de marca de agua a la forma, utiliza el método [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) como se muestra a continuación.

```php
$watermarkText = "CONFIDENCIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar la clase TextFrame](/slides/php-java/text-formatting/)
{{% /alert %}}

### **Agregar una Marca de Agua de Texto a una Presentación**

Si deseas agregar una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agrégala al [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). El resto de la lógica es la misma que cuando agregas una marca de agua a una sola diapositiva: crea un objeto [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) y luego agrega la marca de agua a él usando el método [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENCIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar el Patrón de Diapositivas](/slides/php-java/slide-master/)
{{% /alert %}}

### **Establecer la Transparencia de la Forma de Marca de Agua**

Por defecto, la forma rectángulo tiene estilo con colores de relleno y línea. Las siguientes líneas de código hacen que la forma sea transparente.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Establecer la Fuente para una Marca de Agua de Texto**

Puedes cambiar la fuente de la marca de agua de texto como se muestra a continuación.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Establecer el Color del Texto de la Marca de Agua**

Para establecer el color del texto de la marca de agua, utiliza este código:

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

### **Centrar una Marca de Agua de Texto**

Es posible centrar la marca de agua en una diapositiva, y para eso, puedes hacer lo siguiente:

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

La imagen a continuación muestra el resultado final.

![La marca de agua de texto](text_watermark.png)

## **Marca de Agua de Imagen**

### **Agregar una Marca de Agua de Imagen a una Presentación**

Para agregar una marca de agua de imagen a una diapositiva de presentación, puedes hacer lo siguiente:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

## **Bloquear una Marca de Agua para Evitar Edición**

Si es necesario prevenir que una marca de agua sea editada, utiliza el método [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) en la forma. Con esta propiedad, puedes proteger la forma de ser seleccionada, redimensionada, reposicionada, agrupada con otros elementos, bloquear su texto de ser editado, y mucho más:

```php
// Bloquear la forma de marca de agua para modificar
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

## **Traer una Marca de Agua al Frente**

En Aspose.Slides, el orden Z de las formas se puede establecer a través del método [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder). Para hacer esto, necesitas llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta forma, es posible traer una forma al frente o enviarla al fondo de la diapositiva. Esta característica es especialmente útil si necesitas colocar una marca de agua frente a la presentación:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

## **Establecer la Rotación de la Marca de Agua**

Aquí hay un ejemplo de código sobre cómo ajustar la rotación de la marca de agua para que esté posicionada diagonalmente a través de la diapositiva:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

## **Establecer un Nombre para una Marca de Agua**

Aspose.Slides te permite establecer el nombre de una forma. Al usar el nombre de la forma, puedes acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de marca de agua, asígnalo al método [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("marca de agua");
```

## **Eliminar una Marca de Agua**

Para eliminar la forma de marca de agua, utiliza el método [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) para encontrarla en las formas de la diapositiva. Luego, pasa la forma de marca de agua al método [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "marca de agua") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **Un Ejemplo en Vivo**

Es posible que quieras consultar los **herramientas en línea gratuitas de Aspose.Slides** [Agregar Marca de Agua](https://products.aspose.app/slides/watermark) y [Eliminar Marca de Agua](https://products.aspose.app/slides/watermark/remove-watermark).

![Herramientas en línea para agregar y eliminar marcas de agua](online_tools.png)