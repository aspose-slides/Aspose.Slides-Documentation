---
title: Buscar y reemplazar texto en presentaciones de PowerPoint en Java
linktitle: Buscar y reemplazar texto
type: docs
weight: 55
url: /es/java/search-and-replace-text/
keywords:
- buscar texto
- resaltar texto
- reemplazar texto
- expresión regular
- devolución de resultados
- marco de texto
- informe de auditoría
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones de PowerPoint mientras se recopila cada coincidencia con Aspose.Slides para Java."
---
## **Visión general**

Aspose.Slides for Java puede buscar, resaltar y reemplazar texto en un marco de texto individual o en toda una presentación. Cada operación también puede notificar a una aplicación sobre cada coincidencia mediante una devolución de resultados. Esto permite actualizar una presentación y, simultáneamente, crear un registro de auditoría que contiene el texto encontrado, su contexto, posición, marco de texto y número de diapositiva.

Estas capacidades son útiles para revisiones, redacciones, comprobaciones de terminología, limpieza de plantillas y flujos de trabajo de generación de informes automatizados.

En los primeros ejemplos a continuación, utilizamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente contenido:

![Texto de ejemplo](sample_text.png)

## **Elegir el ámbito de búsqueda**

Utilice los métodos de [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) para limitar una operación a un marco de texto. Utilice los métodos de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un marco de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [ITextFrame.highlightText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Resaltar coincidencias de expresión regular | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Reemplazar texto literal | [ITextFrame.replaceText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reemplazar coincidencias de expresión regular | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurar la coincidencia de texto**

Para operaciones de texto literal, utilice [TextSearchOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/) para controlar la coincidencia:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita las coincidencias a palabras completas.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controla si se debe respetar mayúsculas y minúsculas.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) incluye las notas de diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones de expresión regular utilizan un `Pattern` de Java, por lo que reglas como la sensibilidad a mayúsculas y los límites de palabra se definen en la propia expresión y sus banderas.

## **Recopilar información de coincidencias con una devolución de resultados**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifindresultcallback/) para recibir una notificación por cada coincidencia. Su método [IFindResultCallback.foundResult](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) proporciona el marco de texto relacionado, el texto origen, el texto encontrado y la posición de la coincidencia.

La devolución de resultados no recibe directamente el número de diapositiva. La implementación a continuación lo obtiene a partir de la diapositiva padre y también gestiona el texto encontrado en notas de diapositiva. Un `Integer` nullable permite que el mismo modelo de resultados represente texto asociado a otros tipos de diapositiva.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

Para operaciones de reemplazo, `foundText` contiene el texto original encontrado, de modo que la devolución de resultados puede registrar exactamente qué términos fueron sustituidos.

## **Resaltar texto**

Utilice el método [ITextFrame.highlightText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para resaltar coincidencias de texto literal en un marco de texto. Pase un [TextSearchOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/) para controlar la búsqueda y una devolución de resultados para recopilar los detalles de la coincidencia.

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**. Ambas búsquedas informan sus coincidencias a la misma devolución de resultados.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // Resaltar cada aparición de "try" en el marco de texto.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Resaltar solo la palabra completa "to".
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El texto resaltado](highlighted_text.png)

## **Resaltar texto usando expresiones regulares**

El método [ITextFrame.highlightRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) resalta coincidencias de texto encontradas mediante una expresión regular en un marco de texto.

El siguiente código resalta todas las palabras que contienen siete o más caracteres y recopila cada coincidencia:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El texto resaltado usando la expresión regular](highlighted_text_using_regex.png)

## **Resaltar texto en toda la presentación**

Utilice [Presentation.highlightText](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) y [Presentation.highlightRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) para buscar en todos los marcos de texto aplicables de una presentación. El ejemplo siguiente resalta un término literal y todas las direcciones de correo electrónico, manteniendo colecciones de resultados separadas para las dos búsquedas.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Reemplazar texto en un marco de texto**

Utilice [ITextFrame.replaceText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para texto literal y [ITextFrame.replaceRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para sustituciones basadas en patrones. Estos métodos actualizan el texto coincidente dentro del marco de texto existente, preservando el formato de las porciones circundantes en lugar de reconstruir el marco a partir de una cadena simple.

El siguiente ejemplo unifica una variante ortográfica y luego sustituye etiquetas de versión. La misma devolución de resultados registra los términos originales coincidentes en ambas operaciones.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si una coincidencia abarca porciones con formato diferente, revise la salida para confirmar qué formato debe aplicarse al texto sustituido.

## **Reemplazar texto en toda la presentación**

Utilice [Presentation.replaceText](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) y [Presentation.replaceRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para aplicar las mismas operaciones a lo largo de la presentación. Esto es útil para la limpieza de plantillas, actualizaciones de terminología y redacciones.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agrupar coincidencias para informes**

Dado que cada resultado almacena su número de diapositiva y marco de texto, las aplicaciones pueden agrupar las coincidencias para auditorías, informes o flujos de revisión. El siguiente ejemplo agrupa los resultados recopilados primero por diapositiva y luego por marco de texto:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **FAQ**

**¿Cómo puedo buscar solo en un cuadro de texto en lugar de en toda la presentación?**

Obtenga el marco de texto de la forma y llame a [ITextFrame.highlightText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), o [ITextFrame.replaceRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) en ese marco de texto. Los métodos a nivel de presentación procesan todos los marcos de texto aplicables.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Establezca [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) y [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) en `true`, y pase las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, defina los límites de palabra y la sensibilidad a mayúsculas en el propio `Pattern` de Java.

**¿La búsqueda y el reemplazo pueden incluir texto en notas de diapositiva?**

Sí. Establezca [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) en `true` al usar una operación de texto literal a nivel de presentación. La implementación de la devolución de resultados mostrada arriba asigna una coincidencia en una diapositiva de notas a su número de diapositiva padre.

**¿Cómo puedo crear un informe sin escanear la presentación una segunda vez?**

Pase una implementación de [IFindResultCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifindresultcallback/) a la operación de resaltado o reemplazo. La devolución de resultados recibe cada coincidencia mientras se ejecuta la operación, de modo que la aplicación puede almacenar el texto origen, el texto coincidido, la posición, el marco de texto y el número de diapositiva derivado para su posterior agrupación o exportación.

**¿El reemplazo de texto conserva su formato?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) y [ITextFrame.replaceRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifican el texto coincidente dentro del marco de texto existente y mantienen el formato de las porciones circundantes. Si una coincidencia abarca porciones con formato distinto, inspeccione el resultado para asegurarse de que el reemplazo utilice el estilo deseado.