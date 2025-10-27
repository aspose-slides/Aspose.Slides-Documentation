---
title: Verwalten von Präsentationskopf- und Fußzeilen mit Python
linktitle: Kopfzeile und Fußzeile
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
- presentation
- Python
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python via .NET, um Kopf- und Fußzeilen in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen und anzupassen, für ein professionelles Aussehen."
---

## **Übersicht**

Aspose.Slides für Python ermöglicht es Ihnen, Platzhalter für Kopf- und Fußzeilen in einer Präsentation mit genauem Geltungsbereich zu steuern. Fußzeilentext, Datum/Uhrzeit und Folienzahlen auf Folien werden auf Masterebene verwaltet und können global angewendet oder pro Folie angepasst werden. Kopfzeilen werden in Notizen und Handzetteln unterstützt, wobei Sie die Sichtbarkeit umschalten und Text für Kopfzeile, Fußzeile, Datum/Uhrzeit und Seitenzahlen über den dedizierten Kopf‑ und Fußzeilen‑Manager auf dem Master‑Notiz‑Folienblatt oder einzelnen Notiz‑Folien festlegen können. Dieser Artikel beschreibt die wichtigsten Muster zum Aktualisieren dieser Platzhalter und zur konsistenten Weitergabe von Änderungen in Ihrem Deck.

## **Kopf‑ und Fußzeilentext verwalten**

In diesem Abschnitt lernen Sie, wie Sie Kopf‑ und Fußzeilentext in einer Präsentation verwalten – die Fußzeile, das Datum und die Uhrzeit sowie die Folienzahlen aktivieren oder ändern. Wir geben einen kurzen Überblick über die Geltungsbereiche für die Anwendung dieser Einstellungen (gesamte Präsentation, einzelne Folien und Notiz‑/Handzettel‑Ansichten) und zeigen, wie Sie die Aspose.Slides‑API verwenden, um sie schnell und konsistent zu aktualisieren.

Das nachstehende Code‑Beispiel öffnet eine Präsentation, aktiviert und setzt den Fußzeilentext, aktualisiert den Kopfzeilentext auf der Master‑Notiz‑Folien und speichert die Datei.

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

## **Kopf‑ und Fußzeilen auf Notiz‑Folien verwalten**

In diesem Abschnitt lernen Sie, wie Sie Kopf‑ und Fußzeilen speziell für Notiz‑Folien in Aspose.Slides verwalten. Wir behandeln das Aktivieren der relevanten Platzhalter, das Setzen von Text für Fußzeilen, Datum/Uhrzeit und Seitenzahlen sowie das konsistente Anwenden dieser Änderungen auf dem Notiz‑Master und einzelnen Notiz‑Seiten.

Führen Sie die folgenden Schritte aus:

1. Laden Sie eine Präsentationsdatei.
2. Holen Sie die Master‑Notiz‑Folien und deren [header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
3. Aktivieren Sie auf der Master‑Notiz‑Folien die Sichtbarkeit von Kopfzeile, Fußzeile, Foliennummer und Datum/Uhrzeit für den Master und alle untergeordneten Notiz‑Folien.
4. Setzen Sie auf der Master‑Notiz‑Folien den Text für Kopfzeile, Fußzeile und Datum/Uhrzeit für den Master und alle untergeordneten Notiz‑Folien.
5. Holen Sie die Notiz‑Folien für die erste Präsentationsfolie und deren [header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
6. Stellen Sie für diese erste Notiz‑Folien sicher, dass Kopfzeile, Fußzeile, Foliennummer und Datum/Uhrzeit sichtbar sind (schalten Sie alle aus, die deaktiviert sind, ein).
7. Setzen Sie für diese erste Notiz‑Folien den Text für Kopfzeile, Fußzeile und Datum/Uhrzeit.
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

**Kann ich einer regulären Folie eine „Kopfzeile“ hinzufügen?**

In PowerPoint gibt es die „Kopfzeile“ nur für Notizen und Handzettel; auf regulären Folien werden nur Fußzeile, Datum/Uhrzeit und Foliennummer unterstützt. In Aspose.Slides entspricht das denselben Einschränkungen: Kopfzeile nur für Notizen/Handzettel, und auf Folien – Fußzeile/DatumUhrzeit/Foliennummer.

**Was ist, wenn das Layout keinen Fußzeilenbereich enthält – kann ich die Sichtbarkeit aktivieren?**

Ja. Prüfen Sie die Sichtbarkeit über den Kopf‑/Fußzeilen‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und Methoden sind für Fälle gedacht, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummer ab einem anderen Wert als 1 beginnen lassen?**

Setzen Sie die Präsentation’s [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/); danach wird die gesamte Nummerierung neu berechnet. Sie können z. B. bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Kopf‑/Fußzeilen beim Exportieren nach PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notiz‑Seiten sichtbar sind, erscheinen sie auch im Ausgabeformat zusammen mit dem restlichen Inhalt.