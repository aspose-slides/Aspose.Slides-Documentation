---
title: Diaképletek alkalmazása vagy módosítása .NET-ben
linktitle: Dia elrendezés
type: docs
weight: 60
url: /hu/net/slide-layout/
keywords:
- dia elrendezés
- tartalom elrendezés
- helyőrlap
- prezentáció tervezés
- dia tervezés
- használaton kívüli elrendezés
- lábléc láthatóság
- cím dia
- cím és tartalom
- szakaszcím
- két tartalom
- összehasonlítás
- csak cím
- üres elrendezés
- tartalom felirattal
- kép felirattal
- cím és függőleges szöveg
- függőleges cím és szöveg
- PowerPoint
- OpenDocument
- prezentáció
- C#
- .NET
- Aspose.Slides
description: "Kezelje és testreszabja a diaképleteket az Aspose.Slides for .NET-ben. Tekintse meg az elrendezéstípusokat, a helyőrlapok kezelését és a lábléc láthatóságát C# kódrészletek segítségével."
---
## **Bevezetés**

Egy diaképlet meghatározza a helyőrlapdobozok elrendezését és a dián lévő tartalom formázását. Szabályozza, hogy mely helyőrlapok érhetők el, és hol jelennek meg. A diaképletek segítenek gyorsan és következetesen elkészíteni a bemutatókat – legyen szó egyszerű vagy összetettebb anyagról. A PowerPoint leggyakoribb diaképletei a következők:

**Címdia elrendezés** – Két szöveghelyőrlapot tartalmaz: egyet a címnek és egyet az alcímmel.

**Cím és tartalom elrendezés** – A tetején kisebb címhelyőrlappal, alatta nagyobbal a fő tartalomhoz (például szöveg, felsorolás, diagramok, képek stb.) rendelkezik.

**Üres elrendezés** – Nem tartalmaz helyőrlapokat, így teljes szabadságot ad a dia teljesen újratervezéséhez.

A diaképletek a dia mester részei, amely a legfelső szintű dia, és meghatározza az előadás elrendezési stílusait. A diaképletekhez a dia mester segítségével férhet hozzá és módosíthatja őket – típusa, neve vagy egyedi azonosítója alapján. Alternatívaként egy adott diaképletet közvetlenül is szerkeszthet a prezentáción belül.

Az Aspose.Slides for .NET-ben a diaképletekkel a következőkkel dolgozhat:

- A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály alatt elérhető tulajdonságok, például a [LayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/layoutslides/) és a [Masters](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/masters/).
- Olyan típusok, mint a [ILayoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutplaceholdermanager/) és a [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslideheaderfootermanager/).

{{% alert title="Info" color="info" %}}
Ha többet szeretne megtudni a mester diák használatáról, tekintse meg a [Slide Master](/slides/hu/net/slide-master/) cikket.
{{% /alert %}}

## **Diaképletek hozzáadása a bemutatókhoz**

A diák megjelenésének és szerkezetének testreszabásához előfordulhat, hogy új diaképleteket kell hozzáadnia a prezentációhoz. Az Aspose.Slides for .NET lehetővé teszi, hogy ellenőrizze, létezik-e már egy adott elrendezés, szükség esetén újat adjon hozzá, és azt használja a diák beszúrásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
2. Hozzáfér a [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterlayoutslidecollection/) gyűjteményhez.  
3. Ellenőrizze, hogy a kívánt diaképlet már létezik-e a gyűjteményben. Ha nem, adja hozzá a szükséges diaképletet.  
4. Adjon hozzá egy üres diát az új diaképlet alapján.  
5. Mentse a prezentációt.

```cs
// Példányosítsa a Presentation osztályt, amely egy PowerPoint fájlt képvisel.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Menjen végig a diaképlet típusokon, hogy kiválasszon egy diaképletet.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Olyan helyzet, amikor a prezentáció nem tartalmazza az összes diaképlet típust.
        // A prezentáció fájl csak Üres és Egyedi diaképlet típusokat tartalmaz.
        // Azonban az egyedi típusú diaképletek jól felismerhető nevekkel rendelkezhetnek,
        // például "Cím", "Cím és tartalom" stb., amelyek a diaképlet kiválasztásához használhatók.
        // Emellett támaszkodhat egy helyőrlap alakzattípusok halmazára.
        // Például a Cím dia csak a Cím helyőrlap típust kell, hogy tartalmazza, és így tovább.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Adj hozzá egy üres diát a hozzáadott diaképlettel.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Mentse a prezentációt a lemezre.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Használaton kívüli diaképletek eltávolítása**

Az Aspose.Slides a [Compress](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/) osztályból a [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust kínálja, amely lehetővé teszi a nem kívánt és használaton kívüli diaképletek törlését.

Az alábbi C# kód bemutatja, hogyan lehet eltávolítani egy diaképletet egy PowerPoint prezentációból:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Helyőrlapok hozzáadása diaképletekhez**

Az Aspose.Slides a [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/placeholdermanager/) tulajdonságot biztosítja, amely lehetővé teszi új helyőrlapok hozzáadását egy diaképlethez.

Ez a kezelő a következő helyőrlap típusokhoz tartalmaz metódusokat:

| PowerPoint helyőrlap              | [ILayoutPlaceholderManager] metódus |
| --------------------------------- | ----------------------------------- |
| ![Tartalom](content.png)          | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Tartalom (függőleges)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Szöveg](text.png)               | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Szöveg (függőleges)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Kép](picture.png)               | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png)             | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Táblázat](table.png)            | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)         | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Média](media.png)               | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online kép](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Az alábbi C# kód bemutatja, hogyan lehet új helyőrlap alakzatokat hozzáadni az Üres elrendezés diához:

```cs
using (var presentation = new Presentation())
{
    // Szerezze meg az Üres elrendezés diát.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Szerezze meg a diaképlet helyőrlap-kezelőjét.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Különböző helyőrlapok hozzáadása az Üres elrendezés diához.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Új dia hozzáadása az Üres elrendezéssel.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A helyőrlapok a diaképleten](add_placeholders.png)

## **Lábléc láthatóság beállítása egy diaképlethez**

PowerPoint prezentációkban a lábléc elemek, mint a dátum, dia száma és egyéni szöveg, a diaképlet függvényében megjeleníthetők vagy elrejthetők. Az Aspose.Slides for .NET lehetővé teszi ezen lábléc helyőrlapok láthatóságának vezérlését. Ez akkor hasznos, ha bizonyos elrendezéseknél lábléc információt szeretne megjeleníteni, míg mások tiszták és minimalistaak maradnak.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen be egy diaképlet hivatkozást az indexe alapján.  
3. Állítsa a dia lábléc helyőrlapját láthatóvá.  
4. Állítsa a dia számhelyőrlapját láthatóvá.  
5. Állítsa a dátum-idő helyőrlapját láthatóvá.  
6. Mentse a prezentációt.

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Gyermek lábléc láthatóság beállítása egy dián**

PowerPoint prezentációkban a lábléc elemek, mint a dátum, dia száma és egyéni szöveg, a mester dia szintjén szabályozhatók, hogy következetességet biztosítsanak minden diaképleten. Az Aspose.Slides for .NET lehetővé teszi ezen lábléc helyőrlapok láthatóságának és tartalmának beállítását a mester dián, és ezeknek a beállításoknak a propagálását az összes gyermek diaképletre. Ez a megközelítés egységes lábléc információt biztosít a teljes prezentációban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást a mester diára az indexe alapján.  
3. Állítsa a mester és az összes gyermek lábléc helyőrlapját láthatóvá.  
4. Állítsa a mester és az összes gyermek dia számhelyőrlapját láthatóvá.  
5. Állítsa a mester és az összes gyermek dátum-idő helyőrlapját láthatóvá.  
6. Mentse a prezentációt.

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Mi a különbség a mester dia és a diaképlet között?**

A mester dia meghatározza az általános témát és az alapértelmezett formázást, míg a diaképletek konkrét helyőrlap elrendezéseket definiálnak a különböző tartalomtípusokhoz.

**Másolhatok diaképletet egy prezentációból egy másikba?**

Igen, klónozhat egy diaképletet egy prezentáció [LayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/layoutslides/) gyűjteményéből, és egy másikba beillesztheti az `AddClone` metódussal.

**Mi történik, ha törlök egy diaképletet, amelyet még egy dia használ?**

Ha megpróbál törölni egy diaképletet, amelyet a prezentáció legalább egy diája még hivatkozik, az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxeditexception/) kivételt dob. Ennek elkerüléséhez használja a [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust, amely biztonságosan eltávolítja csak a nem használt diaképleteket.