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
- callback de resultados
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

Aspose.Slides for Java puede buscar, resaltar y reemplazar texto en un marco de texto individual o en toda una presentación. Cada operación también puede notificar a una aplicación sobre cada coincidencia mediante un callback de resultados. Esto permite actualizar una presentación y, simultáneamente, generar una traza de auditoría que contiene el texto encontrado, su contexto, posición, marco de texto y número de diapositiva.

Estas capacidades son útiles para revisiones, redactado, verificación de terminología, limpieza de plantillas y flujos de trabajo de generación de informes automáticos.

En los primeros ejemplos a continuación, utilizamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de ejemplo](sample_text.png)

## **Elegir el ámbito de búsqueda**

Utilice los métodos de ITextFrame para limitar una operación a un único marco de texto. Utilice los métodos de Presentation para procesar todo el texto aplicable en la presentación.

| Operación | Un marco de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [ITextFrame.highlightText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Resaltar coincidencias de expresiones regulares | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Reemplazar texto literal | [ITextFrame.replaceText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reemplazar coincidencias de expresiones regulares | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurar la coincidencia de texto**

Para operaciones de texto literal, utilice TextSearchOptions para controlar la coincidencia:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita las coincidencias a palabras completas.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controla si se debe respetar la capitalización de los caracteres.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/es/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) incluye las notas de la diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones con expresiones regulares utilizan un `Pattern` de Java, por lo que las reglas de coincidencia, como la sensibilidad a mayúsculas y los límites de palabras, se definen mediante la expresión y sus banderas.

## **Identificar el propietario de un marco de texto**

Los flujos de trabajo genéricos de procesamiento de texto a menudo reciben un ITextFrame mientras buscan, reemplazan, validan o exportan texto. Utilice ITextFrame.getParentShape y ITextFrame.getParentCell para determinar qué objeto de la presentación es propietario del marco de texto.

Los valores esperados dependen del propietario:

| Propietario del marco de texto | `getParentShape` | `getParentCell` |
|---|---|---|
| Una AutoShape u otra forma que contenga texto | El propietario [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) | `null` |
| Una celda de tabla | `null` | El propietario [ICell](https://reference.aspose.com/slides/es/java/com.aspose.slides/icell/) |

Ambos métodos proporcionan navegación de solo lectura. Llamarlos no mueve el marco de texto ni cambia su propietario. El código genérico debería comprobar ambos valores en busca de `null` y manejar la posibilidad de que ninguno de los propietarios esté disponible.

El siguiente ejemplo usa SlideUtil.getAllTextFrames para iterar por los marcos de texto de una presentación. Para las formas, informa del nombre de la forma, el tipo en tiempo de ejecución de Java y la diapositiva contenedora. Para las celdas de tabla, informa de las coordenadas de columna y fila basadas en cero y de la diapositiva contenedora.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Para contenido de SmartArt, itere a través de las formas en ISmartArtNode.getShapes y acceda a cada ISmartArtShape.getTextFrame. El marco de texto puede rastrearse a su forma asociada mediante ITextFrame.getParentShape, mientras que ITextFrame.getParentCell devuelve `null`. Por lo tanto, la rama de forma en el ejemplo también gestiona texto de nodos SmartArt.

## **Recopilar información de coincidencias con un callback**

Implemente IFindResultCallback para recibir una notificación por cada coincidencia. Su método IFindResultCallback.foundResult proporciona el marco de texto relacionado, el texto origen, el texto coincidente y la posición de la coincidencia.

El callback no recibe directamente el número de diapositiva. La implementación a continuación lo deduce de la diapositiva padre y también gestiona el texto encontrado en las notas de la diapositiva. Un `Integer` nullable permite que el mismo modelo de resultado represente texto asociado a otros tipos de diapositiva.

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

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

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

Para operaciones de reemplazo, `foundText` contiene el texto original coincidente, por lo que el callback puede registrar exactamente qué términos fueron reemplazados.

## **Resaltar texto**

Utilice el método ITextFrame.highlightText para resaltar coincidencias de texto literal en un marco de texto. Pase TextSearchOptions para controlar la búsqueda y un callback para recopilar los detalles de la coincidencia.

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**. Ambas búsquedas informan sus coincidencias al mismo callback.

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

![Texto resaltado](highlighted_text.png)

## **Resaltar texto usando expresiones regulares**

El método ITextFrame.highlightRegex resalta las coincidencias de texto encontradas mediante una expresión regular en un marco de texto.

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

![Texto resaltado usando la expresión regular](highlighted_text_using_regex.png)

## **Resaltar texto en toda una presentación**

Utilice Presentation.highlightText y Presentation.highlightRegex para buscar en todos los marcos de texto aplicables de una presentación. El siguiente ejemplo resalta un término literal y todas las direcciones de correo electrónico, manteniendo colecciones de resultados separadas para ambas búsquedas.

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

Utilice ITextFrame.replaceText para texto literal e ITextFrame.replaceRegex para reemplazo basado en patrones. Estos métodos actualizan el texto coincidente dentro del marco de texto existente, conservando el formato de la porción circundante en lugar de reconstruir el marco de texto a partir de una cadena simple.

El siguiente ejemplo estandariza una variante ortográfica y luego reemplaza etiquetas de versión. El mismo callback registra los términos originales coincidentes en ambas operaciones.

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

Utilice Presentation.replaceText y Presentation.replaceRegex para aplicar las mismas operaciones en toda la presentación. Esto es útil para la limpieza de plantillas, actualizaciones de terminología y redactado.

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

Dado que cada resultado almacena su número de diapositiva y su marco de texto, las aplicaciones pueden agrupar coincidencias para auditorías, informes o flujos de trabajo de revisión. El siguiente ejemplo agrupa los resultados recopilados primero por diapositiva y luego por marco de texto:

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

**¿Cómo puedo buscar solo en un cuadro de texto en lugar de toda la presentación?**

Obtenga el marco de texto de la forma y llame a ITextFrame.highlightText, ITextFrame.highlightRegex, ITextFrame.replaceText o ITextFrame.replaceRegex en ese marco de texto. Los métodos a nivel de presentación procesan todos los marcos de texto aplicables en su lugar.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Establezca TextSearchOptions.setWholeWordsOnly y TextSearchOptions.setCaseSensitive a `true`, y pase las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, defina los límites de palabra y la sensibilidad a mayúsculas en el propio `Pattern` de Java.

**¿Puede la búsqueda y el reemplazo incluir texto en las notas de la diapositiva?**

Sí. Establezca TextSearchOptions.setIncludeNotes a `true` al usar una operación de texto literal a nivel de presentación. La implementación del callback mostrada arriba asigna una coincidencia en una diapositiva de notas al número de diapositiva padre.

**¿Cómo puedo crear un informe sin escanear la presentación una segunda vez?**

Pase una implementación de IFindResultCallback a la operación de resaltado o reemplazo. El callback recibe cada coincidencia mientras se ejecuta la operación, por lo que la aplicación puede almacenar el texto origen, el texto coincidente, la posición, el marco de texto y el número de diapositiva derivado para agruparlo o exportarlo posteriormente.

**¿El reemplazo de texto conserva su formato?**

ITextFrame.replaceText e ITextFrame.replaceRegex modifican el texto coincidente dentro del marco de texto existente y conservan el formato de la porción circundante. Si una coincidencia abarca porciones con formato diferente, inspeccione el resultado para asegurarse de que el reemplazo utilice el estilo deseado.