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
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für PHP via Java. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren und exportieren Sie sie."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird anschließend in eine PowerPoint‑Folie eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder es wird nach einer Anwendung zum Öffnen bzw. Bearbeiten des Objekts gefragt. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern. 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)). 

## **OLE‑Objekt‑Frames zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mit Aspose.Slides for PHP via Java als OLE‑Objekt‑Frame in eine Folie einbetten, dann geht das folgendermaßen: 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse. 
1. Holen Sie sich über den Index den Verweis auf die Folie. 
1. Lesen Sie die Excel‑Datei als Byte‑Array. 
1. Fügen Sie der Folie das [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) mit dem Byte‑Array und weiteren Informationen zum OLE‑Objekt hinzu. 
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei. 

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als OLE‑Objekt‑Frame in eine Folie eingefügt, wobei Aspose.Slides for PHP via Java verwendet wurde.  
**Hinweis**, dass der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) eine einbettbare Objekt‑Erweiterung als zweiten Parameter erhält. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen des OLE‑Objekts auszuwählen. 
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

Dieser PHP‑Code zeigt, wie Sie ein [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügen: 
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// OLE-Objekt-Frame mit verknüpfter Excel-Datei hinzufügen.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Zugriff auf OLE‑Objekt‑Frames**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es wie folgt leicht finden oder darauf zugreifen: 

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse erstellen. 
2. Holen Sie sich den Verweis auf die Folie über deren Index. 
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die auf der ersten Folie nur eine Form enthält. 
4. Sobald das OLE‑Objekt‑Frame angesprochen ist, können Sie beliebige Operationen darauf ausführen. 

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) und dessen Dateidaten verwendet. 
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Abrufen der eingebetteten Dateidaten.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Ermitteln der Dateierweiterung der eingebetteten Datei.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **Eigenschaften verknüpfter OLE‑Objekt‑Frames zugreifen**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objekt‑Frames. 

Dieser PHP‑Code zeigt, wie Sie prüfen können, ob ein OLE‑Objekt verknüpft ist, und dann den Pfad zur verknüpften Datei ermitteln: 
```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Überprüfen, ob das OLE-Objekt verknüpft ist.
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

{{% alert color="primary" %}} 

In diesem Abschnitt verwendet das untenstehende Code‑Beispiel [Aspose.Cells for PHP via Java](/cells/php-java/). 

{{% /alert %}} 

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie das Objekt leicht zugreifen und dessen Daten wie folgt ändern: 

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse erstellen. 
2. Holen Sie sich den Verweis auf die Folie über deren Index. 
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die auf der ersten Folie eine Form enthält. 
4. Sobald das OLE‑Objekt‑Frame angesprochen ist, können Sie beliebige Operationen darauf ausführen. 
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu. 
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten. 
7. Speichern Sie das aktualisierte `Workbook` in einem Stream. 
8. Ändern Sie die OLE‑Objektdaten aus dem Stream. 

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) angesprochen und dessen Dateidaten werden geändert, um die Diagrammdaten zu aktualisieren. 
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

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

    // Ändere die OLE-Frame-Objektdaten.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for PHP via Java das Einbetten anderer Dateitypen in Folien. Sie können beispielsweise HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, öffnet es sich automatisch im jeweiligen Programm, bzw. der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen. 

Dieser PHP‑Code zeigt, wie Sie HTML und ZIP in eine Folie einbetten: 
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

Beim Arbeiten mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for PHP via Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder deren Erweiterung aktualisieren können. 

Dieser PHP‑Code zeigt, wie Sie den Dateityp für ein eingebettetes OLE‑Objekt auf `zip` setzen: 
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau bestehend aus einem Symbolbild hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie das OLE‑Objekt öffnen oder darauf zugreifen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for PHP via Java festlegen. 

Dieser PHP‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen: 
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Ein Bild zu den Präsentationsressourcen hinzufügen.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Einen Titel und das Bild für die OLE-Vorschau festlegen.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Verhindern, dass ein OLE‑Objekt‑Frame skaliert und neu positioniert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Durch Klicken auf die Schaltfläche „Links aktualisieren“ kann die Größe und Position des OLE‑Objekt‑Frames geändert werden, weil PowerPoint die Daten aus dem verknüpften OLE‑Objekt aktualisiert und die Objektvorschau neu erstellt. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objekt‑Daten auffordert, setzen Sie die Methode `setUpdateAutomatic` der [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Klasse auf `false`: 
```php
$oleFrame->setUpdateAutomatic(false);
```


## **Eingebettete Dateien extrahieren**

Aspose.Slides for PHP via Java ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt: 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält. 
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)‑Formen zu. 
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Object‑Frames zu und schreiben Sie sie auf die Festplatte. 

Dieser PHP‑Code zeigt, wie Sie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahieren: 
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

**Wird der OLE‑Inhalt beim Exportieren von Folien nach PDF/Bildern gerendert?**  
Was auf der Folie sichtbar ist, wird gerendert – das Symbol/Ersatzbild (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie Ihr eigenes Vorschau‑Bild festlegen, um das erwartete Erscheinungsbild im exportierten PDF sicherzustellen.  

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**  
Form sperren: Aspose.Slides bietet [Form‑Ebene‑Sperren](/slides/de/php-java/applying-protection-to-presentation/). Das ist keine Verschlüsselung, verhindert aber effektiv versehentliche Änderungen und Verschiebungen.  

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**  
PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild folgen Sie den Praktiken der [Working Solution for Worksheet Resizing](/slides/de/php-java/working-solution-for-worksheet-resizing/) – entweder den Frame an den Bereich anpassen oder den Bereich an einen festen Frame skalieren und ein geeignetes Ersatzbild setzen.  

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**  
In PPTX gibt es keine Informationen zu „relativen Pfaden“ – nur den vollständigen Pfad. Relative Pfade finden sich im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/Zugriffs‑URIs oder das Einbetten bevorzugen.