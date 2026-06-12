---
title: Změna velikosti snímku v prezentaci v C++
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
- nastavení velikosti snímku
- změna velikosti snímku
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
descriptions: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí C++ a Aspose.Slides, optimalizujte prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce.  

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.  
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.  

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se použijí na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentacích**

 Tento ukázkový kód vám ukazuje, jak změnit velikost snímku v prezentaci v jazyce C++ pomocí Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Určení vlastní velikosti snímků v prezentacích**

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete se rozhodnout použít specifickou nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazit na určitých typech obrazovek, pravděpodobně získáte výhodu z nastavení vlastní velikosti pro vaši prezentaci.  

Tento ukázkový kód vám ukazuje, jak pomocí Aspose.Slides pro C++ specifikovat vlastní velikost snímku pro prezentaci v jazyce C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Velikost papíru A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Zpracování obsahu snímků po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) deformovat. Ve výchozím nastavení jsou objekty automaticky přizpůsobeny tak, aby odpovídaly nové velikosti snímku. Při změně velikosti snímku však můžete zadat nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.  

Podle toho, co chcete dosáhnout, můžete použít některé z těchto nastavení:

- `DoNotScale`

  Pokud **NE** chcete, aby byly objekty na snímcích přizpůsobovány, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete měnit velikost na menší snímek a potřebujete, aby Aspose.Slides zmenšilo objekty na snímcích tak, aby se všechny vešly (tím se vyhnete ztrátě obsahu), použijte toto nastavení. 

- `Maximize`

  Pokud chcete měnit velikost na větší snímek a potřebujete, aby Aspose.Slides zvětšilo objekty na snímcích tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení. 

Tento ukázkový kód vám ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Můžete převést jakoukoli jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.  

**Může velmi velká vlastní velikost snímku ovlivnit výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou ke zvýšené spotřebě paměti a delším časům zpracování. Snažte se zvolit praktickou velikost snímku a měřítko vykreslování upravujte jen podle potřeby, aby byl dosažen požadovaný výstupní kvalita.  

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/cpp/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem, pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesizescaletype/). Po vyrovnání velikostí můžete sloučit snímky při zachování formátování.  

**Mohu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslovat náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/getimage/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, což zajišťuje konzistentní ohraničení a geometrie.