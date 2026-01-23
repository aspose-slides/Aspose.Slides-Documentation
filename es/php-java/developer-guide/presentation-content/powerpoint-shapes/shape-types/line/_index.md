---
title: Añadir formas de línea a presentaciones en PHP
linktitle: Línea
type: docs
weight: 50
url: /es/php-java/Line/
keywords:
- línea
- crear línea
- añadir línea
- línea simple
- configurar línea
- personalizar línea
- estilo de guión
- cabeza de flecha
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a manipular el formato de líneas en presentaciones de PowerPoint con Aspose.Slides para PHP a través de Java. Descubra propiedades, métodos y ejemplos."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java admite la incorporación de diferentes tipos de formas a las diapositivas. En este tema, comenzaremos a trabajar con formas añadiendo líneas a las diapositivas. Con Aspose.Slides for PHP via Java, los desarrolladores no solo pueden crear líneas simples, sino que también pueden dibujar algunas líneas elegantes en las diapositivas.

{{% /alert %}} 

## **Crear una línea simple**

Para añadir una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Añada una AutoShape del tipo Línea mediante el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido una línea a la primera diapositiva de la presentación.
```php
  # Instanciar la clase PresentationEx que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar una AutoShape de tipo línea
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Grabar el PPTX en disco
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Crear una línea con forma de flecha**

Aspose.Slides for PHP via Java también permite a los desarrolladores configurar algunas propiedades de la línea para que resulte más atractiva. Intentemos configurar algunas propiedades de una línea para que tenga forma de flecha. Siga los pasos a continuación para lograrlo:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Añada una AutoShape del tipo Línea mediante el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Establezca el [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) a uno de los estilos ofrecidos por Aspose.Slides for PHP via Java.
- Establezca el ancho de la línea.
- Establezca el [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides for PHP via Java.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) y la [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) del punto de inicio de la línea.
- Establezca el [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) y la [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) del punto final de la línea.
- Guarde la presentación modificada como un archivo PPTX.
```php
  # Instanciar la clase PresentationEx que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir una AutoShape de tipo línea
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Aplicar algo de formato a la línea
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Guardar el PPTX en disco
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo convertir una línea normal en un conector para que se "ajuste" a las formas?**

No. Una línea normal (una [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, utilice el tipo [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) dedicado y las [APIs correspondientes](/slides/es/php-java/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y es difícil determinar los valores finales?**

[Lea las propiedades efectivas](/slides/es/php-java/shape-effective-properties/) a través de `LineFormatEffectiveData`/`LineFillFormatEffectiveData`—estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea para que no se pueda editar (mover, redimensionar)?**

Sí. Las formas proporcionan [lock objects](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/) que le permiten impedir operaciones de edición.