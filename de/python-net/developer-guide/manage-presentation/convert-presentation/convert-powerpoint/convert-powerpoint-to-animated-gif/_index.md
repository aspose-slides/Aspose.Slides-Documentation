---
title: Präsentationen in animierte GIFs in Python konvertieren
linktitle: Präsentation zu GIF
type: docs
weight: 65
url: /de/python-net/convert-powerpoint-to-animated-gif/
keywords:
- animiertes GIF
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- ODP konvertieren
- PowerPoint zu GIF
- OpenDocument zu GIF
- Präsentation zu GIF
- Folie zu GIF
- PPT zu GIF
- PPTX zu GIF
- ODP zu GIF
- Standardeinstellungen
- benutzerdefinierte Einstellungen
- Python
- Aspose.Slides
description: "Einfach PowerPoint‑Präsentationen (PPT, PPTX) und OpenDocument‑Dateien (ODP) in animierte GIFs mit Aspose.Slides für Python konvertieren. Schnell, hochwertige Ergebnisse."
---

## **Präsentationen mit Standard‑Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in Python zeigt, wie Sie eine Präsentation mit den Standard‑Einstellungen in ein animiertes GIF konvertieren:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

Das animierte GIF wird mit den Standard‑Parametern erstellt.

{{% alert title="TIPP" color="primary" %}} 
Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/)‑Klasse verwenden. Siehe den Beispielcode unten. 
{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie Sie eine Präsentation mit benutzerdefinierten Einstellungen in Python in ein animiertes GIF konvertieren:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # die Größe des resultierenden GIF
options.default_delay = 2000 # wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
options.transition_fps = 35  # FPS erhöhen für bessere Übergangsanimationsqualität

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}
Vielleicht möchten Sie den kostenlosen [Text zu GIF](https://products.aspose.app/slides/text-to-gif)‑Konverter von Aspose ausprobieren. 
{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [Fallback‑Schriften konfigurieren](/slides/de/python-net/powerpoint-fonts/). Aspose.Slides wird Ersatzschriften verwenden, aber das Aussehen kann abweichen. Für Branding sollten die benötigten Schriftarten stets explizit verfügbar sein.

**Kann ich ein Wasserzeichen auf die GIF‑Frames legen?**

Ja. [Ein halbtransparentes Objekt/Logo hinzufügen](/slides/de/python-net/watermark/) zur Master‑Folie oder zu einzelnen Folien vor dem Export – das Wasserzeichen erscheint dann in jedem Frame.