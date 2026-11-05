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
- jedinečná velikost snímku
- snímek v plné velikosti
- typ obrazovky
- neskalovat
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí Pythonu a Aspose.Slides, optimalizovat prezentace pro jakýkoli typ obrazovky bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce. 

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jediná velikost snímku a poměr stran se uplatňují na všechny snímky. Pro optimální výsledky nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="info" title="Note" %}}
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

Stránky poznámek a podkladů mají odlišné rozměry od běžných snímků. Viz [Notes Page Size](/slides/cs/python-net/notes-size/) pro změnu jejich velikosti a orientace.

## **Změna velikosti snímku v prezentaci**

Tento ukázkový kód vám ukazuje, jak změnit velikost snímku v prezentaci v Pythonu pomocí Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Určení vlastních velikostí snímků**

Pokud pro svou práci považujete běžné velikosti snímků (4:3 a 16:9) za nevhodné, můžete se rozhodnout použít specifickou nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně budete mít prospěch z nastavení vlastní velikosti pro vaši prezentaci. 

Tento ukázkový kód vám ukazuje, jak pomocí Aspose.Slides pro Python přes .NET určit vlastní velikost snímku pro prezentaci v Pythonu:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # formát papíru A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Zpracování obsahu snímků po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) deformovat. Ve výchozím nastavení se objekty automaticky přizpůsobí nové velikosti snímku. Při změně velikosti snímku však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co chcete dosáhnout, můžete použít některé z těchto nastavení:

- `DO_NOT_SCALE`

  Pokud nechcete, aby byly objekty na snímcích měněny, použijte toto nastavení.

- `ENSURE_FIT`

  Pokud chcete zmenšit na menší velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty na snímcích tak, aby se všechny vešly (tím se vyhnete ztrátě obsahu), použijte toto nastavení. 

- `MAXIMIZE`

  Pokud chcete zvětšit na větší velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení. 

Tento ukázkový kód vám ukazuje, jak použít nastavení `MAXIMIZE` při změně velikosti snímku v prezentaci:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Můžete převést libovolnou jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímků (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou ke zvýšené spotřebě paměti a delšímu času zpracování. Snažte se o praktickou velikost snímku a měřítko vykreslování nastavujte jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/python-net/merge-presentation/), pokud mají různé velikosti snímků – nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete snímky sloučit při zachování formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslit miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje konzistentní ořez a geometrii.