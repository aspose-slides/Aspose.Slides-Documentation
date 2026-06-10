---
title: Alakzatok átméretezése a prezentáció diákon .NET-ben
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
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for .NET segítségével – automatizálja a diaterv módosítását és növelje a termelékenységet."
---
## **Áttekintés**

Az Aspose.Slides for .NET ügyfelei egyik leggyakoribb kérdése, hogy hogyan lehet átméretezni az alakzatokat úgy, hogy a diaméret változásakor az adatok ne vágódjanak le. Ez a rövid technikai cikk bemutatja, hogyan lehet ezt megvalósítani.

## **Alakzatok átméretezése**

Az alakzatok eltolódásának megakadályozása érdekében, amikor a diaméret változik, frissíteni kell minden alakzat pozícióját és méreteit, hogy azok megfeleljenek az új diakiosztásnak.

```c#
 // Töltsd be a prezentációfájlt.
 using (Presentation presentation = new Presentation("sample.pptx"))
 {
     // Szerezd meg az eredeti dia méretét.
     float currentHeight = presentation.SlideSize.Size.Height;
     float currentWidth = presentation.SlideSize.Size.Width;

     // Módosítsd a dia méretét a meglévő alakzatok méretezése nélkül.
     presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

     // Szerezd meg az új dia méretét.
     float newHeight = presentation.SlideSize.Size.Height;
     float newWidth = presentation.SlideSize.Size.Width;

     float heightRatio = newHeight / currentHeight;
     float widthRatio = newWidth / currentWidth;

     // Átméretezd és áthelyezd az alakzatokat minden dián.
     foreach (ISlide slide in presentation.Slides)
     {
         foreach (IShape shape in slide.Shapes)
         {
             // Méretezd az alakzat méretét.
             shape.Height *= heightRatio;
             shape.Width *= widthRatio;

             // Méretezd az alakzat helyzetét.
             shape.Y *= heightRatio;
             shape.X *= widthRatio;
         }
     }

     presentation.Save("output.pptx", SaveFormat.Pptx);
 }
```

{{% alert color="primary" %}}
Ha egy dián táblázat van, a fenti kód nem fog megfelelően működni. Ebben az esetben a táblázat minden celláját át kell méretezni.
{{% /alert %}}

Használja a következő kódot a saját oldalán, hogy átméretezze a táblázatot tartalmazó diákot. Táblázatok esetén a szélesség vagy magasság beállítása különleges eset: egyes sorok magasságát és oszlopok szélességét kell módosítani a táblázat teljes méretének megváltoztatásához.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Szerezd meg az eredeti dia méretét.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Módosítsd a dia méretét a meglévő alakzatok átméretezése nélkül.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Szerezd meg az új dia méretét.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Méretezd az alakzat méretét.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Méretezd az alakzat helyzetét.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Méretezd az alakzat méretét.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Méretezd az alakzat helyzetét.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Méretezd az alakzat méretét.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Méretezd az alakzat helyzetét.
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

## **GYIK**

**Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?**

A dia átméretezésekor az alakzatok megtartják eredeti pozíciójukat és méretüket, hacsak a méretezés nincs kifejezetten módosítva. Ez a tartalom levágásához vagy az alakzatok eltolódásához vezethet.

**A megadott kód minden alakzat típusra működik?**

Az alap példa a legtöbb alakzat típusra (szövegdobozok, képek, diagramok stb.) működik. Azonban táblázatok esetén külön kell kezelni a sorokat és oszlopokat, mivel a táblázat magassága és szélessége az egyes cellák dimenzióiból származik.

**Hogyan lehet átméretezni a táblázatokat a dia átméretezésekor?**

Az összes soron és oszlopon végig kell iterálni, és arányosan át kell méretezni a magasságukat és szélességüket, ahogy a második kódrészletben látható.

**Ez az átméretezés működik mesterdiák és elrendezési diák esetén is?**

Igen, de a [Mesterek](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/masters/) és a [ElrendezésiDiák](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/layoutslides/) esetén is végig kell iterálni, és ugyanazt a méretezési logikát alkalmazni kell az alakzataikra, hogy a teljes bemutató egységes legyen.

**Megváltoztathatom a dia orientációját (álló/fekvő) az átméretezéssel együtt?**

Igen. A [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/hu/net/aspose.slides/islidesize/orientation/) beállításával módosíthatja az orientációt. Ügyeljen arra, hogy a méretezési logikát ennek megfelelően állítsa be a elrendezés megőrzéséhez.

**Van korlátozás a beállítható diaméretre?**

Az Aspose.Slides egyedi méreteket támogat, de a nagyon nagy méretek befolyásolhatják a teljesítményt vagy a PowerPoint egyes verzióival való kompatibilitást.

**Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?**

Az átméretezés előtt ellenőrizze az alakzat `AspectRatioLocked` tulajdonságát. Ha zárolt, akkor a szélességet vagy magasságot arányosan kell módosítani, ahelyett, hogy egyenként skálázná őket.