---
title: Gestionar Marcadores de Posición
type: docs
weight: 10
url: /es/php-java/manage-placeholder/
description: Cambiar texto en un marcador de posición en diapositivas de PowerPoint usando PHP. Establecer texto de aviso en un marcador de posición en diapositivas de PowerPoint usando PHP.
---

## **Cambiar Texto en Marcador de Posición**
Usando [Aspose.Slides para PHP a través de Java](/slides/es/php-java/), puedes encontrar y modificar marcadores de posición en las diapositivas de presentaciones. Aspose.Slides te permite realizar cambios en el texto de un marcador de posición.

**Requisito previo**: Necesitas una presentación que contenga un marcador de posición. Puedes crear una presentación de este tipo en la aplicación estándar de Microsoft PowerPoint.

Así es como utilizas Aspose.Slides para reemplazar el texto en el marcador de posición en esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y pasa la presentación como argumento.
2. Obtén una referencia a la diapositiva a través de su índice.
3. Itera a través de las formas para encontrar el marcador de posición.
4. Transforma el marcador de posición a una [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) asociado con la [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Guarda la presentación modificada.

Este código PHP muestra cómo cambiar el texto en un marcador de posición:

```php
  # Instancia una clase Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Itera a través de las formas para encontrar el marcador de posición
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Cambia el texto en cada marcador de posición
        $shp->getTextFrame()->setText("Este es el Marcador de Posición");
      }
    }
    # Guarda la presentación en el disco
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Texto de Aviso en Marcador de Posición**
Los diseños estándar y preconstruidos contienen textos de aviso en los marcadores de posición, como ***Haz clic para agregar un título*** o ***Haz clic para agregar un subtítulo***. Usando Aspose.Slides, puedes insertar tus textos de aviso preferidos en los diseños de marcadores de posición.

Este código PHP te muestra cómo establecer el texto de aviso en un marcador de posición:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Itera a través de la diapositiva
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint muestra "Haz clic para agregar título"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Agregar Título";
        } else // Agrega subtítulo
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Agregar Subtítulo";
        }
        $shape->getTextFrame()->setText($text);
        echo("Marcador de posición con texto: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Transparencia de Imagen en Marcador de Posición**

Aspose.Slides te permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Al ajustar la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen resalten (dependiendo de los colores del texto y la imagen).

Este código PHP te muestra cómo establecer la transparencia para una imagen de fondo (dentro de una forma):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Valor actual de transparencia: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```