---
title: PPT zu PPTX in Python konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/python-java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Konvertieren Sie legacy PPT-Dateien zu PPTX in Python mit Aspose.Slides. Enthält Python-Beispiele für Einzel- und Batch-Konvertierung, Fehlerbehandlung und Genauigkeitshinweise."
---
## **Übersicht**

PPT ist das alte binäre PowerPoint‑Format, während PPTX das neuere Open‑XML‑Format ist. Aspose.Slides für Python über Java kann eine PPT‑Datei laden und sie als PPTX speichern, ohne Microsoft PowerPoint zu benötigen. Dieser Artikel zeigt, wie man eine einzelne Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

Jedes Beispiel startet die Java‑Virtuelle‑Maschine bei Bedarf und gibt die Präsentation nach Gebrauch frei. Ersetzen Sie die Beispielpfade durch Ihre eigenen Datei‑ oder Verzeichnispfade.

## **Eine PPT‑Datei zu PPTX konvertieren**

Laden Sie die Quelldatei mit der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse, und rufen Sie dann [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Pptx) auf. Der `finally`‑Block gibt die Präsentation frei und setzt deren Ressourcen frei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Laden Sie die alte PPT-Präsentation.
presentation = Presentation("presentation.ppt")
try:
    # Speichern Sie die Präsentation im PPTX-Format.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Dateierweiterung bestimmt das Ausgabeformat nicht automatisch; das Argument [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Pptx) tut es. Halten Sie Eingabe‑ und Ausgabepfade unterschiedlich, wenn Sie die ursprüngliche PPT‑Datei behalten möchten.

## **Mehrere PPT‑Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Vorgang den Rest des Stapels nicht stoppt.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Für produktive Einsätze protokollieren Sie die gesamte Ausnahme, entscheiden Sie, ob eine bestehende Ausgabedatei überschrieben werden darf, und schreiben Sie fehlgeschlagene Dateinamen in eine Wiederholungs‑ oder Prüfungswarteschlange. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können dazu führen, dass die Konvertierung fehlschlägt. Siehe [Password-Protected Presentations](/slides/de/python-java/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung erhält normalerweise Folien, Master, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings repräsentieren PPT und PPTX nicht jedes Feature exakt auf dieselbe Weise. Ein Legacy‑Feature, das kein PPTX‑Äquivalent hat oder von der Bibliothek nicht unterstützt wird, kann normalisiert, ausgelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, ungewöhnliche Schriften oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format, verwenden Sie daher einen geeigneten makrofähigen Workflow, wenn VBA erhalten bleiben muss. Vergewissern Sie sich außerdem, dass erforderliche Schriften und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente öffnen Sie das erzeugte PPTX programmgesteuert erneut und prüfen Sie die Anzahl der Folien sowie den Inhalt, und vergleichen Sie dann das Aussehen und das Folien‑Show‑Verhalten im vorgesehenen Viewer. Betrachten Sie einen erfolgreichen Aufruf von [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) nicht als Beweis dafür, dass jedes Legacy‑Feature eine exakte PPTX‑Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht werden soll, die mit Open‑XML‑Paketen arbeiten, oder in einem Format gespeichert werden soll, das einfacher zu prüfen und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rollback‑Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Wenn Sie stattdessen PDF, HTML, Bilder, XPS oder einen anderen Ausgabetyp benötigen, verwenden Sie die formatbezogene Anleitung in [Convert Presentations to Multiple Formats](/slides/de/python-java/convert-presentation/), anstatt anzunehmen, dass alle Ziele bearbeitbare PowerPoint‑Funktionen erhalten.

## **Online‑Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) verwenden. Für wiederholbare Konvertierungen, Batch‑Verarbeitung oder Anwendungs‑Level‑Fehlerbehandlung nutzen Sie die Python‑via‑Java‑API.

## **Verwandte Artikel**

- [PPT vs PPTX](/slides/de/python-java/ppt-vs-pptx/)
- [Präsentationen in Python speichern](/slides/de/python-java/save-presentation/)
- [Unterstützte Dateiformate](/slides/de/python-java/supported-file-formats/)
- [Präsentationen in Python öffnen](/slides/de/python-java/open-presentation/)

## **FAQ**

**Kann ich PPT zu PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für Python über Java lädt und speichert Präsentationsdateien, ohne dass Microsoft PowerPoint erforderlich ist.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt beibehalten?**

Sie behält den üblichen Präsentationsinhalt bei, aber eine exakte Genauigkeit ist nicht für jedes Legacy‑ oder nicht unterstützte Feature garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezielle Animationen oder ungewöhnliche Schriften enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, wenn Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt dazu, dass der Ladevorgang fehlschlägt.

**Soll ich die PPT‑Datei nach der Konvertierung löschen?**

Bewahren Sie das Original auf, bis Sie das PPTX in den für Sie relevanten Viewern und Workflows überprüft haben. Dies stellt eine Rollback‑Kopie bereit, falls ein Legacy‑Feature anders konvertiert wird.