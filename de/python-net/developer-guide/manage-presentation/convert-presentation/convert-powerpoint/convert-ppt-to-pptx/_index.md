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
description: "Konvertieren Sie veraltete PPT-Dateien in PPTX mit Python und Aspose.Slides. Enthält Beispiele für Einzeldatei- und Batch-Konvertierung, Fehlerbehandlung und Hinweise zur Treue."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint-Format, während PPTX das neuere Open XML-Format ist. Aspose.Slides für Python via .NET kann eine PPT‑Datei laden und sie als PPTX speichern, ohne Microsoft PowerPoint zu benötigen. Dieser Artikel zeigt, wie man eine Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **Konvertieren einer PPT‑Datei in PPTX**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/), dann rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) mit [SaveFormat.PPTX](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/) auf. Die `with`‑Anweisung gibt die Präsentation frei und setzt deren Ressourcen frei, wenn der Block endet.

```python
import aspose.slides as slides

# Lade die veraltete PPT-Präsentation.
with slides.Presentation("presentation.ppt") as presentation:
    # Speichere die Präsentation im PPTX-Format.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Die Dateierweiterung wählt das Ausgabformat nicht von selbst aus; das Argument [SaveFormat.PPTX](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/) tut dies. Halten Sie die Eingabe‑ und Ausgabepfade unterschiedlich, wenn Sie die ursprüngliche PPT‑Datei beibehalten müssen.

## **Mehrere PPT‑Dateien konvertieren**

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

Für Produktionsszenarien sollten Sie die vollständige Ausnahme protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlgeschlagene Dateinamen in eine Wiederholungs‑ oder Prüfungswarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können alle zu einem Fehlversuch der Konvertierung führen. Siehe [Password-Protected Presentations](/python-net/password-protected-presentation/) für das Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung erhält normalerweise Folien, Master, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings stellen PPT und PPTX nicht jedes Merkmal exakt gleich dar. Ein Legacy‑Feature, das kein PPTX‑Äquivalent hat oder von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verlinkte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, ungewöhnliche Schriftarten oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format, daher sollten Sie einen geeigneten makrofähigen Arbeitsablauf verwenden, wenn VBA erhalten bleiben muss. Vergewissern Sie sich außerdem, dass erforderliche Schriftarten und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder wiedergegeben wird.

Bei wichtigen Dokumenten öffnen Sie das erzeugte PPTX programmgesteuert erneut und prüfen die wichtigsten Folienzahlen und Inhalte, dann vergleichen Sie das Aussehen und das Diashow‑Verhalten im vorgesehenen Viewer. Betrachten Sie einen erfolgreichen Aufruf von [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) nicht als Nachweis, dass jedes Legacy‑Feature eine exakte PPTX‑Darstellung hat.

## **Wann PPTX zu verwenden ist**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die Open‑XML‑Pakete verwenden, oder in einem Format gespeichert werden soll, das sich leichter inspizieren und wiederherstellen lässt als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rollback‑Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Falls Sie stattdessen PDF, HTML, Bilder, XPS oder einen anderen Ausgabetyp benötigen, verwenden Sie die formatspezifische Anleitung in [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) anstatt anzunehmen, dass alle Ziele bearbeitbare PowerPoint‑Funktionen erhalten.

## **Online‑Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) nutzen. Für wiederholbare Konvertierungen, Batch‑Verarbeitung oder Anwendungs‑Fehlerbehandlung verwenden Sie die Python‑API.

## **Verwandte Artikel**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/python-net/save-presentation/)
- [Supported File Formats](/python-net/supported-file-formats/)
- [Open Presentations in Python](/python-net/open-presentation/)

## **FAQ**

**Kann ich PPT zu PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für Python via .NET lädt und speichert Präsentationsdateien, ohne Microsoft PowerPoint zu benötigen.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt erhalten?**

Sie erhält die üblichen Präsentationsinhalte, aber eine exakte Treue ist nicht für jedes Legacy‑ oder nicht unterstützte Feature garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder ungewöhnliche Schriftarten enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, wenn Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt zum Scheitern des Ladevorgangs.

**Sollte ich die PPT‑Datei nach der Konvertierung löschen?**

Bewahren Sie das Original auf, bis Sie das PPTX in den für Sie relevanten Viewern und Workflows geprüft haben. So haben Sie eine Rollback‑Kopie, falls ein Legacy‑Feature anders konvertiert wird.