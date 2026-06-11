---
title: Hyperlänk
type: docs
weight: 130
url: /sv/cpp/examples/elements/hyperlink/
keywords:
- kodexempel
- hyperlänk
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lägg till och hantera hyperlänkar i Aspose.Slides för C++: länka text, former och bilder, ange mål och åtgärder för PPT, PPTX och ODP med C++-exempel."
---
Den här artikeln visar hur man lägger till, får åtkomst till, tar bort och uppdaterar hyperlänkar på former med **Aspose.Slides for C++**.

## **Lägg till en hyperlänk**

Skapa en rektangulär form med en hyperlänk som pekar på en extern webbplats.

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

## **Åtkomst till en hyperlänk**

Läs hyperlänkinformation från en formes textdel.

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

## **Ta bort en hyperlänk**

Rensa hyperlänken från en formes text.

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

## **Uppdatera en hyperlänk**

Ändra målet för en befintlig hyperlänk. Använd `HyperlinkManager` för att modifiera text som redan innehåller en hyperlänk, vilket efterliknar hur PowerPoint uppdaterar hyperlänkar på ett säkert sätt.

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

    // Att ändra en hyperlänk i befintlig text bör göras via
    // HyperlinkManager istället för att sätta egenskapen direkt.
    // Detta efterliknar hur PowerPoint säkert uppdaterar hyperlänkar.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```