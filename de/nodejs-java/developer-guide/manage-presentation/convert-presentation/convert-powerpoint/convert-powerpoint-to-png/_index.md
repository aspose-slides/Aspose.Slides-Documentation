---
title: PowerPoint in PNG konvertieren
type: docs
weight: 30
url: /de/nodejs-java/convert-powerpoint-to-png/
keywords: PowerPoint zu PNG, PPT zu PNG, PPTX zu PNG, java, Aspose.Slides für Node.js via Java
description: PowerPoint‑Präsentation in PNG konvertieren
---

## **Über die PowerPoint-zu-PNG-Konvertierung**

Das PNG (Portable Network Graphics)-Format ist nicht so verbreitet wie JPEG (Joint Photographic Experts Group), aber es ist immer noch sehr beliebt. 

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG. 

{{% alert title="Tip" color="primary" %}} Sie sollten sich die kostenlosen Aspose free **PowerPoint to PNG Converters** ansehen: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Implementierung des auf dieser Seite beschriebenen Vorgangs. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Führen Sie die folgenden Schritte aus:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Klasse.
2. Rufen Sie das Folienobjekt aus der Sammlung ab, die von der Methode [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) der [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)-Klasse zurückgegeben wird.
3. Verwenden Sie die Methode [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide), um das Thumbnail jeder Folie zu erhalten.
4. Verwenden Sie die [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat))-Methode, um das Folien‑Thumbnail im PNG‑Format zu speichern.

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

Wenn Sie PNG‑Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Thumbnails bestimmen. 

Dieser JavaScript‑Code demonstriert die beschriebene Vorgehensweise:
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

Wenn Sie PNG‑Dateien in einer bestimmten Größe erhalten möchten, können Sie die gewünschten `width`‑ und `height`‑Argumente für `ImageSize` übergeben. 

Dieser Code zeigt, wie Sie eine PowerPoint‑Datei in PNG konvertieren und dabei die Bildgröße festlegen: 
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

**Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) exportieren, anstatt die gesamte Folie?**

Aspose.Slides unterstützt das [generating thumbnails for individual shapes](/slides/de/nodejs-java/create-shape-thumbnails/); Sie können eine Form als PNG‑Bild rendern.

**Wird parallele Konvertierung auf einem Server unterstützt?**

Ja, aber [don’t share](/slides/de/nodejs-java/multithreading/) Sie eine einzelne Präsentationsinstanz nicht über Threads hinweg. Verwenden Sie pro Thread oder Prozess eine separate Instanz.

**Welche Einschränkungen hat die Testversion beim Export nach PNG?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [other restrictions](/slides/de/nodejs-java/licensing/), bis eine Lizenz angewendet wird.