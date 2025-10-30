---
title: Präsentations-Header und -Footer mit Python verwalten
linktitle: Header und Footer
type: docs
weight: 140
url: /de/python-net/presentation-header-and-footer/
keywords:
- Header
- Header-Text
- Footer
- Footer-Text
- Header festlegen
- Footer festlegen
- Handzettel
- Notizen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python via .NET, um Header und Footer in PowerPoint‑ und OpenDocument‑Präsentationen hinzuzufügen und anzupassen und so ein professionelles Erscheinungsbild zu erzielen."
---

## **Übersicht**

Aspose.Slides für Python ermöglicht Ihnen die präzise Steuerung von Header‑ und Footer‑Platzhaltern in einer gesamten Präsentation. Footer‑Text, Datum/Uhrzeit und Folienzahlen werden auf Master‑Ebene verwaltet und können global angewendet oder pro Folie angepasst werden. Header werden in Notizen und Handzetteln unterstützt, wo Sie die Sichtbarkeit umschalten und Text für Header, Footer, Datum/Uhrzeit und Seitenzahlen über den dedizierten Header‑&‑Footer‑Manager auf dem Master‑Notiz‑Slide oder einzelnen Notiz‑Slides festlegen können. Dieser Artikel beschreibt die wichtigsten Vorgehensweisen zum Aktualisieren dieser Platzhalter und zur konsistenten Propagierung von Änderungen in Ihrer Präsentation.

## **Header‑ und Footer‑Text verwalten**

In diesem Abschnitt lernen Sie, wie Sie Header‑ und Footer‑Inhalte in einer Präsentation verwalten – Footer, Datum/Uhrzeit und Folienzahlen aktivieren oder ändern. Wir geben einen kurzen Überblick über die Geltungsbereiche für diese Einstellungen (gesamte Präsentation, einzelne Folien und Notizen/Handzettel‑Ansichten) und zeigen, wie Sie die Aspose.Slides‑API nutzen, um sie schnell und einheitlich zu aktualisieren.

Das folgende Code‑Beispiel öffnet eine Präsentation, aktiviert und setzt den Footer‑Text, aktualisiert den Header‑Text auf dem Master‑Notiz‑Slide und speichert die Datei.

```py
import aspose.slides as slides

# Funktion zum Festlegen des Header‑Texts.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Präsentation laden.
with slides.Presentation("sample.pptx") as presentation:
    # Footer setzen.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Header aktualisieren.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Präsentation speichern.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Header und Footer auf Notiz‑Slides verwalten**

In diesem Abschnitt lernen Sie, wie Sie Header und Footer speziell für Notiz‑Slides in Aspose.Slides verwalten. Wir behandeln das Aktivieren der relevanten Platzhalter, das Festlegen von Text für Footer, Datum/Uhrzeit und Seitenzahlen sowie das konsistente Anwenden dieser Änderungen auf dem Notiz‑Master und einzelnen Notiz‑Seiten.

Befolgen Sie die untenstehenden Schritte:

1. Präsentationsdatei laden.
2. Den Master‑Notiz‑Slide und seinen [Header‑ und Footer‑Manager](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/) abrufen.
3. Auf dem Master‑Notiz‑Slide die Sichtbarkeit von Header, Footer, Folienzahl und Datum/Uhrzeit für den Master und alle untergeordneten Notiz‑Slides aktivieren.
4. Auf dem Master‑Notiz‑Slide Text für Header, Footer und Datum/Uhrzeit für den Master und alle untergeordneten Notiz‑Slides festlegen.
5. Den Notiz‑Slide für die erste Präsentationsfolie und seinen [Header‑ und Footer‑Manager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/) abrufen.
6. Für diesen ersten Notiz‑Slide sicherstellen, dass Header, Footer, Folienzahl und Datum/Uhrzeit sichtbar sind (alle deaktivierten einschalten).
7. Für diesen ersten Notiz‑Slide den Text für Header, Footer und Datum/Uhrzeit festlegen.
8. Die Präsentation im PPTX‑Format speichern.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Master‑Notiz‑Slide und alle untergeordneten Header‑, Footer‑, Folienzahl‑ und Datum/Uhrzeit‑Platzhalter sichtbar machen.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Text auf dem Master‑Notiz‑Slide und allen untergeordneten Header‑, Footer‑ und Datum/Uhrzeit‑Platzhaltern setzen.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Header, Footer, Folienzahl und Datum/Uhrzeit nur für den ersten Notiz‑Slide ändern.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Sicherstellen, dass die Header‑, Footer‑, Folienzahl‑ und Datum/Uhrzeit‑Platzhalter sichtbar sind.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Text auf den Header‑, Footer‑ und Datum/Uhrzeit‑Platzhaltern des Notiz‑Slides setzen.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Präsentation speichern.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich einen "Header" zu normalen Folien hinzufügen?**

In PowerPoint existiert ein "Header" nur für Notizen und Handzettel; bei normalen Folien werden nur Footer, Datum/Uhrzeit und Folienzahl unterstützt. In Aspose.Slides entspricht das denselben Beschränkungen: Header ausschließlich für Notizen/Handzettel, bei Folien – Footer/DatumUhrzeit/Folienzahl.

**Was, wenn das Layout keinen Footer‑Bereich enthält – kann ich dessen Sichtbarkeit aktivieren?**

Ja. Prüfen Sie die Sichtbarkeit über den Header‑/Footer‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und Methoden sind für Fälle vorgesehen, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummerierung bei einem anderen Startwert als 1 beginnen lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) der Präsentation; anschließend wird die gesamte Nummerierung neu berechnet. Beispielsweise können Sie bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Headern/Footern beim Exportieren zu PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das bedeutet, wenn die Elemente auf Folien/Notiz‑Seiten sichtbar sind, erscheinen sie auch im Ausgabeformat zusammen mit dem übrigen Inhalt.