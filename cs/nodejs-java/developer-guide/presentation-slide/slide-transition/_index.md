---
title: Správa přechodů snímků v prezentacích pomocí JavaScriptu
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Přizpůsobte přechody snímků v JavaScriptu pomocí Aspose.Slides pro Node.js via Java, s podrobným návodem pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat přechody snímků v prezentacích pomocí Aspose.Slides. Ukazuje, jak použít typy přechodů na snímky, nakonfigurovat chování přechodu, například postup po kliknutí nebo po uplynutí určeného času, zkontrolovat a zakázat automatické postupování, použít Morph přechod a jeho typy a nastavit možnosti efektu přechodu. Příklady demonstrují, jak načíst nebo vytvořit prezentaci, upravit nastavení přechodů pro vybrané snímky a uložit výsledek jako soubor PPTX. Článek také odpovídá na časté otázky o rychlosti přechodu, zvucích přechodu, aplikaci stejného přechodu na více snímků a kontrole přechodu aktuálně nastaveného na snímku.

## **Přidání přechodu snímku**

Pro vytvoření jednoduchého efektu přechodu snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
2. Použijte typ přechodu snímku na snímku z jedněch z přechodových efektů nabízených společností Aspose.Slides pro Node.js via Java pomocí výčtu TransitionType enum.
3. Uložte upravený soubor prezentace.

```javascript
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Použijte kruhový typ přechodu na snímku 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Použijte typ přechodu comb na snímku 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Uložte prezentaci na disk
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání pokročilého přechodu snímku**

V předchozí sekci jsme použili jen jednoduchý efekt přechodu na snímku. Nyní, abychom tento jednoduchý efekt učinili ještě lepším a ovladatelnějším, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
2. Použijte typ přechodu snímku na snímku z jedněch z přechodových efektů nabízených Aspose.Slides pro Node.js via Java.
3. Můžete také nastavit přechod na Pokračovat po kliknutí, po určitém časovém intervalu nebo obojí.
4. Pokud je přechod snímku nastaven na Pokračovat po kliknutí, přechod se posune pouze po kliknutí myší. Navíc, pokud je nastavena vlastnost Advance After Time, přechod se posune automaticky po uplynutí určeného času.
5. Uložte upravenou prezentaci jako soubor prezentace.

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Použijte kruhový typ přechodu na snímku 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Nastavte čas přechodu na 3 sekundy
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Použijte typ přechodu comb na snímku 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Nastavte čas přechodu na 5 sekund
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Použijte typ přechodu zoom na snímku 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Nastavte čas přechodu na 7 sekund
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Uložte prezentaci na disk
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph přechod**
{{% alert color="primary" %}} 
Aspose.Slides pro Node.js via Java nyní podporuje [Morph Transition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MorphTransition). Jedná se o nový morph přechod zavedený v PowerPoint 2019.
{{% /alert %}} 

Morph přechod vám umožňuje animovat plynulý pohyb z jednoho snímku na další. Tento článek popisuje koncept a způsob použití Morph přechodu. Pro efektivní použití Morph přechodu potřebujete dvě snímky, které mají alespoň jeden společný objekt. Nejjednodušší způsob je duplikovat snímek a poté přesunout objekt na druhém snímku na jiné místo.

Následující úryvek kódu ukazuje, jak přidat klon snímku s nějakým textem do prezentace a nastavit přechod typu [morph type](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TransitionType) na druhý snímek.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Typy Morph přechodu**
Byl přidán nový výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TransitionMorphType). Reprezentuje různé typy Morph přechodu snímku.

Výčet TransitionMorphType má tři položky:

- ByObject: Morph přechod bude proveden s ohledem na tvary jako nedělitelných objektů.
- ByWord: Morph přechod bude proveden převodem textu po slovech, kde je to možné.
- ByChar: Morph přechod bude proveden převodem textu po znacích, kde je to možné.

Následující úryvek kódu ukazuje, jak nastavit morph přechod na snímek a změnit typ morph:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení efektů přechodu**
Aspose.Slides pro Node.js via Java podporuje nastavení efektů přechodu, jako je z černé, zleva, zprava atd. Pro nastavení efektu přechodu postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Získejte referenci na snímek.
- Nastavte efekt přechodu.
- Uložte prezentaci jako soubor [PPTX ](https://docs.fileformat.com/presentation/pptx/).

V níže uvedeném příkladu jsme nastavili efekty přechodu.

```javascript
// Vytvořte instanci třídy Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Nastavte efekt
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Uložte prezentaci na disk
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Nastavte [speed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/setspeed/) přechodu pomocí nastavení [TransitionSpeed](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/transitionspeed/) (např. pomalá/střední/rychlá).

**Mohu k přechodu připojit zvuk a nastavit jeho opakování?**

Ano. Můžete vložit zvuk do přechodu a řídit chování pomocí nastavení jako je režim zvuku a opakování (např. [setSound](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), plus metadata jako [setSoundIsBuiltIn](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) a [setSoundName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na každý snímek?**

Nastavte požadovaný typ přechodu v nastavení přechodu každého snímku; přechody jsou uloženy per snímek, takže aplikace stejného typu na všechny snímky poskytne jednotný výsledek.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Prohlédněte si [nastavení přechodu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) snímku a přečtěte jeho [transition type](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideshowtransition/gettype/); tato hodnota vám přesně řekne, který efekt je aplikován.