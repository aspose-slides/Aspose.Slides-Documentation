---
title: Změna velikosti snímku prezentace v .NET
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/net/slide-size/
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
- unikátní velikost snímku
- celoplošný snímek
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
description: "Zjistěte, jak rychle změnit velikost snímků v souborech PPT, PPTX a ODP pomocí .NET a Aspose.Slides, optimalizujte prezentace pro jakýkoli displej bez ztráty kvality."
---
## **Úvod**

Aspose.Slides for .NET poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je zásadní jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší monitory a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jednotná velikost snímku a poměr stran se vztahují na všechny snímky. Pro optimální výsledky nastavte rozměry snímků na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="info" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

Stránky s poznámkami a letáky mají odlišné rozměry než běžné snímky. Viz [Velikost stránky poznámek](/slides/cs/net/notes-size/) pro změnu jejich velikosti a orientace.

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

## **Zadejte vlastní velikosti snímků**

Přizpůsobení velikosti snímku vašim specifickým potřebám, například pro unikátní rozložení papíru nebo specifikace obrazovky, může být užitečné. Zde je návod, jak nastavit vlastní velikost snímku pomocí Aspose.Slides for .NET:

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

Po změně velikosti se může obsah snímku zdeformovat. Můžete řídit, jak Aspose.Slides tuto změnu zpracuje:

- **`DoNotScale`**: Zachovat objekty v původní velikosti a zabránit jejich škálování.
- **`EnsureFit`**: Škálovat objekty tak, aby se vešly do menších snímků, čímž se zabrání ztrátě obsahu.
- **`Maximize`**: Zvětšit objekty tak, aby odpovídaly větším snímkům a zachovaly estetickou konzistenci.

Příklad použití nastavení `Maximize` pro úpravu velikosti snímku:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Často kladené otázky**

### Můžu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?

Ano. Aspose.Slides interně používá body, kde jeden bod odpovídá 1/72 palce. Jakoukoliv jednotku (např. milimetry nebo centimetry) můžete převést na body a použít převedené hodnoty k definování šířky a výšky snímku.

### Ovplyvní velmi velká vlastní velikost snímku výkon a využití paměti během renderování?

Ano. Větší rozměry snímků (v bodech) spojené s vyšší škálou renderování vedou k vyšší spotřebě paměti a delším časům zpracování. Snažte se zvolit praktickou velikost snímku a upravovat škálu renderování jen podle potřeby, aby byl dosažen požadovaný výstupní kvalita.

### Můžu definovat jednu nestandardní velikost snímku a pak sloučit snímky z prezentací, které mají různé velikosti?

Nemůžete [sloučit prezentace](/slides/cs/net/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete sloučit snímky a zachovat formátování.

### Můžu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?

Ano. Aspose.Slides dokáže vytvořit náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/getimage/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getimage/). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje konzistentní rámování a geometrii.