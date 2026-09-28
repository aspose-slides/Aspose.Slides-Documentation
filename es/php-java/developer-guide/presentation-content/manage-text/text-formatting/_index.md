---
title: Formato del texto de la presentación en PHP
linktitle: Formato de texto
type: docs
weight: 50
url: /es/php-java/text-formatting/
keywords:
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia del texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuente
- rotación del texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad de ajuste automático
- anclaje del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Formatea y da estilo al texto en presentaciones de PowerPoint y OpenDocument utilizando Aspose.Slides para PHP a través de Java. Personaliza fuentes, colores, alineación y más."
---
## **Visión general**

Este artículo muestra cómo formatear texto en presentaciones de PowerPoint y OpenDocument utilizando Aspose.Slides para PHP a través de Java. Cubre colores de fondo, transparencia, espaciado de caracteres, propiedades de fuente, rotación, espaciado de párrafos, comportamiento de ajuste automático, anclaje de texto, tabuladores y configuración de idioma.

A menos que se indique lo contrario, los ejemplos usan [sample.pptx](sample.pptx). La primera forma en su primera diapositiva es un cuadro de texto, y su primer párrafo contiene el texto que se muestra a continuación. Tanto los índices de diapositiva como de forma comienzan en cero. Los ejemplos que seleccionan porciones en negrita utilizan el formato efectivo, incluido el formato de negrita heredado:

![Texto de muestra](sample_text.png)

Para buscar y resaltar texto literal o coincidencias de expresiones regulares, consulte [Buscar y Reemplazar Texto](/slides/es/php-java/search-and-replace-text/).

## **Establecer color de fondo del texto**

Utilice [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) para establecer el color de resaltado predeterminado para un párrafo, o utilice [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#getHighlightColor) para porciones de texto individuales.

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

El siguiente fragmento de código muestra cómo establecer el color de fondo para **porciones de texto con una fuente en negrita**:

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

Utilice [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setAlignment) para establecer la alineación del párrafo dentro de un marco de texto. El valor puede ser centrado, alineado a la izquierda, alineado a la derecha, justificado, etc.

El siguiente fragmento de código muestra cómo alinear el párrafo al **centro**:

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

## **Establecer transparencia para el texto**

La transparencia del texto se controla mediante el componente alfa del color asignado a [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#getFillFormat). En los ejemplos siguientes, `alpha = 50` es un valor alfa ARGB en la escala 0–255, no un porcentaje de transparencia.

El siguiente fragmento de código muestra cómo aplicar transparencia al **párrafo completo**:

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

El siguiente fragmento de código muestra cómo aplicar transparencia a **porciones de texto con una fuente en negrita**:

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

![Las porciones de texto transparente](transparent_text_portions.png)

## **Establecer espaciado de caracteres para el texto**

Utilice [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setSpacing) para ampliar o reducir el espaciado entre caracteres en un cuadro de texto. Los ejemplos añaden 3 puntos de espaciado; los valores negativos reducen el texto.

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

El siguiente fragmento de código muestra cómo ampliar el espaciado de caracteres en **porciones de texto con una fuente en negrita**:

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

### **Desactivar el kerning para fuentes específicas**

En algunos casos, el texto renderizado por Aspose.Slides puede parecer ligeramente más compacto que el mismo texto mostrado en PowerPoint. Esto puede suceder porque PowerPoint puede ignorar los datos de kerning de ciertas fuentes, aun cuando la fuente contenga información de kerning válida y el kerning esté habilitado en la configuración de PowerPoint.

Para que la salida renderizada se acerque más a PowerPoint en esos casos, puede desactivar el kerning para las porciones de texto que usan la fuente afectada. Establezca [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) a un valor mayor que el tamaño real de la fuente. Este ejemplo requiere "presentation.pptx" con un cuadro de texto como primera forma en la primera diapositiva. Comprueba los nombres de fuente efectivos, incluidas las fuentes heredadas, y establece un umbral de 100 puntos para las porciones que usan Roboto. Esto desactiva el kerning para las porciones coincidentes con un tamaño de fuente inferior a 100 puntos:

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

Para el texto que coincide con el umbral, esta configuración evita el kerning y puede ayudar a alinear la representación de Aspose.Slides con la salida visual de PowerPoint para fuentes afectadas por este comportamiento específico de PowerPoint.

## **Gestionar propiedades de fuente del texto**

Las propiedades de fuente pueden establecerse a nivel de párrafo mediante [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o en porciones individuales mediante [PortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/portionformat/).

El siguiente ejemplo establece la fuente predeterminada del primer párrafo en Times New Roman de 12 puntos con negrita, cursiva y subrayado punteado. El formato explícito en porciones individuales tiene prioridad sobre estos valores predeterminados:

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

El siguiente ejemplo aplica Times New Roman de 13 puntos, formato cursiva y subrayado punteado a las porciones cuyo formato efectivo es negrita:

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

## **Establecer rotación del texto**

Utilice [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setTextVerticalType) para establecer una orientación de texto predefinida dentro de una forma.

El siguiente fragmento de código establece la orientación del texto en la forma a [TextVerticalType::Vertical270](https://reference.aspose.com/slides/es/php-java/aspose.slides/textverticaltype/), lo que rota el texto **90 grados en sentido antihorario**:

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

## **Establecer rotación personalizada para marcos de texto**

Utilice [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setRotationAngle) para definir un ángulo de rotación personalizado para un [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/).

El siguiente fragmento de código rota el marco de texto 3 grados en sentido horario dentro de la forma:

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

## **Establecer espaciado entre líneas de los párrafos**

Aspose.Slides proporciona [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setSpaceBefore) y [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setSpaceWithin) para controlar el espaciado de los párrafos. Estas propiedades se usan de la siguiente manera:

* Use un valor positivo para especificar el espaciado de línea como porcentaje de la altura de la línea.
* Use un valor negativo para especificar el espaciado de línea en puntos.

El siguiente ejemplo establece el espaciado dentro del primer párrafo en el 200 % de la altura de la línea (doble espacio):

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

Las reglas de salto de línea de los párrafos son útiles en bloques de texto estrechos y en presentaciones que mezclan texto latino y de Asia Oriental. Los siguientes métodos pertenecen a [ParagraphFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/), por lo que se aplican a un párrafo completo:

- [setLatinLineBreak](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) controla las reglas de salto de línea latinas. En texto mixto, cambiarlo también puede alterar dónde se ajusta el texto y la puntuación asiática adyacente.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controla las reglas de salto de línea de Asia Oriental, incluidas las restricciones de caracteres al principio y al final de una línea.

Estas reglas no sustituyen a [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setWrapText), que habilita el ajuste automático dentro de un marco de texto. Influyen en el diseño cuando ocurre el ajuste; no insertan caracteres de salto de línea. Un salto de línea explícito fuerza una nueva línea dentro del párrafo independientemente del ancho disponible.

El siguiente ejemplo autocontenido crea un bloque de texto estrecho que contiene chino y texto latino. Establece ambas opciones de salto de línea de forma explícita y guarda “line_breaking.pptx”. Para experimentar con cualquiera de las reglas, cambie el valor correspondiente manteniendo los demás ajustes fijos. El ejemplo usa Arial de 24 pt y SimSun con un ancho de marco de 160 pt y márgenes horizontales del marco en cero. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setAutofitType) se llama con [TextAutofitType::None](https://reference.aspose.com/slides/es/php-java/aspose.slides/textautofittype/) para que el tamaño del texto y las dimensiones del marco permanezcan fijos.

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

## **Controlar la puntuación colgante**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) permite que la puntuación elegible se extienda más allá del borde derecho de la línea de texto en lugar de ocupar la siguiente línea. Se aplica a todo el párrafo y es diferente de una sangría colgante.

El siguiente ejemplo autocontenido habilita la puntuación colgante en un marco de texto de 100 pt de ancho y guarda “hanging_punctuation.pptx”. Con Arial de 24 pt y márgenes horizontales del marco en cero, el punto final permanece después de “sentence” y se extiende más allá del borde derecho del texto. Establezca la propiedad a [NullableBool::False](https://reference.aspose.com/slides/es/php-java/aspose.slides/nullablebool/) para comparar: con estos ajustes, el punto ocupa una línea separada. El ajuste automático está habilitado y el autofit está desactivado para mantener fijo el ancho disponible.

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

No todas las marcas de puntuación pueden colgar. El resultado visible depende de la disponibilidad de la fuente y del diseño: cambiar la fuente, el ancho disponible, los márgenes o los ajustes de autofit puede eliminar la diferencia visible.

## **Establecer tipo de ajuste automático para marcos de texto**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setAutofitType) determina cómo se comporta el texto cuando supera los límites de su contenedor. Úselo para controlar si el texto se reduce, desborda o redimensiona la forma automáticamente. El siguiente ejemplo configura la forma para redimensionarse y ajustarse al texto y guarda el resultado en “autofit_type.pptx”.

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

Para contar líneas después del ajuste automático y ver cómo el ancho del texto o de la forma cambia el resultado, consulte [Count Rendered Lines](/slides/es/php-java/manage-paragraph/). El número de líneas por sí solo no indica si el texto desborda su contenedor.

## **Establecer anclaje de los marcos de texto**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setAnchoringType) define cómo se posiciona verticalmente el texto dentro de una forma, por ejemplo, en la parte superior, central o inferior. El siguiente ejemplo ancla el texto en la parte inferior de la primera forma y guarda el resultado en “text_anchor.pptx”.

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

Utilice [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) y [ParagraphFormat::getTabs](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#getTabs) para configurar los tabuladores en un párrafo. El siguiente ejemplo establece el intervalo de tabulación predeterminado en 100 pt y añade un tabulador alineado a la izquierda en 30 pt. Estos ajustes afectan al texto que contiene caracteres de tabulación.

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

## **Establecer idioma de revisión**

Aspose.Slides proporciona [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setLanguageId), que permite establecer el idioma de revisión para una porción de texto. El idioma de revisión determina el idioma utilizado para la corrección ortográfica y gramatical en PowerPoint.

El siguiente ejemplo requiere “presentation.pptx” con un cuadro de texto como primera forma en la primera diapositiva y al menos un párrafo. Reemplaza el contenido del primer párrafo con “1。”, establece SimSun como su fuente y asigna el idioma de revisión chino simplificado (`zh-CN`). Guarda el resultado en “proofing_language.pptx”:

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

    // Establecer el Id de un idioma de revisión.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer idioma predeterminado**

Utilice [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para definir el idioma predeterminado del texto creado al cargar o crear una presentación. El siguiente ejemplo crea una presentación con inglés de EE. UU. como idioma predeterminado del texto, añade un cuadro de texto y muestra `en-US` para su primera porción de texto.

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

Para aplicar el formato de texto predeterminado a nivel de presentación, utilice [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getDefaultTextStyle).

El siguiente ejemplo establece una fuente en negrita de 14 pt como predeterminada para los párrafos de nivel superior en una nueva presentación y la guarda en “default_text_style.pptx”. El texto puede heredar estos valores predeterminados a menos que un formato más específico los sobrescriba.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Obtener el formato del párrafo de nivel superior.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Extraer texto con el efecto de mayúsculas**

En PowerPoint, aplicar el efecto tipográfico **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando se recupera una porción de texto con Aspose.Slides, la biblioteca devuelve el texto exactamente como se ingresó. Para que coincida con el texto visualizado, verifique [TextCapType](https://reference.aspose.com/slides/es/php-java/aspose.slides/textcaptype/) y convierta la cadena devuelta a mayúsculas cuando el valor sea `All`.

Este ejemplo requiere “sample2.pptx” con un cuadro de texto como primera forma en la primera diapositiva. Su primer párrafo contiene “Hello, Aspose!” con el efecto All Caps aplicado, como se muestra a continuación.

![El efecto All Caps](all_caps_effect.png)

El fragmento de código a continuación muestra cómo extraer el texto con el efecto **All Caps** aplicado:

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

Para modificar el texto en una tabla de una diapositiva, utilice [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/table/). Recorrer las celdas y actualizar cada celda mediante [Cell::getTextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/cell/#getTextFrame) y el formato de párrafo mediante [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/#getParagraphFormat).

**¿Cómo aplico un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, utilice [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#getFillFormat). Establezca [FillFormat::setFillType](https://reference.aspose.com/slides/es/php-java/aspose.slides/fillformat/#setFillType) a [FillType::Gradient](https://reference.aspose.com/slides/es/php-java/aspose.slides/filltype/) y configure las paradas del degradado, la dirección y la transparencia.