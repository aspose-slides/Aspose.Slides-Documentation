---
title: Erstellen von Formvorschau-Bildern
type: docs
weight: 70
url: /java/create-shape-thumbnails/
---


## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides für Java kann verwendet werden, um Präsentationsdateien zu erstellen, in denen jede Seite einer Folie entspricht. Die Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides für Java, Vorschau-Bilder der Folienformen zu generieren.

{{% /alert %}} 

In diesem Thema zeigen wir, wie man Vorschau-Bilder von Folien in verschiedenen Situationen generiert:

- Generierung eines Formvorschau-Bildes innerhalb einer Folie.
- Generierung eines Formvorschau-Bildes für eine Folienform mit benutzerdefinierten Dimensionen.
- Generierung eines Formvorschau-Bildes innerhalb der Grenzen des Erscheinungsbilds einer Form.

## **Generierung von Formvorschau-Bildern aus Folien**
Um ein Formvorschau-Bild aus einer beliebigen Folie mit Aspose.Slides für Java zu generieren, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie mithilfe ihrer ID oder ihres Indexes.
1. [Holen Sie das Formvorschau-Bild](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) der referenzierten Folie im Standardmaßstab.
1. Speichern Sie das Vorschau-Bild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt Ihnen, wie man ein Formvorschau-Bild aus einer Folie generiert:

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Vollbildbild
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generierung von Formvorschau-Bildern mit benutzerdefiniertem Skalierungsfaktor**
Um das Formvorschau-Bild einer Folie mit Aspose.Slides für Java zu generieren, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie mithilfe ihrer ID oder ihres Indexes.
1. [Holen Sie das Formvorschau-Bild](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) der referenzierten Folie mit benutzerdefinierten Dimensionen.
1. Speichern Sie das Vorschau-Bild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt Ihnen, wie man ein Formvorschau-Bild basierend auf einem definierten Skalierungsfaktor generiert:

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Vollbildbild
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generierung eines Formvorschau-Bildes der Grenzen**
Diese Methode zur Erstellung von Vorschau-Bildern von Formen ermöglicht es Entwicklern, ein Vorschau-Bild in den Grenzen des Erscheinungsbilds der Form zu generieren. Dabei werden alle Formeffekte berücksichtigt. Das generierte Formvorschau-Bild wird durch die Foliengrenzen eingeschränkt. Um ein Vorschau-Bild einer Folienform innerhalb der Grenzen ihres Erscheinungsbilds zu generieren, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie mithilfe ihrer ID oder ihres Indexes.
1. Holen Sie sich das Vorschau-Bild der referenzierten Folie mit den Formgrenzen als Erscheinungsbild.
1. Speichern Sie das Vorschau-Bild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode basiert auf den oben genannten Schritten:

```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Vollbildbild
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```