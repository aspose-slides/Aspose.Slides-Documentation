---
title: Optimieren des Bildmanagements in Präsentationen in .NET
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/net/image/
keywords:
- Bild hinzufügen
- Bild hinzufügen
- Bitmap hinzufügen
- Bild ersetzen
- Bild ersetzen
- aus dem Web
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- externe SVG‑Ressourcen
- SVG‑Resolver
- verknüpfte SVG‑Bilder
- SVG‑Schriften
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Optimieren Sie das Bildmanagement in PowerPoint und OpenDocument mit Aspose.Slides für .NET, verbessern Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---
## **Einführung**

Bilder machen Präsentationen ansprechender und visuell attraktiver. In Microsoft PowerPoint können Sie Bilder aus Dateien, dem Internet oder anderen Quellen auf Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Präsentationsfolien auf verschiedene Arten.

{{% alert title="Hinweis" color="info" %}} 
Aspose bietet kostenlose Konverter — [JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt) — die es Ihnen erlauben, schnell Präsentationen aus Bildern zu erstellen. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Wenn Sie ein Bild als Bildrahmen hinzufügen möchten — insbesondere, wenn Sie es skalieren, Effekte anwenden oder andere Standard-Formatierungsoptionen nutzen wollen — siehe [Bildrahmen](/slides/de/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}
Sie können Bilder von einem Format in ein anderes konvertieren. Siehe die folgenden Seiten: Bild zu JPG konvertieren ([image to JPG](https://products.aspose.com/slides/de/net/conversion/image-to-jpg/)), JPG zu Bild ([JPG to image](https://products.aspose.com/slides/de/net/conversion/jpg-to-image/)), JPG zu PNG ([JPG to PNG](https://products.aspose.com/slides/de/net/conversion/jpg-to-png/)), PNG zu JPG ([PNG to JPG](https://products.aspose.com/slides/de/net/conversion/png-to-jpg/)), PNG zu SVG ([PNG to SVG](https://products.aspose.com/slides/de/net/conversion/png-to-svg/)) und SVG zu PNG ([SVG to PNG](https://products.aspose.com/slides/de/net/conversion/svg-to-png/)).
{{% /alert %}}

Aspose.Slides unterstützt Bilder in gängigen Formaten wie JPEG, PNG, BMP, GIF und anderen.

## **Bilder, die lokal gespeichert sind, zu Folien hinzufügen**

Sie können ein oder mehrere auf Ihrem Computer gespeicherte Bilder zu einer Präsentationsfolie hinzufügen. Der folgende C#‑Beispielcode zeigt, wie ein Bild zu einer Folie hinzugefügt wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Bilder aus dem Web zu Folien hinzufügen**

Wenn das Bild, das Sie einer Folie hinzufügen möchten, nicht auf Ihrem Computer gespeichert ist, können Sie es direkt aus dem Web einfügen.

Der folgende C#‑Beispielcode zeigt, wie ein Bild aus dem Web zu einer Folie hinzugefügt wird:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster speichert und steuert Informationen wie Thema und Layout für die Folien, die ihn verwenden. Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint das Bild auf jeder Folie, die auf diesem Master basiert.

Der folgende C#‑Beispielcode zeigt, wie ein Bild zu einem Folienmaster hinzugefügt wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Bilder als Folienhintergründe hinzufügen**

Sie können ein Bild als Hintergrund für eine oder mehrere Folien verwenden. Weitere Details finden Sie unter *[Bilder als Hintergründe für Folien festlegen](/slides/de/net/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG zu Präsentationen hinzufügen**

SVG‑Inhalte können einer Präsentation mithilfe der Klasse [SvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/svgimage/) hinzugefügt werden. Das resultierende [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/)-Objekt kann anschließend zur Bildsammlung der Präsentation hinzugefügt und zum Erstellen eines Bildrahmens verwendet werden.

Der folgende C#‑Beispielcode importiert einen eigenständigen SVG‑String. Alle Bilder, Stile und anderen Ressourcen, die von diesem SVG verwendet werden, sind direkt im SVG‑Inhalt eingebettet.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **SVG‑Inhalt mit externen Ressourcen importieren**

Aus Design‑Tools, Diagrammeditoren, Symbolsystemen und Web‑Pipelines exportierte SVG‑Dateien können Ressourcen referenzieren, die außerhalb des SVG‑Dokuments gespeichert sind. Beispielsweise kann ein SVG einen Bild‑Link wie `images/photo.png`, einen CSS‑`url(...)`‑Wert oder eine Schrift‑URL enthalten.

Um solchen SVG‑Inhalt zu importieren, erstellen Sie eine Implementierung von [IExternalResourceResolver](https://reference.aspose.com/slides/de/net/aspose.slides.import/iexternalresourceresolver/) und übergeben Sie diese zusammen mit einer Basis‑URI an einen passenden `SvgImage`‑Konstruktor. Die Basis‑URI gibt den Speicherort des SVG‑Dokuments an und wird zum Auflösen relativer Links verwendet.

Das [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/)-Interface bietet Zugriff auf Informationen über das importierte SVG:

- `SvgContent` gibt das SVG‑Markup als Zeichenkette zurück.
- `SvgData` gibt den SVG‑Inhalt als Byte‑Array zurück.
- `BaseUri` gibt die Basis‑URI für relative Links zurück.
- `ExternalResourceResolver` gibt den für das SVG‑Bild zugewiesenen Resolver zurück.

### **Einen externen Ressourcen‑Resolver implementieren**

Der Resolver verfügt über zwei Methoden:

- [ResolveUri](https://reference.aspose.com/slides/de/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) kombiniert die Basis‑URI und einen relativen Ressourcen‑Link und liefert eine absolute URI. Gibt `null` zurück, wenn der Link nicht aufgelöst werden kann oder nicht erlaubt ist.
- [GetEntity](https://reference.aspose.com/slides/de/net/aspose.slides.import/iexternalresourceresolver/getentity/) liefert einen lesbaren Stream für eine absolute Ressourcen‑URI. Gibt `null` zurück, wenn die Ressource fehlt, blockiert oder nicht verfügbar ist. Bei Bedarf kann ein Fallback‑Stream zurückgegeben werden.

Der folgende Resolver lädt verknüpfte Ressourcen nur aus einem zulässigen lokalen Verzeichnis. Netzwerkressourcen und Pfade außerhalb des zulässigen Verzeichnisses werden blockiert. Für nicht aufgelöste Bild‑Links wird optional ein Fallback‑Bild zurückgegeben.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Dieser Resolver erlaubt absichtlich nur lokale Dateien.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Verwenden Sie ein Fallback nur für Bildressourcen. Das Zurückgeben eines Bildstreams
        // für eine fehlende Schriftart oder ein Stylesheet wäre nicht gültig.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Verknüpfte Ressourcen während des SVG‑Imports auflösen**

Angenommen, `assets/diagram.svg` enthält einen relativen Verweis wie:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Der folgende C#‑Beispielcode übergibt die SVG‑Datei‑URI als Basis‑URI und stellt einen benutzerdefinierten Resolver bereit. Der Resolver wandelt den relativen Bild‑Link in eine absolute URI um und liefert einen Stream, der die verknüpfte Ressource enthält, während Aspose.Slides das SVG verarbeitet.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Die Basis-URI gibt den Speicherort des SVG-Dokuments an.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage stellt den Quellinhalt, die Binärdaten, die Basis-URI und den Resolver bereit.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

Die Klasse `SvgImage` bietet außerdem Überladungen, die SVG‑Daten als Byte‑Array oder Stream zusammen mit einem externen Ressourcen‑Resolver und einer Basis‑URI akzeptieren.

{{% alert title="Wichtig" color="warning" %}}
Der Ressourcen‑Resolver stellt externe Ressourcen während der Verarbeitung und dem Rendern des SVG durch Aspose.Slides zur Verfügung. Er verändert das ursprüngliche SVG‑Markup nicht und bettet die aufgelösten Ressourcen nicht automatisch ein.

Wird ein `ISvgImage` zur Bildsammlung der Präsentation hinzugefügt, kann die PPTX‑Datei sowohl die originale SVG‑Darstellung als auch ein rasterbasiertes Fallback‑Bild enthalten. Eine verknüpfte Ressource kann im generierten Fallback‑Bild erscheinen, während ein relativer Link wie `images/photo.png` unverändert im gespeicherten SVG bleibt. Eine Anwendung, die die native SVG‑Darstellung rendert, kann daher den verknüpften Inhalt weglassen, wenn die ursprüngliche externe Ressource nicht verfügbar ist.
{{% /alert %}}

### **Ein portables SVG‑Bild erstellen**

Um ein SVG‑Bild zu erstellen, das nicht von externen Dateien abhängt, machen Sie das SVG vor der Erstellung des `SvgImage` eigenständig. Ersetzen Sie beispielsweise verknüpfte Bild‑URLs durch `data:`‑URIs, die die Bilddaten enthalten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nachdem alle erforderlichen Ressourcen im SVG‑Inhalt eingebettet sind, erstellen Sie das `SvgImage`, fügen es zur Bildsammlung der Präsentation hinzu und setzen es wie im vorherigen Beispiel in einen Bildrahmen ein.

### **Umgang mit fehlenden oder blockierten Ressourcen**

Geben Sie `null` von `ResolveUri` zurück, wenn eine Ressourcen‑URI ungültig, verboten oder nicht auflösbar ist. Geben Sie `null` von `GetEntity` zurück, wenn die Ressource nicht gelesen werden kann. Aspose.Slides setzt die Verarbeitung des SVG nach Möglichkeit ohne diese Ressource fort.

Ein Fallback‑Stream kann für eine fehlende Ressource zurückgegeben werden, muss jedoch zum angeforderten Ressourcentyp passen. Beispiel: Einen Bild‑Stream nur für ein fehlendes Bild zurückgeben, nicht für eine Schriftart oder ein Stylesheet.

{{% alert title="Sicherheit" color="warning" %}}
Lösen Sie keine beliebigen Dateipfade oder uneingeschränkten Netzwerk‑URLs aus nicht vertrauenswürdigen SVG‑Dateien auf. Beschränken Sie zulässige Schemas, Verzeichnisse und Hosts. Für Netzwerkressourcen sollten zudem Verbindungs‑Timeouts, Größen‑Limits für Antworten und Inhalts‑Validierungen angewendet werden.
{{% /alert %}}

## **SVG in ein Satz von Formen konvertieren**
Aspose.Slides kann ein SVG in einen Satz von Formen umwandeln, ähnlich der entsprechenden Funktionalität in PowerPoint:

![PowerPoint‑Kontextmenü](img_01_01.png)

Diese Funktion wird durch eine Überladung der Methode [AddGroupShape](https://reference.aspose.com/slides/de/net/aspose.slides.ishapecollection/addgroupshape/methods/1) des Interfaces [IShapeCollection](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection) bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage)‑Objekt als erstes Argument übernimmt.

Der folgende C#‑Beispielcode zeigt, wie diese Methode verwendet wird, um eine SVG‑Datei in einen Satz von Formen zu konvertieren:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Quell‑SVG‑Dateiname
string svgFileName = "sample.svg";

// Ausgabedateiname der Präsentation
string outPptxPath = "presentation.pptx";

// Neue Präsentation erstellen
using (IPresentation presentation = new Presentation())
{
    // SVG-Dateiinhalt lesen
    string svgContent = File.ReadAllText(svgFileName);

    // Ein SvgImage‑Objekt erstellen
    ISvgImage svgImage = new SvgImage(svgContent);

    // Foliengröße abrufen
    SizeF slideSize = presentation.SlideSize.Size;

    // Konvertiere das SVG‑Bild in eine Gruppe von Formen und skaliere es auf die Foliengröße
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Präsentation im PPTX‑Format speichern
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Bilder als EMF zu Folien hinzufügen**
Aspose.Slides für .NET ermöglicht das Erzeugen von EMF‑Bildern aus Excel‑Arbeitsblättern mit Aspose.Cells und das Hinzufügen dieser zu Präsentationsfolien.

Der folgende C#‑Beispielcode zeigt, wie das funktioniert:

``` csharp
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Arbeitsmappe in einen Stream speichern
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Bilder in der Bildsammlung ersetzen**

Aspose.Slides erlaubt das Ersetzen von Bildern, die in der Bildsammlung einer Präsentation gespeichert sind, einschließlich der von Folienformen verwendeten Bilder. Dieser Abschnitt beschreibt mehrere Wege, Bilder in der Sammlung zu aktualisieren. Sie können ein Bild mittels roher Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/)-Instanz oder einem bereits in der Sammlung vorhandenen Bild ersetzen.

Gehen Sie wie folgt vor:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) .  
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.  
3. Ersetzen Sie das Zielbild mit dem neuen Bild mittels des Byte‑Arrays.  
4. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/)-Objekt und ersetzen das Zielbild mit diesem Objekt.  
5. Im dritten Ansatz ersetzen Sie das Zielbild mit einem Bild, das bereits in der Bildsammlung der Präsentation existiert.  
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using Presentation presentation = new Presentation("sample.pptx");

// Erster Weg.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Zweiter Weg.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Dritter Weg.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Präsentation in einer Datei speichern.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
Mit Asposes kostenlosem [Text‑zu‑GIF](https://products.aspose.app/slides/de/text-to-gif)-Konverter können Sie Text einfach animieren und GIFs aus Text erstellen. 
{{% /alert %}}

## **FAQ**

**Bleibt die Originalauflösung des Bildes nach dem Einfügen erhalten?**  
Ja. Die Quell‑Pixel werden beibehalten, aber das endgültige Erscheinungsbild hängt davon ab, wie das [Bild](/slides/de/net/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Was ist der beste Weg, dasselbe Logo gleichzeitig über Dutzende Folien zu ersetzen?**  
Platzieren Sie das Logo auf der Master‑Folien‑ oder Layout‑Folien und ersetzen Sie es in der Bildsammlung der Präsentation — Die Änderungen werden auf alle Elemente, die diese Ressource verwenden, übertragen.

**Kann ein eingefügtes SVG in bearbeitbare Formen umgewandelt werden?**  
Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren; danach lassen sich einzelne Teile mit den üblichen Form‑Eigenschaften bearbeiten.

**Wie kann ich ein Bild als Hintergrund für mehrere Folien gleichzeitig festlegen?**  
[Weisen Sie das Bild als Hintergrund](/slides/de/net/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu — Alle Folien, die diesen Master/Layout nutzen, erben den Hintergrund.

**Wie verhindere ich, dass eine Präsentation durch zu viele Bilder zu groß wird?**  
Verwenden Sie eine einzelne Bildressource statt Duplikaten, wählen Sie angemessene Auflösungen, komprimieren Sie beim Speichern und halten Sie wiederholte Grafiken nach Möglichkeit im Master.