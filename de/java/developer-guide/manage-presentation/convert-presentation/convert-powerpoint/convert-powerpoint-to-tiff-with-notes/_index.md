---
title: PowerPoint in TIFF mit Notizen konvertieren
type: docs
weight: 100
url: /java/convert-powerpoint-to-tiff-with-notes/
keywords: "PowerPoint in TIFF mit Notizen konvertieren"
description: "PowerPoint in TIFF mit Notizen in Aspose.Slides konvertieren."
---

## **PPT(X) im Notizen-Folienansicht in TIFF konvertieren**
Die [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse kann verwendet werden, um die gesamte Präsentation in der Notizen-Folienansicht in TIFF zu konvertieren. Die folgenden Codebeispiele aktualisieren die Beispielpräsentation in TIFF-Bilder in der Notizen-Folienansicht, wie unten gezeigt:

```java
//Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //Speichern der Präsentation in TIFF-Notizen
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

Die obigen Codebeispiele aktualisieren die Beispielpräsentation in TIFF-Bilder in der Notizen-Folienansicht, wie unten gezeigt:

|**Die Quellansicht der Präsentation mit Foliennotizen**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**Das erzeugte TIFF-Bild in der Notizen-Folienansicht**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Tipp" color="primary" %}}

Sie möchten möglicherweise den Aspose [KOSTENLOSEN PowerPoint zu Poster-Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ausprobieren.

{{% /alert %}}