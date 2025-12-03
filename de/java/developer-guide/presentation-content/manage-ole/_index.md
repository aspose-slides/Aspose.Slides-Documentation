---
title: OLE in Präsentationen mit Java verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/java/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung & Einbetten
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
- Java
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Java. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren Sie sie und exportieren Sie sie."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) ist eine Microsoft-Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verlinkung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in eine PowerPoint‑Folie eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird beim Doppelklick auf das Symbol das Diagramm in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle lädt, und Sie können die Diagrammdaten innerhalb von PowerPoint bearbeiten. 

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Hinzufügen von OLE‑Objekt‑Frames zu Folien**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mit Aspose.Slides for Java als OLE‑Objekt‑Frame in eine Folie einbetten, so geht es:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich den Verweis auf eine Folie über ihren Index.
3. Lesen Sie die Excel‑Datei als Byte‑Array ein.
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) zur Folie hinzu, das das Byte‑Array und weitere Informationen über das OLE‑Objekt enthält.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als OLE‑Objekt‑Frame in eine Folie eingefügt, indem wir Aspose.Slides for Java verwendet haben. **Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) akzeptiert als zweiten Parameter eine Erweiterung des einbettbaren Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.
``` java
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Daten für das OLE-Objekt vorbereiten.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Hinzufügen von verknüpften OLE‑Objekt‑Frames**

Aspose.Slides for Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) ohne Einbetten von Daten, sondern nur mit einem Dateiverweis.

Dieser Java‑Code zeigt, wie Sie ein [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügen:
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE-Objekt-Frame mit verknüpfter Excel-Datei hinzufügen.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Zugriff auf OLE‑Objekt‑Frames**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf folgende Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse erstellen.
2. Holen Sie den Verweis auf die Folie über deren Index.
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die nur eine Form auf der ersten Folie enthält. Wir haben dieses Objekt dann zu einem [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) *gecastet*. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden soll.
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.

Im nachstehenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) sowie dessen Dateidaten abgerufen.
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Eingebettete Dateidaten abrufen.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Erweiterung der eingebetteten Datei erhalten.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Zugriff auf Eigenschaften verknüpfter OLE‑Objekt‑Frames**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objekt‑Frames.

Dieser Java‑Code zeigt, wie Sie prüfen können, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermitteln:
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Prüfen, ob das OLE-Objekt verknüpft ist.
    if (oleFrame.isObjectLink()) {
        // Den vollständigen Pfad zur verknüpften Datei ausgeben.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Den relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **Ändern von OLE‑Objektdaten**

{{% alert color="primary" %}} 

In diesem Abschnitt verwendet das untenstehende Codebeispiel [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie das Objekt auf folgende Weise leicht zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse erstellen.
2. Holen Sie den Verweis auf die Folie über ihren Index. 
3. Greifen Sie auf die OLE‑Objekt‑Frame‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die eine Form auf der ersten Folie enthält. Wir haben dieses Objekt dann zu einem [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) *gecastet*. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden soll.
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im nachstehenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) abgerufen und dessen Dateidaten geändert, um die Diagrammdaten zu aktualisieren.
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE-Objektdaten als Workbook-Objekt lesen.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Arbeitsmappendaten ändern.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE-Frame-Objektdaten ändern.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Einbetten anderer Dateitypen in Folien**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for Java das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML-, PDF- und ZIP-Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im entsprechenden Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.

Dieser Java‑Code zeigt, wie Sie HTML und ZIP in eine Folie einbetten:
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Festlegen von Dateitypen für eingebettete Objekte**

Beim Arbeiten mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder dessen Erweiterung aktualisieren können.

Dieser Java‑Code zeigt, wie Sie den Dateityp für ein eingebettetes OLE‑Objekt auf `zip` festlegen:
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Festlegen von Symbolbildern und Titeln für eingebettete Objekte**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau in Form eines Symbolbildes hinzugefügt. Diese Vorschau sehen Benutzer, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for Java festlegen.

Dieser Java‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen:
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Ein Bild zu den Präsentationsressourcen hinzufügen.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Verhindern, dass ein OLE‑Objekt‑Frame skaliert und repositioniert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Das Klicken auf die Schaltfläche „Update Links“ kann Größe und Position des OLE‑Objekt‑Frames ändern, da PowerPoint die Daten aus dem verknüpften OLE‑Objekt aktualisiert und die Objektvorschau neu lädt. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, setzen Sie die Methode `setUpdateAutomatic` des [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/)‑Interfaces auf `false`:
```java
oleFrame.setUpdateAutomatic(false);
```


## **Extrahieren eingebetteter Dateien**

Aspose.Slides for Java ermöglicht das Extrahieren der in Folien eingebetteten Dateien als OLE‑Objekte auf folgende Weise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe)‑Formen zu.
3. Greifen Sie auf die Daten eingebetteter Dateien aus OLE‑Object‑Frames zu und schreiben Sie sie auf die Festplatte.

Dieser Java‑Code zeigt, wie Sie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahieren:
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```


## **FAQ**

**Wird der OLE‑Inhalt beim Exportieren von Folien in PDF/Bilder gerendert?**

Was auf der Folie sichtbar ist, wird gerendert – das Symbol/Ersetzungssymbol (Vorschau). Der „Live“-OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschaubild festlegen, um das erwartete Aussehen im exportierten PDF zu gewährleisten.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides stellt [Form‑Ebene Sperren](/slides/de/java/applying-protection-to-presentation/) bereit. Dies ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Verschiebungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert die Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die Praktiken aus der [Working Solution for Worksheet Resizing](/slides/de/java/working-solution-for-worksheet-resizing/) befolgen – entweder den Frame an den Bereich anpassen oder den Bereich auf einen festen Frame skalieren und ein geeignetes Ersetzungssymbol festlegen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

In PPTX ist die Information zu „relativen Pfaden“ nicht verfügbar – es wird nur der vollständige Pfad gespeichert. Relative Pfade kommen im älteren PPT‑Format vor. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.