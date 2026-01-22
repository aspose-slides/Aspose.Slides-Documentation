---
title: PowerPoint-Folien in PNG mit JavaScript konvertieren
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint-Präsentationen schnell mit Aspose.Slides für Node.js in hochwertige PNG-Bilder in JavaScript konvertieren und dabei präzise, automatisierte Ergebnisse gewährleisten."
---

## **Über die PowerPoint‑zu‑PNG‑Konvertierung**

Das PNG‑Format (Portable Network Graphics) ist nicht so verbreitet wie JPEG (Joint Photographic Experts Group), aber es ist immer noch sehr beliebt. 

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG. 

{{% alert title="Tip" color="primary" %}} Sie können die kostenlosen Aspose **PowerPoint‑zu‑PNG‑Konverter** ausprobieren: [PPTX zu PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT zu PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Gehen Sie wie folgt vor:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie das Folien‑Objekt aus der Sammlung, die von der [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) Methode unter der [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) Klasse zurückgegeben wird.
3. Verwenden Sie die [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) Methode, um das Miniaturbild für jede Folie zu erhalten.
4. Verwenden Sie die [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) Methode, um das Folien‑Miniaturbild im PNG‑Format zu speichern.

Dieser JavaScript‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in PNG konvertieren:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG‑Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Miniaturbilds bestimmen. 

Dieser JavaScript‑Code demonstriert den beschriebenen Vorgang:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG‑Dateien in einer bestimmten Größe erhalten möchten, können Sie die gewünschten `width`‑ und `height`‑Parameter für `ImageSize` übergeben. 

Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in PNG konvertieren und dabei die Größe der Bilder angeben: 
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) anstatt der gesamten Folie exportieren?**

Aspose.Slides unterstützt das [Erzeugen von Miniaturbildern für einzelne Formen](/slides/de/nodejs-java/create-shape-thumbnails/); Sie können eine Form in ein PNG‑Bild rendern.

**Wird die parallele Konvertierung auf einem Server unterstützt?**

Ja, aber [teilen Sie nicht](/slides/de/nodejs-java/multithreading/) eine einzelne Präsentationsinstanz über Threads hinweg. Verwenden Sie für jeden Thread oder Prozess eine separate Instanz.

**Welche Einschränkungen gibt es in der Testversion beim Export nach PNG?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/nodejs-java/licensing/), bis eine Lizenz angewendet wird.