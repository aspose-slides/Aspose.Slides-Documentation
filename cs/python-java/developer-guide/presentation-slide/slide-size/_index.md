---
title: Změna velikosti snímku prezentace v Pythonu přes Java
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/python-java/slide-size/
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
- zajistit vložení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak rychle změnit velikost snímků v souborech PPT, PPTX a ODP pomocí Pythonu přes Java a Aspose.Slides a optimalizovat prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší monitory a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jediná velikost snímku a poměr stran se vztahují na všechny snímky. Pro optimální výsledky nastavte rozměry snímku na začátku tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="info" title="Poznámka" %}}
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód ukazuje, jak změnit velikost snímku v prezentaci v Pythonu přes Java pomocí Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Určení vlastních velikostí snímků v prezentacích**

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete se rozhodnout použít specifickou nebo unikátní velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazit na určitých typech obrazovek, pravděpodobně budete těžit z nastavení vlastní velikosti pro vaši prezentaci.

Tento ukázkový kód ukazuje, jak pomocí Aspose.Slides pro Python přes Java specifikovat vlastní velikost snímku pro prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zpracování obsahu snímku po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (obrázky nebo objekty) zkreslit. Ve výchozím nastavení jsou objekty automaticky přizpůsobeny nové velikosti snímku. Při změně velikosti snímku prezentace však můžete zadat nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

Podle toho, co chcete dosáhnout, můžete použít kterékoliv z těchto nastavení:

- [DoNotScale](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Pokud nechcete, aby byly objekty na snímcích změněny, použijte toto nastavení.

- [EnsureFit](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Pokud chcete zmenšit na menší velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty snímků tak, aby se všechny vešly (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- [Maximize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Pokud chcete zvětšit na větší velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty snímků tak, aby byly úměrné nové velikosti, použijte toto nastavení.

Tento ukázkový kód ukazuje, jak použít nastavení [Maximize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesizescaletype/#Maximize) při změně velikosti snímku v prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Jakoukoli jednotku (například milimetry nebo centimetry) můžete převést na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během renderování?**

Ano. Větší rozměry snímků (v bodech) v kombinaci s vyšším měřítkem renderování vedou ke zvýšené spotřebě paměti a delším dobám zpracování. Cílem by měla být praktická velikost snímku a měřítko renderování upravovat jen podle potřeby pro dosažení požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací s různými velikostmi?**

Nemůžete [merge presentations](/slides/cs/python-java/merge-presentation/) když mají různé velikosti snímků — nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesizescaletype/). Po vyrovnání velikostí můžete sloučit snímky při zachování formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může renderovat miniatury pro [entire slides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) i pro [selected shapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje konzistentní ohraničení a geometrii.