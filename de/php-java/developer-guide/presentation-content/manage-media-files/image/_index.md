---
title: Bild
type: docs
weight: 10
url: /de/php-java/image/
description: Arbeiten Sie mit Bildern in Folien in PowerPoint-Präsentationen unter Verwendung von PHP. Fügen Sie Bilder von der Festplatte oder aus dem Internet in PowerPoint-Folien mit PHP hinzu. Fügen Sie Bilder zu Folienmaster oder als Folienhintergrund mit PHP hinzu. Fügen Sie SVG zu PowerPoint-Präsentationen mit PHP hinzu. Konvertieren Sie SVG in Formen in PowerPoint mit PHP. Fügen Sie Bilder als EMF in Folien mit PHP hinzu.
---

## **Bilder in Folien in Präsentationen**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Orten in Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien in Ihren Präsentationen durch verschiedene Verfahren.

{{% alert  title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—mit denen Benutzer schnell Präsentationen aus Bildern erstellen können.

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten—insbesondere wenn Sie planen, standardmäßige Formatierungsoptionen zu verwenden, um die Größe zu ändern, Effekte hinzuzufügen usw.—sehen Sie sich [Bildrahmen](https://docs.aspose.com/slides/php-java/picture-frame/) an.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}

Sie können Ein- und Ausgabeoperationen, die Bilder und PowerPoint-Präsentationen betreffen, manipulieren, um ein Bild von einem Format in ein anderes zu konvertieren. Siehe diese Seiten: konvertieren [Bild zu JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), konvertieren [PNG zu JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), konvertieren [SVG zu PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Operationen mit Bildern in diesen gängigen Formaten: JPEG, PNG, GIF und anderen.

## **Hinzufügen von lokal gespeicherten Bildern zu Folien**

Sie können ein oder mehrere Bilder auf Ihrem Computer in eine Folie in einer Präsentation einfügen. Dieser Beispielcode zeigt Ihnen, wie Sie ein Bild in eine Folie hinzufügen:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hinzufügen von Bildern aus dem Web zu Folien**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, auf Ihrem Computer nicht verfügbar ist, können Sie das Bild direkt aus dem Internet hinzufügen.

Dieser Beispielcode zeigt Ihnen, wie Sie ein Bild aus dem Internet zu einer Folie hinzufügen:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[ERSETZEN MIT URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hinzufügen von Bildern zu Folienmastern**

Ein Folienmaster ist die oberste Folie, die Informationen (Design, Layout usw.) über alle Folien darunter speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie unter diesem Folienmaster.

Dieser Java-Beispielcode zeigt Ihnen, wie Sie ein Bild zu einem Folienmaster hinzufügen:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hinzufügen von Bildern als Folienhintergrund**

Sie können entscheiden, ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien zu verwenden. In diesem Fall müssen Sie *[Bilder als Hintergründe für Folien festlegen](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)* ansehen.

## **Hinzufügen von SVG zu Präsentationen**
Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) verwenden, die zur Schnittstelle [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) gehört.

Um ein Bildobjekt basierend auf einem SVG-Bild zu erstellen, können Sie es so tun:

1. Erstellen Sie ein SvgImage-Objekt, um es in die ImageShapeCollection einzufügen
2. Erstellen Sie ein PPImage-Objekt aus ISvgImage
3. Erstellen Sie ein PictureFrame-Objekt mithilfe der IPPImage-Schnittstelle

Dieser Beispielcode zeigt Ihnen, wie Sie die obigen Schritte implementieren, um ein SVG-Bild in eine Präsentation hinzuzufügen:
```php
  # Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Konvertieren von SVG in eine Gruppe von Formen**
Die Konvertierung von SVG in eine Gruppe von Formen von Aspose.Slides ist ähnlich wie die PowerPoint-Funktionalität, die verwendet wird, um mit SVG-Bildern zu arbeiten:

![PowerPoint Popup-Menü](img_01_01.png)

Die Funktionalität wird von einer der Überladungen der Methode [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) der Schnittstelle [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage)-Objekt als erstes Argument nimmt.

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Methode verwenden, um eine SVG-Datei in eine Gruppe von Formen zu konvertieren:

```php
  # Erstellen Sie eine neue Präsentation
  $presentation = new Presentation();
  try {
    # Lesen Sie den Inhalt der SVG-Datei
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Erstellen Sie ein SvgImage-Objekt
    $svgImage = new SvgImage($svgContent);
    # Holen Sie sich die Foliengröße
    $slideSize = $presentation->getSlideSize()->getSize();
    # Konvertieren Sie das SVG-Bild in eine Gruppe von Formen, indem Sie es an die Foliengröße anpassen
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Speichern Sie die Präsentation im PPTX-Format
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Hinzufügen von Bildern als EMF in Folien**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, EMF-Bilder aus Excel-Blättern zu generieren und die Bilder als EMF in Folien mit Aspose.Cells hinzuzufügen. 

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Aufgabe ausführen:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Speichern Sie die Arbeitsmappe im Stream
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Seite" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}

Mit dem kostenlosen Aspose [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter können Sie Texte einfach animieren, GIFs aus Texten erstellen usw. 

{{% /alert %}}