---
title: Přístup k snímkům prezentace na Androidu
linktitle: Přístup k snímku
type: docs
weight: 20
url: /cs/androidjava/access-slide-in-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak přistupovat k snímkům a spravovat je v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android. Zvyšte produktivitu pomocí příkladů kódu v Java."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides získat přístup k snímkům v prezentaci a spravovat je. Ukazuje, jak načíst snímky podle jejich nulového indexu ze sbírky snímků a jak získat snímek podle jeho jedinečného ID pomocí metody `getSlideById`.

Dozvíte se také, jak změnit pozici snímku pomocí metody `setSlideNumber` a jak definovat počáteční číslo snímku pro prezentaci pomocí metody `setFirstSlideNumber`. Příklady demonstrují načtení prezentace, získání referencí na snímky, aktualizaci pořadí nebo číslování snímků a uložení upravené prezentace.

## **Přístup k snímku podle indexu**

Všechny snímky v prezentaci jsou uspořádány číselně podle pozice snímku, počínaje 0. První snímek je přístupný pomocí indexu 0; druhý snímek pomocí indexu 1; atd.

Třída Presentation, která představuje soubor prezentace, zveřejňuje všechny snímky jako kolekci [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/) (kolekci objektů [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) ). Tento Java kód ukazuje, jak získat snímek podle jeho indexu:

```java
// Vytvoří objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("demo.pptx");
try {
    // Přistupuje k snímku pomocí jeho indexu
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Přístup k snímku podle ID**

Každý snímek v prezentaci má přiřazené jedinečné ID. K cílení na toto ID můžete použít metodu [getSlideById](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (nabízenou třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/)). Tento Java kód ukazuje, jak zadat platné ID snímku a získat tento snímek pomocí metody [getSlideById](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlideById-long-):

```java
// Vytvoří objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("demo.pptx");
try {
    // Získá ID snímku
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Přistupuje k snímku pomocí jeho ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Změna pozice snímku**

Aspose.Slides umožňuje změnit pozici snímku. Například můžete určit, že má první snímek stát se druhým snímkem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte referenci na snímek (jejíž pozici chcete změnit) pomocí jeho indexu.
3. Nastavte novou pozici snímku pomocí vlastnosti [setSlideNumber](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).
4. Uložte upravenou prezentaci.

Tento Java kód demonstruje operaci, při které je snímek na pozici 1 přesunut na pozici 2:

```java
// Vytvoří objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Získá snímek, jehož pozice bude změněna
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Nastaví novou pozici pro snímek
    sld.setSlideNumber(2);
    
    // Uloží upravenou prezentaci
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

První snímek se stal druhým; druhý snímek se stal prvním. Když změníte pozici snímku, ostatní snímky jsou automaticky upraveny.

## **Nastavení čísla snímku**

Pomocí vlastnosti [setFirstSlideNumber](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (nabízené třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/)) můžete určit nové číslo pro první snímek v prezentaci. Tato operace způsobí přepočet čísel ostatních snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte číslo snímku.
3. Nastavte číslo snímku.
4. Uložte upravenou prezentaci.

Tento Java kód demonstruje operaci, při které je první snímek nastaven na číslo 10:

```java
// Vytvoří objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Získá číslo snímku
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Nastaví číslo snímku
    pres.setFirstSlideNumber(10);
	
    // Uloží upravenou prezentaci
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Pokud chcete přeskočit první snímek, můžete číslování zahájit od druhého snímku (a skrýt číslování pro první snímek) takto:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Nastaví číslo pro první snímek prezentace
    presentation.setFirstSlideNumber(0);

    // Zobrazí čísla snímků pro všechny snímky
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Skryje číslo snímku pro první snímek
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Uloží upravenou prezentaci
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Často kladené otázky**

**Odpovídá číslo snímku, které uživatel vidí, nulovému indexu ve sbírce?**

Číslo zobrazené na snímku může začínat libovolnou hodnotou (např. 10) a nemusí odpovídat indexu; vztah je řízen nastavením [first slide number](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) v prezentaci.

**Ovlivňují skryté snímky indexování?**

Ano. Skrytý snímek zůstává ve sbírce a je započítán do indexování; „skrytý“ se vztahuje k zobrazení, nikoli k jeho pozici ve sbírce.

**Mění se index snímku, když jsou přidány nebo odebrány jiné snímky?**

Ano. Indexy vždy odrážejí aktuální pořadí ve sbírce snímků a jsou přepočítány při vložení, smazání nebo přesunu snímků.