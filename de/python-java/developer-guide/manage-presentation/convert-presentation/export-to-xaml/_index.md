---
title: Präsentationen nach XAML in Python via Java exportieren
linktitle: Präsentation zu XAML
type: docs
weight: 30
url: /de/python-java/export-to-xaml/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- PowerPoint zu XAML
- OpenDocument zu XAML
- Präsentation zu XAML
- PPT zu XAML
- PPTX zu XAML
- ODP zu XAML
- PPT als XAML speichern
- PPTX als XAML speichern
- ODP als XAML speichern
- PPT zu XAML exportieren
- PPTX zu XAML exportieren
- ODP zu XAML exportieren
- Python
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen nach XAML mit Aspose.Slides für Python via Java. Verwenden Sie die Standardoptionen oder schließen Sie versteckte Folien ein."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python via Java nach XAML exportiert werden. Er führt in XAML ein, zeigt den Export mit den Standardeinstellungen und demonstriert, wie versteckte Folien mit [XamlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/) eingebunden werden.

Die Beispiele erfordern Aspose.Slides für Python via Java und eine kompatible Java‑Laufzeit. Legen Sie `pres.pptx` im aktuellen Arbeitsverzeichnis ab. Jeder Beispiel startet die JVM nur, wenn sie noch nicht läuft.

## **Über XAML**

XAML (Extensible Application Markup Language) ist eine XML‑basierte Sprache zur Beschreibung von Benutzeroberflächen. Sie wird von Frameworks wie Windows Presentation Foundation (WPF) verwendet. XAML kann mit einem visuellen Designer oder einem Texteditor erstellt und bearbeitet werden.

## **Präsentationen mit Standardoptionen nach XAML exportieren**

Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) aus der Eingabedatei und übergeben Sie [XamlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/) an [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save), um den Export mit den Standardeinstellungen durchzuführen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Verwenden Sie [XamlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/), um den Export zu konfigurieren. Um versteckte Folien einzuschließen, rufen Sie vor dem Speichern [setExportHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) mit `True` auf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Wie kann ich eine Ersatzschriftart wählen, wenn die Originalschriftart nicht verfügbar ist?**

Verwenden Sie [setDefaultRegularFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) an Ihrem [XamlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/)-Objekt, um eine Ersatzschriftart anzugeben. Stellen Sie sicher, dass die gewählte Schriftart in der Exportumgebung verfügbar ist.

**Kann ich das exportierte Markup in jedem XAML‑Framework verwenden?**

XAML‑Frameworks unterscheiden sich in den unterstützten Elementen und Funktionen. Testen Sie das exportierte Markup in Ihrem Ziel‑Framework, bevor Sie es in einer Anwendung integrieren.

**Werden versteckte Folien standardmäßig exportiert?**

Nein. Um sie einzuschließen, rufen Sie [setExportHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) mit `True` auf. Lassen Sie den Wert auf `False`, um sie auszuschließen.