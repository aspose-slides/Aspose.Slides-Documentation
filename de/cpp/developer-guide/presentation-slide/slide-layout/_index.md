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
- Foliengestaltung
- ungenutztes Layout
- Fußzeilensichtbarkeit
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
description: "Verwalten und Anpassen von Folienlayouts in Aspose.Slides für C++. Erkunden Sie Layouttypen, Platzhaltersteuerung und Fußzeilensichtbarkeit anhand von C++-Codebeispielen."
---

## **Übersicht**

Ein Folienlayout definiert die Anordnung von Platzhalter‑Boxen und die Formatierung des Inhalts einer Folie. Es steuert, welche Platzhalter verfügbar sind und wo sie angezeigt werden. Folienlayouts helfen Ihnen, Präsentationen schnell und konsistent zu entwerfen – egal, ob Sie etwas Einfaches oder Komplexeres erstellen. Zu den am häufigsten verwendeten Folienlayouts in PowerPoint gehören:

**Titel‑Folienlayout** – Enthält zwei Textplatzhalter: einen für den Titel und einen für den Untertitel.

**Titel‑und‑Inhalts‑Layout** – Zeigt oben einen kleineren Titelplatzhalter und darunter einen größeren für Hauptinhalt (wie Text, Aufzählungspunkte, Diagramme, Bilder und mehr).

**Leeres Layout** – Enthält keine Platzhalter und gibt Ihnen die volle Kontrolle, die Folie von Grund auf zu gestalten.

Folienlayouts sind Teil eines Folienmasters, der die Folie auf höchster Ebene darstellt und Layout‑Stile für die Präsentation definiert. Sie können Layout‑Folien über den Folienmaster zugreifen und ändern – entweder nach Typ, Name oder eindeutiger ID. Alternativ können Sie eine bestimmte Layout‑Folie direkt in der Präsentation bearbeiten.

Um mit Folienlayouts in Aspose.Slides für Android zu arbeiten, können Sie verwenden:
- Methoden wie [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) und [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) in der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 
- Typen wie [ILayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/), und [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Um mehr über die Arbeit mit Master‑Folien zu erfahren, lesen Sie den Artikel [Folienmaster](/slides/de/cpp/slide-master/) .
{{% /alert %}}

## **Folienlayouts zu Präsentationen hinzufügen**

Um das Aussehen und die Struktur Ihrer Folien anzupassen, müssen Sie möglicherweise neue Layout‑Folien zu einer Präsentation hinzufügen. Aspose.Slides für Android ermöglicht es Ihnen, zu prüfen, ob ein bestimmtes Layout bereits existiert, bei Bedarf ein neues hinzuzufügen und es zu verwenden, um Folien basierend auf diesem Layout einzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Greifen Sie auf die [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/) zu.
1. Prüfen Sie, ob die gewünschte Layout‑Folie bereits in der Sammlung vorhanden ist. Falls nicht, fügen Sie die benötigte Layout‑Folie hinzu.
1. Fügen Sie eine leere Folie auf Basis der neuen Layout‑Folie hinzu.
1. Speichern Sie die Präsentation.

Der folgende C++‑Code zeigt, wie man ein Folienlayout zu einer PowerPoint‑Präsentation hinzufügt:
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    //     Eine Situation, in der die Präsentation nicht alle Layout-Typen enthält.
    //     Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layout-Typen.
    //     Allerdings können Layout-Folien mit benutzerdefinierten Typen erkennbare Namen haben,
    //     z. B. "Title", "Title and Content" usw., die für die Auswahl von Layout-Folien verwendet werden können.
    //     Sie können sich auch auf eine Menge von Platzhalter-Formtypen verlassen.
    //     Zum Beispiel sollte eine Titelfolie nur den Titel-Platzhaltertyp haben und so weiter.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Add an empty slide using the added layout slide.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Save the presentation to disk.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Unbenutzte Layout‑Folien entfernen**

Aspose.Slides stellt die Methode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) der Klasse [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) bereit, mit der Sie unerwünschte und unbenutzte Layout‑Folien löschen können.

Der folgende C++‑Code zeigt, wie man eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernt:
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Platzhalter zu Folienlayouts hinzufügen**

Aspose.Slides stellt die Methode [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) bereit, mit der Sie neue Platzhalter zu einer Layout‑Folie hinzufügen können.

Dieser Manager enthält Methoden für die folgenden Platzhaltertypen:

| PowerPoint‑Platzhalter | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/) Methode |
| ---------------------- | ------------------------------------------------------------ |
| ![Inhalt](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Inhalt (Vertikal)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertikal)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Bild](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagramm](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabelle](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medien](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑Bild](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Der folgende C++‑Code zeigt, wie man neue Platzhalter‑Formen zum leeren Layout‑Slide hinzufügt:
```cpp
auto presentation = MakeObject<Presentation>();

// Hole die leere Layoutfolie.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Hole den Platzhalter-Manager der Layoutfolie.
auto placeholderManager = layout->get_PlaceholderManager();

// Füge verschiedene Platzhalter zur leeren Layoutfolie hinzu.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das Ergebnis:

![Die Platzhalter auf der Layout‑Folie](add_placeholders.png)

## **Footer‑Sichtbarkeit für eine Layout‑Folie festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text je nach Layout angezeigt oder ausgeblendet werden. Aspose.Slides für Android ermöglicht es Ihnen, die Sichtbarkeit dieser Fußzeilen‑Platzhalter zu steuern. Dies ist nützlich, wenn Sie möchten, dass bestimmte Layouts Fußzeileninformationen anzeigen, während andere sauber und minimal bleiben.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Layout‑Folie anhand ihres Index.
3. Setzen Sie den Fußzeilen‑Platzhalter der Folie auf sichtbar.
4. Setzen Sie den Foliennummer‑Platzhalter auf sichtbar.
5. Setzen Sie den Datum‑Uhrzeit‑Platzhalter auf sichtbar.
6. Speichern Sie die Präsentation.

Der folgende C++‑Code zeigt, wie man die Sichtbarkeit einer Folien‑Fußzeile einstellt und verwandte Aufgaben ausführt:
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```


## **Footer‑Sichtbarkeit für untergeordnete Folien festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text auf Ebene der Master‑Folie gesteuert werden, um Konsistenz über alle Layout‑Folien hinweg sicherzustellen. Aspose.Slides für Android ermöglicht es Ihnen, die Sichtbarkeit und den Inhalt dieser Fußzeilen‑Platzhalter auf der Master‑Folie festzulegen und diese Einstellungen an alle untergeordneten Layout‑Folien zu propagieren. Dieser Ansatz gewährleistet einheitliche Fußzeileninformationen in der gesamten Präsentation.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Master‑Folie anhand ihres Index.
3. Setzen Sie die Fußzeilen‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
4. Setzen Sie die Foliennummer‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
5. Setzen Sie die Datum‑Uhrzeit‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
6. Speichern Sie die Präsentation.

Der folgende C++‑Code demonstriert diese Operation:
```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Was ist der Unterschied zwischen einer Master‑Folie und einer Layout‑Folie?**

Eine Master‑Folie definiert das Gesamtthema und die Standardformatierung, während Layout‑Folien spezifische Anordnungen von Platzhaltern für verschiedene Inhaltstypen festlegen.

**Kann ich eine Layout‑Folie von einer Präsentation in eine andere kopieren?**

Ja, Sie können eine Layout‑Folie aus der Layout‑Folien‑Sammlung einer Präsentation, die über die Methode [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) zugänglich ist, klonen und sie mit der Methode `AddClone` in eine andere Präsentation einfügen.

**Was passiert, wenn ich eine Layout‑Folie lösche, die noch von einer Folie verwendet wird?**

Wenn Sie versuchen, eine Layout‑Folie zu löschen, die noch von mindestens einer Folie in der Präsentation referenziert wird, wirft Aspose.Slides eine [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/). Um dies zu vermeiden, verwenden Sie [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), das nur die nicht genutzten Layout‑Folien sicher entfernt.