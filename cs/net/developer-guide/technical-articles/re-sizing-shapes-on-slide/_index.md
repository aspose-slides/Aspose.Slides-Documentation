---
title: Změna velikosti tvarů na snímcích prezentace v .NET
type: docs
weight: 130
url: /cs/net/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- úprava velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET—automatizujte úpravy rozvržení snímků a zvyšte produktivitu."
---
## **Přehled**

Jedna z nejčastějších otázek zákazníků Aspose.Slides pro .NET je, jak změnit velikost tvarů tak, aby při změně velikosti snímku nedocházelo k oříznutí dat. Tento krátký technický článek ukazuje, jak to provést.

## **Změna velikosti tvarů**

Aby se zabránilo nesprávnému zarovnání tvarů při změně velikosti snímku, aktualizujte pozici a rozměry každého tvaru tak, aby odpovídaly novému rozložení snímku.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Načtěte soubor prezentace.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Získat původní velikost snímku.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Změňte velikost snímku bez škálování existujících tvarů.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Získat novou velikost snímku.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Změňte velikost a přemístěte tvary na každém snímku.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Změňte velikost tvaru.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Změňte pozici tvaru.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Pokud snímek obsahuje tabulku, výše uvedený kód nebude fungovat správně. V takovém případě je třeba změnit velikost každé buňky v tabulce.
{{% /alert %}}

Použijte následující kód na své straně k změně velikosti snímků, které obsahují tabulky. U tabulek škálujte výšky jednotlivých řádků a šířky sloupců místo šířky a výšky celého tvaru – aplikace obojího by tabulku zvětšila dvakrát a posunula ji mimo snímek.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Získat původní velikost snímku.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Změnit velikost snímku bez škálování existujících tvarů.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Získat novou velikost snímku.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Změnit velikost tvaru.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Změnit pozici tvaru.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Změnit velikost tvaru.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Změnit pozici tvaru.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // Změnit velikost tabulky prostřednictvím jejích řádků a sloupců.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // Změnit velikost tvaru.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Změnit pozici tvaru.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

### Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?

Při změně velikosti snímku tvary zachovávají svou původní pozici a velikost, pokud není explicitně změněno měřítko. To může vést k oříznutí obsahu nebo k nesprávnému zarovnání tvarů.

### Funguje poskytnutý kód pro všechny typy tvarů?

Základní příklad funguje pro většinu typů tvarů (textová pole, obrázky, grafy atd.). U tabulek však musíte zpracovávat řádky a sloupce samostatně, protože výška a šířka tabulky jsou určeny rozměry jednotlivých buněk.

### Jak změnit velikost tabulek při změně velikosti snímku?

Musíte projít všechny řádky a sloupce tabulky a změnit jejich výšku a šířku úměrně, jak je ukázáno ve druhém příkladu kódu.

### Bude tato změna velikosti fungovat i pro hlavní snímky a rozložení snímků?

Ano, ale měli byste také projít [Masters](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/masters/) a [LayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/layoutslides/) a použít stejnou logiku škálování na jejich tvary, aby byla zajištěna konzistence v celé prezentaci.

### Mohu změnit orientaci snímku (na výšku/do šířky) spolu se změnou velikosti?

Ano. Můžete nastavit [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/cs/net/aspose.slides/islidesize/orientation/) pro změnu orientace. Ujistěte se, že logiku škálování nastavíte odpovídajícím způsobem, aby rozvržení zůstalo zachováno.

### Existuje limit velikosti snímku, kterou mohu nastavit?

Aspose.Slides podporuje vlastní velikosti, ale velmi velké rozměry mohou ovlivnit výkon nebo kompatibilitu s některými verzemi PowerPointu.

### Jak mohu zabránit deformaci tvarů se zamknutým poměrem stran?

Můžete před škálováním zkontrolovat vlastnost `AspectRatioLocked` tvaru. Pokud je zamčená, upravte šířku nebo výšku úměrně místo samostatného škálování.