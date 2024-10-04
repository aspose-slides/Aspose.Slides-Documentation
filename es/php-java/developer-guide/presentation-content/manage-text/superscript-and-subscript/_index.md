---
title: Superíndice e Inferior
type: docs
weight: 80
url: /php-java/superscript-and-subscript/
---

## **Gestionar Texto de Superíndice e Inferior**
Puedes agregar texto en superíndice e inferior dentro de cualquier parte del párrafo. Para agregar texto en Superíndice o Inferior en el marco de texto de Aspose.Slides, se debe utilizar el método [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) de la clase [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

Esta propiedad devuelve o establece el texto en superíndice o inferior (valor de -100% (inferior) a 100% (superíndice). Por ejemplo:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtén la referencia de una diapositiva usando su índice.
- Agrega un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de tipo [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
- Accede al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) asociado con el [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
- Limpia los párrafos existentes.
- Crea un nuevo objeto párrafo para contener texto en superíndice y agrégalo a la [colección IParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) del [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame).
- Crea un nuevo objeto porción.
- Establece la propiedad Escapement para la porción entre 0 y 100 para agregar superíndice. (0 significa sin superíndice).
- Establece algún texto para [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) y luego agrégalo a la colección de porciones del párrafo.
- Crea un nuevo objeto párrafo para contener texto en inferior y agrégalo a la colección IParagraphs del ITextFrame.
- Crea un nuevo objeto porción.
- Establece la propiedad Escapement para la porción entre 0 y -100 para agregar inferior. (0 significa sin inferior).
- Establece algún texto para [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) y luego agrégalo a la colección de porciones del párrafo.
- Guarda la presentación como un archivo PPTX.

La implementación de los pasos anteriores se proporciona a continuación.

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
    # Crear párrafo para texto en inferior
    $paragraph2 = new Paragraph();
    # Crear porción con texto habitual
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Crear porción con texto en inferior
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