---
title: Präsentationen in HTML5 mit JavaScript konvertieren
linktitle: Präsentation nach HTML5
type: docs
weight: 40
url: /de/nodejs-java/export-to-html5/
keywords:
- PowerPoint nach HTML5
- OpenDocument nach HTML5
- Präsentation nach HTML5
- Folie nach HTML5
- PPT nach HTML5
- PPTX nach HTML5
- ODP nach HTML5
- PPT als HTML5 speichern
- PPTX als HTML5 speichern
- ODP als HTML5 speichern
- PPT nach HTML5 exportieren
- PPTX nach HTML5 exportieren
- ODP nach HTML5 exportieren
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für Node.js. Bewahren Sie Formatierung, Animationen und Interaktivität."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides für Node.js via Java in HTML5 konvertiert werden. Er behandelt den einfachen Export, die Steuerung von Form‑Animationen und Folienübergängen sowie das Kommentar‑Layout. Außerdem vergleicht er die HTML5‑Ausgabe mit der SVG‑basierten Ausgabe des Standard‑HTML‑Exports.

## **PowerPoint nach HTML5 exportieren**

Das folgende Beispiel lädt eine Präsentation aus dem Arbeitsverzeichnis und speichert sie im HTML5‑Format. Es verwendet die standardmäßigen Exporteinstellungen; das nächste Beispiel zeigt, wie die Animationswiedergabe explizit gesteuert werden kann. Ersetzen Sie den Eingabepfad durch den Pfad zu Ihrer Präsentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Zusätzlich zum HTML‑Dokument schreibt der Export unterstützende CSS‑ und JavaScript‑Dateien für Folienstyling, Animationen, Effekte und Navigation. Bewahren Sie diese Dateien zusammen mit dem HTML‑Dokument auf, wenn Sie die Ausgabe verschieben oder veröffentlichen. Die erzeugte Seite lädt außerdem jQuery und Anime.js von öffentlichen CDNs; ohne sie funktionieren Foliennavigation und Animationen nicht.
{{% /alert %}}

Um ohne die Wiedergabe von Form‑Animationen oder Folienübergängen zu exportieren, übergeben Sie `false` an [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) und [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) in [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Diese Einstellungen sind unabhängig, so dass Sie eine aktivieren und die andere deaktivieren können. Das Beispiel exportiert die Präsentation mit beiden Animationsarten im erzeugten Dokument deaktiviert.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint nach HTML exportieren**

Der Standard‑HTML‑Export verwendet einen anderen Rendering‑Ansatz: Folieninhalt wird als SVG innerhalb einer HTML‑Seite dargestellt. Das folgende Beispiel konvertiert eine Präsentation in ein HTML‑Dokument mit diesem Rendering‑Ansatz.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Der nachstehende vereinfachte Markup verdeutlicht die Struktur der erzeugten Seite. Das SVG‑Element enthält den gerenderten Folieninhalt; der Platzhaltertext steht für diesen Inhalt und ist kein wörtlicher Exportausgabe.

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
Der SVG‑basierte Export stellt PowerPoint‑Formen nicht als einzelne HTML‑Elemente bereit. Verwenden Sie den HTML5‑Export, wenn Sie die in diesem Artikel gezeigten Optionen für Form‑Animationen und Folienübergänge benötigen.
{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

Der HTML5‑Export erzeugt eine Seite zum Anzeigen und Navigieren der Präsentationsfolien in einem Browser. Dieses Beispiel aktiviert sowohl [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) als auch [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-), sodass die exportierte Folienansicht Effekte aus der Quellpräsentation wiedergeben kann.

Verwenden Sie eine Präsentation, die bereits Form‑Animationen und Folienübergänge enthält, um die Wirkung dieser Einstellungen zu sehen. Das Aktivieren fügt Folien, die keine Effekte haben, keine neuen Effekte hinzu. Öffnen Sie nach dem Export das erzeugte HTML5‑Dokument in einem Browser, wobei die zugehörigen Dateien verfügbar sind.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Eine Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Sie können vorhandene Folienkommentare in die HTML5‑Ausgabe einbinden, sodass Leser Rückmeldungen neben dem Folieninhalt sehen können. Das Beispiel in diesem Abschnitt setzt voraus, dass die Quellpräsentation Kommentare enthält, wie unten dargestellt. Es exportiert diese Kommentare; es werden keine neuen erstellt.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Übergeben Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/)‑Objekt an die Methode [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) von [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Verwenden Sie [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-), um `Right` aus der Aufzählung [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) auszuwählen, damit die Kommentare rechts von jeder Folie platziert werden.

Das folgende Beispiel exportiert die Präsentation nach HTML5 mit diesem Kommentar‑Layout. Eine Präsentation ohne Kommentare enthält keinen anzuzeigenden Kommentartext.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **JavaScript‑Hyperlinks beim Export ausschließen**

Angenommen, `hyperlinks.pptx` enthält verlinkten Text mit einem Ziel `javascript:alert('Hello')` und einen normalen `https://example.com/`‑Link. Um den JavaScript‑Hyperlink beim Export auszuschließen, übergeben Sie `true` an [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Der Standardwert ist `false`, sodass diese Links nicht gefiltert werden, es sei denn, Sie aktivieren die Option.

Das folgende Beispiel lädt die Präsentation aus dem Arbeitsverzeichnis und exportiert sie mit [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Die exportierte Datei lässt den JavaScript‑Hyperlink weg, behält jedoch dessen Text und den normalen HTTPS‑Link bei. Die Quellpräsentation bleibt unverändert.

Diese Option filtert JavaScript‑Hyperlinks; sie entfernt nicht alle Skripte oder anderen aktiven Inhalt und garantiert keine CSP‑Konformität. Beispielsweise enthält die HTML5‑Ausgabe weiterhin Skripte für die Foliennavigation und Animationen.

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, der HTML5‑Export bietet separate Optionen, um [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) und [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) zu aktivieren oder zu deaktivieren.

**Werden Kommentare unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, vorhandene Kommentare können in die HTML5‑Ausgabe eingebunden und (zum Beispiel rechts von der Folie) über [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, die Einstellung [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ermöglicht es, beim Speichern Hyperlinks mit JavaScript‑Aufrufen zu überspringen. Der Standardwert ist `false`. Siehe [JavaScript‑Hyperlinks beim Export ausschließen](/slides/de/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) für ein HTML5‑Exportbeispiel und den Anwendungsbereich des Filters. Diese Einstellung entfernt nicht das JavaScript, das vom HTML5‑Viewer für Navigation und Animationen verwendet wird.