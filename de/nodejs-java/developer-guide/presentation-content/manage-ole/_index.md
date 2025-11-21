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
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Node.js. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren Sie sie und exportieren Sie sie."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, durch Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein in MS Excel erstelltes Diagramm. Das Diagramm wird dann in eine PowerPoint‑Folienfolie eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird beim Doppelklick auf das Symbol das Diagramm in der zugehörigen Anwendung (Excel) geöffnet, oder es wird nach einer Anwendung zum Öffnen bzw. Bearbeiten des Objekts gefragt. 
- Ein OLE‑Objekt kann seine tatsächlichen Inhalte anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern. 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)). 

## **Hinzufügen von OLE‑Objekt‑Frames zu Folien**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mit Aspose.Slides for Node.js via Java als OLE‑Objekt‑Frame in eine Folie einbetten, so gehen Sie vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.  
2. Holen Sie sich die Referenz einer Folie über ihren Index.  
3. Lesen Sie die Excel‑Datei als Byte‑Array.  
4. Fügen Sie der Folie das [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) hinzu, das das Byte‑Array und weitere Informationen über das OLE‑Objekt enthält.  
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  

Im nachfolgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als OLE‑Objekt‑Frame zu einer Folie hinzugefügt, wobei Aspose.Slides for Node.js via Java verwendet wurde.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) akzeptiert als zweiten Parameter eine Erweiterung des einbettbaren Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.  
```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Daten für das OLE-Objekt vorbereiten.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// OLE-Objekt-Frame zur Folie hinzufügen.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


### **Hinzufügen verknüpfter OLE‑Objekt‑Frames**

Aspose.Slides for Node.js via Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame), bei dem keine Daten eingebettet, sondern nur ein Link zur Datei verwendet wird.  

Dieser JavaScript‑Code zeigt, wie Sie ein [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügen:  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// OLE-Objekt-Frame mit verknüpfter Excel-Datei hinzufügen.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Zugriff auf OLE‑Objekt‑Frames**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf folgende Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse erstellen.  
2. Holen Sie sich die Referenz der Folie über ihren Index.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX-Datei verwendet, die auf der ersten Folie nur eine Form enthält.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  

Im nachfolgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) und seine Dateidaten abgerufen.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Eingebettete Dateidaten abrufen.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Erweiterung der eingebetteten Datei abrufen.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Zugriff auf Eigenschaften verknüpfter OLE‑Objekt‑Frames**

Aspose.Slides ermöglicht den Zugriff auf die Eigenschaften verknüpfter OLE‑Objekt‑Frames.  

Dieser JavaScript‑Code zeigt, wie Sie prüfen können, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermitteln:  
```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Überprüfen, ob das OLE-Objekt verlinkt ist.
    if (oleFrame.isObjectLink()) {
        // Gibt den vollständigen Pfad zur verlinkten Datei aus.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Gibt den relativen Pfad zur verlinkten Datei aus, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **Ändern von OLE‑Objektdaten**

{{% alert color="primary" %}} 

In diesem Abschnitt verwendet das nachstehende Code‑Beispiel [Aspose.Cells for Java](/cells/java/).  

{{% /alert %}}

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse erstellen.  
2. Holen Sie sich die Referenz der Folie über ihren Index.  
3. Greifen Sie auf die OLE‑Objekt‑Frame‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die auf der ersten Folie eine Form enthält.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.  

Im nachfolgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) abgerufen und seine Dateidaten werden geändert, um die Diagrammdaten zu aktualisieren.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE-Objektdaten als Workbook-Objekt lesen.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Die Workbook-Daten ändern.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // OLE-Frame-Objektdaten ändern.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Einbetten anderer Dateitypen in Folien**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for Node.js via Java das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML-, PDF- und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im entsprechenden Programm geöffnet oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.  

Dieser JavaScript‑Code zeigt, wie Sie HTML und ZIP in eine Folie einbetten:  
```javascript
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

Beim Arbeiten mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for Node.js via Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder dessen Erweiterung aktualisieren können.  

Dieser JavaScript‑Code zeigt, wie Sie den Dateityp eines eingebetteten OLE‑Objekts auf `zip` setzen:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Ändere den Dateityp zu ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Festlegen von Symbolbildern und Titeln für eingebettete Objekte**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau in Form eines Symbolbildes hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie das OLE‑Objekt öffnen oder darauf zugreifen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for Node.js via Java festlegen.  

Dieser JavaScript‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Bild zu den Präsentationsressourcen hinzufügen.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Titel und Bild für die OLE‑Vorschau setzen.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Verhindern, dass ein OLE‑Objekt‑Frame skaliert und neu positioniert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Ein Klick auf die Schaltfläche „Update Links“ kann die Größe und Position des OLE‑Objekt‑Frames ändern, weil PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Vorschau neu lädt. Um zu verhindern, dass PowerPoint zum Aktualisieren der Objektdaten auffordert, verwenden Sie die Methode `setUpdateAutomatic` der Klasse [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) mit dem Wert `false`:  
```javascript
oleFrame.setUpdateAutomatic(false);
```


## **Extrahieren eingebetteter Dateien**

Aspose.Slides for Node.js via Java ermöglicht das Extrahieren der in Folien eingebetteten Dateien als OLE‑Objekte auf folgende Weise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse, die die OLE‑Objekte enthält, die Sie extrahieren möchten.  
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)‑Formen zu.  
3. Greifen Sie auf die Daten eingebetteter Dateien aus OLE‑Objekt‑Frames zu und schreiben Sie sie auf die Festplatte.  

Dieser JavaScript‑Code zeigt, wie Sie in einer Folie eingebettete Dateien als OLE‑Objekte extrahieren:  
```javascript
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

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**

Was auf der Folie sichtbar ist, wird gerendert – das Symbol/Ersetzungbild (Vorschau). Der „Live‑“ OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschau‑Bild festlegen, um das erwartete Aussehen im exportierten PDF zu gewährleisten.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [Form‑Sperren](/slides/de/nodejs-java/applying-protection-to-presentation/). Das ist keine Verschlüsselung, verhindert jedoch effektiv unbeabsichtigte Bearbeitungen und Verschiebungen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format gibt es keine Informationen zu „relativen Pfaden“ – nur den vollständigen Pfad. Relative Pfade sind im älteren PPT‑Format zu finden. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.