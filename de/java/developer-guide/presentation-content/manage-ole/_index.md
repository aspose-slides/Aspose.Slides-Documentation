---
title: OLE in Präsentationen mit Java verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/java/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung & -einbettung
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
## **Einführung**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, in einer anderen Anwendung über Verknüpfung oder Einbettung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in einer PowerPoint‑Folie platziert. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird beim Doppelklick auf das Symbol das Diagramm in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen, und Sie können die Diagrammdaten innerhalb von PowerPoint ändern. 

[Aspose.Slides for Java](https://products.aspose.com/slides/de/java/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/OleObjectFrame)).

## **OLE‑Objekt‑Frames zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mithilfe von Aspose.Slides for Java als OLE‑Objekt‑Frame in eine Folie einbetten, dann können Sie das folgendermaßen tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Lesen Sie die Excel‑Datei als Byte‑Array.  
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/OleObjectFrame) zur Folie hinzu, das das Byte‑Array und weitere Informationen zum OLE‑Objekt enthält.  
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  

Im Beispiel unten haben wir ein Diagramm aus einer Excel‑Datei mithilfe von Aspose.Slides for Java als OLE‑Objekt‑Frame zu einer Folie hinzugefügt.  
**Hinweis**, dass der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/OleEmbeddedDataInfo) eine einbettbare Objekt‑Erweiterung als zweiten Parameter erwartet. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.  

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Bereiten Sie die Daten für das OLE-Objekt vor.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Fügen Sie den OLE-Objekt-Frame zur Folie hinzu.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Verknüpfte OLE‑Objekt‑Frames hinzufügen**

Aspose.Slides for Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/OleObjectFrame) ohne Einbettung von Daten, sondern nur mit einem Link zur Datei.

Der folgende Java‑Code zeigt, wie Sie ein [OleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/OleObjectFrame) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Fügen Sie einen OLE-Objekt-Frame mit einer verknüpften Excel-Datei hinzu.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zugriff auf OLE‑Objekt‑Frames**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf diese Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) Klasse erstellen.  
2. Rufen Sie die Referenz der Folie über ihren Index ab.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/OleObjectFrame)‑Form. In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die auf der ersten Folie nur eine Form enthält. Wir haben dieses Objekt dann als [IOleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/IOleObjectFrame) gecastet. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  

Im folgenden Beispiel werden ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) und dessen Dateidaten abgerufen.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Holen Sie die eingebetteten Dateidaten.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Holen Sie die Erweiterung der eingebetteten Datei.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Zugriff auf Eigenschaften verknüpfter OLE‑Objekt‑Frames**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objekt‑Frames.

Der folgende Java‑Code zeigt, wie Sie prüfen können, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermitteln:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Prüfen, ob das OLE-Objekt verknüpft ist.
    if (oleFrame.isObjectLink()) {
        // Geben Sie den vollständigen Pfad zur verknüpften Datei aus.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Geben Sie den relativen Pfad zur verknüpften Datei aus, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE‑Objektdaten ändern**

{{% alert color="info" %}} 

In diesem Abschnitt verwendet das untenstehende Codebeispiel [Aspose.Cells for Java](/cells/java/).  

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie dieses Objekt leicht zugreifen und seine Daten wie folgt ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) Klasse erstellen.  
2. Rufen Sie die Referenz der Folie über ihren Index ab.  
3. Greifen Sie auf die OLE‑Objekt‑Frame‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die auf der ersten Folie eine Form enthält. Wir haben dieses Objekt dann als [IOleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/IOleObjectFrame) gecastet. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.  

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten geändert, um die Diagrammdaten zu aktualisieren.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Lesen Sie die OLE-Objektdaten als Workbook-Objekt.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Ändern Sie die Workbook-Daten.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Ändern Sie die OLE-Frame-Objektdaten.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for Java das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML-, PDF- und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im entsprechenden Programm geöffnet oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.

Der folgende Java‑Code zeigt, wie Sie HTML und ZIP in eine Folie einbetten:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **Dateitypen für eingebettete Objekte festlegen**

Beim Arbeiten mit Präsentationen müssen Sie möglicherweise alte OLE‑Objekte durch neue ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes ersetzen. Aspose.Slides for Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder deren Erweiterung aktualisieren können.

Der folgende Java‑Code zeigt, wie Sie den Dateityp für ein eingebettetes OLE‑Objekt auf `zip` setzen:

```java
import com.aspose.slides.*;

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

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau bestehend aus einem Symbolbild hinzugefügt. Diese Vorschau wird den Benutzern angezeigt, bevor sie das OLE‑Objekt öffnen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for Java festlegen.

Der folgende Java‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Bild zu den Präsentationsressourcen hinzufügen.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Verhindern, dass ein OLE‑Objekt‑Frame in Größe und Position verändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Durch Klicken auf „Verknüpfungen aktualisieren“ kann die Größe und Position des OLE‑Objekt‑Frames geändert werden, weil PowerPoint die Daten aus dem verknüpften OLE‑Objekt aktualisiert und die Vorschau erneuert. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objekt‑Daten auffordert, setzen Sie die Methode `setUpdateAutomatic` des [IOleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ioleobjectframe/) Interface auf `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides for Java ermöglicht das Extrahieren der in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/oleobjectframe)‑Formen zu.  
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Object‑Frames zu und schreiben Sie sie auf die Festplatte.  

Der folgende Java‑Code zeigt, wie Sie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahieren:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

### Wird der OLE‑Inhalt beim Exportieren von Folien nach PDF/Bildern gerendert?

Es wird das gerendert, was auf der Folie sichtbar ist – das Symbol‑/Ersatzbild (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschau‑Bild festlegen, um das gewünschte Erscheinungsbild im exportierten PDF sicherzustellen.

### Wie kann ich ein OLE‑Objekt auf einer Folie sperren, damit Benutzer es in PowerPoint nicht verschieben/bearbeiten können?

Sperren Sie die Form: Aspose.Slides bietet [Form‑bezogene Sperren](/slides/de/java/applying-protection-to-presentation/). Dies ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Bearbeitungen und Bewegungen.

### Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Aussehen folgen Sie den bewährten Vorgehensweisen im [Working Solution for Worksheet Resizing](/slides/de/java/working-solution-for-worksheet-resizing/) – passen Sie den Frame an den Bereich an oder skalieren Sie den Bereich auf einen festen Frame und legen Sie ein geeignetes Ersatzbild fest.

### Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format erhalten bleiben?

Im PPTX‑Format ist die Information „relativer Pfad“ nicht verfügbar – es wird nur der vollständige Pfad gespeichert. Relative Pfade existieren im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.