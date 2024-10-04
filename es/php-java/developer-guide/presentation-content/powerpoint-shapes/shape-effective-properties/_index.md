---
title: Propiedades Efectivas de Forma
type: docs
weight: 50
url: /php-java/shape-effective-properties/
---

En este tema, discutiremos las propiedades **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En las propiedades de la porción en la diapositiva de la porción;
1. En el estilo de texto de forma prototipo en la diapositiva de diseño o máster (si la forma del marco de texto de la porción tiene uno);
1. En la configuración de texto global de la presentación;

esos valores se denominan valores **locales**. En cualquier nivel, los valores **locales** pueden definirse u omitirse. Pero cuando una aplicación necesita saber cómo debería lucir la porción, utiliza los valores **efectivos**. Puedes obtener los valores efectivos utilizando el método **getEffective()** desde el formato local.

Este código de ejemplo muestra cómo obtener valores efectivos:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat::getEffective();
    $localPortionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat::getEffective();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obteniendo Propiedades Efectivas de la Cámara**
Aspose.Slides para PHP a través de Java permite a los desarrolladores obtener propiedades efectivas de la cámara. Para este propósito, se añadió la interfaz [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) a Aspose.Slides. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de la interfaz [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) se utiliza como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Este código de ejemplo muestra cómo obtener propiedades efectivas para la cámara:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Propiedades efectivas de la cámara =");
    echo("Tipo: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Campo de visión: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obteniendo Propiedades Efectivas de Light Rig**
Aspose.Slides para PHP a través de Java permite a los desarrolladores obtener propiedades efectivas de Light Rig. Para este propósito, se añadió la interfaz [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) a Aspose.Slides. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de Light Rig. Una instancia de la interfaz [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) se utiliza como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Este código de ejemplo muestra cómo obtener propiedades efectivas de Light Rig:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Propiedades efectivas de light rig =");
    echo("Tipo: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Dirección: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obteniendo Propiedades Efectivas de la Forma Biselada**
Aspose.Slides para PHP a través de Java permite a los desarrolladores obtener propiedades efectivas de la forma biselada. Para este propósito, se añadió la interfaz [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) a Aspose.Slides. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de relieve de la cara de la forma. Una instancia de la interfaz [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) se utiliza como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Este código de ejemplo muestra cómo obtener propiedades efectivas para la forma biselada:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Propiedades efectivas del relieve de la cara superior de la forma =");
    echo("Tipo: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Ancho: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Altura: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obteniendo Propiedades Efectivas de un Marco de Texto**
Usando Aspose.Slides para PHP a través de Java, puedes obtener propiedades efectivas de un marco de texto. Para este propósito, se añadió la interfaz [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) a Aspose.Slides. Contiene propiedades efectivas de formato de marco de texto.

Este código de ejemplo muestra cómo obtener propiedades de formato de marco de texto efectivas:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Tipo de anclaje: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Tipo de ajuste automático: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Tipo de texto vertical: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Márgenes");
    echo("   Izquierda: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Superior: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Derecha: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Inferior: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obteniendo Propiedades Efectivas de un Estilo de Texto**
Usando Aspose.Slides para PHP a través de Java, puedes obtener propiedades efectivas de un estilo de texto. Para este propósito, se añadió la interfaz [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) a Aspose.Slides. Contiene propiedades efectivas del estilo de texto.

Este código de ejemplo muestra cómo obtener propiedades de estilo de texto efectivas:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Formato de párrafo efectivo para el nivel de estilo #" . $i . " =");
      echo("Profundidad: " . $effectiveStyleLevel->getDepth());
      echo("Sangría: " . $effectiveStyleLevel->getIndent());
      echo("Alineación: " . $effectiveStyleLevel->getAlignment());
      echo("Alineación de fuente: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obteniendo el Valor Efectivo de Altura de Fuente**
Usando Aspose.Slides para PHP a través de Java, puedes obtener propiedades efectivas de altura de fuente. Aquí, proporcionamos un código que muestra cómo cambia el valor efectivo de altura de fuente de la porción después de que se establecen valores de altura de fuente locales en diferentes niveles de la estructura de presentación:

```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Texto de muestra con la primera porción");
    $portion1 = new Portion(" y la segunda porción.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Altura de fuente efectiva justo después de la creación:");
    echo("Porción #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Porción #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Altura de fuente efectiva después de establecer la altura de fuente predeterminada de la presentación completa:");
    echo("Porción #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Porción #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Altura de fuente efectiva después de establecer la altura de fuente predeterminada del párrafo:");
    echo("Porción #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Porción #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Altura de fuente efectiva después de establecer la altura de fuente de la porción #0:");
    echo("Porción #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Porción #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Altura de fuente efectiva después de establecer la altura de fuente de la porción #1:");
    echo("Porción #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Porción #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obteniendo el Formato Efectivo de Relleno para la Tabla**
Usando Aspose.Slides para PHP a través de Java, puedes obtener el formato de relleno efectivo para diferentes partes lógicas de la tabla. Para este propósito, se añadió la interfaz [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) en Aspose.Slides. Contiene propiedades efectivas de formato de relleno. Ten en cuenta esto: el formato de celda siempre tiene prioridad sobre el formato de fila; la fila tiene prioridad sobre la columna; y la columna tiene prioridad sobre toda la tabla.

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $tableFormatEffective = $tbl->getTableFormat()->getEffective();
    $rowFormatEffective = $tbl->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnFormatEffective = $tbl->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellFormatEffective = $tbl->get_Item(0, 0)->getCellFormat()->getEffective();
    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```