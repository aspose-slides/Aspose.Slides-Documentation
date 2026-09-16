---
title: Präsentations‑Hyperlinks in JavaScript verwalten
linktitle: Hyperlinks verwalten
type: docs
weight: 20
url: /de/nodejs-java/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Text‑Hyperlink
- Folien‑Hyperlink
- Form‑Hyperlink
- Bild‑Hyperlink
- Video‑Hyperlink
- veränderlicher Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hyperlinks in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Node.js via Java hinzufügen, formatieren, aktualisieren und entfernen, wobei JavaScript‑Beispiele verwendet werden."
---
## **Einleitung**

Ein Hyperlink verbindet Präsentationsinhalte mit einer Website oder einem Ort innerhalb der Präsentation. In PowerPoint dienen Hyperlinks häufig zwei Zwecken:

* Eine Website von Text, Form oder Medienrahmen aus öffnen.
* Zu einer anderen Folie navigieren, zum Beispiel von einem Inhaltsverzeichnis.

Aspose.Slides für Node.js via Java ermöglicht das Hinzufügen dieser Links, das Steuern ihres Aussehens und Sounds, das Aktualisieren ihrer Eigenschaften und das Entfernen. Die nachfolgenden Beispiele zeigen, wie man mit Hyperlinks auf einzelnen Elementen arbeitet und wie man Hyperlinks auf Präsentations‑, Folien‑ oder Text‑Frame‑Ebene abruft.

{{% alert color="info" title="Hinweis" %}}
Sie können Präsentationen auch mit dem [kostenlosen Online‑Aspose‑PowerPoint‑Editor](https://products.aspose.app/slides/de/editor) bearbeiten.
{{% /alert %}} 

## **URL‑Hyperlinks hinzufügen**

Sie können einer URL einer Website Text, einer Form oder einem Medienrahmen zuweisen. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den anklickbaren Bereich: Ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

### **URL‑Hyperlinks zu Text hinzufügen**

Um Text zu einer Website zu verlinken, übergeben Sie ein [Hyperlink](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink) an die [setHyperlinkClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick)-Methode des Textabschnitts, wie unten gezeigt. Nur dieser Textabschnitt wird anklickbar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **URL‑Hyperlinks zu Formen und Medienrahmen hinzufügen**

Um eine Form oder einen Rahmen anklickbar zu machen, rufen Sie deren [setHyperlinkClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Shape#setHyperlinkClick)-Methode auf. Der Hyperlink gehört zum Objekt selbst und nicht zu einem Textabschnitt darin.

Der gleiche Ansatz gilt für Bild‑, Audio‑ und Videorahmen: Weisen Sie den Hyperlink dem Rahmen zu und rufen Sie bei Bedarf [setTooltip](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#setTooltip) auf.

Das folgende Beispiel macht ein Rechteck anklickbar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlinks zur Erstellung eines Inhaltsverzeichnisses verwenden**

Interne Hyperlinks ermöglichen es Lesern, von einem Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [setInternalHyperlinkClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick), um den Text „Seite 2“ auf der ersten Folie mit der zweiten Folie zu verlinken.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlinks formatieren**

### **Farbe**

Die [setColorSource](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#setColorSource)-Methode von [Hyperlink](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink) bestimmt, ob ein Hyperlink die Hyperlink‑Farbe der Präsentation oder die Formatierung des Textabschnitts verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkColorSource) und setzen Sie die Füllfarbe des Absatzes. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen beachten diese Einstellung nicht.

Das folgende Beispiel fügt zwei Text‑Hyperlinks zur gleichen Folie hinzu. Der erste verwendet eine rote Textfüllung, der zweite behält die standardmäßige Hyperlink‑Farbe bei.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Sound**

Ein Hyperlink kann beim Aktivieren einen Sound abspielen oder einen bereits spielenden Sound stoppen. Verwenden Sie die folgenden Methoden, um dieses Verhalten zu konfigurieren:

- [Hyperlink.setSound](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#setSound) legt die dem Hyperlink zugeordnete Audiodatei fest.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) steuert, ob das Aktivieren des Hyperlinks den vorherigen Sound stoppt.

#### **Einen Hyperlink‑Sound hinzufügen**

Das folgende Beispiel lädt `sampleaudio.wav` und verknüpft es mit einem Button auf der ersten Folie. Durch Klicken des Buttons wird der Sound abgespielt und zur nächsten Folie navigiert. Eine zweite Form auf derselben Folie stoppt den vorherigen Sound, ohne eine Navigationsaktion auszuführen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Einen Hyperlink‑Sound extrahieren**

Das folgende Beispiel öffnet die zuvor erstellte Präsentation und liest den Hyperlink‑Audio‑Stream der ersten Form über [getSound](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#getSound) und [getBinaryData](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Audio#getBinaryData) in den Speicher.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip‑ und Interaktionseinstellungen**

Sie können nach dem Zuweisen eines Hyperlinks zu Text oder einer Form die folgenden [Hyperlink](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink)-Methoden aufrufen:

- [setTooltip](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#setTooltip) legt den Text fest, den ein Betrachter als Hinweis für den Link anzeigen kann.
- [setTargetFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) gibt den Ziel‑Frame innerhalb eines übergeordneten HTML‑Framesets an, falls zutreffend.
- [setHistory](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#setHistory) steuert, ob das Aktivieren des Links dessen Ziel zur Liste der angesehenen Hyperlinks hinzufügt.
- [setHighlightClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) legt fest, ob der Hyperlink beim Klicken hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [getAnyHyperlinks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks), um Hyperlink‑Container, einschließlich Text‑Abschnitt‑Links, zu sammeln, bevor Sie sie ändern. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie ausschließlich [removeHyperlinkClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) oder [removeHyperlinkMouseOver](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) auf; das Entfernen einer Klick‑Aktion entfernt nicht deren Mouse‑Over‑Gegenstück.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Für bedingungslose Entfernung entfernt [removeAllHyperlinks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) beide Aktivierungstypen im ausgewählten Umfang in einem Aufruf. Für eine selektive Bereinigung und Abdeckung von Mastern, Layouts und Notizen siehe [Berichten, Bereinigen und Verifizieren von Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Ein vollständiges Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verteilen, erfassen Sie ihre interaktiven Aktionen sowie ihre Web‑Links. [getAnyHyperlinks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) gibt Hyperlink‑Container zurück, nicht eine flache Liste von URL‑Strings. Untersuchen Sie sowohl [getHyperlinkClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Shape#getHyperlinkClick) als auch [getHyperlinkMouseOver](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) für jeden Container. Sie sind unabhängig: derselbe Container kann beide Aktionen bereitstellen, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container benötigen kann.

Das reine Scannen von Shape‑Level‑Hyperlinks kann Links übersehen, die Text‑Abschnitten zugewiesen sind. Fragen Sie stattdessen den passenden Umfang ab und behalten Sie die zurückgegebenen Container, damit Sie deren Aktionen später aktualisieren oder entfernen können.

### **Präsentations‑, Folien‑ und Text‑Frame‑Umfänge abfragen**

Die Klasse [HyperlinkQueries](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkQueries) ist über [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) und [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) zugänglich. Jeder Umfang unterstützt dieselben Abfragen:

- [getHyperlinkClicks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) liefert Container mit einer Klick‑Aktion.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) liefert Container mit einer Mouse‑Over‑Aktion.
- [getAnyHyperlinks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) liefert Container mit einer oder beiden Aktionen.

Das folgende Beispiel erstellt `hyperlink-audit-input.pptx` mit einem externen Klick‑Link, einem Datei‑Mouse‑Over‑Link, einer internen Folien‑Navigation, einem Text‑Mouse‑Over‑Link und einer Makro‑Aktion. Es führt keine dieser Aktionen aus. Die gleichen drei Abfragen funktionieren in jedem Umfang; die Zählungen beschreiben Container, nicht die Gesamtzahl der Aktionen. Der Text‑Frame‑Umfang schließt die eigenen Links des umgebenden Shapes aus.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In diesem Beispiel melden Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Mouse‑Over‑Container und drei Container mit einer beliebigen Aktion. Die Text‑Frame‑Abfrage meldet je eine Container in jeder Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [Hyperlink.getActionType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#getActionType), um eine Aktion zu interpretieren, bevor Sie ihr Ziel auswerten. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkActionType) decken mehr als reine Web‑Navigation ab:

| Werte | Bedeutung für ein Audit |
| --- | --- |
| `Hyperlink` | Externer Hyperlink; URL und Schema prüfen. |
| `JumpSpecificSlide` | Interne Navigation zu einer bestimmten Folie. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Eingebaute Diashow‑Navigation, im Diashow‑Kontext aufgelöst. |
| `JumpEndShow`, `StartCustomSlideShow` | Aktuelle Show beenden bzw. benutzerdefinierte Show starten. |
| `StartMacro` | Makro ausführen. |
| `StartProgram` | Programm starten. |
| `OpenFile`, `OpenPresentation` | Datei oder andere Präsentation öffnen; getrennt von Web‑URLs prüfen. |
| `StartStopMedia` | Medien‑Wiedergabe starten oder stoppen. |
| `NoAction`, `Unknown` | Keine Navigationsaktion bzw. nicht erkennbare Aktion, die geprüft werden muss. |

Lesen Sie externe Ziele über [getExternalUrl](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) und spezifische interne Ziele über [getTargetSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Interne Aktionen und eingebaute Befehle besitzen möglicherweise keine externe URL; eine leere URL bedeutet nicht, dass der Container keine Aktion hat. Bewahren Sie den Wert von [getExternalUrlOriginal](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) auf, wenn er von der normalisierten URL abweicht, und fügen Sie den Tooltip von [getTooltip](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Hyperlink#getTooltip) hinzu, falls verfügbar.

### **Hyperlinks berichten, bereinigen und verifizieren**

Das folgende JavaScript‑Beispiel liest eine vorhandene Präsentation (verwenden Sie die oben erstellte Datei), schreibt `hyperlink-audit.json`, wendet eine Richtlinie an, speichert `hyperlink-sanitized.pptx` und öffnet sie erneut, um beide Aktivierungstypen erneut zu prüfen. Es sammelt Container, bevor sie geändert werden, und nutzt Referenz‑Equality, um eine doppelte Verarbeitung zu vermeiden. Präsentations‑Abfragen decken gewöhnliche Folien ab; für ein paketweites Inventar werden zusätzlich explizit Master, Layouts, Notizen sowie die Notiz‑ und Handzettel‑Master, falls vorhanden, abgefragt.

Der Bericht speichert einen ein‑basierten Folien‑Index und, sofern verfügbar, [getSlideId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/BaseSlide#getSlideId). [getSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Shape#getSlide) liefert die zugehörige Folie für unterstützte Container. Master, Layouts und Notizen besitzen keinen gewöhnlichen Folien‑Index und werden über ihren Umfang identifiziert. Shape‑Container und Text‑Abschnitt‑Formatierungs‑Container werden separat benannt; andere Containertypen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichtslokale ID, sodass seine beiden Aktionen korreliert werden können. Der Bericht speichert Aktionstypen als die ganzzahligen Konstanten der HyperlinkActionType‑Aufzählung.

Diese bewusst restriktive Anwendungsrichtlinie erlaubt ausschließlich absolute HTTPS‑URLs und gültige interne Folienziele. Sie verwirft Makros, Programme, Datei‑Aktionen, andere Diashow‑Aktionen, unbekannte Aktionen und andere URL‑Schemata. Diese Ablehnungen sind Richtlinien‑Entscheidungen, nicht ein Aspose.Slides‑Sicherheitsurteil. HTTPS allein begründet kein Vertrauen: Ergänzen Sie Host‑Whitelist‑ und weitere Prüfungen für Ihre Anwendung. Sowohl originale als auch normalisierte externe URLs werden geprüft. Das Beispiel auditirt Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Bereinigung unterstützt der Container über [getHyperlinkManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Shape#getHyperlinkManager) [setExternalHyperlinkClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) und [removeHyperlinkMouseOver](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Landing‑Page ersetzt; andere verbotene Klick‑ und Mouse‑Over‑Aktionen werden unabhängig entfernt. Setzen Sie `replaceExternalClicks` auf `false`, um alle Richtlinien‑Verstöße zu entfernen. Wählen Sie vor dem Deployment eine von Ihrer Anwendung bereitgestellte Ersatz‑Page.

Die Export‑Flagge des Berichts verwendet eine konservative PDF‑Review‑Richtlinie: Mouse‑Over‑Aktionen und alles außer einem externen Link oder einem spezifischen Folien‑Sprung werden als potenziell nicht unterstützt markiert. Es ist ein Hinweis für die Überprüfung, kein Test der Fähigkeit oder eine Garantie, dass nicht markierte Links den Export überstehen. Unterstützte [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/) und [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/) Exporte können Hyperlinks je nach Aktion, Export‑Optionen und Viewer erhalten; Raster‑[Bilder](/slides/de/nodejs-java/convert-powerpoint-to-png/) und -[Videos](/slides/de/nodejs-java/convert-powerpoint-to-video/) können interaktive Hyperlinks nicht erhalten; markieren Sie daher jede Aktion beim Auditing für diese Ausgaben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Mit dem oben erstellten Input enthält der Bericht fünf Aktionszeilen. Der Datei‑Mouse‑Over‑Link und das Makro‑Klick‑Element werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Verifizierung gibt null verbotene Aktionen aus. Ein Input mit einer verbotenen externen Klick‑URL demonstriert zudem den Ersetzungs‑Zweig. Ein Container mit einem erlaubten Klick und einem verbotenen Mouse‑Over behält seine Klick‑Aktion.

Diese selektive Bereinigung unterscheidet sich von [removeAllHyperlinks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), das beide Aktivierungstypen im ausgewählten Umfang unabhängig von einer Richtlinie entfernt. Die Verifizierung prüft hier ausschließlich Hyperlink‑Aktionen; sie entfernt keine eingebetteten VBA‑Projekte, OLE‑Objekte oder anderen aktiven Inhalt und validiert weder exportierte PDF‑ noch HTML‑Dateien.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder dessen erster Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink zielt auf eine einzelne Folie. Um zu einem Abschnitt zu navigieren, verlinken Sie zur ersten Folie dieses Abschnitts.

**Kann ich einem Master‑Folienelement einen Hyperlink zuweisen, sodass er auf allen Folien funktioniert?**

Ja. Elemente von Master‑Folien und Layouts unterstützen Hyperlinks. Links auf diesen Elementen stehen während der Bildschirmanzeige auf allen Folien zur Verfügung, die den entsprechenden Master oder das Layout verwenden.

**Werden Hyperlinks beim Export nach PDF, HTML, Bildern oder Video erhalten bleiben?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks erhalten; Raster‑Bilder und Videos können keine interaktiven Hyperlinks bewahren. Siehe die Export‑Hinweise in [Berichten, Bereinigen und Verifizieren von Hyperlinks](#report-sanitize-and-verify-hyperlinks).