---
title: Åtkomst till presentationsbilder i .NET
linktitle: Åtkomst till bild
type: docs
weight: 20
url: /sv/net/access-slide-in-presentation/
keywords:
- åtkomst till bild
- bildindex
- bild-id
- bildposition
- ändra position
- bildegenskaper
- bildnummer
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du får åtkomst till och hanterar bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Öka produktiviteten med kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur man får åtkomst till och hanterar bilder i en presentation med Aspose.Slides. Den visar hur man hämtar bilder via deras nollbaserade index från `Slides`‑samlingen och hur man får åtkomst till en bild via dess unika ID med hjälp av metoden `GetSlideById`.

Du kommer också att lära dig hur du ändrar en bilds position genom att sätta egenskapen `SlideNumber` och hur du definierar startnumret för bilder i en presentation med egenskapen `FirstSlideNumber`. Exemplen visar hur man laddar en presentation, hämtar bildreferenser, uppdaterar bildordning eller numrering och sparar den modifierade presentationen.

## **Åtkomst till en bild via index**

Alla bilder i en presentation är ordnade numeriskt baserat på bildpositionen med start från 0. Den första bilden är åtkomlig via index 0; den andra bilden via index 1; osv.

Presentation‑klassen, som representerar en presentationsfil, exponerar alla bilder som en [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection)-samling (samling av [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/)-objekt). Denna C#‑kod visar hur du får åtkomst till en bild via dess index:

```c#
// Skapar ett Presentation-objekt som representerar en presentationsfil
Presentation presentation = new Presentation("AccessSlides.pptx");

// Hämtar en bilds referens via dess index
ISlide slide = presentation.Slides[0];
```

## **Åtkomst till en bild via ID**

Varje bild i en presentation har ett unikt ID kopplat till sig. Du kan använda metoden [GetSlideById](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/methods/getslidebyid) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)) för att rikta in dig på det ID:t. Denna C#‑kod visar hur du anger ett giltigt bild‑ID och får åtkomst till den bilden via metoden [GetSlideById](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/methods/getslidebyid):

```c#
// Skapar ett Presentation-objekt som representerar en presentationsfil
Presentation presentation = new Presentation("AccessSlides.pptx");

// Hämtar ett bild-ID
uint id = presentation.Slides[0].SlideId;

// Kommer åt bilden via dess ID
IBaseSlide slide = presentation.GetSlideById(id);
```

## **Ändra bildposition**

Aspose.Slides låter dig ändra en bilds position. Till exempel kan du ange att den första bilden ska bli den andra bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta bildens referens (vars position du vill ändra) via dess index.
3. Ange en ny position för bilden via egenskapen [SlideNumber](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/slidenumber/).
4. Spara den modifierade presentationen.

Denna C#‑kod demonstrerar en operation där bilden på position 1 flyttas till position 2:

```c#
// Skapar ett Presentation-objekt som representerar en presentationsfil
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Hämtar bilden vars position ska ändras
    ISlide sld = pres.Slides[0];

    // Sätter den nya positionen för bilden
    sld.SlideNumber = 2;

    // Sparar den modifierade presentationen
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

Den första bilden blev den andra; den andra bilden blev den första. När du ändrar en bilds position justeras de andra bilderna automatiskt.

## **Ställ in bildnummer**

Genom att använda egenskapen [FirstSlideNumber](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/firstslidenumber/) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)) kan du ange ett nytt nummer för den första bilden i en presentation. Denna operation får de andra bildnumren att omräknas.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta bildnumret.
3. Ange bildnumret.
4. Spara den modifierade presentationen.

Denna C#‑kod demonstrerar en operation där den första bildens nummer sätts till 10:

```c#
// Skapar ett Presentation-objekt som representerar en presentationsfil
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Hämtar bildnumret
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Sätter bildnumret
    presentation.FirstSlideNumber=10;
    
    // Sparar den modifierade presentationen
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

Om du föredrar att hoppa över den första bilden kan du börja numreringen från den andra bilden (och dölja numreringen för den första bilden) på följande sätt:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Sätter numret för den första presentationsbilden
    presentation.FirstSlideNumber = 0;

    // Visar bildnummer för alla bilder
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Döljer bildnumret för den första bilden
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Sparar den modifierade presentationen
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Matchar bildnumret som en användare ser samlingens nollbaserade index?**

Numret som visas på en bild kan börja från ett godtyckligt värde (t.ex. 10) och behöver inte matcha indexet; förhållandet styrs av presentationens inställning för [first slide number](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/firstslidenumber/).

**Påverkar dolda bilder indexeringen?**

Ja. En dold bild finns kvar i samlingen och räknas med i indexeringen; "dold" avser visning, inte dess position i samlingen.

**Ändras en bilds index när andra bilder läggs till eller tas bort?**

Ja. Indexen speglar alltid den aktuella ordningen i bilder och omräknas vid införande, borttagning och flytt av bilder.