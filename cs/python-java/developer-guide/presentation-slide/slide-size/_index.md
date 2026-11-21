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
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí Pythonu přes Java a Aspose.Slides a optimalizovat prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standard (4:3 poměr stran)**: Ideální pro starší monitory a zařízení.
- **Širokoúhlý (16:9 poměr stran)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jednotná velikost snímku a poměr stran se vztahuje na všechny snímky. Pro optimální výsledky nastavte rozměry snímku na začátku procesu vytváření prezentace, abyste předešli komplikacím.

{{% alert color="info" title="Note" %}}
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

Stránky poznámek a podkladů mají odlišné rozměry od běžných snímků. Viz [Notes Page Size](/slides/cs/python-java/notes-size/) pro změnu jejich velikosti a orientace.

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

Pokud považujete běžné velikosti snímků (4:3 a 16:9) za nevhodné pro svou práci, můžete se rozhodnout použít konkrétní nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazit na určitých typech obrazovek, pravděpodobně vám prospěje použití vlastního nastavení velikosti pro vaši prezentaci.

Tento ukázkový kód ukazuje, jak pomocí Aspose.Slides pro Python přes Java nastavit vlastní velikost snímku pro prezentaci:

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

Po změně velikosti snímku v prezentaci může dojít k deformaci obsahu snímků (například obrázků nebo objektů). Ve výchozím nastavení se objekty automaticky přizpůsobí nové velikosti snímku. Při změně velikosti snímku však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co chcete dosáhnout, můžete použít kterékoliv z následujících nastavení:

- [DoNotScale](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  Pokud NECHCETE, aby byly objekty na snímcích přizpůsobeny, použijte toto nastavení.

- [EnsureFit](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  Pokud chcete zmenšit velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty na snímcích tak, aby se všechny vešly (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- [Maximize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  Pokud chcete zvětšit velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty na snímcích tak, aby byly proporciální nové velikosti snímku, použijte toto nastavení.

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

Ano. Aspose.Slides interně používá body, kde 1 bod je 1/72 palce. Můžete převést libovolnou jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k určení šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou ke zvýšené spotřebě paměti a delšímu času zpracování. Snažte se o praktickou velikost snímku a měřítko vykreslování upravujte jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/python-java/merge-presentation/) pokud mají různé velikosti snímků – nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesizescaletype/). Po vyrovnání velikostí můžete sloučit snímky a zachovat formátování.

**Mohu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslovat náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, čímž zajišťují konzistentní ohraničení a geometrii.