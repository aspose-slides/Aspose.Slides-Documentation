---
title: Hyperlink
type: docs
weight: 130
url: /nl/cpp/examples/elements/hyperlink/
keywords:
- codevoorbeeld
- hyperlink
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Hyperlinks toevoegen en beheren in Aspose.Slides for C++: tekst, vormen en afbeeldingen koppelen, doelen en acties instellen voor PPT, PPTX en ODP met C++-voorbeelden."
---
Dit artikel toont hoe u hyperlinks aan vormen kunt toevoegen, benaderen, verwijderen en bijwerken met **Aspose.Slides for C++**.

## **Hyperlink toevoegen**

Maak een rechthoekvorm aan met een hyperlink die naar een externe website verwijst.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Hyperlink benaderen**

Lees hyperlink‑informatie uit de tekst van een vorm.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Hyperlink verwijderen**

Verwijder de hyperlink uit de tekst van een vorm.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Hyperlink bijwerken**

Verander het doel van een bestaande hyperlink. Gebruik `HyperlinkManager` om tekst die al een hyperlink bevat te wijzigen, wat nabootst hoe PowerPoint hyperlinks veilig bijwerkt.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Een hyperlink in bestaande tekst wijzigen moet gebeuren via
    // HyperlinkManager in plaats van de eigenschap direct in te stellen.
    // Dit bootst na hoe PowerPoint hyperlinks veilig bijwerkt.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```