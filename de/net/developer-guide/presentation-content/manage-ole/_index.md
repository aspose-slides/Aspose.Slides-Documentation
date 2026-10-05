---
title: OLE-Objekte in Präsentationen in .NET verwalten
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
- Verknüpftes Objekt
- Verknüpfte Datei
- OLE ändern
- OLE Symbol
- OLE Titel
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
## **Einleitung**

{{% alert color="info" title="Hinweis" %}}

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird anschließend in einer PowerPoint‑Folien eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall öffnet ein Doppelklick auf das Symbol das Diagramm in der zugehörigen Anwendung (Excel) bzw. werden Sie aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle geladen und Sie können die Diagrammdaten direkt in PowerPoint bearbeiten.

[Aspose.Slides für .NET](https://products.aspose.com/slides/net/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **OLE‑Objektrahmen zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mit Aspose.Slides für .NET als OLE‑Objektrahmen in eine Folie einbetten, dann können Sie dies wie folgt tun:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
3. Lesen Sie die Excel‑Datei als Byte‑Array ein.  
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) der Folie hinzu, das das Byte‑Array und weitere Informationen zum OLE‑Objekt enthält.  
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei mithilfe von Aspose.Slides für .NET als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zu einer Folie hinzugefügt.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) akzeptiert als zweiten Parameter eine Erweiterung des eingebetteten Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.

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

    // OLE-Objektrahmen zur Folie hinzufügen.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Verknüpfte OLE‑Objektrahmen hinzufügen**

Aspose.Slides für .NET ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) ohne Einbetten von Daten, sondern nur mit einem Link zur Datei.

Dieser C#‑Code zeigt, wie man ein [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügt:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // OLE-Objektrahmen mit einer verknüpften Excel-Datei hinzufügen.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Zugriff auf OLE‑Objektrahmen**

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie es auf folgende Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erstellen.  
2. Holen Sie die Referenz der Folie über ihren Index.  
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) Form zu.  
   In unserem Beispiel verwendeten wir die zuvor erstellte PPTX, die nur eine Form auf der ersten Folie enthält. Wir *casten* dieses Objekt anschließend zu einem [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Dies war der gewünschte OLE‑Objektrahmen, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Operationen darauf ausführen.

Im nachfolgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) sowie dessen Dateidaten abgerufen.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Die erste Form als OLE-Objektrahmen erhalten.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Die eingebetteten Dateidaten erhalten.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Die Erweiterung der eingebetteten Datei erhalten.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Eigenschaften verknüpfter OLE‑Objektrahmen abrufen**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objektrahmen.

Dieser C#‑Code zeigt, wie man prüft, ob ein OLE‑Objekt verknüpft ist und anschließend den Pfad zur verknüpften Datei ermittelt:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Die erste Form als OLE-Objektrahmen erhalten.
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

{{% alert color="info" title="Hinweis" %}}

In diesem Abschnitt verwendet das nachstehende Code‑Beispiel [Aspose.Cells für .NET](https://docs.aspose.com/cells/net/).

{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie es auf folgende Weise leicht zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erzeugen.  
2. Holen Sie die Referenz der Folie über ihren Index.  
3. Greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) Form zu.  
   In unserem Beispiel nutzten wir die zuvor erstellte PPTX, die eine Form auf der ersten Folie enthält. Wir *casten* dieses Objekt anschließend zu einem [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Dies war der gewünschte OLE‑Objektrahmen, auf den zugegriffen werden sollte.  
4. Sobald der OLE‑Objektrahmen zugänglich ist, können Sie beliebige Operationen darauf ausführen.  
5. Erzeugen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im nachfolgenden Beispiel wird ein OLE‑Objektrahmen (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten werden geändert, um die Diagrammdaten zu aktualisieren.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Die erste Form als OLE-Objektrahmen erhalten.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Die OLE-Objektdaten als Workbook-Objekt lesen.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Die Arbeitsmappendaten ändern.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Die OLE-Rahmenobjektdaten ändern.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides für .NET das Einbetten anderer Dateitypen in Folien. Beispielsweise können HTML‑, PDF‑ und ZIP‑Dateien als Objekte eingefügt werden. Wird das eingefügte Objekt von einem Benutzer doppelt angeklickt, öffnet es sich automatisch im entsprechenden Programm, bzw. der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.

Dieser C#‑Code zeigt, wie HTML‑ und ZIP‑Dateien in eine Folie eingebettet werden:

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

Bei der Arbeit mit Präsentationen kann es erforderlich sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides für .NET ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass die OLE‑Rahmendaten bzw. deren Erweiterung aktualisiert werden können.

Dieser C#‑Code zeigt, wie der Dateityp eines eingebetteten OLE‑Objekts auf `zip` gesetzt wird:

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

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau in Form eines Symbolbildes hinzugefügt. Diese Vorschau sehen Benutzer, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Möchten Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden, können Sie das Symbolbild und den Titel mit Aspose.Slides für .NET festlegen.

Dieser C#‑Code zeigt, wie das Symbolbild und der Titel für ein eingebettetes Objekt festgelegt werden: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Verhindern, dass ein OLE‑Objektrahmen in Größe und Position verändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Ein Klick auf die Schaltfläche „Update Links“ kann die Größe und Position des OLE‑Objektrahmens ändern, weil PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Objektvorschau neu lädt. Um zu verhindern, dass PowerPoint zum Aktualisieren der Objektdaten auffordert, setzen Sie die Eigenschaft `UpdateAutomatic` des [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/)‑Interfaces auf `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Größe und Position des OLE-Objektrahmens beibehalten, wenn PowerPoint die Verknüpfung aktualisiert.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides für .NET ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien auf folgende Weise:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)‑Formen zu.  
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Objektrahmen zu und schreiben Sie sie auf die Festplatte.

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

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**

Was auf der Folie sichtbar ist, wird gerendert – das Symbol bzw. Ersatzbild (Vorschau). Der „Live“-OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschau‑Bild festlegen, um das erwartete Erscheinungsbild im exportierten PDF zu gewährleisten.

Um die eingebettete Datei zusätzlich als PDF‑Anhang zu erhalten, setzen Sie [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) auf `true`. Diese Option ist standardmäßig deaktiviert. Ein Beispiel und Anweisungen zum Überprüfen des Anhangs finden Sie unter [Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten](/slides/de/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [Form‑Sperren](/slides/de/net/applying-protection-to-presentation/). Das ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und das Verschieben.

**Warum springt ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die Praktiken der [Lösung für die Größenanpassung von Arbeitsblättern](/slides/de/net/working-solution-for-worksheet-resizing/) befolgen – entweder den Rahmen an den Bereich anpassen oder den Bereich an einen festen Rahmen skalieren und ein geeignetes Ersatzbild festlegen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

In PPTX sind Informationen zu „relativen Pfaden“ nicht verfügbar – nur der vollständige Pfad. Relative Pfade gibt es im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.