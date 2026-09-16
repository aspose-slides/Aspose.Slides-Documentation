---
title: Verwalten von Präsentations-Hyperlinks unter Android
linktitle: Hyperlinks verwalten
type: docs
weight: 20
url: /de/androidjava/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Text-Hyperlink
- Folien-Hyperlink
- Form-Hyperlink
- Bild-Hyperlink
- Video-Hyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Hinzufügen, Formatieren, Aktualisieren und Entfernen von Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android über Java, anhand von Java-Beispielen."
---
## **Einleitung**

Ein Hyperlink verbindet Präsentationsinhalte mit einer Website oder einem Ort innerhalb der Präsentation. In PowerPoint dienen Hyperlinks typischerweise zwei Zwecken:

* Öffnen einer Website über Text, eine Form oder einen Medienrahmen.
* Navigieren zu einer anderen Folie, beispielsweise von einem Inhaltsverzeichnis.

Aspose.Slides für Android via Java ermöglicht das Hinzufügen dieser Links, das Steuern ihres Aussehens und Sounds, das Aktualisieren ihrer Eigenschaften und das Entfernen. Die nachstehenden Beispiele zeigen, wie man mit Hyperlinks an einzelnen Elementen arbeitet und wie man Hyperlinks auf Präsentations-, Folien‑ oder Text‑Frame‑Ebene abruft.

{{% alert color="info" title="Note" %}}
Sie können Präsentationen auch mit dem [kostenlosen Online‑Aspose‑PowerPoint‑Editor](https://products.aspose.app/slides/de/editor) bearbeiten.
{{% /alert %}} 

## **URL‑Hyperlinks hinzufügen**

Sie können einer Website‑URL Text, einer Form oder einem Medienrahmen zuweisen. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den anklickbaren Bereich: Ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

### **URL‑Hyperlinks zu Text hinzufügen**

Um Text mit einer Website zu verknüpfen, übergeben Sie ein [Hyperlink](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/hyperlink/) an die Methode [setHyperlinkClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) des Text‑Portions, wie unten gezeigt. Nur dieser Textabschnitt wird anklickbar.

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

### **URL‑Hyperlinks zu Formen und Medien‑Frames hinzufügen**

Um eine Form oder einen Rahmen anklickbar zu machen, rufen Sie deren Methode [setHyperlinkClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) auf. Der Hyperlink gehört zum Objekt selbst und nicht zu einem Textabschnitt darin.

Der gleiche Ansatz gilt für Bild‑, Audio‑ und Video‑Frames: Weisen Sie dem Frame den Hyperlink zu und rufen Sie bei Bedarf [setTooltip](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) auf.

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

Interne Hyperlinks ermöglichen es Lesern, von einem Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [setInternalHyperlinkClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-), um den Text „Seite 2“ auf der ersten Folie mit der zweiten Folie zu verknüpfen.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Die Methode [setColorSource](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) von [IHyperlink](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/) bestimmt, ob ein Hyperlink die Hyperlink‑Farbe der Präsentation oder die Formatierung des Textabschnitts verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/hyperlinkcolorsource/) und setzen die Füllfarbe des Abschnitts. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen berücksichtigen diese Einstellung nicht.

Das folgende Beispiel fügt zwei Text‑Hyperlinks zur selben Folie hinzu. Der erste verwendet eine rote Textfüllung, der zweite behält die Standard‑Hyperlink‑Farbe bei.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Ein Hyperlink kann beim Aktivieren einen Sound abspielen oder einen bereits laufenden Sound stoppen. Verwenden Sie die folgenden Methoden, um dieses Verhalten zu konfigurieren:

- [IHyperlink.setSound](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) legt die dem Hyperlink zugeordnete Audiodatei fest.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) steuert, ob das Aktivieren des Hyperlinks den vorherigen Sound stoppt.

#### **Hyperlink‑Sound hinzufügen**

Das folgende Beispiel lädt `sampleaudio.wav` und verknüpft es mit einem Button auf der ersten Folie. Durch Klicken des Buttons wird der Sound abgespielt und zur nächsten Folie navigiert. Eine zweite Form auf derselben Folie stoppt den vorherigen Sound beim Klicken, ohne eine Navigation auszuführen.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

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

Das folgende Beispiel öffnet die oben erstellte Präsentation und liest den Hyperlink‑Audio des ersten Shapes über [getSound](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#getSound--) und [getBinaryData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudio/#getBinaryData--) in den Speicher.

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

### **Tooltip und Interaktionseinstellungen**

Sie können nach der Zuweisung eines Hyperlinks zu Text oder einer Form die folgenden [IHyperlink](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/)‑Methoden aufrufen:

- [setTooltip](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) legt den Text fest, den ein Betrachter als Hinweis zum Link anzeigen kann.
- [setTargetFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) gibt den Ziel‑Frame innerhalb eines übergeordneten HTML‑Framesets an, falls zutreffend.
- [setHistory](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) bestimmt, ob das Aktivieren des Links dessen Ziel zur Liste der angesehenen Hyperlinks hinzufügt.
- [setHighlightClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) steuert, ob der Hyperlink beim Klicken hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [getAnyHyperlinks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) zum Sammeln von Hyperlink‑Containern, einschließlich Text‑Abschnitt‑Links, bevor Sie sie ändern. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie ausschließlich [removeHyperlinkClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) oder [removeHyperlinkMouseOver](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) auf; das Entfernen einer Klick‑Aktion entfernt nicht die entsprechende Maus‑Über‑Aktion.

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

Für uneingeschränktes Entfernen entfernt [removeAllHyperlinks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) beide Aktivierungstypen im ausgewählten Geltungsbereich in einem Aufruf. Für selektive Bereinigung und Abdeckung von Master‑Folien, Layouts und Notizen siehe [Berichten, Bereinigen und Verifizieren von Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Ein vollständiges Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verteilen, erfassen Sie deren interaktive Aktionen sowie deren Web‑Links. [getAnyHyperlinks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) liefert Objekte vom Typ [IHyperlinkContainer](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkcontainer/), nicht eine flache Liste von URL‑Strings. Untersuchen Sie sowohl [getHyperlinkClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) als auch [getHyperlinkMouseOver](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) jedes Containers. Sie sind unabhängig: derselbe Container kann beide Aktionen enthalten, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container benötigt.

Das reine Abfragen von Shape‑Level‑Hyperlinks kann Links übersehen, die Text‑Abschnitten zugeordnet sind. Fragen Sie stattdessen den entsprechenden Geltungsbereich ab und behalten Sie die zurückgegebenen Container, damit Sie deren Aktionen später aktualisieren oder entfernen können.

### **Abfrage von Präsentations‑, Folien‑ und Text‑Frame‑Geltungsbereichen**

Das Interface [IHyperlinkQueries](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkqueries/) ist über [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) und [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) verfügbar. Jeder Geltungsbereich unterstützt dieselben Abfragen:

- [getHyperlinkClicks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) gibt Container mit einer Klick‑Aktion zurück.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) gibt Container mit einer Maus‑Über‑Aktion zurück.
- [getAnyHyperlinks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) gibt Container zurück, die eine oder beide Aktionen besitzen.

Das folgende Beispiel erstellt `hyperlink-audit-input.pptx` mit einem externen Klick‑Link, einem Datei‑Maus‑Über‑Link, interner Folien‑Navigation, einem Text‑Maus‑Über‑Link und einer Makro‑Aktion. Es führt keine dieser Aktionen aus. Die gleichen drei Abfragen funktionieren in jedem Geltungsbereich; die Zählungen beschreiben Container, nicht die Gesamtzahl der Aktionen. Der Text‑Frame‑Geltungsbereich schließt die eigenen Links des umgebenden Shapes aus.

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

Für dieses Beispiel berichten die Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Maus‑Über‑Container und drei Container mit einer beliebigen Aktion. Die Text‑Frame‑Abfrage liefert jeweils einen Container pro Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [IHyperlink.getActionType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#getActionType--) zur Interpretation einer Aktion, bevor Sie ihr Ziel interpretieren. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/hyperlinkactiontype/) decken mehr als reine Web‑Navigation ab:

| Werte | Bedeutung für die Prüfung |
| --- | --- |
| `Hyperlink` | Externer Hyperlink; URL und Schema prüfen. |
| `JumpSpecificSlide` | Interne Navigation zu einer bestimmten Folie. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Eingebaute Folien‑Show‑Navigation, im Präsentationskontext aufgelöst. |
| `JumpEndShow`, `StartCustomSlideShow` | Aktuelle Show beenden bzw. benutzerdefinierte Show starten. |
| `StartMacro` | Makro ausführen. |
| `StartProgram` | Programm starten. |
| `OpenFile`, `OpenPresentation` | Datei oder weitere Präsentation öffnen; getrennt von Web‑URLs prüfen. |
| `StartStopMedia` | Medien‑Wiedergabe starten oder stoppen. |
| `NoAction`, `Unknown` | Keine Navigationsaktion bzw. unbekannte Aktion, die überprüft werden muss. |

Lesen Sie externe Ziele mit [getExternalUrl](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) und spezifische interne Ziele mit [getTargetSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Interne Aktionen und eingebaute Befehle haben möglicherweise keine externe URL; eine leere URL bedeutet nicht, dass der Container keine Aktion besitzt. Bewahren Sie den Wert von [getExternalUrlOriginal](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) auf, wenn er von der normalisierten URL abweicht, und fügen Sie den Tooltip von [getTooltip](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) hinzu, sofern vorhanden.

### **Hyperlinks berichten, bereinigen und prüfen**

Das folgende Java‑Beispiel liest eine vorhandene Präsentation (die oben erstellte Datei), schreibt `hyperlink-audit.json`, wendet eine Richtlinie an, speichert `hyperlink-sanitized.pptx` und öffnet sie erneut, um beide Aktivierungstypen erneut zu prüfen. Es sammelt Container, bevor es sie ändert, und nutzt Referenzgleichheit, um eine doppelte Verarbeitung zu vermeiden. Präsentations‑Abfragen decken gewöhnliche Folien ab; für ein paketweites Inventar werden zusätzlich explizit Master‑Folien, Layouts, Notizen sowie die Notiz‑ und Handzettel‑Master‑Folien abgefragt, falls vorhanden.

Der Bericht speichert einen 1‑basierten Folien‑Index und [getSlideId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) sofern verfügbar. [ISlideComponent.getSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecomponent/#getSlide--) liefert die zugehörige Folie für unterstützte Container. Master‑Folien, Layouts und Notizen besitzen keinen gewöhnlichen Folien‑Index und werden über ihren Geltungsbereich identifiziert. Shape‑Container und Text‑Abschnitt‑Formatierungs‑Container werden separat bezeichnet; andere Containertypen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichtslokale ID, damit seine beiden Aktionen korreliert werden können. Die Berichtsdaten speichern Aktionstypen als die Ganzzahl‑Konstanten der Java‑Enumeration.

Diese bewusst restriktive Anwendungspolitik erlaubt nur absolute HTTPS‑URLs und gültige interne Folienziele. Sie verwirft Makros, Programme, Datei‑Aktionen, andere Folien‑Show‑Aktionen, unbekannte Aktionen und andere URL‑Schemen. Diese Ablehnungen sind Richtlinien‑Entscheidungen, nicht ein Sicherheitsurteil von Aspose.Slides. HTTPS allein begründet kein Vertrauen: Ergänzen Sie Host‑Allow‑Lists und weitere Prüfungen für Ihre Anwendung. Sowohl originale als auch normalisierte externe URLs werden geprüft. Das Beispiel prüft Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Behebung unterstützt das [getHyperlinkManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) des Containers [setExternalHyperlinkClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) und [removeHyperlinkMouseOver](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Landing‑Page ersetzt; andere verbotene Klick‑ und Maus‑Über‑Aktionen werden unabhängig entfernt. Setzen Sie `replaceExternalClicks` auf `false`, um alle Richtlinien‑Verstöße zu entfernen. Wählen Sie vor dem Einsatz eine anwendungsinterne Ersatz‑Seite.

Das Export‑Flag des Berichts verwendet eine konservative PDF‑Prüf‑Richtlinie: Maus‑Über‑Aktionen und alles außer externen Links bzw. spezifischen Folien‑Sprüngen werden als potenziell nicht unterstützt markiert. Es ist ein Prüfungshinweis, kein Fähigkeitstest und keine Garantie, dass nicht markierte Links den Export überleben. Unterstützte [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/)‑ und [HTML](/slides/de/androidjava/convert-powerpoint-to-html/)‑Exporte können Hyperlinks je nach Aktion, Export‑Optionen und Betrachter erhalten; Raster‑[Bilder](/slides/de/androidjava/convert-powerpoint-to-png/) und -[Videos](/slides/de/androidjava/convert-powerpoint-to-video/) können interaktive Hyperlinks nicht bewahren; kennzeichnen Sie jede Aktion, wenn Sie für diese Ausgaben prüfen.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
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
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
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
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

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

Mit dem oben erstellten Input enthält der Bericht fünf Aktions‑Zeilen. Der Datei‑Maus‑Über‑Link und das Makro‑Klick‑Element werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Verifikation gibt null verbotene Aktionen aus. Ein Input mit einer verbotenen externen Klick‑URL demonstriert zudem den Ersetzungs‑Zweig. Ein Container mit einem zulässigen Klick und einem verbotenen Maus‑Über‑Link behält seine Klick‑Aktion bei.

Diese selektive Bereinigung unterscheidet sich von [removeAllHyperlinks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), das beide Aktivierungstypen im gewählten Geltungsbereich unabhängig von Richtlinien entfernt. Die hier durchgeführte Verifikation prüft ausschließlich Hyperlink‑Aktionen; sie entfernt weder eingebettete VBA‑Projekte, OLE‑Objekte noch andere aktive Inhalte und validiert nicht ein exportiertes PDF‑ oder HTML‑Dokument.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder dessen erster Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink zielt auf eine einzelne Folie. Um zu einem Abschnitt zu navigieren, verknüpfen Sie mit der ersten Folie dieses Abschnitts.

**Kann ich einem Master‑Folienelement einen Hyperlink zuweisen, sodass er auf allen Folien funktioniert?**

Ja. Elemente von Master‑Folien und Layouts unterstützen Hyperlinks. Links auf diesen Elementen stehen während der Bildschirmanzeige auf allen Folien, die den entsprechenden Master oder das Layout verwenden, zur Verfügung.

**Werden Hyperlinks beim Export nach PDF, HTML, Bildern oder Video erhalten bleiben?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks bewahren; Raster‑Bilder und Video können das nicht. Siehe die Export‑Hinweise im Abschnitt [Berichten, Bereinigen und Verifizieren von Hyperlinks](#report-sanitize-and-verify-hyperlinks).