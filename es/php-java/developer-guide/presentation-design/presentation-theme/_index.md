---
title: Tema de Presentación
type: docs
weight: 10
url: /php-java/presentation-theme/
keywords: "Tema, tema de PowerPoint, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Tema de presentación de PowerPoint"
---

Un tema de presentación define las propiedades de los elementos de diseño. Al seleccionar un tema de presentación, esencialmente estás eligiendo un conjunto específico de elementos visuales y sus propiedades.

En PowerPoint, un tema comprende colores, [fuentes](/slides/php-java/powerpoint-fonts/), [estilos de fondo](/slides/php-java/presentation-background/), y efectos.

![theme-constituents](theme-constituents.png)

## **Cambiar Color del Tema**

Un tema de PowerPoint utiliza un conjunto específico de colores para diferentes elementos en una diapositiva. Si no te gustan los colores, puedes cambiarlos aplicando nuevos colores para el tema. Para permitirte seleccionar un nuevo color de tema, Aspose.Slides proporciona valores bajo la enumeración [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor).

Este código PHP te muestra cómo cambiar el color de acento para un tema:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Puedes determinar el valor efectivo del color resultante de esta manera:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

Para demostrar aún más la operación de cambio de color, creamos otro elemento y le asignamos el color de acento (de la operación inicial). Luego cambiamos el color en el tema:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

El nuevo color se aplica automáticamente a ambos elementos.

### **Establecer Color del Tema desde una Paleta Adicional**

Al aplicar transformaciones de luminancia al color principal del tema(1), se forman colores de la paleta adicional(2). Luego puedes establecer y obtener esos colores de tema.

![additional-palette-colors](additional-palette-colors.png)

**1** - Colores principales del tema

**2** - Colores de la paleta adicional.

Este código PHP demuestra una operación donde se obtienen colores de la paleta adicional a partir del color principal del tema y luego se utilizan en formas:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Acento 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Acento 4, más claro 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Acento 4, más claro 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Acento 4, más oscuro 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Acento 4, más oscuro 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Cambiar Fuente del Tema**

Para permitirte seleccionar fuentes para temas y otros propósitos, Aspose.Slides utiliza estos identificadores especiales (similares a los utilizados en PowerPoint):

* **+mn-lt** - Fuente del Cuerpo en Latino (Fuente Menor en Latino)
* **+mj-lt** - Fuente de Encabezado en Latino (Fuente Mayor en Latino)
* **+mn-ea** - Fuente del Cuerpo en Asia Oriental (Fuente Menor en Asia Oriental)
* **+mj-ea** - Fuente de Encabezado en Asia Oriental (Fuente Mayor en Asia Oriental)

Este código PHP te muestra cómo asignar la fuente latina a un elemento del tema:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Formato de texto del tema");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

Este código PHP te muestra cómo cambiar la fuente del tema de presentación:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

La fuente en todos los cuadros de texto se actualizará.

{{% alert color="primary" title="CONSEJO" %}} 

Es posible que desees ver [fuentes de PowerPoint](/slides/php-java/powerpoint-fonts/).

{{% /alert %}}

## **Cambiar Estilo de Fondo del Tema**

Por defecto, la aplicación de PowerPoint proporciona 12 fondos predefinidos, pero solo 3 de esos 12 fondos se guardan en una presentación típica. 

![todo:image_alt_text](presentation-design_8.png)

Por ejemplo, después de guardar una presentación en la aplicación de PowerPoint, puedes ejecutar este código PHP para averiguar el número de fondos predefinidos en la presentación:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Número de estilos de relleno de fondo para el tema es " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Usando la propiedad [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) de la clase [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme), puedes agregar o acceder al estilo de fondo en un tema de PowerPoint.

{{% /alert %}} 

Este código PHP te muestra cómo establecer el fondo de una presentación:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);

```

**Guía de índices**: 0 se usa para sin relleno. El índice comienza desde 1.

{{% alert color="primary" title="CONSEJO" %}} 

Es posible que desees ver [Fondo de PowerPoint](/slides/php-java/presentation-background/).

{{% /alert %}}

## **Cambiar Efecto del Tema**

Un tema de PowerPoint generalmente contiene 3 valores para cada matriz de estilos. Esas matrices se combinan en estos 3 efectos: sutil, moderado e intenso. Por ejemplo, este es el resultado cuando se aplican los efectos a una forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propiedades ([FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)) de la clase [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme), puedes cambiar los elementos en un tema (incluso de manera más flexible que las opciones en PowerPoint).

Este código PHP te muestra cómo cambiar un efecto del tema alterando partes de los elementos:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Los cambios resultantes en el color de relleno, tipo de relleno, efecto de sombra, etc.:

![todo:image_alt_text](presentation-design_11.png)