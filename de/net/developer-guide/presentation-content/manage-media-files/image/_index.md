---
title: Bild
type: docs
weight: 10
url: /net/image/
keywords: "Bild hinzufügen, Foto hinzufügen, PowerPoint-Präsentation, EMF, SVG, C#, Csharp, Aspose.Slides für .NET"
description: "Bild zu PowerPoint-Folie oder Präsentation in C# oder .NET hinzufügen"
---

## **Bilder in Folien in Präsentationen**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder von einer Datei, dem Internet oder anderen Orten auf Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien in Ihren Präsentationen über verschiedene Verfahren.

{{% alert title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es den Menschen ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten—insbesondere wenn Sie planen, Standardformatierungsoptionen zu verwenden, um dessen Größe zu ändern, Effekte hinzuzufügen usw.—sehen Sie sich [Bildrahmen](https://docs.aspose.com/slides/net/picture-frame/) an. 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}

Sie können Eingabe-/Ausgabeoperationen einrichten, die Bilder und PowerPoint-Präsentationen betreffen, um ein Bild von einem Format in ein anderes zu konvertieren. Siehe diese Seiten: konvertieren [Bild zu JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/net/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), konvertieren [PNG zu JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), konvertieren [SVG zu PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Operationen mit Bildern in diesen gängigen Formaten: JPEG, PNG, BMP, GIF und anderen. 

## **Hinzufügen von lokal gespeicherten Bildern zu Folien**

Sie können ein oder mehrere Bilder von Ihrem Computer auf eine Folie in einer Präsentation hinzufügen. Dieser Beispielcode in C# zeigt Ihnen, wie Sie ein Bild zu einer Folie hinzufügen:

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

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, auf Ihrem Computer nicht verfügbar ist, können Sie das Bild direkt aus dem Internet hinzufügen. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Bild aus dem Web zu einer Folie in C# hinzufügen:

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

Ein Folienmaster ist die oberste Folie, die Informationen (Design, Layout usw.) über alle darunter liegenden Folien speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie unter diesem Folienmaster. 

Dieser C# Beispielcode zeigt Ihnen, wie Sie ein Bild zu einem Folienmaster hinzufügen:

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

Sie können entscheiden, ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien zu verwenden. In diesem Fall müssen Sie *[Bilder als Hintergründe für Folien einstellen](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Hinzufügen von SVG zu Präsentationen**
Sie können jedes Bild in einer Präsentation einfügen oder hinzufügen, indem Sie die [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) Methode verwenden, die zur [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) Schnittstelle gehört.

Um ein Bildobjekt basierend auf einem SVG-Bild zu erstellen, können Sie es auf folgende Weise tun:

1. Erstellen Sie ein SvgImage-Objekt, um es in die ImageShapeCollection einzufügen.
2. Erstellen Sie ein PPImage-Objekt aus dem ISvgImage.
3. Erstellen Sie ein PictureFrame-Objekt mit der IPPImage-Schnittstelle.

Dieser Beispielcode zeigt Ihnen, wie Sie die oben beschriebenen Schritte implementieren, um ein SVG-Bild in eine Präsentation einzufügen:
``` csharp 
// Der Pfad zum Dokumentenverzeichnis
string dataDir = @"D:\Documents\";

// Quell-SVG-Dateiname
string svgFileName = dataDir + "sample.svg";

// Ausgabedateiname der Präsentation
string outPptxPath = dataDir + "presentation.pptx";

// Neue Präsentation erstellen
using (var p = new Presentation())
{
    // SVG-Dateiinhalt lesen
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage-Objekt erstellen
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImage-Objekt erstellen
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Neues PictureFrame erstellen 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Präsentation im PPTX-Format speichern
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Konvertieren von SVG zu einer Gruppe von Shapes**
Die Konvertierung von SVG zu einer Gruppe von Shapes in Aspose.Slides ähnelt der PowerPoint-Funktionalität, die verwendet wird, um mit SVG-Bildern zu arbeiten:


![PowerPoint Popup-Menü](img_01_01.png)

Die Funktionalität wird durch eine der Überladungen der [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) Methode der [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) Schnittstelle bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) Objekt als erstes Argument übernimmt.

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Methode verwenden, um eine SVG-Datei in eine Gruppe von Shapes zu konvertieren:

``` csharp 
// Der Pfad zum Dokumentenverzeichnis
string dataDir = @"D:\Documents\";

// Quell-SVG-Dateiname
string svgFileName = dataDir + "sample.svg";

// Ausgabedateiname der Präsentation
string outPptxPath = dataDir + "presentation.pptx";

// Neue Präsentation erstellen
using (IPresentation presentation = new Presentation())
{
    // SVG-Dateiinhalt lesen
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage-Objekt erstellen
    ISvgImage svgImage = new SvgImage(svgContent);

    // Foliengröße abrufen
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG-Bild in eine Gruppe von Shapes umwandeln und es an die Foliengröße anpassen
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Präsentation im PPTX-Format speichern
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Hinzufügen von Bildern als EMF in Folien**
Aspose.Slides für .NET ermöglicht es Ihnen, EMF-Bilder aus Excel-Tabellen zu generieren und die Bilder als EMF in Folien mit Aspose.Cells hinzuzufügen. 

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Aufgabe ausführen:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Das Arbeitsbuch in einen Stream speichern
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Seite" + (j + 1) + ".out.emf";
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

{{% alert title="Info" color="info" %}}

Mit dem kostenlosen [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter von Aspose können Sie Texte einfach animieren, GIFs aus Texten erstellen usw. 

{{% /alert %}}