---
title: Elipse
type: docs
weight: 30
url: /es/php-java/ellipse/
---


{{% alert color="primary" %}} 

En este tema, presentamos a los desarrolladores cómo agregar formas de elipse a sus diapositivas utilizando Aspose.Slides para PHP a través de Java. Aspose.Slides para PHP a través de Java proporciona un conjunto más fácil de API para dibujar diferentes tipos de formas con solo unas pocas líneas de código.

{{% /alert %}} 

## **Crear Elipse**
Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una AutoShape de tipo Elipse utilizando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Escriba la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una elipse a la primera diapositiva.

```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar AutoShape de tipo elipse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Escribir el archivo PPTX en el disco
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Crear Elipse Formateada**
Para agregar una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una AutoShape de tipo Elipse utilizando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Establezca el tipo de relleno de la elipse como sólido.
- Establezca el color de la elipse utilizando la propiedad SolidFillColor.Color expuesta por el objeto [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) asociado con el objeto [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Establezca el color de las líneas de la elipse.
- Establezca el ancho de las líneas de la elipse.
- Escriba la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una elipse formateada a la primera diapositiva de la presentación.

```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar AutoShape de tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Aplicar algo de formato a la forma de la elipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Aplicar algo de formato a la línea de la elipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Escribir el archivo PPTX en el disco
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```