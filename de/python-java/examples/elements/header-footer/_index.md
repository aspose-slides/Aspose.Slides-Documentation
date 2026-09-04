---
title: Kopfzeile Fußzeile
type: docs
weight: 220
url: /de/python-java/examples/elements/header-footer/
keywords:
- Codebeispiel
- Kopfzeile
- Fußzeile
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Steuern Sie Folienkopf- und -fußzeilen mit Aspose.Slides für Python via Java: Fügen Sie Datum, Foliennummern und benutzerdefinierten Text in PPT-, PPTX- und ODP-Präsentationen hinzu."
---
Dieser Artikel demonstriert, wie man Fußzeilen hinzufügt und Platzhalter für Datum und Uhrzeit aktualisiert, indem man **Aspose.Slides for Python via Java** verwendet.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jedes Beispiel importiert `asposeslides`, bevor die JVM gestartet wird, und importiert anschließend die API, sobald die JVM läuft.

## **Fußzeile hinzufügen**

Fügen Sie Text zum Fußzeilenbereich einer Folie hinzu und machen Sie ihn sichtbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Datum und Uhrzeit aktualisieren**

Ändern Sie den Platzhalter für Datum und Uhrzeit auf einer Folie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```