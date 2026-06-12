---
title: Správa zástupců prezentace v PHP
linktitle: Správa zástupců
type: docs
weight: 10
url: /cs/php-java/manage-placeholder/
keywords:
- zástupce
- textový zástupce
- obrázkový zástupce
- zástupce grafu
- text výzvy
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Jednoduše spravujte zástupce v Aspose.Slides pro PHP přes Java: nahraďte text, přizpůsobte výzvy a nastavte průhlednost obrázku v PowerPointu a OpenDocumentu."
---
## **Přehled**

Aspose.Slides vám umožňuje programově spravovat zástupce (placeholder) v prezentacích. Tento článek vysvětluje, jak na snímcích najít zástupce a změnit jejich text, nastavit vlastní výzvu textu pro rozložení zástupců a upravit průhlednost obrázku použitého jako pozadí zástupce. Obsahuje také krátké FAQ, které objasňuje rozdíl mezi základními zástupci a lokálními tvary, vysvětluje, jak lze změny zástupců aplikovat prostřednictvím rozložení nebo hlavních snímků, a odkazuje na správu zástupců záhlaví a patičky.

## **Změna textu ve zástupci**
Pomocí [Aspose.Slides pro PHP přes Java](/slides/cs/php-java/) můžete na snímcích v prezentacích najít a upravit zástupce. Aspose.Slides vám umožňuje měnit text ve zástupci.

**Předpoklad**: Potřebujete prezentaci, která obsahuje zástupce. Takovou prezentaci můžete vytvořit v běžné aplikaci Microsoft PowerPoint.

Takto pomocí Aspose.Slides nahradíte text ve zástupci v dané prezentaci:

1. Vytvořte instanci třídy [`Presentation`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) a předávejte prezentaci jako argument.
2. Získejte referenci na snímek pomocí jeho indexu.
3. Procházejte tvary a vyhledejte zástupce.
4. Přetypujte tvar zástupce na [`AutoShape`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/AutoShape) a změňte text pomocí [`TextFrame`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrame), který je spojený s [`AutoShape`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/AutoShape).
5. Uložte upravenou prezentaci.

Tento PHP kód ukazuje, jak změnit text ve zástupci:

```php
  # Vytvoří instanci třídy Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Prochází tvary a hledá zástupce
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Mění text v každém zástupci
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Uloží prezentaci na disk
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavení výzvy textu ve zástupci**
Standardní a předpřipravená rozložení obsahují výzvy textu jako ***Click to add a title*** nebo ***Click to add a subtitle***. Pomocí Aspose.Slides můžete do rozložení zástupců vložit vlastní výzvy textu.

Tento PHP kód ukazuje, jak nastavit výzvu textu ve zástupci:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Prochází snímek
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint zobrazuje "Klikněte pro přidání nadpisu"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Přidá podnadpis
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavení průhlednosti obrázku ve zástupci**

Aspose.Slides umožňuje nastavit průhlednost obrázku na pozadí textového zástupce. Úpravou průhlednosti obrázku v takovém rámečku můžete zvýraznit text nebo obrázek (v závislosti na barvách textu a obrázku).

Tento PHP kód ukazuje, jak nastavit průhlednost pozadí obrázku (uvnitř tvaru):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Co je základní zástupce a jak se liší od lokálního tvaru na snímku?**

Základní zástupce je původní tvar v rozložení nebo hlavním snímku, ze kterého dědí tvar snímku – typ, umístění a některé formátování pochází z něj. Lokální tvar je samostatný; pokud neexistuje základní zástupce, dědění se neuplatní.

**Jak mohu aktualizovat všechny nadpisy nebo popisky v celé prezentaci, aniž bych procházel každý snímek?**

Upravte odpovídající zástupce v rozložení nebo v hlavním snímku. Snímky založené na těchto rozloženích/hlavním snímku automaticky zdědí změnu.

**Jak mohu řídit standardní zástupce záhlaví/pati – datum a čas, číslo snímku a text patičky?**

Použijte správce HeaderFooter v odpovídajícím rozsahu (normální snímky, rozložení, hlavní snímek, poznámky/letáky) k zapnutí nebo vypnutí těchto zástupců a nastavení jejich obsahu.