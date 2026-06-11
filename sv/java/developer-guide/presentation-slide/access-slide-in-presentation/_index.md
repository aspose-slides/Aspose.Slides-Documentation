---
title: Åtkomst till presentationsbilder i Java
linktitle: Åtkomst till bild
type: docs
weight: 20
url: /sv/java/access-slide-in-presentation/
keywords:
- åtkomst bild
- bildindex
- bild-id
- bildposition
- ändra position
- bildegenskaper
- bildnummer
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du får åtkomst till och hanterar bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java. Öka produktiviteten med kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur du får åtkomst till och hanterar bilder i en presentation med Aspose.Slides. Den visar hur du hämtar bilder efter deras nollbaserade index från bildsamlingen och hur du får åtkomst till en bild via dess unika ID med metoden `getSlideById`.

Du lär dig också hur du ändrar en bilds position med metoden `setSlideNumber` och hur du definierar startbildnumret för en presentation med metoden `setFirstSlideNumber`. Exemplen demonstrerar hur du laddar en presentation, får bildreferenser, uppdaterar bildordning eller numrering och sparar den ändrade presentationen.

## **Få åtkomst till en bild efter index**

Alla bilder i en presentation ordnas numeriskt baserat på bildpositionen med start från 0. Den första bilden är åtkomlig via index 0; den andra bilden via index 1; osv.

Klassen Presentation, som representerar en presentationsfil, exponerar alla bilder som en [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidecollection/) (samling av [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/)‑objekt). Denna Java‑kod visar hur du får åtkomst till en bild via dess index:

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

## **Få åtkomst till en bild efter ID**

Varje bild i en presentation har ett unikt ID kopplat till sig. Du kan använda metoden [getSlideById](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSlideById-long-) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)) för att rikta in dig på det ID:t. Denna Java‑kod visar hur du anger ett giltigt bild‑ID och får åtkomst till bilden via metoden [getSlideById](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSlideById-long-):

```java
// Skapar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("demo.pptx");
try {
    // Hämtar ett bild-ID
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Åtkomst till bilden via dess ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Ändra bildens position**

Aspose.Slides låter dig ändra en bilds position. Till exempel kan du ange att den första bilden ska bli den andra bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta bildreferensen (den bild vars position du vill ändra) via dess index
1. Ange en ny position för bilden via egenskapen [setSlideNumber](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#setSlideNumber-int-).
1. Spara den ändrade presentationen.

Denna Java‑kod demonstrerar en operation där bilden på position 1 flyttas till position 2:

```java
// Skapar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hämtar bilden vars position kommer att ändras
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Anger den nya positionen för bilden
    sld.setSlideNumber(2);
    
    // Sparar den ändrade presentationen
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Den första bilden blev den andra; den andra bilden blev den första. När du ändrar en bilds position justeras andra bilder automatiskt.

## **Ange bildnumret**

Genom att använda egenskapen [setFirstSlideNumber](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (exponerad av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)) kan du ange ett nytt nummer för den första bilden i en presentation. Denna operation får andra bildnummer att räknas om.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta bildnumret.
1. Ange bildnumret.
1. Spara den ändrade presentationen.

Denna Java‑kod demonstrerar en operation där det första bildnumret sätts till 10:

```java
// Skapar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Hämtar bildnumret
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Anger bildnumret
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

    // Anger numret för den första presentationsbilden
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

## **FAQ**

**Matchar bildnumret som en användare ser samlingens nollbaserade index?**

Numret som visas på en bild kan börja från ett godtyckligt värde (t.ex. 10) och måste inte matcha indexet; förhållandet styrs av presentationens inställning för [första bildnummer](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-).

**Påverkar dolda bilder indexeringen?**

Ja. En dold bild förblir i samlingen och räknas med i indexeringen; "dold" avser bara visning, inte dess position i samlingen.

**Ändras en bilds index när andra bilder läggs till eller tas bort?**

Ja. Indexen speglar alltid den aktuella ordningen i bilderna och räknas om vid infogning, borttagning och flyttning.