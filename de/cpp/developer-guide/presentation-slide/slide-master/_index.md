---
title: Verwalten von Folienmastern in Präsentationen mit C++
linktitle: Folienmaster
type: docs
weight: 80
url: /de/cpp/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT‑Masterfolie
- mehrere Masterfolien
- Masterfolien vergleichen
- Hintergrund
- Platzhalter
- Masterfolie klonen
- Masterfolie kopieren
- Masterfolie duplizieren
- unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für C++: Zugriff, Bearbeitung, Klonen, Vergleichen und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert gemeinsam genutzte Designeinstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Themen‑Einstellungen und Fußzeilen‑Einstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters der übliche Weg, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für C++ unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Folienmaster enthalten, und jeder Folienmaster kann mehrere Layout‑Folien enthalten. Normale Folien verweisen normalerweise nicht direkt auf einen Folienmaster. Stattdessen verwendet eine normale Folie eine Layout‑Folie, und diese Layout‑Folie gehört zu einem Folienmaster.

Die Hierarchie lautet:

1. **Folienmaster** – definiert das gemeinsame Design und Thema.  
1. **Layout‑Folie** – definiert eine spezifische Anordnung von Platzhaltern und Layout‑Formatierungen.  
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layout‑Folie.

![Die Hierarchie von Folienmastern, Layout‑Folien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch die Schnittstelle [IMasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/) repräsentiert. Alle Folienmaster einer Präsentation sind über die Sammlung [Presentation::get_Masters](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_masters/) verfügbar, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/) implementiert.

{{% alert color="info" title="Inheritance" %}}
Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Beispielsweise verwenden Folien, die auf einem Layout basieren, das Hintergrundbild des Layouts, wenn sowohl ein Folienmaster als auch das Layout einen Hintergrund definieren. Weitere Informationen zu Layout‑Folien finden Sie unter [Apply or Change Slide Layouts](/slides/de/cpp/slide-layout/).
{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Befehl Folienmaster auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Sammlung `get_Masters()` zum Zugriff auf Folienmaster:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Sie können den von einer normalen Folie verwendeten Folienmaster auch über deren Layout erhalten:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Inhalt eines Folienmasters**

Ein Folienmaster ist ein folienähnliches Objekt. Er implementiert [IBaseSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/), sodass er viele der gleichen Folien‑Eigenschaften wie normale und Layout‑Folien bereitstellt. Master‑spezifische Mitglieder sind auf der API‑Seite [IMasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/) aufgelistet.

Häufig verwendete Folienmaster‑Mitglieder umfassen:

| Mitglied | Zweck |
| --- | --- |
| `get_Background()` | Legt den Folienhintergrund auf Master‑Ebene fest. |
| `get_Shapes()` | Speichert Formen, die auf dem Master platziert wurden, z. B. Logos, Bildrahmen und gemeinsamen Text. |
| `get_LayoutSlides()` | Speichert die Layout‑Folien, die zum Master gehören. |
| `get_ThemeManager()` | Gibt Zugriff auf die Master‑Theme‑APIs. |
| `get_HeaderFooterManager()` | Steuert Kopf‑, Fußzeilen, Datum und Foliennummern für den Master und seine untergeordneten Layouts. |
| `GetDependingSlides()` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende Bildelemente.

Das folgende Beispiel fügt dem ersten Folienmaster ein Logo hinzu:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Weitere Informationen zu Bildrahmen finden Sie unter [Picture Frame](/slides/de/cpp/picture-frame/).

## **Sichtbarkeit von Master‑Grafiken steuern**

Verwenden Sie [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/set_showmastershapes/), um geerbte Master‑Grafiken, wie Logos oder dekorative Formen, auszublenden, ohne sie aus dem Master zu löschen. übergeben Sie `false` an [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/set_showmastershapes/) auf der Folie, die diese Grafiken weglassen soll, und `true` auf Folien, die sie anzeigen sollen.

Das folgende, eigenständige Beispiel erstellt ein blaues dekoratives Band auf einem Master und zwei Folien, die dasselbe leere Layout verwenden. Das Band ist auf der ersten Folie sichtbar und auf der zweiten ausgeblendet. Keine Eingabe‑Präsentation oder Bilddatei ist erforderlich.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Beispiel verwendet das mit einer neuen Präsentation gelieferte **Blank**‑Layout und entfernt die Platzhalter der ursprünglichen Folie.

### **Geltungsbereich der Einstellung wählen**

Eine normale Folie greift über [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/get_layoutslide/) und [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ilayoutslide/get_masterslide/) auf ihren Master zu. Das Setzen der Eigenschaft auf einer einzelnen Folie wirkt nur auf diese Folie. Das Übergeben von `false` an [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/de/cpp/aspose.slides/layoutslide/set_showmastershapes/) blendet Master‑Grafiken für alle Folien aus, die dieses geteilte Layout verwenden, selbst wenn deren eigene Einstellung `true` ist. Um Grafiken nur auf einer Folie auszublenden, ändern Sie die Folien‑Eigenschaft und lassen das geteilte Layout unverändert.

Die Einstellung wird als Sichtbarkeits‑Steuerung auf dem Folienmaster selbst nicht unterstützt. Auf einem Master liefert sie immer `false`, und das Zuweisen von `true` wirft `System::NotSupportedException`. Wenden Sie sie auf eine normale Folie oder ein Layout an.

### **Grafiken vom Hintergrund unterscheiden**

| Vorgang | Wirkung |
| --- | --- |
| Master‑Grafiken ausblenden | Steuert die Sichtbarkeit geerbter Master‑Formen, ohne sie zu löschen oder die eigenen Formen der Folie zu ändern. |
| Folien‑Hintergrundfüllung ändern | Ändert die Hintergrundfarbe, den Verlauf oder das Bild. Master‑Grafiken sind separate Formen und können über diesem Hintergrund sichtbar bleiben. Siehe [Presentation Background](/slides/de/cpp/presentation-background/). |
| Form vom Master löschen | Entfernt die gemeinsam genutzte Quellform, sodass sie nicht mehr für irgendeine Folie verfügbar ist, die diesen Master verwendet. |

## **Mit Platzhaltern arbeiten**

Platzhalter werden normalerweise auf Layout‑Folien definiert. Der Folienmaster liefert den gemeinsamen Stil und das Thema, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalter‑Befehle in der Folienmaster‑Ansicht verfügbar.

![Der Befehl Platzhalter einfügen in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layout‑Folie, die zum Master gehört:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sie können auch vorhandene Platzhalter‑Formen, die bereits auf einem Folienmaster existieren, formatieren. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Formatierter Titel‑Platzhalter, der von normalen Folien geerbt wird](slide-master_8.png)

Weitere Optionen für Platzhalter‑ und Textformatierung finden Sie unter [Set Prompt Text in Placeholder](/slides/de/cpp/manage-placeholder/) und [Text Formatting](/slides/de/cpp/text-formatting/).

## **Hintergrund eines Folienmasters ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für den ersten Folienmaster:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Verwandte Themen finden Sie unter [Presentation Background](/slides/de/cpp/presentation-background/) und [Presentation Theme](/slides/de/cpp/presentation-theme/).

## **Einen Folienmaster in eine andere Präsentation klonen**

Verwenden Sie [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/addclone/), um einen Folienmaster in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Wenn Sie normale Folien zusammen mit ihrem Master klonen müssen, siehe [Clone Slides](/slides/de/cpp/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Folienmaster enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenauftritte, Seitenstrukturen oder Themen‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Folienmastern](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie hinzu, die auf diesem Layout basiert:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Folienmaster vergleichen**

Folienmaster können mit der von [IBaseSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/) geerbten `Equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Weitere Informationen finden Sie unter [Compare Presentation Slides](/slides/de/cpp/compare-slides/).

## **Folienmaster‑Ansicht als Standard‑Ansicht festlegen**

Verwenden Sie die Methode `set_LastView` auf [ViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Weitere Ansicht‑Einstellungen finden Sie unter [Save Presentation](/slides/de/cpp/save-presentation/).

## **Unbenutzte Folienmaster entfernen**

Präsentationen enthalten manchmal Folienmaster, die von keiner normalen Folie mehr verwendet werden. Das Entfernen ungenutzter Master kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/de/cpp/aspose.slides/masterslidecollection/removeunused/), um ungenutzte Master aus der Sammlung `get_Masters()` zu entfernen:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sie können außerdem die Low‑Code‑Methode [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) verwenden:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Was ist der Unterschied zwischen einem Folienmaster und einer Layout‑Folie?**

Ein Folienmaster definiert gemeinsam genutzte Designeinstellungen wie Thema, Hintergrund, gemeinsame Formen und Textstile. Eine Layout‑Folie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layout‑Folie und erbt dadurch sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Markenauftritte benötigen.

**Sollte ich Platzhalter zu einem Folienmaster oder zu einer Layout‑Folie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layout‑Folien hinzu. Gemeinsame visuelle Elemente und gemeinsame Formatierungen kommen auf den Folienmaster, während Inhalt‑Platzhalter auf den Layout‑Folien platziert werden, die von normalen Folien verwendet werden.

**Kann ich einen Folienmaster löschen, der noch verwendet wird?**

Nein. Ein Folienmaster, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zuerst diese Folien zu Layouts unter einem anderen Master, oder verwenden Sie eine Bereinigungs‑Methode, die nur ungenutzte Master entfernt.