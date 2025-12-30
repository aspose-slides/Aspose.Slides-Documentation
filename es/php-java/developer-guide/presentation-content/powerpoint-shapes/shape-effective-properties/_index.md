---
title: Obtener propiedades efectivas de forma de presentaciones en PHP
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/php-java/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- rig de luz
- forma con chaflán
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Descubra cómo Aspose.Slides for PHP via Java calcula y aplica propiedades efectivas de forma para una renderización precisa de PowerPoint."
---

En este tema, hablaremos de propiedades **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En propiedades de porción en la diapositiva de la porción;
1. En estilo de texto de forma prototipo en la diapositiva de diseño o maestra (si la forma del marco de texto de la porción tiene una);
1. En la configuración global de texto de la presentación;

esos valores se denominan valores **locales**. En cualquier nivel, los valores **locales** pueden definirse u omitirse. Pero cuando una aplicación necesita saber cómo debería verse la porción, utiliza valores **efectivos**. Puedes obtener valores efectivos usando el método **getEffective()** del formato local.

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


## **Obtener propiedades efectivas de una cámara**
Aspose.Slides for PHP vía Java permite a los desarrolladores obtener propiedades efectivas de la cámara. Para este fin, se agregó la interfaz [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) a Aspose.Slides. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) se usa como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Este código de ejemplo muestra cómo obtener propiedades efectivas de la cámara:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective camera properties =");
    echo("Type: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Field of view: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener propiedades efectivas de un Light Rig**
Aspose.Slides for PHP vía Java permite a los desarrolladores obtener propiedades efectivas de Light Rig. Para este fin, se agregó la interfaz [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) a Aspose.Slides. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de Light Rig. Una instancia de la [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) se usa como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Este código de ejemplo muestra cómo obtener propiedades efectivas de Light Rig:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective light rig properties =");
    echo("Type: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Direction: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener propiedades efectivas de una forma con chaflán**
Aspose.Slides for PHP vía Java permite a los desarrolladores obtener propiedades efectivas de Bevel Shape. Para este fin, se agregó la interfaz [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) a Aspose.Slides. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de relieve de la forma. Una instancia de la [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) se usa como parte de la interfaz [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)) , que es un par de [valores efectivos](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Este código de ejemplo muestra cómo obtener propiedades efectivas de la forma con chaflán:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective shape's top face relief properties =");
    echo("Type: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Width: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Height: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener propiedades efectivas de un marco de texto**
Usando Aspose.Slides for PHP vía Java, puedes obtener propiedades efectivas de un Text Frame. Para este fin, se agregó la interfaz [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) a Aspose.Slides. Contiene propiedades de formato de marco de texto efectivas. 

Este código de ejemplo muestra cómo obtener propiedades de formato de marco de texto efectivos:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Anchoring type: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Autofit type: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Text vertical type: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Margins");
    echo("   Left: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Top: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Right: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Bottom: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener propiedades efectivas de un estilo de texto**
Usando Aspose.Slides for PHP vía Java, puedes obtener propiedades efectivas de Text Style. Para este fin, se agregó la interfaz [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) a Aspose.Slides. Contiene propiedades efectivas de estilo de texto.

Este código de ejemplo muestra cómo obtener propiedades efectivas de estilo de texto:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Effective paragraph formatting for style level #" . $i . " =");
      echo("Depth: " . $effectiveStyleLevel->getDepth());
      echo("Indent: " . $effectiveStyleLevel->getIndent());
      echo("Alignment: " . $effectiveStyleLevel->getAlignment());
      echo("Font alignment: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener el valor efectivo de la altura de fuente**
Usando Aspose.Slides for PHP vía Java, puedes obtener propiedades efectivas de Font Height. Aquí proporcionamos un código que muestra cómo el valor de altura de fuente efectivo de la porción cambia después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación:
```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Sample text with first portion");
    $portion1 = new Portion(" and second portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Effective font height just after creation:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Effective font height after setting entire presentation default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Effective font height after setting paragraph default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Effective font height after setting portion #0 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Effective font height after setting portion #1 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener el formato de relleno efectivo para una tabla**
Usando Aspose.Slides for PHP vía Java, puedes obtener el formato de relleno efectivo para distintas partes lógicas de una tabla. Para este fin, se agregó la interfaz [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) a Aspose.Slides. Contiene propiedades de formato de relleno efectivas. Ten en cuenta lo siguiente: el formato de celda siempre tiene prioridad sobre el formato de fila; la fila tiene prioridad sobre la columna; y la columna tiene prioridad sobre toda la tabla.
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


## **Preguntas frecuentes**

**¿Cómo puedo saber si obtuve una "instantánea" en lugar de un "objeto vivo", y cuándo debo volver a leer las propiedades efectivas?**

Los objetos EffectiveData son instantáneas inmutables de los valores calculados en el momento de la llamada. Si cambias la configuración local o heredada de la forma, vuelve a obtener los datos efectivos para obtener los valores actualizados.

**¿Cambiar la diapositiva de diseño/maestra afecta a las propiedades efectivas que ya se habían obtenido?**

Sí, pero solo después de volver a leerlas. Un objeto EffectiveData ya obtenido no se actualiza por sí mismo; solicita uno nuevo después de cambiar el diseño o la maestra.

**¿Puedo modificar valores a través de EffectiveData?**

No. EffectiveData es de solo lectura. Realiza los cambios en los objetos de formato local (forma/texto/3D, etc.) y luego vuelve a obtener los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**

El valor efectivo se determina mediante el mecanismo predeterminado (valores por defecto de PowerPoint/Aspose.Slides). Ese valor resuelto pasa a formar parte de la instantánea EffectiveData.

**Desde un valor de fuente efectivo, ¿puedo saber qué nivel proporcionó el tamaño o la tipografía?**

No directamente. EffectiveData devuelve el valor final. Para encontrar el origen, revisa los valores locales en la porción/párrafo/marco de texto y los estilos de texto en el diseño/maestra/presentación para ver dónde aparece la primera definición explícita.

**¿Por qué los valores EffectiveData a veces parecen idénticos a los locales?**

Porque el valor local resultó ser el final (no se necesitó herencia de nivel superior). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo trabajar solo con las locales?**

Usa EffectiveData cuando necesites el resultado "tal como se renderiza" después de aplicar toda la herencia (por ejemplo, para alinear colores, sangrías o tamaños). Si necesitas cambiar el formato en un nivel específico, modifica las propiedades locales y, si es necesario, vuelve a leer EffectiveData para verificar el resultado.