---
title: Optimieren der Bildverwaltung in Präsentationen in .NET
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
- externe SVG-Ressourcen
- SVG-Resolver
- verknüpfte SVG-Bilder
- SVG-Schriften
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Optimieren Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für .NET, verbessern Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---
## **Einleitung**

Bilder machen Präsentationen ansprechender und visueller. In Microsoft PowerPoint können Sie Bilder aus Dateien, dem Internet oder anderen Quellen in Folien einfügen. Ähnlich ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Präsentationsfolien auf verschiedene Weise.

{{% alert  title="Hinweis" color="primary" %}} 
Aspose stellt kostenlose Konverter bereit—[JPEG nach PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—mit denen Sie schnell Präsentationen aus Bildern erstellen können. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Wenn Sie ein Bild als Bilderrahmen hinzufügen möchten—insbesondere wenn Sie es skalieren, Effekte anwenden oder andere Standardformatierungsoptionen nutzen wollen—siehe [Bildrahmen](/slides/de/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}
Sie können Bilder von einem Format in ein anderes konvertieren. Siehe die folgenden Seiten: konvertiere [Bild zu JPG](https://products.aspose.com/slides/de/net/conversion/image-to-jpg/), [JPG zu Bild](https://products.aspose.com/slides/de/net/conversion/jpg-to-image/), [JPG zu PNG](https://products.aspose.com/slides/de/net/conversion/jpg-to-png/), [PNG zu JPG](https://products.aspose.com/slides/de/net/conversion/png-to-jpg/), [PNG zu SVG](https://products.aspose.com/slides/de/net/conversion/png-to-svg/), und [SVG zu PNG](https://products.aspose.com/slides/de/net/conversion/svg-to-png/).
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

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer gespeichert ist, können Sie es direkt aus dem Web hinzufügen. 

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

Ein Folienmaster speichert und steuert Informationen wie das Thema und Layout für die Folien, die ihn verwenden. Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint das Bild auf jeder Folie, die auf diesem Master basiert. 

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

## **Bilder als Folienhintergrund hinzufügen**

Sie können ein Bild als Hintergrund für eine oder mehrere Folien verwenden. Details finden Sie unter *[Bilder als Hintergrund für Folien festlegen](/slides/de/net/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG zu Präsentationen hinzufügen**

SVG-Inhalte können einer Präsentation mit der Klasse [SvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/svgimage/) hinzugefügt werden. Das resultierende [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/)‑Objekt kann dann zur Bildsammlung der Präsentation hinzugefügt und verwendet werden, um einen Bilderrahmen zu erstellen.

Das folgende C#‑Beispiel importiert einen eigenständigen SVG-String. Alle von diesem SVG verwendeten Bilder, Stile und anderen Ressourcen werden direkt im SVG‑Inhalt eingebettet.

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

SVG‑Dateien, die aus Design‑Tools, Diagramm‑Editoren, Icon‑Systemen und Web‑Pipelines exportiert werden, können Ressourcen referenzieren, die außerhalb des SVG‑Dokuments gespeichert sind. Zum Beispiel kann ein SVG einen Bildlink wie `images/photo.png`, einen CSS‑`url(...)`‑Wert oder eine Schrift‑URL enthalten.

Um solche SVG‑Inhalte zu importieren, erstellen Sie eine Implementierung von [IExternalResourceResolver](https://reference.aspose.com/slides/de/net/aspose.slides.import/iexternalresourceresolver/) und übergeben Sie sie zusammen mit einer Basis‑URI an einen geeigneten `SvgImage`‑Konstruktor. Die Basis‑URI gibt den Speicherort des SVG‑Dokuments an und wird zum Auflösen relativer Links verwendet.

Das Interface [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/) bietet Zugriff auf Informationen über das importierte SVG:

- `SvgContent` gibt das SVG-Markup als Zeichenkette zurück.  
- `SvgData` gibt den SVG‑Inhalt als Byte‑Array zurück.  
- `BaseUri` gibt die für relative Links verwendete Basis‑URI zurück.  
- `ExternalResourceResolver` gibt den dem SVG-Bild zugewiesenen Resolver zurück.  

### **Implementieren eines externen Ressourcen‑Resolvers**

Der Resolver verfügt über zwei Methoden:

- [ResolveUri](https://reference.aspose.com/slides/de/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) kombiniert die Basis‑URI und einen relativen Ressourcenlink und gibt eine absolute URI zurück. Gibt `null` zurück, wenn der Link nicht aufgelöst werden kann oder nicht zulässig ist.  
- [GetEntity](https://reference.aspose.com/slides/de/net/aspose.slides.import/iexternalresourceresolver/getentity/) gibt einen lesbaren Stream für eine absolute Ressourcen‑URI zurück. Gibt `null` zurück, wenn die Ressource fehlt, blockiert oder nicht verfügbar ist. Ein Fallback‑Stream kann ebenfalls zurückgegeben werden, wenn dies angemessen ist.  

Der folgende Resolver lädt verknüpfte Ressourcen nur aus einem erlaubten lokalen Verzeichnis. Netzwerkressourcen und Pfade außerhalb des erlaubten Verzeichnisses werden blockiert. Für nicht aufgelöste Bildlinks wird ein optionales Fallback‑Bild zurückgegeben.

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

        // Dieser Resolver erlaubt bewusst nur lokale Dateien.
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

        // Verwenden Sie einen Rückfall nur für Bildressourcen. Das Zurückgeben eines Bildstreams
        // für eine fehlende Schriftart oder Stylesheet wäre nicht gültig.
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

Angenommen, `assets/diagram.svg` enthält eine relative Referenz wie:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Das folgende C#‑Beispiel übergibt die SVG‑Datei‑URI als Basis‑URI und liefert einen benutzerdefinierten Resolver. Der Resolver wandelt den relativen Bildlink in eine absolute URI um und gibt einen Stream zurück, der die verknüpfte Ressource enthält, während Aspose.Slides das SVG verarbeitet.

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

Die Klasse `SvgImage` bietet zudem Überladungen, die SVG‑Daten als Byte‑Array oder Stream akzeptieren, zusammen mit einem externen Ressourcen‑Resolver und einer Basis‑URI.

{{% alert title="Wichtig" color="warning" %}}
Der Ressourcen‑Resolver stellt externe Ressourcen während der Verarbeitung und Darstellung des SVG durch Aspose.Slides bereit. Er verändert das ursprüngliche SVG‑Markup nicht und bettet die aufgelösten Ressourcen nicht automatisch ein.

Wenn ein `ISvgImage` zur Bildsammlung der Präsentation hinzugefügt wird, kann die PPTX‑Datei sowohl die ursprüngliche SVG‑Darstellung als auch ein Raster‑Fallback‑Bild enthalten. Eine verknüpfte Ressource kann im erzeugten Fallback‑Bild erscheinen, während ein relativer Link wie `images/photo.png` im gespeicherten SVG unverändert bleibt. Eine Anwendung, die die native SVG‑Darstellung rendert, kann daher den verknüpften Inhalt weglassen, wenn die ursprüngliche externe Ressource nicht verfügbar ist.
{{% /alert %}}

### **Erstellen eines portablen SVG‑Bildes**

Um ein SVG‑Bild zu erstellen, das nicht von externen Dateien abhängt, machen Sie das SVG vor dem Erzeugen des `SvgImage` eigenständig. Ersetzen Sie zum Beispiel verknüpfte Bild‑URLs durch `data:`‑URIs, die die Bilddaten enthalten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nachdem alle erforderlichen Ressourcen im SVG‑Inhalt eingebettet wurden, erstellen Sie das `SvgImage`, fügen es der Bildsammlung der Präsentation hinzu und setzen es wie im vorherigen Beispiel in einen Bilderrahmen ein.

### **Umgang mit fehlenden oder blockierten Ressourcen**

Geben Sie `null` von `ResolveUri` zurück, wenn eine Ressourcen‑URI ungültig, verboten oder nicht auflösbar ist. Geben Sie `null` von `GetEntity` zurück, wenn die Ressource nicht gelesen werden kann. Aspose.Slides verarbeitet das SVG nach Möglichkeit weiter ohne diese Ressource.

Ein Fallback‑Stream kann für eine fehlende Ressource zurückgegeben werden, dessen Inhalt muss jedoch mit dem angeforderten Ressourcentyp kompatibel sein. Beispielsweise geben Sie nur einen Bild‑Stream für ein fehlendes Bild zurück, nicht für eine Schriftart oder ein Stylesheet.

{{% alert title="Sicherheit" color="warning" %}}
Lösen Sie keine beliebigen Dateipfade oder uneingeschränkten Netzwerk‑URLs aus nicht vertrauenswürdigen SVG‑Dateien auf. Beschränken Sie zulässige Schemas, Verzeichnisse und Hosts. Für Netzwerkressourcen sollten zudem Verbindungs‑Timeouts, Begrenzungen der Antwortgröße und Inhaltsvalidierungen angewendet werden.
{{% /alert %}}

## **SVG in eine Menge von Formen konvertieren**
Aspose.Slides kann ein SVG in eine Menge von Formen konvertieren, ähnlich der entsprechenden Funktionalität in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Diese Funktion wird durch eine Überladung der Methode [AddGroupShape](https://reference.aspose.com/slides/de/net/aspose.slides.ishapecollection/addgroupshape/methods/1) des Interfaces [IShapeCollection](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection) bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage)-Objekt als erstes Argument entgegennimmt.

Der folgende C#‑Beispielcode zeigt, wie diese Methode verwendet wird, um eine SVG‑Datei in eine Menge von Formen zu konvertieren:

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
    // SVG‑Dateiinhalt lesen
    string svgContent = File.ReadAllText(svgFileName);

    // Ein SvgImage‑Objekt erstellen
    ISvgImage svgImage = new SvgImage(svgContent);

    // Foliengröße ermitteln
    SizeF slideSize = presentation.SlideSize.Size;

    // Das SVG‑Bild in eine Gruppe von Formen konvertieren und an die Foliengröße anpassen
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Präsentation im PPTX‑Format speichern
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Bilder als EMF zu Folien hinzufügen**
Aspose.Slides für .NET ermöglicht es Ihnen, mit Aspose.Cells EMF‑Bilder aus Excel‑Arbeitsblättern zu erzeugen und diese zu Präsentationsfolien hinzuzufügen.

Der folgende C#‑Beispielcode zeigt, wie das gemacht wird:

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
Aspose.Slides ermöglicht das Ersetzen von Bildern, die in der Bildsammlung einer Präsentation gespeichert sind, einschließlich der von Folienformen verwendeten Bilder. Dieser Abschnitt beschreibt mehrere Möglichkeiten, Bilder in der Sammlung zu aktualisieren. Sie können ein Bild mit rohen Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/)-Instanz oder einem anderen Bild, das bereits in der Sammlung existiert, ersetzen.

Führen Sie die folgenden Schritte aus:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) .
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
3. Ersetzen Sie das Zielbild mit dem neuen Bild unter Verwendung des Byte‑Arrays.
4. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/)‑Objekt und ersetzen das Zielbild durch dieses Objekt.
5. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildsammlung der Präsentation existiert.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

// Speichern Sie die Präsentation in einer Datei.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
Mit Asposes kostenlosem [Text‑zu‑GIF](https://products.aspose.app/slides/de/text-to-gif)‑Konverter können Sie Text einfach animieren und GIFs aus Text erstellen. 
{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die Quellpixel bleiben erhalten, aber das endgültige Erscheinungsbild hängt davon ab, wie das [Bild](/slides/de/net/picture-frame/) auf der Folie skaliert wird und welche Komprimierung beim Speichern angewendet wird.

**Was ist der beste Weg, das gleiche Logo auf Dutzenden Folien gleichzeitig zu ersetzen?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildsammlung der Präsentation – Aktualisierungen werden auf alle Elemente, die diese Ressource verwenden, übertragen.

**Kann ein eingefügtes SVG in bearbeitbare Formen konvertiert werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, woraufhin einzelne Teile mit den Standard‑Formeigenschaften bearbeitbar werden.

**Wie kann ich ein Bild als Hintergrund für mehrere Folien gleichzeitig festlegen?**

Weisen Sie das Bild als Hintergrund auf dem Master‑Slide oder dem entsprechenden Layout zu ([Bild als Hintergrund zuweisen](/slides/de/net/presentation-background/)) – alle Folien, die diesen Master/Layout verwenden, erben den Hintergrund.

**Wie verhindere ich, dass eine Präsentation wegen vieler Bilder zu groß wird?**

Verwenden Sie eine einzelne Bildressource statt Duplikaten, wählen Sie angemessene Auflösungen, wenden Sie beim Speichern Kompression an und behalten Sie wiederholte Grafiken dort im Master, wo es sinnvoll ist.