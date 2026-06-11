---
title: Lägg till bilder i presentationer med Python
linktitle: Lägg till bild
type: docs
weight: 10
url: /sv/python-net/add-slide-to-presentation/
keywords:
- lägg till bild
- skapa bild
- tom bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg enkelt till bilder i dina PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET—sömlös, effektiv bildinfogning på sekunder."
---
## **Översikt**

Innan du lägger till bilder i en presentation är det bra att förstå hur PowerPoint organiserar dem. Varje presentation innehåller en masterbild, valfria layoutbilder och en eller flera vanliga bilder. Varje bild har ett unikt ID, och vanliga bilder ordnas enligt ett nollbaserat index. Denna artikel visar hur du använder Aspose.Slides för Python för att skapa bilder och välja lämpliga layouter.

## **Lägg till bilder i presentationer**

Aspose.Slides låter dig lägga till nya bilder baserade på befintliga layoutbilder. Exemplet nedan går igenom varje layout i presentationen, lägger till en bild som använder den layouten och sparar sedan filen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta [SlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/).
1. För varje objekt i `presentation.layout_slides`, anropa `add_empty_slide` för att lägga till en bild som använder den layouten.
1. Modifiera eventuellt de nylagda bilderna.
1. Spara presentationen som en PPTX-fil.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen.
with slides.Presentation() as presentation:
    # Hämta bildsamlingen.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Lägg till en tom bild i bildsamlingen.
        slides.add_empty_slide(layout_slide)

    # Utför någon bearbetning på de nyligen tillagda bilderna.

    # Spara presentationen på disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag infoga en ny bild på en specifik position, inte bara i slutet?**

Ja. Biblioteket stöder bildsamlingar och [insert](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/insert_clone/)‑operationer, så du kan lägga till en bild på det önskade indexet istället för bara i slutet.

**Bevaras tema/stilar när en bild läggs till baserat på en layout?**

Ja. En layout ärver formatering från sin master, och den nya bilden ärver från den valda layouten och dess associerade master.

**Vilken bild finns i en ny "tom" presentation innan du lägger till bilder?**

En ny skapad presentation innehåller redan en tom bild med index noll. Detta är viktigt att ta hänsyn till när du beräknar insättningsindex.

**Hur väljer jag den "rätta" layouten för en ny bild om mastern har många alternativ?**

Välj vanligtvis den [LayoutSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/) som matchar den önskade strukturen ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidelayouttype/)). Om en sådan layout saknas kan du [add it to the master](/slides/sv/python-net/slide-layout/) och sedan använda den.