---
title: Gestionar notas de la presentación en PHP
linktitle: Notas de la presentación
type: docs
weight: 110
url: /es/php-java/presentation-notes/
keywords:
- notas
- diapositiva de notas
- agregar notas
- eliminar notas
- estilo de notas
- notas maestras
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Personaliza las notas de la presentación con Aspose.Slides para PHP a través de Java. Trabaja sin problemas con notas de PowerPoint y OpenDocument para aumentar tu productividad."
---

{{% alert color="primary" %}}
Aspose.Slides admite eliminar diapositivas de notas de una presentación. En este tema, presentaremos esta nueva funcionalidad de eliminar notas y también añadir diapositivas con estilo de notas a cualquier presentación.
{{% /alert %}}

Aspose.Slides para PHP a través de Java ofrece la función de eliminar notas de cualquier diapositiva, así como añadir estilo a las notas existentes. Los desarrolladores pueden eliminar notas de las siguientes maneras:

* Eliminar notas de una diapositiva específica de una presentación.
* Eliminar notas de todas las diapositivas de una presentación.

## **Eliminar notas de una diapositiva**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:
```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Eliminar notas de la primera diapositiva
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Guardar la presentación en disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eliminar notas de una presentación**
Las notas de todas las diapositivas de una presentación pueden eliminarse como se muestra en el ejemplo a continuación:
```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Eliminar notas de todas las diapositivas
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Guardar la presentación en disco
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Añadir un estilo de notas**
Se ha añadido el método [getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) a la clase [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) respectivamente. Esta propiedad especifica el estilo del texto de una nota. La implementación se muestra en el ejemplo a continuación.
```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Obtener el estilo de texto de MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Establecer viñeta de símbolo para los párrafos de primer nivel
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


## **Preguntas frecuentes**

**¿Qué entidad API proporciona acceso a las notas de una diapositiva específica?**
Las notas se acceden a través del gestor de notas de la diapositiva: la diapositiva tiene un [NotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/) y un [método](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/) que devuelve el objeto de notas, o `null` si no hay notas.

**¿Existen diferencias en la compatibilidad de notas entre las versiones de PowerPoint con las que funciona la biblioteca?**
La biblioteca está dirigida a una amplia gama de formatos de Microsoft PowerPoint (desde 97–newer) y ODP; las notas son compatibles con estos formatos sin depender de una copia instalada de PowerPoint.