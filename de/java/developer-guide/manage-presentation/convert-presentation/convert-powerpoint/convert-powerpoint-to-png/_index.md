---
title: PowerPoint-Folien zu PNG konvertieren in Java
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder konvertieren mit Aspose.Slides für Java, um präzise, automatisierte Ergebnisse zu gewährleisten."
---

## **Über die PowerPoint-zu-PNG-Konvertierung**

Das PNG‑Format (Portable Network Graphics) ist nicht so populär wie JPEG (Joint Photographic Experts Group), ist aber nach wie vor sehr beliebt.

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe keine Rolle spielt, ist PNG ein besseres Bildformat als JPEG.

{{% alert title="Tip" color="primary" %}} Vielleicht möchten Sie die kostenlosen Aspose **PowerPoint‑zu‑PNG‑Konverter** prüfen: [PPTX zu PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT zu PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint zu PNG konvertieren**

Gehen Sie wie folgt vor:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Rufen Sie das Folienobjekt aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) unter dem Interface [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) ab.
3. Verwenden Sie die Methode [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide), um das Miniaturbild für jede Folie zu erhalten.
4. Verwenden Sie die [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) Methode, um das Folien‑Miniaturbild im PNG‑Format zu speichern.

Dieser Java‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in PNG konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint zu PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG‑Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Miniaturbilds bestimmen.

Dieser Java‑Code demonstriert die beschriebene Vorgehensweise:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint zu PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG‑Dateien in einer bestimmten Größe erhalten möchten, können Sie Ihre bevorzugten Argumente `width` und `height` für `ImageSize` übergeben.

Dieser Code zeigt, wie Sie ein PowerPoint in PNG konvertieren, wobei Sie die Größe der Bilder angeben:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
