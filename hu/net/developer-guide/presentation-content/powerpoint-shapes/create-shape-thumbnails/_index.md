---
title: Bélyegképek létrehozása a prezentációs alakzatokhoz .NET-ben
linktitle: Alakzat bélyegképek
type: docs
weight: 70
url: /hu/net/create-shape-thumbnails/
keywords:
- alakzat bélyegkép
- alakzat kép
- alakzat renderelése
- alakzat renderelés
- vizuális határok
- alakzat határok
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Készítsen magas minőségű alakzat bélyegképeket PowerPoint diákból az Aspose.Slides for .NET segítségével – egyszerűen hozhat létre és exportálhat prezentációs bélyegképeket."
---
## **Bevezetés**

Aspose.Slides for .NET a prezentációs fájlok létrehozására szolgál, ahol minden oldal egy diát jelent. Ezek a diák megtekinthetők a prezentációs fájlok Microsoft PowerPoint programmal történő megnyitásával. Néha azonban a fejlesztőknek szükségük lehet a alakzatok képeinek külön képolvasóban történő megtekintésére. Ilyen esetekben az Aspose.Slides for .NET segít a diákat alkotó alakzatok bélyegkép‑képeinek előállításában. Ennek a funkciónak a használatát az alábbi cikk részletezi.

Ez a cikk azt mutatja be, hogyan lehet különböző módokon előállítani diabélyegek képeit:

- Alakzat bélyegképének előállítása egy dián belül.
- Alakzat bélyegképének előállítása felhasználó által meghatározott méretekkel.
- Alakzat bélyegképének előállítása az alakzat megjelenésének határain belül.

## **Alakzat bélyegképének előállítása diáról**

Az Aspose.Slides for .NET használatával bármely diáról alakzat bélyegképét a következőképpen állíthatja elő:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze be egy diának a hivatkozását az azonosítója vagy indexe alapján.
3. Szerezze meg a hivatkozott dia alakzat bélyegkép‑képét az alapértelmezett méretezésben.
4. Mentse el a bélyegkép képet bármilyen kívánt képtformátumba.

Az alábbi példa az alakzat bélyegképének előállítását mutatja.

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

## **Felhasználó által meghatározott méretezési tényezővel rendelkező bélyegkép előállítása**

Az Aspose.Slides for .NET használatával bármely diaalakzat bélyegképét a következőképpen állíthatja elő:

1. Hozzon létre egy példányt a `Presentation` osztályból.
2. Szerezze be egy diának a hivatkozását az azonosítója vagy indexe alapján.
3. Szerezze meg a hivatkozott dia bélyegkép‑képét az alakzat határainak figyelembevételével.
4. Mentse el a bélyegkép képet bármilyen kívánt képtformátumba.

Az alábbi példa felhasználó által definiált méretezési tényezővel rendelkező bélyegképet mutat.

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

## **Határak alapú alakzat megjelenés bélyegkép létrehozása**

Ez a módszer az alakzatok bélyegképeinek létrehozásához lehetővé teszi a fejlesztők számára, hogy az alakzat megjelenésének határain belül készítsenek bélyegképet. Figyelembe veszi az összes alakzati hatást. A létrehozott alakzat bélyegképét a dia határai korlátozzák. Bármely diaalakzat megjelenésének határain belüli bélyegkép előállításához használja az alábbi példakódot:

1. Hozzon létre egy példányt a `Presentation` osztályból.
2. Szerezze be egy diának a hivatkozását az azonosítója vagy indexe alapján.
3. Szerezze meg a hivatkozott dia bélyegkép‑képét az alakzat határainak megjelenésként való használatával.
4. Mentse el a bélyegkép képet bármilyen kívánt képtformátumba.

Az alábbi példa egy felhasználó által definiált méretezési tényezővel rendelkező bélyegképet hoz létre.

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

## **Az alakzat tényleges vizuális határainak lekérdezése**

Az [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) keretjellemzői — a `X`, `Y`, `Width` és `Height` tulajdonságai — leírják a prezentációs modellben tárolt téglalapot. A ténylegesen renderelt tartalom túlnyúlhat ezen a kereten, vagy egy másik tengelyre igazított téglalapot foglalhat el. A forgatás, körvonalak, nyílszárnyak, szöveg elrendezése és túlfutása, a generált SmartArt geometria és egyéb renderelési hatások mind módosíthatják a lefoglalt területet.

Használja a [GetVisualBounds](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getvisualbounds/) metódust az elfoglalt terület kiszámításához anélkül, hogy képet hozna létre. A metódus egy [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) objektumot ad vissza diakoordinátákban. A visszakapott téglalap nincs levágva a diára, ezért koordinátái negatívak lehetnek, ha a tartalom a dia eredete után is terjed.

A [GetVisualBounds](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getvisualbounds/) metódus jelenleg nincs deklarálva az [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) felületen. Ezért a diáról származó alakzatot a shape gyűjteményből tartsa interfész értékként, és csak a metódus hívásakor konvertálja.

A következő példa lekéri és összehasonlítja a keret- és vizuális határokat:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Ugyanez a [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) felhasználható a közeli alakzatok `Left`, `Right`, `Top` vagy `Bottom` élhez igazításához; elegendő hely lefoglalásához egy generált elrendezésben; vagy a megengedett területen kívüli tartalom észleléséhez. A vizuális határok különösen hasznosak SmartArt, szövegdobozok, nyilak, képek, forgatott alakzatok és csoportos alakzatok esetén, ahol a tárolt keret nem tükrözi a teljes renderelt eredményt.

Használja a [GetVisualBounds](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getvisualbounds/) metódust, ha elrendezési vagy validációs koordinátákra van szüksége, és nem szükséges bitmap. Használja az [IShape.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getimage/) metódust, ha az alakzatot renderelni kell. A [ShapeThumbnailBounds](https://reference.aspose.com/slides/hu/net/aspose.slides/shapethumbnailbounds/) esetében a `ShapeThumbnailBounds.Shape` a kép méretét az alakzat határai alapján állítja be, beleértve a körvonalbeállításokat, míg a `ShapeThumbnailBounds.Appearance` az alakzat megjelenése alapján méretezi a képet, és a végeredményt a dia határaira korlátozza. Ezzel szemben a [GetVisualBounds](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getvisualbounds/) csak a kiszámított téglalapot adja vissza, és nem vágja le a diára.

## **GYIK**

**Milyen képt formátumok használhatók a alakzat bélyegképeinek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/), és egyebek. Az alakzatok [exportálhatók vektoros SVG‑ként](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/writeassvg/) a tartalmuk SVG‑ként történő mentésével.

**Mi a különbség a Shape és az Appearance határok között a bélyegkép renderelésekor?**

`Shape` a forma geometriai adatait használja; `Appearance` a [vizuális hatásokat](/slides/hu/net/shape-effect/) (árnyékok, ragyogások stb.) veszi figyelembe.

**Mi történik, ha egy alakzat rejtettként van megjelölve? Mégis rendereli a bélyegképként?**

A rejtett alakzat továbbra is része a modellnek, és renderelhető; a rejtett jelző a diavetítés megjelenését befolyásolja, de nem akadályozza meg az alakzat képének generálását.

**Támogatottak a csoportos alakzatok, diagramok, SmartArt és egyéb összetett objektumok?**

Igen. Bármely, [Shape](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/)‑ként reprezentált objektum (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/), és a [SmartArt](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/smartart/) elemeket) menthető bélyegképként vagy SVG‑ként.

**A rendszer által telepített betűtípusok befolyásolják a szöveg alakzatok bélyegképeinek minőségét?**

Igen. Ajánlott a [szükséges betűtípusok biztosítása](/slides/hu/net/custom-font/) (vagy a [betűtípus-helyettesítések beállítása](/slides/hu/net/font-substitution/)), hogy elkerülje a nem kívánt helyettesítéseket és a szöveg átrendeződését.