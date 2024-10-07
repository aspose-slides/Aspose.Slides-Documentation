---
title: Präsentationskopf und -fußzeile
type: docs
weight: 140
url: /python-net/presentation-header-and-footer/
keywords: "Kopfzeile, Fußzeile, Kopfzeile setzen, Fußzeile setzen, Kopf- und Fußzeile setzen, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "PowerPoint-Kopf- und Fußzeile in Python"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/python-net/) bietet Unterstützung für die Arbeit mit Texten von Kopf- und Fußzeilen, die tatsächlich auf der Masterfolie der Folien verwaltet werden.

{{% /alert %}} 

[Aspose.Slides für Python über .NET](/slides/python-net/) bietet die Funktion zur Verwaltung von Kopf- und Fußzeilen innerhalb von Präsentationsfolien. Diese werden tatsächlich auf der Masterebene der Präsentation verwaltet.
## **Kopf- und Fußzeilentext verwalten**
Die Notizen einer bestimmten Folie können wie im folgenden Beispiel aktualisiert werden:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Methode zum Setzen des Kopf-/Fußzeilentexts
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hallo, neue Kopfzeile"

# Präsentation laden
with slides.Presentation("combined_with_master.pptx") as pres:
    # Fußzeile setzen
    pres.header_footer_manager.set_all_footers_text("Mein Fußzeilentext")
    pres.header_footer_manager.set_all_footers_visibility(True)

    # Zugriff auf und Aktualisierung der Kopfzeile
    masterNotesSlide = pres.master_notes_slide_manager.master_notes_slide
    if masterNotesSlide is not None:
        update_header_footer_text(masterNotesSlide)

    # Präsentation speichern
    pres.save("HeaderFooter-out.pptx", slides.export.SaveFormat.PPTX)
```




## **Kopf- und Fußzeilen in Handouts und Notizenfolien verwalten**
Aspose.Slides für Python über .NET unterstützt Kopf- und Fußzeilen in Handouts und Notizenfolien. Bitte folgen Sie den nachstehenden Schritten:

- Laden Sie eine [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), die ein Video enthält.
- Ändern Sie die Einstellungen für Kopf- und Fußzeilen für die Notizen-Masterfolie und alle Notizenfolien.
- Setzen Sie die Master-Notizenfolie und alle untergeordneten Fußzeilen-Platzhalter sichtbar.
- Setzen Sie die Master-Notizenfolie und alle untergeordneten Platzhalter für Datum und Uhrzeit sichtbar.
- Ändern Sie die Einstellungen für Kopf- und Fußzeilen nur für die erste Notizenfolie.
- Setzen Sie den Platzhalter für die Kopfzeile der Notizenfolie sichtbar.
- Setzen Sie den Text für den Platzhalter der Kopfzeile der Notizenfolie.
- Setzen Sie den Text für den Platzhalter für Datum und Uhrzeit der Notizenfolie.
- Schreiben Sie die modifizierte Präsentationsdatei.

Der Codeausschnitt ist im folgenden Beispiel angegeben.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("combined_with_master.pptx") as presentation:
	masterNotesSlide = presentation.master_notes_slide_manager.master_notes_slide
	if masterNotesSlide != None:
		headerFooterManager = masterNotesSlide.header_footer_manager

		# Machen Sie die Master-Notizenfolie und alle untergeordneten Fußzeilen-Platzhalter sichtbar
		headerFooterManager.set_header_and_child_headers_visibility(True) 
		headerFooterManager.set_footer_and_child_footers_visibility(True) 
		headerFooterManager.set_slide_number_and_child_slide_numbers_visibility(True) 
		headerFooterManager.set_date_time_and_child_date_times_visibility(True)

		# Setzen Sie den Text für die Master-Notizenfolie und alle untergeordneten Platzhalter für Kopfzeilen
		headerFooterManager.set_header_and_child_headers_text("Kopfzeilentext") 
		headerFooterManager.set_footer_and_child_footers_text("Fußzeilentext") 
		headerFooterManager.set_date_time_and_child_date_times_text("Datum und Uhrzeit Text") 

	# Ändern Sie die Einstellungen für Kopf- und Fußzeilen nur für die erste Notizenfolie
	notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
	if notesSlide != None:
		headerFooterManager = notesSlide.header_footer_manager

		# Machen Sie den Platzhalter für die Kopfzeile der Notizenfolie sichtbar

		if not headerFooterManager.is_header_visible:
			headerFooterManager.set_header_visibility(True) 

		if not headerFooterManager.is_footer_visible:
			headerFooterManager.set_footer_visibility(True) 

		if not headerFooterManager.is_slide_number_visible:
			headerFooterManager.set_slide_number_visibility(True) 

		if not headerFooterManager.is_date_time_visible:
			headerFooterManager.set_date_time_visibility(True) 

		# Setzen Sie den Text für den Platzhalter der Kopfzeile der Notizenfolie
		headerFooterManager.set_header_text("Neuer Kopfzeilentext") 
		headerFooterManager.set_footer_text("Neuer Fußzeilentext") 
		headerFooterManager.set_date_time_text("Neuer Datum- und Uhrzeit-Text") 
	presentation.save("testresult.pptx",slides.export.SaveFormat.PPTX)
```