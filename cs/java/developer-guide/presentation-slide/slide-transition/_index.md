---
title: Správa přechodů snímků v prezentacích pomocí Java
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/java/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- použít přechod snímku
- pokročilý přechod snímku
- morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak přizpůsobit přechody snímků v Aspose.Slides for Java, s průvodcem krok za krokem pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat přechody snímků v prezentacích pomocí Aspose.Slides. Ukazuje, jak aplikovat typy přechodů na snímky, konfigurovat chování přechodu, například postup po kliknutí nebo po nastaveném čase, zkontrolovat a zakázat automatické postoupání, použít Morph přechod a jeho typy a nastavit možnosti efektu přechodu. Příklady demonstrují, jak načíst nebo vytvořit prezentaci, upravit nastavení přechodu pro vybrané snímky a uložit výsledek jako soubor PPTX. Článek také odpovídá na časté otázky týkající se rychlosti přechodu, zvuků přechodu, aplikace stejného přechodu na více snímků a kontroly přechodu aktuálně nastaveného na snímku.

## **Přidání přechodu snímku**
Pro vytvoření jednoduchého efektu přechodu snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) .
2. Použijte typ přechodu snímku na snímku z jedné z nabízených efektů přechodu od Aspose.Slides for Java pomocí výčtu TransitionType .
3. Zapište upravený soubor prezentace.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Aplikujte kruhový typ přechodu na snímek 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Aplikujte typ přechodu comb na snímek 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Uložte prezentaci na disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání pokročilého přechodu snímku**
V předchozí sekci jsme použili jen jednoduchý efekt přechodu na snímku. Nyní, aby byl tento jednoduchý efekt ještě lepší a kontrolovatelný, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) .
2. Použijte typ přechodu snímku na snímku z jedné z nabízených efektů přechodu od Aspose.Slides for Java .
3. Můžete také nastavit přechod tak, aby se posunul po kliknutí, po konkrétním časovém intervalu nebo obojí.
4. Pokud je přechod snímku povolen k posunu po kliknutí, přechod se posune pouze při kliknutí myši. Navíc pokud je nastavena vlastnost Advance After Time, přechod se posune automaticky po uplynutí určeného času.
5. Zapište upravenou prezentaci jako soubor prezentace.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Aplikujte kruhový typ přechodu na snímek 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Nastavte čas přechodu na 3 sekundy
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Aplikujte typ přechodu comb na snímek 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Nastavte čas přechodu na 5 sekund
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Aplikujte zoom typ přechodu na snímek 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Nastavte čas přechodu na 7 sekund
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Uložte prezentaci na disk
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph přechod**
{{% alert color="info" %}} 

Aspose.Slides for Java nyní podporuje [Morph Transition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IMorphTransition). Jedná se o nový morph přechod zavedený v PowerPoint 2019.

{{% /alert %}} 

Morph přechod vám umožňuje plynule animovat pohyb z jednoho snímku na další. Tento článek popisuje koncept a způsob použití Morph přechodu. Pro efektivní použití Morph přechodu potřebujete dva snímky s alespoň jedním společným objektem. Nejjednodušší způsob je duplikovat snímek a pak přesunout objekt na druhém snímku na jiné místo.

Následující úryvek kódu ukazuje, jak přidat klon snímku s textem do prezentace a nastavit přechod [morph type](https://reference.aspose.com/slides/cs/java/com.aspose.slides/TransitionType) na druhý snímek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Typy morph přechodu**
Došlo k přidání nového výčtu [TransitionMorphType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/TransitionMorphType). Reprezentuje různé typy Morph přechodu snímku.

Výčet TransitionMorphType má tři členy:

- ByObject: Morph přechod bude proveden s ohledem na tvary jako nedělitelných objektů.
- ByWord: Morph přechod bude proveden s přesunem textu po slovech, kde je to možné.
- ByChar: Morph přechod bude proveden s přesunem textu po znacích, kde je to možné.

Následující úryvek kódu ukazuje, jak nastavit morph přechod na snímek a změnit typ morphu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení efektů přechodu**
Aspose.Slides for Java podporuje nastavení efektů přechodu, jako například z černé, zleva, zprava atd. Pro nastavení efektu přechodu postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
- Získejte referenci na snímek.
- Nastavte efekt přechodu.
- Zapište prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) .

V níže uvedeném příkladu jsme nastavili efekty přechodu.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Nastavte efekt
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Uložte prezentaci na disk
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

### Můžu řídit rychlost přehrávání přechodu snímku?

Ano. Nastavte [speed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) přechodu pomocí nastavení [TransitionSpeed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitionspeed/) (např. pomalá/střední/rychlá).

### Můžu ke přechodu připojit audio a nechat jej opakovat?

Ano. Můžete vložit zvuk pro přechod a ovládat chování pomocí nastavení jako režim zvuku a opakování (např. [setSound](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadata jako [setSoundIsBuiltIn](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) a [setSoundName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na každý snímek?

Nakonfigurujte požadovaný typ přechodu v nastavení přechodu každého snímku; přechody jsou uloženy po snímku, takže aplikace stejného typu na všechny snímky poskytne jednotný výsledek.

### Jak mohu zkontrolovat, který přechod je aktuálně nastaven na snímku?

Prozkoumejte [transition settings](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslide/#getSlideShowTransition--) snímku a přečtěte jeho [transition type](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setType-int-); tato hodnota vám přesně řekne, který efekt je aplikován.