---
title: "PowerPoint in SWF Flash konvertieren"
type: docs
weight: 80
url: /de/nodejs-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX zu SWF"
description: "PowerPoint PPT, PPTX in SWF mit JavaScript konvertieren"
---

## **PPT(X) in SWF konvertieren**
Die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) Methode, die von der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein **SWF**‑Dokument zu konvertieren. Das folgende Beispiel zeigt, wie man eine Präsentation mithilfe von Optionen, die von der Klasse [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) bereitgestellt werden, in ein **SWF**‑Dokument konvertiert. Sie können auch Kommentare im erzeugten SWF mithilfe der Klasse [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) und der Klasse [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) einbinden.
```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Speichern der Präsentation
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich ausgeblendete Folien in das SWF einbinden?**

Ja. Verwenden Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) in [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/). Standardmäßig werden ausgeblendete Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF‑Größe steuern?**

Verwenden Sie die Methode [setCompressed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setcompressed/) und [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setjpegquality/), um die Dateigröße und die Bildqualität auszubalancieren.

**Wofür ist 'setViewerIncluded' gedacht und wann sollte ich es verwenden?**

[setViewerIncluded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) fügt eine eingebettete Player‑UI (Navigationssteuerungen, Paneele, Suche) hinzu. Verwenden Sie es, wenn Sie einen eigenen Player einsetzen wollen oder einen schlichten SWF‑Rahmen ohne UI benötigen.

**Was passiert, wenn eine Quellschriftart auf dem Export‑Computer fehlt?**

Aspose.Slides ersetzt die Schriftart, die Sie über [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/) angeben, um ein unbeabsichtigtes Fallback zu vermeiden.