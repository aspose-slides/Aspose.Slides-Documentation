---
title: Prezentációs témák kezelése .NET-ben
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/net/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- téma színe
- további paletta
- téma betűtípusa
- téma stílusa
- téma effektusa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET fő prezentációs témái lehetővé teszik PowerPoint fájlok létrehozását, testreszabását és konvertálását egységes márkázással."
---
## **Bevezetés**

A bemutató téma meghatározza a tervezési elemek tulajdonságait. Amikor bemutató témát választ, lényegében egy meghatározott vizuális elemek és azok tulajdonságainak halmazát választja ki.

A PowerPointban egy téma színekből, [betűtípusok](/slides/hu/net/powerpoint-fonts/), [háttérstílusok](/slides/hu/net/presentation-background/), és effektusokból áll.

![theme-constituents](theme-constituents.png)

## **Téma színének módosítása**

A PowerPoint téma egy meghatározott színkészletet használ a dián lévő különböző elemekhez. Ha nem tetszenek a színek, a téma új színek alkalmazásával módosíthatja őket. Az új téma szín kiválasztásához az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolásban elérhető értékeket biztosítja.

Ez a C# kód megmutatja, hogyan lehet megváltoztatni egy téma hangsúlyszínét:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Így határozhatja meg a keletkező szín tényleges értékét:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Szín [A=255, R=128, G=100, B=162])
}
```

A színváltoztatás műveletének további bemutatásához létrehozunk egy másik elemet, és hozzárendeljük a hangsúlyszínt (az első műveletből). Ezután megváltoztatjuk a színt a témában:
```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

Az új szín automatikusan alkalmazásra kerül mindkét elemen.

### **Téma színének beállítása egy további palettáról**

Amikor a fő téma színre (1) luminancia-transzformációkat alkalmaz, a további palettáról (2) színek keletkeznek. Ezután beállíthatja és lekérheti ezeket a téma színeket.

![additional-palette-colors](additional-palette-colors.png)

**1** – Fő téma színek  
**2** – Színek a további palettáról.

Ez a C# kód bemutat egy műveletet, ahol a további palettaszíneket a fő téma színből származtatják, majd alakzatokban használják:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Akcent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Akcent 4, világosabb 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcent 4, világosabb 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcent 4, világosabb 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcent 4, sötétebb 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcent 4, sötétebb 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **`SchemeColor` leképezése `IColorScheme` színekre**

Amikor a [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/)‑val dolgozik, észreveheti, hogy a következő témaszín értékeket tartalmazza:
`Background1`, `Background2`, `Text1`, and `Text2`.

Azonban a `Presentation.MasterTheme.ColorScheme` egy [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/)‑t ad vissza, amely a megfelelő színeket a következőképpen teszi elérhetővé:
`Dark1`, `Dark2`, `Light1`, and `Light2`.

Ez a különbség csak a névben van. Ezek az értékek ugyanazokra a témaszín‑helyekre vonatkoznak, és a leképezés rögzített:
* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus átalakítás a `Text`/`Background` és a `Dark`/`Light` között. Egyszerűen csak alternatív nevei ugyanannak a témaszínnek.

Ez a néveltérés a Microsoft Office terminológiájából származik. A régebbi Office‑verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` elnevezéseket használták, míg az újabb felhasználói felületek ugyanazokat a helyeket `Text 1`, `Background 1`, `Text 2` és `Background 2`‑ként jelenítik meg.

## **Téma betűtípusának módosítása**

A témák és egyéb célok számára történő betűtípusok kiválasztásához az Aspose.Slides ezeket a speciális azonosítókat használja (a PowerPointban használtakhoz hasonlóan):
* **+mn-lt** - Törzsszöveg betűtípusa Latin (Minor Latin Font)
* **+mj-lt** - Címsor betűtípusa Latin (Major Latin Font)
* **+mn-ea** - Törzsszöveg kelet-ázsiai betűtípusa (Minor East Asian Font)
* **+mj-ea** - Törzsszöveg kelet-ázsiai betűtípusa (Minor East Asian Font)

Ez a C# kód megmutatja, hogyan lehet a latin betűtípust egy témaelemhez hozzárendelni:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

Ez a C# kód megmutatja, hogyan lehet módosítani a bemutató téma betűtípusát:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

A betűtípus minden szövegdobozban frissülni fog.
{{% alert color="info" title="TIP" %}} 

Érdemes megtekinteni a [PowerPoint betűtípusokat](/slides/hu/net/powerpoint-fonts/).

{{% /alert %}}

## **Téma háttérstílusának módosítása**

Alapértelmezés szerint a PowerPoint alkalmazás 12 előre definiált hátteret biztosít, de egy tipikus bemutatóban csak ezek közül 3 kerül mentésre.

![todo:image_alt_text](presentation-design_8.png)

Például, miután egy bemutatót elment a PowerPoint alkalmazásban, futtathatja ezt a C# kódot annak megállapításához, hogy hány előre definiált háttér van a bemutatóban:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

A [BackgroundFillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) tulajdonság használatával a [FormatScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/) osztályból hozzáadhat vagy elérheti a háttérstílust egy PowerPoint témában. 

{{% /alert %}}

Ez a C# kód megmutatja, hogyan kell beállítani a háttérképet egy bemutatóhoz:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Index útmutató**: 0 jelöli a kitöltés nélkült állapotot. Az index 1‑től kezdődik.

{{% alert color="info" title="TIP" %}} 

Érdemes megtekinteni a [PowerPoint háttér](/slides/hu/net/presentation-background/) lehetőséget.

{{% /alert %}}

## **Téma effektusának módosítása**

Egy PowerPoint téma általában 3 értéket tartalmaz minden stílus‑tömbhöz. Ezek a tömbök az alábbi három effektusba egyesülnek: finom, közepes és intenzív. Például ez a végeredmény, amikor az effektusok egy adott alakzatra kerülnek alkalmazásra:

![todo:image_alt_text](presentation-design_10.png)

A [FormatScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme) osztályból származó 3 tulajdonság ([FillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/effectstyles)) használatával módosíthatja a téma elemeit (még rugalmasabban, mint a PowerPoint beállításai).

Ez a C# kód megmutatja, hogyan lehet módosítani egy témaeffektust az elemek egyes részeinek változtatásával:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

A keletkezett változások a kitöltőszínben, a kitöltés típusában, az árnyék effektusban stb.:
![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

### Alkalmazhatok egy témát egyetlen diára a mester módosítása nélkül?

Igen. Az Aspose.Slides támogatja a dia‑szintű téma felülírását, így egy helyi témát alkalmazhat csak arra a diára, miközben a mester téma érintetlen marad (a [SlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/slidethememanager/) segítségével).

### Mi a legbiztonságosabb módja egy téma átvinni az egyik bemutatóból a másikba?

[Diák klónozása](/slides/hu/net/clone-slides/) a mesterükkel együtt a célbemutatóba. Ez megőrzi az eredeti mestert, elrendezéseket és a kapcsolódó témát, így a megjelenés konzisztens marad.

### Hogyan tekinthetem meg a „tényleges” (effective) értékeket a teljes öröklődés és felülírás után?

Használja az API ["effective" nézeteit](/slides/hu/net/shape-effective-properties/) a téma/szín/betűtípus/effektus esetén. Ezek a mester és a helyi felülírások alkalmazása után feloldott, végső tulajdonságokat adják vissza.