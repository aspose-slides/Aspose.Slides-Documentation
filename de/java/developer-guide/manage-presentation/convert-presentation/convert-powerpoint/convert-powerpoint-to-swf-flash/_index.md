---
title: PowerPoint-Präsentationen in SWF-Flash in Java konvertieren
linktitle: PowerPoint zu SWF
type: docs
weight: 80
url: /de/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) in SWF-Flash in Java mit Aspose.Slides konvertieren. Schritt-für-Schritt-Codebeispiele, schnelle hochwertige Ausgabe, keine PowerPoint-Automatisierung."
---

## **PPT(X) nach SWF konvertieren**
Die [Speichern](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode, die von der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein **SWF**-Dokument zu konvertieren. Das folgende Beispiel zeigt, wie man eine Präsentation mithilfe der von der [**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions) Klasse bereitgestellten Optionen in ein **SWF**-Dokument konvertiert. Sie können außerdem Kommentare im generierten **SWF** mithilfe der [**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) Klasse und der [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) Schnittstelle einfügen.
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
