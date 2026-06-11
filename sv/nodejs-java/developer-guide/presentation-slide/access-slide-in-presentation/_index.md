---
title: Åtkomst till presentationsbilder i JavaScript
linktitle: Åtkomst till bild
type: docs
weight: 20
url: /sv/nodejs-java/access-slide-in-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du får åtkomst till och hanterar bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js. Öka produktiviteten med kodexempel."
---
## **Översikt**

Denna artikel förklarar hur du får åtkomst till och hanterar bilder i en presentation med Aspose.Slides. Den visar hur du hämtar bilder via deras nollbaserade index från bildsamlingen och hur du får åtkomst till en bild med dess unika ID med metoden `getSlideById`.

Du kommer också att lära dig hur du ändrar en bilds position med metoden `setSlideNumber` samt hur du anger startbildnumret för en presentation med metoden `setFirstSlideNumber`. Exemplen demonstrerar hur man laddar en presentation, hämtar bildreferenser, uppdaterar bildordning eller numrering och sparar den modifierade presentationen.

## **Åtkomst till bild efter index**

Alla bilder i en presentation ordnas numeriskt baserat på bildens position med start från 0. Den första bilden är åtkomlig via index 0; den andra bilden via index 1; osv.

Klassen Presentation, som representerar en presentationsfil, exponerar alla bilder som en [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/) samling (samling av [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/)‑objekt). Denna JavaScript‑kod visar hur du får åtkomst till en bild via dess index:

```javascript
// Instansierar ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Hämtar en bild med hjälp av dess bildindex
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Åtkomst till bild via ID**

Varje bild i en presentation har ett unikt ID kopplat till sig. Du kan använda metoden [getSlideById](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)) för att rikta in dig på det ID:t. Denna JavaScript‑kod visar hur du anger ett giltigt bild‑ID och får åtkomst till den bilden via metoden [getSlideById](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSlideById-long-):

```javascript
// Instansierar ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Hämtar en bild-ID
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Kommer åt bilden via dess ID
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Ändra bildposition**

Aspose.Slides låter dig ändra en bilds position. Till exempel kan du ange att den första bilden ska bli den andra bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta bildens referens (vars position du vill ändra) via dess index
3. Ange en ny position för bilden via egenskapen [setSlideNumber](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
4. Spara den modifierade presentationen.

Denna JavaScript‑kod demonstrerar en operation där bilden på position 1 flyttas till position 2:

```javascript
// Instansierar ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hämtar bilden vars position kommer att ändras
    var sld = pres.getSlides().get_Item(0);
    // Anger den nya positionen för bilden
    sld.setSlideNumber(2);
    // Sparar den modifierade presentationen
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Den första bilden blev den andra; den andra bilden blev den första. När du ändrar en bilds position justeras de andra bilderna automatiskt.

## **Ange bildnummer**

Genom att använda egenskapen [setFirstSlideNumber](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)) kan du ange ett nytt nummer för den första bilden i en presentation. Denna operation får de andra bildnumren att omräknas.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta bildnumret.
3. Ange bildnumret.
4. Spara den modifierade presentationen.

Denna JavaScript‑kod demonstrerar en operation där den första bildens nummer sätts till 10:

```javascript
// Instansierar ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Hämtar bildnumret
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Anger bildnumret
    pres.setFirstSlideNumber(10);
    // Sparar den modifierade presentationen
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Om du föredrar att hoppa över den första bilden kan du starta numreringen från den andra bilden (och dölja numreringen för den första bilden) på följande sätt:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Sätter numret för den första presentationsbilden
    presentation.setFirstSlideNumber(0);
    // Visar bildnummer för alla bilder
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // Döljer bildnumret för den första bilden
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // Sparar den modifierade presentationen
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Matchar bildnumret som en användare ser samlingens nollbaserade index?**

Numret som visas på en bild kan börja från ett godtyckligt värde (t.ex. 10) och behöver inte matcha indexet; förhållandet styrs av presentationens [första bildnumret](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) inställning.

**Påverkar dolda bilder indexeringen?**

Ja. En dold bild finns kvar i samlingen och räknas med i indexeringen; "hidden" avser visning, inte dess position i samlingen.

**Ändras en bilds index när andra bilder läggs till eller tas bort?**

Ja. Indexen speglar alltid den aktuella ordningen i bilderna och omräknas vid insättnings‑, borttagnings‑ och flyttoperationer.