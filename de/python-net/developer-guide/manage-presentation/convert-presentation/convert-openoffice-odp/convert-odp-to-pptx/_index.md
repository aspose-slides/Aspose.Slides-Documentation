---
title: ODP in PPTX konvertieren
type: docs
weight: 10
url: /python-net/convert-odp-to-pptx/
keywords: "OpenOffice Präsentation konvertieren, ODP, ODP in PPTX, Python"
description: "OpenOffice ODP in PowerPoint Präsentation PPTX in Python konvertieren"
---

Aspose.Slides für Python über .NET bietet die Klasse Präsentation, die eine Präsentationsdatei darstellt. Die [**Präsentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse kann jetzt auch über den Präsentationskonstruktor auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP-Präsentation in eine PPTX-Präsentation konvertiert.

```py
# Aspose.Slides für Python über .NET Modul importieren
import aspose.slides as slides

# Die ODP-Datei öffnen
pres = slides.Presentation("AccessOpenDoc.odp")

# Die ODP-Präsentation im PPTX-Format speichern
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Live-Beispiel**
Sie können die [**Aspose.Slides-Konvertierung**](https://products.aspose.app/slides/conversion/) Webanwendung besuchen, die mit der **Aspose.Slides API** erstellt wurde. Die App zeigt, wie die ODP-zu-PPTX-Konvertierung mit der Aspose.Slides-API implementiert werden kann.