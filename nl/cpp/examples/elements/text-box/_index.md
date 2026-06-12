---
title: Tekstvak
type: docs
weight: 40
url: /nl/cpp/examples/elements/text-box/
keywords:
- codevoorbeeld
- tekstvak
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Werken met tekstvakken in Aspose.Slides voor C++: tekst toevoegen, opmaken, uitlijnen, tekstomloop, automatisch aanpassen en stijlen met C++ voor PPT-, PPTX- en ODP-presentaties."
---
In Aspose.Slides wordt een **tekstvak** weergegeven door een `AutoShape`. Bijna elke vorm kan tekst bevatten, maar een typisch tekstvak heeft geen opvulling of rand en toont alleen tekst.

Deze gids legt uit hoe u tekstvakken programmatisch kunt toevoegen, benaderen en verwijderen.

## **Voeg een tekstvak toe**

Een tekstvak is simpelweg een `AutoShape` zonder opvulling of rand en met enige opgemaakte tekst. Hieronder staat hoe u er één maakt:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Maak een rechthoekvorm (standaard gevuld met een rand en zonder tekst).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Verwijder opvulling en rand zodat het eruitziet als een typisch tekstvak.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Stel tekstopmaak in.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Wijs de daadwerkelijke tekstinhoud toe.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Opmerking:** Elke `AutoShape` die een niet-lege `TextFrame` bevat, kan functioneren als een tekstvak.

## **Benader tekstvakken op inhoud**

Om alle tekstvakken te vinden die een specifiek trefwoord bevatten (bijv. "Slide"), doorloopt u de vormen en controleert u hun tekst:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Alleen AutoShapes kunnen bewerkbare tekst bevatten.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Doe iets met het overeenkomende tekstvak.
            }
        }
    }

    presentation->Dispose();
}
```

## **Verwijder tekstvakken op inhoud**

Dit voorbeeld vindt en verwijdert alle tekstvakken op de eerste dia die een specifiek trefwoord bevatten:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Tip:** Maak altijd een kopie van de vormverzameling voordat u deze tijdens iteratie wijzigt om fouten bij het aanpassen van de verzameling te voorkomen.