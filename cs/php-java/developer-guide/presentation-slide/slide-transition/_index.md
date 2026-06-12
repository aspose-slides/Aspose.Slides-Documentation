---
title: Správa přechodů snímků v prezentacích pomocí PHP
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/php-java/slide-transition/
keywords:
- přechod snímku
- přidání přechodu snímku
- aplikace přechodu snímku
- pokročilý přechod snímku
- morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Objevte, jak přizpůsobit přechody snímků v Aspose.Slides pro PHP přes Java, s podrobným návodem pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat přechody snímků v prezentacích pomocí Aspose.Slides. Ukazuje, jak použít typy přechodů na snímky, nakonfigurovat chování přechodu, například přechod na kliknutí nebo po uplynutí určené doby, zkontrolovat a zakázat automatické přecházení, použít přechod Morph a jeho typy a nastavit možnosti efektu přechodu. Příklady ukazují, jak načíst nebo vytvořit prezentaci, upravit nastavení přechodu pro vybrané snímky a uložit výsledek jako soubor PPTX. Článek také odpovídá na časté otázky o rychlosti přechodu, zvucích přechodu, aplikaci stejného přechodu na více snímků a kontrole přechodu aktuálně nastaveného na snímku.

## **Přidání přechodu snímku**
Pro vytvoření jednoduchého efektu přechodu snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Aplikujte typ přechodu snímku na snímek z jedné z nabízených přechodových efektů pomocí výčtu TransitionType.
1. Zapište upravený soubor prezentace.

```php
  # Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Použijte přechod typu circle na snímku 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Použijte přechod typu comb na snímku 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Uložte prezentaci na disk
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Přidání pokročilého přechodu snímku**
V předchozí sekci jsme použili jednoduchý efekt přechodu na snímek. Nyní, pro vylepšení a lepší kontrolu tohoto efektu, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Aplikujte typ přechodu snímku na snímek z jedné z nabízených přechodových efektů.
1. Můžete také nastavit přechod na „Advance On Click“, po určité době nebo obojí.
1. Pokud je přechod snímku povolen na „Advance On Click“, přechod proběhne pouze po kliknutí myší. Pokud je nastavená vlastnost „Advance After Time“, přechod proběhne automaticky po uplynutí zadané doby.
1. Zapište upravenou prezentaci jako soubor prezentace.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Použijte přechod typu circle na snímku 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Nastavte čas přechodu na 3 sekundy
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Použijte přechod typu comb na snímku 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Nastavte čas přechodu na 5 sekund
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Použijte přechod typu zoom na snímku 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Nastavte čas přechodu na 7 sekund
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Uložte prezentaci na disk
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Morph přechod**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java nyní podporuje [Morph Transition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/morphtransition/). Jedná se o nový morph přechod zavedený v PowerPointu 2019.

{{% /alert %}} 

Morph přechod vám umožňuje animovat plynulý pohyb z jednoho snímku na další. Tento článek popisuje koncept a způsob použití Morph přechodu. Pro efektivní použití Morph přechodu budete potřebovat dva snímky se společným alespoň jedním objektem. Nejjednodušší je duplikovat snímek a poté přesunout objekt na druhém snímku na jiné místo.

Následující úryvek kódu ukazuje, jak přidat klon snímku s textem do prezentace a nastavit přechod [morph type](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TransitionType) na druhý snímek.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Typy Morph přechodu**
Byl přidán nový výčtový typ [TransitionMorphType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TransitionMorphType). Reprezentuje různé typy Morph přechodu snímku.

Výčet TransitionMorphType má tři členy:

- ByObject: Morph přechod bude proveden s ohledem na tvary jako nedělitelné objekty.
- ByWord: Morph přechod bude proveden převodem textu po slovech, kde je to možné.
- ByChar: Morph přechod bude proveden převodem textu po znacích, kde je to možné.

Následující úryvek kódu ukazuje, jak nastavit morph přechod na snímek a změnit typ morphu:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Nastavení efektů přechodu**
Aspose.Slides for PHP via Java podporuje nastavení efektů přechodu, jako např. z černé, zleva, zprava atd. Pro nastavení efektu přechodu postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Získejte referenci na snímek.
- Nastavte efekt přechodu.
- Zapište prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).

V níže uvedeném příkladu jsme nastavili efekty přechodu.

```php
  # Vytvořte instanci třídy Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Nastavte efekt
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Uložte prezentaci na disk
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Časté dotazy**

**Mohu ovládat rychlost přehrávání přechodu snímku?**

Ano. Nastavte [speed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/setspeed/) přechodu pomocí nastavení [TransitionSpeed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/transitionspeed/) (např. slow/medium/fast).

**Mohu k přechodu připojit zvuk a nechat jej opakovat?**

Ano. Můžete vložit zvuk pro přechod a řídit chování pomocí nastavení jako režim zvuku a smyčka (např. [setSound](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/setsoundloop/), plus metadata jako [setSoundIsBuiltIn](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) a [setSoundName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Jak nejrychleji použít stejný přechod na všechny snímky?**

Nakonfigurujte požadovaný typ přechodu v nastavení přechodu každého snímku; přechody jsou uloženy per snímek, takže aplikace stejného typu na všechny snímky poskytne jednotný výsledek.

**Jak zjistit, který přechod je aktuálně nastaven na snímku?**

Prohlédněte si [nastavení přechodu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getSlideShowTransition) snímku a přečtěte jeho [transition type](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideshowtransition/settype/); tato hodnota vám přesně řekne, který efekt je aplikován.