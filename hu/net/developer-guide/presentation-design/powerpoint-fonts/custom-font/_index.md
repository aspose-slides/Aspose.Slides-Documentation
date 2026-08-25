---
title: PowerPoint betűkészletek testreszabása .NET-ben
linktitle: Egyéni betűkészlet
type: docs
weight: 20
url: /hu/net/custom-font/
keywords:
- betűkészlet
- egyéni betűkészlet
- külső betűkészlet
- betűkészlet betöltése
- betűkészletek kezelése
- betűkészlet mappa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Testreszabhatja a betűkészleteket a PowerPoint diákon az Aspose.Slides for .NET segítségével, hogy prezentációi minden eszközön élesek és konzisztens megjelenést biztosítsanak."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűkészletek használatát a prezentációkban anélkül, hogy telepítené őket az operációs rendszerre. Betűkészleteket tölthet be egyéni mappákból, megadhat betűkészleteket egy adott prezentációhoz dokumentumszintű betűkészlet‑forrásokkal, vagy betöltheti a külső betűkészleteket közvetlenül bináris adatokból.

A betöltött betűkészleteket a prezentáció renderelésekor vagy exportálásakor használja, például PDF‑hez, képekhez és más támogatott formátumokhoz. Ez segít az eredmény konzisztens megjelenésének fenntartásában különböző környezetekben. A cikk bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűkészlet‑mappákat, és hogyan törölheti a betűkészlet‑gyorsítót a külső betűkészletekkel dolgozás után.

A betűkészletek rendereléshez történő regisztrálása különbözik a betűkészletek PPTX‑fájlba ágyazásától. Ha a betűkészletet magában a prezentációban kell tárolni, használja a betűkészlet‑ágyazási funkciókat kifejezetten.

Egy prezentáció témája különböző írásrendszerek számára hivatkozhat külön betűcsaládokra. Ezek a leképezések csak betűneveket tárolnak, de nem telepítik vagy töltik be a betűkészlet‑fájlokat. Tekintse meg a [Script‑Specific Theme Fonts](/slides/hu/net/script-specific-font-mappings/) oldalt a leképezések kezeléséhez, és használja az alábbi betöltési beállításokat, hogy a hivatkozott betűkészletek elérhetők legyenek a konzisztens rendereléshez.

{{% alert color="info" title="Note" %}}
Az Aspose Slides a [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) metódussal teszi lehetővé ezen betűkészletek betöltését:

* TrueType (.ttf) és TrueType Collection (.ttc) betűkészletek. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) szócikket.

* OpenType (.otf) betűkészletek. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) szócikket.
{{% /alert %}}

## **Egyéni betűkészletek betöltése**

Az Aspose.Slides lehetővé teszi, hogy a prezentációban használt betűkészleteket betöltse a rendszerre való telepítés nélkül. Ez befolyásolja az exportkimenetet – például PDF, képek és egyéb támogatott formátumok – így a létrejött dokumentumok minden környezetben egységesen jelennek meg. A betűkészleteket egyéni könyvtárakból tölti be.

1. Adjon meg egy vagy több mappát, amely a betűkészlet‑fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) metódust a megadott mappák betöltéséhez.
3. Töltse be és renderelje/exportálja a prezentációt.
4. Hívja meg a [FontsLoader.ClearCache](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/clearcache/) metódust a betűkészlet‑gyorsítótörléshez.

Az alábbi kódrészlet bemutatja a betűkészlet‑betöltési folyamatot:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Határozza meg az egyéni betűkészlet fájlokat tartalmazó mappákat.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Töltse be az egyéni betűkészleteket a megadott mappákból.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderelje/exportálja a prezentációt (például PDF-be, képekbe vagy más formátumokba) a betöltött betűkészletek használatával.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Törölje a betűkészlet gyorsítótárát a munka befejezése után.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűkészlet‑keresési útvonalakhoz, de nem változtatja meg a betűkészlet‑inicializálási sorrendet.
A betűkészletek ezen a sorrenden inicializálódnak:

1. Az operációs rendszer alapértelmezett betűkészlet‑útvonala.  
1. A [FontsLoader](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyéni betűkészlet‑mappák lekérése**
Az Aspose.Slides a [GetFontFolders](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/getfontfolders/) metódust biztosítja, amely lehetővé teszi a betűkészlet‑mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metódussal hozzáadott mappákat és a rendszer betűkészlet‑mappákat.

Ez a C# kód bemutatja a [GetFontFolders](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/getfontfolders/) használatát:

```c#
using Aspose.Slides;

// Ez a sor kiírja azokat a mappákat, amelyekben a betűkészlet fájlok keresése történik.
// Ezek a LoadExternalFonts metódussal hozzáadott mappák és a rendszer betűkészlet mappái.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Egyéni betűkészletek megadása egy prezentációhoz**
Az Aspose.Slides a [DocumentLevelFontSources](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/documentlevelfontsources/) tulajdonságot biztosítja, amely lehetővé teszi külső betűkészletek megadását a prezentációhoz.

Ez a C# kód bemutatja a [DocumentLevelFontSources](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/documentlevelfontsources/) használatát:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // A prezentációval dolgozz
    // A CustomFont1, CustomFont2, valamint az assets\fonts és global\fonts mappák és azok alkönyvtáraiban található betűkészletek elérhetők a prezentáció számára
}
```

## **Betűkészletek külső kezelése**

Az Aspose.Slides a [LoadExternalFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) metódust biztosítja, amely lehetővé teszi a külső betűkészletek betöltését bináris adatokból.

Ez a C# kód bemutatja a bájt‑tömb‑alapú betűkészlet‑betöltési folyamatot:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // külső betűkészlet betöltve a prezentáció életciklusa alatt
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **GYIK**

**A egyéni betűkészletek befolyásolják az összes formátumú exportot (PDF, PNG, SVG, HTML)?**

Igen. A csatlakoztatott betűkészleteket a renderelő minden exportformátumban használja.

**A egyéni betűkészletek automatikusan beágyazódnak a létrejövő PPTX‑be?**

Nem. A betűkészlet regisztrálása a rendereléshez nem ugyanaz, mint a PPTX‑be ágyazása. Ha a betűkészletet a prezentációs fájlban kell tárolni, használja a kifejezett [embedding features](/slides/hu/net/embedded-font/) lehetőséget.

**Szabályozhatom a helyettesítési viselkedést, ha egy egyéni betűkészlet nem tartalmaz bizonyos glifeket?**

Igen. Állítsa be a [font substitution](/slides/hu/net/font-substitution/), [replacement rules](/slides/hu/net/font-replacement/) és [fallback sets](/slides/hu/net/fallback-font/) beállításokat, hogy pontosan meghatározza, mely betűkészletet használja a hiányzó glif esetén.

**Használhatok betűkészleteket Linux/Docker konténerekben anélkül, hogy rendszerszinten telepíteném őket?**

Igen. Hivatkozhat a saját betűkészlet‑mappáira, vagy betöltheti a betűkészleteket bájt‑tömbökből. Ez eltávolítja a rendszer betűkészlet‑könyvtárakra való függőséget a konténer‑képből.

> **Megjegyzés Linux/Docker esetén**: A `FontsLoader.LoadExternalFonts` hívásakor győződjön meg róla, hogy a `directories` tömb minden eleme nem üres útvonalat tartalmaz egy létező könyvtárhoz. Ha a betűkészlet‑útvonalat összeállító környezeti változó nincs definiálva vagy üres, az Aspose.Slides megpróbálhatja az üres értéket teljes útvonalként feloldani, ami `System.ArgumentException`‑t eredményez.

**Mi a helyzet a licenceléssel – beágyazhatok bármilyen egyéni betűkészletet korlátozások nélkül?**

Ön felelős a betűkészlet‑licencének betartásáért. A feltételek változóak; egyes licencelések tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűkészlet EULA‑ját, mielőtt terjesztené a kimeneteket.