---
title: Effizientes Zusammenführen von Präsentationen in C++
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/cpp/merge-presentation/
keywords:
- PowerPoint zusammenführen
- Präsentationen zusammenführen
- Folien zusammenführen
- PPT zusammenführen
- PPTX zusammenführen
- ODP zusammenführen
- PowerPoint kombinieren
- Präsentationen kombinieren
- Folien kombinieren
- PPT kombinieren
- PPTX kombinieren
- ODP kombinieren
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in C++ durch Klonen von Folien, Steuern von Mastern und Layouts, Anpassen der Foliengröße, Erhalten von Abschnitten und Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für C++ kombiniert Präsentationen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) in eine andere geklont werden. Der Hauptvorgang ist [ISlideCollection::AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/), der die Formatierung der Quellfolie beibehalten oder die geklonte Folie an einen Master oder ein Layout in der Zielpräsentation anhängen kann.

Dieser Artikel behandelt die gebräuchlichsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei die Formatierung der Quelle beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zielpräsentation anwenden;
- Ein bestimmtes Layout aus der Zielpräsentation anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑to‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriftarten, Passwörter, große Dateien und Multithreading‑Probleme handhaben.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie erbt einen Großteil ihres Aussehens von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Überladung, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [ISlideCollection::AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) auf eine der folgenden Arten:

- `AddClone(sourceSlide)` — bewahrt das Layout und die Formatierung der Quellfolie. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, nicht mehrfach geklont werden.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — hängt die geklonte Folie an einen bestimmten Ziel‑[IMasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/). Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `AddClone(sourceSlide, destinationLayout)` — hängt die geklonte Folie direkt an ein bestimmtes Ziel‑[ILayoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/).

Der an einen `AddClone`‑Überladung übergebene Master oder das Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quell‑Präsentation.

## **Gesamte Präsentationen zusammenführen und Quell‑Formatierung beibehalten**

Die einfachste Zusammenführung kopiert jede Folie der Quellpräsentation in die Zielpräsentation. Dies ist die geeignete Wahl, wenn die importierten Folien ihr ursprüngliches Thema, ihren Master und ihre Layout‑Beziehungen beibehalten sollen.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Zielpräsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quell‑Formatierung bewusst beibehalten wird.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folienindizes aus der Quellpräsentation.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Validieren Sie Folienindizes vor dem Klonen, wenn sie aus Benutzereingaben oder externer Konfiguration stammen.

## **Folien mit einem Ziel‑Master zusammenführen**

Verwenden Sie die Überladung [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/), wenn importierte Folien einem Master folgen sollen, der bereits zur Zielpräsentation gehört.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides wählt ein passendes Layout unter dem angegebenen Master aus, indem es den Layout‑Typ oder Namen des Quell‑Layouts vergleicht. Wenn kein geeignetes Layout existiert und `allowCloneMissingLayout` ist `true`, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es `false`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/cpp/aspose.slides/details_pptxeditexception/) ausgelöst.

Verwenden Sie `false`, wenn die Zusammenführung fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

Verwenden Sie die Überladung [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/), wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht neu. Wenn Quell‑ und Ziel‑Layouts unterschiedliche Platzhalterstrukturen besitzen, prüfen Sie das Ergebnis, um sicherzustellen, dass die geerbte Formatierung und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienabmessungen können zusammengeführt werden, jedoch gestaltet das Klonen einer Folie in eine Präsentation mit anderer Foliengröße deren Inhalt nicht automatisch neu für die neue Leinwand. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktikabler Ansatz ist, die Quellpräsentation vor dem Klonen zu skalieren. Die Methode [SlideSize::SetSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesize/setsize/) kann bestehenden Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesizescaletype/) skaliert den Inhalt, damit er in die gewünschte Größe passt.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Das Skalieren ändert das Quell‑Präsentationsobjekt im Speicher. Wenn Sie die ursprüngliche Quellpräsentation unverändert für weitere Vorgänge benötigen, öffnen Sie eine separate Instanz für die Zusammenführung.

## **Folien in einen Präsentationsabschnitt zusammenführen**

Die grundlegende Folien‑Klon‑Schleife reproduziert nicht die Abschnittshierarchie der Quellpräsentation. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Zielpräsentation und klonen Sie Folien explizit mit [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Die geklonten Folien werden an den angegebenen Zielabschnitt angehängt. Um mehrere Quellabschnitte zu erhalten, reproduzieren Sie diese Abschnitte in der Zielpräsentation und ordnen Sie jede Quellfolie dem entsprechenden Zielabschnitt zu.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑to‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur solange offen, wie sie kopiert wird, und speichert die endgültige Datei einmalig.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Dies ist ein nützlicher Ausgangspunkt, um die Quell‑Formatierung importierter Folien beizubehalten. Wenn Ihr Ergebnis ein einziges Ziel‑Theme verwenden muss, ersetzen Sie den einfachen Aufruf `AddClone(slide)` durch die zuvor gezeigte Überladung für Ziel‑Master oder Ziel‑Layout.

## **Praktische Überlegungen**

### **Master, Layouts und Formattreue**

Standard‑Folien‑Klonen kann bei Bedarf einen erforderlichen Quell‑Master automatisch in die Zielpräsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um ein wiederholtes Klonen desselben Masters zu vermeiden. Manuell geklonte Master werden von diesem Register nicht erfasst, daher sollten Sie Master nicht vorab klonen, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit gleichem Namen visuell identisch sind. Wenn ein Unternehmens‑Template das endgültige Aussehen steuern muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout eindeutig aus und prüfen Sie das Ergebnis nach der Zusammenführung.

### **Notizen und Kommentare**

Sprechernotizen und Folienkommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie kopiert. Aspose.Slides bietet zudem dedizierte APIs für [presentation notes](https://docs.aspose.com/slides/de/cpp/presentation-notes/) und [presentation comments](https://docs.aspose.com/slides/de/cpp/presentation-comments/).

Wenn das Format der Notizseite wichtig ist, überprüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Überprüfungs‑Workflows prüfen Sie zudem die Kommentar‑Autoren und verschachtelten Kommentare nach dem Kombinieren von Dateien verschiedener Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können Präsentations‑Ressourcen wie Bilder, eingebettete Audios, eingebettete Videos und OLE‑Daten referenzieren. Klonen Sie die Folie selbst und nicht nur die sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen erhalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpfter Audio‑, Video‑, OLE‑Objekt‑ oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie wandelt einen externen Link nicht in eingebetteten Inhalt um. Prüfen Sie verknüpfte Ressourcenknoten und URLs in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, dies sollte jedoch nicht als generelle Garantie dafür verstanden werden, dass identische Binär‑Ressourcen aus unabhängigen Quellpräsentationen immer dedupliziert werden. Ist die Dateigröße wichtig, inspizieren Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplizierung zu verlassen.

### **Eingebettete Schriftarten und Verfügbarkeit**

Schriftarten werden auf Präsentationsebene verwaltet. Wenn die Typografie über verschiedene Rechner hinweg konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede erforderliche Schriftart in der Zielumgebung verfügbar ist. Sie können eingebettete Schriftarten mit [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/getembeddedfonts/) inspizieren und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](https://docs.aspose.com/slides/de/cpp/embedded-font/) beschrieben.

Prüfen Sie außerdem, ob Sie die Lizenz haben, die in den Quell‑Dateien verwendeten Schriftarten einzubetten. Schriftlizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Das Passwort wird über [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/) übergeben.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Das Öffnen einer verschlüsselten Quelle wendet nicht automatisch denselben Schutz auf die Zielpräsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen großen Binärobjekten können erheblichen Speicher beanspruchen. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateinutzung. Siehe [Manage Presentation BLOBs](https://docs.aspose.com/slides/de/cpp/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien bevorzugen Sie das Laden über Dateipfade, entsorgen Sie jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, es sei denn, der Workflow erfordert Checkpoints.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Präsentationsinstanz auf einen Zusammenführungs‑Vorgang beschränkt. Wenn Sie unabhängige Aufgaben parallelisieren, verwenden Sie unabhängige Präsentationsinstanzen und folgen Sie der [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/de/cpp/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lassen sich importierte Folien an das Ziel‑Theme anpassen?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zielpräsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quellfolie einem geeigneten Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout anstelle eines Ziel‑Masters verwenden?**

Verwenden Sie ein spezifisches Layout, wenn jede importierte Folie ein bekanntes Layout benutzen soll. Verwenden Sie einen Master, wenn Sie Aspose.Slides die Auswahl unter den Layouts dieses Masters basierend auf Layout‑Typ oder Namen der Quellfolie überlassen möchten.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, jedoch wird der Folieninhalt nicht automatisch für die Zielabmessungen neu gestaltet. Skalieren Sie die Quellpräsentation zuerst, wenn Sie eine vorhersehbare Platzierung benötigen, zum Beispiel mit [SlideSize::SetSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesize/setsize/) und [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesizescaletype/).

**Kann ich PPT-, PPTX- und ODP‑Präsentationen in einer Datei zusammenführen?**

Ja. Laden Sie jede Quellpräsentation, klonen Sie die erforderlichen Folien in eine Zielpräsentation und speichern Sie die Zielpräsentation in einem unterstützten Ausgabeformat. Da die Formate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach formatübergreifenden Zusammenführungen. Siehe [Supported File Formats](https://docs.aspose.com/slides/de/cpp/supported-file-formats/).

**Werden Quellabschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Reproduzieren Sie die erforderlichen Abschnitte in der Zielpräsentation und verwenden Sie die Abschnitt‑Überladung von [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare übernommen?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notizen‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten betreffen, prüfen Sie das Ergebnis, da diese Szenarien Präsentations‑ und nicht nur Folien‑Strukturen betreffen.

**Was geschieht mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach der Zusammenführung weiterhin verfügbar sein müssen.

**Sind eingebettete Schriftarten aus allen Quellen garantiert in der zusammengeführten Präsentation vorhanden?**

Verlassen Sie sich nicht ausschließlich auf das Klonen von Folien für die Schriftart‑Verteilung. Inspizieren Sie die eingebetteten Schriftarten der Zielpräsentation und verwalten Sie das Einbetten oder die Verfügbarkeit externer Schriftarten explizit, wenn die Typografie wichtig ist.

**Wie füge ich eine passwortgeschützte Datei zusammen?**

Öffnen Sie sie mit dem korrekten [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Nutzen Sie das BLOB‑Management, wenn große Binärobjekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, entsorgen Sie Quellpräsentationen umgehend nach ihrer Verwendung und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Zusammenführungs‑Operation auf eigene Präsentationsinstanzen beschränkt.