---
title: Přístup k snímkům prezentace v JavaScriptu
linktitle: Přístup ke snímku
type: docs
weight: 20
url: /cs/nodejs-java/access-slide-in-presentation/
keywords:
- přístup k snímku
- index snímku
- ID snímku
- pozice snímku
- změna pozice
- vlastnosti snímku
- číslo snímku
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak přistupovat k snímkům a spravovat je v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js. Zvyšte produktivitu s ukázkovým kódem."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přistupovat k snímkům v prezentaci a spravovat je. Ukazuje, jak načíst snímky podle jejich nulového indexu ze sbírky snímků a jak získat snímek podle jeho jedinečného ID pomocí metody `getSlideById`.

Také se naučíte, jak změnit pozici snímku pomocí metody `setSlideNumber` a jak definovat počáteční číslo snímku pro prezentaci pomocí metody `setFirstSlideNumber`. Příklady ukazují načtení prezentace, získání odkazů na snímky, aktualizaci pořadí nebo číslování snímků a uložení upravené prezentace.

## **Přístup ke snímku podle indexu**

Všechny snímky v prezentaci jsou uspořádány číselně podle pozice snímku počínaje 0. První snímek je přístupný pomocí indexu 0; druhý snímek je přístupný pomocí indexu 1; atd.

Třída Presentation, která představuje soubor prezentace, poskytuje všechny snímky jako kolekci [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/) (kolekci objektů [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/)). Tento JavaScriptový kód vám ukazuje, jak přistoupit k snímku podle jeho indexu:

```javascript
// Vytvoří objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Přistupuje k snímku pomocí jeho indexu
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Přístup ke snímku podle ID**

Každý snímek v prezentaci má přiřazené jedinečné ID. K cílení na toto ID můžete použít metodu [getSlideById](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (poskytnutou třídou [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/)). Tento JavaScriptový kód vám ukazuje, jak zadat platné ID snímku a získat přístup k tomuto snímku pomocí metody [getSlideById](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSlideById-long-):

```javascript
// Vytvoří objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Získá ID snímku
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Přistupuje ke snímku pomocí jeho ID
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Změna pozice snímku**

Aspose.Slides vám umožňuje změnit pozici snímku. Například můžete určit, že první snímek se má stát druhým snímkem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek (jejíž pozici chcete změnit) pomocí jeho indexu
1. Nastavte novou pozici snímku pomocí vlastnosti [setSlideNumber](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
1. Uložte upravenou prezentaci.

Tento JavaScriptový kód ukazuje operaci, při které je snímek na pozici 1 přesunut na pozici 2:

```javascript
// Vytvoří objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Získá snímek, jehož pozice bude změněna
    var sld = pres.getSlides().get_Item(0);
    // Nastaví novou pozici snímku
    sld.setSlideNumber(2);
    // Uloží upravenou prezentaci
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

První snímek se stal druhým; druhý snímek se stal prvním. Když změníte pozici snímku, ostatní snímky jsou automaticky přizpůsobeny.

## **Nastavení čísla snímku**

Pomocí vlastnosti [setFirstSlideNumber](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (poskytnuté třídou [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/)) můžete určit nové číslo prvního snímku v prezentaci. Tato operace způsobí přepočet čísel ostatních snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte číslo snímku.
1. Nastavte číslo snímku.
1. Uložte upravenou prezentaci.

Tento JavaScriptový kód ukazuje operaci, kde je číslo prvního snímku nastaveno na 10:

```javascript
// Vytvoří objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Získá číslo snímku
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Nastaví číslo snímku
    pres.setFirstSlideNumber(10);
    // Uloží upravenou prezentaci
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Pokud chcete přeskočit první snímek, můžete číslování zahájit od druhého snímku (a skrýt číslování pro první snímek) tímto způsobem:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Nastaví číslo prvního snímku prezentace
    // Zobrazí čísla snímků na všech snímcích
    // Skryje číslo snímku na prvním snímku
    // Uloží upravenou prezentaci
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Často kladené otázky**

**Odpovídá číslo snímku, které uživatel vidí, nulovému indexu v kolekci?**

Číslo zobrazené na snímku může začínat libovolnou hodnotou (např. 10) a nemusí odpovídat indexu; vztah je řízen nastavením [first slide number](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) v prezentaci.

**Ovlivňují skryté snímky indexování?**

Ano. Skrytý snímek zůstává v kolekci a je započítán do indexování; „skrytý“ se vztahuje k zobrazování, nikoli k jeho pozici v kolekci.

**Mění se index snímku, když jsou přidány nebo odebrány jiné snímky?**

Ano. Indexy vždy odrážejí aktuální pořadí snímků a jsou přepočítány při operacích vložení, smazání a přesunu.