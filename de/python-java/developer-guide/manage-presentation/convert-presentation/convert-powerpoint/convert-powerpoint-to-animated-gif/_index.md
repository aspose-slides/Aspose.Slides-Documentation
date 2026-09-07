---
title: PowerPoint-Präsentationen in Python in animierte GIFs konvertieren
linktitle: PowerPoint zu GIF
type: docs
weight: 65
url: /de/python-java/convert-powerpoint-to-animated-gif/
keywords:
- animiertes GIF
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu GIF
- Präsentation zu GIF
- Folie zu GIF
- PPT zu GIF
- PPTX zu GIF
- PPT als GIF speichern
- PPTX als GIF speichern
- PPT als GIF exportieren
- PPTX als GIF exportieren
- Standardeinstellungen
- Benutzerdefinierte Einstellungen
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen (PPT, PPTX) ganz einfach mit Aspose.Slides für Python via Java in animierte GIFs konvertieren. Schnelle, hochwertige Ergebnisse."
---
## **Überblick**

Aspose.Slides for Python via Java ermöglicht das Konvertieren von PowerPoint‑Präsentationen in animierte GIF‑Dateien mit nur wenigen Codezeilen. Dies ist nützlich, um Folieninhalte in Webseiten, Messenger‑Apps oder Dokumentationen zu teilen. Dieser Artikel erklärt, wie man eine Präsentation mit den Standardeinstellungen exportiert und wie man Frame‑Größe, Folienverzögerung und Übergangs‑Frame‑Rate über [GifOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/gifoptions/) anpasst.

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Das folgende Python‑Beispiel lädt `pres.pptx` und speichert es als animiertes GIF mit den Standard‑Einstellungen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tipp"%}}
Um die GIF‑Ausgabe anzupassen, übergeben Sie beim Speichern ein [GifOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/gifoptions/)-Objekt, wie unten gezeigt.
{{% /alert %}}

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Verwenden Sie [setFrameSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/gifoptions/#setFrameSize), um die Ausgabedimensionen in Pixel anzugeben, [setDefaultDelay](https://reference.aspose.com/slides/de/python-java/aspose.slides/gifoptions/#setDefaultDelay), um die Standard‑Folienverzögerung in Millisekunden festzulegen, und [setTransitionFps](https://reference.aspose.com/slides/de/python-java/aspose.slides/gifoptions/#setTransitionFps), um die Übergangs‑Frame‑Rate zu steuern.

Das folgende Beispiel exportiert ein 960 × 720‑GIF mit einer Standard‑Folienverzögerung von zwei Sekunden und 35 Frames pro Sekunde für Übergänge. Die Standardverzögerung gilt, wenn die Folie keine „Advance‑After“-Zeit hat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Hinweis"%}}
Sie können auch Aspose‘ kostenlosen [Text to GIF](https://products.aspose.app/slides/de/text-to-gif)-Konverter ausprobieren.
{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatzschriftarten](/slides/de/python-java/powerpoint-fonts/). Die Schriftart‑Substitution kann das Aussehen des exportierten GIFs ändern. Es ist wichtig, die Originalschriftarten verfügbar zu machen, wenn das Design der Präsentation beibehalten werden soll.

**Kann ich ein Wasserzeichen über die GIF‑Frames legen?**

Ja. [Fügen Sie ein halbtransparentes Objekt oder Logo](/slides/de/python-java/watermark/) zu den entsprechenden Master‑Folien oder zu einzelnen Folien vor dem Export hinzu. Das Wasserzeichen wird Teil des gerenderten Folieninhalts.