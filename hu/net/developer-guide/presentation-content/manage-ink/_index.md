---
title: "Prezentációs tinta objektumok kezelése .NET-ben"
linktitle: "Tinta kezelése"
type: docs
weight: 95
url: /hu/net/manage-ink/
keywords:
- tinta
- tinta objektum
- tinta nyomvonal
- tinta kezelése
- tinta rajzolása
- rajzolás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "PowerPoint tinta objektumok kezelése – digitális tinta létrehozása, szerkesztése és stílusozása az Aspose.Slides for .NET segítségével. Kódminták nyomvonalakról, ecset színről és méretről."
---
## **Bevezetés**

A PowerPoint biztosítja az tinta funkciót, amely lehetővé teszi nem szabványos alakzatok rajzolását, ezek használhatók más objektumok kiemelésére, kapcsolatok és folyamatok bemutatására, valamint a dián lévő konkrét elemek figyelemfelkeltésére.

Az Aspose.Slides biztosítja a [Aspose.Slides.Ink](https://reference.aspose.com/slides/hu/net/aspose.slides.ink/) interfészt, amely tartalmazza a tinta objektumok létrehozásához és kezeléséhez szükséges típusokat.

## **A normál objektumok és a tinta objektumok közötti különbségek**

A PowerPoint dián lévő objektumok általában alakzatobjektumokként jelennek meg. Egy alakzatobjektum legegyszerűbb formájában egy tároló, amely meghatározza az objektum saját területét (a keretét) és annak tulajdonságait. Az utóbbi tartalmazza a tároló területméretét, a tároló alakját, a tároló háttérszínét stb. További információkért lásd a [Alakzat elrendezési formátum](https://docs.aspose.com/slides/hu/net/shape-manipulations/#access-layout-formats-for-shape) szakaszt.

Azonban amikor a PowerPoint egy tinta objektummal dolgozik, figyelmen kívül hagyja a keret (tároló) minden tulajdonságát, kivéve a méretét. A tároló területméretét a szabványos `width` és `height` értékek határozzák meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintaforma nyomvonalak**

A nyomvonal egy alapvető elem vagy szabvány, amelyet a digitális tinta írásakor a toll mozgásának pályájának rögzítésére használnak. A nyomvonalak felvételek, amelyek összekapcsolt pontok sorozatát írják le.

A legegyszerűbb kódolási forma minden mintapont X és Y koordinátáit adja meg. Amikor az összekapcsolt pontok megjelennek, a következő képet eredményezik:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecsettulajdonságok a rajzoláshoz**

Használhat ecsetet a nyomvonal elemek pontjait összekötő vonalak rajzolásához. Az ecsetnek saját színe és mérete van, ami a `Brush.Color` és a `Brush.Size` tulajdonságoknak felel meg.

### **Tintaecset színének beállítása**

Ez a C# kód mutatja, hogyan állíthatja be egy ecset színét:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **Tintaecset méretének beállítása**

Ez a C# kód mutatja, hogyan állíthatja be egy ecset méretét:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

Általában az ecset szélessége és magassága nem egyezik, ezért a PowerPoint nem jeleníti meg az ecset méretét (az adatmező szürkén jelenik meg). Ha az ecset szélessége és magassága megegyezik, a PowerPoint a következő módon jeleníti meg a méretet:

![ink_powerpoint3](ink_powerpoint3.png)

A tisztább szemlélet kedvéért növeljük meg a tinta objektum magasságát, és tekintsük át a fontos méreteket:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig azt feltételezi, hogy a vonal vastagsága nulla (lásd az utolsó képet).

Ezért a teljes tinta objektum látható területének meghatározásához figyelembe kell venni a nyomvonal objektumok ecsetméretét. Itt a célobjektum (a kézírásos szöveg nyomvonalobjektuma) a tároló (keret) méretéhez lett skálázva. Amikor a tároló (keret) mérete változik, az ecset mérete állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint ugyanígy viselkedik a szövegekkel is:

![ink_powerpoint6](ink_powerpoint6.png)

**További olvasnivaló**

* Az alakzatokról általánosságban a [PowerPoint alakzatok](https://docs.aspose.com/slides/hu/net/powerpoint-shapes/) szakaszban olvashat. 
* A hatékony értékekkel kapcsolatos további információkért lásd a [Alakzat hatékony tulajdonságai](https://docs.aspose.com/slides/hu/net/shape-effective-properties/#get-effective-font-height-value) szakaszt.