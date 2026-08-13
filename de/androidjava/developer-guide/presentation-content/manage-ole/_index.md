---
title: OLE in Präsentationen auf Android verwalten
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
## **Einleitung**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, mit der Daten und Objekte, die in einer Anwendung erstellt wurden, durch Verknüpfung oder Einbettung in einer anderen Anwendung platziert werden können. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird anschließend in einer PowerPoint‑Folie eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol dargestellt werden. In diesem Fall wird beim Doppelklick auf das Symbol das Diagramm in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen bzw. Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seine tatsächlichen Inhalte anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen und Sie können die Diagrammdaten direkt in PowerPoint bearbeiten.

[Aspose.Slides für Android via Java](https://products.aspose.com/slides/de/androidjava/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/OleObjectFrame)).

## **OLE‑Objektrahmen zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mit Aspose.Slides für Android via Java als OLE‑Objektrahmen in eine Folie einbetten, dann gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.  
2. Holen Sie sich den Referenzwert einer Folie über ihren Index.  
3. Lesen Sie die Excel‑Datei als Byte‑Array ein.  
4. Fügen Sie den [OleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/OleObjectFrame) zur Folie hinzu und übergeben Sie das Byte‑Array sowie weitere Informationen zum OLE‑Objekt.  
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als OLE‑Objektrahmen in eine Folie eingefügt, wobei Aspose.Slides für Android via Java verwendet wurde.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/OleEmbeddedDataInfo) akzeptiert als zweiten Parameter eine Erweiterung des einbettbaren Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen des OLE‑Objekts auszuwählen.

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Daten für das OLE-Objekt vorbereiten.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Den OLE-Objektrahmen zur Folie hinzufügen.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Verknüpfte OLE‑Objektrahmen hinzufügen**

Aspose.Slides für Android via Java erlaubt das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/OleObjectFrame), ohne Daten einzubetten, sondern nur mit einem Link zur Datei.

Der folgende Java‑Code zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/OleObjectFrame) mit einer verknüpften Excel‑Datei zu einer Folie hinzugefügt wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Fügen Sie einen OLE-Objektrahmen mit einer verknüpften Excel-Datei hinzu.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE‑Objektrahmen zugreifen**

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie es folgendermaßen finden bzw. darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse erstellen.  
2. Holen Sie sich die Referenz der Folie über deren Index.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/OleObjectFrame)‑Form zu.  
   In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die nur eine Form auf der ersten Folie enthält. Wir haben dieses Objekt dann als [IOleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioleobjectframe/) *gecastet*. Das war der gewünschte OLE‑Objektrahmen, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Vorgänge darauf ausführen.

Im nachfolgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) und dessen Dateidaten abgerufen.

```java 
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

### **Eigenschaften verknüpfter OLE‑Objektrahmen abrufen**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objektrahmen.

Der folgende Java‑Code zeigt, wie geprüft wird, ob ein OLE‑Objekt verknüpft ist, und wie anschließend der Pfad zur verknüpften Datei ermittelt wird:

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

{{% alert color="info" %}} 

In diesem Abschnitt verwendet das Code‑Beispiel [Aspose.Cells für Android via Java](/cells/androidjava/). 

{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie es auf folgende Weise zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse erstellen.  
2. Holen Sie sich die Referenz der Folie über deren Index.  
3. Greifen Sie auf die Form des OLE‑Objektrahmens zu.  
   In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die eine Form auf der ersten Folie enthält. Wir haben dieses Objekt dann als [IOleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioleobjectframe/) *gecastet*. Das war der gewünschte OLE‑Objektrahmen, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Vorgänge darauf ausführen.  
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einen Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im nachfolgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten so modifiziert, dass die Diagrammdaten aktualisiert werden.

```java 
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

    // OLE-Objektdaten als Workbook-Objekt einlesen.
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

Neben Excel‑Diagrammen ermöglicht Aspose.Slides für Android via Java das Einbetten weiterer Dateitypen in Folien. Sie können beispielsweise HTML-, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wird das eingefügte Objekt doppelt geklickt, öffnet es sich automatisch im entsprechenden Programm, oder der Benutzer wird aufgefordert, ein geeignetes Programm zur Öffnung auszuwählen.

Der folgende Java‑Code zeigt, wie HTML‑ und ZIP‑Dateien in eine Folie eingebettet werden:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

Beim Arbeiten mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu substituieren. Aspose.Slides für Android via Java erlaubt das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Rahmendaten oder dessen Erweiterung aktualisieren können.

Der folgende Java‑Code zeigt, wie der Dateityp für ein eingebettetes OLE‑Objekt auf `zip` gesetzt wird:

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

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau mit einem Symbolbild hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie das OLE‑Objekt öffnen oder darauf zugreifen. Möchten Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden, können Sie das Symbolbild und den Titel mit Aspose.Slides für Android via Java festlegen.

Der folgende Java‑Code zeigt, wie Symbolbild und Titel für ein eingebettetes Objekt gesetzt werden:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Bild zu den Präsentationsressourcen hinzufügen.
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

## **Verhindern, dass ein OLE‑Objektrahmen in Größe und Position verändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Links zu aktualisieren. Das Klicken auf „Links aktualisieren“ kann Größe und Position des OLE‑Objektrahmens ändern, weil PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Vorschau neu erstellt. Um zu verhindern, dass PowerPoint zur Aktualisierung auffordert, setzen Sie die `setUpdateAutomatic`‑Methode der [IOleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioleobjectframe/)‑Schnittstelle auf `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides für Android via Java ermöglicht das Extrahieren von Dateien, die in Folien als OLE‑Objekte eingebettet sind, wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Durchlaufen Sie alle Formen der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/oleobjectframe)‑Formen zu.  
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Objektrahmen zu und schreiben Sie sie auf die Festplatte.

Der folgende Java‑Code zeigt, wie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahiert werden:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

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

### Wird der OLE‑Inhalt beim Exportieren von Folien in PDF/Bilder gerendert?

Es wird nur das auf der Folie sichtbare Element gerendert – das Symbol/Ersetzungssymbol (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschau‑Bild festlegen, um das gewünschte Erscheinungsbild im exportierten PDF sicherzustellen.

### Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?

Sperren Sie die Form: Aspose.Slides bietet Sperren auf Form‑Ebene. Das ist keine Verschlüsselung, verhindert aber effektiv versehentliche Änderungen und Verschiebungen.

### Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild folgen Sie den Praktiken der [Working Solution for Worksheet Resizing](/slides/de/androidjava/working-solution-for-worksheet-resizing/): entweder den Rahmen an den Bereich anpassen oder den Bereich an einen festen Rahmen skalieren und ein geeignetes Ersetzungssymbol setzen.

### Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?

Im PPTX‑Format gibt es keine „relativen Pfad“-Informationen – nur den vollständigen Pfad. Relative Pfade finden sich im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/erreichbare URIs oder das Einbetten bevorzugen.