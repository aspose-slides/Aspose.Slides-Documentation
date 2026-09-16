---
title: Verwalten von Präsentations‑Hyperlinks in Java
linktitle: Hyperlinks verwalten
type: docs
weight: 20
url: /de/java/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Texthyperlink
- Folienhyperlink
- Formhyperlink
- Bildhyperlink
- Videohyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java hinzufügen, formatieren, aktualisieren und entfernen, mit Java-Beispielen."
---
## **Einleitung**

Ein Hyperlink verbindet Präsentationsinhalt mit einer Website oder einem Ort innerhalb der Präsentation. In PowerPoint dienen Hyperlinks üblicherweise zwei Zwecken:

* Öffnen Sie eine Website aus Text, einer Form oder einem Medienrahmen.
* Navigieren Sie zu einer anderen Folie, zum Beispiel aus einem Inhaltsverzeichnis.

Aspose.Slides für Java ermöglicht das Hinzufügen dieser Links, die Steuerung von Aussehen und Klang, das Aktualisieren ihrer Eigenschaften und das Entfernen. Die nachstehenden Beispiele zeigen, wie man mit Hyperlinks für einzelne Elemente arbeitet und wie man Hyperlinks auf Ebene der Präsentation, Folie oder des Textrahmens abruft.

{{% alert color="info" title="Note" %}}
Sie können Präsentationen auch mit dem [kostenlosen Online-Aspose-PowerPoint-Editor](https://products.aspose.app/slides/de/editor) bearbeiten.
{{% /alert %}} 

## **URL-Hyperlinks hinzufügen**

Sie können einer URL einer Website Text, einer Form oder einem Medienrahmen zuweisen. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den anklickbaren Bereich: Ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

### **URL-Hyperlinks zu Text hinzufügen**

Um Text mit einer Website zu verknüpfen, übergeben Sie ein [Hyperlink](https://reference.aspose.com/slides/de/java/com.aspose.slides/hyperlink/) an die [setHyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-)‑Methode des Textabschnitts, wie unten gezeigt. Nur dieser Textabschnitt wird anklickbar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **URL-Hyperlinks zu Formen und Medienrahmen hinzufügen**

Um eine Form oder einen Rahmen anklickbar zu machen, rufen Sie dessen [setHyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-)‑Methode auf. Der Hyperlink gehört zum Objekt selbst und nicht zu einem Textabschnitt darin.

Der gleiche Ansatz gilt für Bild-, Audio‑ und Video‑Frames: Weisen Sie dem Frame den Hyperlink zu und rufen Sie bei Bedarf [setTooltip](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) auf.

Das folgende Beispiel macht ein Rechteck anklickbar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlinks zur Erstellung eines Inhaltsverzeichnisses verwenden**

Interne Hyperlinks ermöglichen es dem Leser, vom Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [setInternalHyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-), um den Text „Page 2“ auf der ersten Folie mit der zweiten Folie zu verknüpfen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlinks formatieren**

### **Farbe**

Die [setColorSource](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#setColorSource-int-)‑Methode von [IHyperlink](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/) bestimmt, ob ein Hyperlink die Hyperlink‑Farbe der Präsentation oder die Formatierung des Textabschnitts verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/hyperlinkcolorsource/) und setzen die Füllfarbe des Abschnitts. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen wenden diese Einstellung nicht an.

Das folgende Beispiel fügt derselben Folie zwei Text‑Hyperlinks hinzu. Der erste verwendet eine rote Textfüllung, während der zweite die Standard‑Hyperlink‑Farbe beibehält.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Sound**

Ein Hyperlink kann beim Aktivieren einen Sound abspielen oder einen bereits spielenden Sound stoppen. Verwenden Sie die folgenden Methoden, um dieses Verhalten zu konfigurieren:

- [IHyperlink.setSound](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) gibt das dem Hyperlink zugeordnete Audio an.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) steuert, ob das Aktivieren des Hyperlinks den vorherigen Sound stoppt.

#### **Hyperlink‑Sound hinzufügen**

Das folgende Beispiel lädt `sampleaudio.wav` und verknüpft es mit einer Schaltfläche auf der ersten Folie. Ein Klick auf die Schaltfläche spielt den Sound ab und navigiert zur nächsten Folie. Eine zweite Form auf derselben Folie stoppt beim Klicken den vorherigen Sound, ohne eine Navigation auszuführen.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Hyperlink‑Sound extrahieren**

Das folgende Beispiel öffnet die oben erstellte Präsentation und liest das Hyperlink‑Audio der ersten Form über [getSound](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#getSound--) und [getBinaryData](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaudio/#getBinaryData--) in den Speicher.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip‑ und Interaktionseinstellungen**

Sie können nach dem Zuweisen eines Hyperlinks zu Text oder einer Form die folgenden [IHyperlink](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/)‑Methoden aufrufen:

- [setTooltip](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) legt den Text fest, den ein Betrachter als Hinweis für den Link anzeigen kann.
- [setTargetFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) gibt das Ziel‑Frame innerhalb eines übergeordneten HTML‑Framesets an, falls zutreffend.
- [setHistory](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) steuert, ob das Aktivieren des Links sein Ziel zur Liste der angesehenen Hyperlinks hinzufügt.
- [setHighlightClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) steuert, ob der Hyperlink beim Klicken hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [getAnyHyperlinks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) , um Hyperlink‑Container, einschließlich Text‑Abschnitt‑Links, zu sammeln, bevor Sie sie ändern. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie ausschließlich [removeHyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) bzw. [removeHyperlinkMouseOver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) auf; das Entfernen einer Klick‑Aktion entfernt nicht das Mouse‑Over‑Gegenstück.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Für bedingungslose Entfernung entfernt [removeAllHyperlinks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) beide Aktivierungstypen im ausgewählten Umfang in einem Aufruf. Für selektive Bereinigung und Berücksichtigung von Mastern, Layouts und Notizen siehe [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Vollständiges Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verteilen, erstellen Sie ein Inventar ihrer interaktiven Aktionen sowie ihrer Web‑Links. [getAnyHyperlinks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) gibt [IHyperlinkContainer](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkcontainer/)‑Objekte zurück, nicht eine flache Liste von URL‑Zeichenketten. Untersuchen Sie sowohl [getHyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) als auch [getHyperlinkMouseOver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) in jedem Container. Sie sind unabhängig: derselbe Container kann beide Aktionen enthalten, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container benötigt.

Das Scannen nur von Hyperlinks auf Shape‑Ebene kann Links, die an Text‑Abschnitten hängen, übersehen. Stattdessen fragen Sie den entsprechenden Umfang ab und bewahren die zurückgegebenen Container, damit Sie deren Aktionen später aktualisieren oder entfernen können.

### **Abfragen von Präsentations-, Folien- und Text‑Frame‑Umfängen**

Die [IHyperlinkQueries](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkqueries/)‑Schnittstelle ist über [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) und [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) verfügbar. Jeder Umfang unterstützt dieselben Abfragen:

- [getHyperlinkClicks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) gibt Container mit einer Klick‑Aktion zurück.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) gibt Container mit einer Mouse‑Over‑Aktion zurück.
- [getAnyHyperlinks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) gibt Container zurück, die eine oder beide Aktionen besitzen.

Das folgende Beispiel erstellt `hyperlink-audit-input.pptx` mit einem externen Klick‑Link, einem Datei‑Mouse‑Over‑Link, interner Folien‑Navigation, einem Text‑Mouse‑Over‑Link und einer Makro‑Aktion. Es führt keine dieser Aktionen aus. Die gleichen drei Abfragen funktionieren in jedem Umfang; die Zähler beschreiben Container, nicht Aktions‑Summen. Der Text‑Frame‑Umfang schließt die eigenen Links des umgebenden Shapes aus.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für dieses Beispiel melden Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Mouse‑Over‑Container und drei Container mit einer beliebigen Aktion. Die Text‑Frame‑Abfrage meldet einen Container in jeder Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [IHyperlink.getActionType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#getActionType--) , um eine Aktion zu interpretieren, bevor Sie ihr Ziel interpretieren. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/de/java/com.aspose.slides/hyperlinkactiontype/) decken mehr als Web‑Navigation ab:

| Werte | Bedeutung für ein Audit |
| --- | --- |
| `Hyperlink` | Externer Hyperlink; prüfen Sie die URL und ihr Schema. |
| `JumpSpecificSlide` | Interne Navigation zu einer bestimmten Folie. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Eingebaute Folien‑Navigation, im Präsentations‑Kontext aufgelöst. |
| `JumpEndShow`, `StartCustomSlideShow` | Beendet die aktuelle Show oder startet eine benutzerdefinierte Show. |
| `StartMacro` | Ein Makro ausführen. |
| `StartProgram` | Ein Programm starten. |
| `OpenFile`, `OpenPresentation` | Eine Datei bzw. eine andere Präsentation öffnen; separat von Web‑URLs prüfen. |
| `StartStopMedia` | Medienwiedergabe starten oder stoppen. |
| `NoAction`, `Unknown` | Keine Navigationsaktion oder eine nicht erkannte Aktion, die geprüft werden muss. |

Lesen Sie externe Ziele mit [getExternalUrl](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#getExternalUrl--) , und spezifische interne Ziele mit [getTargetSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#getTargetSlide--). Interne Aktionen und eingebaute Befehle können keine externe URL haben; eine leere URL bedeutet nicht, dass der Container keine Aktion hat. Bewahren Sie den von [getExternalUrlOriginal](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) zurückgegebenen Wert auf, wenn er von der normalisierten URL abweicht, und fügen Sie den von [getTooltip](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#getTooltip--) zurückgegebenen Tooltip hinzu, falls verfügbar.

### **Hyperlinks berichten, bereinigen und verifizieren**

Das folgende Java‑Beispiel liest eine vorhandene Präsentation (verwenden Sie die oben erstellte Datei), schreibt `hyperlink-audit.json`, wendet eine Richtlinie an, speichert `hyperlink-sanitized.pptx` und öffnet sie erneut, um beide Aktivierungstypen zu prüfen. Es sammelt Container, bevor sie geändert werden, und verwendet Referenzgleichheit, um die doppelte Verarbeitung desselben Containers zu vermeiden. Präsentations‑Abfragen decken normale Folien ab; für ein paketweites Inventar werden zudem explizit Master, Layouts, Notizen und die Notizen‑ und Handzettel‑Master abgefragt, falls vorhanden.

Der Bericht speichert einen eins‑basierten Folien‑Index und, falls verfügbar, [getSlideId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/#getSlideId--). [ISlideComponent.getSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecomponent/#getSlide--) liefert die zugehörige Folie für unterstützte Container. Master, Layouts und Notizen haben keinen gewöhnlichen Folien‑Index und werden über ihren Umfang identifiziert. Shape‑Container und Text‑Abschnitt‑Formatierungs‑Container werden separat gekennzeichnet; andere Containertypen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichtslokale ID, sodass seine beiden Aktionen korreliert werden können. Der Bericht speichert Aktionstypen als die von der Java‑Aufzählung definierten Ganzzahl‑Konstanten.

Diese bewusst restriktive Anwendungsrichtlinie erlaubt nur absolute HTTPS‑URLs und gültige interne Folien‑Ziele. Sie verwirft Makros, Programme, Datei‑Aktionen, andere Diashow‑Aktionen, unbekannte Aktionen und andere URL‑Schemata. Diese Ablehnungen sind Richtlinien‑Entscheidungen, kein Sicherheitsurteil von Aspose.Slides. HTTPS allein schafft kein Vertrauen: Fügen Sie Host‑Whitelist‑ und weitere Prüfungen für Ihre Anwendung hinzu. Sowohl ursprüngliche als auch normalisierte externe URLs werden geprüft. Das Beispiel prüft Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Behebung unterstützt der Container's [getHyperlinkManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) und [removeHyperlinkMouseOver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Landing‑Page ersetzt; andere verbotene Klicks und Mouse‑Over‑Aktionen werden unabhängig entfernt. Setzen Sie `replaceExternalClicks` auf `false`, um alle Richtlinienverstöße zu entfernen. Wählen Sie vor der Bereitstellung eine von der Anwendung bereitgestellte Ersatz‑Seite.

Das Export‑Flag im Bericht verwendet eine konservative PDF‑Prüfrichtlinie: Mouse‑Over‑Aktionen und alles außer einem externen Link oder einem spezifischen Sprung zu einer Folie werden als potenziell nicht unterstützt markiert. Es ist ein Hinweis zur Überprüfung, kein Fähigkeitstest oder eine Garantie, dass nicht markierte Links den Export überleben. Unterstützte [PDF](/slides/de/java/convert-powerpoint-to-pdf/)‑ und [HTML](/slides/de/java/convert-powerpoint-to-html/)‑Exporte können Hyperlinks erhalten, abhängig von der Aktion, den Export‑Optionen und dem Viewer. Raster‑[Bilder](/slides/de/java/convert-powerpoint-to-png/) und -[Video](/slides/de/java/convert-powerpoint-to-video/) können interaktive Hyperlinks nicht erhalten; markieren Sie jede Aktion beim Auditing für diese Ausgaben.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Serialisiere die flachen Zeilen dieses Berichts ohne zusätzliche JSON-Abhängigkeit.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Mit dem oben erstellten Eingabedokument enthält der Bericht fünf Aktionszeilen. Der Datei‑Mouse‑Over‑Link und der Makro‑Klick werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Verifizierung gibt null verbotene Aktionen aus. Ein Eingabedokument mit einem verbotenen externen Klick‑URL testet ebenfalls den Ersetzungs‑Zweig. Ein Container mit einem erlaubten Klick und einem verbotenen Mouse‑Over behält seine Klick‑Aktion.

Diese selektive Bereinigung unterscheidet sich von [removeAllHyperlinks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), das beide Aktivierungstypen im gesamten ausgewählten Umfang entfernt, unabhängig von Richtlinien. Die Verifizierung prüft hier nur Hyperlink‑Aktionen; sie entfernt keine eingebetteten VBA‑Projekte, OLE‑Objekte oder anderen aktiven Inhalt und validiert nicht eine exportierte PDF‑ oder HTML‑Datei.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder seiner ersten Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink zielt auf eine einzelne Folie. Um zu einem Abschnitt zu navigieren, verlinken Sie zur ersten Folie dieses Abschnitts.

**Kann ich einem Master‑Folienelement einen Hyperlink zuweisen, sodass er auf allen Folien funktioniert?**

Ja. Master‑Folien‑ und Layout‑Elemente unterstützen Hyperlinks. Links auf diesen Elementen stehen während der Bildschirmanzeige auf Folien zur Verfügung, die den entsprechenden Master oder das Layout verwenden.

**Werden Hyperlinks beim Exportieren zu PDF, HTML, Bildern oder Video erhalten bleiben?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks erhalten; Raster‑Bilder und Video können das nicht. Siehe die Export‑Hinweise in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).