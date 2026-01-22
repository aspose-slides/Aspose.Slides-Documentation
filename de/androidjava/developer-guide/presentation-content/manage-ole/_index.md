---
title: OLE in Präsentationen unter Android verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Android via Java. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren Sie sie und exportieren Sie sie."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in eine PowerPoint‑Folie eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, bzw. Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagramm‑Benutzeroberfläche wird geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern. 

[Aspose.Slides für Android via Java](https://products.aspose.com/slides/androidjava/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **OLE‑Objekt‑Frames zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mithilfe von Aspose.Slides für Android via Java als OLE‑Objekt‑Frame in eine Folie einbetten, so gehen Sie vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.  
1. Holen Sie die Referenz einer Folie über ihren Index.  
1. Lesen Sie die Excel‑Datei in ein Byte‑Array ein.  
1. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) zur Folie hinzu, das das Byte‑Array und weitere Informationen zum OLE‑Objekt enthält.  
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.  

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei mithilfe von Aspose.Slides für Android via Java als OLE‑Objekt‑Frame zu einer Folie hinzugefügt.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) akzeptiert als zweiten Parameter eine Dateierweiterung für das einzubettende Objekt. Diese Erweiterung erlaubt PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.  
```java
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Daten für das OLE-Objekt vorbereiten.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// OLE-Objekt-Frame zur Folie hinzufügen.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Verknüpfte OLE‑Objekt‑Frames hinzufügen**

Aspose.Slides für Android via Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) ohne Einbetten von Daten, sondern nur mit einem Verweis auf die Datei.  

Der folgende Java‑Code zeigt, wie man ein [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügt:  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE-Objekt-Frame mit einer verknüpften Excel-Datei hinzufügen.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Zugriff auf OLE‑Objekt‑Frames**

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie es auf folgende Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse erstellen.  
2. Holen Sie die Referenz der Folie über ihren Index.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die auf der ersten Folie nur eine Form enthält. Wir haben dieses Objekt dann zu einem [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) *gecastet*. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) sowie dessen Dateidaten abgerufen.  
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Eingebettete Dateidaten abrufen.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Erweiterung der eingebetteten Datei abrufen.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Eigenschaften verknüpfter OLE‑Objekt‑Frames abrufen**

Aspose.Slides ermöglicht den Zugriff auf die Eigenschaften verknüpfter OLE‑Objekt‑Frames.  

Der folgende Java‑Code zeigt, wie man prüft, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermittelt:  
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Prüfen, ob das OLE-Objekt verknüpft ist.
    if (oleFrame.isObjectLink()) {
        // Vollständigen Pfad zur verknüpften Datei ausgeben.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **OLE‑Objektdaten ändern**

{{% alert color="primary" %}} 

In diesem Abschnitt verwendet das nachstehende Code‑Beispiel [Aspose.Cells für Android via Java](/cells/androidjava/).  

{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie das Objekt auf folgende Weise leicht zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse erstellen.  
2. Holen Sie die Referenz der Folie über ihren Index.  
3. Greifen Sie auf die OLE‑Objekt‑Frame‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die auf der ersten Folie eine Form enthält. Wir haben dieses Objekt dann zu einem [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) *gecastet*. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.  

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten geändert, um die Diagrammdaten zu aktualisieren.  
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE-Objektdaten als Workbook-Objekt lesen.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Workbook-Daten ändern.
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


## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides für Android via Java das Einbetten weiterer Dateitypen in Folien. Beispielsweise können Sie HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im entsprechenden Programm geöffnet, bzw. der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.  

Der folgende Java‑Code zeigt, wie HTML‑ und ZIP‑Dateien in eine Folie eingebettet werden:  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Dateitypen für eingebettete Objekte festlegen**

Beim Arbeiten mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu substituieren. Aspose.Slides für Android via Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder dessen Erweiterung aktualisieren können.  

Der folgende Java‑Code zeigt, wie der Dateityp eines eingebetteten OLE‑Objekts auf `zip` gesetzt wird:  
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


## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau in Form eines Symbolbildes hinzugefügt. Diese Vorschau wird den Benutzern angezeigt, bevor sie das OLE‑Objekt öffnen oder darauf zugreifen. Möchten Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden, können Sie das Symbolbild und den Titel mit Aspose.Slides für Android via Java festlegen.  

Der folgende Java‑Code zeigt, wie Symbolbild und Titel für ein eingebettetes Objekt gesetzt werden:  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Bild zu den Ressourcen der Präsentation hinzufügen.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Verhindern, dass ein OLE‑Objekt‑Frame in Größe und Position verändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Das Klicken auf die Schaltfläche „Update Links“ kann die Größe und Position des OLE‑Objekt‑Frames ändern, da PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Vorschau neu erstellt. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, setzen Sie die Methode `setUpdateAutomatic` des [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) Interfaces auf `false`:  
```java
oleFrame.setUpdateAutomatic(false);
```


## **Eingebettete Dateien extrahieren**

Aspose.Slides für Android via Java ermöglicht das Extrahieren der in Folien eingebetteten Dateien als OLE‑Objekte wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe)‑Formen zu.  
3. Greifen Sie auf die Daten eingebetteter Dateien aus den OLE‑Object‑Frames zu und schreiben Sie sie auf die Festplatte.  

Der folgende Java‑Code zeigt, wie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahiert werden:  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```


## **FAQ**

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**

Es wird das, was auf der Folie sichtbar ist, gerendert – das Symbol/Ersetzungs‑Bild (Vorschau). Der „Live‑“ OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschau‑Bild festlegen, um das erwartete Aussehen im exportierten PDF sicherzustellen.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet Sperren auf Form‑Ebene. Das ist keine Verschlüsselung, verhindert jedoch effektiv unbeabsichtigte Änderungen und das Verschieben.

**Warum springt ein verknüpftes Excel‑Objekt oder ändert die Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die Vorgehensweise aus der [Working Solution for Worksheet Resizing](/slides/de/androidjava/working-solution-for-worksheet-resizing/) befolgen – entweder den Frame an den Bereich anpassen oder den Bereich an einen festen Frame skalieren und ein passendes Ersatzbild festlegen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format erhalten bleiben?**

Im PPTX‑Format ist die Information zu „relativen Pfaden“ nicht vorhanden – es wird nur der vollständige Pfad gespeichert. Relative Pfade kommen im älteren PPT‑Format vor. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.