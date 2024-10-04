---
title: Formateo de Texto
type: docs
weight: 50
url: /php-java/text-formatting/
---

## **Resaltar Texto**
El método [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) ha sido agregado a la interfaz [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Permite resaltar parte del texto con un color de fondo usando una muestra de texto, similar a la herramienta de Color de Resaltado de Texto en PowerPoint 2019.

El siguiente fragmento de código muestra cómo usar esta característica:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// resaltando todas las palabras 'importante'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// resaltando todas las ocurrencias separadas de 'el'

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Aspose proporciona un simple, [servicio de edición de PowerPoint en línea gratuito](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Resaltar Texto usando Expresión Regular**

El método [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) ha sido agregado a la interfaz [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Permite resaltar parte del texto con un color de fondo usando regex, similar a la herramienta de Color de Resaltado de Texto en PowerPoint 2019.

El siguiente fragmento de código muestra cómo usar esta característica:

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

## **Establecer Color de Fondo del Texto**

Aspose.Slides permite especificar el color preferido para el fondo de un texto.

Este código PHP muestra cómo establecer el color de fondo para un texto completo:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Negro");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Rojo ");
    $portion3 = new Portion("Negro");
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

Este código PHP muestra cómo establecer el color de fondo solo para una parte de un texto:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Negro");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Rojo ");
    $portion3 = new Portion("Negro");
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
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Rojo"))->findFirst();
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

## **Alinear Párrafos de Texto**

El formateo de texto es uno de los elementos clave al crear cualquier tipo de documentos o presentaciones. Sabemos que Aspose.Slides para PHP a través de Java admite agregar texto a las diapositivas, pero en este tema, veremos cómo podemos controlar la alineación de los párrafos de texto en una diapositiva. Siga los pasos a continuación para alinear los párrafos de texto usando Aspose.Slides para PHP a través de Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva utilizando su índice.
3. Acceda a las formas de marcador de posición presentes en la diapositiva y conviértalas en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. Obtenga el párrafo (que necesita ser alineado) del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) expuesto por [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Alinee el párrafo. Un párrafo puede alinearse a la derecha, a la izquierda, al centro y justificar.
6. Escriba la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se presenta a continuación.

```php
  # Instanciar un objeto de Presentación que representa un archivo PPTX
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo en AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Cambiar el texto en ambos marcadores de posición
    $tf1->setText("Alineación al Centro por Aspose");
    $tf2->setText("Alineación al Centro por Aspose");
    # Obtener el primer párrafo de los marcadores de posición
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Alineando el párrafo de texto al centro
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # Escribir la presentación como un archivo PPTX
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Transparencia para Texto**
Este artículo demuestra cómo establecer la propiedad de transparencia a cualquier forma de texto usando Aspose.Slides para PHP a través de Java. Para establecer la transparencia en el texto. Siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva.
3. Establezca el color de sombra.
4. Escriba la presentación como un archivo PPTX.

La implementación de los pasos anteriores se presenta a continuación.

```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - la transparencia es: " . $shadowColor->getAlpha() / 255.0 * 100);
    # establecer la transparencia al cero por ciento
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Espaciado de Caracteres para Texto**

Aspose.Slides permite establecer el espacio entre letras en un cuadro de texto. De esta manera, puede ajustar la densidad visual de una línea o bloque de texto expandiendo o condensando el espacio entre caracteres.

Este código PHP muestra cómo expandir el espaciado para una línea de texto y condensar el espaciado para otra línea:

```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// expandir

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// condensar

  $presentation->save("out.pptx", SaveFormat::Pptx);

```

## **Gestionar Propiedades de Fuente de Párrafo**

Las presentaciones generalmente contienen tanto texto como imágenes. El texto se puede formatear de varias maneras, ya sea para resaltar secciones y palabras específicas, o para conformarse a estilos corporativos. El formateo de texto ayuda a los usuarios a variar la apariencia del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para PHP a través de Java para configurar las propiedades de la fuente de los párrafos de texto en las diapositivas. Para gestionar las propiedades de fuente de un párrafo usando Aspose.Slides para PHP a través de Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga una referencia de la diapositiva usando su índice.
1. Acceda a las formas de marcador de posición en la diapositiva y conviértalas en [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Obtenga el [Párrafo](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) de la [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) expuesta por [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Justifique el párrafo.
1. Acceda a la porción de texto de un párrafo.
1. Defina la fuente usando FontData y establezca la fuente de la porción de texto en consecuencia.
   1. Establezca la fuente en negrita.
   1. Establezca la fuente en cursiva.
1. Establezca el color de fuente usando el [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) expuesto por el objeto [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
1. Escriba la presentación modificada en un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

La implementación de los pasos anteriores se presenta a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas.

```php
  # Instanciar un objeto de Presentación que representa un archivo PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Accediendo a una diapositiva usando su posición
    $slide = $pres->getSlides()->get_Item(0);
    # Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo en AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Accediendo al primer párrafo
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Accediendo a la primera porción
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definir nuevas fuentes
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Asignar nuevas fuentes a la porción
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Establecer fuente en Negrita
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Establecer fuente en Cursiva
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Establecer color de fuente
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Escribir el PPTX en disco
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gestionar Familia de Fuentes de Texto**
Una porción se utiliza para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para PHP a través de Java para crear un cuadro de texto con algo de texto y luego definir una fuente particular y varias otras propiedades de la categoría de familia de fuentes. Para crear un cuadro de texto y establecer las propiedades de fuente del texto en él:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva utilizando su índice.
3. Agregue un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) del tipo [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) a la diapositiva.
4. Elimine el estilo de relleno asociado con el [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. Acceda al TextFrame del AutoShape.
6. Agregue algo de texto al TextFrame.
7. Acceda al objeto Portion asociado con el [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
8. Defina la fuente que se utilizará para la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. Establezca otras propiedades de fuente como negrita, cursiva, subrayado, color y altura usando las propiedades relevantes expuestas por el objeto Portion.
10. Escriba la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se presenta a continuación.

```php
  # Instanciar Presentación
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar un AutoShape de tipo Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Eliminar cualquier estilo de relleno asociado con el AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Acceder al TextFrame asociado con el AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Cuadro de Texto de Aspose");
    # Acceder a la Porción asociada con el TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Establecer la Fuente para la Porción
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Establecer propiedad Negrita de la Fuente
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Establecer propiedad Cursiva de la Fuente
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Establecer propiedad Subrayado de la Fuente
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Establecer la Altura de la Fuente
    $port->getPortionFormat()->setFontHeight(25);
    # Establecer el color de la Fuente
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Escribir el PPTX en disco
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Tamaño de Fuente para Texto**

Aspose.Slides permite elegir el tamaño de fuente preferido para el texto existente en un párrafo y otros textos que pueden agregarse al párrafo más adelante.

Este código PHP muestra cómo establecer el tamaño de la fuente para los textos contenidos en un párrafo:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Obtener la primera forma, por ejemplo.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Obtener el primer párrafo, por ejemplo.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Establecer el tamaño de fuente predeterminado en 20 pt para todas las porciones de texto en el párrafo.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # Establecer el tamaño de fuente en 20 pt para las porciones de texto actuales en el párrafo.
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

## **Establecer Rotación de Texto**

Aspose.Slides para PHP a través de Java permite a los desarrolladores rotar el texto. El texto puede configurarse para aparecer como [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) o [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Para rotar el texto de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Agregue cualquier forma a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Rote el texto](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Guarde el archivo en el disco.

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
    # Accediendo al cuadro de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Crear el objeto Párrafo para el cuadro de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear objeto Porción para el párrafo
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Un rápido zorro marrón salta sobre el perro perezoso. Un rápido zorro marrón salta sobre el perro perezoso.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Guardar Presentación
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Ángulo de Rotación Personalizado para TextFrame**
Aspose.Slides para PHP a través de Java ahora admite establecer un ángulo de rotación personalizado para el textframe. En este tema, veremos un ejemplo de cómo establecer la propiedad RotationAngle en Aspose.Slides. Se han agregado los nuevos métodos [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) y [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) a las interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) y [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat), lo que permite establecer el ángulo de rotación personalizado para el textframe. Para establecer el RotationAngle, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Agregue un gráfico en la diapositiva.
3. [Establecer la propiedad RotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Escriba la presentación como un archivo PPTX.

En el ejemplo dado a continuación, establecemos la propiedad RotationAngle.

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
    # Accediendo al cuadro de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Crear el objeto Párrafo para el cuadro de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear objeto Porción para el párrafo
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Ejemplo de rotación de texto.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Guardar Presentación
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Espaciado de Línea de Párrafo**
Aspose.Slides proporciona propiedades bajo [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` y `SpaceWithin`—que le permiten gestionar el espaciado de línea para un párrafo. Las tres propiedades se utilizan de la siguiente manera:

* Para especificar el espaciado de línea para un párrafo en porcentaje, use un valor positivo. 
* Para especificar el espaciado de línea para un párrafo en puntos, use un valor negativo.

Por ejemplo, puede aplicar un espaciado de línea de 16pt para un párrafo estableciendo la propiedad `SpaceBefore` en -16.

Así es como especifica el espaciado de línea para un párrafo específico:

1. Cargue una presentación que contenga un AutoShape con algo de texto en él.
2. Obtenga la referencia de una diapositiva a través de su índice.
3. Acceda al TextFrame.
4. Acceda al Párrafo.
5. Establezca las propiedades del Párrafo.
6. Guarde la presentación.

Este código PHP muestra cómo especificar el espaciado de línea para un párrafo:

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Obtener la referencia de una diapositiva por su índice
    $sld = $pres->getSlides()->get_Item(0);
    # Acceder al TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Acceder al Párrafo
    $para = $tf1->getParagraphs()->get_Item(0);
    # Establecer propiedades del Párrafo
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # Guardar Presentación
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer la Propiedad AutofitType para TextFrame**
En este tema, exploraremos las diferentes propiedades de formato del cuadro de texto. Este artículo cubre cómo establecer la propiedad AutofitType del cuadro de texto, anclar el texto y rotar el texto en la presentación. Aspose.Slides para PHP a través de Java permite a los desarrolladores establecer la propiedad AutofitType de cualquier cuadro de texto. AutofitType puede establecerse en [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) o [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape). Si se establece en [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal), entonces la forma permanecerá igual, mientras que el texto se ajustará sin causar que la forma cambie, mientras que si AutofitType se establece en [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape), entonces la forma se modificará de tal manera que solo se contenga el texto requerido. Para establecer la propiedad AutofitType de un cuadro de texto, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Agregue cualquier forma a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Establezca el AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) del TextFrame.
6. Guarde el archivo en el disco.

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
    # Accediendo al cuadro de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Crear el objeto Párrafo para el cuadro de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear objeto Porción para el párrafo
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Un rápido zorro marrón salta sobre el perro perezoso. Un rápido zorro marrón salta sobre el perro perezoso.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Guardar Presentación
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Anclaje de TextFrame**
Aspose.Slides para PHP a través de Java permite a los desarrolladores anclar cualquier TextFrame. TextAnchorType especifica dónde se coloca ese texto en la forma. El tipo de anclaje puede establecerse en [Superior](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top), [Centro](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center), [Inferior](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom), [Justificado](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) o [Distribuido](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed). Para establecer el anclaje de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Agregue cualquier forma a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Establezca el TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) del TextFrame.
6. Guarde el archivo en el disco.

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
    # Accediendo al cuadro de texto
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Crear el objeto Párrafo para el cuadro de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crear objeto Porción para el párrafo
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Un rápido zorro marrón salta sobre el perro perezoso. Un rápido zorro marrón salta sobre el perro perezoso.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Guardar Presentación
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tabs y EffectiveTabs en Presentación**
Todos los tabuladores de texto se dan en píxeles.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figura: 2 Tabulaciones Explícitas y 2 Tabulaciones Predeterminadas**|
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La colección EffectiveTabs incluye todas las tabulaciones (de la colección Tabs y las tabulaciones predeterminadas).
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La propiedad EffectiveTabs.DefaultTabSize (294) muestra la distancia entre las tabulaciones predeterminadas (3 y 4 en nuestro ejemplo).
- EffectiveTabs.GetTabByIndex(index) con index = 0 devolverá la primera tabulación explícita (Posición = 731), index = 1 - segunda tabulación (Posición = 1241). Si intenta obtener la siguiente tabulación con index = 2, devolverá la primera tabulación predeterminada (Posición = 1470), etc.
- EffectiveTabs.GetTabAfterPosition(pos) se utiliza para obtener la siguiente tabulación después de algún texto. Por ejemplo, tiene el texto: "¡Hola Mundo!". Para renderizar dicho texto, debe saber dónde comenzar a dibujar "mundo!". Primero, debe calcular la longitud de "Hola" en píxeles y llamar a GetTabAfterPosition con este valor. Obtendrá la próxima posición de tabulación para dibujar "mundo!".
