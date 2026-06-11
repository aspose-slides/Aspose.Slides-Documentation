---
title: Masterbild
type: docs
weight: 30
url: /sv/cpp/examples/elements/master-slide/
keywords:
- kodexempel
- masterbild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Utforska exempel på masterbilder i Aspose.Slides för C++: skapa, redigera och formge masterbilder, platshållare och teman i PPT, PPTX och ODP med tydlig C++-kod."
---
Masterbilder utgör den översta nivån i bildens arvshierarki i PowerPoint. En **masterbild** definierar gemensamma designelement såsom bakgrunder, logotyper och textformatering. **Layoutbilder** ärver från masterbilder, och **normala bilder** ärver från layoutbilder.

Denna artikel visar hur man skapar, ändrar och hanterar masterbilder med Aspose.Slides för C++.

## **Lägg till en masterbild**

Detta exempel visar hur man skapar en ny masterbild genom att klona standardbilden. Den lägger sedan till en företagsnamnsbanner på alla bilder via layoutarv.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Klona standardmasterbilden.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Lägg till en banner med företagsnamn högst upp på masterbilden.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Tilldela den nya masterbilden till en layoutbild.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Tilldela layoutbilden till den första bilden i presentationen.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Notering 1:** Masterbilder ger ett sätt att applicera konsekvent varumärkesprofil eller delade designelement på alla bilder. Alla ändringar som görs på mastern återfinns automatiskt i beroende layout- och normala bilder.  
> 💡 **Notering 2:** Alla former eller formateringar som läggs till i en masterbild ärvs av layoutbilder och i sin tur av alla normala bilder som använder dessa layouter.  
> Bilden nedan visar hur en textruta som läggs till i en masterbild automatiskt renderas på den slutgiltiga bilden.

![Exempel på masterarv](master-slide-banner.png)

## **Kom åt en masterbild**

Du kan komma åt masterbilder via presentationens masterkollektion. Så här hämtar och arbetar du med dem:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Ändra bakgrundstypen.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Ta bort en masterbild**

Masterbilder kan tas bort antingen via index eller via referens.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Ta bort en masterbild efter index.
    presentation->get_Masters()->RemoveAt(0);

    // Ta bort en masterbild efter referens.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Ta bort oanvända masterbilder**

Vissa presentationer innehåller masterbilder som inte används. Att ta bort dessa bilder kan minska filstorleken.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Ta bort alla oanvända masterbilder (även de som är markerade som Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```