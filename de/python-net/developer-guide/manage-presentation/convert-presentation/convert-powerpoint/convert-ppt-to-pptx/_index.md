---
title: PPT zu PPTX in Python konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/python-net/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPT zu PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Konvertieren Sie Legacy-PPT-Dateien in PPTX mit Python und Aspose.Slides. Enthält Beispiele für Einzeldatei- und Stapelkonvertierung, Fehlerbehandlung und Genauigkeits‑Hinweise."
---
## **Übersicht**

PPT ist das alte binäre PowerPoint-Format, während PPTX das neuere Open XML-Format ist. Aspose.Slides for Python via .NET kann eine PPT-Datei laden und sie als PPTX speichern, ohne Microsoft PowerPoint zu benötigen. Dieser Artikel zeigt, wie man eine einzelne Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **PPT-Datei in PPTX konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) und rufen Sie dann [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) mit [SaveFormat.PPTX](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/) auf. Die `with`-Anweisung entsorgt die Präsentation und gibt deren Ressourcen frei, wenn der Block endet.

```python
import aspose.slides as slides

# Laden Sie die alte PPT-Präsentation.
with slides.Presentation("presentation.ppt") as presentation:
    # Speichern Sie die Präsentation im PPTX-Format.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Die Dateierweiterung wählt das Ausgabeformat nicht automatisch aus; das Argument [SaveFormat.PPTX](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/) bestimmt es. Halten Sie die Eingabe- und Ausgabepfade unterschiedlich, wenn Sie die ursprüngliche PPT-Datei beibehalten müssen.

## **Mehrere PPT-Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Vorgang den Rest des Stapels nicht stoppt.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Für produktive Einsätze sollten Sie die vollständige Ausnahme protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlgeschlagene Dateinamen in eine Wiederholungs‑ oder Prüfungswarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können alle zu einem Fehlschlag der Konvertierung führen. Siehe [Password-Protected Presentations](/slides/de/python-net/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Master, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings stellen PPT und PPTX nicht jedes Feature exakt gleich dar. Ein Legacy‑Feature, das kein PPTX‑Äquivalent hat oder von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anderweitig angezeigt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, ungewöhnliche Schriftarten oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format, daher sollten Sie einen geeigneten makrofähigen Workflow verwenden, wenn VBA verfügbar bleiben muss. Vergewissern Sie sich außerdem, dass die erforderlichen Schriftarten und externen Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente öffnen Sie das erzeugte PPTX programmgesteuert erneut und prüfen Sie die wichtigsten Folienzahlen und Inhalte, dann vergleichen Sie das Erscheinungsbild und das Vorführverhalten im gewünschten Viewer. Betrachten Sie einen erfolgreichen Aufruf von [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) nicht als Nachweis, dass jedes Legacy‑Feature eine exakte PPTX‑Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die mit Open‑XML‑Paketen arbeiten, oder in einem Format gespeichert werden soll, das sich leichter inspizieren und wiederherstellen lässt als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rollback‑Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Falls Sie stattdessen PDF, HTML, Bilder, XPS oder einen anderen Ausgabetyp benötigen, verwenden Sie die formatbezogene Anleitung in [Convert Presentations to Multiple Formats](/slides/de/python-net/convert-presentation/), anstatt anzunehmen, dass alle Ziele bearbeitbare PowerPoint‑Features erhalten.

## **Online‑Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) verwenden. Für wiederholbare Konvertierungen, Batch‑Verarbeitung oder Anwendungsebene‑Fehlerbehandlung nutzen Sie die Python‑API.

## **Verwandte Artikel**

- [PPT vs PPTX](/slides/de/python-net/ppt-vs-pptx/)
- [Präsentationen in Python speichern](/slides/de/python-net/save-presentation/)
- [Unterstützte Dateiformate](/slides/de/python-net/supported-file-formats/)
- [Präsentationen in Python öffnen](/slides/de/python-net/open-presentation/)

## **FAQ**

**Kann ich PPT zu PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides for Python via .NET lädt und speichert Präsentationsdateien, ohne Microsoft PowerPoint zu benötigen.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt beibehalten?**

Sie bewahrt gängige Präsentationsinhalte, aber eine exakte Genauigkeit ist für jedes Legacy‑ oder nicht unterstützte Feature nicht garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder ungewöhnliche Schriftarten enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, sofern Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt dazu, dass der Ladevorgang fehlschlägt.

**Sollte ich die PPT‑Datei nach der Konvertierung löschen?**

Bewahren Sie das Original auf, bis Sie das PPTX in den für Sie relevanten Viewern und Workflows geprüft haben. Dies bietet eine Rollback‑Kopie, falls ein Legacy‑Feature anders konvertiert wird.