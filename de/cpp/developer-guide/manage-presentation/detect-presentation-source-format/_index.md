---
title: Bestimmen des ursprünglichen Präsentationsformats in C++
linktitle: Quellformat
type: docs
weight: 35
url: /de/cpp/detect-presentation-source-format/
keywords:
- Quellformat
- Präsentationsformat erkennen
- PowerPoint
- OpenDocument
- Präsentation
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Lesen Sie das ursprüngliche Format einer geladenen Präsentation in C++ mit Aspose.Slides für C++, vergleichen Sie Erkennungs‑APIs und verarbeiten Sie Dateien, Streams und Legacy‑Formate."
---
## **Übersicht**

Nach dem Laden einer Präsentation rufen Sie [Presentation::get_SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_sourceformat/) auf, um ihr ursprüngliches Format zu bestimmen. Die Methode ist ebenfalls über [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_sourceformat/) verfügbar. Verwenden Sie sie, wenn die nachfolgende Verarbeitung vom Format abhängt, aus dem die aktuelle Instanz geladen wurde.

Das Quellformat unterscheidet sich vom für eine Ausgabedatei gewählten [SaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/). Das Speichern in ein anderes Format ändert das Quellformat der bestehenden Instanz nicht.

## **Quellformat einer Datei auslesen**

Dieses Beispiel benötigt eine vorhandene Datei `sample.pptx`. Es lädt die Datei und wählt eine Anwendungs‑Verarbeitungsrichtlinie über [Presentation::get_SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_sourceformat/), anstatt den Dateinamen zu verwenden. Ändern Sie den Eingabepfad, um andere Formate auszuprobieren. Das Beispiel gibt die ausgewählte Richtlinie aus; ersetzen Sie die Meldungen durch Ihre Anwendungslogik.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Unterstützte Werte erkennen**

Die Aufzählung [SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/sourceformat/) unterscheidet die folgenden Präsentationsformate. Die nachstehenden Erweiterungen sind konventionelle Dateierweiterungen, nicht die Rekonstruktion des ursprünglichen Dateinamens.

| SourceFormat‑Wert | Erweiterung | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑97‑2003‑Präsentation |
| `Pptx` | `.pptx` | Office‑Open‑XML‑Präsentation |
| `Pptm` | `.pptm` | Makro‑aktivierte Office‑Open‑XML‑Präsentation |
| `Pps` | `.pps` | PowerPoint‑97‑2003‑Bildschirmpräsentation |
| `Ppsx` | `.ppsx` | Office‑Open‑XML‑Bildschirmpräsentation |
| `Ppsm` | `.ppsm` | Makro‑aktivierte Office‑Open‑XML‑Bildschirmpräsentation |
| `Pot` | `.pot` | PowerPoint‑97‑2003‑Vorlage |
| `Potx` | `.potx` | Office‑Open‑XML‑Vorlage |
| `Potm` | `.potm` | Makro‑aktivierte Office‑Open‑XML‑Vorlage |
| `Odp` | `.odp` | OpenDocument‑Präsentation |
| `Otp` | `.otp` | OpenDocument‑Vorlage |
| `Fodp` | `.fodp` | Flat‑XML‑ODF‑Präsentation |
| `Xml` | `.xml` | PowerPoint‑XML‑Präsentation |

## **Quellformat eines Streams auslesen**

Dieses Beispiel benötigt eine vorhandene Datei `sample.pps`. Das Einlesen der Bytes in einen Memory‑Stream modelliert Eingaben ohne Dateinamen, etwa einen Datenbankwert oder ein hochgeladenes Byte‑Array. Der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)-Konstruktor erhält nur den Stream.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS und POT verwenden dasselbe zugrunde liegende Binärformat. Beim Laden über einen Dateipfad kann die Erweiterung helfen, zwischen Bildschirmpräsentation und Vorlage zu unterscheiden. Ohne Dateinamen kann älterer PPS‑ und POT‑Inhalt als `SourceFormat::Ppt` gemeldet werden; das obige PPS‑Beispiel meldet `Ppt`.

Muss Ihre Anwendung die Unterscheidung bewahren, behalten Sie den ursprünglichen Dateinamen oder Metadaten zum Subtyp separat. Eine Erweiterung ist ein nützlicher Hinweis für diese älteren Subtypen, sollte aber nicht die einzige Grundlage zur Identifikation beliebiger Präsentationsinhalte sein.

## **Erkennung vor und nach dem Laden vergleichen**

Verwenden Sie [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentationfactory/getpresentationinfo/) und [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/get_loadformat/), wenn Sie eine Datei prüfen müssen, bevor das komplette Präsentations‑Objektmodell geladen wird. Nutzen Sie [Presentation::get_SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_sourceformat/), wenn die Instanz bereits existiert.

Dieses Beispiel benötigt `sample.pptx` und gibt in beiden Prüfungen `Pptx` aus. In der Produktion wählen Sie die API, die zu Ihrem Verarbeitungsstadium passt; eine bereits geladene Präsentation benötigt keine zweite Inspektion ausschließlich zum Ermitteln ihres Quellformats.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Die Ergebnisse besitzen unterschiedliche Aufzählungstypen: [LoadFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadformat/) und [SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/sourceformat/). Vergleichen Sie sie nicht, indem Sie ihre numerischen Werte casten, und gehen Sie nicht davon aus, dass jedes Format identische Erkennungsergebnisse liefert. PowerPoint‑XML kann vor dem Laden als `LoadFormat::Unknown` und nach dem Laden als `SourceFormat::Xml` gemeldet werden.

## **Quell‑ und Ausgabeformate getrennt halten**

Dieses Beispiel benötigt `sample.pptx` und schreibt `converted.odp`. Es gibt sowohl vor als auch nach dem Speichern der Originalinstanz `Pptx` aus. Nur die neue Instanz, die aus der ODP‑Ausgabe geladen wird, meldet `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Eine von Grund auf neu erstellte Präsentation mit `MakeObject<Presentation>()` meldet `SourceFormat::Pptx`. Sie hat keine Eingabedatei: Das ist der Standardwert für eine frisch erstellte Instanz, kein Hinweis darauf, dass eine PPTX‑Datei geladen wurde. Verfolgen Sie getrennt, ob Ihre Anwendung die Instanz erstellt oder geladen hat, falls diese Unterscheidung relevant ist.

## **Ein Quellformat einer Erweiterung zuordnen**

Das folgende Beispiel benötigt `sample.pptx`. Es ordnet jedem derzeit unterstützten [SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/sourceformat/)-Wert eine konventionelle Erweiterung zu, ohne den Eingabedateinamen zu analysieren. Der Fallback verhindert, dass einem nicht erkannten Wert stillschweigend eine Erweiterung zugewiesen wird.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Diese Zuordnung konvertiert keine Datei und stellt keinen verlorenen legacy‑PPS/POT‑Subtyp wieder her, der beim Laden aus einem Stream verloren ging. Zum tatsächlichen Speichern wählen Sie ausdrücklich ein [SaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) oder nutzen die in [Save Presentations in Their Original Format](/slides/de/cpp/save-presentation/#save-presentations-in-their-original-format) gezeigte Konvertierung.

## **Formate durch Speichern und erneutes Öffnen verifizieren**

Dieses eigenständige Beispiel erstellt eine Präsentation und schreibt drei Dateien in das Arbeitsverzeichnis, wobei gleichnamige Dateien überschrieben werden. Es öffnet jede Ausgabe sowohl über den Pfad als auch über einen Memory‑Stream erneut. Für PPTX und ODP melden beide Wege das gespeicherte Format. Für PPS meldet das Laden über den Pfad `Pps`, während das Laden derselben Bytes ohne Dateinamen `Ppt` ergibt.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

Die folgende Tabelle fasst die Quellformat‑Identifikation für Präsentationen mit übereinstimmenden Erweiterungen zusammen:

| Gespeichertes Format | SourceFormat aus Dateipfad | SourceFormat aus namenlosem Stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` jeweils | Gleich wie Dateipfad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` jeweils | Gleich wie Dateipfad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` jeweils | Gleich wie Dateipfad |
| ODP, OTP | `Odp`, `Otp` jeweils | Gleich wie Dateipfad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Legacy‑PPS/POT‑Inhalt wird für namenlose Streams auf `Ppt` normalisiert. Die Tabelle beschreibt die Formatidentifikation, nicht die Bewahrung aller Präsentations‑Features während einer Konvertierung.

## **FAQ**

**Ändert das Speichern nach ODP das Quellformat einer aus PPTX geladenen Präsentation?**

Nein. Die bestehende Instanz meldet weiterhin `Pptx`. Eine Instanz, die aus der gespeicherten ODP‑Datei geladen wird, meldet `Odp`.

**Kann ein Stream immer zwischen einem legacy‑Präsentations‑, Bildschirm‑ und Vorlagenformat unterscheiden?**

Nein. PPT, PPS und POT teilen das Binärformat. Bewahren Sie Dateinamen oder Subtyp‑Metadaten separat, wenn diese Unterscheidung erforderlich ist.

**Welche API sollte ich verwenden, wenn die Präsentation bereits geladen ist?**

Lesen Sie [Presentation::get_SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_sourceformat/). Verwenden Sie [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentationfactory/getpresentationinfo/) für eine Inspektion vor dem Laden.