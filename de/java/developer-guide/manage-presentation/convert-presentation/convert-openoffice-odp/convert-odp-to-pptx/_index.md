---
title: ODP in PPTX in Java konvertieren
linktitle: ODP zu PPTX
type: docs
weight: 10
url: /de/java/convert-odp-to-pptx/
keywords:
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- ODP konvertieren
- OpenDocument zu PPTX
- ODP zu PPTX
- ODP als PPTX speichern
- ODP nach PPTX exportieren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "ODP mit Aspose.Slides für Java in PPTX konvertieren. Saubere Java-Code-Beispiele, Stapel-Tipps und hochwertige Ergebnisse - ohne PowerPoint."
---

## **ODP in PPTX/PPT-Präsentation konvertieren**
Aspose.Slides for Java bietet die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), die eine Präsentationsdatei darstellt. Die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) kann nun ODP ebenfalls über den [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-)‑Konstruktor zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie eine ODP‑Präsentation in eine PPTX‑Präsentation konvertiert wird.
```java
// ODP-Datei öffnen
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Speichere die ODP-Präsentation im PPTX-Format
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Live-Beispiel**
Sie können die Web‑App [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) besuchen, die mit **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP‑zu‑PPTX‑Konvertierung mit der Aspose.Slides‑API implementiert werden kann.