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
description: "Aprenda cómo crear, dar formato y manipular formas de elipse en Aspose.Slides para PHP mediante Java en presentaciones PPT y PPTX — se incluyen ejemplos de código."
---

{{% alert color="primary" %}} 

En este tema, presentaremos a los desarrolladores cómo añadir formas de elipse a sus diapositivas usando Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java ofrece un conjunto de API más sencillo para dibujar diferentes tipos de formas con solo unas pocas líneas de código.

{{% /alert %}} 

## **Crear una elipse**
Para añadir una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada un AutoShape de tipo Elipse usando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
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
    # Guardar el archivo PPTX en disco
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Crear una elipse con formato**
Para añadir una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada un AutoShape de tipo Elipse usando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Establezca el tipo de relleno de la elipse a Sólido.
- Establezca el color de la elipse usando el método `SolidFillColor::setColor` expuesto por el objeto [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) asociado al objeto [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).
- Establezca el color de las líneas de la elipse.
- Establezca el ancho de las líneas de la elipse.
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una elipse con formato a la primera diapositiva de la presentación.
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir AutoShape de tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Aplicar algo de formato a la forma elipse
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

Las coordenadas y tamaños se especifican normalmente **en puntos**. Para obtener resultados predecibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas requeridos a puntos antes de asignar valores.

**¿Cómo puedo colocar una elipse por encima o por debajo de otros objetos (controlar el orden de apilamiento)?**

Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están debajo.

**¿Cómo animo la aparición o énfasis de una elipse?**

[Apply](/slides/es/php-java/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure disparadores y temporizaciones para orquestar cuándo y cómo se reproduce la animación.