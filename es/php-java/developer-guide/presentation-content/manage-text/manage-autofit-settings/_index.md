---
title: Mejora tus presentaciones con AutoFit en PHP
linktitle: Configuración de Autofit
type: docs
weight: 30
url: /es/php-java/manage-autofit-settings/
keywords:
- cuadro de texto
- autofit
- no autofit
- ajustar texto
- reducir texto
- envolver texto
- redimensionar forma
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Gestiona la configuración de AutoFit en Aspose.Slides para PHP para optimizar la visualización de texto en tus presentaciones PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---

De forma predeterminada, cuando agregas un cuadro de texto, Microsoft PowerPoint usa la configuración **Resize shape to fix text** para el cuadro de texto; se redimensiona automáticamente el cuadro de texto para garantizar que su texto siempre quepa en él. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto en el cuadro de texto se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro de texto—incrementa su altura—para permitir que contenga más texto. 
* Cuando el texto en el cuadro de texto se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro de texto—disminuye su altura—para eliminar el espacio redundante. 

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de ajuste automático para un cuadro de texto: 

* **No ajustar automáticamente**
* **Reducir texto al desbordarse**
* **Redimensionar forma para ajustar texto**
* **Ajustar texto en forma.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java proporciona opciones similares—algunas propiedades de la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)—que le permiten controlar el comportamiento de ajuste automático de los cuadros de texto en presentaciones.

## **Redimensionar forma para ajustar texto**

Si desea que el texto en un cuadro siempre quepa en ese cuadro después de realizar cambios en el texto, debe utilizar la opción **Resize shape to fix text**. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) en `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código PHP muestra cómo especificar que un texto siempre debe caber en su cuadro en una presentación de PowerPoint:
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


Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumentará su altura) para garantizar que todo el texto quepa en él. Si el texto se vuelve más corto, ocurre lo contrario. 

## **No Autoajustar**

Si desea que un cuadro de texto o una forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debe utilizar la opción **No Autoajustar**. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) en `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código PHP muestra cómo especificar que un cuadro de texto debe mantener siempre sus dimensiones en una presentación de PowerPoint:
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

## **Reducir texto al desbordarse**

Si un texto se vuelve demasiado largo para su cuadro, mediante la opción **Shrink text on overflow** puede especificar que el tamaño y el espaciado del texto deben reducirse para que quepan en su cuadro. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) en `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código PHP muestra cómo especificar que un texto debe reducirse al desbordarse en una presentación de PowerPoint:
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


{{% alert title="Info" color="info" %}}
Cuando se utiliza la opción **Shrink text on overflow**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su cuadro. 
{{% /alert %}}

## **Ajustar texto**

Si desea que el texto en una forma se ajuste dentro de esa forma cuando el texto supera el borde de la forma (solo ancho), debe usar el parámetro **Wrap text in shape**. Para especificar esta configuración, debe establecer la propiedad [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) en `true`.

Este código PHP muestra cómo usar la configuración Ajustar Texto en una presentación de PowerPoint:
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


{{% alert title="Note" color="warning" %}} 
Si establece la propiedad `WrapText` en `False` para una forma, cuando el texto dentro de la forma se vuelve más largo que el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea. 
{{% /alert %}}

## **Preguntas frecuentes**

**¿Los márgenes internos del marco de texto afectan al AutoFit?**

Sí. El relleno (márgenes internos) reduce el área utilizable para el texto, por lo que AutoFit se activará antes, reduciendo la fuente o redimensionando la forma más pronto. Verifique y ajuste los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con saltos de línea manuales y suaves?**

Los saltos forzados permanecen en su lugar, y AutoFit adapta el tamaño de fuente y el espaciado alrededor de ellos. Eliminar saltos innecesarios a menudo reduce la agresividad con la que AutoFit necesita encoger el texto.

**¿Afecta el cambio de la fuente del tema o la sustitución de fuentes a los resultados de AutoFit?**

Sí. Sustituir a una fuente con métricas de glifo diferentes cambia el ancho/alto del texto, lo que puede alterar el tamaño final de la fuente y el ajuste de líneas. Después de cualquier cambio o sustitución de fuente, vuelva a comprobar las diapositivas.