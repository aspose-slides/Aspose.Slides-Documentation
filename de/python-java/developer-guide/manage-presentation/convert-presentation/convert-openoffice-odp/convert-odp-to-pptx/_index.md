---
title: ODP nach PPTX in Python konvertieren
linktitle: ODP nach PPTX
type: docs
weight: 10
url: /de/python-java/convert-odp-to-pptx/
keywords:
- OpenDocument konvertieren
- Präsentation konvertieren
- Folien konvertieren
- ODP konvertieren
- OpenDocument nach PPTX
- ODP nach PPTX
- ODP als PPTX speichern
- ODP nach PPTX exportieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Konvertieren Sie ODP-Präsentationen zu PPTX mit Aspose.Slides für Python über Java. Verwenden Sie ein komplettes Python-Beispiel, ohne PowerPoint oder LibreOffice zu installieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man eine OpenDocument‑(ODP‑)Präsentation in das PowerPoint‑(PPTX‑)Format mit Aspose.Slides für Python über Java konvertiert.

## **ODP in PPTX konvertieren**

Die Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) kann eine ODP‑Datei direkt laden. Speichern Sie die geladene Präsentation im PPTX‑Format mit [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/).

Befolgen Sie die [installationsanweisungen](/slides/de/python-java/installation/), bevor Sie das Beispiel ausführen. Legen Sie eine ODP‑Präsentation mit dem Namen `AccessOpenDoc.odp` im Arbeitsverzeichnis ab. Der folgende Code startet die JVM bei Bedarf, öffnet die ODP‑Datei und speichert sie als `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # Speichern Sie die ODP-Präsentation im PPTX-Format.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Live‑Beispiel**

Testen Sie die Web‑App [Aspose.Slides Conversion](https://products.aspose.app/slides/de/conversion/), um die von Aspose.Slides unterstützte ODP‑zu‑PPTX‑Konvertierung zu sehen.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP nach PPTX zu konvertieren?**

Nein. Aspose.Slides für Python über Java liest und schreibt Präsentationsdateien ohne diese Anwendungen. Sie benötigen das Python‑Paket und eine kompatible Java‑Runtime.

**Werden Master‑Folien, Layouts und Designs bei der Konvertierung beibehalten?**

Aspose.Slides bildet die Struktur und Formatierung der Quellpräsentation auf PPTX ab. Da ODP und PPTX jedoch unterschiedliche Funktionen unterstützen, können einige Elemente nach der Konvertierung anders aussehen. Stellen Sie die erforderlichen Schriftarten bereit und prüfen Sie Präsentationen mit komplexer Formatierung. Siehe [OpenDocument conversion](/slides/de/python-java/convert-openoffice-odp/) für Kompatibilitäts‑Hinweise.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja, sofern Sie das zum Öffnen der Datei erforderliche Passwort angeben. Siehe [password-protected presentations](/slides/de/python-java/password-protected-presentation/) für Details zum Laden geschützter Dateien, bevor Sie sie in ein anderes Format speichern.

**Eignet sich Aspose.Slides für Cloud‑ oder REST‑basierte Konvertierungsdienste?**

Ja. Sie können Aspose.Slides für Python über Java in Ihrem Backend mit der erforderlichen Java‑Runtime verwenden. Für eine REST‑API siehe [Aspose.Slides Cloud](https://products.aspose.cloud/slides/de/family/).