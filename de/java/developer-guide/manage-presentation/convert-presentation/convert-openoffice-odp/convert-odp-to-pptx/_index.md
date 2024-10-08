---
title: ODP in PPTX konvertieren
type: docs
weight: 10
url: /de/java/convert-odp-to-pptx/
---

## **ODP in PPTX/PPT-Präsentation konvertieren**
Aspose.Slides für Java bietet die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), die eine Präsentationsdatei darstellt. Die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) kann nun auch über den Konstruktor [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie eine ODP-Präsentation in eine PPTX-Präsentation konvertiert werden kann.

```java
// ODP-Datei öffnen
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Speichern der ODP-Präsentation im PPTX-Format
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live-Beispiel**
Sie können die [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Webanwendung besuchen, die mit der **Aspose.Slides API** entwickelt wurde. Die App demonstriert, wie die Konvertierung von ODP in PPTX mit der Aspose.Slides API implementiert werden kann.