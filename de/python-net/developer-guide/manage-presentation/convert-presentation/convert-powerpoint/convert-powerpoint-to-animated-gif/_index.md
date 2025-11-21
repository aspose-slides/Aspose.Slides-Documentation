---
title: Präsentationen in Python in animierte GIFs konvertieren
linktitle: Präsentation zu GIF
type: docs
weight: 65
url: /de/python-net/convert-powerpoint-to-animated-gif/
keywords:
- animiertes GIF
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPTX konvertieren
- ODP konvertieren
- PowerPoint zu GIF
- OpenDocument zu GIF
- Präsentation zu GIF
- Folien zu GIF
- PPT zu GIF
- PPTX zu GIF
- ODP zu GIF
- Standard-Einstellungen
- Benutzerdefinierte Einstellungen
- Python
- Aspose.Slides
description: "Konvertieren Sie PowerPoint‑Präsentationen (PPT, PPTX) und OpenDocument‑Dateien (ODP) einfach in animierte GIFs mit Aspose.Slides für Python. Schnelle, hochwertige Ergebnisse."
---

## **Präsentationen mit Standardeinstellungen in animiertes GIF konvertieren**

Dieser Beispielcode in Python zeigt, wie man eine Präsentation mit Standard‑Einstellungen in ein animiertes GIF konvertiert:
```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```


Das animierte GIF wird mit den Standardparametern erstellt. 

{{%  alert  title="TIP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die Klasse [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/) verwenden. Siehe den Beispielcode unten. 

{{% /alert %}} 

## **Präsentationen mit benutzerdefinierten Einstellungen in animiertes GIF konvertieren**

Dieser Beispielcode zeigt, wie man eine Präsentation mit benutzerdefinierten Einstellungen in Python in ein animiertes GIF konvertiert:
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # die Größe des resultierenden GIFs
options.default_delay = 2000 # wie lange jede Folie angezeigt wird, bis sie zur nächsten wechselt
options.transition_fps = 35  # FPS erhöhen für bessere Übergangsanimationsqualität

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```


{{% alert title="Info" color="info" %}}

Vielleicht möchten Sie den KOSTENLOSEN [Text to GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose ausprobieren. 

{{% /alert %}}

## **FAQ**

**Was ist, wenn die in der Präsentation verwendeten Schriftarten nicht auf dem System installiert sind?**

Installieren Sie die fehlenden Schriftarten oder [konfigurieren Sie Ersatzschriftarten](/slides/de/python-net/powerpoint-fonts/). Aspose.Slides wird sie ersetzen, aber das Aussehen kann abweichen. Für Branding stellen Sie stets sicher, dass die erforderlichen Schriftarten explizit verfügbar sind.

**Kann ich ein Wasserzeichen auf die GIF‑Frames legen?**

Ja. [Fügen Sie ein halbtransparentes Objekt/Logo](/slides/de/python-net/watermark/) zur Master‑Folien oder zu einzelnen Folien vor dem Export hinzu — das Wasserzeichen wird auf jedem Frame angezeigt.