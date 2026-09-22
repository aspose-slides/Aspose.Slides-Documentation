---
title: Präsentationsinformationen in .NET abrufen und aktualisieren
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/net/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
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
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument‑Präsentationen mit .NET für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Aspose.Slides kann das Format einer Präsentation identifizieren und deren Dokumentmetadaten auslesen, ohne ein komplettes Präsentationsobjektmodell zu erstellen. Dies ist nützlich, wenn Sie Dateien klassifizieren, ein Inventar erstellen oder Eigenschaften überprüfen müssen, bevor Sie entscheiden, ob die Präsentationsinhalte geladen und verarbeitet werden sollen.

Dieser Artikel demonstriert eine leichte Inspektion über [PresentationFactory](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/) und [IPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/), sowie gezielte Aktualisierungen über [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/).

## **Prüfen des Präsentationsformats**

Wenn Sie bereits eine geladene Präsentation haben, siehe [Determine the Original Presentation Format](/slides/de/net/detect-presentation-source-format/) für die Erkennung nach dem Laden und die Einschränkungen von Legacy-PPT-, PPS- und POT-Streams.

Verwenden Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/), um eine Datei zu inspizieren, ohne eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Instanz zu erstellen. Die Eigenschaft [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/loadformat/) gibt das erkannte Format zurück, beispielsweise PPTX, PPT oder ODP.

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

## **Erstellen eines leichten Präsentationsinventars**

Wenn Sie viele Präsentationsdateien verarbeiten, benötigen Sie möglicherweise ein kompaktes Inventar für Validierung, Indexierung oder ein Dokumentenverwaltungssystem. In diesem Szenario verwenden Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/) um ein [IPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/) Objekt zu erhalten und rufen dann [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/) auf, um die Dokumentmetadaten zu lesen. Dieser Ansatz erstellt keine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Instanz und erfordert nicht, dass Sie das komplette Präsentationsobjektmodell durchlaufen.

Die von [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/) bereitgestellten erweiterten Eigenschaften liefern die folgenden Inventarwerte:

| Eigenschaft | Inventarwert |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/slides/de/) | Gesamtzahl der Folien. |
| [HiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/hiddenslides/) | Anzahl der ausgeblendeten Folien. |
| [Notes](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/notes/) | Anzahl der Folien, die Notizen enthalten. |
| [Paragraphs](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/paragraphs/) | Gesamtzahl der Absätze, falls verfügbar. |
| [Words](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/words/) | Gesamtzahl der Wörter. |
| [MultimediaClips](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/multimediaclips/) | Gesamtzahl der Audio- und Videoclips. |

Das folgende Beispiel liest diese Werte, ohne ein [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Objekt zu erstellen, und gibt ein kompaktes Inventar aus. Es kombiniert zudem [HeadingPairs](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/headingpairs/) mit [TitlesOfParts](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/titlesofparts/), um Inhaltsgruppen wie Schriftarten, Designs und Folientitel anzuzeigen.

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

Jedes [IHeadingPair](https://reference.aspose.com/slides/de/net/aspose.slides/iheadingpair/) liefert einen Gruppennamen und die Anzahl der Elemente in dieser Gruppe. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/titlesofparts/) ist ein flaches, geordnetes Array, daher nutzen Sie die Anzahl aufeinanderfolgender Titel, die durch jedes Heading‑Paar angegeben werden.

### **Gespeicherte Metadaten und Formatbeschränkungen**

Die vom Aufruf [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/) zurückgegebenen Inventareigenschaften spiegeln die Metadaten wider, die im Quelldokument vorhanden sind. Aspose.Slides lädt das Präsentationsobjektmodell nicht und traversiert es nicht, um diese Werte für diesen Aufruf neu zu berechnen. Fehlende Eigenschaften werden durch Standardwerte dargestellt, und gespeicherte Werte können veraltet sein, wenn die Anwendung, die die Datei zuletzt gespeichert hat, ihre Dokumenteigenschaften nicht aktualisiert hat.

- **PPTX:** Das Format stellt erweiterte Dokumenteigenschaften für Folien-, Noten-, Ausgeblendete‑Folien-, Absatz-, Wort‑ und Multimedia‑Zähler sowie Heading‑Paare und Teil‑Titel bereit. Die Verfügbarkeit hängt davon ab, welche Eigenschaften vom Dokumentersteller geschrieben wurden.
- **PPT:** Das binäre Format kann entsprechende Dokument‑Zusammenfassungs‑Eigenschaften speichern. Wenn eine Eigenschaft fehlt oder nicht vom Dokumentersteller aktualisiert wurde, gibt Aspose.Slides ihren gespeicherten oder Standardwert zurück, anstatt sie aus den Folien zu berechnen.
- **ODP:** OpenDocument‑Metadaten liefern allgemeine Dokumentstatistiken wie Seiten‑, Absatz‑ und Wortzählungen, aber diese Werte decken nicht jede PowerPoint‑spezifische erweiterte Eigenschaft ab. Metadaten zu ausgeblendeten Folien, Notizen‑Folien, Multimedia, Heading‑Pairs und Teil‑Titeln können nicht verfügbar sein, und die Inventareigenschaften können Standardwerte zurückgeben. Behandeln Sie einen Nullwert oder ein leeres Array nicht als autoritativen Beweis dafür, dass der entsprechende Inhalt fehlt.

Verwenden Sie den leichten Metadaten‑Ansatz für Inventare und Vorprüfungen. Laden Sie die Präsentation und inspizieren Sie ihr live Objektmodell, wenn das Ergebnis Änderungen im Speicher widerspiegeln muss oder wenn Sie den tatsächlichen Präsentationsinhalt verifizieren müssen.

## **Präsentationseigenschaften aktualisieren**

Die von [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/) zurückgegebenen Eigenschaften können ebenfalls geändert werden, ohne eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Instanz zu erstellen. Wenden Sie die Änderungen mit [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) an und schreiben Sie die gebundene Präsentation mit [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Das folgende Bild zeigt die ursprünglichen Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Das folgende Beispiel ändert den Titel und das zuletzt gespeicherte Datum und schreibt das Ergebnis in eine neue Datei:

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

Das folgende Bild zeigt die geänderten Dokumenteigenschaften.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Für verwandte Sicherheitsprüfungen und Schutzeinstellungen siehe die folgenden Artikel:

- [Passwortgeschützte Präsentationen](/slides/de/net/password-protected-presentation/)
- [Schreibgeschützte Präsentationen](/slides/de/net/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Laden Sie die Präsentation und verwenden Sie [Presentation.FontsManager](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/fontsmanager/). Rufen Sie [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getembeddedfonts/) auf, um die eingebetteten Schriftarten zu erhalten, und [FontsManager.GetFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getfonts/) , um die von der Präsentation genutzten Schriftarten zu erhalten. Vergleichen Sie beide Ergebnisse, um Schriftarten zu finden, die für die Darstellung erforderlich sind, aber nicht eingebettet wurden.

**Wie kann ich schnell feststellen, ob die Datei ausgeblendete Folien enthält und wie viele?**

Wenn die gespeicherten Dokumentmetadaten ausreichen, lesen Sie [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/hiddenslides/) über [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/) und [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Dies eignet sich für ein leichtes Inventar. Wenn die Präsentation im Speicher geändert wurde, können die gespeicherten Metadaten fehlen oder veraltet sein, oder Sie müssen Live‑Werte prüfen, indem Sie durch [Presentation.Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slides/de/) iterieren und die [Slide.Hidden](https://reference.aspose.com/slides/de/net/aspose.slides/slide/hidden/) Eigenschaft jeder Folie inspizieren.

**Kann ich erkennen, ob benutzerdefinierte Foliengröße und -ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Laden Sie die Präsentation und lesen Sie [Presentation.SlideSize](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slidesize/). Prüfen Sie [ISlideSize.Type](https://reference.aspose.com/slides/de/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/de/net/aspose.slides/islidesize/size/) und [ISlideSize.Orientation](https://reference.aspose.com/slides/de/net/aspose.slides/islidesize/orientation/), um die aktuellen Einstellungen mit den erwarteten Vorgaben und Abmessungen zu vergleichen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Suchen Sie jedes [Chart](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chart/) und prüfen Sie [ChartData.DataSourceType](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chartdata/datasourcetype/). Für eine externe Arbeitsmappe lesen Sie [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/de/net/aspose.slides.charts/chartdata/externalworkbookpath/). Der Datentyp und Pfad identifizieren eine externe Referenz, aber die Verfügbarkeit des Ziels muss separat geprüft werden.

**Wie kann ich 'schwere' Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Es gibt keine einzelne Komplexitäts‑Eigenschaft. Durchlaufen Sie [Presentation.Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slides/de/) und die [IBaseSlide.Shapes](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/shapes/) Sammlung jeder Folie. Verwenden Sie die Anzahl der Formen sowie das Vorhandensein großer Bilder, Effekte, Animationen oder Multimedia als Hinweis, und messen Sie ein repräsentatives Rendern oder Exportieren, bevor Sie eine Folie als bestätigten Leistungsengpass einstufen.