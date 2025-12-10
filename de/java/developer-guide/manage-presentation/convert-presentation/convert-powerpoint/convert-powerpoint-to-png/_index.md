---
title: PowerPoint-Folien in PNG konvertieren in Java
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
description: "Konvertieren Sie PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder mit Aspose.Slides für Java und gewährleisten dabei präzise, automatisierte Ergebnisse."
---

## **Über die PowerPoint-zu-PNG-Konvertierung**

Das PNG (Portable Network Graphics)-Format ist nicht so populär wie JPEG (Joint Photographic Experts Group), aber es ist immer noch sehr beliebt. 

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG. 

{{% alert title="Tip" color="primary" %}} Vielleicht möchten Sie sich die kostenlosen Aspose **PowerPoint-zu-PNG-Konverter** ansehen: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live-Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Führen Sie die folgenden Schritte aus:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
2. Rufen Sie das Folienobjekt aus der [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Sammlung über das [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)-Interface ab.
3. Verwenden Sie die Methode [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide), um das Miniaturbild für jede Folie zu erhalten.
4. Verwenden Sie die [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat))-Methode, um das Folien‑Miniaturbild im PNG-Format zu speichern.

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PNG konvertieren:
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


## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG-Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Miniaturbildes bestimmen. 

Dieser Java-Code demonstriert die beschriebene Operation:
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


## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG-Dateien in einer bestimmten Größe erhalten möchten, können Sie Ihre bevorzugten `width`- und `height`-Argumente für `ImageSize` übergeben. 

Dieser Code zeigt Ihnen, wie Sie ein PowerPoint in PNG konvertieren, während Sie die Größe der Bilder angeben: 
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


## **FAQ**

**Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) statt der gesamten Folie exportieren?**  
Aspose.Slides unterstützt das [Erzeugen von Miniaturbildern für einzelne Formen](/slides/de/java/create-shape-thumbnails/); Sie können eine Form als PNG-Bild rendern.

**Wird die parallele Konvertierung auf einem Server unterstützt?**  
Ja, aber [nicht teilen](/slides/de/java/multithreading/) Sie keine einzelne Präsentationsinstanz über Threads hinweg. Verwenden Sie pro Thread oder Prozess eine separate Instanz.

**Welche Einschränkungen gibt es in der Testversion beim Exportieren nach PNG?**  
Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/java/licensing/), bis eine Lizenz angewendet wird.