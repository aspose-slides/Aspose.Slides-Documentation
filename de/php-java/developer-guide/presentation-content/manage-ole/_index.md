---
title: OLE verwalten
type: docs
weight: 40
url: /php-java/manage-ole/
keywords:
- OLE hinzufügen
- OLE einbetten
- ein Objekt hinzufügen
- ein Objekt einbetten
- eine Datei einbetten
- verknüpftes Objekt
- Objektverknüpfung und -einbettung
- OLE-Objekt
- PowerPoint 
- Präsentation
- PHP
- Java
- Aspose.Slides für PHP über Java
description: Fügen Sie OLE-Objekte in PowerPoint-Präsentationen mit PHP hinzu
---

{{% alert color="primary" %}} 

OLE (Objektverknüpfung und -einbettung) ist eine Microsoft-Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, durch Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren.

{{% /alert %}} 

Betrachten Sie ein in MS Excel erstelltes Diagramm. Das Diagramm wird dann in eine PowerPoint-Folie eingefügt. Dieses Excel-Diagramm wird als OLE-Objekt betrachtet.

- Ein OLE-Objekt kann als Symbol erscheinen. In diesem Fall wird das Diagramm beim Doppelklicken auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen.
- Ein OLE-Objekt kann die tatsächlichen Inhalte anzeigen, z. B. die Inhalte eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammoberfläche lädt, und Sie können die Daten des Diagramms innerhalb der PowerPoint-App ändern.

[Aspose.Slides für PHP über Java](https://products.aspose.com/slides/php-java/) ermöglicht es Ihnen, OLE-Objekte als OLE-Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)) in Folien einzufügen.

## **Hinzufügen von OLE-Objektrahmen zu Folien**
Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten dieses Diagramm als OLE-Objektrahmen in eine Folie mit Aspose.Slides für PHP über Java einbetten, können Sie dies folgendermaßen tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Holen Sie die Referenz der Folie, indem Sie ihren Index verwenden.
1. Öffnen Sie die Excel-Datei mit dem Excel-Diagrammobjekt und speichern Sie sie in `MemoryStream`.
1. Fügen Sie den [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame) zur Folie hinzu, indem Sie das Byte-Array und weitere Informationen über das OLE-Objekt übergeben.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel-Datei als OLE-Objektrahmen in eine Folie mit Aspose.Slides für PHP über Java eingefügt.
**Hinweis:** Der [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IOleEmbeddedDataInfo) Konstruktor benötigt als zweiten Parameter eine einbettbare Objektdateiendung. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE-Objekts auszuwählen.

```php
  # Instanziiert die Präsentation-Klasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Lädt eine Excel-Datei in den Stream
    $fs = new Java("java.io.FileInputStream", "book1.xlsx");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $mstream = new Java("java.io.ByteArrayOutputStream");
    $buf = $Array->newInstance($Byte, 4096);
    while (true) {
      $bytesRead = $fs->read($buf, 0, $Array->getLength($buf));
      if ($bytesRead <= 0) {
        break;
      }
      $mstream->write($buf, 0, $bytesRead);
    } 
    $fs->close();
    # Erstellt ein Datenobjekt zum Einbetten
    $dataInfo = new OleEmbeddedDataInfo($mstream->toByteArray(), "xlsx");
    $mstream->close();
    # Fügt eine Ole Object Frame-Form hinzu
    $oleObjectFrame = $sld->getShapes()->addOleObjectFrame(0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $dataInfo);
    # Schreibt die PPTX-Datei auf die Festplatte
    $pres->save("OleEmbed_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zugriff auf OLE-Objektrahmen**
Wenn ein OLE-Objekt bereits in eine Folie eingebettet ist, können Sie dieses Objekt ganz einfach auf folgende Weise finden oder darauf zugreifen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Holen Sie die Referenz der Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die OLE-Objektrahmenform zu.

   In unserem Beispiel verwendeten wir die zuvor erstellte PPTX, die nur eine Form auf der ersten Folie hat. Wir haben dann dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame) "gecastet". Dies war der gewünschte OLE-Objektrahmen, auf den zugegriffen werden sollte.
1. Sobald der OLE-Objektrahmen zugegriffen wurde, können Sie beliebige Operationen darauf ausführen.

Im folgenden Beispiel wird ein OLE-Objektrahmen (ein in eine Folie eingebettetes Excel-Diagrammobjekt) zugegriffen – und dann werden die Datei-Daten in eine Excel-Datei geschrieben.

```php
  # Lädt die PPTX in ein Präsentationsobjekt
  $pres = new Presentation("AccessingOLEObjectFrame.pptx");
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Castet die Form zu OleObjectFrame
    $oleObjectFrame = $sld->getShapes()->get_Item(0);
    # Liest das OLE-Objekt und schreibt es auf die Festplatte
    if (!java_is_null($oleObjectFrame)) {
      # Holt die eingebetteten Dateidaten
      $data = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileData();
      # Holt die eingebettete Dateiendung
      $fileExtention = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension();
      # Erstellt einen Pfad, um die extrahierte Datei zu speichern
      $extractedPath = "excelFromOLE_out" . $fileExtention;
      # Speichert die extrahierten Daten
      $fstr = new Java("java.io.FileOutputStream", $extractedPath);
      $Array = new java_class("java.lang.reflect.Array");
      try {
        $fstr->write($data, 0, $Array->getLength($data));
      } finally {
        $fstr->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändern von OLE-Objektdaten**

Wenn ein OLE-Objekt bereits in eine Folie eingebettet ist, können Sie einfach auf dieses Objekt zugreifen und seine Daten auf folgende Weise ändern:

1. Öffnen Sie die gewünschte Präsentation mit dem eingebetteten OLE-Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse erstellen.
1. Holen Sie die Referenz der Folie durch ihren Index. 
1. Greifen Sie auf die OLE-Objektrahmenform zu.

   In unserem Beispiel verwendeten wir die zuvor erstellte PPTX, die nur eine Form auf der ersten Folie hat. Wir haben dann dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame) "gecastet". Dies war der gewünschte OLE-Objektrahmen, auf den zugegriffen werden sollte.
1. Sobald der OLE-Objektrahmen zugegriffen wurde, können Sie beliebige Operationen darauf ausführen.
1. Erstellen Sie das Workbook-Objekt und greifen Sie auf die OLE-Daten zu.
1. Greifen Sie auf das gewünschte Arbeitsblatt zu und ändern Sie die Daten.
1. Speichern Sie das aktualisierte Workbook in Streams.
1. Ändern Sie die OLE-Objektdaten von den Stream-Daten.

Im folgenden Beispiel wird ein OLE-Objektrahmen (ein in eine Folie eingebettetes Excel-Diagrammobjekt) zugegriffen – und dann werden die Datei-Daten geändert, um die Diagrammdaten zu ändern:

```php
  $pres = new Presentation("ChangeOLEObjectData.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $ole = null;
    # Durchläuft alle Formen nach Ole-Rahmen
    foreach($slide->getShapes() as $shape) {
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $ole = $shape;
      }
    }
    if (!java_is_null($ole)) {
      $msln = new ByteArrayInputStream($ole->getEmbeddedData()->getEmbeddedFileData());
      try {
        # Liest die Objektdaten im Workbook
        $Wb = new Workbook($msln);
        $msout = new Java("java.io.ByteArrayOutputStream");
        try {
          # Ändert die Workbook-Daten
          $Wb->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
          $Wb->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
          $Wb->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
          $Wb->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);
          $so1 = new OoxmlSaveOptions(SaveFormat::XLSX);
          $Wb->save($msout, $so1);
          # Ändert die Ole-Rahmen-Objektdaten
          $newData = new OleEmbeddedDataInfo($msout->toByteArray(), $ole->getEmbeddedData()->getEmbeddedFileExtension());
          $ole->setEmbeddedData($newData);
        } finally {
          if (!java_is_null($msout)) {
            $msout->close();
          }
        }
      } finally {
        if (!java_is_null($msln)) {
          $msln->close();
        }
      }
    }
    $pres->save("OleEdit_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Weitere Dateitypen in Folien einbetten

Neben Excel-Diagrammen ermöglicht Aspose.Slides für PHP über Java auch das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML-, PDF- und ZIP-Dateien als Objekte in eine Folie einfügen. Wenn ein Benutzer auf das eingefügte Objekt doppelklickt, wird das Objekt automatisch im relevanten Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm auszuwählen, um das Objekt zu öffnen.

Dieser PHP-Code zeigt, wie Sie HTML und ZIP in eine Folie einbetten:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.html"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $htmlBytes = $bytes;

    $dataInfoHtml = new OleEmbeddedDataInfo($htmlBytes, "html");
    $oleFrameHtml = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $dataInfoHtml);
    $oleFrameHtml->setObjectIcon(true);
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $zipBytes = $bytes;

    $dataInfoZip = new OleEmbeddedDataInfo($zipBytes, "zip");
    $oleFrameZip = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $dataInfoZip);
    $oleFrameZip->setObjectIcon(true);
    $pres->save("embeddedOle.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Dateitypen für eingebettete Objekte festlegen

Bei der Arbeit an Präsentationen müssen Sie möglicherweise alte OLE-Objekte durch neue ersetzen. Oder Sie müssen ein nicht unterstütztes OLE-Objekt durch ein unterstütztes ersetzen.

Aspose.Slides für PHP über Java ermöglicht es Ihnen, den Dateityp für ein eingebettetes Objekt festzulegen. So können Sie die OLE-Rahmendaten oder deren Erweiterung ändern.

Dieser Java-Code zeigt Ihnen, wie Sie den Dateityp für ein eingebettetes OLE-Objekt festlegen:

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    echo("Die aktuelle eingebettete Datenendung ist: " . $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension());
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $oleObjectFrame->setEmbeddedData(new OleEmbeddedDataInfo($bytes, "zip"));

    $pres->save("embeddedChanged.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Festlegen von Symbolbildern und Titeln für eingebettete Objekte

Nachdem Sie ein OLE-Objekt eingebettet haben, wird automatisch eine Vorschau mit einem Symbolbild und einem Titel hinzugefügt. Die Vorschau ist das, was Benutzer sehen, bevor sie auf das OLE-Objekt zugreifen oder es öffnen.

Wenn Sie ein bestimmtes Bild und einen bestimmten Text als Elemente in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides für PHP über Java festlegen.

Dieser PHP-Code zeigt Ihnen, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    $oleImage;
    $image = Images->fromFile("image.png");
    try {
      $oleImage = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $oleObjectFrame->setSubstitutePictureTitle("Mein Titel");
    $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleObjectFrame->setObjectIcon(false);
    $pres->save("embeddedOle-newImage.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verhindern, dass ein OLE-Objektrahmen in der Größe geändert und repositioniert wird**

Nachdem Sie ein verknüpftes OLE-Objekt zu einer Präsentationsfolie hinzugefügt haben, sehen Sie möglicherweise eine Nachricht, die Sie auffordert, die Links zu aktualisieren, wenn Sie die Präsentation in PowerPoint öffnen. Wenn Sie auf die Schaltfläche "Links aktualisieren" klicken, kann sich die Größe und Position des OLE-Objektrahmens ändern, da PowerPoint die Daten des verknüpften OLE-Objekts aktualisiert und die Objektvorschau aktualisiert. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, setzen Sie die Methode `setUpdateAutomatic` der [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) Klasse auf `false`:

```php
$oleObjectFrame->setUpdateAutomatic(false);
```

## Extrahieren von eingebetteten Dateien

Aspose.Slides für PHP über Java ermöglicht es Ihnen, die in Folien als OLE-Objekte eingebetteten Dateien auf folgende Weise zu extrahieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse, die das OLE-Objekt enthält, das Sie extrahieren möchten.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe) Form zu.
3. Greifen Sie auf die Daten der eingebetteten Datei aus dem OLE-Objektrahmen zu und schreiben Sie sie auf die Festplatte.

Dieser PHP-Code zeigt Ihnen, wie Sie eine in eine Folie als OLE-Objekt eingebettete Datei extrahieren:

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($index = 0; $index < java_values($slide->getShapes()->size()) ; $index++) {
      $shape = $slide->getShapes()->get_Item($index);
      $oleFrame = $shape;
      if (!java_is_null($oleFrame)) {
        $data = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $extension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
        # Speichert die extrahierten Daten
        $fstr = new Java("java.io.FileOutputStream", "oleFrame" . $index . $extension);
        $Array = new java_class("java.lang.reflect.Array");
        try {
          $fstr->write($data, 0, $Array->getLength($data));
        } finally {
          $fstr->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```