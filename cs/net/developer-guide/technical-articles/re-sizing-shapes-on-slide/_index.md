---
title: Změna velikosti tvarů na snímcích prezentace v .NET
type: docs
weight: 130
url: /cs/net/resizing-shapes-on-slide/
aliases:
  - /cs/net/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- úprava velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET — automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku v prezentaci, možná budete také muset změnit velikost a umístění jeho tvarů, aby se vešly do nových rozměrů. Tento článek ukazuje, jak ručně měřit tvary a jak zacházet s tabulkami na snímcích, základních snímcích a rozvrženích.

## **Změna velikosti tvarů**

Pro zachování relativní polohy a velikosti každého tvaru vynásobte jeho horizontální souřadnice a šířku poměrem nové šířky snímku k původní šířce. Použijte odpovídající poměr výšky na jeho vertikální souřadnice a výšku.

První příklad načte prezentaci, jejíž snímky neobsahují tabulky, změní velikost snímku na formát A4 a výsledek uloží. Používá [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) s [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/), aby následná smyčka řídila měřítko. Poměry jsou bezrozměrné; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru neskaluje velikost jeho písma.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Vypočítejte nezávislé horizontální a vertikální koeficienty měřítka.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Tabulky vyžadují samostatné zacházení: je třeba měřit šířky jejich sloupců a výšky řádků místo přiřazení celkové šířky a výšky tabulky. Výšky řádků mohou zůstávat větší, než je požadováno, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na základních snímcích a rozvrženích i na jednotlivých snímcích před uložením změněné prezentace. Jeho pomocná třída zpracovává každý [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) měřením [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) a [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Poté měří pozici tabulky, aniž by samostatně měřila její celkové rozměry.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Vypočítejte nezávislé horizontální a vertikální koeficienty měřítka.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Změňte velikost tvarů definovaných na hlavních snímcích a rozvrženích i na jednotlivých snímcích.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            //            Rozměry tabulky jsou řízeny šířkami sloupců a výškami řádků.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **Často kladené dotazy**

**Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?**  
Pokud změníte velikost snímku bez škálování tvarů, zachovají své původní polohy a rozměry a mohou přesahovat okraj snímku. Škálování šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**  
První příklad mění ohraničení tvaru přímo a je určen pro snímky bez tabulek. Druhý příklad zachází s tabulkami samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady neskalují velikost písma a obsah tabulky může omezovat výšky řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**  
Měřte šířky sloupců podle poměru šířky a minimální výšky řádků podle poměru výšky, poté změňte měřítko pozice tabulky, jak je ukázáno ve druhém příkladu.

**Bude tato změna velikosti fungovat pro hlavní snímky a rozvržení snímků?**  
Ano. Druhý příklad prochází [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) a každým [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) hlavního snímku a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/do šířky) spolu se změnou velikosti?**  
Ano. Nastavte [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) po změně velikosti snímku a před načtením cílových rozměrů, aby faktory měřítka odrážely konečnou orientaci.

**Existuje limit velikosti snímku, kterou mohu nastavit?**  
Můžete zadat vlastní rozměry snímku pomocí [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Podporované rozměry také závisí na formátu prezentace a aplikaci použité k otevření souboru.

**Jak mohu zabránit deformaci tvarů s pevným poměrem stran?**  
Použijte stejný faktor měřítka pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší ze šířkových a výškových poměrů pro obě rozměry i pozice. Tím se zachová poměr, ale může zůstat nevyužitý prostor podél jedné hrany.