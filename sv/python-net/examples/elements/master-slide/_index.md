---
title: Masterbild
type: docs
weight: 30
url: /sv/python-net/examples/elements/master-slide/
keywords:
- masterbild
- lägg till masterbild
- åtkomst till masterbild
- ta bort masterbild
- oanvänd masterbild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantera masterbilder i Python med Aspose.Slides: skapa, redigera, klona och formatera teman, bakgrunder, platshållare för att förena bilder i PowerPoint och OpenDocument."
---
Masterbilder utgör den översta nivån i bildens arvshierarki i PowerPoint. En **masterbild** definierar gemensamma designelement såsom bakgrunder, logotyper och textformatering. **Layoutbilder** ärver från masterbilder, och **vanliga bilder** ärver från layoutbilder.

Denna artikel visar hur man skapar, ändrar och hanterar masterbilder med Aspose.Slides för Python via .NET.

## **Lägg till en masterbild**

Detta exempel visar hur man skapar en ny masterbild genom att klona den förvalda.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Klona standardmasterbilden.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tips 1:** Masterbilder erbjuder ett sätt att tillämpa konsekvent varumärkesprofil eller delade designelement på alla bilder. Eventuella ändringar som görs på masterbilden kommer automatiskt att återspeglas i beroende layout- och vanliga bilder.  
> 💡 **Tips 2:** Alla former eller formateringar som läggs till i en masterbild ärvts av layoutbilder och i sin tur av alla vanliga bilder som använder dessa layouter.  
> Bilden nedan visar hur en textruta som lagts till i en masterbild automatiskt renderas på den slutliga bilden.

![Exempel på masterärv](master-slide-banner.png)

## **Åtkomst till en masterbild**

Du kan komma åt masterbilder med hjälp av samlingen `Presentation.masters`. Så här hämtar du dem och arbetar med dem:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Läs åt den första masterbilden.
        first_master_slide = presentation.masters[0]
```

## **Ta bort en masterbild**

Masterbilder kan tas bort antingen efter index eller genom referens.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Ta bort efter index.
        presentation.masters.remove_at(0)

        # Eller ta bort efter referens.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort oanvända masterbilder**

Vissa presentationer innehåller masterbilder som inte används. Att ta bort dessa bilder kan hjälpa till att minska filstorleken.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Ta bort alla oanvända masterbilder (även de som är markerade som Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tips:** Använd `remove_unused(True)` för att rensa bort oanvända masterbilder och minimera presentationens storlek.