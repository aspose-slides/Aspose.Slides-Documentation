---
title: Verwalten von OLE-Objekten in Präsentationen in .NET
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/net/manage-ole/
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
- .NET
- C#
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für .NET. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren Sie sie und exportieren Sie sie."
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird anschließend in eine PowerPoint‑Folie eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen bzw. Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle geladen und Sie können die Diagrammdaten direkt in PowerPoint ändern.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **OLE‑Objekt‑Frames zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es als OLE‑Objekt‑Frame in einer Folie mit Aspose.Slides for .NET einbetten, so gehen Sie vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
2. Holen Sie sich über den Index einen Referenz auf die Folie.  
3. Lesen Sie die Excel‑Datei als Byte‑Array.  
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zur Folie hinzu und übergeben Sie das Byte‑Array sowie weitere Informationen zum OLE‑Objekt.  
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie hinzugefügt – mithilfe von Aspose.Slides for .NET.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) nimmt als zweiten Parameter eine Dateierweiterung des einbettbaren Objekts entgegen. Diese Erweiterung ermöglicht PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.  
```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Daten für das OLE-Objekt vorbereiten.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // OLE-Objekt-Frame zur Folie hinzufügen.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


### **Verknüpfte OLE‑Objekt‑Frames hinzufügen**

Aspose.Slides for .NET ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) ohne Einbetten von Daten, sondern nur mit einem Link zur Datei.

Der nachstehende C#‑Code zeigt, wie Sie einem [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügen:
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // OLE-Objekt-Frame mit verknüpfter Excel-Datei hinzufügen.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Zugriff auf OLE‑Objekt‑Frames**

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie es wie folgt finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erstellen.  
2. Holen Sie sich die Referenz der Folie über deren Index.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑Form zu.  
   In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die nur eine Form auf der ersten Folie enthält. Wir haben dieses Objekt anschließend als [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) gecastet. Dies war das gewünschte OLE‑Objekt‑Frame.  
4. Sobald das OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.

Im nachstehenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) und dessen Dateidaten abgerufen.  
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Erste Form als OLE-Objekt-Frame abrufen.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Eingebettete Dateidaten abrufen.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Erweiterung der eingebetteten Datei abrufen.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **Eigenschaften von verknüpften OLE‑Objekt‑Frames abrufen**

Aspose.Slides ermöglicht das Abrufen von Eigenschaften verknüpfter OLE‑Objekt‑Frames.

Der folgende C#‑Code zeigt, wie Sie prüfen, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermitteln:
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Erste Form als OLE-Objekt-Frame abrufen.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Prüfen, ob das OLE-Objekt verknüpft ist.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Vollständigen Pfad zur verknüpften Datei ausgeben.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **OLE‑Objektdaten ändern**

{{% alert color="primary" %}} 

In diesem Abschnitt verwendet das Code‑Beispiel [Aspose.Cells for .NET](/cells/net/). 

{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie das Objekt auf folgende Weise leicht zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erstellen.  
2. Holen Sie sich die Referenz der Folie über deren Index.  
3. Greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑Form zu.  
   In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die eine Form auf der ersten Folie enthält. Wir haben dieses Objekt anschließend als [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) gecastet. Dies war das gewünschte OLE‑Objekt‑Frame.  
4. Sobald das OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  
5. Erzeugen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im nachstehenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten geändert, um die Diagrammdaten zu aktualisieren.  
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Erhalte die erste Form als OLE-Objekt-Frame.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Lese die OLE-Objektdaten als Workbook-Objekt.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Ändere die Arbeitsblattdaten.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Ändere die OLE-Frame-Objektdaten.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for .NET das Einbetten anderer Dateitypen in Folien. Sie können beispielsweise HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im jeweiligen Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.

Der folgende C#‑Code zeigt, wie Sie HTML und ZIP in eine Folie einbetten:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Dateityp für eingebettete Objekte festlegen**

Bei der Arbeit mit Präsentationen kann es erforderlich sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for .NET erlaubt das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder deren Erweiterung aktualisieren können.

Der folgende C#‑Code zeigt, wie Sie den Dateityp für ein eingebettetes OLE‑Objekt auf `zip` setzen:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Dateityp zu ZIP ändern.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau mit einem Symbolbild erstellt. Diese Vorschau ist das, was Benutzer sehen, bevor sie das OLE‑Objekt öffnen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for .NET festlegen.

Der folgende C#‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Füge ein Bild zu den Präsentationsressourcen hinzu.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Setze einen Titel und das Bild für die OLE-Vorschau.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Verhindern, dass ein OLE‑Objekt‑Frame skaliert und neu positioniert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Das Klicken auf „Links aktualisieren“ kann die Größe und Position des OLE‑Objekt‑Frames ändern, weil PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Vorschau neu rendert. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, setzen Sie die Eigenschaft `UpdateAutomatic` des [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/)‑Interfaces auf `false`:
```cs
oleFrame.UpdateAutomatic = false;
```


## **Eingebettete Dateien extrahieren**

Aspose.Slides for .NET erlaubt das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:
1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑Formen zu.  
3. Greifen Sie auf die Daten eingebetteter Dateien aus den OLE‑ObjectFrames zu und schreiben Sie sie auf die Festplatte.

Der folgende C#‑Code zeigt, wie Sie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahieren:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```


## **FAQ**

**Werden OLE‑Inhalte beim Export von Folien in PDF/Bilder gerendert?**

Es wird das, was auf der Folie sichtbar ist, gerendert – das Symbol bzw. das Ersatzbild (Vorschau). Der „live“ OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschau‑Bild festlegen, um das gewünschte Aussehen im exportierten PDF sicherzustellen.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [Form‑Ebene‑Sperren](/slides/de/net/applying-protection-to-presentation/). Das ist keine Verschlüsselung, verhindert aber effektiv versehentliche Änderungen und Verschiebungen.

**Warum springt ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild folgen Sie den bewährten Methoden der [Working Solution for Worksheet Resizing](/slides/de/net/working-solution-for-worksheet-resizing/) – entweder den Frame an den Bereich anpassen oder den Bereich auf einen festen Frame skalieren und ein geeignetes Ersatzbild setzen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format gibt es keine Informationen zu „relativen Pfaden“ – nur den absoluten Pfad. Relative Pfade existieren im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.