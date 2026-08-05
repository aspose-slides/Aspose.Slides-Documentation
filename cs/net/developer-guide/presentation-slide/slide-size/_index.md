---
title: Změna velikosti snímku v prezentaci v .NET
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
- plnoformátový snímek
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
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí .NET a Aspose.Slides, optimalizovat prezentace pro jakýkoli typ obrazovky bez ztráty kvality."
---
## **Úvod**

Aspose.Slides for .NET poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší monitory a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučený pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a jeden poměr stran se použijí pro všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste předešli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Jak změnit velikost snímku v prezentaci**

Tento příklad ukazuje, jak změnit velikost snímku v prezentaci pomocí Aspose.Slides v C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Určení vlastních velikostí snímků**

Přizpůsobení velikosti snímku vašim konkrétním potřebám, například pro jedinečné rozložení papíru nebo specifikace obrazovky, může být užitečné. Zde je návod, jak nastavit vlastní velikost snímku pomocí Aspose.Slides for .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Formát papíru A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Manipulace s obsahem snímku po změně velikosti**

Po změně velikosti se může obsah snímku deformovat. Můžete řídit, jak Aspose.Slides tuto změnu zpracuje:

- **`DoNotScale`**: Zachová objekty v původní velikosti, aby nedošlo k měřítkování.
- **`EnsureFit`**: Zmenší objekty tak, aby se vešly do menších snímků, čímž se zabrání ztrátě obsahu.
- **`Maximize`**: Zvětší objekty tak, aby odpovídaly větším snímkům a zachovaly estetickou konzistenci.

Příklad použití nastavení `Maximize` pro úpravu velikosti snímku:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Můžete převést jakoukoli jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během renderování?**

Ano. Větší rozměry snímku (v bodech) ve spojení s vyšším měřítkem renderování zvyšují spotřebu paměti a prodlužují dobu zpracování. Zaměřte se na praktickou velikost snímku a upravujte měřítko renderování jen podle potřeby, aby byl dosažen požadovaný výstupní kvalita.

**Mohu definovat jednu nestandardní velikost snímku a pak sloučit snímky z prezentací, které mají různé velikosti?**

Nelze [sloučit prezentace](/slides/cs/net/merge-presentation/), pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem, pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesizescaletype/). Po vyrovnání velikostí můžete sloučit snímky a zachovat formátování.

**Mohu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides dokáže vytvořit náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/getimage/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getimage/). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, což zajišťuje konzistentní ohraničení a geometrii.