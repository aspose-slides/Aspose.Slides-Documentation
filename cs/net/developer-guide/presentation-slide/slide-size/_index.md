---
title: Změna velikosti snímku prezentace v .NET
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/net/slide-size/
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
- neškálovat
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí .NET a Aspose.Slides, optimalizovat prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides pro .NET poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce.

Populární velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.
- **Widescreen (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se vztahují na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="info" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Jak změnit velikost snímku v prezentaci**

Tento příklad ukazuje, jak změnit velikost snímku v prezentaci pomocí Aspose.Slides v C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Určení vlastních velikostí snímků**

Přizpůsobení velikosti snímku vašim konkrétním potřebám, například pro unikátní rozvržení papíru nebo specifikace obrazovky, může být užitečné. Zde je návod, jak nastavit vlastní velikost snímku pomocí Aspose.Slides pro .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Velikost papíru A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Zpracování obsahu snímku po změně velikosti**

Po změně velikosti se může obsah snímku deformovat. Můžete řídit, jak Aspose.Slides tuto změnu velikosti zvládá:

- **`DoNotScale`**: Ponechat objekty v původních rozměrech, aby se zabránilo škálování.
- **`EnsureFit`**: Zmenšit objekty tak, aby se vešly na menší snímky, čímž se zabrání ztrátě obsahu.
- **`Maximize`**: Zvětšit objekty tak, aby odpovídaly větším snímkům pro estetickou jednotnost.

Příklad použití nastavení `Maximize` pro úpravu velikosti snímku:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Často kladené otázky**

### Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?

Ano. Aspose.Slides interně používá body, kde 1 bod = 1/72 palce. Můžete převést libovolnou jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.

### Ovlivní velmi velká vlastní velikost snímku výkon a využití paměti během renderování?

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem renderování vedou ke zvýšené spotřebě paměti a delším dobám zpracování. Snažte se o praktickou velikost snímku a upravujte měřítko renderování jen podle potřeby, aby byla dosažena požadovaná kvalita výstupu.

### Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?

Nemůžete [sloučit prezentace](/slides/cs/net/merge-presentation/), pokud mají různé velikosti snímků – nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem, pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesizescaletype/). Po sladění velikostí můžete snímky sloučit a zachovat formátování.

### Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?

Ano. Aspose.Slides může vykreslit miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/getimage/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getimage/). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, což zajišťuje konzistentní ohraničení a geometrie.