---
title: Gestionar superíndice y subíndice en presentaciones usando PHP
linktitle: Superíndice y Subíndice
type: docs
weight: 80
url: /es/php-java/superscript-and-subscript/
keywords:
- superíndice
- subíndice
- añadir superíndice
- añadir subíndice
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Domina el superíndice y el subíndice en Aspose.Slides para PHP mediante Java y eleva tus presentaciones con un formato de texto profesional para lograr el máximo impacto."
---

## **Administrar texto en superíndice y subíndice**
Puede añadir texto en superíndice y subíndice dentro de cualquier porción de párrafo. Para añadir texto en superíndice o subíndice en el marco de texto de Aspose.Slides es necesario usar el método [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) de la clase [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

Esta propiedad devuelve o establece el texto en superíndice o subíndice (valor de -100 % (subíndice) a 100 % (superíndice)). Por ejemplo:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtener la referencia de una diapositiva mediante su índice.
- Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de tipo [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Acceder al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) asociado al [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Borrar los párrafos existentes
- Crear un nuevo objeto de párrafo para contener texto en superíndice y añadirlo a la colección [IParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
- Crear un nuevo objeto de porción
- Establecer la propiedad Escapement para la porción entre 0 y 100 para añadir superíndice. (0 significa sin superíndice)
- Establecer algún texto para [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) y luego añadirlo a la colección de porciones del párrafo.
- Crear un nuevo objeto de párrafo para contener texto en subíndice y añadirlo a la colección IParagraphs del ITextFrame.
- Crear un nuevo objeto de porción
- Establecer la propiedad Escapement para la porción entre 0 y -100 para añadir subíndice. (0 significa sin subíndice)
- Establecer algún texto para [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) y luego añadirlo a la colección de porciones del párrafo.
- Guardar la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```php
  # Instanciar una clase Presentation que representa un PPTX
  $pres = new Presentation();
  try {
    # Obtener la diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Crear un cuadro de texto
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Crear un párrafo para texto en superíndice
    $superPar = new Paragraph();
    # Crear una porción con texto normal
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Crear una porción con texto en superíndice
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Crear un párrafo para texto en subíndice
    $paragraph2 = new Paragraph();
    # Crear una porción con texto normal
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Crear una porción con texto en subíndice
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Añadir párrafos al cuadro de texto
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Se conservará el superíndice y el subíndice al exportar a PDF u otros formatos?**

Sí, Aspose.Slides conserva correctamente el formato de superíndice y subíndice al exportar presentaciones a PDF, PPT/PPTX, imágenes y otros formatos compatibles. El formato especializado permanece intacto en todos los archivos de salida.

**¿Se pueden combinar el superíndice y el subíndice con otros estilos de formato como negrita o cursiva?**

Sí, Aspose.Slides permite mezclar varios estilos de texto dentro de una única porción. Puede habilitar negrita, cursiva, subrayado y, al mismo tiempo, aplicar superíndice o subíndice configurando las propiedades correspondientes en [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

**¿Funciona el formato de superíndice y subíndice para texto dentro de tablas, gráficos o SmartArt?**

Sí, Aspose.Slides admite el formato en la mayoría de los objetos, incluidas tablas y elementos de gráficos. Al trabajar con SmartArt, debe acceder a los elementos apropiados (como [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)) y sus contenedores de texto, y luego configurar las propiedades de [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) de manera similar.