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
## **Einführung**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren. 
{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird anschließend in einer PowerPoint‑Folie platziert. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen, und Sie können die Diagrammdaten innerhalb von PowerPoint ändern. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/de/net/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe)).

## **OLE‑Objektrahmen zu Folien hinzufügen**

Vorausgesetzt, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mit Aspose.Slides for .NET als OLE‑Objektrahmen in einer Folie einbetten, können Sie dies folgendermaßen tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Lesen Sie die Excel‑Datei als Byte‑Array.
4. Fügen Sie dem Folienobjekt das [OleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe) hinzu, das das Byte‑Array und weitere Informationen zum OLE‑Objekt enthält.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei mittels Aspose.Slides for .NET als [OleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe) zu einer Folie hinzugefügt.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/de/net/aspose.slides.dom.ole/oleembeddeddatainfo/) erwartet als zweiten Parameter eine Erweiterung des einbettbaren Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Daten für das OLE-Objekt vorbereiten.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Den OLE-Objektrahmen zur Folie hinzufügen.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Verknüpfte OLE‑Objektrahmen hinzufügen**

Aspose.Slides for .NET ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe) ohne Einbetten von Daten, sondern nur mit einem Link zur Datei.

Dieser C#‑Code zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe) mit einer verknüpften Excel‑Datei zu einer Folie hinzugefügt wird:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // OLE-Objektrahmen mit verknüpfter Excel-Datei hinzufügen.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Zugriff auf OLE‑Objektrahmen**

Falls ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf diese Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse erstellen.
2. Holen Sie die Referenz der Folie über deren Index.
3. Greifen Sie auf das [OleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe)‑Shape zu.  
   In unserem Beispiel verwendeten wir die zuvor erstellte PPTX, die auf der ersten Folie nur ein Shape enthält. Anschließend *casten* wir dieses Objekt zu einem [IOleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ioleobjectframe). Dies war der gewünschte OLE‑Objektrahmen, auf den zugegriffen werden sollte.
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Operationen darauf ausführen.

Im nachfolgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) sowie dessen Dateidaten geöffnet.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Erhalte das erste Shape als OLE-Objektrahmen.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Erhalte die eingebetteten Dateidaten.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Erhalte die Erweiterung der eingebetteten Datei.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Eigenschaften verknüpfter OLE‑Objektrahmen abrufen**

Aspose.Slides ermöglicht den Zugriff auf die Eigenschaften verknüpfter OLE‑Objektrahmen.

Dieser C#‑Code zeigt, wie geprüft wird, ob ein OLE‑Objekt verknüpft ist, und wie anschließend der Pfad zur verknüpften Datei ermittelt wird:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Das erste Shape als OLE-Objektrahmen erhalten.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Prüfen, ob das OLE-Objekt verknüpft ist.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Gibt den vollständigen Pfad zur verknüpften Datei aus.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Gibt den relativen Pfad zur verknüpften Datei aus, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE‑Objektdaten ändern**

{{% alert color="info" %}} 
Im diesem Abschnitt verwendet das nachstehende Codebeispiel [Aspose.Cells for .NET](/cells/net/). 
{{% /alert %}}

Falls ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie das Objekt auf diese Weise leicht zugreifen und seine Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse erstellen.
2. Holen Sie die Referenz der Folie über deren Index.
3. Greifen Sie auf das [OLEObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe)‑Shape zu.  
   In unserem Beispiel verwendeten wir die zuvor erstellte PPTX, die auf der ersten Folie ein Shape enthält. Anschließend *casten* wir dieses Objekt zu einem [IOleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ioleobjectframe). Dies war der gewünschte OLE‑Objektrahmen, auf den zugegriffen werden sollte.
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Operationen darauf ausführen.
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.
6. Greifen Sie das gewünschte `Worksheet` an und ändern Sie die Daten.
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im nachfolgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) geöffnet, und dessen Dateidaten werden geändert, um die Diagrammdaten zu aktualisieren.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Das erste Shape als OLE-Objektrahmen erhalten.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Die OLE-Objektdaten als Workbook-Objekt lesen.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Die Workbook-Daten ändern.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Die OLE-Rahmen-Objektdaten ändern.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for .NET das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML-, PDF- und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im jeweiligen Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.

Dieser C#‑Code zeigt, wie HTML und ZIP in eine Folie eingebettet werden:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

Bei der Arbeit mit Präsentationen müssen Sie möglicherweise alte OLE‑Objekte durch neue ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes austauschen. Aspose.Slides for .NET ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Rahmendaten oder deren Erweiterung aktualisieren können.

Dieser C#‑Code zeigt, wie der Dateityp für ein eingebettetes OLE‑Objekt auf `zip` festgelegt wird:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau bestehend aus einem Symbolbild hinzugefügt. Diese Vorschau sehen Benutzer, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for .NET festlegen.

Dieser C#‑Code zeigt, wie das Symbolbild und der Titel für ein eingebettetes Objekt festgelegt werden: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Verhindern, dass ein OLE‑Objektrahmen in Größe und Position geändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Das Klicken auf die Schaltfläche „Links aktualisieren“ kann die Größe und Position des OLE‑Objektrahmens ändern, weil PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Objektvorschau neu rendert. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, setzen Sie die Eigenschaft `UpdateAutomatic` der [IOleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ioleobjectframe/) Schnittstelle auf `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Größe und Position des OLE-Objektrahmens beibehalten, wenn PowerPoint den Link aktualisiert.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides for .NET ermöglicht das Extrahieren der in Folien als OLE‑Objekte eingebetteten Dateien auf folgende Weise:
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.
2. Durchlaufen Sie alle Shapes in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/oleobjectframe)‑Shapes zu.
3. Greifen Sie auf die Daten eingebetteter Dateien aus OLE‑Objektrahmen zu und schreiben Sie sie auf die Festplatte.

Dieser C#‑Code zeigt, wie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahiert werden:

```c#
using Aspose.Slides;

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

### Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?

Es wird das auf der Folie Sichtbare gerendert – das Symbol/Ersatzbild (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Falls nötig, setzen Sie ein eigenes Vorschaubild, um das erwartete Erscheinungsbild im exportierten PDF sicherzustellen.

### Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?

Sperren Sie das Shape: Aspose.Slides stellt [Shape‑Ebene‑Sperren](/slides/de/net/applying-protection-to-presentation/) bereit. Dies ist keine Verschlüsselung, verhindert aber effektiv versehentliche Bearbeitungen und Verschiebungen.

### Warum springt ein verknüpftes Excel‑Objekt oder ändert die Größe, wenn ich die Präsentation öffne?

PowerPoint kann die Vorschau des verknüpften OLE aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die Praktiken aus der [Lösung für Arbeitsblatt‑Größenanpassung](/slides/de/net/working-solution-for-worksheet-resizing/) befolgen – entweder den Rahmen an den Bereich anpassen oder den Bereich an einen festen Rahmen skalieren und ein passendes Ersatzbild festlegen.

### Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format erhalten bleiben?

Im PPTX‑Format sind Informationen zu „relativen Pfaden“ nicht vorhanden – es wird nur der vollständige Pfad gespeichert. Relative Pfade existieren im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade bzw. zugängliche URIs oder das Einbetten bevorzugen.