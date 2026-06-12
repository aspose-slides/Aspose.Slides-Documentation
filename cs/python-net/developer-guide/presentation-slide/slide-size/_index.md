---
title: Změna velikosti snímku v prezentacích pomocí Pythonu
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/python-net/slide-size/
keywords:
- velikost snímku
- poměr stran
- standard
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
- neškálovat
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
descriptions: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí jazyka Python a Aspose.Slides, optimalizujte prezentace pro jakoukoliv obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce.  

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší monitory a zařízení.  
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.  

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se uplatňuje na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentaci**

Tento ukázkový kód vám ukazuje, jak změnit velikost snímku v prezentaci v Pythonu pomocí Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Určení vlastních velikostí snímků**

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete se rozhodnout použít konkrétní nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozložení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně získáte výhodu použitím vlastního nastavení velikosti pro vaši prezentaci.  

Tento ukázkový kód vám ukazuje, jak pomocí Aspose.Slides pro Python přes .NET specifikovat vlastní velikost snímku pro prezentaci v Pythonu:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # velikost papíru A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Zpracování obsahu snímků po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) zkreslit. Ve výchozím nastavení jsou objekty automaticky změněny tak, aby se vejily do nové velikosti snímku. Při změně velikosti snímku však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.  

V závislosti na tom, co chcete dosáhnout, můžete použít kterékoliv z těchto nastavení:

- `DO_NOT_SCALE`  
  Pokud NECHCETE, aby byly objekty na snímcích změněny, použijte toto nastavení.

- `ENSURE_FIT`  
  Pokud chcete měřítko na menší velikost snímku a potřebujete, aby Aspose.Slides zmenšilo objekty snímků tak, aby se všechny vešly na snímky (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- `MAXIMIZE`  
  Pokud chcete měřítko na větší velikost snímku a potřebujete, aby Aspose.Slides zvětšilo objekty snímků tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení.

Tento ukázkový kód vám ukazuje, jak použít nastavení `MAXIMIZE` při změně velikosti snímku v prezentaci:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Můžete převést libovolnou jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) spolu s vyšším měřítkem vykreslování způsobují vyšší spotřebu paměti a delší dobu zpracování. Snažte se o praktickou velikost snímku a měřítko vykreslování upravujte jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/python-net/merge-presentation/), pokud mají různé velikosti snímků – nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se bude zacházet s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete sloučit snímky při zachování formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslovat miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, což zajišťuje konzistentní ohraničení a geometrii.