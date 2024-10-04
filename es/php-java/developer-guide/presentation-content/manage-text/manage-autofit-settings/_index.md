---
title: Administrar la configuración de ajuste automático
type: docs
weight: 30
url: /es/php-java/manage-autofit-settings/
keywords: "Cuadro de texto, Ajuste automático, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Configurar la configuración de ajuste automático para cuadros de texto en PowerPoint"
---

De forma predeterminada, cuando agrega un cuadro de texto, Microsoft PowerPoint utiliza la configuración **Redimensionar forma para ajustar texto** para el cuadro de texto: redimensiona automáticamente el cuadro de texto para asegurarse de que su texto siempre quepa dentro de él.

![cuadro-de-texto-en-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto en el cuadro de texto se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro de texto—aumenta su altura—para permitir que contenga más texto.
* Cuando el texto en el cuadro de texto se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro de texto—disminuye su altura—para eliminar espacio redundante.

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de ajuste automático para un cuadro de texto:

* **No ajustar automáticamente**
* **Reducir texto en desbordamiento**
* **Redimensionar forma para ajustar texto**
* **Ajustar texto en forma.**

![opciones-de-ajuste-automático-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides para PHP a través de Java proporciona opciones similares—algunas propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)—que le permiten controlar el comportamiento de ajuste automático para cuadros de texto en presentaciones.

## **Redimensionar Forma para Ajustar Texto**

Si desea que el texto en un cuadro siempre quepa dentro de ese cuadro después de que se realicen cambios en el texto, debe usar la opción **Redimensionar forma para ajustar texto**. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) en `Shape`.

![configuración-de-ajuste-siempre-powerpoint](alwaysfit-setting-powerpoint.png)

Este código PHP le muestra cómo especificar que un texto debe siempre ajustarse a su cuadro en una presentación de PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumento en altura) para asegurarse de que todo el texto quepa dentro de él. Si el texto se vuelve más corto, ocurre lo contrario.

## **No Ajustar Automáticamente**

Si desea que un cuadro de texto o forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debe usar la opción **No ajustar automáticamente**. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) en `None`.

![configuración-no-ajustar-automáticamente-powerpoint](donotautofit-setting-powerpoint.png)

Este código PHP le muestra cómo especificar que un cuadro de texto debe mantener siempre sus dimensiones en una presentación de PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Cuando el texto se vuelve demasiado largo para su cuadro, se desborda.

## **Reducir Texto en Desbordamiento**

Si un texto se vuelve demasiado largo para su cuadro, a través de la opción **Reducir texto en desbordamiento**, puede especificar que el tamaño y el espaciado del texto deben reducirse para que quepa en su cuadro. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) en `Normal`.

![configuración-reducir-texto-en-desbordamiento-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código PHP le muestra cómo especificar que un texto debe ser reducido en desbordamiento en una presentación de PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Información" color="info" %}}

Cuando se utiliza la opción **Reducir texto en desbordamiento**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su cuadro.

{{% /alert %}}

## **Ajustar Texto**

Si desea que el texto en una forma se ajuste dentro de esa forma cuando el texto exceda el límite de la forma (solo ancho), debe usar el parámetro **Ajustar texto en forma**. Para especificar esta configuración, debe establecer la propiedad [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) en `true`.

Este código PHP le muestra cómo usar la configuración de Ajustar Texto en una presentación de PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Nota" color="warning" %}} 

Si establece la propiedad `WrapText` en `False` para una forma, cuando el texto dentro de la forma se vuelve más largo que el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea.

{{% /alert %}}