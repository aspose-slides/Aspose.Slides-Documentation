---
title: Folie konvertieren
type: docs
weight: 35
url: /java/convert-slide/
keywords: 
- Folie in Bild konvertieren
- Folie als Bild exportieren
- Folie als Bild speichern
- Folie in Bild
- Folie in PNG
- Folie in JPEG
- Folie in Bitmap
- Java
- Aspose.Slides für Java
description: "Konvertieren von PowerPoint-Folien in Bilder (Bitmap, PNG oder JPG) in Java"
---

Aspose.Slides für Java ermöglicht es Ihnen, Folien (in Präsentationen) in Bilder zu konvertieren. Dies sind die unterstützten Bildformate: BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie folgendermaßen vor:

1. Zuerst setzen Sie die Konvertierungsparameter und die Folienobjekte, die Sie konvertieren möchten, mit:
   * der [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) Schnittstelle oder
   * der [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions) Schnittstelle.

2. Zweitens konvertieren Sie die Folie in ein Bild, indem Sie die Methode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) verwenden.

## **Über Bitmap und andere Bildformate**

In Java ist ein [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images) ein Objekt, das es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten (JPG, PNG usw.) zu speichern.

{{% alert title="Info" color="info" %}}

Aspose hat kürzlich einen Online-Converter für [Text zu GIF](https://products.aspose.app/slides/text-to-gif) entwickelt.

{{% /alert %}}

## **Konvertieren von Folien in Bitmap und Speichern der Bilder im PNG-Format**

Dieser Java-Code zeigt Ihnen, wie Sie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertieren und das Bild dann im PNG-Format speichern:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Konvertiert die erste Folie in der Präsentation in ein Images-Objekt
    IImage slideImage = pres.getSlides().get_Item(0).getImage();

	// Speichert das Bild im PNG-Format
	try {
        // speichert das Bild auf der Festplatte.
         slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Dieser Beispielcode zeigt Ihnen, wie Sie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertieren, indem Sie die Methode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) verwenden:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// Holt die Größe der Präsentationsfolie
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// Erstellt ein Images mit der Foliengröße
    IImage slideImage = sld.getImage(new RenderingOptions(), slideSize);
    try {
         // speichert das Bild auf der Festplatte.
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Tipp" color="primary" %}} 

Sie können eine Folie in ein Images-Objekt konvertieren und das Objekt dann direkt irgendwo verwenden. Oder Sie können eine Folie in ein Images konvertieren und das Bild dann im JPEG- oder einem anderen Format Ihrer Wahl speichern.

{{% /alert %}}  

## **Konvertieren von Folien in Bilder mit benutzerdefinierten Größen**

Möglicherweise müssen Sie ein Bild einer bestimmten Größe erhalten. Mithilfe einer Überladung der Methode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) können Sie eine Folie in ein Bild mit bestimmten Abmessungen (Länge und Breite) konvertieren.

Dieser Beispielcode demonstriert die vorgeschlagene Konvertierung mit der Methode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) in Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Konvertiert die erste Folie in der Präsentation in ein Bitmap mit der angegebenen Größe
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1820, 1040));
	
	// Speichert das Bild im JPEG-Format
	try {
         // speichert das Bild auf der Festplatte.
          slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konvertieren von Folien mit Notizen und Kommentaren in Bilder**

Einige Folien enthalten Notizen und Kommentare.

Aspose.Slides bietet zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) und [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions)—die es Ihnen ermöglichen, das Rendern von Präsentationsfolien in Bilder zu steuern. Beide Schnittstellen beherbergen die [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) Schnittstelle, die es Ihnen ermöglicht, Notizen und Kommentare auf einer Folie hinzuzufügen, wenn Sie diese Folie in ein Bild konvertieren.

{{% alert title="Info" color="info" %}} 

Mit der [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) Schnittstelle können Sie Ihre bevorzugte Position für Notizen und Kommentare im resultierenden Bild angeben.

{{% /alert %}} 

Dieser Java-Code demonstriert den Konvertierungsprozess für eine Folie mit Notizen und Kommentaren:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // Erstellt die Rendering-Optionen
    IRenderingOptions options = new RenderingOptions();

    // Setzt die Position der Notizen auf der Seite
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // Setzt die Position der Kommentare auf der Seite 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // Setzt die Breite des Ausgabegebietes für Kommentare
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // Setzt die Farbe für das Kommentierungsgebiet
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // Konvertiert die erste Folie der Präsentation in ein Bitmap-Objekt
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, 2f, 2f);

    // Speichert das Bild im GIF-Format
    try {
          slideImage.save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Dieser Java-Code demonstriert den Konvertierungsprozess für eine Folie mit Notizen unter Verwendung der Methode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) :

``` java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// Holt die Größe der Präsentationsnotizen
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// Erstellt die Rendering-Optionen
	IRenderingOptions options = new RenderingOptions();

	// Setzt die Position der Notizen
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Erstellt ein Images mit der Größe der Notizen
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, notesSize);

	// Speichert das Bild im PNG-Format
    try {
         // speichert das Bild auf der Festplatte.
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 

In jedem Konvertierungsprozess von Folien zu Bildern kann die Eigenschaft [NotesPositions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) nicht auf BottomFull gesetzt werden (um die Position für Notizen anzugeben), da der Text einer Notiz groß sein kann, was bedeutet, dass er möglicherweise nicht in die angegebene Bildgröße passt.

{{% /alert %}} 

## **Konvertieren von Folien in Bilder mit ITiffOptions**

Die [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) Schnittstelle gibt Ihnen mehr Kontrolle (in Bezug auf Parameter) über das resultierende Bild. Mit dieser Schnittstelle können Sie die Größe, Auflösung, Farbpalette und andere Parameter für das resultierende Bild angeben.

Dieser Java-Code zeigt einen Konvertierungsprozess, bei dem ITiffOptions verwendet wird, um ein Schwarz-Weiß-Bild mit einer Auflösung von 300 dpi und der Größe 2160 × 2800 auszugeben:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// Holt eine Folie nach ihrem Index
	ISlide slide = pres.getSlides().get_Item(0);

	// Erstellt ein TiffOptions-Objekt
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// Setzt die Schriftart, die verwendet wird, falls die Quellschriftart nicht gefunden wird
	options.setDefaultRegularFont("Arial Black");

	// Setzt die Position der Notizen auf der Seite
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// Setzt das Pixel-Format (schwarz-weiß)
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// Setzt die Auflösung
	options.setDpiX(300);
	options.setDpiY(300);

	// Konvertiert die Folie in ein Bitmap-Objekt
	IImage slideImage = slide.getImage(options);

	// Speichert das Bild im TIFF-Format
	try {
          slideImage.save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 

Die TIFF-Unterstützung ist in Versionen vor JDK 9 nicht garantiert.

{{% /alert %}} 

## **Konvertieren aller Folien in Bilder**

Aspose.Slides ermöglicht es Ihnen, alle Folien in einer einzelnen Präsentation in Bilder zu konvertieren. Im Wesentlichen können Sie die Präsentation (in ihrer Gesamtheit) in Bilder konvertieren.

Dieser Beispielcode zeigt Ihnen, wie Sie alle Folien in einer Präsentation in Bilder in Java konvertieren:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Rendert die Präsentation folienweise in ein Array von Bildern
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // Steuert die versteckten Folien (versteckte Folien werden nicht gerendert)
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // Konvertiert die Folie in ein Bitmap-Objekt
        IImage slideImage = pres.getSlides().get_Item(i).getImage(2f, 2f);

        // Speichert das Bild im PNG-Format
        try {
              slideImage.save("Slide_" + i + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
} 
```