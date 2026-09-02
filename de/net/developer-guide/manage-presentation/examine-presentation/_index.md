---
title: Abrufen und Aktualisieren von Präsentationsinformationen in .NET
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/net/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteneigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- Eigenschaften aktualisieren
- PPTX untersuchen
- PPT untersuchen
- ODP untersuchen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit .NET für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Aspose.Slides kann das Format einer Präsentation erkennen und die Dokumentmetadaten lesen, ohne ein vollständiges Präsentations‑Objektmodell zu erstellen. Das ist nützlich, wenn Sie Dateien klassifizieren, ein Inventar erstellen oder Eigenschaften prüfen möchten, bevor Sie entscheiden, ob Sie den Präsentationsinhalt laden und verarbeiten.

Dieser Artikel demonstriert die leichte Inspektion über [PresentationFactory](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/) und [IPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/), sowie gezielte Aktualisierungen über [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/).

## **Format einer Präsentation prüfen**

Verwenden Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/), um eine Datei zu inspizieren, ohne ein [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Exemplar zu erstellen. Die Eigenschaft [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/loadformat/) gibt das erkannte Format zurück, z. B. PPTX, PPT oder ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Leichtgewichtiges Präsentationsinventar erstellen**

Wenn Sie viele Präsentationsdateien verarbeiten, benötigen Sie möglicherweise ein kompaktes Inventar für Validierung, Indexierung oder ein Dokument‑Management‑System. In diesem Szenario verwenden Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/), um ein [IPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/)‑Objekt zu erhalten, und rufen dann [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/) auf, um die Dokumentmetadaten zu lesen. Dieser Ansatz erstellt kein [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Exemplar und erfordert nicht, dass Sie das vollständige Präsentations‑Objektmodell durchlaufen.

Die von [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/) bereitgestellten erweiterten Eigenschaften liefern die folgenden Inventarwerte:

| Property | Inventory value |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/slides/de/) | Gesamtzahl der Folien. |
| [HiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/hiddenslides/) | Anzahl versteckter Folien. |
| [Notes](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/notes/) | Anzahl der Folien, die Notizen enthalten. |
| [Paragraphs](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/paragraphs/) | Gesamtzahl der Absätze, falls verfügbar. |
| [Words](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/words/) | Gesamtzahl der Wörter. |
| [MultimediaClips](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/multimediaclips/) | Gesamtzahl der Audio‑ und Videoclips. |

Das folgende Beispiel liest diese Werte, ohne ein [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Objekt zu erstellen, und gibt ein kompaktes Inventar aus. Es kombiniert außerdem [HeadingPairs](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/headingpairs/) mit [TitlesOfParts](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/titlesofparts/), um Inhaltsgruppen wie Schriftarten, Designs und Folientitel anzuzeigen.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Jeder [IHeadingPair](https://reference.aspose.com/slides/de/net/aspose.slides/iheadingpair/) liefert einen Gruppennamen und die Anzahl der Elemente in dieser Gruppe. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/titlesofparts/) ist ein flaches, geordnetes Array, daher verbrauchen Sie die Anzahl aufeinanderfolgender Titel, die durch jedes Heading‑Pair angegeben werden.

### **Gespeicherte Metadaten und Formatbeschränkungen**

Die von [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/) zurückgegebenen Inventareigenschaften spiegeln die im Quelldokument verfügbaren Metadaten wider. Aspose.Slides lädt das Präsentations‑Objektmodell nicht und durchläuft es nicht, um diese Werte für diesen Aufruf neu zu berechnen. Fehlende Eigenschaften werden durch Standardwerte dargestellt, und gespeicherte Werte können veraltet sein, wenn die Anwendung, die die Datei zuletzt gespeichert hat, ihre Dokumenteigenschaften nicht aktualisiert hat.

- **PPTX:** Das Format stellt erweiterte Dokumenteigenschaften für Folien‑, Notizen‑, versteckte‑Folien‑, Absatz‑, Wort‑ und Multimedia‑Zählungen sowie Heading‑Pairs und Part‑Titles bereit. Die Verfügbarkeit hängt davon ab, welche Eigenschaften vom Dokumentersteller geschrieben wurden.
- **PPT:** Das Binärformat kann entsprechende Dokument‑Zusammenfassungs‑Eigenschaften speichern. Wenn eine Eigenschaft fehlt oder nicht vom Dokumentersteller aktualisiert wurde, gibt Aspose.Slides den gespeicherten oder Standardwert zurück, anstatt ihn aus den Folien zu berechnen.
- **ODP:** OpenDocument‑Metadaten liefern allgemeine Dokumentstatistiken wie Seiten‑, Absatz‑ und Wortzählungen, aber diese Werte lassen sich nicht auf jede PowerPoint‑spezifische erweiterte Eigenschaft abbilden. Metadaten zu versteckten Folien, Notizen‑Folien, Multimedia, Heading‑Pairs und Part‑Titles können fehlen, und die Inventareigenschaften können Standardwerte zurückgeben. Behandeln Sie keinen Null‑Wert oder ein leeres Array als endgültigen Beweis dafür, dass der entsprechende Inhalt fehlt.

Verwenden Sie den leichten Metadaten‑Ansatz für Inventare und Vorprüfungen. Laden Sie die Präsentation und prüfen Sie ihr Live‑Objektmodell, wenn das Ergebnis in‑Speicher‑Änderungen widerspiegeln muss oder wenn Sie den tatsächlichen Präsentationsinhalt verifizieren müssen.

## **Präsentationseigenschaften aktualisieren**

Die von [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/) zurückgegebenen Eigenschaften können ebenfalls geändert werden, ohne ein [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Exemplar zu erstellen. Wenden Sie die Änderungen mit [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) an und schreiben Sie dann die gebundene Präsentation mit [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Das folgende Bild zeigt die ursprünglichen Dokumenteigenschaften der PowerPoint‑Präsentation.

![Ursprüngliche Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Das folgende Beispiel ändert den Titel und den letzten Speicherzeitpunkt und schreibt das Ergebnis in eine neue Datei:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Das folgende Bild zeigt die geänderten Dokumenteigenschaften der PowerPoint‑Präsentation.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Für verwandte Sicherheitsprüfungen und Schutzeinstellungen siehe die folgenden Artikel:

- [Passwortgeschützte Präsentationen](/slides/de/net/password-protected-presentation/)
- [Schreibgeschützte Präsentationen](/slides/de/net/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Laden Sie die Präsentation und verwenden Sie [Presentation.FontsManager](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/fontsmanager/). Rufen Sie [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getembeddedfonts/) auf, um die eingebetteten Schriftarten zu erhalten, und [FontsManager.GetFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getfonts/), um die von der Präsentation verwendeten Schriftarten zu erhalten. Vergleichen Sie die beiden Ergebnisse, um Schriftarten zu finden, die für die Darstellung erforderlich, aber nicht eingebettet sind.

**Wie kann ich schnell feststellen, ob die Datei versteckte Folien enthält und wie viele?**

Wenn gespeicherte Dokumentmetadaten ausreichen, lesen Sie [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/hiddenslides/) über [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/) und [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Dies eignet sich für ein leichtgewichtiges Inventar. Wenn die Präsentation im Speicher geändert wurde, können die gespeicherten Metadaten fehlen oder veraltet sein, oder Sie müssen Live‑Werte prüfen, indem Sie [Presentation.Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slides/de/) durchlaufen und die Eigenschaft [Slide.Hidden](https://reference.aspose.com/slides/de/net/aspose.slides/slide/hidden/) jeder Folie inspizieren.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet wird und ob sie von den Vorgaben abweicht?**

Ja. Laden Sie die Präsentation und lesen Sie [Presentation.SlideSize](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slidesize/). Prüfen Sie [ISlideSize.Type](https://reference.aspose.com/slides/de/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/de/net/aspose.slides/islidesize/size/) und [ISlideSize.Orientation](https://reference.aspose.com/slides/de/net/aspose.slides/islidesize/orientation/), um die aktuellen Einstellungen mit den erwarteten Vorgaben und Abmessungen zu vergleichen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Lokalisieren Sie jedes [Chart](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chart/) und prüfen Sie [ChartData.DataSourceType](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chartdata/datasourcetype/). Für eine externe Arbeitsmappe lesen Sie [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chartdata/externalworkbookpath/). Der Datentyp und der Pfad identifizieren eine externe Referenz, doch die Verfügbarkeit des Ziels muss separat überprüft werden.

**Wie kann ich 'schwere' Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Es gibt keine einzelne Komplexitäts‑Eigenschaft. Durchlaufen Sie [Presentation.Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slides/de/) und die [IBaseSlide.Shapes](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/shapes/)‑Sammlung jeder Folie. Nutzen Sie die Anzahl der Formen sowie das Vorhandensein großer Bilder, Effekte, Animationen oder Multimedia als Indikatoren und messen Sie ein repräsentatives Render‑ oder Export‑Ergebnis, bevor Sie eine Folie als bestätigten Leistungsengpass einstufen.