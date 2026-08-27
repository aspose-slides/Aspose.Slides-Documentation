---
title: PowerPoint-Präsentationen in .NET zu Markdown konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu MD
- Präsentation zu MD
- Folie zu MD
- PPT zu MD
- PPTX zu MD
- PowerPoint als Markdown speichern
- Präsentation als Markdown speichern
- Folie als Markdown speichern
- PPT als MD speichern
- PPTX als MD speichern
- PPT nach MD exportieren
- PPTX nach MD exportieren
- Markdown-Bildexport
- CDN-Bildlinks
- PowerPoint
- Präsentation
- Markdown
- .NET
- C#
- Aspose.Slides
description: "PPT- und PPTX-Präsentationen in .NET zu Markdown konvertieren und steuern, wo exportierte Bitmap-, Metadatei- und SVG-Bilder gespeichert und referenziert werden."
---
## **Übersicht**

Aspose.Slides für .NET kann PPT- und PPTX-Präsentationen in Markdown für Dokumentation, statische Websites, Inhaltsmigration und Versionskontroll‑Workflows konvertieren. Sie können einen Markdown‑Flavor auswählen, steuern, wie Folieninhalte gerendert werden, und entscheiden, wo exportierte Bilder gespeichert werden und wie das erzeugte Markdown sie referenziert.

Standardmäßig verwendet der Markdown‑Export eine reine Textausgabe. Um visuelle Inhalte zu exportieren, setzen Sie die [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/exporttype/)‑Eigenschaft auf den Wert `Sequential` oder `Visual` aus der Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownexporttype/). `Sequential` rendert Folienelemente einzeln und in Reihenfolge, während `Visual` gruppierte Elemente zusammenhält, um deren visuelle Beziehung zu bewahren. Der Wert `TextOnly` erzeugt keine Bildressourcen, sodass die Bild‑Speicher‑Ereignisse in diesem Modus nicht aufgerufen werden.

## **Präsentation in Markdown konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/), und rufen Sie anschließend die Methode [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) mit dem `Md`‑Wert aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/) auf.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Markdown‑Flavor auswählen**

Die Eigenschaft [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/flavor/) steuert die für die Ausgabe verwendete Markdown‑Spezifikation. Die Aufzählung [Flavor](https://reference.aspose.com/slides/de/net/aspose.slides.export/flavor/) enthält CommonMark, GitHub Flavored Markdown und weitere unterstützte Varianten.

Das folgende Beispiel exportiert eine Präsentation als CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Bilder mit dem Standard‑lokalen Speicherverhalten exportieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/) bietet zwei Eigenschaften für lokal gespeicherte Bilder:

- [BasePath](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/basepath/) gibt das Basisverzeichnis für das Markdown‑Dokument und dessen Ressourcen an.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) gibt das Bildunterverzeichnis an. Der Standardwert ist `Images`.

Das folgende Beispiel rendert visuelle Inhalte, schreibt Bilder nach `output/assets` und erstellt relative Bildreferenzen im Markdown‑Dokument:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Dieses Verhalten dient auch als Rückfallback, wenn ein benutzerdefinierter Bild‑Speicher‑Handler `false` zurückgibt.

## **Bildspeicherung und Markdown‑Links anpassen**

Verwenden Sie das Ereignis [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/imagesaving/) für nicht‑SVG‑Bitmap‑ und Metadatei‑Ressourcen, die beim Markdown‑Export erzeugt werden. Sein Delegat [MarkdownImageSavingHandler](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) erhält das Objekt [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/), sein [ImageFormat](https://reference.aspose.com/slides/de/net/aspose.slides/imageformat/) und den erzeugten Markdown‑Link als `ref string`‑Parameter. Speichern oder laden Sie das Bild mit dem angegebenen Format hoch und ersetzen Sie `link` durch die Referenz, die im Markdown‑Ausgabe erscheinen soll.

Ressourcen im SVG‑Format werden gesondert behandelt. Abonnieren Sie das Ereignis [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), dessen Delegat [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) ein [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/)‑Objekt und den Parameter `ref string link` erhält. Ein SVG hat kein `ImageFormat`‑Argument; schreiben oder laden Sie stattdessen die XML‑Daten aus der Eigenschaft [ISvgImage.SvgData](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/svgdata/) hoch. Je nach Exportmodus und visueller Gruppierung kann ein SVG in der Quellpräsentation gerastert oder mit anderem Inhalt kombiniert werden; die resultierende Nicht‑SVG‑Ressource wird dann an `ImageSaving` übergeben. Abonnieren Sie beide Ereignisse, wenn jede exportierte visuelle Ressource einer benutzerdefinierten Verarbeitung bedarf.

Der Rückgabewert des Handlers bestimmt, wer das Bild verarbeitet:

- Geben Sie `true` zurück, nachdem der Handler das Bild gespeichert, hochgeladen, transformiert oder anderweitig verarbeitet und einen gültigen Wert für `link` zugewiesen hat. Aspose.Slides schreibt diesen Wert in das Markdown‑Dokument und führt nicht die Standard‑lokale Speicherung aus.
- Geben Sie `false` zurück, damit Aspose.Slides das Bild lokal speichert und den Link gemäß [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/basepath/) und [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) erzeugt.

{{% alert color="warning" title="Wichtig" %}}
Ein Handler, der `true` zurückgibt, übernimmt die Verantwortung für das Bild. Gibt er `true` zurück, ohne einen gültigen, nicht leeren Link zuzuweisen, schlägt der Export mit einer `InvalidOperationException` fehl.
{{% /alert %}}

### **Bilder in ein CDN‑Ursprungsverzeichnis speichern und externe URLs verwenden**

Das folgende Beispiel behandelt `cdn-origin/presentations/quarterly-report` als ein eingehängtes oder synchronisiertes CDN‑Ursprungsverzeichnis. Jeder Handler extrahiert den erzeugten Dateinamen, speichert das Bild in diesem benutzerdefinierten Verzeichnis und ersetzt die erzeugte lokale Referenz durch eine öffentliche CDN‑URL. Das Beispiel führt selbst keinen Netzwerk‑Upload aus: Die URL ist erst gültig, nachdem das Verzeichnis als CDN‑Ursprung eingehängt oder seine Dateien im CDN veröffentlicht wurden. Für Objektspeicher ersetzen Sie das Datei‑System‑Schreiben durch den Upload‑Vorgang des Speicher‑SDKs und weisen `link` erst zu, nachdem der Upload erfolgreich war.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Der Bitmap‑Handler gibt bewusst `false` für Bilder zurück, die kleiner als 128 × 128 Pixel sind, sodass Aspose.Slides diese Bilder nach `output/fallback-images` unter Verwendung des Standardverhaltens speichert. Größere Bitmap‑ und Metadatei‑Ressourcen sowie SVG‑Ressourcen werden vom benutzerdefinierten Code verarbeitet. Beispielsweise wird eine erzeugte lokale Referenz wie `fallback-images/image1.png` zu `https://cdn.example.com/presentations/quarterly-report/image1.png`. Die Handler verwenden Betriebssystem‑Pfade nur beim Schreiben von Dateien; Links, die in Markdown geschrieben werden, nutzen Vorwärtsschrägstriche und URL‑kodierte Dateinamen. Wenden Sie dieselbe Regel beim Erstellen relativer Links an: Verwenden Sie `/` und nicht den plattformspezifischen Verzeichnistrenner.

## **FAQ**

**Kann ein Handler sowohl Raster‑Bilder als auch SVG‑Bilder verarbeiten?**

Nein. Verwenden Sie [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/imagesaving/) für erzeugte Bitmap‑ und Metadatei‑Ressourcen und [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) für als SVG erzeugte Ressourcen. Ersteres liefert ein [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/)-Objekt und ein [ImageFormat](https://reference.aspose.com/slides/de/net/aspose.slides/imageformat/); letzteres liefert ein [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/)-Objekt, dessen SVG‑Daten aus [ISvgImage.SvgData](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/svgdata/) gelesen werden können. Ein Quell‑SVG, das während des Exports gerastert wird, wird stattdessen von `ImageSaving` verarbeitet.

**Was passiert, wenn ein Bild‑Speicher‑Handler `false` zurückgibt?**

Aspose.Slides verwendet sein standardmäßiges lokales Speicherverhalten. Der Bildort und die erzeugte Referenz werden von [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/basepath/) und [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/de/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) gesteuert.

**Kann ein Handler eine URL bereitstellen, ohne das Bild lokal zu speichern?**

Ja. Der Handler kann das Bild in einen Objektspeicher hochladen oder an einen anderen Dienst weitergeben, die resultierende URL `link` zuweisen und `true` zurückgeben. Der Handler muss die Verarbeitung selbst abschließen; das Zurückgeben von `true` verhindert das standardmäßige lokale Speichern.

**Warum wirft der Markdown‑Export eine `InvalidOperationException` von einem Handler?**

Diese Ausnahme tritt auf, wenn der Handler `true` zurückgibt, jedoch keinen gültigen Link bereitstellt. Weisen Sie den relativen Pfad oder die externe URL, die in das Markdown geschrieben werden soll, zu, bevor Sie `true` zurückgeben.

**Welchen Pfadtrenner sollten Bild‑Links verwenden?**

Verwenden Sie Vorwärtsschrägstriche in Markdown‑Links und URLs. Nutzen Sie `Path.Combine` nur für Dateisystem‑Pfade und erstellen bzw. normalisieren Sie die Markdown‑Referenz anschließend separat.

**Werden Hyperlinks beim Markdown‑Export beibehalten?**

Ja. Text‑[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien‑[Transitions](/slides/de/net/slide-transition/) und -[Animations](/slides/de/net/powerpoint-animation/) werden nicht konvertiert.

**Können Präsentationen parallel in Markdown konvertiert werden?**

Sie können verschiedene Präsentationsdateien parallel verarbeiten, sollten jedoch dieselbe [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Instanz nicht zwischen Threads teilen. Befolgen Sie die [Multithreading‑Richtlinien](/slides/de/net/multithreading/) und verwenden Sie für jede Datei eine separate Instanz.