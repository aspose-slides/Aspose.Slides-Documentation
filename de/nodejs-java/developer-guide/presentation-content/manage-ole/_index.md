---
title: OLE in Präsentationen mit JavaScript verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Node.js via Java. Betten Sie OLE-Inhalte ein, aktualisieren Sie sie und exportieren Sie sie nahtlos."
---
## **Einleitung**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein in MS Excel erstelltes Diagramm. Das Diagramm wird anschließend in einer PowerPoint‑Folie platziert. Dieses Excel‑Diagramm wird als OLE‑Objekt betrachtet. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen.
- Ein OLE‑Objekt kann seine tatsächlichen Inhalte anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern.

[Aspose.Slides für Node.js via Java](https://products.aspose.com/slides/nodejs-java/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Hinzufügen von OLE‑Objektrahmen zu Folien**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mit Aspose.Slides für Node.js via Java als OLE‑Objektrahmen in eine Folie einbetten, so geht es:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie die Referenz einer Folie anhand ihres Index.
3. Lesen Sie die Excel‑Datei als Byte‑Array.
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) zur Folie hinzu, das das Byte‑Array und weitere Informationen zum OLE‑Objekt enthält.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als OLE‑Objektrahmen in eine Folie eingefügt, wobei Aspose.Slides für Node.js via Java verwendet wurde.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) akzeptiert als zweiten Parameter die Erweiterung des einzubettenden Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Hinzufügen verknüpfter OLE‑Objektrahmen**

Aspose.Slides für Node.js via Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) ohne Einbetten von Daten, sondern nur mit einem Verweis auf die Datei.

Dieser JavaScript‑Code zeigt, wie Sie ein [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügen:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Füge einen OLE-Objektrahmen mit einer verknüpften Excel-Datei hinzu.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Zugriff auf OLE‑Objektrahmen**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf folgende Weise leicht finden bzw. darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse erstellen.
2. Holen Sie die Referenz der Folie mithilfe ihres Index.
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)‑Form (Shape) zu. In unserem Beispiel haben wir das zuvor erstellte PPTX verwendet, das nur eine Shape auf der ersten Folie enthält.
4. Sobald auf den OLE‑Objektrahmen zugegriffen wurde, können Sie beliebige Operationen darauf ausführen.

Im nachstehenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) sowie dessen Dateidaten abgerufen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Holen Sie die eingebetteten Dateidaten.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Holen Sie die Erweiterung der eingebetteten Datei.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Zugriff auf Eigenschaften verknüpfter OLE‑Objektrahmen**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objektrahmen.

Dieser JavaScript‑Code zeigt, wie Sie prüfen können, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermitteln:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Überprüfen, ob das OLE-Objekt verknüpft ist.
    if (oleFrame.isObjectLink()) {
        // Geben Sie den vollständigen Pfad zur verknüpften Datei aus.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Geben Sie den relativen Pfad zur verknüpften Datei aus, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Ändern von OLE‑Objektdaten**

{{% alert color="info" title="Note" %}}

In diesem Abschnitt verwendet das nachstehende Codebeispiel [Aspose.Cells für Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie das Objekt auf folgende Weise leicht zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse erstellen.
2. Holen Sie die Referenz der Folie über ihren Index.
3. Greifen Sie auf die OLE‑Objektrahmen‑Shape zu. In unserem Beispiel haben wir das zuvor erstellte PPTX verwendet, das eine Shape auf der ersten Folie enthält.
4. Sobald auf den OLE‑Objektrahmen zugegriffen wurde, können Sie beliebige Operationen darauf ausführen.
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im nachstehenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) abgerufen, und dessen Dateidaten werden geändert, um die Diagrammdaten zu aktualisieren.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Lese die OLE-Objektdaten als Workbook-Objekt.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Ändere die Workbook-Daten.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Ändere die OLE-Rahmenobjektdaten.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Einbetten anderer Dateitypen in Folien**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides für Node.js via Java das Einbetten weiterer Dateitypen in Folien. Beispielsweise können Sie HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelt anklickt, wird es automatisch im entsprechenden Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.

Dieser JavaScript‑Code zeigt, wie HTML und ZIP in eine Folie eingebettet werden:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Festlegen von Dateitypen für eingebettete Objekte**

Bei der Arbeit mit Präsentationen müssen Sie möglicherweise alte OLE‑Objekte durch neue ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes ersetzen. Aspose.Slides für Node.js via Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Rahmendaten oder die Erweiterung aktualisieren können.

Dieser JavaScript‑Code zeigt, wie Sie den Dateityp für ein eingebettetes OLE‑Objekt auf `zip` setzen:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Ändern Sie den Dateityp zu ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Festlegen von Symbolbildern und Titeln für eingebettete Objekte**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau bestehend aus einem Symbolbild hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides für Node.js via Java festlegen.

Dieser JavaScript‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Bild zu den Präsentationsressourcen hinzufügen.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Titel und Bild für die OLE‑Vorschau festlegen.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Verhindern, dass ein OLE‑Objektrahmen in Größe und Position geändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Das Klicken auf die Schaltfläche „Update Links“ kann Größe und Position des OLE‑Objektrahmens ändern, da PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Objektvorschau neu lädt. Um zu verhindern, dass PowerPoint auffordert, die Daten des Objekts zu aktualisieren, rufen Sie die Methode [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) der Klasse [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) mit `false` auf:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Extrahieren eingebetteter Dateien**

Aspose.Slides für Node.js via Java ermöglicht das Extrahieren der in Folien eingebetteten Dateien als OLE‑Objekte auf folgende Weise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.
2. Durchlaufen Sie alle Shapes in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe)‑Shapes zu.
3. Greifen Sie auf die Daten eingebetteter Dateien aus OLE‑Objektrahmen zu und schreiben Sie sie auf die Festplatte.

Dieser JavaScript‑Code zeigt, wie Sie in einer Folie eingebettete Dateien als OLE‑Objekte extrahieren:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**Wird der OLE‑Inhalt beim Exportieren von Folien in PDF/Bilder gerendert?**

Was auf der Folie sichtbar ist, wird gerendert – das Symbol/Ersatzbild (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Falls nötig, setzen Sie ein eigenes Vorschau‑Bild, um das erwartete Aussehen im exportierten PDF sicherzustellen.  
Um die eingebettete Datei ebenfalls als PDF‑Anhang zu erhalten, rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) mit `true` auf. Diese Option ist standardmäßig deaktiviert. Ein Beispiel und Anweisungen zum Prüfen des Anhangs finden Sie unter [Preserve Embedded OLE Files as PDF Attachments](/slides/de/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie das Shape: Aspose.Slides bietet Sperren auf Shape‑Ebene. Dies ist keine Verschlüsselung, verhindert aber effektiv versehentliche Änderungen und Verschiebungen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

In PPTX steht die Information zu „relativen Pfaden“ nicht zur Verfügung – nur der vollständige Pfad. Relative Pfade gibt es im älteren PPT‑Format. Für Portabilität sollten zuverlässige absolute Pfade/erreichbare URIs oder das Einbetten bevorzugt werden.