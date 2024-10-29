---
title: PowerPoint in PNG konvertieren
type: docs
weight: 30
url: /de/androidjava/convert-powerpoint-to-png/
keywords: PowerPoint in PNG, PPT in PNG, PPTX in PNG, java, Aspose.Slides für Android über Java
description: PowerPoint-Präsentation in PNG konvertieren
---

## **Über die Konvertierung von PowerPoint in PNG**

Das PNG (Portable Network Graphics) Format ist nicht so beliebt wie JPEG (Joint Photographic Experts Group), aber immer noch sehr beliebt.

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe keine Rolle spielt, ist PNG ein besseres Bildformat als JPEG. 

{{% alert title="Tipp" color="primary" %}} Sie sollten einen Blick auf die kostenlosen **PowerPoint zu PNG Konverter** von Aspose werfen: [PPTX in PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT in PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Diese sind eine Live-Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Gehen Sie diese Schritte durch:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Holen Sie das Folienobjekt aus der [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Sammlung unter dem [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) Interface.
3. Verwenden Sie die [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) Methode, um das Thumbnail für jede Folie zu erhalten.
4. Verwenden Sie die [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) Methode, um das Folien-Thumbnail im PNG-Format zu speichern.

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

Wenn Sie PNG-Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Thumbnails bestimmen.

Dieser Code in Java demonstriert den beschriebenen Vorgang:

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

Wenn Sie PNG-Dateien mit einer bestimmten Größe erhalten möchten, können Sie Ihre bevorzugten `width` und `height` Argumente für `ImageSize` übergeben.

Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in PNG konvertieren, während Sie die Größe für die Bilder angeben:

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