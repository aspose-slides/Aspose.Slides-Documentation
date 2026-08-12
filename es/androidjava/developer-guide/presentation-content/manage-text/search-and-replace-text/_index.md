---
title: Buscar y reemplazar texto en presentaciones de PowerPoint en Android
linktitle: Buscar y reemplazar texto
type: docs
weight: 55
url: /es/androidjava/search-and-replace-text/
keywords:
- buscar texto
- resaltar texto
- reemplazar texto
- expresión regular
- callback de resultados
- cuadro de texto
- informe de auditoría
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones de PowerPoint mientras se recopila cada coincidencia con Aspose.Slides para Android mediante Java."
---
## **Descripción general**

Aspose.Slides for Android via Java puede buscar, resaltar y reemplazar texto en un cuadro de texto individual o en toda una presentación. Cada operación también puede notificar a una aplicación sobre cada coincidencia mediante un callback de resultados. Esto permite actualizar una presentación y, simultáneamente, crear un rastro de auditoría que contiene el texto coincidente, su contexto, posición, cuadro de texto y número de diapositiva.

Estas capacidades son útiles para revisiones, redactado, comprobaciones de terminología, limpieza de plantillas y flujos de trabajo de generación de informes automatizados.

En los primeros ejemplos a continuación, utilizamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Sample text](sample_text.png)

## **Elija el alcance de búsqueda**

Utilice los métodos de [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) para limitar una operación a un cuadro de texto. Utilice los métodos de [IPresentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un cuadro de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [ITextFrame.highlightText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Resaltar coincidencias de expresiones regulares | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Reemplazar texto literal | [ITextFrame.replaceText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reemplazar coincidencias de expresiones regulares | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configure la coincidencia de texto**

Para operaciones con texto literal, utilice [TextSearchOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textsearchoptions/) para controlar la coincidencia:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita las coincidencias a palabras completas.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controla si la capitalización de los caracteres debe coincidir.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) incluye notas de diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones con expresiones regulares utilizan un `Pattern` de Java, por lo que las reglas de coincidencia, como la distinción entre mayúsculas y minúsculas y los límites de palabra, se definen mediante la expresión y sus banderas.

## **Recopilar información de coincidencias con un callback**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifindresultcallback/) para recibir una notificación por cada coincidencia. Su método [IFindResultCallback.foundResult](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) proporciona el cuadro de texto relacionado, el texto fuente, el texto coincidente y la posición de la coincidencia.

El callback no recibe directamente el número de diapositiva. La implementación a continuación lo deriva de la diapositiva principal y también maneja el texto encontrado en las notas de la diapositiva. Un `Integer` anulable permite que el mismo modelo de resultado represente texto asociado a otros tipos de diapositiva.

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

Para las operaciones de reemplazo, `foundText` contiene el texto original coincidente, de modo que el callback puede registrar exactamente qué términos fueron reemplazados.

## **Resaltar texto**

Utilice el método [ITextFrame.highlightText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para resaltar coincidencias de texto literal en un cuadro de texto. Passe [TextSearchOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textsearchoptions/) para controlar la búsqueda y un callback para recopilar los detalles de la coincidencia.

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**. Ambas búsquedas informan sus coincidencias al mismo callback.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // Resaltar cada aparición de "try" en el cuadro de texto.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

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

![The highlighted text](highlighted_text.png)

## **Resaltar texto usando expresiones regulares**

El método [ITextFrame.highlightRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) resalta las coincidencias de texto encontradas mediante una expresión regular en un cuadro de texto.

El siguiente código resalta todas las palabras que contienen siete o más caracteres y recoge cada coincidencia:

```java
import com.aspose.slides.*;
import android.graphics.Color;
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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Resaltar texto en toda una presentación**

Utilice [IPresentation.highlightText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) y [IPresentation.highlightRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) para buscar en todos los cuadros de texto aplicables de una presentación. El ejemplo siguiente resalta un término literal y todas las direcciones de correo electrónico manteniendo colecciones de resultados independientes para ambas búsquedas.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

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

## **Reemplazar texto en un cuadro de texto**

Utilice [ITextFrame.replaceText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para texto literal y [ITextFrame.replaceRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para reemplazo basado en patrones. Estos métodos actualizan el texto coincidente dentro del cuadro de texto existente, lo que conserva el formato de la porción circundante en lugar de reconstruir el cuadro de texto a partir de una cadena simple.

El siguiente ejemplo normaliza una variante ortográfica y luego reemplaza las etiquetas de versión. El mismo callback registra los términos originales coincidentes en ambas operaciones.

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

Si una coincidencia abarca porciones con formato diferente, revise la salida para confirmar qué formato debe aplicarse al texto de reemplazo.

## **Reemplazar texto en toda una presentación**

Utilice [IPresentation.replaceText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) y [IPresentation.replaceRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) para aplicar las mismas operaciones en toda la presentación. Esto es útil para la limpieza de plantillas, actualizaciones de terminología y redactado.

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

Porque cada resultado almacena su número de diapositiva y cuadro de texto, las aplicaciones pueden agrupar coincidencias para auditorías, informes o flujos de revisión. El siguiente ejemplo agrupa los resultados recogidos primero por diapositiva y luego por cuadro de texto:

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

## **Preguntas frecuentes**

**¿Cómo puedo buscar solo en un cuadro de texto en lugar de en toda la presentación?**

Obtenga el cuadro de texto de la forma y llame a [ITextFrame.highlightText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), o [ITextFrame.replaceRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) en ese cuadro de texto. Los métodos a nivel de presentación procesan todos los cuadros de texto aplicables en su lugar.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Establezca [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) y [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) en `true` y pase las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, defina los límites de palabra y la distinción entre mayúsculas y minúsculas directamente en el `Pattern` de Java.

**¿Pueden la búsqueda y el reemplazo incluir texto en notas de diapositiva?**

Sí. Establezca [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) en `true` cuando utilice una operación de texto literal a nivel de presentación. La implementación del callback mostrada arriba asigna una coincidencia en una diapositiva de notas a su número de diapositiva principal.

**¿Cómo puedo crear un informe sin escanear la presentación una segunda vez?**

Passe una implementación de [IFindResultCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifindresultcallback/) a la operación de resaltado o reemplazo. El callback recibe cada coincidencia mientras la operación se ejecuta, de modo que la aplicación puede almacenar el texto fuente, el texto coincidente, la posición, el cuadro de texto y el número de diapositiva derivado para agruparlo o exportarlo posteriormente.

**¿El reemplazo de texto conserva su formato?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) y [ITextFrame.replaceRegex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifican el texto coincidente dentro del cuadro de texto existente y conservan el formato de la porción circundante. Si una coincidencia abarca porciones con formato diferente, inspeccione el resultado para asegurarse de que el reemplazo utilice el estilo deseado.