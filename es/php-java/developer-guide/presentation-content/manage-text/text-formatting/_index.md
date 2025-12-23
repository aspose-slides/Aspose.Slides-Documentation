---
title: Formatear texto de PowerPoint en PHP
linktitle: Formateo de texto
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
- ancla del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Formatee y estilice el texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP via Java. Personalice fuentes, colores, alineación y más."
---

## **Resaltar texto**
El método [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) se ha añadido a la interfaz [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

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
Aspose ofrece un sencillo, [servicio gratuito en línea de edición de PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Resaltar texto usando una expresión regular**
El método [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) se ha añadido a la interfaz [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

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

Este código PHP muestra cómo establecer el color de fondo para un texto completo:
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
El formato de texto es uno de los elementos clave al crear cualquier tipo de documentos o presentaciones. Sabemos que Aspose.Slides for PHP via Java soporta añadir texto a diapositivas pero en este tema veremos cómo controlar la alineación de los párrafos de texto en una diapositiva. Por favor siga los pasos a continuación para alinear los párrafos de texto usando Aspose.Slides for PHP via Java:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Acceda a las formas Placeholder presentes en la diapositiva y convíertalas a [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. Obtenga el Paragraph (que necesita alinearse) del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) expuesto por [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Alinee el Paragraph. Un párrafo puede alinearse a Derecha, Izquierda, Centro y Justificar.
6. Escriba la presentación modificada como un archivo PPTX.

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
    # Guardando la presentación como un archivo PPTX
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer transparencia para el texto**
Este artículo muestra cómo establecer la propiedad de transparencia a cualquier forma de texto usando Aspose.Slides for PHP via Java. Para establecer la transparencia al texto, siga los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva.
3. Establezca el color de sombra.
4. Escriba la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # establecer transparencia al cero por ciento
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el espaciado de caracteres para el texto**
Aspose.Slides le permite establecer el espacio entre letras en un cuadro de texto. De esta forma, puede ajustar la densidad visual de una línea o bloque de texto expandiendo o condensando el espaciado entre caracteres.

Este código PHP muestra cómo expandir el espaciado para una línea de texto y condensar el espaciado para otra línea:
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// expandir

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// condensar

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **Administrar propiedades de fuente de un párrafo**
Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas, o para cumplir con los estilos corporativos. El formato de texto ayuda a los usuarios a variar la apariencia del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides for PHP via Java para configurar las propiedades de fuente de los párrafos de texto en diapositivas. Para administrar las propiedades de fuente de un párrafo usando Aspose.Slides for PHP via Java:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Acceda a las formas Placeholder en la diapositiva y convíertalas a [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
4. Obtenga el [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) del [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) expuesto por [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. Justifique el párrafo.
6. Acceda al Portion de texto de un Paragraph.
7. Defina la fuente usando FontData y establezca la Fuente del Portion de texto en consecuencia.
   1. Establezca la fuente en negrita.
   2. Establezca la fuente en cursiva.
8. Establezca el color de la fuente usando el [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) expuesto por el objeto [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. Escriba la presentación modificada a un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

```php
  # Instanciar un objeto Presentation que representa un archivo PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Accediendo a una diapositiva usando su posición
    $slide = $pres->getSlides()->get_Item(0);
    # Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo a AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Accediendo al primer párrafo
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Accediendo a la primera porción
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definir nuevas tipografías
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Asignar nuevas tipografías a la porción
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


## **Administrar la familia de fuentes del texto**
Un Portion se usa para contener texto con estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides for PHP via Java para crear un cuadro de texto con algún texto y luego definir una fuente particular, y varias otras propiedades de la categoría de familia de fuentes. Para crear un cuadro de texto y establecer propiedades de fuente del texto en él:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Agregue un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) del tipo [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
4. Elimine el estilo de relleno asociado con el [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. Acceda al TextFrame del AutoShape.
6. Agregue algo de texto al TextFrame.
7. Acceda al objeto Portion asociado con el [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
8. Defina la fuente que se usará para el [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. Establezca otras propiedades de fuente como negrita, cursiva, subrayado, color y altura usando las propiedades relevantes expuestas por el objeto Portion.
10. Escriba la presentación modificada como un archivo PPTX.

```php
  # Instanciar Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar un AutoShape de tipo Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Eliminar cualquier estilo de relleno asociado al AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Acceder al TextFrame asociado al AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Acceder a la Portion asociada al TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Establecer la fuente para la Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Establecer la propiedad Bold de la fuente
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Establecer la propiedad Italic de la fuente
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Establecer la propiedad Underline de la fuente
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


## **Establecer rotación del texto**
Aspose.Slides for PHP via Java permite a los desarrolladores rotar el texto. El texto puede configurarse para aparecer como [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) o [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Para rotar el texto de cualquier TextFrame, siga los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Agregue cualquier Forma a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Gire el texto](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Guarde el archivo en disco.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir un AutoShape de tipo Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Añadir TextFrame al Rectángulo
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accediendo al marco de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Crear el objeto Paragraph para el marco de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear objeto Portion para el párrafo
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
Aspose.Slides for PHP via Java ahora soporta establecer ángulo de rotación personalizado para textframe. En este tema, veremos con ejemplo cómo establecer la propiedad RotationAngle en Aspose.Slides. Los nuevos métodos [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) y [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) se han añadido a las interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) y [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat), lo que permite establecer el ángulo de rotación personalizado para textframe. Para establecer RotationAngle, siga los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Agregue un gráfico en la diapositiva.
3. [Establezca la propiedad RotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Escriba la presentación como un archivo PPTX.

En el ejemplo siguiente, establecemos la propiedad RotationAngle.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar un AutoShape de tipo Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Agregar TextFrame al Rectángulo
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accediendo al marco de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Crear el objeto Paragraph para el marco de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear objeto Portion para el párrafo
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


## **Espaciado de línea de un párrafo**
Aspose.Slides proporciona propiedades bajo [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` y `SpaceWithin`—que le permiten gestionar el espaciado de línea para un párrafo. Las tres propiedades se usan de la siguiente manera:

* Para especificar el espaciado de línea para un párrafo en porcentaje, use un valor positivo. 
* Para especificar el espaciado de línea para un párrafo en puntos, use un valor negativo.

Por ejemplo, puede aplicar un espaciado de línea de 16 pt a un párrafo estableciendo la propiedad `SpaceBefore` en -16.

Los pasos son:

1. Cargue una presentación que contenga un AutoShape con algún texto.
2. Obtenga la referencia de una diapositiva a través de su índice.
3. Acceda al TextFrame.
4. Acceda al Paragraph.
5. Establezca las propiedades del Paragraph.
6. Guarde la presentación.

Este código PHP muestra cómo especificar el espaciado de línea para un párrafo:
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Obtener una referencia a la diapositiva por su índice
    $sld = $pres->getSlides()->get_Item(0);
    # Acceder al TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Acceder al Paragraph
    $para = $tf1->getParagraphs()->get_Item(0);
    # Establecer propiedades del Paragraph
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
En este tema, exploraremos las diferentes propiedades de formato de un marco de texto. Este artículo cubre cómo establecer la propiedad AutofitType de un marco de texto, ancla del texto y rotar el texto en la presentación. Aspose.Slides for PHP via Java permite a los desarrolladores establecer la propiedad AutofitType de cualquier marco de texto. AutofitType puede establecerse en [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) o [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape). Si se establece en [Normal], la forma permanecerá igual mientras el texto se ajusta sin cambiar la forma, mientras que si se establece en [Shape], la forma se modificará de modo que solo contenga el texto necesario. Para establecer la propiedad AutofitType de un marco de texto, siga los pasos a continuación:

1. Crea una instancia de la clase [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Acceda a la primera diapositiva.
3. Agregue cualquier forma a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Establezca el AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) del TextFrame.
6. Guarde el archivo en disco.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Acceder a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar un AutoShape de tipo Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Agregar TextFrame al Rectángulo
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accediendo al marco de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Crear el objeto Paragraph para el marco de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear objeto Portion para el párrafo
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


## **Establecer el ancla de un TextFrame**
Aspose.Slides for PHP via Java permite a los desarrolladores establecer el ancla de cualquier TextFrame. TextAnchorType especifica dónde se coloca el texto en la forma. AnchorType puede establecerse en [Top](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) o [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed). Para establecer el ancla de cualquier TextFrame, siga los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Agregue cualquier forma a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Establezca TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) del TextFrame.
6. Guarde el archivo en disco.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar un AutoShape del tipo Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Agregar TextFrame al Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accediendo al TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Crear el objeto Paragraph para el TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear objeto Portion para el párrafo
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
|**Figura: 2 Tabulaciones explícitas y 2 Tabulaciones predeterminadas**|

- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La colección EffectiveTabs incluye todas las tabulaciones (de la colección Tabs y las tabulaciones predeterminadas).
- EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) muestra la distancia entre las tabulaciones predeterminadas (3 y 4 en nuestro ejemplo).
- EffectiveTabs.GetTabByIndex(index) con index = 0 devolverá la primera tabulación explícita (Position = 731), index = 1 – segunda tabulación (Position = 1241). Si intentas obtener la siguiente tabulación con index = 2 devolverá la primera tabulación predeterminada (Position = 1470) y así sucesivamente.
- EffectiveTabs.GetTabAfterPosition(pos) se usa para obtener la siguiente tabulación después de cierto texto. Por ejemplo, tienes el texto: "Hello World!". Para renderizar ese texto debes saber dónde empezar a dibujar "world!". Primero, calcula la longitud de "Hello" en píxeles y llama a GetTabAfterPosition con ese valor. Obtendrás la posición de la siguiente tabulación para dibujar "world!".

## **Extraer texto con el efecto Todo en mayúsculas**
En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva incluso cuando fue escrito originalmente en minúsculas. Cuando recuperas una porción de texto con Aspose.Slides, la biblioteca devuelve el texto exactamente como se ingresó. Para manejar esto, revise [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/)—si indica `All`, simplemente convierta la cadena devuelta a mayúsculas para que su salida coincida con lo que los usuarios ven en la diapositiva.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![The All Caps effect](all_caps_effect.png)

El ejemplo de código a continuación muestra cómo extraer el texto con el efecto **All Caps** aplicado:
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
**¿Cómo modificar texto en una tabla en una diapositiva?**

Para modificar texto en una tabla en una diapositiva, necesita usar la clase [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Puede iterar a través de todas las celdas de la tabla y cambiar el texto en cada celda accediendo a sus propiedades `TextFrame` y `ParagraphFormat` dentro de cada celda.

**¿Cómo aplicar color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar color degradado al texto, use el método `getFillFormat` en [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/). Establezca el `FilFormat` a `Gradient`, donde puede definir los colores de inicio y fin del degradado, junto con otras propiedades como dirección y transparencia para crear el efecto degradado en el texto.