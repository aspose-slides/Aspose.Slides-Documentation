---
title: Buscar y reemplazar texto en presentaciones de PowerPoint en JavaScript
linktitle: Buscar y reemplazar texto
type: docs
weight: 55
url: /es/nodejs-java/search-and-replace-text/
keywords:
- buscar texto
- resaltar texto
- reemplazar texto
- expresión regular
- callback de resultados
- marco de texto
- informe de auditoría
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones de PowerPoint mientras se recopila cada coincidencia con Aspose.Slides para Node.js vía Java."
---
## **Visión general**

Aspose.Slides for Node.js via Java puede buscar, resaltar y reemplazar texto en un marco de texto individual o en toda una presentación. Cada operación también puede notificar a una aplicación sobre cada coincidencia mediante una devolución de llamada de resultados. Esto permite actualizar una presentación y, simultáneamente, crear un registro de auditoría que contiene el texto coincidente, su contexto, posición, marco de texto y número de diapositiva.

Estas capacidades son útiles para revisiones, redacciones, comprobaciones de terminología, limpieza de plantillas y flujos de trabajo de generación de informes automáticos.

En los primeros ejemplos a continuación, utilizamos un archivo llamado **"sample.pptx"**, que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de ejemplo](sample_text.png)

## **Elegir el ámbito de búsqueda**

Utilice los métodos de [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) para limitar una operación a un marco de texto. Utilice los métodos de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un marco de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [TextFrame.highlightText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Resaltar coincidencias de expresiones regulares | [TextFrame.highlightRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Reemplazar texto literal | [TextFrame.replaceText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reemplazar coincidencias de expresiones regulares | [TextFrame.replaceRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurar la coincidencia de texto**

Para operaciones de texto literal, utilice [TextSearchOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textsearchoptions/) para controlar la coincidencia:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita las coincidencias a palabras completas.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controla si la distinción entre mayúsculas y minúsculas es obligatoria.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) incluye las notas de diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones basadas en expresiones regulares utilizan un `Pattern` de Java, por lo que reglas como la sensibilidad a mayúsculas y los límites de palabras se definen en la propia expresión y sus banderas.

## **Identificar al propietario de un marco de texto**

Los flujos de trabajo genéricos de procesamiento de texto a menudo reciben un [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) mientras buscan, reemplazan, validan o exportan texto. Utilice [TextFrame.getParentShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#getParentShape--) y [TextFrame.getParentCell](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#getParentCell--) para determinar qué objeto de la presentación es el propietario del marco de texto.

Los valores esperados dependen del propietario:

| Propietario del marco de texto | `getParentShape` | `getParentCell` |
|---|---|---|
| Una AutoShape u otra forma que contenga texto | La [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/) propietaria | `null` |
| Una celda de tabla | `null` | La [Cell](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/cell/) propietaria |

Ambos métodos ofrecen navegación de solo lectura. Llamarlos no mueve el marco de texto ni cambia su propietario. El código genérico debe comprobar ambos valores contra `null` y manejar la posibilidad de que ninguno de los propietarios esté disponible.

El siguiente ejemplo utiliza [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) para iterar a través de los marcos de texto de una presentación. Para las formas, informa del nombre de la forma, el tipo de tiempo de ejecución de Java y la diapositiva contenedora. Para las celdas de tabla, informa de las coordenadas de columna y fila basadas en cero y de la diapositiva contenedora.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Para el contenido de SmartArt, itere a través de las formas en [SmartArtNode.getShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartartnode/#getShapes--) y acceda a cada [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). El marco de texto puede rastrearse a su forma asociada mediante [TextFrame.getParentShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#getParentShape--), mientras que [TextFrame.getParentCell](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#getParentCell--) devuelve `null`. Por lo tanto, la rama de forma en el ejemplo también gestiona texto proveniente de nodos de SmartArt.

## **Recopilar información de coincidencias con una devolución de llamada**

Cree un proxy Java para la devolución de llamada de resultados y reciba una notificación por cada coincidencia. La función proxy recibe el marco de texto relacionado, el texto fuente, el texto coincidido y la posición de la coincidencia.

La devolución de llamada no recibe directamente un número de diapositiva. La implementación a continuación lo deriva mediante la forma o celda de tabla propietaria del marco de texto, con [TextFrame.getSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#getSlide--) como alternativa. También gestiona texto encontrado en notas de diapositiva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Para operaciones de reemplazo, `foundText` contiene el texto original coincidente, de modo que la devolución de llamada puede registrar exactamente qué términos fueron sustituidos.

## **Resaltar texto**

Utilice el método [TextFrame.highlightText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para resaltar coincidencias de texto literal en un marco de texto. Pase un [TextSearchOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textsearchoptions/) para controlar la búsqueda.

El ejemplo de código a continuación resalta todas las ocurrencias del carácter **"try"** y luego resalta solo la palabra completa **"to"**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Resaltar cada aparición de "try" en el marco de texto.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Resaltar solo la palabra completa "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El texto resaltado](highlighted_text.png)

## **Resaltar texto usando expresiones regulares**

El método [TextFrame.highlightRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) resalta coincidencias de texto encontradas mediante una expresión regular en un marco de texto.

El siguiente código resalta todas las palabras que contengan siete o más caracteres:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El texto resaltado usando la expresión regular](highlighted_text_using_regex.png)

## **Resaltar texto en toda la presentación**

Utilice [Presentation.highlightText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) y [Presentation.highlightRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) para buscar en todos los marcos de texto aplicables de una presentación. El ejemplo siguiente resalta un término literal y todas las direcciones de correo electrónico:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Reemplazar texto en un marco de texto**

Utilice [TextFrame.replaceText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para texto literal y [TextFrame.replaceRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para reemplazo basado en patrones. Estos métodos actualizan el texto coincidente dentro del marco de texto existente, conservando el formato de las porciones circundantes en lugar de reconstruir el marco de texto a partir de una cadena simple.

El siguiente ejemplo unifica una variante ortográfica y luego sustituye etiquetas de versión:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si una coincidencia abarca porciones con formato distinto, revise el resultado para confirmar qué formato debe aplicarse al texto de sustitución.

## **Reemplazar texto en toda la presentación**

Utilice [Presentation.replaceText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) y [Presentation.replaceRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para aplicar las mismas operaciones en toda la presentación. Esto es útil para la limpieza de plantillas, actualizaciones de terminología y redactado.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agrupar coincidencias para informes**

Dado que cada resultado recopilado guarda su número de diapositiva y marco de texto, las aplicaciones pueden agrupar coincidencias para auditorías, generación de informes o flujos de revisión. El siguiente ejemplo agrupa los resultados primero por diapositiva y luego por marco de texto:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Cómo puedo buscar solo en un cuadro de texto en lugar de en toda la presentación?**

Obtenga el marco de texto de la forma y llame a [TextFrame.highlightText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), o [TextFrame.replaceRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) en ese marco de texto. Los métodos a nivel de presentación procesan todos los marcos de texto aplicables.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Establezca [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) y [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) en `true`, y pase las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, defina los límites de palabra y la sensibilidad a mayúsculas en el propio `Pattern` de Java.

**¿Puede la búsqueda y el reemplazo incluir texto en las notas de diapositiva?**

Sí. Establezca [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) en `true` al usar una operación de texto literal a nivel de presentación. La implementación de la devolución de llamada mostrada arriba asigna una coincidencia en una nota a su diapositiva principal.

**¿Cómo puedo crear un informe sin volver a escanear la presentación?**

Pase un proxy de devolución de llamada de resultados Java a la operación de resaltado o reemplazo. La devolución de llamada recibe cada coincidencia mientras la operación se ejecuta, de modo que la aplicación puede almacenar el texto origen, el texto coincidido, la posición, el marco de texto y el número de diapositiva derivado para su posterior agrupación o exportación.

**¿El reemplazo de texto conserva su formato?**

[TextFrame.replaceText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) y [TextFrame.replaceRegex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifican el texto coincidido dentro del marco de texto existente y conservan el formato de las porciones circundantes. Si una coincidencia abarca porciones con formatos diferentes, inspeccione el resultado para asegurarse de que el reemplazo utiliza el estilo deseado.