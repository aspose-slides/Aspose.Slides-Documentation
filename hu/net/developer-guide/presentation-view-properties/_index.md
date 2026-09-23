---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése .NET‑ben
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
- egyedi nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET nézet tulajdonságait, hogy testreszabhassa a PPT, PPTX és ODP diák formátumait—állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalomrégióból áll: a dia maga, egy oldalsó tartalomrégió, és egy alsó tartalomrégió. A különböző tartalomrégiók elhelyezésével kapcsolatos tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy elmentse a nézet állapotát a fájlba, így a megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutatót utoljára elmentették.

A [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/iviewproperties/properties/normalviewproperties) property hozzá lett adva, hogy hozzáférést biztosítson a bemutató normál nézet tulajdonságaihoz.  

[INormalViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/inormalviewrestoredproperties) interfészei és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/net/aspose.slides/splitterbarstatetype) felsorolt enum hozzá lett adva.

## **Az INormalViewProperties leírása**

A normál nézet tulajdonságait képviseli.

A **ShowOutlineIcons** property azt határozza meg, hogy az alkalmazás ikonokat jelenítsen-e meg, ha a körvonal tartalmat bármelyik tartalomrégióban a normál nézet módban jeleníti meg.

A **SnapVerticalSplitter** property azt határozza meg, hogy a függőleges elválasztó pálca minimalizált állapotba „csapódjon‑be”, ha az oldalsó régió elég kicsi.

A **PreferSingleView** property azt határozza meg, hogy a felhasználó inkább egy teljes ablakot kitöltő egyetlen tartalomrégiót szeretne-e a három tartalomrégiós szabványos normál nézet helyett. Ha engedélyezve van, az alkalmazás egy tartalomrégiót megjeleníthet az egész ablakban.

A **VerticalBarState** és **HorizontalBarState** propertyk azt az állapotot határozzák meg, amelyben a függőleges vagy vízszintes elválasztó pálcát meg kell jeleníteni. A vízszintes elválasztó pálca elválasztja a diát a dia alatti tartalomrégiótól, a függőleges elválasztó pálca elválasztja a diát az oldalsó tartalomrégiótól. Lehetséges értékek: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** és **SplitterBarStateType.Restored**.

A **RestoredLeft** és **RestoredTop** propertyk a normál nézet felső vagy oldalsó diarégiójának méretezését határozzák meg, amikor a **VerticalBarState** és **HorizontalBarState** megfelelően a **SplitterBarStateType.Restored** értéket kapja.

## **Az INormalViewProperties helyreállításáról**

Meghatározza a diarégió (szélesség, ha a RestoredTop gyermekéről van szó, magasság, ha a RestoredLeft gyermekéről van szó) méretét a normál nézetben, amikor a régió változó, visszaállított méretű (sem minimalizált, sem maximalizált) állapotban van.

A **DimensionSize** property a diarégió méretét határozza meg (szélesség, ha a restoredTop gyermekéről van szó, magasság, ha a restoredLeft gyermekéről van szó).

A **AutoAdjust** property azt határozza meg, hogy az oldalsó tartalomrégió mérete kompenzálja‑e az új méretet, amikor a nézetet tartalmazó ablakot átméretezik az alkalmazásban.

Az alábbi példa bemutatja, hogyan érheti el a **ViewProperties.NormalViewProperties** propertyket egy bemutatóhoz.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Állítsa vissza a bemutató nézet tulajdonságait
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Az Alapértelmezett Nagyítási Szint Beállítása**

Az Aspose.Slides for .NET most már támogatja az alapértelmezett nagyítási szint beállítását a bemutatóhoz, így a bemutató megnyitásakor a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties) beállításával történhet meg egy bemutatónál. A dia nézet tulajdonságai, valamint a [NotesViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties/properties/notesviewproperties) programozottan beállíthatók. Ebben a témában egy példán keresztül megmutatjuk, hogyan állítható be a Bemutató View tulajdonságai az Aspose.Slides‑ben.

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból
1. Állítsa be a Bemutató [Properties](https://reference.aspose.com/slides/hu/net/aspose.slides/viewproperties) tulajdonságait
1. Írja ki a bemutatót PPTX fájlként

Az alábbi példában beállítottuk a nagyítási értéket a dia nézethez és a jegyzet nézethez egyaránt.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // A bemutató nézet tulajdonságainak beállítása
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Nagyítási érték százalékban a dia nézethez
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Nagyítási érték százalékban a jegyzet nézethez 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Rács Távolság Beállítása**

Használja a [Presentation.ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/viewproperties/) elemet a bemutató szintű nézetbeállítások eléréséhez. Az [IViewProperties.GridSpacing](https://reference.aspose.com/slides/hu/net/aspose.slides/iviewproperties/gridspacing/) property az alapul szolgáló szerkesztő rács intervallumát olvassa vagy módosítja. Ez a beállítás az egész bemutatóra vonatkozik, nem egyedi diára. A rács távolság pontokban van megadva, ahol 72 pont egy hüvelyknek felel meg. Pozitív értéket használjon, ahogyan azt az API dokumentációja előírja.

Az alábbi példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rács távolságot, negyed hüvelykes intervallumra állítja, majd elmenti az eredményt.

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

A rács különbözik a [drawing guides](/slides/hu/net/drawing-guides/)-tól. A rács távolság szabályos intervallumot szabályoz, míg a rajzoló segédvonalak egyenként elhelyezett vízszintes vagy függőleges igazító vonalak. A segédvonalak hozzáadása, mozgatása vagy törlése nem változtatja meg a rács távolságát.

Mind a rács, mind a rajzoló segédvonalak szerkesztési segédeszközök. Nem jelennek meg diatartalomként PDF‑ben, képeken, SVG‑ben vagy diavetítésben. A rács távolság tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **Kommentárok Megjelenítése vagy Elrejtése a Bemutató Megnyitásakor**

Használja a [Presentation.ViewProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/viewproperties/) elemet a bemutató szintű nézetbeállítások eléréséhez. Olvassa vagy módosítsa az [IViewProperties.ShowComments](https://reference.aspose.com/slides/hu/net/aspose.slides/iviewproperties/showcomments/) propertyt, hogy tárolja, a kommentárokat meg kell‑e jeleníteni, amikor a bemutató megnyílik a PowerPoint‑ban vagy egy másik kompatibilis szerkesztőben.

Ez a beállítás csak a tárolt nézetpreferenciát szabályozza. Nem ad hozzá, nem távolít el, nem szerkeszt és nem old meg kommentárokat. A kommentárok elrejtése megőrzi azok tartalmát, szerzőit, pozícióit, válaszait és állapotát. Lásd a [Presentation Comments](/slides/hu/net/presentation-comments/) oldalt a kommentárok magukon végzett műveletekhez.

Az alábbi példához egy meglévő `comments.pptx` fájlra van szükség, amely tartalmaz kommentárokat. Kiírja a jelenlegi láthatósági beállítást, kéri a kommentárok elrejtését, és ment egy új PPTX‑et anélkül, hogy bármely kommentárt eltávolítana. Emellett beállítja az [IViewProperties.LastView](https://reference.aspose.com/slides/hu/net/aspose.slides/iviewproperties/lastview/) propertyt a [ViewType.SlideView](https://reference.aspose.com/slides/hu/net/aspose.slides/viewtype/) értékre, hogy az első szerkesztői nézetet a kommentár láthatóságával együtt konfigurálja.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Ez a beállítás nem határozza meg, hogy a kommentárok szerepelnek‑e a PDF, HTML, kép, jegyzet vagy szórólap exportokban. A megfelelő export‑specifikus beállításokat külön kell konfigurálni.

## **GYIK**

**Miért nem látható a rács a bemutató újranyitása után?**  
A fájl tárolja a rács távolságát, de a szerkesztő dönt arról, hogy a rács megjelenik‑e. Ellenőrizze a szerkesztő rács‑láthatósági beállításait.

**A rajzoló segédvonalak törlése megváltoztatja‑e a rács távolságát?**  
Nem. A rajzoló segédvonalak és a rács távolság független beállítások. A segédvonalak törlése nem módosítja a tárolt rács intervallumot.

**Beállíthatok‑e különböző nézetbeállításokat a bemutató különböző szakaszaihoz?**  
A nézetbeállítások a bemutató szintjén vannak definiálva (Normál nézet / Dia nézet), nem szakaszonként, ezért egyetlen paraméterkészlet vonatkozik a teljes dokumentumra a megnyitáskor.

**Előre meghatározhatok‑e különböző nézetállapotokat különböző felhasználóknak?**  
Nem. A beállítások a fájlban vannak tárolva, és megosztottak. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de a fájl maga csak egy nézet‑tulajdonság‑készletet tartalmaz.

**Létrehozhatok‑e sablont előre definiált View Property‑kkel, hogy az új bemutatók ugyanúgy nyíljanak meg?**  
Igen. Mivel a view property‑k a bemutató szintjén vannak tárolva, beágyazhatja őket egy sablonba, és új dokumentumok létrehozásakor ugyanazzal a kezdeti nézet‑konfigurációval indulnak.