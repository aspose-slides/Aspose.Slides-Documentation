---
title: Alakzatok átméretezése prezentációs diákon .NET-ben
type: docs
weight: 130
url: /hu/net/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for .NET segítségével—automatizálja a diaelrendezés beállításait és növelje a termelékenységet."
---
## **Áttekintés**

Az Aspose.Slides for .NET ügyfelei leggyakoribb kérdései közé tartozik, hogyan lehet átméretezni az alakzatokat úgy, hogy a diák méretének változása esetén az adatok ne vágódjanak le. Ez a rövid technikai cikk bemutatja, hogyan lehet ezt megoldani.

## **Alakzatok átméretezése**

Az alakzatok eltorzulásának megelőzése érdekében a diák méretének változása esetén frissíteni kell minden alakzat pozícióját és méreteit, hogy azok megfeleljenek az új diaelrendezésnek.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Töltsük be a prezentáció fájlt.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Szerezzük meg az eredeti dia méretét.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Módosítsuk a dia méretét a meglévő alakzatok méretezése nélkül.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Szerezzük meg az új dia méretét.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Alakzatok átméretezése és újrapozicionálása minden dián.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Alakzat méretének méretezése.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Alakzat pozíciójának méretezése.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Ha egy dián táblázat található, a fenti kód nem működik helyesen. Ebben az esetben a táblázat minden celláját át kell méretezni.
{{% /alert %}}

Használja a következő kódot a táblázatot tartalmazó diák átméretezéséhez. Táblázatok esetén a sortmagasságokat és oszlopszélességeket kell méretezni az alakzat szélessége és magassága helyett – mindkettő alkalmazása kétszeres méretezést eredményezne, és a táblázat a diáról kilökődne.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Szerezzük meg az eredeti dia méretét.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Módosítsuk a dia méretét a meglévő alakzatok méretezése nélkül.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Szerezzük meg az új dia méretét.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Méretezzük az alakzat méretét.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Méretezzük az alakzat pozícióját.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Méretezzük az alakzat méretét.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Méretezzük az alakzat pozícióját.
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
                // Méretezzük a táblázat méretét a sorok és oszlopok alapján.
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
                // Méretezzük az alakzat méretét.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Méretezzük az alakzat pozícióját.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

### Miért torzulnak vagy vágódnak le az alakzatok egy dia átméretezése után?

Ha egy diát átméretezünk, az alakzatok megtartják eredeti pozíciójukat és méretüket, hacsak a méretezés nem módosul kifejezetten. Ennek következtében a tartalom levágható vagy az alakzatok eltorzulhatnak.

### Működik a megadott kód minden alakzat típusra?

Az alap példa a legtöbb alakzattípusra (szövegdobozok, képek, diagramok stb.) működik. Táblázatok esetén azonban sorokat és oszlopokat külön kell kezelni, mivel a táblázat magasságát és szélességét az egyes cellák méretei határozzák meg.

### Hogyan lehet átméretezni a táblázatokat a dia átméretezésekor?

A táblázat összes sorát és oszlopát végig kell járni, és az ő magasságukat, szélességüket arányosan átméretezni, ahogy a második kódrészletben látható.

### Működik ez az átméretezés a mesterdiákon és a elrendezési diákon is?

Igen, de a [Masters](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/masters/) és a [LayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/layoutslides/) elemein is végig kell menni, és ugyanazt a méretezési logikát alkalmazni kell rájuk, hogy a teljes bemutató egységes maradjon.

### Módosíthatom a dia orientációját (álló/általános) az átméretezés közben?

Igen. A [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/hu/net/aspose.slides/islidesize/orientation/) beállításával változtatható az orientáció. Ügyeljünk arra, hogy a méretezési logikát ennek megfelelően állítsuk be a layout megőrzése érdekében.

### Van korlátozás a beállítható dia méretre?

Az Aspose.Slides egyedi méreteket támogat, de nagyon nagy méretek befolyásolhatják a teljesítményt vagy a kompatibilitást bizonyos PowerPoint verziókkal.

### Hogyan lehet megakadályozni, hogy a rögzített képarányú alakzatok torzuljanak?

A skálázás előtt ellenőrizheted az alakzat `AspectRatioLocked` tulajdonságát. Ha zárolt, akkor a szélességet vagy magasságot arányosan módosítsd, ahelyett, hogy külön-külön méreteznéd őket.