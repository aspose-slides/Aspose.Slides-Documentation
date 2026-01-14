---
title: Formatear texto de PowerPoint en PHP
linktitle: Formato de texto
type: docs
weight: 50
url: /es/php-java/text-formatting/
keywords:
- resaltar texto
- expresión regular
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia de texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuentes
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad autofit
- anclaje del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Formatear y dar estilo al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP vía Java. Personaliza fuentes, colores, alineación y mucho más."
---

## **Resaltar texto**
El método [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlighttext/) se ha añadido a la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

Permite resaltar una parte del texto con color de fondo usando una muestra de texto, similar a la herramienta Resaltar color de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// resaltando todas las palabras 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// resaltando todas las ocurrencias separadas de 'the'

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
Aspose proporciona un sencillo [servicio gratuito de edición en línea de PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Resaltar texto usando una expresión regular**
El método [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlightregex/) se ha añadido a la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

Permite resaltar una parte del texto con color de fondo usando una expresión regular, similar a la herramienta Resaltar color de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// resaltando todas las palabras con 10 símbolos o más

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el color de fondo del texto**
Aspose.Slides le permite especificar el color preferido para el fondo de un texto.

Este código PHP muestra cómo establecer el color de fondo para todo un texto:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->spliterator(), false)->map(( p) -> $p->getPortions())->forEach(( c) -> $c->forEach(( ic) -> $ic->getPortionFormat()->getHighlightColor()->setColor($Color.BLUE)));
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


Este código PHP muestra cómo establecer el color de fondo solo para una parte del texto:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Red"))->findFirst();
    if ($redPortion->isPresent()) {
      $redPortion->get()->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->RED);
    }
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Alinear párrafos de texto**
El formato del texto es uno de los elementos clave al crear cualquier tipo de documento o presentación. Sabemos que Aspose.Slides for PHP via Java permite añadir texto a las diapositivas, pero en este tema veremos cómo controlar la alineación de los párrafos de texto en una diapositiva. Siga los pasos a continuación para alinear los párrafos de texto usando Aspose.Slides for PHP via Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Acceda a las formas de marcador de posición presentes en la diapositiva y conviértalas a [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
4. Obtenga el [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) (que necesita ser alineado) desde el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) expuesto por [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
5. Alinee el párrafo. Un párrafo puede alinearse a la derecha, izquierda, centro y justificado.
6. Guarde la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```php
  # Instanciar un objeto Presentation que representa un archivo PPTX
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo a AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Cambiar el texto en ambos marcadores de posición
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # Obteniendo el primer párrafo de los marcadores de posición
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Alineando el párrafo de texto al centro
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # Guardando la presentación como archivo PPTX
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer transparencia para el texto**
Este artículo demuestra cómo establecer la propiedad de transparencia en cualquier forma de texto usando Aspose.Slides for PHP via Java. Para establecer la transparencia en el texto, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva.
3. Establezca el color de la sombra.
4. Guarde la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # establecer la transparencia a cero por ciento
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el espaciado de caracteres para el texto**
Aspose.Slides le permite establecer el espacio entre letras en un cuadro de texto. De esta manera, puede ajustar la densidad visual de una línea o bloque de texto ampliando o condensando el espaciado entre caracteres.

Este código PHP muestra cómo ampliar el espaciado para una línea de texto y condensar el espaciado para otra línea:
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// expandir

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// condensar

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **Gestionar propiedades de fuente de un párrafo**
Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para ajustarse a estilos corporativos. El formato del texto ayuda a los usuarios a variar la apariencia del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides for PHP via Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas. Para gestionar las propiedades de fuente de un párrafo usando Aspose.Slides for PHP via Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva usando su índice.
1. Acceda a las formas de marcador de posición en la diapositiva y conviértalas a [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Obtenga el [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) expuesto por [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Justifique el párrafo.
1. Acceda a la porción de texto de un párrafo.
1. Defina la fuente usando FontData y establezca la fuente de la porción de texto en consecuencia.
   1. Establezca la fuente en negrita.
   1. Establezca la fuente en cursiva.
1. Establezca el color de la fuente usando el [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) expuesto por el objeto [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Guarde la presentación modificada en un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

La implementación de los pasos anteriores se muestra a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas.
```php
  # Instanciar un objeto Presentation que representa un archivo PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Acceder a una diapositiva usando su posición
    $slide = $pres->getSlides()->get_Item(0);
    # Acceder al primer y segundo marcador de posición en la diapositiva y convertirlo a AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Acceder al primer párrafo
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Acceder a la primera porción
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definir nuevas fuentes
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
    # Establecer el color de la fuente
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Guardar el PPTX en disco
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gestionar la familia de fuentes del texto**
Una porción se usa para contener texto con estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides for PHP via Java para crear un cuadro de texto con algo de texto y luego definir una fuente concreta, así como varias otras propiedades de la categoría de familia de fuentes. Para crear un cuadro de texto y establecer las propiedades de fuente del texto en él:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) del tipo [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) a la diapositiva.
4. Elimine el estilo de relleno asociado al [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
5. Acceda al TextFrame del AutoShape.
6. Añada texto al TextFrame.
7. Acceda al objeto [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) asociado al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
8. Defina la fuente a usar para el [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
9. Establezca otras propiedades de fuente como negrita, cursiva, subrayado, color y altura usando las propiedades relevantes expuestas por el objeto Portion.
10. Guarde la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```php
  # Instanciar una presentación
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir un AutoShape del tipo Rectángulo
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Eliminar cualquier estilo de relleno asociado al AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Acceder al TextFrame asociado al AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Acceder a la porción asociada al TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Establecer la fuente para la porción
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Establecer la propiedad negrita de la fuente
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Establecer la propiedad cursiva de la fuente
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Establecer la propiedad subrayado de la fuente
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Establecer la altura de la fuente
    $port->getPortionFormat()->setFontHeight(25);
    # Establecer el color de la fuente
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Guardar el PPTX en disco
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el tamaño de fuente para el texto**
Aspose.Slides le permite elegir el tamaño de fuente preferido para el texto existente en un párrafo y otros textos que puedan añadirse al párrafo posteriormente.

Este código PHP muestra cómo establecer el tamaño de fuente para los textos contenidos en un párrafo:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # Obtiene la primera forma, por ejemplo.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Obtiene el primer párrafo, por ejemplo.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Establece el tamaño de fuente predeterminado a 20 pt para todas las porciones de texto del párrafo.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # Establece el tamaño de fuente a 20 pt para las porciones de texto actuales del párrafo.
      foreach($paragraph->getPortions() as $portion) {
        $portion->getPortionFormat()->setFontHeight(20);
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Establecer la rotación del texto**
Aspose.Slides for PHP via Java permite a los desarrolladores rotar el texto. El texto puede configurarse para aparecer como [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Horizontal), [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical), [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#MongolianVertical) o [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVerticalRightToLeft). Para rotar el texto de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Añada cualquier Shape a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
5. [Rotate the text](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
6. Guarde el archivo en disco.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir un AutoShape de tipo Rectángulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Añadir un TextFrame al rectángulo
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Acceder al marco de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Crear el objeto Paragraph para el marco de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear el objeto Portion para el párrafo
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Guardar la presentación
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer ángulo de rotación personalizado para un TextFrame**
Aspose.Slides for PHP via Java ahora soporta la configuración de un ángulo de rotación personalizado para TextFrame. En este tema veremos con un ejemplo cómo establecer la propiedad RotationAngle en Aspose.Slides. Los nuevos métodos [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/) y [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/getrotationangle/) se han añadido a la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/), lo que permite establecer el ángulo de rotación personalizado para TextFrame. Para establecer RotationAngle, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Añada un gráfico en la diapositiva.
3. [Set a rotation angle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/).
4. Guarde la presentación como un archivo PPTX.

En el ejemplo siguiente, establecemos la propiedad RotationAngle.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir un AutoShape de tipo Rectángulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Añadir un TextFrame al rectángulo
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Acceder al marco de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Crear el objeto Paragraph para el marco de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear el objeto Portion para el párrafo
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Text rotation example.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Guardar la presentación
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Interlineado de un párrafo**
Aspose.Slides proporciona propiedades bajo [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/)‑`SpaceAfter`, `SpaceBefore` y `SpaceWithin`, que permiten gestionar el interlineado de un párrafo. Las tres propiedades se usan de la siguiente manera:

* Para especificar el interlineado de un párrafo en porcentaje, use un valor positivo. 
* Para especificar el interlineado de un párrafo en puntos, use un valor negativo.

Por ejemplo, puede aplicar un interlineado de 16 pt a un párrafo estableciendo la propiedad `SpaceBefore` a ‑16.

Así es como se especifica el interlineado para un párrafo concreto:

1. Cargue una presentación que contenga un AutoShape con texto.
2. Obtenga la referencia de una diapositiva a través de su índice.
3. Acceda al TextFrame.
4. Acceda al Paragraph.
5. Establezca las propiedades del Paragraph.
6. Guarde la presentación.

Este código PHP muestra cómo especificar el interlineado para un párrafo:
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Obtener la referencia de una diapositiva por su índice
    $sld = $pres->getSlides()->get_Item(0);
    # Acceder al TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Acceder al párrafo
    $para = $tf1->getParagraphs()->get_Item(0);
    # Establecer propiedades del párrafo
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # Guardar la presentación
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer la propiedad AutofitType para un TextFrame**
En este tema exploraremos las distintas propiedades de formato de los marcos de texto. Este artículo cubre cómo establecer la propiedad AutofitType del marco de texto, el anclaje del texto y la rotación del texto en la presentación. Aspose.Slides for PHP via Java permite a los desarrolladores establecer la propiedad AutofitType de cualquier marco de texto. AutofitType puede establecerse en [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal) o [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape). Si se establece en [Normal], la forma permanecerá igual mientras el texto se ajusta sin que la forma cambie; si AutofitType se establece en [Shape], la forma se modificará de modo que solo contenga el texto necesario. Para establecer la propiedad AutofitType de un marco de texto, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Añada cualquier shape a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
5. [Set the autofit type](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setautofittype/) del TextFrame.
6. Guarde el archivo en disco.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Acceder a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir un AutoShape de tipo Rectángulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Añadir un TextFrame al rectángulo
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Acceder al marco de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Crear el objeto Paragraph para el marco de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear el objeto Portion para el párrafo
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Guardar la presentación
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el anclaje de un TextFrame**
Aspose.Slides for PHP via Java permite a los desarrolladores anclar cualquier TextFrame. TextAnchorType especifica dónde se coloca el texto dentro de la forma. AnchorType puede establecerse en [Top](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Top), [Center](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Center), [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Bottom), [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Justified) o [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Distributed). Para establecer el anclaje de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Añada cualquier shape a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
5. [Set the text anchor type](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setanchoringtype/) del TextFrame.
6. Guarde el archivo en disco.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir un AutoShape de tipo Rectángulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Añadir un TextFrame al rectángulo
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Acceder al marco de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Crear el objeto Paragraph para el marco de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear el objeto Portion para el párrafo
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Guardar la presentación
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Tabulaciones y EffectiveTabs en una presentación**
Todas las tabulaciones de texto se dan en píxeles.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figura: 2 Tabulaciones explícitas y 2 tabulaciones predeterminadas**|

- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.  
- La colección EffectiveTabs incluye todas las tabulaciones (de la colección Tabs y las predeterminadas).  
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.  
- La propiedad EffectiveTabs.DefaultTabSize (294) muestra la distancia entre las tabulaciones predeterminadas (3 y 4 en nuestro ejemplo).  
- EffectiveTabs.GetTabByIndex(index) con index = 0 devolverá la primera tabulación explícita (Position = 731), index = 1 – segunda tabulación (Position = 1241). Si intenta obtener la siguiente tabulación con index = 2, devolverá la primera tabulación predeterminada (Position = 1470) y así sucesivamente.  
- EffectiveTabs.GetTabAfterPosition(pos) se usa para obtener la siguiente tabulación después de algún texto. Por ejemplo, tiene el texto: "Hello World!". Para renderizar ese texto debe saber dónde comenzar a dibujar "world!". Primero, calcule la longitud de "Hello" en píxeles y llame a GetTabAfterPosition con ese valor. Obtendrá la posición de la siguiente tabulación para dibujar "world!".

## **Extraer texto con el efecto de mayúsculas**
En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando recupera dicha porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como fue introducido. Para manejar esto, compruebe [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/)—si indica `All`, convierta simplemente la cadena devuelta a mayúsculas para que su salida coincida con lo que los usuarios ven en la diapositiva.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![El efecto de mayúsculas](all_caps_effect.png)

El siguiente ejemplo de código muestra cómo extraer el texto con el efecto **All Caps** aplicado:
```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $textPortion = $paragraph->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = $textPortion->getText()->toUpperCase();
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```


Salida:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **Preguntas frecuentes**

**¿Cómo modificar el texto en una tabla de una diapositiva?**

Para modificar el texto en una tabla de una diapositiva, debe utilizar la clase [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Puede iterar por todas las celdas de la tabla y cambiar el texto en cada celda accediendo a sus propiedades `TextFrame` y `ParagraphFormat` dentro de cada celda.

**¿Cómo aplicar un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use el método `getFillFormat` en [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/). Establezca `FillFormat` a `Gradient`, donde podrá definir los colores de inicio y fin del degradado, así como otras propiedades como dirección y transparencia para crear el efecto degradado en el texto.