---
title: "Tinta objektumok kezelése prezentációkban Python segítségével"
linktitle: "Tinta kezelése"
type: docs
weight: 95
url: /hu/python-net/manage-ink/
keywords:
- tinta
- tintaobjektum
- tinta nyomvonal
- tinta kezelése
- tinta rajzolása
- rajzolás
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Kezelje a PowerPoint tinta objektumokat — hozza létre, szerkessze és formázza a digitális tintát az Aspose.Slides for Python via .NET segítségével. Szerezzen kódmintákat a nyomvonalakhoz, ecset színhez és mérethez."
---
## **Bevezetés**

A PowerPoint rendelkezik a tinta funkcióval, amely lehetővé teszi, hogy nem szabványos alakzatokat rajzolj, melyeket más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint egy dián belüli konkrét elemek figyelemfelkeltésére használhatsz. 

Az Aspose.Slides biztosítja a [aspose.slides.ink](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/) névteret, amely tartalmazza a tintatípusok létrehozásához és kezeléséhez szükséges típusokat. 

## **Különbségek a szabályos objektumok és a tintaobjektumok között**

PowerPoint diákon lévő objektumok általában alakzatobjektumokként jelennek meg. Egy alakzatobjektum legegyszerűbben egy tároló, amely meghatározza magának az objektumnak a területét (a keretét) a tulajdonságaival együtt. Az utóbbi tartalmazza a tároló területméretét, a tároló alakját, a tároló háttérszínét stb. További információkért lásd a [Shape Layout Format](https://docs.aspose.com/slides/hu/python-net/shape-manipulations/#access-layout-formats-for-shape) oldalát.

Azonban amikor a PowerPoint egy tintaobjektummal dolgozik, figyelmen kívül hagyja a keret (tároló) összes tulajdonságát, kivéve a méretét. A tároló terület mérete a szabványos `width` és `height` értékek alapján határozható meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintaalakú nyomvonalak**

A nyomvonal egy alapvető elem vagy szabvány, amely a toll útvonalát rögzíti, amikor a felhasználó digitális tintát ír. A nyomvonalak felvételek, amelyek összekapcsolt pontok sorozatát írják le. 

A kódolás legegyszerűbb formája minden mintapont X és Y koordinátáit adja meg. Ha az összekapcsolt pontok megjelennek, egy ilyesféle képet hoznak létre:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecsettulajdonságok a rajzoláshoz**

Ecsetet használhatsz a nyomvonal elemeinek pontjait összekötő vonalak rajzolásához. Az ecsetnek saját színe és mérete van, ami a `Brush.color` és `Brush.size` tulajdonságoknak felel meg. 

### **Tintaecset színének beállítása**

Ezt a Python kódot használva megtekintheted, hogyan állítható be egy ecset színe:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Tintaecset méretének beállítása** 

Ezt a Python kódot használva megtekintheted, hogyan állítható be egy ecset mérete:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Általában egy ecset szélessége és magassága nem egyezik, ezért a PowerPoint nem jeleníti meg az ecset méretét (az adatmező szürkén jelenik meg). Ha azonban az ecset szélessége és magassága megegyezik, a PowerPoint a méretet a következőképpen jeleníti meg:

![ink_powerpoint3](ink_powerpoint3.png)

Átláthatóság kedvéért növeljük meg a tintaobjektum magasságát, és tekintsük át a fontos méreteket: 

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig azt feltételezi, hogy a vonal vastagsága nulla (lásd az utolsó képet). 

Ezért a teljes tintaobjektum látható területének meghatározásához figyelembe kell venni a nyomvonalobjektumok ecsetméretét. Itt a célobjektum (a kézzel írott szöveg nyomvonalobjektuma) a tároló (keret) méretéhez van méretezve. Amikor a tároló (keret) mérete változik, az ecset mérete állandó marad, és fordítva. 

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint ugyanúgy viselkedik, amikor szövegekkel dolgozik:

![ink_powerpoint6](ink_powerpoint6.png)

**További olvasmányok**

* A formákról általánosságban a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/python-net/powerpoint-shapes/) szekcióban olvashatsz. 
* A hatékony értékekkel kapcsolatos további információkért lásd a [Shape Effective Properties](https://docs.aspose.com/slides/hu/python-net/shape-effective-properties/#get-effective-font-height-value) dokumentumot.