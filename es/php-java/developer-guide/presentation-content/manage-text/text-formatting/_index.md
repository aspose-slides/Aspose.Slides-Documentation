---
title: Formatear texto de presentación en PHP
linktitle: Formato de texto
type: docs
weight: 50
url: /es/php-java/text-formatting/
keywords:
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia de texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuente
- rotación de texto
- ángulo de rotación
- marco de texto
- espaciado de línea
- propiedad de ajuste automático
- anclaje de marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Formatee y aplique estilo al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java. Personalice fuentes, colores, alineación y más."
---
## **Visión general**

Este artículo muestra cómo dar formato al texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java. Cubre colores de fondo, transparencia, espaciado de caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de ajuste automático, anclaje de texto, tabuladores y configuración de idioma.

A menos que se indique lo contrario, los ejemplos utilizan [sample.pptx](sample.pptx). La primera forma en su primera diapositiva es un cuadro de texto, y su primer párrafo contiene el texto que se muestra a continuación. Tanto los índices de diapositiva como los de forma son basados en cero. Los ejemplos que seleccionan porciones en negrita usan formato efectivo, incluido el formato de negrita heredado:

![Texto de ejemplo](sample_text.png)

Para buscar y resaltar texto literal o coincidencias de expresiones regulares, vea [Search and Replace Text](/slides/es/php-java/search-and-replace-text/).

## **Establecer color de fondo del texto**

Utilice [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) para establecer el color de resaltado predeterminado de un párrafo, o utilice [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) para porciones de texto individuales.

El siguiente ejemplo establece un resaltado gris claro como predeterminado para el primer párrafo. Los colores de resaltado explícitos en porciones individuales tienen prioridad sobre este valor predeterminado:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Establecer el color de resaltado para todo el párrafo.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![El párrafo gris](gray_paragraph.png)

El siguiente ejemplo de código muestra cómo establecer el color de fondo para **porciones de texto con una fuente en negrita**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Establecer el color de resaltado para la porción de texto.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![Las porciones de texto gris](gray_text_portions.png)

## **Alinear párrafos de texto**

Utilice [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) para establecer la alineación del párrafo dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, alineado a la derecha, justificado, etc.

El siguiente ejemplo de código muestra cómo alinear el párrafo al **centro**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Establecer la alineación del párrafo al centro.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![El párrafo alineado](aligned_paragraph.png)

## **Alinear fuentes dentro de una línea**

Utilice [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) para alinear verticalmente porciones de texto con diferentes tamaños de fuente dentro de una línea. Esta configuración se aplica a todo el párrafo y controla la alineación dentro de cada una de sus líneas.

El siguiente ejemplo independiente crea cuatro cuadros de texto etiquetados en una diapositiva. Cada párrafo contiene el mismo texto en 18, 36 y 54 puntos, con una alineación de fuente diferente. Utiliza Arial, desactiva el ajuste automático y el ajuste de línea, y mantiene los marcos de texto lo suficientemente grandes para una sola línea.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![Comparación de alineación de fuente Baseline, Top, Center y Bottom con tamaños de fuente mixtos](font_alignment.png)

La alineación de fuentes utiliza métricas tipográficas, por lo que los bordes visibles de letras individuales no siempre coinciden exactamente. El ejemplo incluye una letra mayúscula y un descendente para ayudar a mostrar la diferencia entre la alineación de línea base y la alineación inferior. La disponibilidad y sustitución de fuentes, los caracteres usados y la diferencia de tamaños de fuente influyen en el resultado. Las dimensiones del marco, márgenes, espaciado de línea, ajuste de texto y ajuste automático también afectan al diseño; utilice las mismas fuentes y configuraciones de diseño al comparar modos.

Esta configuración difiere de [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), que controla la alineación horizontal del párrafo, y de [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), que posiciona el bloque de texto verticalmente dentro de su forma. El formato de superíndice y subíndice mediante [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) desplaza las porciones individuales con respecto a la línea base en lugar de establecer la alineación de fuente para las líneas del párrafo.

## **Establecer transparencia del texto**

La transparencia del texto se controla mediante el componente alfa del color asignado a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). En los ejemplos siguientes, `alpha = 50` es un valor de canal alfa ARGB en la escala 0–255, no un porcentaje de transparencia.

El siguiente ejemplo de código muestra cómo aplicar transparencia al **párrafo completo**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Establecer el color de relleno del texto a un color transparente.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![El párrafo transparente](transparent_paragraph.png)

El siguiente ejemplo de código muestra cómo aplicar transparencia a **porciones de texto con una fuente en negrita**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Establecer la transparencia de la porción de texto.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![Las porciones de texto transparentes](transparent_text_portions.png)

## **Establecer espaciado de caracteres del texto**

Utilice [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) para ampliar o condensar el espaciado entre caracteres en un cuadro de texto. Los ejemplos añaden 3 puntos de espaciado; los valores negativos condensan el texto.

El siguiente código PHP muestra cómo ampliar el espaciado de caracteres en el **párrafo completo**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Nota: Use valores negativos para comprimir el espaciado de caracteres.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Expandir el espaciado de caracteres.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![El espaciado de caracteres en el párrafo](character_spacing_in_paragraph.png)

El siguiente ejemplo de código muestra cómo ampliar el espaciado de caracteres en **porciones de texto con una fuente en negrita**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Nota: Use valores negativos para comprimir el espaciado de caracteres.
            $portion->getPortionFormat()->setSpacing(3); // Expandir el espaciado de caracteres.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![El espaciado de caracteres en las porciones de texto](character_spacing_in_text_portions.png)

### **Desactivar kerning para fuentes específicas**

En algunos casos, el texto renderizado por Aspose.Slides puede parecer ligeramente más ajustado que el mismo texto mostrado en PowerPoint. Esto puede ocurrir porque PowerPoint puede ignorar los datos de kerning para ciertas fuentes, incluso cuando la fuente contiene información de kerning válida y el kerning está habilitado en la configuración de PowerPoint.

Para que la salida renderizada se acerque a PowerPoint en esos casos, puede desactivar el kerning para las porciones de texto que usan la fuente afectada. Establezca [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) a un valor mayor que el tamaño real de la fuente. Este ejemplo requiere “presentation.pptx” con un cuadro de texto como primera forma en la primera diapositiva. Comprueba los nombres de fuentes efectivos, incluidas las fuentes heredadas, y establece un umbral de 100 puntos para las porciones que usan Roboto. Esto desactiva el kerning para las porciones coincidentes con un tamaño de fuente inferior a 100 puntos:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para el texto coincidente por debajo del umbral, esta configuración evita el kerning y puede ayudar a alinear la representación de Aspose.Slides con la salida visual de PowerPoint para fuentes afectadas por este comportamiento específico de PowerPoint.

## **Gestionar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o en porciones individuales mediante [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

El siguiente ejemplo establece la fuente predeterminada del primer párrafo en Times New Roman 12 puntos con negrita, cursiva y subrayado punteado. El formato explícito de las porciones individuales tiene prioridad sobre estos valores predeterminados.

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Establecer las propiedades de fuente del párrafo.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![Las propiedades de fuente del párrafo](font_properties_for_paragraph.png)

El siguiente ejemplo aplica Times New Roman 13 puntos, formato en cursiva y subrayado punteado a las porciones cuyo formato efectivo es negrita:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Establecer las propiedades de fuente para la porción de texto.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![Las propiedades de fuente de las porciones de texto](font_properties_for_text_portions.png)

## **Controlar la normalización de la altura del texto**

Utilice [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) al reproducir la tipografía de una plantilla o investigar diferencias en la altura de los caracteres. En PowerPoint, activar la normalización estira o comprime verticalmente los caracteres individuales para darles una altura visible uniforme dentro de la porción de texto. No garantiza alturas iguales entre diferentes fuentes.

Establezca la propiedad en [NullableBool::True or False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) para habilitar o desactivar explícitamente la normalización. `NullableBool::NotDefined` deja la configuración local sin definir, de modo que la porción hereda su valor, por ejemplo, del [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) del párrafo. No equivale a `False`. Use [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) y lea `getNormaliseHeight` en los datos de formato efectivo devueltos para obtener el valor booleano resuelto.

El siguiente ejemplo independiente requiere que **Arial** esté instalado. Crea dos bloques de texto que contienen las mismas letras mayúsculas, minúsculas, descendentes y caracteres acentuados a 54 puntos. Ambos párrafos habilitan la normalización por defecto. La porción superior la desactiva explícitamente; la inferior la hereda. Los tamaños de los marcos, márgenes y espaciado de párrafos son idénticos, con ajuste de línea y autofit desactivados para mantener la comparación consistente. El ejemplo imprime `False: false` y `NotDefined: true`, luego guarda “text_height_normalization.pptx”.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La comparación a continuación se exportó de la presentación guardada. La fila superior tiene la normalización desactivada (`False`); la fila inferior la hereda (`NotDefined` → `True`). Mantenga Arial instalado para reproducir esta apariencia.

![Texto Arial de 54 puntos con normalización desactivada arriba y normalización heredada activada abajo](text_height_normalization.png)

La normalización altera la altura de los caracteres sin cambiar el valor asignado de [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight), que especifica el tamaño de la fuente en puntos. El método [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) del párrafo controla el espaciado entre líneas, mientras que [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) del marco de texto controla cómo el texto o su contenedor se ajustan. Estas configuraciones sirven a propósitos diferentes y pueden afectar el diseño general de forma independiente. Para más información sobre el formato de párrafos y la herencia, vea [Manage Paragraph](/slides/es/php-java/manage-paragraph/).

## **Aplicar y eliminar tachado**

Utilice [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) en una porción de texto para mostrar correcciones, términos cancelados o precios anteriores sin eliminar el texto original. Establézcalo en [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) para una o dos líneas a través del texto.

Para eliminar el tachado, pase [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None). Esto desactiva explícitamente el efecto, incluso si el formato circundante especifica tachado. Por el contrario, [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) deja sin definir la configuración local, permitiendo que la porción herede el formato, por ejemplo, del párrafo. No garantiza que el tachado se elimine. Use [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) para leer el formato resultante, incluidos los valores heredados.

El siguiente ejemplo independiente crea tres comparaciones de precios. Cada párrafo tiene porciones separadas para la etiqueta, el precio anterior y el precio actual, de modo que solo el precio anterior se ve afectado. La primera fila aplica y luego elimina el tachado; las demás filas conservan el tachado simple y doble. Cambiar esta configuración conserva el texto y su resto de formato, incluida la negrita del precio anterior.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // Aplicar tachado, luego eliminarlo explícitamente del primer precio anterior.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado, de arriba a abajo: sin tachado, tachado simple y tachado doble.

![Precios anteriores sin tachado, con tachado simple y con tachado doble](strikethrough.png)

## **Establecer rotación del texto**

Utilice [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente ejemplo de código establece la orientación del texto en la forma a [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/), que rota el texto **90 grados en sentido antihorario**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![La rotación del texto](text_rotation.png)

## **Mostrar dígitos lado a lado en texto vertical**

Para mantener unidos dos dígitos en una etiqueta japonesa vertical, coloque ambos dígitos en una única porción de texto y llame a [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) sobre esa porción. El ejemplo usa [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) y MS Gothic de 40 puntos para ambas etiquetas. Solo el valor [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) pasado a la porción numérica difiere.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

En PowerPoint, la etiqueta izquierda (`True`) muestra los dígitos en posición vertical y uno al lado del otro entre 和 y 年. La etiqueta derecha (`False`) gira el par 90 grados en sentido horario. Los caracteres japoneses circundantes permanecen verticales en ambas etiquetas.

![Comparación en PowerPoint de etiquetas de fecha vertical con dígitos verticales a la izquierda y dígitos girados a la derecha.](vertical_date.png)

## **Establecer rotación personalizada para marcos de texto**

Utilice [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) para establecer un ángulo de rotación personalizado para un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

El siguiente ejemplo de código rota el marco de texto 3 grados en sentido horario dentro de la forma:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![La rotación de texto personalizada](custom_text_rotation.png)

## **Establecer espaciado de línea de los párrafos**

Aspose.Slides ofrece [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) y [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) para controlar el espaciado de los párrafos. Estas propiedades se usan así:

* Utilice un valor positivo para especificar el espaciado de línea como porcentaje de la altura de la línea.
* Utilice un valor negativo para especificar el espaciado de línea en puntos.

El siguiente ejemplo establece el espaciado dentro del primer párrafo en el 200 % de la altura de la línea (doble espaciado):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![El espaciado de línea dentro del párrafo](line_spacing.png)

## **Controlar el salto de línea**

Las reglas de salto de línea de los párrafos son útiles en bloques de texto estrechos y presentaciones que combinan texto latino y asiático oriental. Los siguientes métodos pertenecen a [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/), por lo que se aplican a todo el párrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) controla las reglas de salto de línea para texto latino. En texto mixto, cambiarlo también puede alterar dónde se ajusta el texto y la puntuación asiática oriental adyacentes.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controla las reglas de salto de línea para texto asiático oriental, incluidas las restricciones de caracteres al comienzo y al final de una línea.

Estas reglas no sustituyen a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText), que habilita el ajuste automático dentro de un marco de texto. Influyen en el diseño cuando ocurre el ajuste; no insertan caracteres de salto de línea. Un salto de línea explícito fuerza una nueva línea dentro del párrafo independientemente del ancho disponible.

El siguiente ejemplo independiente crea un bloque de texto estrecho que contiene texto chino y latino. Establece ambas opciones de salto de línea explícitamente y guarda “line_breaking.pptx”. Para experimentar con cualquiera de las reglas, cambie el valor correspondiente manteniendo la otra configuración fija. El ejemplo usa Arial de 24 puntos y SimSun con un ancho de marco de 160 puntos y márgenes horizontales del marco de texto a cero. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) se llama con [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) para que el tamaño del texto y las dimensiones del marco permanezcan fijos.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controlar puntuación colgante**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) permite que la puntuación elegible sobresalga más allá del borde derecho de la línea de texto en lugar de ocupar la siguiente línea. Se aplica a todo el párrafo y es diferente de una sangría colgante.

El siguiente ejemplo independiente habilita la puntuación colgante en un marco de texto de 100 puntos de ancho y guarda “hanging_punctuation.pptx”. Con Arial de 24 puntos y márgenes horizontales del marco de texto a cero, el punto final permanece después de “sentence” y se extiende más allá del borde derecho del texto. Establezca la propiedad a [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) para comparar: con estos ajustes, el punto ocupa una línea separada. El ajuste de línea está habilitado y el autofit está desactivado para mantener el ancho disponible fijo.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

No todas las marcas de puntuación pueden colgar. Las [condiciones de fuente y diseño descritas arriba](#control-line-breaking) también se aplican a esta comparación: cambiar la fuente, el ancho disponible, los márgenes o la configuración de autofit puede eliminar la diferencia visible.

## **Establecer tipo de ajuste automático para marcos de texto**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, se desborda o cambia de tamaño la forma automáticamente. El siguiente ejemplo configura la forma para redimensionarse y ajustarse al texto y guarda el resultado en “autofit_type.pptx”.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para contar líneas después del ajuste automático y ver cómo cambian el texto o el ancho de la forma, vea [Count Rendered Lines](/slides/es/php-java/manage-paragraph/). El recuento de líneas por sí solo no indica si el texto se desborda del contenedor.

## **Establecer anclaje de los marcos de texto**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo, en la parte superior, central o inferior. El siguiente ejemplo ancla el texto en la parte inferior de la primera forma y guarda el resultado en “text_anchor.pptx”.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer tabulación del texto**

Utilice [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) y [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) para configurar los tabuladores en un párrafo. El siguiente ejemplo establece el intervalo de tabulación predeterminado en 100 puntos y añade un tabulador alineado a la izquierda en 30 puntos. Estas configuraciones afectan al texto que contiene caracteres de tabulación.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![Los tabuladores del párrafo](paragraph_tabs.png)

## **Establecer idioma de corrección**

Aspose.Slides proporciona [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId), que permite establecer el idioma de corrección para una porción de texto. El idioma de corrección determina el idioma usado para la revisión ortográfica y gramatical en PowerPoint.

El siguiente ejemplo requiere “presentation.pptx” con un cuadro de texto como primera forma en la primera diapositiva y al menos un párrafo. Sustituye el contenido del primer párrafo por “1。”, establece SimSun como su fuente y asigna el idioma de corrección chino simplificado (`zh-CN`). Guarda el resultado en “proofing_language.pptx”:

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Establecer el Id de un idioma de corrección.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Copiar metadatos de idioma**

Al copiar texto multilingüe desde una plantilla, conserve tanto [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) como [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). El siguiente ejemplo independiente crea una porción fuente con inglés estadounidense como idioma y francés como idioma alternativo y copia el texto y los identificadores a una porción en una nueva presentación.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // Si la fuente no tiene idioma alternativo, null borra el valor del destino.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para probar una fuente sin idioma alternativo, omita la asignación de `"fr-FR"`. El identificador alternativo será entonces `null`, y la misma sentencia de copia preserva su ausencia sin introducir un valor predeterminado, aun si el destino ya tenía asignado un idioma alternativo.

Estos identificadores almacenan metadatos de idioma. Conservarlos no determina qué diccionario selecciona PowerPoint para la revisión ortográfica o gramatical.

## **Establecer idioma predeterminado**

Utilice [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para definir el idioma predeterminado del texto creado al cargar o crear una presentación. El siguiente ejemplo crea una presentación con inglés estadounidense como idioma predeterminado del texto, añade un cuadro de texto e imprime `en-US` para su primera porción de texto.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una nueva forma rectangular con texto.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Comprobar el idioma de la primera porción.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Establecer estilo de texto predeterminado**

Para aplicar formato de texto predeterminado a nivel de presentación, use [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

El siguiente ejemplo establece una fuente en negrita de 14 puntos como predeterminada para los párrafos de nivel superior en una nueva presentación y la guarda en “default_text_style.pptx”. El texto puede heredar estos valores predeterminados a menos que un formato más específico los sobrescriba.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Obtener el formato de párrafo de nivel superior.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionColor()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pp​​ ​  



```

## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque se haya escrito originalmente en minúsculas. Cuando recupera una porción de texto con Aspose.Slides, la biblioteca devuelve el texto exactamente como se introdujo. Para que coincida con el texto mostrado, compruebe [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `All`.

Este ejemplo requiere “sample2.pptx” con un cuadro de texto como primera forma en la primera diapositiva. Su primer párrafo contiene “Hello, Aspose!” con el efecto All Caps aplicado, como se muestra a continuación.

![El efecto All Caps](all_caps_effect.png)

El siguiente ejemplo de código muestra cómo extraer el texto con el efecto **All Caps** aplicado:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

## **FAQ**

**¿Cómo modifico el texto en una tabla de una diapositiva?**

Para modificar el texto en una tabla de una diapositiva, utilice [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Recorra las celdas y actualice cada celda mediante [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) y el formato de párrafo mediante [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**¿Cómo aplico un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, utilice [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Establezca [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) a [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) y configure las paradas de degradado, la dirección y la transparencia.