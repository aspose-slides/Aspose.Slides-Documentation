---
title: Správa přechodů snímků v prezentacích pomocí Java
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/java/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- aplikovat přechod snímku
- pokročilý přechod snímku
- morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak přizpůsobit přechody snímků v Aspose.Slides pro Java, s podrobným průvodcem pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Článek vysvětluje, jak spravovat přechody snímků v prezentacích pomocí Aspose.Slides. Ukazuje, jak aplikovat typy přechodů na snímky, nakonfigurovat chování přechodu, například pokročování po kliknutí nebo po uplynutí určeného času, zkontrolovat a zakázat automatické pokročování, použít Morph přechod a jeho typy a nastavit možnosti efektu přechodu. Příklady ukazují, jak načíst nebo vytvořit prezentaci, upravit nastavení přechodu pro vybrané snímky a uložit výsledek jako soubor PPTX. Článek také odpovídá na časté otázky o rychlosti přechodu, zvucích přechodu, aplikaci stejného přechodu na více snímků a kontrole přechodu aktuálně nastaveného na snímku.

## **Přidat přechod snímku**
Pro vytvoření jednoduchého efektu přechodu snímku postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Použijte typ přechodu snímku na snímku z jedněch z efektů přechodu nabízených společností Aspose.Slides pro Java pomocí výčtu TransitionType.
1. Zapište upravený soubor prezentace.

```java
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Aplikujte přechod typu kruh na snímek 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Aplikujte přechod typu hřeben na snímek 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Uložte prezentaci na disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidat pokročilý přechod snímku**
V předchozí části jsme aplikovali jednoduchý efekt přechodu na snímek. Nyní, abychom tento jednoduchý efekt učinili ještě lepším a řízenějším, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Použijte typ přechodu snímku na snímku z jedněch z efektů přechodu nabízených společností Aspose.Slides pro Java.
1. Můžete také nastavit přechod na Pokročování po kliknutí, po konkrétním časovém intervalu nebo obojí.
1. Pokud je přechod snímku povolen na Pokročování po kliknutí, přechod se posune pouze po kliknutí myší. Navíc, pokud je nastaven vlastnost Advance After Time, přechod se automaticky posune po uplynutí zadaného času.
1. Zapište upravenou prezentaci jako soubor prezentace.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Aplikujte přechod typu kruh na snímek 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Nastavte dobu trvání přechodu na 3 sekundy
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Aplikujte přechod typu hřeben na snímek 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Nastavte dobu trvání přechodu na 5 sekund
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Aplikujte přechod typu zoom na snímek 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Nastavte dobu trvání přechodu na 7 sekund
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Uložte prezentaci na disk
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph přechod**
{{% alert color="primary" %}} 

Aspose.Slides pro Java nyní podporuje [Morph Transition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IMorphTransition). Jedná se o nový morph přechod zavedený v PowerPoint 2019.

{{% /alert %}} 

Morph přechod vám umožňuje animovat plynulý přechod z jednoho snímku na další. Tento článek popisuje koncept a způsob použití Morph přechodu. Pro efektivní použití Morph přechodu potřebujete mít dva snímky s alespoň jedním společným objektem. Nejjednodušší způsob je duplikovat snímek a poté přesunout objekt na druhém snímku na jiné místo.

Následující úryvek kódu ukazuje, jak přidat klon snímku s nějakým textem do prezentace a nastavit přechod typu [morph type](https://reference.aspose.com/slides/cs/java/com.aspose.slides/TransitionType) na druhý snímek.

```java
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

## **Typy Morph přechodu**
Nový výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/TransitionMorphType) byl přidán. Reprezentuje různé typy Morph přechodu snímku.

Výčet TransitionMorphType má tři členy:

- ByObject: Morph přechod bude proveden s ohledem na tvary jako nedělitelné objekty.
- ByWord: Morph přechod bude proveden převodem textu po slovech, kde je to možné.
- ByChar: Morph přechod bude proveden převodem textu po znacích, kde je to možné.

Následující úryvek kódu ukazuje, jak nastavit morph přechod na snímek a změnit typ morphu:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit efekty přechodu**
Aspose.Slides pro Java podporuje nastavení efektů přechodu, jako jsou z černé, zleva, zprava atd. Pro nastavení efektu přechodu postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
- Získejte referenci na snímek.
- Nastavte efekt přechodu.
- Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).

V níže uvedeném příkladu jsme nastavili efekty přechodu.

```java
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

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Nastavte [rychlost](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) přechodu pomocí nastavení [TransitionSpeed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/transitionspeed/) (např. pomalá/střední/rychlá).

**Mohu k přechodu připojit zvuk a nastavit jeho opakování?**

Ano. Můžete vložit zvuk pro přechod a řídit chování pomocí nastavení, jako je režim zvuku a opakování (např. [setSound](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadata jako [setSoundIsBuiltIn](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) a [setSoundName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Jaký je nejrychlejší způsob, jak použít stejný přechod na každý snímek?**

Konfigurujte požadovaný typ přechodu v nastavení přechodu každého snímku; přechody jsou uloženy pro každý snímek, takže použití stejného typu na všechny snímky poskytne konzistentní výsledek.

**Jak mohu zkontrolovat, který přechod je aktuálně nastaven na snímku?**

Prohlédněte si [nastavení přechodu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslide/#getSlideShowTransition--) snímku a přečtěte jeho [typ přechodu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slideshowtransition/#setType-int-); tato hodnota vám přesně sdělí, který efekt je aplikován.