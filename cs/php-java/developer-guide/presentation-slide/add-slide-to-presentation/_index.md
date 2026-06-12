---
title: Přidání snímků do prezentací v PHP
linktitle: Přidat snímek
type: docs
weight: 10
url: /cs/php-java/add-slide-to-presentation/
keywords:
- přidat snímek
- vytvořit snímek
- prázdný snímek
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Jednoduše přidejte snímky do vašich prezentací PowerPoint a OpenDocument pomocí Aspose.Slides for PHP via Java — plynulé, efektivní vkládání snímků během několika sekund."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat snímky do prezentací PowerPoint. Prezentace obsahuje master/layout snímky a běžné snímky a běžné snímky jsou uspořádány podle indexu začínajícího nulou. Každý snímek má jedinečné ID a soubory prezentací bez snímků nejsou podporovány.

Tento článek vysvětluje, jak vytvořit objekt `Presentation`, získat jeho kolekci snímků, přidat prázdný snímek, pracovat s nově přidaným snímkem a uložit aktualizovanou prezentaci. Také pokrývá související body, jako je vkládání snímků na konkrétní pozici, používání rozvržení a pochopení prázdného snímku, který existuje v nově vytvořené prezentaci.

## **Přidání snímku do prezentace**

Než se budeme zabývat přidáváním snímků do souborů prezentací, diskutujme některé skutečnosti o snímcích. Každý soubor prezentace PowerPoint obsahuje **Master / Layout** snímek a další **Normal** snímky. To znamená, že soubor prezentace obsahuje alespoň jeden nebo více snímků. Je důležité vědět, že soubory prezentací bez snímků nejsou podporovány Aspose.Slides for PHP via Java. Každý snímek má jedinečné Id a všechny Normal snímky jsou uspořádány v pořadí určeném indexem začínajícím nulou.

Aspose.Slides for PHP via Java umožňuje vývojářům přidávat prázdné snímky do jejich prezentace. Pro přidání prázdného snímku do prezentace postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
- Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/) pomocí metody [getSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#getSlides--) (kolekce objektů Slide) vystavené objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
- Přidejte prázdný snímek do prezentace na konci kolekce obsahových snímků voláním metod [**addEmptySlide**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/#addEmptySlide) vystavených objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/).
- Proveďte nějakou práci s nově přidaným prázdným snímkem.
- Nakonec zapište soubor prezentace pomocí objektu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation();
  try {
    # Vytvořte instanci třídy SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Přidejte prázdný snímek do kolekce Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Proveďte nějakou práci s nově přidaným snímkem
    # Uložte soubor PPTX na disk
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Často kladené otázky**

**Mohu vložit nový snímek na konkrétní pozici, ne jen na konec?**

Ano. Knihovna podporuje kolekce snímků a operace [insert](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/insertclone/), takže můžete přidat snímek na požadovaný index místo pouze na konec.

**Zachovají se motivy/styly při přidání snímku založeného na rozvržení?**

Ano. Rozvržení dědí formátování od svého masteru a nový snímek dědí od vybraného rozvržení a jeho přidruženého masteru.

**Který snímek je přítomen v nové "prázdné" prezentaci před přidáním snímků?**

Nově vytvořená prezentace již obsahuje jeden prázdný snímek s indexem nula. To je důležité vzít v úvahu při výpočtu indexů vkládání.

**Jak si vybrat "správné" rozvržení pro nový snímek, pokud má master mnoho možností?**

Obecně zvolte [LayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/), který odpovídá požadované struktuře ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidelayouttype/)). Pokud takové rozvržení chybí, můžete jej [přidat do masteru](/slides/cs/php-java/slide-layout/) a poté jej použít.