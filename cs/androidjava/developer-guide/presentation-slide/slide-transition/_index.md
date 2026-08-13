---
title: Správa přechodů snímků v prezentacích na Androidu
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/androidjava/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- aplikovat přechod snímku
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
description: "Objevte, jak přizpůsobit přechody snímků v Aspose.Slides pro Android prostřednictvím Java, s podrobným postupem pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat přechody snímků v prezentacích pomocí Aspose.Slides. Ukazuje, jak aplikovat typy přechodů na snímky, nakonfigurovat chování přechodu, jako je postupovat po kliknutí nebo po uplynutí určeného času, použít Morph přechod a jeho typy a nastavit možnosti efektu přechodu. Příklady demonstrují, jak načíst nebo vytvořit prezentaci, upravit nastavení přechodu pro vybrané snímky a uložit výsledek jako soubor PPTX. Článek také odpovídá na běžné otázky o rychlosti přechodu, zvucích přechodu, aplikaci stejného přechodu na více snímků a kontrole aktuálně nastaveného přechodu na snímku.

## **Přidat přechod snímku**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
2. Použijte typ přechodu snímku na snímku z jedněch z přechodových efektů nabízených společností Aspose.Slides pro Android prostřednictvím Java pomocí výčtu TransitionType.
3. Zapište upravený soubor prezentace.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Použijte přechod typu kruh na snímku 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Použijte přechod typu hřeben na snímku 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Uložte prezentaci na disk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidat pokročilý přechod snímku**
V předchozí části jsme na snímek použili jednoduchý přechodový efekt. Nyní, abychom tento jednoduchý efekt přechodu vylepšili a lépe ovládali, postupujte podle níže uvedených kroků:
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
2. Použijte typ přechodu snímku na snímku z jedněch z přechodových efektů nabízených společností Aspose.Slides pro Android prostřednictvím Java.
3. Můžete také nastavit přechod na Pokračovat po kliknutí, po určitém časovém intervalu nebo obojí.
4. Pokud je přechod snímku nastaven na Pokračovat po kliknutí, přechod se posune pouze po kliknutí myší. Navíc, pokud je nastavena vlastnost Advance After Time, přechod se automaticky posune po uplynutí zadaného času.
5. Zapište upravenou prezentaci jako soubor prezentace.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Použijte přechod typu kruh na snímku 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Postupovat po kliknutí nebo automaticky po 3 sekundách
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Použijte přechod typu hřeben na snímku 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Postupovat po kliknutí nebo automaticky po 5 sekundách
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Použijte přechod typu zoom na snímku 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Postupovat po kliknutí nebo automaticky po 7 sekundách
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
Aspose.Slides pro Android prostřednictvím Java nyní podporuje [Morph Transition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IMorphTransition). Jedná se o nový morph přechod zavedený v PowerPointu 2019.
{{% /alert %}} 

Morph přechod vám umožní plynule animovat přechod z jednoho snímku na další. Tento článek popisuje pojem a jak Morph přechod použít. Pro efektivní použití Morph přechodu potřebujete mít dva snímky s alespoň jedním společným objektem. Nejsnadnější způsob je duplikovat snímek a poté přesunout objekt na druhém snímku na jiné místo.

Následující úryvek kódu ukazuje, jak přidat klon snímku s nějakým textem do prezentace a nastavit přechod typu [morph type](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TransitionType) na druhý snímek.

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

## **Typy Morph přechodu**
Byl přidán nový výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TransitionMorphType). Reprezentuje různé typy Morph přechodu snímku.

Výčet TransitionMorphType má tři položky:
- ByObject: Morph přechod bude proveden s ohledem na tvary jako nedělitelná objekty.
- ByWord: Morph přechod bude proveden převedením textu po slovech, kde je to možné.
- ByChar: Morph přechod bude proveden převedením textu po znacích, kde je to možné.

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

## **Nastavit efekty přechodu**
Aspose.Slides pro Android prostřednictvím Java podporuje nastavení efektů přechodu, jako např. z černé, zleva, zprava atd. Pro nastavení efektu přechodu postupujte podle následujících kroků:
- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
- Získejte odkaz na snímek.
- Nastavte efekt přechodu.
- Zapište prezentaci jako soubor [PPTX ](https://docs.fileformat.com/presentation/pptx/).

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

## **FAQ**

### Můžu řídit rychlost přehrávání přechodu snímku?
Ano. Nastavte [rychlost](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) přechodu pomocí nastavení [TransitionSpeed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/transitionspeed/) (např. pomalá/střední/rychlá).

### Mohu k přechodu připojit zvuk a nastavit smyčku?
Ano. Můžete do přechodu vložit zvuk a řídit jeho chování pomocí nastavení jako režim zvuku a opakování (např. [setSound](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadata jako [setSoundIsBuiltIn](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) a [setSoundName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Jaký je nejrychlejší způsob, jak použít stejný přechod na každý snímek?
Nastavte požadovaný typ přechodu v nastavení přechodu každého snímku; přechody jsou ukládány per snímek, takže aplikace stejného typu na všechny snímky poskytne jednotný výsledek.

### Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?
Prohlédněte nastavení [přechodu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) daného snímku a přečtěte jeho [typ přechodu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); tato hodnota přesně určuje, jaký efekt je aplikován.