---
title: Master-dia
type: docs
weight: 30
url: /nl/cpp/examples/elements/master-slide/
keywords:
- codevoorbeeld
- master-dia
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek Aspose.Slides voor C++ master-dia-voorbeelden: maak, bewerk en stijl master-dia's, plaatsaanduidingen en thema's in PPT, PPTX en ODP met duidelijke C++-code."
---
Master-dia's vormen het hoogste niveau van de dia-erfenishierarchie in PowerPoint. Een **master-dia** definieert gemeenschappelijke ontwerpelementen zoals achtergronden, logo's en tekstopmaak. **Lay-out-dia's** erven van master-dia's, en **normale dia's** erven van lay-out-dia's.

Dit artikel toont hoe u master-dia's kunt maken, wijzigen en beheren met Aspose.Slides voor C++.

## **Een master-dia toevoegen**

Dit voorbeeld laat zien hoe u een nieuwe master-dia kunt maken door de standaarddia te klonen. Vervolgens wordt er een banner met de bedrijfsnaam aan alle dia's toegevoegd via lay-out-erfenis.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Kloon de standaard master-dia.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Voeg een banner met bedrijfsnaam toe aan de bovenkant van de master-dia.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Wijs de nieuwe master-dia toe aan een lay-out-dia.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Wijs de lay-out-dia toe aan de eerste dia in de presentatie.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Opmerking 1:** Master-dia's bieden een manier om consistente branding of gedeelde ontwerpelementen toe te passen op alle dia's. Wijzigingen die u in de master aanbrengt, worden automatisch weergegeven in de afhankelijke lay-out- en normale dia's.

> 💡 **Opmerking 2:** Alle vormen of opmaak die aan een master-dia worden toegevoegd, worden geërfd door lay-out-dia's en daarmee door alle normale dia's die die lay-outs gebruiken.

> De afbeelding hieronder illustreert hoe een tekstvak dat op een master-dia is toegevoegd, automatisch wordt weergegeven op de uiteindelijke dia.

![Voorbeeld van master-erfenis](master-slide-banner.png)

## **Toegang tot een master-dia**

U kunt master-dia's benaderen via de master-collectie van de presentatie. Hieronder leest u hoe u ze kunt ophalen en ermee kunt werken:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Wijzig het achtergrondtype.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Een master-dia verwijderen**

Master-dia's kunnen worden verwijderd op basis van index of referentie.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Verwijder een master-dia op index.
    presentation->get_Masters()->RemoveAt(0);

    // Verwijder een master-dia via referentie.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Ongebruikte master-dia's verwijderen**

Sommige presentaties bevatten master-dia's die niet worden gebruikt. Het verwijderen van deze dia's kan helpen om de bestandsgrootte te verkleinen.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Verwijder alle ongebruikte master-dia's (ook die gemarkeerd zijn als Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```