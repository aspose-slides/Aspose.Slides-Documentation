---
title: Folienlayouts in C++ anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/cpp/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
- Platzhalter
- Präsentationsdesign
- Foliendesign
- unbenutztes Layout
- Sichtbarkeit der Fußzeile
- Titelfolie
- Titel und Inhalt
- Abschnittsüberschrift
- Zwei Inhalte
- Vergleich
- Nur Titel
- Leeres Layout
- Inhalt mit Beschriftung
- Bild mit Beschriftung
- Titel und vertikaler Text
- Vertikaler Titel und Text
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: Folienlayouts in Aspose.Slides für C++ anwenden, erstellen und ändern, Platzhalter hinzufügen, unbenutzte Layouts entfernen und die Sichtbarkeit der Fußzeile steuern.
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und die Formatierung von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die am häufigsten verwendeten Layouts umfassen:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen universellen Inhalts‑Platzhalter.
- **Leere Folie**: Enthält keine Inhalts‑Platzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verständnis der Layoutvererbung**

Eine Präsentation hat drei verwandte Ebenen:

1. Ein [Masterfolie](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/) definiert das Thema, die gemeinsame Formatierung, Hintergründe und gemeinsame Objekte.
1. Eine [Layoutfolie](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
1. Eine [Standardfolie](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine Standardfolie erbt Thema und Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer Standardfolie festgelegter Wert überschreibt den geerbten Wert auf dieser Ebene. Wenn eine Standardfolie erstellt wird, werden ihre Platzhalterformen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur Standardfolie gehört.

Fügen Sie einem Layout die erforderlichen Platzhalter hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch die entsprechende Platzhalterform zu bereits vorhandenen Standardfolien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern der geerbten Formatierung oder der vorhandenen Platzhaltergeometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Vor dem Bearbeiten eines bereits verwendeten Layouts sollten Sie dessen abhängige Folien prüfen und die resultierende Präsentation überprüfen.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie seine abhängigen Folien zuerst einem anderen Layout zu oder entfernen Sie nur ungenutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Folienmaster](/slides/de/cpp/slide-master/).

## **Auswahl und Anwendung eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den standardmäßigen PowerPoint-Layoutdefinitionen folgt. Layoutnamen können vom Benutzer bearbeitet und lokalisiert werden, sodass eine namensbasierte Auswahl weniger zuverlässig ist, es sei denn, Sie kontrollieren die Quellvorlage.

Das folgende Beispiel sucht auf dem ersten Master nach **Titel und Inhalt**. Ist dieses Layout nicht verfügbar, fällt es bewusst auf **Leere Folie** zurück. Die zweite Null‑Prüfung ist nötig, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die Methode [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/set_layoutslide/) auf die erste Standardfolie angewendet.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ändern des Layouts einer Folie entfernt nicht die direkt zur Folie hinzugefügten normalen Formen. Platzhalterpositionen, geerbte Formatierungen und die Zuordnung zwischen vorhandenen Platzhaltern und dem neuen Layout können jedoch ändern, sodass Sie die Ausgabe prüfen sollten, wenn Sie zwischen wesentlich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind separate Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die Methode [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterlayoutslidecollection/add/) in der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt anschließend eine darauf basierende Standardfolie. Layoutnamen müssen innerhalb der Sammlung eindeutig sein.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Fügen Sie ein Layout nur hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert ein geeignetes Layout bereits, wählen und verwenden Sie es, anstatt ein Duplikat zu erstellen.

## **Hinzufügen von Platzhaltern zu einer Layoutfolie**

Die Methode [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) liefert ein [ILayoutPlaceholderManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout.

| PowerPoint Platzhalter              | `ILayoutPlaceholderManager`‑Methode |
| ----------------------------------- | ------------------------------------ |
| ![Inhalt](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Inhalt (Vertikal)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertikal)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Bild](picture.png)               | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagramm](chart.png)             | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabelle](table.png)               | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Medien](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Bild](onlineImage.png)     | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Das folgende Beispiel überprüft, ob das **Leere Folie**‑Layout existiert, fügt ihm vier Platzhalter hinzu und erstellt anschließend eine Standardfolie, die das modifizierte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die Standardfolie erstellt wird, sodass Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie erzeugen kann.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die Platzhalter auf der Layoutfolie](add_placeholders.png)

{{% alert color="warning" title="Warnung" %}}
Das Ändern der geerbten Formatierung oder der Geometrie bestehender Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht rückwirkend in bereits vorhandene Standardfolien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Entfernen nicht verwendeter Layoutfolien**

Verwenden Sie die Methode [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), um Layouts zu entfernen, auf die keine Standardfolie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Um ein bestimmtes Layout zu entfernen, verwenden Sie zuerst dessen Methode [get_HasDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) oder [GetDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/getdependingslides/). Ordnen Sie alle abhängigen Folien neu zu, bevor Sie [ILayoutSlide::Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/remove/) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout besitzt eigene Fußzeilen-, Folienzahl‑ und Datums‑Zeit‑Platzhalter. Verwenden Sie die Methode [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/), um diese Platzhalter für ein Layout zu steuern. Das ist nützlich, wenn z. B. Inhalts‑Layouts Fußzeilen anzeigen sollen, Titel‑Layouts jedoch nicht.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einem Master und seinen untergeordneten Layouts**

Um einheitliche Fußzeileneinstellungen über eine Master‑Hierarchie hinweg anzuwenden, verwenden Sie die Methode [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Die Verbreitungsmethoden von [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑Folien und Standardfolien; sie zielen nicht nur auf eine einzelne Standardfolie.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Was ist der Unterschied zwischen einer Masterfolie und einer Layoutfolie?**

Eine Masterfolie definiert das Thema und die gemeinsame Formatierung der Präsentation. Eine Layoutfolie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Standardfolien verwenden diese Layouts und speichern folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie eine Kopie zur Ziel‑Sammlung mit der Methode [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/igloballayoutslidecollection/addclone/) hinzu. Beim Kopieren zwischen Präsentationen sollten Sie zudem Schriften, Themen, Bilder und andere vom Quell‑Layout verwendete Ressourcen überprüfen.

**Was passiert, wenn ich ein bereits verwendetes Layout ändere?**

Abhängige Folien erben die Layout‑Änderungen, sofern sie die betroffene Formatierung oder Objekte nicht lokal überschreiben. Die Platzhaltergeometrie und die geerbten Stile können dadurch auf vielen Folien gleichzeitig geändert werden. Verwenden Sie [GetDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/getdependingslides/), um die betroffenen Folien vor der Bearbeitung des Layouts zu ermitteln.

**Was passiert, wenn ich ein noch verwendetes Layout entferne?**

Aspose.Slides löst eine [PptxEditException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxeditexception/) aus. Ordnen Sie zuerst die abhängigen Folien neu zu, oder verwenden Sie [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), um nur nicht referenzierte Layouts zu entfernen.