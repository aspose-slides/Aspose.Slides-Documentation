---
title: Erstellen von Form-Thumbnails
type: docs
weight: 70
url: /de/php-java/create-shape-thumbnails/
---


## **Übersicht**
{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java kann verwendet werden, um Präsentationsdateien zu erstellen, in denen jede Seite einem Slide entspricht. Die Slides können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Entwickler müssen jedoch manchmal die Bilder der Formen separat in einem Bildbetrachter anzeigen. In solchen Fällen hilft Aspose.Slides für PHP über Java, Thumbnail-Bilder der Slide-Formen zu generieren.

{{% /alert %}} 

In diesem Thema zeigen wir, wie man Slide-Thumbnails in verschiedenen Situationen generiert:

- Generierung eines Form-Thumbnails innerhalb eines Slides.
- Generierung eines Form-Thumbnails für eine Slide-Form mit benutzerdefinierten Dimensionen.
- Generierung eines Form-Thumbnails innerhalb der Grenzen des Erscheinungsbilds einer Form.

## **Generierung von Form-Thumbnails aus Slides**
Um ein Form-Thumbnail aus einem beliebigen Slide mit Aspose.Slides für PHP über Java zu generieren, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz eines beliebigen Slides anhand seiner ID oder seines Index.
1. [Holen Sie das Thumbnail-Bild der Form](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--) des referenzierten Slides im Standardmaßstab.
1. Speichern Sie das Thumbnail-Bild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Form-Thumbnail aus einem Slide generieren:

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstellen Sie ein Vollbildbild
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
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

## **Generierung von Form-Thumbnails mit benutzerdefiniertem Skalierungsfaktor**
Um das Form-Thumbnail eines Slides mit Aspose.Slides für PHP über Java zu generieren, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz eines beliebigen Slides anhand seiner ID oder seines Index.
1. [Holen Sie das Thumbnail-Bild der Form](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-) des referenzierten Slides mit benutzerdefinierten Dimensionen.
1. Speichern Sie das Thumbnail-Bild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Form-Thumbnail basierend auf einem definierten Skalierungsfaktor generieren:

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstellen Sie ein Vollbildbild
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
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

## **Generierung des Formen-Thumbnails der Grenzen**
Dieses Verfahren zur Erstellung von Thumbnails von Formen ermöglicht es Entwicklern, ein Thumbnail innerhalb der Grenzen des Erscheinungsbilds der Form zu generieren. Es berücksichtigt alle Formeffekte. Das generierte Form-Thumbnail wird durch die Blenden des Slides eingeschränkt. Um ein Thumbnail einer Slide-Form innerhalb der Grenzen ihres Erscheinungsbilds zu generieren, tun Sie Folgendes:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz eines beliebigen Slides anhand seiner ID oder seines Index.
1. Holen Sie das Thumbnail-Bild des referenzierten Slides mit den Formen-Grenzen als Erscheinungsbild.
1. Speichern Sie das Thumbnail-Bild in Ihrem bevorzugten Bildformat.

Dieser Beispielcode basiert auf den obigen Schritten:

```php
  # Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Erstellen Sie ein Vollbildbild
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Speichern Sie das Bild auf der Festplatte im PNG-Format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
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