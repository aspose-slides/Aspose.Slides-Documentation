---
title: Změna velikosti snímku v prezentacích pomocí Pythonu
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/python-net/slide-size/
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
- Python
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí Pythonu a Aspose.Slides, optimalizovat prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jediná velikost snímku a poměr stran platí pro všechny snímky. Pro optimální výsledky nastavte rozměry snímku na začátku tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentaci**

Tento ukázkový kód vám ukáže, jak změnit velikost snímku v prezentaci v Pythonu pomocí Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Určení vlastních velikostí snímků**

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete zvolit konkrétní nebo unikátní velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, můžete těžit z nastavení vlastní velikosti pro vaši prezentaci.

Tento ukázkový kód vám ukáže, jak pomocí Aspose.Slides for Python via .NET nastavit vlastní velikost snímku pro prezentaci v Pythonu:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # velikost papíru A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Zpracování obsahu snímku po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (obrázky nebo objekty) zkreslit. Ve výchozím nastavení se objekty automaticky přizpůsobí nové velikosti snímku. Při změně velikosti snímku však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

Podle toho, co chcete dosáhnout, můžete použít některé z těchto nastavení:

- `DO_NOT_SCALE`

  Pokud nechcete, aby se objekty na snímcích měnily velikostí, použijte toto nastavení.

- `ENSURE_FIT`

  Pokud chcete zmenšit snímek a potřebujete, aby Aspose.Slides zmenšil objekty tak, aby se všechno vešlo na snímek (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- `MAXIMIZE`

  Pokud chcete zvětšit snímek a potřebujete, aby Aspose.Slides zvětšil objekty tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení.

Tento ukázkový kód vám ukáže, jak použít nastavení `MAXIMIZE` při změně velikosti snímku v prezentaci:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Můžete převést libovolnou jednotku (např. milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou ke zvýšené spotřebě paměti a delším dobám zpracování. Zaměřte se na praktickou velikost snímku a upravujte měřítko vykreslování jen podle potřeby pro dosažení požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/python-net/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem, pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesizescaletype/). Po vyrovnání velikostí můžete snímky sloučit a zachovat formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides dokáže vykreslit miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, což zajišťuje konzistentní zarámování a geometrii.