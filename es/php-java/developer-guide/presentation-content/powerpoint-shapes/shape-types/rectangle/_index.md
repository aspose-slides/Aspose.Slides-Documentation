---
title: Rectángulo
type: docs
weight: 80
url: /php-java/rectangle/
---

{{% alert color="primary" %}} 

Al igual que los temas anteriores, este también trata sobre la adición de una forma, y esta vez la forma de la que discutiremos es **Rectángulo**. En este tema, hemos descrito cómo los desarrolladores pueden agregar rectángulos simples o formateados a sus diapositivas utilizando Aspose.Slides para PHP a través de Java.

{{% /alert %}} 

## **Agregar Rectángulo a la Diapositiva**
Para agregar un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de tipo Rectángulo utilizando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Escriba la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado un rectángulo simple a la primera diapositiva de la presentación.

```php
  # Instanciar la clase Prseetation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir AutoShape de tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Escribir el archivo PPTX en el disco
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Agregar Rectángulo Formateado a la Diapositiva**
Para agregar un rectángulo formateado a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de tipo Rectángulo utilizando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Establezca el [Tipo de Relleno](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) del Rectángulo en Sólido.
- Establezca el Color del Rectángulo utilizando el método [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) expuesto por el objeto [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) asociado con el objeto [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Establezca el Color de las líneas del Rectángulo.
- Establezca el Ancho de las líneas del Rectángulo.
- Escriba la presentación modificada como un archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.

```php
  # Instanciar la clase Prseetation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir AutoShape de tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Aplicar algún formato a la forma de elipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Aplicar algún formato a la línea de la Elipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Escribir el archivo PPTX en el disco
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```