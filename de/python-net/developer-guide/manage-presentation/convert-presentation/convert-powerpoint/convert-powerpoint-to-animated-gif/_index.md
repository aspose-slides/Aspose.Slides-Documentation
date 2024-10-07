---
title: PowerPoint in animiertes GIF konvertieren
type: docs
weight: 65
url: /python-net/convert-powerpoint-to-animated-gif/
keywords: "PowerPoint konvertieren, PPT, PPTX, animiertes GIF, PPT in animiertes GIF, PPTX in animiertes GIF, Python, Standardeinstellungen, benutzerdefinierte Einstellungen"
description: "PowerPoint-Präsentation in animiertes GIF konvertieren: PPT in GIF, PPTX in GIF in Python"
---

## Konvertieren von Präsentationen in animierte GIFs mit Standardeinstellungen ##

Dieser Beispielcode in Python zeigt Ihnen, wie Sie eine Präsentation in ein animiertes GIF mit Standardeinstellungen konvertieren:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

Das animierte GIF wird mit den Standardeinstellungen erstellt. 

{{%  alert  title="TIPP"  color="primary"  %}} 

Wenn Sie die Parameter für das GIF anpassen möchten, können Sie die [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/) Klasse verwenden. Siehe den Beispielcode unten. 

{{% /alert %}} 

## Konvertieren von Präsentationen in animierte GIFs mit benutzerdefinierten Einstellungen ##
Dieser Beispielcode zeigt Ihnen, wie Sie eine Präsentation in ein animiertes GIF mit benutzerdefinierten Einstellungen in Python konvertieren:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # die Größe des resultierenden GIF
options.default_delay = 2000 # wie lange jede Folie angezeigt wird, bevor sie zur nächsten wechselt
options.transition_fps = 35  # FPS erhöhen, um die Übergangsanimationsqualität zu verbessern

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}

Sie möchten möglicherweise einen KOSTENLOSEN [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose ausprobieren. 

{{% /alert %}}