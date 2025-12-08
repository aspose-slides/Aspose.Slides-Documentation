---
title: PPTX nach PPT in Python konvertieren
linktitle: PPTX zu PPT
type: docs
weight: 21
url: /de/python-net/convert-pptx-to-ppt/
keywords:
- PPTX zu PPT
- PPTX nach PPT konvertieren
- PowerPoint konvertieren
- Präsentation konvertieren
- Python
- Aspose.Slides
description: "Konvertieren Sie PPTX einfach zu PPT mit Aspose.Slides für Python über .NET - sorgen Sie für nahtlose Kompatibilität mit PowerPoint-Formaten und bewahren Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Aspose.Slides for Python ermöglicht das Konvertieren moderner PPTX‑Präsentationen in das alte PPT‑Format vollständig im Code. Öffnen Sie eine PPTX‑Datei und exportieren Sie sie als PPT, wobei Inhalt und Layout der Präsentation erhalten bleiben, sodass das Ergebnis mit älteren Versionen von PowerPoint kompatibel ist. derselbe Workflow kann weitere Ausgaben erzeugen – wie PDF, XPS, ODP, HTML oder Bilder – und lässt sich daher nahtlos in Skripte, CI‑Pipelines und Stapelverarbeitungen integrieren.

## **PPTX in PPT konvertieren**

Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)‑Methode der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse. Das unten stehende Python‑Beispiel konvertiert eine Präsentation von PPTX nach PPT unter Verwendung der Standardoptionen.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
presentation = slides.Presentation("presentation.pptx")

# Speichern Sie die Präsentation als PPT-Datei.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```


## **FAQ**

**Überleben alle PPTX‑Effekte und -Funktionen beim Speichern im Legacy‑PPT‑Format (97–2003)?**

Nicht immer. Das PPT‑Format fehlt es an einigen neueren Möglichkeiten (z. B. bestimmten Effekten, Objekten und Verhaltensweisen), sodass Funktionen während der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren, anstatt die gesamte Präsentation?**

Das direkte Speichern wirkt sich auf die gesamte Präsentation aus. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ nutzen Sie einen Dienst/API, der per‑Folie‑Konvertierungsparameter unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und auch die [Konfiguration von Schutz-/Verschlüsselungseinstellungen](/slides/de/python-net/password-protected-presentation/) für das gespeicherte PPT festlegen.

**Siehe auch:**
- [PPT & PPTX nach PDF in Python konvertieren | Erweiterte Optionen](/slides/de/python-net/convert-powerpoint-to-pdf/)
- [PowerPoint‑Präsentationen in XPS in Python konvertieren](/slides/de/python-net/convert-powerpoint-to-xps/)
- [PowerPoint‑Präsentationen in HTML in Python konvertieren](/slides/de/python-net/convert-powerpoint-to-html/)
- [PowerPoint‑Folien in PNG in Python konvertieren](/slides/de/python-net/convert-powerpoint-to-png/)