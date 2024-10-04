---
title: Notas de Presentación
type: docs
weight: 110
url: /es/php-java/presentation-notes/
keywords: "Notas del orador de PowerPoint"
description: "Notas de presentación, notas del orador"
---


{{% alert color="primary" %}} 

Aspose.Slides soporta la eliminación de las diapositivas de notas de una presentación. En este tema, presentaremos esta nueva función de eliminar notas y también agregar diapositivas de estilo de notas de cualquier presentación. 

{{% /alert %}} 

Aspose.Slides para PHP a través de Java proporciona la función de eliminar notas de cualquier diapositiva así como añadir estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

* Eliminar notas de una diapositiva específica de una presentación.
* Eliminar notas de todas las diapositivas de una presentación.


## **Eliminar notas de una diapositiva**
Las notas de una diapositiva específica se pueden eliminar como se muestra en el ejemplo a continuación:

```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Eliminar las notas de la primera diapositiva
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Guardar la presentación en el disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eliminar notas de la presentación**
Las notas de todas las diapositivas de una presentación se pueden eliminar como se muestra en el ejemplo a continuación:

```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Eliminar las notas de todas las diapositivas
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Guardar la presentación en el disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Agregar NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) se ha añadido al método de la interface [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) y a la clase [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) respectivamente. Esta propiedad especifica el estilo de un texto de notas. La implementación se demuestra en el ejemplo a continuación.

```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Obtener el estilo de texto de MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Establecer un viñeta de símbolo para los párrafos de primer nivel
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```