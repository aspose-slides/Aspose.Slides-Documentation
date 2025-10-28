---
title: Manage Presentation Headers and Footers with Python
linktitle: Header and Footer
type: docs
weight: 140
url: /de/python-net/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile festlegen
- Fußzeile festlegen
- Handzettel
- Notizen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python über .NET, um Kopf‑ und Fußzeilen in PowerPoint‑ und OpenDocument‑Präsentationen hinzuzufügen und anzupassen und so ein professionelles Erscheinungsbild zu erzielen."
---

## **Übersicht**

Aspose.Slides für Python ermöglicht es Ihnen, Kopf‑ und Fußzeilen‑Platzhalter in einer gesamten Präsentation mit präzisem Geltungsbereich zu steuern. Fußzeilentext, Datum/Uhrzeit und Foliennummern auf Folien werden auf Master‑Ebene verwaltet und können global angewendet oder pro Folie angepasst werden. Kopfzeilen werden in Notizen und Handzetteln unterstützt, wo Sie die Sichtbarkeit umschalten und Text für Kopfzeile, Fußzeile, Datum/Uhrzeit und Seitenzahlen über den dedizierten Kopf‑ und Fußzeilen‑Manager auf dem Master‑Notizblatt oder einzelnen Notizblättern festlegen können. Dieser Artikel beschreibt die wichtigsten Muster zum Aktualisieren dieser Platzhalter und zur konsistenten Weitergabe von Änderungen in Ihrer gesamten Präsentation.

## **Kopf‑ und Fußzeilentext verwalten**

In diesem Abschnitt lernen Sie, wie Sie Kopf‑ und Fußzeilen‑Inhalte in einer Präsentation verwalten – die Fußzeile, Datum/Uhrzeit und Foliennummern aktivieren oder ändern. Wir geben kurz die Geltungsbereiche für die Anwendung dieser Einstellungen an (gesamte Präsentation, einzelne Folien und Notizen/Handzettel‑Ansichten) und zeigen, wie Sie die Aspose.Slides‑API nutzen, um sie schnell und konsistent zu aktualisieren.

Der nachstehende Code öffnet eine Präsentation, aktiviert und setzt den Fußzeilentext, aktualisiert den Kopfzeilentext auf der Master‑Notizfolie und speichert die Datei.

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

## **Kopf‑ und Fußzeilen auf Notizfolien verwalten**

In diesem Abschnitt lernen Sie, wie Sie Kopf‑ und Fußzeilen speziell für Notizfolien in Aspose.Slides verwalten. Wir behandeln das Aktivieren der relevanten Platzhalter, das Festlegen von Text für Fußzeilen, Datum/Uhrzeit und Seitenzahlen und das konsistente Anwenden dieser Änderungen auf dem Notizen‑Master und einzelnen Notizseiten.

Folgen Sie den Schritten unten:

1. Laden Sie eine Präsentationsdatei.
2. Rufen Sie die Master‑Notizfolie und deren [Kopf‑ und Fußzeilen‑Manager](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/) ab.
3. Aktivieren Sie auf der Master‑Notizfolie die Sichtbarkeit von Kopfzeile, Fußzeile, Foliennummer und Datum/Uhrzeit für den Master und alle untergeordneten Notizfolien.
4. Legen Sie auf der Master‑Notizfolie den Text für Kopfzeile, Fußzeile und Datum/Uhrzeit für den Master und alle untergeordneten Notizfolien fest.
5. Rufen Sie die Notizfolie für die erste Präsentationsfolie und deren [Kopf‑ und Fußzeilen‑Manager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/) ab.
6. Stellen Sie für diese erste Notizfolie nur sicher, dass Kopfzeile, Fußzeile, Foliennummer und Datum/Uhrzeit sichtbar sind (schalten Sie alle aus, die deaktiviert sind).
7. Setzen Sie für diese erste Notizfolie nur den Text für Kopfzeile, Fußzeile und Datum/Uhrzeit.
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

**Kann ich eine "Kopfzeile" zu normalen Folien hinzufügen?**

In PowerPoint existiert eine „Kopfzeile“ nur für Notizen und Handzettel; bei normalen Folien werden nur Fußzeile, Datum/Uhrzeit und Foliennummer unterstützt. In Aspose.Slides entspricht das denselben Einschränkungen: Kopfzeile nur für Notizen/Handzettel, und bei Folien – Fußzeile/Datum‑Uhrzeit/Foliennummer.

**Was ist, wenn das Layout keinen Fußzeilenbereich enthält – kann ich dessen Sichtbarkeit "aktivieren"?**

Ja. Prüfen Sie die Sichtbarkeit über den Kopf‑/Fußzeilen‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und -Methoden sind für Fälle gedacht, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummerierung bei einem Wert ungleich 1 beginnen lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Sie können beispielsweise bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren nach PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabeformat zusammen mit dem restlichen Inhalt.