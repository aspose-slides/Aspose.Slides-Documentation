---
title: Spravovat ink objekty prezentace v PHP
linktitle: Spravovat ink
type: docs
weight: 95
url: /cs/php-java/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- správa ink
- kreslení ink
- kreslení
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Spravovat ink objekty PowerPoint — vytvářet, upravovat a stylovat digitální ink pomocí Aspose.Slides pro PHP přes Java. Získejte ukázky kódu pro stopy, barvu a velikost štětce."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která vám umožňuje kreslit nestandardní tvary, jež lze použít k zvýraznění dalších objektů, zobrazování spojení a procesů a přitáhnout pozornost k určitým položkám na snímku.  

Aspose.Slides poskytuje všechny typy Ink (např. třída [Ink](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ink/)) které potřebujete pro vytváření a správu ink objektů.

## **Rozdíly mezi běžnými objekty a Ink objekty**

Objekty na snímku PowerPointu jsou obvykle reprezentovány objekty tvaru. Objekt tvaru v nejjednodušší podobě představuje kontejner, který určuje oblast samotného objektu (jeho rámec) spolu s jeho vlastnostmi. Poslední zahrnuje velikost oblasti kontejneru, tvar kontejneru, pozadí kontejneru atd. Pro informace viz [Shape Layout Format](https://docs.aspose.com/slides/cs/php-java/shape-manipulations/#access-layout-formats-for-shape).

Nicméně když PowerPoint pracuje s ink objektem, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními hodnotami `width` a `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Stopy**

Stopa je základní prvek nebo standard používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopy jsou záznamy popisující sekvence spojených bodů.  

Nejjednodušší forma kódování specifikuje souřadnice X a Y každého vzorkovacího bodu. Když jsou všechny spojené body vykresleny, vytvoří se obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Můžete použít štětec k nakreslení čar spojujících body elementů stopy. Štětec má vlastní barvu a velikost, odpovídající vlastnostem `Brush.Color` a `Brush.Size`.  

### **Nastavit barvu Ink štětce**

Tento PHP kód ukazuje, jak nastavit barvu štětce:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Nastavit velikost Ink štětce**

Tento PHP kód ukazuje, jak nastavit velikost štětce:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Obecně šířka a výška štětce neodpovídají, takže PowerPoint nezobrazuje velikost štětce (datová část je šedá). Když se šířka a výška štětce shodují, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku ink objektu a prozkoumáme důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců – vždy předpokládá, že tloušťka čáry je nula (viz poslední obrázek).  

Proto musíme při určení viditelné oblasti celého ink objektu zohlednit velikost štětců stop. Zde byl cílový objekt (stopa ručně psaného textu) přizpůsoben velikosti kontejneru (rámce). Když se velikost kontejneru (rámce) změní, velikost štětce zůstane konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vykazuje stejné chování při práci s texty:

![ink_powerpoint6](ink_powerpoint6.png)

**Další čtení**

* Pro čtení o tvarech obecně si přečtěte sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/php-java/powerpoint-shapes/).  
* Pro více informací o efektivních hodnotách viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/php-java/shape-effective-properties/#getting-effective-font-height-value).