---
title: Změna velikosti snímku prezentace v C++
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/cpp/slide-size/
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
- C++
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí C++ a Aspose.Slides, optimalizovat prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce.

Populární velikosti snímků a poměry:

- **Standard (4:3 Aspect Ratio)**: Ideální pro starší obrazovky a zařízení.
- **Widescreen (16:9 Aspect Ratio)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jednotná velikost snímku a poměr stran se vztahují na všechny snímky. Pro optimální výsledky nastavte rozměry snímku na začátku tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="info" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód ukazuje, jak změnit velikost snímku v prezentaci v C++ pomocí Aspose.Slides:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Určení vlastních velikostí snímků v prezentacích**

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete se rozhodnout použít konkrétní nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně vám prospěje nastavení vlastní velikosti pro vaši prezentaci.

Tento ukázkový kód ukazuje, jak pomocí Aspose.Slides pro C++ zadat vlastní velikost snímku pro prezentaci v C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Velikost papíru A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Manipulace s obsahem snímků po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (obrázky nebo objekty, například) deformovat. Standardně se objekty automaticky přizpůsobí nové velikosti snímku. Přesto při změně velikosti snímku můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

Podle toho, co chcete dosáhnout, můžete použít některé z následujících nastavení:

- `DoNotScale`

  Pokud nechcete, aby se objekty na snímcích přizpůsobovaly, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete přizpůsobit menší velikosti snímku a potřebujete, aby Aspose.Slides zmenšil objekty snímků tak, aby se všechny vešly (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- `Maximize`

  Pokud chcete přizpůsobit větší velikosti snímku a potřebujete, aby Aspose.Slides zvětšil objekty snímků tak, aby byly proporcionální nové velikosti snímku, použijte toto nastavení.

Tento ukázkový kód ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Často kladené otázky**

### Můžu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Můžete převést libovolnou jednotku (například milimetry nebo centimetry) na body a použít tyto převedené hodnoty k definování šířky a výšky snímku.

### Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během renderování?

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem renderování vedou k vyšší spotřebě paměti a delším dobám zpracování. Dbejte na praktickou velikost snímku a měřítko renderování upravujte jen podle potřeby k dosažení požadované kvality výstupu.

### Můžu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?

Nemůžete [sloučit prezentace](/slides/cs/cpp/merge-presentation/) , pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak bude zacházeno s existujícím obsahem, pomocí volby [SlideSizeScaleType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesizescaletype/). Po sladění velikostí můžete sloučit snímky a zachovat formátování.

### Můžu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?

Ano. Aspose.Slides dokáže vytvořit miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/getimage/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, čímž zajišťují konzistentní ohraničení a geometrie.