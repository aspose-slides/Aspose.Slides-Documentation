---
title: ODP in PPTX umwandeln
type: docs
weight: 10
url: /androidjava/convert-odp-to-pptx/
---

## **ODP in PPTX/PPT-Präsentation umwandeln**
Aspose.Slides für Android über Java bietet die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse, die eine Präsentationsdatei darstellt. Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse kann jetzt auch auf ODP über den [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) Konstruktor zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP-Präsentation in eine PPTX-Präsentation umwandelt.

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
Sie können die [**Aspose.Slides Konvertierung**](https://products.aspose.app/slides/conversion/) Webanwendung besuchen, die mit der **Aspose.Slides API** entwickelt wurde. Die App zeigt, wie die ODP-zu-PPTX-Konvertierung mit der Aspose.Slides API umgesetzt werden kann.