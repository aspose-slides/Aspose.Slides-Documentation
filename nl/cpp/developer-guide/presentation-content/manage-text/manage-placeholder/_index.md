---
title: Beheer Presentatie‑placeholders in C++
linktitle: Beheer Placeholders
type: docs
weight: 10
url: /nl/cpp/manage-placeholder/
keywords:
- placeholder
- tekst‑placeholder
- afbeelding‑placeholder
- diagram‑placeholder
- inhouds‑placeholder
- prompt‑tekst
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u tekst‑, afbeelding‑, diagram‑ en inhouds‑placeholders kunt inspecteren en bewerken en hoe u placeholder‑erfenis begrijpt met Aspose.Slides voor C++."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel, tekst, afbeelding, diagram en algemene content‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een layout‑dia of master‑dia.

Aspose.Slides biedt placeholder‑informatie via de [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/)‑methode. De methode retourneert een [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/)‑object of `nullptr` voor een gewone vorm. Gebruik [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) om te bepalen wat de placeholder moet bevatten.

De vorm‑interface blijft relevant nadat je het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, diagram‑ of content‑placeholder wordt meestal weergegeven door een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
- Een gevulde afbeelding‑placeholder kan worden weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/).
- Een gevulde diagram‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/).
- Een content‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) als de runtime‑vorminterface in plaats van aan te nemen dat elke placeholder een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) is.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een type‑check voordat je tekst-, afbeelding-, diagram‑, tabel‑ of media‑specifieke leden benadert.
{{% /alert %}}

## **Begrijp Placeholder‑Erfenis**

Placeholders vormen een hiërarchie:

1. Een master‑dia definieert herbruikbare stijlen en, in sommige gevallen, master‑level placeholders.
2. Een layout‑dia definieert de indeling die door één of meer normale dia’s wordt gebruikt en kan erven van de master.
3. Een normale dia bevat de placeholders voor die dia en kan erven van zijn layout.

Roep [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) aan om een niveau hoger in deze hiërarchie te gaan. Een dia‑placeholder retourneert normaal zijn layout‑placeholder; een layout‑placeholder kan zijn master‑placeholder retourneren. De methode retourneert `nullptr` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft een overzicht van de placeholders op de eerste dia en meldt hun basishouders:

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

Een placeholder op een normale dia bewerken creëert of wijzigt een lokale overschrijving voor die dia. Het bewerken van de gerelateerde layout of master kan alle dia’s beïnvloeden die die instelling nog erven. Een gewone lokale vorm heeft geen basis‑placeholder en begint niet te erven alleen omdat hij dezelfde coördinaten gebruikt.

## **Placeholder‑status Verwijderen**

Wanneer je een sjabloon aanpast, gebruik je [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) om een bestaand object als een gewone vorm te behouden. Zijn [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/)‑methode retourneert `nullptr`, maar de vorm blijft in de collectie van de dia staan. In tegenstelling tot [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) die de vorm uit die collectie verwijdert.

Het volgende voorbeeld vereist `template.pptx` met minstens één dia en een niet‑lege tekst‑placeholder op de eerste dia. Gebruik een placeholder met opmaak geërfd van zijn layout of master om het effect van het verwijderen van die relatie te zien. Het voorbeeld controleert dat dezelfde vorm blijft, roept de methode opnieuw aan op de nu gewone vorm, en slaat het resultaat op.

{{% alert color="warning" title="Warning" %}}
Het verwijderen van de placeholder‑status behoudt de geërfde weergave‑instellingen niet automatisch. Het voorbeeld laat die instellingen bewust onveranderd, dus de output kan er anders uitzien. Een vorm waarvan positie en grootte volledig geërfd zijn, kan na de oproep nul‑coördinaten en afmetingen hebben en onzichtbaar worden, ook al blijft hij in de collectie.
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // Het aanroepen van de methode op een gewone vorm heeft geen effect.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

Voor een overeenkomende placeholder geven alle drie controles `True` terug. De tekst blijft, maar geërfde positie, grootte, rotatie, lettertype, alinea‑uitlijning, marges van het tekstkader, verticale verankering, vulling en lijneigenschappen kunnen wijzigen wanneer de placeholder‑relatie wordt verwijderd. Bijvoorbeeld, geërfde titelopmaak kan terugvallen op gewone tekstopmaak. Zie [Slide Layout](/slides/nl/cpp/slide-layout/) voor meer over layouts.

Om de beoogde weergave te behouden, leg je de berekende positie, grootte en rotatie vast vóór de aanroep, en kopieer je de benodigde effectieve opmaakwaarden naar afzonderlijke variabelen. Haal die waarden op via [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), en [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/). Vertrouw niet alleen op de effectieve‑formatobjecten, want hun tekst‑opmaakwaarden kunnen veranderen nadat de relatie is verwijderd. Pas de vastgelegde waarden expliciet toe op de gewone vorm daarna, inclusief lettertype‑familie, -grootte, -stijl, -kleur, alinea‑instellingen, tekstkader‑instellingen, vulling en lijn die door jouw sjabloon worden gebruikt.

Geërfde vorm‑geometrie moet mogelijk ook expliciet worden toegewezen via [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/). Voor een rechthoekige tekst‑placeholder betekent dit het toewijzen van [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); alleen de vulling en lijn herstellen kan de zichtbare rechthoek niet herstellen. Sjablonen met extra effecten of complexere opmaak vereisen die instellingen eveneens te behandelen.

## **Tekst Wijzigen in een Placeholder**

Titel‑, gecentreerde‑titel‑, ondertitel‑, body‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) voordat je zijn [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/)‑methode gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste dia bij en slaat het resultaat op:

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

Dit patroon voorkomt het casten van afbeelding‑, diagram‑, tabel‑ of media‑placeholders naar [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Het identificeert bovendien de placeholder op basis van het doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompttekst Instellen op een Layout**

Prompttekst is de ontwerp‑tijd instructie die in een lege placeholder wordt weergegeven, bijvoorbeeld *Klik om titel toe te voegen*. Stel aangepaste prompttekst in op de layout‑placeholder in plaats van deze via de vormcollectie van een normale dia te benaderen. Toegang tot de layout krijg je via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) en itereren over [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de layout die door de eerste dia wordt gebruikt:

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

Prompttekst is geen gewone dia‑inhoud. Het is bedoeld voor lege placeholders in bewerkings‑applicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt bovendien geen bestaande tekst op dia’s die de layout gebruiken.

## **Een Afbeelding‑Placeholder Bijwerken**

Er zijn twee gevallen om te behandelen:

- Als de afbeelding‑placeholder al gevuld is en wordt weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), vervang dan de afbeelding via [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) en [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/).
- Als het nog een lege placeholder is, voeg dan een afbeelding‑frame toe op de coördinaten van de placeholder met [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) en verwijder de lege placeholder.

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

De vervanging die voor een lege placeholder wordt aangemaakt is een lokaal afbeelding‑frame, geen nieuwe placeholder, omdat [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) alleen‑lezen is. Het behoudt de gereserveerde positie maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, bereid en vul de placeholder eerst in PowerPoint, en werk vervolgens het resulterende [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) bij met Aspose.Slides.

Voor transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/cpp/picture-frame/). Die bewerkingen behoren tot het afbeelding‑frame of de afbeelding‑vulling, niet tot placeholder‑metadata.

## **Werken met Diagram‑ en Inhoud‑Placeholders**

Een gevulde diagram‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/). Dit voorbeeld zoekt zo’n diagram via zowel placeholder‑type als runtime‑interface, wijzigt de titel en slaat het bestand op:

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

Een algemene inhoud‑placeholder heeft meestal [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). In PowerPoint fungeert hij als launcher voor verschillende inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat hij is gevuld, inspecteer je de daadwerkelijke vorm‑interface om te weten wat hij bevat. Gespecialiseerde layouts kunnen ook [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), of [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) blootleggen.

Aspose.Slides converteert een lege [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) placeholder niet naar een [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) door alleen [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) te wijzigen; het type is alleen‑lezen. Om een leeg diagram of een leeg inhoudsgebied programmatisch te vullen, voeg je het benodigde object toe op de coördinaten van de placeholder en verwijder je daarna de lege placeholder. Het volgende voorbeeld doet dat voor een diagram:

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

Het toegevoegde diagram is een gewone lokale diagram. Het neemt het gebied van de placeholder in, maar erft niet van de layout‑placeholder. Gebruik de speciale [chart management articles](/slides/nl/cpp/powerpoint-charts/) wanneer je de categorieën, series of werkmapgegevens moet vervangen.

## **Volledig Voorbeeld: Tekst of Afbeeldinginhoud Bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt op de eerste dia naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑types, werkt de geschikte inhoud bij en slaat het resultaat op. Het voorbeeld vermijdt opzettelijk het aannemen van een vorm‑index of het casten van elke placeholder naar dezelfde interface.

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

Een basis‑placeholder is de overeenkomstige vorm op de layout of master waarvan een andere placeholder erft. Gebruik [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) om deze op te halen. Een gewone lokale vorm retourneert `nullptr` omdat ze geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle dia‑titels wijzigen door een layout‑placeholder te bewerken?**

Je kunt geërfde opmaak of prompttekst wijzigen via een layout, maar bestaande titelinhoud wordt opgeslagen op de normale dia’s. Om de daadwerkelijke titeltekst door een hele presentatie heen te vervangen, doorloop je de dia’s en werk je elke titel‑placeholder bij.

**Hoe beheer ik datum‑, dia‑nummer‑, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op het juiste niveau (dia, layout, master, notities of hand-out). Zie [Manage Presentation Header and Footer](/slides/nl/cpp/presentation-header-and-footer/) voor volledige voorbeelden.