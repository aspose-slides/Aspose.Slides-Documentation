---
title: Změna velikosti snímků prezentace v PHP
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/php-java/slide-size/
keywords:
- velikost snímku
- poměr stran
- standardní
- širokoúhlý
- 4:3
- 16:9
- nastavit velikost snímku
- změnit velikost snímku
- vlastní velikost snímku
- speciální velikost snímku
- unikátní velikost snímku
- snímek v plné velikosti
- typ obrazovky
- neškálovat
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí PHP a Aspose.Slides, optimalizovat prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší monitory a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se používají pro všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód ukazuje, jak změnit velikost snímku v prezentaci pomocí Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Určení vlastních velikostí snímků v prezentacích**

Pokud považujete běžné velikosti snímků (4:3 a 16:9) za nevhodné pro svou práci, můžete se rozhodnout použít konkrétní nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně získáte výhodu použitím vlastního nastavení velikosti pro vaši prezentaci.

Tento ukázkový kód ukazuje, jak pomocí Aspose.Slides pro PHP přes Java zadat vlastní velikost snímku pro prezentaci :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// Velikost papíru A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zpracování obsahu snímků po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) deformovat. Ve výchozím nastavení jsou objekty automaticky změněny tak, aby odpovídaly nové velikosti snímku. Při změně velikosti snímku však můžete určit nastavení, které rozhoduje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co chcete dosáhnout, můžete použít kterékoliv z těchto nastavení:

- `DoNotScale`

  Pokud **NECHCETE**, aby byly objekty na snímcích změněny, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete zmenšit velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty na snímcích tak, aby se všechny vešly (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- `Maximize`

  Pokud chcete zvětšit velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty na snímcích tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení.

Tento ukázkový kód ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené dotazy**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod = 1/72 palce. Libovolnou jednotku (např. milimetry nebo centimetry) můžete převést na body a použít tyto převedené hodnoty k definování šířky a výšky snímku.

**Ovplyvní velmi velká vlastní velikost snímku výkon a využití paměti během renderování?**

Ano. Větší rozměry snímků (v bodech) v kombinaci s vyšším měřítkem renderování vedou ke zvýšené spotřebě paměti a delším časům zpracování. Snažte se o praktickou velikost snímku a měřítko renderování upravujte jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/php-java/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete snímky sloučit a zachovat formátování.

**Mohu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vytvořit náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, čímž zajišťují konzistentní ohraničení a geometrii.