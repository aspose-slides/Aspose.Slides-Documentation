---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése .NET-ben
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/net/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egyetlen nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET nézet tulajdonságait, hogy testreszabja a PPT, PPTX és ODP formátumú diák megjelenését – állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: a diákról magáról, egy oldalsó tartalomterületről és egy alsó tartalomterületről. A különböző tartalomterületek elhelyezésével kapcsolatos tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy a nézetállapotot a fájlba mentse, így megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutatót utoljára elmentették.

Az [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/iviewproperties/properties/normalviewproperties) tulajdonság hozzá lett adva, hogy hozzáférést biztosítson a bemutató normál nézetének tulajdonságaihoz.  

Az [INormalViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/inormalviewrestoredproperties) interfészek és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/net/aspose.slides/splitterbarstatetype) enumeráció hozzá lett adva.

## **Az INormalViewProperties névjegye**

A normál nézet tulajdonságait képviseli.

A **ShowOutlineIcons** tulajdonság megadja, hogy az alkalmazás ikonokat jelenítsen-e, ha a vázlat tartalmat a normál nézet bármelyik tartalomterületén jeleníti meg.

A **SnapVerticalSplitter** tulajdonság megadja, hogy a függőleges elválasztó a mellékleges terület elég kicsi méretekor minimalizált állapotba ragadjon-e.

A **PreferSingleView** tulajdonság megadja, hogy a felhasználó a teljes ablakot egyetlen tartalomterülettel szeretné-e a három tartalomterületből álló szabványos normál nézet helyett. Ha engedélyezve van, az alkalmazás eldöntheti, hogy egy tartalomterületet az egész ablakban jelenít meg.

A **VerticalBarState** és **HorizontalBarState** tulajdonságok megadják, hogy a vízszintes vagy függőleges elválasztó sáv milyen állapotban legyen látható. A vízszintes elválasztó sáv elválasztja a diát a diától alul lévő tartalomterülettől, a függőleges elválasztó sáv elválasztja a diát az oldalsó tartalomterülettől. Lehetséges értékek: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** és **SplitterBarStateType.Restored**.

A **RestoredLeft** és **RestoredTop** tulajdonságok megadják a normál nézet felső vagy oldalsó diaterületének méretét, amikor a **VerticalBarState** vagy **HorizontalBarState** értéke **SplitterBarStateType.Restored**.

## **Az INormalViewProperties helyreállításáról**

Meghatározza a diaterület (szélesség, ha a RestoredTop gyermekeként, magasság, ha a RestoredLeft gyermekeként) méretét a normál nézetben, amikor a terület változó visszaállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A **DimensionSize** tulajdonság megadja a diaterület méretét (szélesség, ha a restoredTop gyermek, magasság, ha a restoredLeft gyermek).

A **AutoAdjust** tulajdonság megadja, hogy az oldalsó tartalomterület mérete kompenzálja-e az új méretet, amikor az alkalmazáson belüli nézetet tartalmazó ablak méretét módosítják.

Az alábbi példában látható, hogyan férhet hozzá egy bemutató **ViewProperties.NormalViewProperties** tulajdonságaihoz.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // A bemutató nézet tulajdonságainak helyreállítása
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Alapértelmezett nagyítási érték beállítása**

Aspose.Slides for .NET most már támogatja a bemutató alapértelmezett nagyítási értékének beállítását, így a bemutató megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties) beállításával valósítható meg egy bemutatóban. A Diánézet tulajdonságai, valamint a [NotesViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/properties/notesviewproperties) programozottan beállíthatók. Ebben a témában egy példán keresztül megmutatjuk, hogyan állíthatók be a bemutató nézet tulajdonságai az Aspose.Slides-ben.

A nézet tulajdonságok beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból
1. Állítsa be a bemutató nézet [Properties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties)
1. Írja a bemutatót PPTX fájlként

Az alábbi példában beállítottuk a nagyítási értéket a diánézethez és a jegyzetnézethez is.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // A bemutató nézet tulajdonságainak beállítása
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Nagyítás százalékban a diánézethez
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Nagyítás százalékban a jegyzetnézethez 
    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Rács távolság beállítása**

Használja a [Presentation.ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/viewproperties/) elemet a bemutató szintű nézetbeállítások eléréséhez. Az [IViewProperties.GridSpacing](https://reference.aspose.com/slides/hu/net/aspose.slides/iviewproperties/gridspacing/) tulajdonság lekéri vagy módosítja az alaptól függő szerkesztő rács intervallumát. Ez a beállítás az egész bemutatóra vonatkozik, nem egyetlen diára. A rácstávolság pontokban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogyan az API dokumentáció megköveteli.

A következő példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rácstávolságot, egy negyed hüvelykes intervallumot állít be, és elmenti az eredményt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

A rács eltér a [drawing guides](/slides/hu/net/drawing-guides/) elemtől. A rácstávolság egy szabályos intervallumot szabályoz, míg a rajzoló segédvonalak egyenként elhelyezett vízszintes vagy függőleges igazító vonalak. A segédvonalak hozzáadása, mozgatása vagy törlése nem változtatja meg a rácstávolságot.

A rács és a rajzoló segédvonalak egyaránt szerkesztési segédeszközök. Nem jelennek meg diatartalomként PDF-ben, képekben, SVG-ben vagy diavetítésben. A rácstávolság tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **GYIK**

**Miért nem látható a rács, miután újra megnyitottam a bemutatót?**  
A fájl tárolja a rácstávolságot, de a szerkesztő szabályozza, hogy a rács megjelenik-e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**Megváltoztatja-e a rajzoló segédvonalak törlése a rácstávolságot?**  
Nem. A rajzoló segédvonalak és a rácstávolság független beállítások. A segédvonalak törlése változatlanul hagyja a tárolt rácsintervallumot.

**Beállíthatok-e különböző nézetbeállításokat a bemutató különböző szakaszaira?**  
A [View settings](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/viewproperties/) a bemutató szintjén vannak meghatározva ([Normal View](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/slideviewproperties/)), nem szakaszonként, ezért egyetlen paraméterkészlet érvényes a dokumentum egészére a megnyitáskor.

**Előre definiálhatok-e különböző nézetállapotokat különböző felhasználók számára?**  
Nem. A beállítások a fájlban vannak tárolva és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl maga csak egy nézettulajdonság-készletet tartalmaz.

**Elkészíthetek-e egy sablont előre definiált nézet tulajdonságokkal, hogy az új bemutatók ugyanúgy nyíljanak meg?**  
Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/viewproperties/) a bemutató szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumokat hozhat létre belőle ugyanazzal a kiinduló nézetkonfigurációval.