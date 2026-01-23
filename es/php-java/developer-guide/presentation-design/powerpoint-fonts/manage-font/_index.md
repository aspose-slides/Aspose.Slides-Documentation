---
title: Gestionar fuentes en presentaciones usando PHP
linktitle: Gestionar fuentes
type: docs
weight: 10
url: /es/php-java/manage-fonts/
keywords:
- administrar fuentes
- propiedades de fuentes
- párrafo
- formato de texto
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Controla fuentes en PHP con Aspose.Slides: incrusta, sustituye y carga fuentes personalizadas para mantener las presentaciones PPT, PPTX y ODP claras, seguras para la marca y consistentes."
---

## **Gestionar propiedades relacionadas con la fuente**
{{% alert color="primary" %}} 

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para ajustarse a los estilos corporativos. El formato del texto ayuda a los usuarios a variar el aspecto y la sensación del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides for PHP via Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas.

{{% /alert %}} 

Para gestionar las propiedades de fuente de un párrafo usando Aspose.Slides for PHP via Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva usando su índice.
1. Acceder a las formas [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) en la diapositiva y convertirlas a [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Obtener el [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) expuesto por [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Justificar el párrafo.
1. Acceder al [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) de texto de un [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
1. Definir la fuente usando [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) y establecer la **Font** del [Portion] de texto en consecuencia.
   1. Establecer la fuente en negrita.
   1. Establecer la fuente en cursiva.
1. Establecer el color de la fuente usando el [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) expuesto por el objeto [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Guardar la presentación modificada en un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación. Toma una presentación sin formato y aplica formatos de fuente a una de las diapositivas. Las capturas de pantalla que siguen muestran el archivo de entrada y cómo los fragmentos de código lo modifican. El código cambia la fuente, el color y el estilo de la fuente.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: El texto en el archivo de entrada**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: El mismo texto con formato actualizado**|
```php
  # Instanciar un objeto Presentation que representa un archivo PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Accediendo a una diapositiva mediante su posición
    $slide = $pres->getSlides()->get_Item(0);
    # Accediendo al primer y segundo placeholder en la diapositiva y convirtiéndolo a AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Accediendo al primer párrafo
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Justificar el párrafo
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Accediendo a la primera porción
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definir fuentes nuevas
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Asignar nuevas fuentes a la porción
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Establecer la fuente en negrita
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Establecer la fuente en cursiva
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Establecer color de la fuente
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Guardar el PPTX en disco
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer propiedades de fuente del texto**
{{% alert color="primary" %}} 

Como se menciona en **Gestionar propiedades relacionadas con la fuente**, un [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) se utiliza para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides for PHP via Java para crear un cuadro de texto con algún texto y luego definir una fuente concreta, así como varias otras propiedades de la categoría de familia tipográfica.

{{% /alert %}} 

Para crear un cuadro de texto y establecer las propiedades de fuente del texto que contiene:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva usando su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de tipo **Rectangle** a la diapositiva.
1. Eliminar el estilo de relleno asociado al [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Acceder al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) del [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Añadir texto al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
1. Acceder al objeto [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) asociado al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
1. Definir la fuente a usar para el [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Establecer otras propiedades de fuente como negrita, cursiva, subrayado, color y altura mediante las propiedades relevantes expuestas por el objeto [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Escribir la presentación modificada como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto con algunas propiedades de fuente establecidas por Aspose.Slides for PHP via Java**|
```php
  # Instanciar un objeto Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir un AutoShape de tipo Rectángulo
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Eliminar cualquier estilo de relleno asociado al AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Acceder al TextFrame asociado al AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Acceder a la Porción asociada al TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Establecer la fuente para la Porción
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Establecer la propiedad Negrita de la fuente
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Establecer la propiedad Cursiva de la fuente
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Establecer la propiedad Subrayado de la fuente
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Establecer la altura de la fuente
    $port->getPortionFormat()->setFontHeight(25);
    # Establecer el color de la fuente
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Guardar la presentación en disco
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
