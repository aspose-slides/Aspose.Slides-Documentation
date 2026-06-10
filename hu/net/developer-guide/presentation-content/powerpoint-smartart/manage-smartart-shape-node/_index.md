---
title: SmartArt alakzat csomópontok kezelése a prezentációkban .NET-ben
linktitle: SmartArt alakzat csomópont
type: docs
weight: 30
url: /hu/net/manage-smartart-shape-node/
keywords:
- SmartArt csomópont
- gyermekcsomópont
- csomópont hozzáadása
- csomópont pozíciója
- csomópont elérése
- csomópont eltávolítása
- egyéni pozíció
- asszisztens csomópont
- kitöltési formátum
- csomópont megjelenítése
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Kezelje a SmartArt alakzat csomópontokat PPT és PPTX fájlokban az Aspose.Slides for .NET segítségével. Szerezzen egyértelmű kódrészleteket és tippeket a prezentációk hatékonyabbá tételéhez."
---
## **Áttekintés**

A PowerPoint‑prezentációk SmartArt grafikái csomópontok alapján vannak felépítve, amelyek szöveget tartalmaznak és meghatározzák a diagram szerkezetét. Az Aspose.Slides lehetővé teszi ezen SmartArt csomópontok programozott kezelését: új csomópontok és gyermekcsomópontok hozzáadása, gyermekcsomópontok egy adott pozícióba való beszúrása, meglévő csomópontok elérése, valamint a szövegük, szintjük és pozíciójuk olvasása.

Ez a cikk bemutatja a SmartArt alakzat csomópontjainak kezelését. Megmutatja, hogyan lehet csomópontokat eltávolítani, gyermekcsomópontokkal index vagy pozíció szerint dolgozni, egy asszisztens csomópontot normál csomópontra változtatni, a SmartArt csomópont alakzatok pozícióját, méretét és forgását módosítani, a csomópont kitöltési formátumát beállítani, valamint egy Miniatűr képet generálni egy SmartArt gyermekcsomóponthoz.

## **SmartArt csomópont hozzáadása**

Az Aspose.Slides for .NET a legegyszerűbb API‑t biztosítja a SmartArt alakzatok kezeléséhez a legegyszerűbb módon. Az alábbi mintakód segít csomópontot és gyermekcsomópontot hozzáadni egy SmartArt alakzathoz.

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián szereplő minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArt típusra.
- Adjon hozzá egy új csomópontot a SmartArt alakzat NodeCollection gyűjteményéhez, és állítsa be a szöveget a TextFrame‑ben.
- Ezután adjon hozzá egy gyermekcsomópontot az újonnan hozzáadott SmartArt csomóponthoz, és állítsa be a szöveget a TextFrame‑ben.
- Mentse a prezentációt.

```c#
// Töltsd be a kívánt prezentációt
Presentation pres = new Presentation("AddNodes.pptx");

// Haladj át minden alakzaton az első dián belül
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Ellenőrizd, hogy az alakzat SmartArt típusú-e
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Alakzat típusának átalakítása SmartArt-ra
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Új SmartArt csomópont hozzáadása
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Szöveg hozzáadása
        TemNode.TextFrame.Text = "Test";

        // Új gyermekcsomópont hozzáadása a szülőcsomóponthoz. A gyűjtemény végén kerül hozzáadásra
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Szöveg hozzáadása
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Prezentáció mentése
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **SmartArt csomópont hozzáadása meghatározott pozícióban**

Az alábbi mintakódban bemutatjuk, hogyan adhatók hozzá a SmartArt alakzat egyes csomópontjaihoz tartozó gyermekcsomópontok egy adott pozícióban.

- Hozzon létre egy példányt a `Presentation` osztályból.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Adjon hozzá egy StackedList típusú SmartArt alakzatot a kiválasztott diához.
- Érje el az első csomópontot a hozzáadott SmartArt alakzatban.
- Ezután adjon hozzá egy gyermekcsomópontot a kiválasztott csomóponthoz a 2‑es pozícióban, és állítsa be a szöveget.
- Mentse a prezentációt.

```c#
// Prezentációpéldány létrehozása
Presentation pres = new Presentation();

// A prezentáció dia elérése
ISlide slide = pres.Slides[0];

// Smart Art IShape hozzáadása
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// A SmartArt csomópont elérése a 0-ás indexen
ISmartArtNode node = smart.AllNodes[0];

// Új gyermekcsomópont hozzáadása a szülőcsomópontban a 2-es pozícióban
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Szöveg hozzáadása
chNode.TextFrame.Text = "Sample Text Added";

// Prezentáció mentése
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **SmartArt csomópont elérése**

Az alábbi mintakód segít elérni a SmartArt alakzaton belüli csomópontokat. Kérjük, vegye figyelembe, hogy a SmartArt LayoutType‑ját nem lehet módosítani, mivel csak olvasható, és csak a SmartArt alakzat hozzáadása során állítható be.

- Hozzon létre egy példányt a `Presentation` osztályból, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián szereplő minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArt típusra.
- Iteráljon végig a SmartArt alakzaton belüli összes csomóponton.
- Érje el és jelenítse meg a SmartArt csomópont pozícióját, szintjét és a szöveget.

```c#
  // Töltsd be a kívánt prezentációt
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Haladj át minden alakzaton az első dián belül
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Ellenőrizd, hogy az alakzat SmartArt típusú-e
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Alakzat típusának átalakítása SmartArt-ra
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Haladj át az összes csomóponton a SmartArt-on belül
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // A SmartArt csomópont elérése az i indexen
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // A SmartArt csomópont paramétereinek kiírása
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

## **SmartArt gyermekcsomópont elérése**

Az alábbi mintakód segít elérni a SmartArt alakzaton belüli egyes csomópontokhoz tartozó gyermekcsomópontokat.

- Hozzon létre egy példányt a PresentationEx osztályból, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián szereplő minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArtEx típusra.
- Iteráljon végig a SmartArt alakzaton belüli összes csomóponton.
- Minden kiválasztott SmartArt alakzat csomópont esetén iteráljon végig a adott csomóponton belüli összes gyermekcsomóponton.
- Érje el és jelenítse meg a gyermekcsomópont pozícióját, szintjét és a szöveget.

```c#
// Töltsd be a kívánt prezentációt
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Haladj át minden alakzaton az első dián belül
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Ellenőrizd, hogy az alakzat SmartArt típusú-e
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Alakzat típusának átalakítása SmartArt-ra
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Haladj át az összes csomóponton a SmartArt-on belül
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // A SmartArt csomópont elérése az i indexen
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Haladj végig a gyermekcsomópontokon az i indexű SmartArt csomópontban
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // A gyermekcsomópont elérése a SmartArt csomópontban
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // A SmartArt gyermekcsomópont paramétereinek kiírása
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **SmartArt gyermekcsomópont elérése meghatározott pozícióban**

Ebben a példában megtanuljuk, hogyan érhetők el a SmartArt alakzat egyes csomópontjaihoz tartozó gyermekcsomópontok egy adott pozícióban.

- Hozzon létre egy példányt a `Presentation` osztályból.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Adjon hozzá egy StackedList típusú SmartArt alakzatot.
- Érje el a hozzáadott SmartArt alakzatot.
- Érje el a 0‑as indexű csomópontot a kiválasztott SmartArt alakzaton.
- Ezután a GetNodeByPosition() metódussal érje el a 1‑es pozícióban lévő gyermekcsomópontot a kiválasztott SmartArt csomópontnál.
- Érje el és jelenítse meg a gyermekcsomópont pozícióját, szintjét és a szöveget.

```c#
// A prezentáció példányosítása
Presentation pres = new Presentation();

// Az első dia elérése
ISlide slide = pres.Slides[0];

// SmartArt alakzat hozzáadása az első diára
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// A SmartArt csomópont elérése a 0-ás indexen
ISmartArtNode node = smart.AllNodes[0];

// A gyermekcsomópont elérése az 1-es pozícióban a szülőcsomópontban
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// A SmartArt gyermekcsomópont paramétereinek kiírása
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **SmartArt csomópont eltávolítása**

Ebben a példában megtanuljuk a SmartArt alakzaton belüli csomópontok eltávolítását.

- Hozzon létre egy példányt a `Presentation` osztályból, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián szereplő minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArt típusra.
- Ellenőrizze, hogy a SmartArt rendelkezik-e több mint 0 csomóponttal.
- Válassza ki a törlendő SmartArt csomópontot.
- Ezután a RemoveNode() metódussal távolítsa el a kiválasztott csomópontot, majd mentse a prezentációt.

```c#
// Töltsd be a kívánt prezentációt
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Haladj át minden alakzaton az első dián belül
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Ellenőrizd, hogy az alakzat SmartArt típusú-e
        if (shape is ISmartArt)
        {
            // Alakzat típusának átalakítása SmartArtEx-re
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // A SmartArt csomópont elérése a 0-ás indexen
                ISmartArtNode node = smart.AllNodes[0];

                // A kiválasztott csomópont eltávolítása
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Prezentáció mentése
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **SmartArt csomópont eltávolítása meghatározott pozícióban**

Ebben a példában megtanuljuk a SmartArt alakzaton belüli csomópontok egy adott pozícióban történő eltávolítását.

- Hozzon létre egy példányt a `Presentation` osztályból, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián szereplő minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArt típusra.
- Válassza ki a 0‑as indexű SmartArt alakzat csomópontot.
- Ellenőrizze, hogy a kiválasztott SmartArt csomópont rendelkezik-e több mint 2 gyermekcsomóponttal.
- Ezután a RemoveNodeByPosition() metódussal távolítsa el az 1‑es pozícióban lévő csomópontot.
- Mentse a prezentációt.

```c#
// Töltsd be a kívánt prezentációt             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Haladj át minden alakzaton az első dián belül
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Ellenőrizd, hogy az alakzat SmartArt típusú-e
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Alakzat típusának átalakítása SmartArt-ra
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // A SmartArt csomópont elérése a 0-ás indexen
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // A gyermekcsomópont eltávolítása az 1-es pozícióban
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Prezentáció mentése
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Egyéni pozíció beállítása gyermekcsomóponthoz egy SmartArt objektumban**

Az Aspose.Slides for .NET most már támogatja a SmartArtShape X és Y tulajdonságainak beállítását. Az alábbi kódrészlet megmutatja, hogyan állítható be egyéni SmartArtShape pozíció, méret és forgatás, és vegye figyelembe, hogy új csomópontok hozzáadása az összes csomópont pozíciójának és méretének újraszámítását eredményezi.

```c#
// Töltsd be a kívánt prezentációt
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// SmartArt alakzat áthelyezése új pozícióba
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// SmartArt alakzat szélességének módosítása
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// SmartArt alakzat magasságának módosítása
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// SmartArt alakzat forgatásának módosítása
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **Asszisztens csomópont ellenőrzése**

Az alábbi mintakódban megvizsgáljuk, hogyan azonosíthatók a Assistant (asszisztens) csomópontok a SmartArt csomópontgyűjteményben, és hogyan lehet őket módosítani.

- Hozzon létre egy példányt a PresentationEx osztályból, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg a második dia hivatkozását az Index használatával.
- Iteráljon végig az első dián szereplő minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArtEx típusra.
- Iteráljon végig a SmartArt alakzaton belüli összes csomóponton, és ellenőrizze, hogy asszisztens csomópontok-e.
- Módosítsa az asszisztens csomópont állapotát normál csomópontra.
- Mentse a prezentációt.

```c#
// Prezentáció példány létrehozása
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Haladj át minden alakzaton az első dián belül
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Ellenőrizd, hogy az alakzat SmartArt típusú-e
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Alakzat típusának átalakítása SmartArtEx-re
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Haladj végig a SmartArt alakzat összes csomópontján

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Ellenőrizd, hogy a csomópont asszisztens csomópont-e
                if (node.IsAssistant)
                {
                    // Az asszisztens csomópont beállítása hamisra és normál csomópontra változtatás
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Prezentáció mentése
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Csomópont kitöltési formátumának beállítása**

Az Aspose.Slides for .NET lehetővé teszi egyedi SmartArt alakzatok hozzáadását és azok kitöltési formátumának beállítását. Ez a cikk bemutatja, hogyan hozhatók létre és érhetők el a SmartArt alakzatok, valamint hogyan állítható be a kitöltési formátum az Aspose.Slides for .NET segítségével.

Kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a `Presentation` osztályból.
- Szerezze meg egy dia hivatkozását az indexének használatával.
- Adjon hozzá egy SmartArt alakzatot a LayoutType beállításával.
- Állítsa be a FillFormat‑ot a SmartArt alakzat csomópontjain.
- Írja ki a módosított prezentációt PPTX fájlként.

```c#
using (Presentation presentation = new Presentation())
{
    // A dia elérése
    ISlide slide = presentation.Slides[0];

    // SmartArt alakzat és csomópontok hozzáadása
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // A csomópont kitöltőszínének beállítása
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Prezentáció mentése
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **SmartArt gyermekcsomópont miniatűrjének generálása**

A fejlesztők az alábbi lépéseket követve generálhatnak miniatűr képet egy SmartArt gyermekcsomópontról:

1. Hozzon létre egy `Presentation` osztály példányt, amely a PPTX fájlt képviseli.
2. Adjon hozzá SmartArtot.
3. Szerezze meg egy csomópont hivatkozását az Index használatával
4. Szerezze meg a miniatűr képet.
5. Mentse a miniatűr képet a kívánt képformátumban.

Az alábbi példa egy SmartArt gyermekcsomópont miniatűrjének generálását mutatja

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **GYIK**

**Támogatott a SmartArt animáció?**

Igen. A SmartArt-ot hagyományos alakzatként kezelik, így [alkalmazhat standard animációkat](/slides/hu/net/shape-animation/) (belépő, kilépő, hangsúlyozó, mozgásvonalak) és beállíthatja az időzítést. Szükség esetén animálhatja a SmartArt csomópontokon belüli alakzatokat is.

**Hogyan tudok megbízhatóan megtalálni egy adott SmartArt-ot a dián, ha a belső azonosítója ismeretlen?**

Adjunk és keressünk [alternatív szöveg](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/alternativetext/) alapján. Egy egyedi AltText beállítása a SmartArton lehetővé teszi, hogy programozottan megtaláljuk anélkül, hogy a belső azonosítókra támaszkodnánk.

**Megmarad a SmartArt megjelenése a prezentáció PDF‑be konvertálásakor?**

Igen. Az Aspose.Slides magas vizuális hűséggel rendereli a SmartArt-ot a [PDF export](/slides/hu/net/convert-powerpoint-to-pdf/) során, megőrizve a elrendezést, színeket és hatásokat.

**Kivonhatok képet az egész SmartArt‑ról (előnézetekhez vagy jelentésekhez)?**

Igen. Renderelhet egy SmartArt alakzatot [raszteres formátumokba](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/) vagy [SVG](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/writeassvg/) a méretezhető vektorkimenethez, ami alkalmas miniatűrökhöz, jelentésekhez vagy webes használatra.