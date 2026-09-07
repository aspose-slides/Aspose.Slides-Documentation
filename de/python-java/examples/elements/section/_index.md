---
title: Abschnitt
type: docs
weight: 90
url: /de/python-java/examples/elements/section/
keywords:
- Codebeispiel
- Abschnitt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie Präsentationsabschnitte in Aspose.Slides für Python via Java: Hinzufügen, Zugreifen, Entfernen und Umbenennen von Abschnitten mit Python-Codebeispielen."
---
Beispiele für die Verwaltung von Präsentationsabschnitten—Hinzufügen, Zugreifen, Entfernen und Umbenennen programmgesteuert mit **Aspose.Slides for Python via Java**.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jeder Beispiel importiert `asposeslides` bevor die JVM gestartet wird und importiert anschließend die API, nachdem die JVM läuft.

## **Abschnitt hinzufügen**

Erstellen Sie einen Abschnitt, der bei einer bestimmten Folie beginnt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Geben Sie die Folie an, die den Beginn des Abschnitts markiert.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Abschnitt abrufen**

Lesen Sie Abschnittsinformationen aus einer Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Zugriff auf einen Abschnitt nach Index.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Abschnitt entfernen**

Löschen Sie einen zuvor hinzugefügten Abschnitt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Entfernen Sie den ersten Abschnitt.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Abschnitt umbenennen**

Ändern Sie den Namen eines vorhandenen Abschnitts.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```