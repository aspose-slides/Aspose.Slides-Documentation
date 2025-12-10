---
title: Miniaturansichten von Präsentationsformen in Java erstellen
linktitle: Form-Miniaturansichten
type: docs
weight: 70
url: /de/java/create-shape-thumbnails/
keywords:
- Form-Miniaturansicht
- Form-Bild
- Form rendern
- Form-Rendering
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen Sie hochwertige Form-Miniaturansichten aus PowerPoint-Folien mit Aspose.Slides für Java – einfach Präsentations-Miniaturansichten erzeugen und exportieren."
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides for Java kann verwendet werden, um Präsentationsdateien zu erstellen, bei denen jede Seite einer Folie entspricht. Die Folien können durch Öffnen der Präsentationsdateien mit Microsoft PowerPoint angezeigt werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides for Java, Miniaturbilder der Folienformen zu erzeugen.

{{% /alert %}} 

In diesem Thema zeigen wir, wie man Miniaturansichten von Folien in verschiedenen Situationen erzeugt:

- Erzeugen einer Form‑Miniaturansicht innerhalb einer Folie.
- Erzeugen einer Form‑Miniaturansicht für eine Folienform mit benutzerdefinierten Abmessungen.
- Erzeugen einer Form‑Miniaturansicht innerhalb der Grenzen des Aussehens einer Form.

## **Form‑Miniaturansicht von einer Folie erzeugen**
Um eine Form‑Miniaturansicht von einer beliebigen Folie mit Aspose.Slides for Java zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Rufen Sie die Referenz einer beliebigen Folie über deren ID oder Index ab.
1. [Abrufen des Form‑Miniaturbildes](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) der referenzierten Folie in der Standardgröße.
1. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt, wie Sie eine Form‑Miniaturansicht von einer Folie erzeugen:
```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstellen Sie ein Bild in voller Auflösung
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Speichern Sie das Bild im PNG-Format auf der Festplatte
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Miniaturansicht mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um die Form‑Miniaturansicht einer Folie mit benutzerdefinierten Abmessungen zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Rufen Sie die Referenz einer beliebigen Folie über deren ID oder Index ab.
1. [Abrufen des Form‑Miniaturbildes](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) der referenzierten Folie mit benutzerdefinierten Dimensionen.
1. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt, wie Sie eine Form‑Miniaturansicht basierend auf einem definierten Skalierungsfaktor erzeugen:
```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erzeugen Sie ein Bild in voller Auflösung
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Speichern Sie das Bild im PNG-Format auf der Festplatte
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Miniaturansicht der Form basierend auf Grenzwerten des Aussehens erstellen**
Diese Methode zum Erstellen von Miniaturansichten von Formen ermöglicht es Entwicklern, eine Miniaturansicht innerhalb der Grenzen des Aussehens der Form zu erzeugen. Dabei werden alle Formeffekte berücksichtigt. Die erzeugte Form‑Miniaturansicht ist durch die Foliengrenzen eingeschränkt. Um eine Miniaturansicht einer Folienform innerhalb ihrer Erscheinungsgrenzen zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Rufen Sie die Referenz einer beliebigen Folie über deren ID oder Index ab.
1. Abrufen des Miniaturbildes der referenzierten Folie mit Formgrenzen als Aussehen.
1. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode basiert auf den obigen Schritten:
```java
// Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erzeugen Sie ein Bild in voller Auflösung
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Speichern Sie das Bild im PNG-Format auf der Festplatte
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Miniaturansichten verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/), und andere. Formen können auch [als Vektor‑SVG exportiert](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) werden, indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Grenzen beim Rendern einer Miniaturansicht?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/java/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als ausgeblendet markiert ist? Wird sie weiterhin als Miniaturansicht gerendert?**

Eine ausgeblendete Form bleibt Teil des Modells und kann gerendert werden; das ausgeblendete Flag beeinflusst die Anzeige der Präsentation, hindert jedoch nicht daran, das Bild der Form zu erzeugen.

**Werden Gruppenformen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) und [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)), kann als Miniaturansicht oder als SVG gespeichert werden.

**Beeinflussen systeminstallierte Schriftarten die Qualität von Miniaturansichten für Textformen?**

Ja. Sie sollten [die erforderlichen Schriftarten bereitstellen](/slides/de/java/custom-font/) (oder [Schriftart‑Substitutionen konfigurieren](/slides/de/java/font-substitution/)), um unerwünschte Ersatzschriften und Textumbrüche zu vermeiden.