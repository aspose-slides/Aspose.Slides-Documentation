---
title: PPT in PPTX mit Python konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/python-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPT zu PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Konvertieren Sie veraltete PPT-Dateien in PPTX mit Python und Aspose.Slides. Enthält Python-Beispiele für Einzelfile- und Batch-Konvertierung, Fehlerbehandlung und Hinweise zur Genauigkeit."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint-Format, während PPTX das neuere Open XML-Format ist. Aspose.Slides für Python via Java kann eine PPT-Datei laden und sie ohne Microsoft PowerPoint als PPTX speichern. Dieser Artikel zeigt, wie man eine Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

Jedes Beispiel startet die Java-Virtual-Machine bei Bedarf und gibt die Präsentation nach der Verwendung frei. Ersetzen Sie die Beispielpfade durch Ihre eigenen Datei- oder Verzeichnispfade.

## **Konvertieren einer PPT-Datei in PPTX**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und rufen Sie dann [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Pptx) auf. Der `finally`-Block gibt die Präsentation frei und gibt ihre Ressourcen frei.

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

Die Dateierweiterung wählt das Ausgabeformat nicht automatisch aus; das Argument [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Pptx) macht dies. Halten Sie die Eingabe‑ und Ausgabe‑Pfad verschieden, wenn Sie die ursprüngliche PPT‑Datei behalten müssen.

## **Mehrere PPT-Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`-Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Vorgang nicht den Rest des Stapels stoppt.

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

Für produktive Abläufe sollten Sie die vollständige Ausnahme protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlgeschlagene Dateinamen in eine Wiederholungs- oder Prüfwarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können alle dazu führen, dass eine Konvertierung fehlschlägt. Siehe [Password-Protected Presentations](/slides/de/python-java/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy-Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Master, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings stellen PPT und PPTX nicht jedes Feature exakt gleich dar. Ein Legacy-Feature, das kein PPTX-Äquivalent hat oder von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verlinkte OLE-Objekte, ActiveX-Steuerelemente, eingebettete Medien, ungewöhnliche Schriftarten oder VBA-Makros enthält. Eine reine PPTX-Datei ist kein makrofähiges Format, daher sollten Sie einen geeigneten makrofähigen Workflow verwenden, wenn VBA erhalten bleiben muss. Vergewissern Sie sich außerdem, dass die erforderlichen Schriftarten und externen Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente sollten Sie das erzeugte PPTX programmgesteuert erneut öffnen und Schlüssel‑Folienanzahlen sowie Inhalt prüfen, dann dessen Darstellung und Bildlaufverhalten im gewünschten Viewer vergleichen. Behandeln Sie einen erfolgreichen Aufruf von [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) nicht als Nachweis, dass jedes Legacy-Feature eine exakte PPTX-Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint-Versionen bearbeitet, mit Systemen ausgetauscht wird, die Open XML-Pakete verarbeiten, oder in einem Format gespeichert werden soll, das leichter zu prüfen und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rückgängig-Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeits-Tests bestanden hat.

Wenn Sie stattdessen PDF, HTML, Bilder, XPS oder einen anderen Ausgabetyp benötigen, verwenden Sie die formatbezogene Anleitung in [Convert Presentations to Multiple Formats](/slides/de/python-java/convert-presentation/), anstatt anzunehmen, dass alle Ziele editierbare PowerPoint-Features erhalten.

## **Online-Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) nutzen. Für wiederholbare Konvertierungen, Batch-Verarbeitung oder Fehlerbehandlung auf Anwendungsebene verwenden Sie die Python-via-Java-API.

## **Verwandte Artikel**

- [PPT vs PPTX](/slides/de/python-java/ppt-vs-pptx/)
- [Präsentationen in Python speichern](/slides/de/python-java/save-presentation/)
- [Unterstützte Dateiformate](/slides/de/python-java/supported-file-formats/)
- [Präsentationen in Python öffnen](/slides/de/python-java/open-presentation/)

## **FAQ**

**Kann ich PPT zu PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für Python via Java lädt und speichert Präsentationsdateien, ohne Microsoft PowerPoint zu benötigen.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt beibehalten?**

Sie bewahrt den üblichen Präsentationsinhalt, jedoch ist eine exakte Treue für jedes Legacy- oder nicht unterstützte Feature nicht garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder ungewöhnliche Schriftarten enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, sofern Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt zum Fehlschlagen des Ladevorgangs.

**Sollte ich die PPT‑Datei nach der Konvertierung löschen?**

Bewahren Sie das Original, bis Sie das PPTX in den für Sie relevanten Viewern und Workflows überprüft haben. So haben Sie eine Rückgängig-Kopie, falls ein Legacy-Feature anders konvertiert wird.