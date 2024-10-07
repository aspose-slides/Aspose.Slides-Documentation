---
title: Folienlayout
type: docs
weight: 60
url: /python-net/slide-layout/
keyword: "Folie Größe festlegen, Folienoptionen festlegen, Foliengröße angeben, Fußzeilenanzeige, Kindfußzeile, Inhaltsverkleinerung, Seitengröße, Python, Aspose.Slides"
description: "Stellen Sie die PowerPoint-Foliengröße und -optionen in Python ein"
---

Ein Folienlayout enthält die Platzhalterkästen und Formatierungsinformationen für alle Inhalte, die auf einer Folie erscheinen. Das Layout bestimmt die verfügbaren Inhaltsplatzhalter und deren Position.

Folienlayouts ermöglichen es Ihnen, Präsentationen schnell zu erstellen und zu gestalten (ob einfach oder komplex). Hier sind einige der beliebtesten Folienlayouts, die in PowerPoint-Präsentationen verwendet werden:

* **Titelfolienlayout**. Dieses Layout besteht aus zwei Platzhaltern für Text. Ein Platzhalter ist für den Titel und der andere für den Untertitel.
* **Titel- und Inhaltslayout**. Dieses Layout enthält einen relativ kleinen Platzhalter oben für den Titel und einen größeren Platzhalter für den Hauptinhalt (Diagramm, Absätze, Aufzählung, nummerierte Liste, Bilder usw.).
* **Leeres Layout**. Dieses Layout enthält keine Platzhalter, sodass Sie Elemente von Grund auf neu erstellen können.

Da ein Masterlayout die oberste hierarchische Folie ist, die Informationen über Folienlayouts speichert, können Sie die Masterfolie verwenden, um auf Folienlayouts zuzugreifen und Änderungen daran vorzunehmen. Ein Layoutfolien kann nach Typ oder Name aufgerufen werden. Ebenso hat jede Folie eine eindeutige ID, die verwendet werden kann, um darauf zuzugreifen.

Alternativ können Sie direkt Änderungen an einem bestimmten Folienlayout in einer Präsentation vornehmen.

* Um Ihnen die Arbeit mit Folienlayouts (einschließlich der in Masterfolien) zu ermöglichen, bietet Aspose.Slides Eigenschaften wie `layout_slides` und `masters` unter der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse an.
* Um verwandte Aufgaben auszuführen, bietet Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/baseslideheaderfootermanager/) und viele andere Typen an.

{{% alert title="Info" color="info" %}}

Für weitere Informationen zur Arbeit mit Masterfolien im Speziellen siehe den Artikel [Folie Master](https://docs.aspose.com/slides/python-net/slide-master/).

{{% /alert %}}

## **Folie Layout zur Präsentation hinzufügen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die [MasterSlide-Sammlung](https://reference.aspose.com/slides/python-net/aspose.slides/imasterlayoutslidecollection/) zu.
1. Gehen Sie die vorhandenen Layoutfolien durch, um zu bestätigen, dass die erforderliche Layoutfolie bereits in der Layoutfoliensammlung vorhanden ist. Andernfalls fügen Sie die gewünschte Layoutfolie hinzu.
1. Fügen Sie eine leere Folie basierend auf der neuen Layoutfolie hinzu.
1. Speichern Sie die Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie ein Folienlayout zu einer PowerPoint-Präsentation hinzufügen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die die Präsentationsdatei darstellt
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Geht durch die Layoutfolientypen
    layoutSlides = presentation.masters[0].layout_slides
    layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)  
    if layoutSlide is None:
         layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE)

    if layoutSlide is None:
        # Die Situation, in der eine Präsentation einige Layouttypen nicht enthält.
        # Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layouttypen.
        # Aber Layoutfolien mit benutzerdefinierten Typen haben unterschiedliche Foliennamen,
        # wie "Titel", "Titel und Inhalt" usw. Und es ist möglich, diese
        # Namen für die Auswahl von Layoutfolien zu verwenden.
        # Sie können auch eine Reihe von Platzhalterschablonentypen verwenden. Zum Beispiel,
        # Titel-Folie sollte nur den Typ Platzhalter für Titel haben usw.
        for titleAndObjectLayoutSlide in layoutSlides:
            if titleAndObjectLayoutSlide.name == "Titel und Objekt":
                layoutSlide = titleAndObjectLayoutSlide
                break

        if layoutSlide is None:
            for titleLayoutSlide in layoutSlides:
                if titleLayoutSlide.name == "Titel":
                    layoutSlide = titleLayoutSlide
                    break

            if layoutSlide is None:
                layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.BLANK)
                if layoutSlide is None:
                    layoutSlide = layoutSlides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Titel und Objekt")

    # Fügt eine leere Folie mit dem hinzugefügten Layout hinzu 
    presentation.slides.insert_empty_slide(0, layoutSlide)

    # Speichert die Präsentation auf der Festplatte
    presentation.save("AddLayoutSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ungenutzte Layoutfolie entfernen**

Aspose.Slides bietet die Methode `remove_unused_layout_slides` aus der [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) Klasse, um unerwünschte und ungenutzte Layoutfolien zu löschen. Dieser Python-Code zeigt Ihnen, wie Sie eine Layoutfolie aus einer PowerPoint-Präsentation entfernen:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Größe und Typ für Folienlayout festlegen**

Um Ihnen zu ermöglichen, die Größe und den Typ für eine bestimmte Layoutfolie festzulegen, bietet Aspose.Slides die Eigenschaften `type` und `size` (aus der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse). Dieser Python-Code demonstriert den Vorgang:

```python
import aspose.slides as slides

# Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Setzt die Foliengröße für die generierte Präsentation auf die der Quelle
        auxPresentation.slide_size.set_size(presentation.slide_size.type, slides.SlideSizeScaleType.ENSURE_FIT)

        auxPresentation.slides.insert_clone(0, slide)
        auxPresentation.slides.remove_at(0)
        # Speichert die Präsentation auf der Festplatte
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Fußzeilenanzeige innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
1. Setzen Sie den Fußzeilenplatzhalter auf sichtbar.
1. Setzen Sie den Datums-Zeit-Platzhalter auf sichtbar.
1. Speichern Sie die Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie die Sichtbarkeit einer Folienfußzeile (und verwandte Aufgaben) festlegen:

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    headerFooterManager = presentation.slides[0].header_footer_manager
    # Eigenschaft is_footer_visible wird verwendet, um anzugeben, dass ein Platzhalter für die Folienfußzeile fehlt
    if not headerFooterManager.is_footer_visible: 
        # Methode set_footer_visibility wird verwendet, um einen Platzhalter für die Folienfußzeile sichtbar zu machen
        headerFooterManager.set_footer_visibility(True) 
        # Eigenschaft is_slide_number_visible wird verwendet, um anzugeben, dass ein Platzhalter für die Foliennummer fehlt
    if not headerFooterManager.is_slide_number_visible:  
        # Methode set_slide_number_visibility wird verwendet, um einen Platzhalter für die Foliennummer sichtbar zu machen
        headerFooterManager.set_slide_number_visibility(True) 
        # Eigenschaft is_date_time_visible wird verwendet, um anzugeben, dass ein Platzhalter für Datum und Uhrzeit fehlt
    if not headerFooterManager.is_date_time_visible: 
        # Methode set_date_time_visibility wird verwendet, um einen Platzhalter für Datum und Uhrzeit sichtbar zu machen 
        headerFooterManager.set_date_time_visibility(True)

    # Methode set_footer_text wird verwendet, um einen Text für einen Platzhalter der Folienfußzeile festzulegen 
    headerFooterManager.set_footer_text("Fußzeilentext") 
    # Methode set_date_time_text wird verwendet, um einen Text für einen Platzhalter für Datum und Uhrzeit festzulegen.
    headerFooterManager.set_date_time_text("Datum und Uhrzeit Text") 

    # Speichert die Präsentation auf der Festplatte
    presentation.save("Presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Sichtbarkeit der Kindfußzeile innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz für die Masterfolie über ihren Index.
1. Setzen Sie die Masterfolie und alle Platzhalter für Kindfußzeilen auf sichtbar.
1. Setzen Sie einen Text für die Masterfolie und alle Platzhalter für Kindfußzeilen.
1. Setzen Sie einen Text für die Masterfolie und alle Platzhalter für das Datum und die Uhrzeit der Kinder.
1. Speichern Sie die Präsentation.

Dieser Python-Code demonstriert den Vorgang:

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    manager = presentation.masters[0].header_footer_manager
    manager.set_footer_and_child_footers_visibility(True) # Methode set_footer_and_child_footers_visibility wird verwendet, um die Masterfolie und alle Platzhalter für Kindfußzeilen sichtbar zu machen
    manager.set_slide_number_and_child_slide_numbers_visibility(True) # Methode set_slide_number_and_child_slide_numbers_visibility wird verwendet, um die Masterfolie und alle Platzhalter für Kindseitennummern sichtbar zu machen
    manager.set_date_time_and_child_date_times_visibility(True) # Methode set_date_time_and_child_date_times_visibility wird verwendet, um die Masterfolie und alle Platzhalter für Datum und Uhrzeit der Kinder sichtbar zu machen

    manager.set_footer_and_child_footers_text("Fußzeilentext") # Methode set_footer_and_child_footers_text wird verwendet, um Texte für die Masterfolie und alle Platzhalter für Kindfußzeilen festzulegen
    manager.set_date_time_and_child_date_times_text("Datum und Uhrzeit Text") # Methode set_date_time_and_child_date_times_text wird verwendet, um Texte für die Masterfolie und alle Platzhalter für das Datum und die Uhrzeit der Kinder festzulegen
```

## **Foliengröße in Bezug auf Inhaltsverkleinerung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die die Folie enthält, deren Größe Sie festlegen möchten.
1. Erstellen Sie eine weitere Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, um eine neue Präsentation zu generieren.
1. Holen Sie sich die Referenz der Folie (aus der ersten Präsentation) über ihren Index.
1. Setzen Sie den Fußzeilenplatzhalter auf sichtbar. 
1. Setzen Sie den Datums-Zeit-Platzhalter auf sichtbar. 
1. Speichern Sie die Präsentation.

Dieser Python-Code demonstriert den Vorgang: 

```python
import aspose.slides as slides

# Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Setzt die Foliengröße für die generierte Präsentationen auf die der Quelle
        presentation.slide_size.set_size(540, 720, slides.SlideSizeScaleType.ENSURE_FIT) # Methode set_size wird verwendet, um die Foliengröße mit einer Inhaltsverkleinerung für eine Anpassung sicherzustellen
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.MAXIMIZE) # Methode set_size wird verwendet, um die Foliengröße mit maximaler Größe des Inhalts festzulegen
                
        # Speichert die Präsentation auf der Festplatte
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Seitengröße beim Generieren von PDF festlegen**

Bestimmte Präsentationen (wie Poster) werden häufig in PDF-Dokumente umgewandelt. Wenn Sie Ihre PowerPoint in PDF konvertieren möchten, um die besten Druck- und Barrierefreiheitsoptionen zu nutzen, sollten Sie Ihre Folien auf Größen einstellen, die zu PDF-Dokumenten passen (z.B. A4).

Aspose.Slides bietet die [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/) Klasse, um Ihnen zu ermöglichen, Ihre bevorzugten Einstellungen für Folien festzulegen. Dieser Python-Code zeigt Ihnen, wie Sie die `type` Eigenschaft (aus der `SlideSize` Klasse) verwenden, um eine bestimmte Papiergröße für die Folien in einer Präsentation festzulegen:

```python
import aspose.slides as slides

# Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt  
with slides.Presentation() as presentation:
    # Setzt die Eigenschaft SlideSize.Type 
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.ENSURE_FIT)

    # Setzt verschiedene Eigenschaften für PDF-Optionen
    opts = slides.export.PdfOptions()
    opts.sufficient_resolution = 600

    # Speichert die Präsentation auf der Festplatte
    presentation.save("SetPDFPageSize_out.pdf", slides.export.SaveFormat.PDF, opts)
```