---
title: Lägg till bilder i presentationer i Python
linktitle: Lägg till bild
type: docs
weight: 10
url: /sv/python-java/add-slide-to-presentation/
keywords:
- lägg till bild
- skapa bild
- tom bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg enkelt till bilder i dina PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java—smidig, effektiv bildinfogning på några sekunder."
---
## **Översikt**

Aspose.Slides låter dig lägga till bilder i PowerPoint‑presentationer programvarumässigt. En presentation innehåller master‑/layout‑bilder och vanliga bilder, och de vanliga bilderna ordnas efter ett nollbaserat index. Varje bild har ett unikt ID, och presentationsfiler utan bilder stöds inte.

Denna artikel förklarar hur du skapar ett [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objekt, får åtkomst till dess bildsamling, lägger till en tom bild, arbetar med den nyinfogade bilden och sparar den uppdaterade presentationen. Den täcker också relaterade punkter, såsom att infoga bilder på en specifik position, använda layouter och förstå den tomma bilden som finns i en ny skapad presentation.

## **Lägg till en bild i en presentation**

Innan vi går in på hur man lägger till bilder i presentationsfiler, låt oss gå igenom några fakta om bilder. Varje PowerPoint‑presentationsfil innehåller **master‑/layout**‑bilder och **vanliga** bilder. En presentationsfil måste innehålla minst en bild. Presentationsfiler utan bilder stöds inte av Aspose.Slides för Python via Java. Varje bild har ett unikt ID, och alla vanliga bilder ordnas i en följd som anges av ett nollbaserat index.

Aspose.Slides för Python via Java låter utvecklare lägga till tomma bilder i sina presentationer. För att lägga till en tom bild i en presentation, följ dessa steg:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
- Hämta en referens till [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)-objektet med metoden [getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-objektet.
- Lägg till en tom bild i slutet av presentationens bildsamling genom att anropa metoden [addEmptySlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addEmptySlide) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)-objektet.
- Gör någon bearbetning med den nyinfogade tomma bilden.
- Skriv slutligen presentationsfilen med [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-objektet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instansiera Presentation-klassen som representerar presentationsfilen.
presentation = Presentation()
try:
    # Hämta bildsamlingen.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Lägg till en tom bild i bildsamlingen.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Gör något arbete på den nyinfogade bilden.

    # Spara PPTX-filen till disk.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag infoga en ny bild på en specifik position, inte bara i slutet?**

Ja. Biblioteket stödjer bildsamlingar och [insert](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertClone)-operationer, så du kan lägga till en bild på det önskade indexet snarare än endast i slutet.

**Behålls tema/stilar när jag lägger till en bild baserad på en layout?**

Ja. En layout ärver formatering från sin master, och den nya bilden ärver från den valda layouten och dess associerade master.

**Vilken bild finns i en ny "tom" presentation innan några bilder läggs till?**

En nyss skapad presentation innehåller redan en blank bild med index noll. Detta är viktigt att beakta när du beräknar infogningsindex.

**Hur väljer jag rätt layout för en ny bild om mastern har många alternativ?**

Vanligtvis väljer du den [LayoutSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/) som matchar den erforderliga strukturen ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidelayouttype/)). Om en sådan layout saknas kan du [add it to the master](/slides/sv/python-java/slide-layout/) och sedan använda den.