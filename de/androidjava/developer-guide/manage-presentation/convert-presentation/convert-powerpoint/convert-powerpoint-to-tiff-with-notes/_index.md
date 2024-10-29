---
title: PowerPoint in TIFF mit Notizen konvertieren
type: docs
weight: 100
url: /de/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords: "PowerPoint mit Notizen in TIFF konvertieren"
description: "PowerPoint in TIFF mit Notizen in Aspose.Slides konvertieren."
---

## **PPT(X) im Notizen-Folien-Ansicht zu TIFF konvertieren**
Die [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse kann verwendet werden, um die gesamte Präsentation in der Notizen-Folien-Ansicht in TIFF zu konvertieren. Die folgenden Code-Beispiele aktualisieren die Beispieldatei in TIFF-Bilder in der Notizen-Folien-Ansicht, wie unten gezeigt:

```java
//Erstellen eines Presentation-Objekts, das eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //Speichern der Präsentation als TIFF mit Notizen
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

Die obigen Code-Beispiele aktualisieren die Beispieldatei in TIFF-Bilder in der Notizen-Folien-Ansicht, wie unten gezeigt:

|**Die Quellansicht der Präsentation mit Foliennotizen**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**Das generierte TIFF-Bild in der Notizen-Folien-Ansicht**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Tipp" color="primary" %}}

Sie möchten vielleicht den Aspose [KOSTENLOSEN PowerPoint zu Poster-Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ausprobieren.

{{% /alert %}}