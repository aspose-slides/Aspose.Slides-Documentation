---
title: Añadir rectángulos a presentaciones en PHP
linktitle: Rectángulo
type: docs
weight: 80
url: /es/php-java/rectangle/
keywords:
- añadir rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo simple
- rectángulo con formato
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Mejora tus presentaciones de PowerPoint añadiendo rectángulos con Aspose.Slides para PHP a través de Java — diseña y modifica formas de forma programada fácilmente."
---

{{% alert color="primary" %}} 

Al igual que los temas anteriores, este también trata sobre añadir una forma y, en esta ocasión, la forma que discutiremos es **Rectángulo**. En este tema, hemos descrito cómo los desarrolladores pueden añadir rectángulos simples o con formato a sus diapositivas utilizando Aspose.Slides para PHP a través de Java.

{{% /alert %}} 

## **Agregar un rectángulo a una diapositiva**
Para añadir un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Añada un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de tipo Rectángulo mediante el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Guarde la presentación modificada como archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un rectángulo simple a la primera diapositiva de la presentación.
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir AutoShape de tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Escribir el archivo PPTX en disco
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Agregar un rectángulo con formato a una diapositiva**
Para añadir un rectángulo con formato a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Añada un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de tipo Rectángulo mediante el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Establezca el [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) del rectángulo en Solid.
- Defina el color del rectángulo mediante el método [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) expuesto por el objeto [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) asociado al objeto [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Establezca el color de las líneas del rectángulo.
- Defina el ancho de las líneas del rectángulo.
- Guarde la presentación modificada como archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir AutoShape de tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Aplicar algo de formato a la forma elipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Aplicar algo de formato a la línea de la elipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Guardar el archivo PPTX en disco
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Cómo añado un rectángulo con esquinas redondeadas?**

Utilice el tipo de forma de esquina redondeada y ajuste el radio de la esquina en las propiedades de la forma; también puede aplicar redondeo por esquina mediante ajustes de geometría.

**¿Cómo lleno un rectángulo con una imagen (textura)?**

Seleccione el [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) de tipo picture, proporcione la fuente de la imagen y configure los [modos de estirado/teselado](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/).

**¿Puede un rectángulo tener sombra y resplandor?**

Sí. [Sombra exterior/interior, resplandor y bordes suaves](/slides/es/php-java/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con un hipervínculo?**

Sí. [Asigne un hipervínculo](/slides/es/php-java/manage-hyperlinks/) a la forma al hacer clic (para ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo contra movimientos y cambios?**

[Utilice bloqueos de forma](/slides/es/php-java/applying-protection-to-presentation/): puede prohibir mover, cambiar el tamaño, seleccionar o editar texto para preservar el diseño.

**¿Puedo convertir un rectángulo a una imagen raster o SVG?**

Sí. Puede [renderizar la forma](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) a una imagen con un tamaño/escala especificados o [exportarla como SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectángulo considerando el tema y la herencia?**

[Utilice las propiedades efectivas de la forma](/slides/es/php-java/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos del tema, la disposición y la configuración local, simplificando el análisis de formato.