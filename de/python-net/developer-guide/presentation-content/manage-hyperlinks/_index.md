---
title: Hyperlinks in Python verwalten
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
- Folienhyperlink
- Formhyperlink
- Bild-Hyperlink
- Video-Hyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET hinzu, formatieren, aktualisieren und entfernen Sie diese, anhand von Python-Beispielen."
---
## **Einleitung**

Ein Hyperlink verbindet Präsentationsinhalt mit einer Website oder einem Ort innerhalb der Präsentation. In PowerPoint dienen Hyperlinks üblicherweise zwei Zwecken:

* Öffnet eine Website aus Text, einer Form oder einem Medienrahmen.
* Navigiert zu einer anderen Folie, zum Beispiel aus einem Inhaltsverzeichnis.

Aspose.Slides for Python via .NET ermöglicht das Hinzufügen dieser Links, das Steuern ihres Erscheinungsbildes und Sounds, das Aktualisieren ihrer Eigenschaften und das Entfernen. Die nachstehenden Beispiele zeigen, wie man mit Hyperlinks für einzelne Elemente arbeitet und wie man Hyperlinks auf Präsentations-, Folien- oder Textfeld‑Ebene abruft.

{{% alert color="info" title="Note" %}}
Sie können Präsentationen auch mit dem [kostenlosen Online Aspose PowerPoint‑Editor](https://products.aspose.app/slides/editor) bearbeiten.
{{% /alert %}}

## **URL‑Hyperlinks hinzufügen**

Sie können einer Text, Form oder einem Medienrahmen eine Website‑URL zuweisen. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den anklickbaren Bereich: Ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

Für Präsentationen mit relativen Hyperlinks siehe [Hyperlink‑Basis verwalten](/slides/de/python-net/presentation-properties/#manage-the-hyperlink-base), um die dokumentbezogene Basis zu lesen, zu ändern oder zu löschen.

### **URL‑Hyperlinks zu Text hinzufügen**

Um Text mit einer Website zu verlinken, weisen Sie dem [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) der [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/)-Eigenschaft des Textabschnitts zu, wie unten gezeigt. Nur dieser Textabschnitt wird anklickbar.

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

Weisen Sie dem Rechteck über die [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/)-Eigenschaft eine URL zu, um den gesamten Bereich anklickbar zu machen. Der [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) gibt dem Leser einen Hinweis auf das Ziel, wenn er mit der Maus über das Rechteck fährt. Die gleichen Eigenschaften gelten für Bild‑, Audio‑ und Videorahmen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinks zur Erstellung eines Inhaltsverzeichnisses verwenden**

Interne Hyperlinks ermöglichen es dem Leser, von einem Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/), um den Text „Seite 2“ auf der ersten Folie mit der zweiten Folie zu verknüpfen.

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

Sie können die Farbe des verlinkten Textes ändern, einen Sound abspielen oder stoppen, wenn ein Leser einen Link aktiviert, und den Tooltip festlegen, der beim Überfahren angezeigt wird.

### **Farbe**

Die [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/)-Eigenschaft von [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) bestimmt, ob ein Hyperlink die Hyperlink‑Farbe der Präsentation oder die Formatierung des Textabschnitts verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) und setzen die Füllfarbe des Abschnitts. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen wenden diese Einstellung nicht an.

In diesem Beispiel führt das Setzen von [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) beim ersten Link dazu, dass sein Text rot angezeigt wird. Der zweite Link behält die Hyperlink‑Farbe der Präsentation bei.

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

Ein Hyperlink kann bei Aktivierung einen Sound abspielen oder einen bereits laufenden Sound stoppen. Verwenden Sie die folgenden Eigenschaften, um dieses Verhalten zu konfigurieren:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) gibt das dem Hyperlink zugeordnete Audio an.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) steuert, ob das Aktivieren des Hyperlinks den vorherigen Sound stoppt.

#### **Hyperlink‑Sound hinzufügen**

Der Button auf der ersten Folie verwendet [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/), um Audio aus einer WAV‑Datei abzuspielen, wenn der Leser zum Weiterblättern klickt. Auf der zweiten Folie verwendet ein separater Button [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/), um die Wiedergabe zu stoppen und den Leser auf dieser Folie zu halten.

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

Das folgende Beispiel öffnet die oben erstellte Präsentation und liest das Hyperlink‑Audio der ersten Form mittels [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) und [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) in den Speicher.

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

Sie können die folgenden [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/)-Eigenschaften nach dem Zuweisen eines Hyperlinks zu Text oder einer Form aktualisieren:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) legt den Text fest, den ein Betrachter als Hinweis zum Link anzeigen kann.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) gibt den Zielrahmen innerhalb eines übergeordneten HTML‑Framesets an, falls zutreffend.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) steuert, ob das Aktivieren des Links sein Ziel zur Liste der angesehenen Hyperlinks hinzufügt.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) steuert, ob der Hyperlink beim Anklicken hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/), um Hyperlink‑Container, einschließlich Textabschnitt‑Links, zu sammeln, bevor Sie sie ändern. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie nur [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) bzw. [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) auf; das Entfernen einer Klickaktion entfernt nicht die zugehörige Mouse‑Over‑Aktion.

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

Für die bedingungslose Entfernung entfernt [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) beide Aktivierungstypen im ausgewählten Umfang mit einem Aufruf. Für eine selektive Bereinigung und Abdeckung von Mastern, Layouts und Notizen siehe [Bericht, Säuberung und Überprüfung von Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Hyperlinks vor dem Ersetzen von SmartArt‑Text löschen**

Wenn Sie einen Absatz in einem vorhandenen SmartArt‑Knoten ersetzen, kann das Löschen seiner Textabschnitte einen alten Hyperlink erhalten bleiben. Rufen Sie den Absatz über [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/) ab. Bevor Sie seine Abschnitte löschen, rufen Sie [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) über [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) im Textfeld der Knotenform auf, die den Absatz anzeigt. Dadurch werden alle Hyperlinks in diesem Frame entfernt, einschließlich Links in seinen anderen Absätzen.

In `SmartArtHyperlink.pptx` befindet sich die dritte Form auf der ersten Folie als SmartArt‑Grafik. Das Beispiel ersetzt den ersten Absatz ihres vierten Knotens. In dieser Präsentation zeigt die erste Form des Knotens diesen Absatz an.

Nach dem Hinzufügen beider Abschnitte liest das Beispiel deren effektive Formatierung mit [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/). Die effektive [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/)‑Eigenschaft gibt den neuen Hyperlink für den ersten Abschnitt zurück und `None` für den zweiten.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **Vollständiges Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verteilen, erfassen Sie deren interaktive Aktionen sowie Web‑Links. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) gibt [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/)-Objekte zurück, nicht eine flache Liste von URL‑Zeichenketten. Untersuchen Sie sowohl [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) als auch [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) in jedem Container. Sie sind unabhängig: derselbe Container kann beide Aktionen bereitstellen, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container benötigen kann.

Das Scannen nur von Hyperlinks auf Formebene kann Links übersehen, die an Textabschnitten hängen. Fragen Sie stattdessen den entsprechenden Umfang ab und behalten Sie die zurückgegebenen Container, damit Sie deren Aktionen später aktualisieren oder entfernen können.

### **Abfrage von Präsentations-, Folien- und Textfeld‑Umfängen**

Die Klasse [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) ist über [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) und [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) verfügbar. Jeder Umfang unterstützt dieselben Abfragen:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) gibt Container mit einer Klickaktion zurück.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) gibt Container mit einer Mouse‑Over‑Aktion zurück.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) gibt Container mit einer oder beiden Aktionen zurück.

Dieses Beispiel weist einer Form und ihrem Text Klick‑ und Mouse‑Over‑Aktionen zu sowie einer separaten Schaltfläche eine Makro‑Aktion. Es vergleicht die von [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) zurückgegebenen Container mit den Zählungen für jeden Aktivierungstyp. Eine Textfeld‑Abfrage zählt nur Links im Text. Die eigenen Aktionen der umschließenden Form erscheinen in den Folien‑ und Präsentations‑Abfragen.

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

Für dieses Beispiel melden die Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Mouse‑Over‑Container und drei Container mit einer der beiden Aktionen. Die Textfeld‑Abfrage meldet einen Container in jeder Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/), um eine Aktion zu interpretieren, bevor Sie ihr Ziel interpretieren. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) decken mehr als Web‑Navigation ab:

| Werte | Bedeutung für ein Audit |
| --- | --- |
| `HYPERLINK` | Externer Hyperlink; prüfen Sie die URL und ihr Schema. |
| `JUMP_SPECIFIC_SLIDE` | Interne Navigation zu einer bestimmten Folie. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Eingebaute Diashow‑Navigation, aufgelöst im Diashow‑Kontext. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Beendet die aktuelle Show oder startet eine benutzerdefinierte Show. |
| `START_MACRO` | Führt ein Makro aus. |
| `START_PROGRAM` | Startet ein Programm. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Öffnet eine Datei oder eine andere Präsentation; separat von Web‑URLs prüfen. |
| `START_STOP_MEDIA` | Startet oder stoppt die Medienwiedergabe. |
| `NO_ACTION`, `UNKNOWN` | Keine Navigationsaktion oder eine nicht erkannte Aktion, die einer Überprüfung bedarf. |

Lesen Sie externe Ziele aus [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) und spezifische interne Ziele aus [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Interne Aktionen und eingebaute Befehle können keine externe URL besitzen; eine leere URL bedeutet nicht, dass der Container keine Aktion hat. Bewahren Sie [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) auf, wenn sie von der normalisierten URL abweicht, und fügen Sie den [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) hinzu, falls verfügbar.

### **Hyperlinks berichten, sanieren und prüfen**

Dieses Beispiel öffnet die Präsentation aus dem vorherigen Beispiel und schreibt pro Aktion einen JSON‑Datensatz. Es verwendet [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/), um Container auf normalen Folien, Mastern, Layouts und Notizen zu sammeln, einschließlich der Notiz‑ und Handzettel‑Mastern, falls vorhanden. Es fragt jeden Umfang einmal ab, um doppelte Verarbeitungen zu vermeiden, wendet die unten beschriebene Richtlinie an und öffnet die gespeicherte Präsentation erneut, um sowohl Klick‑ als auch Mouse‑Over‑Aktionen zu prüfen.

Der Bericht erfasst einen 1‑basierten Folien‑Index und [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/), sofern verfügbar. Der Sammler behält die zugehörige Folie und den Umfang zusammen mit jedem zurückgegebenen Container. Master, Layouts und Notizen haben keinen normalen Folien‑Index und werden über ihren Umfang identifiziert. Form‑Container und Text‑Abschnitt‑Formatierungs‑Container werden getrennt bezeichnet; andere Containertypen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichtslokale ID, sodass seine beiden Aktionen korreliert werden können.

Diese bewusst restriktive Anwendungsrichtlinie erlaubt nur absolute HTTPS‑URLs und gültige interne Folienziele. Sie verwirft Makros, Programme, Datei‑Aktionen, andere Diashow‑Aktionen, unbekannte Aktionen und andere URL‑Schemen. Diese Ablehnungen sind Richtlinienentscheidungen, nicht ein Sicherheitsurteil von Aspose.Slides. HTTPS allein schafft keinen Vertrauensaufbau: Fügen Sie Host‑Allowlisten und andere Prüfungen für Ihre Anwendung hinzu. Sowohl ursprüngliche als auch normalisierte externe URLs werden geprüft. Das Beispiel prüft Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Behebung unterstützt der [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) des Containers [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) und [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Landing‑Page ersetzt; andere verbotene Klick‑ und Mouse‑Over‑Aktionen werden unabhängig entfernt. Setzen Sie `replace_external_clicks` auf `False`, um alle Richtlinienverstöße zu entfernen. Wählen Sie vor der Bereitstellung eine von der Anwendung bereitgestellte Ersatz‑Seite.

Die Export‑Markierung des Berichts verwendet eine konservative PDF‑Prüfrichtlinie: Markieren Sie Mouse‑Over‑Aktionen und alles andere als einen externen Link oder einen spezifischen Folien‑Sprung als potenziell nicht unterstützt. Es ist ein Hinweis für die Überprüfung, kein Fähigkeitstest oder eine Garantie, dass nicht markierte Links den Export überstehen. Unterstützte [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/)‑ und [HTML](/slides/de/python-net/convert-powerpoint-to-html/)‑Exporte können Hyperlinks erhalten, abhängig von der Aktion, den Exportoptionen und dem Viewer. Raster-[Bilder](/slides/de/python-net/convert-powerpoint-to-png/) und -[Videos](/slides/de/python-net/convert-powerpoint-to-video/) können interaktive Hyperlinks nicht erhalten; markieren Sie jede Aktion, wenn Sie für diese Ausgaben prüfen.

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

Mit dem oben erstellten Eingabedaten enthält der Bericht fünf Aktionszeilen. Der Datei‑Mouse‑Over‑Link und der Makro‑Klick werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Überprüfung gibt null verbotene Aktionen aus. Ein Eingabedatum, das eine verbotene externe Klick‑URL enthält, testet ebenfalls den Ersetzungszweig. Ein Container mit einem erlaubten Klick und einem verbotenen Mouse‑Over behält seine Klick‑Aktion.

Diese selektive Bereinigung unterscheidet sich von [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), das beide Aktivierungstypen im gesamten ausgewählten Umfang entfernt, unabhängig von der Richtlinie. Die Überprüfung prüft hier nur Hyperlink‑Aktionen; sie entfernt keine eingebetteten VBA‑Projekte, OLE‑Objekte oder andere aktive Inhalte und validiert keine exportierte PDF‑ oder HTML‑Datei.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder seiner ersten Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink richtet sich an eine einzelne Folie. Um Navigation zu einem Abschnitt zu erzeugen, verlinken Sie zur ersten Folie dieses Abschnitts.

**Kann ich einen Hyperlink an Master‑Folienelementen anhängen, sodass er auf allen Folien funktioniert?**

Ja. Elemente von Master‑Folien und Layouts unterstützen Hyperlinks. Links auf diesen Elementen sind während der Bildschirminshow auf Folien verfügbar, die den entsprechenden Master oder das Layout verwenden.

**Werden Hyperlinks beim Exportieren nach PDF, HTML, Bildern oder Video erhalten bleiben?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks erhalten; Raster‑Bilder und Videos können dies nicht. Siehe die Export‑Überlegungen in [Bericht, Säuberung und Überprüfung von Hyperlinks](#report-sanitize-and-verify-hyperlinks).