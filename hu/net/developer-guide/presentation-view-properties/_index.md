---
title: Prezentáció nézet tulajdonságainak lekérdezése és frissítése .NET-ben
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
- egyes nézet
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
description: "Az Aspose.Slides for .NET segítségével konfigurálhatja a normál nézet elrendezését, a diák és a jegyzetek nagyítását, a rács távolságát, valamint a megjegyzések láthatóságát PowerPoint prezentációkban."
---
## **Bevezetés**

PowerPoint normál nézetében a dia a bélyegkép‑ vagy vázlat oldalsó ablaktábla és az alatti jegyzetablak között jelenik meg. Az Aspose.Slides for .NET a prezentáció mentett szerkesztési beállításait teszi elérhetővé a [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Ezek közé tartozik az ablaktábla elrendezése, a nagyítási szintek, a rács távolság és a megjegyzések láthatósága.

## **Az INormalViewProperties**

Használja a [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) a [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) interfész eléréséhez. [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) szabályozza, hogy ikonok jelenjenek‑e a dia címek mellett a vázlatban. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) lehetővé teszi, hogy az oldalsó ablaktábla a minimalizált állapothoz rögzítve legyen, amikor a felhasználó szűkíti. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) jelzi a preferenciát, hogy egy ablaktábla jelenjen meg a teljes ablakban.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) szabályozza az oldalsó ablaktábla és a dia közötti elválasztót. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) szabályozza a jegyzetablak feletti elválasztót. Mindkettő elfogad egy [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) értéket: `Minimized`, `Maximized` vagy `Restored`.

## **Az INormalViewProperties helyreállítása**

Amikor egy elválasztót helyreállítanak, a [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) a mentett oldalsó ablaktábla méretét, a [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) a felső diaszekció mentett méretét adja. Mindkettő [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/)‑t tesz elérhetővé. Ennek a [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/)‑nek az értéke 0‑tól 100‑ig terjedő százalék, a [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) szabályozza, hogy a szerkesztő módosítsa‑e a méretet az ablak átméretezésekor.

Ez a példa egy meglévő prezentációt frissít. Visszaállítja a horizontális elválasztót, a [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) értékét 80 %-ra állítja automatikus igazítással, és maximalizálja a vertikális elválasztót. Emellett engedélyezi a [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) funkciót a vázlat nézethez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Alapértelmezett nagyítási érték beállítása**

A [SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) és a [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) független nagyítási beállításokat tárolnak a szerkesztő számára. Ezek a beállítások nem befolyásolják a dia méreteit, a diavetítés lejátszását vagy a képexport felbontását.

Ez a példa megnyit egy meglévő prezentációt, és engedélyezi a [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/)‑t, hogy a dia a szerkesztő ablakához igazodjon. A jegyzetoldalhoz letiltja az automatikus méretezést, és a [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) értékét rögzített 80 %-os nagyításra állítja.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Rács távolság beállítása**

A [GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) beállítja a szerkesztői rácsvonalak közötti távolságot a teljes prezentációban. Pozitív értéket vár pontban, 72 pont hüvelykenként. Ez a példa kiírja a jelenlegi távolságot egy meglévő prezentációban, és egy negyed hüvelykes rácsot ment 18 pontos intervállal.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

A rács rögzített intervállal ismétlődik. A [Rajzsegédletek](/slides/hu/net/drawing-guides/) egyedi vízszintes vagy függőleges pozíciókat jelöl. Mindkettő szerkesztési segédeszköz, és csak azokban a szerkesztőkben jelenik meg, amelyek támogatják. A diavetítések és a PDF‑, kép‑ vagy SVG‑exportok nem tartalmazzák őket.

## **Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor**

A [ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) egy olyan preferenciát tárol, amelyet a kompatibilis szerkesztők a prezentáció megnyitásakor használnak. Egy megjegyzésekkel rendelkező meglévő prezentáció esetén ez a példa kiírja a jelenlegi beállítást, és egy példányt ment el a megjegyzések elrejtésével. Emellett a [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) értékét a [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/)‑ra állítja, így a példány dianézetben nyílik meg.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

A megjegyzések elrejtése megőrzi azok szövegét, szerzőjét, pozícióját, válaszait és állapotát. A megjegyzések módosításához lásd a [Prezentációs megjegyzések](/slides/hu/net/presentation-comments/) oldalt. Az exportálási beállítások szabályozzák, hogy a megjegyzések megjelennek‑e PDF‑ben, HTML‑ben, képekben, jegyzetekben vagy kézikönyvekben.

## **GYIK**

**Miért rejtőzik a rács, amikor újra megnyitom a prezentációt?**  
A prezentáció tárolja a rács intervallumát. A rács megtekintéséhez engedélyezze a rács láthatóságát a szerkesztőben.

**A rajzsegédletek törlése megváltoztatja a rács távolságát?**  
Nem. Egy segédlet hozzáadása, mozgatása vagy törlése nem változtatja meg a rács intervallumát.

**Lehetnek a prezentáció különböző részei eltérő nézetbeállításokkal?**  
Nem. A [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) a teljes prezentációra vonatkozik.

**Menthetek különböző nézetbeállításokat különböző felhasználók számára?**  
A fájl egyetlen nézetbeállítás‑készletet tárol mindenki számára. Egy szerkesztő továbbá alkalmazhatja a felhasználó helyi preferenciáit.

**Menthetek nézetbeállításokat sablonba?**  
Igen. A sablonból létrehozott prezentációk öröklik a sablon mentett nézetbeállításait.