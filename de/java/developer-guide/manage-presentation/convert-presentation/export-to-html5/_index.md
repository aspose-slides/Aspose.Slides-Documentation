---
title: Präsentationen nach HTML5 in Java konvertieren
linktitle: Präsentation zu HTML5
type: docs
weight: 40
url: /de/java/export-to-html5/
keywords:
- PowerPoint zu HTML5
- OpenDocument zu HTML5
- Präsentation zu HTML5
- Folie zu HTML5
- PPT zu HTML5
- PPTX zu HTML5
- ODP zu HTML5
- PPT als HTML5 speichern
- PPTX als HTML5 speichern
- ODP als HTML5 speichern
- PPT zu HTML5 exportieren
- PPTX zu HTML5 exportieren
- ODP zu HTML5 exportieren
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint‑ und OpenDocument‑Präsentationen zu responsive­m HTML5 mit Aspose.Slides für Java. Formatierung, Animationen und Interaktivität erhalten."
---
## **Überblick**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides für Java in HTML5 konvertiert werden. Er behandelt den einfachen Export, die Steuerung von Formanimationen und Folienübergängen sowie das Layout von Kommentaren. Außerdem vergleicht er die HTML5‑Ausgabe mit der SVG‑basierten Ausgabe des Standard‑HTML‑Exports.

## **PowerPoint nach HTML5 exportieren**

Das folgende Beispiel lädt eine Präsentation aus dem Arbeitsverzeichnis und speichert sie im HTML5‑Format. Es verwendet die Standard‑Exporteinstellungen; das nächste Beispiel zeigt, wie die Wiedergabe von Animationen explizit gesteuert werden kann. Ersetzen Sie den Eingabepfad durch den Pfad zu Ihrer Präsentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Zusätzlich zum HTML‑Dokument schreibt der Export unterstützende CSS‑ und JavaScript‑Dateien für Folienstil, Animationen, Effekte und Navigation. Bewahren Sie diese Dateien zusammen mit dem HTML‑Dokument auf, wenn Sie die Ausgabe verschieben oder veröffentlichen. Die generierte Seite lädt außerdem jQuery und Anime.js von öffentlichen CDNs; ohne diese funktionieren die Foliennavigation und -animationen nicht.
{{% /alert %}}

Um ohne Abspielen von Formanimationen oder Folienübergängen zu exportieren, übergeben Sie `false` an [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Diese Einstellungen sind unabhängig, sodass Sie eine aktivieren und die andere deaktivieren können. Das Beispiel exportiert die Präsentation mit beiden Animationsarten im generierten Dokument deaktiviert.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint nach HTML exportieren**

Der Standard‑HTML‑Export verwendet einen anderen Rendering‑Ansatz: Der Folieninhalt wird als SVG innerhalb einer HTML‑Seite dargestellt. Das folgende Beispiel konvertiert eine Präsentation in ein HTML‑Dokument mithilfe dieses Rendering‑Ansatzes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Der untenstehende vereinfachte Markup veranschaulicht die Struktur der erzeugten Seite. Das SVG‑Element enthält den gerenderten Folieninhalt; der Platzhaltertext steht für diesen Inhalt und ist nicht der tatsächliche Exportoutput.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Der SVG‑basierte Export stellt PowerPoint‑Formen nicht als einzelne HTML‑Elemente bereit. Verwenden Sie den HTML5‑Export, wenn Sie die in diesem Artikel gezeigten Optionen für Formanimationen und Folienübergänge benötigen.
{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

Der HTML5‑Export erzeugt eine Seite zum Anzeigen und Navigieren der Präsentationsfolien im Browser. Dieses Beispiel aktiviert sowohl [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) als auch [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-), sodass die exportierte Folienansicht Effekte aus der Quellpräsentation wiedergeben kann.

Verwenden Sie eine Präsentation, die bereits Formanimationen und Folienübergänge enthält, um die Wirkung dieser Einstellungen zu sehen. Das Aktivieren fügt Folien, die keine Effekte haben, keine neuen Effekte hinzu. Öffnen Sie nach dem Export das erzeugte HTML5‑Dokument in einem Browser, dessen unterstützende Dateien verfügbar sind.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Eine Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Sie können vorhandene Folienkommentare in die HTML5‑Ausgabe einbinden, damit Leser das Feedback zusammen mit dem Folieninhalt sehen können. Das Beispiel in diesem Abschnitt geht davon aus, dass die Quellpräsentation Kommentare enthält, wie unten dargestellt. Es exportiert diese Kommentare; es erstellt keine neuen.

![Two comments on the presentation slide](two_comments_pptx.png)

Übergeben Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/)‑Objekt an die Methode [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) von [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Verwenden Sie [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-), um `Right` aus der Aufzählung [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) auszuwählen und die Kommentare rechts von jeder Folie zu platzieren.

Das folgende Beispiel exportiert die Präsentation nach HTML5 mit diesem Kommentar‑Layout. Eine Präsentation ohne Kommentare enthält keinen anzuzeigenden Kommentartext.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![The comments in the output HTML5 document](two_comments_html5.png)

## **JavaScript‑Hyperlinks beim Export ausschließen**

Angenommen, `hyperlinks.pptx` enthält verlinkten Text mit dem Ziel `javascript:alert('Hello')` und einen normalen `https://example.com/`‑Link. Um den JavaScript‑Hyperlink beim Export auszuschließen, übergeben Sie `true` an [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Der Standardwert ist `false`, sodass diese Links nicht gefiltert werden, es sei denn, Sie aktivieren die Option.

Das folgende Beispiel lädt die Präsentation aus dem Arbeitsverzeichnis und exportiert sie mit [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Die exportierte Datei lässt den JavaScript‑Hyperlink weg, behält jedoch dessen Text und den normalen HTTPS‑Link bei. Die Quellpräsentation bleibt unverändert.

Diese Option filtert JavaScript‑Hyperlinks; sie entfernt nicht alle Skripte oder andere aktive Inhalte und garantiert keine CSP‑Konformität. Beispielsweise enthält die HTML5‑Ausgabe weiterhin Skripte für die Foliennavigation und -animationen.

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, der HTML5‑Export bietet separate Optionen zum Aktivieren oder Deaktivieren von [Formanimationen](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [Folienübergängen](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Werden Kommentare unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, vorhandene Kommentare können in die HTML5‑Ausgabe aufgenommen und (zum Beispiel rechts von der Folie) über [Layout‑Einstellungen](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, die [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)‑Einstellung ermöglicht es, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Der Standardwert ist `false`. Siehe [Exclude JavaScript Hyperlinks During Export](/slides/de/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) für ein HTML5‑Exportbeispiel und den Anwendungsbereich des Filters. Diese Einstellung entfernt nicht das JavaScript, das vom HTML5‑Viewer für Navigation und Animationen verwendet wird.