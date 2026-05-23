---
title: "Verwalten von Folienmastern in Präsentationen mit C++"
linktitle: "Folienmaster"
type: docs
weight: 80
url: /de/cpp/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT-Masterfolie
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
description: "Verwalten Sie Folienmaster in Aspose.Slides für C++: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert gemeinsam genutzte Designeinstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Designthemen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters der übliche Weg, eine Präsentation konsistent zu halten, ohne die gleiche Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für C++ unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Folienmaster enthalten, und jeder Folienmaster kann mehrere Layoutfolien enthalten. Normale Folien verweisen normalerweise nicht direkt auf einen Folienmaster. Stattdessen verwendet eine normale Folie eine Layoutfolie, und diese Layoutfolie gehört zu einem Folienmaster.

Die Hierarchie lautet:

1. **Folienmaster** – definiert das gemeinsame Design und Thema.
1. **Layoutfolie** – definiert eine spezifische Anordnung von Platzhaltern und layoutbezogene Formatierungen.
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layoutfolie.

![Die Hierarchie von Folienmastern, Layoutfolien und Normalfolien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch das Interface [IMasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/) dargestellt. Alle Folienmaster in einer Präsentation sind über die Sammlung [Presentation::get_Masters](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_masters/) verfügbar, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslidecollection/) implementiert.

{{% alert color="info" title="Inheritance" %}}
Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Beispiel: Wenn ein Folienmaster und eine Layoutfolie beide einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Hintergrund des Layouts. Weitere Informationen zu Layoutfolien finden Sie unter [Apply or Change Slide Layouts](/slides/de/cpp/slide-layout/).
{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster-Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Folienmaster-Befehl auf der PowerPoint-Ansichtregisterkarte](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Sammlung `get_Masters()` zum Zugriff auf Folienmaster:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Sie können den von einer normalen Folie verwendeten Folienmaster auch über deren Layout abrufen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Was ein Folienmaster enthält**

Ein Folienmaster ist ein folienähnliches Objekt. Es implementiert [IBaseSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/), sodass es viele der gleichen Folieneigenschaften wie normale und Layoutfolien bereitstellt. Master‑spezifische Mitglieder sind auf der API‑Seite [IMasterSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/imasterslide/) aufgelistet.

Häufig verwendete Folienmaster‑Mitglieder umfassen:

| Member | Zweck |
| --- | --- |
| `get_Background()` | Legt den Hintergrund auf Master‑Ebene fest. |
| `get_Shapes()` | Speichert Formen, die auf dem Master platziert werden, wie Logos, Bildrahmen und gemeinsamen Text. |
| `get_LayoutSlides()` | Speichert die Layoutfolien, die zum Master gehören. |
| `get_ThemeManager()` | Bietet Zugriff auf die Master‑Theme‑APIs. |
| `get_HeaderFooterManager()` | Steuert Header, Footer, Datum und Foliennummern für den Master und seine untergeordneten Layouts. |
| `GetDependingSlides()` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Dies ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende Bildelemente.

Das folgende Beispiel fügt dem ersten Folienmaster ein Logo hinzu:

```cpp
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

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layoutfolien definiert. Der Folienmaster liefert den gemeinsamen Stil und das Thema, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalter‑Befehle in der Folienmaster‑Ansicht verfügbar.

![Der Befehl Platzhalter einfügen in der PowerPoint‑Folienmaster‑Ansicht](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layoutfolie, die zum Master gehört:

```cpp
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

Sie können auch Platzhalterformen formatieren, die bereits auf einem Folienmaster vorhanden sind. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Verlaufsfüllung an:

```cpp
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

Weitere Platzhalter‑ und Textformatierungsoptionen finden Sie unter [Set Prompt Text in Placeholder](/slides/de/cpp/manage-placeholder/) und [Text Formatting](/slides/de/cpp/text-formatting/).

## **Hintergrund eines Folienmasters ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für den ersten Folienmaster:

```cpp
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

Eine Präsentation kann mehrere Folienmaster enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Marken, Seitenstrukturen oder Themen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Folienmastern](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```cpp
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

Folienmaster können mit der von [IBaseSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/) geerbten `Equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt, wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

```cpp
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
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Weitere Ansichts‑Einstellungen finden Sie unter [Save Presentation](/slides/de/cpp/save-presentation/).

## **Unbenutzte Folienmaster entfernen**

Präsentationen enthalten manchmal Folienmaster, die von keiner normalen Folie mehr verwendet werden. Das Entfernen unbenutzter Master kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/de/cpp/aspose.slides/masterslidecollection/removeunused/), um unbenutzte Master aus der Sammlung `get_Masters()` zu entfernen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sie können außerdem die Low‑Code‑Methode [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) verwenden:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Was ist der Unterschied zwischen einem Folienmaster und einer Layoutfolie?**

Ein Folienmaster definiert gemeinsam genutzte Designeinstellungen wie Thema, Hintergrund, gemeinsame Formen und Textstile. Eine Layoutfolie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layoutfolie und erbt somit sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Marken benötigen.

**Soll ich Platzhalter zu einem Folienmaster oder zu einer Layoutfolie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layoutfolien hinzu. Gemeinsame visuelle Elemente und gemeinsame Formatierungen kommen auf den Folienmaster, während Inhalts‑Platzhalter auf den Layouts platziert werden, die von normalen Folien verwendet werden.

**Kann ich einen Folienmaster löschen, der noch verwendet wird?**

Nein. Ein Folienmaster, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zuerst diese Folien zu Layouts unter einem anderen Master oder nutzen Sie eine Bereinigungs‑Methode, die nur unbenutzte Master entfernt.