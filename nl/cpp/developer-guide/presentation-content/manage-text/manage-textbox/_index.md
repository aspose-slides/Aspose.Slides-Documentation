---
title: Beheer tekstvakken in presentaties met C++
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/cpp/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak aanmaken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak, identificeer, formatteer en werk tekstvakken bij in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++."
---
## **Inleiding**

In Aspose.Slides voor C++ wordt de tekst van dia's opgeslagen in tekstframes die bij vormen horen. De [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) interface vertegenwoordigt de meest voorkomende vorm die tekst bevat en geeft de tekst weer via de [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/get_textframe/) methode.

{{% alert color="info" title="Opmerking" %}}

Elke auto‑vorm implementeert [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/), maar niet elke vorm is een auto‑vorm of ondersteunt een tekstframe. Controleer bij het verwerken van een bestaande presentatie of een vorm [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) implementeert voordat u de tekst benadert.

{{% /alert %}}

## **Maak een tekstvak op een dia**

Om een tekstvak te maken, voegt u een auto‑vorm toe aan een dia, voegt u tekst toe aan het tekstframe en slaat u de presentatie op. Het volgende voorbeeld maakt een rechthoekig tekstvak:

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

De coördinaten en afmetingen die aan [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addautoshape/) worden doorgegeven, worden gemeten in points. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/addtextframe/) initialiseert het tekstframe met de opgegeven tekst.

## **Controleren op een tekstvakvorm**

Gebruik de [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/get_istextbox/) methode om te bepalen of een auto‑vorm wordt behandeld als een tekstvak. Dit is handig wanneer een presentatie zowel tekstdragende als puur grafische auto‑vormen bevat.

![Een tekstvak en een vorm](istextbox.png)

Het volgende voorbeeld inspecteert elke auto‑vorm in een presentatie:

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

Een nieuw toegevoegde auto‑vorm wordt pas als tekstvak beschouwd wanneer deze niet‑lege tekst bevat. U kunt die tekst leveren via [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/addtextframe/) of [ITextFrame::set_Text](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/set_text/). Het toevoegen of toewijzen van een lege string zorgt ervoor dat [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/get_istextbox/) `false` retourneert:

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

De eerste twee controles retourneren `true`; de laatste twee retourneren `false`.

## **Vind de vorm die een tekstframe bezit**

Generieke tekstverwerkingscode kan een [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) ontvangen zonder te weten welk presentatie‑object het bevat. Gebruik de [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentshape/) methode om terug te navigeren naar de eigenaar‑[IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/).

Voor een tekstframe dat eigendom is van een auto‑vorm of een andere tekstdragende vorm, retourneert [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentshape/) de eigenaar en retourneert [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr`. Beide methoden bieden alleen‑lezen navigatie. Controleer de geretourneerde waarde op `nullptr` voordat u er toegang toe krijgt. Zie voor het identificeren van zowel vorm‑ als tabelcel‑eigenaars, inclusief vormen die gekoppeld zijn aan SmartArt‑knopen, [Search and Replace Text](/slides/nl/cpp/search-and-replace-text/).

## **Kolommen toevoegen aan een tekstvak**

De [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_columncount/) methode verdeelt het tekstframe in kolommen, terwijl [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_columnspacing/) de ruimte tussen kolommen in points instelt. Beide methoden behoren tot [ITextFrameFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/) en kunnen worden aangeroepen via het tekstframe van een bestaand tekstvak. Tekst stroomt tussen kolommen binnen dezelfde vorm; het gaat niet door naar een andere vorm.

Het volgende voorbeeld maakt een drie‑kolom tekstvak met 10 points tussen de kolommen, slaat de presentatie op en leest de opgeslagen instellingen terug uit het uitvoerbestand:

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

## **Tekst extraheren uit afzonderlijke kolommen**

Gebruik [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/splittextbycolumns/) om de tekst op te halen die aan elke visuele kolom in een bestaand tekstframe is toegewezen. De methode retourneert één string per kolom, in kolom‑gebaseerde leesvolgorde. Een enkel‑kolom tekstframe levert een array met één element op, en een lege kolom wordt weergegeven door een lege string. De strings bevatten alleen platte tekst; formattering op segmentniveau wordt niet behouden.

Dit is nuttig wanneer u moet:

- Tekst extraheren terwijl de kolom‑gebaseerde leesvolgorde behouden blijft.
- De inhoud van dia’s met meerdere kolommen indexeren of vergelijken.
- Elke kolom exporteren naar een afzonderlijk bestand, databaseveld of andere bestemming.
- Inspecteren hoe tekst wordt herverdeeld na het instellen van het kolomaantal met [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_columncount/) of de spatiëring met [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_columnspacing/), of bij het wijzigen van het lettertype of de grootte van het tekstframe.

De methode rapporteert de tekst die verdeeld is binnen het huidige [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/); hij laat niet automatisch tekst vloeien tussen afzonderlijke vormen of tekstvakken. Kolomverdeling kan afhangen van beschikbare lettertypen en andere tekst‑layoutinstellingen, dus zorg ervoor dat de vereiste lettertypen beschikbaar zijn wanneer consistente resultaten belangrijk zijn.

Het volgende voorbeeld laadt een presentatie, vindt de eerste auto‑vorm met meerdere kolommen en een tekstframe op de eerste dia, leest het geconfigureerde kolomaantal, en schrijft de tekst van elke kolom naar een afzonderlijk bestand. Vormen die geen tekstframe bieden, worden overgeslagen.

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

## **Tekst bijwerken**

Om tekst door de hele presentatie heen bij te werken, doorloopt u de dia’s en vormen, selecteert u auto‑vormen en bewerkt u vervolgens hun tekstsegmenten. Werken op segmentniveau stelt u in staat zowel tekst als teken‑formattering te wijzigen.

Het volgende voorbeeld vervangt elke instantie van `years` door `months` binnen individuele auto‑vormtekstsegmenten en maakt elk getroffen segment vet:

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

Deze doorloop werkt alleen tekst bij in auto‑vormen. Tekst die is opgeslagen in tabellen, grafieken, SmartArt of gegroepeerde vormen vereist een doorloop van de collecties van die objecten.

## **Een tekstvak met een hyperlink toevoegen**

Een hyperlink kan worden toegewezen aan een specifiek tekstsegment, zodat alleen die tekst als klikbare link fungeert. Gebruik [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) om het segment te koppelen aan een externe URL.

Het volgende voorbeeld maakt gelinkte tekst en slaat deze op in een presentatie:

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

## **FAQ**

**Wat is het verschil tussen een tekstvak en een placeholder op een master- of layoutdia?**

Een [placeholder](/slides/nl/cpp/manage-placeholder/) kan zijn positie en opmaak erven van een [master‑slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/masterslide/) of een [layout‑slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/layoutslide/). Een regulier tekstvak is een onafhankelijke vorm op de dia waarop het is aangemaakt en krijgt geen placeholder‑gedrag wanneer de layout verandert.

**Hoe kan ik tekst vervangen zonder tekst in grafieken, tabellen of SmartArt te wijzigen?**

Beperk de doorloop tot vormen die [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) implementeren, zoals getoond in het voorbeeld Tekst bijwerken. Grafieken, tabellen en SmartArt slaan tekst op in hun eigen objectmodellen, waardoor ze niet worden aangepast door die lus.