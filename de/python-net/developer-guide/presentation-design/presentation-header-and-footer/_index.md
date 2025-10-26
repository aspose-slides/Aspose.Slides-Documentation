---
title: Manage Presentation Headers and Footers with Python
linktitle: Header and Footer
type: docs
weight: 140
url: /de/python-net/developer-guide/presentation-design/presentation-header-and-footer/
keywords:
- header
- header text
- footer
- footer text
- set header
- set footer
- handout
- notes
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python via .NET, um Header und Footer in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen und anzupassen, damit sie professionell aussehen."
---

## **Übersicht**

Aspose.Slides für Python ermöglicht es Ihnen, Header‑ und Footer‑Platzhalter in einer Präsentation mit präzisem Geltungsbereich zu steuern. Footer‑Text, Datum/Uhrzeit und Folienzahlen werden auf Master‑Ebene verwaltet und können global angewendet oder pro Folie angepasst werden. Header werden in Notizen und Handzetteln unterstützt, wo Sie die Sichtbarkeit umschalten und Text für Header, Footer, Datum/Uhrzeit sowie Seitenzahlen über den dedizierten Header‑&‑Footer‑Manager auf dem Master‑Notiz‑Slide oder einzelnen Notiz‑Slides festlegen können. Dieser Artikel beschreibt die wichtigsten Muster zum Aktualisieren dieser Platzhalter und zur konsistenten Weitergabe von Änderungen in Ihrer Präsentation.

## **Header‑ und Footer‑Text verwalten**

In diesem Abschnitt erfahren Sie, wie Sie Header‑ und Footer‑Inhalte in einer Präsentation verwalten – Footer, Datum und Uhrzeit sowie Folienzahlen aktivieren oder ändern. Wir geben einen kurzen Überblick über die Geltungsbereiche dieser Einstellungen (gesamte Präsentation, einzelne Folien und Notiz/Handzettel‑Ansichten) und zeigen, wie Sie die Aspose.Slides‑API nutzen, um sie schnell und einheitlich zu aktualisieren.

Das nachfolgende Code‑Beispiel öffnet eine Präsentation, aktiviert und setzt den Footer‑Text, aktualisiert den Header‑Text auf dem Master‑Notiz‑Slide und speichert die Datei.

```py
import aspose.slides as slides

# Function to set the header text.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # Set the footer.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Access and update the header.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Header und Footer auf Notizfolien verwalten**

In diesem Abschnitt lernen Sie, wie Sie Header und Footer speziell für Notizfolien in Aspose.Slides verwalten. Wir behandeln das Aktivieren der entsprechenden Platzhalter, das Setzen von Text für Footer, Datum/Uhrzeit und Seitenzahlen sowie das konsistente Anwenden dieser Änderungen auf dem Notiz‑Master und den einzelnen Notiz‑Seiten.

Befolgen Sie die nachstehenden Schritte:

1. Laden Sie eine Präsentationsdatei.
2. Rufen Sie den Master‑Notiz‑Slide und dessen [Header‑&‑Footer‑Manager](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/) ab.
3. Aktivieren Sie auf dem Master‑Notiz‑Slide die Sichtbarkeit von Header, Footer, Folienzahl und Datum/Uhrzeit für den Master und alle untergeordneten Notiz‑Slides.
4. Setzen Sie auf dem Master‑Notiz‑Slide den Text für Header, Footer und Datum/Uhrzeit für den Master und alle untergeordneten Notiz‑Slides.
5. Rufen Sie die Notiz‑Slide zur ersten Präsentationsfolie und deren [Header‑&‑Footer‑Manager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/) ab.
6. Stellen Sie für diese erste Notiz‑Slide sicher, dass Header, Footer, Folienzahl und Datum/Uhrzeit sichtbar sind (schalten Sie ggf. ausgeschaltete ein).
7. Setzen Sie für diese erste Notiz‑Slide den Text für Header, Footer und Datum/Uhrzeit.
8. Speichern Sie die Präsentation im PPTX‑Format.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Make the master notes slide and all child header, footer, slide number, and date/time placeholders visible.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Set text on the master notes slide and all child header, footer, and date/time placeholders.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Change header, footer, slide number, and date/time settings for the first notes slide only.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Ensure the header, footer, slide number, and date/time placeholders are visible.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Set text on the notes slide header, footer, and date/time placeholders.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich einen „Header“ zu normalen Folien hinzufügen?**

In PowerPoint existiert ein „Header“ nur für Notizen und Handzettel; bei normalen Folien werden nur Footer, Datum/Uhrzeit und Folienzahl unterstützt. In Aspose.Slides entspricht das denselben Einschränkungen: Header nur für Notizen/Handzettel, bei Folien – Footer/DatumUhrzeit/Folienzahl.

**Was ist, wenn das Layout keinen Footer‑Bereich enthält – kann ich die Sichtbarkeit aktivieren?**

Ja. Prüfen Sie die Sichtbarkeit über den Header‑/Footer‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und Methoden sind dafür vorgesehen, Fälle zu behandeln, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummerierung bei einem anderen Wert als 1 beginnen lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Beispielsweise können Sie bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Headern/Footern beim Exportieren zu PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabeformat zusammen mit dem übrigen Inhalt.