---
title: Folie konvertieren
type: docs
weight: 35
url: /php-java/convert-slide/
keywords: 
- folie in bild konvertieren
- folie als bild exportieren
- folie als bild speichern
- folie zu bild
- folie zu PNG
- folie zu JPEG
- folie zu bitmap
- PHP
- Aspose.Slides für PHP über Java
description: "Konvertieren Sie eine PowerPoint-Folie in ein Bild (Bitmap, PNG oder JPG) in PHP"
---

Aspose.Slides für PHP über Java ermöglicht es Ihnen, Folien (in Präsentationen) in Bilder zu konvertieren. Dies sind die unterstützten Bildformate: BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, tun Sie Folgendes:

1. Zuerst legen Sie die Konvertierungsparameter und die Folienobjekte, die konvertiert werden sollen, fest, indem Sie:
   * das [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) Interface oder
   * das [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions) Interface verwenden.

2. Zweitens konvertieren Sie die Folie in ein Bild, indem Sie die [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) Methode verwenden.

## **Über Bitmap und andere Bildformate**

In Java ist ein [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) ein Objekt, das es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixel-Daten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten (JPG, PNG usw.) zu speichern.

{{% alert title="Info" color="info" %}}

Aspose hat kürzlich einen Online [Text to GIF](https://products.aspose.app/slides/text-to-gif) Konverter entwickelt.

{{% /alert %}}

## **Konvertieren von Folien in Bitmap und Speichern der Bilder im PNG-Format**

Dieser PHP-Code zeigt Ihnen, wie Sie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertieren und dann das Bild im PNG-Format speichern:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Konvertiert die erste Folie in der Präsentation in ein Images-Objekt
    $slideImage = $pres->getSlides()->get_Item(0)->getImage();
    # Speichert das Bild im PNG-Format
    try {
      # speichert das Bild auf der Festplatte.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieser Beispielcode zeigt Ihnen, wie Sie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertieren, indem Sie die [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) Methode verwenden:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Holt die Größe der Präsentationsfolie
    $slideSize = new Java("java.awt.Dimension", $slideSize->getWidth(), $slideSize->getHeight());
    # Erstellt ein Images mit der Foliengröße
    $slideImage = $sld->getImage(new RenderingOptions(), $slideSize);
    try {
      # speichert das Bild auf der Festplatte.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tipp" color="primary" %}} 

Sie können eine Folie in ein Images-Objekt konvertieren und das Objekt dann direkt irgendwo verwenden. Oder Sie können eine Folie in ein Images konvertieren und das Bild dann im JPEG- oder in einem anderen Format Ihrer Wahl speichern.

{{% /alert %}}  

## **Konvertieren von Folien in Bilder mit benutzerdefinierten Größen**

Vielleicht müssen Sie ein Bild einer bestimmten Größe erhalten. Mit einer Überladung der [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) Methode können Sie eine Folie in ein Bild mit bestimmten Abmessungen (Länge und Breite) konvertieren.

Dieser Beispielcode demonstriert die vorgeschlagene Konvertierung unter Verwendung der [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) Methode:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Konvertiert die erste Folie in der Präsentation in ein Bitmap mit der angegebenen Größe
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 1820, 1040));
    # Speichert das Bild im JPEG-Format
    try {
      # speichert das Bild auf der Festplatte.
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Konvertieren von Folien mit Notizen und Kommentaren zu Bildern**

Einige Folien enthalten Notizen und Kommentare.

Aspose.Slides bietet zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) und [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions)—die es Ihnen ermöglichen, das Rendering von Präsentationsfolien in Bilder zu steuern. Beide Schnittstellen verfügen über die [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) Schnittstelle, die es Ihnen ermöglicht, Notizen und Kommentare auf einer Folie hinzuzufügen, wenn Sie diese Folie in ein Bild konvertieren.

{{% alert title="Info" color="info" %}} 

Mit der [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) Schnittstelle können Sie Ihre bevorzugte Position für Notizen und Kommentare im resultierenden Bild angeben.

{{% /alert %}} 

Dieser PHP-Code demonstriert den Konvertierungsprozess für eine Folie mit Notizen und Kommentaren:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # Erstellt die Rendering-Optionen
    $options = new RenderingOptions();
    # Setzt die Position der Notizen auf der Seite
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Setzt die Position der Kommentare auf der Seite
    $options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);
    # Setzt die Breite des Kommentarausgabebereichs
    $options->getNotesCommentsLayouting()->setCommentsAreaWidth(500);
    # Setzt die Farbe für den Kommentarausgabebereich
    $options->getNotesCommentsLayouting()->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);
    # Konvertiert die erste Folie der Präsentation in ein Bitmap-Objekt
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, 2.0, 2.0);
    # Speichert das Bild im GIF-Format
    try {
      $slideImage->save("Slide_Notes_Comments_0.gif", ImageFormat::Gif);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieser PHP-Code demonstriert den Konvertierungsprozess für eine Folie mit Notizen unter Verwendung der [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) Methode:

```php
  $pres = new Presentation("PresentationNotes.pptx");
  try {
    # Holt die Größe der Präsentationsnotizen
    $notesSize = $pres->getNotesSize()->getSize();
    # Erstellt die Rendering-Optionen
    $options = new RenderingOptions();
    # Setzt die Position der Notizen
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Erstellt ein Images mit der Größe der Notizen
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, $notesSize);
    # Speichert das Bild im PNG-Format
    try {
      # speichert das Bild auf der Festplatte.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Hinweis" color="warning" %}} 

In jedem Konvertierungsprozess von Folien zu Bildern kann die [NotesPositions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) Eigenschaft nicht auf BottomFull gesetzt werden (um die Position für Notizen anzugeben), da der Text einer Notiz groß sein kann, was bedeutet, dass er möglicherweise nicht in die angegebene Bildgröße passt.

{{% /alert %}} 

## **Konvertieren von Folien zu Bildern unter Verwendung von ITiffOptions**

Die [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) Schnittstelle gibt Ihnen mehr Kontrolle (in Bezug auf Parameter) über das resultierende Bild. Mit dieser Schnittstelle können Sie die Größe, Auflösung, Farbpalette und andere Parameter für das resultierende Bild angeben.

Dieser PHP-Code demonstriert einen Konvertierungsprozess, bei dem ITiffOptions verwendet wird, um ein schwarz-weiß-Bild mit einer Auflösung von 300 dpi und einer Größe von 2160 × 2800 auszugeben:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # Holt eine Folie nach ihrem Index
    $slide = $pres->getSlides()->get_Item(0);
    # Erstellt ein TiffOptions-Objekt
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));
    # Setzt die Schriftart, die verwendet wird, falls die Quelldatei nicht gefunden wird
    $options->setDefaultRegularFont("Arial Black");
    # Setzt die Position der Notizen auf der Seite
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Setzt das Pixel-Format (schwarz-weiß)
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);
    # Setzt die Auflösung
    $options->setDpiX(300);
    $options->setDpiY(300);
    # Konvertiert die Folie in ein Bitmap-Objekt
    $slideImage = $slide->getImage($options);
    # Speichert das Bild im TIFF-Format
    try {
      $slideImage->save("PresentationNotesComments.tiff", ImageFormat::Tiff);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Hinweis" color="warning" %}} 

Die Unterstützung von Tiff ist in Versionen vor JDK 9 nicht garantiert.

{{% /alert %}} 

## **Konvertieren aller Folien in Bilder**

Aspose.Slides ermöglicht es Ihnen, alle Folien in einer einzelnen Präsentation in Bilder zu konvertieren. Im Wesentlichen können Sie die gesamte Präsentation in Bilder konvertieren.

Dieser Beispielcode zeigt Ihnen, wie Sie alle Folien in einer Präsentation in Bilder konvertieren:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Rendert die Präsentation in ein Bilder-Array, folie für folie
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      # Kontrolliert versteckte Folien (rendert keine versteckten Folien)
      if ($pres->getSlides()->get_Item($i)->getHidden()) {
        continue;
      }
      # Konvertiert die Folie in ein Bitmap-Objekt
      $slideImage = $pres->getSlides()->get_Item($i)->getImage(2.0, 2.0);
      # Speichert das Bild im PNG-Format
      try {
        $slideImage->save("Slide_" . $i . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```