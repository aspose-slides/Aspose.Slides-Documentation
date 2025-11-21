---
title: Optimieren der Bildverwaltung in Präsentationen in .NET
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/net/image/
keywords:
- Bild hinzufügen
- Grafik hinzufügen
- Bitmap hinzufügen
- Bild ersetzen
- Grafik ersetzen
- aus dem Web
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Vereinfachen Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für .NET, optimieren Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---

## **Bilder in Folien in Präsentationen**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Quellen in Folien einfügen. Ähnlich ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien in Ihren Präsentationen über verschiedene Verfahren.

{{% alert  title="Tip" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten – insbesondere wenn Sie planen, Standardformatierungsoptionen zu verwenden, um die Größe zu ändern, Effekte hinzuzufügen usw. – lesen Sie [Picture Frame](https://docs.aspose.com/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Sie können Ein‑ und Ausgabeoperationen mit Bildern und PowerPoint‑Präsentationen manipulieren, um ein Bild von einem Format in ein anderes zu konvertieren. Siehe diese Seiten: Bild nach JPG konvertieren [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); JPG nach Bild konvertieren [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); JPG nach PNG konvertieren [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), PNG nach JPG konvertieren [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); PNG nach SVG konvertieren [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), SVG nach PNG konvertieren [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Vorgänge mit Bildern in diesen gängigen Formaten: JPEG, PNG, BMP, GIF und andere. 

## **Hinzufügen von lokal gespeicherten Bildern zu Folien**

Sie können ein oder mehrere Bilder von Ihrem Computer zu einer Folie in einer Präsentation hinzufügen. Dieser Beispielcode in C# zeigt, wie ein Bild zu einer Folie hinzugefügt wird:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Hinzufügen von Bildern aus dem Web zu Folien**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer verfügbar ist, können Sie das Bild direkt aus dem Web hinzufügen. 

Dieser Beispielcode zeigt, wie ein Bild aus dem Web zu einer Folie in C# hinzugefügt wird:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Hinzufügen von Bildern zu Folienmaster**

Ein Folienmaster ist die übergeordnete Folie, die Informationen (Design, Layout usw.) über alle darunter liegenden Folien speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie, die diesen Folienmaster verwendet. 

Dieser C#‑Beispielcode zeigt, wie ein Bild zu einem Folienmaster hinzugefügt wird:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Hinzufügen von Bildern als Folienhintergrund**

Sie können entscheiden, ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien zu verwenden. In diesem Fall sollten Sie *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)* sehen.

## **Hinzufügen von SVG zu Präsentationen**
Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) verwenden, die zur Schnittstelle [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) gehört.

Um ein Bildobjekt basierend auf einer SVG‑Grafik zu erstellen, können Sie dies wie folgt tun:

1. Erstellen Sie ein SvgImage‑Objekt, um es in ImageShapeCollection einzufügen
2. Erstellen Sie ein PPImage‑Objekt aus ISvgImage
3. Erstellen Sie ein PictureFrame‑Objekt mit der IPPImage‑Schnittstelle

Dieser Beispielcode zeigt, wie Sie die oben genannten Schritte umsetzen, um ein SVG‑Bild zu einer Präsentation hinzuzufügen:
``` csharp 
// Der Pfad zum Dokumentenverzeichnis
string dataDir = @"D:\Documents\";

// Name der Quell‑SVG‑Datei
string svgFileName = dataDir + "sample.svg";

// Name der Ausgabedatei der Präsentation
string outPptxPath = dataDir + "presentation.pptx";

// Neue Präsentation erstellen
using (var p = new Presentation())
{
    // SVG‑Dateiinhalt lesen
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage‑Objekt erstellen
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImage‑Objekt erstellen
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Erstellt einen neuen PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Präsentation im PPTX‑Format speichern
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Konvertieren von SVG in eine Menge von Formen**
Die Konvertierung von SVG in eine Menge von Formen in Aspose.Slides ist ähnlich der PowerPoint‑Funktionalität zum Umgang mit SVG‑Grafiken:

![PowerPoint Popup Menu](img_01_01.png)

Diese Funktionalität wird von einer der Überladungen der Methode [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) des Interfaces [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage)‑Objekt als erstes Argument erhält.

Dieser Beispielcode zeigt, wie die beschriebene Methode verwendet wird, um eine SVG‑Datei in eine Menge von Formen zu konvertieren:
``` csharp 
// Der Pfad zum Dokumentenverzeichnis
string dataDir = @"D:\Documents\";

// Name der Quell‑SVG‑Datei
string svgFileName = dataDir + "sample.svg";

// Name der Ausgabedatei der Präsentation
string outPptxPath = dataDir + "presentation.pptx";

// Neue Präsentation erstellen
using (IPresentation presentation = new Presentation())
{
    // SVG‑Dateiinhalt lesen
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage‑Objekt erstellen
    ISvgImage svgImage = new SvgImage(svgContent);

    // Foliengröße abrufen
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG‑Bild in Gruppe von Formen konvertieren und auf Foliengröße skalieren
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Präsentation im PPTX‑Format speichern
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Hinzufügen von Bildern als EMF in Folien**
Aspose.Slides für .NET ermöglicht das Erzeugen von EMF‑Bildern aus Excel‑Tabellen und das Hinzufügen dieser Bilder als EMF in Folien mit Aspose.Cells. 

Dieser Beispielcode zeigt, wie die beschriebene Aufgabe durchgeführt wird:
``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Arbeitsmappe in Stream speichern
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```


## **Ersetzen von Bildern in der Bildersammlung**

Aspose.Slides ermöglicht das Ersetzen von Bildern, die in der Bildersammlung einer Präsentation gespeichert sind (einschließlich der von Folienformen genutzten). Dieser Abschnitt zeigt mehrere Ansätze zum Aktualisieren von Bildern in der Sammlung. Die API bietet unkomplizierte Methoden zum Ersetzen eines Bildes mithilfe roher Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)‑Instanz oder eines anderen Bildes, das bereits in der Sammlung vorhanden ist.

Folgen Sie den untenstehenden Schritten:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
3. Ersetzen Sie das Zielbild durch das neue Bild mithilfe des Byte‑Arrays.
4. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)‑Objekt und ersetzen das Zielbild durch dieses Objekt.
5. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildersammlung der Präsentation vorhanden ist.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.
```cs
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using Presentation presentation = new Presentation("sample.pptx");

// Der erste Weg.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Der zweite Weg.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Der dritte Weg.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Präsentation in einer Datei speichern.
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="Info" color="info" %}}

Mit dem kostenlosen Aspose‑[Text to GIF](https://products.aspose.app/slides/text-to-gif)‑Konverter können Sie Texte leicht animieren, GIFs aus Texten erstellen usw. 

{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die Originalpixel werden beibehalten, aber das endgültige Erscheinungsbild hängt davon ab, wie das [picture](/slides/de/net/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Wie ist der beste Weg, das gleiche Logo gleichzeitig in dutzenden Folien zu ersetzen?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildersammlung der Präsentation – die Änderungen werden auf alle Elemente, die diese Ressource nutzen, übertragen.

**Kann ein eingefügtes SVG in editierbare Formen konvertiert werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, woraufhin einzelne Teile mit den üblichen Formeigenschaften bearbeitbar werden.

**Wie kann ich ein Bild gleichzeitig als Hintergrund für mehrere Folien festlegen?**

[Weisen Sie das Bild als Hintergrund](/slides/de/net/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu – alle Folien, die diesen Master/Layout verwenden, übernehmen den Hintergrund.

**Wie verhindere ich, dass die Präsentation durch viele Bilder „aufbläht“?**

Verwenden Sie eine einzelne Bildressource wiederholt statt Duplikaten, wählen Sie angemessene Auflösungen, wenden Sie Kompression beim Speichern an und platzieren Sie wiederkehrende Grafiken nach Möglichkeit auf dem Master.