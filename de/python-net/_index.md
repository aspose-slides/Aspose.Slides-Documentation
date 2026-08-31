---
title: Aspose.Slides für Python via .NET
second_title: Aspose.Slides für Python
type: docs
weight: 35
url: /de/python-net/
is_root: true
keywords:
- Aspose.Slides für Python
- PowerPoint-Automatisierung mit Python
- Python PPT-Bibliothek
- PowerPoint nach PDF exportieren mit Python
- PowerPoint nach SVG exportieren mit Python
- PowerPoint in Python bearbeiten
- Python PowerPoint ohne Microsoft Office
- PPTX mit Python verwalten
- Folienvorschau Python
- Python Audio zu Folien hinzufügen
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides für Python via .NET bietet ein umfassendes Funktionsset, einschließlich der Verwaltung von Text, Formen, Tabellen und Animationen, dem Hinzufügen von Audio und Video zu Folien, der Vorschau von Folien und dem Export nach SVG, PDF und mehr."
---
{{% alert color="info" %}}

**Willkommen bei Aspose.Slides für Python via .NET**

![Aspose.Slides für Python via .NET Produktlogo](aspose_slides-for-python.png)

Aspose.Slides für Python via .NET ist eine robuste Klassenbibliothek, die es Ihren Anwendungen ermöglicht, PowerPoint®‑Präsentationen zu lesen und zu schreiben, ohne Microsoft PowerPoint® zu benötigen.

Es ist die erste und einzige Komponente, die Python‑Entwicklern eine vollumfängliche PowerPoint®‑Dokumentenverwaltung bietet.

Aspose.Slides für Python via .NET umfasst ein breites Spektrum an Funktionen, z. B. die Arbeit mit Text, Formen, Tabellen und Animationen; das Hinzufügen von Audio und Video; die Vorschau von Folien; sowie das Exportieren von Folien in Formate wie SVG, PDF und weitere.

{{% /alert %}}

## Installieren von Aspose.Slides für Python via .NET

```bash
pip install aspose.slides
```

Das Paket liefert die erforderliche .NET‑Laufzeit, sodass nichts Weiteres installiert werden muss und Microsoft PowerPoint nicht erforderlich ist. Python 3.7 oder neuer unter Windows, Linux oder macOS.

## Erstellen einer PowerPoint‑Präsentation in Python

Dieses Beispiel erstellt eine Präsentation, fügt der ersten Folie eine Form mit Text hinzu und speichert das Ergebnis sowohl als PPTX als auch als PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Beim Ausführen wird `presentation.pptx` (ca. 34 KB) und `presentation.pdf` (ca. 36 KB) im Arbeitsverzeichnis gespeichert.

Ohne Lizenz läuft die Bibliothek im Evaluierungsmodus, der ein Wasserzeichen hinzufügt und die Anzahl der Folien begrenzt. Siehe [Lizenzierung](/slides/de/python-net/licensing/), um eine zu aktivieren.

## Aspose.Slides für Python via .NET Ressourcen

Entdecken Sie diese hilfreichen Ressourcen:

- [Aspose.Slides für Python via .NET Online-Dokumentation](/slides/de/python-net/)
- [Aspose.Slides für Python via .NET Funktionen](/slides/de/python-net/features-overview/)
- [Aspose.Slides für Python via .NET Versionshinweise](https://releases.aspose.com/slides/de/python-net/release-notes/)
- [Aspose.Slides für Python via .NET Produktseite](https://products.aspose.com/slides/de/python-net/)
- [Download Aspose.Slides für Python via .NET](https://releases.aspose.com/slides/de/python-net/)
- [Aspose.Slides für Python via .NET PyPi-Paket installieren](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides für Python via .NET API‑Referenzhandbuch](https://reference.aspose.com/slides/de/python-net/)
- [Aspose.Slides für Python via .NET Kostenloses Support-Forum](https://forum.aspose.com/c/slides/de/11)
- [Aspose.Slides für Python via .NET Kostenpflichtiger Support‑Helpdesk](https://helpdesk.aspose.com/)

## FAQ

### Was ist Aspose.Slides für Python via .NET?

Aspose.Slides für Python via .NET ist eine leistungsstarke Python‑Bibliothek, mit der Sie PowerPoint‑Präsentationen (PPT, PPTX, ODP) programmgesteuert erstellen, bearbeiten und konvertieren können, ohne dass Microsoft PowerPoint installiert sein muss.

### Welche Präsentationsfunktionen unterstützt Aspose.Slides?

Die Bibliothek unterstützt die Verwaltung von Text, Formen, Tabellen, Diagrammen, Animationen, Master‑Folien, Audio, Video und mehr. Außerdem ermöglicht sie die Folienvorschau, das Rendering und den Export in Formate wie PDF, SVG, HTML und Bilder.

### Kann ich Präsentationen mit Aspose.Slides in andere Formate konvertieren?

Ja. Aspose.Slides ermöglicht die Konvertierung von PowerPoint‑Dateien in PDF, SVG, HTML, JPG, PNG, TIFF und weitere Formate mit hoher Treue und Leistung.

### Wird Microsoft PowerPoint benötigt, um Aspose.Slides zu verwenden?

Nein. Aspose.Slides ist eine eigenständige API und erfordert weder Microsoft Office noch Drittanbieter‑Software.

### Welche Plattformen unterstützt Aspose.Slides für Python via .NET?

Sie ist plattformübergreifend und funktioniert in Windows-, Linux- und macOS‑Umgebungen.

### Wie komme ich mit Aspose.Slides für Python starten?

Sie können es über PyPi installieren und das [Entwicklerhandbuch](/slides/de/python-net/developer-guide/) durchstöbern, um mit Beispielen, API‑Referenzen und Tutorials zu beginnen.