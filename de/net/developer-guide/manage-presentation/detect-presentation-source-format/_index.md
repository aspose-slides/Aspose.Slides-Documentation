---
title: Bestimmen des ursprünglichen Präsentationsformats in .NET
linktitle: Quellformat
type: docs
weight: 35
url: /de/net/detect-presentation-source-format/
keywords:
- Quellformat
- Präsentationsformat erkennen
- PowerPoint
- OpenDocument
- Präsentation
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Lesen Sie das Originalformat einer geladenen Präsentation in C# mit Aspose.Slides für .NET, vergleichen Sie Erkennungs‑APIs und verarbeiten Sie Dateien, Streams und Legacy‑Formate."
---
## **Übersicht**

Nachdem Sie eine Präsentation geladen haben, lesen Sie die schreibgeschützte [Presentation.SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sourceformat/) Eigenschaft, um ihr ursprüngliches Format zu bestimmen. Die Eigenschaft ist ebenfalls über [IPresentation.SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/sourceformat/) verfügbar. Verwenden Sie sie, wenn die nachfolgende Verarbeitung vom Format abhängt, aus dem die aktuelle Instanz geladen wurde.

Das Quellformat unterscheidet sich vom für eine Ausgabedatei gewählten [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/). Das Speichern in ein anderes Format ändert das Quellformat der vorhandenen Instanz nicht.

## **Lesen des Quellformats einer Datei**

Dieses Beispiel erfordert eine vorhandene Datei `sample.pptx`. Es lädt die Datei und wählt eine Anwendungs‑Verarbeitungspolitik anhand von [Presentation.SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sourceformat/) aus, anstatt den Dateinamen zu verwenden. Ändern Sie den Eingabepfad, um andere Formate zu testen. Das Beispiel gibt die ausgewählte Politik aus; ersetzen Sie die Meldungen durch Ihre Anwendungslogik.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Erkennen der unterstützten Werte**

Die [SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/sourceformat/) Aufzählung unterscheidet die folgenden Präsentationsformate. Die untenstehenden Erweiterungen sind konventionelle Erweiterungen, keine Rekonstruktion des ursprünglichen Dateinamens.

| SourceFormat‑Wert | Erweiterung | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑97‑2003‑Präsentation |
| `Pptx` | `.pptx` | Office Open XML‑Präsentation |
| `Pptm` | `.pptm` | Makro‑aktivierte Office Open XML‑Präsentation |
| `Pps` | `.pps` | PowerPoint‑97‑2003‑Bildschirmpräsentation |
| `Ppsx` | `.ppsx` | Office Open XML‑Bildschirmpräsentation |
| `Ppsm` | `.ppsm` | Makro‑aktivierte Office Open XML‑Bildschirmpräsentation |
| `Pot` | `.pot` | PowerPoint‑97‑2003‑Vorlage |
| `Potx` | `.potx` | Office Open XML‑Vorlage |
| `Potm` | `.potm` | Makro‑aktivierte Office Open XML‑Vorlage |
| `Odp` | `.odp` | OpenDocument‑Präsentation |
| `Otp` | `.otp` | OpenDocument‑Präsentationsvorlage |
| `Fodp` | `.fodp` | Flat‑XML‑ODF‑Präsentation |
| `Xml` | `.xml` | PowerPoint‑XML‑Präsentation |

## **Lesen des Quellformats eines Streams**

Dieses Beispiel erfordert eine vorhandene Datei `sample.pps`. Das Einlesen ihrer Bytes in einen Memory‑Stream modelliert Eingaben ohne Dateinamen, z. B. einen Datenbankwert oder ein hochgeladenes Byte‑Array. Der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Konstruktor erhält nur den Stream.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS und POT verwenden dasselbe zugrunde liegende Binärformat. Beim Laden über einen Dateipfad kann die Erweiterung helfen, eine Bildschirmpräsentation oder Vorlage zu unterscheiden. Ohne Dateinamen kann Legacy‑PPS‑ und POT‑Inhalt als `SourceFormat.Ppt` gemeldet werden; das PPS‑Beispiel oben meldet `Ppt`.

Wenn Ihre Anwendung die Unterscheidung erhalten muss, bewahren Sie den ursprünglichen Dateinamen oder Subtyp‑Metadaten separat auf. Eine Erweiterung ist ein nützlicher Hinweis für diese Legacy‑Subtypen, sollte jedoch nicht die einzige Grundlage zur Identifizierung beliebiger Präsentationsinhalte sein.

## **Vergleich der Erkennung vor und nach dem Laden**

Verwenden Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/) und [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/loadformat/), wenn Sie eine Datei prüfen müssen, bevor ihr vollständiges Präsentationsobjektmodell geladen wird. Verwenden Sie [Presentation.SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sourceformat/), wenn die Instanz bereits existiert.

Dieses Beispiel erfordert `sample.pptx` und gibt `Pptx` für beide Prüfungen aus. In der Produktion wählen Sie die API, die zu Ihrem Verarbeitungsschritt passt; eine bereits geladene Präsentation benötigt keine zweite Inspektion ausschließlich zur Ermittlung ihres Quellformats.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Die Ergebnisse haben unterschiedliche Aufzählungstypen: [LoadFormat](https://reference.aspose.com/slides/de/net/aspose.slides/loadformat/) und [SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/sourceformat/). Vergleichen Sie sie nicht, indem Sie ihre numerischen Werte casten, und gehen Sie nicht davon aus, dass jedes Format identische Erkennungsergebnisse liefert. Im nachstehenden „Speichern‑und‑Wiederöffnen“-Check wurde PowerPoint XML vor dem Laden als `LoadFormat.Unknown` und nach dem Laden als `SourceFormat.Xml` gemeldet.

## **Quell- und Ausgabeformate getrennt halten**

Dieses Beispiel erfordert `sample.pptx` und schreibt `converted.odp`. Es gibt sowohl vor als auch nach dem Speichern der ursprünglichen Instanz `Pptx` aus. Nur die neue Instanz, die aus der ODP‑Ausgabe geladen wird, meldet `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

Eine mit `new Presentation()` von Grund auf neu erstellte Präsentation meldet `SourceFormat.Pptx`. Sie hat keine Eingabedatei: Das ist der Standardwert für eine neu erstellte Instanz, kein Hinweis darauf, dass eine PPTX‑Datei geladen wurde. Verfolgen Sie getrennt, ob Ihre Anwendung die Instanz erstellt oder geladen hat, falls diese Unterscheidung wichtig ist.

## **Zuordnung eines Quellformats zu einer Erweiterung**

Das folgende Beispiel erfordert `sample.pptx`. Es ordnet jedem derzeit unterstützten [SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/sourceformat/)‑Wert eine konventionelle Erweiterung zu, ohne den Eingabedateinamen zu analysieren. Der Fallback verhindert, dass stillschweigend einer nicht erkannten Werte eine Erweiterung zugewiesen wird.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Diese Zuordnung konvertiert keine Datei und stellt keinen verlorenen Legacy‑PPS/POT‑Subtyp wieder her, der beim Laden über einen Stream verloren ging. Für das eigentliche Speichern wählen Sie ausdrücklich ein [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/) oder verwenden Sie die in **[Präsentationen im Originalformat speichern](/slides/de/net/save-presentation/#save-presentations-in-their-original-format)** gezeigte Konvertierung.

## **Formate durch Speichern und erneutes Öffnen überprüfen**

Dieses eigenständige Beispiel erstellt eine Präsentation und schreibt drei Dateien in das Arbeitsverzeichnis, wobei Dateien mit denselben Namen überschrieben werden. Es öffnet jede Ausgabe sowohl über den Pfad als auch über einen Memory‑Stream erneut. Für PPTX und ODP melden beide Wege das gespeicherte Format. Für PPS meldet das Laden über den Pfad `Pps`, während das Laden derselben Bytes ohne Dateinamen `Ppt` meldet.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

Der gleiche Check mit allen oben aufgeführten Formaten ergab folgende Ergebnisse für erzeugte Präsentationen mit passenden Erweiterungen:

| Gespeichertes Format | SourceFormat aus einem Dateipfad | SourceFormat aus einem namenlosen Stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` jeweils | Wie Dateipfad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` jeweils | Wie Dateipfad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` jeweils | Wie Dateipfad |
| ODP, OTP | `Odp`, `Otp` jeweils | Wie Dateipfad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

In diesen Checks war die einzige Normalisierung des Quellformats die Umwandlung von PPS/POT zu `Ppt` für namenlose Streams. Die Tabelle beschreibt die Formatidentifikation, nicht die Erhaltung aller Präsentationsmerkmale während einer Konvertierung.

## **FAQ**

**Ändert das Speichern im ODP‑Format das Quellformat einer aus PPTX geladenen Präsentation?**

Nein. Die bestehende Instanz gibt weiterhin `Pptx` an. Eine aus der gespeicherten ODP‑Datei geladene Instanz gibt `Odp` an.

**Kann ein Stream stets zwischen einer alten Präsentation, Bildschirmpräsentation und Vorlage unterscheiden?**

Nein. PPT, PPS und POT teilen das Binärformat. Bewahren Sie Dateinamen oder Subtyp‑Metadaten separat auf, wenn diese Unterscheidung erforderlich ist.

**Welche API sollte ich verwenden, wenn die Präsentation bereits geladen ist?**

Lesen Sie [Presentation.SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sourceformat/). Verwenden Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/) für die Inspektion vor dem Laden.