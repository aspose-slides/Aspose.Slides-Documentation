---
title: Abrufen und Aktualisieren von Präsentationsinformationen in C++
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/cpp/examine-presentation/
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
- C++
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit C++ für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Aspose.Slides kann das Format einer Präsentation erkennen und deren Dokumentmetadaten auslesen, ohne ein vollständiges Präsentationsobjektmodell zu erstellen. Das ist nützlich, wenn Sie Dateien klassifizieren, ein Inventar erstellen oder Eigenschaften prüfen möchten, bevor Sie entscheiden, ob der Präsentationsinhalt geladen und verarbeitet werden soll.

Dieser Artikel demonstriert die leichte Inspektion über [PresentationFactory](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentationfactory/) und [IPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/), sowie gezielte Aktualisierungen über [IDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/).

## **Prüfen des Präsentationsformats**

Wenn Sie bereits eine geladene Präsentation haben, siehe [Determine the Original Presentation Format](/slides/de/cpp/detect-presentation-source-format/) für die Erkennung nach dem Laden und die Einschränkungen von Legacy‑PPT-, PPS‑ und POT‑Streams.

Verwenden Sie [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/), um eine Datei zu inspizieren, ohne ein [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Exemplar zu erstellen. Die Methode [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/get_loadformat/) gibt das erkannte Format zurück, z. B. PPTX, PPT oder ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Erstellen eines leichten Präsentationsinventars**

Wenn Sie viele Präsentationsdateien verarbeiten, benötigen Sie möglicherweise ein kompaktes Inventar für Validierung, Indexierung oder ein Dokumenten‑Management‑System. Verwenden Sie in diesem Szenario [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/), um ein [IPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/)‑Objekt zu erhalten, und rufen Sie dann [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) auf, um die Dokumentmetadaten zu lesen. Dieser Ansatz erstellt kein [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Exemplar und erfordert nicht das Durchlaufen des vollständigen Präsentationsobjektmodells.

Die von [IDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/) bereitgestellten erweiterten Eigenschaften liefern die folgenden Inventarwerte:

| Methode | Inventarwert |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_slides/) | Gesamtzahl der Folien. |
| [get_HiddenSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Anzahl versteckter Folien. |
| [get_Notes](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_notes/) | Anzahl der Folien, die Notizen enthalten. |
| [get_Paragraphs](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Gesamtzahl der Absätze, sofern verfügbar. |
| [get_Words](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_words/) | Gesamtzahl der Wörter. |
| [get_MultimediaClips](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Gesamtzahl von Audio‑ und Video‑Clips. |

Das folgende Beispiel liest diese Werte, ohne ein [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Objekt zu erstellen, und gibt ein kompaktes Inventar aus. Außerdem wird [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_headingpairs/) mit [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) kombiniert, um Inhaltsgruppen wie Schriftarten, Designs und Folientitel anzuzeigen.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Jedes [IHeadingPair](https://reference.aspose.com/slides/de/cpp/aspose.slides/iheadingpair/) liefert einen Gruppennamen über [IHeadingPair::get_Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/iheadingpair/get_name/) und die Anzahl der Elemente in dieser Gruppe über [IHeadingPair::get_Count](https://reference.aspose.com/slides/de/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) gibt ein flaches, geordnetes Array zurück, sodass die Anzahl aufeinanderfolgender Titel, die von jedem Heading‑Pair angegeben werden, verarbeitet werden kann.

### **Gespeicherte Metadaten und Formatbeschränkungen**

Die von [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) zurückgegebenen Inventareigenschaften spiegeln die im Quellendokument verfügbaren Metadaten wider. Aspose.Slides lädt und durchläuft das Präsentationsobjektmodell nicht, um diese Werte für diesen Aufruf neu zu berechnen. Fehlende Eigenschaften werden durch Standardwerte dargestellt, und gespeicherte Werte können veraltet sein, wenn die Anwendung, die die Datei zuletzt gespeichert hat, ihre Dokumenteigenschaften nicht aktualisiert hat.

- **PPTX:** Das Format bietet erweiterte Dokumenteigenschaften für Folien-, Notiz‑, versteckte‑Folien‑, Absatz‑, Wort‑ und Multimedia‑Zähler sowie für Heading‑Pairs und Part‑Titles. Die Verfügbarkeit hängt davon ab, welche Eigenschaften vom Dokumentersteller geschrieben wurden.
- **PPT:** Das Binärformat kann entsprechende Dokument‑Zusammenfassungs‑Eigenschaften speichern. Ist eine Eigenschaft abwesend oder wurde vom Dokumentersteller nicht aktualisiert, gibt Aspose.Slides ihren gespeicherten oder Standardwert zurück, anstatt sie aus den Folien zu berechnen.
- **ODP:** OpenDocument‑Metadaten bieten allgemeine Dokumentstatistiken wie Seiten‑, Absatz‑ und Wort‑Zähler, aber diese Werte lassen sich nicht auf jede PowerPoint‑spezifische erweiterte Eigenschaft abbilden. Metadaten zu versteckten Folien, Notizen‑Folien, Multimedia, Heading‑Pairs und Part‑Titles können fehlen, und die Inventareigenschaften können Standardwerte zurückgeben. Behandeln Sie weder einen Nullwert noch ein leeres Array als endgültigen Beweis dafür, dass der zugehörige Inhalt fehlt.

Verwenden Sie den leichten Metadaten‑Ansatz für Inventare und Vorprüfungen. Laden Sie die Präsentation und inspizieren Sie ihr Live‑Objektmodell, wenn das Ergebnis In‑Memory‑Änderungen widerspiegeln muss oder wenn Sie den tatsächlichen Präsentationsinhalt verifizieren wollen.

## **Präsentationseigenschaften aktualisieren**

Die von [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) zurückgegebenen Eigenschaften können ebenfalls geändert werden, ohne ein [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Exemplar zu erstellen. Wenden Sie die Änderungen mit [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) an und schreiben Sie die gebundene Präsentation mit [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) zurück.

Das folgende Bild zeigt die ursprünglichen Dokumenteigenschaften.

![Original document properties of the PowerPoint presentation](input_properties.png)

Das folgende Beispiel ändert den Titel und die letzte Speicherzeit und schreibt das Ergebnis in eine neue Datei:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

Das folgende Bild zeigt die aktualisierten Dokumenteigenschaften.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Nützliche Links**

Für verwandte Sicherheitsprüfungen und Schutzeinstellungen siehe die folgenden Artikel:

- [Password-Protect Presentations](/slides/de/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/de/cpp/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriften eingebettet sind und welche das sind?**

Laden Sie die Präsentation und verwenden Sie [Presentation::get_FontsManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_fontsmanager/). Rufen Sie [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/getembeddedfonts/) auf, um die eingebetteten Schriften zu erhalten, und [FontsManager::GetFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/getfonts/), um die von der Präsentation verwendeten Schriften zu erhalten. Vergleichen Sie die beiden Ergebnisse, um Schriften zu finden, die zum Rendern benötigt, aber nicht eingebettet sind.

**Wie kann ich schnell feststellen, ob die Datei versteckte Folien enthält und wie viele?**

Wenn die gespeicherten Dokumentmetadaten ausreichen, lesen Sie [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) über [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) und [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Das ist für ein leichtes Inventar geeignet. Wenn die Präsentation im Speicher geändert wurde, können die gespeicherten Metadaten fehlen oder veraltet sein; in diesem Fall iterieren Sie über [Presentation::get_Slides](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_slides/) und prüfen jeweils die Methode [Slide::get_Hidden](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/get_hidden/).

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und Orientierung verwendet wird und ob sie von den Vorgaben abweicht?**

Ja. Laden Sie die Präsentation und lesen Sie [Presentation::get_SlideSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_slidesize/). Prüfen Sie [ISlideSize::get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidesize/get_size/) und [ISlideSize::get_Orientation](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidesize/get_orientation/), um die aktuellen Einstellungen mit den erwarteten Vorgaben und Abmessungen zu vergleichen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen verwenden?**

Ja. Finden Sie jedes [Chart](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chart/) und prüfen Sie [ChartData::get_DataSourceType](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Bei einer externen Arbeitsmappe lesen Sie [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Der Datenquellentyp und Pfad identifizieren eine externe Referenz, aber die Verfügbarkeit des Ziels muss separat geprüft werden.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Es gibt keine einzelne Komplexitäts‑Eigenschaft. Durchlaufen Sie [Presentation::get_Slides](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_slides/) und die [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/get_shapes/)‑Sammlung jeder Folie. Nutzen Sie die Anzahl der Formen sowie das Vorhandensein großer Bilder, Effekte, Animationen oder Multimedia als Screening‑Signal und messen Sie ein repräsentatives Rendering oder Export, bevor Sie eine Folie als bestätigten Performance‑Engpass einstufen.