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
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET - automatizujte úpravy rozvržení snímků a zvyšte produktivitu."
---
## **Přehled**

Jedna z nejčastějších otázek zákazníků Aspose.Slides pro .NET je, jak změnit velikost tvarů tak, aby při změně velikosti snímku nebyla data oříznuta. Tento stručný technický článek ukazuje, jak to provést.

## **Změna velikosti tvarů**

Aby se zabránilo nesprávnému zarovnání tvarů při změně velikosti snímku, aktualizujte pozici a rozměry každého tvaru tak, aby odpovídaly novému rozložení snímku.

```c#
 // Načíst soubor prezentace.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Získat původní velikost snímku.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Změnit velikost snímku bez škálování existujících tvarů.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Získat novou velikost snímku.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Změnit velikost a pozici tvarů na každém snímku.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Škálovat velikost tvaru.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Škálovat pozici tvaru.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Pokud snímek obsahuje tabulku, výše uvedený kód nebude fungovat správně. V takovém případě je třeba změnit velikost každé buňky v tabulce.
{{% /alert %}}

Použijte následující kód k změně velikosti snímků, které obsahují tabulky. U tabulek je nastavení šířky nebo výšky zvláštním případem: musíte upravit výšku jednotlivých řádků a šířku sloupců, aby se změnila celková velikost tabulky.

```c#
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
            // Škálovat velikost tvaru.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Škálovat pozici tvaru.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Škálovat velikost tvaru.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Škálovat pozici tvaru.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Škálovat velikost tvaru.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Škálovat pozici tvaru.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?**

Při změně velikosti snímku si tvary zachovávají původní pozici a rozměry, pokud není výslovně změněno měřítko. To může vést k oříznutí obsahu nebo k nesprávnému zarovnání tvarů.

**Funguje poskytnutý kód pro všechny typy tvarů?**

Základní příklad funguje pro většinu typů tvarů (textová pole, obrázky, grafy atd.). U tabulek však musíte zacházet s řádky a sloupci samostatně, protože výška a šířka tabulky jsou určeny rozměry jednotlivých buněk.

**Jak změním velikost tabulek při změně velikosti snímku?**

Je nutné projít všechny řádky a sloupce tabulky a změnit jejich výšku a šířku úměrně, jak je ukázáno ve druhém příkladu kódu.

**Bude tato změna velikosti fungovat i pro hlavní snímky a rozložení snímků?**

Ano, ale měli byste také projít [Předlohy](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/masters/) a [RozloženíSnimek](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/layoutslides/) a použít stejnou logiku škálování na jejich tvary, aby byla zachována konzistence v celé prezentaci.

**Mohu změnit orientaci snímku (na výšku / na šířku) spolu se změnou velikosti?**

Ano. Můžete nastavit [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/cs/net/aspose.slides/islidesize/orientation/) pro změnu orientace. Ujistěte se, že logiku škálování upravíte tak, aby byl zachován původní rozvrh.

**Existuje limit velikosti, kterou mohu nastavit?**

Aspose.Slides podporuje vlastní velikosti, ale velmi velké rozměry mohou ovlivnit výkon nebo kompatibilitu s některými verzemi PowerPointu.

**Jak mohu zabránit deformaci tvarů se zamknutým poměrem stran?**

Před škálováním můžete zkontrolovat vlastnost `AspectRatioLocked` tvaru. Pokud je zamčena, upravte šířku nebo výšku úměrně místo samostatného škálování.