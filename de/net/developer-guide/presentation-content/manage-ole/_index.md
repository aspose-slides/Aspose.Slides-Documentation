---
title: Verwalten von OLE-Objekten in Präsentationen in .NET
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/net/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung und -Einbettung
- OLE hinzufügen
- OLE einbetten
- Objekt hinzufügen
- Objekt einbetten
- Datei hinzufügen
- Datei einbettern
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

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, mit der Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung platziert werden können. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in einer PowerPoint‑Folie platziert. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird beim Doppelklick auf das Symbol das Diagramm in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen, und Sie können die Diagrammdaten innerhalb von PowerPoint ändern.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **OLE‑Objektrahmen zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mit Aspose.Slides for .NET als OLE‑Objektrahmen in eine Folie einbetten, dann gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Lesen Sie die Excel‑Datei als Byte‑Array.  
4. Fügen Sie der Folie das [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) mit dem Byte‑Array und weiteren Informationen zum OLE‑Objekt hinzu.  
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) in eine Folie eingefügt, wobei Aspose.Slides for .NET verwendet wurde.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) nimmt als zweiten Parameter eine Dateierweiterung des einbettbaren Objekts entgegen. Diese Erweiterung ermöglicht PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen des OLE‑Objekts auszuwählen.  
```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Daten für das OLE-Objekt vorbereiten.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // OLE-Objektrahmen zur Folie hinzufügen.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


### **Verknüpfte OLE‑Objektrahmen hinzufügen**

Aspose.Slides for .NET ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) ohne eingebettete Daten, sondern nur mit einem Link zur Datei.

Dieser C#‑Code zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) mit einer verknüpften Excel‑Datei zu einer Folie hinzugefügt wird:  
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // OLE-Objektrahmen mit verknüpfter Excel-Datei hinzufügen.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Zugriff auf OLE‑Objektrahmen**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf folgende Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erstellen.  
2. Holen Sie die Referenz der Folie über deren Index.  
3. Greifen Sie auf die Form [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu.  
   In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die nur eine Form auf der ersten Folie enthält. Wir haben dieses Objekt dann als [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) *gecastet*. Dies war der gewünschte OLE‑Objektrahmen, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Operationen darauf ausführen.

Im folgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) und dessen Dateidaten abgerufen.  
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Das erste Shape als OLE-Objektrahmen holen.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Eingebettete Dateidaten holen.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Die Erweiterung der eingebetteten Datei holen.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **Eigenschaften verknüpfter OLE‑Objektrahmen abrufen**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objektrahmen.

Dieser C#‑Code zeigt, wie geprüft wird, ob ein OLE‑Objekt verknüpft ist, und wie der Pfad zur verknüpften Datei ermittelt wird:  
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Das erste Shape als OLE-Objektrahmen holen.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Prüfen, ob das OLE-Objekt verknüpft ist.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Den vollständigen Pfad zur verknüpften Datei ausgeben.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Den relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
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

In diesem Abschnitt verwendet das untenstehende Codebeispiel [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie das Objekt auf folgende Weise zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erstellen.  
2. Holen Sie die Referenz der Folie über deren Index.  
3. Greifen Sie auf die Form [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu.  
   In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die eine Form auf der ersten Folie enthält. Wir haben dieses Objekt dann als [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) *gecastet*. Dies war der gewünschte OLE‑Objektrahmen, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Operationen darauf ausführen.  
5. Erzeugen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im folgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten werden geändert, um die Diagrammdaten zu aktualisieren.  
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Das erste Shape als OLE-Objektrahmen holen.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // OLE-Objektdaten als Workbook-Objekt lesen.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Workbook-Daten ändern.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // OLE-Objektrahmen-Daten ändern.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for .NET das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im entsprechenden Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.

Dieser C#‑Code zeigt, wie HTML‑ und ZIP‑Dateien in eine Folie eingebettet werden:  
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


## **Dateitypen für eingebettete Objekte festlegen**

Beim Arbeiten mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for .NET ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Rahmendaten oder deren Erweiterung aktualisieren können.

Dieser C#‑Code zeigt, wie der Dateityp für ein eingebettetes OLE‑Objekt auf `zip` gesetzt wird:  
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

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau bestehend aus einem Symbolbild hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie das OLE‑Objekt öffnen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for .NET festlegen.

Dieser C#‑Code zeigt, wie das Symbolbild und der Titel für ein eingebettetes Objekt gesetzt werden:  
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Ein Bild zu den Präsentationsressourcen hinzufügen.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Einen Titel und das Bild für die OLE-Vorschau festlegen.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Verhindern, dass ein OLE‑Objektrahmen in Größe und Position geändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Durch Klicken auf „Links aktualisieren“ kann die Größe und Position des OLE‑Objektrahmens geändert werden, weil PowerPoint die Daten aus dem verknüpften OLE‑Objekt aktualisiert und die Vorschau neu erstellt. Um zu verhindern, dass PowerPoint auffordert, die Daten des Objekts zu aktualisieren, setzen Sie die `UpdateAutomatic`‑Eigenschaft des [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) Interfaces auf `false`:  
```cs
oleFrame.UpdateAutomatic = false;
```


## **Eingebettete Dateien extrahieren**

Aspose.Slides for .NET ermöglicht das Extrahieren der in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Durchlaufen Sie alle Formen der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑Formen zu.  
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Objektrahmen zu und schreiben Sie sie auf die Festplatte.

Dieser C#‑Code zeigt, wie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahiert werden:  
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

**Wird der OLE‑Inhalt beim Export von Folien zu PDF/Bildern gerendert?**

Es wird das auf der Folie sichtbare Element gerendert – das Symbol/Ersetzungssymbol (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschaubild festlegen, um das erwartete Aussehen im exportierten PDF zu gewährleisten.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [Form‑Sperren auf Ebene der Form](/slides/de/net/applying-protection-to-presentation/). Dies ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Bewegungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert die Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild folgen Sie den Praktiken der [Lösungsansätze für die Größenanpassung von Arbeitsblättern](/slides/de/net/working-solution-for-worksheet-resizing/) – entweder den Rahmen an den Bereich anpassen oder den Bereich an einen festen Rahmen skalieren und ein geeignetes Ersatzbild festlegen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format gibt es keine Informationen zu „relativen Pfaden“ – nur den vollständigen Pfad. Relative Pfade finden sich im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/erreichbare URIs oder das Einbetten bevorzugen.  