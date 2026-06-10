---
title: "Diaformák bélyegképeinek létrehozása .NET környezetben"
linktitle: "Forma bélyegképek"
type: docs
weight: 70
url: /hu/net/create-shape-thumbnails/
keywords:
- "forma bélyegkép"
- "forma kép"
- "forma renderelése"
- "forma renderelés"
- "PowerPoint"
- "prezentáció"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Készítsen magas minőségű forma bélyegképeket PowerPoint diákról az Aspose.Slides for .NET segítségével – egyszerűen hozhat létre és exportálhat prezentációs bélyegképeket."
---
## **Bevezetés**

Az Aspose.Slides for .NET-et prezentációs fájlok létrehozására használják, ahol minden oldal egy diának felel meg. Ezeket a diákat a Microsoft PowerPoint segítségével nyitható meg. Néha azonban a fejlesztőknek külön képpel szeretnék megtekinteni a formák képeit egy képmegjelenítőben. Ilyen esetekben az Aspose.Slides for .NET segít a diaformák bélyegképeinek generálásában. A funkció használatát ebben a cikkben ismertetjük.  
Ez a cikk bemutatja, hogyan lehet különböző módokon előállítani a dia bélyegképeket:

- Forma bélyegkép generálása egy dián belül.
- Forma bélyegkép generálása egy diaformához felhasználó által meghatározott méretekkel.
- Forma bélyegkép generálása a forma megjelenésének határain belül.

## **Forma bélyegkép generálása diáról**
Az Aspose.Slides for .NET használatával bármely diáról forma bélyegképet generálhat:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezze be bármely dia referenciáját azonosító vagy index alapján.
1. Kérje le a referencia diához tartozó forma bélyegképét alapértelmezett méretezésben.
1. Mentse el a bélyegképet a kívánt képformátumba.

Az alábbi példa forma bélyegképet generál.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Felhasználó által definiált skálázási tényező bélyegkép generálása**
Az Aspose.Slides for .NET használatával bármely diára vonatkozó forma bélyegkép generálásához:

1. Hozzon létre egy példányt a `Presentation` osztályból.
1. Szerezze be bármely dia referenciáját azonosító vagy index alapján.
1. Kérje le a referencia dia bélyegképét a forma határainak figyelembevételével.
1. Mentse el a bélyegképet a kívánt képformátumba.

Az alábbi példa bélyegképet generál felhasználó által meghatározott skálázási tényezővel.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Skálázás az X és Y tengelyek mentén.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Határolás-alapú forma megjelenésű bélyegkép létrehozása**
Ez a módszer a formák bélyegképeinek létrehozására lehetővé teszi, hogy a fejlesztők a forma megjelenésének határai között generáljanak bélyegképet. Figyelembe veszi a forma összes effektjét. A generált forma bélyegkép a dia határai által korlátozott. Bármely diaforma megjelenésének határain belüli bélyegképhez használja az alábbi mintakódot:

1. Hozzon létre egy példányt a `Presentation` osztályból.
1. Szerezze be bármely dia referenciáját azonosító vagy index alapján.
1. Kérje le a referencia dia bélyegképét a forma határai megjelenésként.
1. Mentse el a bélyegképet a kívánt képformátumba.

Az alábbi példa egy bélyegképet hoz létre felhasználó által definiált skálázási tényezővel.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Skálázás az X és Y tengelyek mentén.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **GYIK**

**Milyen képformátumok használhatók a forma bélyegképek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/), és egyebek. A formákat [vektorként SVG‑ként exportálhatja](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/writeassvg/) a forma tartalmát SVG‑ként mentve.

**Mi a különbség a Shape és az Appearance határok között bélyegkép renderelésekor?**

`Shape` a forma geometriai adatait használja; `Appearance` a [vizuális effektusokat](/slides/hu/net/shape-effect/) (árnyékok, ragyogás stb.) veszi figyelembe.

**Mi történik, ha egy forma rejtettnek van jelölve? Továbbra is megjelenik bélyegképként?**

A rejtett forma továbbra is része a modellnek, és renderelhető; a rejtett jelző a diavetítés megjelenítését befolyásolja, de nem akadályozza meg a forma képének előállítását.

**Támogatottak-e csoportos formák, diagramok, SmartArt és egyéb összetett objektumok?**

Igen. Bármely, [Shape](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/)‑ként (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/), és a [SmartArt](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/smartart/)) reprezentált objektum menthető bélyegképként vagy SVG‑ként.

**A rendszer által telepített betűkészletek befolyásolják a szöveges formák bélyegképeinek minőségét?**

Igen. Ajánlott [a szükséges betűkészletek biztosítása](/slides/hu/net/custom-font/) (vagy [betűkészlet helyettesítések beállítása](/slides/hu/net/font-substitution/)) a nem kívánt helyettesítések és a szöveg átrendeződés elkerülése érdekében.