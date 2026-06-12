---
title: Animovat text v PowerPointu v PHP
linktitle: Animovaný text
type: docs
weight: 60
url: /cs/php-java/animated-text/
keywords:
- animovaný text
- animace textu
- animovaný odstavec
- animace odstavce
- efekt animace
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte dynamický animovaný text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java, s snadno sledovatelnými, optimalizovanými ukázkami kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s animovaným textem v Aspose.Slides použitím animačních efektů na jednotlivé odstavce a jak získat efekty již přiřazené odstavcům v textovém rámečku. Zaměřuje se na API metody používané k přidání animace na úrovni odstavce a inspekci existujících animačních efektů odstavců v prezentaci.

## **Přidání animačních efektů k odstavcům**

Přidali jsme metodu [**addEffect()**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) do třídy [**Sequence**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Sequence). Tato metoda vám umožňuje přidat animační efekty k jednomu odstavci. Tento ukázkový kód vám ukazuje, jak přidat animační efekt k jednomu odstavci:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # vyberte odstavec pro přidání efektu
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # přidejte efekt animace Fly do vybraného odstavce
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Získání animačních efektů odstavců**

Možná budete chtít zjistit animační efekty přidané k odstavci – například v jednom scénáři chcete získat animační efekty v odstavci, protože je chcete použít pro jiný odstavec nebo tvar.

Aspose.Slides pro PHP přes Java vám umožňuje získat všechny animační efekty aplikované na odstavce obsažené v textovém rámečku (tvaru). Tento ukázkový kód vám ukazuje, jak získat animační efekty v odstavci:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Často kladené otázky**

**Jak se animační efekty textu liší od přechodů snímků a lze je kombinovat?**

Animační efekty textu řídí chování objektu v čase na snímku, zatímco [přechody](/slides/cs/php-java/slide-transition/) řídí, jak se snímky mění. Jsou nezávislé a lze je použít společně; pořadí přehrávání je řízeno časovou osou animace a nastavením přechodů.

**Zůstávají animační efekty textu zachovány při exportu do PDF nebo obrázků?**

Ne. PDF a rastrové obrázky jsou statické, takže uvidíte jediný stav snímku bez pohybu. Pro zachování pohybu použijte export do [video](/slides/cs/php-java/convert-powerpoint-to-video/) nebo [HTML](/slides/cs/php-java/export-to-html5/).

**Fungují animační efekty textu v rozvrženích a hlavním motivu snímku?**

Efekty aplikované na objekty rozvržení/masteru jsou děděny snímky, ale jejich načasování a interakce s animačními efekty na úrovni snímku závisí na konečné sekvenci na snímku.