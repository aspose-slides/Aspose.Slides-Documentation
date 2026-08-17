---
title: "Beheer van placeholders in C++"
linktitle: "Beheer placeholders"
type: docs
weight: 10
url: /nl/cpp/manage-placeholder/
keywords:
- placeholder
- tekstplaceholder
- afbeeldingsplaceholder
- grafiekplaceholder
- inhoudplaceholder
- prompttekst
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je tekst-, afbeelding-, grafiek- en inhoudsplaceholders kunt inspecteren en bewerken en de erfelijkheid van placeholders kunt begrijpen met Aspose.Slides voor C++."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel‑, tekst‑, afbeelding‑, grafiek‑ en algemene inhouds‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een layout‑slide of master‑slide.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de [IShape::get_Placeholder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_placeholder/) methode. De methode retourneert een [IPlaceholder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iplaceholder/) object of `nullptr` voor een normale vorm. Gebruik [IPlaceholder::get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iplaceholder/get_type/) om te bepalen wat de placeholder zou moeten bevatten.

De vorm‑interface blijft relevant nadat je het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, grafiek‑ of inhoud‑placeholder wordt doorgaans weergegeven door een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/).
- Een gevulde afbeelding‑placeholder kan worden weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/).
- Een gevulde grafiek‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/).
- Een inhouds‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [IPlaceholder::get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iplaceholder/get_type/) als de runtime‑vorminterface in plaats van aan te nemen dat elke placeholder een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) is.

{{% alert color="warning" title="Waarschuwing" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iplaceholder/get_type/) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een type‑check voordat je tekst, afbeelding, grafiek, tabel of media‑specifieke leden benadert.
{{% /alert %}}

## **Begrijp placeholder‑erfenis**

Placeholders vormen een hiërarchie:

1. Een master‑slide definieert herbruikbare stijlen en, in sommige gevallen, master‑level placeholders.
2. Een layout‑slide definieert de indeling die door één of meer normale slides wordt gebruikt en kan erven van de master.
3. Een normale slide bevat de placeholders voor die slide en kan erven van zijn layout.

Roep [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/getbaseplaceholder/) aan om één niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder retourneert normaal zijn layout‑placeholder; een layout‑placeholder kan zijn master‑placeholder retourneren. De methode geeft `nullptr` terug wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft een lijst van placeholders op de eerste slide weer en meldt hun basis‑placeholders:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Een placeholder op een normale slide bewerken creëert of wijzigt een lokale overschrijving voor die slide. Het bewerken van de bijbehorende layout of master kan alle slides beïnvloeden die die instelling nog steeds erven. Een locale gewone vorm heeft geen basis‑placeholder en begint niet te erven alleen omdat hij dezelfde coördinaten bezet.

## **Tekst wijzigen in een placeholder**

Titel-, gecentreerde‑titel-, subtitel‑, tekst‑ en inhouds‑placeholders ondersteunen normaal gesproken tekst. Controleer op [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) voordat je de [get_TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/get_textframe/) methode gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste slide bij en slaat het resultaat op:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Dit patroon vermijdt het casten van afbeelding-, grafiek-, tabel‑ of media‑placeholders naar [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/). Het identificeert de placeholder ook op basis van het doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompt‑tekst instellen op een layout**

Prompt‑tekst is de instructie tijdens het ontwerp die wordt weergegeven in een lege placeholder, zoals *Klik om een titel toe te voegen*. Stel aangepaste prompt‑tekst in op de layout‑placeholder in plaats van te proberen deze te benaderen via de vorm‑collectie van een normale slide. Toegang tot de layout krijg je via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/get_layoutslide/) en je kunt itereren over [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/get_shapes/).

Het volgende voorbeeld wijzigt de titel‑ en subtitel‑prompts op de layout die wordt gebruikt door de eerste slide:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Prompt‑tekst is geen normale slide‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsprogramma's zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt ook niet de bestaande tekst op slides die de layout gebruiken.

## **Een afbeelding‑placeholder bijwerken**

Er zijn twee gevallen om te behandelen:

- Als de afbeelding‑placeholder al gevuld is en wordt weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/), vervang de afbeelding via [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/get_picture/) en [ISlidesPicture::set_Image](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidespicture/set_image/).
- Als het nog een lege placeholder is, voeg dan een afbeelding‑frame toe op de coördinaten van de placeholder met [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addpictureframe/) en verwijder de lege placeholder.

Het volgende voorbeeld ondersteunt beide gevallen en slaat de presentatie op:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

De vervanging die voor een lege placeholder wordt gemaakt is een lokaal afbeelding‑frame, geen nieuwe placeholder, omdat [IShape::get_Placeholder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_placeholder/) alleen‑lezen is. Het behoudt de gereserveerde positie maar erft niet meer het placeholder‑specifieke gedrag. Als het behouden van de placeholder‑relatie essentieel is, maak en vul de placeholder eerst in PowerPoint, en werk vervolgens het resulterende [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) bij met Aspose.Slides.

Voor afbeeldings‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/cpp/picture-frame/). Deze bewerkingen behoren tot het afbeelding‑frame of de afbeelding‑vulling, niet tot de placeholder‑metadata.

## **Werken met grafiek‑ en inhouds‑placeholders**

Een gevulde grafiek‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/). Dit voorbeeld vindt zo'n grafiek zowel via het placeholder‑type als de runtime‑interface, wijzigt de titel en slaat het bestand op:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Een algemene inhouds‑placeholder heeft meestal [PlaceholderType::Object](https://reference.aspose.com/slides/nl/cpp/aspose.slides/placeholdertype/). In PowerPoint fungeert deze als een starter voor verschillende inhoudstypen, waaronder grafieken, tabellen, diagrammen, afbeeldingen en media. Nadat deze is gevuld, inspecteer je de feitelijke vorm‑interface om te weten wat het bevat. Gespecialiseerde lay‑outs kunnen ook [PlaceholderType::Chart](https://reference.aspose.com/slides/nl/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/nl/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/nl/cpp/aspose.slides/placeholdertype/) of [PlaceholderType::Diagram](https://reference.aspose.com/slides/nl/cpp/aspose.slides/placeholdertype/) blootleggen.

Aspose.Slides converteert een lege [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) placeholder niet naar een [IChart](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/) alleen door [IPlaceholder::get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iplaceholder/get_type/) te wijzigen; het type is alleen‑lezen. Om een lege grafiek‑ of inhouds‑gebied programmatically te vullen, voeg je het vereiste object toe op de coördinaten van de placeholder en verwijder je vervolgens de lege placeholder. Het volgende voorbeeld doet dit voor een grafiek:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

De toegevoegde grafiek is een gewone locale grafiek. Hij neemt het gebied van de placeholder in beslag maar erft niet van de layout‑placeholder. Gebruik de speciale [chart management articles](/slides/nl/cpp/powerpoint-charts/) wanneer je de categorieën, series of werkboek‑gegevens moet vervangen.

## **Volledig voorbeeld: Tekst‑ of afbeeldingsinhoud bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt de eerste slide op een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑types, werkt de relevante inhoud bij en slaat de output op. Het voorbeeld vermijdt opzettelijk het aannemen van een vorm‑index of het casten van elke placeholder naar dezelfde interface.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Wat is een basis‑placeholder?**

Een basis‑placeholder is de overeenkomstige vorm op de layout of master waarvan een andere placeholder erft. Gebruik [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/getbaseplaceholder/) om deze op te halen. Een gewone locale vorm retourneert `nullptr` omdat hij geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle slide‑titels wijzigen door een layout‑placeholder te bewerken?**

Je kunt geërfde opmaak of prompt‑tekst wijzigen via een layout, maar bestaande titelinhoud staat opgeslagen op de normale slides. Om de werkelijke titeltekst in een hele presentatie te vervangen, moet je over de slides itereren en elke titel‑placeholder bijwerken.

**Hoe beheer ik datum-, slide‑nummer-, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op de juiste slide-, layout‑, master‑, notities‑ of handout‑scope. Zie [Manage Presentation Header and Footer](/slides/nl/cpp/presentation-header-and-footer/) voor volledige voorbeelden.