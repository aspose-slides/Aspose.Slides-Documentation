---
title: ODP nach PPTX in Python konvertieren
linktitle: ODP nach PPTX
type: docs
weight: 10
url: /de/python-net/convert-odp-to-pptx/
keywords:
- OpenDocument konvertieren
- ODP konvertieren
- OpenDocument zu PPTX
- ODP zu PPTX
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Konvertieren Sie ODP nach PPTX mit Aspose.Slides für Python via .NET. Saubere Codebeispiele, Batch-Tipps und hochwertige Ergebnisse - PowerPoint nicht erforderlich."
---

## **Export ODP nach PPTX**

Aspose.Slides für Python über .NET bietet die Klasse **Presentation**, die eine Präsentationsdatei repräsentiert. [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse kann nun ebenfalls über den Presentation‑Konstruktor auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie eine ODP‑Präsentation in eine PPTX‑Präsentation konvertiert wird.
```py
# Importieren Sie das Aspose.Slides-Modul für Python via .NET
import aspose.slides as slides

# Öffnen Sie die ODP-Datei
pres = slides.Presentation("AccessOpenDoc.odp")

# Speichern der ODP-Präsentation im PPTX-Format
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Live‑Beispiel**

Sie können die Web‑App [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) besuchen, die mit **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP‑nach‑PPTX‑Konvertierung mit der Aspose.Slides‑API umgesetzt werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP nach PPTX zu konvertieren?**

Nein. Aspose.Slides funktioniert eigenständig und benötigt keine Drittanbieter‑Anwendungen zum Lesen oder Schreiben von ODP/PPTX.

**Werden Master‑Folien, Layouts und Designs bei der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentations‑Objektmodell und behält die Struktur bei, einschließlich Master‑Folien und Layouts, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja. Aspose.Slides unterstützt die Erkennung von Schutz, das Öffnen und Arbeiten mit [protected presentations](/slides/de/python-net/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort bereitstellen, sowie das Konfigurieren von Verschlüsselung und den Zugriff auf Dokumenteneigenschaften.

**Eignet sich Aspose.Slides für Cloud‑ oder REST‑basierte Konvertierungsdienste?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST‑API) verwenden; beide Optionen unterstützen die ODP → PPTX‑Konvertierung.