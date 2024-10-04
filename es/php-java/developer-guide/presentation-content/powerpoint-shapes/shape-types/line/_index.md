---
title: Línea
type: docs
weight: 50
url: /es/php-java/Línea/
---


{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java admite agregar diferentes tipos de formas a las diapositivas. En este tema, comenzaremos a trabajar con formas agregando líneas a las diapositivas. Usando Aspose.Slides para PHP a través de Java, los desarrolladores no solo pueden crear líneas simples, sino que también se pueden dibujar algunas líneas elegantes en las diapositivas.

{{% /alert %}} 

## **Crear Línea Simple**

Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una AutoShape de tipo Línea utilizando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Escriba la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

```php
  # Instanciar la clase PresentationEx que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar una AutoShape de tipo línea
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Escribir el PPTX en el disco
    $pres->save("LíneaShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Crear Línea en Forma de Flecha**

Aspose.Slides para PHP a través de Java también permite a los desarrolladores configurar algunas propiedades de la línea para que se vea más atractiva. Intentemos configurar algunas propiedades de una línea para que se parezca a una flecha. Siga los pasos a continuación para hacerlo:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una AutoShape de tipo Línea utilizando el método [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Establezca el [Estilo de Línea](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) en uno de los estilos ofrecidos por Aspose.Slides para PHP a través de Java.
- Establezca el ancho de la línea.
- Establezca el [Estilo de Trazo](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) de la línea en uno de los estilos ofrecidos por Aspose.Slides para PHP a través de Java.
- Establezca el [Estilo de Cabeza de Flecha](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) y [Longitud](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) del punto de inicio de la línea.
- Establezca el [Estilo de Cabeza de Flecha](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) y [Longitud](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) del punto final de la línea.
- Escriba la presentación modificada como un archivo PPTX.

```php
  # Instanciar la clase PresentationEx que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar una AutoShape de tipo línea
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Aplicar algún formato a la línea
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Escribir el PPTX en el disco
    $pres->save("LíneaShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```