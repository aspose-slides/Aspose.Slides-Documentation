---
title: Správa přechodů snímků v prezentacích na Androidu
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/androidjava/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- použít přechod snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte, jak přizpůsobit přechody snímků v Aspose.Slides pro Android pomocí Javy, s podrobným průvodcem pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat přechody snímků v prezentacích pomocí Aspose.Slides. Ukazuje, jak použít typy přechodů na snímky, nakonfigurovat chování přechodu, jako je postup po kliknutí nebo po uplynutí určeného času, zkontrolovat a zakázat automatické postupování, použít Morph přechod a jeho typy a nastavit možnosti efektu přechodu. Příklady demonstrují, jak načíst nebo vytvořit prezentaci, upravit nastavení přechodu pro vybrané snímky a uložit výsledek jako soubor PPTX. Článek také odpovídá na běžné otázky o rychlosti přechodu, zvucích přechodu, použití stejného přechodu na více snímcích a kontrolě, jaký přechod je aktuálně nastaven na snímku.

## **Přidání přechodu snímku**
Pro vytvoření jednoduchého efektu přechodu snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) class.
2. Použijte typ přechodu snímku na snímek z jedněch z přechodových efektů nabízených Aspose.Slides pro Android via Java pomocí výčtu TransitionType.
3. Zapište upravený soubor prezentace.

```java
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Použijte přechod typu kruh na snímku 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Použijte přechod typu hřeben na snímku 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Zapište prezentaci na disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání pokročilého přechodu snímku**
V předchozí části jsme použili jen jednoduchý efekt přechodu na snímku. Nyní, abychom tento jednoduchý efekt vylepšili a zpřesnili, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) class.
2. Použijte typ přechodu snímku na snímek z jedněch z přechodových efektů nabízených Aspose.Slides pro Android via Java.
3. Můžete také nastavit přechod tak, aby se posunul po kliknutí, po určité časové prodlevě nebo obojí.
4. Pokud je přechod snímku nastaven na Posun po kliknutí, přechod se posune pouze po kliknutí myší. Navíc, pokud je nastaveno vlastnost Advance After Time, přechod se posune automaticky po uplynutí zadaného času.
5. Zapište upravenou prezentaci jako soubor prezentace.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Použijte přechod typu kruh na snímku 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Nastavte dobu přechodu na 3 sekundy
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Použijte přechod typu hřeben na snímku 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Nastavte dobu přechodu na 5 sekund
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Použijte přechod typu zoom na snímku 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Nastavte dobu přechodu na 7 sekund
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Zapište prezentaci na disk
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph přechod**
{{% alert color="primary" %}} 

Aspose.Slides pro Android via Java nyní podporuje [Morph Transition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IMorphTransition). Jedná se o nový morph přechod zavedený v PowerPoint 2019.

{{% /alert %}} 

Morph přechod vám umožňuje animovat plynulý pohyb z jednoho snímku na další. Tento článek popisuje koncept a způsob použití Morph přechodu. Pro efektivní použití Morph přechodu potřebujete mít dva snímky s alespoň jedním společným objektem. Nejjednodušší je duplikovat snímek a poté přesunout objekt na druhém snímku na jiné místo.

Následující úryvek kódu ukazuje, jak přidat klon snímku s nějakým textem do prezentace a nastavit přechod [morph type](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TransitionType) na druhý snímek.

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
Byl přidán nový výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TransitionMorphType). Reprezentuje různé typy Morph přechodu snímku.

Výčet TransitionMorphType má tři členy:

- ByObject: Morph přechod bude proveden s ohledem na tvary jako nedělitelné objekty.
- ByWord: Morph přechod bude proveden přenášením textu po slovech, kde je to možné.
- ByChar: Morph přechod bude proveden přenášením textu po znacích, kde je to možné.

Následující úryvek kódu ukazuje, jak nastavit morph přechod na snímek a změnit typ morph:

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

## **Nastavení efektů přechodu**
Aspose.Slides pro Android via Java podporuje nastavení efektů přechodu, jako je z černé, zleva, zprava atd. Pro nastavení efektu přechodu postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) class.
- Získejte odkaz na snímek.
- Nastavte efekt přechodu.
- Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/)file.

V níže uvedeném příkladu jsme nastavili efekty přechodu.

```java
// Vytvořte instanci třídy Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Nastavte efekt
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Zapište prezentaci na disk
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Nastavte rychlost přechodu pomocí [speed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) pomocí nastavení [TransitionSpeed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/transitionspeed/) (např. pomalá/střední/rychlá).

**Mohu k přechodu připojit audio a nastavit jeho opakování?**

Ano. Můžete vložit zvuk pro přechod a řídit chování pomocí nastavení jako režim zvuku a smyčka (např. [setSound](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadata jako [setSoundIsBuiltIn](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) a [setSoundName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Jaký je nejrychlejší způsob, jak použít stejný přechod na každý snímek?**

Nastavte požadovaný typ přechodu v nastavení přechodu každého snímku; přechody jsou uloženy po snímku, takže aplikace stejného typu na všechny snímky poskytne jednotný výsledek.

**Jak mohu zkontrolovat, který přechod je aktuálně nastaven na snímku?**

Prohlédněte nastavení přechodu snímku a přečtěte jeho typ přechodu; tato hodnota vám řekne, který efekt je aplikován.