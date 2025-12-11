---
title: PowerPoint-Präsentationen in SWF-Flash auf Android konvertieren
linktitle: PowerPoint zu SWF
type: docs
weight: 80
url: /de/androidjava/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu SWF
- Präsentation zu SWF
- Folie zu SWF
- PPT zu SWF
- PPTX zu SWF
- PowerPoint zu Flash
- Präsentation zu Flash
- Folie zu Flash
- PPT zu Flash
- PPTX zu Flash
- PPT als SWF speichern
- PPTX als SWF speichern
- PPT nach SWF exportieren
- PPTX nach SWF exportieren
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) in SWF-Flash in Java mit Aspose.Slides für Android konvertieren. Schritt‑für‑Schritt‑Code‑Beispiele, schnelle hochwertige Ausgabe, keine PowerPoint‑Automatisierung."
---

## **PPT(X) in SWF konvertieren**
Die [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode, die von der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein **SWF**-Dokument zu konvertieren. Das folgende Beispiel zeigt, wie man mithilfe der von der [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions) Klasse bereitgestellten Optionen eine Präsentation in ein **SWF**-Dokument konvertiert. Sie können auch Kommentare in das erzeugte SWF einfügen, indem Sie die [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) Klasse und die [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) Schnittstelle verwenden.
```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Präsentation speichern
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich versteckte Folien in das SWF einbinden?**

Ja. Aktivieren Sie die versteckten Folien mit der [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) Methode in [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/). Standardmäßig werden versteckte Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF-Größe steuern?**

Verwenden Sie die [setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) Methode und passen Sie die [JPEG-Qualität anpassen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) an, um Dateigröße und Bildtreue auszubalancieren.

**Wofür dient 'setViewerIncluded' und wann sollte ich es deaktivieren?**

[setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) fügt eine eingebettete Player-UI (Navigationssteuerungen, Panels, Suche) hinzu. Deaktivieren Sie es, wenn Sie Ihren eigenen Player verwenden wollen oder ein reines SWF-Gerüst ohne UI benötigen.

**Was passiert, wenn auf dem Export-Computer eine Quellschriftart fehlt?**

Aspose.Slides ersetzt die Schriftart durch die, die Sie über [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) angeben, um ein unbeabsichtigtes Fallback zu vermeiden.