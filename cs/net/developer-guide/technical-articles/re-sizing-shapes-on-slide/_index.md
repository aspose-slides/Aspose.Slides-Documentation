---
title: Změna velikosti tvarů na snímcích prezentace v .NET
type: docs
weight: 130
url: /cs/net/resizing-shapes-on-slide/
aliases:
  - /net/zmenit-velikost-tvaru-na-snimku/
  - /cs/net/re-sizing-shapes-on-slide/
keywords:
  - změna velikosti tvaru
  - změna velikosti tvaru
  - PowerPoint
  - OpenDocument
  - prezentace
  - .NET
  - C#
  - Aspose.Slides
description: "Snadno změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET—automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku v prezentaci, možná budete muset také změnit velikost a umístění jejích tvarů, aby odpovídaly novým rozměrům. Tento článek ukazuje, jak ručně měřit tvarové měřítko a jak zacházet s tabulkami na snímcích, hlavních snímcích a rozvrženích.

## **Změna velikosti tvarů**

Pro zachování relativního umístění a velikosti každého tvaru vynásobte jeho vodorovné souřadnice a šířku poměrem nové šířky snímku k původní šíři. Použijte odpovídající poměr výšky pro jeho svislé souřadnice a výšku.

První příklad načte prezentaci, jejíž snímky neobsahují tabulky, změní velikost snímku na A4 a výsledek uloží. Používá [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) s [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/), aby následná smyčka řídila měřítko. Poměry jsou bezrozměrné; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru neškáluje velikost písma.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Vypočítejte nezávislé horizontální a vertikální škálovací faktory.
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
Tabulky vyžadují samostatné zpracování: měřítkujte jejich šířky sloupců a výšky řádků místo přiřazení celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší než požadované, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na hlavních snímcích a rozvrženích i na jednotlivých snímcích před uložením změněné velikosti prezentace. Jeho pomocník zpracovává každé [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) škálováním [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) a [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Pak škáluje pozici tabulky, aniž by samostatně měřil její celkové rozměry.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Vypočítejte nezávislé horizontální a vertikální škálovací faktory.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Změna velikosti tvarů definovaných na hlavních snímcích a rozvrženích i na jednotlivých snímcích.
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
            // Rozměry tabulky jsou řízeny šířkami sloupců a výškami řádků.
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

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?**

Pokud změníte velikost snímku bez škálování tvarů, zachovají si původní pozice a rozměry a mohou přesahovat okraj snímku. Škálování šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění ohraničení tvarů přímo a je určen pro snímky bez tabulek. Druhý příklad zpracovává tabulky samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady neškálují velikost písma a obsah tabulky může omezovat výšky řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**

Měřítkujte šířky sloupců pomocí poměru šířky a minimální výšky řádků pomocí poměru výšky, pak škálujte pozici tabulky, jak je ukázáno ve druhém příkladu.

**Bude tato změna velikosti fungovat pro hlavní snímky a rozvržení snímků?**

Ano. Druhý příklad iteruje přes [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) a [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) každého hlavního snímku a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/do šířky) spolu se změnou velikosti?**

Ano. Nastavte [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) po změně velikosti snímku a před načtením cílových rozměrů, aby faktory měřítka odrážely konečnou orientaci.

**Existuje limit velikosti snímku, který mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Podporované rozměry také závisí na formátu prezentace a aplikaci použité k otevření souboru.

**Jak mohu zabránit deformaci tvarů s pevným poměrem stran?**

Použijte stejný faktor měřítka pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší z poměrů šířky a výšky pro oba rozměry i pozice. To zachová proporce, ale může zanechat nevyužitý prostor podél jedné hrany.