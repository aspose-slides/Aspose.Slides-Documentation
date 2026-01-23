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
- Verknüpftes Objekt
- Verknüpfte Datei
- OLE ändern
- OLE‑Symbol
- OLE‑Titel
- OLE extrahieren
- Objekt extrahieren
- Datei extrahieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für PHP via Java. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren und exportieren Sie sie."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verlinkung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in eine PowerPoint‑Folie eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol erscheinen. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder es wird verlangt, eine Anwendung zum Öffnen bzw. Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern. 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)). 

## **OLE‑Objekt‑Frames zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es in einer Folie als OLE‑Objekt‑Frame einbetten, können Sie dies mit Aspose.Slides for PHP via Java folgendermaßen tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.  
1. Holen Sie sich über den Index einen Verweis auf die Folie.  
1. Lesen Sie die Excel‑Datei als Byte‑Array.  
1. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) zur Folie hinzu, wobei das Byte‑Array und weitere Informationen zum OLE‑Objekt übergeben werden.  
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.  

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei zu einer Folie als OLE‑Objekt‑Frame hinzugefügt, wobei Aspose.Slides for PHP via Java verwendet wurde.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) erwartet als zweiten Parameter die Erweiterung des einbettbaren Objekts. Diese Erweiterung erlaubt PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.  
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


### **Verknüpfte OLE‑Objekt‑Frames hinzufügen**

Aspose.Slides for PHP via Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) ohne Einbetten von Daten, sondern nur mit einem Link zur Datei.  

Dieser PHP‑Code zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) mit einer verknüpften Excel‑Datei zu einer Folie hinzugefügt wird:  
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Add an OLE object frame with a linked Excel file.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Zugriff auf OLE‑Objekt‑Frames**

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, lässt es sich folgendermaßen leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse erstellen.  
2. Holen Sie sich über den Index einen Verweis auf die Folie.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Form zu. In unserem Beispiel nutzten wir das zuvor erstellte PPTX, das nur eine Form auf der ersten Folie enthält.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  

Im nachfolgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) und dessen Dateidaten aufgerufen.  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Laden Sie die eingebetteten Dateidaten.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Laden Sie die Dateierweiterung der eingebetteten Datei.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **Eigenschaften verknüpfter OLE‑Objekt‑Frames abrufen**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objekt‑Frames.  

Der folgende PHP‑Code demonstriert, wie geprüft wird, ob ein OLE‑Objekt verknüpft ist, und wie anschließend der Pfad zur verknüpften Datei ermittelt wird:  
```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Prüfen, ob das OLE-Objekt verknüpft ist.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Gibt den vollständigen Pfad zur verknüpften Datei aus.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Gibt den relativen Pfad zur verknüpften Datei aus, falls vorhanden.
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

{{% alert color="primary" %}} 

In diesem Abschnitt verwendet das nachfolgende Code‑Beispiel [Aspose.Cells for PHP via Java](/cells/php-java/).  

{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, lässt es sich leicht zugreifen und seine Daten folgendermaßen ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse erstellen.  
2. Holen Sie sich über den Index einen Verweis auf die Folie.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Form zu. In unserem Beispiel nutzten wir das zuvor erstellte PPTX, das eine Form auf der ersten Folie enthält.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie das gewünschte `Worksheet` auf und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.  

Im nachfolgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) aufgerufen und dessen Dateidaten geändert, um die Diagrammdaten zu aktualisieren.  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // OLE‑Objektdaten als Workbook‑Objekt lesen.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Workbook‑Daten ändern.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // OLE‑Frame‑Objektdaten ändern.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for PHP via Java das Einbetten weiterer Dateitypen in Folien. Beispielsweise können HTML‑, PDF‑ und ZIP‑Dateien als Objekte eingefügt werden. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im zugehörigen Programm geöffnet bzw. der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.  

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

Beim Arbeiten mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu substituieren. Aspose.Slides for PHP via Java erlaubt das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder deren Erweiterung aktualisieren können.  

Der folgende PHP‑Code demonstriert, wie der Dateityp für ein eingebettetes OLE‑Objekt auf `zip` gesetzt wird:  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Ändern Sie den Dateityp zu ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau bestehend aus einem Symbolbild hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie das OLE‑Objekt öffnen. Möchten Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden, können Sie das Symbolbild und den Titel mit Aspose.Slides for PHP via Java setzen.  

Der folgende PHP‑Code zeigt, wie Symbolbild und Titel für ein eingebettetes Objekt festgelegt werden:  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Bild zu den Präsentationsressourcen hinzufügen.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Verhindern, dass ein OLE‑Objekt‑Frame in Größe und Position geändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Folie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Links zu aktualisieren. Das Klicken auf „Links aktualisieren“ kann die Größe und Position des OLE‑Objekt‑Frames ändern, weil PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Vorschau neu rendert. Um zu verhindern, dass PowerPoint nach einer Aktualisierung der Objekt­daten fragt, setzen Sie die Methode `setUpdateAutomatic` der [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Klasse auf `false`:  
```php
$oleFrame->setUpdateAutomatic(false);
```


## **Eingebettete Dateien extrahieren**

Aspose.Slides for PHP via Java ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien folgendermaßen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Formen zu.  
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Object‑Frames zu und schreiben Sie sie auf die Festplatte.  

Der folgende PHP‑Code zeigt, wie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahiert werden:  
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

Was auf der Folie sichtbar ist, wird gerendert – das Symbol/Ersetzung‑Bild (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Falls nötig, legen Sie ein eigenes Vorschaubild fest, um das erwartete Erscheinungsbild im exportierten PDF sicherzustellen.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet Form‑bezogene Sperren. Das ist keine Verschlüsselung, verhindert jedoch effektiv unbeabsichtigte Änderungen und Bewegungen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format stehen keine „relativen Pfad“-Informationen zur Verfügung – nur der vollständige Pfad wird gespeichert. Relative Pfade finden sich im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.