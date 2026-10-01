---
title: Změna velikosti snímku prezentace v PHP
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
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí PHP a Aspose.Slides, optimalizujte prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce. 

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší monitory a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se použijí na všechny snímky. Pro dosažení nejlepších výsledků nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="info" title="Note" %}}
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

Poznámky a stránky s výstřižky mají od běžných snímků odlišné rozměry. Viz [Velikost stránky s poznámkami](/slides/cs/php-java/notes-size/) pro změnu jejich velikosti a orientace.

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód vám ukazuje, jak změnit velikost snímku v prezentaci pomocí Aspose.Slides:

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

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete se rozhodnout použít specifickou nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazit na určitých typech obrazovek, pravděpodobně získáte výhodu z nastavení vlastní velikosti pro vaši prezentaci. 

Tento ukázkový kód vám ukazuje, jak pomocí Aspose.Slides pro PHP prostřednictvím Java specifikovat vlastní velikost snímku pro prezentaci:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// formát papíru A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zpracování obsahu snímku po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) zkreslit. Ve výchozím nastavení se objekty automaticky přizpůsobí nové velikosti snímku. Při změně velikosti snímku však můžete nastavit volbu, která určuje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co chcete dosáhnout, můžete použít některé z těchto nastavení:

- `DoNotScale`

  Pokud NENI chcete, aby objekty na snímcích byly změněny, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete přizpůsobit menší velikosti snímku a potřebujete, aby Aspose.Slides zmenšil objekty na snímcích tak, aby se všechny vešly (tím zabráníte ztrátě obsahu), použijte toto nastavení. 

- `Maximize`

  Pokud chcete přizpůsobit větší velikosti snímku a potřebujete, aby Aspose.Slides zvětšil objekty na snímcích, aby byly úměrné nové velikosti snímku, použijte toto nastavení. 

Tento ukázkový kód vám ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

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

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides používá interně body, kde 1 bod odpovídá 1/72 palce. Můžete převést libovolnou jednotku (např. milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti při vykreslování?**

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou k vyšší spotřebě paměti a delším časům zpracování. Snažte se o praktickou velikost snímku a upravujte měřítko vykreslování jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/php-java/merge-presentation/) pokud mají různé velikosti snímků – nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete snímky sloučit a zachovat formátování.

**Mohu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides dokáže vykreslit náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, čímž zajišťují konzistentní ohraničení a geometrii.