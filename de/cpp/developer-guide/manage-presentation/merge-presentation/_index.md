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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in C++ durch Klonen von Folien, Steuerung von Mastern und Layouts, Anpassen der Foliengröße, Beibehalten von Abschnitten und Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides for C++ kombiniert Präsentationen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) in eine andere geklont werden. Der Hauptvorgang ist [ISlideCollection::AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/), die entweder die Formatierung der Quellfolie beibehalten oder die geklonte Folie einem Master oder Layout in der Zielpräsentation zuordnen kann.

Dieser Artikel behandelt die gebräuchlichsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei deren Quellformatierung beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zielpräsentation anwenden;
- Ein bestimmtes Layout aus der Zielpräsentation anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑zu‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriftarten, Passwörter, große Dateien und Multithreading‑Probleme behandeln.

## **Wie das Klonen von Folien die Master‑ und Layouts beeinflusst**

Eine Folie übernimmt einen Großteil ihres Aussehens von ihrem Layout und Master. Aus diesem Grund bestimmt die gewählte Überladung von `AddClone`, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [ISlideCollection::AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) auf eine der folgenden Arten:

- `AddClone(sourceSlide)` — Erhält das Layout und die Formatierung der Quellfolie. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — Ordnet die geklonte Folie einem bestimmten Ziel‑[IMasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/) zu. Aspose.Slides sucht unter diesem Master nach einem passenden Layout nach Layout‑Typ oder Name.
- `AddClone(sourceSlide, destinationLayout)` — Ordnet die geklonte Folie direkt einem bestimmten Ziel‑[ILayoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/) zu.

Der an `AddClone` übergebene Master oder das Layout muss zur **Ziel‑**Präsentation gehören, nicht zur Quell‑Präsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Die einfachste Variante kopiert jede Folie der Quell‑Präsentation in die Ziel‑Präsentation. Das ist die richtige Wahl, wenn die importierten Folien ihr ursprüngliches Thema, Master und Layout‑Beziehungen behalten sollen.

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

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Ziel‑Präsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung bewusst erhalten bleibt.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folienindizes aus der Quell‑Präsentation.

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

Verwenden Sie die Überladung [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/), wenn importierte Folien einem Master folgen sollen, der bereits zur Ziel‑Präsentation gehört.

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

Aspose.Slides wählt ein geeignetes Layout unter dem angegebenen Master aus, indem es den Layout‑Typ oder Namen der Quellfolie abgleicht. Existiert kein passendes Layout und ist `allowCloneMissingLayout` `true`, wird das Quell‑Layout geklont, damit die Folie hinzugefügt werden kann. Ist es `false`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/cpp/aspose.slides/details_pptxeditexception/) ausgelöst.

Verwenden Sie `false`, wenn der Merge fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

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

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht neu. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass die geerbte Formatierung und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit verschiedenen Folienmaßen können zusammengeführt werden, jedoch passt das Klonen einer Folie in eine Präsentation mit anderer Foliengröße den Inhalt nicht automatisch an die neue Leinwand an. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktikabler Ansatz ist, die Quell‑Präsentation vor dem Klonen zu skalieren. Die Methode [SlideSize::SetSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesize/setsize/) kann vorhandenen Inhalt skalieren, während die Folienmaße geändert werden. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesizescaletype/) skaliert den Inhalt, sodass er in die gewünschte Größe passt.

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

Das Ändern der Größe modifiziert das Quell‑Präsentationsobjekt im Speicher. Wenn Sie die ursprüngliche Quell‑Präsentation unverändert für andere Vorgänge benötigen, öffnen Sie für den Merge eine separate Instanz.

## **Folien in einen Präsentationsabschnitt einfügen**

Die grundlegende Folien‑Klon‑Schleife reproduziert die Abschnittshierarchie der Quell‑Präsentation nicht. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Ziel‑Präsentation und klonen Sie Folien explizit mit [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/).

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

Die geklonten Folien werden an den angegebenen Ziel‑Abschnitt angehängt. Um mehrere Quell‑Abschnitte zu erhalten, enumerieren Sie [Presentation::get_Sections](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_sections/), rufen Sie die aktuellen Folien jedes Quell‑Abschnitts mit [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/getslideslistofsection/) ab, erstellen Sie die Abschnitte in der Ziel‑Präsentation neu und klonen Sie jede zurückgegebene Folie in den entsprechenden Ziel‑Abschnitt. Siehe [Manage Slide Sections](/slides/de/cpp/slide-section/) für ein vollständiges Beispiel zur Abschnitt‑Enumeration, einschließlich leerer Abschnitte und struktureller Änderungen.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur so lange geöffnet, wie sie kopiert wird, und speichert die resultierende Datei einmal am Ende.

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

Dies ist ein nützliches Grundgerüst, um die Quellformatierung importierter Folien zu erhalten. Wenn Ihr Ergebnis ein einheitliches Ziel‑Thema verwenden muss, ersetzen Sie den einfachen Aufruf `AddClone(slide)` durch die zuvor gezeigte Überladung mit Ziel‑Master oder Ziel‑Layout.

## **Praktische Überlegungen**

### **Master, Layouts und Formatierungstreue**

Standard‑Folienklonen kann einen erforderlichen Quell‑Master automatisch in die Ziel‑Präsentation einbringen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um zu verhindern, dass derselbe Master mehrfach geklont wird. Manuell geklonte Master werden von diesem Register nicht erfasst, daher sollten Sie Master nicht vorab klonen, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit gleichem Namen visuell gleichwertig sind. Wenn ein Corporate‑Template das endgültige Aussehen bestimmen soll, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout explizit und prüfen Sie das Ergebnis nach dem Merge.

### **Notizen und Kommentare**

Sprechernotizen und Folienkommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie mitkopiert. Aspose.Slides stellt außerdem dedizierte APIs für [presentation notes](/slides/de/cpp/presentation-notes/) und [presentation comments](/slides/de/cpp/presentation-comments/) bereit.

Ist die Formatierung der Notizenseite wichtig, überprüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows sollten Sie zudem die Autoren der Kommentare und ggf. verschachtelte Kommentare nach dem Zusammenführen aus unterschiedlichen Quellen prüfen.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst, anstatt nur ihre sichtbaren Formen zu kopieren, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen beibehalten kann.

Eingebettete und verknüpfte Ressourcen sind unterschiedlich zu behandeln. Ein verknüpftes Audio, Video, OLE‑Objekt oder Hyperlink bleibt abhängig von seinem externen Ziel; das Klonen einer Folie wandelt einen externen Link nicht in eingebetteten Inhalt um. Testen Sie Pfade und URLs verknüpfter Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides protokolliert zwar automatisch geklonte Master, dies sollte nicht als generelle Garantie dafür angesehen werden, dass identische Binär‑Ressourcen aus unabhängigen Quell‑Präsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, untersuchen Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplizierung zu verlassen.

### **Eingebettete Schriftarten und Schriftartenverfügbarkeit**

Schriftarten werden auf Präsentationsebene verwaltet. Wenn die Typografie über verschiedene Rechner hinweg konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede benötigte Schriftart in der Ziel‑Umgebung verfügbar ist. Sie können eingebettete Schriftarten mit [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/getembeddedfonts/) prüfen und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](/slides/de/cpp/embedded-font/) beschrieben.

Stellen Sie zudem sicher, dass Sie das Recht haben, die in den Quell‑Dateien verwendeten Schriftarten einzubetten. Lizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor deren Folien geklont werden können. Geben Sie das Passwort über [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/) an.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Das Öffnen einer verschlüsselten Quelle wendet den Schutz nicht automatisch auf die Ziel‑Präsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen großen Binär‑Objekten können erhebliche Mengen an Speicher beanspruchen. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateien. Siehe [Manage Presentation BLOBs](/slides/de/cpp/manage-blob/) für Strategien im Umgang mit großen Dateien.

Bei großen Dateien sollten Sie bevorzugt aus Dateipfaden laden, jede Quell‑Präsentation sofort nach dem Merge freigeben und das wiederholte Speichern von Zwischenergebnissen vermeiden, es sei denn, der Workflow erfordert Prüfpunkte.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Präsentations‑Instanz auf einen Merge‑Vorgang beschränkt. Wenn Sie unabhängige Jobs parallelisieren, verwenden Sie unabhängige Präsentations‑Instanzen und befolgen Sie die [Aspose.Slides‑Multithreading‑Leitlinie](/slides/de/cpp/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quell‑Präsentation bei?**

Verwenden Sie [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den erforderlichen Quell‑Master automatisch klonen.

**Wie bringe ich importierte Folien dazu, das Ziel‑Thema zu verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Ziel‑Präsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quell‑Folie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout statt eines Ziel‑Masters verwenden?**

Verwenden Sie ein festes Layout, wenn jede importierte Folie ein bekanntes Layout benutzen soll. Verwenden Sie einen Master, wenn Sie Aspose.Slides die Auswahl zwischen den Layouts dieses Masters basierend auf dem Typ oder Namen des Quell‑Layouts überlassen möchten.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, jedoch wird der Folieninhalt nicht automatisch für die Ziel‑Abmessungen neu gestaltet. Skalieren Sie die Quell‑Präsentation zuerst, wenn Sie eine vorhersehbare Platzierung benötigen, zum Beispiel mit [SlideSize::SetSize](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesize/setsize/) und [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quell‑Präsentation, klonen Sie die gewünschten Folien in eine Ziel‑Präsentation und speichern Sie das Ergebnis in einem unterstützten Ausgabeformat. Da die Formate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach einem Format‑übergreifenden Merge. Siehe [Supported File Formats](/slides/de/cpp/supported-file-formats/).

**Werden Quell‑Abschnitte automatisch erhalten?**

Nicht durch eine Grundschleife, die nur Folien klont. Reproduzieren Sie die benötigten Abschnitte in der Ziel‑Präsentation und verwenden Sie die Abschnitt‑Überladung von [AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidecollection/addclone/), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare erhalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notizen‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten betreffen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien Präsentations‑ und Folien‑Strukturen betreffen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass die Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriftarten aus jeder Quelle im zusammengeführten Dokument garantiert verfügbar?**

Verlassen Sie sich nicht ausschließlich auf das Klonen von Folien für die Schriftarten‑Bereitstellung. Prüfen Sie die eingebetteten Schriftarten der Ziel‑Präsentation und verwalten Sie das Einbetten oder die Verfügbarkeit externer Schriftarten explizit, wenn Typografie wichtig ist.

**Wie merge ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem korrekten [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Verwenden Sie das BLOB‑Management, wenn große Binär‑Objekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, geben Sie Quell‑Präsentationen sofort nach dem Merge frei und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Merge‑Operation auf eigene Präsentations‑Instanzen beschränkt.