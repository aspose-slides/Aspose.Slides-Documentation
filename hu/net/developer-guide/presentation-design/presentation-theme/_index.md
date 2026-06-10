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
- kiegészítő paletta
- téma betűtípusa
- téma stílusa
- téma effektusa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Mester prezentációs témák az Aspose.Slides .NET számára, amelyek segítségével PowerPoint fájlokat hozhat létre, testreszabhat és konvertálhat konzisztens márkázással."
---
## **Bevezetés**

Egy bemutató téma meghatározza a tervezési elemek tulajdonságait. Amikor egy bemutató témát választ, lényegében egy adott vizuális elemeket és azok tulajdonságait tartalmazó készletet választ.

A PowerPointban egy téma színeket, [fonts](/slides/hu/net/powerpoint-fonts/), [background styles](/slides/hu/net/presentation-background/), és effektusokat tartalmaz.

![theme-constituents](theme-constituents.png)

## **Téma színének módosítása**

Egy PowerPoint téma egy adott színszettet használ a dia különböző elemeihez. Ha nem tetszenek a színek, új színeket alkalmazva módosíthatja a témát. Ahhoz, hogy kiválaszthass egy új téma színt, az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolásban értékeket biztosít.

Ez a C# kód bemutatja, hogyan változtatható meg egy téma kiemelés színe:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Így határozhatod meg a kapott szín tényleges értékét:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Szín [A=255, R=128, G=100, B=162])
```

A színváltoztatás további bemutatásához létrehozunk egy másik elemet, és rákapcsoljuk a kiemelés színét (az első műveletből). Ezután megváltoztatjuk a színt a témában:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Az új szín automatikusan alkalmazásra kerül mindkét elemre.

### **Téma színének beállítása egy kiegészítő palettáról**

Amikor a fő téma színre (1) luminancia transzformációkat alkalmazol, a kiegészítő palettáról (2) színek keletkeznek. Ezután beállíthatod és lekérheted ezeket a téma színeket. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Fő téma színek  

**2** - A kiegészítő paletta színei.

Ez a C# kód bemutatja, hogyan nyerhetők ki a kiegészítő paletta színek a fő téma színből, majd használhatók alakzatokban:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Akcentus 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Akcentus 4, Világosabb 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcentus 4, Világosabb 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcentus 4, Világosabb 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcentus 4, Sötétebb 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcentus 4, Sötétebb 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **SchemeColor leképezése IColorScheme színekre**

Amikor a [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) elemmel dolgozol, észreveheted, hogy a következő téma színértékeket tartalmazza:

`Background1`, `Background2`, `Text1`, és `Text2`.

Azonban a `Presentation.MasterTheme.ColorScheme` a [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/) típusát adja vissza, amely a megfelelő színeket a következőképpen jeleníti meg:

`Dark1`, `Dark2`, `Light1`, és `Light2`.

Ez a különbség csak a nevekben van. Ezek az értékek ugyanazokra a téma színbetűkre vonatkoznak, és a leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus átalakítás a `Text`/`Background` és a `Dark`/`Light` között. Egyszerűen csak alternatív nevek azonos téma színekhez.

Ez a néveltérés a Microsoft Office terminológiájából származik. A régebbi Office verziók a `Dark 1`, `Light 1`, `Dark 2`, és `Light 2` neveket használták, míg az újabb felhasználói felületek ugyanezeket a csatlakozókat jelenítik meg `Text 1`, `Background 1`, `Text 2`, és `Background 2` formában.

## **Téma betűtípusának módosítása**

Ahhoz, hogy a témákhoz és egyéb célokra betűtípusokat válassz, az Aspose.Slides ezeket a speciális azonosítókat használja (hasonlóan a PowerPointban használtakhoz):

* **+mn-lt** - Test betűtípusa latin (Kisebb latin betűtípus)
* **+mj-lt** - Fejléc betűtípusa latin (Nagy latin betűtípus)
* **+mn-ea** - Test betűtípusa kelet-ázsiai (Kisebb kelet-ázsiai betűtípus)
* **+mj-ea** - Fejléc betűtípusa kelet-ázsiai (Nagy kelet-ázsiai betűtípus)

Ez a C# kód megmutatja, hogyan rendelhető a latin betűtípus egy téma elemhez:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Ez a C# kód megmutatja, hogyan változtatható meg a bemutató téma betűtípusa:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Az összes szövegdoboz betűtípusa frissülni fog.

{{% alert color="primary" title="TIP" %}} 
Érdemes megnézni a [PowerPoint fonts](/slides/hu/net/powerpoint-fonts/). 
{{% /alert %}}

## **Téma háttérstílusának módosítása**

Alapértelmezésben a PowerPoint alkalmazás 12 előre definiált hátteret biztosít, de egy tipikus prezentációban csak 3 van elmentve ezekből a 12-ből. 

![todo:image_alt_text](presentation-design_8.png)

Például, ha elment egy bemutatót a PowerPointban, futtathatja ezt a C# kódot, hogy megtudja a prezentációban lévő előre definiált háttér számát:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
A [BackgroundFillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) tulajdonságot a [FormatScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/) osztályból használva hozzáadhat vagy elérhet háttérstílust egy PowerPoint témában. 
{{% /alert %}}

Ez a C# kód megmutatja, hogyan állíts be háttért egy prezentációhoz:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Index útmutató**: 0 az üres kitöltésre használatos. Az index 1-től kezdődik.

{{% alert color="primary" title="TIP" %}} 
Érdemes megnézni a [PowerPoint Background](/slides/hu/net/presentation-background/). 
{{% /alert %}}

## **Téma effektus változtatása**

Egy PowerPoint téma általában 3 értéket tartalmaz minden stílus tömbhöz. Ezek a tömbök kombinálódnak a 3 effektusban: finom, mérsékelt és intenzív. Például, ez a kimenet, amikor a effektusok egy adott alakzatra kerülnek:

![todo:image_alt_text](presentation-design_10.png)

A [FillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/linestyles), és [EffectStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/effectstyles) tulajdonságok a [FormatScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme) osztályból használva módosíthatod a téma elemeit (még rugalmasabban, mint a PowerPoint opciói).

Ez a C# kód megmutatja, hogyan változtatható meg egy téma effektus az elemek részeinek módosításával:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Az eredményül kapott változások a kitöltési színben, kitöltés típusban, árnyék hatásban stb.:

![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

**Alkalmazhatok egy témát egyetlen diára a mester anélkül?**

Igen. Az Aspose.Slides támogatja a dia-szintű téma felülírásokat, így alkalmazhatsz helyi témát csak arra a diára, miközben a mester téma érintetlen marad (a [SlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/slidethememanager/) segítségével).

**Mi a legbiztonságosabb módja a téma átvitelének az egyik prezentációból a másikba?**

[Clone slides](/slides/hu/net/clone-slides/) a masterrel együtt a célelő prezentációba. Ez megőrzi az eredeti mastert, elrendezéseket és a kapcsolódó témát, így a megjelenés konzisztens marad.

**Hogyan láthatom a "hatékony" értékeket az összes öröklődés és felülírás után?**

Használd az API ["effective"](/slides/hu/net/shape-effective-properties/) nézeteit a téma/szín/betűtípus/effektus esetén. Ezek a feloldott, végleges tulajdonságokat adják vissza a master és a helyi felülírások alkalmazása után.