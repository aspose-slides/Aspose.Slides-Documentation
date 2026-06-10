---
title: SmartArt grafikus elemek kezelése prezentációkban .NET-ben
linktitle: SmartArt grafika
type: docs
weight: 20
url: /hu/net/manage-smartart-shape/
keywords:
- SmartArt objektum
- SmartArt grafika
- SmartArt stílus
- SmartArt szín
- SmartArt létrehozása
- SmartArt hozzáadása
- SmartArt szerkesztése
- SmartArt módosítása
- SmartArt elérése
- SmartArt elrendezéstípus
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Automatizálja a PowerPoint SmartArt létrehozását, szerkesztését és stílusozását .NET-ben az Aspose.Slides segítségével, tömör kódrészletekkel és a teljesítményre fókuszáló útmutatással."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan hozzon létre és kezeljen SmartArt grafikákat PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan adhat hozzá egy SmartArt alakzatot egy diához, hogyan érhet el létező SmartArt alakzatokat, hogyan találhat SmartArt-ot egy adott elrendezéstípus szerint, és hogyan frissítheti megjelenését a SmartArt stílus vagy színstílus módosításával.

A példák bemutatják, hogyan dolgozzunk SmartArt alakzatokkal a prezentáció diájának alakzatgyűjteményén keresztül, ellenőrizzük, hogy egy alakzat SmartArt-e, majd módosítsuk vagy vizsgáljuk meg annak tulajdonságait.

## **SmartArt alakzat létrehozása**
Az Aspose.Slides for .NET most lehetővé teszi, hogy saját SmartArt alakzatokat adjunk hozzá a diákhoz a semmiből. Az Aspose.Slides for .NET a legegyszerűbb API‑t biztosítja a SmartArt alakzatok létrehozásához. A SmartArt alakzat létrehozásához egy dián kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
- Szerezze meg a dia hivatkozását az Index használatával.
- Adjon hozzá egy SmartArt alakzatot a LayoutType beállításával.
- Mentse a módosított prezentációt PPTX fájlként.

```c#
// A prezentáció példányosítása
using (Presentation pres = new Presentation())
{

    // A prezentáció diájának elérése
    ISlide slide = pres.Slides[0];

    // SmartArt alakzat hozzáadása
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Prezentáció mentése
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **SmartArt alakzat elérése egy dián**
A következő kódot a prezentáció diájához hozzáadott SmartArt alakzatok eléréséhez használjuk. A példakódban végigjárjuk a dia minden alakzatát, és ellenőrizzük, hogy SmartArt alakzat-e. Ha az alakzat SmartArt típusú, akkor típuskonverzióval SmartArt példányként kezeljük.

```c#
// A kívánt prezentáció betöltése
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Az első dián belüli minden alakzat bejárása
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape is ISmartArt)
        {
            // Az alakzat típuskonvertálása SmartArtEx-re
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```



## **SmartArt alakzat elérése adott elrendezéstípussal**
A következő mintakód segít hozzáférni egy adott LayoutType‑ú SmartArt alakzathoz. Vegye figyelembe, hogy a SmartArt LayoutType‑ját nem módosíthatja, mivel csak olvasható, és csak a SmartArt alakzat hozzáadása során állítható be.

- Hozzon létre egy `Presentation` osztály példányt, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Járja végig az első dia minden alakzatát.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, típuskonvertálja a kiválasztott alakzatot SmartArt‑ra.
- Ellenőrizze a SmartArt alakzatot a megadott LayoutType‑bal, és a szükséges műveleteket hajtsa végre ezután.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Az első dián belüli minden alakzat bejárása
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape is ISmartArt)
        {
            // Az alakzat típuskonvertálása SmartArtEx-re
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt elrendezés ellenőrzése
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```



## **SmartArt alakzat stílusának módosítása**
A következő mintakód segít hozzáférni a SmartArt alakzathoz egy adott LayoutType‑val.

- Hozzon létre egy `Presentation` osztály példányt, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Járja végig az első dia minden alakzatát.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, típuskonvertálja a kiválasztott alakzatot SmartArt‑ra.
- Keresse meg a SmartArt alakzatot a megadott Stílussal.
- Állítsa be az új Stílust a SmartArt alakzatra.
- Mentse a prezentációt.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Az első dián belüli minden alakzat bejárása
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape is ISmartArt)
        {
            // Az alakzat típuskonvertálása SmartArtEx-re
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt stílus ellenőrzése
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // SmartArt stílusának módosítása
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Prezentáció mentése
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **SmartArt alakzat színstílusának módosítása**
Ebben a példában megtanuljuk, hogyan változtassuk meg egy SmartArt alakzat színstílusát. A következő mintakódban hozzáférünk a SmartArt alakzathoz egy adott színstílussal, és módosítjuk annak stílusát.

- Hozzon létre egy `Presentation` osztály példányt, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Járja végig az első dia minden alakzatát.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, típuskonvertálja a kiválasztott alakzatot SmartArt‑ra.
- Keresse meg a SmartArt alakzatot a megadott Színstílussal.
- Állítsa be az új Színstílust a SmartArt alakzatra.
- Mentse a prezentációt.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Az első dián belüli minden alakzat bejárása
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if (shape is ISmartArt)
        {
            // Az alakzat típuskonvertálása SmartArtEx-re
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt színstílus ellenőrzése
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // SmartArt színstílus módosítása
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Prezentáció mentése
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Animálhatom a SmartArt‑ot egyetlen objektumként?**

Igen. A SmartArt egy alakzat, ezért a [standard animációkat](/slides/hu/net/powerpoint-animation/) alkalmazhatja az animációk API‑ján (belépés, kilépés, hangsúlyozás, mozgáspályák) úgy, mint a többi alakzatra.

**Hogyan találhatok meg egy adott SmartArt-ot egy dián, ha nem ismerem annak belső azonosítóját?**

Állítson be és használja az Alternatív szöveget (AltText), majd keresse meg az alakzatot ezen érték alapján – ez a javasolt módja a célalakzat megtalálásának.

**Csoportosíthatom a SmartArt-ot más alakzatokkal?**

Igen. A SmartArt-ot más alakzatokkal (képek, táblázatok stb.) csoportosíthatja, majd a [csoportot manipulálhatja](/slides/hu/net/group/).

**Hogyan kaphatok képet egy adott SmartArt-ból (pl. előnézethez vagy jelentéshez)?**

Exportáljon egy előnézeti képet/thumbnail‑t az alakzatról; a könyvtár képes [egyes alakzatok renderelésére](/slides/hu/net/create-shape-thumbnails/) raszter fájlokba (PNG/JPG/TIFF).

**Megmarad a SmartArt megjelenése, ha a teljes prezentációt PDF‑be konvertáljuk?**

Igen. A renderelő motor a magas hűségre törekszik a [PDF‑export](/slides/hu/net/convert-powerpoint-to-pdf/) során, számos minőség‑ és kompatibilitási beállítással.