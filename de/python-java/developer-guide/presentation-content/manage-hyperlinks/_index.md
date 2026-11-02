---
title: Verwalten von Präsentations-Hyperlinks in Python via Java
linktitle: Hyperlinks verwalten
type: docs
weight: 20
url: /de/python-java/manage-hyperlinks/
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
- Python
- Java
- Aspose.Slides
description: "Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java hinzufügen, formatieren, aktualisieren und entfernen, anhand von Python-Beispielen."
---
## **Einführung**

Ein Hyperlink verbindet Präsentationsinhalte mit einer Website oder einem Ort innerhalb der Präsentation. In PowerPoint dienen Hyperlinks üblicherweise zwei Zwecken:

* Öffnen einer Website über Text, eine Form oder einen Medienrahmen.
* Navigieren zu einer anderen Folie, zum Beispiel von einem Inhaltsverzeichnis.

Aspose.Slides für Python via Java ermöglicht das Hinzufügen dieser Links, das Steuern von Aussehen und Klang, das Aktualisieren ihrer Eigenschaften und das Entfernen. Die nachfolgenden Beispiele zeigen, wie man mit Hyperlinks auf einzelnen Elementen arbeitet und wie man Hyperlinks auf Präsentations‑, Folien‑ oder Textfeld‑Ebene abruft.

{{% alert color="info" title="Note" %}}
Sie können Präsentationen auch mit dem [kostenlosen Online‑Aspose‑PowerPoint‑Editor](https://products.aspose.app/slides/editor) bearbeiten.
{{% /alert %}} 

## **URL‑Hyperlinks hinzufügen**

Sie können einer URL einer Website Text, einer Form oder einem Medienrahmen zuweisen. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den anklickbaren Bereich: Ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

Für Präsentationen mit relativen Hyperlinks siehe [Manage the Hyperlink Base](/slides/de/python-java/presentation-properties/#manage-the-hyperlink-base), um die dokumentweite Basis zu lesen, zu ändern oder zu löschen.

### **URL‑Hyperlinks zu Text hinzufügen**

Um Text mit einer Website zu verknüpfen, übergeben Sie ein [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) an die [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick)-Methode des Textabschnitts, wie unten gezeigt. Nur dieser Textabschnitt wird anklickbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **URL‑Hyperlinks zu Formen und Medienrahmen hinzufügen**

Um eine Form oder einen Rahmen anklickbar zu machen, rufen Sie deren [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick)-Methode auf. Der Hyperlink gehört zum Objekt selbst und nicht zu einem enthaltenen Textabschnitt.

Der gleiche Ansatz gilt für Bild‑, Audio‑ und Video‑Frames: Weisen Sie dem Frame den Hyperlink zu und rufen Sie bei Bedarf [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) auf.

Das folgende Beispiel macht ein Rechteck anklickbar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hyperlinks zur Erstellung eines Inhaltsverzeichnisses verwenden**

Interne Hyperlinks ermöglichen es Lesern, von einem Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick), um den Text „Seite 2“ auf der ersten Folie mit der zweiten Folie zu verknüpfen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hyperlinks formatieren**

### **Farbe**

Die [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource)-Methode von [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) bestimmt, ob ein Hyperlink die Präsentations‑Hyperlink‑Farbe oder die Formatierung des Textabschnitts verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) und setzen die Füllfarbe des Abschnitts. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen unterstützen diese Einstellung nicht.

Das folgende Beispiel fügt zwei Text‑Hyperlinks zur gleichen Folie hinzu. Der erste verwendet eine rote Textfüllung, der zweite behält die Standard‑Hyperlink‑Farbe bei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Ton**

Ein Hyperlink kann beim Aktivieren einen Ton abspielen oder einen bereits spielenden Ton stoppen. Verwenden Sie die folgenden Methoden, um dieses Verhalten zu konfigurieren:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) legt die dem Hyperlink zugeordnete Audiodatei fest.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) bestimmt, ob das Aktivieren des Hyperlinks den vorherigen Ton stoppt.

#### **Hyperlink‑Ton hinzufügen**

Das folgende Beispiel lädt `sampleaudio.wav` und ordnet es einem Button auf der ersten Folie zu. Das Klicken des Buttons spielt den Ton ab und navigiert zur nächsten Folie. Eine zweite Form auf dieser Folie stoppt den vorherigen Ton beim Klicken, ohne eine Navigation auszuführen.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Hyperlink‑Ton extrahieren**

Das folgende Beispiel öffnet die oben erstellte Präsentation und liest den Hyperlink‑Audiocode der ersten Form über [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) und [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) in den Speicher.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Tooltip‑ und Interaktionseinstellungen**

Sie können nach der Zuordnung eines Hyperlinks zu Text oder einer Form die folgenden [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/)‑Methoden aufrufen:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) legt den Text fest, den ein Betrachter als Hinweis für den Link anzeigen kann.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) gibt den Ziel‑Frame innerhalb eines übergeordneten HTML‑Framesets an, falls anwendbar.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) steuert, ob das Aktivieren des Links sein Ziel zur Liste der angesehenen Hyperlinks hinzufügt.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) bestimmt, ob der Hyperlink beim Klicken hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks), um Hyperlink‑Container, einschließlich Text‑Abschnitt‑Links, zu sammeln, bevor Sie sie ändern. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie ausschließlich [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) oder [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) auf; das Entfernen einer Klick‑Aktion entfernt nicht die entsprechende Maus‑Über‑Aktion.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Für bedingungsloses Entfernen entfernt [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) beide Aktivierungstypen im ausgewählten Umfang mit einem Aufruf. Für selektive Bereinigung und Abdeckung von Master‑Folien, Layouts und Notizen siehe [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Ein vollständiges Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verteilen, erfassen Sie ihre interaktiven Aktionen sowie ihre Web‑Links. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) liefert Hyperlink‑Container wie [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) und [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/)-Objekte, nicht eine flache Liste von URL‑Strings. Untersuchen Sie sowohl [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) als auch [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) bei jedem Container. Sie sind unabhängig: Der gleiche Container kann beide Aktionen bereitstellen, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container benötigen kann.

Das reine Abfragen von Hyperlinks auf Form‑Ebene kann Links, die Text‑Abschnitten zugewiesen sind, übersehen. Fragen Sie stattdessen den entsprechenden Umfang ab und bewahren Sie die zurückgegebenen Container, sodass Sie ihre Aktionen später aktualisieren oder entfernen können.

### **Präsentations‑, Folien‑ und Text‑Frame‑Umfänge abfragen**

Die Klasse [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) ist über [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) und [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) verfügbar. Jeder Umfang unterstützt dieselben Abfragen:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) liefert Container mit einer Klick‑Aktion.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) liefert Container mit einer Maus‑Über‑Aktion.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) liefert Container mit einer oder beiden Aktionen.

Das folgende Beispiel erstellt `hyperlink-audit-input.pptx` mit einem externen Klick‑Link, einem Dateimaus‑Über‑Link, einer internen Folien‑Navigation, einem Text‑Maus‑Über‑Link und einer Makro‑Aktion. Es führt keine dieser Aktionen aus. Die gleichen drei Abfragen funktionieren in jedem Umfang; die Zählungen beschreiben Container, nicht Aktionszahlen. Der Text‑Frame‑Umfang schließt die eigenen Links der umgebenden Form aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Für dieses Beispiel melden Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Maus‑Über‑Container und drei Container mit einer beliebigen Aktion. Die Text‑Frame‑Abfrage meldet einen Container in jeder Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType), um eine Aktion zu interpretieren, bevor Sie ihr Ziel interpretieren. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) decken mehr als reine Web‑Navigation ab:

| Werte | Bedeutung für ein Audit |
| --- | --- |
| `Hyperlink` | Externer Hyperlink; URL und Schema prüfen. |
| `JumpSpecificSlide` | Interne Navigation zu einer bestimmten Folie. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Eingebaute Folien‑Show‑Navigation, im Folien‑Show‑Kontext aufgelöst. |
| `JumpEndShow`, `StartCustomSlideShow` | Aktuelle Show beenden bzw. benutzerdefinierte Show starten. |
| `StartMacro` | Makro ausführen. |
| `StartProgram` | Programm starten. |
| `OpenFile`, `OpenPresentation` | Datei oder andere Präsentation öffnen; getrennt von Web‑URLs prüfen. |
| `StartStopMedia` | Medien‑Wiedergabe starten oder stoppen. |
| `NoAction`, `Unknown` | Keine Navigationsaktion bzw. unbekannte Aktion, die überprüft werden muss. |

Lesen Sie externe Ziele mit [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) und spezifische interne Ziele mit [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). Interne Aktionen und eingebaute Befehle besitzen möglicherweise keine externe URL; eine leere URL bedeutet nicht, dass der Container keine Aktion hat. Bewahren Sie den Wert von [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) auf, wenn er vom normalisierten URL abweicht, und fügen Sie den Tooltip von [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) hinzu, falls vorhanden.

### **Hyperlinks melden, bereinigen und verifizieren**

Das folgende Python‑Beispiel liest eine vorhandene Präsentation (verwenden Sie die oben erstellte Datei), schreibt `hyperlink-audit.json`, wendet eine Richtlinie an, speichert `hyperlink-sanitized.pptx` und öffnet sie erneut, um beide Aktivierungstypen erneut zu prüfen. Es sammelt Container, bevor sie geändert werden, und nutzt Referenzgleichheit, um eine doppelte Verarbeitung zu vermeiden. Präsentations‑Abfragen decken gewöhnliche Folien ab; für ein paketweites Inventar werden explizit auch Master‑Folien, Layouts, Notizen sowie die Notizen‑ und Handzettel‑Master abgefragt, falls vorhanden.

Der Bericht speichert einen einsbasierten Folien‑Index und [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId), sofern verfügbar. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) liefert die zugehörige Folie für unterstützte Container. Master, Layouts und Notizen besitzen keinen gewöhnlichen Folien‑Index und werden durch ihren Umfang identifiziert. Form‑Container und Text‑Abschnitt‑Format‑Container werden getrennt gekennzeichnet; andere Container‑Typen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichtslokale ID, sodass seine beiden Aktionen korreliert werden können. Der Bericht speichert Aktionstypen als die Ganzzahl‑Konstanten der Java‑Aufzählung.

Diese bewusst restriktive Anwendungs‑Richtlinie erlaubt nur absolute HTTPS‑URLs und gültige interne Folien‑Ziele. Sie verwirft Makros, Programme, Datei‑Aktionen, andere Folien‑Show‑Aktionen, unbekannte Aktionen und andere URL‑Schemen. Diese Ablehnungen sind Richtlinien‑Entscheidungen, keine Aspose.Slides‑Sicherheitsbewertung. HTTPS allein begründet kein Vertrauen: Ergänzen Sie Host‑Whitelist‑ und weitere Prüfungen für Ihre Anwendung. Sowohl originale als auch normalisierte externe URLs werden geprüft. Das Beispiel prüft Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Bereinigung unterstützt das [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) des Containers [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) und [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Landing‑Page ersetzt; andere verbotene Klick‑ und Maus‑Über‑Aktionen werden unabhängig voneinander entfernt. Setzen Sie `replace_external_clicks` auf `False`, um alle Richtlinien‑Verstöße zu entfernen. Wählen Sie vor der Bereitstellung eine anwendungsinterne Ersatz‑Seite.

Die Export‑Flagge des Berichts verwendet eine konservative PDF‑Überprüfungs‑Richtlinie: Maus‑Über‑Aktionen und alles außer einem externen Link oder einem spezifischen Folien‑Sprung werden potenziell nicht unterstützt markiert. Es ist ein Hinweis zur Überprüfung, kein Fähigkeitstest und keine Garantie, dass unmarkierte Links den Export überstehen. Unterstützte [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/)‑ und [HTML](/slides/de/python-java/convert-powerpoint-to-html/)‑Exporte können Hyperlinks je nach Aktion, Export‑Optionen und Viewer erhalten; Raster‑[images](/slides/de/python-java/convert-powerpoint-to-png/)‑ und [video](/slides/de/python-java/convert-powerpoint-to-video/)‑Exporte können interaktive Hyperlinks nicht erhalten; kennzeichnen Sie jede Aktion, wenn Sie für diese Ausgaben prüfen.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Mit dem oben erstellten Input enthält der Bericht fünf Aktions‑Zeilen. Der Dateimaus‑Über‑Link und das Makro‑Klick‑Element werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Verifikation gibt null verbotene Aktionen aus. Ein Input mit einer verbotenen externen Klick‑URL demonstriert ebenfalls den Ersetzungs‑Zweig. Ein Container mit erlaubtem Klick und verbotener Maus‑Über‑Aktion behält seine Klick‑Aktion.

Diese selektive Bereinigung unterscheidet sich von [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), das beide Aktivierungstypen im ausgewählten Umfang ungeachtet der Richtlinie entfernt. Die Verifikation prüft hier ausschließlich Hyperlink‑Aktionen; sie entfernt nicht eingebettete VBA‑Projekte, OLE‑Objekte oder andere aktive Inhalte und validiert keine exportierte PDF‑ oder HTML‑Datei.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder seiner ersten Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink zielt auf eine einzelne Folie. Um zu einem Abschnitt zu navigieren, verlinken Sie zur ersten Folie dieses Abschnitts.

**Kann ich einem Master‑Folienelement einen Hyperlink zuweisen, sodass er auf allen Folien funktioniert?**

Ja. Elemente von Master‑Folien und Layouts unterstützen Hyperlinks. Links auf diesen Elementen stehen während der Vorführung auf allen Folien, die den entsprechenden Master oder das Layout verwenden, zur Verfügung.

**Werden Hyperlinks beim Export nach PDF, HTML, Bildern oder Video erhalten?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks erhalten; Raster‑Bilder und Video können keine interaktiven Hyperlinks bewahren. Siehe die Export‑Hinweise in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).