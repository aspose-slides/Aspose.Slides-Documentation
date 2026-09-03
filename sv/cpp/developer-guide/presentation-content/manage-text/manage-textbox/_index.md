---
title: "Hantera textrutor i presentationer med C++"
linktitle: "Hantera textruta"
type: docs
weight: 20
url: /sv/cpp/manage-textbox/
keywords:
- textruta
- textram
- lägga till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägga till textkolumn
- lägga till hyperlänk
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa, identifiera, formatera och uppdatera textrutor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++."
---
## **Introduktion**

I Aspose.Slides för C++ lagras bildtext i textramar som tillhör former. Gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) representerar den mest vanliga textbärande formen och exponerar dess text via metoden [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Note" %}}

Varje autoshape implementerar [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/), men inte varje form är en autoshape eller stöder en textram. När du bearbetar en befintlig presentation, kontrollera att en form implementerar [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) innan du får åtkomst till dess text.

{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta, lägg till en autoshape på en bild, lägg till text i dess textram och spara presentationen. Följande exempel skapar en rektangulär textruta:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

Koordinaterna och dimensionerna som skickas till [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addautoshape/) mäts i punkter. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/addtextframe/) initierar textramen med den angivna texten.

## **Kontrollera om en form är en textruta**

Använd metoden [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/get_istextbox/) för att avgöra om en autoshape behandlas som en textruta. Detta är användbart när en presentation innehåller både textbärande och enbart grafiska autoshapes.

![En textruta och en form](istextbox.png)

Följande exempel inspekterar varje autoshape i en presentation:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

En nyinlagd autoshape betraktas inte som en textruta förrän den innehåller icke‑tom text. Du kan tillhandahålla den texten via [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/addtextframe/) eller [ITextFrame::set_Text](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/set_text/). Att lägga till eller tilldela en tom sträng får [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/get_istextbox/) att returnera `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

De två första kontrollerna returnerar `true`; de två sista returnerar `false`.

## **Hitta formen som äger en textram**

Generisk textbearbetningskod kan få en [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) utan att veta vilket presentationsobjekt som innehåller den. Använd metoden [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentshape/) för att navigera tillbaka till dess ägande [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/).

För en textram som ägs av en autoshape eller en annan textbärande form, returnerar [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentshape/) ägaren och [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentcell/) returnerar `nullptr`. Båda metoderna ger endast läs‑åtkomst. Kontrollera det returnerade värdet för `nullptr` innan du använder det. För att identifiera både form‑ och tabellcell‑ägare, inklusive former kopplade till SmartArt‑noder, se [Search and Replace Text](/slides/sv/cpp/search-and-replace-text/).

## **Lägg till kolumner i en textruta**

Metoden [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/set_columncount/) delar textramen i kolumner, medan [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/set_columnspacing/) anger avståndet mellan kolumner i punkter. Båda metoderna tillhör [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/) och kan anropas via textramen för en befintlig textruta. Text flödar om mellan kolumner inom samma form; den fortsätter inte i en annan form.

Följande exempel skapar en textruta med tre kolumner och 10 punkters avstånd mellan kolumnerna, sparar presentationen och läser de lagrade inställningarna från utdatafilen:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Extrahera text från enskilda kolumner**

Använd [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/splittextbycolumns/) för att hämta den text som tilldelats varje visuell kolumn i en befintlig textram. Metoden returnerar en sträng för varje kolumn, i kolumnbaserad läsordning. En textram med en enda kolumn ger en array med ett element, och en tom kolumn representeras av en tom sträng. Strängarna innehåller endast vanlig text; formatering på delnivå bevaras inte.

Detta är användbart när du behöver:

- Extrahera text samtidigt som dess kolumnbaserade läsordning bevaras.
- Indexera eller jämföra innehållet i bilder med flera kolumner.
- Exportera varje kolumn till en separat fil, databasfält eller annan destination.
- Inspektera hur text redistribueras efter att kolumnantalet har ställts in med [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/set_columncount/) eller avståndet med [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/set_columnspacing/), eller efter att teckensnitt eller textramsstorlek har ändrats.

Metoden rapporterar den text som fördelas inom den aktuella [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/); den flödar inte automatiskt text mellan separata former eller textrutor. Kolumnfördelning kan bero på tillgängliga teckensnitt och andra textlayoutinställningar, så se till att de erforderliga teckensnitten är tillgängliga när konsekventa resultat är viktiga.

Följande exempel laddar en presentation, hittar den första autoshape med flera kolumner och en textram på den första bilden, läser dess konfigurerade kolumnantal och skriver texten från varje kolumn till en separat fil. Former som inte har en textram hoppar över.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Uppdatera text**

För att uppdatera text i hela en presentation, iterera genom bilderna och formerna, välj autoshapes och redigera sedan deras textdelar. Att arbeta på delnivå låter dig ändra både text och teckenformatering.

Följande exempel ersätter varje förekomst av `years` med `months` i enskilda autoshape‑textdelar och gör varje berörd del fetstil:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Denna traversering uppdaterar endast text i autoshapes. Text som lagras i tabeller, diagram, SmartArt eller grupperade former kräver traversering av dessa objekts egna samlingar.

## **Lägg till en textruta med en hyperlänk**

En hyperlänk kan tilldelas en specifik textdel, så att endast den texten fungerar som den klickbara länken. Använd [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) för att koppla delen till en extern URL.

Följande exempel skapar länkad text och sparar den i en presentation:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **Vanliga frågor**

**Vad är skillnaden mellan en textruta och en textplatshållare på en master‑ eller layout‑bild?**

En [placeholder](/slides/sv/cpp/manage-placeholder/) kan ärva sin position och formatering från en [master slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/masterslide/) eller en [layout slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/layoutslide/). En vanlig textruta är en oberoende form på den bild där den skapades och får inte placeholder‑beteende när layouten ändras.

**Hur kan jag ersätta text utan att ändra text i diagram, tabeller eller SmartArt?**

Begränsa traverseringen till former som implementerar [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/), som visas i exemplet Uppdatera text. Diagram, tabeller och SmartArt lagrar text i sina egna objektmodeller, så de ändras inte av den loopen.