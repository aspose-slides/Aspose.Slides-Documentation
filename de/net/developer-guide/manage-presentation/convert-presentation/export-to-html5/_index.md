---
title: Präsentationen in HTML5 konvertieren in .NET
linktitle: Präsentation nach HTML5
type: docs
weight: 40
url: /de/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen zu responsive HTML5 mit Aspose.Slides für .NET. Behalten Sie Formatierung, Animationen und Interaktivität bei."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides für .NET in HTML5 konvertiert werden. Er behandelt den Basis‑Export, die Steuerung von Formanimationen und Folienübergängen sowie das Layout von Kommentaren. Außerdem vergleicht er die HTML5‑Ausgabe mit der SVG‑basierten Ausgabe des Standard‑HTML‑Exports.

## **PowerPoint nach HTML5 exportieren**

Das folgende Beispiel lädt eine Präsentation aus dem Arbeitsverzeichnis und speichert sie im HTML5‑Format. Es verwendet die Standardeinstellungen für den Export; das nächste Beispiel zeigt, wie die Animationswiedergabe explizit gesteuert werden kann. Ersetzen Sie den Eingabepfad durch den Pfad zu Ihrer Präsentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
Zusätzlich zum HTML‑Dokument schreibt der Export unterstützende CSS‑ und JavaScript‑Dateien für Folienstil, Animationen, Effekte und Navigation. Bewahren Sie diese Dateien zusammen mit dem HTML‑Dokument auf, wenn Sie die Ausgabe verschieben oder veröffentlichen. Die erzeugte Seite lädt außerdem jQuery und Anime.js von öffentlichen CDNs; ohne sie funktionieren die Foliennavigation und -animationen nicht.
{{% /alert %}}

Um zu exportieren, ohne Formanimationen oder Folienübergänge abzuspielen, setzen Sie [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) und [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) in [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) auf `false`. Diese Einstellungen sind unabhängig, sodass Sie eine aktivieren und die andere deaktivieren können. Das Beispiel exportiert die Präsentation mit deaktivierten beiden Animationsarten auf der erzeugten Seite.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **PowerPoint nach HTML exportieren**

Der Standard‑HTML‑Export verwendet einen anderen Rendering‑Ansatz: Folieninhalte werden als SVG innerhalb einer HTML‑Seite dargestellt. Das folgende Beispiel konvertiert eine Präsentation in ein HTML‑Dokument mittels dieses Rendering‑Ansatzes.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Der vereinfachte Markup unten veranschaulicht die Struktur der erzeugten Seite. Das SVG‑Element enthält den gerenderten Folieninhalt; der Platzhaltertext steht für diesen Inhalt und ist nicht die wörtliche Exportausgabe.

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
Der SVG‑basierte Export stellt PowerPoint‑Formen nicht als einzelne HTML‑Elemente bereit. Verwenden Sie den HTML5‑Export, wenn Sie die im Artikel gezeigten Optionen für Formanimationen und Folienübergänge benötigen.
{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

Der HTML5‑Export erzeugt eine Seite zum Anzeigen und Navigieren der Präsentationsfolien im Browser. Dieses Beispiel aktiviert sowohl [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) als auch [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/), sodass die exportierte Folienansicht Effekte aus der Quellpräsentation abspielen kann.

Verwenden Sie eine Präsentation, die bereits Formanimationen und Folienübergänge enthält, um die Wirkung dieser Einstellungen zu sehen. Das Aktivieren fügt Folien, die keine Effekte haben, keine neuen Effekte hinzu. Öffnen Sie nach dem Export das erzeugte HTML5‑Dokument in einem Browser, in dem die zugehörigen Unterstützungsdateien verfügbar sind.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Konvertieren einer Präsentation in ein HTML5‑Dokument mit Kommentaren**

Sie können vorhandene Folienkommentare in die HTML5‑Ausgabe einbinden, damit Leser Rückmeldungen neben dem Folieninhalt sehen. Das Beispiel in diesem Abschnitt geht davon aus, dass die Quellpräsentation Kommentare enthält, wie unten dargestellt. Es exportiert diese Kommentare; es erstellt keine neuen.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Weisen Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/)‑Objekt der Eigenschaft [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) von [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) zu. Setzen Sie [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) auf `Right` aus der Aufzählung [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/), um die Kommentare rechts von jeder Folie zu platzieren.

Das folgende Beispiel exportiert die Präsentation nach HTML5 mit diesem Kommentar‑Layout. Eine Präsentation ohne Kommentare enthält keinen anzuzeigenden Kommentartext.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Das Bild unten zeigt das exportierte HTML5‑Dokument, in dem die Kommentare neben der Folie angezeigt werden.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **JavaScript‑Hyperlinks beim Export ausschließen**

Angenommen, `hyperlinks.pptx` enthält verknüpften Text mit dem Ziel `javascript:alert('Hello')` sowie einen normalen `https://example.com/`‑Link. Um den JavaScript‑Hyperlink beim Export auszuschließen, setzen Sie [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) auf `true`. Der Standardwert ist `false`, sodass diese Links nicht gefiltert werden, solange Sie die Option nicht aktivieren.

Das folgende Beispiel lädt die Präsentation aus dem Arbeitsverzeichnis und exportiert sie mit [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Die exportierte Datei lässt den JavaScript‑Hyperlink weg, behält jedoch dessen Text und den normalen HTTPS‑Link bei. Die Quellpräsentation bleibt unverändert.

Diese Option filtert JavaScript‑Hyperlinks; sie entfernt nicht alle Skripte oder andere aktive Inhalte und garantiert keine CSP‑Konformität. Beispielsweise enthält die HTML5‑Ausgabe weiterhin Skripte für die Foliennavigation und -animationen.

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, der HTML5‑Export bietet separate Optionen, um [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) und [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) zu aktivieren oder zu deaktivieren.

**Werden Kommentare unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, vorhandene Kommentare können in die HTML5‑Ausgabe aufgenommen und (z. B. rechts von der Folie) über [Layout‑Einstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits- oder CSP‑Gründen überspringen?**

Ja, die Einstellung [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) ermöglicht es, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Der Standardwert ist `false`. Siehe [JavaScript‑Hyperlinks beim Export ausschließen](/slides/de/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) für ein einfaches HTML‑, HTML5‑ und PDF‑Exportbeispiel sowie den Geltungsbereich des Filters. Diese Einstellung entfernt nicht das JavaScript, das vom HTML5‑Viewer für Navigation und Animationen verwendet wird.