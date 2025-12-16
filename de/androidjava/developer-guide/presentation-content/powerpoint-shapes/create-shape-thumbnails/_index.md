---
title: Erstelle Miniaturbilder von Präsentationsformen auf Android
linktitle: Form-Miniaturbilder
type: docs
weight: 70
url: /de/androidjava/create-shape-thumbnails/
keywords:
- Form-Miniaturbild
- Formbild
- Form rendern
- Formdarstellung
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Generieren Sie hochwertige Miniaturbilder von Formen aus PowerPoint-Folien mit Aspose.Slides für Android via Java – einfach Präsentations-Miniaturbilder erstellen und exportieren."
---

## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java kann verwendet werden, um Präsentationsdateien zu erstellen, bei denen jede Seite einer Folie entspricht. Die Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter anzeigen. In solchen Fällen hilft Aspose.Slides for Android via Java, Miniaturbilder der Folienformen zu generieren.

{{% /alert %}} 

In diesem Thema zeigen wir, wie man Folien‑Miniaturbilder in verschiedenen Situationen erzeugt:

- Miniaturbild einer Form innerhalb einer Folie generieren.
- Miniaturbild einer Folienform mit benutzerdefinierten Abmessungen generieren.
- Miniaturbild innerhalb der Grenzen der Formanzeige generieren.

## **Formvorschau aus einer Folie erzeugen**
Um aus einer beliebigen Folie mit Aspose.Slides for Android via Java eine Formvorschau zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Holen Sie die Referenz einer beliebigen Folie über deren ID oder Index.
1. [Rufen Sie das Form‑Miniaturbild ab](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) der referenzierten Folie in der Standardskalierung.
1. Speichern Sie das Miniaturbild im von Ihnen bevorzugten Bildformat.

Dieser Beispielcode zeigt, wie man eine Formvorschau aus einer Folie erzeugt:
```java
// Instanziiere eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstelle ein Bild in voller Größe
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Speichere das Bild im PNG-Format auf die Festplatte
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Miniaturbild mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um das Form‑Miniaturbild einer Folie mit Aspose.Slides for Android via Java zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Holen Sie die Referenz einer beliebigen Folie über deren ID oder Index.
1. [Rufen Sie das Form‑Miniaturbild ab](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) der referenzierten Folie mit benutzerdefinierten Abmessungen.
1. Speichern Sie das Miniaturbild im von Ihnen bevorzugten Bildformat.

Dieser Beispielcode zeigt, wie man ein Form‑Miniaturbild basierend auf einem definierten Skalierungsfaktor erzeugt:
```java
// Instanziiere eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstelle ein Bild in voller Größe
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Speichere das Bild im PNG-Format auf die Festplatte
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Miniaturbild basierend auf Formen‑Anzeige‑Grenzen erstellen**
Diese Methode zum Erzeugen von Miniaturbildern von Formen ermöglicht Entwicklern, ein Miniaturbild innerhalb der Grenzen der Formanzeige zu generieren. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Formen‑Miniaturbild ist durch die Folien‑Grenzen beschränkt. Um ein Miniaturbild einer Folienform innerhalb ihrer Anzeige‑Grenzen zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Holen Sie die Referenz einer beliebigen Folie über deren ID oder Index.
1. Rufen Sie das Miniaturbild der referenzierten Folie mit Formgrenzen als Anzeige ab.
1. Speichern Sie das Miniaturbild im von Ihnen bevorzugten Bildformat.

Dieser Beispielcode basiert auf den oben genannten Schritten:
```java
// Instanziiere eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Erstelle ein Bild in voller Größe
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Speichere das Bild im PNG-Format auf die Festplatte
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

**Welche Bildformate können beim Speichern von Formvorschauen verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/), und andere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Grenzen beim Rendern einer Vorschau?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/androidjava/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als verborgen markiert ist? Wird sie trotzdem als Miniaturbild gerendert?**

Eine versteckte Form bleibt Teil des Modells und kann gerendert werden; das versteckte Flag beeinflusst die Anzeige der Diashow, verhindert jedoch nicht die Erzeugung des Formbildes.

**Werden Gruppierungen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jedes Objekt, das als [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/), und [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)), kann als Miniaturbild oder als SVG gespeichert werden.

**Beeinflussen systeminstallierte Schriften die Qualität von Miniaturbildern für Textformen?**

Ja. Sie sollten die erforderlichen Schriften [bereitstellen](/slides/de/androidjava/custom-font/) (oder [Schriftart‑Ersetzungen konfigurieren](/slides/de/androidjava/font-substitution/)), um unerwünschte Fallbacks und Text‑Umbrüche zu vermeiden.