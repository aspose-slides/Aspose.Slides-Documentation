---
title: Změna velikosti snímku prezentace v C++
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/cpp/slide-size/
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
- C++
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí C++ a Aspose.Slides, optimalizujte prezentace pro jakýkoli displej bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce. 

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se vztahuje na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód ukazuje, jak změnit velikost snímku v prezentaci v C++ pomocí Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Určení vlastních velikostí snímků v prezentacích**

Pokud považujete běžné velikosti snímků (4:3 a 16:9) za nevhodné pro svou práci, můžete se rozhodnout použít specifickou nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozložení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně vám prospěje nastavení vlastní velikosti pro vaši prezentaci. 

Tento ukázkový kód ukazuje, jak pomocí Aspose.Slides pro C++ nastavit vlastní velikost snímku pro prezentaci v C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Velikost papíru A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Zpracování obsahu snímku po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) zkreslit. Ve výchozím nastavení jsou objekty automaticky přizpůsobeny tak, aby odpovídaly nové velikosti snímku. Při změně velikosti snímku však můžete zadat nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co chcete udělat nebo dosáhnout, můžete použít kterékoliv z následujících nastavení:

- `DoNotScale`

  Pokud nechcete, aby objekty na snímcích byly změněny, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete přizpůsobit menší velikosti snímku a potřebujete, aby Aspose.Slides zmenšil objekty na snímcích tak, aby se všechny vešly (tím se vyhnete ztrátě obsahu), použijte toto nastavení. 

- `Maximize`

  Pokud chcete přizpůsobit větší velikosti snímku a potřebujete, aby Aspose.Slides zvětšil objekty na snímcích tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení. 

Tento ukázkový kód ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod = 1/72 palce. Můžete převést jakoukoli jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k určení šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) spojené s vyšším měřítkem vykreslování vedou ke zvýšené spotřebě paměti a delším časům zpracování. Snažte se o praktickou velikost snímku a upravujte měřítko vykreslování jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nelze [sloučit prezentace](/slides/cs/cpp/merge-presentation/) pokud mají různé velikosti snímků – nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak bude zacházeno s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete sloučit snímky při zachování formátování.

**Mohu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslovat náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/getimage/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje konzistentní ohraničení a geometrii.