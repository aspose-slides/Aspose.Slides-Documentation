---
title: Verwalten von Präsentationskopf‑ und Fußzeilen in C++
linktitle: Kopf‑ und Fußzeile
type: docs
weight: 140
url: /de/cpp/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile festlegen
- Fußzeile festlegen
- Handzettel
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Platzhalter für Fußzeile, Datum‑Uhrzeit, Foliennummer und Kopfzeile auf Folien, Notizseiten und Handzetteln mit Aspose.Slides für C++ verwalten."
---
## **Übersicht**

PowerPoint verwendet je nach Folientyp unterschiedliche Platzhalter für Kopf‑ und Fußzeile. Aspose.Slides für C++ ermöglicht die Steuerung von Text und Sichtbarkeit dieser Platzhalter über die Kopf‑/Fußzeilen‑Manager‑Schnittstellen.

Die verfügbaren Platzhalter hängen vom Geltungsbereich ab:

| Geltungsbereich | Kopfzeile | Fußzeile | Datum/Uhrzeit | Folien‑/Seitennummer |
|---|---|---|---|---|
| Normale Folie | Nein | Ja | Ja | Ja |
| Notizen‑Master | Ja | Ja | Ja | Ja |
| Notizfolie | Ja | Ja | Ja | Ja |
| Handzettel‑Master | Ja | Ja | Ja | Ja |

Eine reguläre Präsentationsfolie besitzt keinen Kopfzeilen‑Platzhalter. Kopfzeilen sind auf Notizseiten und Handzetteln verfügbar. Für normale Folien verwenden Sie stattdessen die Platzhalter für Fußzeile, Datum/Uhrzeit und Foliennummer.

Der Geltungsbereich einer Änderung hängt vom verwendeten Manager ab. Die [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideheaderfootermanager/)‑Schnittstelle steuert **eine** normale Folie. Die [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/inotesslideheaderfootermanager/)‑Schnittstelle steuert **eine** Notizfolie. Master‑ und Layout‑Manager können Einstellungen zudem auf abhängige Folien übertragen, während die [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/)‑Schnittstelle den Handzettel‑Master steuert.

## **Fußzeile, Datum/Uhrzeit und Foliennummern auf normalen Folien festlegen**

Für normale Folien besteht der typische Ablauf darin, den jeweiligen Folien‑Header/Footer‑Manager zu öffnen, den Fußzeilen‑ und Datum/Uhrzeit‑Text zu setzen, die benötigten Platzhalter zu aktivieren und die Präsentation zu speichern. Foliennummern werden von der Präsentation generiert, daher muss nur deren Sichtbarkeit gesteuert werden.

Verwenden Sie [`SetFooterText`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) und [`SetDateTimeText`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/), um den Text zu setzen, und [`SetFooterVisibility`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) sowie [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/), um die jeweiligen Platzhalter sichtbar zu machen.

Das folgende End‑zu‑Ende‑Beispiel wendet dieselbe Fußzeile, denselben Datum/Uhrzeit‑Text und dieselbe Folien‑Nummer‑Sichtbarkeit auf **alle** normalen Folien an:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Falls Sie nur **eine** Folie aktualisieren möchten, greifen Sie direkt über [`Presentation::get_Slide`](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_slide/) auf diese Folie zu, anstatt die gesamte Folien‑Sammlung zu durchlaufen.

## **Kopf‑ und Fußzeilen im Notizen‑Master festlegen**

Der Notizen‑Master definiert einheitliche Formatierung und Platzhalter‑Verhalten für Notizseiten. Verwenden Sie die [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/)‑Schnittstelle, wenn Sie ausschließlich den Notizen‑Master ändern möchten.

Das folgende Beispiel setzt Kopf‑, Fußzeilen‑ und Datum/Uhrzeit‑Text im Notizen‑Master und macht alle unterstützten Platzhalter auf diesem Master sichtbar:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

Die Methode [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) liefert `nullptr`, wenn die Präsentation keinen Notizen‑Master enthält.

## **Notizen‑Master‑Einstellungen auf untergeordnete Notizfolien anwenden**

Ein Notizen‑Master kann Kopf‑ und Fußzeileneinstellungen sowohl auf sich selbst als auch auf alle abhängigen Notizfolien übertragen. Verwenden Sie die dafür vorgesehenen Propagations‑Methoden der [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/), wenn dieselben Einstellungen über die gesamte Notiz‑Hierarchie hinweg gelten sollen.

Beispielsweise aktualisieren [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) und [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) die Kopfzeile des Notizen‑Masters und aller untergeordneten Kopfzeilen. Entsprechende Methoden stehen für Fußzeilen, Datum/Uhrzeit und Foliennummern bereit.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Die oben genannten Propagations‑Methoden sind [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) sowie [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Kopf‑ und Fußzeilen auf einer einzelnen Notizfolie festlegen**

Eine Notizfolie ist einer bestimmten regulären Folie zugeordnet. Verwenden Sie deren [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/inotesslideheaderfootermanager/)‑Schnittstelle, wenn Sie ausschließlich diese Notizseite anpassen möchten.

Die Methode [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/de/cpp/aspose.slides/inotesslidemanager/addnotesslide/) liefert die Notizfolie zur aktuellen Folie und erstellt sie, falls sie noch nicht existiert. Das folgende Beispiel konfiguriert die Notizseite, die mit der ersten Präsentationsfolie verknüpft ist:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Wenn Sie zuerst Einstellungen vom Notizen‑Master propagieren und anschließend eine einzelne Notizfolie ändern, ermöglichen die nachträglichen Folien‑spezifischen Einstellungen eine unabhängige Anpassung dieser Notizseite.

## **Kopf‑ und Fußzeilen im Handzettel‑Master festlegen**

Handzettel‑Seiten verwenden den Handzettel‑Master für ihre Kopf‑, Fußzeilen‑, Datum/Uhrzeit‑ und Seiten‑Nummer‑Platzhalter. Im Gegensatz zu Notizseiten werden Handzettel‑Einstellungen über den Handzettel‑Master verwaltet, nicht über einzelne Handzettel‑Folien.

Verwenden Sie [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/), um auf den Handzettel‑Master zuzugreifen. Falls er nicht vorhanden ist, rufen Sie [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) auf, um den Standard‑Handzettel‑Master zu erzeugen.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Geltungsbereich und Vererbung verstehen**

Wählen Sie den Header/Footer‑Manager, der dem gewünschten Geltungsbereich entspricht:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/islideheaderfootermanager/) ändert Fußzeile, Datum/Uhrzeit und Folien‑Nummer‑Einstellungen für **eine** normale Folie.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslideheaderfootermanager/) steuert eine Layout‑Folie und kann unterstützte Einstellungen auf abhängige Folien übertragen.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslideheaderfootermanager/) steuert einen regulären Folien‑Master und kann unterstützte Einstellungen auf abhängige Folien übertragen.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasternotesslideheaderfootermanager/) steuert den Notizen‑Master und kann Einstellungen auf **alle** abhängigen Notizfolien übertragen.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/inotesslideheaderfootermanager/) ändert **eine** Notizfolie und unterstützt neben Fußzeile und Datum/Uhrzeit auch einen Kopfzeilen‑Platzhalter.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) ändert den Handzettel‑Master und unterstützt alle vier Platzhalter‑Typen.

Verwenden Sie die Propagation von einem Master‑ oder Layout‑Manager, wenn dieselbe Einstellung in der gesamten Hierarchie gelten soll. Nutzen Sie einen einzelnen Folien‑ bzw. Notiz‑Slide‑Manager, wenn eine lokale Einstellung nur für **eine** Seite erforderlich ist.

## **FAQ**

**Kann ich einer normalen Folie eine Kopfzeile hinzufügen?**

Nein. PowerPoint definiert keinen Kopfzeilen‑Platzhalter für normale Folien. Auf normalen Folien verwenden Sie die Platzhalter für Fußzeile, Datum/Uhrzeit und Folien‑Nummer. Kopfzeilen‑Platzhalter stehen nur auf Notizseiten und Handzetteln zur Verfügung.

**Was tun, wenn ein Fußzeilen‑, Datum/Uhrzeit‑ oder Folien‑Nummer‑Platzhalter nicht sichtbar ist?**

Verwenden Sie den entsprechenden Header/Footer‑Manager, um die Sichtbarkeit zu prüfen und bei Bedarf zu aktivieren. Zum Beispiel gibt [`get_IsFooterVisible`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) an, ob ein Fußzeilen‑Platzhalter vorhanden ist, und [`SetFooterVisibility`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) ändert seine Sichtbarkeit.

**Wie starte ich die Folien‑Nummerierung ab einem anderen Wert als 1?**

Verwenden Sie [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/set_firstslidenumber/), um die erste Folien‑Nummer festzulegen. Die Folien‑Nummer‑Platzhalter verwenden dann die aktualisierte Numerierungs‑Sequenz.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren nach PDF, Bildern oder HTML?**

Sichtbare Kopf‑ und Fußzeilen‑Elemente werden zusammen mit dem restlichen Präsentationsinhalt im Ausgabemedium gerendert. Ihr Aussehen hängt vom zu exportierenden Seitentyp und den jeweiligen Platzhalter‑Sichtbarkeitseinstellungen ab.