---
title: Jegyzetlap méretének és tájolásának módosítása .NET‑ben
linktitle: Jegyzetlap mérete
type: docs
weight: 10
url: /hu/net/notes-size/
keywords:
- jegyzetlap mérete
- jegyzet tájolás
- fekvő jegyzetek
- álló jegyzetek
- kézbesítő mérete
- PowerPoint
- prezentáció
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Olvassa el és módosítsa a jegyzetlap méreteit az Aspose.Slides for .NET‑ben, váltson tájolást, ellenőrizze a mentett méreteket, és exportálja a jegyzeteket vagy kézbesítőket PDF‑be és képekbe."
---
## **Áttekintés**

Használja a [Presentation.NotesSize](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/notessize/) objektumot a prezentáció jegyzetlap beállításainak eléréséhez. Ez egy [INotesSize](https://reference.aspose.com/slides/hu/net/aspose.slides/inotessize/) objektumot ad vissza, amelynek a [Size](https://reference.aspose.com/slides/hu/net/aspose.slides/inotessize/size/) tulajdonsága írható. Bár magának a beállítási objektumnak csak olvasható a hozzáférése, új méreteket rendelhet a méret tulajdonságához.

Szélesség és magasság **pont**‑ban van megadva, ahol hüvelykenként 72 pont van. Például a 900 × 600 pont 12,5 × 8⅓ hüvelyknek felel meg. Ezek a beállítások a prezentációra vonatkoznak, nem egy adott dia jegyzeteire.

| Beállítás | Cél |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/notessize/) | A jegyzetlap méreteit és a kézbesítő exporthoz használt oldalméreteket szabályozza. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slidesize/) | A szokásos prezentációs diák méreteit szabályozza az [ISlideSize](https://reference.aspose.com/slides/hu/net/aspose.slides/islidesize/) segítségével. |

Az egyik beállítás módosítása nem változtatja meg automatikusan a másikat. A jegyzetlap tájolásának módosítása szintén nem forgatja el a szokásos diákat. Lásd a [Slide Size](/slides/hu/net/slide-size/) oldalt a diák átméretezéséhez.

Az alábbi példák meglévő `sample.pptx` fájlt használnak. Az export példákhoz használjon egy olyan prezentációt, amelynek legalább egy dia beszélő jegyzetekkel rendelkezik. Minden példát önállóan futtathat.

## **Olvassa el a jegyzetlap méretét és tájolását**

Olvassa ki a szélességet és a magasságot, és hasonlítsa össze őket a tájolás meghatározásához: a szélesebb oldal fekvő, a magasabb álló, az egyenlő méretek négyzet alakú oldalt írnak le. Ez a példa a tényleges méreteket pontban írja ki, anélkül, hogy standard papírméretet feltételezne.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Váltás fekvőre a papírméret megváltoztatása nélkül**

A tájolás csak megváltoztatásához cserélje fel a meglévő szélességet és magasságot. Ez megőrzi mindkét oldal hosszát, beleértve az egyedi papírméretét is. Az alábbi feltétel megakadályozza, hogy egy már fekvő oldal visszaváljon állóra, és egy négyzet oldal változatlan maradjon.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Álló tájolás esetén használja ugyanazt a hozzárendelést, ha `size.Width > size.Height`. Ne helyettesítse A4 vagy Letter méretekkel, hacsak nem kívánja megváltoztatni a papírméretet is.

## **Egyedi jegyzetlap méretének beállítása és ellenőrzése**

Rendelje hozzá mindkét dimenziót egyszerre, majd használja a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódust a prezentáció írásához. Ez a példa egy 900 × 600 pontos fekvő oldalt állít be, PPTX‑ként menti, majd újra megnyitja a mentett fájlt az értékek ellenőrzéséhez. Az összehasonlítás 0,01 pont toleranciát enged meg a lebegőpontos értékeknél; ez nem garancia a pontosságra minden fájlformátumnál.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

A várt eredmény `900 x 600 points` és `Size preserved: True`. Egy frissen megnyitott prezentáció ellenőrzése a mentett fájlt hitelesíti, nem csak a memóriában lévő beállításokat.

## **Jegyzetek és kézbesítők exportálása**

Az oldalméretek határozzák meg a jegyzetek vagy kézbesítő elrendezések számára rendelkezésre álló területet. Ezek önmagukban nem aktiválják az elrendezéseket: konfigurálni kell az export beállításokat is. A szokásos diák exportálása továbbra is a diák méretét használja.

### **Jegyzetek exportálása PDF-be és PNG-be**

Rendelje hozzá a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notescommentslayoutingoptions/) objektumot a [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) tulajdonsághoz, hogy a PDF‑be belefoglalja a jegyzeteket. Ez a példa az első, jegyzetekkel rendelkező diát PNG‑be is rendereli a [Slide.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage/) és a [RenderingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/renderingoptions/) használatával.

A [BottomTruncated](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notespositions/) mód a jegyzeteket egy oldalon tartja; a nem férő jegyzetek levághatók. A PDF 900 × 600 pontos oldalakat használ. Az alább használt 1 × 1 képméretezésnél a PNG 900 × 600 pixel. A pontok az oldal geometriáját írják le; a pixelek a raszter kimenetet, amelynek méretei a renderelési skálától is függenek.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Hosszú jegyzetek PDF exportálásához a [BottomFull](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notespositions/) mód további oldalakat biztosít, ha szükséges. Ne használja ezt a módot a fent említett egydi dia kép hívással, mert az nem támogatja. Átméretezés után ellenőrizze a kimenetet, hogy a jegyzetek levágottak‑e, és a meglévő notes‑master objektumok elhelyezése; csak az oldalméretek módosítása nem garantálja, hogy minden tartalom elfér. További információkért lásd a [Convert PowerPoint to PDF with Notes](/slides/hu/net/convert-powerpoint-to-pdf-with-notes/) oldalt.

### **Kézbesítők exportálása PDF-be**

Használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handoutlayoutingoptions/) objektumot több dia bélyegkép egy oldalon elhelyezéséhez. A következő példa egy 900 × 600 pontos oldalt állít be, és a [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handouttype/) segítségével legfeljebb négy diát rendez el egy oldalon. A vízszintes előbeállítás a diasorrendet szabályozza; az oldal tájolása a szélességéből és magasságából ered.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Az oldalméret módosítása változtatja a kézbesítő rács rendelkezésre álló területét anélkül, hogy a forrásdiák méretét változtatná. Kézbesítő képekhez használja a [Presentation.GetImages](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/getimages/) metódust a kézbesítő elrendezéssel, ahelyett, hogy egyedi dia képmetódust alkalmazna. Az Aspose.Slides-ben a prezentáció‑szintű kézbesítő renderelés a jegyzetlap méreteit használja, míg az egyedi dia kép hívás nem hoz létre kézbesítő oldalt. A [Handout Mode](/slides/hu/net/convert-powerpoint-in-handout-mode/) oldalon megtalálhatók a elrendezési lehetőségek.

## **Oldalméret megjelenítőkben, exportálásnál és nyomtatásnál**

Az eltárolt prezentáció méretét, az exportált oldalméretet és a nyomtatott papírméretet külön válassza el:

- **Presentation viewers:** A megjelenítő megjelenítheti vagy nyomtathatja a jegyzeteket saját elrendezési szabályai alapján. Ha egy másik alkalmazás menti a fájlt, nyissa meg újra, és ellenőrizze a méreteket; az alkalmazás formátumkonverziója normalizálhatja azokat.
- **Export formats:** A fenti jegyzet és kézbesítő PDF példák a konfigurált oldalméreteket használják. A raszter képek egész pixelméreteket és egy renderelési skálát használnak, így a tört pont értékek kerekíthetők a képkimenetben. A szokásos diák exportálása nem alkalmazza a jegyzetlap méretét.
- **Printer drivers:** A papír kiválasztása, az automatikus forgatás és a méretezés‑az‑oldalra‑beállítások megváltoztathatják a fizikai kimenetet anélkül, hogy a prezentációban vagy a PDF‑ben tárolt méreteket módosítanák. Egy meghatározott papírméret esetén egyeztesse a nyomtató beállításait, és ellenőrizze a nyomtatási előnézetet.

## **GYIK**

**Beállíthatom a jegyzetek méretét csak egy diára?**

A jegyzetlap mérete a prezentáció‑szintű beállítás. Az egyes diák különböző jegyzettartalommal rendelkezhetnek, de ez a tulajdonság nem biztosít külön oldalméretet minden diára.

**Miért nem változott a diák a jegyzetek tájolásának módosítása után?**

A jegyzetoldalak és a szokásos diák méretei függetlenek egymástól. Használja a szokásos diák méretbeállításait, ha a diákat magukat szeretné átméretezni.

**Miért különbözik a mentett vagy nyomtatott eredmény mérete?**

Először nyissa meg újra a mentett prezentációt, és hasonlítsa össze a jegyzetek méreteit. Ha azok megváltoztak, ellenőrizze, hogy egy másik alkalmazásban való mentés vagy konvertálás módosította‑e az oldalbeállításokat. Ha nem, ellenőrizze az export elrendezését, a képméretarányt, a megjelenítő beállításait és a nyomtató papírválasztását.