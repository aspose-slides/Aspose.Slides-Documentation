---
title: Erstellen von Formminiaturen
type: docs
weight: 70
url: /androidjava/create-shape-thumbnails/
---


## **Überblick**
{{% alert color="primary" %}} 

Aspose.Slides für Android über Java kann verwendet werden, um Präsentationsdateien zu erstellen, in denen jede Seite einer Folie entspricht. Die Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter anzeigen. In solchen Fällen hilft Aspose.Slides für Android über Java dabei, Miniaturansichten der Folienformen zu generieren.

{{% /alert %}} 

In diesem Thema zeigen wir, wie man Folienminiaturen in verschiedenen Situationen generiert:

- Generieren einer Miniaturansicht einer Form innerhalb einer Folie.
- Generieren einer Miniaturansicht einer Form für eine Folienform mit benutzerdefinierten Abmessungen.
- Generieren einer Miniaturansicht in den Grenzen des Aussehens einer Form.

## **Generieren von Formminiaturen aus Folien**
Um eine Formminiaturansicht von einer Folie mit Aspose.Slides für Android über Java zu generieren, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz der gewünschten Folie anhand ihrer ID oder ihres Index.
1. [Holen Sie das Miniaturansichtsbild der Form](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) der referenzierten Folie im Standardmaßstab.
1. Speichern Sie das Miniaturansichtsbild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt, wie man eine Formminiaturansicht von einer Folie generiert:

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

## **Generieren von Formminiaturen mit benutzerdefiniertem Maßstab**
Um die Formminiaturansicht einer Folie mit Aspose.Slides für Android über Java zu generieren, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz der gewünschten Folie anhand ihrer ID oder ihres Index.
1. [Holen Sie das Miniaturansichtsbild der Form](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) der referenzierten Folie mit benutzerdefinierten Abmessungen.
1. Speichern Sie das Miniaturansichtsbild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt, wie man eine Formminiaturansicht basierend auf einem definierten Maßstab generiert:

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

## **Generieren der Miniaturansicht der Grenzen**
Diese Methode zur Erstellung von Miniaturen von Formen ermöglicht es Entwicklern, eine Miniaturansicht in den Grenzen des Aussehens der Form zu generieren. Alle Formeffekte werden dabei berücksichtigt. Die generierte Formminiatur wird durch die Foliengrenzen eingeschränkt. Um eine Miniaturansicht einer Folienform innerhalb der Grenzen ihres Aussehens zu generieren, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz der gewünschten Folie anhand ihrer ID oder ihres Index.
1. Holen Sie das Miniaturbild der referenzierten Folie mit den Grenzen der Form als Aussehen.
1. Speichern Sie das Miniaturansichtsbild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode basiert auf den obigen Schritten:

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