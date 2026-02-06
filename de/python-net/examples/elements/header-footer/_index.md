---
title: Kopf- und Fußzeile
type: docs
weight: 220
url: /de/python-net/examples/elements/header-footer/
keywords:
- Kopf- und Fußzeile
- Kopf- und Fußzeile hinzufügen
- Kopf- und Fußzeile aktualisieren
- Datum und Uhrzeit festlegen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Steuern Sie Kopf- und Fußzeilen in Python mit Aspose.Slides: Datum/Uhrzeit, Folienzahlen und Fußzeilentext hinzufügen oder bearbeiten, Platzhalter in PPT, PPTX und ODP ein- oder ausblenden."
---
Zeigt, wie Fußzeilen hinzugefügt und Platzhalter für Datum und Uhrzeit aktualisiert werden, indem **Aspose.Slides for Python via .NET** verwendet wird.

## **Fußzeile hinzufügen**

Fügen Sie Text zum Fußzeilenbereich einer Folie hinzu und machen Sie ihn sichtbar.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Datum und Uhrzeit aktualisieren**

Ändern Sie den Platzhalter für Datum und Uhrzeit auf einer Folie.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```