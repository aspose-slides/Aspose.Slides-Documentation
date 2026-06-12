---
title: Masterdia
type: docs
weight: 30
url: /nl/python-net/examples/elements/master-slide/
keywords:
- masterdia
- masterdia toevoegen
- masterdia benaderen
- masterdia verwijderen
- ongebruikte masterdia
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer masterdia's in Python met Aspose.Slides: maak, bewerk, kloon en formatteer thema's, achtergronden, placeholders om dia's in PowerPoint en OpenDocument te uniformiseren."
---
Masterdia's vormen het hoogste niveau van de dia‑erfenishierarchie in PowerPoint. Een **masterdia** definieert gemeenschappelijke ontwerpelementen zoals achtergronden, logo’s en tekstopmaak. **Lay‑outdia's** erven van masterdia's, en **normale dia's** erven van lay‑outdia's.

Dit artikel laat zien hoe u masterdia's kunt maken, wijzigen en beheren met Aspose.Slides voor Python via .NET.

## **Masterdia toevoegen**

Dit voorbeeld toont hoe u een nieuwe masterdia kunt maken door de standaarddia te klonen.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Kloon de standaard masterdia.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Masterdia's bieden een manier om consistente branding of gedeelde ontwerpelementen toe te passen op alle dia's. Wijzigingen die op de master worden aangebracht, worden automatisch doorgevoerd op de afhankelijke lay‑out- en normale dia's.
> 💡 **Tip 2:** Alle vormen of opmaak die aan een masterdia worden toegevoegd, worden geërfd door lay‑outdia's en, op hun beurt, door alle normale dia's die die lay‑outs gebruiken.
> De afbeelding hieronder toont hoe een tekstvak dat op een masterdia is toegevoegd, automatisch wordt weergegeven op de uiteindelijke dia.

![Voorbeeld van master‑erfenis](master-slide-banner.png)

## **Toegang tot een masterdia**

U kunt masterdia's benaderen via de `Presentation.masters`-collectie. Hieronder staat hoe u ze kunt ophalen en ermee kunt werken:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Benader de eerste masterdia.
        first_master_slide = presentation.masters[0]
```

## **Masterdia verwijderen**

Masterdia's kunnen worden verwijderd op basis van index of referentie.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Verwijder op index.
        presentation.masters.remove_at(0)

        # Of verwijder via referentie.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ongebruikte masterdia's verwijderen**

Sommige presentaties bevatten masterdia's die niet worden gebruikt. Het verwijderen van deze dia's kan helpen de bestandsgrootte te verkleinen.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Verwijder alle ongebruikte masterdia's (ook die gemarkeerd als Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** Gebruik `remove_unused(True)` om ongebruikte masterdia's op te ruimen en de presentatiegrootte te minimaliseren.