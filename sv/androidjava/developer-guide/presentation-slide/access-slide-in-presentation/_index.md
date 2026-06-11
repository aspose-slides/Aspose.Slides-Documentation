---
title: Åtkomst till presentationsbilder på Android
linktitle: Åtkomst till bild
type: docs
weight: 20
url: /sv/androidjava/access-slide-in-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du får åtkomst till och hanterar bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android. Öka produktiviteten med Java‑kodexempel."
---
## **Översikt**

Denna artikel förklarar hur du får åtkomst till och hanterar bilder i en presentation med Aspose.Slides. Den visar hur du hämtar bilder via deras nollbaserade index från bildsamlingen och hur du får åtkomst till en bild med dess unika ID med metoden `getSlideById`.

Du kommer även att lära dig hur du ändrar en bilds position med metoden `setSlideNumber` och hur du anger startnumret för en bild i en presentation med metoden `setFirstSlideNumber`. Exemplen demonstrerar inläsning av en presentation, hämtning av bildreferenser, uppdatering av bildordning eller numrering samt sparande av den ändrade presentationen.

## **Åtkomst till en bild efter index**

Alla bilder i en presentation är ordnade numeriskt baserat på bildens position med start från 0. Den första bilden är åtkomlig via index 0; den andra bilden via index 1; osv.

Presentation‑klassen, som representerar en presentationsfil, exponerar alla bilder som en [ISlideCollection]‑samling (samling av [ISlide]‑objekt). Denna Java‑kod visar hur du får åtkomst till en bild via dess index:

```java
// Skapar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("demo.pptx");
try {
    // Hämtar en bild med hjälp av dess bildindex
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Åtkomst till en bild via ID**

Varje bild i en presentation har ett unikt ID som är kopplat till den. Du kan använda metoden [getSlideById] (som exponeras av klassen [Presentation]) för att rikta in dig på det ID:t. Denna Java‑kod visar hur du anger ett giltigt bild‑ID och får åtkomst till den bilden via metoden [getSlideById]:

```java
// Skapar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("demo.pptx");
try {
    // Hämtar ett bild-ID
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Kommer åt bilden via dess ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Ändra bildens position**

Aspose.Slides låter dig ändra en bilds position. Till exempel kan du ange att den första bilden ska bli den andra bilden.

1. Skapa en instans av klassen [Presentation].
1. Hämta bildens referens (vars position du vill ändra) via dess index
1. Ange en ny position för bilden via egenskapen [setSlideNumber].
1. Spara den ändrade presentationen.

Denna Java‑kod demonstrerar en operation där bilden i position 1 flyttas till position 2:

```java
// Skapar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hämtar bilden vars position ska ändras
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Sätter den nya positionen för bilden
    sld.setSlideNumber(2);
    
    // Sparar den ändrade presentationen
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Den första bilden blev den andra; den andra bilden blev den första. När du ändrar en bilds position justeras andra bilder automatiskt.

## **Ange bildens nummer**

Genom att använda egenskapen [setFirstSlideNumber] (som exponeras av klassen [Presentation]) kan du ange ett nytt nummer för den första bilden i en presentation. Denna operation får andra bildnummer att omräknas.

1. Skapa en instans av klassen [Presentation].
1. Hämta bildnumret.
1. Ange bildnumret.
1. Spara den ändrade presentationen.

Denna Java‑kod demonstrerar en operation där den första bildens nummer sätts till 10:

```java
// Skapar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Hämtar bildnumret
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Sätter bildnumret
    pres.setFirstSlideNumber(10);
	
    // Sparar den ändrade presentationen
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Om du föredrar att hoppa över den första bilden kan du börja numreringen från den andra bilden (och dölja numreringen för den första bilden) på följande sätt:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Sätter numret för den första presentationsbilden
    presentation.setFirstSlideNumber(0);

    // Visar bildnummer för alla bilder
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Döljer bildnumret för den första bilden
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Sparar den ändrade presentationen
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Vanliga frågor**

**Stämmer bildnumret som en användare ser överens med samlingens nollbaserade index?**

Numret som visas på en bild kan börja från ett godtyckligt värde (t.ex. 10) och behöver inte matcha indexet; förhållandet styrs av presentationens [first slide number]‑inställning.

**Påverkar dolda bilder indexeringen?**

Ja. En dold bild förblir i samlingen och räknas med i indexeringen; "dold" avser visning, inte dess position i samlingen.

**Ändras en bilds index när andra bilder läggs till eller tas bort?**

Ja. Indexen speglar alltid den aktuella ordningen i bilder och omräknas vid insättning, borttagning och flyttoperationer.