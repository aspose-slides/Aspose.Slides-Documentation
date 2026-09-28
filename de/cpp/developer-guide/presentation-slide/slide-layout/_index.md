---
title: Anwenden oder Ändern von Folienlayouts in C++
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
- ungenutztes Layout
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
description: "Folienlayouts in Aspose.Slides für C++ anwenden, erstellen und ändern, Platzhalter hinzufügen, ungenutzte Layouts entfernen und die Sichtbarkeit der Fußzeile steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und Formatierungen von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, ermöglicht jedoch, dass jede Folie ihren eigenen Inhalt enthält.

Die gängigsten Layouts umfassen:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen allgemeingültigen Inhalts‑Platzhalter.
- **Leer**: Enthält keine Inhalts‑Platzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layoutvererbung**

Eine Präsentation hat drei miteinander verbundene Ebenen:

1. Eine [Masterfolie](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/) definiert das Design, die gemeinsam genutzte Formatierung, Hintergründe und gemeinsame Objekte.
1. Eine [Layoutfolie](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
1. Eine [Normalfolie](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine Normalfolie erbt Design und Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer Normalfolie gesetzter Wert überschreibt den vererbten Wert auf dieser Ebene. Beim Erstellen einer Normalfolie werden ihre Platzhalterformen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur Normalfolie gehört.

Fügen Sie erforderliche Platzhalter zu einem Layout hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout führt nicht automatisch zu einer entsprechenden Platzhalterform in bereits vorhandenen Normalfolien.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern vererbter Formatierungen oder der Geometrie vorhandener Layout‑Platzhalter kann jede davon abhängige Folie aktualisieren. Bevor Sie ein bereits verwendetes Layout bearbeiten, prüfen Sie dessen abhängige Folien und prüfen Sie die resultierende Präsentation.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Weisen Sie seine abhängigen Folien zuerst einem anderen Layout zu oder entfernen Sie nur ungenutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Folienmaster](/slides/de/cpp/slide-master/).

Um geerbte Logos oder dekorative Master‑Formen auf einer Folie oder über ein gemeinsames Layout auszublenden, siehe [Steuerung der Sichtbarkeit von Mastergrafiken](/slides/de/cpp/slide-master/). Das Beispiel vergleicht zwei Folien, die denselben Master verwenden.

## **Auswählen und Anwenden eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den standardmäßigen PowerPoint‑Layout‑Definitionen folgt. Layoutnamen sind vom Benutzer editierbar und können lokalisiert werden, sodass eine namensbasierte Auswahl weniger zuverlässig ist, sofern Sie die Quellvorlage nicht kontrollieren.

Das folgende Beispiel sucht nach **Titel und Inhalt** im ersten Master. Ist dieses Layout nicht verfügbar, wird bewusst auf **Leer** ausgewichen. Die zweite Null‑Prüfung ist notwendig, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/set_layoutslide/)‑Methode auf die erste Normalfolie angewendet.

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

Das Ändern des Layouts einer Folie entfernt nicht die direkt zur Folie hinzugefügten normalen Formen. Platzhalterpositionen, vererbte Formatierungen und die Zuordnung zwischen vorhandenen Platzhaltern und dem neuen Layout können sich jedoch ändern, sodass das Ergebnis beim Wechsel zwischen wesentlich unterschiedlichen Layouts geprüft werden sollte.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind getrennte Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erzeugen, rufen Sie die [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterlayoutslidecollection/add/)‑Methode auf der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout namens `Report Title and Content` hinzu und erstellt anschließend eine Normalfolie, die darauf basiert. Layoutnamen müssen innerhalb der Sammlung eindeutig sein.

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

Fügen Sie ein Layout nur hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert bereits ein geeignetes Layout, wählen Sie es aus und verwenden Sie es erneut, anstatt ein Duplikat zu erzeugen.

## **Platzhalter zu einer Layoutfolie hinzufügen**

Die [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/)‑Methode liefert einen [ILayoutPlaceholderManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout.

| PowerPoint‑Platzhalter              | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Inhalt](content.png)              | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Inhalt (vertikal)](contentV.png)  | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (vertikal)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Bild](picture.png)                | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagramm](chart.png)              | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabelle](table.png)               | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Medien](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online‑Bild](onlineImage.png)     | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Das folgende Beispiel prüft, ob das **Leer**‑Layout existiert, fügt ihm vier Platzhalter hinzu und erzeugt anschließend eine Normalfolie, die das geänderte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die Normalfolie erzeugt wird, sodass Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie generieren kann.

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
Das Ändern vererbter Formatierungen oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht nachträglich in bestehende Normalfolien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Entfernen nicht verwendeter Layoutfolien**

Verwenden Sie die [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)‑Methode, um Layouts zu entfernen, auf die keine Normalfolie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

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

Um ein bestimmtes Layout zu entfernen, prüfen Sie zunächst seine [get_HasDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/)‑Methode oder die [GetDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/getdependingslides/)‑Methode. Weisen Sie alle abhängigen Folien neu zu, bevor Sie [ILayoutSlide::Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/remove/) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout besitzt eigene Fußzeilen‑, Folien‑Nummer‑ und Datum‑Uhr‑Platzhalter. Verwenden Sie die [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/)‑Methode, um diese Platzhalter für ein Layout zu kontrollieren. Dies ist nützlich, wenn beispielsweise Inhalts‑Layouts Fußzeilen anzeigen sollen, Titelfolien jedoch nicht.

Das folgende Beispiel wählt ein Layout sicher aus und macht dessen Fußzeilenelemente sichtbar:

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

Um konsistente Fußzeileneinstellungen über eine Master‑Hierarchie hinweg anzuwenden, nutzen Sie die [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/get_headerfootermanager/)‑Methode. Die Propagationsmethoden von [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑ und Normalfolien; sie zielen nicht nur auf eine einzelne Normalfolie.

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

Eine Masterfolie definiert das Design und die gemeinsam genutzte Formatierung der Präsentation. Eine Layoutfolie gehört zu einem Master und legt eine wiederverwendbare Anordnung von Platzhaltern fest. Normalfolien verwenden diese Layouts und speichern den folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie eine Kopie zur Ziel‑Sammlung mit der [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/igloballayoutslidecollection/addclone/)‑Methode hinzu. Beim Kopieren zwischen Präsentationen sollten Sie zudem Schriftarten, Designs, Bilder und andere vom Quell‑Layout genutzte Ressourcen überprüfen.

**Was passiert, wenn ich ein bereits verwendetes Layout ändere?**

Abhängige Folien übernehmen die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschrieben haben. Die Geometrie von Platzhaltern und vererbte Stile können daher auf vielen Folien gleichzeitig wechseln. Verwenden Sie [GetDependingSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/getdependingslides/), um die betroffenen Folien vor dem Bearbeiten des Layouts zu identifizieren.

**Was passiert, wenn ich ein Layout entferne, das noch verwendet wird?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxeditexception/). Weisen Sie zuerst die abhängigen Folien neu zu oder verwenden Sie [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), um nur nicht referenzierte Layouts zu entfernen.