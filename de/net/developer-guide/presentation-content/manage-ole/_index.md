---
title: OLE in Präsentationen mit C# verwalten
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
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für .NET. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren und exportieren Sie sie."
---

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, mit der Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung platziert werden können. 
{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird anschließend in einer PowerPoint‑Folie platziert. Dieses Excel‑Diagramm wird als OLE‑Objekt betrachtet. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder es wird aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, beispielsweise den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Hinzufügen von OLE‑Objekt‑Frames zu Folien**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mithilfe von Aspose.Slides for .NET als OLE‑Objekt‑Frame in einer Folie einbetten, so können Sie vorgehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Lesen Sie die Excel‑Datei als Byte‑Array.  
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zur Folie hinzu und übergeben dabei das Byte‑Array sowie weitere Informationen zum OLE‑Objekt.  
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei mithilfe von Aspose.Slides for .NET als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie hinzugefügt.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) akzeptiert als zweiten Parameter eine Erweiterung des einbettbaren Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen dieses OLE‑Objekts zu wählen.  
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


### **Hinzufügen verknüpfter OLE‑Objekt‑Frames**

Aspose.Slides for .NET ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) ohne Einbetten von Daten, sondern nur mit einem Link zur Datei.  

Dieser C#‑Code zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) mit einer verknüpften Excel‑Datei zu einer Folie hinzugefügt wird:  
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

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie es folgendermaßen leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erstellen.  
2. Holen Sie die Referenz der Folie über ihren Index.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑Form zu.  
   In unserem Beispiel haben wir das zuvor erstellte PPTX verwendet, das auf der ersten Folie nur eine Form enthält. Wir haben dieses Objekt anschließend *gecastet* zu einem [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Das war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) und dessen Dateidaten abgerufen.  
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Erhalte die erste Form als OLE-Objekt-Frame.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Erhalte die eingebetteten Dateidaten.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Erhalte die Dateierweiterung der eingebetteten Datei.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **Zugriff auf Eigenschaften verknüpfter OLE‑Objekt‑Frames**

Aspose.Slides ermöglicht den Zugriff auf die Eigenschaften verknüpfter OLE‑Objekt‑Frames.  

Dieser C#‑Code zeigt, wie geprüft wird, ob ein OLE‑Objekt verknüpft ist, und wie anschließend der Pfad zur verknüpften Datei ermittelt wird:  
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Erhalte die erste Form als OLE-Objekt-Frame.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Prüfe, ob das OLE-Objekt verknüpft ist.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Gib den vollständigen Pfad zur verknüpften Datei aus.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Gib den relativen Pfad zur verknüpften Datei aus, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **Ändern von OLE‑Objektdaten**

{{% alert color="primary" %}} 
In diesem Abschnitt verwendet das untenstehende Code‑Beispiel [Aspose.Cells for .NET](/cells/net/).  
{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie dieses Objekt auf diese Weise leicht zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erstellen.  
2. Holen Sie die Referenz der Folie über ihren Index.  
3. Greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑Form zu.  
   In unserem Beispiel haben wir das zuvor erstellte PPTX verwendet, das auf der ersten Folie eine Form enthält. Wir haben dieses Objekt anschließend *gecastet* zu einem [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Das war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.  
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einen Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.  

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten geändert, um die Diagrammdaten zu aktualisieren.  
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
                // Ändere die Arbeitsmappendaten.
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


## **Einbetten anderer Dateitypen in Folien**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for .NET das Einbetten weiterer Dateitypen in Folien. Beispielsweise können Sie HTML-, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im entsprechenden Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.  

Dieser C#‑Code zeigt, wie HTML und ZIP in eine Folie eingebettet werden:  
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


## **Festlegen von Dateitypen für eingebettete Objekte**

Beim Arbeiten mit Präsentationen kann es erforderlich sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for .NET ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder dessen Erweiterung aktualisieren können.  

Dieser C#‑Code zeigt, wie der Dateityp für ein eingebettetes OLE‑Objekt auf `zip` gesetzt wird:  
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Dateityp auf ZIP ändern.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Festlegen von Symbolbildern und Titeln für eingebettete Objekte**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau in Form eines Symbolbildes hinzugefügt. Diese Vorschau sehen die Benutzer, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Möchten Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden, können Sie das Symbolbild und den Titel mit Aspose.Slides for .NET festlegen.  

Dieser C#‑Code zeigt, wie das Symbolbild und der Titel für ein eingebettetes Objekt festgelegt werden:  
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Bild zu den Präsentationsressourcen hinzufügen.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Titel und Bild für die OLE-Vorschau festlegen.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Verhindern, dass ein OLE‑Objekt‑Frame skaliert und neu positioniert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Das Klicken auf die Schaltfläche „Links aktualisieren“ kann die Größe und Position des OLE‑Objekt‑Frames ändern, da PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Objektvorschau neu erstellt. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, setzen Sie die Eigenschaft `UpdateAutomatic` der Schnittstelle [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) auf `false`:  
```cs
oleFrame.UpdateAutomatic = false;
```


## **Extrahieren eingebetteter Dateien**

Aspose.Slides for .NET ermöglicht das Extrahieren von in Folien eingebetteten Dateien als OLE‑Objekte folgendermaßen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑Formen zu.  
3. Greifen Sie auf die Daten der eingebetteten Dateien aus OLE‑Object‑Frames zu und schreiben Sie sie auf die Festplatte.  

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

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**

Es wird das auf der Folie sichtbare Element gerendert – das Symbol/Ersetzungsbild (Vorschau). Der „live“ OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschau­bild festlegen, um das erwartete Erscheinungsbild im exportierten PDF zu gewährleisten.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [Form‑Ebene‑Sperren](/slides/de/net/applying-protection-to-presentation/). Dies ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Bewegungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie den Empfehlungen der [Working Solution for Worksheet Resizing](/slides/de/net/working-solution-for-worksheet-resizing/) folgen – entweder den Rahmen an den Bereich anpassen oder den Bereich auf einen festen Rahmen skalieren und ein geeignetes Ersetzungsbild festlegen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format sind Informationen zu „relativen Pfaden“ nicht verfügbar – nur der vollständige Pfad. Relative Pfade existieren im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/erreichbare URIs oder das Einbetten bevorzugen.