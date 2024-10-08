---
title: OLE verwalten
type: docs
weight: 40
url: /net/manage-ole/
keywords:
- OLE hinzufügen
- OLE einbetten
- ein Objekt hinzufügen
- ein Objekt einbetten
- eine Datei einbetten
- verknüpftes Objekt
- Objektverknüpfung und Einbettung
- OLE-Objekt
- PowerPoint 
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: Fügen Sie OLE-Objekte in PowerPoint-Präsentationen mit C# oder .NET hinzu
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) ist eine Microsoft-Technologie, die es ermöglicht, in einer Anwendung erstellte Daten und Objekte in einer anderen Anwendung durch Verknüpfung oder Einbettung zu platzieren.

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in einer PowerPoint-Folie platziert. Dieses Excel-Diagramm wird als OLE-Objekt betrachtet.

- Ein OLE-Objekt kann als Symbol erscheinen. In diesem Fall wird das Diagramm geöffnet, wenn Sie auf das Symbol doppelklicken, in der zugehörigen Anwendung (Excel), oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen.
- Ein OLE-Objekt kann tatsächlich Inhalte anzeigen – zum Beispiel die Inhalte eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammoberfläche wird geladen, und Sie können die Daten des Diagramms innerhalb der PowerPoint-App ändern.

[Aspose.Slides für .NET](https://products.aspose.com/slides/net/) ermöglicht es Ihnen, OLE-Objekte als OLE-Objektrahmen in Folien einzufügen ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Hinzufügen von OLE-Objektrahmen zu Folien**
Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten dieses Diagramm als OLE-Objektrahmen in eine Folie einbetten, indem Sie Aspose.Slides für .NET verwenden, dann können Sie es folgendermaßen tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie einen Verweis auf die Folie über ihren Index.
3. Öffnen Sie die Excel-Datei, die das Excel-Diagrammobjekt enthält, und speichern Sie sie in `MemoryStream`.
4. Fügen Sie den [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) zur Folie hinzu, indem Sie das Byte-Array und andere Informationen über das OLE-Objekt übergeben.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel-Datei als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) in eine Folie eingefügt, indem wir Aspose.Slides für .NET verwendet haben.  
**Hinweis:** Der [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo) Konstruktor benötigt als zweiten Parameter eine einbettbare Objekterweiterung. Diese Erweiterung ermöglicht es PowerPoint, den Datei- oder Objekttyp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE-Objekts auszuwählen.

``` csharp 
// Instanziiert die Presentation-Klasse, die die PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Lädt eine Excel-Datei in den Stream
    MemoryStream mstream = new MemoryStream();
    using (FileStream fs = new FileStream("book1.xlsx", FileMode.Open, FileAccess.Read))
    {
        byte[] buf = new byte[4096];

        while (true)
        {
            int bytesRead = fs.Read(buf, 0, buf.Length);
            if (bytesRead <= 0)
                break;
            mstream.Write(buf, 0, bytesRead);
        }
    }

    // Erstellt ein Datenobjekt für die Einbettung
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.ToArray(), "xlsx");

    // Fügt eine Ole Object Frame-Form hinzu
    IOleObjectFrame oleObjectFrame = sld.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width,
        pres.SlideSize.Size.Height, dataInfo);

    //Speichert die PPTX-Datei auf der Festplatte
    pres.Save("OleEmbed_out.pptx", SaveFormat.Pptx);
}
```
### Hinzufügen von verknüpften OLE-Objektrahmen

Aspose.Slides für .NET ermöglicht es Ihnen, einen [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) hinzuzufügen, ohne Daten einzubetten, sondern nur mit einem Link zur Datei.

Dieser C#-Code zeigt Ihnen, wie Sie einen [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) mit einer verknüpften Excel-Datei zu einer Folie hinzufügen:

``` csharp 
using (Presentation pres = new Presentation())
{
	// Greift auf die erste Folie zu
	ISlide slide = pres.Slides[0];

	// Fügt einen Ole Object Frame mit einer verknüpften Excel-Datei hinzu
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book1.xlsx");

	// Speichert die PPTX-Datei auf der Festplatte
	pres.Save("OleLinked_out.pptx", SaveFormat.Pptx);
}
```

## **Zugriff auf OLE-Objektrahmen**
Wenn ein OLE-Objekt bereits in einer Folie eingebettet ist, können Sie dieses Objekt einfach folgendermaßen finden oder darauf zugreifen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie den Verweis auf die Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) Form zu.
   In unserem Beispiel verwendeten wir die zuvor erstellte PPTX, die nur eine Form auf der ersten Folie hat. Wir haben dann dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) *cast*. Dies war der gewünschte OLE-Objektrahmen, auf den zugegriffen werden sollte.
4. Sobald der OLE-Objektrahmen zugänglich ist, können Sie jede Operation an ihm durchführen.
Im folgenden Beispiel wird ein OLE-Objektrahmen (ein in eine Folie eingebettetes Excel-Diagrammobjekt) zugegriffen, und die Dateidaten werden in eine Excel-Datei geschrieben:
``` csharp 
// Lädt die PPTX in ein Präsentationsobjekt
using (Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx"))
{
    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Castet die Form zu OleObjectFrame
    OleObjectFrame oleObjectFrame = sld.Shapes[0] as OleObjectFrame;

    // Liest das OLE-Objekt und schreibt es auf die Festplatte
    if (oleObjectFrame != null)
    {
        // Erhält die eingebetteten Dateidaten
        byte[] data = oleObjectFrame.EmbeddedData.EmbeddedFileData;

        // Erhält die eingebettete Dateierweiterung
        string fileExtension = oleObjectFrame.EmbeddedData.EmbeddedFileExtension;

        // Erstellt einen Pfad zum Speichern der extrahierten Datei
        string extractedPath = "excelFromOLE_out" + fileExtension;

        // Speichert die extrahierten Daten
        using (FileStream fstr = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))
        {
            fstr.Write(data, 0, data.Length);
        }
    }
}
```

### Zugriff auf die Eigenschaften von verknüpften OLE-Objektrahmen

Aspose.Slides ermöglicht Ihnen den Zugriff auf die Eigenschaften von verbundenen OLE-Objektrahmen.

Dieser C#-Code zeigt Ihnen, wie Sie überprüfen können, ob ein OLE-Objekt verknüpft ist, und dann den Pfad zur verknüpften Datei abrufen:
```csharp
using (Presentation pres = new Presentation("OleLinked.ppt"))
{
	// Greift auf die erste Folie zu
	ISlide slide = pres.Slides[0];

	// Erhält die erste Form als Ole Object Frame
	OleObjectFrame oleObjectFrame = slide.Shapes[0] as OleObjectFrame;

	// Überprüft, ob das Ole-Objekt verknüpft ist.
	if (oleObjectFrame != null && oleObjectFrame.IsObjectLink)
	{
		// Gibt den vollständigen Pfad zu einer verlinkten Datei aus
		Console.WriteLine("Ole Object Frame ist verknüpft mit: " + oleObjectFrame.LinkPathLong);

		// Gibt den relativen Pfad zu einer verlinkten Datei aus, falls vorhanden.
		// Nur die PPT-Präsentationen können den relativen Pfad enthalten.
		string relativePath = oleObjectFrame.LinkPathRelative;
		if (!string.IsNullOrEmpty(relativePath))
		{
			Console.WriteLine("Ole Object Frame relativer Pfad: " + oleObjectFrame.LinkPathRelative);
		}
	}
}
```
## **Ändern von OLE-Objektdaten**

Wenn ein OLE-Objekt bereits in einer Folie eingebettet ist, können Sie dieses Objekt einfach aufrufen und seine Daten folgendermaßen ändern:

1. Öffnen Sie die gewünschte Präsentation mit dem eingebetteten OLE-Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse erstellen.
2. Erhalten Sie den Verweis auf die Folie über ihren Index. 
3. Greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) Form zu.
   In unserem Beispiel verwendeten wir die zuvor erstellte PPTX, die eine Form auf der ersten Folie hat. Wir haben dann dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) *cast*. Dies war der gewünschte OLE-Objektrahmen, auf den zugegriffen werden sollte.
4. Sobald der OLE-Objektrahmen zugänglich ist, können Sie jede Operation an ihm durchführen.
5. Erstellen Sie das Workbook-Objekt und greifen Sie auf die OLE-Daten zu.
6. Greifen Sie auf das gewünschte Arbeitsblatt zu und ändern Sie die Daten.
7. Speichern Sie das aktualisierte Workbook in Streams.
8. Ändern Sie die OLE-Objektdaten aus den Stream-Daten.
Im folgenden Beispiel wird ein OLE-Objektrahmen (ein in eine Folie eingebettetes Excel-Diagrammobjekt) zugegriffen und dann werden seine Dateidaten geändert, um die Diagrammdaten zu ändern:
``` csharp 
using (Presentation pres = new Presentation("ChangeOLEObjectData.pptx"))
{
    ISlide slide = pres.Slides[0];

    OleObjectFrame ole = null;

    // Durchläuft alle Formen für Ole-Rahmen
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is OleObjectFrame)
        {
            ole = (OleObjectFrame)shape;
        }
    }

    if (ole != null)
    {
        using (MemoryStream msln = new MemoryStream(ole.EmbeddedData.EmbeddedFileData))
        {
            // Liest Objekt Daten im Workbook
            Workbook Wb = new Workbook(msln);

            using (MemoryStream msout = new MemoryStream())
            {
                // Modifiziert die Workbook-Daten
                Wb.Worksheets[0].Cells[0, 4].PutValue("E");
                Wb.Worksheets[0].Cells[1, 4].PutValue(12);
                Wb.Worksheets[0].Cells[2, 4].PutValue(14);
                Wb.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                Wb.Save(msout, so1);

                // Ändert die Ole-Rahmenobjektdaten
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.ToArray(), ole.EmbeddedData.EmbeddedFileExtension);
                ole.SetEmbeddedData(newData);
            }
        }
    }

    pres.Save("OleEdit_out.pptx", SaveFormat.Pptx);
}
```
## **Einbetten anderer Dateitypen in Folien**

Neben Excel-Diagrammen ermöglicht Aspose.Slides für .NET das Einbetten anderer Dateitypen in Folien. Zum Beispiel können Sie HTML-, PDF- und ZIP-Dateien als Objekte in eine Folie einfügen. Wenn ein Benutzer auf das eingefügte Objekt doppelklickt, wird das Objekt automatisch im relevanten Programm gestartet oder der Benutzer wird aufgefordert, ein entsprechendes Programm zum Öffnen des Objekts auszuwählen.

Dieser C#-Code zeigt Ihnen, wie Sie HTML und ZIP in eine Folie einbetten:

```c#
using (Presentation pres = new Presentation())
{
  ISlide slide = pres.Slides[0];
  
  byte[] htmlBytes = File.ReadAllBytes("embedOle.html");
  IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
  IOleObjectFrame oleFrameHtml = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
  oleFrameHtml.IsObjectIcon = true;

  byte[] zipBytes = File.ReadAllBytes("embedOle.zip");
  IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
  IOleObjectFrame oleFrameZip = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, dataInfoZip);
  oleFrameZip.IsObjectIcon = true;

  pres.Save("embeddedOle.pptx", SaveFormat.Pptx);
}
```
## **Festlegen von Dateitypen für eingebettete Objekte**

Bei der Arbeit an Präsentationen müssen Sie möglicherweise alte OLE-Objekte durch neue ersetzen. Oder Sie müssen ein nicht unterstütztes OLE-Objekt durch ein unterstütztes ersetzen.

Aspose.Slides für .NET ermöglicht es Ihnen, den Dateityp für ein eingebettetes Objekt festzulegen. Auf diese Weise können Sie die OLE-Rahmendaten oder ihre Erweiterung ändern.

Dieser C#-Code zeigt Ihnen, wie Sie den Dateityp für ein eingebettetes OLE-Objekt festlegen:

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    Console.WriteLine($"Aktuelle eingebettete Daten Erweiterung ist: {oleObjectFrame.EmbeddedData.EmbeddedFileExtension}");
   
    oleObjectFrame.SetEmbeddedData(new OleEmbeddedDataInfo(File.ReadAllBytes("embedOle.zip"), "zip"));
   
    pres.Save("embeddedChanged.pptx", SaveFormat.Pptx);
}
```
## **Festlegen von Symbolbildern und Titeln für eingebettete Objekte**

Nachdem Sie ein OLE-Objekt eingebettet haben, wird automatisch eine Vorschau mit einem Symbolbild und einem Titel hinzugefügt. Die Vorschau ist das, was Benutzer sehen, bevor sie auf das OLE-Objekt zugreifen oder es öffnen.

Wenn Sie ein bestimmtes Bild und einen bestimmten Text als Elemente in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides für .NET festlegen.

Dieser C#-Code zeigt Ihnen, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen: 

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];

    IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    oleObjectFrame.SubstitutePictureTitle = "Mein Titel";
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleObjectFrame.IsObjectIcon = false;

    pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

## **Verhindern, dass ein OLE-Objektrahmen geändert oder repositioniert wird**

Nachdem Sie ein verknüpftes OLE-Objekt zu einer Präsentationsfolie hinzugefügt haben, sehen Sie möglicherweise eine Nachricht, die Sie auffordert, die Links zu aktualisieren, wenn Sie die Präsentation in PowerPoint öffnen. Ein Klick auf die Schaltfläche "Links aktualisieren" kann die Größe und Position des OLE-Objektrahmens ändern, da PowerPoint die Daten aus dem verknüpften OLE-Objekt aktualisiert und die Objektvorschau auffrischt. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten aufgefordert wird, setzen Sie die `UpdateAutomatic`-Eigenschaft des [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) Interfaces auf `false`:

```cs
oleObjectFrame.UpdateAutomatic = false;
```

## **Extrahieren von eingebetteten Dateien**

Aspose.Slides für .NET erlaubt es Ihnen, die in Folien als OLE-Objekte eingebetteten Dateien folgendermaßen zu extrahieren:
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die das OLE-Objekt enthält, das Sie extrahieren möchten.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) Form zu.
3. Greifen Sie auf die Daten der eingebetteten Datei aus dem OLE-Objektrahmen zu und schreiben Sie sie auf die Festplatte. 
Dieser C#-Code zeigt Ihnen, wie Sie eine in einer Folie als OLE-Objekt eingebettete Datei extrahieren:
```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];

    for (var index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;
        
        if (oleFrame != null)
        {
            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
            
            File.WriteAllBytes($"oleFrame{index}{extension}", data);
        }
    }
}
```