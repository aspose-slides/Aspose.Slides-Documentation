---
title: Buscar y reemplazar texto en presentaciones de PowerPoint en PHP
linktitle: Buscar y reemplazar texto
type: docs
weight: 55
url: /es/php-java/search-and-replace-text/
keywords:
- buscar texto
- resaltar texto
- reemplazar texto
- expresión regular
- devolución de llamada de resultados
- marco de texto
- informe de auditoría
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones de PowerPoint mientras se recoge cada coincidencia con Aspose.Slides para PHP a través de Java."
---
## **Descripción general**

Aspose.Slides for PHP via Java puede buscar, resaltar y reemplazar texto en un marco de texto individual o en toda una presentación. Cada operación también puede notificar a una aplicación sobre cada coincidencia mediante una devolución de llamada de resultados. Esto permite actualizar una presentación y, simultáneamente, construir un registro de auditoría que contenga el texto coincidente, su contexto, posición, marco de texto y número de diapositiva.

Estas capacidades son útiles para la revisión, la redacción, la verificación de terminología, la limpieza de plantillas y los flujos de trabajo de generación de informes automatizados.

En los primeros ejemplos a continuación, utilizamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de ejemplo](sample_text.png)

## **Elegir el alcance de búsqueda**

Utilice los métodos de [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) para limitar una operación a un solo marco de texto. Utilice los métodos de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un marco de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [TextFrame::highlightText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#highlightText) |
| Resaltar coincidencias de expresiones regulares | [TextFrame::highlightRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#highlightRegex) |
| Reemplazar texto literal | [TextFrame::replaceText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#replaceText) |
| Reemplazar coincidencias de expresiones regulares | [TextFrame::replaceRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#replaceRegex) |

## **Configurar la coincidencia de texto**

Para operaciones de texto literal, utilice [TextSearchOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/textsearchoptions/) para controlar la coincidencia:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/es/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) limita las coincidencias a palabras completas.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/es/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) controla si debe coincidir la capitalización de los caracteres.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/es/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) incluye las notas de diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones con expresiones regulares utilizan un `Pattern` de Java, por lo que reglas de coincidencia como la sensibilidad a mayúsculas y los límites de palabra se definen en la expresión y sus indicadores.

## **Recopilar información de coincidencias mediante una devolución de llamada**

Pase una devolución de llamada proxy de Java a un método de resaltado o reemplazo para recibir una notificación por cada coincidencia. El método de devolución de llamada recibe el marco de texto correspondiente, el texto fuente, el texto coincidente y la posición de la coincidencia.

La devolución de llamada no recibe directamente el número de diapositiva. La implementación a continuación lo deriva de la diapositiva principal y también gestiona el texto encontrado en las notas de diapositiva. La matriz de resultados utiliza `null` cuando el texto está asociado a otro tipo de diapositiva.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Cree un proxy para este objeto PHP antes de pasarlo a una operación:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Para las operaciones de reemplazo, `foundText` contiene el texto coincidente original, de modo que la devolución de llamada puede registrar exactamente qué términos fueron reemplazados.

## **Resaltar texto**

Utilice el método [TextFrame::highlightText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#highlightText) para resaltar coincidencias de texto literal en un marco de texto. Pase [TextSearchOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/textsearchoptions/) para controlar la búsqueda.

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Resaltar cada ocurrencia de "try" en el marco de texto.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Resaltar solo la palabra completa "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

El resultado:

![Texto resaltado](highlighted_text.png)

## **Resaltar texto usando expresiones regulares**

El método [TextFrame::highlightRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#highlightRegex) resalta las coincidencias de texto encontradas mediante una expresión regular en un marco de texto.

El siguiente código resalta todas las palabras que contienen siete o más caracteres:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

El resultado:

![Texto resaltado usando la expresión regular](highlighted_text_using_regex.png)

## **Resaltar texto en toda una presentación**

Utilice [Presentation::highlightText](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#highlightText) y [Presentation::highlightRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#highlightRegex) para buscar en todos los marcos de texto aplicables de una presentación. El siguiente ejemplo resalta un término literal y todas las direcciones de correo electrónico:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Reemplazar texto en un marco de texto**

Utilice [TextFrame::replaceText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#replaceText) para texto literal y [TextFrame::replaceRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#replaceRegex) para reemplazo basado en patrones. Estos métodos actualizan el texto coincidente dentro del marco de texto existente, que conserva el formato de la porción circundante en lugar de reconstruir el marco de texto a partir de una cadena simple.

El siguiente ejemplo normaliza una variante ortográfica y luego reemplaza etiquetas de versión:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Si una coincidencia abarca porciones con diferente formato, revise la salida para confirmar qué formato debe aplicarse al texto de reemplazo.

## **Reemplazar texto en toda una presentación**

Utilice [Presentation::replaceText](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#replaceText) y [Presentation::replaceRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#replaceRegex) para aplicar las mismas operaciones en toda la presentación. Esto es útil para la limpieza de plantillas, actualizaciones de terminología y redacción.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Agrupar coincidencias para informes**

Debido a que cada resultado almacena su número de diapositiva y marco de texto, las aplicaciones pueden agrupar las coincidencias para auditorías, informes o flujos de trabajo de revisión. El siguiente ejemplo agrupa los resultados recopilados primero por diapositiva y luego por marco de texto:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **Preguntas frecuentes**

**¿Cómo puedo buscar solo en un cuadro de texto en lugar de en toda la presentación?**

Obtenga el marco de texto de la forma y llame a [TextFrame::highlightText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#replaceText), o [TextFrame::replaceRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#replaceRegex) en ese marco de texto. Los métodos a nivel de presentación procesan todos los marcos de texto aplicables.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Establezca [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/es/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) y [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/es/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) a `true`, y pase las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, defina los límites de palabras y la sensibilidad a mayúsculas en el propio `Pattern` de Java.

**¿Puede la búsqueda y el reemplazo incluir texto en las notas de diapositiva?**

Sí. Establezca [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/es/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) a `true` al utilizar una operación de texto literal a nivel de presentación.

**¿Cómo puedo crear un informe sin escanear la presentación una segunda vez?**

Pase una devolución de llamada proxy de Java a la operación de resaltado o reemplazo. Recibe cada coincidencia mientras la operación se ejecuta, por lo que la aplicación puede almacenar el texto fuente, el texto coincidente, la posición, el marco de texto y el número de diapositiva derivado para agruparlo o exportarlo posteriormente.

**¿El reemplazo de texto conserva su formato?**

[TextFrame::replaceText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#replaceText) y [TextFrame::replaceRegex](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#replaceRegex) modifican el texto coincidente dentro del marco de texto existente y conservan el formato de la porción circundante. Si una coincidencia abarca porciones con diferente formato, inspeccione el resultado para asegurarse de que el reemplazo utilice el estilo deseado.