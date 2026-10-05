---
title: OLE in Präsentationen mit Java verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/java/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung & -Einbettung
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
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Java. OLE-Inhalte nahtlos einbetten, aktualisieren und exportieren."
---
## **Einleitung**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in einer PowerPoint‑Folie platziert. Dieses Excel‑Diagramm wird als OLE‑Objekt betrachtet. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen.  
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, beispielsweise den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern.  

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) ermöglicht das Einfügen von OLE Objects in Folien als OLE‑Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **OLE‑Objektrahmen zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mithilfe von Aspose.Slides for Java als OLE‑Objektrahmen in eine Folie einbetten, dann können Sie dies folgendermaßen tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.  
1. Holen Sie sich die Referenz einer Folie über deren Index.  
1. Lesen Sie die Excel‑Datei als Byte‑Array.  
1. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) zur Folie hinzu, das das Byte‑Array und weitere Informationen über das OLE‑Objekt enthält.  
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei mithilfe von Aspose.Slides for Java als OLE‑Objektrahmen zu einer Folie hinzugefügt. **Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) akzeptiert als zweiten Parameter eine Erweiterung des einbettbaren Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.

``` java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Daten für das OLE-Objekt vorbereiten.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Den OLE-Objektrahmen zur Folie hinzufügen.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Verknüpfte OLE‑Objektrahmen hinzufügen**

Aspose.Slides for Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) ohne Einbetten von Daten, sondern nur mit einem Link zur Datei.  

Dieser Java‑Code zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) mit einer verknüpften Excel‑Datei zu einer Folie hinzugefügt wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE-Objektrahmen mit einer verknüpften Excel-Datei hinzufügen.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Zugriff auf OLE‑Objektrahmen**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf folgende Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse erstellen.  
2. Holen Sie sich die Referenz der Folie über deren Index.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)‑Form zu. In unserem Beispiel verwendeten wir das zuvor erstellte PPTX, das nur eine Form auf der ersten Folie enthält. Wir casten dieses Objekt anschließend zu einem [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Dies war das gewünschte OLE‑Objektrahmen, das zugegriffen werden sollte.  
4. Sobald auf den OLE‑Objektrahmen zugegriffen wurde, können Sie beliebige Operationen damit durchführen.  

Im folgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) und dessen Dateidaten abgerufen.

``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Die eingebetteten Dateidaten abrufen.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Die Erweiterung der eingebetteten Datei abrufen.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Zugriff auf Eigenschaften verknüpfter OLE‑Objektrahmen**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objektrahmen.  

Dieser Java‑Code zeigt, wie man prüft, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermittelt:

```java
import com.aspose.slides.*;

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

## **OLE‑Objektdaten ändern**

{{% alert color="info" title="Note" %}}

In diesem Abschnitt verwendet das nachstehende Codebeispiel [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).  

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie das Objekt auf folgende Weise leicht zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse erstellen.  
2. Holen Sie sich die Referenz der Folie über deren Index.  
3. Greifen Sie auf die OLE‑Objektrahmen‑Form zu. In unserem Beispiel verwendeten wir das zuvor erstellte PPTX, das eine Form auf der ersten Folie enthält. Wir casten dieses Objekt dann zu einem [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Dies war das gewünschte OLE‑Objektrahmen, das zugegriffen werden sollte.  
4. Sobald auf den OLE‑Objektrahmen zugegriffen wurde, können Sie beliebige Operationen ausführen.  
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.  

Im folgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten geändert, um die Diagrammdaten zu aktualisieren.

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

    // OLE-Objektdaten als Workbook-Objekt lesen.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Die Workbook-Daten ändern.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Die OLE‑Rahmenobjektdaten ändern.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for Java das Einbetten anderer Dateitypen in Folien. Sie können beispielsweise HTML-, PDF- und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im entsprechenden Programm geöffnet, oder der Benutzer wird aufgefordert, ein passendes Programm zum Öffnen auszuwählen.  

Dieser Java‑Code zeigt, wie HTML und ZIP in einer Folie eingebettet werden:

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

Bei der Arbeit mit Präsentationen kann es notwendig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Rahmendaten oder deren Erweiterung aktualisieren können.  

Dieser Java‑Code zeigt, wie der Dateityp für ein eingebettetes OLE‑Objekt auf `zip` gesetzt wird:

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

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau in Form eines Symbolbildes hinzugefügt. Diese Vorschau sehen Benutzer, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for Java festlegen.  

Dieser Java‑Code zeigt, wie das Symbolbild und der Titel für ein eingebettetes Objekt festgelegt werden:

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

oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Verhindern, dass ein OLE‑Objektrahmen in Größe und Position verändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Das Klicken auf die Schaltfläche „Update Links“ kann die Größe und Position des OLE‑Objektrahmens ändern, weil PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Vorschau des Objekts neu lädt. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, rufen Sie die Methode [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) des Interfaces [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) mit `false` auf:

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

Aspose.Slides for Java ermöglicht das Extrahieren der in Folien eingebetteten Dateien als OLE‑Objekte auf folgende Weise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Iterieren Sie über alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe)‑Formen zu.  
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Objektrahmen zu und schreiben Sie sie auf die Festplatte.  

Dieser Java‑Code zeigt, wie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahiert werden:

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

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**

Was auf der Folie sichtbar ist, wird gerendert – das Symbol/Ersetzungsbild (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschaubild festlegen, um das erwartete Aussehen im exportierten PDF sicherzustellen.  

Um das eingebettete Dokument zusätzlich als PDF‑Anhang zu erhalten, rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) mit `true` auf. Diese Option ist standardmäßig deaktiviert. Für ein Beispiel und Anweisungen zum Prüfen des Anhangs siehe [Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten](/slides/de/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [Form‑Ebene‑Sperren](/slides/de/java/applying-protection-to-presentation/). Dies ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Bearbeitungen und Verschiebungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert die Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE aktualisieren. Für ein stabiles Erscheinungsbild befolgen Sie die Praktiken von [Lösung für die Größenanpassung von Arbeitsblättern](/slides/de/java/working-solution-for-worksheet-resizing/) – passen Sie entweder den Rahmen an den Bereich an oder skalieren Sie den Bereich zu einem festen Rahmen und legen Sie ein geeignetes Ersatzbild fest.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

In PPTX sind Informationen zu „relativen Pfaden“ nicht verfügbar – nur der vollständige Pfad. Relative Pfade kommen im älteren PPT‑Format vor. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder Einbettungen bevorzugen.