---
title: Präsentationen nach HTML5 in PHP konvertieren
linktitle: Präsentation zu HTML5
type: docs
weight: 40
url: /de/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für PHP über Java. Formatierung, Animationen und Interaktivität bleiben erhalten."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint-Präsentationen mit Aspose.Slides für PHP über Java in HTML5 konvertiert werden. Er behandelt den grundlegenden Export, die Steuerung von Formenanimationen und Folienübergängen sowie das Layout von Kommentaren. Außerdem wird die HTML5-Ausgabe mit der SVG-basierten Ausgabe des standardmäßigen HTML-Exports verglichen.

## **PowerPoint nach HTML5 exportieren**

Das folgende Beispiel lädt eine Präsentation aus dem Arbeitsverzeichnis und speichert sie im HTML5-Format. Es verwendet die Standardeinstellungen für den Export; das nächste Beispiel zeigt, wie die Animationswiedergabe explizit gesteuert werden kann. Ersetzen Sie den Eingabepfad durch den Pfad zu Ihrer Präsentation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Zusätzlich zum HTML-Dokument schreibt der Export unterstützende CSS- und JavaScript-Dateien für Folienstyling, Animationen, Effekte und Navigation. Bewahren Sie diese Dateien zusammen mit dem HTML-Dokument auf, wenn Sie die Ausgabe verschieben oder veröffentlichen. Die erzeugte Seite lädt außerdem jQuery und Anime.js von öffentlichen CDNs; ohne diese funktionieren die Foliennavigation und Animationen nicht.
{{% /alert %}}

Um ohne das Abspielen von Formenanimationen oder Folienübergängen zu exportieren, übergeben Sie `false` an [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) und [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) in [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Diese Einstellungen sind unabhängig, sodass Sie eine aktivieren und die andere deaktivieren können. Das Beispiel exportiert die Präsentation mit beiden Animationsarten im generierten Seiteninhalt deaktiviert.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint nach HTML exportieren**

Der standardmäßige HTML-Export verwendet einen anderen Rendering‑Ansatz: Folieninhalte werden als SVG in einer HTML‑Seite dargestellt. Das folgende Beispiel konvertiert eine Präsentation in ein HTML‑Dokument mit diesem Rendering‑Ansatz.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Der vereinfachte Markup unten veranschaulicht die Struktur der erzeugten Seite. Das SVG‑Element enthält die gerenderte Folieninhalte; der Platzhaltertext steht für diese Inhalte und ist nicht die tatsächliche Exportausgabe.

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
Der SVG-basierte Export stellt PowerPoint‑Formen nicht als einzelne HTML‑Elemente bereit. Verwenden Sie den HTML5‑Export, wenn Sie die im Artikel gezeigten Optionen für Formenanimationen und Folienübergänge benötigen.
{{% /alert %}}

## **PowerPoint in HTML5‑Folienansicht exportieren**

Der HTML5‑Export erzeugt eine Seite zum Anzeigen und Navigieren der Präsentationsfolien in einem Browser. Dieses Beispiel aktiviert sowohl [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) als auch [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions), damit die exportierte Folienansicht Effekte aus der Quellpräsentation abspielen kann.

Verwenden Sie eine Präsentation, die bereits Formenanimationen und Folienübergänge enthält, um die Wirkung dieser Einstellungen zu sehen. Das Aktivieren fügt Folien, die keine Effekte besitzen, keine neuen Effekte hinzu. Öffnen Sie nach dem Export das erzeugte HTML5‑Dokument in einem Browser, in dem die zugehörigen Unterstützungsdateien verfügbar sind.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Eine Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Sie können vorhandene Folienkommentare in die HTML5‑Ausgabe einbinden, so dass Leser Rückmeldungen neben dem Folieninhalt sehen können. Das Beispiel in diesem Abschnitt erwartet, dass die Quellpräsentation Kommentare enthält, wie unten dargestellt. Es exportiert diese Kommentare; es erstellt keine neuen.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Übergeben Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/)-Objekt an die Methode [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) von [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Verwenden Sie [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), um `Right` aus der Aufzählung [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) auszuwählen und die Kommentare rechts von jeder Folie zu platzieren.

Das folgende Beispiel exportiert die Präsentation mit diesem Kommentar‑Layout nach HTML5. Eine Präsentation ohne Kommentare enthält keinen anzuzeigenden Kommentartext.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Das Bild unten zeigt das exportierte HTML5‑Dokument, wobei die Kommentare neben der Folie angezeigt werden.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **JavaScript‑Hyperlinks beim Export ausschließen**

Angenommen, `hyperlinks.pptx` enthält verlinkten Text mit einem Ziel `javascript:alert('Hello')` und einen normalen `https://example.com/`‑Link. Um den JavaScript‑Hyperlink beim Export auszuschließen, übergeben Sie `true` an [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Der Standardwert ist `false`, sodass diese Links nicht gefiltert werden, es sei denn, Sie aktivieren die Option.

Das folgende Beispiel lädt die Präsentation aus dem Arbeitsverzeichnis und exportiert sie mit [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Die exportierte Datei lässt den JavaScript‑Hyperlink weg, behält jedoch dessen Text und den normalen HTTPS‑Link bei. Die Quellpräsentation bleibt unverändert.

Diese Option filtert JavaScript‑Hyperlinks; sie entfernt nicht alle Skripte oder andere aktive Inhalte und gewährleistet keine CSP‑Konformität. Beispielsweise enthält die HTML5‑Ausgabe weiterhin Skripte für die Foliennavigation und Animationen.

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, der HTML5‑Export bietet separate Optionen, um [Formenanimationen](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) und [Folienübergänge](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) zu aktivieren oder zu deaktivieren.

**Werden Kommentare unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, vorhandene Kommentare können in die HTML5‑Ausgabe eingebunden und (zum Beispiel rechts von der Folie) über die [Layout‑Einstellungen](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, die Einstellung [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) ermöglicht es, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Der Standardwert ist `false`. Siehe [Exclude JavaScript Hyperlinks During Export](/slides/de/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) für ein HTML5‑Export‑Beispiel und den Anwendungsbereich des Filters. Diese Einstellung entfernt nicht das JavaScript, das vom HTML5‑Viewer für Navigation und Animationen verwendet wird.