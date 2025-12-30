---
title: Añadir elipses a presentaciones en PHP
linktitle: Elipse
type: docs
weight: 30
url: /es/php-java/ellipse/
keywords:
- elipse
- forma
- añadir elipse
- crear elipse
- dibujar elipse
- elipse con formato
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a crear, formatear y manipular formas de elipse en Aspose.Slides para PHP a través de Java en presentaciones PPT y PPTX — con ejemplos de código incluidos."
---

{{% alert color="primary" %}} 

En este tema, presentaremos a los desarrolladores cómo añadir formas de elipse a sus diapositivas mediante Aspose.Slides para PHP a través de Java. Aspose.Slides para PHP a través de Java ofrece un conjunto más sencillo de API para dibujar diferentes tipos de formas con solo unas pocas líneas de código.

{{% /alert %}} 

## **Crear una elipse**
Para añadir una elipse sencilla a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Añada un AutoShape de tipo Elipse usando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una elipse a la primera diapositiva
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir AutoShape de tipo elipse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Escribir el archivo PPTX en disco
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Crear una elipse formateada**
Para añadir una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Añada un AutoShape de tipo Elipse usando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Establezca el Tipo de Relleno de la Elipse a Sólido.
- Establezca el Color de la Elipse usando la propiedad SolidFillColor.Color expuesta por el objeto [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) asociado al objeto [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Establezca el Color de las líneas de la Elipse.
- Establezca el Ancho de las líneas de la Elipse.
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una elipse formateada a la primera diapositiva de la presentación.
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir AutoShape de tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Aplicar algo de formato a la forma de la elipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Aplicar algo de formato a la línea de la elipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Guardar el archivo PPTX en disco
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Cómo establezco la posición exacta y el tamaño de una elipse respecto a las unidades de la diapositiva?**

Las coordenadas y los tamaños suelen especificarse **en puntos**. Para obtener resultados previsibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas requeridos a puntos antes de asignar los valores.

**¿Cómo puedo colocar una elipse encima o debajo de otros objetos (controlar el orden de apilamiento)?**

Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están debajo.

**¿Cómo animo la aparición o el énfasis de una elipse?**

[Aplicar](/slides/es/php-java/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure disparadores y tiempos para orquestar cuándo y cómo se reproduce la animación.