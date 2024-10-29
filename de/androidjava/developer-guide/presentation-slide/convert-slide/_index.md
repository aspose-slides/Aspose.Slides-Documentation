---
title: Folie konvertieren
type: docs
weight: 35
url: /de/androidjava/convert-slide/
keywords: 
- Folie in Bild umwandeln
- Folie als Bild exportieren
- Folie als Bild speichern
- Folie in Bild
- Folie in PNG
- Folie in JPEG
- Folie in bitmap
- Java
- Aspose.Slides für Android über Java
description: "Konvertieren Sie eine PowerPoint-Folie in ein Bild (Bitmap, PNG oder JPG) in Java"
---

Aspose.Slides für Android über Java ermöglicht es Ihnen, Folien (in Präsentationen) in Bilder zu konvertieren. Die unterstützten Bildformate sind: BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor: 

1. Zuerst legen Sie die Konvertierungsparameter und die Folienobjekte fest, die konvertiert werden sollen, indem Sie:
   * das [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions) Interface oder
   * das [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions) Interface verwenden.

2. Zweitens konvertieren Sie die Folie in ein Bild, indem Sie die [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) Methode verwenden.

## **Über Bitmap und andere Bildformate**

In Java ist ein [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images) ein Objekt, das es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten (JPG, PNG usw.) zu speichern.

{{% alert title="Info" color="info" %}}

Aspose hat kürzlich einen Online [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter entwickelt. 

{{% /alert %}}

## **Konvertieren von Folien zu Bitmap und Speichern der Bilder im PNG-Format**

Dieser Java-Code zeigt Ihnen, wie Sie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertieren und das Bild dann im PNG-Format speichern:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Konvertiert die erste Folie in der Präsentation in ein Images-Objekt
    IImage slideImage = pres.getSlides().get_Item(0).getImage();

	// Speichert das Bild im PNG-Format
	try {
        // Speichern Sie das Bild auf der Festplatte.
         slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Dieser Beispielcode zeigt Ihnen, wie Sie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertieren, indem Sie die [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) Methode verwenden:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// Holt die Präsentationsfoliogröße
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// Erstellt ein Images mit der Foliengröße
    IImage slideImage = sld.getImage(new RenderingOptions(), slideSize);
    try {
         // Speichern Sie das Bild auf der Festplatte.
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

## **Konvertieren von Folien zu Bildern mit benutzerdefinierten Größen**

Sie müssen möglicherweise ein Bild einer bestimmten Größe erhalten. Mithilfe einer Überladung der [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) Methode können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Länge und Breite) konvertieren.

Dieser Beispielcode demonstriert die vorgeschlagene Konvertierung mithilfe der [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) Methode in Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Konvertiert die erste Folie in der Präsentation in ein Bitmap mit der angegebenen Größe
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1820, 1040));
	
	// Speichert das Bild im JPEG-Format
	try {
         // Speichern Sie das Bild auf der Festplatte.
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

Aspose.Slides bietet zwei Interfaces—[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions) und [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions)—die es Ihnen ermöglichen, das Rendern von Präsentationsfolien in Bilder zu steuern. Beide Interfaces enthalten das [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) Interface, das es Ihnen ermöglicht, Notizen und Kommentare auf einer Folie hinzuzufügen, wenn Sie diese Folie in ein Bild konvertieren.

{{% alert title="Info" color="info" %}} 

Mit dem [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) Interface können Sie Ihre bevorzugte Position für Notizen und Kommentare im resultierenden Bild angeben.

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

    // Setzt die Breite des Ausgabegebiets für die Kommentare
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // Setzt die Farbe für das Kommentarfeld
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

Dieser Java-Code demonstriert den Konvertierungsprozess für eine Folie mit Notizen, indem er die [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) Methode verwendet:

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
         // Speichern Sie das Bild auf der Festplatte.
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 

In jedem Prozess der Konvertierung von Folien zu Bildern kann die [NotesPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) Eigenschaft nicht auf BottomFull gesetzt werden (um die Position für Notizen anzugeben), da der Text einer Notiz groß sein kann, was bedeutet, dass er möglicherweise nicht in die angegebene Bildgröße passt.

{{% /alert %}} 

## **Konvertieren von Folien zu Bildern mit ITiffOptions**

Das [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions) Interface gibt Ihnen mehr Kontrolle (in Bezug auf Parameter) über das resultierende Bild. Mithilfe dieses Interfaces können Sie die Größe, Auflösung, Farbpalette und andere Parameter für das resultierende Bild angeben.

Dieser Java-Code demonstriert einen Konvertierungsprozess, bei dem ITiffOptions verwendet wird, um ein Schwarzweißbild mit einer Auflösung von 300 dpi und einer Größe von 2160 × 2800 auszugeben:

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

	// Setzt das Pixel-Format (Schwarzweiß)
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

Die Unterstützung für Tiff ist in Versionen vor JDK 9 nicht garantiert.

{{% /alert %}} 

## **Konvertieren aller Folien in Bilder**

Aspose.Slides ermöglicht es Ihnen, alle Folien in einer einzelnen Präsentation in Bilder zu konvertieren. Im Wesentlichen können Sie die gesamte Präsentation in Bilder konvertieren. 

Dieser Beispielcode zeigt Ihnen, wie Sie alle Folien in einer Präsentation in Bilder in Java konvertieren:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Präsentation folienweise in ein Bilderarray rendern
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // Versteckte Folien steuern (versteckte Folien nicht rendern)
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