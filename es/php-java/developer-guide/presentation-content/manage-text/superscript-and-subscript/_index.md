---
title: Gestionar superíndice y subíndice en presentaciones usando PHP
linktitle: Superíndice y subíndice
type: docs
weight: 80
url: /es/php-java/superscript-and-subscript/
keywords:
- superíndice
- subíndice
- agregar superíndice
- agregar subíndice
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Domine el superíndice y subíndice en Aspose.Slides para PHP mediante Java y eleve sus presentaciones con un formato de texto profesional para lograr el máximo impacto."
---

## **Administrar texto de superíndice y subíndice**
Puede agregar texto en superíndice y subíndice dentro de cualquier porción de párrafo. Para agregar texto en superíndice o subíndice en un marco de texto de Aspose.Slides debe usar el método [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) de la clase [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

Esta propiedad devuelve o establece el texto en superíndice o subíndice (valor de -100 % (subíndice) a 100 % (superíndice)). Por ejemplo:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Acceda al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) asociado con el [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
- Borre los párrafos existentes
- Cree un nuevo objeto de párrafo para contener texto en superíndice y agréguelo a la [IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) del [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame).
- Cree un nuevo objeto Portion
- Establezca la propiedad Escapement para la porción entre 0 y 100 para agregar superíndice. (0 significa sin superíndice)
- Establezca algún texto para [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) y luego agréguelo a la colección de porciones del párrafo.
- Cree un nuevo objeto de párrafo para contener texto en subíndice y agréguelo a la colección IParagraphs del ITextFrame.
- Cree un nuevo objeto Portion
- Establezca la propiedad Escapement para la porción entre 0 y -100 para agregar subíndice. (0 significa sin subíndice)
- Establezca algún texto para [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) y luego agréguelo a la colección de porciones del párrafo.
- Guarde la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```php
  # Instanciar una clase Presentation que representa un PPTX
  $pres = new Presentation();
  try {
    # Obtener diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Crear cuadro de texto
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Crear párrafo para texto en superíndice
    $superPar = new Paragraph();
    # Crear porción con texto habitual
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Crear porción con texto en superíndice
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Crear párrafo para texto en subíndice
    $paragraph2 = new Paragraph();
    # Crear porción con texto habitual
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Crear porción con texto en subíndice
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Agregar párrafos al cuadro de texto
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

**¿Se conservarán el superíndice y el subíndice al exportar a PDF u otros formatos?**

Sí, Aspose.Slides conserva correctamente el formato de superíndice y subíndice al exportar presentaciones a PDF, PPT/PPTX, imágenes y otros formatos compatibles. El formato especializado permanece intacto en todos los archivos de salida.

**¿Se pueden combinar el superíndice y el subíndice con otros estilos de formato como negrita o cursiva?**

Sí, Aspose.Slides le permite mezclar varios estilos de texto dentro de una sola porción. Puede activar negrita, cursiva, subrayado y aplicar simultáneamente superíndice o subíndice configurando las propiedades correspondientes en [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

**¿El formato de superíndice y subíndice funciona para texto dentro de tablas, gráficos o SmartArt?**

Sí, Aspose.Slides admite el formato dentro de la mayoría de los objetos, incluidas tablas y elementos de gráficos. Al trabajar con SmartArt, debe acceder a los elementos apropiados (como [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)) y sus contenedores de texto, y luego configurar las propiedades de [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) de manera similar.