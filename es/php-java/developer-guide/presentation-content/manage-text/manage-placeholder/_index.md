---
title: Administrar marcadores de posición de presentación en PHP
linktitle: Administrar marcadores
type: docs
weight: 10
url: /es/php-java/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- texto de sugerencia
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Administre marcadores de posición en Aspose.Slides para PHP mediante Java de forma sencilla: reemplace texto, personalice sugerencias y establezca la transparencia de imágenes en PowerPoint y OpenDocument."
---

## **Cambiar texto en un marcador de posición**
Usando [Aspose.Slides for PHP via Java](/slides/es/php-java/), puedes encontrar y modificar marcadores de posición en diapositivas de presentaciones. Aspose.Slides permite realizar cambios en el texto de un marcador de posición.

**Prerequisito**: Necesitas una presentación que contenga un marcador de posición. Puedes crear dicha presentación en la aplicación estándar de Microsoft PowerPoint.

Así es como usas Aspose.Slides para reemplazar el texto en el marcador de posición de esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y pasa la presentación como argumento.
2. Obtén una referencia a la diapositiva mediante su índice.
3. Itera a través de las formas para encontrar el marcador de posición.
4. Convierte el tipo de la forma del marcador de posición a un [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) asociado con el [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
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
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Guarda la presentación en disco
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer texto de sugerencia en un marcador de posición**
Los diseños estándar y predefinidos contienen textos de sugerencia en marcadores de posición como ***Haga clic para agregar un título*** o ***Haga clic para agregar un subtítulo***. Usando Aspose.Slides, puedes insertar tus textos de sugerencia preferidos en los diseños de marcadores de posición.

Este código PHP te muestra cómo establecer el texto de sugerencia en un marcador de posición:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Recorre la diapositiva
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint muestra "Haz clic para agregar título"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Añade subtítulo
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer transparencia de imagen en marcador de posición**
Aspose.Slides permite establecer la transparencia de la imagen de fondo en un marcador de posición de texto. Ajustando la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen resalten (dependiendo de los colores del texto y de la imagen).

Este código PHP te muestra cómo establecer la transparencia para el fondo de una imagen (dentro de una forma):
```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**¿Qué es un marcador de posición base y en qué se diferencia de una forma local en una diapositiva?**

Un marcador de posición base es la forma original en un diseño o maestro del que hereda la forma de la diapositiva: tipo, posición y parte del formato provienen de él. Una forma local es independiente; si no existe un marcador de posición base, la herencia no se aplica.

**¿Cómo puedo actualizar todos los títulos o leyendas en una presentación sin iterar sobre cada diapositiva?**

Edita el marcador de posición correspondiente en el diseño o en el maestro. Las diapositivas basadas en esos diseños/maestro heredarán automáticamente el cambio.

**¿Cómo controlo los marcadores de posición estándar de encabezado/pie de página —fecha y hora, número de diapositiva y texto del pie?**

Utiliza los administradores HeaderFooter en el alcance apropiado (diapositivas normales, diseños, maestro, notas/folletos) para activar o desactivar esos marcadores de posición y establecer su contenido.