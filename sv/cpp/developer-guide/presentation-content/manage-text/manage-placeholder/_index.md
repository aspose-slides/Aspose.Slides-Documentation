---
title: Hantera presentationsplatshållare i C++
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/cpp/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- innehållsplatshållare
- uppmaningstext
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du inspekterar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår platshållarärv med Aspose.Slides för C++."
---
## **Översikt**

En platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel-, brödtext-, bild-, diagram- och allmänna innehållsplatshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och andra inställningar från en layoutbild eller masterbild.

Aspose.Slides exponerar platshållarinformation via metoden [IShape::get_Placeholder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_placeholder/). Metoden returnerar ett [IPlaceholder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iplaceholder/)‑objekt eller `nullptr` för en normal form. Använd [IPlaceholder::get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iplaceholder/get_type/) för att avgöra vad platshållaren är avsedd att innehålla.

Formgränssnittet är fortfarande relevant efter att du känt till platshållartypen:

- En tom text‑, bild‑, diagram‑ eller innehållsplatshållare representeras vanligtvis av en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/).
- En ifylld bildplatshållare kan representeras av en [IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/).
- En ifylld diagramplatshållare kan representeras av en [IChart](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/).
- En innehållsplatshållare kan innehålla flera typer av innehåll. Kontrollera både [IPlaceholder::get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iplaceholder/get_type/) och gränssnittet i körning istället för att anta att varje platshållare är en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Varning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iplaceholder/get_type/) beskriver en platshållares roll; den garanterar inte formens körningstyp. Använd alltid en typkontroll innan du får åtkomst till text, bild, diagram, tabell eller media‑specifika medlemmar.
{{% /alert %}}

## **Förstå platshållarärv**

Platshållare bildar en hierarki:

1. En master‑bild definierar återanvändbara stilar och, i vissa fall, master‑nivå platshållare.
2. En layout‑bild definierar arrangemanget som används av en eller flera vanliga bilder och kan ärva från mastern.
3. En vanlig bild innehåller platshållarna för den bilden och kan ärva från dess layout.

Anropa [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/getbaseplaceholder/) för att gå ett steg upp i denna hierarki. En bildplatshållare returnerar normalt sin layout‑platshållare; en layout‑platshållare kan returnera sin master‑platshållare. Metoden returnerar `nullptr` när formen inte har någon basplatshållare.

Följande exempel listar platshållare på den första bilden och rapporterar deras basplatshållare:

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

Att redigera en platshållare på en vanlig bild skapar eller ändrar en lokal överskrivning för den bilden. Att redigera den relaterade layouten eller mastern kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen basplatshållare och börjar inte ärva bara för att den har samma koordinater.

## **Ändra text i en platshållare**

Titel-, centrerad‑titel‑, undertitel‑, brödtext‑ och text‑platshållare stödjer normalt text. Kontrollera för [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) innan du använder dess [get_TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/get_textframe/)‑metod.

Det här exemplet uppdaterar den första titel‑platshållaren på den första bilden och sparar resultatet:

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

Detta mönster undviker att kasta bild‑, diagram‑, tabell‑ eller media‑platshållare till [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/). Det identifierar också platshållaren efter syfte istället för att förlita sig på ett skört form‑index.

## **Ange uppmaningstext på en layout**

Uppmaningstext är design‑tidsinstruktionen som visas i en tom platshållare, t.ex. *Klicka för att lägga till titel*. Ställ in anpassad uppmaningstext på layout‑platshållaren istället för att försöka nå den via en vanlig bilds formsamling. Åtkomst till layouten sker via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/get_layoutslide/) och iterera över [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/get_shapes/).

Följande exempel ändrar titel‑ och undertitel‑uppmaningar på den layout som används av den första bilden:

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

Uppmaningstext är inte normalt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram som PowerPoint. När en användare eller ett program tillhandahåller verkligt innehåll visas uppmaningen inte längre. Att ändra en uppmaning ersätter inte heller befintlig text på bilder som använder layouten.

## **Uppdatera en bild‑platshållare**

Det finns två fall att hantera:

- Om bild‑platshållaren redan är ifylld och representeras av en [IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/), ersätt bilden via [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/get_picture/) och [ISlidesPicture::set_Image](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidespicture/set_image/).
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addpictureframe/) och ta bort den tomma platshållaren.

Nästa exempel stöder båda fallen och sparar presentationen:

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

Ersättningen som skapas för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [IShape::get_Placeholder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_placeholder/) är skrivskyddad. Den behåller den reserverade positionen men ärver inte längre platshållarspecifikt beteende. Om det är viktigt att behålla platshållarrelationen, förbered och fyll i platshållaren i PowerPoint först, och uppdatera sedan den resulterande [IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bildspecifika effekter, se [Manage Picture Frames](/slides/sv/cpp/picture-frame/). Dessa operationer tillhör bildramen eller bildfyllningen, inte platshållarmetadata.

## **Arbeta med diagram‑ och innehållsplatshållare**

En ifylld diagram‑platshållare kan representeras av en [IChart](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/). Detta exempel hittar ett sådant diagram både via platshållartyp och körningsgränssnitt, ändrar dess titel och sparar filen:

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

En generell innehållsplatshållare har vanligtvis [PlaceholderType::Object](https://reference.aspose.com/slides/sv/cpp/aspose.slides/placeholdertype/). I PowerPoint fungerar den som en lanserare för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. Efter att den har fyllts i, inspektera det faktiska formgränssnittet för att ta reda på vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType::Chart](https://reference.aspose.com/slides/sv/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/sv/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/sv/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/sv/cpp/aspose.slides/placeholdertype/), eller [PlaceholderType::Diagram](https://reference.aspose.com/slides/sv/cpp/aspose.slides/placeholdertype/).

Aspose.Slides konverterar inte en tom [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/)‑platshållare till en [IChart](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/) enbart genom att ändra [IPlaceholder::get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iplaceholder/get_type/); typen är skrivskyddad. För att programmässigt fylla ett tomt diagram eller innehållsområde, lägg till det erforderliga objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

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

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layout‑platshållaren. Använd de dedikerade [chart management articles](/slides/sv/cpp/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsboksdata.

## **Fullständigt exempel: Uppdatera text‑ eller bildinnehåll**

Följande heltäckande exempel öppnar en mall, söker den första bilden efter antingen en titel‑ eller bild‑platshållare, kontrollerar platshållar‑ och formtyper, uppdaterar det lämpliga innehållet och sparar resultatet. Exemplet undviker medvetet att anta ett form‑index eller kasta varje platshållare till samma gränssnitt.

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

**Vad är en basplatshållare?**

En basplatshållare är den motsvarande formen på layouten eller mastern som en annan platshållare ärver från. Använd [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/getbaseplaceholder/) för att hämta den. En vanlig lokal form returnerar `nullptr` eftersom den inte är en del av platshållarhierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layout‑platshållare?**

Du kan ändra ärvd formatering eller uppmaningstext via en layout, men befintligt titelinnehåll lagras på de vanliga bilderna. För att ersätta faktisk titeltext i hela presentationen, iterera över bilderna och uppdatera varje titel‑platshållare.

**Hur hanterar jag datum-, bildnummer-, sidhuvud- och sidfot‑platshållare?**

Använd header‑ och footer‑hanterarna på rätt bild, layout, master, anteckningar eller utdelningsnivå. Se [Manage Presentation Header and Footer](/slides/sv/cpp/presentation-header-and-footer/) för kompletta exempel.