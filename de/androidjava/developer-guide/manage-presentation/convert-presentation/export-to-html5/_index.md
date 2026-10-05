---
title: Präsentationen nach HTML5 auf Android konvertieren
linktitle: Präsentation zu HTML5
type: docs
weight: 40
url: /de/androidjava/export-to-html5/
aliases:
  - /de/androidjava/export-nach-html5/
keywords:
- PowerPoint nach HTML5
- OpenDocument nach HTML5
- Präsentation nach HTML5
- Folien nach HTML5
- PPT nach HTML5
- PPTX nach HTML5
- ODP nach HTML5
- PPT als HTML5 speichern
- PPTX als HTML5 speichern
- ODP als HTML5 speichern
- PPT nach HTML5 exportieren
- PPTX nach HTML5 exportieren
- ODP nach HTML5 exportieren
- Android
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen zu responsivem HTML5 mit Aspose.Slides für Android über Java. Bewahren Sie Formatierung, Animationen und Interaktivität."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mithilfe von Aspose.Slides für Android via Java nach HTML5 konvertiert werden. Er behandelt den grundlegenden Export, die Steuerung von Formen‑Animationen und Folien‑Übergängen sowie das Layout von Kommentaren. Außerdem wird die HTML5‑Ausgabe mit der SVG‑basierten Ausgabe des Standard‑HTML‑Exports verglichen.

## **PowerPoint nach HTML5 exportieren**

Im folgenden Beispiel wird eine Präsentation aus dem Arbeitsverzeichnis geladen und im HTML5‑Format gespeichert. Es verwendet die Standard‑Exporteinstellungen; das nächste Beispiel zeigt, wie die Animationswiedergabe explizit gesteuert wird. Ersetzen Sie den Eingabepfad durch den Pfad zu Ihrer Präsentation.

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

Zusätzlich zum HTML‑Dokument schreibt der Export unterstützende CSS‑ und JavaScript‑Dateien für Folien‑Styling, Animationen, Effekte und Navigation. Bewahren Sie diese Dateien zusammen mit dem HTML‑Dokument auf, wenn Sie die Ausgabe verschieben oder veröffentlichen. Die erzeugte Seite lädt außerdem jQuery und Anime.js von öffentlichen CDNs; ohne diese funktionieren die Folien‑Navigation und Animationen nicht.

{{% /alert %}}

Um zu exportieren, ohne Formen‑Animationen oder Folien‑Übergänge abzuspielen, übergeben Sie `false` an [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Diese Einstellungen sind unabhängig, sodass Sie eine aktivieren und die andere deaktivieren können. Das Beispiel exportiert die Präsentation mit beiden Animationsarten in der erzeugten Seite deaktiviert.

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

Der Standard‑HTML‑Export verwendet einen anderen Rendering‑Ansatz: Der Folieninhalt wird als SVG innerhalb einer HTML‑Seite dargestellt. Das folgende Beispiel konvertiert eine Präsentation in ein HTML‑Dokument unter Verwendung dieses Rendering‑Ansatzes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Das vereinfachte Markup unten veranschaulicht die Struktur der erzeugten Seite. Das SVG‑Element enthält den gerenderten Folieninhalt; der Platzhalter‑Text steht für diesen Inhalt und ist keine wörtliche Export‑Ausgabe.

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

Der SVG‑basierte Export stellt PowerPoint‑Formen nicht als einzelne HTML‑Elemente bereit. Verwenden Sie den HTML5‑Export, wenn Sie die in diesem Artikel gezeigten Optionen für Formen‑Animationen und Folien‑Übergänge benötigen.

{{% /alert %}}

## **PowerPoint nach HTML5‑Foliensicht exportieren**

Der HTML5‑Export erzeugt eine Seite zum Anzeigen und Navigieren der Präsentationsfolien im Browser. Dieses Beispiel aktiviert sowohl [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) als auch [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-), sodass die exportierte Foliensicht Effekte aus der Quellpräsentation abspielen kann.

Verwenden Sie eine Präsentation, die bereits Formen‑Animationen und Folien‑Übergänge enthält, um die Wirkung dieser Einstellungen zu sehen. Das Aktivieren fügt Folien, die keine Effekte besitzen, keine neuen Effekte hinzu. Nach dem Export öffnen Sie das erzeugte HTML5‑Dokument in einem Browser, wobei die zugehörigen Dateien verfügbar sind.

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

Sie können vorhandene Folien‑Kommentare in die HTML5‑Ausgabe einbeziehen, sodass Leser Feedback neben dem Folieninhalt sehen können. Das Beispiel in diesem Abschnitt setzt voraus, dass die Quellpräsentation Kommentare enthält, wie unten illustriert. Es exportiert diese Kommentare; es erstellt keine neuen.

![Two comments on the presentation slide](two_comments_pptx.png)

Übergeben Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/)-Objekt an die Methode [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) von [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Verwenden Sie [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-), um `Right` aus der Aufzählung [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) auszuwählen und die Kommentare rechts von jeder Folie zu platzieren.

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

Das Bild unten zeigt das exportierte HTML5‑Dokument mit den neben der Folie angezeigten Kommentaren.

![The comments in the output HTML5 document](two_comments_html5.png)

## **JavaScript‑Hyperlinks beim Export ausschließen**

Angenommen, `hyperlinks.pptx` enthält verknüpften Text mit dem Ziel `javascript:alert('Hello')` und einen normalen `https://example.com/`‑Link. Um den JavaScript‑Hyperlink beim Export auszuschließen, übergeben Sie `true` an [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Der Standardwert ist `false`, sodass diese Links nicht gefiltert werden, solange Sie die Option nicht aktivieren.

Das folgende Beispiel lädt die Präsentation aus dem Arbeitsverzeichnis und exportiert sie mit [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/):

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

Diese Option filtert JavaScript‑Hyperlinks; sie entfernt nicht alle Skripte oder andere aktive Inhalte und garantiert keine CSP‑Konformität. Beispielsweise enthält die HTML5‑Ausgabe weiterhin Skripte für die Folien‑Navigation und Animationen.

## **FAQ**

**Kann ich steuern, ob Objekt‑Animationen und Folien‑Übergänge in HTML5 abgespielt werden?**

Ja, der HTML5‑Export bietet separate Optionen, um [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) zu aktivieren oder zu deaktivieren.

**Werden Kommentare unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, vorhandene Kommentare können in die HTML5‑Ausgabe integriert und über die [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) für Notizen und Kommentare positioniert werden (z. B. rechts von der Folie).

**Kann ich Links, die JavaScript ausführen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, die Einstellung [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ermöglicht das Überspringen von Hyperlinks mit JavaScript‑Aufrufen beim Speichern. Der Standardwert ist `false`. Siehe [Exclude JavaScript Hyperlinks During Export](/slides/de/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) für ein HTML5‑Export‑Beispiel und den Geltungsbereich des Filters. Diese Einstellung entfernt nicht das JavaScript, das vom HTML5‑Viewer für Navigation und Animationen verwendet wird.