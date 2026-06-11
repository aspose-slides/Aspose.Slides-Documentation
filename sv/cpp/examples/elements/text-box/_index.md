---
title: Textruta
type: docs
weight: 40
url: /sv/cpp/examples/elements/text-box/
keywords:
- kodexempel
- textruta
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Arbeta med textrutor i Aspose.Slides för C++: lägg till, formatera, justera, radbryt, anpassa automatiskt och styla text med C++ för PPT-, PPTX- och ODP-presentationer."
---
I Aspose.Slides representeras en **textruta** av en `AutoShape`. Nästan vilken form som helst kan innehålla text, men en typisk textruta har ingen fyllning eller kant och visar endast text.

Denna guide förklarar hur man programatiskt lägger till, får åtkomst till och tar bort textrutor.

## **Lägg till en textruta**

En textruta är helt enkelt en `AutoShape` utan fyllning eller kant och med viss formaterad text. Så här skapar du en:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Skapa en rektangelform (standard är fylld med kant och utan text).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Ta bort fyllning och kant för att få den att se ut som en vanlig textruta.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Ställ in textformatering.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Tilldela själva textinnehållet.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Obs:** Alla `AutoShape` som innehåller en icke-tom `TextFrame` kan fungera som en textruta.

## **Få åtkomst till textrutor efter innehåll**

För att hitta alla textrutor som innehåller ett specifikt nyckelord (t.ex. "Slide"), iterera genom formerna och kontrollera deras text:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Endast AutoShapes kan innehålla redigerbar text.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Gör något med den matchande textrutan.
            }
        }
    }

    presentation->Dispose();
}
```

## **Ta bort textrutor efter innehåll**

Detta exempel hittar och raderar alla textrutor på den första bilden som innehåller ett specifikt nyckelord:

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

> 💡 **Tips:** Skapa alltid en kopia av formsamlingen innan du modifierar den under iteration för att undvika fel vid ändring av samlingen.