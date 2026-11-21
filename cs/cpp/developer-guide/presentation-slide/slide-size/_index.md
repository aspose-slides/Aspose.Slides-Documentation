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
- plnoformátový snímek
- typ obrazovky
- neškálovat
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí C++ a Aspose.Slides, optimalizovat prezentace pro jakýkoli displej bez ztráty kvality."
---
## **Introduction**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.
- **Widescreen (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci po celé prezentaci, protože jednotná velikost snímku a poměr stran se vztahuje na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku tvorby prezentace, abyste předešli komplikacím.

{{% alert color="info" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

Poznámky a stránky s podklady mají odlišné rozměry od běžných snímků. Viz [Notes Page Size](/slides/cs/cpp/notes-size/) pro změnu jejich velikosti a orientace.

## **Change the Slide Size in Presentations**

This sample code shows you how to change the slide size in a presentation in C++ using Aspose.Slides:

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

## **Specify Custom Slide Sizes in Presentations**

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete zvolit konkrétní nebo unikátní velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránek nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně získáte výhodu použitím vlastního nastavení velikosti pro vaši prezentaci.

This sample code shows you how to use Aspose.Slides for C++ to specify a custom slide size for a presentation in C++:

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

## **Handle Slide Content After Resizing**

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) zkreslit. Ve výchozím nastavení jsou objekty automaticky změněny velikostí, aby odpovídaly nové velikosti snímku. Při změně velikosti snímku však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

Podle toho, co chcete dosáhnout, můžete použít některé z následujících nastavení:

- `DoNotScale`

  Pokud NECHCETE, aby objekty na snímcích byly změněny velikostí, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete měřítko na menší velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty snímků tak, aby se všechny vešly na snímky (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- `Maximize`

  Pokud chcete měřítko na větší velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty snímků tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení.

This sample code shows you how to use the `Maximize` setting when changing the size of a presentation’s slide:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

### Can I set a custom slide size using units other than inches (for example, points or millimeters)?

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Můžete převést jakoukoli jednotku (například milimetry nebo centimetry) na body a použít převodní hodnoty k definování šířky a výšky snímku.

### Will a very large custom slide size affect performance and memory usage during rendering?

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem renderování vedou ke zvýšené spotřebě paměti a delším dobám zpracování. Usilujte o praktickou velikost snímku a upravujte měřítko renderování pouze podle potřeby, aby byl dosažen požadovaný výstupní kvalita.

### Can I define one non-standard slide size and then merge slides from presentations that have different sizes?

Nemůžete [merge presentations](/slides/cs/cpp/merge-presentation/) při různých velikostech snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete vybrat, jak bude zacházeno s existujícím obsahem, pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete sloučit snímky při zachování formátování.

### Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?

Ano. Aspose.Slides může generovat miniatury pro [entire slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/getimage/) i pro [selected shapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/). Vytvořené obrázky odrážejí aktuální velikost snímku a poměr stran, což zajišťuje konzistentní ohraničení a geometrii.