---
title: OLE in Präsentationen mit PHP verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/php-java/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung & Einbettung
- OLE hinzufügen
- OLE einbetten
- Objekt hinzufügen
- Objekt einbetten
- Datei hinzufügen
- Datei einbetten
- verknüpftes Objekt
- verknüpfte Datei
- OLE ändern
- OLE-Symbol
- OLE-Titel
- OLE extrahieren
- Objekt extrahieren
- Datei extrahieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für PHP via Java. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren Sie sie und exportieren Sie sie."
---
## **Einleitung**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird anschließend in eine PowerPoint‑Folie eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird beim Doppelklick auf das Symbol das Diagramm in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen.
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen, und Sie können die Diagrammdaten innerhalb von PowerPoint ändern.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **OLE‑Objektrahmen zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mithilfe von Aspose.Slides for PHP via Java als OLE‑Objektrahmen in eine Folie einbetten, dann können Sie dies wie folgt tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich über den Index einen Verweis auf die Folie.
1. Lesen Sie die Excel‑Datei als Byte‑Array ein.
1. Fügen Sie den [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) der Folie hinzu und übergeben Sie das Byte‑Array sowie weitere Informationen zum OLE‑Objekt.
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als OLE‑Objektrahmen in eine Folie eingefügt, wobei Aspose.Slides for PHP via Java verwendet wurde.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) akzeptiert eine einbettbare Objekt‑Erweiterung als zweiten Parameter. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Verknüpfte OLE‑Objektrahmen hinzufügen**

Aspose.Slides for PHP via Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) ohne Einbetten von Daten, sondern nur mit einem Link zur Datei.

Der folgende PHP‑Code zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) mit einer verknüpften Excel‑Datei zu einer Folie hinzugefügt wird:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Füge einen OLE-Objektrahmen mit einer verknüpften Excel-Datei hinzu.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE‑Objektrahmen zugreifen**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf folgende Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse erstellen.
2. Holen Sie sich über den Index einen Verweis auf die Folie.
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Form. In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die nur eine Form auf der ersten Folie enthält.
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Operationen darauf ausführen.

Im folgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) und dessen Dateidaten abgerufen.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Hole die eingebetteten Dateidaten.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Hole die Dateierweiterung der eingebetteten Datei.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Eigenschaften verknüpfter OLE‑Objektrahmen lesen**

Aspose.Slides ermöglicht das Auslesen von Eigenschaften verknüpfter OLE‑Objektrahmen.

Der folgende PHP‑Code zeigt, wie Sie prüfen, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermitteln:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Prüfen, ob das OLE-Objekt verknüpft ist.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Gib den vollständigen Pfad zur verknüpften Datei aus.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Gib den relativen Pfad zur verknüpften Datei aus, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLE‑Objektdaten ändern**

{{% alert color="info" title="Note" %}}

In diesem Abschnitt verwendet das nachfolgende Code‑Beispiel [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie das Objekt auf folgende Weise leicht zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse erstellen.
2. Holen Sie sich über den Index einen Verweis auf die Folie. 
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die eine Form auf der ersten Folie enthält.
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Operationen darauf ausführen.
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im folgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten werden geändert, um die Diagrammdaten zu aktualisieren.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Lese die OLE-Objektdaten als Workbook-Objekt.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Ändere die Workbook-Daten.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Ändere die OLE-Objektrahmen-Daten.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for PHP via Java das Einbetten anderer Dateitypen in Folien. Beispielsweise können HTML‑, PDF‑ und ZIP‑Dateien als Objekte eingefügt werden. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im zugehörigen Programm geöffnet, bzw. der Benutzer wird aufgefordert, ein geeignetes Programm auszuwählen.

Der folgende PHP‑Code zeigt, wie HTML‑ und ZIP‑Dateien in eine Folie eingebettet werden:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Dateitypen für eingebettete Objekte festlegen**

Beim Arbeiten mit Präsentationen müssen Sie möglicherweise alte OLE‑Objekte durch neue ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes austauschen. Aspose.Slides for PHP via Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Rahmendaten oder deren Erweiterung aktualisieren können.

Der folgende PHP‑Code zeigt, wie Sie den Dateityp für ein eingebettetes OLE‑Objekt auf `zip` setzen:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Ändere den Dateityp zu ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau mit einem Symbolbild hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Wenn Sie ein bestimmtes Bild und einen bestimmten Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for PHP via Java festlegen.

Der folgende PHP‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Füge ein Bild zu den Präsentationsressourcen hinzu.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Setze einen Titel und das Bild für die OLE-Vorschau.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Verhindern, dass ein OLE‑Objektrahmen in Größe und Position verändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Durch Klick auf „Update Links“ kann die Größe und Position des OLE‑Objektrahmens geändert werden, weil PowerPoint die Daten aus dem verknüpften OLE‑Objekt aktualisiert und die Vorschau neu erstellt. Um zu verhindern, dass PowerPoint zum Aktualisieren der Objektdaten auffordert, rufen Sie die Methode [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) der Klasse [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) mit `false` auf:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides for PHP via Java ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse, die die OLE‑Objekte enthält, die Sie extrahieren möchten.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Formen zu.
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Objektrahmen zu und schreiben Sie sie auf die Festplatte.

Der folgende PHP‑Code zeigt, wie Sie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahieren:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**

Was auf der Folie sichtbar ist, wird gerendert – das Symbol/Ersatzbild (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschaubild festlegen, um das erwartete Aussehen im exportierten PDF sicherzustellen.

Um die eingebettete Datei zudem als PDF‑Anhang zu erhalten, rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) mit `true` auf. Diese Option ist standardmäßig deaktiviert. Ein Beispiel und Anleitungen zum Prüfen des Anhangs finden Sie unter [Preserve Embedded OLE Files as PDF Attachments](/slides/de/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet Formen‑Sperren auf Ebene der Form. Das ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Bewegungen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

In PPTX sind Informationen zu „relativen Pfaden“ nicht verfügbar – nur der vollständige Pfad wird gespeichert. Relative Pfade kommen im älteren PPT‑Format vor. Für Portabilität sollten Sie zuverlässige absolute Pfade/erreichbare URIs oder das Einbetten bevorzugen.