---
title: Verwalten von Headern und Footern in Präsentationen mit Python
linktitle: Header und Footer
type: docs
weight: 140
url: /de/python-net/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile setzen
- Fußzeile setzen
- Handzettel
- Notizen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Python über .NET, um Header und Footer in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen und anzupassen, damit sie professionell aussehen."
---

## **Übersicht**

Aspose.Slides für Python ermöglicht es Ihnen, Header‑ und Footer‑Platzhalter in einer Präsentation mit präzisem Geltungsbereich zu steuern. Footer‑Text, Datum/Uhrzeit und Foliennummern auf den Folien werden auf Master‑Ebene verwaltet und können global angewendet oder pro Folie angepasst werden. Header werden in Notizen und Handouts unterstützt, wobei Sie die Sichtbarkeit umschalten und Text für Header, Footer, Datum/Uhrzeit und Seitenzahlen über den dedizierten Header‑&‑Footer‑Manager auf der Master‑Notizfolie oder einzelnen Notizfolien festlegen können. Dieser Artikel beschreibt die wichtigsten Muster zum Aktualisieren dieser Platzhalter und zum konsistenten Durchsetzen von Änderungen in Ihrer Präsentation.

## **Kopf‑ und Fußzeilentext verwalten**

In diesem Abschnitt erfahren Sie, wie Sie Header‑ und Footer‑Inhalte in einer Präsentation verwalten – den Footer, Datum und Uhrzeit sowie die Foliennummern aktivieren oder ändern. Wir skizzieren kurz die Geltungsbereiche für die Anwendung dieser Einstellungen (die gesamte Präsentation, einzelne Folien und Notiz/Handout‑Ansichten) und zeigen, wie Sie die Aspose.Slides‑API nutzen, um sie schnell und konsistent zu aktualisieren.

Das folgende Codebeispiel öffnet eine Präsentation, aktiviert und setzt den Footer‑Text, aktualisiert den Header‑Text auf der Master‑Notizfolie und speichert die Datei.
```py
import aspose.slides as slides

# Funktion zum Festlegen des Header-Textes.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Präsentation laden.
with slides.Presentation("sample.pptx") as presentation:
    # Footer festlegen.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Zugriff auf den Header und Aktualisierung.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Präsentation speichern.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Kopf‑ und Fußzeilen in Notizfolien verwalten**

In diesem Abschnitt lernen Sie, wie Sie Header und Footer speziell für Notizfolien in Aspose.Slides verwalten. Wir behandeln das Aktivieren der entsprechenden Platzhalter, das Setzen von Text für Footer, Datum/Uhrzeit und Seitenzahlen und das konsistente Anwenden dieser Änderungen auf dem Notiz‑Master und einzelnen Notizseiten.

Folgen Sie den untenstehenden Schritten:

1. Laden Sie eine Präsentationsdatei.
2. Holen Sie die Master‑Notizfolie und deren [header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).
3. Aktivieren Sie auf der Master‑Notizfolie die Sichtbarkeit von Header, Footer, Foliennummer und Datum/Uhrzeit für den Master und alle untergeordneten Notizfolien.
4. Setzen Sie auf der Master‑Notizfolie den Text für Header, Footer und Datum/Uhrzeit für den Master und alle untergeordneten Notizfolien.
5. Holen Sie die Notizfolie für die erste Präsentationsfolie und deren [header & footer manager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).
6. Stellen Sie nur für diese erste Notizfolie sicher, dass Header, Footer, Foliennummer und Datum/Uhrzeit sichtbar sind (schalten Sie ggf. ausstehende ein).
7. Setzen Sie nur für diese erste Notizfolie den Text für Header, Footer und Datum/Uhrzeit.
8. Speichern Sie die Präsentation im PPTX-Format.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Machen Sie die Master-Notizfolie und alle untergeordneten Header-, Footer-, Foliennummer- und Datum/Uhrzeit-Platzhalter sichtbar.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Text auf der Master-Notizfolie und allen untergeordneten Header-, Footer- und Datum/Uhrzeit-Platzhaltern setzen.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Header-, Footer-, Foliennummer- und Datum/Uhrzeit-Einstellungen nur für die erste Notizfolie ändern.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Sicherstellen, dass die Header-, Footer-, Foliennummer- und Datum/Uhrzeit-Platzhalter sichtbar sind.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Text auf den Header-, Footer- und Datum/Uhrzeit-Platzhaltern der Notizfolie setzen.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Präsentation speichern.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich einen „Header“ zu normalen Folien hinzufügen?**

In PowerPoint existiert ein „Header“ nur für Notizen und Handouts; bei normalen Folien werden nur Footer, Datum/Uhrzeit und Foliennummer unterstützt. In Aspose.Slides gilt dieselbe Einschränkung: Header nur für Notizen/Handouts, und auf Folien – Footer/DateTime/SlideNumber.

**Was, wenn das Layout keinen Fußzeilenbereich enthält—kann ich dessen Sichtbarkeit aktivieren?**

Ja. Überprüfen Sie die Sichtbarkeit mit dem Header‑/Footer‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und Methoden sind für Fälle gedacht, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummerierung bei einem Wert ungleich 1 beginnen lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Beispielsweise können Sie bei 0 oder 10 beginnen und die Nummer auf der Titel­folie ausblenden.

**Was geschieht mit Headern/Fußzeilen beim Export in PDF/Bilder/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabeformat zusammen mit dem übrigen Inhalt.