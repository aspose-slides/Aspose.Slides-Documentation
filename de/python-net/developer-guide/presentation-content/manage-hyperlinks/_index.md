---
title: Präsentations-Hyperlinks in Python verwalten
linktitle: Hyperlinks verwalten
type: docs
weight: 20
url: /de/python-net/manage-hyperlinks/
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
- Aspose.Slides
description: "Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET hinzufügen, formatieren, aktualisieren und entfernen, anhand von Python-Beispielen."
---
## **Einführung**

Ein Hyperlink verbindet Präsentationsinhalte mit einer Website oder einer Stelle innerhalb der Präsentation. In PowerPoint dienen Hyperlinks üblicherweise zwei Zwecken:

* Öffnen einer Website über Text, eine Form oder einen Medienrahmen.
* Navigieren zu einer anderen Folie, zum Beispiel von einem Inhaltsverzeichnis.

Aspose.Slides für Python via .NET ermöglicht das Hinzufügen dieser Links, die Steuerung von Aussehen und Klang, das Aktualisieren ihrer Eigenschaften und das Entfernen. Die nachfolgenden Beispiele zeigen, wie man mit Hyperlinks an einzelnen Elementen arbeitet und wie man Hyperlinks auf Präsentations‑, Folien‑ oder Text‑Frame‑Ebene abruft.

{{% alert color="info" title="Note" %}}
Sie können Präsentationen auch mit dem [kostenlosen Online-Aspose PowerPoint-Editor](https://products.aspose.app/slides/de/editor) bearbeiten.
{{% /alert %}}

## **URL‑Hyperlinks hinzufügen**

Sie können einer Textstelle, einer Form oder einem Medienrahmen eine Website‑URL zuweisen. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den anklickbaren Bereich: Ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

### **URL‑Hyperlinks zu Text hinzufügen**

Um Text mit einer Website zu verknüpfen, weisen Sie dem [Hyperlink](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/) der Textportion die Eigenschaft [hyperlink_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/hyperlink_click/) zu, wie unten gezeigt. Nur dieser Textabschnitt wird anklickbar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **URL‑Hyperlinks zu Formen und Medienrahmen hinzufügen**

Um eine Form oder einen Rahmen anklickbar zu machen, setzen Sie dessen [hyperlink_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/hyperlink_click/)‑Eigenschaft. Der Hyperlink gehört zum Objekt selbst und nicht zu einer Textportion darin.

Dies gilt gleichermaßen für Bild‑, Audio‑ und Videorahmen: Weisen Sie dem Rahmen den Hyperlink zu und setzen Sie bei Bedarf das [tooltip](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/tooltip/) des Links.

Das folgende Beispiel macht ein Rechteck anklickbar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks zur Erstellung eines Inhaltsverzeichnisses verwenden**

Interne Hyperlinks ermöglichen es Lesern, von einem Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [set_internal_hyperlink_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/), um den Text „Seite 2“ auf der ersten Folie mit der zweiten Folie zu verknüpfen.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks formatieren**

### **Farbe**

Die Eigenschaft [color_source](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/color_source/) von [Hyperlink](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/) bestimmt, ob ein Hyperlink die Hyperlink‑Farbe der Präsentation oder die Formatierung der Textportion verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkcolorsource/) und setzen die Füllfarbe der Portion. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen berücksichtigen diese Einstellung nicht.

Das folgende Beispiel fügt zwei Text‑Hyperlinks zur gleichen Folie hinzu. Der erste verwendet eine rote Textfüllung, der zweite behält die Standard‑Hyperlink‑Farbe bei.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Sound**

Ein Hyperlink kann beim Aktivieren einen Klang abspielen oder einen bereits spielenden Klang stoppen. Verwenden Sie die folgenden Eigenschaften, um dieses Verhalten zu konfigurieren:

- [Hyperlink.sound](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/sound/) gibt das dem Hyperlink zugeordnete Audio an.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/stop_sound_on_click/) legt fest, ob das Aktivieren des Hyperlinks den vorherigen Klang stoppt.

#### **Hyperlink‑Sound hinzufügen**

Das folgende Beispiel lädt `sampleaudio.wav` und verknüpft es mit einem Button auf der ersten Folie. Ein Klick auf den Button spielt den Klang und navigiert zur nächsten Folie. Eine zweite Form auf derselben Folie stoppt den vorherigen Klang beim Klick, ohne eine Navigation auszuführen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Hyperlink‑Sound extrahieren**

Das folgende Beispiel öffnet die oben erstellte Präsentation und liest das Hyperlink‑Audio der ersten Form über [sound](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/sound/) und [binary_data](https://reference.aspose.com/slides/de/python-net/aspose.slides/audio/binary_data/) in den Speicher ein.

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Tooltip‑ und Interaktionseinstellungen**

Sie können die folgenden [Hyperlink](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/)‑Eigenschaften nach der Zuweisung eines Hyperlinks zu Text oder einer Form aktualisieren:

- [tooltip](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/tooltip/) legt den Text fest, den ein Betrachter als Hinweis zum Link anzeigen kann.
- [target_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/target_frame/) gibt den Ziel‑Frame innerhalb eines übergeordneten HTML‑Framesets an, falls zutreffend.
- [history](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/history/) bestimmt, ob das Aktivieren des Links dessen Ziel zur Historie der angezeigten Hyperlinks hinzufügt.
- [highlight_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/highlight_click/) legt fest, ob der Hyperlink beim Klicken hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [get_any_hyperlinks](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/), um Hyperlink‑Container, einschließlich Text‑Portions‑Links, zu sammeln, bevor Sie sie ändern. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie ausschließlich [remove_hyperlink_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) oder [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) auf; das Entfernen einer Klick‑Aktion entfernt nicht deren Maus‑over‑Gegenstück.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Für eine uneingeschränkte Entfernung entfernt [remove_all_hyperlinks](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) beide Aktivierungstypen im ausgewählten Geltungsbereich in einem Aufruf. Für eine selektive Bereinigung und Abdeckung von Master‑, Layout‑ und Notiz‑Folien siehe [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Ein vollständiges Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verteilen, erfassen Sie deren interaktive Aktionen sowie Web‑Links. [get_any_hyperlinks](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) liefert Objekte vom Typ [IHyperlinkContainer](https://reference.aspose.com/slides/de/python-net/aspose.slides/ihyperlinkcontainer/), nicht eine flache Liste von URL‑Zeichenketten. Prüfen Sie sowohl [hyperlink_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) als auch [hyperlink_mouse_over](https://reference.aspose.com/slides/de/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) jedes Containers. Sie sind unabhängig: Derselbe Container kann beide Aktionen bereitstellen, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container benötigen kann.

Das reine Scannen von Hyperlinks auf Shape‑Ebene kann Links übersehen, die Text‑Portionen zugeordnet sind. Fragen Sie stattdessen den geeigneten Geltungsbereich ab und bewahren Sie die zurückgegebenen Container, damit Sie deren Aktionen später aktualisieren oder entfernen können.

### **Präsentations‑, Folien‑ und Text‑Frame‑Bereiche abfragen**

Die Klasse [HyperlinkQueries](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkqueries/) ist über [Presentation.hyperlink_queries](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/hyperlink_queries/) und [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/hyperlink_queries/) verfügbar. Jeder Geltungsbereich unterstützt dieselben Abfragen:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) gibt Container mit einer Klick‑Aktion zurück.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) gibt Container mit einer Maus‑over‑Aktion zurück.
- [get_any_hyperlinks](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) gibt Container zurück, die eine oder beide Aktionen besitzen.

Das folgende Beispiel erstellt `hyperlink-audit-input.pptx` mit einem externen Klick‑Link, einem Datei‑Maus‑over‑Link, interner Folien‑Navigation, einem Text‑Maus‑over‑Link und einer Makro‑Aktion. Es führt keine dieser Aktionen aus. Die gleichen drei Abfragen funktionieren in jedem Geltungsbereich; die Zählwerte beziehen sich auf Container, nicht auf Aktionssummen. Der Text‑Frame‑Geltungsbereich schließt die eigenen Links des umgebenden Shapes aus.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

In diesem Beispiel melden Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Maus‑over‑Container und drei Container mit einer beliebigen Aktion. Die Text‑Frame‑Abfrage meldet jeweils einen Container pro Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [Hyperlink.action_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/action_type/), um eine Aktion zu interpretieren, bevor Sie ihr Ziel auswerten. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkactiontype/) decken mehr als Web‑Navigation ab:

| Werte | Bedeutung für ein Audit |
| --- | --- |
| `HYPERLINK` | Externer Hyperlink; prüfen Sie die URL und ihr Schema. |
| `JUMP_SPECIFIC_SLIDE` | Interne Navigation zu einer bestimmten Folie. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Eingebaute Präsentationsnavigation, im Präsentationskontext aufgelöst. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Beenden der aktuellen Show bzw. Start einer benutzerdefinierten Show. |
| `START_MACRO` | Ausführen eines Makros. |
| `START_PROGRAM` | Starten eines Programms. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Öffnen einer Datei bzw. einer anderen Präsentation; separat von Web‑URLs prüfen. |
| `START_STOP_MEDIA` | Starten oder Stoppen der Medienwiedergabe. |
| `NO_ACTION`, `UNKNOWN` | Keine Navigationsaktion bzw. nicht erkannte Aktion, die einer Überprüfung bedarf. |

Lesen Sie externe Ziele aus [external_url](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/external_url/) und spezifische interne Ziele aus [target_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/target_slide/). Interne Aktionen und eingebaute Befehle können keine externe URL besitzen; eine leere URL bedeutet nicht, dass der Container keine Aktion hat. Bewahren Sie [external_url_original](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/external_url_original/) auf, wenn sie von der normalisierten URL abweicht, und fügen Sie das [tooltip](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlink/tooltip/) hinzu, falls verfügbar.

### **Hyperlinks melden, bereinigen und verifizieren**

Das folgende Python‑Beispiel liest eine bestehende Präsentation (verwenden Sie die oben erstellte Datei), schreibt `hyperlink-audit.json`, wendet eine Richtlinie an, speichert `hyperlink-sanitized.pptx` und öffnet sie erneut, um beide Aktivierungstypen erneut zu prüfen. Es sammelt Container, bevor sie geändert werden, und fragt jeden Folien‑Geltungsbereich nur einmal ab, um doppelte Verarbeitung zu vermeiden. Präsentations‑Abfragen decken gewöhnliche Folien ab; für ein paketweites Inventar fragt das Beispiel gewöhnliche Folien, Master, Layouts, Notizen sowie die Notiz‑ und Handzettel‑Master ab, sofern vorhanden.

Der Bericht speichert einen einsbasierten Folien‑Index und, falls verfügbar, die [slide_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/slide_id/). Der Sammler behält die zugehörige Folie und den Geltungsbereich neben jedem zurückgegebenen Container. Master, Layouts und Notizen besitzen keinen gewöhnlichen Folien‑Index und werden über ihren Geltungsbereich identifiziert. Shape‑Container und Text‑Portion‑Format‑Container werden getrennt gekennzeichnet; andere Container‑Typen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichtslokale ID, sodass seine beiden Aktionen korreliert werden können.

Diese bewusst restriktive Anwendungsrichtlinie erlaubt nur absolute HTTPS‑URLs und gültige interne Folienziele. Sie lehnt Makros, Programme, Datei‑Aktionen, andere Präsentations‑Aktionen, unbekannte Aktionen und andere URL‑Schemen ab. Diese Ablehnungen sind Richtlinien‑Entscheidungen, kein Sicherheitsurteil von Aspose.Slides. HTTPS allein schafft kein Vertrauen: Ergänzen Sie Host‑Whitelist‑Einträge und weitere Prüfungen für Ihre Anwendung. Sowohl originale als auch normalisierte externe URLs werden geprüft. Das Beispiel prüft Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Behebung unterstützt das [hyperlink_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) des Containers [set_external_hyperlink_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) und [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Landing‑Page ersetzt; andere verbotene Klick‑ und Maus‑over‑Aktionen werden unabhängig entfernt. Setzen Sie `replace_external_clicks` auf `False`, um alle Richtlinienverstöße zu entfernen. Wählen Sie vor dem Deployment eine ersetzende Seite, die von Ihrer Anwendung bereitgestellt wird.

Das Export‑Flag des Berichts verwendet eine konservative PDF‑Review‑Richtlinie: Maus‑over‑Aktionen und alles außer einem externen Link oder einem spezifischen Folien‑Sprung werden potenziell nicht unterstützt markiert. Es ist ein Hinweis zur Überprüfung, kein Fähigkeitstest und keine Garantie, dass nicht markierte Links beim Export erhalten bleiben. Unterstützte [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/)‑ und [HTML](/slides/de/python-net/convert-powerpoint-to-html/)‑Exporte können Hyperlinks bewahren, abhängig von Aktion, Export‑Optionen und Viewer. Raster‑[images](/slides/de/python-net/convert-powerpoint-to-png/) und [video](/slides/de/python-net/convert-powerpoint-to-video/) können interaktive Hyperlinks nicht erhalten; markieren Sie jede Aktion, wenn Sie für diese Ausgaben prüfen.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Query each slide scope once, retaining its owner with each container.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Mit dem oben erstellten Eingabedokument enthält der Bericht fünf Aktionszeilen. Der Datei‑Maus‑over‑Link und das Makro‑Klick‑Element werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Verifizierung gibt null verbotene Aktionen aus. Ein Eingabedokument mit einer verbotenen externen Klick‑URL demonstriert zudem den Ersetzungs‑Zweig. Ein Container mit einem erlaubten Klick und einem verbotenen Maus‑over behält seine Klick‑Aktion.

Diese selektive Bereinigung unterscheidet sich von [remove_all_hyperlinks](https://reference.aspose.com/slides/de/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), das beide Aktivierungstypen im gewählten Geltungsbereich unabhängig von Richtlinien entfernt. Die Verifizierung prüft hier ausschließlich Hyperlink‑Aktionen; sie entfernt weder eingebettete VBA‑Projekte, OLE‑Objekte noch anderen aktiven Inhalt und validiert weder eine exportierte PDF‑ noch HTML‑Datei.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder seiner ersten Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink zielt auf eine einzelne Folie. Um zu einem Abschnitt zu navigieren, verlinken Sie zur ersten Folie dieses Abschnitts.

**Kann ich einem Master‑Folienelement einen Hyperlink zuweisen, sodass er auf allen Folien funktioniert?**

Ja. Elemente von Master‑Folien und Layouts unterstützen Hyperlinks. Diese Links sind während der Vorführung auf allen Folien verfügbar, die den entsprechenden Master bzw. das Layout verwenden.

**Werden Hyperlinks beim Export nach PDF, HTML, Bildern oder Video erhalten bleiben?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks erhalten; Raster‑Bilder und Video können keine interaktiven Hyperlinks bewahren. Siehe die Export‑Hinweise in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).