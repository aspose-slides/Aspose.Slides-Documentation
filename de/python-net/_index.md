---
title: Aspose.Slides für Python via .NET
second_title: Aspose.Slides für Python
type: docs
weight: 35
url: /de/python-net/
is_root: true
keywords:
- Aspose.Slides für Python
- PowerPoint-Automatisierung Python
- Python PPT Bibliothek
- PowerPoint nach PDF exportieren Python
- PowerPoint nach SVG exportieren Python
- PowerPoint in Python bearbeiten
- Python PowerPoint ohne Microsoft Office
- PPTX mit Python verwalten
- Folienvorschau Python
- Python Audio zu Folien hinzufügen
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET bietet einen umfassenden Funktionsumfang, einschließlich der Verwaltung von Text, Formen, Tabellen und Animationen, dem Hinzufügen von Audio und Video zu Folien, der Vorschau von Folien und dem Export nach SVG, PDF und mehr."
---
{{% alert color="primary" %}}

**Willkommen bei Aspose.Slides für Python via .NET**

![Aspose.Slides für Python via .NET Produktlogo](aspose_slides-for-python.png)

Aspose.Slides für Python via .NET ist eine robuste Klassenbibliothek, die es Ihren Anwendungen ermöglicht, PowerPoint®‑Präsentationen zu lesen und zu schreiben, ohne Microsoft PowerPoint® zu benötigen.

Es ist die erste und einzige Komponente, die vollständiges PowerPoint®‑Dokumentenmanagement für Python‑Entwickler bereitstellt.

Aspose.Slides für Python via .NET enthält eine Vielzahl von Funktionen, z. B. Arbeiten mit Text, Formen, Tabellen und Animationen; Hinzufügen von Audio und Video; Vorschau von Folien; und Export von Folien in Formate wie SVG, PDF und mehr.

{{% /alert %}}

## Installation von Aspose.Slides für Python via .NET

```bash
pip install aspose.slides
```

Das Paket liefert die benötigte .NET‑Runtime mit, sodass nichts Weiteres installiert werden muss und Microsoft PowerPoint nicht erforderlich ist. Python 3.7 oder höher unter Windows, Linux oder macOS.

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

Beim Ausführen werden `presentation.pptx` (ca. 34 KB) und `presentation.pdf` (ca. 36 KB) im Arbeitsverzeichnis erstellt.

Ohne Lizenz läuft die Bibliothek im Evaluierungsmodus, der ein Wasserzeichen hinzufügt und die Anzahl der Folien begrenzt. Siehe [Licensing](/slides/de/python-net/licensing/) zum Anwenden einer Lizenz.

## Ressourcen für Aspose.Slides für Python via .NET

Entdecken Sie diese hilfreichen Ressourcen::

- [Aspose.Slides für Python via .NET Online-Dokumentation](/slides/de/python-net/)
- [Aspose.Slides für Python via .NET Funktionen](/slides/de/python-net/features-overview/)
- [Aspose.Slides für Python via .NET Versionshinweise](https://releases.aspose.com/slides/de/python-net/release-notes/)
- [Aspose.Slides für Python via .NET Produktseite](https://products.aspose.com/slides/de/python-net/)
- [Aspose.Slides für Python via .NET herunterladen](https://releases.aspose.com/slides/de/python-net/)
- [Aspose.Slides für Python via .NET PyPi‑Paket installieren](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides für Python via .NET API‑Referenzhandbuch](https://reference.aspose.com/slides/de/python-net/)
- [Aspose.Slides für Python via .NET kostenloses Support‑Forum](https://forum.aspose.com/c/slides/de/11)
- [Aspose.Slides für Python via .NET kostenpflichtiger Support‑Helpdesk](https://helpdesk.aspose.com/)

## Häufig gestellte Fragen

### Was ist Aspose.Slides für Python via .NET?

Aspose.Slides für Python via .NET ist eine leistungsfähige Python‑Bibliothek, die das Erstellen, Bearbeiten und Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP) programmgesteuert ermöglicht, ohne dass Microsoft PowerPoint installiert sein muss.

### Welche Präsentationsfunktionen unterstützt Aspose.Slides?

Die Bibliothek unterstützt die Verwaltung von Text, Formen, Tabellen, Diagrammen, Animationen, Master‑Folien, Audio, Video und mehr. Sie ermöglicht außerdem die Folienvorschau, das Rendern, Drucken und den Export in Formate wie PDF, SVG, HTML und Bilddateien.

### Kann ich Präsentationen mit Aspose.Slides in andere Formate konvertieren?

Ja. Aspose.Slides ermöglicht die Konvertierung von PowerPoint‑Dateien in PDF, SVG, HTML, JPG, PNG, TIFF und weitere Formate mit hoher Treue und Leistung.

### Ist Microsoft PowerPoint erforderlich, um Aspose.Slides zu nutzen?

Nein. Aspose.Slides ist eine eigenständige API und erfordert weder Microsoft Office noch andere Drittanbieter‑Software.

### Welche Plattformen werden von Aspose.Slides für Python via .NET unterstützt?

Es ist plattformübergreifend und funktioniert in Windows‑, Linux‑ und macOS‑Umgebungen.

### Wie kann ich mit Aspose.Slides für Python beginnen?

Sie können das Paket über PyPi installieren und den [Developer Guide](/slides/de/python-net/developer-guide/) nutzen, um mit Beispielen, API‑Referenzen und Tutorials zu starten.